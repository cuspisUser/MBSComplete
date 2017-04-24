namespace DDModule.Obracun
{
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Infragistics.Win.UltraWinToolbars;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmUnosVrstePosla : Form
    {
        public ObracunDDSmartPart ___ParentForm;
        public DataView _dv;
        public DataRowView _drvVrstaPosla;
        private IContainer components { get; set; }
        public string m_vrstaobracuna;
        private bool pocetno;

        public frmUnosVrstePosla()
        {
            base.Closing += new CancelEventHandler(this.frmUnosVrstePosla_Closing);
            base.Load += new EventHandler(this.frmUnosVrstePosla_Load);
            this.___ParentForm = new ObracunDDSmartPart();
            this.pocetno = true;
            this.InitializeComponent();
        }

        private void BrojSati_ValueChanged(object sender, EventArgs e)
        {
            if (!this.pocetno)
            {
                this.UpdateIznosa(RuntimeHelpers.GetObjectValue(sender));
            }
        }

        private void cbSifra_GotFocus(object sender, EventArgs e)
        {
            this.cbSifra.ToggleDropdown();
        }

        private void cbSifraValidating(object sender, CancelEventArgs e)
        {
            bool flag = false;
            DataRow[] rowArray = null;
            if ((this.cbSifra.Value != null) && DB.IsInteger(Conversions.ToString(this.cbSifra.Value)))
            {
                rowArray = this.DdvrsteposlaDataSet1.DDVRSTEPOSLA.Select("DDIDVRSTAPOSLA = " + Conversions.ToString(DB.N20(DB.IzvuciSamoBrojke(Conversions.ToString(this.cbSifra.Value), true))));
            }
            if ((rowArray != null) && (rowArray.Length > 0))
            {
                NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvVrstaPosla].Current, new object[] { "DDNAZIVVRSTAPOSLA", RuntimeHelpers.GetObjectValue(rowArray[0]["DDNAZIVVRSTAPOSLA"]) }, null, false, true);
                flag = true;
            }
            if (!flag)
            {
                NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvVrstaPosla].Current, new object[] { "DDNAZIVVRSTAPOSLA", "" }, null, false, true);
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

        private void frmUnosVrstePosla_Closing(object sender, CancelEventArgs e)
        {
            this.Zatvori();
        }

        private void frmUnosVrstePosla_Load(object sender, EventArgs e)
        {
            this.NapuniVrstePosla();
            this.BrojSati.DataBindings.Add("Value", this._drvVrstaPosla, "ddsati");
            this.Satnica.DataBindings.Add("Value", this._drvVrstaPosla, "ddsatnica");
            this.Iznos.DataBindings.Add("Value", this._drvVrstaPosla, "ddiznos");
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
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this._drvVrstaPosla["DDIDVRSTAPOSLA"])))
            {
                this.cbSifra.Value = RuntimeHelpers.GetObjectValue(this._drvVrstaPosla["DDIDVRSTAPOSLA"]);
            }
            if (!this.cbSifra.Enabled)
            {
                this.BrojSati.Select();
            }
            else
            {
                this.cbSifra.Select();
            }
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDVRSTEPOSLA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDVRSTAPOSLA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDNAZIVVRSTAPOSLA");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnosVrstePosla));
            this._Form_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.lblSifEle = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.BrojSati = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Satnica = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Postotak = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Iznos = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.btnFocus = new System.Windows.Forms.Button();
            this.ButtonOdustani = new Infragistics.Win.Misc.UltraButton();
            this.ButtonSpremi = new Infragistics.Win.Misc.UltraButton();
            this.cbSifra = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.DdvrsteposlaDataSet1 = new Placa.DDVRSTEPOSLADataSet();
            this.UltraNumericEditor1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ButtonNetoUBruto = new Infragistics.Win.Misc.UltraButton();
            this.ButtonUkupniTrosakUBruto = new Infragistics.Win.Misc.UltraButton();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.BrojSati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Satnica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Postotak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdvrsteposlaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraNumericEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // _Form_Toolbars_Dock_Area_Top
            // 
            this._Form_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Form_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form_Toolbars_Dock_Area_Top.Name = "_Form_Toolbars_Dock_Area_Top";
            this._Form_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(728, 0);
            // 
            // _Form_Toolbars_Dock_Area_Bottom
            // 
            this._Form_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 168);
            this._Form_Toolbars_Dock_Area_Bottom.Name = "_Form_Toolbars_Dock_Area_Bottom";
            this._Form_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(728, 0);
            // 
            // _Form_Toolbars_Dock_Area_Left
            // 
            this._Form_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Form_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._Form_Toolbars_Dock_Area_Left.Name = "_Form_Toolbars_Dock_Area_Left";
            this._Form_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 168);
            // 
            // _Form_Toolbars_Dock_Area_Right
            // 
            this._Form_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Form_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(728, 0);
            this._Form_Toolbars_Dock_Area_Right.Name = "_Form_Toolbars_Dock_Area_Right";
            this._Form_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 168);
            // 
            // lblSifEle
            // 
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.lblSifEle.Appearance = appearance17;
            this.lblSifEle.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblSifEle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSifEle.Location = new System.Drawing.Point(8, 11);
            this.lblSifEle.Name = "lblSifEle";
            this.lblSifEle.Size = new System.Drawing.Size(171, 23);
            this.lblSifEle.TabIndex = 0;
            this.lblSifEle.Text = "Šifra vrste posla:";
            // 
            // UltraLabel2
            // 
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.UltraLabel2.Appearance = appearance10;
            this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(8, 40);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(171, 23);
            this.UltraLabel2.TabIndex = 8;
            this.UltraLabel2.Text = "Broj sati:";
            // 
            // UltraLabel3
            // 
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.UltraLabel3.Appearance = appearance19;
            this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(8, 64);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(171, 23);
            this.UltraLabel3.TabIndex = 10;
            this.UltraLabel3.Text = "Satnica:";
            // 
            // UltraLabel4
            // 
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.UltraLabel4.Appearance = appearance20;
            this.UltraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel4.Location = new System.Drawing.Point(8, 88);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(171, 23);
            this.UltraLabel4.TabIndex = 12;
            this.UltraLabel4.Text = "Postotak:";
            // 
            // UltraLabel5
            // 
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextVAlignAsString = "Middle";
            this.UltraLabel5.Appearance = appearance;
            this.UltraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel5.Location = new System.Drawing.Point(8, 112);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(171, 23);
            this.UltraLabel5.TabIndex = 14;
            this.UltraLabel5.Text = "Iznos:";
            // 
            // BrojSati
            // 
            this.BrojSati.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.BrojSati.FormatString = "#,##0.00";
            this.BrojSati.Location = new System.Drawing.Point(184, 42);
            this.BrojSati.MaskInput = "nnnn.nn";
            this.BrojSati.Name = "BrojSati";
            this.BrojSati.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.BrojSati.Size = new System.Drawing.Size(90, 21);
            this.BrojSati.TabIndex = 9;
            this.BrojSati.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.BrojSati.ValueChanged += new System.EventHandler(this.BrojSati_ValueChanged);
            // 
            // Satnica
            // 
            this.Satnica.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.Satnica.FormatString = "#,##0.00000000";
            this.Satnica.Location = new System.Drawing.Point(184, 66);
            this.Satnica.MaskInput = "nnnnnnnn.nnnnnnnn";
            this.Satnica.Name = "Satnica";
            this.Satnica.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Satnica.Size = new System.Drawing.Size(90, 21);
            this.Satnica.TabIndex = 11;
            this.Satnica.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.Satnica.ValueChanged += new System.EventHandler(this.Satnica_ValueChanged);
            // 
            // Postotak
            // 
            this.Postotak.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.Postotak.FormatString = "#,##0.00";
            this.Postotak.Location = new System.Drawing.Point(184, 90);
            this.Postotak.MaskInput = "nnnn.nn";
            this.Postotak.Name = "Postotak";
            this.Postotak.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Postotak.Size = new System.Drawing.Size(90, 21);
            this.Postotak.TabIndex = 13;
            this.Postotak.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.Postotak.Value = 100D;
            this.Postotak.ValueChanged += new System.EventHandler(this.Postotak_ValueChanged);
            // 
            // Iznos
            // 
            this.Iznos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.Iznos.FormatString = "#,##0.00";
            this.Iznos.Location = new System.Drawing.Point(184, 114);
            this.Iznos.MaskInput = "nnnnnnnnnn.nn";
            this.Iznos.Name = "Iznos";
            this.Iznos.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Iznos.Size = new System.Drawing.Size(90, 21);
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
            this.ButtonOdustani.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.ButtonOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonOdustani.Location = new System.Drawing.Point(589, 140);
            this.ButtonOdustani.Name = "UltraButton3";
            this.ButtonOdustani.Size = new System.Drawing.Size(128, 23);
            this.ButtonOdustani.TabIndex = 50;
            this.ButtonOdustani.Text = "Odustani";
            this.ButtonOdustani.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ButtonOdustani.Click += new System.EventHandler(this.ButtonOdustani_Click);
            // 
            // UltraButton4
            // 
            this.ButtonSpremi.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.ButtonSpremi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonSpremi.Location = new System.Drawing.Point(460, 140);
            this.ButtonSpremi.Name = "UltraButton4";
            this.ButtonSpremi.Size = new System.Drawing.Size(123, 23);
            this.ButtonSpremi.TabIndex = 49;
            this.ButtonSpremi.Text = "Spremi";
            this.ButtonSpremi.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ButtonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // cbSifra
            // 
            appearance2.TextHAlignAsString = "Center";
            this.cbSifra.ButtonAppearance = appearance2;
            appearance3.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance3;
            editorButton1.Text = "...";
            this.cbSifra.ButtonsRight.Add(editorButton1);
            this.cbSifra.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbSifra.DataMember = "DDVRSTEPOSLA";
            this.cbSifra.DataSource = this.DdvrsteposlaDataSet1;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbSifra.DisplayLayout.Appearance = appearance4;
            this.cbSifra.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(91, 0);
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Width = 65;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "Naziv";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(422, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.Width = 316;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            ultraGridBand1.UseRowLayout = true;
            this.cbSifra.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbSifra.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbSifra.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.cbSifra.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.cbSifra.DisplayLayout.MaxColScrollRegions = 1;
            this.cbSifra.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSifra.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbSifra.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.cbSifra.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbSifra.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbSifra.DisplayLayout.Override.CellAppearance = appearance12;
            this.cbSifra.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cbSifra.DisplayLayout.Override.CellPadding = 0;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance14.TextHAlignAsString = "Left";
            this.cbSifra.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.cbSifra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbSifra.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            this.cbSifra.DisplayLayout.Override.RowAppearance = appearance15;
            this.cbSifra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbSifra.DisplayLayout.Override.TemplateAddRowAppearance = appearance16;
            this.cbSifra.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cbSifra.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cbSifra.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cbSifra.DisplayMember = "DDNAZIVVRSTAPOSLA";
            this.cbSifra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cbSifra.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbSifra.DropDownWidth = 532;
            this.cbSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbSifra.LimitToList = true;
            this.cbSifra.Location = new System.Drawing.Point(184, 11);
            this.cbSifra.MaxDropDownItems = 20;
            this.cbSifra.Name = "cbSifra";
            this.cbSifra.Size = new System.Drawing.Size(532, 22);
            this.cbSifra.TabIndex = 1;
            this.cbSifra.ValueMember = "DDIDVRSTAPOSLA";
            this.cbSifra.GotFocus += new System.EventHandler(this.cbSifra_GotFocus);
            this.cbSifra.Validating += new System.ComponentModel.CancelEventHandler(this.cbSifraValidating);
            // 
            // DdvrsteposlaDataSet1
            // 
            this.DdvrsteposlaDataSet1.DataSetName = "DDVRSTEPOSLADataSet";
            // 
            // UltraNumericEditor1
            // 
            this.UltraNumericEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.UltraNumericEditor1.FormatString = "#,##0.00";
            this.UltraNumericEditor1.Location = new System.Drawing.Point(441, 68);
            this.UltraNumericEditor1.MaskInput = "nnnnnnnnnn.nn";
            this.UltraNumericEditor1.Name = "UltraNumericEditor1";
            this.UltraNumericEditor1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.UltraNumericEditor1.Size = new System.Drawing.Size(91, 21);
            this.UltraNumericEditor1.TabIndex = 55;
            this.UltraNumericEditor1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // ButtonNetoUBruto
            // 
            this.ButtonNetoUBruto.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.ButtonNetoUBruto.Location = new System.Drawing.Point(441, 103);
            this.ButtonNetoUBruto.Name = "ButtonNetoUBruto";
            this.ButtonNetoUBruto.Size = new System.Drawing.Size(123, 23);
            this.ButtonNetoUBruto.TabIndex = 56;
            this.ButtonNetoUBruto.Text = "Neto -> Bruto";
            this.ButtonNetoUBruto.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ButtonNetoUBruto.Click += new System.EventHandler(this.ButtonNetoUBruto_Click);
            // 
            // ButtonUkupniTrosakUBruto
            // 
            this.ButtonUkupniTrosakUBruto.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.ButtonUkupniTrosakUBruto.Location = new System.Drawing.Point(570, 103);
            this.ButtonUkupniTrosakUBruto.Name = "ButtonUkupniTrosakUBruto";
            this.ButtonUkupniTrosakUBruto.Size = new System.Drawing.Size(146, 23);
            this.ButtonUkupniTrosakUBruto.TabIndex = 57;
            this.ButtonUkupniTrosakUBruto.Text = "Ukupni trošak -> Bruto";
            this.ButtonUkupniTrosakUBruto.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ButtonUkupniTrosakUBruto.Click += new System.EventHandler(this.ButtonUkupniTrosakUBruto_Click);
            // 
            // UltraLabel1
            // 
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.UltraLabel1.Appearance = appearance18;
            this.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel1.Location = new System.Drawing.Point(360, 66);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(80, 23);
            this.UltraLabel1.TabIndex = 62;
            this.UltraLabel1.Text = "Traženi iznos:";
            // 
            // frmUnosVrstePosla
            // 
            this.AcceptButton = this.ButtonSpremi;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.ButtonOdustani;
            this.ClientSize = new System.Drawing.Size(728, 168);
            this.Controls.Add(this.UltraLabel1);
            this.Controls.Add(this.ButtonUkupniTrosakUBruto);
            this.Controls.Add(this.ButtonNetoUBruto);
            this.Controls.Add(this.UltraNumericEditor1);
            this.Controls.Add(this.ButtonOdustani);
            this.Controls.Add(this.ButtonSpremi);
            this.Controls.Add(this.cbSifra);
            this.Controls.Add(this.btnFocus);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.Postotak);
            this.Controls.Add(this.Satnica);
            this.Controls.Add(this.BrojSati);
            this.Controls.Add(this.UltraLabel2);
            this.Controls.Add(this.UltraLabel3);
            this.Controls.Add(this.UltraLabel4);
            this.Controls.Add(this.UltraLabel5);
            this.Controls.Add(this.lblSifEle);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmUnosVrstePosla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obračun honorara - unos vrste posla";
            ((System.ComponentModel.ISupportInitialize)(this.BrojSati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Satnica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Postotak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdvrsteposlaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraNumericEditor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Iznos_ValueChanged(object sender, EventArgs e)
        {
            if (!this.pocetno)
            {
                this.UpdateIznosa(RuntimeHelpers.GetObjectValue(sender));
            }
        }

        private void NapuniVrstePosla()
        {
            DDVRSTEPOSLADataAdapter adapter = new DDVRSTEPOSLADataAdapter();
            this.DdvrsteposlaDataSet1.Clear();
            adapter.Fill(this.DdvrsteposlaDataSet1);
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
            Keys keys = keyData;
            if ((keys == Keys.Escape) && this.Zatvori())
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool ProvjeraPrijeSpremanja()
        {
            bool flag = false;
            if (this.cbSifra.Value == null)
            {
                flag = true;
            }
            NewLateBinding.LateIndexSetComplex(this.BindingContext[this._drvVrstaPosla].Current, new object[] { "DDIDVRSTAPOSLA", RuntimeHelpers.GetObjectValue(this.cbSifra.Value) }, null, false, true);
            if (flag)
            {
                MessageBox.Show("Greška prilikom spremanja podataka", "Spremi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
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
                this._drvVrstaPosla.EndEdit();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                flag = true;
            }
            catch (System.Exception exception1)
            {
                if (exception1.Message.IndexOf("unique") > 0)
                {
                    MessageBox.Show("Vrsta posla već je zadana trenutnoj osobi", "Drugi dohodak", MessageBoxButtons.OK);
                    this.cbSifra.Select();
                }
                else
                {
                    MessageBox.Show("Greška prilikom spremanja");
                }

                throw exception1;

                //flag = false;
                
            }
            return flag;
        }

        private void ButtonNetoUBruto_Click(object sender, EventArgs e)
        {
            decimal number = Conversions.ToDecimal(Operators.DivideObject(this.UltraNumericEditor1.Value, (1.0 - (((1.0 - (0.01 * Convert.ToDouble(this.___ParentForm.NetoUBruto_Izdaci()))) * 0.01) * Convert.ToDouble(this.___ParentForm.NetoUBruto_DopIz()))) - (((((1.0 - (0.01 * Convert.ToDouble(this.___ParentForm.NetoUBruto_Izdaci()))) * (1.0 - (0.01 * Convert.ToDouble(this.___ParentForm.NetoUBruto_DopIz())))) * 0.01) * Convert.ToDouble(this.___ParentForm.NetoUBruto_Porez())) * (1.0 + (0.01 * Convert.ToDouble(this.___ParentForm.NetoUBruto_Prirez()))))));
            this.Iznos.Value = DB.RoundUpDecimale(number, 2);
            this.Iznos.Focus();
            this.UltraNumericEditor1.Focus();
        }

        private void ButtonUkupniTrosakUBruto_Click(object sender, EventArgs e)
        {
            decimal num4 = 0;
            decimal num3 = 23M;
            decimal num = this.___ParentForm.NetoUBruto_DopNa();
            decimal num2 = this.___ParentForm.NetoUBruto_Izdaci();
            if (this.___ParentForm.NetoUBrutoPdv())
            {
                num4 = Conversions.ToDecimal(Operators.DivideObject(this.UltraNumericEditor1.Value, (1.0 + (((1.0 - (0.01 * Convert.ToDouble(num2))) * 0.01) * Convert.ToDouble(num))) + (0.01 * Convert.ToDouble(num3))));
            }
            else
            {
                num4 = Conversions.ToDecimal(Operators.DivideObject(this.UltraNumericEditor1.Value, (1.0 + (((1.0 - (0.01 * Convert.ToDouble(num2))) * 0.01) * Convert.ToDouble(num))) + 0.0));
            }
            this.Iznos.Value = DB.RoundUpDecimale(num4, 2);
            this.Iznos.Focus();
            this.UltraNumericEditor1.Focus();
        }

        private void ButtonOdustani_Click(object sender, EventArgs e)
        {
            try
            {
                this._drvVrstaPosla.CancelEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
            this.Close();
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            this.Spremi();
        }

        private void UpdateIznosa(object sender)
        {
            if (((UltraNumericEditor) sender).Name == "Iznos")
            {
                this._drvVrstaPosla["DDIZNOS"] = RuntimeHelpers.GetObjectValue(this.Iznos.Value);
            }
            else
            {
                decimal num = 0;
                if ((decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.BrojSati.Value)), decimal.Zero) > 0) & (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.Satnica.Value)), decimal.Zero) > 0))
                {
                    num = DB.RoundUP(DB.N20(Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(this.BrojSati.Value, DB.N20(RuntimeHelpers.GetObjectValue(this.Satnica.Value))), DB.N20(RuntimeHelpers.GetObjectValue(this.Postotak.Value))), 100)));
                }
                if ((this._drvVrstaPosla != null) && (decimal.Compare(num, decimal.Zero) != 0))
                {
                    this._drvVrstaPosla["DDIZNOS"] = num;
                    this.Iznos.Value = num;
                }
            }
        }

        private bool Zatvori()
        {
            try
            {
                this._drvVrstaPosla.CancelEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
            return true;
        }

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Bottom;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Left;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Right;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Top;

        private UltraNumericEditor BrojSati;

        private Button btnFocus;

        public UltraCombo cbSifra;

        private DDVRSTEPOSLADataSet DdvrsteposlaDataSet1;

        private UltraNumericEditor Iznos;

        public UltraLabel lblSifEle;

        private UltraNumericEditor Postotak;

        private UltraNumericEditor Satnica;

        private UltraButton ButtonNetoUBruto;

        private UltraButton ButtonUkupniTrosakUBruto;

        private UltraButton ButtonOdustani;

        private UltraButton ButtonSpremi;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel3;

        private UltraLabel UltraLabel4;

        private UltraLabel UltraLabel5;

        private UltraNumericEditor UltraNumericEditor1;
    }
}

