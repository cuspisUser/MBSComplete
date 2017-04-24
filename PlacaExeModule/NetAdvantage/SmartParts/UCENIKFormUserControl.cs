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
    public class UCENIKFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMRODJENJAUCENIKA")]
        private UltraDateTimeEditor _datePickerDATUMRODJENJAUCENIKA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DATUMRODJENJAUCENIKA")]
        private UltraLabel _label1DATUMRODJENJAUCENIKA;
        [AccessedThroughProperty("label1IDUCENIK")]
        private UltraLabel _label1IDUCENIK;
        [AccessedThroughProperty("label1IMERODITELJA")]
        private UltraLabel _label1IMERODITELJA;
        [AccessedThroughProperty("label1IMEUCENIK")]
        private UltraLabel _label1IMEUCENIK;
        [AccessedThroughProperty("label1JMBGUCENIKA")]
        private UltraLabel _label1JMBGUCENIKA;
        [AccessedThroughProperty("label1NASELJE")]
        private UltraLabel _label1NASELJE;
        [AccessedThroughProperty("label1NAZIVPOSTE")]
        private UltraLabel _label1NAZIVPOSTE;
        
        [AccessedThroughProperty("lblID_Opcina")]
        private UltraLabel _lblID_Opcina;


        [AccessedThroughProperty("lblPrezimeRoditelj")]
        private UltraLabel _lblPrezimeRoditelj;
        [AccessedThroughProperty("lblOIBRoditelj")]
        private UltraLabel _lblOIBRoditelj;
        [AccessedThroughProperty("lblIBANRoditelj")]
        private UltraLabel _lblIBANRoditelj;

        [AccessedThroughProperty("label1ODJELJENJE")]
        private UltraLabel _label1ODJELJENJE;
        [AccessedThroughProperty("label1OIBUCENIK")]
        private UltraLabel _label1OIBUCENIK;
        [AccessedThroughProperty("label1POSTANSKIBROJ")]
        private UltraLabel _label1POSTANSKIBROJ;
        [AccessedThroughProperty("label1PREZIMEUCENIK")]
        private UltraLabel _label1PREZIMEUCENIK;
        [AccessedThroughProperty("label1RAZRED")]
        private UltraLabel _label1RAZRED;
        [AccessedThroughProperty("label1SPOLUCENIKA")]
        private UltraLabel _label1SPOLUCENIKA;
        [AccessedThroughProperty("label1ULICAIBROJ")]
        private UltraLabel _label1ULICAIBROJ;
        [AccessedThroughProperty("labelNAZIVPOSTE")]
        private UltraLabel _labelNAZIVPOSTE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDUCENIK")]
        private UltraNumericEditor _textIDUCENIK;
        [AccessedThroughProperty("textIMERODITELJA")]
        private UltraTextEditor _textIMERODITELJA;
        [AccessedThroughProperty("textIMEUCENIK")]
        private UltraTextEditor _textIMEUCENIK;
        [AccessedThroughProperty("textJMBGUCENIKA")]
        private UltraTextEditor _textJMBGUCENIKA;
        [AccessedThroughProperty("textNASELJE")]
        private UltraTextEditor _textNASELJE;
        [AccessedThroughProperty("textODJELJENJE")]
        private UltraTextEditor _textODJELJENJE;
        [AccessedThroughProperty("textOIBUCENIK")]
        private UltraTextEditor _textOIBUCENIK;
        [AccessedThroughProperty("textPOSTANSKIBROJ")]
        private UltraTextEditor _textPOSTANSKIBROJ;
        [AccessedThroughProperty("textID_Opcina")]
        private ComboBox _textID_Opcina;
        [AccessedThroughProperty("textPREZIMEUCENIK")]
        private UltraTextEditor _textPREZIMEUCENIK;

        [AccessedThroughProperty("textPrezimeRoditelj")]
        private UltraTextEditor _textPrezimeRoditelj;
        [AccessedThroughProperty("textOIBRoditelj")]
        private UltraTextEditor _textOIBRoditelj;
        [AccessedThroughProperty("textIBANRoditelj")]
        private UltraTextEditor _textIBANRoditelj;

        [AccessedThroughProperty("textRAZRED")]
        private UltraNumericEditor _textRAZRED;
        [AccessedThroughProperty("textSPOLUCENIKA")]
        private UltraTextEditor _textSPOLUCENIKA;
        [AccessedThroughProperty("textULICAIBROJ")]
        private UltraTextEditor _textULICAIBROJ;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceUCENIK;
        private IContainer components = null;
        private UCENIKDataSet dsUCENIKDataSet1;
        protected TableLayoutPanel layoutManagerformUCENIK;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private UCENIKDataSet.UCENIKRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "UCENIK";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.UCENIKDescription;
        private DeklaritMode m_Mode;

        public UCENIKFormUserControl()
        {
            this.InitializeComponent();
            NapuniOpcine();
            this.Localize();
            this.SetSize();
        }

        private void NapuniOpcine()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("Select IDOPCINE As ID, (IDOPCINE + ' - ' + NAZIVOPCINE) As Naziv From Opcina Order by IDOPCINE", client.sqlConnection);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            
            ComboID_Opcina.DisplayMember = "Naziv";
            ComboID_Opcina.ValueMember = "ID";
            ComboID_Opcina.DataSource = tbl;

            client.CloseConnection();
            command.Dispose();
            adapter.Dispose();
        }

        private void CallPromptPOSTANSKIBROJEVIPOSTANSKIBROJ(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.UCENIKController.SelectPOSTANSKIBROJEVIPOSTANSKIBROJ(fillMethod, fillByRow);
            this.UpdateValuesPOSTANSKIBROJEVIPOSTANSKIBROJ(result);
        }

        private void CallViewPOSTANSKIBROJEVIPOSTANSKIBROJ(object sender, EventArgs e)
        {
            DataRow result = this.UCENIKController.ShowPOSTANSKIBROJEVIPOSTANSKIBROJ(this.m_CurrentRow);
            this.UpdateValuesPOSTANSKIBROJEVIPOSTANSKIBROJ(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceUCENIK.DataSource = this.UCENIKController.DataSet;
            this.dsUCENIKDataSet1 = this.UCENIKController.DataSet;
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
                    enumerator = this.dsUCENIKDataSet1.UCENIK.Rows.GetEnumerator();
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
                if (this.UCENIKController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "UCENIK", this.m_Mode, this.dsUCENIKDataSet1, this.dsUCENIKDataSet1.UCENIK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceUCENIK, "DATUMRODJENJAUCENIKA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMRODJENJAUCENIKA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMRODJENJAUCENIKA.DataBindings.Remove(this.datePickerDATUMRODJENJAUCENIKA.DataBindings["Text"]);
            }
            this.datePickerDATUMRODJENJAUCENIKA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsUCENIKDataSet1.UCENIK[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (UCENIKDataSet.UCENIKRow) ((DataRowView) this.bindingSourceUCENIK.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(UCENIKFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceUCENIK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceUCENIK).BeginInit();
            this.layoutManagerformUCENIK = new TableLayoutPanel();
            this.layoutManagerformUCENIK.SuspendLayout();
            this.layoutManagerformUCENIK.AutoSize = true;
            this.layoutManagerformUCENIK.Dock = DockStyle.Fill;
            this.layoutManagerformUCENIK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformUCENIK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformUCENIK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformUCENIK.Size = size;
            this.layoutManagerformUCENIK.ColumnCount = 2;
            this.layoutManagerformUCENIK.RowCount = 15;
            this.layoutManagerformUCENIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUCENIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIK.RowStyles.Add(new RowStyle());
            this.label1IDUCENIK = new UltraLabel();
            this.textIDUCENIK = new UltraNumericEditor();
            this.label1PREZIMEUCENIK = new UltraLabel();
            this.textPREZIMEUCENIK = new UltraTextEditor();
            this.label1IMEUCENIK = new UltraLabel();
            this.textIMEUCENIK = new UltraTextEditor();
            this.label1OIBUCENIK = new UltraLabel();
            this.textOIBUCENIK = new UltraTextEditor();
            this.label1RAZRED = new UltraLabel();
            this.textRAZRED = new UltraNumericEditor();
            this.label1ODJELJENJE = new UltraLabel();
            this.textODJELJENJE = new UltraTextEditor();
            this.label1SPOLUCENIKA = new UltraLabel();
            this.textSPOLUCENIKA = new UltraTextEditor();
            this.label1ULICAIBROJ = new UltraLabel();
            this.textULICAIBROJ = new UltraTextEditor();
            this.label1NASELJE = new UltraLabel();
            this.textNASELJE = new UltraTextEditor();
            this.label1JMBGUCENIKA = new UltraLabel();
            this.textJMBGUCENIKA = new UltraTextEditor();
            this.label1DATUMRODJENJAUCENIKA = new UltraLabel();
            this.datePickerDATUMRODJENJAUCENIKA = new UltraDateTimeEditor();
            this.label1IMERODITELJA = new UltraLabel();
            this.textIMERODITELJA = new UltraTextEditor();
            this.label1POSTANSKIBROJ = new UltraLabel();
            this.textPOSTANSKIBROJ = new UltraTextEditor();
            this.label1NAZIVPOSTE = new UltraLabel();
            this.labelNAZIVPOSTE = new UltraLabel();
            lblID_opcina = new UltraLabel();
            ComboID_Opcina = new ComboBox();
            lblIBANRoditelj = new UltraLabel();
            lblPrezimeRoditelj = new UltraLabel();
            lblOIBRoditelj = new UltraLabel();
            texIBANRoditelj = new UltraTextEditor();
            textOIBRoditelj = new UltraTextEditor();
            textPrezimeRoditelj = new UltraTextEditor();

            ((ISupportInitialize) this.textIDUCENIK).BeginInit();
            ((ISupportInitialize) this.textPREZIMEUCENIK).BeginInit();
            ((ISupportInitialize) this.textIMEUCENIK).BeginInit();
            ((ISupportInitialize) this.textOIBUCENIK).BeginInit();
            ((ISupportInitialize) this.textRAZRED).BeginInit();
            ((ISupportInitialize) this.textODJELJENJE).BeginInit();
            ((ISupportInitialize) this.textSPOLUCENIKA).BeginInit();
            ((ISupportInitialize) this.textULICAIBROJ).BeginInit();
            ((ISupportInitialize) this.textNASELJE).BeginInit();
            ((ISupportInitialize) this.textJMBGUCENIKA).BeginInit();
            ((ISupportInitialize) this.textIMERODITELJA).BeginInit();
            ((ISupportInitialize) this.textPOSTANSKIBROJ).BeginInit();
            this.dsUCENIKDataSet1 = new UCENIKDataSet();
            this.dsUCENIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsUCENIKDataSet1.DataSetName = "dsUCENIK";
            this.dsUCENIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceUCENIK.DataSource = this.dsUCENIKDataSet1;
            this.bindingSourceUCENIK.DataMember = "UCENIK";
            ((ISupportInitialize) this.bindingSourceUCENIK).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDUCENIK.Location = point;
            this.label1IDUCENIK.Name = "label1IDUCENIK";
            this.label1IDUCENIK.TabIndex = 1;
            this.label1IDUCENIK.Tag = "labelIDUCENIK";
            this.label1IDUCENIK.Text = "Šif.uč.:";
            this.label1IDUCENIK.StyleSetName = "FieldUltraLabel";
            this.label1IDUCENIK.AutoSize = true;
            this.label1IDUCENIK.Anchor = AnchorStyles.Left;
            this.label1IDUCENIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDUCENIK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDUCENIK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDUCENIK.ImageSize = size;
            this.label1IDUCENIK.Appearance.ForeColor = Color.Black;
            this.label1IDUCENIK.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1IDUCENIK, 0, 0);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1IDUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1IDUCENIK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDUCENIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1IDUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDUCENIK.Location = point;
            this.textIDUCENIK.Name = "textIDUCENIK";
            this.textIDUCENIK.Tag = "IDUCENIK";
            this.textIDUCENIK.TabIndex = 0;
            this.textIDUCENIK.Anchor = AnchorStyles.Left;
            this.textIDUCENIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDUCENIK.ReadOnly = false;
            this.textIDUCENIK.PromptChar = ' ';
            //this.textIDUCENIK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDUCENIK.DataBindings.Add(new Binding("Value", this.bindingSourceUCENIK, "IDUCENIK"));
            this.textIDUCENIK.NumericType = NumericType.Integer;
            //this.textIDUCENIK.MaskInput = "{LOC}-nnnnn";
            this.textIDUCENIK.MaxValue = 999999;
            this.layoutManagerformUCENIK.Controls.Add(this.textIDUCENIK, 1, 0);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textIDUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textIDUCENIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDUCENIK.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PREZIMEUCENIK.Location = point;
            this.label1PREZIMEUCENIK.Name = "label1PREZIMEUCENIK";
            this.label1PREZIMEUCENIK.TabIndex = 1;
            this.label1PREZIMEUCENIK.Tag = "labelPREZIMEUCENIK";
            this.label1PREZIMEUCENIK.Text = "Prezime:";
            this.label1PREZIMEUCENIK.StyleSetName = "FieldUltraLabel";
            this.label1PREZIMEUCENIK.AutoSize = true;
            this.label1PREZIMEUCENIK.Anchor = AnchorStyles.Left;
            this.label1PREZIMEUCENIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1PREZIMEUCENIK.Appearance.ForeColor = Color.Black;
            this.label1PREZIMEUCENIK.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1PREZIMEUCENIK, 0, 1);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1PREZIMEUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1PREZIMEUCENIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PREZIMEUCENIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PREZIMEUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x45, 0x17);
            this.label1PREZIMEUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPREZIMEUCENIK.Location = point;
            this.textPREZIMEUCENIK.Name = "textPREZIMEUCENIK";
            this.textPREZIMEUCENIK.Tag = "PREZIMEUCENIK";
            this.textPREZIMEUCENIK.TabIndex = 0;
            this.textPREZIMEUCENIK.Anchor = AnchorStyles.Left;
            this.textPREZIMEUCENIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPREZIMEUCENIK.ReadOnly = false;
            this.textPREZIMEUCENIK.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "PREZIMEUCENIK"));
            this.textPREZIMEUCENIK.MaxLength = 50;
            this.layoutManagerformUCENIK.Controls.Add(this.textPREZIMEUCENIK, 1, 1);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textPREZIMEUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textPREZIMEUCENIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPREZIMEUCENIK.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPREZIMEUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPREZIMEUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IMEUCENIK.Location = point;
            this.label1IMEUCENIK.Name = "label1IMEUCENIK";
            this.label1IMEUCENIK.TabIndex = 1;
            this.label1IMEUCENIK.Tag = "labelIMEUCENIK";
            this.label1IMEUCENIK.Text = "Ime:";
            this.label1IMEUCENIK.StyleSetName = "FieldUltraLabel";
            this.label1IMEUCENIK.AutoSize = true;
            this.label1IMEUCENIK.Anchor = AnchorStyles.Left;
            this.label1IMEUCENIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IMEUCENIK.Appearance.ForeColor = Color.Black;
            this.label1IMEUCENIK.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1IMEUCENIK, 0, 2);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1IMEUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1IMEUCENIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IMEUCENIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IMEUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x17);
            this.label1IMEUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIMEUCENIK.Location = point;
            this.textIMEUCENIK.Name = "textIMEUCENIK";
            this.textIMEUCENIK.Tag = "IMEUCENIK";
            this.textIMEUCENIK.TabIndex = 0;
            this.textIMEUCENIK.Anchor = AnchorStyles.Left;
            this.textIMEUCENIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIMEUCENIK.ReadOnly = false;
            this.textIMEUCENIK.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "IMEUCENIK"));
            this.textIMEUCENIK.MaxLength = 50;
            this.layoutManagerformUCENIK.Controls.Add(this.textIMEUCENIK, 1, 2);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textIMEUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textIMEUCENIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIMEUCENIK.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textIMEUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textIMEUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OIBUCENIK.Location = point;
            this.label1OIBUCENIK.Name = "label1OIBUCENIK";
            this.label1OIBUCENIK.TabIndex = 1;
            this.label1OIBUCENIK.Tag = "labelOIBUCENIK";
            this.label1OIBUCENIK.Text = "OIB:";
            this.label1OIBUCENIK.StyleSetName = "FieldUltraLabel";
            this.label1OIBUCENIK.AutoSize = true;
            this.label1OIBUCENIK.Anchor = AnchorStyles.Left;
            this.label1OIBUCENIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1OIBUCENIK.Appearance.ForeColor = Color.Black;
            this.label1OIBUCENIK.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1OIBUCENIK, 0, 3);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1OIBUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1OIBUCENIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OIBUCENIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OIBUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x2b, 0x17);
            this.label1OIBUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOIBUCENIK.Location = point;
            this.textOIBUCENIK.Name = "textOIBUCENIK";
            this.textOIBUCENIK.Tag = "OIBUCENIK";
            this.textOIBUCENIK.TabIndex = 0;
            this.textOIBUCENIK.Anchor = AnchorStyles.Left;
            this.textOIBUCENIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOIBUCENIK.ReadOnly = false;
            this.textOIBUCENIK.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "OIBUCENIK"));
            this.textOIBUCENIK.MaxLength = 11;
            this.layoutManagerformUCENIK.Controls.Add(this.textOIBUCENIK, 1, 3);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textOIBUCENIK, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textOIBUCENIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOIBUCENIK.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textOIBUCENIK.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textOIBUCENIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAZRED.Location = point;
            this.label1RAZRED.Name = "label1RAZRED";
            this.label1RAZRED.TabIndex = 1;
            this.label1RAZRED.Tag = "labelRAZRED";
            this.label1RAZRED.Text = "RAZRED:";
            this.label1RAZRED.StyleSetName = "FieldUltraLabel";
            this.label1RAZRED.AutoSize = true;
            this.label1RAZRED.Anchor = AnchorStyles.Left;
            this.label1RAZRED.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZRED.Appearance.ForeColor = Color.Black;
            this.label1RAZRED.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1RAZRED, 0, 4);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1RAZRED, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1RAZRED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZRED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZRED.MinimumSize = size;
            size = new System.Drawing.Size(70, 0x17);
            this.label1RAZRED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAZRED.Location = point;
            this.textRAZRED.Name = "textRAZRED";
            this.textRAZRED.Tag = "RAZRED";
            this.textRAZRED.TabIndex = 0;
            this.textRAZRED.Anchor = AnchorStyles.Left;
            this.textRAZRED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAZRED.ReadOnly = false;
            this.textRAZRED.PromptChar = ' ';
            this.textRAZRED.Enter += new EventHandler(this.numericEditor_Enter);
            this.textRAZRED.DataBindings.Add(new Binding("Value", this.bindingSourceUCENIK, "RAZRED"));
            this.textRAZRED.NumericType = NumericType.Integer;
            this.textRAZRED.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformUCENIK.Controls.Add(this.textRAZRED, 1, 4);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textRAZRED, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textRAZRED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAZRED.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAZRED.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAZRED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ODJELJENJE.Location = point;
            this.label1ODJELJENJE.Name = "label1ODJELJENJE";
            this.label1ODJELJENJE.TabIndex = 1;
            this.label1ODJELJENJE.Tag = "labelODJELJENJE";
            this.label1ODJELJENJE.Text = "ODJELJENJE:";
            this.label1ODJELJENJE.StyleSetName = "FieldUltraLabel";
            this.label1ODJELJENJE.AutoSize = true;
            this.label1ODJELJENJE.Anchor = AnchorStyles.Left;
            this.label1ODJELJENJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ODJELJENJE.Appearance.ForeColor = Color.Black;
            this.label1ODJELJENJE.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1ODJELJENJE, 0, 5);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1ODJELJENJE, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1ODJELJENJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ODJELJENJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ODJELJENJE.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1ODJELJENJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textODJELJENJE.Location = point;
            this.textODJELJENJE.Name = "textODJELJENJE";
            this.textODJELJENJE.Tag = "ODJELJENJE";
            this.textODJELJENJE.TabIndex = 0;
            this.textODJELJENJE.Anchor = AnchorStyles.Left;
            this.textODJELJENJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textODJELJENJE.ReadOnly = false;
            this.textODJELJENJE.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "ODJELJENJE"));
            this.textODJELJENJE.MaxLength = 5;
            this.layoutManagerformUCENIK.Controls.Add(this.textODJELJENJE, 1, 5);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textODJELJENJE, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textODJELJENJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textODJELJENJE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textODJELJENJE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textODJELJENJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SPOLUCENIKA.Location = point;
            this.label1SPOLUCENIKA.Name = "label1SPOLUCENIKA";
            this.label1SPOLUCENIKA.TabIndex = 1;
            this.label1SPOLUCENIKA.Tag = "labelSPOLUCENIKA";
            this.label1SPOLUCENIKA.Text = "SPOLUCENIKA:";
            this.label1SPOLUCENIKA.StyleSetName = "FieldUltraLabel";
            this.label1SPOLUCENIKA.AutoSize = true;
            this.label1SPOLUCENIKA.Anchor = AnchorStyles.Left;
            this.label1SPOLUCENIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SPOLUCENIKA.Appearance.ForeColor = Color.Black;
            this.label1SPOLUCENIKA.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1SPOLUCENIKA, 0, 6);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1SPOLUCENIKA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1SPOLUCENIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SPOLUCENIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SPOLUCENIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x6d, 0x17);
            this.label1SPOLUCENIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSPOLUCENIKA.Location = point;
            this.textSPOLUCENIKA.Name = "textSPOLUCENIKA";
            this.textSPOLUCENIKA.Tag = "SPOLUCENIKA";
            this.textSPOLUCENIKA.TabIndex = 0;
            this.textSPOLUCENIKA.Anchor = AnchorStyles.Left;
            this.textSPOLUCENIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSPOLUCENIKA.ReadOnly = false;
            this.textSPOLUCENIKA.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "SPOLUCENIKA"));
            this.textSPOLUCENIKA.MaxLength = 1;
            this.layoutManagerformUCENIK.Controls.Add(this.textSPOLUCENIKA, 1, 6);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textSPOLUCENIKA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textSPOLUCENIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSPOLUCENIKA.Margin = padding;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textSPOLUCENIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textSPOLUCENIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ULICAIBROJ.Location = point;
            this.label1ULICAIBROJ.Name = "label1ULICAIBROJ";
            this.label1ULICAIBROJ.TabIndex = 1;
            this.label1ULICAIBROJ.Tag = "labelULICAIBROJ";
            this.label1ULICAIBROJ.Text = "ULICAIBROJ:";
            this.label1ULICAIBROJ.StyleSetName = "FieldUltraLabel";
            this.label1ULICAIBROJ.AutoSize = true;
            this.label1ULICAIBROJ.Anchor = AnchorStyles.Left;
            this.label1ULICAIBROJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1ULICAIBROJ.Appearance.ForeColor = Color.Black;
            this.label1ULICAIBROJ.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1ULICAIBROJ, 0, 7);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1ULICAIBROJ, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1ULICAIBROJ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ULICAIBROJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ULICAIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x61, 0x17);
            this.label1ULICAIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textULICAIBROJ.Location = point;
            this.textULICAIBROJ.Name = "textULICAIBROJ";
            this.textULICAIBROJ.Tag = "ULICAIBROJ";
            this.textULICAIBROJ.TabIndex = 0;
            this.textULICAIBROJ.Anchor = AnchorStyles.Left;
            this.textULICAIBROJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textULICAIBROJ.ReadOnly = false;
            this.textULICAIBROJ.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "ULICAIBROJ"));
            this.textULICAIBROJ.MaxLength = 50;
            this.layoutManagerformUCENIK.Controls.Add(this.textULICAIBROJ, 1, 7);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textULICAIBROJ, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textULICAIBROJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textULICAIBROJ.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textULICAIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textULICAIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NASELJE.Location = point;
            this.label1NASELJE.Name = "label1NASELJE";
            this.label1NASELJE.TabIndex = 1;
            this.label1NASELJE.Tag = "labelNASELJE";
            this.label1NASELJE.Text = "NASELJE:";
            this.label1NASELJE.StyleSetName = "FieldUltraLabel";
            this.label1NASELJE.AutoSize = true;
            this.label1NASELJE.Anchor = AnchorStyles.Left;
            this.label1NASELJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NASELJE.Appearance.ForeColor = Color.Black;
            this.label1NASELJE.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1NASELJE, 0, 8);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1NASELJE, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1NASELJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NASELJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NASELJE.MinimumSize = size;
            size = new System.Drawing.Size(0x49, 0x17);
            this.label1NASELJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNASELJE.Location = point;
            this.textNASELJE.Name = "textNASELJE";
            this.textNASELJE.Tag = "NASELJE";
            this.textNASELJE.TabIndex = 0;
            this.textNASELJE.Anchor = AnchorStyles.Left;
            this.textNASELJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNASELJE.ReadOnly = false;
            this.textNASELJE.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "NASELJE"));
            this.textNASELJE.MaxLength = 50;
            this.layoutManagerformUCENIK.Controls.Add(this.textNASELJE, 1, 8);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textNASELJE, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textNASELJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNASELJE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNASELJE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNASELJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1JMBGUCENIKA.Location = point;
            this.label1JMBGUCENIKA.Name = "label1JMBGUCENIKA";
            this.label1JMBGUCENIKA.TabIndex = 1;
            this.label1JMBGUCENIKA.Tag = "labelJMBGUCENIKA";
            this.label1JMBGUCENIKA.Text = "JMBGUCENIKA:";
            this.label1JMBGUCENIKA.StyleSetName = "FieldUltraLabel";
            this.label1JMBGUCENIKA.AutoSize = true;
            this.label1JMBGUCENIKA.Anchor = AnchorStyles.Left;
            this.label1JMBGUCENIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1JMBGUCENIKA.Appearance.ForeColor = Color.Black;
            this.label1JMBGUCENIKA.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1JMBGUCENIKA, 0, 9);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1JMBGUCENIKA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1JMBGUCENIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1JMBGUCENIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1JMBGUCENIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x6f, 0x17);
            this.label1JMBGUCENIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textJMBGUCENIKA.Location = point;
            this.textJMBGUCENIKA.Name = "textJMBGUCENIKA";
            this.textJMBGUCENIKA.Tag = "JMBGUCENIKA";
            this.textJMBGUCENIKA.TabIndex = 0;
            this.textJMBGUCENIKA.Anchor = AnchorStyles.Left;
            this.textJMBGUCENIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textJMBGUCENIKA.ReadOnly = false;
            this.textJMBGUCENIKA.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "JMBGUCENIKA"));
            this.textJMBGUCENIKA.MaxLength = 13;
            this.layoutManagerformUCENIK.Controls.Add(this.textJMBGUCENIKA, 1, 9);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textJMBGUCENIKA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textJMBGUCENIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textJMBGUCENIKA.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textJMBGUCENIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textJMBGUCENIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMRODJENJAUCENIKA.Location = point;
            this.label1DATUMRODJENJAUCENIKA.Name = "label1DATUMRODJENJAUCENIKA";
            this.label1DATUMRODJENJAUCENIKA.TabIndex = 1;
            this.label1DATUMRODJENJAUCENIKA.Tag = "labelDATUMRODJENJAUCENIKA";
            this.label1DATUMRODJENJAUCENIKA.Text = "DATUMRODJENJAUCENIKA:";
            this.label1DATUMRODJENJAUCENIKA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMRODJENJAUCENIKA.AutoSize = true;
            this.label1DATUMRODJENJAUCENIKA.Anchor = AnchorStyles.Left;
            this.label1DATUMRODJENJAUCENIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMRODJENJAUCENIKA.Appearance.ForeColor = Color.Black;
            this.label1DATUMRODJENJAUCENIKA.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1DATUMRODJENJAUCENIKA, 0, 10);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1DATUMRODJENJAUCENIKA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1DATUMRODJENJAUCENIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMRODJENJAUCENIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMRODJENJAUCENIKA.MinimumSize = size;
            size = new System.Drawing.Size(0xbc, 0x17);
            this.label1DATUMRODJENJAUCENIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMRODJENJAUCENIKA.Location = point;
            this.datePickerDATUMRODJENJAUCENIKA.Name = "datePickerDATUMRODJENJAUCENIKA";
            this.datePickerDATUMRODJENJAUCENIKA.Tag = "DATUMRODJENJAUCENIKA";
            this.datePickerDATUMRODJENJAUCENIKA.TabIndex = 0;
            this.datePickerDATUMRODJENJAUCENIKA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMRODJENJAUCENIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMRODJENJAUCENIKA.Enabled = true;
            this.layoutManagerformUCENIK.Controls.Add(this.datePickerDATUMRODJENJAUCENIKA, 1, 10);
            this.layoutManagerformUCENIK.SetColumnSpan(this.datePickerDATUMRODJENJAUCENIKA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.datePickerDATUMRODJENJAUCENIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMRODJENJAUCENIKA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMRODJENJAUCENIKA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMRODJENJAUCENIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IMERODITELJA.Location = point;
            this.label1IMERODITELJA.Name = "label1IMERODITELJA";
            this.label1IMERODITELJA.TabIndex = 1;
            this.label1IMERODITELJA.Tag = "labelIMERODITELJA";
            this.label1IMERODITELJA.Text = "IMERODITELJA:";
            this.label1IMERODITELJA.StyleSetName = "FieldUltraLabel";
            this.label1IMERODITELJA.AutoSize = true;
            this.label1IMERODITELJA.Anchor = AnchorStyles.Left;
            this.label1IMERODITELJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IMERODITELJA.Appearance.ForeColor = Color.Black;
            this.label1IMERODITELJA.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1IMERODITELJA, 0, 11);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1IMERODITELJA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1IMERODITELJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IMERODITELJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IMERODITELJA.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.label1IMERODITELJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIMERODITELJA.Location = point;
            this.textIMERODITELJA.Name = "textIMERODITELJA";
            this.textIMERODITELJA.Tag = "IMERODITELJA";
            this.textIMERODITELJA.TabIndex = 0;
            this.textIMERODITELJA.Anchor = AnchorStyles.Left;
            this.textIMERODITELJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIMERODITELJA.ReadOnly = false;
            this.textIMERODITELJA.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "IMERODITELJA"));
            this.textIMERODITELJA.MaxLength = 50;
            this.layoutManagerformUCENIK.Controls.Add(this.textIMERODITELJA, 1, 11);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textIMERODITELJA, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textIMERODITELJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIMERODITELJA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textIMERODITELJA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textIMERODITELJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POSTANSKIBROJ.Location = point;
            this.label1POSTANSKIBROJ.Name = "label1POSTANSKIBROJ";
            this.label1POSTANSKIBROJ.TabIndex = 1;
            this.label1POSTANSKIBROJ.Tag = "labelPOSTANSKIBROJ";
            this.label1POSTANSKIBROJ.Text = "POSTANSKIBROJ:";
            this.label1POSTANSKIBROJ.StyleSetName = "FieldUltraLabel";
            this.label1POSTANSKIBROJ.AutoSize = true;
            this.label1POSTANSKIBROJ.Anchor = AnchorStyles.Left;
            this.label1POSTANSKIBROJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1POSTANSKIBROJ.Appearance.ForeColor = Color.Black;
            this.label1POSTANSKIBROJ.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1POSTANSKIBROJ, 0, 12);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1POSTANSKIBROJ, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1POSTANSKIBROJ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POSTANSKIBROJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POSTANSKIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 0x17);
            this.label1POSTANSKIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOSTANSKIBROJ.Location = point;
            this.textPOSTANSKIBROJ.Name = "textPOSTANSKIBROJ";
            this.textPOSTANSKIBROJ.Tag = "POSTANSKIBROJ";
            this.textPOSTANSKIBROJ.TabIndex = 0;
            this.textPOSTANSKIBROJ.Anchor = AnchorStyles.Left;
            this.textPOSTANSKIBROJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOSTANSKIBROJ.ReadOnly = false;
            this.textPOSTANSKIBROJ.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "POSTANSKIBROJ"));
            this.textPOSTANSKIBROJ.MaxLength = 5;
            EditorButton button = new EditorButton {
                Key = "editorButtonPOSTANSKIBROJEVIPOSTANSKIBROJ",
                Tag = "editorButtonPOSTANSKIBROJEVIPOSTANSKIBROJ",
                Text = "..."
            };
            this.textPOSTANSKIBROJ.ButtonsRight.Add(button);
            this.textPOSTANSKIBROJ.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptPOSTANSKIBROJEVIPOSTANSKIBROJ);
            this.layoutManagerformUCENIK.Controls.Add(this.textPOSTANSKIBROJ, 1, 12);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textPOSTANSKIBROJ, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textPOSTANSKIBROJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOSTANSKIBROJ.Margin = padding;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textPOSTANSKIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textPOSTANSKIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPOSTE.Location = point;
            this.label1NAZIVPOSTE.Name = "label1NAZIVPOSTE";
            this.label1NAZIVPOSTE.TabIndex = 1;
            this.label1NAZIVPOSTE.Tag = "labelNAZIVPOSTE";
            this.label1NAZIVPOSTE.Text = "NAZIVPOSTE:";
            this.label1NAZIVPOSTE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPOSTE.AutoSize = true;
            this.label1NAZIVPOSTE.Anchor = AnchorStyles.Left;
            this.label1NAZIVPOSTE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPOSTE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPOSTE.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.label1NAZIVPOSTE, 0, 13);
            this.layoutManagerformUCENIK.SetColumnSpan(this.label1NAZIVPOSTE, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.label1NAZIVPOSTE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPOSTE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPOSTE.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.label1NAZIVPOSTE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVPOSTE.Location = point;
            this.labelNAZIVPOSTE.Name = "labelNAZIVPOSTE";
            this.labelNAZIVPOSTE.Tag = "NAZIVPOSTE";
            this.labelNAZIVPOSTE.TabIndex = 0;
            this.labelNAZIVPOSTE.Anchor = AnchorStyles.Left;
            this.labelNAZIVPOSTE.BackColor = Color.Transparent;
            this.labelNAZIVPOSTE.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "NAZIVPOSTE"));
            this.labelNAZIVPOSTE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformUCENIK.Controls.Add(this.labelNAZIVPOSTE, 1, 13);
            this.layoutManagerformUCENIK.SetColumnSpan(this.labelNAZIVPOSTE, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.labelNAZIVPOSTE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVPOSTE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVPOSTE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVPOSTE.Size = size;






            this.lblID_opcina.Location = point;
            this.lblID_opcina.Name = "lblID_opcina";
            this.lblID_opcina.TabIndex = 100;
            this.lblID_opcina.Tag = "lblID_opcina";
            this.lblID_opcina.Text = "Općina";
            this.lblID_opcina.StyleSetName = "FieldUltraLabel";
            this.lblID_opcina.AutoSize = true;
            this.lblID_opcina.Anchor = AnchorStyles.Left;
            this.lblID_opcina.Appearance.TextVAlign = VAlign.Middle;
            this.lblID_opcina.Appearance.ForeColor = Color.Black;
            this.lblID_opcina.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.lblID_opcina, 0, 14);
            this.layoutManagerformUCENIK.SetColumnSpan(this.lblID_opcina, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.lblID_opcina, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblID_opcina.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.lblID_opcina.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.lblID_opcina.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.lblPrezimeRoditelj.Location = point;
            this.lblPrezimeRoditelj.Name = "lblPrezimeRoditelj";
            this.lblPrezimeRoditelj.TabIndex = 102;
            this.lblPrezimeRoditelj.Tag = "lblPrezimeRoditelj";
            this.lblPrezimeRoditelj.Text = "Prezime Roditelj:";
            this.lblPrezimeRoditelj.StyleSetName = "FieldUltraLabel";
            this.lblPrezimeRoditelj.AutoSize = true;
            this.lblPrezimeRoditelj.Anchor = AnchorStyles.Left;
            this.lblPrezimeRoditelj.Appearance.TextVAlign = VAlign.Middle;
            this.lblPrezimeRoditelj.Appearance.ForeColor = Color.Black;
            this.lblPrezimeRoditelj.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.lblPrezimeRoditelj, 0, 15);
            this.layoutManagerformUCENIK.SetColumnSpan(this.lblPrezimeRoditelj, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.lblPrezimeRoditelj, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblPrezimeRoditelj.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.lblPrezimeRoditelj.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.lblPrezimeRoditelj.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.lblOIBRoditelj.Location = point;
            this.lblOIBRoditelj.Name = "lblOIBRoditelj";
            this.lblOIBRoditelj.TabIndex = 104;
            this.lblOIBRoditelj.Tag = "lblOIBRoditelj";
            this.lblOIBRoditelj.Text = "OIB Roditelj:";
            this.lblOIBRoditelj.StyleSetName = "FieldUltraLabel";
            this.lblOIBRoditelj.AutoSize = true;
            this.lblOIBRoditelj.Anchor = AnchorStyles.Left;
            this.lblOIBRoditelj.Appearance.TextVAlign = VAlign.Middle;
            this.lblOIBRoditelj.Appearance.ForeColor = Color.Black;
            this.lblOIBRoditelj.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.lblOIBRoditelj, 0, 16);
            this.layoutManagerformUCENIK.SetColumnSpan(this.lblOIBRoditelj, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.lblOIBRoditelj, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblOIBRoditelj.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.lblOIBRoditelj.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.lblOIBRoditelj.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.lblIBANRoditelj.Location = point;
            this.lblIBANRoditelj.Name = "lblIBANRoditelj";
            this.lblIBANRoditelj.TabIndex = 106;
            this.lblIBANRoditelj.Tag = "lblIBANRoditelj";
            this.lblIBANRoditelj.Text = "IBAN Roditelj:";
            this.lblIBANRoditelj.StyleSetName = "FieldUltraLabel";
            this.lblIBANRoditelj.AutoSize = true;
            this.lblIBANRoditelj.Anchor = AnchorStyles.Left;
            this.lblIBANRoditelj.Appearance.TextVAlign = VAlign.Middle;
            this.lblIBANRoditelj.Appearance.ForeColor = Color.Black;
            this.lblIBANRoditelj.BackColor = Color.Transparent;
            this.layoutManagerformUCENIK.Controls.Add(this.lblIBANRoditelj, 0, 17);
            this.layoutManagerformUCENIK.SetColumnSpan(this.lblIBANRoditelj, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.lblIBANRoditelj, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblIBANRoditelj.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.lblIBANRoditelj.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.lblIBANRoditelj.Size = size;


            this.ComboID_Opcina.Location = point;
            this.ComboID_Opcina.Name = "cmbOpcina";
            this.ComboID_Opcina.Tag = "cmbOpcina";
            this.ComboID_Opcina.TabIndex = 101;
            this.ComboID_Opcina.Anchor = AnchorStyles.Left;
            this.ComboID_Opcina.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "ID_Opcina"));
            this.layoutManagerformUCENIK.Controls.Add(this.ComboID_Opcina, 1, 14);
            this.layoutManagerformUCENIK.SetColumnSpan(this.ComboID_Opcina, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.ComboID_Opcina, 1);
            padding = new Padding(0, 1, 3, 2);
            this.ComboID_Opcina.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.ComboID_Opcina.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.ComboID_Opcina.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.textPrezimeRoditelj.Location = point;
            this.textPrezimeRoditelj.Name = "textPrezimeRoditelj";
            this.textPrezimeRoditelj.Tag = "textPrezimeRoditelj";
            this.textPrezimeRoditelj.TabIndex = 103;
            this.textPrezimeRoditelj.Anchor = AnchorStyles.Left;
            this.textPrezimeRoditelj.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPrezimeRoditelj.ReadOnly = false;
            this.textPrezimeRoditelj.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "PrezimeRoditelj"));
            this.textPrezimeRoditelj.MaxLength = 50;
            this.layoutManagerformUCENIK.Controls.Add(this.textPrezimeRoditelj, 1, 15);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textPrezimeRoditelj, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textPrezimeRoditelj, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPrezimeRoditelj.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPrezimeRoditelj.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPrezimeRoditelj.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.textOIBRoditelj.Location = point;
            this.textOIBRoditelj.Name = "textOIBRoditelj";
            this.textOIBRoditelj.Tag = "textOIBRoditelj";
            this.textOIBRoditelj.TabIndex = 105;
            this.textOIBRoditelj.Anchor = AnchorStyles.Left;
            this.textOIBRoditelj.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOIBRoditelj.ReadOnly = false;
            this.textOIBRoditelj.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "OIBRoditelj"));
            this.textOIBRoditelj.MaxLength = 11;
            this.layoutManagerformUCENIK.Controls.Add(this.textOIBRoditelj, 1, 16);
            this.layoutManagerformUCENIK.SetColumnSpan(this.textOIBRoditelj, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.textOIBRoditelj, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOIBRoditelj.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textOIBRoditelj.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textOIBRoditelj.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.texIBANRoditelj.Location = point;
            this.texIBANRoditelj.Name = "texIBANRoditelj";
            this.texIBANRoditelj.Tag = "texIBANRoditelj";
            this.texIBANRoditelj.TabIndex = 107;
            this.texIBANRoditelj.Anchor = AnchorStyles.Left;
            this.texIBANRoditelj.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.texIBANRoditelj.ReadOnly = false;
            this.texIBANRoditelj.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIK, "IBANRoditelj"));
            this.texIBANRoditelj.MaxLength = 30;
            this.layoutManagerformUCENIK.Controls.Add(this.texIBANRoditelj, 1, 17);
            this.layoutManagerformUCENIK.SetColumnSpan(this.texIBANRoditelj, 1);
            this.layoutManagerformUCENIK.SetRowSpan(this.texIBANRoditelj, 1);
            padding = new Padding(0, 1, 3, 2);
            this.texIBANRoditelj.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.texIBANRoditelj.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.texIBANRoditelj.Size = size;




            this.Controls.Add(this.layoutManagerformUCENIK);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceUCENIK;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "UCENIKFormUserControl";
            this.Text = "UCENIK";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.UCENIKFormUserControl_Load);
            this.layoutManagerformUCENIK.ResumeLayout(false);
            this.layoutManagerformUCENIK.PerformLayout();
            ((ISupportInitialize) this.bindingSourceUCENIK).EndInit();
            ((ISupportInitialize) this.textIDUCENIK).EndInit();
            ((ISupportInitialize) this.textPREZIMEUCENIK).EndInit();
            ((ISupportInitialize) this.textIMEUCENIK).EndInit();
            ((ISupportInitialize) this.textOIBUCENIK).EndInit();
            ((ISupportInitialize) this.textRAZRED).EndInit();
            ((ISupportInitialize) this.textODJELJENJE).EndInit();
            ((ISupportInitialize) this.textSPOLUCENIKA).EndInit();
            ((ISupportInitialize) this.textULICAIBROJ).EndInit();
            ((ISupportInitialize) this.textNASELJE).EndInit();
            ((ISupportInitialize) this.textJMBGUCENIKA).EndInit();
            ((ISupportInitialize) this.textIMERODITELJA).EndInit();
            ((ISupportInitialize) this.textPOSTANSKIBROJ).EndInit();
            this.dsUCENIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.UCENIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceUCENIK, this.UCENIKController.WorkItem, this))
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
            this.label1IDUCENIK.Text = StringResources.UCENIKIDUCENIKDescription;
            this.label1PREZIMEUCENIK.Text = StringResources.UCENIKPREZIMEUCENIKDescription;
            this.label1IMEUCENIK.Text = StringResources.UCENIKIMEUCENIKDescription;
            this.label1OIBUCENIK.Text = StringResources.UCENIKOIBUCENIKDescription;
            this.label1RAZRED.Text = StringResources.UCENIKRAZREDDescription;
            this.label1ODJELJENJE.Text = StringResources.UCENIKODJELJENJEDescription;
            this.label1SPOLUCENIKA.Text = StringResources.UCENIKSPOLUCENIKADescription;
            this.label1ULICAIBROJ.Text = StringResources.UCENIKULICAIBROJDescription;
            this.label1NASELJE.Text = StringResources.UCENIKNASELJEDescription;
            this.label1JMBGUCENIKA.Text = StringResources.UCENIKJMBGUCENIKADescription;
            this.label1DATUMRODJENJAUCENIKA.Text = StringResources.UCENIKDATUMRODJENJAUCENIKADescription;
            this.label1IMERODITELJA.Text = StringResources.UCENIKIMERODITELJADescription;
            this.label1POSTANSKIBROJ.Text = StringResources.UCENIKPOSTANSKIBROJDescription;
            this.label1NAZIVPOSTE.Text = StringResources.UCENIKNAZIVPOSTEDescription;
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
            if (!this.UCENIKController.WorkItem.Items.Contains("UCENIK|UCENIK"))
            {
                this.UCENIKController.WorkItem.Items.Add(this.bindingSourceUCENIK, "UCENIK|UCENIK");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsUCENIKDataSet1.UCENIK.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.UCENIKController.Update(this);
            }
            UpdateOpcina((int)textIDUCENIK.Value);
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UCENIKController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            UpdateOpcina((int)textIDUCENIK.Value);
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UCENIKController.Update(this))
            {
                this.UCENIKController.DataSet = new UCENIKDataSet();
                DataSetUtil.AddEmptyRow(this.UCENIKController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.UCENIKController.DataSet.UCENIK[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
            UpdateOpcina((int)textIDUCENIK.Value);
        }

        private void UpdateOpcina(int id)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
            command.Connection = client.sqlConnection;

            if (ComboID_Opcina.Text.Length > 0)
            {
                command.CommandText = "Update Ucenik Set ID_Opcina = '" + ComboID_Opcina.SelectedValue + "', PrezimeRoditelj = '" + textPrezimeRoditelj.Text + 
                                      "', OIBRoditelj = '" + textOIBRoditelj.Text + "', IBANRoditelj = '" + texIBANRoditelj.Text + "' Where IDUCENIK= '" + id + "'";
            }
            else
            {
                command.CommandText = "Update Ucenik Set ID_Opcina = NULL, PrezimeRoditelj = '" + textPrezimeRoditelj.Text +
                                      "', OIBRoditelj = '" + textOIBRoditelj.Text + "', IBANRoditelj = '" + texIBANRoditelj.Text + "' Where IDUCENIK= '" + id + "'";
            }

            command.ExecuteNonQuery();

            command.Dispose();
            UCENIKController.Update(this);
        }

        private void SetFocusInFirstField()
        {
            this.textIDUCENIK.Focus();
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

        private void UCENIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.UCENIKDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void UpdateValuesPOSTANSKIBROJEVIPOSTANSKIBROJ(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceUCENIK.Current).Row["POSTANSKIBROJ"] = RuntimeHelpers.GetObjectValue(result["POSTANSKIBROJ"]);
                ((DataRowView) this.bindingSourceUCENIK.Current).Row["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(result["NAZIVPOSTE"]);
                this.bindingSourceUCENIK.ResetCurrentItem();
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

        protected virtual UltraDateTimeEditor datePickerDATUMRODJENJAUCENIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMRODJENJAUCENIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMRODJENJAUCENIKA = value;
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

        protected virtual UltraLabel label1DATUMRODJENJAUCENIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMRODJENJAUCENIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMRODJENJAUCENIKA = value;
            }
        }

        protected virtual UltraLabel label1IDUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDUCENIK = value;
            }
        }

        protected virtual UltraLabel label1IMERODITELJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IMERODITELJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IMERODITELJA = value;
            }
        }

        protected virtual UltraLabel label1IMEUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IMEUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IMEUCENIK = value;
            }
        }

        protected virtual UltraLabel label1JMBGUCENIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1JMBGUCENIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1JMBGUCENIKA = value;
            }
        }

        protected virtual UltraLabel label1NASELJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NASELJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NASELJE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPOSTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPOSTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPOSTE = value;
            }
        }

        protected virtual UltraLabel lblID_opcina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblID_Opcina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblID_Opcina= value;
            }
        }


        protected virtual UltraLabel lblOIBRoditelj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblOIBRoditelj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblOIBRoditelj = value;
            }
        }


        protected virtual UltraLabel lblIBANRoditelj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblIBANRoditelj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblIBANRoditelj = value;
            }
        }

        protected virtual UltraLabel lblPrezimeRoditelj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblPrezimeRoditelj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblPrezimeRoditelj = value;
            }
        }


        protected virtual UltraLabel label1ODJELJENJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ODJELJENJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ODJELJENJE = value;
            }
        }

        protected virtual UltraLabel label1OIBUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OIBUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OIBUCENIK = value;
            }
        }

        protected virtual UltraLabel label1POSTANSKIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POSTANSKIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POSTANSKIBROJ = value;
            }
        }

        protected virtual UltraLabel label1PREZIMEUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PREZIMEUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PREZIMEUCENIK = value;
            }
        }

        protected virtual UltraLabel label1RAZRED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZRED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZRED = value;
            }
        }

        protected virtual UltraLabel label1SPOLUCENIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SPOLUCENIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SPOLUCENIKA = value;
            }
        }

        protected virtual UltraLabel label1ULICAIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ULICAIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ULICAIBROJ = value;
            }
        }

        protected virtual UltraLabel labelNAZIVPOSTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVPOSTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVPOSTE = value;
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

        protected virtual UltraNumericEditor textIDUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDUCENIK = value;
            }
        }

        protected virtual UltraTextEditor textIMERODITELJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIMERODITELJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIMERODITELJA = value;
            }
        }

        protected virtual UltraTextEditor textIMEUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIMEUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIMEUCENIK = value;
            }
        }

        protected virtual UltraTextEditor textJMBGUCENIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textJMBGUCENIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textJMBGUCENIKA = value;
            }
        }

        protected virtual UltraTextEditor textNASELJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNASELJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNASELJE = value;
            }
        }

        protected virtual UltraTextEditor textODJELJENJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textODJELJENJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textODJELJENJE = value;
            }
        }

        protected virtual UltraTextEditor textOIBUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOIBUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOIBUCENIK = value;
            }
        }

        protected virtual UltraTextEditor textPOSTANSKIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOSTANSKIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOSTANSKIBROJ = value;
            }
        }

        protected virtual ComboBox ComboID_Opcina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textID_Opcina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textID_Opcina = value;
            }
        }


        protected virtual UltraTextEditor textPrezimeRoditelj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPrezimeRoditelj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPrezimeRoditelj = value;
            }
        }

        protected virtual UltraTextEditor textOIBRoditelj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOIBRoditelj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOIBRoditelj = value;
            }
        }

        protected virtual UltraTextEditor texIBANRoditelj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIBANRoditelj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIBANRoditelj = value;
            }
        }

        protected virtual UltraTextEditor textPREZIMEUCENIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPREZIMEUCENIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPREZIMEUCENIK = value;
            }
        }

        protected virtual UltraNumericEditor textRAZRED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAZRED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAZRED = value;
            }
        }

        protected virtual UltraTextEditor textSPOLUCENIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSPOLUCENIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSPOLUCENIKA = value;
            }
        }

        protected virtual UltraTextEditor textULICAIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textULICAIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textULICAIBROJ = value;
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
        public NetAdvantage.Controllers.UCENIKController UCENIKController { get; set; }
    }
}

