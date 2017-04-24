using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.SmartParts;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Obracun
{

    public class frmEleUnos : Form
    {
        public DataView __DataView;
        public DataView __DataView__;
        public ObracunSmartPart _cfm;
        public DataRowView _drvElement;
        private string _sSifra;
        public string _vrstaelementa;
        private IContainer components { get; set; }
        private Label label1;
        private ComboBox cmbMjesecOsiguranja;
        private bool pocetno;

        public frmEleUnos()
        {
            base.Load += new EventHandler(this.frmEleUnos_Load);
            this.pocetno = true;
            this._cfm = new ObracunSmartPart();
            this.InitializeComponent();

        }

        private void BrojSati_ValueChanged(object sender, EventArgs e)
        {
            if (!this.pocetno)
            {
                this.UpdateIznosa(RuntimeHelpers.GetObjectValue(sender));
            }
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
            if (!Operators.ConditionalCompareObjectEqual(this._sSifra, this.cbSifra.Value, false))
            {
                DataRow[] rowArray = null;
                bool flag = false;
                if ((this.cbSifra.Value != null) && DB.IsInteger(Conversions.ToString(this.cbSifra.Value)))
                {
                    rowArray = this.ElementDataSet2.ELEMENT.Select("IDELEMENT = " + Conversions.ToString(DB.N20(DB.IzvuciSamoBrojke(Conversions.ToString(this.cbSifra.Value), true))));
                }
                decimal num = DB.RoundUpDecimale(placa.Test(Conversions.ToInteger(this._drvElement["IDRADNIK"]), Conversions.ToInteger(this.cbSifra.Value), Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString, decimal.Zero, decimal.Zero), 2);
                if (decimal.Compare(num, decimal.Zero) > 0)
                {
                    this.Satnica.Appearance.ForeColor = Color.Red;
                    this.Satnica.Value = num;
                    this._drvElement["OBRSATNICA"] = num;
                }
                if ((rowArray != null) && (rowArray.Length > 0))
                {
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "NAZIVELEMENT", RuntimeHelpers.GetObjectValue(rowArray[0]["NAZIVELEMENT"]) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "IDOSNOVAOSIGURANJA", RuntimeHelpers.GetObjectValue(rowArray[Conversions.ToInteger("0")]["IDOSNOVAOSIGURANJA"]) }, null, false, true);
                    this._drvElement["obrpostotak"] = RuntimeHelpers.GetObjectValue(rowArray[0]["POSTOTAK"]);
                    this.Postotak.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["POSTOTAK"]);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "OBRPOSTOTAK", RuntimeHelpers.GetObjectValue(rowArray[0]["POSTOTAK"]) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "RAZDOBLJESESMIJEPREKLAPATI", RuntimeHelpers.GetObjectValue(rowArray[Conversions.ToInteger("0")]["RAZDOBLJESESMIJEPREKLAPATI"]) }, null, false, true);
                    flag = true;
                }
                if (!flag)
                {
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "IDOSNOVAOSIGURANJA", DBNull.Value }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "NAZIVELEMENT", "" }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "POSTOTAK", 0 }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvElement].Current, new object[] { "RAZDOBLJESESMIJEPREKLAPATI", false }, null, false, true);
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

        private void frmEleUnos_Load(object sender, EventArgs e)
        {
            this.NapuniElemente();
            this.OdDatuma.DataBindings.Add("Value", this._drvElement, "ELEMENTRAZDOBLJEOD");
            this.DoDatuma.DataBindings.Add("Value", this._drvElement, "ELEMENTRAZDOBLJEDO");
            this.BrojSati.DataBindings.Add("Value", this._drvElement, "OBRSATI");
            this.Satnica.DataBindings.Add("Value", this._drvElement, "OBRSATNICA");
            this.Postotak.DataBindings.Add("Value", this._drvElement, "OBRPOSTOTAK");
            this.Iznos.DataBindings.Add("Value", this._drvElement, "OBRIZNOS");
            if (!this.cbSifra.Enabled)
            {
                this.BrojSati.Select();
            }
            else
            {
                this.cbSifra.Select();
            }
            this.pocetno = false;
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this._drvElement["idelement"])))
            {
                this.cbSifra.Value = RuntimeHelpers.GetObjectValue(this._drvElement["idelement"]);
            }
            NapuniMjesecOsiguranja();


        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEleUnos));
            this.label1IDVRSTAELEMENTA = new Infragistics.Win.Misc.UltraLabel();
            this.label1NAZIVVRSTAELEMENT = new Infragistics.Win.Misc.UltraLabel();
            this._Form_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.lblSifEle = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.OdDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.DoDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.BrojSati = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Satnica = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Postotak = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Iznos = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.btnFocus = new System.Windows.Forms.Button();
            this.UltraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMjesecOsiguranja = new System.Windows.Forms.ComboBox();
            this.cbSifra = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ElementDataSet2 = new Placa.ELEMENTDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.OdDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrojSati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Satnica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Postotak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1IDVRSTAELEMENTA
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDVRSTAELEMENTA.Appearance = appearance1;
            this.label1IDVRSTAELEMENTA.BackColorInternal = System.Drawing.Color.Transparent;
            this.label1IDVRSTAELEMENTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1IDVRSTAELEMENTA.Location = new System.Drawing.Point(6, 43);
            this.label1IDVRSTAELEMENTA.Name = "label1IDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.Size = new System.Drawing.Size(123, 23);
            this.label1IDVRSTAELEMENTA.TabIndex = 4;
            this.label1IDVRSTAELEMENTA.Text = "Od datuma:";
            // 
            // label1NAZIVVRSTAELEMENT
            // 
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextVAlignAsString = "Middle";
            this.label1NAZIVVRSTAELEMENT.Appearance = appearance22;
            this.label1NAZIVVRSTAELEMENT.BackColorInternal = System.Drawing.Color.Transparent;
            this.label1NAZIVVRSTAELEMENT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1NAZIVVRSTAELEMENT.Location = new System.Drawing.Point(6, 72);
            this.label1NAZIVVRSTAELEMENT.Name = "label1NAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.Size = new System.Drawing.Size(123, 23);
            this.label1NAZIVVRSTAELEMENT.TabIndex = 6;
            this.label1NAZIVVRSTAELEMENT.Text = "Do datuma:";
            // 
            // _Form_Toolbars_Dock_Area_Top
            // 
            this._Form_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Form_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form_Toolbars_Dock_Area_Top.Name = "_Form_Toolbars_Dock_Area_Top";
            this._Form_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(638, 0);
            // 
            // _Form_Toolbars_Dock_Area_Bottom
            // 
            this._Form_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 204);
            this._Form_Toolbars_Dock_Area_Bottom.Name = "_Form_Toolbars_Dock_Area_Bottom";
            this._Form_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(638, 0);
            // 
            // _Form_Toolbars_Dock_Area_Left
            // 
            this._Form_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Form_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._Form_Toolbars_Dock_Area_Left.Name = "_Form_Toolbars_Dock_Area_Left";
            this._Form_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 204);
            // 
            // _Form_Toolbars_Dock_Area_Right
            // 
            this._Form_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Form_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(638, 0);
            this._Form_Toolbars_Dock_Area_Right.Name = "_Form_Toolbars_Dock_Area_Right";
            this._Form_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 204);
            // 
            // lblSifEle
            // 
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.lblSifEle.Appearance = appearance25;
            this.lblSifEle.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblSifEle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSifEle.Location = new System.Drawing.Point(6, 19);
            this.lblSifEle.Name = "lblSifEle";
            this.lblSifEle.Size = new System.Drawing.Size(123, 23);
            this.lblSifEle.TabIndex = 0;
            this.lblSifEle.Text = "Šifra elementa:";
            // 
            // UltraLabel2
            // 
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.UltraLabel2.Appearance = appearance26;
            this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(6, 97);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(123, 23);
            this.UltraLabel2.TabIndex = 8;
            this.UltraLabel2.Text = "Broj sati:";
            // 
            // UltraLabel3
            // 
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.UltraLabel3.Appearance = appearance27;
            this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(6, 123);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(123, 23);
            this.UltraLabel3.TabIndex = 10;
            this.UltraLabel3.Text = "IzracunSatnice:";
            // 
            // UltraLabel4
            // 
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.UltraLabel4.Appearance = appearance28;
            this.UltraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel4.Location = new System.Drawing.Point(6, 147);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(123, 23);
            this.UltraLabel4.TabIndex = 12;
            this.UltraLabel4.Text = "Postotak:";
            // 
            // UltraLabel5
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.UltraLabel5.Appearance = appearance2;
            this.UltraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel5.Location = new System.Drawing.Point(6, 171);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(123, 23);
            this.UltraLabel5.TabIndex = 14;
            this.UltraLabel5.Text = "Iznos:";
            // 
            // OdDatuma
            // 
            appearance23.BackColor = System.Drawing.Color.Lavender;
            appearance23.FontData.BoldAsString = "True";
            appearance23.ForeColor = System.Drawing.Color.Black;
            this.OdDatuma.Appearance = appearance23;
            this.OdDatuma.BackColor = System.Drawing.Color.Lavender;
            this.OdDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.OdDatuma.Location = new System.Drawing.Point(135, 46);
            this.OdDatuma.Name = "OdDatuma";
            this.OdDatuma.Size = new System.Drawing.Size(103, 21);
            this.OdDatuma.TabIndex = 5;
            // 
            // DoDatuma
            // 
            appearance24.BackColor = System.Drawing.Color.Lavender;
            appearance24.FontData.BoldAsString = "True";
            appearance24.ForeColor = System.Drawing.Color.Black;
            this.DoDatuma.Appearance = appearance24;
            this.DoDatuma.BackColor = System.Drawing.Color.Lavender;
            this.DoDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.DoDatuma.Location = new System.Drawing.Point(135, 73);
            this.DoDatuma.Name = "DoDatuma";
            this.DoDatuma.Size = new System.Drawing.Size(103, 21);
            this.DoDatuma.TabIndex = 7;
            // 
            // BrojSati
            // 
            appearance18.BackColor = System.Drawing.Color.Lavender;
            appearance18.FontData.BoldAsString = "True";
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.BrojSati.Appearance = appearance18;
            this.BrojSati.BackColor = System.Drawing.Color.Lavender;
            this.BrojSati.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.BrojSati.FormatString = "#,##0.00";
            this.BrojSati.Location = new System.Drawing.Point(135, 100);
            this.BrojSati.MaskInput = "nnnn.nn";
            this.BrojSati.Name = "BrojSati";
            this.BrojSati.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.BrojSati.Size = new System.Drawing.Size(103, 21);
            this.BrojSati.TabIndex = 9;
            this.BrojSati.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.BrojSati.ValueChanged += new System.EventHandler(this.BrojSati_ValueChanged);
            // 
            // Satnica
            // 
            appearance19.BackColor = System.Drawing.Color.Lavender;
            appearance19.FontData.BoldAsString = "True";
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.Satnica.Appearance = appearance19;
            this.Satnica.BackColor = System.Drawing.Color.Lavender;
            this.Satnica.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Satnica.FormatString = "#,##0.00000000";
            this.Satnica.Location = new System.Drawing.Point(135, 126);
            this.Satnica.MaskInput = "nnnnnnnn.nnnnnnnn";
            this.Satnica.Name = "Satnica";
            this.Satnica.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Satnica.Size = new System.Drawing.Size(103, 21);
            this.Satnica.TabIndex = 11;
            this.Satnica.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.Satnica.ValueChanged += new System.EventHandler(this.Satnica_ValueChanged);
            // 
            // Postotak
            // 
            appearance20.BackColor = System.Drawing.Color.Lavender;
            appearance20.FontData.BoldAsString = "True";
            appearance20.ForeColor = System.Drawing.Color.Black;
            this.Postotak.Appearance = appearance20;
            this.Postotak.BackColor = System.Drawing.Color.Lavender;
            this.Postotak.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Postotak.FormatString = "#,##0.00";
            this.Postotak.Location = new System.Drawing.Point(135, 150);
            this.Postotak.MaskInput = "nnnn.nn";
            this.Postotak.Name = "Postotak";
            this.Postotak.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Postotak.Size = new System.Drawing.Size(103, 21);
            this.Postotak.TabIndex = 13;
            this.Postotak.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.Postotak.Value = 13D;
            this.Postotak.ValueChanged += new System.EventHandler(this.Postotak_ValueChanged);
            // 
            // Iznos
            // 
            appearance21.BackColor = System.Drawing.Color.Lavender;
            appearance21.FontData.BoldAsString = "True";
            appearance21.ForeColor = System.Drawing.Color.Black;
            this.Iznos.Appearance = appearance21;
            this.Iznos.BackColor = System.Drawing.Color.Lavender;
            this.Iznos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Iznos.FormatString = "#,##0.00";
            this.Iznos.Location = new System.Drawing.Point(135, 174);
            this.Iznos.MaskInput = "-nnnnnnnnnn.nn";
            this.Iznos.Name = "Iznos";
            this.Iznos.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Iznos.Size = new System.Drawing.Size(103, 21);
            this.Iznos.TabIndex = 15;
            this.Iznos.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.Iznos.ValueChanged += new System.EventHandler(this.Iznos_ValueChanged);
            // 
            // btnFocus
            // 
            this.btnFocus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFocus.Location = new System.Drawing.Point(-100, 116);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(2, 0);
            this.btnFocus.TabIndex = 20;
            this.btnFocus.TabStop = false;
            this.btnFocus.Text = "Button1";
            // 
            // UltraButton3
            // 
            this.UltraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton3.Location = new System.Drawing.Point(492, 175);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(128, 23);
            this.UltraButton3.TabIndex = 50;
            this.UltraButton3.Text = "Odustani";
            this.UltraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton3.Click += new System.EventHandler(this.UltraButton3_Click);
            // 
            // UltraButton4
            // 
            this.UltraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton4.Location = new System.Drawing.Point(363, 175);
            this.UltraButton4.Name = "UltraButton4";
            this.UltraButton4.Size = new System.Drawing.Size(123, 23);
            this.UltraButton4.TabIndex = 49;
            this.UltraButton4.Text = "Spremi";
            this.UltraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton4.Click += new System.EventHandler(this.UltraButton4_Click);
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.label1);
            this.UltraGroupBox1.Controls.Add(this.cmbMjesecOsiguranja);
            this.UltraGroupBox1.Controls.Add(this.lblSifEle);
            this.UltraGroupBox1.Controls.Add(this.UltraButton3);
            this.UltraGroupBox1.Controls.Add(this.label1NAZIVVRSTAELEMENT);
            this.UltraGroupBox1.Controls.Add(this.UltraButton4);
            this.UltraGroupBox1.Controls.Add(this.label1IDVRSTAELEMENTA);
            this.UltraGroupBox1.Controls.Add(this.cbSifra);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox1.Controls.Add(this.Iznos);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel4);
            this.UltraGroupBox1.Controls.Add(this.Postotak);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox1.Controls.Add(this.Satnica);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.BrojSati);
            this.UltraGroupBox1.Controls.Add(this.DoDatuma);
            this.UltraGroupBox1.Controls.Add(this.OdDatuma);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(638, 204);
            this.UltraGroupBox1.TabIndex = 55;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(326, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Oznaka mjeseca osiguranja:";
            // 
            // cmbMjesecOsiguranja
            // 
            this.cmbMjesecOsiguranja.FormattingEnabled = true;
            this.cmbMjesecOsiguranja.Location = new System.Drawing.Point(329, 73);
            this.cmbMjesecOsiguranja.Name = "cmbMjesecOsiguranja";
            this.cmbMjesecOsiguranja.Size = new System.Drawing.Size(297, 21);
            this.cmbMjesecOsiguranja.TabIndex = 51;
            // 
            // cbSifra
            // 
            appearance29.BackColor = System.Drawing.Color.Lavender;
            appearance29.FontData.BoldAsString = "True";
            appearance29.ForeColor = System.Drawing.Color.Black;
            this.cbSifra.Appearance = appearance29;
            appearance30.TextHAlignAsString = "Center";
            this.cbSifra.ButtonAppearance = appearance30;
            appearance31.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance31;
            editorButton1.Text = "...";
            this.cbSifra.ButtonsRight.Add(editorButton1);
            this.cbSifra.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbSifra.DataMember = "ELEMENT";
            this.cbSifra.DataSource = this.ElementDataSet2;
            appearance32.BackColor = System.Drawing.SystemColors.Window;
            appearance32.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.cbSifra.DisplayLayout.Appearance = appearance32;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(88, 0);
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Width = 60;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(480, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 9;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
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
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 9;
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
            appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.GroupByBox.Appearance = appearance33;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
            this.cbSifra.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance35.BackColor2 = System.Drawing.SystemColors.Control;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
            this.cbSifra.DisplayLayout.MaxColScrollRegions = 1;
            this.cbSifra.DisplayLayout.MaxRowScrollRegions = 1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSifra.DisplayLayout.Override.ActiveCellAppearance = appearance36;
            appearance37.BackColor = System.Drawing.SystemColors.Highlight;
            appearance37.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbSifra.DisplayLayout.Override.ActiveRowAppearance = appearance37;
            this.cbSifra.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbSifra.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance38.BackColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.CardAreaAppearance = appearance38;
            appearance39.BorderColor = System.Drawing.Color.Silver;
            appearance39.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbSifra.DisplayLayout.Override.CellAppearance = appearance39;
            this.cbSifra.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cbSifra.DisplayLayout.Override.CellPadding = 0;
            appearance40.BackColor = System.Drawing.SystemColors.Control;
            appearance40.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance40.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance40.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.GroupByRowAppearance = appearance40;
            appearance41.TextHAlignAsString = "Left";
            this.cbSifra.DisplayLayout.Override.HeaderAppearance = appearance41;
            this.cbSifra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbSifra.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.BorderColor = System.Drawing.Color.Silver;
            this.cbSifra.DisplayLayout.Override.RowAppearance = appearance42;
            this.cbSifra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance43.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbSifra.DisplayLayout.Override.TemplateAddRowAppearance = appearance43;
            this.cbSifra.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cbSifra.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cbSifra.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cbSifra.DisplayMember = "NAZIVELEMENT";
            this.cbSifra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbSifra.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbSifra.DropDownWidth = 600;
            this.cbSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbSifra.LimitToList = true;
            this.cbSifra.Location = new System.Drawing.Point(135, 20);
            this.cbSifra.MaxDropDownItems = 9999;
            this.cbSifra.Name = "cbSifra";
            this.cbSifra.Size = new System.Drawing.Size(491, 22);
            this.cbSifra.TabIndex = 1;
            this.cbSifra.UseAppStyling = false;
            this.cbSifra.ValueMember = "IDELEMENT";
            this.cbSifra.ValueChanged += new System.EventHandler(this.cbSifra_ValueChanged);
            this.cbSifra.Enter += new System.EventHandler(this.cbSifra_Enter);
            this.cbSifra.GotFocus += new System.EventHandler(this.cbSifra_GotFocus);
            this.cbSifra.Validating += new System.ComponentModel.CancelEventHandler(this.cbSifra_Validating);
            // 
            // ElementDataSet2
            // 
            this.ElementDataSet2.DataSetName = "ELEMENTDataSet";
            // 
            // frmEleUnos
            // 
            this.AcceptButton = this.UltraButton4;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.UltraButton3;
            this.ClientSize = new System.Drawing.Size(638, 204);
            this.ControlBox = false;
            this.Controls.Add(this.UltraGroupBox1);
            this.Controls.Add(this.btnFocus);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmEleUnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obračun plaće - unos elementa";
            ((System.ComponentModel.ISupportInitialize)(this.OdDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrojSati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Satnica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Postotak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        private void Iznos_ValueChanged(object sender, EventArgs e)
        {
            if (!this.pocetno)
            {
                this.UpdateIznosa(RuntimeHelpers.GetObjectValue(sender));
            }
        }

        private void NapuniElemente()
        {
            ELEMENTDataAdapter adapter = new ELEMENTDataAdapter();
            this.ElementDataSet2.Clear();
            adapter.FillByIDVRSTAELEMENTA(this.ElementDataSet2, Conversions.ToShort(this._vrstaelementa));
        }

        private void NapuniMjesecOsiguranja()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            cmbMjesecOsiguranja.DataSource = client.GetDataTable("Select Oznaka, KratkiOpis From JOPPDOznakaMjesecaOsiguranje");
            cmbMjesecOsiguranja.ValueMember = "Oznaka";
            cmbMjesecOsiguranja.DisplayMember = "KratkiOpis";

            try
            {
                string mjesec_osiguranja = client.ExecuteScalar("Select OznakaMjeseca From ObracunElementi Where IDOBRACUN = '" + _drvElement[0].ToString() + "' And IDRADNIK = '" + _drvElement[1].ToString() +
                                                                "' And IDELEMENT = '" + cbSifra.Value.ToString() + "' And ELEMENTRAZDOBLJEOD = '" + OdDatuma.DateTime.ToString("yyyy-MM-dd") +
                                                                "' And ELEMENTRAZDOBLJEDO = '" + DoDatuma.DateTime.ToString("yyyy-MM-dd") + "'").ToString();
                if (mjesec_osiguranja.Length > 0)
                {
                    cmbMjesecOsiguranja.SelectedValue = mjesec_osiguranja;
                }
                else
                {
                    cmbMjesecOsiguranja.SelectedValue = 3;
                }
            }
            catch 
            {
                cmbMjesecOsiguranja.SelectedValue = 3;
            }

            
        }

        private void Postotak_ValueChanged(object sender, EventArgs e)
        {
            if (!this.pocetno)
            {
                this.UpdateIznosa(RuntimeHelpers.GetObjectValue(sender));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            if (keyData != Keys.Escape)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            try
            {
                this._drvElement.CancelEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
            return true;
        }

        private bool ProvjeraPrijeSpremanja()
        {
            try
            {
                if (this.cbSifra.Value == null)
                {
                    throw new Exception("Polje element mora biti popunjeno");
                }
                if ((this.OdDatuma.Value == DBNull.Value) | !Information.IsDate(RuntimeHelpers.GetObjectValue(this.OdDatuma.Value)))
                {
                    throw new Exception("Polje od datuma mora biti popunjeno sa odgovarajućim podatkom");
                }
                if ((this.DoDatuma.Value == DBNull.Value) | !Information.IsDate(RuntimeHelpers.GetObjectValue(this.DoDatuma.Value)))
                {
                    throw new Exception("Polje do datuma mora biti popunjeno sa odgovarajućim podatkom");
                }
                //zbog joppd-a i oznake razdoblja 28.02.2014
                //if ((DateTime.Parse(Conversions.ToString(this.OdDatuma.Value)).Month != Conversions.ToDouble(this._cfm.mjesecobracuna)) | (DateTime.Parse(Conversions.ToString(this.OdDatuma.Value)).Year != Conversions.ToDouble(this._cfm.godinaobracuna)))
                //{
                //    throw new Exception("Polje od datuma mora biti popunjeno sa odgovarajućim podatkom - u skladu sa mjesecom i godinom obračuna");
                //}
                //if ((DateTime.Parse(Conversions.ToString(this.DoDatuma.Value)).Month != Conversions.ToDouble(this._cfm.mjesecobracuna)) | (DateTime.Parse(Conversions.ToString(this.DoDatuma.Value)).Year != Conversions.ToDouble(this._cfm.godinaobracuna)))
                //{
                //    throw new Exception("Polje do datuma mora biti popunjeno sa odgovarajućim podatkom - u skladu sa mjesecom i godinom obračuna");
                //}
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //flag = false;
                
                //return flag;
            }
            try
            {
                if (((NewLateBinding.LateIndexGet(this.BindingContext[this._drvElement].Current, new object[] { "IDOSNOVAOSIGURANJA" }, null) != DBNull.Value) & (DB.N2T(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.BindingContext[this._drvElement].Current, new object[] { "IDOSNOVAOSIGURANJA" }, null)), "") != "")) && !DB.N2B(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.BindingContext[this._drvElement].Current, new object[] { "RAZDOBLJESESMIJEPREKLAPATI" }, null))))
                {
                    int num3 = this.__DataView.Count - 1;
                    for (int i = 0; i <= num3; i++)
                    {
                        if (((((this._cfm.BindingContext[this.__DataView].Position != i) & ((this.__DataView[i]["IDOSNOVAOSIGURANJA"] != DBNull.Value) & (DB.N2T(RuntimeHelpers.GetObjectValue(this.__DataView[i]["IDOSNOVAOSIGURANJA"]), "") != ""))) & !DB.N2B(RuntimeHelpers.GetObjectValue(this.__DataView[i]["RAZDOBLJESESMIJEPREKLAPATI"]))) && Operators.ConditionalCompareObjectNotEqual(this.__DataView[i]["IDOSNOVAOSIGURANJA"], NewLateBinding.LateIndexGet(this.BindingContext[this._drvElement].Current, new object[] { "IDOSNOVAOSIGURANJA" }, null), false)) && placa.PreklapanjeDatumskihRazdoblja(Conversions.ToDate(this.__DataView[i]["ELEMENTRAZDOBLJEOD"]), Conversions.ToDate(this.__DataView[i]["ELEMENTRAZDOBLJEDO"]), Conversions.ToDate(this.OdDatuma.Value), Conversions.ToDate(this.DoDatuma.Value)))
                        {
                            throw new Exception("Unesena datumska razdoblje se preklapaju");
                        }
                    }
                    int num4 = this.__DataView__.Count - 1;
                    for (int j = 0; j <= num4; j++)
                    {
                        if (((((this.__DataView__[j]["IDOSNOVAOSIGURANJA"] != DBNull.Value) & (DB.N2T(RuntimeHelpers.GetObjectValue(this.__DataView__[j]["IDOSNOVAOSIGURANJA"]), "") != "")) & !DB.N2B(RuntimeHelpers.GetObjectValue(this.__DataView__[j]["RAZDOBLJESESMIJEPREKLAPATI"]))) && Operators.ConditionalCompareObjectNotEqual(this.__DataView__[j]["IDOSNOVAOSIGURANJA"], NewLateBinding.LateIndexGet(this.BindingContext[this._drvElement].Current, new object[] { "IDOSNOVAOSIGURANJA" }, null), false)) && placa.PreklapanjeDatumskihRazdoblja(Conversions.ToDate(this.__DataView__[j]["ELEMENTRAZDOBLJEOD"]), Conversions.ToDate(this.__DataView__[j]["ELEMENTRAZDOBLJEDO"]), Conversions.ToDate(this.OdDatuma.Value), Conversions.ToDate(this.DoDatuma.Value)))
                        {
                            throw new Exception("Unesena datumska razdoblje se preklapaju");
                        }
                    }
                }
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Exception exception2 = exception3;
                //MessageBox.Show(exception2.Message, "Obračun plaća", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //flag = false;
                
                //return flag;
            }
            return true;
        }

        private void Satnica_ValueChanged(object sender, EventArgs e)
        {
            if (!this.pocetno)
            {
                this.UpdateIznosa(RuntimeHelpers.GetObjectValue(sender));
            }
        }

        private bool Spremi()
        {
            bool flag = false;
            if (!this.ProvjeraPrijeSpremanja())
            {
                return false;
            }
            try
            {
                this._drvElement.EndEdit();
                flag = true;
            }
            catch (System.Exception exception1)
            {
                if (exception1.Message.IndexOf("unique") > 0)
                {
                    MessageBox.Show("Element je već pridružen trenutnom zaposleniku!!", "Obračun plaća", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.cbSifra.Select();
                }
                else
                {
                    MessageBox.Show("Greška prilikom spremanja " + exception1.Message, "Obračun plaća", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

                throw exception1;

                //flag = false;
            }
            return flag;
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this._drvElement.CancelEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void UltraButton4_Click(object sender, EventArgs e)
        {
            ObracunSmartPart.id_element = cbSifra.Value.ToString();
            ObracunSmartPart.razdoblje_do = DoDatuma.DateTime;
            ObracunSmartPart.razdoblje_od = OdDatuma.DateTime;
            ObracunSmartPart.id_radnika = _drvElement[1].ToString();
            ObracunSmartPart.oznaka_mjeseca = cmbMjesecOsiguranja.SelectedValue.ToString();

            this._drvElement["idelement"] = RuntimeHelpers.GetObjectValue(this.cbSifra.Value);
            if (this.Spremi())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void UpdateIznosa(object sender)
        {
            if (((UltraNumericEditor) sender).Name == "Iznos")
            {
                this._drvElement["OBRIZNOS"] = RuntimeHelpers.GetObjectValue(this.Iznos.Value);
            }
            else
            {
                decimal num = 0;
                if ((decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), decimal.Zero) > 0) & (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.Satnica.Value)), decimal.Zero) > 0))
                {
                    num = DB.RoundUP(decimal.Divide(decimal.Multiply(decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), DB.N20(RuntimeHelpers.GetObjectValue(this.Satnica.Value))), DB.N20(RuntimeHelpers.GetObjectValue(this.Postotak.Value))), 100M));
                }
                if ((this._drvElement != null) && (decimal.Compare(num, decimal.Zero) != 0))
                {
                    this._drvElement["OBRIZNOS"] = num;
                    this.Iznos.Value = num;
                }
            }
        }

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Bottom;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Left;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Right;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Top;

        private UltraNumericEditor BrojSati;

        private Button btnFocus;

        public UltraCombo cbSifra;

        public UltraDateTimeEditor DoDatuma;

        private ELEMENTDataSet ElementDataSet2;

        private UltraNumericEditor Iznos;

        private UltraLabel label1IDVRSTAELEMENTA;

        private UltraLabel label1NAZIVVRSTAELEMENT;

        public UltraLabel lblSifEle;

        public UltraDateTimeEditor OdDatuma;

        private UltraNumericEditor Postotak;

        private UltraNumericEditor Satnica;

        private UltraButton UltraButton3;

        private UltraButton UltraButton4;

        private UltraGroupBox UltraGroupBox1;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel3;

        private UltraLabel UltraLabel4;

        private UltraLabel UltraLabel5;

        private void cbSifra_ValueChanged(object sender, EventArgs e)
        {
            if ((int)cbSifra.Value == 21 | (int)cbSifra.Value == 55 | (int)cbSifra.Value == 57)
            {
                UltraLabel2.Text = "Broj Godina:";
            }
            else
            {
                UltraLabel2.Text = "Broj sati:";
            }
        }

    }
}

