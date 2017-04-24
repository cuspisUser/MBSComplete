using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SmartPart]
public class IspisZaposlenika : UserControl
{
    private SqlConnection cnn;
    private IContainer components;
    private ReportDocument rptPopisRadnika;

    public IspisZaposlenika()
    {
        base.Load += new EventHandler(this.frmIspisRadnik_Load);
        this.cnn = new SqlConnection();
        this.rptPopisRadnika = new ReportDocument();
        this.InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.Ispis();
        this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        this.IspisImePrezime();
        this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmIspisRadnik_Load(object sender, EventArgs e)
    {
        this.SqlConnection1.ConnectionString = Configuration.ConnectionString;
        this.daSortSifra.SelectCommand.Connection = this.cnn;
        this.daSortPrezime.SelectCommand.Connection = this.cnn;
        this.PodaciORadnicima_Load();
        this.obracunstazaNaDan.Value = DateAndTime.Today;
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IspisZaposlenika));
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SPOJENOPREZIME");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SPOJENOPREZIME");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.daSortSifra = new System.Data.SqlClient.SqlDataAdapter();
            this.SqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.SqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.SqlConnection3 = new System.Data.SqlClient.SqlConnection();
            this.SqlConnection2 = new System.Data.SqlClient.SqlConnection();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.doradnika = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.PregledRadnikaDataSet1 = new Placa.PregledRadnikaDataSet();
            this.lblDoRadnika = new Infragistics.Win.Misc.UltraLabel();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblOdRadnika = new Infragistics.Win.Misc.UltraLabel();
            this.odradnika = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.Label1 = new System.Windows.Forms.Label();
            this.obracunstazaNaDan = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Label13 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.neaktivni = new System.Windows.Forms.CheckBox();
            this.aktivni = new System.Windows.Forms.CheckBox();
            this.chkPrezime = new System.Windows.Forms.CheckBox();
            this.daSortPrezime = new System.Data.SqlClient.SqlDataAdapter();
            this.SqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.SqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.DsIspisRadnik1 = new dsIspisRadnik();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doradnika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odradnika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obracunstazaNaDan)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DsIspisRadnik1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList2
            // 
            this.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // daSortSifra
            // 
            this.daSortSifra.InsertCommand = this.SqlInsertCommand1;
            this.daSortSifra.SelectCommand = this.SqlSelectCommand1;
            this.daSortSifra.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "V_OD_MATICNI_PODACI_RADNIKA", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDRADNIK", "IDRADNIK"),
                        new System.Data.Common.DataColumnMapping("PREZIME", "PREZIME"),
                        new System.Data.Common.DataColumnMapping("IME", "IME"),
                        new System.Data.Common.DataColumnMapping("OPCINARADAIDOPCINE", "OPCINARADAIDOPCINE"),
                        new System.Data.Common.DataColumnMapping("OPCINASTANOVANJAIDOPCINE", "OPCINASTANOVANJAIDOPCINE"),
                        new System.Data.Common.DataColumnMapping("NAZIVBANKE1", "NAZIVBANKE1"),
                        new System.Data.Common.DataColumnMapping("TEKUCI", "TEKUCI"),
                        new System.Data.Common.DataColumnMapping("FAKTOROSOBNOGODBITKASUMARNO", "FAKTOROSOBNOGODBITKASUMARNO"),
                        new System.Data.Common.DataColumnMapping("TJEDNIFONDSATI", "TJEDNIFONDSATI"),
                        new System.Data.Common.DataColumnMapping("KOEFICIJENT", "KOEFICIJENT"),
                        new System.Data.Common.DataColumnMapping("GODINESTAZA", "GODINESTAZA"),
                        new System.Data.Common.DataColumnMapping("MJESECISTAZA", "MJESECISTAZA"),
                        new System.Data.Common.DataColumnMapping("DANISTAZA", "DANISTAZA"),
                        new System.Data.Common.DataColumnMapping("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"),
                        new System.Data.Common.DataColumnMapping("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"),
                        new System.Data.Common.DataColumnMapping("NAZIVSKUPPOREZAIDOPRINOSA", "NAZIVSKUPPOREZAIDOPRINOSA"),
                        new System.Data.Common.DataColumnMapping("JMBG", "JMBG"),
                        new System.Data.Common.DataColumnMapping("POSTOTAKOSLOBODJENJAODPOREZA", "POSTOTAKOSLOBODJENJAODPOREZA"),
                        new System.Data.Common.DataColumnMapping("TJEDNIFONDSATISTAZ", "TJEDNIFONDSATISTAZ"),
                        new System.Data.Common.DataColumnMapping("BROJPRIZNATIHMJESECI", "BROJPRIZNATIHMJESECI"),
                        new System.Data.Common.DataColumnMapping("AKTIVAN", "AKTIVAN"),
                        new System.Data.Common.DataColumnMapping("ZBIRNINETO", "ZBIRNINETO")})});
            // 
            // SqlInsertCommand1
            // 
            this.SqlInsertCommand1.CommandText = resources.GetString("SqlInsertCommand1.CommandText");
            this.SqlInsertCommand1.Connection = this.SqlConnection1;
            this.SqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@IDRADNIK", System.Data.SqlDbType.Int, 4, "IDRADNIK"),
            new System.Data.SqlClient.SqlParameter("@PREZIME", System.Data.SqlDbType.NVarChar, 100, "PREZIME"),
            new System.Data.SqlClient.SqlParameter("@IME", System.Data.SqlDbType.NVarChar, 50, "IME"),
            new System.Data.SqlClient.SqlParameter("@OPCINARADAIDOPCINE", System.Data.SqlDbType.NVarChar, 4, "OPCINARADAIDOPCINE"),
            new System.Data.SqlClient.SqlParameter("@OPCINASTANOVANJAIDOPCINE", System.Data.SqlDbType.NVarChar, 4, "OPCINASTANOVANJAIDOPCINE"),
            new System.Data.SqlClient.SqlParameter("@NAZIVBANKE1", System.Data.SqlDbType.NVarChar, 20, "NAZIVBANKE1"),
            new System.Data.SqlClient.SqlParameter("@TEKUCI", System.Data.SqlDbType.NVarChar, 10, "TEKUCI"),
            new System.Data.SqlClient.SqlParameter("@FAKTOROSOBNOGODBITKASUMARNO", System.Data.SqlDbType.Money, 8, "FAKTOROSOBNOGODBITKASUMARNO"),
            new System.Data.SqlClient.SqlParameter("@TJEDNIFONDSATI", System.Data.SqlDbType.Money, 4, "TJEDNIFONDSATI"),
            new System.Data.SqlClient.SqlParameter("@KOEFICIJENT", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((byte)(17)), ((byte)(10)), "KOEFICIJENT", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@GODINESTAZA", System.Data.SqlDbType.SmallInt, 2, "GODINESTAZA"),
            new System.Data.SqlClient.SqlParameter("@MJESECISTAZA", System.Data.SqlDbType.SmallInt, 2, "MJESECISTAZA"),
            new System.Data.SqlClient.SqlParameter("@DANISTAZA", System.Data.SqlDbType.SmallInt, 2, "DANISTAZA"),
            new System.Data.SqlClient.SqlParameter("@DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", System.Data.SqlDbType.DateTime, 8, "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"),
            new System.Data.SqlClient.SqlParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", System.Data.SqlDbType.Int, 4, "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"),
            new System.Data.SqlClient.SqlParameter("@NAZIVSKUPPOREZAIDOPRINOSA", System.Data.SqlDbType.NVarChar, 100, "NAZIVSKUPPOREZAIDOPRINOSA"),
            new System.Data.SqlClient.SqlParameter("@JMBG", System.Data.SqlDbType.NVarChar, 13, "JMBG"),
            new System.Data.SqlClient.SqlParameter("@POSTOTAKOSLOBODJENJAODPOREZA", System.Data.SqlDbType.Money, 4, "POSTOTAKOSLOBODJENJAODPOREZA"),
            new System.Data.SqlClient.SqlParameter("@TJEDNIFONDSATISTAZ", System.Data.SqlDbType.Money, 4, "TJEDNIFONDSATISTAZ"),
            new System.Data.SqlClient.SqlParameter("@BROJPRIZNATIHMJESECI", System.Data.SqlDbType.SmallInt, 2, "BROJPRIZNATIHMJESECI"),
            new System.Data.SqlClient.SqlParameter("@AKTIVAN", System.Data.SqlDbType.Bit, 1, "AKTIVAN"),
            new System.Data.SqlClient.SqlParameter("@ZBIRNINETO", System.Data.SqlDbType.Bit, 1, "ZBIRNINETO")});
            // 
            // SqlConnection1
            // 
            this.SqlConnection1.ConnectionString = "workstation id=-vuger;packet size=4096;integrated security=SSPI;data source=sreck" +
    "o\\sqlexpress;persist security info=False;initial catalog=rudes";
            this.SqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // SqlSelectCommand1
            // 
            this.SqlSelectCommand1.CommandText = resources.GetString("SqlSelectCommand1.CommandText");
            this.SqlSelectCommand1.Connection = this.SqlConnection3;
            this.SqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@odradnika", System.Data.SqlDbType.Int, 4, "IDRADNIK"),
            new System.Data.SqlClient.SqlParameter("@doradnika", System.Data.SqlDbType.Int, 4, "IDRADNIK"),
            new System.Data.SqlClient.SqlParameter("@aktivan", System.Data.SqlDbType.Bit, 1, "AKTIVAN")});
            // 
            // SqlConnection3
            // 
            this.SqlConnection3.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=RUDES;Integrated Security=True";
            this.SqlConnection3.FireInfoMessageEventOnUserErrors = false;
            // 
            // SqlConnection2
            // 
            this.SqlConnection2.ConnectionString = "workstation id=-RAZVOJ;packet size=4096;integrated security=SSPI;data source=srec" +
    "ko\\sqlexpress;persist security info=False;initial catalog=novaplaca";
            this.SqlConnection2.FireInfoMessageEventOnUserErrors = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.doradnika);
            this.GroupBox1.Controls.Add(this.lblDoRadnika);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.lblOdRadnika);
            this.GroupBox1.Controls.Add(this.odradnika);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GroupBox1.Location = new System.Drawing.Point(4, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(679, 68);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Zaposlenici";
            // 
            // doradnika
            // 
            appearance21.TextHAlignAsString = "Center";
            this.doradnika.ButtonAppearance = appearance21;
            appearance25.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance25;
            editorButton1.Text = "...";
            this.doradnika.ButtonsRight.Add(editorButton1);
            this.doradnika.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.doradnika.DataMember = "RADNIK";
            this.doradnika.DataSource = this.PregledRadnikaDataSet1;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.doradnika.DisplayLayout.Appearance = appearance26;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Width = 60;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(165, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Width = 150;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(150, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Width = 150;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            this.doradnika.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.doradnika.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.doradnika.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance27.BorderColor = System.Drawing.SystemColors.Window;
            this.doradnika.DisplayLayout.GroupByBox.Appearance = appearance27;
            appearance28.ForeColor = System.Drawing.SystemColors.GrayText;
            this.doradnika.DisplayLayout.GroupByBox.BandLabelAppearance = appearance28;
            this.doradnika.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance29.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance29.BackColor2 = System.Drawing.SystemColors.Control;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance29.ForeColor = System.Drawing.SystemColors.GrayText;
            this.doradnika.DisplayLayout.GroupByBox.PromptAppearance = appearance29;
            this.doradnika.DisplayLayout.MaxColScrollRegions = 1;
            this.doradnika.DisplayLayout.MaxRowScrollRegions = 1;
            appearance30.BackColor = System.Drawing.SystemColors.Window;
            appearance30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.doradnika.DisplayLayout.Override.ActiveCellAppearance = appearance30;
            appearance.BackColor = System.Drawing.SystemColors.Highlight;
            appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.doradnika.DisplayLayout.Override.ActiveRowAppearance = appearance;
            this.doradnika.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.doradnika.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            this.doradnika.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.doradnika.DisplayLayout.Override.CellAppearance = appearance3;
            this.doradnika.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.doradnika.DisplayLayout.Override.CellPadding = 0;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.doradnika.DisplayLayout.Override.GroupByRowAppearance = appearance4;
            appearance5.TextHAlignAsString = "Left";
            this.doradnika.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.doradnika.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.doradnika.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            this.doradnika.DisplayLayout.Override.RowAppearance = appearance6;
            this.doradnika.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.doradnika.DisplayLayout.Override.TemplateAddRowAppearance = appearance7;
            this.doradnika.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.doradnika.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.doradnika.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.doradnika.DisplayMember = "IDRADNIK";
            this.doradnika.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.doradnika.DropDownWidth = 400;
            this.doradnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.doradnika.Location = new System.Drawing.Point(119, 40);
            this.doradnika.MaxDropDownItems = 20;
            this.doradnika.Name = "doradnika";
            this.doradnika.Size = new System.Drawing.Size(102, 26);
            this.doradnika.TabIndex = 6;
            this.doradnika.ValueMember = "IDRADNIK";
            // 
            // PregledRadnikaDataSet1
            // 
            this.PregledRadnikaDataSet1.DataSetName = "PregledRadnikaDataSet";
            // 
            // lblDoRadnika
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.TextVAlignAsString = "Middle";
            this.lblDoRadnika.Appearance = appearance8;
            this.lblDoRadnika.BackColorInternal = System.Drawing.SystemColors.ControlLight;
            this.lblDoRadnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDoRadnika.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDoRadnika.Location = new System.Drawing.Point(227, 40);
            this.lblDoRadnika.Name = "lblDoRadnika";
            this.lblDoRadnika.Size = new System.Drawing.Size(288, 22);
            this.lblDoRadnika.TabIndex = 5;
            this.lblDoRadnika.Tag = "NAZIVELEMENT";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(105, 20);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Do zaposlenika:";
            // 
            // lblOdRadnika
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.TextVAlignAsString = "Middle";
            this.lblOdRadnika.Appearance = appearance9;
            this.lblOdRadnika.BackColorInternal = System.Drawing.SystemColors.ControlLight;
            this.lblOdRadnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblOdRadnika.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblOdRadnika.Location = new System.Drawing.Point(227, 14);
            this.lblOdRadnika.Name = "lblOdRadnika";
            this.lblOdRadnika.Size = new System.Drawing.Size(288, 22);
            this.lblOdRadnika.TabIndex = 2;
            this.lblOdRadnika.Tag = "NAZIVELEMENT";
            // 
            // odradnika
            // 
            appearance10.TextHAlignAsString = "Center";
            this.odradnika.ButtonAppearance = appearance10;
            appearance11.TextHAlignAsString = "Center";
            editorButton2.Appearance = appearance11;
            editorButton2.Text = "...";
            this.odradnika.ButtonsRight.Add(editorButton2);
            this.odradnika.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.odradnika.DataMember = "RADNIK";
            this.odradnika.DataSource = this.PregledRadnikaDataSet1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.odradnika.DisplayLayout.Appearance = appearance12;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.Width = 60;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 3;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 1;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(165, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.Width = 150;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 2;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(150, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.Width = 150;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 4;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 5;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 6;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14});
            this.odradnika.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.odradnika.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.odradnika.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.odradnika.DisplayLayout.GroupByBox.Appearance = appearance13;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.odradnika.DisplayLayout.GroupByBox.BandLabelAppearance = appearance14;
            this.odradnika.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.odradnika.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.odradnika.DisplayLayout.MaxColScrollRegions = 1;
            this.odradnika.DisplayLayout.MaxRowScrollRegions = 1;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.odradnika.DisplayLayout.Override.ActiveCellAppearance = appearance16;
            appearance17.BackColor = System.Drawing.SystemColors.Highlight;
            appearance17.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.odradnika.DisplayLayout.Override.ActiveRowAppearance = appearance17;
            this.odradnika.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.odradnika.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            this.odradnika.DisplayLayout.Override.CardAreaAppearance = appearance18;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.odradnika.DisplayLayout.Override.CellAppearance = appearance19;
            this.odradnika.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.odradnika.DisplayLayout.Override.CellPadding = 0;
            appearance20.BackColor = System.Drawing.SystemColors.Control;
            appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance20.BorderColor = System.Drawing.SystemColors.Window;
            this.odradnika.DisplayLayout.Override.GroupByRowAppearance = appearance20;
            appearance22.TextHAlignAsString = "Left";
            this.odradnika.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.odradnika.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.odradnika.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.odradnika.DisplayLayout.Override.RowAppearance = appearance23;
            this.odradnika.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.odradnika.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.odradnika.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.odradnika.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.odradnika.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.odradnika.DisplayMember = "IDRADNIK";
            this.odradnika.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.odradnika.DropDownWidth = 400;
            this.odradnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.odradnika.Location = new System.Drawing.Point(119, 14);
            this.odradnika.MaxDropDownItems = 20;
            this.odradnika.Name = "odradnika";
            this.odradnika.Size = new System.Drawing.Size(102, 26);
            this.odradnika.TabIndex = 1;
            this.odradnika.ValueMember = "IDRADNIK";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(105, 20);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Od zaposlenika:";
            // 
            // obracunstazaNaDan
            // 
            this.obracunstazaNaDan.DateTime = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.obracunstazaNaDan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.obracunstazaNaDan.Location = new System.Drawing.Point(136, 16);
            this.obracunstazaNaDan.Name = "obracunstazaNaDan";
            this.obracunstazaNaDan.Nullable = false;
            this.obracunstazaNaDan.PromptChar = ' ';
            this.obracunstazaNaDan.Size = new System.Drawing.Size(90, 25);
            this.obracunstazaNaDan.TabIndex = 22;
            this.obracunstazaNaDan.Value = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label13.Location = new System.Drawing.Point(8, 16);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(132, 20);
            this.Label13.TabIndex = 21;
            this.Label13.Text = "Datum obračuna staža:";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.obracunstazaNaDan);
            this.GroupBox2.Controls.Add(this.Label13);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GroupBox2.Location = new System.Drawing.Point(4, 83);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(679, 42);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Staž";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.neaktivni);
            this.GroupBox3.Controls.Add(this.aktivni);
            this.GroupBox3.Controls.Add(this.chkPrezime);
            this.GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GroupBox3.Location = new System.Drawing.Point(4, 131);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(679, 46);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Ostali uvjeti";
            // 
            // neaktivni
            // 
            this.neaktivni.Location = new System.Drawing.Point(88, 19);
            this.neaktivni.Name = "neaktivni";
            this.neaktivni.Size = new System.Drawing.Size(80, 24);
            this.neaktivni.TabIndex = 1;
            this.neaktivni.Text = "neaktivni";
            // 
            // aktivni
            // 
            this.aktivni.Checked = true;
            this.aktivni.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aktivni.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.aktivni.Location = new System.Drawing.Point(11, 19);
            this.aktivni.Name = "aktivni";
            this.aktivni.Size = new System.Drawing.Size(71, 24);
            this.aktivni.TabIndex = 0;
            this.aktivni.Text = "aktivni";
            // 
            // chkPrezime
            // 
            this.chkPrezime.Location = new System.Drawing.Point(191, 19);
            this.chkPrezime.Name = "chkPrezime";
            this.chkPrezime.Size = new System.Drawing.Size(184, 24);
            this.chkPrezime.TabIndex = 7;
            this.chkPrezime.Text = "redoslijed abeceda";
            this.chkPrezime.CheckedChanged += new System.EventHandler(this.chkPrezime_CheckedChanged);
            // 
            // daSortPrezime
            // 
            this.daSortPrezime.InsertCommand = this.SqlCommand1;
            this.daSortPrezime.SelectCommand = this.SqlCommand2;
            this.daSortPrezime.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "V_OD_MATICNI_PODACI_RADNIKA", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDRADNIK", "IDRADNIK"),
                        new System.Data.Common.DataColumnMapping("PREZIME", "PREZIME"),
                        new System.Data.Common.DataColumnMapping("IME", "IME"),
                        new System.Data.Common.DataColumnMapping("OPCINARADAIDOPCINE", "OPCINARADAIDOPCINE"),
                        new System.Data.Common.DataColumnMapping("OPCINASTANOVANJAIDOPCINE", "OPCINASTANOVANJAIDOPCINE"),
                        new System.Data.Common.DataColumnMapping("NAZIVBANKE1", "NAZIVBANKE1"),
                        new System.Data.Common.DataColumnMapping("TEKUCI", "TEKUCI"),
                        new System.Data.Common.DataColumnMapping("FAKTOROSOBNOGODBITKASUMARNO", "FAKTOROSOBNOGODBITKASUMARNO"),
                        new System.Data.Common.DataColumnMapping("TJEDNIFONDSATI", "TJEDNIFONDSATI"),
                        new System.Data.Common.DataColumnMapping("KOEFICIJENT", "KOEFICIJENT"),
                        new System.Data.Common.DataColumnMapping("GODINESTAZA", "GODINESTAZA"),
                        new System.Data.Common.DataColumnMapping("MJESECISTAZA", "MJESECISTAZA"),
                        new System.Data.Common.DataColumnMapping("DANISTAZA", "DANISTAZA"),
                        new System.Data.Common.DataColumnMapping("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"),
                        new System.Data.Common.DataColumnMapping("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"),
                        new System.Data.Common.DataColumnMapping("NAZIVSKUPPOREZAIDOPRINOSA", "NAZIVSKUPPOREZAIDOPRINOSA"),
                        new System.Data.Common.DataColumnMapping("JMBG", "JMBG"),
                        new System.Data.Common.DataColumnMapping("POSTOTAKOSLOBODJENJAODPOREZA", "POSTOTAKOSLOBODJENJAODPOREZA"),
                        new System.Data.Common.DataColumnMapping("TJEDNIFONDSATISTAZ", "TJEDNIFONDSATISTAZ"),
                        new System.Data.Common.DataColumnMapping("BROJPRIZNATIHMJESECI", "BROJPRIZNATIHMJESECI"),
                        new System.Data.Common.DataColumnMapping("AKTIVAN", "AKTIVAN"),
                        new System.Data.Common.DataColumnMapping("ZBIRNINETO", "ZBIRNINETO")})});
            // 
            // SqlCommand1
            // 
            this.SqlCommand1.CommandText = resources.GetString("SqlCommand1.CommandText");
            this.SqlCommand1.Connection = this.SqlConnection1;
            this.SqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@IDRADNIK", System.Data.SqlDbType.Int, 4, "IDRADNIK"),
            new System.Data.SqlClient.SqlParameter("@PREZIME", System.Data.SqlDbType.NVarChar, 100, "PREZIME"),
            new System.Data.SqlClient.SqlParameter("@IME", System.Data.SqlDbType.NVarChar, 50, "IME"),
            new System.Data.SqlClient.SqlParameter("@OPCINARADAIDOPCINE", System.Data.SqlDbType.NVarChar, 4, "OPCINARADAIDOPCINE"),
            new System.Data.SqlClient.SqlParameter("@OPCINASTANOVANJAIDOPCINE", System.Data.SqlDbType.NVarChar, 4, "OPCINASTANOVANJAIDOPCINE"),
            new System.Data.SqlClient.SqlParameter("@NAZIVBANKE1", System.Data.SqlDbType.NVarChar, 20, "NAZIVBANKE1"),
            new System.Data.SqlClient.SqlParameter("@TEKUCI", System.Data.SqlDbType.NVarChar, 10, "TEKUCI"),
            new System.Data.SqlClient.SqlParameter("@FAKTOROSOBNOGODBITKASUMARNO", System.Data.SqlDbType.Money, 8, "FAKTOROSOBNOGODBITKASUMARNO"),
            new System.Data.SqlClient.SqlParameter("@TJEDNIFONDSATI", System.Data.SqlDbType.Money, 4, "TJEDNIFONDSATI"),
            new System.Data.SqlClient.SqlParameter("@KOEFICIJENT", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((byte)(17)), ((byte)(10)), "KOEFICIJENT", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@GODINESTAZA", System.Data.SqlDbType.SmallInt, 2, "GODINESTAZA"),
            new System.Data.SqlClient.SqlParameter("@MJESECISTAZA", System.Data.SqlDbType.SmallInt, 2, "MJESECISTAZA"),
            new System.Data.SqlClient.SqlParameter("@DANISTAZA", System.Data.SqlDbType.SmallInt, 2, "DANISTAZA"),
            new System.Data.SqlClient.SqlParameter("@DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", System.Data.SqlDbType.DateTime, 8, "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"),
            new System.Data.SqlClient.SqlParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", System.Data.SqlDbType.Int, 4, "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"),
            new System.Data.SqlClient.SqlParameter("@NAZIVSKUPPOREZAIDOPRINOSA", System.Data.SqlDbType.NVarChar, 100, "NAZIVSKUPPOREZAIDOPRINOSA"),
            new System.Data.SqlClient.SqlParameter("@JMBG", System.Data.SqlDbType.NVarChar, 13, "JMBG"),
            new System.Data.SqlClient.SqlParameter("@POSTOTAKOSLOBODJENJAODPOREZA", System.Data.SqlDbType.Money, 4, "POSTOTAKOSLOBODJENJAODPOREZA"),
            new System.Data.SqlClient.SqlParameter("@TJEDNIFONDSATISTAZ", System.Data.SqlDbType.Money, 4, "TJEDNIFONDSATISTAZ"),
            new System.Data.SqlClient.SqlParameter("@BROJPRIZNATIHMJESECI", System.Data.SqlDbType.SmallInt, 2, "BROJPRIZNATIHMJESECI"),
            new System.Data.SqlClient.SqlParameter("@AKTIVAN", System.Data.SqlDbType.Bit, 1, "AKTIVAN"),
            new System.Data.SqlClient.SqlParameter("@ZBIRNINETO", System.Data.SqlDbType.Bit, 1, "ZBIRNINETO")});
            // 
            // SqlCommand2
            // 
            this.SqlCommand2.CommandText = resources.GetString("SqlCommand2.CommandText");
            this.SqlCommand2.Connection = this.SqlConnection1;
            this.SqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@odradnika", System.Data.SqlDbType.Int, 4, "IDRADNIK"),
            new System.Data.SqlClient.SqlParameter("@doradnika", System.Data.SqlDbType.Int, 4, "IDRADNIK"),
            new System.Data.SqlClient.SqlParameter("@aktivan", System.Data.SqlDbType.Bit, 1, "AKTIVAN")});
            // 
            // DsIspisRadnik1
            // 
            this.DsIspisRadnik1.DataSetName = "dsIspisRadnik";
            this.DsIspisRadnik1.Locale = new System.Globalization.CultureInfo("hr-HR");
            this.DsIspisRadnik1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(507, 198);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 3;
            this.Button1.Text = "Potvrdi";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(596, 198);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 4;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(296, 198);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(189, 23);
            this.Button3.TabIndex = 5;
            this.Button3.Text = "Ispis samo imena i prezimena";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // IspisZaposlenika
            // 
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "IspisZaposlenika";
            this.Size = new System.Drawing.Size(683, 229);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doradnika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odradnika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obracunstazaNaDan)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DsIspisRadnik1)).EndInit();
            this.ResumeLayout(false);

    }

    public void Ispis()
    {
        this.rptPopisRadnika.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPopisZaposlenika.rpt");
        this.Cursor = Cursors.WaitCursor;
        try
        {
            this.DsIspisRadnik1.Clear();
            string str = "";
            if (this.odradnika.Text.Trim() != "")
            {
                this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value = this.odradnika.Text;
                this.daSortPrezime.SelectCommand.Parameters["@odradnika"].Value = this.odradnika.Text;
            }
            else
            {
                this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value = DBNull.Value;
                this.daSortPrezime.SelectCommand.Parameters["@odradnika"].Value = DBNull.Value;
            }
            if (this.doradnika.Text.Trim() != "")
            {
                this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value = this.doradnika.Text;
                this.daSortPrezime.SelectCommand.Parameters["@doradnika"].Value = this.doradnika.Text;
            }
            else
            {
                this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value = DBNull.Value;
                this.daSortPrezime.SelectCommand.Parameters["@doradnika"].Value = DBNull.Value;
            }
            if (this.aktivni.Checked & !this.neaktivni.Checked)
            {
                this.daSortSifra.SelectCommand.Parameters["@aktivan"].Value = 1;
                this.daSortPrezime.SelectCommand.Parameters["@aktivan"].Value = 1;
            }
            else if (!this.aktivni.Checked & this.neaktivni.Checked)
            {
                this.daSortSifra.SelectCommand.Parameters["@aktivan"].Value = 0;
                this.daSortPrezime.SelectCommand.Parameters["@aktivan"].Value = 0;
            }
            else if (this.aktivni.Checked & this.neaktivni.Checked)
            {
                this.daSortSifra.SelectCommand.Parameters["@aktivan"].Value = DBNull.Value;
                this.daSortPrezime.SelectCommand.Parameters["@aktivan"].Value = DBNull.Value;
            }
            else
            {
                this.aktivni.Focus();
                return;
            }
            this.daSortPrezime.SelectCommand.Connection = this.SqlConnection1;
            this.daSortSifra.SelectCommand.Connection = this.SqlConnection1;
            if (this.chkPrezime.Checked)
            {
                this.daSortPrezime.Fill(this.DsIspisRadnik1);
            }
            else
            {
                this.daSortSifra.Fill(this.DsIspisRadnik1);
            }
            if (this.DsIspisRadnik1.V_OD_MATICNI_PODACI_RADNIKA.Rows.Count == 0)
            {
                MessageBox.Show("Ni jedan od zadanih uvjeta nije zadovoljen!", "Ispis radnika", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.DsIspisRadnik1.V_OD_MATICNI_PODACI_RADNIKA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        int nUkupnoGodina = 0;
                        int nUkupnoMjeseci = 0;
                        int nUkupnoDana = 0;
                        int num4 = 0;
                        int num6 = 0;
                        int num2 = 0;
                        placa.UkupanRadniStaz(Conversions.ToInteger(current["GODINESTAZA"]), Conversions.ToInteger(current["MJESECISTAZA"]), Conversions.ToInteger(current["DANISTAZA"]), Conversions.ToDate(current["datumzadnjegzaposlenjapromjenefondasati"]), Conversions.ToDate(this.obracunstazaNaDan.Value), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToDecimal(Operators.DivideObject(current["BROJPRIZNATIHMJESECI"], 12)), ref nUkupnoGodina, ref nUkupnoMjeseci, ref nUkupnoDana);
                        placa.UkupanRadniStaz(Conversions.ToInteger(current["GODINESTAZAPRO"]), Conversions.ToInteger(current["MJESECISTAZAPRO"]), Conversions.ToInteger(current["DANISTAZAPRO"]), Conversions.ToDate(current["datumzadnjegzaposlenjapromjenefondasati"]), Conversions.ToDate(this.obracunstazaNaDan.Value), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToDecimal(Operators.DivideObject(current["BROJPRIZNATIHMJESECI"], 12)), ref num4, ref num6, ref num2);
                        current["GODINESTAZAUKUPNO"] = nUkupnoGodina;
                        current["MJESECISTAZAUKUPNO"] = nUkupnoMjeseci;
                        current["DANISTAZAUKUPNO"] = nUkupnoDana;
                        current["GODINEJUBILARNA"] = num4;
                        current["MJESECIJUBILARNA"] = num6;
                        current["DANIJUBILARNA"] = num2;
                        this.BindingContext[this.DsIspisRadnik1.V_OD_MATICNI_PODACI_RADNIKA].EndCurrentEdit();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if ((this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value == DBNull.Value) & (this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value == DBNull.Value))
                {
                    str = "Svi zaposlenici, ";
                }
                else if ((this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value != DBNull.Value) & (this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value == DBNull.Value))
                {
                    str = string.Format("Od  {0}", RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value));
                }
                else if ((this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value == DBNull.Value) & (this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value != DBNull.Value))
                {
                    str = string.Format("Do {0}, ", RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value));
                }
                else
                {
                    str = string.Format("Od {0} do  {1}, ", RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value), RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value));
                }
                if (this.aktivni.Checked & !this.neaktivni.Checked)
                {
                    str = str + "aktivni, ";
                }
                else if (!this.aktivni.Checked & this.neaktivni.Checked)
                {
                    str = str + "neaktivni, ";
                }
                else if (this.aktivni.Checked & this.neaktivni.Checked)
                {
                    str = str + "svi, ";
                }
                str = str + string.Format("Obračun staža na dan: {0}.", this.obracunstazaNaDan.Text);
                this.rptPopisRadnika.SetDataSource(this.DsIspisRadnik1);
                KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                adapter.Fill(dataSet);
                this.rptPopisRadnika.SetParameterValue("USTANOVA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                this.rptPopisRadnika.SetParameterValue("ADRESA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                this.rptPopisRadnika.SetParameterValue("ADRESA2", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                this.rptPopisRadnika.SetParameterValue("TELEFON", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                this.rptPopisRadnika.SetParameterValue("FAX", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
                this.rptPopisRadnika.SetParameterValue("uvjet", str);
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja -Popis zaposlenika",
                    Description = "Pregled izvještaja - Popis zaposlenika",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = this.rptPopisRadnika;
                item.Show(item.Workspaces["main"], info);
            }
        }
        catch (System.Exception exception1)
        {
            throw exception1;            
        }
        finally
        {
            this.Cursor = Cursors.Default;
        }
    }

    public void IspisImePrezime()
    {
        this.rptPopisRadnika.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPopis.rpt");
        this.Cursor = Cursors.WaitCursor;
        try
        {
            this.DsIspisRadnik1.Clear();
            string str = "";
            if (this.odradnika.Text.Trim() != "")
            {
                this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value = this.odradnika.Text;
                this.daSortPrezime.SelectCommand.Parameters["@odradnika"].Value = this.odradnika.Text;
            }
            else
            {
                this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value = DBNull.Value;
                this.daSortPrezime.SelectCommand.Parameters["@odradnika"].Value = DBNull.Value;
            }
            if (this.doradnika.Text.Trim() != "")
            {
                this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value = this.doradnika.Text;
                this.daSortPrezime.SelectCommand.Parameters["@doradnika"].Value = this.doradnika.Text;
            }
            else
            {
                this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value = DBNull.Value;
                this.daSortPrezime.SelectCommand.Parameters["@doradnika"].Value = DBNull.Value;
            }
            if (this.aktivni.Checked & !this.neaktivni.Checked)
            {
                this.daSortSifra.SelectCommand.Parameters["@aktivan"].Value = 1;
                this.daSortPrezime.SelectCommand.Parameters["@aktivan"].Value = 1;
            }
            else if (!this.aktivni.Checked & this.neaktivni.Checked)
            {
                this.daSortSifra.SelectCommand.Parameters["@aktivan"].Value = 0;
                this.daSortPrezime.SelectCommand.Parameters["@aktivan"].Value = 0;
            }
            else if (this.aktivni.Checked & this.neaktivni.Checked)
            {
                this.daSortSifra.SelectCommand.Parameters["@aktivan"].Value = DBNull.Value;
                this.daSortPrezime.SelectCommand.Parameters["@aktivan"].Value = DBNull.Value;
            }
            else
            {
                this.aktivni.Focus();
                return;
            }
            this.daSortPrezime.SelectCommand.Connection = this.SqlConnection1;
            this.daSortSifra.SelectCommand.Connection = this.SqlConnection1;
            if (this.chkPrezime.Checked)
            {
                this.daSortPrezime.Fill(this.DsIspisRadnik1);
            }
            else
            {
                this.daSortSifra.Fill(this.DsIspisRadnik1);
            }
            if (this.DsIspisRadnik1.V_OD_MATICNI_PODACI_RADNIKA.Rows.Count == 0)
            {
                MessageBox.Show("Ni jedan od zadanih uvjeta nije zadovoljen!", "Ispis radnika", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.DsIspisRadnik1.V_OD_MATICNI_PODACI_RADNIKA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        int nUkupnoGodina = 0;
                        int nUkupnoMjeseci = 0;
                        int nUkupnoDana = 0;
                        int num4 = 0;
                        int num6 = 0;
                        int num2 = 0;
                        placa.UkupanRadniStaz(Conversions.ToInteger(current["GODINESTAZA"]), Conversions.ToInteger(current["MJESECISTAZA"]), Conversions.ToInteger(current["DANISTAZA"]), Conversions.ToDate(current["datumzadnjegzaposlenjapromjenefondasati"]), Conversions.ToDate(this.obracunstazaNaDan.Value), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToDecimal(Operators.DivideObject(current["BROJPRIZNATIHMJESECI"], 12)), ref nUkupnoGodina, ref nUkupnoMjeseci, ref nUkupnoDana);
                        placa.UkupanRadniStaz(Conversions.ToInteger(current["GODINESTAZAPRO"]), Conversions.ToInteger(current["MJESECISTAZAPRO"]), Conversions.ToInteger(current["DANISTAZAPRO"]), Conversions.ToDate(current["datumzadnjegzaposlenjapromjenefondasati"]), Conversions.ToDate(this.obracunstazaNaDan.Value), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToInteger(current["tjednifondsatistaz"]), Conversions.ToDecimal(Operators.DivideObject(current["BROJPRIZNATIHMJESECI"], 12)), ref num4, ref num6, ref num2);
                        current["GODINESTAZAUKUPNO"] = nUkupnoGodina;
                        current["MJESECISTAZAUKUPNO"] = nUkupnoMjeseci;
                        current["DANISTAZAUKUPNO"] = nUkupnoDana;
                        current["GODINEJUBILARNA"] = num4;
                        current["MJESECIJUBILARNA"] = num6;
                        current["DANIJUBILARNA"] = num2;
                        this.BindingContext[this.DsIspisRadnik1.V_OD_MATICNI_PODACI_RADNIKA].EndCurrentEdit();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if ((this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value == DBNull.Value) & (this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value == DBNull.Value))
                {
                    str = "Svi zaposlenici, ";
                }
                else if ((this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value != DBNull.Value) & (this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value == DBNull.Value))
                {
                    str = string.Format("Od  {0}", RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value));
                }
                else if ((this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value == DBNull.Value) & (this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value != DBNull.Value))
                {
                    str = string.Format("Do {0}, ", RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value));
                }
                else
                {
                    str = string.Format("Od {0} do  {1}, ", RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@odradnika"].Value), RuntimeHelpers.GetObjectValue(this.daSortSifra.SelectCommand.Parameters["@doradnika"].Value));
                }
                if (this.aktivni.Checked & !this.neaktivni.Checked)
                {
                    str = str + "aktivni, ";
                }
                else if (!this.aktivni.Checked & this.neaktivni.Checked)
                {
                    str = str + "neaktivni, ";
                }
                else if (this.aktivni.Checked & this.neaktivni.Checked)
                {
                    str = str + "svi, ";
                }
                str = str + string.Format("Obračun staža na dan: {0}.", this.obracunstazaNaDan.Text);
                this.rptPopisRadnika.SetDataSource(this.DsIspisRadnik1);
                KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                adapter.Fill(dataSet);
                this.rptPopisRadnika.SetParameterValue("USTANOVA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                this.rptPopisRadnika.SetParameterValue("ADRESA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                this.rptPopisRadnika.SetParameterValue("ADRESA2", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                this.rptPopisRadnika.SetParameterValue("TELEFON", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                this.rptPopisRadnika.SetParameterValue("FAX", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
                this.rptPopisRadnika.SetParameterValue("uvjet", str);
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja -Popis zaposlenika",
                    Description = "Pregled izvještaja - Popis zaposlenika",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = this.rptPopisRadnika;
                item.Show(item.Workspaces["main"], info);
            }
        }
        catch (System.Exception exception1)
        {
            throw exception1;            
        }
        finally
        {
            this.Cursor = Cursors.Default;
        }
    }

    private void PodaciORadnicima_Load()
    {
        new PregledRadnikaDataAdapter().Fill(this.PregledRadnikaDataSet1);
    }

    private CheckBox aktivni;

    private Button Button1;

    private Button Button2;

    private Button Button3;

    private CheckBox chkPrezime;

    [CreateNew]
    public RSmObrazacController Controller { get; set; }

    private SqlDataAdapter daSortPrezime;

    private SqlDataAdapter daSortSifra;

    private UltraCombo doradnika;

    private dsIspisRadnik DsIspisRadnik1;

    private GroupBox GroupBox1;

    private GroupBox GroupBox2;

    private GroupBox GroupBox3;

    private ImageList ImageList2;

    private Label Label1;

    private Label Label13;

    private Label Label2;

    private UltraLabel lblDoRadnika;

    private UltraLabel lblOdRadnika;

    private CheckBox neaktivni;

    private UltraDateTimeEditor obracunstazaNaDan;

    private UltraCombo odradnika;

    private PregledRadnikaDataSet PregledRadnikaDataSet1;

    private SqlCommand SqlCommand1;

    private SqlCommand SqlCommand2;

    private SqlConnection SqlConnection1;

    private SqlConnection SqlConnection2;

    private SqlConnection SqlConnection3;

    private SqlCommand SqlInsertCommand1;

    private SqlCommand SqlSelectCommand1;

    private void chkPrezime_CheckedChanged(object sender, EventArgs e)
    {

    }
}

