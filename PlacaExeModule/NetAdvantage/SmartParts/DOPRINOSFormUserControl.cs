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
    public class DOPRINOSFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDDOPRINOS")]
        private UltraLabel _label1IDDOPRINOS;
        [AccessedThroughProperty("label1IDVRSTADOPRINOS")]
        private UltraLabel _label1IDVRSTADOPRINOS;
        [AccessedThroughProperty("label1MAXDOPRINOS")]
        private UltraLabel _label1MAXDOPRINOS;
        [AccessedThroughProperty("label1MINDOPRINOS")]
        private UltraLabel _label1MINDOPRINOS;
        [AccessedThroughProperty("label1MODOPRINOS")]
        private UltraLabel _label1MODOPRINOS;
        [AccessedThroughProperty("label1MZDOPRINOS")]
        private UltraLabel _label1MZDOPRINOS;
        [AccessedThroughProperty("label1NAZIVDOPRINOS")]
        private UltraLabel _label1NAZIVDOPRINOS;
        [AccessedThroughProperty("label1NAZIVVRSTADOPRINOS")]
        private UltraLabel _label1NAZIVVRSTADOPRINOS;
        [AccessedThroughProperty("label1OPISPLACANJADOPRINOS")]
        private UltraLabel _label1OPISPLACANJADOPRINOS;
        [AccessedThroughProperty("label1PODOPRINOS")]
        private UltraLabel _label1PODOPRINOS;
        [AccessedThroughProperty("label1PRIMATELJDOPRINOS1")]
        private UltraLabel _label1PRIMATELJDOPRINOS1;
        [AccessedThroughProperty("label1PRIMATELJDOPRINOS2")]
        private UltraLabel _label1PRIMATELJDOPRINOS2;
        [AccessedThroughProperty("label1PZDOPRINOS")]
        private UltraLabel _label1PZDOPRINOS;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJADOPRINOS")]
        private UltraLabel _label1SIFRAOPISAPLACANJADOPRINOS;
        [AccessedThroughProperty("label1STOPA")]
        private UltraLabel _label1STOPA;
        [AccessedThroughProperty("label1VBDIDOPRINOS")]
        private UltraLabel _label1VBDIDOPRINOS;
        [AccessedThroughProperty("label1ZRNDOPRINOS")]
        private UltraLabel _label1ZRNDOPRINOS;
        [AccessedThroughProperty("labelNAZIVVRSTADOPRINOS")]
        private UltraLabel _labelNAZIVVRSTADOPRINOS;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDDOPRINOS")]
        private UltraNumericEditor _textIDDOPRINOS;
        [AccessedThroughProperty("textIDVRSTADOPRINOS")]
        private UltraNumericEditor _textIDVRSTADOPRINOS;
        [AccessedThroughProperty("textMAXDOPRINOS")]
        private UltraNumericEditor _textMAXDOPRINOS;
        [AccessedThroughProperty("textMINDOPRINOS")]
        private UltraNumericEditor _textMINDOPRINOS;
        [AccessedThroughProperty("textMODOPRINOS")]
        private UltraTextEditor _textMODOPRINOS;
        [AccessedThroughProperty("textMZDOPRINOS")]
        private UltraTextEditor _textMZDOPRINOS;
        [AccessedThroughProperty("textNAZIVDOPRINOS")]
        private UltraTextEditor _textNAZIVDOPRINOS;
        [AccessedThroughProperty("textOPISPLACANJADOPRINOS")]
        private UltraTextEditor _textOPISPLACANJADOPRINOS;
        [AccessedThroughProperty("textPODOPRINOS")]
        private UltraTextEditor _textPODOPRINOS;
        [AccessedThroughProperty("textPRIMATELJDOPRINOS1")]
        private UltraTextEditor _textPRIMATELJDOPRINOS1;
        [AccessedThroughProperty("textPRIMATELJDOPRINOS2")]
        private UltraTextEditor _textPRIMATELJDOPRINOS2;
        [AccessedThroughProperty("textPZDOPRINOS")]
        private UltraTextEditor _textPZDOPRINOS;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJADOPRINOS")]
        private UltraTextEditor _textSIFRAOPISAPLACANJADOPRINOS;
        [AccessedThroughProperty("textSTOPA")]
        private UltraNumericEditor _textSTOPA;
        [AccessedThroughProperty("textVBDIDOPRINOS")]
        private UltraTextEditor _textVBDIDOPRINOS;
        [AccessedThroughProperty("textZRNDOPRINOS")]
        private UltraTextEditor _textZRNDOPRINOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDOPRINOS;
        private IContainer components = null;
        private DOPRINOSDataSet dsDOPRINOSDataSet1;
        protected TableLayoutPanel layoutManagerformDOPRINOS;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DOPRINOSDataSet.DOPRINOSRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DOPRINOS";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DOPRINOSDescription;
        private DeklaritMode m_Mode;

        public DOPRINOSFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptVRSTADOPRINOSIDVRSTADOPRINOS(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.DOPRINOSController.SelectVRSTADOPRINOSIDVRSTADOPRINOS(fillMethod, fillByRow);
            this.UpdateValuesVRSTADOPRINOSIDVRSTADOPRINOS(result);
        }

        private void CallViewVRSTADOPRINOSIDVRSTADOPRINOS(object sender, EventArgs e)
        {
            DataRow result = this.DOPRINOSController.ShowVRSTADOPRINOSIDVRSTADOPRINOS(this.m_CurrentRow);
            this.UpdateValuesVRSTADOPRINOSIDVRSTADOPRINOS(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceDOPRINOS.DataSource = this.DOPRINOSController.DataSet;
            this.dsDOPRINOSDataSet1 = this.DOPRINOSController.DataSet;
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
                    enumerator = this.dsDOPRINOSDataSet1.DOPRINOS.Rows.GetEnumerator();
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
                if (this.DOPRINOSController.Update(this))
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

        private void DOPRINOSFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DOPRINOSDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DOPRINOS", this.m_Mode, this.dsDOPRINOSDataSet1, this.dsDOPRINOSDataSet1.DOPRINOS.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDOPRINOSDataSet1.DOPRINOS[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DOPRINOSDataSet.DOPRINOSRow) ((DataRowView) this.bindingSourceDOPRINOS.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DOPRINOSFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDOPRINOS = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDOPRINOS).BeginInit();
            this.layoutManagerformDOPRINOS = new TableLayoutPanel();
            this.layoutManagerformDOPRINOS.SuspendLayout();
            this.layoutManagerformDOPRINOS.AutoSize = true;
            this.layoutManagerformDOPRINOS.Dock = DockStyle.Fill;
            this.layoutManagerformDOPRINOS.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDOPRINOS.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDOPRINOS.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDOPRINOS.Size = size;
            this.layoutManagerformDOPRINOS.ColumnCount = 2;
            this.layoutManagerformDOPRINOS.RowCount = 0x12;
            this.layoutManagerformDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOPRINOS.RowStyles.Add(new RowStyle());
            this.label1IDDOPRINOS = new UltraLabel();
            this.textIDDOPRINOS = new UltraNumericEditor();
            this.label1NAZIVDOPRINOS = new UltraLabel();
            this.textNAZIVDOPRINOS = new UltraTextEditor();
            this.label1IDVRSTADOPRINOS = new UltraLabel();
            this.textIDVRSTADOPRINOS = new UltraNumericEditor();
            this.label1NAZIVVRSTADOPRINOS = new UltraLabel();
            this.labelNAZIVVRSTADOPRINOS = new UltraLabel();
            this.label1STOPA = new UltraLabel();
            this.textSTOPA = new UltraNumericEditor();
            this.label1MODOPRINOS = new UltraLabel();
            this.textMODOPRINOS = new UltraTextEditor();
            this.label1PODOPRINOS = new UltraLabel();
            this.textPODOPRINOS = new UltraTextEditor();
            this.label1MZDOPRINOS = new UltraLabel();
            this.textMZDOPRINOS = new UltraTextEditor();
            this.label1PZDOPRINOS = new UltraLabel();
            this.textPZDOPRINOS = new UltraTextEditor();
            this.label1PRIMATELJDOPRINOS1 = new UltraLabel();
            this.textPRIMATELJDOPRINOS1 = new UltraTextEditor();
            this.label1PRIMATELJDOPRINOS2 = new UltraLabel();
            this.textPRIMATELJDOPRINOS2 = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJADOPRINOS = new UltraLabel();
            this.textSIFRAOPISAPLACANJADOPRINOS = new UltraTextEditor();
            this.label1OPISPLACANJADOPRINOS = new UltraLabel();
            this.textOPISPLACANJADOPRINOS = new UltraTextEditor();
            this.label1VBDIDOPRINOS = new UltraLabel();
            this.textVBDIDOPRINOS = new UltraTextEditor();
            this.label1ZRNDOPRINOS = new UltraLabel();
            this.textZRNDOPRINOS = new UltraTextEditor();
            this.label1MINDOPRINOS = new UltraLabel();
            this.textMINDOPRINOS = new UltraNumericEditor();
            this.label1MAXDOPRINOS = new UltraLabel();
            this.textMAXDOPRINOS = new UltraNumericEditor();
            ((ISupportInitialize) this.textIDDOPRINOS).BeginInit();
            ((ISupportInitialize) this.textNAZIVDOPRINOS).BeginInit();
            ((ISupportInitialize) this.textIDVRSTADOPRINOS).BeginInit();
            ((ISupportInitialize) this.textSTOPA).BeginInit();
            ((ISupportInitialize) this.textMODOPRINOS).BeginInit();
            ((ISupportInitialize) this.textPODOPRINOS).BeginInit();
            ((ISupportInitialize) this.textMZDOPRINOS).BeginInit();
            ((ISupportInitialize) this.textPZDOPRINOS).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJDOPRINOS1).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJDOPRINOS2).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJADOPRINOS).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJADOPRINOS).BeginInit();
            ((ISupportInitialize) this.textVBDIDOPRINOS).BeginInit();
            ((ISupportInitialize) this.textZRNDOPRINOS).BeginInit();
            ((ISupportInitialize) this.textMINDOPRINOS).BeginInit();
            ((ISupportInitialize) this.textMAXDOPRINOS).BeginInit();
            this.dsDOPRINOSDataSet1 = new DOPRINOSDataSet();
            this.dsDOPRINOSDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDOPRINOSDataSet1.DataSetName = "dsDOPRINOS";
            this.dsDOPRINOSDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDOPRINOS.DataSource = this.dsDOPRINOSDataSet1;
            this.bindingSourceDOPRINOS.DataMember = "DOPRINOS";
            ((ISupportInitialize) this.bindingSourceDOPRINOS).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDDOPRINOS.Location = point;
            this.label1IDDOPRINOS.Name = "label1IDDOPRINOS";
            this.label1IDDOPRINOS.TabIndex = 1;
            this.label1IDDOPRINOS.Tag = "labelIDDOPRINOS";
            this.label1IDDOPRINOS.Text = "Šifra doprinosa:";
            this.label1IDDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1IDDOPRINOS.AutoSize = true;
            this.label1IDDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1IDDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDOPRINOS.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDDOPRINOS.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDDOPRINOS.ImageSize = size;
            this.label1IDDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1IDDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1IDDOPRINOS, 0, 0);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1IDDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1IDDOPRINOS, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(110, 0x17);
            this.label1IDDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDDOPRINOS.Location = point;
            this.textIDDOPRINOS.Name = "textIDDOPRINOS";
            this.textIDDOPRINOS.Tag = "IDDOPRINOS";
            this.textIDDOPRINOS.TabIndex = 0;
            this.textIDDOPRINOS.Anchor = AnchorStyles.Left;
            this.textIDDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDDOPRINOS.ReadOnly = false;
            this.textIDDOPRINOS.PromptChar = ' ';
            this.textIDDOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDDOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceDOPRINOS, "IDDOPRINOS"));
            this.textIDDOPRINOS.NumericType = NumericType.Integer;
            this.textIDDOPRINOS.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformDOPRINOS.Controls.Add(this.textIDDOPRINOS, 1, 0);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textIDDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textIDDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVDOPRINOS.Location = point;
            this.label1NAZIVDOPRINOS.Name = "label1NAZIVDOPRINOS";
            this.label1NAZIVDOPRINOS.TabIndex = 1;
            this.label1NAZIVDOPRINOS.Tag = "labelNAZIVDOPRINOS";
            this.label1NAZIVDOPRINOS.Text = "Naziv doprinosa:";
            this.label1NAZIVDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVDOPRINOS.AutoSize = true;
            this.label1NAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1NAZIVDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1NAZIVDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1NAZIVDOPRINOS, 0, 1);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1NAZIVDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1NAZIVDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x77, 0x17);
            this.label1NAZIVDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVDOPRINOS.Location = point;
            this.textNAZIVDOPRINOS.Name = "textNAZIVDOPRINOS";
            this.textNAZIVDOPRINOS.Tag = "NAZIVDOPRINOS";
            this.textNAZIVDOPRINOS.TabIndex = 0;
            this.textNAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.textNAZIVDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVDOPRINOS.ReadOnly = false;
            this.textNAZIVDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "NAZIVDOPRINOS"));
            this.textNAZIVDOPRINOS.MaxLength = 50;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textNAZIVDOPRINOS, 1, 1);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textNAZIVDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textNAZIVDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDVRSTADOPRINOS.Location = point;
            this.label1IDVRSTADOPRINOS.Name = "label1IDVRSTADOPRINOS";
            this.label1IDVRSTADOPRINOS.TabIndex = 1;
            this.label1IDVRSTADOPRINOS.Tag = "labelIDVRSTADOPRINOS";
            this.label1IDVRSTADOPRINOS.Text = "Šifra vrste doprinosa:";
            this.label1IDVRSTADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1IDVRSTADOPRINOS.AutoSize = true;
            this.label1IDVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1IDVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVRSTADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1IDVRSTADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1IDVRSTADOPRINOS, 0, 2);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1IDVRSTADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1IDVRSTADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x94, 0x17);
            this.label1IDVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDVRSTADOPRINOS.Location = point;
            this.textIDVRSTADOPRINOS.Name = "textIDVRSTADOPRINOS";
            this.textIDVRSTADOPRINOS.Tag = "IDVRSTADOPRINOS";
            this.textIDVRSTADOPRINOS.TabIndex = 0;
            this.textIDVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.textIDVRSTADOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDVRSTADOPRINOS.ReadOnly = false;
            this.textIDVRSTADOPRINOS.PromptChar = ' ';
            this.textIDVRSTADOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDVRSTADOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceDOPRINOS, "IDVRSTADOPRINOS"));
            this.textIDVRSTADOPRINOS.NumericType = NumericType.Integer;
            this.textIDVRSTADOPRINOS.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonVRSTADOPRINOSIDVRSTADOPRINOS",
                Tag = "editorButtonVRSTADOPRINOSIDVRSTADOPRINOS",
                Text = "..."
            };
            this.textIDVRSTADOPRINOS.ButtonsRight.Add(button);
            this.textIDVRSTADOPRINOS.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptVRSTADOPRINOSIDVRSTADOPRINOS);
            this.layoutManagerformDOPRINOS.Controls.Add(this.textIDVRSTADOPRINOS, 1, 2);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textIDVRSTADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textIDVRSTADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTADOPRINOS.Location = point;
            this.label1NAZIVVRSTADOPRINOS.Name = "label1NAZIVVRSTADOPRINOS";
            this.label1NAZIVVRSTADOPRINOS.TabIndex = 1;
            this.label1NAZIVVRSTADOPRINOS.Tag = "labelNAZIVVRSTADOPRINOS";
            this.label1NAZIVVRSTADOPRINOS.Text = "Naziv vrste doprinosa:";
            this.label1NAZIVVRSTADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTADOPRINOS.AutoSize = true;
            this.label1NAZIVVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1NAZIVVRSTADOPRINOS, 0, 3);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1NAZIVVRSTADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1NAZIVVRSTADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1NAZIVVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVVRSTADOPRINOS.Location = point;
            this.labelNAZIVVRSTADOPRINOS.Name = "labelNAZIVVRSTADOPRINOS";
            this.labelNAZIVVRSTADOPRINOS.Tag = "NAZIVVRSTADOPRINOS";
            this.labelNAZIVVRSTADOPRINOS.TabIndex = 0;
            this.labelNAZIVVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.labelNAZIVVRSTADOPRINOS.BackColor = Color.Transparent;
            this.labelNAZIVVRSTADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "NAZIVVRSTADOPRINOS"));
            this.labelNAZIVVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformDOPRINOS.Controls.Add(this.labelNAZIVVRSTADOPRINOS, 1, 3);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.labelNAZIVVRSTADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.labelNAZIVVRSTADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STOPA.Location = point;
            this.label1STOPA.Name = "label1STOPA";
            this.label1STOPA.TabIndex = 1;
            this.label1STOPA.Tag = "labelSTOPA";
            this.label1STOPA.Text = "STOPA:";
            this.label1STOPA.StyleSetName = "FieldUltraLabel";
            this.label1STOPA.AutoSize = true;
            this.label1STOPA.Anchor = AnchorStyles.Left;
            this.label1STOPA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STOPA.Appearance.ForeColor = Color.Black;
            this.label1STOPA.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1STOPA, 0, 4);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1STOPA, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1STOPA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STOPA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STOPA.MinimumSize = size;
            size = new System.Drawing.Size(60, 0x17);
            this.label1STOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSTOPA.Location = point;
            this.textSTOPA.Name = "textSTOPA";
            this.textSTOPA.Tag = "STOPA";
            this.textSTOPA.TabIndex = 0;
            this.textSTOPA.Anchor = AnchorStyles.Left;
            this.textSTOPA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSTOPA.ReadOnly = false;
            this.textSTOPA.PromptChar = ' ';
            this.textSTOPA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textSTOPA.DataBindings.Add(new Binding("Value", this.bindingSourceDOPRINOS, "STOPA"));
            this.textSTOPA.NumericType = NumericType.Double;
            this.textSTOPA.MaxValue = 79228162514264337593543950335M;
            this.textSTOPA.MinValue = -79228162514264337593543950335M;
            this.textSTOPA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformDOPRINOS.Controls.Add(this.textSTOPA, 1, 4);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textSTOPA, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textSTOPA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSTOPA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textSTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MODOPRINOS.Location = point;
            this.label1MODOPRINOS.Name = "label1MODOPRINOS";
            this.label1MODOPRINOS.TabIndex = 1;
            this.label1MODOPRINOS.Tag = "labelMODOPRINOS";
            this.label1MODOPRINOS.Text = "Model odobrenja doprinosa:";
            this.label1MODOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MODOPRINOS.AutoSize = true;
            this.label1MODOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MODOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MODOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MODOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1MODOPRINOS, 0, 5);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1MODOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1MODOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xbd, 0x17);
            this.label1MODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMODOPRINOS.Location = point;
            this.textMODOPRINOS.Name = "textMODOPRINOS";
            this.textMODOPRINOS.Tag = "MODOPRINOS";
            this.textMODOPRINOS.TabIndex = 0;
            this.textMODOPRINOS.Anchor = AnchorStyles.Left;
            this.textMODOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMODOPRINOS.ReadOnly = false;
            this.textMODOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "MODOPRINOS"));
            this.textMODOPRINOS.MaxLength = 2;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textMODOPRINOS, 1, 5);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textMODOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textMODOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PODOPRINOS.Location = point;
            this.label1PODOPRINOS.Name = "label1PODOPRINOS";
            this.label1PODOPRINOS.TabIndex = 1;
            this.label1PODOPRINOS.Tag = "labelPODOPRINOS";
            this.label1PODOPRINOS.Text = "Poziv odobrenja doprinosa:";
            this.label1PODOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1PODOPRINOS.AutoSize = true;
            this.label1PODOPRINOS.Anchor = AnchorStyles.Left;
            this.label1PODOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PODOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1PODOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1PODOPRINOS, 0, 6);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1PODOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1PODOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1PODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPODOPRINOS.Location = point;
            this.textPODOPRINOS.Name = "textPODOPRINOS";
            this.textPODOPRINOS.Tag = "PODOPRINOS";
            this.textPODOPRINOS.TabIndex = 0;
            this.textPODOPRINOS.Anchor = AnchorStyles.Left;
            this.textPODOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPODOPRINOS.ReadOnly = false;
            this.textPODOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "PODOPRINOS"));
            this.textPODOPRINOS.MaxLength = 0x16;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textPODOPRINOS, 1, 6);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textPODOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textPODOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPODOPRINOS.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPODOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPODOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZDOPRINOS.Location = point;
            this.label1MZDOPRINOS.Name = "label1MZDOPRINOS";
            this.label1MZDOPRINOS.TabIndex = 1;
            this.label1MZDOPRINOS.Tag = "labelMZDOPRINOS";
            this.label1MZDOPRINOS.Text = "Model zaduženja doprinosa:";
            this.label1MZDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MZDOPRINOS.AutoSize = true;
            this.label1MZDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MZDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MZDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1MZDOPRINOS, 0, 7);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1MZDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1MZDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xbd, 0x17);
            this.label1MZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMZDOPRINOS.Location = point;
            this.textMZDOPRINOS.Name = "textMZDOPRINOS";
            this.textMZDOPRINOS.Tag = "MZDOPRINOS";
            this.textMZDOPRINOS.TabIndex = 0;
            this.textMZDOPRINOS.Anchor = AnchorStyles.Left;
            this.textMZDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMZDOPRINOS.ContextMenu = this.contextMenu1;
            this.textMZDOPRINOS.ReadOnly = false;
            this.textMZDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "MZDOPRINOS"));
            this.textMZDOPRINOS.Nullable = true;
            this.textMZDOPRINOS.MaxLength = 2;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textMZDOPRINOS, 1, 7);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textMZDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textMZDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZDOPRINOS.Location = point;
            this.label1PZDOPRINOS.Name = "label1PZDOPRINOS";
            this.label1PZDOPRINOS.TabIndex = 1;
            this.label1PZDOPRINOS.Tag = "labelPZDOPRINOS";
            this.label1PZDOPRINOS.Text = "Poziv zaduženja doprinosa:";
            this.label1PZDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1PZDOPRINOS.AutoSize = true;
            this.label1PZDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1PZDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1PZDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1PZDOPRINOS, 0, 8);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1PZDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1PZDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1PZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPZDOPRINOS.Location = point;
            this.textPZDOPRINOS.Name = "textPZDOPRINOS";
            this.textPZDOPRINOS.Tag = "PZDOPRINOS";
            this.textPZDOPRINOS.TabIndex = 0;
            this.textPZDOPRINOS.Anchor = AnchorStyles.Left;
            this.textPZDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPZDOPRINOS.ContextMenu = this.contextMenu1;
            this.textPZDOPRINOS.ReadOnly = false;
            this.textPZDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "PZDOPRINOS"));
            this.textPZDOPRINOS.Nullable = true;
            this.textPZDOPRINOS.MaxLength = 0x16;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textPZDOPRINOS, 1, 8);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textPZDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textPZDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPZDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJDOPRINOS1.Location = point;
            this.label1PRIMATELJDOPRINOS1.Name = "label1PRIMATELJDOPRINOS1";
            this.label1PRIMATELJDOPRINOS1.TabIndex = 1;
            this.label1PRIMATELJDOPRINOS1.Tag = "labelPRIMATELJDOPRINOS1";
            this.label1PRIMATELJDOPRINOS1.Text = "Primatelj doprinosa:";
            this.label1PRIMATELJDOPRINOS1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJDOPRINOS1.AutoSize = true;
            this.label1PRIMATELJDOPRINOS1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJDOPRINOS1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJDOPRINOS1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJDOPRINOS1.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1PRIMATELJDOPRINOS1, 0, 9);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1PRIMATELJDOPRINOS1, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1PRIMATELJDOPRINOS1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJDOPRINOS1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJDOPRINOS1.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1PRIMATELJDOPRINOS1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJDOPRINOS1.Location = point;
            this.textPRIMATELJDOPRINOS1.Name = "textPRIMATELJDOPRINOS1";
            this.textPRIMATELJDOPRINOS1.Tag = "PRIMATELJDOPRINOS1";
            this.textPRIMATELJDOPRINOS1.TabIndex = 0;
            this.textPRIMATELJDOPRINOS1.Anchor = AnchorStyles.Left;
            this.textPRIMATELJDOPRINOS1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJDOPRINOS1.ReadOnly = false;
            this.textPRIMATELJDOPRINOS1.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "PRIMATELJDOPRINOS1"));
            this.textPRIMATELJDOPRINOS1.MaxLength = 20;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textPRIMATELJDOPRINOS1, 1, 9);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textPRIMATELJDOPRINOS1, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textPRIMATELJDOPRINOS1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJDOPRINOS1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJDOPRINOS1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJDOPRINOS1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJDOPRINOS2.Location = point;
            this.label1PRIMATELJDOPRINOS2.Name = "label1PRIMATELJDOPRINOS2";
            this.label1PRIMATELJDOPRINOS2.TabIndex = 1;
            this.label1PRIMATELJDOPRINOS2.Tag = "labelPRIMATELJDOPRINOS2";
            this.label1PRIMATELJDOPRINOS2.Text = "Primatelj doprinosa (2):";
            this.label1PRIMATELJDOPRINOS2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJDOPRINOS2.AutoSize = true;
            this.label1PRIMATELJDOPRINOS2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJDOPRINOS2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJDOPRINOS2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJDOPRINOS2.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1PRIMATELJDOPRINOS2, 0, 10);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1PRIMATELJDOPRINOS2, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1PRIMATELJDOPRINOS2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJDOPRINOS2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJDOPRINOS2.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 0x17);
            this.label1PRIMATELJDOPRINOS2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJDOPRINOS2.Location = point;
            this.textPRIMATELJDOPRINOS2.Name = "textPRIMATELJDOPRINOS2";
            this.textPRIMATELJDOPRINOS2.Tag = "PRIMATELJDOPRINOS2";
            this.textPRIMATELJDOPRINOS2.TabIndex = 0;
            this.textPRIMATELJDOPRINOS2.Anchor = AnchorStyles.Left;
            this.textPRIMATELJDOPRINOS2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJDOPRINOS2.ContextMenu = this.contextMenu1;
            this.textPRIMATELJDOPRINOS2.ReadOnly = false;
            this.textPRIMATELJDOPRINOS2.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "PRIMATELJDOPRINOS2"));
            this.textPRIMATELJDOPRINOS2.Nullable = true;
            this.textPRIMATELJDOPRINOS2.MaxLength = 20;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textPRIMATELJDOPRINOS2, 1, 10);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textPRIMATELJDOPRINOS2, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textPRIMATELJDOPRINOS2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJDOPRINOS2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJDOPRINOS2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJDOPRINOS2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJADOPRINOS.Location = point;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Name = "label1SIFRAOPISAPLACANJADOPRINOS";
            this.label1SIFRAOPISAPLACANJADOPRINOS.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Tag = "labelSIFRAOPISAPLACANJADOPRINOS";
            this.label1SIFRAOPISAPLACANJADOPRINOS.Text = "Šifra opisa plaćanja doprinosa:";
            this.label1SIFRAOPISAPLACANJADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJADOPRINOS.AutoSize = true;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1SIFRAOPISAPLACANJADOPRINOS, 0, 11);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1SIFRAOPISAPLACANJADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1SIFRAOPISAPLACANJADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xce, 0x17);
            this.label1SIFRAOPISAPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJADOPRINOS.Location = point;
            this.textSIFRAOPISAPLACANJADOPRINOS.Name = "textSIFRAOPISAPLACANJADOPRINOS";
            this.textSIFRAOPISAPLACANJADOPRINOS.Tag = "SIFRAOPISAPLACANJADOPRINOS";
            this.textSIFRAOPISAPLACANJADOPRINOS.TabIndex = 0;
            this.textSIFRAOPISAPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJADOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJADOPRINOS.ReadOnly = false;
            this.textSIFRAOPISAPLACANJADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "SIFRAOPISAPLACANJADOPRINOS"));
            this.textSIFRAOPISAPLACANJADOPRINOS.MaxLength = 2;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textSIFRAOPISAPLACANJADOPRINOS, 1, 11);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textSIFRAOPISAPLACANJADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textSIFRAOPISAPLACANJADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJADOPRINOS.Location = point;
            this.label1OPISPLACANJADOPRINOS.Name = "label1OPISPLACANJADOPRINOS";
            this.label1OPISPLACANJADOPRINOS.TabIndex = 1;
            this.label1OPISPLACANJADOPRINOS.Tag = "labelOPISPLACANJADOPRINOS";
            this.label1OPISPLACANJADOPRINOS.Text = "Opis plaćanja doprinosa:";
            this.label1OPISPLACANJADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJADOPRINOS.AutoSize = true;
            this.label1OPISPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1OPISPLACANJADOPRINOS, 0, 12);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1OPISPLACANJADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1OPISPLACANJADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0xa8, 0x17);
            this.label1OPISPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJADOPRINOS.Location = point;
            this.textOPISPLACANJADOPRINOS.Name = "textOPISPLACANJADOPRINOS";
            this.textOPISPLACANJADOPRINOS.Tag = "OPISPLACANJADOPRINOS";
            this.textOPISPLACANJADOPRINOS.TabIndex = 0;
            this.textOPISPLACANJADOPRINOS.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJADOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJADOPRINOS.ReadOnly = false;
            this.textOPISPLACANJADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "OPISPLACANJADOPRINOS"));
            this.textOPISPLACANJADOPRINOS.MaxLength = 0x24;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textOPISPLACANJADOPRINOS, 1, 12);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textOPISPLACANJADOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textOPISPLACANJADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIDOPRINOS.Location = point;
            this.label1VBDIDOPRINOS.Name = "label1VBDIDOPRINOS";
            this.label1VBDIDOPRINOS.TabIndex = 1;
            this.label1VBDIDOPRINOS.Tag = "labelVBDIDOPRINOS";
            this.label1VBDIDOPRINOS.Text = "VBDI:";
            this.label1VBDIDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1VBDIDOPRINOS.AutoSize = true;
            this.label1VBDIDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1VBDIDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1VBDIDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1VBDIDOPRINOS, 0, 13);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1VBDIDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1VBDIDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x17);
            this.label1VBDIDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDIDOPRINOS.Location = point;
            this.textVBDIDOPRINOS.Name = "textVBDIDOPRINOS";
            this.textVBDIDOPRINOS.Tag = "VBDIDOPRINOS";
            this.textVBDIDOPRINOS.TabIndex = 0;
            this.textVBDIDOPRINOS.Anchor = AnchorStyles.Left;
            this.textVBDIDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDIDOPRINOS.ReadOnly = false;
            this.textVBDIDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "VBDIDOPRINOS"));
            this.textVBDIDOPRINOS.MaxLength = 7;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textVBDIDOPRINOS, 1, 13);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textVBDIDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textVBDIDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDIDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNDOPRINOS.Location = point;
            this.label1ZRNDOPRINOS.Name = "label1ZRNDOPRINOS";
            this.label1ZRNDOPRINOS.TabIndex = 1;
            this.label1ZRNDOPRINOS.Tag = "labelZRNDOPRINOS";
            this.label1ZRNDOPRINOS.Text = "Žiro račun:";
            this.label1ZRNDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1ZRNDOPRINOS.AutoSize = true;
            this.label1ZRNDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1ZRNDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1ZRNDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1ZRNDOPRINOS, 0, 14);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1ZRNDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1ZRNDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x17);
            this.label1ZRNDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZRNDOPRINOS.Location = point;
            this.textZRNDOPRINOS.Name = "textZRNDOPRINOS";
            this.textZRNDOPRINOS.Tag = "ZRNDOPRINOS";
            this.textZRNDOPRINOS.TabIndex = 0;
            this.textZRNDOPRINOS.Anchor = AnchorStyles.Left;
            this.textZRNDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZRNDOPRINOS.ReadOnly = false;
            this.textZRNDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceDOPRINOS, "ZRNDOPRINOS"));
            this.textZRNDOPRINOS.MaxLength = 10;
            this.layoutManagerformDOPRINOS.Controls.Add(this.textZRNDOPRINOS, 1, 14);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textZRNDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textZRNDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZRNDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MINDOPRINOS.Location = point;
            this.label1MINDOPRINOS.Name = "label1MINDOPRINOS";
            this.label1MINDOPRINOS.TabIndex = 1;
            this.label1MINDOPRINOS.Tag = "labelMINDOPRINOS";
            this.label1MINDOPRINOS.Text = "Min. osnovica za obračun doprinosa:";
            this.label1MINDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MINDOPRINOS.AutoSize = true;
            this.label1MINDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MINDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MINDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MINDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1MINDOPRINOS, 0, 15);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1MINDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1MINDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MINDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MINDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(240, 0x17);
            this.label1MINDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMINDOPRINOS.Location = point;
            this.textMINDOPRINOS.Name = "textMINDOPRINOS";
            this.textMINDOPRINOS.Tag = "MINDOPRINOS";
            this.textMINDOPRINOS.TabIndex = 0;
            this.textMINDOPRINOS.Anchor = AnchorStyles.Left;
            this.textMINDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMINDOPRINOS.ReadOnly = false;
            this.textMINDOPRINOS.PromptChar = ' ';
            this.textMINDOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMINDOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceDOPRINOS, "MINDOPRINOS"));
            this.textMINDOPRINOS.NumericType = NumericType.Double;
            this.textMINDOPRINOS.MaxValue = 79228162514264337593543950335M;
            this.textMINDOPRINOS.MinValue = -79228162514264337593543950335M;
            this.textMINDOPRINOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformDOPRINOS.Controls.Add(this.textMINDOPRINOS, 1, 15);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textMINDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textMINDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMINDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textMINDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textMINDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MAXDOPRINOS.Location = point;
            this.label1MAXDOPRINOS.Name = "label1MAXDOPRINOS";
            this.label1MAXDOPRINOS.TabIndex = 1;
            this.label1MAXDOPRINOS.Tag = "labelMAXDOPRINOS";
            this.label1MAXDOPRINOS.Text = "Maks. osnovica za obračun doprinosa:";
            this.label1MAXDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1MAXDOPRINOS.AutoSize = true;
            this.label1MAXDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1MAXDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1MAXDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1MAXDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformDOPRINOS.Controls.Add(this.label1MAXDOPRINOS, 0, 0x10);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.label1MAXDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.label1MAXDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MAXDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MAXDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(250, 0x17);
            this.label1MAXDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMAXDOPRINOS.Location = point;
            this.textMAXDOPRINOS.Name = "textMAXDOPRINOS";
            this.textMAXDOPRINOS.Tag = "MAXDOPRINOS";
            this.textMAXDOPRINOS.TabIndex = 0;
            this.textMAXDOPRINOS.Anchor = AnchorStyles.Left;
            this.textMAXDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMAXDOPRINOS.ReadOnly = false;
            this.textMAXDOPRINOS.PromptChar = ' ';
            this.textMAXDOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMAXDOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceDOPRINOS, "MAXDOPRINOS"));
            this.textMAXDOPRINOS.NumericType = NumericType.Double;
            this.textMAXDOPRINOS.MaxValue = 79228162514264337593543950335M;
            this.textMAXDOPRINOS.MinValue = -79228162514264337593543950335M;
            this.textMAXDOPRINOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformDOPRINOS.Controls.Add(this.textMAXDOPRINOS, 1, 0x10);
            this.layoutManagerformDOPRINOS.SetColumnSpan(this.textMAXDOPRINOS, 1);
            this.layoutManagerformDOPRINOS.SetRowSpan(this.textMAXDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMAXDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textMAXDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textMAXDOPRINOS.Size = size;
            this.Controls.Add(this.layoutManagerformDOPRINOS);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDOPRINOS;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DOPRINOSFormUserControl";
            this.Text = "Doprinosi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DOPRINOSFormUserControl_Load);
            this.layoutManagerformDOPRINOS.ResumeLayout(false);
            this.layoutManagerformDOPRINOS.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDOPRINOS).EndInit();
            ((ISupportInitialize) this.textIDDOPRINOS).EndInit();
            ((ISupportInitialize) this.textNAZIVDOPRINOS).EndInit();
            ((ISupportInitialize) this.textIDVRSTADOPRINOS).EndInit();
            ((ISupportInitialize) this.textSTOPA).EndInit();
            ((ISupportInitialize) this.textMODOPRINOS).EndInit();
            ((ISupportInitialize) this.textPODOPRINOS).EndInit();
            ((ISupportInitialize) this.textMZDOPRINOS).EndInit();
            ((ISupportInitialize) this.textPZDOPRINOS).EndInit();
            ((ISupportInitialize) this.textPRIMATELJDOPRINOS1).EndInit();
            ((ISupportInitialize) this.textPRIMATELJDOPRINOS2).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJADOPRINOS).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJADOPRINOS).EndInit();
            ((ISupportInitialize) this.textVBDIDOPRINOS).EndInit();
            ((ISupportInitialize) this.textZRNDOPRINOS).EndInit();
            ((ISupportInitialize) this.textMINDOPRINOS).EndInit();
            ((ISupportInitialize) this.textMAXDOPRINOS).EndInit();
            this.dsDOPRINOSDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DOPRINOSController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDOPRINOS, this.DOPRINOSController.WorkItem, this))
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
            this.label1IDDOPRINOS.Text = StringResources.DOPRINOSIDDOPRINOSDescription;
            this.label1NAZIVDOPRINOS.Text = StringResources.DOPRINOSNAZIVDOPRINOSDescription;
            this.label1IDVRSTADOPRINOS.Text = StringResources.DOPRINOSIDVRSTADOPRINOSDescription;
            this.label1NAZIVVRSTADOPRINOS.Text = StringResources.DOPRINOSNAZIVVRSTADOPRINOSDescription;
            this.label1STOPA.Text = StringResources.DOPRINOSSTOPADescription;
            this.label1MODOPRINOS.Text = StringResources.DOPRINOSMODOPRINOSDescription;
            this.label1PODOPRINOS.Text = StringResources.DOPRINOSPODOPRINOSDescription;
            this.label1MZDOPRINOS.Text = StringResources.DOPRINOSMZDOPRINOSDescription;
            this.label1PZDOPRINOS.Text = StringResources.DOPRINOSPZDOPRINOSDescription;
            this.label1PRIMATELJDOPRINOS1.Text = StringResources.DOPRINOSPRIMATELJDOPRINOS1Description;
            this.label1PRIMATELJDOPRINOS2.Text = StringResources.DOPRINOSPRIMATELJDOPRINOS2Description;
            this.label1SIFRAOPISAPLACANJADOPRINOS.Text = StringResources.DOPRINOSSIFRAOPISAPLACANJADOPRINOSDescription;
            this.label1OPISPLACANJADOPRINOS.Text = StringResources.DOPRINOSOPISPLACANJADOPRINOSDescription;
            this.label1VBDIDOPRINOS.Text = StringResources.DOPRINOSVBDIDOPRINOSDescription;
            this.label1ZRNDOPRINOS.Text = StringResources.DOPRINOSZRNDOPRINOSDescription;
            this.label1MINDOPRINOS.Text = StringResources.DOPRINOSMINDOPRINOSDescription;
            this.label1MAXDOPRINOS.Text = StringResources.DOPRINOSMAXDOPRINOSDescription;
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
            if (!this.DOPRINOSController.WorkItem.Items.Contains("DOPRINOS|DOPRINOS"))
            {
                this.DOPRINOSController.WorkItem.Items.Add(this.bindingSourceDOPRINOS, "DOPRINOS|DOPRINOS");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDOPRINOSDataSet1.DOPRINOS.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DOPRINOSController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DOPRINOSController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DOPRINOSController.Update(this))
            {
                this.DOPRINOSController.DataSet = new DOPRINOSDataSet();
                DataSetUtil.AddEmptyRow(this.DOPRINOSController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DOPRINOSController.DataSet.DOPRINOS[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDDOPRINOS.Focus();
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

        private void UpdateValuesVRSTADOPRINOSIDVRSTADOPRINOS(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceDOPRINOS.Current).Row["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(result["IDVRSTADOPRINOS"]);
                ((DataRowView) this.bindingSourceDOPRINOS.Current).Row["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTADOPRINOS"]);
                this.bindingSourceDOPRINOS.ResetCurrentItem();
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.DOPRINOSController DOPRINOSController { get; set; }

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

        protected virtual UltraLabel label1IDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1IDVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MAXDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MAXDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MAXDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MINDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MINDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MINDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MODOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1MZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1NAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1PODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PODOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJDOPRINOS1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJDOPRINOS1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJDOPRINOS1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJDOPRINOS2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJDOPRINOS2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJDOPRINOS2 = value;
            }
        }

        protected virtual UltraLabel label1PZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1STOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STOPA = value;
            }
        }

        protected virtual UltraLabel label1VBDIDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1ZRNDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNDOPRINOS = value;
            }
        }

        protected virtual UltraLabel labelNAZIVVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVVRSTADOPRINOS = value;
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

        protected virtual UltraNumericEditor textIDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDDOPRINOS = value;
            }
        }

        protected virtual UltraNumericEditor textIDVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraNumericEditor textMAXDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMAXDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMAXDOPRINOS = value;
            }
        }

        protected virtual UltraNumericEditor textMINDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMINDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMINDOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textMODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMODOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textMZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMZDOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVDOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textPODOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPODOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPODOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJDOPRINOS1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJDOPRINOS1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJDOPRINOS1 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJDOPRINOS2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJDOPRINOS2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJDOPRINOS2 = value;
            }
        }

        protected virtual UltraTextEditor textPZDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPZDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPZDOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJADOPRINOS = value;
            }
        }

        protected virtual UltraNumericEditor textSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSTOPA = value;
            }
        }

        protected virtual UltraTextEditor textVBDIDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDIDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDIDOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textZRNDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZRNDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZRNDOPRINOS = value;
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

