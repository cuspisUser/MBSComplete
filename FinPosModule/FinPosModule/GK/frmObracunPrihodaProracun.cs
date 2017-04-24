using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace FinPosModule.GK
{

    public class frmObracunPrihodaProracun : Form
    {
        private int analitika;
        private IContainer components;
        private string midkontoduguje;
        private string midkontopotrazuje;

        public frmObracunPrihodaProracun(string idkontoduguje, string idkontopotrazuje)
        {
            base.Load += new EventHandler(this.frmObracunPrihodaProracun_Load);
            this.midkontoduguje = idkontoduguje;
            this.midkontopotrazuje = idkontopotrazuje;
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DugovnaStrana()
        {
            if (Strings.Len(RuntimeHelpers.GetObjectValue(this.CmbDugovniKontoUltraCombo.SelectedRow.Cells["idkonto"].Value)) < this.analitika)
            {
                Interaction.MsgBox("Samo analitičkih konta dozvoljena - " + Conversions.ToString(this.analitika) + " i više znakova", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                this.Close();
            }
        }

        private void frmObracunPrihodaProracun_Load(object sender, EventArgs e)
        {
            IEnumerator enumerator = null;
            this.analitika = mipsed.application.framework.Application.Analitika();
            KONTODataSet dataSet = new KONTODataSet();
            new KONTODataAdapter().Fill(dataSet);
            try
            {
                enumerator = dataSet.KONTO.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if (current["idkonto"].ToString().Length >= this.analitika)
                    {
                        this.KontoDataSet1.KONTO.ImportRow(current);
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            InfraCustom.InicijalizirajCombo(this.CmbDugovniKontoUltraCombo, null);
            InfraCustom.InicijalizirajCombo(this.CmbPotrazniKontoUltraCombo, null);
            this.CmbDugovniKontoUltraCombo.Value = this.midkontoduguje;
            this.CmbPotrazniKontoUltraCombo.Value = this.midkontopotrazuje;
        }

        public object GetDugovniKonto()
        {
            if (this.CmbDugovniKontoUltraCombo.SelectedRow == null)
            {
                return null;
            }
            return RuntimeHelpers.GetObjectValue(this.CmbDugovniKontoUltraCombo.SelectedRow.Cells["IDKONTO"].Value);
        }

        public object GetPotrazniKonto()
        {
            if (this.CmbPotrazniKontoUltraCombo.SelectedRow == null)
            {
                return null;
            }
            return RuntimeHelpers.GetObjectValue(this.CmbPotrazniKontoUltraCombo.SelectedRow.Cells["IDKONTO"].Value);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObracunPrihodaProracun));
            this.SqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.SqlConnection2 = new System.Data.SqlClient.SqlConnection();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbDugovniKontoUltraCombo = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.CmbPotrazniKontoUltraCombo = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.UltraToolbarsManager2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._Form_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.CmbDugovniKontoUltraCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbPotrazniKontoUltraCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SqlConnection1
            // 
            this.SqlConnection1.ConnectionString = "Data Source=RAZVOJ;Initial Catalog=VGFIN2005;Integrated Security=True;Persist Sec" +
    "urity Info=False;Packet Size=4096;Workstation ID=RAZVOJ";
            this.SqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // SqlConnection2
            // 
            this.SqlConnection2.ConnectionString = "workstation id=RAZVOJ;packet size=4096;integrated security=SSPI;data source=RAZVO" +
    "J;persist security info=False;initial catalog=VGFIN2004";
            this.SqlConnection2.FireInfoMessageEventOnUserErrors = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Location = new System.Drawing.Point(34, 57);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(108, 17);
            this.Label3.TabIndex = 47;
            this.Label3.Text = "Konto potražuje";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(34, 23);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(92, 17);
            this.Label2.TabIndex = 46;
            this.Label2.Text = "Konto duguje";
            // 
            // CmbDugovniKontoUltraCombo
            // 
            appearance.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance;
            editorButton1.Text = "...";
            this.CmbDugovniKontoUltraCombo.ButtonsRight.Add(editorButton1);
            this.CmbDugovniKontoUltraCombo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CmbDugovniKontoUltraCombo.DataMember = "KONTO";
            this.CmbDugovniKontoUltraCombo.DataSource = this.KontoDataSet1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Appearance = appearance12;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.CmbDugovniKontoUltraCombo.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.CmbDugovniKontoUltraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance20.BorderColor = System.Drawing.SystemColors.Window;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.GroupByBox.Appearance = appearance20;
            appearance21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.GroupByBox.BandLabelAppearance = appearance21;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance22.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance22.BackColor2 = System.Drawing.SystemColors.Control;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.GroupByBox.PromptAppearance = appearance22;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.MaxColScrollRegions = 1;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.ActiveCellAppearance = appearance23;
            appearance24.BackColor = System.Drawing.SystemColors.Highlight;
            appearance24.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.ActiveRowAppearance = appearance24;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.CardAreaAppearance = appearance25;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            appearance26.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.CellAppearance = appearance26;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.CellPadding = 0;
            appearance2.BackColor = System.Drawing.SystemColors.Control;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.GroupByRowAppearance = appearance2;
            appearance3.TextHAlignAsString = "Left";
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.RowAppearance = appearance4;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.Override.TemplateAddRowAppearance = appearance5;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.CmbDugovniKontoUltraCombo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.CmbDugovniKontoUltraCombo.DisplayMember = "IDKONTO";
            this.CmbDugovniKontoUltraCombo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.CmbDugovniKontoUltraCombo.Location = new System.Drawing.Point(146, 17);
            this.CmbDugovniKontoUltraCombo.Name = "CmbDugovniKontoUltraCombo";
            this.CmbDugovniKontoUltraCombo.Size = new System.Drawing.Size(184, 25);
            this.CmbDugovniKontoUltraCombo.TabIndex = 0;
            this.CmbDugovniKontoUltraCombo.Tag = "NR";
            this.CmbDugovniKontoUltraCombo.ValueMember = "IDKONTO";
            // 
            // KontoDataSet1
            // 
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            this.KontoDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // CmbPotrazniKontoUltraCombo
            // 
            appearance6.TextHAlignAsString = "Center";
            editorButton2.Appearance = appearance6;
            editorButton2.Text = "...";
            this.CmbPotrazniKontoUltraCombo.ButtonsRight.Add(editorButton2);
            this.CmbPotrazniKontoUltraCombo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CmbPotrazniKontoUltraCombo.DataMember = "KONTO";
            this.CmbPotrazniKontoUltraCombo.DataSource = this.KontoDataSet1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Appearance = appearance7;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 1;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 3;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.SystemColors.Window;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.GroupByBox.Appearance = appearance8;
            appearance9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.GroupByBox.BandLabelAppearance = appearance9;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance10.BackColor2 = System.Drawing.SystemColors.Control;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.GroupByBox.PromptAppearance = appearance10;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.MaxColScrollRegions = 1;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.ActiveCellAppearance = appearance11;
            appearance13.BackColor = System.Drawing.SystemColors.Highlight;
            appearance13.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.ActiveRowAppearance = appearance13;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.CardAreaAppearance = appearance14;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.CellAppearance = appearance15;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.CellPadding = 0;
            appearance16.BackColor = System.Drawing.SystemColors.Control;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.GroupByRowAppearance = appearance16;
            appearance17.TextHAlignAsString = "Left";
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.RowAppearance = appearance18;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance19.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.Override.TemplateAddRowAppearance = appearance19;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.CmbPotrazniKontoUltraCombo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.CmbPotrazniKontoUltraCombo.DisplayMember = "IDKONTO";
            this.CmbPotrazniKontoUltraCombo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.CmbPotrazniKontoUltraCombo.Location = new System.Drawing.Point(146, 51);
            this.CmbPotrazniKontoUltraCombo.Name = "CmbPotrazniKontoUltraCombo";
            this.CmbPotrazniKontoUltraCombo.Size = new System.Drawing.Size(184, 25);
            this.CmbPotrazniKontoUltraCombo.TabIndex = 1;
            this.CmbPotrazniKontoUltraCombo.Tag = "NR";
            this.CmbPotrazniKontoUltraCombo.ValueMember = "IDKONTO";
            // 
            // UltraToolbarsManager2
            // 
            this.UltraToolbarsManager2.DesignerFlags = 1;
            // 
            // _Form_Toolbars_Dock_Area_Top
            // 
            this._Form_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Floating;
            this._Form_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form_Toolbars_Dock_Area_Top.Name = "_Form_Toolbars_Dock_Area_Top";
            this._Form_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(582, 125);
            // 
            // _Form_Toolbars_Dock_Area_Bottom
            // 
            this._Form_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Floating;
            this._Form_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 0);
            this._Form_Toolbars_Dock_Area_Bottom.Name = "_Form_Toolbars_Dock_Area_Bottom";
            this._Form_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(582, 125);
            // 
            // _Form_Toolbars_Dock_Area_Left
            // 
            this._Form_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent;
            this._Form_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Floating;
            this._Form_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.Color.Transparent;
            this._Form_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._Form_Toolbars_Dock_Area_Left.Name = "_Form_Toolbars_Dock_Area_Left";
            this._Form_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(582, 125);
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.Location = new System.Drawing.Point(479, 89);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(90, 26);
            this.UltraButton1.TabIndex = 52;
            this.UltraButton1.Text = "Spremi";
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // UltraButton2
            // 
            this.UltraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ButtonSoftExtended;
            this.UltraButton2.Location = new System.Drawing.Point(590, 89);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(90, 26);
            this.UltraButton2.TabIndex = 53;
            this.UltraButton2.Text = "Odustani";
            this.UltraButton2.Click += new System.EventHandler(this.UltraButton2_Click);
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.UltraButton2);
            this.UltraGroupBox1.Controls.Add(this.CmbDugovniKontoUltraCombo);
            this.UltraGroupBox1.Controls.Add(this.UltraButton1);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.CmbPotrazniKontoUltraCombo);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(582, 125);
            this.UltraGroupBox1.TabIndex = 57;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // frmObracunPrihodaProracun
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(582, 125);
            this.Controls.Add(this.UltraGroupBox1);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._Form_Toolbars_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObracunPrihodaProracun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obračun prihoda kod plaćene IRE";
            ((System.ComponentModel.ISupportInitialize)(this.CmbDugovniKontoUltraCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbPotrazniKontoUltraCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void PotraznaStrana()
        {
            if (this.CmbPotrazniKontoUltraCombo.SelectedRow != null)
            {
                if (Strings.Len(RuntimeHelpers.GetObjectValue(this.CmbPotrazniKontoUltraCombo.SelectedRow.Cells["idkonto"].Value)) < this.analitika)
                {
                    Interaction.MsgBox("Samo analitičkih konta dozvoljena - " + Conversions.ToString(this.analitika) + " i više znakova", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    this.Close();
                }
            }
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
                this.CmbDugovniKontoUltraCombo.SelectedRow = null;
                this.CmbPotrazniKontoUltraCombo.SelectedRow = null;
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void SetDugovniKonto(object Value)
        {
            this.SetDugovniKonto(RuntimeHelpers.GetObjectValue(Value));
        }

        public void SetPotrazniKonto(object Value)
        {
            this.SetPotrazniKonto(RuntimeHelpers.GetObjectValue(Value));
        }

        public void Spremi()
        {
            this.DugovnaStrana();
            this.PotraznaStrana();
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.Spremi();
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            this.CmbDugovniKontoUltraCombo.SelectedRow = null;
            this.CmbPotrazniKontoUltraCombo.SelectedRow = null;
            this.Close();
        }

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Bottom;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Left;

        private UltraToolbarsDockArea _Form_Toolbars_Dock_Area_Top;

        private UltraCombo CmbDugovniKontoUltraCombo;

        private UltraCombo CmbPotrazniKontoUltraCombo;

        private KONTODataSet KontoDataSet1;

        private Label Label2;

        private Label Label3;

        private SqlConnection SqlConnection1;

        private SqlConnection SqlConnection2;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraGroupBox UltraGroupBox1;

        private UltraToolbarsManager UltraToolbarsManager2;
    }
}

