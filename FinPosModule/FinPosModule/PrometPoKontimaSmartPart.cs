
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Evolve.Wpf.Samples;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;


namespace FinPosModule
{

    [SmartPart]
    public class PrometPoKontimaSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        
        private DateTime POCETNI;
        private ReportDocument rpt;
        private SmartPartInfo smartPartInfo1;
        private DateTime ZAVRSNI;

        public PrometPoKontimaSmartPart()
        {
            base.Load += new EventHandler(this.PrometPoKontimaSmartPart_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Izvještaji-GK-Promet po kontima", "Izvještaji-GK-Promet po kontima");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void BackgroundUpdate()
        {
            new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen, DialogText = "Pripremam izvještaj promet po kontima!", IsCancellingEnabled = false, AutoIncrementInterval = 150 }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelled));
        }

        private void cmboIDdok_BeforeDropDown(object sender, CancelEventArgs e)
        {
            DOKUMENTDataAdapter adapter = new DOKUMENTDataAdapter();
            if (this.DokumentDataSet1.DOKUMENT.Rows.Count == 0)
            {
                adapter.Fill(this.DokumentDataSet1);
            }
        }

        private void cmboIDkontopocetni_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.KontoDataSet1.KONTO.Rows.Count == 0)
            {
                new KONTODataAdapter().Fill(this.KontoDataSet1);
            }
        }

        private void cmboIDkontozavrsni_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.KontoDataSet1.KONTO.Rows.Count == 0)
            {
                new KONTODataAdapter().Fill(this.KontoDataSet1);
            }
        }

        private void cmboIDMT_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.MjestotroskaDataSet1.MJESTOTROSKA.Rows.Count == 0)
            {
                new MJESTOTROSKADataAdapter().Fill(this.MjestotroskaDataSet1);
            }
        }

        private void cmboIDOJ_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ORGJEDDataAdapter adapter = new ORGJEDDataAdapter();
            if (this.OrgjedDataSet1.ORGJED.Rows.Count == 0)
            {
                adapter.Fill(this.OrgjedDataSet1);
            }
        }

        private void CountUntilCancelled(object sender, DoWorkEventArgs e)
        {
            S_FIN_PROMET_PO_KONTIMADataAdapter adapter = new S_FIN_PROMET_PO_KONTIMADataAdapter();
            S_FIN_PROMET_PO_KONTIMADataSet dataSet = new S_FIN_PROMET_PO_KONTIMADataSet();
            try
            {
                int num = 0;
                int num4 = 0;
                int num6 = 0;
                string str2 = string.Empty;
                string str3 = string.Empty;
                if (!this.odDatuma.IsDateValid)
                {
                    this.odDatuma.Value = this.POCETNI;
                }
                if (!this.doDatuma.IsDateValid)
                {
                    this.doDatuma.Value = this.ZAVRSNI;
                }
                this.rpt = new ReportDocument();
                this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptPrometPoKontima.rpt");
                if (this.cmboIDOJ.SelectedRow != null)
                {
                    num6 = Conversions.ToInteger(this.cmboIDOJ.Value);
                }
                else
                {
                    num6 = -1;
                }
                if (this.cmboIDMT.SelectedRow != null)
                {
                    num4 = Conversions.ToInteger(this.cmboIDMT.Value);
                }
                else
                {
                    num4 = -1;
                }
                if (this.cmboIDdok.SelectedRow != null)
                {
                    num = Conversions.ToInteger(this.cmboIDdok.Value);
                }
                else
                {
                    num = -1;
                }
                DateTime rAZDOBLJEOD = Conversions.ToDate(this.odDatuma.Value);
                DateTime rAZDOBLJEDO = Conversions.ToDate(this.doDatuma.Value);
                if (this.cmboIDkontopocetni.SelectedRow != null)
                {
                    str2 = Conversions.ToString(this.cmboIDkontopocetni.Value);
                }
                else
                {
                    str2 = " ";
                }
                if (this.cmboIDkontozavrsni.SelectedRow != null)
                {
                    str3 = Conversions.ToString(this.cmboIDkontozavrsni.Value);
                }
                else
                {
                    str3 = " ";
                }
                try
                {
                    adapter.Fill(dataSet, num6, num4, num, rAZDOBLJEOD, rAZDOBLJEDO, str2, str3);
                }
                catch (SqlException exception1)
                {
                    throw exception1;
                    //SqlException exception = exception1;
                    
                    
                }
                this.rpt.SetDataSource(dataSet);
                this.rpt.SetParameterValue("POCETNI", RuntimeHelpers.GetObjectValue(this.odDatuma.Value));
                this.rpt.SetParameterValue("ZAVRSNI", RuntimeHelpers.GetObjectValue(this.doDatuma.Value));
                this.rpt.SetParameterValue("naslov", "Promet analitičkih konta glavne knjige ra razdoblje: " + Conversions.ToString(this.odDatuma.Value) + "-" + Conversions.ToString(this.doDatuma.Value));
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref this.rpt);
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Exception exception2 = exception3;
                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                
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

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            EditorButton button = new EditorButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("DOKUMENT", -1);
            UltraGridColumn column = new UltraGridColumn("IDDOKUMENT");
            UltraGridColumn column12 = new UltraGridColumn("NAZIVDOKUMENT");
            UltraGridColumn column15 = new UltraGridColumn("IDTIPDOKUMENTA");
            UltraGridColumn column16 = new UltraGridColumn("NAZIVTIPDOKUMENTA");
            UltraGridColumn column17 = new UltraGridColumn("PS");
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            EditorButton button2 = new EditorButton();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            UltraGridBand band2 = new UltraGridBand("KONTO", -1);
            UltraGridColumn column18 = new UltraGridColumn("IDKONTO");
            UltraGridColumn column19 = new UltraGridColumn("NAZIVKONTO");
            UltraGridColumn column20 = new UltraGridColumn("IDAKTIVNOST");
            UltraGridColumn column21 = new UltraGridColumn("NAZIVAKTIVNOST");
            UltraGridColumn column2 = new UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            EditorButton button3 = new EditorButton();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            UltraGridBand band3 = new UltraGridBand("KONTO", -1);
            UltraGridColumn column3 = new UltraGridColumn("IDKONTO");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVKONTO");
            UltraGridColumn column5 = new UltraGridColumn("IDAKTIVNOST");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVAKTIVNOST");
            UltraGridColumn column7 = new UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            EditorButton button4 = new EditorButton();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            UltraGridBand band4 = new UltraGridBand("ORGJED", -1);
            UltraGridColumn column8 = new UltraGridColumn("IDORGJED");
            UltraGridColumn column9 = new UltraGridColumn("NAZIVORGJED");
            UltraGridColumn column10 = new UltraGridColumn("oj");
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            EditorButton button5 = new EditorButton();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            UltraGridBand band5 = new UltraGridBand("MJESTOTROSKA", -1);
            UltraGridColumn column11 = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column13 = new UltraGridColumn("NAZIVMJESTOTROSKA");
            UltraGridColumn column14 = new UltraGridColumn("mt");
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, new Guid("cd2eb0b5-c0cb-485c-bd2a-e79d5ecb8f9d"));
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("cd2eb0b5-c0cb-485c-bd2a-e79d5ecb8f9d");
            DockableControlPane pane = new DockableControlPane(new Guid("7aeb9c20-bd18-4d92-b6dd-22079f416bc9"), floatingParentId, -1, dockedParentId, -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.cmboIDdok = new UltraCombo();
            this.DokumentDataSet1 = new DOKUMENTDataSet();
            this.cmboIDkontozavrsni = new UltraCombo();
            this.KontoDataSet1 = new KONTODataSet();
            this.cmboIDkontopocetni = new UltraCombo();
            this.cmboIDOJ = new UltraCombo();
            this.OrgjedDataSet1 = new ORGJEDDataSet();
            this.cmboIDMT = new UltraCombo();
            this.MjestotroskaDataSet1 = new MJESTOTROSKADataSet();
            this.doDatuma = new UltraDateTimeEditor();
            this.odDatuma = new UltraDateTimeEditor();
            this.Label5 = new Label();
            this.Label6 = new Label();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.Label4 = new Label();
            this.Label7 = new Label();
            this.ErrorProvider1 = new ErrorProvider(this.components);
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._frmPrometPoKontimaUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._frmPrometPoKontimaUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._frmPrometPoKontimaUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._frmPrometPoKontimaUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._frmPrometPoKontimaAutoHideControl = new AutoHideControl();
            this.WindowDockingArea2 = new WindowDockingArea();
            this.DockableWindow2 = new DockableWindow();
            this.RPV = new CrystalReportViewer();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.cmboIDdok).BeginInit();
            this.DokumentDataSet1.BeginInit();
            ((ISupportInitialize) this.cmboIDkontozavrsni).BeginInit();
            this.KontoDataSet1.BeginInit();
            ((ISupportInitialize) this.cmboIDkontopocetni).BeginInit();
            ((ISupportInitialize) this.cmboIDOJ).BeginInit();
            this.OrgjedDataSet1.BeginInit();
            ((ISupportInitialize) this.cmboIDMT).BeginInit();
            this.MjestotroskaDataSet1.BeginInit();
            ((ISupportInitialize) this.doDatuma).BeginInit();
            ((ISupportInitialize) this.odDatuma).BeginInit();
            ((ISupportInitialize) this.ErrorProvider1).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.cmboIDdok);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontozavrsni);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontopocetni);
            this.UltraGroupBox1.Controls.Add(this.cmboIDOJ);
            this.UltraGroupBox1.Controls.Add(this.cmboIDMT);
            this.UltraGroupBox1.Controls.Add(this.doDatuma);
            this.UltraGroupBox1.Controls.Add(this.odDatuma);
            this.UltraGroupBox1.Controls.Add(this.Label5);
            this.UltraGroupBox1.Controls.Add(this.Label6);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.Label4);
            this.UltraGroupBox1.Controls.Add(this.Label7);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(0x318, 0xc9);
            this.UltraGroupBox1.TabIndex = 0;
            this.UltraGroupBox1.Text = "Odabir podataka";
            this.UltraGroupBox1.ViewStyle = GroupBoxViewStyle.Office2007;
            appearance31.TextHAlignAsString = "Center";
            button.Appearance = appearance31;
            button.Text = "...";
            this.cmboIDdok.ButtonsRight.Add(button);
            this.cmboIDdok.CharacterCasing = CharacterCasing.Normal;
            this.cmboIDdok.DataMember = "DOKUMENT";
            this.cmboIDdok.DataSource = this.DokumentDataSet1;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDdok.DisplayLayout.Appearance = appearance42;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 0;
            column.Width = 0x41;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.VisiblePosition = 1;
            column12.Width = 150;
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.Header.VisiblePosition = 2;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.Header.VisiblePosition = 3;
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.Header.VisiblePosition = 4;
            band.Columns.AddRange(new object[] { column, column12, column15, column16, column17 });
            this.cmboIDdok.DisplayLayout.BandsSerializer.Add(band);
            this.cmboIDdok.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.cmboIDdok.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance53.BackGradientStyle = GradientStyle.Vertical;
            appearance53.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.GroupByBox.Appearance = appearance53;
            appearance63.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDdok.DisplayLayout.GroupByBox.BandLabelAppearance = appearance63;
            this.cmboIDdok.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance64.BackColor2 = System.Drawing.SystemColors.Control;
            appearance64.BackGradientStyle = GradientStyle.Horizontal;
            appearance64.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDdok.DisplayLayout.GroupByBox.PromptAppearance = appearance64;
            this.cmboIDdok.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDdok.DisplayLayout.MaxRowScrollRegions = 1;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            appearance65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDdok.DisplayLayout.Override.ActiveCellAppearance = appearance65;
            appearance.BackColor = System.Drawing.SystemColors.Highlight;
            appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDdok.DisplayLayout.Override.ActiveRowAppearance = appearance;
            this.cmboIDdok.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.cmboIDdok.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BorderColor = Color.Silver;
            appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDdok.DisplayLayout.Override.CellAppearance = appearance3;
            this.cmboIDdok.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.cmboIDdok.DisplayLayout.Override.CellPadding = 0;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientAlignment = GradientAlignment.Element;
            appearance4.BackGradientStyle = GradientStyle.Horizontal;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.Override.GroupByRowAppearance = appearance4;
            appearance5.TextHAlignAsString = "Left";
            this.cmboIDdok.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.cmboIDdok.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.cmboIDdok.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = Color.Silver;
            this.cmboIDdok.DisplayLayout.Override.RowAppearance = appearance6;
            this.cmboIDdok.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDdok.DisplayLayout.Override.TemplateAddRowAppearance = appearance7;
            this.cmboIDdok.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.cmboIDdok.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.cmboIDdok.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.cmboIDdok.DisplayMember = "NAZIVDOKUMENT";
            this.cmboIDdok.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDdok.Location = new System.Drawing.Point(0x90, 0x44);
            this.cmboIDdok.Name = "cmboIDdok";
            this.cmboIDdok.AllowNull = DefaultableBoolean.True;
            this.cmboIDdok.Size = new System.Drawing.Size(150, 0x16);
            this.cmboIDdok.TabIndex = 5;
            this.cmboIDdok.Tag = "";
            this.cmboIDdok.ValueMember = "IDDOKUMENT";
            this.DokumentDataSet1.DataSetName = "DOKUMENTDataSet";
            this.DokumentDataSet1.Locale = new CultureInfo("hr-HR");
            appearance8.TextHAlignAsString = "Center";
            button2.Appearance = appearance8;
            button2.Text = "...";
            this.cmboIDkontozavrsni.ButtonsRight.Add(button2);
            this.cmboIDkontozavrsni.CharacterCasing = CharacterCasing.Normal;
            this.cmboIDkontozavrsni.DataMember = "KONTO";
            this.cmboIDkontozavrsni.DataSource = this.KontoDataSet1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontozavrsni.DisplayLayout.Appearance = appearance9;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.Header.VisiblePosition = 0;
            column18.Width = 0x41;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.Header.VisiblePosition = 1;
            column19.Width = 200;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.Header.VisiblePosition = 2;
            column20.Width = 0x41;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.Header.VisiblePosition = 3;
            column21.Width = 100;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 4;
            band2.Columns.AddRange(new object[] { column18, column19, column20, column21, column2 });
            this.cmboIDkontozavrsni.DisplayLayout.BandsSerializer.Add(band2);
            this.cmboIDkontozavrsni.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.cmboIDkontozavrsni.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.cmboIDkontozavrsni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontozavrsni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellAppearance = appearance16;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = GradientAlignment.Element;
            appearance17.BackGradientStyle = GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.TextHAlignAsString = "Left";
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = Color.Silver;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowAppearance = appearance19;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontozavrsni.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.cmboIDkontozavrsni.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontozavrsni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontozavrsni.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontozavrsni.Location = new System.Drawing.Point(0x90, 0x76);
            this.cmboIDkontozavrsni.Name = "cmboIDkontozavrsni";
            this.cmboIDkontozavrsni.AllowNull = DefaultableBoolean.True;
            this.cmboIDkontozavrsni.Size = new System.Drawing.Size(150, 0x16);
            this.cmboIDkontozavrsni.TabIndex = 9;
            this.cmboIDkontozavrsni.Tag = "";
            this.cmboIDkontozavrsni.ValueMember = "IDKONTO";
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            this.KontoDataSet1.Locale = new CultureInfo("hr-HR");
            appearance21.TextHAlignAsString = "Center";
            button3.Appearance = appearance21;
            button3.Text = "...";
            this.cmboIDkontopocetni.ButtonsRight.Add(button3);
            this.cmboIDkontopocetni.CharacterCasing = CharacterCasing.Normal;
            this.cmboIDkontopocetni.DataMember = "KONTO";
            this.cmboIDkontopocetni.DataSource = this.KontoDataSet1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontopocetni.DisplayLayout.Appearance = appearance22;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 0;
            column3.Width = 0x41;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 1;
            column4.Width = 200;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 2;
            column5.Width = 0x41;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.Header.VisiblePosition = 3;
            column6.Width = 100;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.VisiblePosition = 4;
            band3.Columns.AddRange(new object[] { column3, column4, column5, column6, column7 });
            this.cmboIDkontopocetni.DisplayLayout.BandsSerializer.Add(band3);
            this.cmboIDkontopocetni.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.cmboIDkontopocetni.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientStyle = GradientStyle.Vertical;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.Appearance = appearance23;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance24;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance25.BackColor2 = System.Drawing.SystemColors.Control;
            appearance25.BackGradientStyle = GradientStyle.Horizontal;
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.PromptAppearance = appearance25;
            this.cmboIDkontopocetni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontopocetni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveCellAppearance = appearance26;
            appearance27.BackColor = System.Drawing.SystemColors.Highlight;
            appearance27.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveRowAppearance = appearance27;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.CardAreaAppearance = appearance28;
            appearance29.BorderColor = Color.Silver;
            appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellAppearance = appearance29;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellPadding = 0;
            appearance30.BackColor = System.Drawing.SystemColors.Control;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientAlignment = GradientAlignment.Element;
            appearance30.BackGradientStyle = GradientStyle.Horizontal;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.GroupByRowAppearance = appearance30;
            appearance32.TextHAlignAsString = "Left";
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.BorderColor = Color.Silver;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowAppearance = appearance33;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontopocetni.DisplayLayout.Override.TemplateAddRowAppearance = appearance34;
            this.cmboIDkontopocetni.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.cmboIDkontopocetni.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.cmboIDkontopocetni.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontopocetni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontopocetni.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontopocetni.Location = new System.Drawing.Point(0x90, 0x5e);
            this.cmboIDkontopocetni.Name = "cmboIDkontopocetni";
            this.cmboIDkontopocetni.AllowNull = DefaultableBoolean.True;
            this.cmboIDkontopocetni.Size = new System.Drawing.Size(150, 0x16);
            this.cmboIDkontopocetni.TabIndex = 7;
            this.cmboIDkontopocetni.Tag = "";
            this.cmboIDkontopocetni.ValueMember = "IDKONTO";
            appearance35.TextHAlignAsString = "Center";
            button4.Appearance = appearance35;
            button4.Text = "...";
            this.cmboIDOJ.ButtonsRight.Add(button4);
            this.cmboIDOJ.CharacterCasing = CharacterCasing.Normal;
            this.cmboIDOJ.DataMember = "ORGJED";
            this.cmboIDOJ.DataSource = this.OrgjedDataSet1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDOJ.DisplayLayout.Appearance = appearance36;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.VisiblePosition = 0;
            column8.Width = 0x41;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 1;
            column9.Width = 150;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.VisiblePosition = 2;
            band4.Columns.AddRange(new object[] { column8, column9, column10 });
            this.cmboIDOJ.DisplayLayout.BandsSerializer.Add(band4);
            this.cmboIDOJ.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.cmboIDOJ.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance37.BackGradientStyle = GradientStyle.Vertical;
            appearance37.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.GroupByBox.Appearance = appearance37;
            appearance38.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BandLabelAppearance = appearance38;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance39.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance39.BackColor2 = System.Drawing.SystemColors.Control;
            appearance39.BackGradientStyle = GradientStyle.Horizontal;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.PromptAppearance = appearance39;
            this.cmboIDOJ.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDOJ.DisplayLayout.MaxRowScrollRegions = 1;
            appearance40.BackColor = System.Drawing.SystemColors.Window;
            appearance40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveCellAppearance = appearance40;
            appearance41.BackColor = System.Drawing.SystemColors.Highlight;
            appearance41.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveRowAppearance = appearance41;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDOJ.DisplayLayout.Override.CellAppearance = appearance44;
            this.cmboIDOJ.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.cmboIDOJ.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = GradientAlignment.Element;
            appearance45.BackGradientStyle = GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.cmboIDOJ.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.cmboIDOJ.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.cmboIDOJ.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = Color.Silver;
            this.cmboIDOJ.DisplayLayout.Override.RowAppearance = appearance47;
            this.cmboIDOJ.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDOJ.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.cmboIDOJ.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.cmboIDOJ.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.cmboIDOJ.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.cmboIDOJ.DisplayMember = "NAZIVORGJED";
            this.cmboIDOJ.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDOJ.Location = new System.Drawing.Point(0x90, 20);
            this.cmboIDOJ.Name = "cmboIDOJ";
            this.cmboIDOJ.AllowNull = DefaultableBoolean.True;
            this.cmboIDOJ.Size = new System.Drawing.Size(150, 0x16);
            this.cmboIDOJ.TabIndex = 1;
            this.cmboIDOJ.Tag = "";
            this.cmboIDOJ.ValueMember = "IDORGJED";
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            this.OrgjedDataSet1.Locale = new CultureInfo("hr-HR");
            appearance49.TextHAlignAsString = "Center";
            button5.Appearance = appearance49;
            button5.Text = "...";
            this.cmboIDMT.ButtonsRight.Add(button5);
            this.cmboIDMT.CharacterCasing = CharacterCasing.Normal;
            this.cmboIDMT.DataMember = "MJESTOTROSKA";
            this.cmboIDMT.DataSource = this.MjestotroskaDataSet1;
            appearance50.BackColor = System.Drawing.SystemColors.Window;
            appearance50.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDMT.DisplayLayout.Appearance = appearance50;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 0;
            column11.Width = 0x41;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 1;
            column13.Width = 150;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 2;
            band5.Columns.AddRange(new object[] { column11, column13, column14 });
            this.cmboIDMT.DisplayLayout.BandsSerializer.Add(band5);
            this.cmboIDMT.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.cmboIDMT.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance51.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance51.BackGradientStyle = GradientStyle.Vertical;
            appearance51.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.GroupByBox.Appearance = appearance51;
            appearance52.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDMT.DisplayLayout.GroupByBox.BandLabelAppearance = appearance52;
            this.cmboIDMT.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance54.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance54.BackColor2 = System.Drawing.SystemColors.Control;
            appearance54.BackGradientStyle = GradientStyle.Horizontal;
            appearance54.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDMT.DisplayLayout.GroupByBox.PromptAppearance = appearance54;
            this.cmboIDMT.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDMT.DisplayLayout.MaxRowScrollRegions = 1;
            appearance55.BackColor = System.Drawing.SystemColors.Window;
            appearance55.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDMT.DisplayLayout.Override.ActiveCellAppearance = appearance55;
            appearance56.BackColor = System.Drawing.SystemColors.Highlight;
            appearance56.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDMT.DisplayLayout.Override.ActiveRowAppearance = appearance56;
            this.cmboIDMT.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.cmboIDMT.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance57.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.CardAreaAppearance = appearance57;
            appearance58.BorderColor = Color.Silver;
            appearance58.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDMT.DisplayLayout.Override.CellAppearance = appearance58;
            this.cmboIDMT.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.cmboIDMT.DisplayLayout.Override.CellPadding = 0;
            appearance59.BackColor = System.Drawing.SystemColors.Control;
            appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance59.BackGradientAlignment = GradientAlignment.Element;
            appearance59.BackGradientStyle = GradientStyle.Horizontal;
            appearance59.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.GroupByRowAppearance = appearance59;
            appearance60.TextHAlignAsString = "Left";
            this.cmboIDMT.DisplayLayout.Override.HeaderAppearance = appearance60;
            this.cmboIDMT.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.cmboIDMT.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance61.BackColor = System.Drawing.SystemColors.Window;
            appearance61.BorderColor = Color.Silver;
            this.cmboIDMT.DisplayLayout.Override.RowAppearance = appearance61;
            this.cmboIDMT.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance62.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDMT.DisplayLayout.Override.TemplateAddRowAppearance = appearance62;
            this.cmboIDMT.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.cmboIDMT.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.cmboIDMT.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.cmboIDMT.DisplayMember = "IDMJESTOTROSKA";
            this.cmboIDMT.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDMT.Location = new System.Drawing.Point(0x90, 0x2c);
            this.cmboIDMT.Name = "cmboIDMT";
            this.cmboIDMT.AllowNull = DefaultableBoolean.True;
            this.cmboIDMT.Size = new System.Drawing.Size(150, 0x16);
            this.cmboIDMT.TabIndex = 3;
            this.cmboIDMT.Tag = "";
            this.cmboIDMT.ValueMember = "IDMJESTOTROSKA";
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet1.Locale = new CultureInfo("hr-HR");
            this.doDatuma.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.doDatuma.Location = new System.Drawing.Point(0x90, 0xa8);
            this.doDatuma.Name = "doDatuma";
            this.doDatuma.PromptChar = ' ';
            this.doDatuma.Size = new System.Drawing.Size(150, 0x15);
            this.doDatuma.TabIndex = 13;
            this.odDatuma.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.odDatuma.Location = new System.Drawing.Point(0x90, 0x90);
            this.odDatuma.Name = "odDatuma";
            this.odDatuma.PromptChar = ' ';
            this.odDatuma.Size = new System.Drawing.Size(150, 0x15);
            this.odDatuma.TabIndex = 11;
            this.Label5.BackColor = Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label5.Location = new System.Drawing.Point(8, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(130, 0x16);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Organizacijska jedinica:";
            this.Label5.TextAlign = ContentAlignment.MiddleLeft;
            this.Label6.BackColor = Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label6.Location = new System.Drawing.Point(8, 0x2c);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(130, 0x16);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Mjesto troška:";
            this.Label6.TextAlign = ContentAlignment.MiddleLeft;
            this.Label1.BackColor = Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label1.Location = new System.Drawing.Point(8, 0x44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(130, 0x16);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Vrsta dokumenta:";
            this.Label1.TextAlign = ContentAlignment.MiddleLeft;
            this.Label2.BackColor = Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label2.Location = new System.Drawing.Point(8, 0x5e);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(130, 0x16);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Od konta:";
            this.Label2.TextAlign = ContentAlignment.MiddleLeft;
            this.Label3.BackColor = Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label3.Location = new System.Drawing.Point(8, 0x76);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(130, 0x16);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Do konta:";
            this.Label3.TextAlign = ContentAlignment.MiddleLeft;
            this.Label4.BackColor = Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label4.Location = new System.Drawing.Point(8, 0x90);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(130, 0x15);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Od datuma:";
            this.Label4.TextAlign = ContentAlignment.MiddleLeft;
            this.Label7.BackColor = Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label7.Location = new System.Drawing.Point(8, 0xa8);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(130, 0x15);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "Do datuma:";
            this.Label7.TextAlign = ContentAlignment.MiddleLeft;
            this.ErrorProvider1.ContainerControl = this;
            pane.Control = this.UltraGroupBox1;
            Rectangle rectangle = new Rectangle(4, 30, 0x1fc, 0xc6);
            pane.OriginalControlBounds = rectangle;
            pane.Size = new System.Drawing.Size(100, 100);
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            pane2.Size = new System.Drawing.Size(0x318, 0xdb);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            this._frmPrometPoKontimaUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._frmPrometPoKontimaUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmPrometPoKontimaUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmPrometPoKontimaUnpinnedTabAreaLeft.Name = "_frmPrometPoKontimaUnpinnedTabAreaLeft";
            this._frmPrometPoKontimaUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmPrometPoKontimaUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 430);
            this._frmPrometPoKontimaUnpinnedTabAreaLeft.TabIndex = 0x69;
            this._frmPrometPoKontimaUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._frmPrometPoKontimaUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmPrometPoKontimaUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x318, 0);
            this._frmPrometPoKontimaUnpinnedTabAreaRight.Name = "_frmPrometPoKontimaUnpinnedTabAreaRight";
            this._frmPrometPoKontimaUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmPrometPoKontimaUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 430);
            this._frmPrometPoKontimaUnpinnedTabAreaRight.TabIndex = 0x6a;
            this._frmPrometPoKontimaUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._frmPrometPoKontimaUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmPrometPoKontimaUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmPrometPoKontimaUnpinnedTabAreaTop.Name = "_frmPrometPoKontimaUnpinnedTabAreaTop";
            this._frmPrometPoKontimaUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmPrometPoKontimaUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x318, 0);
            this._frmPrometPoKontimaUnpinnedTabAreaTop.TabIndex = 0x6b;
            this._frmPrometPoKontimaUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._frmPrometPoKontimaUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmPrometPoKontimaUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 430);
            this._frmPrometPoKontimaUnpinnedTabAreaBottom.Name = "_frmPrometPoKontimaUnpinnedTabAreaBottom";
            this._frmPrometPoKontimaUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmPrometPoKontimaUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x318, 0);
            this._frmPrometPoKontimaUnpinnedTabAreaBottom.TabIndex = 0x6c;
            this._frmPrometPoKontimaAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmPrometPoKontimaAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmPrometPoKontimaAutoHideControl.Name = "_frmPrometPoKontimaAutoHideControl";
            this._frmPrometPoKontimaAutoHideControl.Owner = this.UltraDockManager1;
            this._frmPrometPoKontimaAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._frmPrometPoKontimaAutoHideControl.TabIndex = 0x6d;
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(0x318, 0xe0);
            this.WindowDockingArea2.TabIndex = 0x6f;
            this.DockableWindow2.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(0x318, 0xdb);
            this.DockableWindow2.TabIndex = 0x71;
            this.RPV.ActiveViewIndex = -1;
            this.RPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPV.Cursor = Cursors.Arrow;
            this.RPV.DisplayBackgroundEdge = false;
            this.RPV.Dock = DockStyle.Fill;
            this.RPV.Location = new System.Drawing.Point(0, 0xe0);
            this.RPV.Name = "RPV";
            this.RPV.Size = new System.Drawing.Size(0x318, 0xce);
            this.RPV.TabIndex = 0x70;
            this.RPV.ToolPanelView = 0;
            this.Controls.Add(this._frmPrometPoKontimaAutoHideControl);
            this.Controls.Add(this.RPV);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this._frmPrometPoKontimaUnpinnedTabAreaTop);
            this.Controls.Add(this._frmPrometPoKontimaUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmPrometPoKontimaUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmPrometPoKontimaUnpinnedTabAreaRight);
            this.Name = "PrometPoKontimaSmartPart";
            this.Size = new System.Drawing.Size(0x318, 430);


            this.UltraGroupBox1.Click += new EventHandler(this.UltraGroupBox1_Click);
            this.cmboIDOJ.BeforeDropDown += new CancelEventHandler(this.cmboIDOJ_BeforeDropDown);
            this.cmboIDMT.BeforeDropDown += new CancelEventHandler(this.cmboIDMT_BeforeDropDown);
            this.cmboIDkontozavrsni.BeforeDropDown += new CancelEventHandler(this.cmboIDkontozavrsni_BeforeDropDown);
            this.cmboIDkontopocetni.BeforeDropDown += new CancelEventHandler(this.cmboIDkontopocetni_BeforeDropDown);
            this.cmboIDdok.BeforeDropDown += new CancelEventHandler(this.cmboIDdok_BeforeDropDown);


            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.cmboIDdok).EndInit();
            this.DokumentDataSet1.EndInit();
            ((ISupportInitialize) this.cmboIDkontozavrsni).EndInit();
            this.KontoDataSet1.EndInit();
            ((ISupportInitialize) this.cmboIDkontopocetni).EndInit();
            ((ISupportInitialize) this.cmboIDOJ).EndInit();
            this.OrgjedDataSet1.EndInit();
            ((ISupportInitialize) this.cmboIDMT).EndInit();
            this.MjestotroskaDataSet1.EndInit();
            ((ISupportInitialize) this.doDatuma).EndInit();
            ((ISupportInitialize) this.odDatuma).EndInit();
            ((ISupportInitialize) this.ErrorProvider1).EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Ispisi()
        {
            this.BackgroundUpdate();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Promet po kontima!",
                Description = "Pregled izvještaja - Promet po kontima!",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = this.rpt;
            item.Show(item.Workspaces["main"], info);
        }

        [LocalCommandHandler("Kreiraj")]
        public void KreirajHandler(object sender, EventArgs e)
        {
            this.Ispisi();
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
                case Keys.F4:
                    this.Ispisi();
                    return true;

                case Keys.Escape:
                    this.ParentForm.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PrometPoKontimaSmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
            this.ZAVRSNI = mipsed.application.framework.Application.Zavrsni;
            this.odDatuma.Value = this.POCETNI;
            this.doDatuma.Value = this.ZAVRSNI;
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            InfraCustom.InicijalizirajCombo(this.cmboIDOJ, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDMT, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDdok, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontopocetni, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontozavrsni, null);
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private AutoHideControl _frmPrometPoKontimaAutoHideControl;

        private UnpinnedTabArea _frmPrometPoKontimaUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmPrometPoKontimaUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmPrometPoKontimaUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmPrometPoKontimaUnpinnedTabAreaTop;

        private UltraCombo cmboIDdok;

        private UltraCombo cmboIDkontopocetni;

        private UltraCombo cmboIDkontozavrsni;

        private UltraCombo cmboIDMT;

        private UltraCombo cmboIDOJ;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
            }
        }

        private DockableWindow DockableWindow2;

        private UltraDateTimeEditor doDatuma;

        private DOKUMENTDataSet DokumentDataSet1;

        private ErrorProvider ErrorProvider1;

        public DataRow FillByRow
        {
            set
            {
            }
        }

        public string FillMethod
        {
            set
            {
            }
        }

        private KONTODataSet KontoDataSet1;

        private Label Label1;

        private Label Label2;

        private Label Label3;

        private Label Label4;

        private Label Label5;

        private Label Label6;

        private Label Label7;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private UltraDateTimeEditor odDatuma;

        private ORGJEDDataSet OrgjedDataSet1;

        private CrystalReportViewer RPV;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDockManager UltraDockManager1;

        private UltraGroupBox UltraGroupBox1;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

