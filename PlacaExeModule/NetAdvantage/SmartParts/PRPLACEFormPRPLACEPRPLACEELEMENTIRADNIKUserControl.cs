namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
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
    public class PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDRADNIK")]
        private PregledRadnikaComboBox _comboIDRADNIK;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDRADNIK")]
        private UltraLabel _label1IDRADNIK;
        [AccessedThroughProperty("label1IME")]
        private UltraLabel _label1IME;
        [AccessedThroughProperty("label1PREZIME")]
        private UltraLabel _label1PREZIME;
        [AccessedThroughProperty("label1PRPLACEIZNOS")]
        private UltraLabel _label1PRPLACEIZNOS;
        [AccessedThroughProperty("label1PRPLACEPOSTOTAK")]
        private UltraLabel _label1PRPLACEPOSTOTAK;
        [AccessedThroughProperty("label1PRPLACESATI")]
        private UltraLabel _label1PRPLACESATI;
        [AccessedThroughProperty("label1PRPLACESATNICA")]
        private UltraLabel _label1PRPLACESATNICA;
        [AccessedThroughProperty("labelIME")]
        private UltraLabel _labelIME;
        [AccessedThroughProperty("labelPREZIME")]
        private UltraLabel _labelPREZIME;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textPRPLACEIZNOS")]
        private UltraNumericEditor _textPRPLACEIZNOS;
        [AccessedThroughProperty("textPRPLACEPOSTOTAK")]
        private UltraNumericEditor _textPRPLACEPOSTOTAK;
        [AccessedThroughProperty("textPRPLACESATI")]
        private UltraNumericEditor _textPRPLACESATI;
        [AccessedThroughProperty("textPRPLACESATNICA")]
        private UltraNumericEditor _textPRPLACESATNICA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePRPLACEPRPLACEELEMENTIRADNIK;
        private IContainer components;
        private PRPLACEDataSet dsPRPLACEDataSet1;
        protected TableLayoutPanel layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK;
        private bool m_AutoNumber;
        private GenericFormClass m_BaseMethods;
        private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow m_CurrentRow;
        private ArrayList m_DataGrids;
        private string m_FirstLevelName;
        private string m_FrameworkDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl()
        {
            base.Disposed += new EventHandler(this.PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl_Disposed);
            base.Load += new EventHandler(this.PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl_Load);
            base.Validating += new CancelEventHandler(this.PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl_Validating);
            this.components = null;
            this.m_FrameworkDescription = StringResources.PRPLACEDescription;
            this.m_DataGrids = new ArrayList();
            this.m_FirstLevelName = "PRPLACEPRPLACEELEMENTIRADNIK";
            this.m_AutoNumber = false;
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("PRPLACEPRPLACEELEMENTIRADNIKAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("PRPLACEPRPLACEELEMENTIRADNIKAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPRPLACEDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataSource = this.PRPLACEController.DataSet;
            this.dsPRPLACEDataSet1 = this.PRPLACEController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
        public void comboIDRADNIK_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDRADNIK.Fill();
        }

        private void comboIDRADNIK_Validating(object sender, CancelEventArgs e)
        {
            if (this.comboIDRADNIK.Value != DBNull.Value)
            {
                decimal num4 = 0;
                decimal num5 = 0;

                try
                {
                    num4 = Conversions.ToDecimal(this.m_ParentRow.GetParentRow("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK").GetParentRow("PRPLACE_PRPLACEPRPLACEELEMENTI")[4]);
                }
                catch (System.Exception)
                {                    
                    num4 = 0;
                }

                try
                {
                    num4 = Conversions.ToDecimal(this.m_ParentRow.GetParentRow("PRPLACE_PRPLACEPRPLACEELEMENTI")[4]);
                }
                catch (System.Exception)
                {
                    num4 = 0;
                }

                try
                {
                    num5 = Conversions.ToDecimal(this.m_ParentRow.GetParentRow("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK").GetParentRow("PRPLACE_PRPLACEPRPLACEELEMENTI")[5]);
                }
                catch (System.Exception)
                {
                    num5 = 0;
                }

                try
                {
                    num5 = Conversions.ToDecimal(this.m_ParentRow.GetParentRow("PRPLACE_PRPLACEPRPLACEELEMENTI")["prplacesati"]);
                }
                catch (System.Exception)
                {
                    num5 = 0;
                }

                int num = Conversions.ToInteger(this.m_ParentRow["prplacezagodinu"]);
                int num3 = Conversions.ToInteger(this.m_ParentRow["prplacezamjesec"]);
                int element = Conversions.ToInteger(this.m_ParentRow["idelement"]);
                ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.Current).Row["PRPLACESATNICA"] = DB.RoundUpDecimale(placa.Test(Conversions.ToInteger(this.comboIDRADNIK.Value), element, Configuration.ConnectionString, num4, num5), 2);
                ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.Current).Row["PRPLACepostotak"] = RuntimeHelpers.GetObjectValue(this.m_CurrentRow.GetParentRow("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK")[5]);
                this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.ResetCurrentItem();
            }
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
            this.dsPRPLACEDataSet1 = (PRPLACEDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsPRPLACEDataSet1.Tables["PRPLACEPRPLACEELEMENTIRADNIK"]);
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PRPLACE", this.m_Mode, this.dsPRPLACEDataSet1, this.dsPRPLACEDataSet1.PRPLACEPRPLACEELEMENTIRADNIK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK).BeginInit();
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK = new TableLayoutPanel();
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SuspendLayout();
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.AutoSize = true;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Dock = DockStyle.Fill;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Size = size;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.ColumnCount = 2;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowCount = 8;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.label1IDRADNIK = new UltraLabel();
            this.comboIDRADNIK = new PregledRadnikaComboBox();
            this.label1PREZIME = new UltraLabel();
            this.labelPREZIME = new UltraLabel();
            this.label1IME = new UltraLabel();
            this.labelIME = new UltraLabel();
            this.label1PRPLACESATI = new UltraLabel();
            this.textPRPLACESATI = new UltraNumericEditor();
            this.label1PRPLACESATNICA = new UltraLabel();
            this.textPRPLACESATNICA = new UltraNumericEditor();
            this.label1PRPLACEPOSTOTAK = new UltraLabel();
            this.textPRPLACEPOSTOTAK = new UltraNumericEditor();
            this.label1PRPLACEIZNOS = new UltraLabel();
            this.textPRPLACEIZNOS = new UltraNumericEditor();
            ((ISupportInitialize) this.textPRPLACESATI).BeginInit();
            ((ISupportInitialize) this.textPRPLACESATNICA).BeginInit();
            ((ISupportInitialize) this.textPRPLACEPOSTOTAK).BeginInit();
            ((ISupportInitialize) this.textPRPLACEIZNOS).BeginInit();
            this.dsPRPLACEDataSet1 = new PRPLACEDataSet();
            this.dsPRPLACEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPRPLACEDataSet1.DataSetName = "dsPRPLACE";
            this.dsPRPLACEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataSource = this.dsPRPLACEDataSet1;
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataMember = "PRPLACEPRPLACEELEMENTIRADNIK";
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNIK.Location = point;
            this.label1IDRADNIK.Name = "label1IDRADNIK";
            this.label1IDRADNIK.TabIndex = 1;
            this.label1IDRADNIK.Tag = "labelIDRADNIK";
            this.label1IDRADNIK.Text = "Zaposlenik:";
            this.label1IDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNIK.AutoSize = true;
            this.label1IDRADNIK.Anchor = AnchorStyles.Left;
            this.label1IDRADNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNIK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRADNIK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRADNIK.ImageSize = size;
            this.label1IDRADNIK.Appearance.ForeColor = Color.Black;
            this.label1IDRADNIK.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.label1IDRADNIK, 0, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.label1IDRADNIK, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.label1IDRADNIK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x53, 0x17);
            this.label1IDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDRADNIK.Location = point;
            this.comboIDRADNIK.Name = "comboIDRADNIK";
            this.comboIDRADNIK.Tag = "IDRADNIK";
            this.comboIDRADNIK.TabIndex = 0;
            this.comboIDRADNIK.Anchor = AnchorStyles.Left;
            this.comboIDRADNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDRADNIK.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNIK.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNIK.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDRADNIK.Enabled = true;
            this.comboIDRADNIK.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "IDRADNIK"));
            this.comboIDRADNIK.ShowPictureBox = true;
            this.comboIDRADNIK.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDRADNIK);
            this.comboIDRADNIK.ValueMember = "IDRADNIK";
            this.comboIDRADNIK.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDRADNIK);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.comboIDRADNIK, 1, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.comboIDRADNIK, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.comboIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PREZIME.Location = point;
            this.label1PREZIME.Name = "label1PREZIME";
            this.label1PREZIME.TabIndex = 1;
            this.label1PREZIME.Tag = "labelPREZIME";
            this.label1PREZIME.Text = "Prezime:";
            this.label1PREZIME.StyleSetName = "FieldUltraLabel";
            this.label1PREZIME.AutoSize = true;
            this.label1PREZIME.Anchor = AnchorStyles.Left;
            this.label1PREZIME.Appearance.TextVAlign = VAlign.Middle;
            this.label1PREZIME.Appearance.ForeColor = Color.Black;
            this.label1PREZIME.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.label1PREZIME, 0, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.label1PREZIME, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.label1PREZIME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PREZIME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x45, 0x17);
            this.label1PREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPREZIME.Location = point;
            this.labelPREZIME.Name = "labelPREZIME";
            this.labelPREZIME.Tag = "PREZIME";
            this.labelPREZIME.TabIndex = 0;
            this.labelPREZIME.Anchor = AnchorStyles.Left;
            this.labelPREZIME.BackColor = Color.Transparent;
            this.labelPREZIME.DataBindings.Add(new Binding("Text", this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "PREZIME"));
            this.labelPREZIME.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.labelPREZIME, 1, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.labelPREZIME, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.labelPREZIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPREZIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelPREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelPREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IME.Location = point;
            this.label1IME.Name = "label1IME";
            this.label1IME.TabIndex = 1;
            this.label1IME.Tag = "labelIME";
            this.label1IME.Text = "Ime:";
            this.label1IME.StyleSetName = "FieldUltraLabel";
            this.label1IME.AutoSize = true;
            this.label1IME.Anchor = AnchorStyles.Left;
            this.label1IME.Appearance.TextVAlign = VAlign.Middle;
            this.label1IME.Appearance.ForeColor = Color.Black;
            this.label1IME.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.label1IME, 0, 2);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.label1IME, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.label1IME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IME.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x17);
            this.label1IME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIME.Location = point;
            this.labelIME.Name = "labelIME";
            this.labelIME.Tag = "IME";
            this.labelIME.TabIndex = 0;
            this.labelIME.Anchor = AnchorStyles.Left;
            this.labelIME.BackColor = Color.Transparent;
            this.labelIME.DataBindings.Add(new Binding("Text", this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "IME"));
            this.labelIME.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.labelIME, 1, 2);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.labelIME, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.labelIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACESATI.Location = point;
            this.label1PRPLACESATI.Name = "label1PRPLACESATI";
            this.label1PRPLACESATI.TabIndex = 1;
            this.label1PRPLACESATI.Tag = "labelPRPLACESATI";
            this.label1PRPLACESATI.Text = "Sati:";
            this.label1PRPLACESATI.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACESATI.AutoSize = true;
            this.label1PRPLACESATI.Anchor = AnchorStyles.Left;
            this.label1PRPLACESATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACESATI.Appearance.ForeColor = Color.Black;
            this.label1PRPLACESATI.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.label1PRPLACESATI, 0, 3);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.label1PRPLACESATI, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.label1PRPLACESATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACESATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACESATI.MinimumSize = size;
            size = new System.Drawing.Size(0x2b, 0x17);
            this.label1PRPLACESATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACESATI.Location = point;
            this.textPRPLACESATI.Name = "textPRPLACESATI";
            this.textPRPLACESATI.Tag = "PRPLACESATI";
            this.textPRPLACESATI.TabIndex = 0;
            this.textPRPLACESATI.Anchor = AnchorStyles.Left;
            this.textPRPLACESATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACESATI.ReadOnly = false;
            this.textPRPLACESATI.PromptChar = ' ';
            this.textPRPLACESATI.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACESATI.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "PRPLACESATI"));
            this.textPRPLACESATI.NumericType = NumericType.Double;
            this.textPRPLACESATI.MaxValue = 79228162514264337593543950335M;
            this.textPRPLACESATI.MinValue = -79228162514264337593543950335M;
            this.textPRPLACESATI.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.textPRPLACESATI, 1, 3);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.textPRPLACESATI, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.textPRPLACESATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACESATI.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPRPLACESATI.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPRPLACESATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACESATNICA.Location = point;
            this.label1PRPLACESATNICA.Name = "label1PRPLACESATNICA";
            this.label1PRPLACESATNICA.TabIndex = 1;
            this.label1PRPLACESATNICA.Tag = "labelPRPLACESATNICA";
            this.label1PRPLACESATNICA.Text = "Satnica:";
            this.label1PRPLACESATNICA.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACESATNICA.AutoSize = true;
            this.label1PRPLACESATNICA.Anchor = AnchorStyles.Left;
            this.label1PRPLACESATNICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACESATNICA.Appearance.ForeColor = Color.Black;
            this.label1PRPLACESATNICA.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.label1PRPLACESATNICA, 0, 4);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.label1PRPLACESATNICA, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.label1PRPLACESATNICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACESATNICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACESATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1PRPLACESATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACESATNICA.Location = point;
            this.textPRPLACESATNICA.Name = "textPRPLACESATNICA";
            this.textPRPLACESATNICA.Tag = "PRPLACESATNICA";
            this.textPRPLACESATNICA.TabIndex = 0;
            this.textPRPLACESATNICA.Anchor = AnchorStyles.Left;
            this.textPRPLACESATNICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACESATNICA.ReadOnly = false;
            this.textPRPLACESATNICA.PromptChar = ' ';
            this.textPRPLACESATNICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACESATNICA.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "PRPLACESATNICA"));
            this.textPRPLACESATNICA.NumericType = NumericType.Double;
            this.textPRPLACESATNICA.MaxValue = 79228162514264337593543950335M;
            this.textPRPLACESATNICA.MinValue = -79228162514264337593543950335M;
            this.textPRPLACESATNICA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.textPRPLACESATNICA, 1, 4);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.textPRPLACESATNICA, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.textPRPLACESATNICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACESATNICA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPRPLACESATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPRPLACESATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEPOSTOTAK.Location = point;
            this.label1PRPLACEPOSTOTAK.Name = "label1PRPLACEPOSTOTAK";
            this.label1PRPLACEPOSTOTAK.TabIndex = 1;
            this.label1PRPLACEPOSTOTAK.Tag = "labelPRPLACEPOSTOTAK";
            this.label1PRPLACEPOSTOTAK.Text = "Postotak:";
            this.label1PRPLACEPOSTOTAK.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEPOSTOTAK.AutoSize = true;
            this.label1PRPLACEPOSTOTAK.Anchor = AnchorStyles.Left;
            this.label1PRPLACEPOSTOTAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEPOSTOTAK.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEPOSTOTAK.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.label1PRPLACEPOSTOTAK, 0, 5);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.label1PRPLACEPOSTOTAK, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.label1PRPLACEPOSTOTAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x4a, 0x17);
            this.label1PRPLACEPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEPOSTOTAK.Location = point;
            this.textPRPLACEPOSTOTAK.Name = "textPRPLACEPOSTOTAK";
            this.textPRPLACEPOSTOTAK.Tag = "PRPLACEPOSTOTAK";
            this.textPRPLACEPOSTOTAK.TabIndex = 0;
            this.textPRPLACEPOSTOTAK.Anchor = AnchorStyles.Left;
            this.textPRPLACEPOSTOTAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEPOSTOTAK.ReadOnly = false;
            this.textPRPLACEPOSTOTAK.PromptChar = ' ';
            this.textPRPLACEPOSTOTAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACEPOSTOTAK.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "PRPLACEPOSTOTAK"));
            this.textPRPLACEPOSTOTAK.NumericType = NumericType.Double;
            this.textPRPLACEPOSTOTAK.MaxValue = 79228162514264337593543950335M;
            this.textPRPLACEPOSTOTAK.MinValue = -79228162514264337593543950335M;
            this.textPRPLACEPOSTOTAK.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.textPRPLACEPOSTOTAK, 1, 5);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.textPRPLACEPOSTOTAK, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.textPRPLACEPOSTOTAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPRPLACEPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPRPLACEPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEIZNOS.Location = point;
            this.label1PRPLACEIZNOS.Name = "label1PRPLACEIZNOS";
            this.label1PRPLACEIZNOS.TabIndex = 1;
            this.label1PRPLACEIZNOS.Tag = "labelPRPLACEIZNOS";
            this.label1PRPLACEIZNOS.Text = "Iznos:";
            this.label1PRPLACEIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEIZNOS.AutoSize = true;
            this.label1PRPLACEIZNOS.Anchor = AnchorStyles.Left;
            this.label1PRPLACEIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEIZNOS.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.label1PRPLACEIZNOS, 0, 6);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.label1PRPLACEIZNOS, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.label1PRPLACEIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1PRPLACEIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEIZNOS.Location = point;
            this.textPRPLACEIZNOS.Name = "textPRPLACEIZNOS";
            this.textPRPLACEIZNOS.Tag = "PRPLACEIZNOS";
            this.textPRPLACEIZNOS.TabIndex = 0;
            this.textPRPLACEIZNOS.Anchor = AnchorStyles.Left;
            this.textPRPLACEIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEIZNOS.ReadOnly = false;
            this.textPRPLACEIZNOS.PromptChar = ' ';
            this.textPRPLACEIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACEIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "PRPLACEIZNOS"));
            this.textPRPLACEIZNOS.NumericType = NumericType.Double;
            this.textPRPLACEIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textPRPLACEIZNOS.MinValue = -79228162514264337593543950335M;
            this.textPRPLACEIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.textPRPLACEIZNOS, 1, 6);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.textPRPLACEIZNOS, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.textPRPLACEIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRPLACEIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRPLACEIZNOS.Size = size;
            this.Controls.Add(this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl";
            this.Text = " Radnici u pripremi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PRPLACEFormUserControl_Load);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.ResumeLayout(false);
            this.layoutManagerformPRPLACEPRPLACEELEMENTIRADNIK.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK).EndInit();
            ((ISupportInitialize) this.textPRPLACESATI).EndInit();
            ((ISupportInitialize) this.textPRPLACESATNICA).EndInit();
            ((ISupportInitialize) this.textPRPLACEPOSTOTAK).EndInit();
            ((ISupportInitialize) this.textPRPLACEIZNOS).EndInit();
            this.dsPRPLACEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PRPLACEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, this.PRPLACEController.WorkItem, this))
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
            this.label1IDRADNIK.Text = StringResources.PRPLACEIDRADNIKDescription;
            this.label1PREZIME.Text = StringResources.PRPLACEPREZIMEDescription;
            this.label1IME.Text = StringResources.PRPLACEIMEDescription;
            this.label1PRPLACESATI.Text = StringResources.PRPLACEPRPLACESATIDescription;
            this.label1PRPLACESATNICA.Text = StringResources.PRPLACEPRPLACESATNICADescription;
            this.label1PRPLACEPOSTOTAK.Text = StringResources.PRPLACEPRPLACEPOSTOTAKDescription;
            this.label1PRPLACEIZNOS.Text = StringResources.PRPLACEPRPLACEIZNOSDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDRADNIK(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNIK", null, DeklaritMode.Insert));
            }
        }

        private void PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl_Disposed(object sender, EventArgs e)
        {
        }

        private void PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl_Load(object sender, EventArgs e)
        {
        }

        private void PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl_Validating(object sender, CancelEventArgs e)
        {
        }

        private void PRPLACEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.PRPLACEController.WorkItem.Items.Contains("PRPLACEPRPLACEELEMENTIRADNIK|PRPLACEPRPLACEELEMENTIRADNIK"))
            {
                this.PRPLACEController.WorkItem.Items.Add(this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "PRPLACEPRPLACEELEMENTIRADNIK|PRPLACEPRPLACEELEMENTIRADNIK");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("PRPLACEPRPLACEELEMENTIRADNIKSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDRADNIK(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDRADNIK.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDRADNIK.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.Current).Row["IDRADNIK"] = RuntimeHelpers.GetObjectValue(row["IDRADNIK"]);
                    ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.Current).Row["PREZIME"] = RuntimeHelpers.GetObjectValue(row["PREZIME"]);
                    ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.Current).Row["IME"] = RuntimeHelpers.GetObjectValue(row["IME"]);
                    this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDRADNIK.Focus();
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

        private void textPRPLACEPOSTOTAK_Validating(object sender, CancelEventArgs e)
        {
            if (!((this.textPRPLACEPOSTOTAK.Value == DBNull.Value) | (this.textPRPLACESATI.Value == DBNull.Value)))
            {
                this.textPRPLACEIZNOS.Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(decimal.Multiply(Conversions.ToDecimal(this.textPRPLACESATI.Value), Conversions.ToDecimal(this.textPRPLACESATNICA.Value)), Conversions.ToDecimal(this.textPRPLACEPOSTOTAK.Value)), 100M), 2);
            }
        }

        private void textPRPLACESATI_Validating(object sender, CancelEventArgs e)
        {
            if (!((this.textPRPLACEPOSTOTAK.Value == DBNull.Value) | (this.textPRPLACESATI.Value == DBNull.Value)))
            {
                this.textPRPLACEIZNOS.Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(decimal.Multiply(Conversions.ToDecimal(this.textPRPLACESATI.Value), Conversions.ToDecimal(this.textPRPLACESATNICA.Value)), Conversions.ToDecimal(this.textPRPLACEPOSTOTAK.Value)), 100M), 2);
            }
        }

        private void textPRPLACESATNICA_Validating(object sender, CancelEventArgs e)
        {
            if (!((this.textPRPLACEPOSTOTAK.Value == DBNull.Value) | (this.textPRPLACESATI.Value == DBNull.Value)))
            {
                this.textPRPLACEIZNOS.Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(decimal.Multiply(Conversions.ToDecimal(this.textPRPLACESATI.Value), Conversions.ToDecimal(this.textPRPLACESATNICA.Value)), Conversions.ToDecimal(this.textPRPLACEPOSTOTAK.Value)), 100M), 2);
            }
        }

        protected virtual PregledRadnikaComboBox comboIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.comboIDRADNIK_Validating);
                if (this._comboIDRADNIK != null)
                {
                    this._comboIDRADNIK.Validating -= handler;
                }
                this._comboIDRADNIK = value;
                if (this._comboIDRADNIK != null)
                {
                    this._comboIDRADNIK.Validating += handler;
                }
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

        protected virtual UltraLabel label1IDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNIK = value;
            }
        }

        protected virtual UltraLabel label1IME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IME = value;
            }
        }

        protected virtual UltraLabel label1PREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PREZIME = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEIZNOS = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEPOSTOTAK = value;
            }
        }

        protected virtual UltraLabel label1PRPLACESATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACESATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACESATI = value;
            }
        }

        protected virtual UltraLabel label1PRPLACESATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACESATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACESATNICA = value;
            }
        }

        protected virtual UltraLabel labelIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIME = value;
            }
        }

        protected virtual UltraLabel labelPREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPREZIME = value;
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
        public NetAdvantage.Controllers.PRPLACEController PRPLACEController { get; set; }

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

        protected virtual UltraNumericEditor textPRPLACEIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRPLACEIZNOS = value;
            }
        }

        protected virtual UltraNumericEditor textPRPLACEPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textPRPLACEPOSTOTAK_Validating);
                if (this._textPRPLACEPOSTOTAK != null)
                {
                    this._textPRPLACEPOSTOTAK.Validating -= handler;
                }
                this._textPRPLACEPOSTOTAK = value;
                if (this._textPRPLACEPOSTOTAK != null)
                {
                    this._textPRPLACEPOSTOTAK.Validating += handler;
                }
            }
        }

        protected virtual UltraNumericEditor textPRPLACESATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACESATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textPRPLACESATI_Validating);
                if (this._textPRPLACESATI != null)
                {
                    this._textPRPLACESATI.Validating -= handler;
                }
                this._textPRPLACESATI = value;
                if (this._textPRPLACESATI != null)
                {
                    this._textPRPLACESATI.Validating += handler;
                }
            }
        }

        protected virtual UltraNumericEditor textPRPLACESATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACESATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textPRPLACESATNICA_Validating);
                if (this._textPRPLACESATNICA != null)
                {
                    this._textPRPLACESATNICA.Validating -= handler;
                }
                this._textPRPLACESATNICA = value;
                if (this._textPRPLACESATNICA != null)
                {
                    this._textPRPLACESATNICA.Validating += handler;
                }
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

