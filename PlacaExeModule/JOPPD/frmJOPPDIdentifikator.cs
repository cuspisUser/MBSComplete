using Hlp;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Data.SqlClient;
using Infragistics.Win.UltraWinGrid;

namespace JOPPD
{
    public class frmJOPPDIdentifikator : Form
    {
        private enum VrstaIzvjesca
        {
            Izvorno = 1,
            Ispravak = 2,
            Dopuna = 3,
            Invalidi = 4
        }

        private IContainer components { get; set; }
        BusinessLogic element = new BusinessLogic();

        //id obracuna placa
        public int? JOPPDID = null;
        public bool? ISObracunHonorara = null;
        public bool? ISObracunPutniNalog = null;
        public bool? ISObracunPlace = null;
        public bool? ISObracunPraksa = null;
        public bool? ISObracunRazno = null;
        public bool? ISVirmaniInvalidi = null;
        public string dopuna_oib = string.Empty;

        public int vrstaIzvjescaID;
        public int id_joppda;
        public int id_vrsta;

        private Infragistics.Win.Misc.UltraLabel UltraLabel7;
        private Infragistics.Win.UltraWinGrid.UltraCombo ddlVrstaIzvjesca;

        private Infragistics.Win.UltraWinGrid.UltraCombo ddlJOPPDObrazac;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private GroupBox gbx1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lblOznakaIzvjesca;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtpJOPPDObrazacDatum;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdPutniNalog;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdHonorari;
        private ToolStrip tspIzracunObracun;
        private ToolStripButton btnOdustani;
        private ToolStripButton btnSpremi;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdPraksa;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugdObracunPlace;
        private Label label2;
        private CheckBox cbkOznaciSvePraksa;
        private Label label1;
        private CheckBox cbkOznaciSvePutniNalog;
        private UltraGrid ugvDopuna;
        private Label label3;
        private CheckBox cbkObracuniRazno;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private UltraGrid ugdObracuniRazno;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private UltraCombo uceOznakaPodnositelja;
        private Label label4;
        private CheckBox cbkOznaciSveDopuna;
        private UltraGrid ugdVirmaniInvalidi;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private GroupBox groupBox2;

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJOPPDIdentifikator));
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            this.UltraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbkOznaciSveDopuna = new System.Windows.Forms.CheckBox();
            this.ugvDopuna = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ddlJOPPDObrazac = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ddlVrstaIzvjesca = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.gbx1 = new System.Windows.Forms.GroupBox();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.uceOznakaPodnositelja = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkObracuniRazno = new System.Windows.Forms.CheckBox();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ugdObracuniRazno = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.cbkOznaciSvePraksa = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbkOznaciSvePutniNalog = new System.Windows.Forms.CheckBox();
            this.ugdObracunPlace = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ugdPraksa = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ugdHonorari = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ugdPutniNalog = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.lblOznakaIzvjesca = new Infragistics.Win.Misc.UltraLabel();
            this.dtpJOPPDObrazacDatum = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.tspIzracunObracun = new System.Windows.Forms.ToolStrip();
            this.btnOdustani = new System.Windows.Forms.ToolStripButton();
            this.btnSpremi = new System.Windows.Forms.ToolStripButton();
            this.ugdVirmaniInvalidi = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugvDopuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlJOPPDObrazac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVrstaIzvjesca)).BeginInit();
            this.gbx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceOznakaPodnositelja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdObracuniRazno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdObracunPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdPraksa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdHonorari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdPutniNalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpJOPPDObrazacDatum)).BeginInit();
            this.tspIzracunObracun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugdVirmaniInvalidi)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraLabel7
            // 
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel7.Appearance = appearance32;
            this.UltraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel7.Location = new System.Drawing.Point(19, 47);
            this.UltraLabel7.Name = "UltraLabel7";
            this.UltraLabel7.Size = new System.Drawing.Size(92, 23);
            this.UltraLabel7.TabIndex = 115;
            this.UltraLabel7.Text = "Vrsta izvješća:";
            this.UltraLabel7.UseAppStyling = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbkOznaciSveDopuna);
            this.groupBox2.Controls.Add(this.ugvDopuna);
            this.groupBox2.Controls.Add(this.ddlJOPPDObrazac);
            this.groupBox2.Controls.Add(this.ultraLabel4);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 173);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ispravak / dopuna postojećeg obrasca";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 160;
            this.label4.Text = "Ozn. sve:";
            // 
            // cbkOznaciSveDopuna
            // 
            this.cbkOznaciSveDopuna.AutoSize = true;
            this.cbkOznaciSveDopuna.Location = new System.Drawing.Point(52, 76);
            this.cbkOznaciSveDopuna.Name = "cbkOznaciSveDopuna";
            this.cbkOznaciSveDopuna.Size = new System.Drawing.Size(15, 14);
            this.cbkOznaciSveDopuna.TabIndex = 159;
            this.cbkOznaciSveDopuna.UseVisualStyleBackColor = true;
            this.cbkOznaciSveDopuna.CheckedChanged += new System.EventHandler(this.cbkOznaciSvePutniNalog_CheckedChanged);
            // 
            // ugvDopuna
            // 
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugvDopuna.DisplayLayout.Appearance = appearance23;
            this.ugvDopuna.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugvDopuna.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance24.BorderColor = System.Drawing.SystemColors.Window;
            this.ugvDopuna.DisplayLayout.GroupByBox.Appearance = appearance24;
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugvDopuna.DisplayLayout.GroupByBox.BandLabelAppearance = appearance25;
            this.ugvDopuna.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugvDopuna.DisplayLayout.GroupByBox.Hidden = true;
            appearance26.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance26.BackColor2 = System.Drawing.SystemColors.Control;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance26.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugvDopuna.DisplayLayout.GroupByBox.PromptAppearance = appearance26;
            this.ugvDopuna.DisplayLayout.MaxColScrollRegions = 1;
            this.ugvDopuna.DisplayLayout.MaxRowScrollRegions = 1;
            appearance27.BackColor = System.Drawing.SystemColors.Window;
            appearance27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugvDopuna.DisplayLayout.Override.ActiveCellAppearance = appearance27;
            appearance28.BackColor = System.Drawing.SystemColors.Highlight;
            appearance28.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugvDopuna.DisplayLayout.Override.ActiveRowAppearance = appearance28;
            this.ugvDopuna.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugvDopuna.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            this.ugvDopuna.DisplayLayout.Override.CardAreaAppearance = appearance29;
            appearance30.BorderColor = System.Drawing.Color.Silver;
            appearance30.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugvDopuna.DisplayLayout.Override.CellAppearance = appearance30;
            this.ugvDopuna.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugvDopuna.DisplayLayout.Override.CellPadding = 0;
            appearance31.BackColor = System.Drawing.SystemColors.Control;
            appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance31.BorderColor = System.Drawing.SystemColors.Window;
            this.ugvDopuna.DisplayLayout.Override.GroupByRowAppearance = appearance31;
            appearance33.TextHAlignAsString = "Left";
            this.ugvDopuna.DisplayLayout.Override.HeaderAppearance = appearance33;
            this.ugvDopuna.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugvDopuna.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.BorderColor = System.Drawing.Color.Silver;
            this.ugvDopuna.DisplayLayout.Override.RowAppearance = appearance36;
            this.ugvDopuna.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugvDopuna.DisplayLayout.Override.TemplateAddRowAppearance = appearance37;
            this.ugvDopuna.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugvDopuna.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugvDopuna.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugvDopuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugvDopuna.Location = new System.Drawing.Point(102, 57);
            this.ugvDopuna.Name = "ugvDopuna";
            this.ugvDopuna.Size = new System.Drawing.Size(471, 80);
            this.ugvDopuna.TabIndex = 158;
            this.ugvDopuna.Text = "ultraGrid1";
            // 
            // ddlJOPPDObrazac
            // 
            this.ddlJOPPDObrazac.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ddlJOPPDObrazac.DisplayMember = "OznakaIzvjesca";
            this.ddlJOPPDObrazac.Location = new System.Drawing.Point(102, 29);
            this.ddlJOPPDObrazac.Name = "ddlJOPPDObrazac";
            this.ddlJOPPDObrazac.Size = new System.Drawing.Size(471, 22);
            this.ddlJOPPDObrazac.TabIndex = 130;
            this.ddlJOPPDObrazac.UseAppStyling = false;
            this.ddlJOPPDObrazac.ValueMember = "ID";
            this.ddlJOPPDObrazac.ValueChanged += new System.EventHandler(this.ddlJOPPDObrazac_ValueChanged);
            // 
            // ultraLabel4
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel4.Appearance = appearance1;
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel4.Location = new System.Drawing.Point(7, 33);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(91, 19);
            this.ultraLabel4.TabIndex = 129;
            this.ultraLabel4.Text = "Odabir obrasca:";
            this.ultraLabel4.UseAppStyling = false;
            // 
            // ddlVrstaIzvjesca
            // 
            this.ddlVrstaIzvjesca.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ddlVrstaIzvjesca.DisplayMember = "Naziv";
            this.ddlVrstaIzvjesca.Location = new System.Drawing.Point(124, 44);
            this.ddlVrstaIzvjesca.Name = "ddlVrstaIzvjesca";
            this.ddlVrstaIzvjesca.Size = new System.Drawing.Size(210, 22);
            this.ddlVrstaIzvjesca.TabIndex = 112;
            this.ddlVrstaIzvjesca.UseAppStyling = false;
            this.ddlVrstaIzvjesca.ValueMember = "ID";
            this.ddlVrstaIzvjesca.ValueChanged += new System.EventHandler(this.ddlVrstaIzvjesca_ValueChanged);
            // 
            // gbx1
            // 
            this.gbx1.Controls.Add(this.ugdVirmaniInvalidi);
            this.gbx1.Controls.Add(this.ultraLabel11);
            this.gbx1.Controls.Add(this.ultraLabel10);
            this.gbx1.Controls.Add(this.uceOznakaPodnositelja);
            this.gbx1.Controls.Add(this.label3);
            this.gbx1.Controls.Add(this.cbkObracuniRazno);
            this.gbx1.Controls.Add(this.ultraLabel9);
            this.gbx1.Controls.Add(this.ugdObracuniRazno);
            this.gbx1.Controls.Add(this.label2);
            this.gbx1.Controls.Add(this.cbkOznaciSvePraksa);
            this.gbx1.Controls.Add(this.label1);
            this.gbx1.Controls.Add(this.cbkOznaciSvePutniNalog);
            this.gbx1.Controls.Add(this.ugdObracunPlace);
            this.gbx1.Controls.Add(this.ugdPraksa);
            this.gbx1.Controls.Add(this.ugdHonorari);
            this.gbx1.Controls.Add(this.ugdPutniNalog);
            this.gbx1.Controls.Add(this.ultraLabel12);
            this.gbx1.Controls.Add(this.ultraLabel8);
            this.gbx1.Controls.Add(this.ultraLabel6);
            this.gbx1.Controls.Add(this.ultraLabel5);
            this.gbx1.Controls.Add(this.ultraLabel3);
            this.gbx1.Controls.Add(this.ultraLabel2);
            this.gbx1.Controls.Add(this.ultraLabel1);
            this.gbx1.Controls.Add(this.lblOznakaIzvjesca);
            this.gbx1.Controls.Add(this.dtpJOPPDObrazacDatum);
            this.gbx1.Location = new System.Drawing.Point(12, 82);
            this.gbx1.Name = "gbx1";
            this.gbx1.Size = new System.Drawing.Size(625, 655);
            this.gbx1.TabIndex = 126;
            this.gbx1.TabStop = false;
            this.gbx1.Text = "Kreiranje novog obrasca";
            // 
            // ultraLabel10
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel10.Appearance = appearance5;
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Location = new System.Drawing.Point(6, 58);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(110, 14);
            this.ultraLabel10.TabIndex = 163;
            this.ultraLabel10.Text = "Oznaka podnositelja:";
            this.ultraLabel10.UseAppStyling = false;
            // 
            // uceOznakaPodnositelja
            // 
            this.uceOznakaPodnositelja.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.uceOznakaPodnositelja.DisplayMember = "Oznaka";
            this.uceOznakaPodnositelja.Location = new System.Drawing.Point(121, 54);
            this.uceOznakaPodnositelja.Name = "uceOznakaPodnositelja";
            this.uceOznakaPodnositelja.Size = new System.Drawing.Size(224, 22);
            this.uceOznakaPodnositelja.TabIndex = 162;
            this.uceOznakaPodnositelja.UseAppStyling = false;
            this.uceOznakaPodnositelja.ValueMember = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 161;
            this.label3.Text = "Ozn. sve:";
            // 
            // cbkObracuniRazno
            // 
            this.cbkObracuniRazno.AutoSize = true;
            this.cbkObracuniRazno.Location = new System.Drawing.Point(35, 534);
            this.cbkObracuniRazno.Name = "cbkObracuniRazno";
            this.cbkObracuniRazno.Size = new System.Drawing.Size(15, 14);
            this.cbkObracuniRazno.TabIndex = 160;
            this.cbkObracuniRazno.UseVisualStyleBackColor = true;
            this.cbkObracuniRazno.CheckedChanged += new System.EventHandler(this.cbkOznaciSvePutniNalog_CheckedChanged);
            // 
            // ultraLabel9
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance7;
            this.ultraLabel9.Location = new System.Drawing.Point(7, 484);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(60, 26);
            this.ultraLabel9.TabIndex = 159;
            this.ultraLabel9.Text = "Obračuni razno:";
            this.ultraLabel9.UseAppStyling = false;
            // 
            // ugdObracuniRazno
            // 
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdObracuniRazno.DisplayLayout.Appearance = appearance4;
            this.ugdObracuniRazno.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdObracuniRazno.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdObracuniRazno.DisplayLayout.GroupByBox.Appearance = appearance12;
            appearance13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdObracuniRazno.DisplayLayout.GroupByBox.BandLabelAppearance = appearance13;
            this.ugdObracuniRazno.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdObracuniRazno.DisplayLayout.GroupByBox.Hidden = true;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance14.BackColor2 = System.Drawing.SystemColors.Control;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdObracuniRazno.DisplayLayout.GroupByBox.PromptAppearance = appearance14;
            this.ugdObracuniRazno.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdObracuniRazno.DisplayLayout.MaxRowScrollRegions = 1;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdObracuniRazno.DisplayLayout.Override.ActiveCellAppearance = appearance15;
            appearance16.BackColor = System.Drawing.SystemColors.Highlight;
            appearance16.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdObracuniRazno.DisplayLayout.Override.ActiveRowAppearance = appearance16;
            this.ugdObracuniRazno.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdObracuniRazno.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            this.ugdObracuniRazno.DisplayLayout.Override.CardAreaAppearance = appearance17;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdObracuniRazno.DisplayLayout.Override.CellAppearance = appearance18;
            this.ugdObracuniRazno.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdObracuniRazno.DisplayLayout.Override.CellPadding = 0;
            appearance19.BackColor = System.Drawing.SystemColors.Control;
            appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance19.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdObracuniRazno.DisplayLayout.Override.GroupByRowAppearance = appearance19;
            appearance20.TextHAlignAsString = "Left";
            this.ugdObracuniRazno.DisplayLayout.Override.HeaderAppearance = appearance20;
            this.ugdObracuniRazno.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdObracuniRazno.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.BorderColor = System.Drawing.Color.Silver;
            this.ugdObracuniRazno.DisplayLayout.Override.RowAppearance = appearance21;
            this.ugdObracuniRazno.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance22.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdObracuniRazno.DisplayLayout.Override.TemplateAddRowAppearance = appearance22;
            this.ugdObracuniRazno.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdObracuniRazno.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdObracuniRazno.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdObracuniRazno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdObracuniRazno.Location = new System.Drawing.Point(69, 481);
            this.ugdObracuniRazno.Name = "ugdObracuniRazno";
            this.ugdObracuniRazno.Size = new System.Drawing.Size(536, 75);
            this.ugdObracuniRazno.TabIndex = 158;
            this.ugdObracuniRazno.Text = "ultraGrid1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 157;
            this.label2.Text = "Ozn. sve:";
            // 
            // cbkOznaciSvePraksa
            // 
            this.cbkOznaciSvePraksa.AutoSize = true;
            this.cbkOznaciSvePraksa.Location = new System.Drawing.Point(35, 441);
            this.cbkOznaciSvePraksa.Name = "cbkOznaciSvePraksa";
            this.cbkOznaciSvePraksa.Size = new System.Drawing.Size(15, 14);
            this.cbkOznaciSvePraksa.TabIndex = 156;
            this.cbkOznaciSvePraksa.UseVisualStyleBackColor = true;
            this.cbkOznaciSvePraksa.CheckedChanged += new System.EventHandler(this.cbkOznaciSvePutniNalog_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 155;
            this.label1.Text = "Ozn. sve:";
            // 
            // cbkOznaciSvePutniNalog
            // 
            this.cbkOznaciSvePutniNalog.AutoSize = true;
            this.cbkOznaciSvePutniNalog.Location = new System.Drawing.Point(35, 360);
            this.cbkOznaciSvePutniNalog.Name = "cbkOznaciSvePutniNalog";
            this.cbkOznaciSvePutniNalog.Size = new System.Drawing.Size(15, 14);
            this.cbkOznaciSvePutniNalog.TabIndex = 154;
            this.cbkOznaciSvePutniNalog.UseVisualStyleBackColor = true;
            this.cbkOznaciSvePutniNalog.CheckedChanged += new System.EventHandler(this.cbkOznaciSvePutniNalog_CheckedChanged);
            // 
            // ugdObracunPlace
            // 
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdObracunPlace.DisplayLayout.Appearance = appearance9;
            this.ugdObracunPlace.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdObracunPlace.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance60.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance60.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance60.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdObracunPlace.DisplayLayout.GroupByBox.Appearance = appearance60;
            appearance61.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdObracunPlace.DisplayLayout.GroupByBox.BandLabelAppearance = appearance61;
            this.ugdObracunPlace.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdObracunPlace.DisplayLayout.GroupByBox.Hidden = true;
            appearance62.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance62.BackColor2 = System.Drawing.SystemColors.Control;
            appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance62.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdObracunPlace.DisplayLayout.GroupByBox.PromptAppearance = appearance62;
            this.ugdObracunPlace.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdObracunPlace.DisplayLayout.MaxRowScrollRegions = 1;
            appearance63.BackColor = System.Drawing.SystemColors.Window;
            appearance63.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdObracunPlace.DisplayLayout.Override.ActiveCellAppearance = appearance63;
            appearance64.BackColor = System.Drawing.SystemColors.Highlight;
            appearance64.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdObracunPlace.DisplayLayout.Override.ActiveRowAppearance = appearance64;
            this.ugdObracunPlace.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdObracunPlace.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            this.ugdObracunPlace.DisplayLayout.Override.CardAreaAppearance = appearance65;
            appearance66.BorderColor = System.Drawing.Color.Silver;
            appearance66.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdObracunPlace.DisplayLayout.Override.CellAppearance = appearance66;
            this.ugdObracunPlace.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdObracunPlace.DisplayLayout.Override.CellPadding = 0;
            appearance67.BackColor = System.Drawing.SystemColors.Control;
            appearance67.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance67.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance67.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdObracunPlace.DisplayLayout.Override.GroupByRowAppearance = appearance67;
            appearance68.TextHAlignAsString = "Left";
            this.ugdObracunPlace.DisplayLayout.Override.HeaderAppearance = appearance68;
            this.ugdObracunPlace.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdObracunPlace.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance69.BackColor = System.Drawing.SystemColors.Window;
            appearance69.BorderColor = System.Drawing.Color.Silver;
            this.ugdObracunPlace.DisplayLayout.Override.RowAppearance = appearance69;
            this.ugdObracunPlace.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance70.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdObracunPlace.DisplayLayout.Override.TemplateAddRowAppearance = appearance70;
            this.ugdObracunPlace.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdObracunPlace.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdObracunPlace.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdObracunPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdObracunPlace.Location = new System.Drawing.Point(70, 142);
            this.ugdObracunPlace.Name = "ugdObracunPlace";
            this.ugdObracunPlace.Size = new System.Drawing.Size(536, 75);
            this.ugdObracunPlace.TabIndex = 153;
            this.ugdObracunPlace.Text = "ultraGrid1";
            // 
            // ugdPraksa
            // 
            appearance71.BackColor = System.Drawing.SystemColors.Window;
            appearance71.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdPraksa.DisplayLayout.Appearance = appearance71;
            this.ugdPraksa.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdPraksa.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance72.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance72.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdPraksa.DisplayLayout.GroupByBox.Appearance = appearance72;
            appearance73.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdPraksa.DisplayLayout.GroupByBox.BandLabelAppearance = appearance73;
            this.ugdPraksa.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdPraksa.DisplayLayout.GroupByBox.Hidden = true;
            appearance74.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance74.BackColor2 = System.Drawing.SystemColors.Control;
            appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance74.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdPraksa.DisplayLayout.GroupByBox.PromptAppearance = appearance74;
            this.ugdPraksa.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdPraksa.DisplayLayout.MaxRowScrollRegions = 1;
            appearance75.BackColor = System.Drawing.SystemColors.Window;
            appearance75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdPraksa.DisplayLayout.Override.ActiveCellAppearance = appearance75;
            appearance76.BackColor = System.Drawing.SystemColors.Highlight;
            appearance76.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdPraksa.DisplayLayout.Override.ActiveRowAppearance = appearance76;
            this.ugdPraksa.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdPraksa.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance77.BackColor = System.Drawing.SystemColors.Window;
            this.ugdPraksa.DisplayLayout.Override.CardAreaAppearance = appearance77;
            appearance78.BorderColor = System.Drawing.Color.Silver;
            appearance78.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdPraksa.DisplayLayout.Override.CellAppearance = appearance78;
            this.ugdPraksa.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdPraksa.DisplayLayout.Override.CellPadding = 0;
            appearance79.BackColor = System.Drawing.SystemColors.Control;
            appearance79.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance79.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance79.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdPraksa.DisplayLayout.Override.GroupByRowAppearance = appearance79;
            appearance80.TextHAlignAsString = "Left";
            this.ugdPraksa.DisplayLayout.Override.HeaderAppearance = appearance80;
            this.ugdPraksa.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdPraksa.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance81.BackColor = System.Drawing.SystemColors.Window;
            appearance81.BorderColor = System.Drawing.Color.Silver;
            this.ugdPraksa.DisplayLayout.Override.RowAppearance = appearance81;
            this.ugdPraksa.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance82.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdPraksa.DisplayLayout.Override.TemplateAddRowAppearance = appearance82;
            this.ugdPraksa.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdPraksa.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdPraksa.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdPraksa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdPraksa.Location = new System.Drawing.Point(70, 394);
            this.ugdPraksa.Name = "ugdPraksa";
            this.ugdPraksa.Size = new System.Drawing.Size(536, 75);
            this.ugdPraksa.TabIndex = 152;
            this.ugdPraksa.Text = "ultraGrid1";
            // 
            // ugdHonorari
            // 
            appearance85.BackColor = System.Drawing.SystemColors.Window;
            appearance85.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdHonorari.DisplayLayout.Appearance = appearance85;
            this.ugdHonorari.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdHonorari.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance86.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance86.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance86.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance86.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdHonorari.DisplayLayout.GroupByBox.Appearance = appearance86;
            appearance87.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdHonorari.DisplayLayout.GroupByBox.BandLabelAppearance = appearance87;
            this.ugdHonorari.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdHonorari.DisplayLayout.GroupByBox.Hidden = true;
            appearance88.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance88.BackColor2 = System.Drawing.SystemColors.Control;
            appearance88.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance88.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdHonorari.DisplayLayout.GroupByBox.PromptAppearance = appearance88;
            this.ugdHonorari.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdHonorari.DisplayLayout.MaxRowScrollRegions = 1;
            appearance89.BackColor = System.Drawing.SystemColors.Window;
            appearance89.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdHonorari.DisplayLayout.Override.ActiveCellAppearance = appearance89;
            appearance90.BackColor = System.Drawing.SystemColors.Highlight;
            appearance90.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdHonorari.DisplayLayout.Override.ActiveRowAppearance = appearance90;
            this.ugdHonorari.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdHonorari.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance91.BackColor = System.Drawing.SystemColors.Window;
            this.ugdHonorari.DisplayLayout.Override.CardAreaAppearance = appearance91;
            appearance92.BorderColor = System.Drawing.Color.Silver;
            appearance92.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdHonorari.DisplayLayout.Override.CellAppearance = appearance92;
            this.ugdHonorari.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdHonorari.DisplayLayout.Override.CellPadding = 0;
            appearance93.BackColor = System.Drawing.SystemColors.Control;
            appearance93.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance93.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance93.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdHonorari.DisplayLayout.Override.GroupByRowAppearance = appearance93;
            appearance94.TextHAlignAsString = "Left";
            this.ugdHonorari.DisplayLayout.Override.HeaderAppearance = appearance94;
            this.ugdHonorari.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdHonorari.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance95.BackColor = System.Drawing.SystemColors.Window;
            appearance95.BorderColor = System.Drawing.Color.Silver;
            this.ugdHonorari.DisplayLayout.Override.RowAppearance = appearance95;
            this.ugdHonorari.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance96.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdHonorari.DisplayLayout.Override.TemplateAddRowAppearance = appearance96;
            this.ugdHonorari.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdHonorari.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdHonorari.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdHonorari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdHonorari.Location = new System.Drawing.Point(70, 226);
            this.ugdHonorari.Name = "ugdHonorari";
            this.ugdHonorari.Size = new System.Drawing.Size(536, 75);
            this.ugdHonorari.TabIndex = 151;
            this.ugdHonorari.Text = "ultraGrid1";
            // 
            // ugdPutniNalog
            // 
            appearance38.BackColor = System.Drawing.SystemColors.Window;
            appearance38.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdPutniNalog.DisplayLayout.Appearance = appearance38;
            this.ugdPutniNalog.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdPutniNalog.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance39.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance39.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdPutniNalog.DisplayLayout.GroupByBox.Appearance = appearance39;
            appearance40.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdPutniNalog.DisplayLayout.GroupByBox.BandLabelAppearance = appearance40;
            this.ugdPutniNalog.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdPutniNalog.DisplayLayout.GroupByBox.Hidden = true;
            appearance41.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance41.BackColor2 = System.Drawing.SystemColors.Control;
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance41.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdPutniNalog.DisplayLayout.GroupByBox.PromptAppearance = appearance41;
            this.ugdPutniNalog.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdPutniNalog.DisplayLayout.MaxRowScrollRegions = 1;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdPutniNalog.DisplayLayout.Override.ActiveCellAppearance = appearance42;
            appearance43.BackColor = System.Drawing.SystemColors.Highlight;
            appearance43.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdPutniNalog.DisplayLayout.Override.ActiveRowAppearance = appearance43;
            this.ugdPutniNalog.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdPutniNalog.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            this.ugdPutniNalog.DisplayLayout.Override.CardAreaAppearance = appearance44;
            appearance45.BorderColor = System.Drawing.Color.Silver;
            appearance45.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdPutniNalog.DisplayLayout.Override.CellAppearance = appearance45;
            this.ugdPutniNalog.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdPutniNalog.DisplayLayout.Override.CellPadding = 0;
            appearance46.BackColor = System.Drawing.SystemColors.Control;
            appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance46.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance46.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdPutniNalog.DisplayLayout.Override.GroupByRowAppearance = appearance46;
            appearance47.TextHAlignAsString = "Left";
            this.ugdPutniNalog.DisplayLayout.Override.HeaderAppearance = appearance47;
            this.ugdPutniNalog.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdPutniNalog.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance48.BackColor = System.Drawing.SystemColors.Window;
            appearance48.BorderColor = System.Drawing.Color.Silver;
            this.ugdPutniNalog.DisplayLayout.Override.RowAppearance = appearance48;
            this.ugdPutniNalog.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance49.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdPutniNalog.DisplayLayout.Override.TemplateAddRowAppearance = appearance49;
            this.ugdPutniNalog.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdPutniNalog.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdPutniNalog.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdPutniNalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdPutniNalog.Location = new System.Drawing.Point(70, 309);
            this.ugdPutniNalog.Name = "ugdPutniNalog";
            this.ugdPutniNalog.Size = new System.Drawing.Size(536, 75);
            this.ugdPutniNalog.TabIndex = 149;
            this.ugdPutniNalog.Text = "ultraGrid1";
            // 
            // ultraLabel12
            // 
            appearance83.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel12.Appearance = appearance83;
            this.ultraLabel12.AutoSize = true;
            this.ultraLabel12.Location = new System.Drawing.Point(23, 397);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(43, 14);
            this.ultraLabel12.TabIndex = 145;
            this.ultraLabel12.Text = "Praksa:";
            this.ultraLabel12.UseAppStyling = false;
            // 
            // ultraLabel8
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel8.Appearance = appearance10;
            this.ultraLabel8.AutoSize = true;
            this.ultraLabel8.Location = new System.Drawing.Point(3, 313);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(64, 14);
            this.ultraLabel8.TabIndex = 140;
            this.ultraLabel8.Text = "Putni nalog:";
            this.ultraLabel8.UseAppStyling = false;
            // 
            // ultraLabel6
            // 
            appearance97.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel6.Appearance = appearance97;
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Location = new System.Drawing.Point(15, 238);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(51, 14);
            this.ultraLabel6.TabIndex = 139;
            this.ultraLabel6.Text = "Honorari:";
            this.ultraLabel6.UseAppStyling = false;
            // 
            // ultraLabel5
            // 
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel5.Appearance = appearance34;
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel5.Location = new System.Drawing.Point(6, 120);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(324, 17);
            this.ultraLabel5.TabIndex = 138;
            this.ultraLabel5.Text = "Uključite u obrazac slijedeće obračune:";
            this.ultraLabel5.UseAppStyling = false;
            // 
            // ultraLabel3
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel3.Appearance = appearance6;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(30, 147);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(36, 14);
            this.ultraLabel3.TabIndex = 136;
            this.ultraLabel3.Text = "Plaće:";
            this.ultraLabel3.UseAppStyling = false;
            // 
            // ultraLabel2
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(72, 28);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(44, 14);
            this.ultraLabel2.TabIndex = 135;
            this.ultraLabel2.Text = "Na dan:";
            this.ultraLabel2.UseAppStyling = false;
            // 
            // ultraLabel1
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel1.Location = new System.Drawing.Point(23, 88);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(90, 14);
            this.ultraLabel1.TabIndex = 134;
            this.ultraLabel1.Text = "Oznaka izvješća:";
            this.ultraLabel1.UseAppStyling = false;
            // 
            // lblOznakaIzvjesca
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.lblOznakaIzvjesca.Appearance = appearance11;
            this.lblOznakaIzvjesca.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblOznakaIzvjesca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOznakaIzvjesca.Location = new System.Drawing.Point(121, 86);
            this.lblOznakaIzvjesca.Name = "lblOznakaIzvjesca";
            this.lblOznakaIzvjesca.Size = new System.Drawing.Size(224, 20);
            this.lblOznakaIzvjesca.TabIndex = 133;
            this.lblOznakaIzvjesca.UseAppStyling = false;
            // 
            // dtpJOPPDObrazacDatum
            // 
            this.dtpJOPPDObrazacDatum.DateTime = new System.DateTime(2013, 12, 25, 0, 0, 0, 0);
            this.dtpJOPPDObrazacDatum.Location = new System.Drawing.Point(121, 24);
            this.dtpJOPPDObrazacDatum.Name = "dtpJOPPDObrazacDatum";
            this.dtpJOPPDObrazacDatum.Size = new System.Drawing.Size(224, 21);
            this.dtpJOPPDObrazacDatum.TabIndex = 132;
            this.dtpJOPPDObrazacDatum.UseAppStyling = false;
            this.dtpJOPPDObrazacDatum.Value = new System.DateTime(2013, 12, 25, 0, 0, 0, 0);
            // 
            // tspIzracunObracun
            // 
            this.tspIzracunObracun.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOdustani,
            this.btnSpremi});
            this.tspIzracunObracun.Location = new System.Drawing.Point(0, 0);
            this.tspIzracunObracun.Name = "tspIzracunObracun";
            this.tspIzracunObracun.Size = new System.Drawing.Size(649, 32);
            this.tspIzracunObracun.TabIndex = 127;
            this.tspIzracunObracun.Text = "toolStrip1";
            // 
            // btnOdustani
            // 
            this.btnOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOdustani.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(92, 29);
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click_1);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSpremi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSpremi.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSpremi.Image = ((System.Drawing.Image)(resources.GetObject("btnSpremi.Image")));
            this.btnSpremi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(204, 29);
            this.btnSpremi.Text = "Kreiraj JOPPD obrazac";
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // ugdVirmaniInvalidi
            // 
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugdVirmaniInvalidi.DisplayLayout.Appearance = appearance8;
            this.ugdVirmaniInvalidi.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdVirmaniInvalidi.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance35.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance35.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance35.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdVirmaniInvalidi.DisplayLayout.GroupByBox.Appearance = appearance35;
            appearance50.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdVirmaniInvalidi.DisplayLayout.GroupByBox.BandLabelAppearance = appearance50;
            this.ugdVirmaniInvalidi.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugdVirmaniInvalidi.DisplayLayout.GroupByBox.Hidden = true;
            appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance51.BackColor2 = System.Drawing.SystemColors.Control;
            appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance51.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugdVirmaniInvalidi.DisplayLayout.GroupByBox.PromptAppearance = appearance51;
            this.ugdVirmaniInvalidi.DisplayLayout.MaxColScrollRegions = 1;
            this.ugdVirmaniInvalidi.DisplayLayout.MaxRowScrollRegions = 1;
            appearance52.BackColor = System.Drawing.SystemColors.Window;
            appearance52.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.ActiveCellAppearance = appearance52;
            appearance53.BackColor = System.Drawing.SystemColors.Highlight;
            appearance53.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.ActiveRowAppearance = appearance53;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance54.BackColor = System.Drawing.SystemColors.Window;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.CardAreaAppearance = appearance54;
            appearance55.BorderColor = System.Drawing.Color.Silver;
            appearance55.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.CellAppearance = appearance55;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.CellPadding = 0;
            appearance56.BackColor = System.Drawing.SystemColors.Control;
            appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance56.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance56.BorderColor = System.Drawing.SystemColors.Window;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.GroupByRowAppearance = appearance56;
            appearance57.TextHAlignAsString = "Left";
            this.ugdVirmaniInvalidi.DisplayLayout.Override.HeaderAppearance = appearance57;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance58.BackColor = System.Drawing.SystemColors.Window;
            appearance58.BorderColor = System.Drawing.Color.Silver;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.RowAppearance = appearance58;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance59.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugdVirmaniInvalidi.DisplayLayout.Override.TemplateAddRowAppearance = appearance59;
            this.ugdVirmaniInvalidi.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugdVirmaniInvalidi.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdVirmaniInvalidi.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdVirmaniInvalidi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdVirmaniInvalidi.Location = new System.Drawing.Point(69, 572);
            this.ugdVirmaniInvalidi.Name = "ugdVirmaniInvalidi";
            this.ugdVirmaniInvalidi.Size = new System.Drawing.Size(536, 75);
            this.ugdVirmaniInvalidi.TabIndex = 165;
            this.ugdVirmaniInvalidi.Text = "ultraGrid1";
            // 
            // ultraLabel11
            // 
            appearance84.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel11.Appearance = appearance84;
            this.ultraLabel11.Location = new System.Drawing.Point(3, 584);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(60, 49);
            this.ultraLabel11.TabIndex = 164;
            this.ultraLabel11.Text = "Virmani za invalide:";
            this.ultraLabel11.UseAppStyling = false;
            // 
            // frmJOPPDIdentifikator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(649, 841);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tspIzracunObracun);
            this.Controls.Add(this.gbx1);
            this.Controls.Add(this.UltraLabel7);
            this.Controls.Add(this.ddlVrstaIzvjesca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJOPPDIdentifikator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kreiranje novog JOPPD obrasca";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugvDopuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlJOPPDObrazac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVrstaIzvjesca)).EndInit();
            this.gbx1.ResumeLayout(false);
            this.gbx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceOznakaPodnositelja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdObracuniRazno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdObracunPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdPraksa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdHonorari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdPutniNalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpJOPPDObrazacDatum)).EndInit();
            this.tspIzracunObracun.ResumeLayout(false);
            this.tspIzracunObracun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugdVirmaniInvalidi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public frmJOPPDIdentifikator()
        {
            base.Load += new EventHandler(this.frmJOPPDIdentifikator_Load);
            this.InitializeComponent();

        }

        private void frmJOPPDIdentifikator_Load(object sender, EventArgs e)
        {
            NapuniVrstaIzvjesca(element);
            NapuniObracunPlace(element);
            NapuniObracunHonorari(element);
            NapuniPostojeciObracun(element);
            NapuniObracunPraksa(element);
            NapuniObracunPutniNalog(element);
            NapuniObracunRazno(element);
            NapuniVirmaniInvalidi(element);

            NapuniOznakuPodnositelja(element);


            uceOznakaPodnositelja.Value = 1;
            this.ddlVrstaIzvjesca.Value = 1;
            this.ddlVrstaIzvjesca_ValueChanged(null, null);

            this.dtpJOPPDObrazacDatum.Value = DateTime.Today;
            this.dtpJOPPDObrazacDatum_ValueChanged(null, null);
        }

        private void NapuniVirmaniInvalidi(BusinessLogic element)
        {
            ugdVirmaniInvalidi.DataSource = element.GetVirmaniInvalidi().DefaultView;
            ugdVirmaniInvalidi.DataBind();

            Tools.UltraGridStyling(ugdVirmaniInvalidi);

            if (ugdVirmaniInvalidi.DisplayLayout.Bands.Count > 0)
                if (ugdVirmaniInvalidi.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdVirmaniInvalidi.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdVirmaniInvalidi.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdVirmaniInvalidi.DisplayLayout.Bands[0].ColHeadersVisible = false;
                    ugdVirmaniInvalidi.DisplayLayout.Bands[0].Columns[3].Format = "N2";
                }
        }

        private void NapuniVrstaIzvjesca(BusinessLogic element)
        {
            ddlVrstaIzvjesca.DataSource = element.GetVrstaIzvjesca().DefaultView;
            ddlVrstaIzvjesca.DataBind();
        }

        private void NapuniObracunPlace(BusinessLogic element)
        {
            ugdObracunPlace.DataSource = element.GetObracunPlace().DefaultView;
            ugdObracunPlace.DataBind();

            Tools.UltraGridStyling(ugdObracunPlace);

            if (ugdObracunPlace.DisplayLayout.Bands.Count > 0)
                if (ugdObracunPlace.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdObracunPlace.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdObracunPlace.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdObracunPlace.DisplayLayout.Bands[0].ColHeadersVisible = false;
                }
        }

        private void NapuniObracunPraksa(BusinessLogic element)
        {
            ugdPraksa.DataSource = element.GetObracunPraksa().DefaultView;
            ugdPraksa.DataBind();

            Tools.UltraGridStyling(ugdPraksa);

            if (ugdPraksa.DisplayLayout.Bands.Count > 0)
                if (ugdPraksa.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdPraksa.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdPraksa.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdPraksa.DisplayLayout.Bands[0].ColHeadersVisible = false;
                }
        }

        private void NapuniObracunHonorari(BusinessLogic element)
        {
            ugdHonorari.DataSource = element.GetObracunHonorari().DefaultView;
            ugdHonorari.DataBind();

            Tools.UltraGridStyling(ugdHonorari);

            if (ugdHonorari.DisplayLayout.Bands.Count > 0)
                if (ugdHonorari.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdHonorari.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdHonorari.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdHonorari.DisplayLayout.Bands[0].ColHeadersVisible = false;
                }
        }

        private void NapuniObracunPutniNalog(BusinessLogic element)
        {
            ugdPutniNalog.DataSource = element.GetObracunPutniNalog().DefaultView;
            ugdPutniNalog.DataBind();

            Tools.UltraGridStyling(ugdPutniNalog);

            if (ugdPutniNalog.DisplayLayout.Bands.Count > 0)
                if (ugdPutniNalog.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdPutniNalog.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdPutniNalog.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdPutniNalog.DisplayLayout.Bands[0].ColHeadersVisible = false;
                    ugdPutniNalog.DisplayLayout.Bands[0].Columns[4].Width = 100;
                    ugdPutniNalog.DisplayLayout.Bands[0].Columns[5].Hidden = true;
                    ugdPutniNalog.DisplayLayout.Bands[0].Columns[6].Hidden = true;
                }
        }

        private void NapuniObracunRazno(BusinessLogic element)
        {
            ugdObracuniRazno.DataSource = element.GetObracunRazno().DefaultView;
            ugdObracuniRazno.DataBind();

            Tools.UltraGridStyling(ugdObracuniRazno);

            if (ugdObracuniRazno.DisplayLayout.Bands.Count > 0)
                if (ugdObracuniRazno.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdObracuniRazno.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdObracuniRazno.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdObracuniRazno.DisplayLayout.Bands[0].ColHeadersVisible = false;
                    ugdObracuniRazno.DisplayLayout.Bands[0].Columns[2].Width = 100;
                }
        }

        private void NapuniOznakuPodnositelja(BusinessLogic elelemt)
        {
            uceOznakaPodnositelja.DataSource = element.GetOznakaPodnositelja();
            uceOznakaPodnositelja.DataBind();
        }

        private void NapuniRadnikeDopuna(BusinessLogic element, string joppda_id)
        {
            ugvDopuna.DataSource = element.GetRadniciDopuna(joppda_id).DefaultView;
            ugvDopuna.DataBind();

            Tools.UltraGridStyling(ugvDopuna);

            if (ugvDopuna.DisplayLayout.Bands.Count > 0)
                if (ugvDopuna.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugvDopuna.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugvDopuna.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    //ugvDopuna.DisplayLayout.Bands[0].ColHeadersVisible = false;
                    //ugdPutniNalog.DisplayLayout.Bands[0].Columns[4].Width = 100;
                }
        }

        private void NapuniPostojeciObracun(BusinessLogic element)
        {
            ddlJOPPDObrazac.DataSource = element.GetPostojeciObracun().DefaultView;
            ddlJOPPDObrazac.DataBind();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (KreirajJOPPDA())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            switch (keyData)
            {
                case Keys.Return:
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    return true;

                case Keys.Escape:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool KreirajJOPPDA()
        {
            try
            {
                vrstaIzvjescaID = (int)this.ddlVrstaIzvjesca.Value;

                // varijable za INSERT
                DateTime oznakaIzvjescaDatum = (DateTime)this.dtpJOPPDObrazacDatum.Value;
                System.Collections.Generic.List<string> obracuni = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> putni_nalog = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> praksa = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> honorari = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> obracuni_razno = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> virmani_invalidi = new System.Collections.Generic.List<string>();

                decimal vrstaIzvjescaSifra = element.GetSifraVrsteIzvjesca(vrstaIzvjescaID);
                const int oznaka_place = 0;
                const int oznaka_honorari = 1;
                const int oznaka_putni_nalog = 2;
                const int oznaka_praksa = 3;
                const int oznaka_razno = 4;
                const int oznaka_invalidi = 5;

                // NOVI
                if (vrstaIzvjescaSifra == (decimal)VrstaIzvjesca.Izvorno || vrstaIzvjescaSifra == (decimal)VrstaIzvjesca.Invalidi)
                {

                    // Validacija place
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdObracunPlace.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                        {
                            obracuni.Add(row.Cells["IDOBRACUN"].Value.ToString());
                        }
                    }

                    // Validacija putni nalog
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdPutniNalog.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                        {
                            putni_nalog.Add(row.Cells["ID"].Value.ToString());
                        }
                    }

                    // Validacija praksa
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdPraksa.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                        {
                            praksa.Add(row.Cells["IDOBRACUN"].Value.ToString());
                        }
                    }

                    //validacija honorari
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdHonorari.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                        {
                            honorari.Add(row.Cells["IDOBRACUN"].Value.ToString());
                        }
                    }

                    //validacija razno
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdObracuniRazno.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                        {
                            obracuni_razno.Add(row.Cells["Sifra"].Value.ToString());
                        }
                    }

                    //validacija virmani invalidi
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdVirmaniInvalidi.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                        {
                            virmani_invalidi.Add(row.Cells["IDOBRACUN"].Value.ToString());
                        }
                    }

                    if (honorari.Count == 0 & putni_nalog.Count == 0 & obracuni.Count == 0 & praksa.Count == 0 & obracuni_razno.Count == 0 & virmani_invalidi.Count == 0)
                    {
                        throw new Exception("Molimo, odaberite jedan od obračuna za koji želite kreirati JOPPD obrazac.");
                    }

                    if(uceOznakaPodnositelja.Value == null)
                    {
                        throw new Exception("Molimo, odaberite oznaku podnositelja.");
                    }

                    //ukoliko se radi o praksi moze se raditi samo joppd za praksu 
                    if(praksa.Count > 0 && (honorari.Count > 0 | putni_nalog.Count > 0 | obracuni.Count > 0 | obracuni_razno.Count > 0))
                    {
                        throw new Exception("Praksa ima drugu oznaku podnositelja te možete kreirati JOPPD obrazac samo za praksu.");
                    }

                    //ukoliko se radi o invalidima moze se raditi samo joppd za invalide 
                    if (virmani_invalidi.Count > 0 && (honorari.Count > 0 | putni_nalog.Count > 0 | obracuni.Count > 0 | obracuni_razno.Count > 0 | praksa.Count > 0))
                    {
                        throw new Exception("Invalidi ima drugu oznaku izvješća te možete kreirati JOPPD obrazac samo za invalide.");
                    }

                    //ukoliko je vrsta izvjesca 4 moze se raditi samo joppd za invalide
                    if ((int)ddlVrstaIzvjesca.Value == 4 && (honorari.Count > 0 | putni_nalog.Count > 0 | obracuni.Count > 0 | obracuni_razno.Count > 0 | praksa.Count > 0))
                    {
                        throw new Exception("Za vrstu izvješća 4 može se raditi JOPPD isključivo za invalide");
                    }
                    
                    //ukoliko se izaberu invalidi moguce je da bude samo vrsta izvjesca 4
                    if(virmani_invalidi.Count > 0 && (int)ddlVrstaIzvjesca.Value != 4)
                    {
                        throw new Exception("Za kreiranje JOPPD-a za invalide vrsta izvješća treba biti 4");
                    }

                    if (praksa.Count > 0)
                    {
                        id_vrsta = 6;
                    }
                    else
                    {
                        id_vrsta = (int)uceOznakaPodnositelja.Value;
                    }

                    // podaci za kasniji INSERT
                    oznakaIzvjescaDatum = (DateTime)this.dtpJOPPDObrazacDatum.Value;

                    if (obracuni.Count > 0)
                    {
                        ISObracunPlace = true;

                        if (honorari.Count > 0)
                            ISObracunHonorara = true;
                        else
                            ISObracunHonorara = false;

                        if (putni_nalog.Count > 0)
                            ISObracunPutniNalog = true;
                        else
                            ISObracunPutniNalog = false;

                        if (praksa.Count > 0)
                            ISObracunPraksa = true;
                        else
                            ISObracunPraksa = false;

                        if (obracuni_razno.Count > 0)
                            ISObracunRazno = true;
                        else
                            ISObracunRazno = false;

                        if (virmani_invalidi.Count > 0)
                            ISVirmaniInvalidi = true;
                        else
                            ISVirmaniInvalidi = false;
                    }
                    else if (honorari.Count > 0)
                    {
                        ISObracunPlace = false;
                        ISObracunHonorara = true;

                        if (putni_nalog.Count > 0)
                            ISObracunPutniNalog = true;
                        else
                            ISObracunPutniNalog = false;

                        if (praksa.Count > 0)
                            ISObracunPraksa = true;
                        else
                            ISObracunPraksa = false;

                        if (obracuni_razno.Count > 0)
                            ISObracunRazno = true;
                        else
                            ISObracunRazno = false;

                        if (virmani_invalidi.Count > 0)
                            ISVirmaniInvalidi = true;
                        else
                            ISVirmaniInvalidi = false;
                    }
                    else if (putni_nalog.Count > 0)
                    {
                        ISObracunPlace = false;
                        ISObracunHonorara = false;
                        ISObracunPutniNalog = true;

                        if (praksa.Count > 0)
                            ISObracunPraksa = true;
                        else
                            ISObracunPraksa = false;

                        if (obracuni_razno.Count > 0)
                            ISObracunRazno = true;
                        else
                            ISObracunRazno = false;

                        if (virmani_invalidi.Count > 0)
                            ISVirmaniInvalidi = true;
                        else
                            ISVirmaniInvalidi = false;
                    }
                    else if(praksa.Count > 0)
                    {
                        ISObracunPlace = false;
                        ISObracunHonorara = false;
                        ISObracunPutniNalog = false;
                        ISObracunPraksa = true;

                        if (obracuni_razno.Count > 0)
                            ISObracunRazno = true;
                        else
                            ISObracunRazno = false;

                        if (virmani_invalidi.Count > 0)
                            ISVirmaniInvalidi = true;
                        else
                            ISVirmaniInvalidi = false;
                    }
                    else if (obracuni_razno.Count > 0)
                    {
                        ISObracunPlace = false;
                        ISObracunHonorara = false;
                        ISObracunPutniNalog = false;
                        ISObracunPraksa = false;
                        ISObracunRazno = true;

                        if (virmani_invalidi.Count > 0)
                            ISVirmaniInvalidi = true;
                        else
                            ISVirmaniInvalidi = false;
                    }
                    else if (virmani_invalidi.Count > 0)
                    {
                        ISObracunPlace = false;
                        ISObracunHonorara = false;
                        ISObracunPutniNalog = false;
                        ISObracunPraksa = false;
                        ISObracunRazno = false;
                        ISVirmaniInvalidi = true;
                    }
                }
                // ISPRAVAK ili DOPUNA
                else if (vrstaIzvjescaSifra == (decimal)VrstaIzvjesca.Ispravak || vrstaIzvjescaSifra == (decimal)VrstaIzvjesca.Dopuna)
                {
                    //dopuna dohvat odredenih radnika
                    if (vrstaIzvjescaSifra == (decimal)VrstaIzvjesca.Dopuna)
                    {
                        int broj_obracuna = 0;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugvDopuna.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                            {
                                broj_obracuna++;
                            }
                        }

                        for (int i = 0; i < ugvDopuna.Rows.Count; i++)
                        {
                            if (ugvDopuna.Rows[i].Cells["Ozn"].Value.ToString() == "True")
                            {
                                broj_obracuna--;
                                if (broj_obracuna == 0)
                                {
                                    dopuna_oib += "'" + ugvDopuna.Rows[i].Cells["OIBStjecatelja"].Value.ToString().Trim() + "'";
                                }
                                else
                                {
                                    dopuna_oib += "'" + ugvDopuna.Rows[i].Cells["OIBStjecatelja"].Value.ToString().Trim() + "',";
                                }
                            }
                        }
                    }

                    // Validacija
                    if (this.ddlJOPPDObrazac.Value == null)
                    {
                        this.ddlJOPPDObrazac.Focus();
                        throw new Exception(string.Format("Molimo, odaberite postojeći JOPPD obrazac za kojega želite kreirati {0}.",
                            (vrstaIzvjescaSifra == (decimal)VrstaIzvjesca.Ispravak ? "ispravak" : "dopunu")));
                    }

                    // ID postojećeg izvještaja
                    // NAPOMENA: uzimamo ID jer šifri može biti više identičnih!!
                    int joppdaID = (int)this.ddlJOPPDObrazac.Value;
                    id_joppda = joppdaID;

                    // Fetching podataka sa odabranog izvješća
                    System.Data.DataRow joppdaRow = element.GetJOPPDAByID(joppdaID);

                    // podaci za kasniji INSERT
                    oznakaIzvjescaDatum = (DateTime)joppdaRow["OznakaIzvjescaDatum"];
                    //obracunID = joppdaRow["ObracunID"] != DBNull.Value ? joppdaRow["ObracunID"].ToString() : null;


                    id_vrsta = VratiOznakuPodnositelja(joppdaID);

                }

                // Validacija
                if (element.GetJOPPDAProvjeraByID(vrstaIzvjescaID, oznakaIzvjescaDatum.ToString("yyyy.MM.dd"), (int)uceOznakaPodnositelja.Value) > 0)
                {
                    throw new Exception(string.Format("GREŠKA: JOPPD obrazac na dan '{0}' sa vrstom '{1} - {2}' i oznakom podnositelja {3} već postoji!",
                        oznakaIzvjescaDatum.ToShortDateString(),
                        vrstaIzvjescaID,
                        ((VrstaIzvjesca)vrstaIzvjescaID).ToString().ToUpper(), uceOznakaPodnositelja.Value.ToString()));
                }

                // INSERTIRANJE novog obrasca
                JOPPDID = element.InsertJOPPDA(oznakaIzvjescaDatum, vrstaIzvjescaID, id_vrsta);
                //insertitanje svih obracuna za joppda
                if (ISObracunPlace == true)
                {
                    foreach (string obracun in obracuni)
                    {
                        element.InsertJOPPDAObracun((int)JOPPDID, obracun, oznaka_place);
                    }
                }
                if (ISObracunPutniNalog == true)
                {
                    foreach (string nalog in putni_nalog)
                    {
                        element.InsertJOPPDAObracun((int)JOPPDID, nalog, oznaka_putni_nalog);
                    }
                }
                if (ISObracunHonorara == true)
                {
                    foreach (string hon in honorari)
                    {
                        element.InsertJOPPDAObracun((int)JOPPDID, hon, oznaka_honorari);
                    }
                }
                if (ISObracunPraksa == true)
                {
                    foreach (string pr in praksa)
                    {
                        element.InsertJOPPDAObracun((int)JOPPDID, pr, oznaka_praksa);
                    }
                }
                if (ISObracunRazno == true)
                {
                    foreach (string pr in obracuni_razno)
                    {
                        element.InsertJOPPDAObracun((int)JOPPDID, pr, oznaka_razno);
                    }
                }
                if (ISVirmaniInvalidi == true)
                {
                    foreach (string inv in virmani_invalidi)
                    {
                        element.InsertJOPPDAObracun((int)JOPPDID, inv, oznaka_invalidi);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška u kreiranju JOPPD obrasca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        private int VratiOznakuPodnositelja(int id)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            int oznaka = 0;
            try
            {
                oznaka = Convert.ToInt32(client.ExecuteScalar("Select OznakaPodnositelja From JOPPDA Where ID = '" + id + "'"));
            }
            catch
            {

            }

            return oznaka;
        }

        private void dtpJOPPDObrazacDatum_ValueChanged(object sender, EventArgs e)
        {
            DateTime joppdObrazacaDatum = (DateTime)this.dtpJOPPDObrazacDatum.Value;
            TimeSpan razlika = joppdObrazacaDatum - new DateTime(joppdObrazacaDatum.Year, 1, 1);

            string godina = joppdObrazacaDatum.Year.ToString().Substring(2, 2);
            int redniDan = razlika.Days + 1;

            // GG000
            this.lblOznakaIzvjesca.Text = string.Format("{0}{1}", godina, redniDan.ToString("000"));
        }

        private void ddlVrstaIzvjesca_ValueChanged(object sender, EventArgs e)
        {
            if ((this.ddlVrstaIzvjesca.Value.ToString() == "1") || (this.ddlVrstaIzvjesca.Value.ToString() == "4"))
            {
                this.gbx1.Visible = true;
            }
            else
            {
                this.gbx1.Visible = false;
            }
            
            this.groupBox2.Visible = !this.gbx1.Visible;

            if (this.gbx1.Visible)
                this.Height = 800;

            if (this.groupBox2.Visible)
                this.Height = 300;


            if (this.ddlVrstaIzvjesca.Value.ToString() == "3")
            {
                ugvDopuna.Visible = true;
            }
            else
            {
                ugvDopuna.Visible = false;
            }
        }

        private void btnOdustani_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            dtpJOPPDObrazacDatum.Select();
            if (KreirajJOPPDA())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cbkOznaciSvePutniNalog_CheckedChanged(object sender, EventArgs e)
        {
            if (((Control)(sender)).Name == "cbkOznaciSvePutniNalog")
            {
                foreach (UltraGridRow row in ugdPutniNalog.Rows)
                {
                    if (cbkOznaciSvePutniNalog.Checked)
                    {
                        row.Cells["Ozn"].Value = true;
                    }
                    else
                    {
                        row.Cells["Ozn"].Value = false;
                    }
                }
            }
            if (((Control)(sender)).Name == "cbkOznaciSvePraksa")
            {
                foreach (UltraGridRow row in ugdPraksa.Rows)
                {
                    if (cbkOznaciSvePraksa.Checked)
                    {
                        row.Cells["Ozn"].Value = true;
                    }
                    else
                    {
                        row.Cells["Ozn"].Value = false;
                    }
                }
            }
            if (((Control)(sender)).Name == "cbkObracuniRazno")
            {
                foreach (UltraGridRow row in ugdObracuniRazno.Rows)
                {
                    if (cbkObracuniRazno.Checked)
                    {
                        row.Cells["Ozn"].Value = true;
                    }
                    else
                    {
                        row.Cells["Ozn"].Value = false;
                    }
                }
            }
            if (((Control)(sender)).Name == "cbkOznaciSveDopuna")
            {
                foreach (UltraGridRow row in ugvDopuna.Rows)
                {
                    if (cbkOznaciSveDopuna.Checked)
                    {
                        row.Cells["Ozn"].Value = true;
                    }
                    else
                    {
                        row.Cells["Ozn"].Value = false;
                    }
                }
            }
        }

        private void ddlJOPPDObrazac_ValueChanged(object sender, EventArgs e)
        {
            if (ddlVrstaIzvjesca.Value.ToString() == "3")
            {
                NapuniRadnikeDopuna(element, ddlJOPPDObrazac.Value.ToString()); 
            }
        }
    }
}

