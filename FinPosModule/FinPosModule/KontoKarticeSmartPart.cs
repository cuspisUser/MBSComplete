using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Evolve.Wpf.Samples;
using FinPosModule.Pregledi;
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
    public class KontoKarticeSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private S_FIN_KONTO_KARTICEDataAdapter daKartice;
        private S_FIN_KONTO_KARTICEDataSet dsKartice;
        private SmartPartInfoProvider infoProvider;
        
        private DateTime POCETNI;
        private ReportDocument rpt;
        private SmartPartInfo smartPartInfo1;
        private DateTime ZAVRSNI;

        public KontoKarticeSmartPart()
        {
            base.Load += new EventHandler(this.KontoKarticeSmartPart_Load);
            this.daKartice = new S_FIN_KONTO_KARTICEDataAdapter();
            this.dsKartice = new S_FIN_KONTO_KARTICEDataSet();
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Izvještaji-GK konto kartice", "Izvještaji-GK konto kartice");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void BackgroundUpdate()
        {
            new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen, DialogText = "Pripremam izvještaj konto kartice!", IsCancellingEnabled = false, AutoIncrementInterval = 150 }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelled));
        }

        private void cmboIDdok_BeforeDropDown(object sender, CancelEventArgs e)
        {
            DataRowCollection rows = this.DokumentDataSet1.DOKUMENT.Rows;
            DOKUMENTDataAdapter adapter = new DOKUMENTDataAdapter();
            if (rows.Count == 0)
            {
                adapter.Fill(this.DokumentDataSet1);
            }
            rows = null;
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

        private void cmboIDOJ_BeforeDropDown(object sender, CancelEventArgs e)
        {
            DataRowCollection rows = this.OrgjedDataSet1.ORGJED.Rows;
            ORGJEDDataAdapter adapter = new ORGJEDDataAdapter();
            if (rows.Count == 0)
            {
                adapter.Fill(this.OrgjedDataSet1);
            }
            rows = null;
        }

        private void CountUntilCancelled(object sender, DoWorkEventArgs e)
        {
            try
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                string str = string.Empty;
                string str2 = string.Empty;
                if (!this.dtOdDatuma.IsDateValid)
                {
                    this.dtOdDatuma.Value = mipsed.application.framework.Application.Pocetni;
                }
                if (!this.dtDoDatuma.IsDateValid)
                {
                    this.dtDoDatuma.Value = mipsed.application.framework.Application.Zavrsni;
                }
                if (this.cmboIDOJ.SelectedRow != null)
                {
                    num3 = Conversions.ToInteger(this.cmboIDOJ.Value);
                }
                else
                {
                    num3 = -1;
                }
                if (this.cmboIDMT.SelectedRow != null)
                {
                    num2 = Conversions.ToInteger(this.cmboIDMT.Value);
                }
                else
                {
                    num2 = -1;
                }
                if (this.cmboIDdok.SelectedRow != null)
                {
                    num = Conversions.ToInteger(this.cmboIDdok.Value);
                }
                else
                {
                    num = -1;
                }
                DateTime rAZDOBLJEOD = Conversions.ToDate(this.dtOdDatuma.Value);
                DateTime rAZDOBLJEDO = Conversions.ToDate(this.dtDoDatuma.Value);
                if (this.cmboIDkontopocetni.SelectedRow != null)
                {
                    str = Conversions.ToString(this.cmboIDkontopocetni.Value);
                }
                else
                {
                    str = " ";
                }
                if (this.cmboIDkontozavrsni.SelectedRow != null)
                {
                    str2 = Conversions.ToString(this.cmboIDkontozavrsni.Value);
                }
                else
                {
                    str2 = " ";
                }
                this.dsKartice.Clear();
                try
                {
                    this.daKartice.Fill(this.dsKartice, num3, Conversions.ToString(num2), num, rAZDOBLJEOD, rAZDOBLJEDO, str, str2);
                }
                catch (SqlException exception1)
                {
                    throw exception1;
                    //SqlException exception = exception1;
                    
                    
                }
                if (this.grpMT.Checked)
                {
                    this.rpt = new ReportDocument();
                    this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptKontoKarticePoMT.rpt");
                }
                else
                {
                    this.rpt = new ReportDocument();
                    this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptKontoKartice.rpt");
                }
                if (this.CheckBox1.Checked)
                {
                    this.rpt.ReportDefinition.Sections[6].SectionFormat.EnableNewPageAfter = true;
                }
                else
                {
                    this.rpt.ReportDefinition.Sections[6].SectionFormat.EnableNewPageAfter = false;
                }

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                this.rpt.SetDataSource(this.dsKartice);
                this.rpt.SetParameterValue("NASLOV", "Kartice analititičkih konta glavne knjige za razdoblje od: " + Conversions.ToString(this.dtOdDatuma.Value) + " " + Conversions.ToString(this.dtDoDatuma.Value));
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref this.rpt);

                this.rpt.SetParameterValue("@ORG", num3);
                this.rpt.SetParameterValue("@MT", num2);
                this.rpt.SetParameterValue("@DOK", num);
                this.rpt.SetParameterValue("@RAZDOBLJEOD", rAZDOBLJEOD);
                this.rpt.SetParameterValue("@RAZDOBLJEDO", rAZDOBLJEDO);
                this.rpt.SetParameterValue("@POCETNIKONTO", str);
                this.rpt.SetParameterValue("@ZAVRSNIKONTO", str2);
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ORGJED", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oj");
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DOKUMENT", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTIPDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVTIPDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PS");
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton3 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton4 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton5 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MJESTOTROSKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mt");
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
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("d0afea92-e55a-406c-a4bb-439cd4d46eea"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("d56a799c-5c6d-4957-8266-c493fa1be62d"), new System.Guid("b502bd7e-9b89-4539-ab06-4949bfa26489"), 0, new System.Guid("d0afea92-e55a-406c-a4bb-439cd4d46eea"), 0);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("b502bd7e-9b89-4539-ab06-4949bfa26489"));
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmboIDOJ = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.Label5 = new System.Windows.Forms.Label();
            this.cmboIDdok = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.DokumentDataSet1 = new Placa.DOKUMENTDataSet();
            this.cmboIDkontozavrsni = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.cmboIDkontopocetni = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cmboIDMT = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.MjestotroskaDataSet1 = new Placa.MJESTOTROSKADataSet();
            this.dtDoDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dtOdDatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.grpMT = new System.Windows.Forms.CheckBox();
            this.ErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmKontoKarticeUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKontoKarticeUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKontoKarticeUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKontoKarticeUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmKontoKarticeAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.RPV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDOJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDdok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DokumentDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontozavrsni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontopocetni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDoDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOdDatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.cmboIDOJ);
            this.UltraGroupBox1.Controls.Add(this.Label5);
            this.UltraGroupBox1.Controls.Add(this.cmboIDdok);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontozavrsni);
            this.UltraGroupBox1.Controls.Add(this.cmboIDkontopocetni);
            this.UltraGroupBox1.Controls.Add(this.cmboIDMT);
            this.UltraGroupBox1.Controls.Add(this.dtDoDatuma);
            this.UltraGroupBox1.Controls.Add(this.dtOdDatuma);
            this.UltraGroupBox1.Controls.Add(this.Label6);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.Label4);
            this.UltraGroupBox1.Controls.Add(this.Label7);
            this.UltraGroupBox1.Controls.Add(this.CheckBox1);
            this.UltraGroupBox1.Controls.Add(this.grpMT);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(792, 216);
            this.UltraGroupBox1.TabIndex = 0;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cmboIDOJ
            // 
            this.cmboIDOJ.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboIDOJ.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance31.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance31;
            editorButton1.Text = "...";
            this.cmboIDOJ.ButtonsRight.Add(editorButton1);
            this.cmboIDOJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDOJ.DataMember = "ORGJED";
            this.cmboIDOJ.DataSource = this.OrgjedDataSet1;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDOJ.DisplayLayout.Appearance = appearance42;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 65;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 150;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.cmboIDOJ.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmboIDOJ.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDOJ.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.GroupByBox.Appearance = appearance53;
            appearance63.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BandLabelAppearance = appearance63;
            this.cmboIDOJ.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance64.BackColor2 = System.Drawing.SystemColors.Control;
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance64.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDOJ.DisplayLayout.GroupByBox.PromptAppearance = appearance64;
            this.cmboIDOJ.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDOJ.DisplayLayout.MaxRowScrollRegions = 1;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            appearance65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveCellAppearance = appearance65;
            appearance.BackColor = System.Drawing.SystemColors.Highlight;
            appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDOJ.DisplayLayout.Override.ActiveRowAppearance = appearance;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDOJ.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDOJ.DisplayLayout.Override.CellAppearance = appearance3;
            this.cmboIDOJ.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDOJ.DisplayLayout.Override.CellPadding = 0;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDOJ.DisplayLayout.Override.GroupByRowAppearance = appearance4;
            appearance5.TextHAlignAsString = "Left";
            this.cmboIDOJ.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.cmboIDOJ.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDOJ.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDOJ.DisplayLayout.Override.RowAppearance = appearance6;
            this.cmboIDOJ.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDOJ.DisplayLayout.Override.TemplateAddRowAppearance = appearance7;
            this.cmboIDOJ.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDOJ.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDOJ.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDOJ.DisplayMember = "NAZIVORGJED";
            this.cmboIDOJ.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDOJ.Location = new System.Drawing.Point(144, 12);
            this.cmboIDOJ.Name = "cmboIDOJ";
            this.cmboIDOJ.Size = new System.Drawing.Size(116, 22);
            this.cmboIDOJ.TabIndex = 1;
            this.cmboIDOJ.Tag = "";
            this.cmboIDOJ.UseAppStyling = false;
            this.cmboIDOJ.ValueMember = "IDORGJED";
            this.cmboIDOJ.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDOJ_BeforeDropDown);
            // 
            // OrgjedDataSet1
            // 
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            this.OrgjedDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label5.Location = new System.Drawing.Point(8, 12);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(134, 22);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Organizacijska jedinica:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmboIDdok
            // 
            this.cmboIDdok.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboIDdok.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance8.TextHAlignAsString = "Center";
            editorButton2.Appearance = appearance8;
            editorButton2.Text = "...";
            this.cmboIDdok.ButtonsRight.Add(editorButton2);
            this.cmboIDdok.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDdok.DataMember = "DOKUMENT";
            this.cmboIDdok.DataSource = this.DokumentDataSet1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDdok.DisplayLayout.Appearance = appearance9;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn4.Width = 65;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Width = 150;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.cmboIDdok.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmboIDdok.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDdok.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDdok.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.cmboIDdok.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDdok.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.cmboIDdok.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDdok.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDdok.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDdok.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.cmboIDdok.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDdok.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDdok.DisplayLayout.Override.CellAppearance = appearance16;
            this.cmboIDdok.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDdok.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDdok.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.TextHAlignAsString = "Left";
            this.cmboIDdok.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.cmboIDdok.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDdok.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDdok.DisplayLayout.Override.RowAppearance = appearance19;
            this.cmboIDdok.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDdok.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.cmboIDdok.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDdok.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDdok.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDdok.DisplayMember = "NAZIVDOKUMENT";
            this.cmboIDdok.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDdok.Location = new System.Drawing.Point(144, 60);
            this.cmboIDdok.Name = "cmboIDdok";
            this.cmboIDdok.Size = new System.Drawing.Size(116, 22);
            this.cmboIDdok.TabIndex = 5;
            this.cmboIDdok.Tag = "";
            this.cmboIDdok.UseAppStyling = false;
            this.cmboIDdok.ValueMember = "IDDOKUMENT";
            this.cmboIDdok.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDdok_BeforeDropDown);
            // 
            // DokumentDataSet1
            // 
            this.DokumentDataSet1.DataSetName = "DOKUMENTDataSet";
            this.DokumentDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // cmboIDkontozavrsni
            // 
            this.cmboIDkontozavrsni.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboIDkontozavrsni.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance21.TextHAlignAsString = "Center";
            editorButton3.Appearance = appearance21;
            editorButton3.Text = "...";
            this.cmboIDkontozavrsni.ButtonsRight.Add(editorButton3);
            this.cmboIDkontozavrsni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDkontozavrsni.DataMember = "KONTO";
            this.cmboIDkontozavrsni.DataSource = this.KontoDataSet1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontozavrsni.DisplayLayout.Appearance = appearance22;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn9.Width = 65;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 1;
            ultraGridColumn10.Width = 200;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 2;
            ultraGridColumn11.Width = 65;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 3;
            ultraGridColumn12.Width = 100;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 4;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13});
            this.cmboIDkontozavrsni.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cmboIDkontozavrsni.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDkontozavrsni.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.Appearance = appearance23;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance24;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance25.BackColor2 = System.Drawing.SystemColors.Control;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontozavrsni.DisplayLayout.GroupByBox.PromptAppearance = appearance25;
            this.cmboIDkontozavrsni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontozavrsni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveCellAppearance = appearance26;
            appearance27.BackColor = System.Drawing.SystemColors.Highlight;
            appearance27.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.ActiveRowAppearance = appearance27;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDkontozavrsni.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CardAreaAppearance = appearance28;
            appearance29.BorderColor = System.Drawing.Color.Silver;
            appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellAppearance = appearance29;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDkontozavrsni.DisplayLayout.Override.CellPadding = 0;
            appearance30.BackColor = System.Drawing.SystemColors.Control;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontozavrsni.DisplayLayout.Override.GroupByRowAppearance = appearance30;
            appearance32.TextHAlignAsString = "Left";
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDkontozavrsni.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowAppearance = appearance33;
            this.cmboIDkontozavrsni.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontozavrsni.DisplayLayout.Override.TemplateAddRowAppearance = appearance34;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDkontozavrsni.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDkontozavrsni.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontozavrsni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontozavrsni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontozavrsni.Location = new System.Drawing.Point(144, 110);
            this.cmboIDkontozavrsni.Name = "cmboIDkontozavrsni";
            this.cmboIDkontozavrsni.Size = new System.Drawing.Size(116, 22);
            this.cmboIDkontozavrsni.TabIndex = 9;
            this.cmboIDkontozavrsni.Tag = "";
            this.cmboIDkontozavrsni.UseAppStyling = false;
            this.cmboIDkontozavrsni.ValueMember = "IDKONTO";
            this.cmboIDkontozavrsni.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDkontozavrsni_BeforeDropDown);
            // 
            // KontoDataSet1
            // 
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            this.KontoDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // cmboIDkontopocetni
            // 
            this.cmboIDkontopocetni.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboIDkontopocetni.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance35.TextHAlignAsString = "Center";
            editorButton4.Appearance = appearance35;
            editorButton4.Text = "...";
            this.cmboIDkontopocetni.ButtonsRight.Add(editorButton4);
            this.cmboIDkontopocetni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDkontopocetni.DataMember = "KONTO";
            this.cmboIDkontopocetni.DataSource = this.KontoDataSet1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDkontopocetni.DisplayLayout.Appearance = appearance36;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn14.Width = 65;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn15.Width = 200;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn16.Width = 65;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 3;
            ultraGridColumn17.Width = 100;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 4;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18});
            this.cmboIDkontopocetni.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.cmboIDkontopocetni.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDkontopocetni.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance37.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.Appearance = appearance37;
            appearance38.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BandLabelAppearance = appearance38;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance39.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance39.BackColor2 = System.Drawing.SystemColors.Control;
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance39.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDkontopocetni.DisplayLayout.GroupByBox.PromptAppearance = appearance39;
            this.cmboIDkontopocetni.DisplayLayout.MaxColScrollRegions = 1;
            this.cmboIDkontopocetni.DisplayLayout.MaxRowScrollRegions = 1;
            appearance40.BackColor = System.Drawing.SystemColors.Window;
            appearance40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveCellAppearance = appearance40;
            appearance41.BackColor = System.Drawing.SystemColors.Highlight;
            appearance41.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmboIDkontopocetni.DisplayLayout.Override.ActiveRowAppearance = appearance41;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDkontopocetni.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.CardAreaAppearance = appearance43;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellAppearance = appearance44;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDkontopocetni.DisplayLayout.Override.CellPadding = 0;
            appearance45.BackColor = System.Drawing.SystemColors.Control;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDkontopocetni.DisplayLayout.Override.GroupByRowAppearance = appearance45;
            appearance46.TextHAlignAsString = "Left";
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderAppearance = appearance46;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDkontopocetni.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowAppearance = appearance47;
            this.cmboIDkontopocetni.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDkontopocetni.DisplayLayout.Override.TemplateAddRowAppearance = appearance48;
            this.cmboIDkontopocetni.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDkontopocetni.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDkontopocetni.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDkontopocetni.DisplayMember = "NAZIVKONTO";
            this.cmboIDkontopocetni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDkontopocetni.Location = new System.Drawing.Point(144, 86);
            this.cmboIDkontopocetni.Name = "cmboIDkontopocetni";
            this.cmboIDkontopocetni.Size = new System.Drawing.Size(116, 22);
            this.cmboIDkontopocetni.TabIndex = 7;
            this.cmboIDkontopocetni.Tag = "";
            this.cmboIDkontopocetni.UseAppStyling = false;
            this.cmboIDkontopocetni.ValueMember = "IDKONTO";
            this.cmboIDkontopocetni.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmboIDkontopocetni_BeforeDropDown);
            // 
            // cmboIDMT
            // 
            this.cmboIDMT.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.cmboIDMT.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance49.TextHAlignAsString = "Center";
            editorButton5.Appearance = appearance49;
            editorButton5.Text = "...";
            this.cmboIDMT.ButtonsRight.Add(editorButton5);
            this.cmboIDMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmboIDMT.DataMember = "MJESTOTROSKA";
            this.cmboIDMT.DataSource = this.MjestotroskaDataSet1;
            appearance50.BackColor = System.Drawing.SystemColors.Window;
            appearance50.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmboIDMT.DisplayLayout.Appearance = appearance50;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 0;
            ultraGridColumn19.Width = 65;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridColumn20.Width = 150;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21});
            this.cmboIDMT.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.cmboIDMT.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmboIDMT.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance51.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance51.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.GroupByBox.Appearance = appearance51;
            appearance52.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cmboIDMT.DisplayLayout.GroupByBox.BandLabelAppearance = appearance52;
            this.cmboIDMT.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance54.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance54.BackColor2 = System.Drawing.SystemColors.Control;
            appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
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
            this.cmboIDMT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cmboIDMT.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance57.BackColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.CardAreaAppearance = appearance57;
            appearance58.BorderColor = System.Drawing.Color.Silver;
            appearance58.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cmboIDMT.DisplayLayout.Override.CellAppearance = appearance58;
            this.cmboIDMT.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cmboIDMT.DisplayLayout.Override.CellPadding = 0;
            appearance59.BackColor = System.Drawing.SystemColors.Control;
            appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance59.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance59.BorderColor = System.Drawing.SystemColors.Window;
            this.cmboIDMT.DisplayLayout.Override.GroupByRowAppearance = appearance59;
            appearance60.TextHAlignAsString = "Left";
            this.cmboIDMT.DisplayLayout.Override.HeaderAppearance = appearance60;
            this.cmboIDMT.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmboIDMT.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance61.BackColor = System.Drawing.SystemColors.Window;
            appearance61.BorderColor = System.Drawing.Color.Silver;
            this.cmboIDMT.DisplayLayout.Override.RowAppearance = appearance61;
            this.cmboIDMT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance62.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboIDMT.DisplayLayout.Override.TemplateAddRowAppearance = appearance62;
            this.cmboIDMT.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmboIDMT.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmboIDMT.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmboIDMT.DisplayMember = "NAZIVMJESTOTROSKA";
            this.cmboIDMT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmboIDMT.Location = new System.Drawing.Point(144, 36);
            this.cmboIDMT.Name = "cmboIDMT";
            this.cmboIDMT.Size = new System.Drawing.Size(116, 22);
            this.cmboIDMT.TabIndex = 3;
            this.cmboIDMT.Tag = "";
            this.cmboIDMT.UseAppStyling = false;
            this.cmboIDMT.ValueMember = "IDMJESTOTROSKA";
            this.cmboIDMT.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.Textbox2_BeforeDropDown);
            // 
            // MjestotroskaDataSet1
            // 
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // dtDoDatuma
            // 
            this.dtDoDatuma.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this.dtDoDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dtDoDatuma.Location = new System.Drawing.Point(144, 160);
            this.dtDoDatuma.Name = "dtDoDatuma";
            this.dtDoDatuma.PromptChar = ' ';
            this.dtDoDatuma.Size = new System.Drawing.Size(116, 21);
            this.dtDoDatuma.TabIndex = 13;
            this.dtDoDatuma.UseAppStyling = false;
            // 
            // dtOdDatuma
            // 
            this.dtOdDatuma.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this.dtOdDatuma.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dtOdDatuma.Location = new System.Drawing.Point(144, 136);
            this.dtOdDatuma.Name = "dtOdDatuma";
            this.dtOdDatuma.PromptChar = ' ';
            this.dtOdDatuma.Size = new System.Drawing.Size(116, 21);
            this.dtOdDatuma.TabIndex = 11;
            this.dtOdDatuma.UseAppStyling = false;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label6.Location = new System.Drawing.Point(8, 36);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(134, 22);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Mjesto troška:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label1.Location = new System.Drawing.Point(8, 60);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(134, 22);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Vrsta dokumenta:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label2.Location = new System.Drawing.Point(8, 86);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(134, 22);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Od konta:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label3.Location = new System.Drawing.Point(8, 110);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(134, 22);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Do konta:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label4.Location = new System.Drawing.Point(8, 136);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(134, 21);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Od datuma:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label7.Location = new System.Drawing.Point(8, 160);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(134, 21);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "Do datuma:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBox1
            // 
            this.CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBox1.Location = new System.Drawing.Point(8, 188);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(226, 24);
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.Text = "Nova stranica za svaki konto";
            this.CheckBox1.UseVisualStyleBackColor = false;
            // 
            // grpMT
            // 
            this.grpMT.BackColor = System.Drawing.Color.Transparent;
            this.grpMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grpMT.Location = new System.Drawing.Point(240, 188);
            this.grpMT.Name = "grpMT";
            this.grpMT.Size = new System.Drawing.Size(324, 24);
            this.grpMT.TabIndex = 15;
            this.grpMT.Text = "Grupiranje podataka po mjestima troška";
            this.grpMT.UseVisualStyleBackColor = false;
            // 
            // ErrorProvider1
            // 
            this.ErrorProvider1.ContainerControl = this;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("b502bd7e-9b89-4539-ab06-4949bfa26489");
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(2, 2, 672, 246);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(792, 234);
            dockAreaPane2.FloatingLocation = new System.Drawing.Point(22, 29);
            dockAreaPane2.Size = new System.Drawing.Size(622, 234);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _frmKontoKarticeUnpinnedTabAreaLeft
            // 
            this._frmKontoKarticeUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmKontoKarticeUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKontoKarticeUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmKontoKarticeUnpinnedTabAreaLeft.Name = "_frmKontoKarticeUnpinnedTabAreaLeft";
            this._frmKontoKarticeUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmKontoKarticeUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 618);
            this._frmKontoKarticeUnpinnedTabAreaLeft.TabIndex = 1;
            // 
            // _frmKontoKarticeUnpinnedTabAreaRight
            // 
            this._frmKontoKarticeUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmKontoKarticeUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKontoKarticeUnpinnedTabAreaRight.Location = new System.Drawing.Point(792, 0);
            this._frmKontoKarticeUnpinnedTabAreaRight.Name = "_frmKontoKarticeUnpinnedTabAreaRight";
            this._frmKontoKarticeUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmKontoKarticeUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 618);
            this._frmKontoKarticeUnpinnedTabAreaRight.TabIndex = 2;
            // 
            // _frmKontoKarticeUnpinnedTabAreaTop
            // 
            this._frmKontoKarticeUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmKontoKarticeUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKontoKarticeUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmKontoKarticeUnpinnedTabAreaTop.Name = "_frmKontoKarticeUnpinnedTabAreaTop";
            this._frmKontoKarticeUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmKontoKarticeUnpinnedTabAreaTop.Size = new System.Drawing.Size(792, 0);
            this._frmKontoKarticeUnpinnedTabAreaTop.TabIndex = 3;
            // 
            // _frmKontoKarticeUnpinnedTabAreaBottom
            // 
            this._frmKontoKarticeUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmKontoKarticeUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKontoKarticeUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 618);
            this._frmKontoKarticeUnpinnedTabAreaBottom.Name = "_frmKontoKarticeUnpinnedTabAreaBottom";
            this._frmKontoKarticeUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmKontoKarticeUnpinnedTabAreaBottom.Size = new System.Drawing.Size(792, 0);
            this._frmKontoKarticeUnpinnedTabAreaBottom.TabIndex = 4;
            // 
            // _frmKontoKarticeAutoHideControl
            // 
            this._frmKontoKarticeAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmKontoKarticeAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmKontoKarticeAutoHideControl.Name = "_frmKontoKarticeAutoHideControl";
            this._frmKontoKarticeAutoHideControl.Owner = this.UltraDockManager1;
            this._frmKontoKarticeAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._frmKontoKarticeAutoHideControl.TabIndex = 5;
            // 
            // RPV
            // 
            this.RPV.ActiveViewIndex = -1;
            this.RPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPV.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPV.DisplayBackgroundEdge = false;
            this.RPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPV.Location = new System.Drawing.Point(0, 239);
            this.RPV.Name = "RPV";
            this.RPV.Size = new System.Drawing.Size(792, 379);
            this.RPV.TabIndex = 112;
            this.RPV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(792, 239);
            this.WindowDockingArea1.TabIndex = 113;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(792, 234);
            this.DockableWindow1.TabIndex = 114;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(4, 4);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(622, 234);
            this.WindowDockingArea2.TabIndex = 0;
            // 
            // KontoKarticeSmartPart
            // 
            this.Controls.Add(this._frmKontoKarticeAutoHideControl);
            this.Controls.Add(this.RPV);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._frmKontoKarticeUnpinnedTabAreaTop);
            this.Controls.Add(this._frmKontoKarticeUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmKontoKarticeUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmKontoKarticeUnpinnedTabAreaRight);
            this.Name = "KontoKarticeSmartPart";
            this.Size = new System.Drawing.Size(792, 618);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDOJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDdok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DokumentDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontozavrsni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDkontopocetni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboIDMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDoDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOdDatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void Ispisi()
        {
            this.BackgroundUpdate();
            frmPregledKontoKartica kartica = new frmPregledKontoKartica {
                ds = this.dsKartice
            };
            if (kartica.ShowDialog() == DialogResult.OK)
            {
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Kartice analitičkih konta glavne knjige!",
                    Description = "Pregled izvještaja - Kartice analitičkih konta glavne knjige!",
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
        }

        private void KontoKarticeSmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
            this.ZAVRSNI = mipsed.application.framework.Application.Zavrsni;
            this.dtOdDatuma.Value = this.POCETNI;
            this.dtDoDatuma.Value = this.ZAVRSNI;
            InfraCustom.InicijalizirajCombo(this.cmboIDOJ, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDMT, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDdok, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontopocetni, null);
            InfraCustom.InicijalizirajCombo(this.cmboIDkontozavrsni, null);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
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

        private void Textbox2_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (this.MjestotroskaDataSet1.MJESTOTROSKA.Rows.Count == 0)
            {
                new MJESTOTROSKADataAdapter().Fill(this.MjestotroskaDataSet1);
            }
        }

        private AutoHideControl _frmKontoKarticeAutoHideControl;

        private UnpinnedTabArea _frmKontoKarticeUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmKontoKarticeUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmKontoKarticeUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmKontoKarticeUnpinnedTabAreaTop;

        private CheckBox CheckBox1;

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

        private DockableWindow DockableWindow1;

        private DOKUMENTDataSet DokumentDataSet1;

        private UltraDateTimeEditor dtDoDatuma;

        private UltraDateTimeEditor dtOdDatuma;

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

        private CheckBox grpMT;

        private KONTODataSet KontoDataSet1;

        private Label Label1;

        private Label Label2;

        private Label Label3;

        private Label Label4;

        private Label Label5;

        private Label Label6;

        private Label Label7;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

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

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

