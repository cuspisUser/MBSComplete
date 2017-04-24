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
    public class DnevnikKnjizenjaSmartpart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        
        private DateTime POCETNI;
        private ReportDocument rpt;
        private SmartPartInfo smartPartInfo1;
        private DateTime ZAVRSNI;

        public DnevnikKnjizenjaSmartpart()
        {
            base.Load += new EventHandler(this.DnevnikKnjizeNjaSmartPart_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Izvještaji-GK-Dnevnik knjiženja", "Izvještaji-GK-Dnevnik knjiženja");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void BackgroundUpdate()
        {
            new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen, DialogText = "Pripremam izvještaj dnevnik knjiženja!", IsCancellingEnabled = false, AutoIncrementInterval = 150 }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelled));
        }

        private void CountUntilCancelled(object sender, DoWorkEventArgs e)
        {
            try
            {
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                };
                this.POCETNI = Conversions.ToDate(this.oddatuma.Value);
                this.ZAVRSNI = Conversions.ToDate(this.dodatuma.Value);
                this.rpt = new ReportDocument();
                this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptDnevnik.rpt");
                SqlCommand command = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.CommandText = "S_FIN_DNEVNIK";
                if (this.oj.SelectedRow == null)
                {
                    num4 = -1;
                }
                else
                {
                    num4 = Conversions.ToInteger(this.oj.Value);
                }
                if (this.mt.SelectedRow == null)
                {
                    num3 = -1;
                }
                else
                {
                    num3 = Conversions.ToInteger(this.mt.Value);
                }
                if (this.vd.SelectedRow == null)
                {
                    num2 = -1;
                }
                else
                {
                    num2 = Conversions.ToInteger(this.vd.Value);
                }
                if (this.oddatuma.IsDateValid & this.dodatuma.IsDateValid)
                {
                    string str = string.Empty;
                    string text;
                    if (this.od_konta.SelectedRow != null)
                    {
                        text = this.od_konta.Text;
                    }
                    else
                    {
                        text = " ";
                    }
                    if (this.do_konta.SelectedRow != null)
                    {
                        str = this.do_konta.Text;
                    }
                    else
                    {
                        str = " ";
                    }
                    DateTime rAZDOBLJEOD = Conversions.ToDate(this.oddatuma.Value);
                    DateTime rAZDOBLJEDO = Conversions.ToDate(this.dodatuma.Value);
                    int bROJDOK = -1;
                    S_FIN_DNEVNIKDataAdapter adapter2 = new S_FIN_DNEVNIKDataAdapter();
                    S_FIN_DNEVNIKDataSet dataSet = new S_FIN_DNEVNIKDataSet();
                    try
                    {
                        adapter2.Fill(dataSet, num4, num3, num2, bROJDOK, rAZDOBLJEOD, rAZDOBLJEDO, text, str, true);
                    }
                    catch (SqlException exception1)
                    {
                        throw exception1;
                        //SqlException exception = exception1;
                        
                        
                    }
                    this.rpt.SetDataSource(dataSet);
                    if (this.od_konta.SelectedRow != null)
                    {
                        this.rpt.SetParameterValue("odkonta", RuntimeHelpers.GetObjectValue(this.od_konta.Value));
                    }
                    else
                    {
                        this.rpt.SetParameterValue("odkonta", "Sva konta");
                    }
                    if (this.do_konta.SelectedRow != null)
                    {
                        this.rpt.SetParameterValue("dokonta", RuntimeHelpers.GetObjectValue(this.do_konta.Value));
                    }
                    else
                    {
                        this.rpt.SetParameterValue("dokonta", "Sva konta");
                    }
                    mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref this.rpt);
                    this.rpt.SetParameterValue("naslov", "Dnevnik knjiženja za razdoblje od: " + Conversions.ToString(this.POCETNI) + " - " + Conversions.ToString(this.ZAVRSNI));
                    this.rpt.SetParameterValue("pocetni", this.POCETNI);
                    this.rpt.SetParameterValue("zavrsni", this.ZAVRSNI);
                }
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

        private void DnevnikKnjizeNjaSmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
            this.ZAVRSNI = mipsed.application.framework.Application.Zavrsni;
            this.oddatuma.Value = this.POCETNI;
            this.dodatuma.Value = this.ZAVRSNI;
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            InfraCustom.InicijalizirajCombo(this.oj, "");
            InfraCustom.InicijalizirajCombo(this.mt, "");
            InfraCustom.InicijalizirajCombo(this.vd, "");
            InfraCustom.InicijalizirajCombo(this.od_konta, "");
            InfraCustom.InicijalizirajCombo(this.do_konta, "");
        }

        private void do_konta_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.KontoDataSet1.KONTO.Rows.Count == 0)
            {
                new KONTODataAdapter().Fill(this.KontoDataSet1);
            }
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
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, new Guid("4d28828a-7ae0-4ce5-aad6-87f3e05bd0ba"));
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("4d28828a-7ae0-4ce5-aad6-87f3e05bd0ba");
            DockableControlPane pane = new DockableControlPane(new Guid("62c1bbfb-2134-4eb9-9daf-dd783d2cc261"), floatingParentId, -1, dockedParentId, -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.vd = new UltraCombo();
            this.DokumentDataSet1 = new DOKUMENTDataSet();
            this.do_konta = new UltraCombo();
            this.KontoDataSet1 = new KONTODataSet();
            this.od_konta = new UltraCombo();
            this.oj = new UltraCombo();
            this.OrgjedDataSet1 = new ORGJEDDataSet();
            this.mt = new UltraCombo();
            this.MjestotroskaDataSet1 = new MJESTOTROSKADataSet();
            this.dodatuma = new UltraDateTimeEditor();
            this.oddatuma = new UltraDateTimeEditor();
            this.Label5 = new Label();
            this.Label6 = new Label();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.Label4 = new Label();
            this.Label7 = new Label();
            this.SqlConnection1 = new SqlConnection();
            this.ErrorProvider1 = new ErrorProvider(this.components);
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._frmDnevnikKnjizenjaAutoHideControl = new AutoHideControl();
            this.WindowDockingArea2 = new WindowDockingArea();
            this.DockableWindow2 = new DockableWindow();
            this.ctlReportViewer = new CrystalReportViewer();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.vd).BeginInit();
            this.DokumentDataSet1.BeginInit();
            ((ISupportInitialize) this.do_konta).BeginInit();
            this.KontoDataSet1.BeginInit();
            ((ISupportInitialize) this.od_konta).BeginInit();
            ((ISupportInitialize) this.oj).BeginInit();
            this.OrgjedDataSet1.BeginInit();
            ((ISupportInitialize) this.mt).BeginInit();
            this.MjestotroskaDataSet1.BeginInit();
            ((ISupportInitialize) this.dodatuma).BeginInit();
            ((ISupportInitialize) this.oddatuma).BeginInit();
            ((ISupportInitialize) this.ErrorProvider1).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.vd);
            this.UltraGroupBox1.Controls.Add(this.do_konta);
            this.UltraGroupBox1.Controls.Add(this.od_konta);
            this.UltraGroupBox1.Controls.Add(this.oj);
            this.UltraGroupBox1.Controls.Add(this.mt);
            this.UltraGroupBox1.Controls.Add(this.dodatuma);
            this.UltraGroupBox1.Controls.Add(this.oddatuma);
            this.UltraGroupBox1.Controls.Add(this.Label5);
            this.UltraGroupBox1.Controls.Add(this.Label6);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.Label4);
            this.UltraGroupBox1.Controls.Add(this.Label7);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(0x318, 0xb5);
            this.UltraGroupBox1.TabIndex = 0;
            this.UltraGroupBox1.ViewStyle = GroupBoxViewStyle.Office2007;
            appearance31.TextHAlignAsString = "Center";
            button.Appearance = appearance31;
            button.Text = "...";
            this.vd.ButtonsRight.Add(button);
            this.vd.CharacterCasing = CharacterCasing.Normal;
            this.vd.DataMember = "DOKUMENT";
            this.vd.DataSource = this.DokumentDataSet1;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.vd.DisplayLayout.Appearance = appearance42;
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
            this.vd.DisplayLayout.BandsSerializer.Add(band);
            this.vd.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.vd.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance53.BackGradientStyle = GradientStyle.Vertical;
            appearance53.BorderColor = System.Drawing.SystemColors.Window;
            this.vd.DisplayLayout.GroupByBox.Appearance = appearance53;
            appearance63.ForeColor = System.Drawing.SystemColors.GrayText;
            this.vd.DisplayLayout.GroupByBox.BandLabelAppearance = appearance63;
            this.vd.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance64.BackColor2 = System.Drawing.SystemColors.Control;
            appearance64.BackGradientStyle = GradientStyle.Horizontal;
            appearance64.ForeColor = System.Drawing.SystemColors.GrayText;
            this.vd.DisplayLayout.GroupByBox.PromptAppearance = appearance64;
            this.vd.DisplayLayout.MaxColScrollRegions = 1;
            this.vd.DisplayLayout.MaxRowScrollRegions = 1;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            appearance65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vd.DisplayLayout.Override.ActiveCellAppearance = appearance65;
            appearance.BackColor = System.Drawing.SystemColors.Highlight;
            appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.vd.DisplayLayout.Override.ActiveRowAppearance = appearance;
            this.vd.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.vd.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            this.vd.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BorderColor = Color.Silver;
            appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.vd.DisplayLayout.Override.CellAppearance = appearance3;
            this.vd.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.vd.DisplayLayout.Override.CellPadding = 0;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientAlignment = GradientAlignment.Element;
            appearance4.BackGradientStyle = GradientStyle.Horizontal;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.vd.DisplayLayout.Override.GroupByRowAppearance = appearance4;
            appearance5.TextHAlignAsString = "Left";
            this.vd.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.vd.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.vd.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = Color.Silver;
            this.vd.DisplayLayout.Override.RowAppearance = appearance6;
            this.vd.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.vd.DisplayLayout.Override.TemplateAddRowAppearance = appearance7;
            this.vd.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.vd.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.vd.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.vd.DisplayMember = "NAZIVDOKUMENT";
            this.vd.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.vd.Location = new System.Drawing.Point(0x92, 0x34);
            this.vd.Name = "vd";
            this.vd.AllowNull = DefaultableBoolean.True;
            this.vd.Size = new System.Drawing.Size(0x74, 0x16);
            this.vd.TabIndex = 5;
            this.vd.Tag = "";
            this.vd.ValueMember = "IDDOKUMENT";
            this.DokumentDataSet1.DataSetName = "DOKUMENTDataSet";
            this.DokumentDataSet1.Locale = new CultureInfo("hr-HR");
            appearance8.TextHAlignAsString = "Center";
            button2.Appearance = appearance8;
            button2.Text = "...";
            this.do_konta.ButtonsRight.Add(button2);
            this.do_konta.CharacterCasing = CharacterCasing.Normal;
            this.do_konta.DataMember = "KONTO";
            this.do_konta.DataSource = this.KontoDataSet1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.do_konta.DisplayLayout.Appearance = appearance9;
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
            this.do_konta.DisplayLayout.BandsSerializer.Add(band2);
            this.do_konta.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.do_konta.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.do_konta.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.do_konta.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.do_konta.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.do_konta.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.do_konta.DisplayLayout.MaxColScrollRegions = 1;
            this.do_konta.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.do_konta.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.do_konta.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.do_konta.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.do_konta.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.do_konta.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.do_konta.DisplayLayout.Override.CellAppearance = appearance16;
            this.do_konta.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.do_konta.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = GradientAlignment.Element;
            appearance17.BackGradientStyle = GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.do_konta.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.TextHAlignAsString = "Left";
            this.do_konta.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.do_konta.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.do_konta.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = Color.Silver;
            this.do_konta.DisplayLayout.Override.RowAppearance = appearance19;
            this.do_konta.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.do_konta.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.do_konta.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.do_konta.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.do_konta.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.do_konta.DisplayMember = "NAZIVKONTO";
            this.do_konta.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.do_konta.Location = new System.Drawing.Point(0x92, 0x66);
            this.do_konta.Name = "do_konta";
            this.do_konta.AllowNull = DefaultableBoolean.True;
            this.do_konta.Size = new System.Drawing.Size(0x74, 0x16);
            this.do_konta.TabIndex = 9;
            this.do_konta.Tag = "";
            this.do_konta.ValueMember = "IDKONTO";
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            this.KontoDataSet1.Locale = new CultureInfo("hr-HR");
            appearance21.TextHAlignAsString = "Center";
            button3.Appearance = appearance21;
            button3.Text = "...";
            this.od_konta.ButtonsRight.Add(button3);
            this.od_konta.CharacterCasing = CharacterCasing.Normal;
            this.od_konta.DataMember = "KONTO";
            this.od_konta.DataSource = this.KontoDataSet1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.od_konta.DisplayLayout.Appearance = appearance22;
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
            this.od_konta.DisplayLayout.BandsSerializer.Add(band3);
            this.od_konta.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.od_konta.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientStyle = GradientStyle.Vertical;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.od_konta.DisplayLayout.GroupByBox.Appearance = appearance23;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.od_konta.DisplayLayout.GroupByBox.BandLabelAppearance = appearance24;
            this.od_konta.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance25.BackColor2 = System.Drawing.SystemColors.Control;
            appearance25.BackGradientStyle = GradientStyle.Horizontal;
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.od_konta.DisplayLayout.GroupByBox.PromptAppearance = appearance25;
            this.od_konta.DisplayLayout.MaxColScrollRegions = 1;
            this.od_konta.DisplayLayout.MaxRowScrollRegions = 1;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.od_konta.DisplayLayout.Override.ActiveCellAppearance = appearance26;
            appearance27.BackColor = System.Drawing.SystemColors.Highlight;
            appearance27.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.od_konta.DisplayLayout.Override.ActiveRowAppearance = appearance27;
            this.od_konta.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.od_konta.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            this.od_konta.DisplayLayout.Override.CardAreaAppearance = appearance28;
            appearance29.BorderColor = Color.Silver;
            appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.od_konta.DisplayLayout.Override.CellAppearance = appearance29;
            this.od_konta.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.od_konta.DisplayLayout.Override.CellPadding = 0;
            appearance30.BackColor = System.Drawing.SystemColors.Control;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientAlignment = GradientAlignment.Element;
            appearance30.BackGradientStyle = GradientStyle.Horizontal;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.od_konta.DisplayLayout.Override.GroupByRowAppearance = appearance30;
            appearance32.TextHAlignAsString = "Left";
            this.od_konta.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.od_konta.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.od_konta.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.BorderColor = Color.Silver;
            this.od_konta.DisplayLayout.Override.RowAppearance = appearance33;
            this.od_konta.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLight;
            this.od_konta.DisplayLayout.Override.TemplateAddRowAppearance = appearance34;
            this.od_konta.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.od_konta.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.od_konta.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.od_konta.DisplayMember = "NAZIVKONTO";
            this.od_konta.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.od_konta.Location = new System.Drawing.Point(0x92, 0x4e);
            this.od_konta.Name = "od_konta";
            this.od_konta.AllowNull = DefaultableBoolean.True;
            this.od_konta.Size = new System.Drawing.Size(0x74, 0x16);
            this.od_konta.TabIndex = 7;
            this.od_konta.Tag = "";
            this.od_konta.ValueMember = "IDKONTO";
            appearance35.TextHAlignAsString = "Center";
            button4.Appearance = appearance35;
            button4.Text = "...";
            this.oj.ButtonsRight.Add(button4);
            this.oj.CharacterCasing = CharacterCasing.Normal;
            this.oj.DataMember = "ORGJED";
            this.oj.DataSource = this.OrgjedDataSet1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.oj.DisplayLayout.Appearance = appearance36;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.VisiblePosition = 0;
            column8.Width = 0x41;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 1;
            column9.Width = 150;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.VisiblePosition = 2;
            band4.Columns.AddRange(new object[] { column8, column9, column10 });
            this.oj.DisplayLayout.BandsSerializer.Add(band4);
            this.oj.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.oj.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance37.BackGradientStyle = GradientStyle.Vertical;
            appearance37.BorderColor = System.Drawing.SystemColors.Window;
            this.oj.DisplayLayout.GroupByBox.Appearance = appearance37;
            appearance38.ForeColor = System.Drawing.SystemColors.GrayText;
            this.oj.DisplayLayout.GroupByBox.BandLabelAppearance = appearance38;
            this.oj.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance39.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance39.BackColor2 = System.Drawing.SystemColors.Control;
            appearance39.BackGradientStyle = GradientStyle.Horizontal;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.oj.DisplayLayout.GroupByBox.PromptAppearance = appearance39;
            this.oj.DisplayLayout.MaxColScrollRegions = 1;
            this.oj.DisplayLayout.MaxRowScrollRegions = 1;
            appearance40.BackColor = System.Drawing.SystemColors.Window;
            appearance40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.oj.DisplayLayout.Override.ActiveCellAppearance = appearance40;
            appearance41.BackColor = System.Drawing.SystemColors.Highlight;
            appearance41.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.oj.DisplayLayout.Override.ActiveRowAppearance = appearance41;
            this.oj.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.oj.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.oj.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.oj.DisplayLayout.Override.CellAppearance = appearance44;
            this.oj.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.oj.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = GradientAlignment.Element;
            appearance45.BackGradientStyle = GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.oj.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.oj.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.oj.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.oj.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = Color.Silver;
            this.oj.DisplayLayout.Override.RowAppearance = appearance47;
            this.oj.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.oj.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.oj.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.oj.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.oj.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.oj.DisplayMember = "NAZIVORGJED";
            this.oj.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.oj.Location = new System.Drawing.Point(0x92, 4);
            this.oj.Name = "oj";
            this.oj.AllowNull = DefaultableBoolean.True;
            this.oj.Size = new System.Drawing.Size(0x74, 0x16);
            this.oj.TabIndex = 1;
            this.oj.Tag = "";
            this.oj.ValueMember = "IDORGJED";
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            this.OrgjedDataSet1.Locale = new CultureInfo("hr-HR");
            appearance49.TextHAlignAsString = "Center";
            button5.Appearance = appearance49;
            button5.Text = "...";
            this.mt.ButtonsRight.Add(button5);
            this.mt.CharacterCasing = CharacterCasing.Normal;
            this.mt.DataMember = "MJESTOTROSKA";
            this.mt.DataSource = this.MjestotroskaDataSet1;
            appearance50.BackColor = System.Drawing.SystemColors.Window;
            appearance50.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.mt.DisplayLayout.Appearance = appearance50;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 0;
            column11.Width = 0x41;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 1;
            column13.Width = 150;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 2;
            band5.Columns.AddRange(new object[] { column11, column13, column14 });
            this.mt.DisplayLayout.BandsSerializer.Add(band5);
            this.mt.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.mt.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance51.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance51.BackGradientStyle = GradientStyle.Vertical;
            appearance51.BorderColor = System.Drawing.SystemColors.Window;
            this.mt.DisplayLayout.GroupByBox.Appearance = appearance51;
            appearance52.ForeColor = System.Drawing.SystemColors.GrayText;
            this.mt.DisplayLayout.GroupByBox.BandLabelAppearance = appearance52;
            this.mt.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance54.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance54.BackColor2 = System.Drawing.SystemColors.Control;
            appearance54.BackGradientStyle = GradientStyle.Horizontal;
            appearance54.ForeColor = System.Drawing.SystemColors.GrayText;
            this.mt.DisplayLayout.GroupByBox.PromptAppearance = appearance54;
            this.mt.DisplayLayout.MaxColScrollRegions = 1;
            this.mt.DisplayLayout.MaxRowScrollRegions = 1;
            appearance55.BackColor = System.Drawing.SystemColors.Window;
            appearance55.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mt.DisplayLayout.Override.ActiveCellAppearance = appearance55;
            appearance56.BackColor = System.Drawing.SystemColors.Highlight;
            appearance56.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.mt.DisplayLayout.Override.ActiveRowAppearance = appearance56;
            this.mt.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.mt.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance57.BackColor = System.Drawing.SystemColors.Window;
            this.mt.DisplayLayout.Override.CardAreaAppearance = appearance57;
            appearance58.BorderColor = Color.Silver;
            appearance58.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.mt.DisplayLayout.Override.CellAppearance = appearance58;
            this.mt.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.mt.DisplayLayout.Override.CellPadding = 0;
            appearance59.BackColor = System.Drawing.SystemColors.Control;
            appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance59.BackGradientAlignment = GradientAlignment.Element;
            appearance59.BackGradientStyle = GradientStyle.Horizontal;
            appearance59.BorderColor = System.Drawing.SystemColors.Window;
            this.mt.DisplayLayout.Override.GroupByRowAppearance = appearance59;
            appearance60.TextHAlignAsString = "Left";
            this.mt.DisplayLayout.Override.HeaderAppearance = appearance60;
            this.mt.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.mt.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance61.BackColor = System.Drawing.SystemColors.Window;
            appearance61.BorderColor = Color.Silver;
            this.mt.DisplayLayout.Override.RowAppearance = appearance61;
            this.mt.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance62.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mt.DisplayLayout.Override.TemplateAddRowAppearance = appearance62;
            this.mt.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.mt.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.mt.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.mt.DisplayMember = "IDMJESTOTROSKA";
            this.mt.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.mt.Location = new System.Drawing.Point(0x92, 0x1c);
            this.mt.Name = "mt";
            this.mt.AllowNull = DefaultableBoolean.True;
            this.mt.Size = new System.Drawing.Size(0x74, 0x16);
            this.mt.TabIndex = 3;
            this.mt.Tag = "";
            this.mt.ValueMember = "IDMJESTOTROSKA";
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet1.Locale = new CultureInfo("hr-HR");
            this.dodatuma.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.dodatuma.Location = new System.Drawing.Point(0x92, 0x98);
            this.dodatuma.Name = "dodatuma";
            this.dodatuma.PromptChar = ' ';
            this.dodatuma.Size = new System.Drawing.Size(0x74, 0x15);
            this.dodatuma.TabIndex = 13;
            this.oddatuma.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.oddatuma.Location = new System.Drawing.Point(0x92, 0x80);
            this.oddatuma.Name = "oddatuma";
            this.oddatuma.PromptChar = ' ';
            this.oddatuma.Size = new System.Drawing.Size(0x74, 0x15);
            this.oddatuma.TabIndex = 11;
            this.Label5.BackColor = Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label5.Location = new System.Drawing.Point(10, 8);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(130, 0x16);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Organizacijska jedinica:";
            this.Label5.TextAlign = ContentAlignment.MiddleLeft;
            this.Label6.BackColor = Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label6.Location = new System.Drawing.Point(10, 0x1c);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(0x86, 0x16);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Mjesto troška:";
            this.Label6.TextAlign = ContentAlignment.MiddleLeft;
            this.Label1.BackColor = Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label1.Location = new System.Drawing.Point(10, 0x37);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0x86, 0x16);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Vrsta dokumenta:";
            this.Label1.TextAlign = ContentAlignment.MiddleLeft;
            this.Label2.BackColor = Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label2.Location = new System.Drawing.Point(10, 0x4e);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0x86, 0x16);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Od konta:";
            this.Label2.TextAlign = ContentAlignment.MiddleLeft;
            this.Label3.BackColor = Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label3.Location = new System.Drawing.Point(10, 0x66);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(0x86, 0x16);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Do konta:";
            this.Label3.TextAlign = ContentAlignment.MiddleLeft;
            this.Label4.BackColor = Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label4.Location = new System.Drawing.Point(10, 0x80);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(0x86, 0x15);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Od datuma:";
            this.Label4.TextAlign = ContentAlignment.MiddleLeft;
            this.Label7.BackColor = Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label7.Location = new System.Drawing.Point(10, 0x98);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(0x86, 0x15);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "Do datuma:";
            this.Label7.TextAlign = ContentAlignment.MiddleLeft;
            this.SqlConnection1.ConnectionString = "workstation id=vuger;packet size=4096;integrated security=SSPI;data source=CRYSTAL;persist security info=False;initial catalog=VGFIN2005";
            this.SqlConnection1.FireInfoMessageEventOnUserErrors = false;
            this.ErrorProvider1.ContainerControl = this;
            pane.Control = this.UltraGroupBox1;
            Rectangle rectangle = new Rectangle(4, 30, 0x25c, 0xc4);
            pane.OriginalControlBounds = rectangle;
            pane.Settings.AllowClose = DefaultableBoolean.False;
            pane.Size = new System.Drawing.Size(100, 100);
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            pane2.Size = new System.Drawing.Size(0x318, 0xc7);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft.Name = "_frmDnevnikKnjizenjaUnpinnedTabAreaLeft";
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x214);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft.TabIndex = 0x6a;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x318, 0);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight.Name = "_frmDnevnikKnjizenjaUnpinnedTabAreaRight";
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x214);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaRight.TabIndex = 0x6b;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop.Name = "_frmDnevnikKnjizenjaUnpinnedTabAreaTop";
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x318, 0);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaTop.TabIndex = 0x6c;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x214);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom.Name = "_frmDnevnikKnjizenjaUnpinnedTabAreaBottom";
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x318, 0);
            this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom.TabIndex = 0x6d;
            this._frmDnevnikKnjizenjaAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmDnevnikKnjizenjaAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmDnevnikKnjizenjaAutoHideControl.Name = "_frmDnevnikKnjizenjaAutoHideControl";
            this._frmDnevnikKnjizenjaAutoHideControl.Owner = this.UltraDockManager1;
            this._frmDnevnikKnjizenjaAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._frmDnevnikKnjizenjaAutoHideControl.TabIndex = 110;
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(0x318, 0xcc);
            this.WindowDockingArea2.TabIndex = 0x70;
            this.DockableWindow2.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(0x318, 0xc7);
            this.DockableWindow2.TabIndex = 0x72;
            this.ctlReportViewer.ActiveViewIndex = -1;
            this.ctlReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlReportViewer.Cursor = Cursors.Arrow;
            this.ctlReportViewer.DisplayBackgroundEdge = false;
            this.ctlReportViewer.Dock = DockStyle.Fill;
            this.ctlReportViewer.Location = new System.Drawing.Point(0, 0xcc);
            this.ctlReportViewer.Name = "ctlReportViewer";
            this.ctlReportViewer.Size = new System.Drawing.Size(0x318, 0x148);
            this.ctlReportViewer.TabIndex = 0x71;
            this.ctlReportViewer.ToolPanelView = 0;
            this.Controls.Add(this._frmDnevnikKnjizenjaAutoHideControl);
            this.Controls.Add(this.ctlReportViewer);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this._frmDnevnikKnjizenjaUnpinnedTabAreaTop);
            this.Controls.Add(this._frmDnevnikKnjizenjaUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmDnevnikKnjizenjaUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmDnevnikKnjizenjaUnpinnedTabAreaRight);
            this.Name = "DnevnikKnjizenjaSmartpart";
            this.Size = new System.Drawing.Size(0x318, 0x214);


            this.vd.BeforeDropDown += new CancelEventHandler(this.vd_BeforeDropDown);
            this.oj.BeforeDropDown += new CancelEventHandler(this.oj_BeforeDropDown);
            this.od_konta.BeforeDropDown += new CancelEventHandler(this.od_konta_BeforeDropDown);
            this.mt.BeforeDropDown += new CancelEventHandler(this.mt_BeforeDropDown);
            this.do_konta.BeforeDropDown += new CancelEventHandler(this.do_konta_BeforeDropDown);


            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.vd).EndInit();
            this.DokumentDataSet1.EndInit();
            ((ISupportInitialize) this.do_konta).EndInit();
            this.KontoDataSet1.EndInit();
            ((ISupportInitialize) this.od_konta).EndInit();
            ((ISupportInitialize) this.oj).EndInit();
            this.OrgjedDataSet1.EndInit();
            ((ISupportInitialize) this.mt).EndInit();
            this.MjestotroskaDataSet1.EndInit();
            ((ISupportInitialize) this.dodatuma).EndInit();
            ((ISupportInitialize) this.oddatuma).EndInit();
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
                Title = "Pregled izvještaja - Dnevnik knjiženja glavne knjige!",
                Description = "Pregled izvještaja - Dnevnik knjiženja glavne knjige!",
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

        private void mt_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.MjestotroskaDataSet1.MJESTOTROSKA.Rows.Count == 0)
            {
                new MJESTOTROSKADataAdapter().Fill(this.MjestotroskaDataSet1);
            }
        }

        private void od_konta_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.KontoDataSet1.KONTO.Rows.Count == 0)
            {
                new KONTODataAdapter().Fill(this.KontoDataSet1);
            }
        }

        private void oj_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ORGJEDDataAdapter adapter = new ORGJEDDataAdapter();
            if (this.OrgjedDataSet1.ORGJED.Rows.Count == 0)
            {
                adapter.Fill(this.OrgjedDataSet1);
            }
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

        private void vd_BeforeDropDown(object sender, CancelEventArgs e)
        {
            DOKUMENTDataAdapter adapter = new DOKUMENTDataAdapter();
            if (this.DokumentDataSet1.DOKUMENT.Rows.Count == 0)
            {
                adapter.Fill(this.DokumentDataSet1);
            }
        }

        private AutoHideControl _frmDnevnikKnjizenjaAutoHideControl;

        private UnpinnedTabArea _frmDnevnikKnjizenjaUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmDnevnikKnjizenjaUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmDnevnikKnjizenjaUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmDnevnikKnjizenjaUnpinnedTabAreaTop;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private CrystalReportViewer ctlReportViewer;

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

        private UltraCombo do_konta;

        private DockableWindow DockableWindow2;

        private UltraDateTimeEditor dodatuma;

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

        private UltraCombo mt;

        private UltraCombo od_konta;

        private UltraDateTimeEditor oddatuma;

        private UltraCombo oj;

        internal ORGJEDDataSet OrgjedDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private SqlConnection SqlConnection1;

        private UltraDockManager UltraDockManager1;

        private UltraGroupBox UltraGroupBox1;

        private UltraCombo vd;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

