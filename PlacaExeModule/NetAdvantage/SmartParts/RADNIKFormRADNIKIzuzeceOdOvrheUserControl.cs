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
    public class RADNIKFormRADNIKIzuzeceOdOvrheUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1BANKAZASTICENOIDBANKE")]
        private UltraLabel _label1BANKAZASTICENOIDBANKE;
        [AccessedThroughProperty("label1ZADIZNOSIZUZECA")]
        private UltraLabel _label1ZADIZNOSIZUZECA;
        [AccessedThroughProperty("label1ZADMOIZUZECE")]
        private UltraLabel _label1ZADMOIZUZECE;
        [AccessedThroughProperty("label1ZADMZIZUZECE")]
        private UltraLabel _label1ZADMZIZUZECE;
        [AccessedThroughProperty("label1ZADOPISPLACANJAIZUZECE")]
        private UltraLabel _label1ZADOPISPLACANJAIZUZECE;
        [AccessedThroughProperty("label1ZADPOIZUZECE")]
        private UltraLabel _label1ZADPOIZUZECE;
        [AccessedThroughProperty("label1ZADPZIZUZECE")]
        private UltraLabel _label1ZADPZIZUZECE;
        [AccessedThroughProperty("label1ZADSIFRAOPISAPLACANJAIZUZECE")]
        private UltraLabel _label1ZADSIFRAOPISAPLACANJAIZUZECE;
        [AccessedThroughProperty("label1ZADTEKUCIIZUZECE")]
        private UltraLabel _label1ZADTEKUCIIZUZECE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textBANKAZASTICENOIDBANKE")]
        private UltraNumericEditor _textBANKAZASTICENOIDBANKE;
        [AccessedThroughProperty("textZADIZNOSIZUZECA")]
        private UltraNumericEditor _textZADIZNOSIZUZECA;
        [AccessedThroughProperty("textZADMOIZUZECE")]
        private UltraTextEditor _textZADMOIZUZECE;
        [AccessedThroughProperty("textZADMZIZUZECE")]
        private UltraTextEditor _textZADMZIZUZECE;
        [AccessedThroughProperty("textZADOPISPLACANJAIZUZECE")]
        private UltraTextEditor _textZADOPISPLACANJAIZUZECE;
        [AccessedThroughProperty("textZADPOIZUZECE")]
        private UltraTextEditor _textZADPOIZUZECE;
        [AccessedThroughProperty("textZADPZIZUZECE")]
        private UltraTextEditor _textZADPZIZUZECE;
        [AccessedThroughProperty("textZADSIFRAOPISAPLACANJAIZUZECE")]
        private UltraTextEditor _textZADSIFRAOPISAPLACANJAIZUZECE;
        [AccessedThroughProperty("textZADTEKUCIIZUZECE")]
        private UltraTextEditor _textZADTEKUCIIZUZECE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKIzuzeceOdOvrhe;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKIzuzeceOdOvrhe;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKIzuzeceOdOvrheRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIKIzuzeceOdOvrhe";
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public RADNIKFormRADNIKIzuzeceOdOvrheUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKIzuzeceOdOvrheAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            //MessageBox.Show("Unjeli ste zaštičeni račun kod iste banke kao i za isplatu plaće,\nvodite računa da mora biti označen \"Uključen u zbirni neto\" na kartici \"Općine i banke\".");
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKIzuzeceOdOvrheAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            //MessageBox.Show("Unjeli ste zaštičeni račun kod iste banke kao i za isplatu plaće,\nvodite računa da mora biti označen \"Uključen u zbirni neto\" na kartici \"Općine i banke\".");
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) ((DataRowView) this.bindingSourceRADNIKIzuzeceOdOvrhe.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptBANKEBANKAZASTICENOIDBANKE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectBANKEBANKAZASTICENOIDBANKE(fillMethod, fillByRow);
            this.UpdateValuesBANKEBANKAZASTICENOIDBANKE(result);
        }

        private void CallViewBANKEBANKAZASTICENOIDBANKE(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowBANKEBANKAZASTICENOIDBANKE(this.m_CurrentRow);
            this.UpdateValuesBANKEBANKAZASTICENOIDBANKE(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKIzuzeceOdOvrhe.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
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
            this.bindingSourceRADNIKIzuzeceOdOvrhe.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKIzuzeceOdOvrhe"]);
            this.bindingSourceRADNIKIzuzeceOdOvrhe.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKIzuzeceOdOvrhe.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) ((DataRowView) this.bindingSourceRADNIKIzuzeceOdOvrhe.Current).Row;
                this.textBANKAZASTICENOIDBANKE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textBANKAZASTICENOIDBANKE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) ((DataRowView) this.bindingSourceRADNIKIzuzeceOdOvrhe.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKIzuzeceOdOvrheUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKIzuzeceOdOvrhe = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKIzuzeceOdOvrhe).BeginInit();
            this.layoutManagerformRADNIKIzuzeceOdOvrhe = new TableLayoutPanel();
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SuspendLayout();
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.AutoSize = true;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Size = size;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.ColumnCount = 2;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowCount = 10;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.label1BANKAZASTICENOIDBANKE = new UltraLabel();
            this.textBANKAZASTICENOIDBANKE = new UltraNumericEditor();
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE = new UltraLabel();
            this.textZADSIFRAOPISAPLACANJAIZUZECE = new UltraTextEditor();
            this.label1ZADOPISPLACANJAIZUZECE = new UltraLabel();
            this.textZADOPISPLACANJAIZUZECE = new UltraTextEditor();
            this.label1ZADTEKUCIIZUZECE = new UltraLabel();
            this.textZADTEKUCIIZUZECE = new UltraTextEditor();
            this.label1ZADMOIZUZECE = new UltraLabel();
            this.textZADMOIZUZECE = new UltraTextEditor();
            this.label1ZADPOIZUZECE = new UltraLabel();
            this.textZADPOIZUZECE = new UltraTextEditor();
            this.label1ZADMZIZUZECE = new UltraLabel();
            this.textZADMZIZUZECE = new UltraTextEditor();
            this.label1ZADPZIZUZECE = new UltraLabel();
            this.textZADPZIZUZECE = new UltraTextEditor();
            this.label1ZADIZNOSIZUZECA = new UltraLabel();
            this.textZADIZNOSIZUZECA = new UltraNumericEditor();
            ((ISupportInitialize) this.textBANKAZASTICENOIDBANKE).BeginInit();
            ((ISupportInitialize) this.textZADSIFRAOPISAPLACANJAIZUZECE).BeginInit();
            ((ISupportInitialize) this.textZADOPISPLACANJAIZUZECE).BeginInit();
            ((ISupportInitialize) this.textZADTEKUCIIZUZECE).BeginInit();
            ((ISupportInitialize) this.textZADMOIZUZECE).BeginInit();
            ((ISupportInitialize) this.textZADPOIZUZECE).BeginInit();
            ((ISupportInitialize) this.textZADMZIZUZECE).BeginInit();
            ((ISupportInitialize) this.textZADPZIZUZECE).BeginInit();
            ((ISupportInitialize) this.textZADIZNOSIZUZECA).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKIzuzeceOdOvrhe.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKIzuzeceOdOvrhe.DataMember = "RADNIKIzuzeceOdOvrhe";
            ((ISupportInitialize) this.bindingSourceRADNIKIzuzeceOdOvrhe).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1BANKAZASTICENOIDBANKE.Location = point;
            this.label1BANKAZASTICENOIDBANKE.Name = "label1BANKAZASTICENOIDBANKE";
            this.label1BANKAZASTICENOIDBANKE.TabIndex = 1;
            this.label1BANKAZASTICENOIDBANKE.Tag = "labelBANKAZASTICENOIDBANKE";
            this.label1BANKAZASTICENOIDBANKE.Text = "Šifra banke za poseban zaštićeni račun:";
            this.label1BANKAZASTICENOIDBANKE.StyleSetName = "FieldUltraLabel";
            this.label1BANKAZASTICENOIDBANKE.AutoSize = true;
            this.label1BANKAZASTICENOIDBANKE.Anchor = AnchorStyles.Left;
            this.label1BANKAZASTICENOIDBANKE.Appearance.TextVAlign = VAlign.Middle;
            this.label1BANKAZASTICENOIDBANKE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1BANKAZASTICENOIDBANKE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1BANKAZASTICENOIDBANKE.ImageSize = size;
            this.label1BANKAZASTICENOIDBANKE.Appearance.ForeColor = Color.Black;
            this.label1BANKAZASTICENOIDBANKE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1BANKAZASTICENOIDBANKE, 0, 0);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1BANKAZASTICENOIDBANKE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1BANKAZASTICENOIDBANKE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1BANKAZASTICENOIDBANKE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BANKAZASTICENOIDBANKE.MinimumSize = size;
            size = new System.Drawing.Size(0x101, 0x17);
            this.label1BANKAZASTICENOIDBANKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBANKAZASTICENOIDBANKE.Location = point;
            this.textBANKAZASTICENOIDBANKE.Name = "textBANKAZASTICENOIDBANKE";
            this.textBANKAZASTICENOIDBANKE.Tag = "BANKAZASTICENOIDBANKE";
            this.textBANKAZASTICENOIDBANKE.TabIndex = 0;
            this.textBANKAZASTICENOIDBANKE.Anchor = AnchorStyles.Left;
            this.textBANKAZASTICENOIDBANKE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBANKAZASTICENOIDBANKE.ReadOnly = false;
            this.textBANKAZASTICENOIDBANKE.PromptChar = ' ';
            this.textBANKAZASTICENOIDBANKE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBANKAZASTICENOIDBANKE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKIzuzeceOdOvrhe, "BANKAZASTICENOIDBANKE"));
            this.textBANKAZASTICENOIDBANKE.NumericType = NumericType.Integer;
            this.textBANKAZASTICENOIDBANKE.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonBANKEBANKAZASTICENOIDBANKE",
                Tag = "editorButtonBANKEBANKAZASTICENOIDBANKE",
                Text = "..."
            };
            this.textBANKAZASTICENOIDBANKE.ButtonsRight.Add(button);
            this.textBANKAZASTICENOIDBANKE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptBANKEBANKAZASTICENOIDBANKE);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textBANKAZASTICENOIDBANKE, 1, 0);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textBANKAZASTICENOIDBANKE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textBANKAZASTICENOIDBANKE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBANKAZASTICENOIDBANKE.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textBANKAZASTICENOIDBANKE.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textBANKAZASTICENOIDBANKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Location = point;
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Name = "label1ZADSIFRAOPISAPLACANJAIZUZECE";
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.TabIndex = 1;
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Tag = "labelZADSIFRAOPISAPLACANJAIZUZECE";
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Text = "Šifra opisa plaćanja:";
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.StyleSetName = "FieldUltraLabel";
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.AutoSize = true;
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Anchor = AnchorStyles.Left;
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Appearance.ForeColor = Color.Black;
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADSIFRAOPISAPLACANJAIZUZECE, 0, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADSIFRAOPISAPLACANJAIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADSIFRAOPISAPLACANJAIZUZECE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADSIFRAOPISAPLACANJAIZUZECE.Location = point;
            this.textZADSIFRAOPISAPLACANJAIZUZECE.Name = "textZADSIFRAOPISAPLACANJAIZUZECE";
            this.textZADSIFRAOPISAPLACANJAIZUZECE.Tag = "ZADSIFRAOPISAPLACANJAIZUZECE";
            this.textZADSIFRAOPISAPLACANJAIZUZECE.TabIndex = 0;
            this.textZADSIFRAOPISAPLACANJAIZUZECE.Anchor = AnchorStyles.Left;
            this.textZADSIFRAOPISAPLACANJAIZUZECE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADSIFRAOPISAPLACANJAIZUZECE.ReadOnly = false;
            this.textZADSIFRAOPISAPLACANJAIZUZECE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADSIFRAOPISAPLACANJAIZUZECE"));
            this.textZADSIFRAOPISAPLACANJAIZUZECE.MaxLength = 2;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADSIFRAOPISAPLACANJAIZUZECE, 1, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADSIFRAOPISAPLACANJAIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADSIFRAOPISAPLACANJAIZUZECE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADSIFRAOPISAPLACANJAIZUZECE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADSIFRAOPISAPLACANJAIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADSIFRAOPISAPLACANJAIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOPISPLACANJAIZUZECE.Location = point;
            this.label1ZADOPISPLACANJAIZUZECE.Name = "label1ZADOPISPLACANJAIZUZECE";
            this.label1ZADOPISPLACANJAIZUZECE.TabIndex = 1;
            this.label1ZADOPISPLACANJAIZUZECE.Tag = "labelZADOPISPLACANJAIZUZECE";
            this.label1ZADOPISPLACANJAIZUZECE.Text = "Opis plaćanja:";
            this.label1ZADOPISPLACANJAIZUZECE.StyleSetName = "FieldUltraLabel";
            this.label1ZADOPISPLACANJAIZUZECE.AutoSize = true;
            this.label1ZADOPISPLACANJAIZUZECE.Anchor = AnchorStyles.Left;
            this.label1ZADOPISPLACANJAIZUZECE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOPISPLACANJAIZUZECE.Appearance.ForeColor = Color.Black;
            this.label1ZADOPISPLACANJAIZUZECE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADOPISPLACANJAIZUZECE, 0, 2);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADOPISPLACANJAIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADOPISPLACANJAIZUZECE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOPISPLACANJAIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOPISPLACANJAIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0x67, 0x17);
            this.label1ZADOPISPLACANJAIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADOPISPLACANJAIZUZECE.Location = point;
            this.textZADOPISPLACANJAIZUZECE.Name = "textZADOPISPLACANJAIZUZECE";
            this.textZADOPISPLACANJAIZUZECE.Tag = "ZADOPISPLACANJAIZUZECE";
            this.textZADOPISPLACANJAIZUZECE.TabIndex = 0;
            this.textZADOPISPLACANJAIZUZECE.Anchor = AnchorStyles.Left;
            this.textZADOPISPLACANJAIZUZECE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADOPISPLACANJAIZUZECE.ReadOnly = false;
            this.textZADOPISPLACANJAIZUZECE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADOPISPLACANJAIZUZECE"));
            this.textZADOPISPLACANJAIZUZECE.MaxLength = 0x24;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADOPISPLACANJAIZUZECE, 1, 2);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADOPISPLACANJAIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADOPISPLACANJAIZUZECE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADOPISPLACANJAIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textZADOPISPLACANJAIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textZADOPISPLACANJAIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADTEKUCIIZUZECE.Location = point;
            this.label1ZADTEKUCIIZUZECE.Name = "label1ZADTEKUCIIZUZECE";
            this.label1ZADTEKUCIIZUZECE.TabIndex = 1;
            this.label1ZADTEKUCIIZUZECE.Tag = "labelZADTEKUCIIZUZECE";
            this.label1ZADTEKUCIIZUZECE.Text = "Zaštićeni tekuči račun:";
            this.label1ZADTEKUCIIZUZECE.StyleSetName = "FieldUltraLabel";
            this.label1ZADTEKUCIIZUZECE.AutoSize = true;
            this.label1ZADTEKUCIIZUZECE.Anchor = AnchorStyles.Left;
            this.label1ZADTEKUCIIZUZECE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADTEKUCIIZUZECE.Appearance.ForeColor = Color.Black;
            this.label1ZADTEKUCIIZUZECE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADTEKUCIIZUZECE, 0, 3);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADTEKUCIIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADTEKUCIIZUZECE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADTEKUCIIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADTEKUCIIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0x9b, 0x17);
            this.label1ZADTEKUCIIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADTEKUCIIZUZECE.Location = point;
            this.textZADTEKUCIIZUZECE.Name = "textZADTEKUCIIZUZECE";
            this.textZADTEKUCIIZUZECE.Tag = "ZADTEKUCIIZUZECE";
            this.textZADTEKUCIIZUZECE.TabIndex = 0;
            this.textZADTEKUCIIZUZECE.Anchor = AnchorStyles.Left;
            this.textZADTEKUCIIZUZECE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADTEKUCIIZUZECE.ReadOnly = false;
            this.textZADTEKUCIIZUZECE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADTEKUCIIZUZECE"));
            this.textZADTEKUCIIZUZECE.MaxLength = 10;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADTEKUCIIZUZECE, 1, 3);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADTEKUCIIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADTEKUCIIZUZECE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADTEKUCIIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZADTEKUCIIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZADTEKUCIIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADMOIZUZECE.Location = point;
            this.label1ZADMOIZUZECE.Name = "label1ZADMOIZUZECE";
            this.label1ZADMOIZUZECE.TabIndex = 1;
            this.label1ZADMOIZUZECE.Tag = "labelZADMOIZUZECE";
            this.label1ZADMOIZUZECE.Text = "Model odobrenja:";
            this.label1ZADMOIZUZECE.StyleSetName = "FieldUltraLabel";
            this.label1ZADMOIZUZECE.AutoSize = true;
            this.label1ZADMOIZUZECE.Anchor = AnchorStyles.Left;
            this.label1ZADMOIZUZECE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADMOIZUZECE.Appearance.ForeColor = Color.Black;
            this.label1ZADMOIZUZECE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADMOIZUZECE, 0, 4);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADMOIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADMOIZUZECE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADMOIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADMOIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1ZADMOIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADMOIZUZECE.Location = point;
            this.textZADMOIZUZECE.Name = "textZADMOIZUZECE";
            this.textZADMOIZUZECE.Tag = "ZADMOIZUZECE";
            this.textZADMOIZUZECE.TabIndex = 0;
            this.textZADMOIZUZECE.Anchor = AnchorStyles.Left;
            this.textZADMOIZUZECE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADMOIZUZECE.ReadOnly = false;
            this.textZADMOIZUZECE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADMOIZUZECE"));
            this.textZADMOIZUZECE.MaxLength = 2;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADMOIZUZECE, 1, 4);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADMOIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADMOIZUZECE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADMOIZUZECE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMOIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMOIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADPOIZUZECE.Location = point;
            this.label1ZADPOIZUZECE.Name = "label1ZADPOIZUZECE";
            this.label1ZADPOIZUZECE.TabIndex = 1;
            this.label1ZADPOIZUZECE.Tag = "labelZADPOIZUZECE";
            this.label1ZADPOIZUZECE.Text = "Poziv na broj odobrenja:";
            this.label1ZADPOIZUZECE.StyleSetName = "FieldUltraLabel";
            this.label1ZADPOIZUZECE.AutoSize = true;
            this.label1ZADPOIZUZECE.Anchor = AnchorStyles.Left;
            this.label1ZADPOIZUZECE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADPOIZUZECE.Appearance.ForeColor = Color.Black;
            this.label1ZADPOIZUZECE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADPOIZUZECE, 0, 5);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADPOIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADPOIZUZECE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADPOIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADPOIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1ZADPOIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADPOIZUZECE.Location = point;
            this.textZADPOIZUZECE.Name = "textZADPOIZUZECE";
            this.textZADPOIZUZECE.Tag = "ZADPOIZUZECE";
            this.textZADPOIZUZECE.TabIndex = 0;
            this.textZADPOIZUZECE.Anchor = AnchorStyles.Left;
            this.textZADPOIZUZECE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADPOIZUZECE.ContextMenu = this.contextMenu1;
            this.textZADPOIZUZECE.ReadOnly = false;
            this.textZADPOIZUZECE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADPOIZUZECE"));
            this.textZADPOIZUZECE.Nullable = true;
            this.textZADPOIZUZECE.MaxLength = 0x16;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADPOIZUZECE, 1, 5);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADPOIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADPOIZUZECE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADPOIZUZECE.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPOIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPOIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADMZIZUZECE.Location = point;
            this.label1ZADMZIZUZECE.Name = "label1ZADMZIZUZECE";
            this.label1ZADMZIZUZECE.TabIndex = 1;
            this.label1ZADMZIZUZECE.Tag = "labelZADMZIZUZECE";
            this.label1ZADMZIZUZECE.Text = "Model zaduženja:";
            this.label1ZADMZIZUZECE.StyleSetName = "FieldUltraLabel";
            this.label1ZADMZIZUZECE.AutoSize = true;
            this.label1ZADMZIZUZECE.Anchor = AnchorStyles.Left;
            this.label1ZADMZIZUZECE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADMZIZUZECE.Appearance.ForeColor = Color.Black;
            this.label1ZADMZIZUZECE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADMZIZUZECE, 0, 6);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADMZIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADMZIZUZECE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADMZIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADMZIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1ZADMZIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADMZIZUZECE.Location = point;
            this.textZADMZIZUZECE.Name = "textZADMZIZUZECE";
            this.textZADMZIZUZECE.Tag = "ZADMZIZUZECE";
            this.textZADMZIZUZECE.TabIndex = 0;
            this.textZADMZIZUZECE.Anchor = AnchorStyles.Left;
            this.textZADMZIZUZECE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADMZIZUZECE.ContextMenu = this.contextMenu1;
            this.textZADMZIZUZECE.ReadOnly = false;
            this.textZADMZIZUZECE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADMZIZUZECE"));
            this.textZADMZIZUZECE.Nullable = true;
            this.textZADMZIZUZECE.MaxLength = 2;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADMZIZUZECE, 1, 6);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADMZIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADMZIZUZECE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADMZIZUZECE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMZIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMZIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADPZIZUZECE.Location = point;
            this.label1ZADPZIZUZECE.Name = "label1ZADPZIZUZECE";
            this.label1ZADPZIZUZECE.TabIndex = 1;
            this.label1ZADPZIZUZECE.Tag = "labelZADPZIZUZECE";
            this.label1ZADPZIZUZECE.Text = "Poziv na broj zaduženja:";
            this.label1ZADPZIZUZECE.StyleSetName = "FieldUltraLabel";
            this.label1ZADPZIZUZECE.AutoSize = true;
            this.label1ZADPZIZUZECE.Anchor = AnchorStyles.Left;
            this.label1ZADPZIZUZECE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADPZIZUZECE.Appearance.ForeColor = Color.Black;
            this.label1ZADPZIZUZECE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADPZIZUZECE, 0, 7);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADPZIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADPZIZUZECE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADPZIZUZECE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADPZIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1ZADPZIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADPZIZUZECE.Location = point;
            this.textZADPZIZUZECE.Name = "textZADPZIZUZECE";
            this.textZADPZIZUZECE.Tag = "ZADPZIZUZECE";
            this.textZADPZIZUZECE.TabIndex = 0;
            this.textZADPZIZUZECE.Anchor = AnchorStyles.Left;
            this.textZADPZIZUZECE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADPZIZUZECE.ContextMenu = this.contextMenu1;
            this.textZADPZIZUZECE.ReadOnly = false;
            this.textZADPZIZUZECE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADPZIZUZECE"));
            this.textZADPZIZUZECE.Nullable = true;
            this.textZADPZIZUZECE.MaxLength = 0x16;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADPZIZUZECE, 1, 7);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADPZIZUZECE, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADPZIZUZECE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADPZIZUZECE.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPZIZUZECE.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPZIZUZECE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADIZNOSIZUZECA.Location = point;
            this.label1ZADIZNOSIZUZECA.Name = "label1ZADIZNOSIZUZECA";
            this.label1ZADIZNOSIZUZECA.TabIndex = 1;
            this.label1ZADIZNOSIZUZECA.Tag = "labelZADIZNOSIZUZECA";
            this.label1ZADIZNOSIZUZECA.Text = "Iznos izuzet od ovrhe:";
            this.label1ZADIZNOSIZUZECA.StyleSetName = "FieldUltraLabel";
            this.label1ZADIZNOSIZUZECA.AutoSize = true;
            this.label1ZADIZNOSIZUZECA.Anchor = AnchorStyles.Left;
            this.label1ZADIZNOSIZUZECA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADIZNOSIZUZECA.Appearance.ForeColor = Color.Black;
            this.label1ZADIZNOSIZUZECA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.label1ZADIZNOSIZUZECA, 0, 8);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.label1ZADIZNOSIZUZECA, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.label1ZADIZNOSIZUZECA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADIZNOSIZUZECA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADIZNOSIZUZECA.MinimumSize = size;
            size = new System.Drawing.Size(0x98, 0x17);
            this.label1ZADIZNOSIZUZECA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADIZNOSIZUZECA.Location = point;
            this.textZADIZNOSIZUZECA.Name = "textZADIZNOSIZUZECA";
            this.textZADIZNOSIZUZECA.Tag = "ZADIZNOSIZUZECA";
            this.textZADIZNOSIZUZECA.TabIndex = 0;
            this.textZADIZNOSIZUZECA.Anchor = AnchorStyles.Left;
            this.textZADIZNOSIZUZECA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADIZNOSIZUZECA.ReadOnly = false;
            this.textZADIZNOSIZUZECA.PromptChar = ' ';
            this.textZADIZNOSIZUZECA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADIZNOSIZUZECA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKIzuzeceOdOvrhe, "ZADIZNOSIZUZECA"));
            this.textZADIZNOSIZUZECA.NumericType = NumericType.Double;
            this.textZADIZNOSIZUZECA.MaxValue = 79228162514264337593543950335M;
            this.textZADIZNOSIZUZECA.MinValue = -79228162514264337593543950335M;
            this.textZADIZNOSIZUZECA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.Controls.Add(this.textZADIZNOSIZUZECA, 1, 8);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.textZADIZNOSIZUZECA, 1);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.SetRowSpan(this.textZADIZNOSIZUZECA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADIZNOSIZUZECA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSIZUZECA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSIZUZECA.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKIzuzeceOdOvrhe);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKIzuzeceOdOvrhe;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKIzuzeceOdOvrheUserControl";
            this.Text = " IzuzeceOdOvrhe";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.ResumeLayout(false);
            this.layoutManagerformRADNIKIzuzeceOdOvrhe.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKIzuzeceOdOvrhe).EndInit();
            ((ISupportInitialize) this.textBANKAZASTICENOIDBANKE).EndInit();
            ((ISupportInitialize) this.textZADSIFRAOPISAPLACANJAIZUZECE).EndInit();
            ((ISupportInitialize) this.textZADOPISPLACANJAIZUZECE).EndInit();
            ((ISupportInitialize) this.textZADTEKUCIIZUZECE).EndInit();
            ((ISupportInitialize) this.textZADMOIZUZECE).EndInit();
            ((ISupportInitialize) this.textZADPOIZUZECE).EndInit();
            ((ISupportInitialize) this.textZADMZIZUZECE).EndInit();
            ((ISupportInitialize) this.textZADPZIZUZECE).EndInit();
            ((ISupportInitialize) this.textZADIZNOSIZUZECA).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKIzuzeceOdOvrhe, this.RADNIKController.WorkItem, this))
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
            this.label1BANKAZASTICENOIDBANKE.Text = StringResources.RADNIKBANKAZASTICENOIDBANKEDescription;
            this.label1ZADSIFRAOPISAPLACANJAIZUZECE.Text = StringResources.RADNIKZADSIFRAOPISAPLACANJAIZUZECEDescription;
            this.label1ZADOPISPLACANJAIZUZECE.Text = StringResources.RADNIKZADOPISPLACANJAIZUZECEDescription;
            this.label1ZADTEKUCIIZUZECE.Text = StringResources.RADNIKZADTEKUCIIZUZECEDescription;
            this.label1ZADMOIZUZECE.Text = StringResources.RADNIKZADMOIZUZECEDescription;
            this.label1ZADPOIZUZECE.Text = StringResources.RADNIKZADPOIZUZECEDescription;
            this.label1ZADMZIZUZECE.Text = StringResources.RADNIKZADMZIZUZECEDescription;
            this.label1ZADPZIZUZECE.Text = StringResources.RADNIKZADPZIZUZECEDescription;
            this.label1ZADIZNOSIZUZECA.Text = StringResources.RADNIKZADIZNOSIZUZECADescription;
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

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKRADNIKIzuzeceOdOvrheLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKIzuzeceOdOvrhe|RADNIKIzuzeceOdOvrhe"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKIzuzeceOdOvrhe, "RADNIKIzuzeceOdOvrhe|RADNIKIzuzeceOdOvrhe");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKIzuzeceOdOvrheSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textBANKAZASTICENOIDBANKE.Focus();
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

        private void UpdateValuesBANKEBANKAZASTICENOIDBANKE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIKIzuzeceOdOvrhe.Current).Row["BANKAZASTICENOIDBANKE"] = RuntimeHelpers.GetObjectValue(result["IDBANKE"]);
                this.bindingSourceRADNIKIzuzeceOdOvrhe.ResetCurrentItem();
            }
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

        protected virtual UltraLabel label1BANKAZASTICENOIDBANKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BANKAZASTICENOIDBANKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BANKAZASTICENOIDBANKE = value;
            }
        }

        protected virtual UltraLabel label1ZADIZNOSIZUZECA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADIZNOSIZUZECA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADIZNOSIZUZECA = value;
            }
        }

        protected virtual UltraLabel label1ZADMOIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADMOIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADMOIZUZECE = value;
            }
        }

        protected virtual UltraLabel label1ZADMZIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADMZIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADMZIZUZECE = value;
            }
        }

        protected virtual UltraLabel label1ZADOPISPLACANJAIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOPISPLACANJAIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOPISPLACANJAIZUZECE = value;
            }
        }

        protected virtual UltraLabel label1ZADPOIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADPOIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADPOIZUZECE = value;
            }
        }

        protected virtual UltraLabel label1ZADPZIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADPZIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADPZIZUZECE = value;
            }
        }

        protected virtual UltraLabel label1ZADSIFRAOPISAPLACANJAIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADSIFRAOPISAPLACANJAIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADSIFRAOPISAPLACANJAIZUZECE = value;
            }
        }

        protected virtual UltraLabel label1ZADTEKUCIIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADTEKUCIIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADTEKUCIIZUZECE = value;
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

        protected virtual UltraNumericEditor textBANKAZASTICENOIDBANKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBANKAZASTICENOIDBANKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBANKAZASTICENOIDBANKE = value;
            }
        }

        protected virtual UltraNumericEditor textZADIZNOSIZUZECA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADIZNOSIZUZECA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADIZNOSIZUZECA = value;
            }
        }

        protected virtual UltraTextEditor textZADMOIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADMOIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADMOIZUZECE = value;
            }
        }

        protected virtual UltraTextEditor textZADMZIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADMZIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADMZIZUZECE = value;
            }
        }

        protected virtual UltraTextEditor textZADOPISPLACANJAIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADOPISPLACANJAIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADOPISPLACANJAIZUZECE = value;
            }
        }

        protected virtual UltraTextEditor textZADPOIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADPOIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADPOIZUZECE = value;
            }
        }

        protected virtual UltraTextEditor textZADPZIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADPZIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADPZIZUZECE = value;
            }
        }

        protected virtual UltraTextEditor textZADSIFRAOPISAPLACANJAIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADSIFRAOPISAPLACANJAIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADSIFRAOPISAPLACANJAIZUZECE = value;
            }
        }

        protected virtual UltraTextEditor textZADTEKUCIIZUZECE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADTEKUCIIZUZECE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADTEKUCIIZUZECE = value;
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

