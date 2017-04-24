namespace Obracun
{
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmEleUnosSvi : Form
    {
        public ObracunSmartPart _ParentFormObracun;
        private string _sSifra;
        public string _vrsta;
        private IContainer components { get; set; }
        private bool m_b_MogucePreklapanjeRazdoblja;
        private Label label1;
        private ComboBox cmbMjesecOsiguranja;
        private string m_sIDOsnovaOsiguranja;

        public frmEleUnosSvi()
        {
            base.Load += new EventHandler(this.frmEleUnosSvi_Load);
            this.InitializeComponent();
        }

        private void cbSifra_Enter(object sender, EventArgs e)
        {
            this._sSifra = Conversions.ToString(this.cbSifra.Value);
        }

        private void cbSifra_GotFocus(object sender, EventArgs e)
        {
            this.cbSifra.ToggleDropdown();
        }

        private void cbSifra_Validating(object sender, CancelEventArgs e)
        {
            if (this._sSifra != this.cbSifra.Value.ToString())
            {
                DataRow[] rowArray = null;
                bool flag = false;
                if ((this.cbSifra.Value != null) && DB.IsInteger(Conversions.ToString(this.cbSifra.Value)))
                {
                    rowArray = this.ElementDataSet1.ELEMENT.Select("IDELEMENT = " + Conversions.ToString(DB.N20(DB.IzvuciSamoBrojke(Conversions.ToString(this.cbSifra.Value), true))));
                }
                this.m_sIDOsnovaOsiguranja = "";
                this.m_b_MogucePreklapanjeRazdoblja = false;
                if ((rowArray != null) && (rowArray.Length > 0))
                {
                    this.labelNaziv.Text = Conversions.ToString(rowArray[0]["NAZIVELEMENT"]);
                    this.Postotak.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["POSTOTAK"]);
                    this.m_sIDOsnovaOsiguranja = DB.N2T(RuntimeHelpers.GetObjectValue(rowArray[0]["IDOSNOVAOSIGURANJA"]), "");
                    this.m_b_MogucePreklapanjeRazdoblja = DB.N2B(RuntimeHelpers.GetObjectValue(rowArray[0]["RAZDOBLJESESMIJEPREKLAPATI"]));
                    flag = true;
                }
                if (!flag)
                {
                    this.labelNaziv.Text = "";
                    this.Postotak.Value = 0;
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

        private void NapuniMjesecOsiguranja()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            cmbMjesecOsiguranja.DataSource = client.GetDataTable("Select Oznaka, KratkiOpis From JOPPDOznakaMjesecaOsiguranje");
            cmbMjesecOsiguranja.ValueMember = "Oznaka";
            cmbMjesecOsiguranja.DisplayMember = "KratkiOpis";
            cmbMjesecOsiguranja.SelectedValue = 3;
        }

        private void frmEleUnosSvi_Load(object sender, EventArgs e)
        {
            this.NapuniElemente();
            this.OdDatuma.Value = DateAndTime.DateSerial(Conversions.ToInteger(this._ParentFormObracun.godinaobracuna), Conversions.ToInteger(this._ParentFormObracun.mjesecobracuna), 1);
            this.DoDatuma.Value = DateAndTime.DateSerial(Conversions.ToInteger(this._ParentFormObracun.godinaobracuna), Conversions.ToInteger(this._ParentFormObracun.mjesecobracuna), DateTime.DaysInMonth(Conversions.ToInteger(this._ParentFormObracun.godinaobracuna), Conversions.ToInteger(this._ParentFormObracun.mjesecobracuna)));
            this.BrojSati.Validating += new CancelEventHandler(this.UpdateIznosa);
            this.Satnica.Validating += new CancelEventHandler(this.UpdateIznosa);
            this.Postotak.Validating += new CancelEventHandler(this.UpdateIznosa);
            this.cbSifra.Select();
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);

            NapuniMjesecOsiguranja();
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ELEMENT", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVRSTAELEMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTAELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSNOVAOSIGURANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSNOVAOSIGURANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZDOBLJESESMIJEPREKLAPATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTOTAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZBRAJASATEUFONDSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTAVLJAMZPZSVIMVIRMANIMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EL");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEleUnosSvi));
            this.label1IDVRSTAELEMENTA = new Infragistics.Win.Misc.UltraLabel();
            this.label1NAZIVVRSTAELEMENT = new Infragistics.Win.Misc.UltraLabel();
            this.labelSifEle = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.labelNaziv = new Infragistics.Win.Misc.UltraLabel();
            this.OdDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.DoDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.BrojSati = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Satnica = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Postotak = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Iznos = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.UltraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.cbSifra = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ElementDataSet1 = new Placa.ELEMENTDataSet();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMjesecOsiguranja = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.OdDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrojSati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Satnica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Postotak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1IDVRSTAELEMENTA
            // 
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.label1IDVRSTAELEMENTA.Appearance = appearance12;
            this.label1IDVRSTAELEMENTA.BackColorInternal = System.Drawing.Color.Transparent;
            this.label1IDVRSTAELEMENTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1IDVRSTAELEMENTA.Location = new System.Drawing.Point(9, 36);
            this.label1IDVRSTAELEMENTA.Name = "label1IDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.Size = new System.Drawing.Size(107, 23);
            this.label1IDVRSTAELEMENTA.TabIndex = 4;
            this.label1IDVRSTAELEMENTA.Text = "Od datuma:";
            // 
            // label1NAZIVVRSTAELEMENT
            // 
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.label1NAZIVVRSTAELEMENT.Appearance = appearance23;
            this.label1NAZIVVRSTAELEMENT.BackColorInternal = System.Drawing.Color.Transparent;
            this.label1NAZIVVRSTAELEMENT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1NAZIVVRSTAELEMENT.Location = new System.Drawing.Point(9, 60);
            this.label1NAZIVVRSTAELEMENT.Name = "label1NAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.Size = new System.Drawing.Size(107, 23);
            this.label1NAZIVVRSTAELEMENT.TabIndex = 6;
            this.label1NAZIVVRSTAELEMENT.Text = "Do datuma:";
            // 
            // labelSifEle
            // 
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.labelSifEle.Appearance = appearance27;
            this.labelSifEle.BackColorInternal = System.Drawing.Color.Transparent;
            this.labelSifEle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSifEle.Location = new System.Drawing.Point(9, 10);
            this.labelSifEle.Name = "labelSifEle";
            this.labelSifEle.Size = new System.Drawing.Size(107, 23);
            this.labelSifEle.TabIndex = 0;
            this.labelSifEle.Text = "Bruto element:";
            // 
            // UltraLabel2
            // 
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.UltraLabel2.Appearance = appearance14;
            this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(9, 84);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(107, 23);
            this.UltraLabel2.TabIndex = 8;
            this.UltraLabel2.Text = "Broj sati:";
            // 
            // UltraLabel3
            // 
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.UltraLabel3.Appearance = appearance15;
            this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(9, 108);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(107, 23);
            this.UltraLabel3.TabIndex = 11;
            this.UltraLabel3.Text = "IzracunSatnice:";
            // 
            // UltraLabel4
            // 
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.UltraLabel4.Appearance = appearance16;
            this.UltraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel4.Location = new System.Drawing.Point(9, 132);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(107, 23);
            this.UltraLabel4.TabIndex = 13;
            this.UltraLabel4.Text = "Postotak:";
            // 
            // UltraLabel5
            // 
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.UltraLabel5.Appearance = appearance17;
            this.UltraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel5.Location = new System.Drawing.Point(9, 156);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(107, 23);
            this.UltraLabel5.TabIndex = 15;
            this.UltraLabel5.Text = "Iznos:";
            // 
            // labelNaziv
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.FontData.BoldAsString = "True";
            appearance18.TextVAlignAsString = "Middle";
            this.labelNaziv.Appearance = appearance18;
            this.labelNaziv.BackColorInternal = System.Drawing.SystemColors.ControlLight;
            this.labelNaziv.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelNaziv.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelNaziv.Location = new System.Drawing.Point(303, 12);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(400, 22);
            this.labelNaziv.TabIndex = 3;
            this.labelNaziv.Tag = "NAZIVELEMENT";
            // 
            // OdDatuma
            // 
            appearance26.BackColor = System.Drawing.Color.Lavender;
            this.OdDatuma.Appearance = appearance26;
            this.OdDatuma.BackColor = System.Drawing.Color.Lavender;
            this.OdDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.OdDatuma.Location = new System.Drawing.Point(125, 38);
            this.OdDatuma.Name = "OdDatuma";
            this.OdDatuma.Size = new System.Drawing.Size(112, 21);
            this.OdDatuma.TabIndex = 5;
            // 
            // DoDatuma
            // 
            appearance19.BackColor = System.Drawing.Color.Lavender;
            this.DoDatuma.Appearance = appearance19;
            this.DoDatuma.BackColor = System.Drawing.Color.Lavender;
            this.DoDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.DoDatuma.Location = new System.Drawing.Point(125, 62);
            this.DoDatuma.Name = "DoDatuma";
            this.DoDatuma.Size = new System.Drawing.Size(112, 21);
            this.DoDatuma.TabIndex = 7;
            // 
            // BrojSati
            // 
            appearance20.BackColor = System.Drawing.Color.Lavender;
            this.BrojSati.Appearance = appearance20;
            this.BrojSati.BackColor = System.Drawing.Color.Lavender;
            this.BrojSati.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.BrojSati.FormatString = "#,##0.00";
            this.BrojSati.Location = new System.Drawing.Point(125, 86);
            this.BrojSati.MaskInput = "nnnn.nn";
            this.BrojSati.Name = "BrojSati";
            this.BrojSati.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.BrojSati.Size = new System.Drawing.Size(112, 21);
            this.BrojSati.TabIndex = 9;
            this.BrojSati.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // Satnica
            // 
            appearance21.BackColor = System.Drawing.Color.Lavender;
            this.Satnica.Appearance = appearance21;
            this.Satnica.BackColor = System.Drawing.Color.Lavender;
            this.Satnica.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Satnica.FormatString = "#,##0.00";
            this.Satnica.Location = new System.Drawing.Point(125, 110);
            this.Satnica.MaskInput = "nnnnnnnn.nn";
            this.Satnica.Name = "Satnica";
            this.Satnica.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Satnica.ReadOnly = true;
            this.Satnica.Size = new System.Drawing.Size(112, 21);
            this.Satnica.TabIndex = 10;
            this.Satnica.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.Satnica.TabStop = false;
            // 
            // Postotak
            // 
            appearance22.BackColor = System.Drawing.Color.Lavender;
            this.Postotak.Appearance = appearance22;
            this.Postotak.BackColor = System.Drawing.Color.Lavender;
            this.Postotak.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Postotak.FormatString = "#,##0.00";
            this.Postotak.Location = new System.Drawing.Point(125, 134);
            this.Postotak.MaskInput = "nnnn.nn";
            this.Postotak.Name = "Postotak";
            this.Postotak.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Postotak.Size = new System.Drawing.Size(112, 21);
            this.Postotak.TabIndex = 11;
            this.Postotak.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // Iznos
            // 
            appearance24.BackColor = System.Drawing.Color.Lavender;
            this.Iznos.Appearance = appearance24;
            this.Iznos.BackColor = System.Drawing.Color.Lavender;
            this.Iznos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Iznos.FormatString = "#,##0.00";
            this.Iznos.Location = new System.Drawing.Point(125, 158);
            this.Iznos.MaskInput = "nnnnnnnnnn.nn";
            this.Iznos.Name = "Iznos";
            this.Iznos.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Iznos.Size = new System.Drawing.Size(112, 21);
            this.Iznos.TabIndex = 12;
            this.Iznos.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // UltraButton2
            // 
            this.UltraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton2.Location = new System.Drawing.Point(575, 158);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(128, 23);
            this.UltraButton2.TabIndex = 48;
            this.UltraButton2.Text = "Odustani";
            this.UltraButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton2.Click += new System.EventHandler(this.UltraButton2_Click);
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.UltraButton1.Location = new System.Drawing.Point(437, 158);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(123, 23);
            this.UltraButton1.TabIndex = 47;
            this.UltraButton1.Text = "Spremi";
            this.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // cbSifra
            // 
            appearance25.BackColor = System.Drawing.Color.Lavender;
            this.cbSifra.Appearance = appearance25;
            appearance28.TextHAlignAsString = "Center";
            this.cbSifra.ButtonAppearance = appearance28;
            appearance29.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance29;
            editorButton1.Text = "...";
            this.cbSifra.ButtonsRight.Add(editorButton1);
            this.cbSifra.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbSifra.DataMember = "ELEMENT";
            this.cbSifra.DataSource = this.ElementDataSet1;
            appearance30.BackColor = System.Drawing.SystemColors.Window;
            appearance30.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbSifra.DisplayLayout.Appearance = appearance30;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(125, 0);
            ultraGridColumn1.Width = 60;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(661, 0);
            ultraGridColumn2.Width = 200;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.VisiblePosition = 8;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 7;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn17.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17});
            ultraGridBand1.UseRowLayout = true;
            this.cbSifra.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbSifra.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbSifra.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.cbSifra.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.cbSifra.DisplayLayout.MaxColScrollRegions = 1;
            this.cbSifra.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSifra.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbSifra.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.cbSifra.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbSifra.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbSifra.DisplayLayout.Override.CellAppearance = appearance8;
            this.cbSifra.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cbSifra.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.cbSifra.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.cbSifra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbSifra.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.cbSifra.DisplayLayout.Override.RowAppearance = appearance11;
            this.cbSifra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbSifra.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.cbSifra.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cbSifra.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cbSifra.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cbSifra.DisplayMember = "NAZIVELEMENT";
            this.cbSifra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbSifra.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbSifra.DropDownWidth = 600;
            this.cbSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbSifra.LimitToList = true;
            this.cbSifra.Location = new System.Drawing.Point(125, 10);
            this.cbSifra.MaxDropDownItems = 35;
            this.cbSifra.Name = "cbSifra";
            this.cbSifra.Size = new System.Drawing.Size(578, 22);
            this.cbSifra.TabIndex = 1;
            this.cbSifra.UseAppStyling = false;
            this.cbSifra.ValueMember = "IDELEMENT";
            this.cbSifra.Enter += new System.EventHandler(this.cbSifra_Enter);
            this.cbSifra.GotFocus += new System.EventHandler(this.cbSifra_GotFocus);
            this.cbSifra.Validating += new System.ComponentModel.CancelEventHandler(this.cbSifra_Validating);
            // 
            // ElementDataSet1
            // 
            this.ElementDataSet1.DataSetName = "ELEMENTDataSet";
            // 
            // UltraGroupBox1
            // 
            appearance.BackColor = System.Drawing.Color.Lavender;
            this.UltraGroupBox1.Appearance = appearance;
            this.UltraGroupBox1.Controls.Add(this.label1);
            this.UltraGroupBox1.Controls.Add(this.cmbMjesecOsiguranja);
            this.UltraGroupBox1.Controls.Add(this.labelSifEle);
            this.UltraGroupBox1.Controls.Add(this.UltraButton2);
            this.UltraGroupBox1.Controls.Add(this.label1NAZIVVRSTAELEMENT);
            this.UltraGroupBox1.Controls.Add(this.label1IDVRSTAELEMENTA);
            this.UltraGroupBox1.Controls.Add(this.Iznos);
            this.UltraGroupBox1.Controls.Add(this.Postotak);
            this.UltraGroupBox1.Controls.Add(this.cbSifra);
            this.UltraGroupBox1.Controls.Add(this.Satnica);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox1.Controls.Add(this.BrojSati);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel4);
            this.UltraGroupBox1.Controls.Add(this.DoDatuma);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox1.Controls.Add(this.OdDatuma);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.labelNaziv);
            this.UltraGroupBox1.Controls.Add(this.UltraButton1);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(709, 189);
            this.UltraGroupBox1.TabIndex = 49;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(402, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Oznaka mjeseca osiguranja:";
            // 
            // cmbMjesecOsiguranja
            // 
            this.cmbMjesecOsiguranja.FormattingEnabled = true;
            this.cmbMjesecOsiguranja.Location = new System.Drawing.Point(405, 60);
            this.cmbMjesecOsiguranja.Name = "cmbMjesecOsiguranja";
            this.cmbMjesecOsiguranja.Size = new System.Drawing.Size(297, 21);
            this.cmbMjesecOsiguranja.TabIndex = 53;
            // 
            // frmEleUnosSvi
            // 
            this.AcceptButton = this.UltraButton1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.UltraButton2;
            this.ClientSize = new System.Drawing.Size(709, 189);
            this.Controls.Add(this.UltraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmEleUnosSvi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pridruživanje elemenata označenim zaposlenicima";
            ((System.ComponentModel.ISupportInitialize)(this.OdDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrojSati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Satnica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Postotak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void NapuniElemente()
        {
            ELEMENTDataAdapter adapter = new ELEMENTDataAdapter();
            this.ElementDataSet1.Clear();
            adapter.FillByIDVRSTAELEMENTA(this.ElementDataSet1, Conversions.ToShort(this._vrsta));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            if (keyData == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool ProvjeraPrijeSpremanja()
        {
            try
            {
                if ((this.OdDatuma.Value == DBNull.Value) | !Information.IsDate(RuntimeHelpers.GetObjectValue(this.OdDatuma.Value)))
                {
                    throw new Exception("Polje od datuma mora biti popunjeno");
                }
                if ((this.DoDatuma.Value == DBNull.Value) | !Information.IsDate(RuntimeHelpers.GetObjectValue(this.DoDatuma.Value)))
                {
                    throw new Exception("Polje do datuma mora biti popunjeno");
                }
                if ((DateTime.Parse(Conversions.ToString(this.OdDatuma.Value)).Month != Conversions.ToDouble(this._ParentFormObracun.mjesecobracuna)) | (DateTime.Parse(Conversions.ToString(this.OdDatuma.Value)).Year != Conversions.ToDouble(this._ParentFormObracun.godinaobracuna)))
                {
                    throw new Exception("Polje od datuma mora biti popunjeno sa odgovarajućim podatkom - u skladu sa mjesecom i godinom obračuna");
                }
                if ((DateTime.Parse(Conversions.ToString(this.DoDatuma.Value)).Month != Conversions.ToDouble(this._ParentFormObracun.mjesecobracuna)) | (DateTime.Parse(Conversions.ToString(this.DoDatuma.Value)).Year != Conversions.ToDouble(this._ParentFormObracun.godinaobracuna)))
                {
                    throw new Exception("Polje do datuma mora biti popunjeno sa odgovarajućim podatkom - u skladu sa mjesecom i godinom obračuna");
                }
                if ((decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), decimal.Zero) != 0) & (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.Iznos.Value)), decimal.Zero) != 0))
                {
                    throw new Exception("Kod skupnog pridruživanja dozvoljen unos samo sati ili samo iznosa!");
                }
            }
            catch (System.Exception exception1)
            {
                MessageBox.Show(exception1.Message, "GREŠKA");
                return false;
            }
            return true;
        }

        private bool Spremi()
        {
            bool flag3 = false;
            if (!this.ProvjeraPrijeSpremanja())
            {
                return false;
            }
            bool flag2 = false;
            DataView view2 = new DataView(this._ParentFormObracun.ObracunDataSet1.ObracunElementi);
            DataView view = new DataView(this._ParentFormObracun.ObracunDataSet1.ObracunElementi);
            RowEnumerator enumerator = this._ParentFormObracun.UltraGrid1.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraGridRow current = enumerator.Current;
                if (Conversions.ToBoolean(current.Cells["oznacen"].Value))
                {
                    bool flag = false;
                    DataView view7 = new DataView(this._ParentFormObracun.ObracunDataSet1.ObracunRadnici) {
                        RowFilter = "IDRADNIK = " + Conversions.ToString(current.Cells["idradnik"].Value)
                    };
                    using (DataView view4 = view7)
                    {
                        IEnumerator enumerator2 = null;

                        if (this.BindingContext[view4].Count == 0)
                            return false;

                        DataRowView view3 = (DataRowView) this.BindingContext[view4].Current;
                        DataRow row = view3.Row;
                        view.RowFilter = string.Format("IDRADNIK = {0} AND IDVRSTAELEMENTA = 2", RuntimeHelpers.GetObjectValue(row["IDRADNIK"]));
                        view2.RowFilter = string.Format("IDRADNIK = {0} AND IDVRSTAELEMENTA = 1", RuntimeHelpers.GetObjectValue(row["IDRADNIK"]));
                        string sIDOsnovaOsiguranja = this.m_sIDOsnovaOsiguranja;
                        if (!((sIDOsnovaOsiguranja != "") & !this.m_b_MogucePreklapanjeRazdoblja))
                        {
                            goto Label_0365;
                        }
                        try
                        {
                            enumerator2 = view.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                DataRowView view5 = (DataRowView) enumerator2.Current;
                                if (((((view5["IDOSNOVAOSIGURANJA"] != DBNull.Value) & (DB.N2T(RuntimeHelpers.GetObjectValue(view5["IDOSNOVAOSIGURANJA"]), "") != "")) & !DB.N2B(RuntimeHelpers.GetObjectValue(view5["RAZDOBLJESESMIJEPREKLAPATI"]))) && (Conversions.ToString(view5["IDOSNOVAOSIGURANJA"]) != sIDOsnovaOsiguranja)) && placa.PreklapanjeDatumskihRazdoblja(Conversions.ToDate(view5["ELEMENTRAZDOBLJEOD"]), Conversions.ToDate(view5["ELEMENTRAZDOBLJEDO"]), Conversions.ToDate(this.OdDatuma.Value), Conversions.ToDate(this.DoDatuma.Value)))
                                {
                                    flag = true;
                                    goto Label_0259;
                                }
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                    Label_0259:
                        if (!flag)
                        {
                            IEnumerator enumerator3 = null;
                            try
                            {
                                enumerator3 = view2.GetEnumerator();
                                while (enumerator3.MoveNext())
                                {
                                    DataRowView view6 = (DataRowView) enumerator3.Current;
                                    if (((((view6["IDOSNOVAOSIGURANJA"] != DBNull.Value) & (DB.N2T(RuntimeHelpers.GetObjectValue(view6["IDOSNOVAOSIGURANJA"]), "") != "")) & !DB.N2B(RuntimeHelpers.GetObjectValue(view6["RAZDOBLJESESMIJEPREKLAPATI"]))) && (view6["IDOSNOVAOSIGURANJA"].ToString() != sIDOsnovaOsiguranja)) && placa.PreklapanjeDatumskihRazdoblja(Conversions.ToDate(view6["ELEMENTRAZDOBLJEOD"]), Conversions.ToDate(view6["ELEMENTRAZDOBLJEDO"]), Conversions.ToDate(this.OdDatuma.Value), Conversions.ToDate(this.DoDatuma.Value)))
                                    {
                                        flag = true;
                                        goto Label_0365;
                                    }
                                }
                            }
                            finally
                            {
                                if (enumerator3 is IDisposable)
                                {
                                    (enumerator3 as IDisposable).Dispose();
                                }
                            }
                        }
                    Label_0365:
                        if (!flag)
                        {
                            try
                            {
                                if (this._vrsta == "1")
                                {
                                    decimal num = 0;
                                    decimal num2 = 0;
                                    decimal num3 = 0;
                                    double num4 = 0;
                                    BindingManagerBase base2 = this._ParentFormObracun.BindingContext[this._ParentFormObracun.dvNetoElementi];
                                    base2.AddNew();
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "IDOBRACUN", this._ParentFormObracun.sifraobracuna }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "IDRADNIK", Conversions.ToInteger(row["IDRADNIK"]) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "IDELEMENT", RuntimeHelpers.GetObjectValue(this.cbSifra.Value) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "NAZIVELEMENT", this.labelNaziv.Text }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "IDVRSTAELEMENTA", this._vrsta }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "ELEMENTRAZDOBLJEOD", RuntimeHelpers.GetObjectValue(this.OdDatuma.Value) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "ELEMENTRAZDOBLJEDO", RuntimeHelpers.GetObjectValue(this.DoDatuma.Value) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "OBRSATI", string.Format("{0:0.00}", decimal.Multiply(decimal.Divide(DB.N20(RuntimeHelpers.GetObjectValue(row["TJEDNIFONDSATI"])), 40M), DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)))) }, null, false, true);
                                    this._ParentFormObracun.IzracunSatnice(ref row, ref num4, ref num2, ref num3, ref num);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "OBRSATNICA", DB.N20(num4) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "OBRPOSTOTAK", DB.N20(RuntimeHelpers.GetObjectValue(this.Postotak.Value)) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base2.Current, new object[] { "OBRIZNOS", RuntimeHelpers.GetObjectValue(Interaction.IIf(decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), decimal.Zero) > 0, DB.RoundUP(decimal.Divide(decimal.Multiply(decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), DB.N20(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this._ParentFormObracun.BindingContext[this._ParentFormObracun.dvNetoElementi].Current, new object[] { "OBRSATNICA" }, null)))), DB.N20(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this._ParentFormObracun.BindingContext[this._ParentFormObracun.dvNetoElementi].Current, new object[] { "OBRPOSTOTAK" }, null)))), 100M)), RuntimeHelpers.GetObjectValue(this.Iznos.Value))) }, null, false, true);
                                    base2.EndCurrentEdit();
                                    base2 = null;
                                }
                                else
                                {
                                    decimal num5 = 0;
                                    decimal num6 = 0;
                                    decimal num8 = 0;
                                    double num9 = 0;
                                    BindingManagerBase base3 = this._ParentFormObracun.BindingContext[this._ParentFormObracun.dvBrutoElementi];
                                    base3.AddNew();
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "IDOBRACUN", this._ParentFormObracun.sifraobracuna }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "IDRADNIK", RuntimeHelpers.GetObjectValue(row["IDRADNIK"]) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "IDELEMENT", RuntimeHelpers.GetObjectValue(this.cbSifra.Value) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "NAZIVELEMENT", this.labelNaziv.Text }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "IDVRSTAELEMENTA", this._vrsta }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "ELEMENTRAZDOBLJEOD", RuntimeHelpers.GetObjectValue(this.OdDatuma.Value) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "ELEMENTRAZDOBLJEDO", RuntimeHelpers.GetObjectValue(this.DoDatuma.Value) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "OBRSATI", string.Format("{0:0.00}", decimal.Multiply(decimal.Divide(DB.N20(RuntimeHelpers.GetObjectValue(row["TJEDNIFONDSATI"])), 40M), DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)))) }, null, false, true);
                                    this._ParentFormObracun.IzracunSatnice(ref row, ref num9, ref num6, ref num8, ref num5);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "OBRSATNICA", DB.N20(num9) }, null, false, true);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "OBRPOSTOTAK", DB.N20(RuntimeHelpers.GetObjectValue(this.Postotak.Value)) }, null, false, true);
                                    decimal number = decimal.Divide(decimal.Multiply(DB.RoundUP(Conversions.ToDecimal(Interaction.IIf(decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), decimal.Zero) > 0, DB.RoundUP(decimal.Multiply(decimal.Multiply(DB.N20(Operators.DivideObject(row["TJEDNIFONDSATI"], 40)), DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value))), DB.N20(num9))), RuntimeHelpers.GetObjectValue(this.Iznos.Value)))), DB.N20(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this._ParentFormObracun.BindingContext[this._ParentFormObracun.dvBrutoElementi].Current, new object[] { "OBRPOSTOTAK" }, null)))), 100M);
                                    NewLateBinding.LateIndexSetComplex(base3.Current, new object[] { "OBRIZNOS", DB.RoundUP(number) }, null, false, true);
                                    base3.EndCurrentEdit();
                                    base3 = null;
                                }
                                flag2 = true;
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                                
                                //if (this._vrsta == "1")
                                //{
                                //    this._ParentFormObracun.BindingContext[this._ParentFormObracun.dvNetoElementi].CancelCurrentEdit();
                                //}
                                //else
                                //{
                                //    this._ParentFormObracun.BindingContext[this._ParentFormObracun.dvBrutoElementi].CancelCurrentEdit();
                                //}
                                //flag2 = false;
                            }
                        }

                        ObracunSmartPart.id_element = cbSifra.Value.ToString();
                        ObracunSmartPart.oznaka_mjeseca = cmbMjesecOsiguranja.SelectedValue.ToString();
                        ObracunSmartPart.razdoblje_do = DoDatuma.DateTime;
                        ObracunSmartPart.razdoblje_od = OdDatuma.DateTime;

                        continue;
                    }
                    
                }
            }
            if (!flag2)
            {
                MessageBox.Show("Element nije dodan niti jednom označenom zaposleniku!", "Obračun plaća - Unos " + Conversions.ToString(Interaction.IIf(Conversions.ToDouble(this._vrsta) == 1.0, "neto", "bruto")) + " elementa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Element je dodan svim označenim zaposlenicimaa!", "Obračun plaća - Unos " + Conversions.ToString(Interaction.IIf(Conversions.ToDouble(this._vrsta) == 1.0, "neto", "bruto")) + " elementa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            return flag3;
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            if (!this.Spremi())
            {
            }
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void UpdateIznosa(object sender, CancelEventArgs e)
        {
            this.Iznos.Value = string.Format("{0:0.00}", decimal.Divide(decimal.Multiply(decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), DB.N20(RuntimeHelpers.GetObjectValue(this.Satnica.Value))), DB.N20(RuntimeHelpers.GetObjectValue(this.Postotak.Value))), 100M));
        }

        private UltraNumericEditor BrojSati;

        private UltraCombo cbSifra;

        private UltraDateTimeEditor DoDatuma;

        private ELEMENTDataSet ElementDataSet1;

        private UltraNumericEditor Iznos;

        private UltraLabel label1IDVRSTAELEMENTA;

        private UltraLabel label1NAZIVVRSTAELEMENT;

        private UltraLabel labelNaziv;

        public UltraLabel labelSifEle;

        private UltraDateTimeEditor OdDatuma;

        private UltraNumericEditor Postotak;

        private UltraNumericEditor Satnica;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraGroupBox UltraGroupBox1;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel3;

        private UltraLabel UltraLabel4;

        private UltraLabel UltraLabel5;
    }
}

