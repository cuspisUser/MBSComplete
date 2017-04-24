using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Deklarit.Resources;
using FinPosModule;
using Hlp;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace FinPosModule.Ira
{

    [SmartPart]
    public class IraSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        private DateTime pocetni;
        private SmartPartInfo smartPartInfo1;
        private UltraExplorerBarWorkspace work;
        private DateTime zavrsni;

        private int od_ire { get; set; }
        private int do_ire { get; set; }
        private bool oznacen { get; set; }

        public IraSmartPart()
        {
            base.Leave += new EventHandler(this.UraSmartPart_Leave);
            base.Load += new EventHandler(this.TestSmartPart_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Knjiga izlaznih računa", "Knjiga izlaznih računa");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public void Brisanje()
        {
            IRADataSet dataSet = new IRADataSet();
            IRADataAdapter adapter = new IRADataAdapter();
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.S_FIN_IRA_PLACANJEDataSet1, "S_FIN_IRA_PLACANJE"];
            if (manager.Count != 0)
            {
                if (this.UltraGrid1.ActiveRow != null)
                {
                    int index = this.UltraGrid1.ActiveRow.Index;
                }
                GKSTAVKADataAdapter adapter2 = new GKSTAVKADataAdapter();
                GKSTAVKADataSet set2 = new GKSTAVKADataSet();
                IRADataAdapter adapter3 = new IRADataAdapter();
                DataRowView current = (DataRowView) manager.Current;
                adapter2.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(set2, Conversions.ToInteger(current["IRADOKIDDOKUMENT"]), Conversions.ToInteger(current["IRABROJ"]), Conversions.ToShort(current["IRAGODIDGODINE"]));
                if (set2.GKSTAVKA.Rows.Count > 0)
                {
                    Interaction.MsgBox("IRA je kontirana u glavnoj knjizi!", MsgBoxStyle.Information, "Financijsko poslovanje");
                }
                else
                {
                    adapter.FillByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(dataSet, Conversions.ToShort(current["IRAGODIDGODINE"]), Conversions.ToInteger(current["IRADOKIDDOKUMENT"]), Conversions.ToInteger(current["IRABROJ"]));
                    DataRow row = dataSet.IRA.Rows[0];
                    this.Controller.Delete(row);
                    current.Delete();
                    this.PuniPodatke(3, Conversions.ToInteger(current["IRABROJ"]), Conversions.ToInteger(current["IRABROJ"]));
                    this.Pre_sort();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_FIN_IRA_PLACANJE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVARANJE_IZNOS");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVARANJE_DATUM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRABROJ", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTIPIRA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRAPARTNERIDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRAUKUPNO");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRAVALUTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRANAPOMENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRADATUM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRAGODIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IRADOKIDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("nazivpartner");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("partneroib");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NEPODLEZE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZVOZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MEDJTRANS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TUZEMSTVO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NULA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSTALO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSN05");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSN10");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSN22");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSN23");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSN25");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV05");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV10");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV22");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV23");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV25");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NEPODLEZE_USLUGA");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "IRAUKUPNO", 5, true, "S_FIN_IRA_PLACANJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "IRAUKUPNO", 5, true);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "ZATVARANJE_IZNOS", 0, true, "S_FIN_IRA_PLACANJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ZATVARANJE_IZNOS", 0, true);
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("b56d929b-39e7-4750-ada8-586c2c609b09"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("20f8bcb7-262e-4452-b055-13947ca15700"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("b56d929b-39e7-4750-ada8-586c2c609b09"), -1);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ToolBar1 = new System.Windows.Forms.ToolBar();
            this.ToolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.S_FIN_IRA_PLACANJEDataSet1 = new S_FIN_IRA_PLACANJEDataSet();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._TestSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_IRA_PLACANJEDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ToolBar1);
            this.Panel1.Location = new System.Drawing.Point(0, 18);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1208, 58);
            this.Panel1.TabIndex = 15;
            // 
            // ToolBar1
            // 
            this.ToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBarButton8,
            this.ToolBarButton1,
            this.ToolBarButton2,
            this.ToolBarButton4,
            this.ToolBarButton6,
            this.ToolBarButton3,
            this.ToolBarButton5,
            this.ToolBarButton7});
            this.ToolBar1.ButtonSize = new System.Drawing.Size(32, 32);
            this.ToolBar1.Divider = false;
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToolBar1.ImageList = this.ImageList1;
            this.ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ToolBar1.MinimumSize = new System.Drawing.Size(0, 60);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            this.ToolBar1.Size = new System.Drawing.Size(1208, 60);
            this.ToolBar1.TabIndex = 1;
            this.ToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
            // 
            // ToolBarButton8
            // 
            this.ToolBarButton8.ImageIndex = 4;
            this.ToolBarButton8.Name = "ToolBarButton8";
            this.ToolBarButton8.Text = "Osvježi";
            // 
            // ToolBarButton1
            // 
            this.ToolBarButton1.ImageIndex = 12;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.Text = "Dodaj";
            // 
            // ToolBarButton2
            // 
            this.ToolBarButton2.ImageIndex = 11;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.Text = "Briši";
            // 
            // ToolBarButton4
            // 
            this.ToolBarButton4.ImageIndex = 8;
            this.ToolBarButton4.Name = "ToolBarButton4";
            this.ToolBarButton4.Text = "Izmjeni";
            // 
            // ToolBarButton6
            // 
            this.ToolBarButton6.ImageKey = "printer.png";
            this.ToolBarButton6.Name = "ToolBarButton6";
            this.ToolBarButton6.Text = "Ispiši";
            // 
            // ToolBarButton3
            // 
            this.ToolBarButton3.ImageIndex = 6;
            this.ToolBarButton3.Name = "ToolBarButton3";
            this.ToolBarButton3.Text = "Proknjiži sve";
            // 
            // ToolBarButton5
            // 
            this.ToolBarButton5.ImageIndex = 4;
            this.ToolBarButton5.Name = "ToolBarButton5";
            this.ToolBarButton5.Text = "Ira - PDV";
            // 
            // ToolBarButton7
            // 
            this.ToolBarButton7.ImageIndex = 4;
            this.ToolBarButton7.Name = "ToolBarButton7";
            this.ToolBarButton7.Text = "Uvoz HZZO";
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "S_FIN_IRA_PLACANJE";
            this.UltraGrid1.DataSource = this.S_FIN_IRA_PLACANJEDataSet1;
            appearance1.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance12.TextHAlignAsString = "Right";
            ultraGridColumn1.CellAppearance = appearance12;
            ultraGridColumn1.Header.Caption = "Plaćeno";
            ultraGridColumn1.Header.VisiblePosition = 5;
            ultraGridColumn1.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn1.PromptChar = ' ';
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Width = 107;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "Datum plaćanja";
            ultraGridColumn2.Header.VisiblePosition = 6;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "Broj";
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 11;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 12;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance13.TextHAlignAsString = "Right";
            ultraGridColumn6.CellAppearance = appearance13;
            ultraGridColumn6.Format = "##,###,####0.00";
            ultraGridColumn6.Header.Caption = "Ukupno";
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.MaskInput = "{LOC} -n,nnn,nnn.nn";
            ultraGridColumn6.Width = 89;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "Valuta";
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn7.Width = 110;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "Napomena";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 306;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "Datum";
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 9;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.Caption = "Naziv partnera";
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 22;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.Width = 292;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "OIB";
            ultraGridColumn13.Header.VisiblePosition = 10;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 28;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "";
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 17;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 19;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 18;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.Caption = "OS N05";
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.Caption = "OS N10";
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.Caption = "OS N22";
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.Caption = "OS N23";
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.Caption = "OS N25";
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.Caption = "PD V05";
            ultraGridColumn26.Header.VisiblePosition = 25;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.Caption = "PD V10";
            ultraGridColumn27.Header.VisiblePosition = 26;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.Caption = "PD V22";
            ultraGridColumn28.Header.VisiblePosition = 27;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.Caption = "PD V23";
            ultraGridColumn29.Header.VisiblePosition = 28;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.Caption = "PD V25";
            ultraGridColumn30.Header.VisiblePosition = 29;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 30;
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
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31});
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance14.FontData.BoldAsString = "True";
            appearance14.TextHAlignAsString = "Right";
            summarySettings1.Appearance = appearance14;
            summarySettings1.DisplayFormat = "{0:#,##0.00}";
            summarySettings1.GroupBySummaryValueAppearance = appearance15;
            summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.Top;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance16.FontData.BoldAsString = "True";
            appearance16.TextHAlignAsString = "Right";
            summarySettings2.Appearance = appearance16;
            summarySettings2.DisplayFormat = "{0:#,##0.00}";
            summarySettings2.GroupBySummaryValueAppearance = appearance17;
            summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.Top;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2});
            ultraGridBand1.SummaryFooterCaption = "Ukupno";
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance9.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance10.BorderColor = System.Drawing.Color.LightGray;
            appearance10.FontData.BoldAsString = "True";
            appearance10.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BorderColor = System.Drawing.Color.Black;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(0, 81);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1208, 533);
            this.UltraGrid1.TabIndex = 11;
            this.UltraGrid1.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.UltraGrid1_InitializeRow);
            this.UltraGrid1.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid1_AfterRowUpdate);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // S_FIN_IRA_PLACANJEDataSet1
            // 
            this.S_FIN_IRA_PLACANJEDataSet1.DataSetName = "S_FIN_IRA_PLACANJEDataSet";
            this.S_FIN_IRA_PLACANJEDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UltraDockManager1
            // 
            dockableControlPane1.Control = this.Panel1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(3, 3, 1110, 63);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Izbornik knjiga IRA";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1208, 76);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _TestSmartPartUnpinnedTabAreaLeft
            // 
            this._TestSmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._TestSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartUnpinnedTabAreaLeft.Name = "_TestSmartPartUnpinnedTabAreaLeft";
            this._TestSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 614);
            this._TestSmartPartUnpinnedTabAreaLeft.TabIndex = 16;
            // 
            // _TestSmartPartUnpinnedTabAreaRight
            // 
            this._TestSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._TestSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1208, 0);
            this._TestSmartPartUnpinnedTabAreaRight.Name = "_TestSmartPartUnpinnedTabAreaRight";
            this._TestSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 614);
            this._TestSmartPartUnpinnedTabAreaRight.TabIndex = 17;
            // 
            // _TestSmartPartUnpinnedTabAreaTop
            // 
            this._TestSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._TestSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartUnpinnedTabAreaTop.Name = "_TestSmartPartUnpinnedTabAreaTop";
            this._TestSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1208, 0);
            this._TestSmartPartUnpinnedTabAreaTop.TabIndex = 18;
            // 
            // _TestSmartPartUnpinnedTabAreaBottom
            // 
            this._TestSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._TestSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 614);
            this._TestSmartPartUnpinnedTabAreaBottom.Name = "_TestSmartPartUnpinnedTabAreaBottom";
            this._TestSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1208, 0);
            this._TestSmartPartUnpinnedTabAreaBottom.TabIndex = 19;
            // 
            // _TestSmartPartAutoHideControl
            // 
            this._TestSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartAutoHideControl.Name = "_TestSmartPartAutoHideControl";
            this._TestSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._TestSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 614);
            this._TestSmartPartAutoHideControl.TabIndex = 20;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1208, 81);
            this.WindowDockingArea1.TabIndex = 21;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.Panel1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(1208, 76);
            this.DockableWindow1.TabIndex = 22;
            // 
            // IraSmartPart
            // 
            this.Controls.Add(this._TestSmartPartAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaRight);
            this.Name = "IraSmartPart";
            this.Size = new System.Drawing.Size(1208, 614);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_IRA_PLACANJEDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void Ispis_ira()
        {
            frmParametriFakturiranja fakturiranja = new frmParametriFakturiranja("IRA") {
                oddatuma = { Value = this.pocetni },
                dodatuma = { Value = this.zavrsni },
                uneOdURE = { Value = this.od_ire },
                uneDoURE = { Value = this.do_ire },
                rbrDatum = { Checked = true }
            };
            if (fakturiranja.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;

                    if (fakturiranja.rbrDatum.Checked)
                    {
                        command.CommandText = "S_FIN_IRA_PLACANJE";

                        command.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(fakturiranja.oddatuma.Value));
                        command.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(fakturiranja.dodatuma.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", 3);
                    }
                    else
                    {
                        command.CommandText = "S_FIN_IRA_PLACANJEPoBroju";

                        command.Parameters.AddWithValue("@od", RuntimeHelpers.GetObjectValue(fakturiranja.uneOdURE.Value));
                        command.Parameters.AddWithValue("@doo", RuntimeHelpers.GetObjectValue(fakturiranja.uneDoURE.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", 3);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter {
                        SelectCommand = command
                    };
                    SqlConnection connection = new SqlConnection {
                        ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                    };
                    adapter.SelectCommand.Connection = connection;
                    S_FIN_IRA_PLACANJEDataSet dataSet = new S_FIN_IRA_PLACANJEDataSet();
                    adapter.Fill(dataSet, "S_FIN_IRA_PLACANJE");

                    //10.02.2015 nepalceni
                    S_FIN_IRA_PLACANJEDataSet set2 = new S_FIN_IRA_PLACANJEDataSet();
                    if (fakturiranja.CheckBox1.Checked)
                    {
                        foreach (DataRow row2 in dataSet.S_FIN_IRA_PLACANJE.Select("IRAUKUPNO - ZATVARANJE_IZNOS <> 0"))
                        {
                            set2.S_FIN_IRA_PLACANJE.ImportRow(row2);
                        }
                    }
                    //09.03.15 ispis placenih
                    else if (fakturiranja.cbkPlaceni.Checked)
                    {
                        foreach (DataRow row3 in dataSet.S_FIN_IRA_PLACANJE.Select("IRAUKUPNO - ZATVARANJE_IZNOS = 0"))
                        {
                            set2.S_FIN_IRA_PLACANJE.ImportRow(row3);
                        }
                    }
                    else
                    {
                        foreach (DataRow row3 in dataSet.S_FIN_IRA_PLACANJE.Select(""))
                        {
                            set2.S_FIN_IRA_PLACANJE.ImportRow(row3);
                        }
                    }

                    ReportDocument rpt = new ReportDocument();
                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja",
                        Description = "Pregled",
                        Icon = ImageResourcesNew.mbs
                    };
                    rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\knjigairaproracun.rpt");

                    string str = string.Empty;
                    if (fakturiranja.rbrDatum.Checked)
                    {
                        str = "Knjiga izdanih računa za razdoblje: " + Conversions.ToString(fakturiranja.oddatuma.Value) + " - " + Conversions.ToString(fakturiranja.dodatuma.Value);
                    }
                    else
                    {
                        str = "Knjiga izdanih računa od broja: " + Conversions.ToString(fakturiranja.uneOdURE.Value) + " do broja " + Conversions.ToString(fakturiranja.uneDoURE.Value);
                    }
                    
                    //10.02.2015
                    //rpt.SetDataSource(dataSet);
                    rpt.SetDataSource(set2);

                    rpt.SetParameterValue("NASLOV", str);
                    mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref rpt);
                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Show(item.Workspaces["main"], info);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                this.Cursor = Cursors.Default;
            }
        }

        public void Ispis_ira_pdv()
        {
            frmParametriFakturiranja fakturiranja = new frmParametriFakturiranja("IRA") {
                oddatuma = { Value = this.pocetni },
                dodatuma = { Value = this.zavrsni },
                uneOdURE = { Value = this.od_ire },
                uneDoURE = { Value = this.do_ire },
                rbrDatum = { Checked = true }
            };
            if (fakturiranja.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;

                    if (fakturiranja.rbrDatum.Checked)
                    {
                        command.CommandText = "S_FIN_IRA_PLACANJE";

                        command.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(fakturiranja.oddatuma.Value));
                        command.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(fakturiranja.dodatuma.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", 3);
                    }
                    else
                    {
                        command.CommandText = "S_FIN_IRA_PLACANJEPoBroju";

                        command.Parameters.AddWithValue("@od", RuntimeHelpers.GetObjectValue(fakturiranja.uneOdURE.Value));
                        command.Parameters.AddWithValue("@doo", RuntimeHelpers.GetObjectValue(fakturiranja.uneDoURE.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", 3);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter {
                        SelectCommand = command
                    };
                    SqlConnection connection = new SqlConnection {
                        ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                    };
                    adapter.SelectCommand.Connection = connection;
                    S_FIN_IRA_PLACANJEDataSet dataSet = new S_FIN_IRA_PLACANJEDataSet();
                    adapter.Fill(dataSet, "S_FIN_IRA_PLACANJE");

                    //03.09.2015 neplaceni
                    S_FIN_IRA_PLACANJEDataSet set2 = new S_FIN_IRA_PLACANJEDataSet();
                    if (fakturiranja.CheckBox1.Checked)
                    {
                        foreach (DataRow row2 in dataSet.S_FIN_IRA_PLACANJE.Select("IRAUKUPNO - ZATVARANJE_IZNOS <> 0"))
                        {
                            set2.S_FIN_IRA_PLACANJE.ImportRow(row2);
                        }
                    }
                    //03.09.2015 placenih
                    else if (fakturiranja.cbkPlaceni.Checked)
                    {
                        foreach (DataRow row3 in dataSet.S_FIN_IRA_PLACANJE.Select("IRAUKUPNO - ZATVARANJE_IZNOS = 0"))
                        {
                            set2.S_FIN_IRA_PLACANJE.ImportRow(row3);
                        }
                    }
                    else
                    {
                        foreach (DataRow row3 in dataSet.S_FIN_IRA_PLACANJE.Select(""))
                        {
                            set2.S_FIN_IRA_PLACANJE.ImportRow(row3);
                        }
                    }

                    ReportDocument rpt = new ReportDocument();
                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja",
                        Description = "Pregled",
                        Icon = ImageResourcesNew.mbs
                    };
                    rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\knjigaira.rpt");

                    string str = string.Empty;
                    if (fakturiranja.rbrDatum.Checked)
                    {
                        str = "Knjiga izdanih računa za razdoblje: " + Conversions.ToString(fakturiranja.oddatuma.Value) + " - " + Conversions.ToString(fakturiranja.dodatuma.Value);
                    }
                    else
                    {
                        str = "Knjiga izdanih računa od broja: " + Conversions.ToString(fakturiranja.uneOdURE.Value) + " do broja " + Conversions.ToString(fakturiranja.uneDoURE.Value);
                    }

                    //03.09.2015
                    //rpt.SetDataSource(dataSet);
                    rpt.SetDataSource(set2);

                    rpt.SetParameterValue("NASLOV", str);
                    mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref rpt);
                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Show(item.Workspaces["main"], info);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                this.Cursor = Cursors.Default;
            }
        }

        public void Izmjena()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }
            IRADataSet dataSet = new IRADataSet();
            IRADataAdapter adapter = new IRADataAdapter();
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.S_FIN_IRA_PLACANJEDataSet1, "S_FIN_IRA_PLACANJE"];
            if (manager.Count != 0)
            {
                DataRowView current = (DataRowView) manager.Current;

                if (current["IRANAPOMENA"].ToString() == "Prijenos iz UF-a")
                {
                    MessageBox.Show("Nije moguće raditi izmjene na računu\n\rkoji je prenesen iz UF-a.");
                    return;
                }

                adapter.FillByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(dataSet, Conversions.ToShort(current["IRAGODIDGODINE"]), Conversions.ToInteger(current["IRADOKIDDOKUMENT"]), Conversions.ToInteger(current["IRABROJ"]));
                DataRow row = dataSet.IRA.Rows[0];
                this.Controller.Update(row);
                current.Delete();
                this.PuniPodatke(3, Conversions.ToInteger(current["IRABROJ"]), Conversions.ToInteger(current["IRABROJ"]));
                this.Pre_sort();

                if (this.UltraGrid1.Rows.Count > 0)
                {
                    this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[index];
                    this.UltraGrid1.ActiveRow.Selected = true;
                    this.UltraGrid1.Focus();
                }
            }
        }

        public void Nova()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }
            IRADataSet set = new IRADataSet();
            IRADataAdapter adapter = new IRADataAdapter();
            DataRow foreignKeys = set.IRA.NewRow();
            foreignKeys["IRAgodidgodine"] = mipsed.application.framework.Application.ActiveYear;
            foreignKeys["IRADOKIDDOKUMENT"] = 3;
            foreignKeys["IRABROJ"] = this.Slijedeci_broj_Dokumenta_IRE();
            this.Controller.Insert(foreignKeys);
            this.PuniPodatke(3, Conversions.ToInteger(foreignKeys["IRABROJ"]), Conversions.ToInteger(foreignKeys["IRABROJ"]));
            this.Pre_sort();

            try
            {
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[index];
                this.UltraGrid1.ActiveRow.Selected = true;
                this.UltraGrid1.Focus();
            }
            catch (System.Exception)
            {
                if (this.UltraGrid1.Rows.Count > 0)
                {
                    this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[(index < this.UltraGrid1.Rows.Count ? index : this.UltraGrid1.Rows.Count - 1)];
                    this.UltraGrid1.ActiveRow.Selected = true;
                    this.UltraGrid1.Focus();
                }
            }
        }

        public void Pre_sort()
        {
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["IRABROJ"].Band.SortedColumns.RefreshSort(true);
            this.UltraGrid1.Refresh();
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
                this.ParentForm.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Proknjizi_Sve_Sokumente()
        {
            IEnumerator enumerator = null;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            connection.Open();
            try
            {
                enumerator = this.S_FIN_IRA_PLACANJEDataSet1.S_FIN_IRA_PLACANJE.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if (current.RowState != DataRowState.Deleted)
                    {
                        SqlCommand command = new SqlCommand {
                            CommandType = CommandType.StoredProcedure,
                            Connection = connection,
                            CommandText = "S_FIN_PROMJENA_STATUSA"
                        };
                        command.Parameters.Add("@BROJDOKUMENTA", SqlDbType.Char, 5).Value = RuntimeHelpers.GetObjectValue(current["IRABROJ"]);
                        command.Parameters.Add("@IDDOKUMENT", SqlDbType.Char, 5).Value = RuntimeHelpers.GetObjectValue(current["IRADOKIDDOKUMENT"]);
                        command.Parameters.Add("@GODINA", SqlDbType.Int).Value = DateAndTime.Year(this.zavrsni);
                        command.Parameters.Add("@STATUSGK", SqlDbType.Bit).Value = true;
                        try
                        {
                            command.ExecuteNonQuery();
                            continue;
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                        }
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
            Interaction.MsgBox("Svi dokumenti izlaznih računa kod kojih je saldo 0, proknjiženi u glavnu knjigu", MsgBoxStyle.Information, "Radnja izvršena");
            connection.Close();
        }

        public void PuniPodatke(Nullable<int> iddokument, int od, int doo)
        {
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.StoredProcedure,
                CommandText = "S_FIN_IRA_PLACANJE"
            };
            command.Parameters.AddWithValue("@IDDOKUMENT", iddokument);
            command.Parameters.AddWithValue("@od", od);
            command.Parameters.AddWithValue("@doo", doo);
            command.Parameters.AddWithValue("@DAT1", this.pocetni);
            command.Parameters.AddWithValue("@DAT2", this.zavrsni);
            SqlDataAdapter adapter = new SqlDataAdapter {
                SelectCommand = command
            };
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            adapter.SelectCommand.Connection = connection;
            adapter.Fill(this.S_FIN_IRA_PLACANJEDataSet1, "S_FIN_IRA_PLACANJE");
        }

        private void SetSmartPartInfoInformation()
        {
            this.smartPartInfo1.Description = "test";
        }

        public int Slijedeci_broj_Dokumenta_IRE()
        {
            int num = 0;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(IRABROJ AS INTEGER)) FROM IRA WHERE IRAgodidgodine = @GODINA and IRADOKIDDOKUMENT = @iddokument"
            };
            command.Parameters.AddWithValue("@GODINA", mipsed.application.framework.Application.ActiveYear);
            command.Parameters.AddWithValue("@iddokument", 3);
            command.Connection = connection;
            connection.Open();
            try
            {
                num = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(command.ExecuteScalar())));
                num++;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }

            connection.Close();
            return num;
        }

        private void TestSmartPart_Load(object sender, EventArgs e)
        {
            S_FIN_IRA_PLACANJEDataAdapter adapter = new S_FIN_IRA_PLACANJEDataAdapter();
            this.pocetni = mipsed.application.framework.Application.Pocetni;
            this.zavrsni = mipsed.application.framework.Application.Zavrsni;
            this.PuniPodatke(null, 1, 0x1869f);
            this.work = (UltraExplorerBarWorkspace) this.Controller.WorkItem.Workspaces["TaskPanel"];
            this.Controller.WorkItem.Workspaces["Dock"].Hide(this.work);
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["IRABROJ"].SortIndicator = SortIndicator.Descending;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.FilterUIType = FilterUIType.FilterRow;
        }

        private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Name == "ToolBarButton1")
            {
                this.Nova();
            }
            if (e.Button.Name == "ToolBarButton2")
            {
                this.Brisanje();
            }
            if (e.Button.Name == "ToolBarButton4")
            {
                this.Izmjena();
            }
            if (e.Button.Name == "ToolBarButton3")
            {
                this.Proknjizi_Sve_Sokumente();
            }
            if (e.Button.Name == "ToolBarButton6")
            {
                this.Ispis_ira();
            }
            if (e.Button.Name == "ToolBarButton5")
            {
                this.Ispis_ira_pdv();
            }
            #region MBS.Complete [22.03.2016]
            if (e.Button.Name == "ToolBarButton7")
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        this.Cursor = Cursors.WaitCursor;
                        DohvatRacuna(ofd.FileName);
                        Cursor.Current = Cursors.Default;
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            if (e.Button.Name == "ToolBarButton8")
            {
                this.Cursor = Cursors.AppStarting;
                RefreshGrid();
                this.Cursor = Cursors.Default;
            }
            #endregion
        }



        #region MBS.Complete [22.03.2016]
        private void DohvatRacuna(string path)
        {
            try
            {
                string plainText = System.IO.File.ReadAllText(path, System.Text.Encoding.Default);
                string[] racuni = plainText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                List<Racun> listRacuni;
                List<PlainRacuni> listaPlain;
                string year = mipsed.application.framework.Application.ActiveYear.ToString().Substring(2);

                if (path.ToLower().EndsWith("k" + year))
                {
                    this.Cursor = Cursors.WaitCursor;
                    listaPlain = PunjenjeUStringK(racuni);
                    listRacuni = PunjenjeUModelK(listaPlain);

                    //zasad ovdje kasnije van
                    if (listRacuni.Capacity > 0)
                    {
                        if (UpisUBazu(listRacuni))
                        {
                            RefreshGrid();
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
                else if (path.ToLower().EndsWith("o" + year))
                {
                    listaPlain = PunjenjeUStringO(racuni);
                    listRacuni = PunjenjeUModelO(listaPlain);

                    //zasad ovdje kasnije van
                    if (listRacuni.Capacity > 0)
                    {
                        if (UpisUBazu(listRacuni))
                        {
                            RefreshGrid();
                        }
                    }
                }
                //jos idu privatni racuni
            }
            catch
            {
                MessageBox.Show("Dogodila se greška prilikom prijenosa računa!!!");
                this.Cursor = Cursors.Default;
            }
        }

        private List<Racun> PunjenjeUModelO(List<PlainRacuni> listaPlain)
        {
            string[] rowField;
            int godina = mipsed.application.framework.Application.ActiveYear;
            int idRacun = Slijedeci_broj_Dokumenta_IRE();

            //uzeti vrijednosti iz forme
            int idPartner = 1;
            int tipIRA = 1;
            int shemaKnjizenjaDopunsko = 1;
            int shemaKnjzenja = OdabirShemeKnjizenja(ref tipIRA, ref idPartner, ref shemaKnjizenjaDopunsko);

            List<Racun> listRacuni = new List<Racun>();
            Racun racun;

            if (shemaKnjzenja != 0)
            {
                foreach (var glave in listaPlain)
                {
                    rowField = glave.glava.Split(':');

                    if (Convert.ToDecimal(rowField[14]) == 0 && Convert.ToDecimal(rowField[40]) == 0)
                    {
                        //samo osnovno osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[4]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[4]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/samo osnovno", rowField[19], rowField[18], rowField[46]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[13].Replace('.', ','));
                        racun.SifraBIS = rowField[3];
                        racun.IznosDopunskoOsiguranje = 0;
                        racun.IznosFizickaOsoba = 0;
                        racun.shemaKnjizenja = shemaKnjzenja;
                        listRacuni.Add(racun);
                        idRacun++;
                    }
                    else if (Convert.ToDecimal(rowField[14]) > 0)
                    {
                        //osnovno osiguranje i fizicka osoba
                        //prvi racun osnovno osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[4]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[4]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/osnovno", rowField[19], rowField[18], rowField[46]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[13].Replace('.', ',')) - Convert.ToDecimal(rowField[15].Replace('.', ','));
                        racun.SifraBIS = rowField[3];
                        racun.IznosDopunskoOsiguranje = 0;
                        racun.IznosFizickaOsoba = Convert.ToDecimal(rowField[15].Replace('.', ','));
                        racun.shemaKnjizenja = shemaKnjzenja;
                        listRacuni.Add(racun);
                        idRacun++;
                        //drugi racun se ne kreira dolazi sa drugom datotekom
                    }
                    else if (Convert.ToDecimal(rowField[40]) > 0)
                    {
                        //osnovno osiguranje i dopunsko osiguranje
                        //prvi racun osnovno osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[4]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[4]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/osnovno", rowField[19], rowField[18], rowField[46]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[13].Replace('.', ',')) - Convert.ToDecimal(rowField[40].Replace('.', ','));
                        racun.SifraBIS = rowField[3];
                        racun.IznosDopunskoOsiguranje = Convert.ToDecimal(rowField[40].Replace('.', ','));
                        racun.IznosFizickaOsoba = 0;
                        racun.shemaKnjizenja = shemaKnjzenja;
                        listRacuni.Add(racun);
                        idRacun++;

                        //drugi racun dopunsko osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[4]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[4]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/dopunsko", rowField[19], rowField[18], rowField[46]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[40].Replace('.', ','));
                        racun.SifraBIS = rowField[39];
                        racun.IznosDopunskoOsiguranje = 0;
                        racun.IznosFizickaOsoba = 0;
                        racun.shemaKnjizenja = shemaKnjzenja;
                        racun.shemaKnjizenjaDopunsko = shemaKnjizenjaDopunsko;
                        listRacuni.Add(racun);
                        idRacun++;
                    }

                }
            }

            return listRacuni;
        }

        private List<PlainRacuni> PunjenjeUStringO(string[] racuni)
        {
            List<PlainRacuni> listaPlain = new List<PlainRacuni>();
            string glava = "";
            List<string> stavke = new List<string>();
            PlainRacuni plainRacun;

            foreach (string row in racuni)
            {
                if (row.StartsWith("30"))
                {
                    if (glava.Length > 0)
                    {
                        plainRacun = new PlainRacuni();
                        plainRacun.glava = glava;
                        plainRacun.stavke = stavke;
                        listaPlain.Add(plainRacun);

                        glava = "";
                        stavke = new List<string>();
                    }

                    glava = row;
                }
                else
                {
                    if (row.StartsWith("31") || row.StartsWith("32"))
                    {
                        stavke.Add(row);
                    }
                }
            }
            //posto u zadnji ne ulazi spremamo ga na kraju
            plainRacun = new PlainRacuni();
            plainRacun.glava = glava;
            plainRacun.stavke = stavke;
            listaPlain.Add(plainRacun);

            return listaPlain;
        }
        private List<Racun> PunjenjeUModelK(List<PlainRacuni> listaPlain)
        {
            string[] rowField;
            int godina = mipsed.application.framework.Application.ActiveYear;
            int idRacun = Slijedeci_broj_Dokumenta_IRE();

            //uzeti vrijednosti iz forme
            int idPartner = 1;
            int tipIRA = 1;
            int shemaKnjizenjaDopunsko = 1;
            int shemaKnjzenja = OdabirShemeKnjizenja(ref tipIRA, ref idPartner, ref shemaKnjizenjaDopunsko);

            List<Racun> listRacuni = new List<Racun>();
            Racun racun;

            if (shemaKnjzenja != 0)
            {
                foreach (var glave in listaPlain)
                {
                    rowField = glave.glava.Split(':');

                    if (Convert.ToDecimal(rowField[15]) == 0 && Convert.ToDecimal(rowField[16]) == 0)
                    {
                        //samo osnovno osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[5]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[5]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/samo osnovno", rowField[22], rowField[21], rowField[51]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[14].Replace('.', ','));
                        racun.SifraBIS = rowField[3];
                        racun.IznosDopunskoOsiguranje = 0;
                        racun.IznosFizickaOsoba = 0;
                        racun.shemaKnjizenja = shemaKnjzenja;
                        listRacuni.Add(racun);
                        idRacun++;
                    }
                    else if (Convert.ToDecimal(rowField[15]) > 0)
                    {
                        //osnovno osiguranje i fizicka osoba
                        //prvi racun osnovno osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[5]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[5]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/osnovno", rowField[22], rowField[21], rowField[51]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[14].Replace('.', ',')) - Convert.ToDecimal(rowField[15].Replace('.', ','));
                        racun.SifraBIS = rowField[3];
                        racun.IznosDopunskoOsiguranje = 0;
                        racun.IznosFizickaOsoba = Convert.ToDecimal(rowField[15].Replace('.', ','));
                        racun.shemaKnjizenja = shemaKnjzenja;
                        listRacuni.Add(racun);
                        idRacun++;
                        //drugi racun se kreira nego dolazi sa drugom datotekom
                    }
                    else if (Convert.ToDecimal(rowField[16]) > 0)
                    {
                        //osnovno osiguranje i dopunsko osiguranje
                        //prvi racun osnovno osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[5]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[5]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/osnovno", rowField[22], rowField[21], rowField[51]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[14].Replace('.', ',')) - Convert.ToDecimal(rowField[16].Replace('.', ','));
                        racun.SifraBIS = rowField[3];
                        racun.IznosDopunskoOsiguranje = Convert.ToDecimal(rowField[16].Replace('.', ','));
                        racun.IznosFizickaOsoba = 0;
                        racun.shemaKnjizenja = shemaKnjzenja;
                        listRacuni.Add(racun);
                        idRacun++;

                        //drugi racun dopunsko osiguranje
                        racun = new Racun();
                        racun.brojIRA = idRacun;
                        racun.godinaIRA = godina;
                        racun.dokumentIRA = 3;
                        racun.partnerIRA = idPartner;
                        racun.tipIRA = tipIRA;
                        racun.datumIRA = Convert.ToDateTime(rowField[5]);
                        racun.valutaIRA = Convert.ToDateTime(rowField[5]).AddDays(30);
                        //ime prezime-datum rodenja/osnovno ili dopunsko
                        racun.napomenaIRA = string.Format("{0} {1}-{2}/dopunsko", rowField[22], rowField[21], rowField[51]);
                        racun.ukupnoIRA = Convert.ToDecimal(rowField[16].Replace('.', ','));
                        racun.SifraBIS = rowField[4];
                        racun.IznosDopunskoOsiguranje = 0;
                        racun.IznosFizickaOsoba = 0;
                        racun.shemaKnjizenja = shemaKnjzenja;
                        racun.shemaKnjizenjaDopunsko = shemaKnjizenjaDopunsko;
                        listRacuni.Add(racun);
                        idRacun++;
                    }

                }
            }

            return listRacuni;
        }
        private void RefreshGrid()
        {
            S_FIN_IRA_PLACANJEDataAdapter adapter = new S_FIN_IRA_PLACANJEDataAdapter();
            this.pocetni = mipsed.application.framework.Application.Pocetni;
            this.zavrsni = mipsed.application.framework.Application.Zavrsni;
            this.PuniPodatke(null, 1, 0x1869f);
            this.work = (UltraExplorerBarWorkspace)this.Controller.WorkItem.Workspaces["TaskPanel"];
            this.Controller.WorkItem.Workspaces["Dock"].Hide(this.work);
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["IRABROJ"].SortIndicator = SortIndicator.Descending;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.FilterUIType = FilterUIType.FilterRow;
        }
        private List<PlainRacuni> PunjenjeUStringK(string[] racuni)
        {
            List<PlainRacuni> listaPlain = new List<PlainRacuni>();
            string glava = "";
            List<string> stavke = new List<string>();
            PlainRacuni plainRacun;

            foreach (string row in racuni)
            {
                if (row.StartsWith("21"))
                {
                    if (glava.Length > 0)
                    {
                        plainRacun = new PlainRacuni();
                        plainRacun.glava = glava;
                        plainRacun.stavke = stavke;
                        listaPlain.Add(plainRacun);

                        glava = "";
                        stavke = new List<string>();
                    }

                    glava = row;
                }
                else
                {
                    if (row.StartsWith("25") ||row.StartsWith("23"))
                    {
                        stavke.Add(row);
                    }
                }
            }
            //posto u zadnji ne ulazi spremamo ga na kraju
            plainRacun = new PlainRacuni();
            plainRacun.glava = glava;
            plainRacun.stavke = stavke;
            listaPlain.Add(plainRacun);

            return listaPlain;
        }

        private bool UpisUBazu(List<Racun> listRacuni)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            StringBuilder errorMessage = new StringBuilder();

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Upis");
            sqlUpit.Transaction = transakcija;

            //prvo upis racuna u IRA-u pa u gkstavke
            if (Zaduzenje(listRacuni, sqlUpit, errorMessage, client, transakcija))
            {
                transakcija.Commit();
                return true;
            }
            else
            {
                transakcija.Rollback();
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                }
                this.Cursor = Cursors.Default;
                return false;
            }
        }

        private bool Zaduzenje(List<Racun> listRacuni, SqlCommand sqlUpit, StringBuilder errorMessage, Mipsed7.DataAccessLayer.SqlClient client, SqlTransaction transakcija)
        {
            if (DaliPostojiShema(sqlUpit) != 0)
            {
                if (InsertIRA(listRacuni, sqlUpit, errorMessage, client, transakcija))
                {
                    MessageBox.Show("Uspješno je preneseno računa u IRA: " + pCounter);

                    int id_shema = 0;
                    if (InsertGlavnaKnjiga(ref id_shema, listRacuni, sqlUpit, errorMessage, client, transakcija))
                    {
                        MessageBox.Show("Uspješno je preneseno računa u GK: " + pCounter);
                    }
                    else
                    {
                        errorMessage.Append("Dogodila se greška prilikom financijskog zaduživanja!\nJavite se u T4S.\n\r" + errorMessage);
                        return false;
                    }
                }
                else
                {
                    errorMessage.Append("Dogodila se greška prilikom prijenosa racuna u knjigu IRA!\nJavite se u T4S.\n\r" + errorMessage);
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public int DaliPostojiShema(SqlCommand sqlUpit)
        {
            sqlUpit.CommandText = "Select Max(IDSHEMAIRA) From SHEMAIRA";

            try
            {
                return Convert.ToInt32(sqlUpit.ExecuteScalar());
            }
            catch { return 0; }
        }

        private bool InsertIRA(List<Racun> listRacuni, SqlCommand sqlUpit, StringBuilder errorMessage, Mipsed7.DataAccessLayer.SqlClient client, SqlTransaction transakcija)
        {
            try
            {
                decimal osn05 = 0;
                decimal osn10 = 0;
                decimal osn22 = 0;
                decimal osn23 = 0;
                decimal osn25 = 0;
                decimal nula = 0;
                decimal pdv05 = 0;
                decimal pdv10 = 0;
                decimal pdv22 = 0;
                decimal pdv23 = 0;
                decimal pdv25 = 0;

                sqlUpit.Parameters.Add(new SqlParameter("@IRAGODINA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRANAPOMENA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRABROJ", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRAPARTNER", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRADATUM", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRAVALUTA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRAUKUPNO", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@NULA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN10", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN22", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN25", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN23", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN05", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV10", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV22", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV25", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV23", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV05", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IDDOKUMENT", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IDTIPIRA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@SifraBis", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Dopunsko", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Fizicka", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@TS", ""));

                pCounter = 0;

                foreach (var item in listRacuni)
                {
                    sqlUpit.Parameters["@IRAGODINA"].Value = item.godinaIRA;
                    sqlUpit.Parameters["@IRABROJ"].Value = item.brojIRA;
                    sqlUpit.Parameters["@IRAPARTNER"].Value = item.partnerIRA;
                    sqlUpit.Parameters["@IRADATUM"].Value = item.datumIRA;
                    sqlUpit.Parameters["@IRAVALUTA"].Value = item.valutaIRA;
                    sqlUpit.Parameters["@IRAUKUPNO"].Value = item.ukupnoIRA;
                    sqlUpit.Parameters["@NULA"].Value = nula;
                    sqlUpit.Parameters["@OSN10"].Value = osn10;
                    sqlUpit.Parameters["@OSN22"].Value = osn22;
                    sqlUpit.Parameters["@OSN25"].Value = osn25;
                    sqlUpit.Parameters["@OSN23"].Value = osn23;
                    sqlUpit.Parameters["@OSN05"].Value = osn05;
                    sqlUpit.Parameters["@PDV10"].Value = pdv10;
                    sqlUpit.Parameters["@PDV22"].Value = pdv22;
                    sqlUpit.Parameters["@PDV25"].Value = pdv25;
                    sqlUpit.Parameters["@PDV23"].Value = pdv23;
                    sqlUpit.Parameters["@PDV05"].Value = pdv05;
                    sqlUpit.Parameters["@IDDOKUMENT"].Value = item.dokumentIRA;
                    sqlUpit.Parameters["@IDTIPIRA"].Value = item.tipIRA;
                    sqlUpit.Parameters["@SifraBis"].Value = item.SifraBIS;
                    sqlUpit.Parameters["@Dopunsko"].Value = item.IznosDopunskoOsiguranje;
                    sqlUpit.Parameters["@Fizicka"].Value = item.IznosFizickaOsoba;
                    sqlUpit.Parameters["@TS"].Value = DateTime.Now;
                    sqlUpit.Parameters["@IRANAPOMENA"].Value = item.napomenaIRA;

                    sqlUpit.CommandText = "Insert Into IRA ([IRAGODIDGODINE],[IRADOKIDDOKUMENT],[IRABROJ],[IRAPARTNERIDPARTNER],[IDTIPIRA],[IRADATUM],[IRAVALUTA],[IRANAPOMENA],[IRAUKUPNO], " +
                            "[NEPODLEZE],[IZVOZ],[MEDJTRANS],[TUZEMSTVO],[NULA],[OSTALO],[OSN10],[OSN22],[OSN23],[OSN25],[PDV10],[PDV22],[PDV23],[PDV25],[OSN05],[PDV05],[NEPODLEZE_USLUGA], " +
                            "[SifraBis],[IznosDopunskoOsiguranje],[IznosFizickaOsoba],[TS]) Values " +
                            "(@IRAGODINA, @IDDOKUMENT, @IRABROJ, @IRAPARTNER, @IDTIPIRA, @IRADATUM, @IRAVALUTA, @IRANAPOMENA, @IRAUKUPNO, 0, 0, 0, @NULA, 0, 0, " +
                            "@OSN10, @OSN22, @OSN23, @OSN25, @PDV10, @PDV22, @PDV23, @PDV25, @OSN05, @PDV05, 0, @SifraBis, @Dopunsko, @Fizicka, @TS)";

                    sqlUpit.ExecuteNonQuery();

                    nula = 0; osn05 = 0; osn10 = 0; osn22 = 0; osn23 = 0; osn25 = 0;
                    pdv05 = 0; pdv10 = 0; pdv22 = 0; pdv23 = 0; pdv25 = 0;

                    pCounter++;
                }
            }
            catch (Exception error)
            {
                pCounter = 0;
                errorMessage.Append(error.Message);
                this.Cursor = Cursors.Default;
                return false;
            }

            return true;
        }

        private bool InsertGlavnaKnjiga(ref int idShema, List<Racun> listRacuni, SqlCommand sqlUpit, StringBuilder errorMessage, Mipsed7.DataAccessLayer.SqlClient client, SqlTransaction transakcija)
        {
            idShema = listRacuni[0].shemaKnjizenja;
            int shemaKnjizenjaDopunsko = 0;

            //dohvat sheme knjizenja za dopunsko
            foreach (var item in listRacuni)
            {
                if (item.shemaKnjizenjaDopunsko != null)
                {
                    shemaKnjizenjaDopunsko = (int)item.shemaKnjizenjaDopunsko;
                    break;
                }
            }

            DataTable dtShemaDopunsko = GetShemaDopunsko(shemaKnjizenjaDopunsko);

            DataTable dtShemaUF = GetShemaKontiranjeByID(idShema);

            int brojStavke = 0;
            int idMjestoTroska;
            int idOrgJedinice;
            string idKonto;
            string duguje;
            string potrazuje;
            string zatvoreno;
            int status;

            sqlUpit.Parameters.Add(new SqlParameter("@DatumPrijave", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ValutaPlacanja", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@BrojDokumenta", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@OPIS", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@GODINA", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ORGDOK", ""));

            pCounter = 0;

            try
            {
                foreach (var item in listRacuni)
                {
                    status = 1;

                    sqlUpit.Parameters["@DatumPrijave"].Value = item.datumIRA;
                    sqlUpit.Parameters["@ValutaPlacanja"].Value = item.valutaIRA;
                    sqlUpit.Parameters["@BrojDokumenta"].Value = item.brojIRA;
                    sqlUpit.Parameters["@OPIS"].Value = item.napomenaIRA;
                    sqlUpit.Parameters["@GODINA"].Value = item.godinaIRA;
                    sqlUpit.Parameters["@ORGDOK"].Value = "IRA br. " + item.brojIRA + "/" + item.godinaIRA;

                    //prvojera dali je dopunsko ili ne
                    if (item.shemaKnjizenjaDopunsko != null & shemaKnjizenjaDopunsko != 0)
                    {
                        foreach (DataRow shema_kontiranja in dtShemaDopunsko.Rows)
                        {
                            brojStavke++;
                            idMjestoTroska = (int)shema_kontiranja["ID_MJESTO_TROSKA"];
                            idOrgJedinice = (int)shema_kontiranja["ID_ORG_JED"];
                            idKonto = shema_kontiranja["ID_KONTO"].ToString().Trim();

                            if (Convert.ToInt32(shema_kontiranja["ID_STRANE_KNJIZENJA"]) == 1)
                            {
                                duguje = item.ukupnoIRA.ToString().Replace(',', '.');
                                potrazuje = "0";

                                sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                                "DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                                "(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + item.dokumentIRA + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', @OPIS, '" +
                                duguje + "', '" + potrazuje + "', @DatumPrijave, " + item.partnerIRA + ", '0', '" + status + "', @ORGDOK, @GODINA, @ValutaPlacanja)";
                            }
                            else
                            {
                                potrazuje = item.ukupnoIRA.ToString().Replace(',', '.');
                                zatvoreno = Math.Abs(item.ukupnoIRA).ToString().Replace(',', '.');
                                duguje = "0";

                                //sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                                //"DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                                //"(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + item.dokumentIRA + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', " +
                                //"@OPIS, '" + duguje + "', '" + potrazuje + "', @DatumPrijave, " + item.partnerIRA + ", '" + zatvoreno + "', '" + status + "', " +
                                //"@ORGDOK, @GODINA, @ValutaPlacanja)";

                                sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                               "DATUMPRIJAVE, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                               "(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + item.dokumentIRA + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', " +
                               "@OPIS, '" + duguje + "', '" + potrazuje + "', @DatumPrijave, '" + zatvoreno + "', '" + status + "', " +
                               "@ORGDOK, @GODINA, @ValutaPlacanja)";

                            }

                            sqlUpit.ExecuteNonQuery();
                        }
                    }
                    else
                    {

                        foreach (DataRow shema_kontiranja in dtShemaUF.Rows)
                        {
                            brojStavke++;
                            idMjestoTroska = (int)shema_kontiranja["ID_MJESTO_TROSKA"];
                            idOrgJedinice = (int)shema_kontiranja["ID_ORG_JED"];
                            idKonto = shema_kontiranja["ID_KONTO"].ToString().Trim();

                            if (Convert.ToInt32(shema_kontiranja["ID_STRANE_KNJIZENJA"]) == 1)
                            {
                                duguje = item.ukupnoIRA.ToString().Replace(',', '.');
                                potrazuje = "0";

                                sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                                "DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                                "(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + item.dokumentIRA + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', @OPIS, '" +
                                duguje + "', '" + potrazuje + "', @DatumPrijave, " + item.partnerIRA + ", '0', '" + status + "', @ORGDOK, @GODINA, @ValutaPlacanja)";
                            }
                            else
                            {
                                potrazuje = item.ukupnoIRA.ToString().Replace(',', '.');
                                zatvoreno = Math.Abs(item.ukupnoIRA).ToString().Replace(',', '.');
                                duguje = "0";

                                //sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                                //"DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                                //"(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + item.dokumentIRA + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', " +
                                //"@OPIS, '" + duguje + "', '" + potrazuje + "', @DatumPrijave, " + item.partnerIRA + ", '" + zatvoreno + "', '" + status + "', " +
                                //"@ORGDOK, @GODINA, @ValutaPlacanja)";

                                sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                                "DATUMPRIJAVE, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                                "(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + item.dokumentIRA + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', " +
                                "@OPIS, '" + duguje + "', '" + potrazuje + "', @DatumPrijave, '" + zatvoreno + "', '" + status + "', " +
                                "@ORGDOK, @GODINA, @ValutaPlacanja)";
                            }

                            sqlUpit.ExecuteNonQuery();
                        }
                    }
                    pCounter++;
                    brojStavke = 0;
                }
            }
            catch (Exception error)
            {
                pCounter = 0;
                errorMessage.Append(error.Message);
                this.Cursor = Cursors.Default;
                return false;
            }
            return true;
        }

        private DataTable GetShemaDopunsko(int shemaKnjizenjaDopunsko)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtShemaKontiranja = client.GetDataTable("SELECT dbo.KONTO.IDKONTO AS ID_KONTO, dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA AS ID_STRANE_KNJIZENJA, " +
                        "dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA AS ID_IRA_VRSTA_IZNOSA, dbo.MJESTOTROSKA.IDMJESTOTROSKA AS ID_MJESTO_TROSKA, dbo.ORGJED.IDORGJED AS ID_ORG_JED, " +
                        "(RTRIM(dbo.Konto.IDKONTO) + ' | ' + dbo.Konto.NAZIVKONTO) AS Konto, dbo.STRANEKNJIZENJA.NAZIVSTRANEKNJIZENJA AS StranaKnjizenja, " +
                        "dbo.IRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIV AS VrstaIznosa, (dbo.MJESTOTROSKA.NAZIVMJESTOTROSKA + ' | ' + Convert(nvarchar, dbo.MJESTOTROSKA.IDMJESTOTROSKA)) AS SifraMT, " +
                        "(dbo.ORGJED.NAZIVORGJED + ' | ' + Convert(nvarchar, dbo.ORGJED.IDORGJED)) AS SifraOJ FROM dbo.SHEMAIRASHEMAIRAKONTIRANJE " +
                        "INNER JOIN dbo.STRANEKNJIZENJA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRASTRANEIDSTRANEKNJIZENJA = dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA " +
                        "INNER JOIN dbo.IRAVRSTAIZNOSA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.IDIRAVRSTAIZNOSA = dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA " +
                        "INNER JOIN dbo.ORGJED ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAOJIDORGJED = dbo.ORGJED.IDORGJED " +
                        "INNER JOIN dbo.MJESTOTROSKA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAMTIDMJESTOTROSKA = dbo.MJESTOTROSKA.IDMJESTOTROSKA " +
                        "INNER JOIN dbo.KONTO ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAKONTOIDKONTO = dbo.KONTO.IDKONTO " +
                        "WHERE (dbo.SHEMAIRASHEMAIRAKONTIRANJE.IDSHEMAIRA = '" + shemaKnjizenjaDopunsko + "')");
            return dtShemaKontiranja;
        }

        public int OdabirShemeKnjizenja(ref int tipIRA, ref int partner, ref int shemaKnjizenjaDopunsko)
        {
            using (OdabirSheme objekt = new OdabirSheme())
            {
                if (objekt.ShowDialogForm("Odabir sheme") == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    tipIRA = objekt.idTipIRA;
                    partner = objekt.idPartner;
                    shemaKnjizenjaDopunsko = objekt.idShemaDopunsko;

                    return objekt.id_sheme;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    return 0;
                }
            }
        }

        private DataTable GetShemaKontiranjeByID(int idShema)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtShemaKontiranja = client.GetDataTable("SELECT dbo.KONTO.IDKONTO AS ID_KONTO, dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA AS ID_STRANE_KNJIZENJA, " +
                        "dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA AS ID_IRA_VRSTA_IZNOSA, dbo.MJESTOTROSKA.IDMJESTOTROSKA AS ID_MJESTO_TROSKA, dbo.ORGJED.IDORGJED AS ID_ORG_JED, " +
                        "(RTRIM(dbo.Konto.IDKONTO) + ' | ' + dbo.Konto.NAZIVKONTO) AS Konto, dbo.STRANEKNJIZENJA.NAZIVSTRANEKNJIZENJA AS StranaKnjizenja, " +
                        "dbo.IRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIV AS VrstaIznosa, (dbo.MJESTOTROSKA.NAZIVMJESTOTROSKA + ' | ' + Convert(nvarchar, dbo.MJESTOTROSKA.IDMJESTOTROSKA)) AS SifraMT, " +
                        "(dbo.ORGJED.NAZIVORGJED + ' | ' + Convert(nvarchar, dbo.ORGJED.IDORGJED)) AS SifraOJ FROM dbo.SHEMAIRASHEMAIRAKONTIRANJE " +
                        "INNER JOIN dbo.STRANEKNJIZENJA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRASTRANEIDSTRANEKNJIZENJA = dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA " +
                        "INNER JOIN dbo.IRAVRSTAIZNOSA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.IDIRAVRSTAIZNOSA = dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA " +
                        "INNER JOIN dbo.ORGJED ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAOJIDORGJED = dbo.ORGJED.IDORGJED " +
                        "INNER JOIN dbo.MJESTOTROSKA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAMTIDMJESTOTROSKA = dbo.MJESTOTROSKA.IDMJESTOTROSKA " +
                        "INNER JOIN dbo.KONTO ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAKONTOIDKONTO = dbo.KONTO.IDKONTO " +
                        "WHERE (dbo.SHEMAIRASHEMAIRAKONTIRANJE.IDSHEMAIRA = '" + idShema + "')");
            return dtShemaKontiranja;
        }

        class PlainRacuni
        {
            public string glava { get; set; }
            public List<string> stavke { get; set; }
        }
        class Racun
        {
            public int brojIRA { get; set; }
            public int godinaIRA { get; set; }
            public int dokumentIRA { get; set; }
            public int partnerIRA { get; set; }
            public int tipIRA { get; set;}
            public DateTime datumIRA { get; set; }
            public DateTime valutaIRA { get; set; }
            public string napomenaIRA { get; set; }
            public decimal ukupnoIRA { get; set; }
            public string SifraBIS { get; set; }
            public decimal IznosDopunskoOsiguranje { get; set; }
            public decimal IznosFizickaOsoba { get; set; }
            public int shemaKnjizenja { get; set; }
            public Nullable<int> shemaKnjizenjaDopunsko { get; set; }
        }
        int pCounter { get; set; }
        #endregion


        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
        }

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.Izmjena();
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (decimal.Compare(decimal.Subtract(DB.N20(RuntimeHelpers.GetObjectValue(e.Row.Cells["IRAUKUPNO"].Value)), DB.N20(RuntimeHelpers.GetObjectValue(e.Row.Cells["ZATVARANJE_IZNOS"].Value))), decimal.Zero) > 0)
            {
                e.Row.Appearance.ForeColor = Color.Red;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(e.Row.Cells["IRAUKUPNO"].Value)), decimal.Zero) < 0)
            {
                e.Row.Appearance.ForeColor = Color.Green;
            }
        }

        private void UraSmartPart_Leave(object sender, EventArgs e)
        {
            UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo {
                DefaultPaneStyle = ChildPaneStyle.VerticalSplit,
                Description = Deklarit.Resources.Resources.Tasks
            };
            Size size = new System.Drawing.Size(210, 100);
            smartPartInfo.PreferredSize = size;
            smartPartInfo.Title = Deklarit.Resources.Resources.Tasks;
            smartPartInfo.DefaultLocation = DockedLocation.DockedRight;
            this.Controller.WorkItem.Workspaces["Dock"].Show(this.work, smartPartInfo);
        }

        private AutoHideControl _TestSmartPartAutoHideControl;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaTop;

        [CreateNew]
        public IRAWorkWithController Controller { get; set; }

        public int CurrentRowIndex
        {
            get
            {
                if (this.UltraGrid1.ActiveRow == null)
                {
                    return -1;
                }
                UltraGridRow activeRow = this.UltraGrid1.ActiveRow;
                while ((activeRow.ParentRow != null) && !(activeRow.ParentRow is UltraGridGroupByRow))
                {
                    activeRow = activeRow.ParentRow;
                }
                return activeRow.ListIndex;
            }
        }

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

        private ImageList ImageList1;

        private Panel Panel1;

        private S_FIN_IRA_PLACANJEDataSet S_FIN_IRA_PLACANJEDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private ToolBar ToolBar1;

        private ToolBarButton ToolBarButton1;

        private ToolBarButton ToolBarButton2;

        private ToolBarButton ToolBarButton3;

        private ToolBarButton ToolBarButton4;

        private ToolBarButton ToolBarButton5;

        private ToolBarButton ToolBarButton6;

        private ToolBarButton ToolBarButton7;
        private ToolBarButton ToolBarButton8;

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private WindowDockingArea WindowDockingArea1;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

