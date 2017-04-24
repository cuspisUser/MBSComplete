using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Deklarit.Resources;
using My.Resources;
using Hlp;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win;
using Infragistics.Win.Misc;
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FinPosModule
{

    [SmartPart]
    public class RacuniSmartPartUser : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private KORISNIKDataSet dskorisnik;
        private SmartPartInfoProvider infoProvider;
        private DateTime pocetni;
        private SmartPartInfo smartPartInfo1;
        private UltraExplorerBarWorkspace work;
        private DateTime zavrsni;

        public RacuniSmartPartUser()
        {
            base.Load += new EventHandler(this.RacuniSmartPart_Load);
            base.Leave += new EventHandler(this.RacuniSmartPart_Leave);
            this.dskorisnik = new KORISNIKDataSet();
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Fakturiranje", "Fakturiranje");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public void Brisanje()
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.RacunDataSet1, "RACUN"];
            if (manager.Count != 0)
            {
                if (this.UltraGrid1.ActiveRow != null)
                {
                    int index = this.UltraGrid1.ActiveRow.Index;
                }
                GKSTAVKADataAdapter adapter2 = new GKSTAVKADataAdapter();
                GKSTAVKADataSet dataSet = new GKSTAVKADataSet();
                IRADataAdapter adapter3 = new IRADataAdapter();
                DataRowView current = (DataRowView) manager.Current;

                if (ProvjeraUF(Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"])))
                {
                    MessageBox.Show("Nije moguće brisati račun koji je\n\rprenesen iz Učeničkog Fakturiranja!!!");
                    return;
                }

                adapter2.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(dataSet, 3, Conversions.ToInteger(current["idracun"]), Conversions.ToShort(current["racungodinaidgodine"]));

                if ((dataSet.GKSTAVKA.Rows.Count <= 0) || (Interaction.MsgBox("Izlazni račun je kontiran u glavnoj knjizi! Odaberite OK za brisanje", MsgBoxStyle.YesNo, "Financijsko poslovanje") != MsgBoxResult.No))
                {
                    RACUNDataAdapter adapter = new RACUNDataAdapter();
                    RACUNDataSet set = new RACUNDataSet();
                    adapter.FillByIDRACUNRACUNGODINAIDGODINE(set, Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"]));

                    if (set.RACUN.Rows.Count > 0)
                    {
                        DataRow row = set.RACUN.Rows[0];
                        this.Controller.Delete(row);
                        current.Delete();
                        this.Pre_sort();
                    }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        }

        public void DesktopAlert(string poruka)
        {
            this.UltraDesktopAlert1.Opacity = 0.9f;
            this.UltraDesktopAlert1.UseFlatMode = DefaultableBoolean.True;
            this.UltraDesktopAlert1.AnimationSpeed = Infragistics.Win.Misc.AnimationSpeed.Fast;
            UltraDesktopAlertShowWindowInfo windowInfo = new UltraDesktopAlertShowWindowInfo {
                Caption = string.Format("<a>{0}</a>", "Slanje računa u tijeku ...!"),
                Text = string.Format("<a>{0}</a>", poruka),
                FooterText = string.Format("<a>{0}</a>", "MIPSED7 FINPOS"),
                Key = "MyWindow"
            };
            UltraDesktopAlertWindowInfo info2 = this.UltraDesktopAlert1.Show(windowInfo);
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(RacuniSmartPartUser));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("RACUN", -1);
            UltraGridColumn column = new UltraGridColumn("IDRACUN");
            UltraGridColumn column12 = new UltraGridColumn("RACUNGODINAIDGODINE");
            UltraGridColumn column23 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column34 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column39 = new UltraGridColumn("MB");
            UltraGridColumn column40 = new UltraGridColumn("PARTNERMJESTO");
            UltraGridColumn column41 = new UltraGridColumn("PARTNERULICA");
            UltraGridColumn column42 = new UltraGridColumn("PARTNEREMAIL");
            UltraGridColumn column43 = new UltraGridColumn("DATUM");
            UltraGridColumn column2 = new UltraGridColumn("VALUTA");
            UltraGridColumn column3 = new UltraGridColumn("RAZDOBLJEOD");
            UltraGridColumn column4 = new UltraGridColumn("RAZDOBLJEDO");
            UltraGridColumn column5 = new UltraGridColumn("MODEL");
            UltraGridColumn column6 = new UltraGridColumn("POZIV");
            UltraGridColumn column7 = new UltraGridColumn("SLOVIMA");
            UltraGridColumn column8 = new UltraGridColumn("NAPOMENA");
            UltraGridColumn column9 = new UltraGridColumn("UKUPNOOSNOVICA");
            UltraGridColumn column10 = new UltraGridColumn("UKUPNOPDV");
            UltraGridColumn column11 = new UltraGridColumn("SVEUKUPNO");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridColumn column13 = new UltraGridColumn("BROJRACUNA");
            UltraGridColumn column14 = new UltraGridColumn("PARTNEROIB");
            UltraGridColumn column15 = new UltraGridColumn("ZAPREDUJAM");
            UltraGridColumn column16 = new UltraGridColumn("RACUN_RACUNRacunStavke");
            UltraGridBand band2 = new UltraGridBand("RACUN_RACUNRacunStavke", 0);
            UltraGridColumn column17 = new UltraGridColumn("IDRACUN");
            UltraGridColumn column18 = new UltraGridColumn("RACUNGODINAIDGODINE");
            UltraGridColumn column19 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column20 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column21 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column22 = new UltraGridColumn("NAZIVPROIZVODRACUN");
            UltraGridColumn column24 = new UltraGridColumn("CIJENA");
            UltraGridColumn column25 = new UltraGridColumn("CIJENARACUN");
            UltraGridColumn column26 = new UltraGridColumn("RABAT");
            UltraGridColumn column27 = new UltraGridColumn("KOLICINA");
            UltraGridColumn column28 = new UltraGridColumn("FINPOREZSTOPARACUN");
            UltraGridColumn column29 = new UltraGridColumn("FINPOREZSTOPA");
            UltraGridColumn column30 = new UltraGridColumn("IZNOSRACUN");
            UltraGridColumn column31 = new UltraGridColumn("IZNOSRABATA");
            UltraGridColumn column32 = new UltraGridColumn("IZNOSMINUSRABAT");
            UltraGridColumn column33 = new UltraGridColumn("PDV");
            UltraGridColumn column35 = new UltraGridColumn("IZNOSPLUSPDV");
            UltraGridColumn column36 = new UltraGridColumn("IDJEDINICAMJERE");
            UltraGridColumn column37 = new UltraGridColumn("NAZIVJEDINICAMJERE");
            UltraGridColumn column38 = new UltraGridColumn("OSNOVICAUKNIZIIRA");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, new Guid("b56d929b-39e7-4750-ada8-586c2c609b09"));
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("b56d929b-39e7-4750-ada8-586c2c609b09");
            DockableControlPane pane = new DockableControlPane(new Guid("20f8bcb7-262e-4452-b055-13947ca15700"), floatingParentId, -1, dockedParentId, -1);
            this.Panel1 = new Panel();
            this.ToolBar1 = new ToolBar();
            this.ToolBarButton1 = new ToolBarButton();
            this.ToolBarButton2 = new ToolBarButton();
            this.ToolBarButton4 = new ToolBarButton();
            this.ToolBarButton6 = new ToolBarButton();
            this.ToolBarButton3 = new ToolBarButton();
            this.ToolBarButton5 = new ToolBarButton();
            this.ToolBarButton7 = new ToolBarButton();
            this.ToolBarButton8 = new ToolBarButton();
            this.ToolBarButton9 = new ToolBarButton();
            this.ToolBarButton11 = new ToolBarButton();
            this.ToolBarButton12 = new ToolBarButton();
            this.ToolBarButton13 = new ToolBarButton();
            this.ImageList2 = new ImageList(this.components);
            this.ImageList1 = new ImageList(this.components);
            this.UltraGrid1 = new UltraGrid();
            this.RacunDataSet1 = new RACUNDataSet();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._TestSmartPartUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._TestSmartPartAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.UltraDesktopAlert1 = new UltraDesktopAlert(this.components);
            this.ToolBarButton10 = new ToolBarButton();
            this.Panel1.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.RacunDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            ((ISupportInitialize) this.UltraDesktopAlert1).BeginInit();
            this.SuspendLayout();
            this.Panel1.Controls.Add(this.ToolBar1);
            this.Panel1.Location = new System.Drawing.Point(0, 0x12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(0x4b8, 0x3a);
            this.Panel1.TabIndex = 15;
            this.ToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToolBar1.Buttons.AddRange(new ToolBarButton[] { ToolBarButton13, this.ToolBarButton1, this.ToolBarButton2, this.ToolBarButton4, this.ToolBarButton6, this.ToolBarButton3, this.ToolBarButton5, this.ToolBarButton7, this.ToolBarButton8, this.ToolBarButton9 });
            this.ToolBar1.ButtonSize = new System.Drawing.Size(0x20, 0x20);
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.ToolBar1.ImageList = this.ImageList2;
            this.ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ToolBar1.MinimumSize = new System.Drawing.Size(0, 60);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            this.ToolBar1.Size = new System.Drawing.Size(0x4b8, 60);
            this.ToolBar1.TabIndex = 1;
            this.ToolBarButton1.ImageIndex = 15;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.Text = "Dodaj";
            this.ToolBarButton2.ImageIndex = 14;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.Text = "Briši";
            this.ToolBarButton4.ImageIndex = 11;
            this.ToolBarButton4.Name = "ToolBarButton4";
            this.ToolBarButton4.Text = "Izmjeni";
            this.ToolBarButton6.ImageIndex = 5;
            this.ToolBarButton6.Name = "ToolBarButton6";
            this.ToolBarButton6.Text = "Ispiši";
            this.ToolBarButton12.ImageIndex = 5;
            this.ToolBarButton12.Name = "ToolBarButton12";
            this.ToolBarButton12.Text = "Uvoz HZZO";
            this.ToolBarButton13.ImageIndex = 5;
            this.ToolBarButton13.Name = "ToolBarButton13";
            this.ToolBarButton13.Text = "Osvježi";
            this.ToolBarButton3.ImageIndex = 4;
            this.ToolBarButton3.Name = "ToolBarButton3";
            this.ToolBarButton3.Text = "Prijenos u GK";
            this.ToolBarButton5.ImageIndex = 9;
            this.ToolBarButton5.Name = "ToolBarButton5";
            this.ToolBarButton5.Text = "Aut. fakt.";
            this.ToolBarButton7.ImageIndex = 10;
            this.ToolBarButton7.Name = "ToolBarButton7";
            this.ToolBarButton7.Text = "Virmani";
            this.ToolBarButton8.ImageIndex = 0x10;
            this.ToolBarButton8.Name = "ToolBarButton8";
            this.ToolBarButton8.Text = "Račun mailom";
            this.ToolBarButton9.Name = "ToolBarButton9";
            this.ToolBarButton9.Text = "Storno";
            this.ToolBarButton11.Name = "ToolBarButton11";
            this.ToolBarButton11.Text = "Odobrenje";
            this.UltraGrid1.DataMember = "RACUN";
            this.UltraGrid1.DataSource = this.RacunDataSet1;
            appearance3.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance3;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.Caption = "Račun";
            column.Header.VisiblePosition = 0;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.VisiblePosition = 5;
            column12.Hidden = true;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.Header.VisiblePosition = 6;
            column23.Hidden = true;
            column34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column34.Header.Caption = "Partner";
            column34.Header.VisiblePosition = 1;
            column34.Width = 0x105;
            column39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column39.Header.VisiblePosition = 7;
            column39.Hidden = true;
            column40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column40.Header.VisiblePosition = 8;
            column40.Hidden = true;
            column41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column41.Header.VisiblePosition = 10;
            column41.Hidden = true;
            column42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column42.Header.VisiblePosition = 11;
            column42.Hidden = true;
            column43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column43.Header.VisiblePosition = 2;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 9;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 12;
            column3.Hidden = true;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 13;
            column4.Hidden = true;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 14;
            column5.Hidden = true;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.Header.VisiblePosition = 15;
            column6.Hidden = true;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.VisiblePosition = 0x10;
            column7.Hidden = true;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.Caption = "Napomena";
            column8.Header.VisiblePosition = 3;
            column8.Width = 0x113;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 0x11;
            column9.Hidden = true;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.VisiblePosition = 0x12;
            column10.Hidden = true;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance.TextHAlignAsString = "Right";
            column11.CellAppearance = appearance;
            column11.Header.Caption = "Ukupan iznos";
            column11.Header.VisiblePosition = 4;
            column11.MaskInput = "{LOC} -n,nnn,nnn.nn";
            column11.Width = 0xcf;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 0x13;
            column13.Hidden = true;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 20;
            column14.Hidden = true;
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.Header.VisiblePosition = 0x15;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.Header.VisiblePosition = 0x16;
            band.Columns.AddRange(new object[] { 
                column, column12, column23, column34, column39, column40, column41, column42, column43, column2, column3, column4, column5, column6, column7, column8, 
                column9, column10, column11, column13, column14, column15, column16
             });
            band.SummaryFooterCaption = "Totali:";
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.Header.VisiblePosition = 0;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.Header.VisiblePosition = 1;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.Header.VisiblePosition = 2;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.Header.VisiblePosition = 3;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.Header.VisiblePosition = 4;
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column22.Header.VisiblePosition = 5;
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column24.Header.VisiblePosition = 6;
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column25.Header.VisiblePosition = 7;
            column26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column26.Header.VisiblePosition = 8;
            column27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column27.Header.VisiblePosition = 9;
            column28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column28.Header.VisiblePosition = 10;
            column29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column29.Header.VisiblePosition = 11;
            column30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column30.Header.VisiblePosition = 12;
            column31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column31.Header.VisiblePosition = 13;
            column32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column32.Header.VisiblePosition = 14;
            column33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column33.Header.VisiblePosition = 15;
            column35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column35.Header.VisiblePosition = 0x10;
            column36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column36.Header.VisiblePosition = 0x11;
            column37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column37.Header.VisiblePosition = 0x12;
            column38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column38.Header.VisiblePosition = 0x13;
            band2.Columns.AddRange(new object[] { 
                column17, column18, column19, column20, column21, column22, column24, column25, column26, column27, column28, column29, column30, column31, column32, column33, 
                column35, column36, column37, column38
             });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band2);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance4.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance5.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance6.BorderColor = Color.LightGray;
            appearance6.FontData.BoldAsString = "True";
            appearance6.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance6;
            appearance2.BackColor = Color.LightSteelBlue;
            appearance2.BorderColor = Color.Black;
            appearance2.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.UltraGrid1.Location = new System.Drawing.Point(0, 0x51);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(0x4b8, 0x215);
            this.UltraGrid1.TabIndex = 11;
            this.RacunDataSet1.DataSetName = "RACUNDataSet";
            pane.Control = this.Panel1;
            Rectangle rectangle = new Rectangle(3, 3, 0x456, 0x3f);
            pane.OriginalControlBounds = rectangle;
            pane.Size = new System.Drawing.Size(100, 100);
            pane.Text = "Fakturiranje";
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            pane2.Size = new System.Drawing.Size(0x4b8, 0x4c);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = WindowStyle.Office2007;
            this._TestSmartPartUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._TestSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._TestSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartUnpinnedTabAreaLeft.Name = "_TestSmartPartUnpinnedTabAreaLeft";
            this._TestSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x266);
            this._TestSmartPartUnpinnedTabAreaLeft.TabIndex = 0x10;
            this._TestSmartPartUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._TestSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._TestSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x4b8, 0);
            this._TestSmartPartUnpinnedTabAreaRight.Name = "_TestSmartPartUnpinnedTabAreaRight";
            this._TestSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x266);
            this._TestSmartPartUnpinnedTabAreaRight.TabIndex = 0x11;
            this._TestSmartPartUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._TestSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._TestSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartUnpinnedTabAreaTop.Name = "_TestSmartPartUnpinnedTabAreaTop";
            this._TestSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x4b8, 0);
            this._TestSmartPartUnpinnedTabAreaTop.TabIndex = 0x12;
            this._TestSmartPartUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._TestSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._TestSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x266);
            this._TestSmartPartUnpinnedTabAreaBottom.Name = "_TestSmartPartUnpinnedTabAreaBottom";
            this._TestSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x4b8, 0);
            this._TestSmartPartUnpinnedTabAreaBottom.TabIndex = 0x13;
            this._TestSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._TestSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartAutoHideControl.Name = "_TestSmartPartAutoHideControl";
            this._TestSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._TestSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 0x266);
            this._TestSmartPartAutoHideControl.TabIndex = 20;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(0x4b8, 0x51);
            this.WindowDockingArea1.TabIndex = 0x15;
            this.DockableWindow1.Controls.Add(this.Panel1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(0x4b8, 0x4c);
            this.DockableWindow1.TabIndex = 0x16;
            this.ToolBarButton10.Name = "ToolBarButton10";
            this.ToolBarButton10.Text = "Kopiraj račun";

            this.ToolBarButton10.Name = "ToolBarButton12";
            this.ToolBarButton10.Text = "Uvoz HZZO";

            this.Controls.Add(this._TestSmartPartAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaRight);
            this.Name = "RacuniSmartPartUser";
            this.Size = new System.Drawing.Size(0x4b8, 0x266);


            this.UltraGrid1.AfterCellUpdate += new CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            this.UltraGrid1.AfterRowUpdate += new RowEventHandler(this.UltraGrid1_AfterRowUpdate);
            this.UltraGrid1.DoubleClickRow += new DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            this.UltraGrid1.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            
            this.ToolBar1.ButtonClick += new ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);


            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.RacunDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            ((ISupportInitialize) this.UltraDesktopAlert1).EndInit();
            this.ResumeLayout(false);
        }

        public void IspisiRacun()
        {
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);

            bool setCustomLogo = false;

            if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "93161265507", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\regos.rpt");
            }
            else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "61456000823", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\fakturazaprudje.rpt");
            }
            else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "96443688162", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\fakturamipsed.rpt");
            }
            else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "17847110267", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\ToolsFakturiranje.rpt");
                setCustomLogo = true;
            }
            else
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\fakturaproracun.rpt");
                setCustomLogo = true;
            }

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            RACUNDataSet set = new RACUNDataSet();
            RowEnumerator enumerator = this.UltraGrid1.Selected.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraGridRow current = enumerator.Current;
                set.Merge(this.RacunDataSet1.RACUN.Select("idracun=" + Conversions.ToString(current.Cells[0].Value) + " and racungodinaidgodine= " + Conversions.ToString(current.Cells["racungodinaidgodine"].Value)));
                set.Merge(this.RacunDataSet1.RACUNRacunStavke.Select("idracun=" + Conversions.ToString(current.Cells[0].Value) + " and racungodinaidgodine= " + Conversions.ToString(current.Cells["racungodinaidgodine"].Value)));
            }
            document.SetDataSource(set);

            // podesavanje loga na ispisu, ukoliko nije podesena lokacija za logo, gleda staru logiku
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            string putanja = client.ExecuteScalar("Select Top 1 Logo From Korisnik").ToString();

            if (putanja.Length == 0)
            {
                try
                {
                    document.SetParameterValue("logoPath", string.Empty);
                }
                catch { }

                if (setCustomLogo)
                {
                    // Postavljanje logotipa
                    string logoPath = AppDomain.CurrentDomain.BaseDirectory + @"Resources\logo_135_135.jpg";

                    if (System.IO.File.Exists(logoPath))
                        document.SetParameterValue("logoPath", logoPath);
                }
            }
            else
            {
                document.SetParameterValue("logoPath", putanja);
            }

            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "93161265507", false), Operators.CompareObjectNotEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "96443688162", false))))
            {
                document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                document.SetParameterValue("adresa", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], ", "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));

                document.SetParameterValue("mjesto", dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]);

                DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                if (rowArray.Length > 0)
                {
                    string ziro = Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]).ToString();

                    IBAN iban = new IBAN();
                    ziro = iban.GenerirajIBANIzBrojaRacuna(ziro, false, true);

                    document.SetParameterValue("ziro", Operators.ConcatenateObject("IBAN: ", ziro));
                }
                else
                {
                    document.SetParameterValue("ziro", "nepoznati");
                }
                document.SetParameterValue("telefonfax", Operators.AddObject(Operators.AddObject(Operators.AddObject("Telefon: ", dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]), " Fax: "), dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
                document.SetParameterValue("mail", Operators.AddObject("Email: ", dataSet.KORISNIK.Rows[0]["EMAIL"]));
                document.SetParameterValue("OIB", Operators.AddObject("OIB:", dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
                document.SetParameterValue("OBRACUNAO", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTOSOBA"]));
                document.SetParameterValue("PREDSTAVNIK", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["PREZIMEIMEOVLASTENEOSOBE"]));
                document.SetParameterValue("tipRacuna", ((bool)dataSet.KORISNIK.Rows[0]["OBVEZNIKPDVA"] ? "R-1 " : string.Empty));

                if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "45065170578", false))
                {
                    document.SetParameterValue("NAPOMENAPOSLOVNI", "Poslovni edukator d.o.o. upisan je u Trgovačkom sudu u Splitu:Tt-10/1130-4, MBS:060228672. \r\nTemeljni kapital 20.000,00 kn,uplaćen u cijelosti. Član uprave: Ivana Ban.");
                }
                else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "17847110267", false))
                {
                    document.SetParameterValue("NAPOMENAPOSLOVNI", "TOOLS4Schools d.o.o. za računovodstvo, Gračanska c. 22, Zagreb; Trgovački sud u Zagrebu MBS:080911316; Temeljni kapital: 20.000,00 uplaćen u cijelosti; Direktor: Marko Krznarić; Oznaka operatera: Boris Lemić");
                }
                else if (!Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "61456000823", false))
                {
                    document.SetParameterValue("NAPOMENAPOSLOVNI", " ");
                }
            }
            else
            {
                document.SetParameterValue("mjesto", dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]);
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        public void Izmjena()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }

            CurrencyManager manager = (CurrencyManager)this.BindingContext[this.RacunDataSet1, "RACUN"];
            if (manager.Count != 0)
            {
                DataRowView current = (DataRowView)manager.Current;

                if (ProvjeraUF(Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"])))
                {
                    MessageBox.Show("Nije moguće uređivati račun koji je\n\rprenesen iz Učeničkog Fakturiranja!!!");
                    return;
                }

                RACUNDataAdapter adapter = new RACUNDataAdapter();
                RACUNDataSet dataSet = new RACUNDataSet();
                adapter.FillByIDRACUNRACUNGODINAIDGODINE(dataSet, Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"]));
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                DataRow row = dataSet.RACUN.Rows[0];
                dictionary.Add("IDRACUN", RuntimeHelpers.GetObjectValue(current["IDRACUN"]));
                dictionary.Add("RACUNGODINAIDGODINE", RuntimeHelpers.GetObjectValue(current["RACUNGODINAIDGODINE"]));
                this.Controller.Update(row);
                current.Delete();
                adapter.FillByIDRACUNRACUNGODINAIDGODINE(this.RacunDataSet1, Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"]));
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
                        this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                        this.UltraGrid1.ActiveRow.Selected = true;
                        this.UltraGrid1.Focus();
                    }
                }
            }
        }

        public void Izradi_Virmane()
        {
            if (ProvjeraUF(Conversions.ToInteger(UltraGrid1.ActiveRow.Cells["IDRACUN"].Value), Conversions.ToShort(UltraGrid1.ActiveRow.Cells["RACUNGODINAIDGODINE"].Value)))
            {
                MessageBox.Show("Nije moguće izraditi virman računa koji je\n\rprenesen iz Učeničkog Fakturiranja!!!");
                return;
            }

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            VirmaniWorkItemUser user = this.Controller.WorkItem.Items.Get<VirmaniWorkItemUser>("Virmani");
            if (user == null)
            {
                user = this.Controller.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Virmani");
            }
            user.Show(user.Workspaces["main"]);
        }

        public void Kopija_racuna()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.RacunDataSet1, "RACUN"];
            if (manager.Count != 0)
            {
                IEnumerator enumerator = null;
                DataRowView current = (DataRowView) manager.Current;

                if (ProvjeraUF(Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"])))
                {
                    MessageBox.Show("Nije moguće izraditi kopiju računa koji je\n\rprenesen iz Učeničkog Fakturiranja!!!");
                    return;
                }

                RACUNDataAdapter adapter = new RACUNDataAdapter();
                RACUNDataSet dataSet = new RACUNDataSet();
                adapter.FillByIDRACUNRACUNGODINAIDGODINE(dataSet, Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"]));
                DataRow row2 = this.RacunDataSet1.RACUN.NewRACUNRow();
                row2["RACUNGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(current["RACUNGODINAIDGODINE"]);
                row2["idracun"] = this.ZadnjiBrojRacunaUGodini();
                row2["zapredujam"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["zapredujam"]);
                row2["IDPARTNER"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["IDPARTNER"]);
                row2["RACUNGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(current["RACUNGODINAIDGODINE"]);
                row2["DATUM"] = DateAndTime.Today;
                row2["valuta"] = DateAndTime.Today.AddDays(7.0);
                row2["RAZDOBLJEOD"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["razdobljeod"]);
                row2["RAZDOBLJEDO"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["razdobljedo"]);
                row2["model"] = "01";
                row2["POZIV"] = this.ZadnjiBrojRacunaUGodini().ToString() + "-" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear) + "-" + dataSet.RACUN.Rows[0]["IDPARTNER"].ToString() + Razno.KontrolniBroj(this.ZadnjiBrojRacunaUGodini().ToString() + "-" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear) + "-" + dataSet.RACUN.Rows[0]["IDPARTNER"].ToString());
                row2["napomena"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["napomena"]);
                this.RacunDataSet1.RACUN.Rows.Add(row2);
                DataRow row3 = this.RacunDataSet1.RACUNRacunStavke.NewRACUNRacunStavkeRow();
                try
                {
                    enumerator = dataSet.RACUNRacunStavke.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow row = (DataRow) enumerator.Current;
                        row3["IDRACUN"] = this.ZadnjiBrojRacunaUGodini();
                        row3["BROJSTAVKE"] = RuntimeHelpers.GetObjectValue(row["brojstavke"]);
                        row3["NAZIVPROIZVODRACUN"] = RuntimeHelpers.GetObjectValue(row["NAZIVPROIZVODRACUN"]);
                        row3["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(row["IDPROIZVOD"]);
                        row3["CIJENARACUN"] = RuntimeHelpers.GetObjectValue(row["CIJENARACUN"]);
                        row3["RABAT"] = RuntimeHelpers.GetObjectValue(row["RABAT"]);
                        row3["KOLICINA"] = RuntimeHelpers.GetObjectValue(row["KOLICINA"]);
                        row3["FINPOREZSTOPARACUN"] = RuntimeHelpers.GetObjectValue(row["FINPOREZSTOPARACUN"]);
                        row3["RACUNGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(row["RACUNGODINAIDGODINE"]);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                this.RacunDataSet1.RACUNRacunStavke.Rows.Add(row3);
                try
                {
                    adapter.Update(this.RacunDataSet1);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
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
                        this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                        this.UltraGrid1.ActiveRow.Selected = true;
                        this.UltraGrid1.Focus();
                    }
                }
            }
        }

        private bool ProvjeraUF(int id, short year)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            string vrsta = client.ExecuteScalar("Select Vrsta From Racun Where IDRACUN = '" + id + "' And RACUNGODINAIDGODINE = '" + year + "'").ToString();

            if (vrsta == "UF" | vrsta == "SU")
            {
                return true;
            }

            return false;
        }

        public void Kopiraj()
        {
        }

        public void Nova()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }

            if (index < 0)
                return;

            RACUNDataSet set = new RACUNDataSet();
            RACUNDataAdapter adapter = new RACUNDataAdapter();
            DataRow foreignKeys = this.RacunDataSet1.RACUN.NewRow();
            foreignKeys["RACUNGODINAIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
            foreignKeys["idracun"] = this.ZadnjiBrojRacunaUGodini();
            this.Controller.Insert(foreignKeys);
            adapter.FillByIDRACUNRACUNGODINAIDGODINE(this.RacunDataSet1, Conversions.ToInteger(foreignKeys["IDRACUN"]), Conversions.ToShort(foreignKeys["RACUNGODINAIDGODINE"]));
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
                    this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                    this.UltraGrid1.ActiveRow.Selected = true;
                    this.UltraGrid1.Focus();
                }
            }
        }

        public object NUMERACIJAdokument(int dok)
        {
            object objectValue = new object();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(brojdokumenta) FROM gkstavka WHERE IDDOKUMENT = @IDDOKUMENT and gkgodidgodine =" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear)
            };
            command.Parameters.AddWithValue("@IDDOKUMENT", dok);
            command.Connection = connection;
            connection.Open();
            try
            {
                objectValue = RuntimeHelpers.GetObjectValue(command.ExecuteScalar());
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)))
                {
                    objectValue = 0;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.Close();
            return objectValue;
        }

        public void Pre_sort()
        {
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["idracun"].SortIndicator = SortIndicator.Descending;
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["idracun"].Band.SortedColumns.RefreshSort(true);
            this.UltraGrid1.Refresh();
        }

        public void PrenesiUGk()
        {

            SHEMAIRASelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<SHEMAIRASelectionListWorkItem>("test");
            DataRow row4 = item.ShowModal(true, "", null);
            item.Terminate();
            if (row4 != null)
            {
                SortedList list = new SortedList();
                RowEnumerator enumerator = this.UltraGrid1.Selected.Rows.GetEnumerator();
                string racuni = string.Empty;

                while (enumerator.MoveNext())
                {
                    UltraGridRow current = enumerator.Current;

                    if (ProvjeraUF(Conversions.ToInteger(current.Cells["IDRACUN"].Value), Conversions.ToShort(current.Cells["RACUNGODINAIDGODINE"].Value)))
                    {
                        racuni += current.Cells["IDRACUN"].Value.ToString() + ",";
                    }
                    else
                    {
                        list.Add(RuntimeHelpers.GetObjectValue(current.Cells["idracun"].Value), RuntimeHelpers.GetObjectValue(current.Cells["idracun"].Value));
                    }

                }

                if (racuni.Length > 0)
                {
                    MessageBox.Show("Nije moguće prenositi u GK račune koji su preneseni iz Učeničkog Fakturiranja!!!\n\rRačuni " + racuni + " su ukonjeni iz prijenosa");
                }

                if (list.Count != 0)
                {
                    int num2 = 0;
                    int num3 = 0;
                    IEnumerator enumerator2 = null;
                    int num = Conversions.ToInteger(Operators.AddObject(this.NUMERACIJAdokument(Conversions.ToInteger(row4["shemairadokiddokument"])), 1));
                    GKSTAVKADataSet dataSet = new GKSTAVKADataSet();
                    GKSTAVKADataAdapter adapter = new GKSTAVKADataAdapter();
                    IRADataAdapter adapter2 = new IRADataAdapter();
                    IRADataSet set = new IRADataSet();
                    GKSTAVKADataSet set2 = new GKSTAVKADataSet();
                    IRADataSet set4 = new IRADataSet();
                    try
                    {
                        enumerator2 = this.RacunDataSet1.RACUN.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            DataRow row2 = (DataRow) enumerator2.Current;
                            if (list.ContainsValue(RuntimeHelpers.GetObjectValue(row2["idracun"])))
                            {
                                decimal num7 = 0;

                                decimal osnovica_05 = 0;
                                decimal osnovica_10 = 0;
                                decimal osnovica_13 = 0;
                                decimal osnovica_23 = 0;
                                decimal osnovica_25 = 0;

                                decimal pdv_05 = 0;
                                decimal pdv_10 = 0;
                                decimal pdv_13 = 0;
                                decimal pdv_23 = 0;
                                decimal pdv_25 = 0;

                                decimal neoporezivo_usluge = 0;
                                decimal neoporezivo_dobra = 0;
                                decimal tuzemni_prijenos = 0;
                                decimal u_tuzemstvu = 0;
                                decimal izvoz = 0;
                                decimal ostalo = 0;

                                DataRow[] rowArray2 = this.RacunDataSet1.RACUNRacunStavke.Select(Conversions.ToString(Operators.ConcatenateObject("idracun = ", row2["idracun"])));
                                int num16 = rowArray2.Length - 1;
                                for (int i = 0; i <= num16; i++)
                                {
                                    // 5%
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 17, false))
                                    {
                                        osnovica_05 = Conversions.ToDecimal(Operators.AddObject(osnovica_05, rowArray2[i]["IZNOSMINUSRABAT"]));
                                        pdv_05 = Conversions.ToDecimal(Operators.AddObject(pdv_05, rowArray2[i]["pdv"]));
                                    }

                                    // 10%
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 19, false))
                                    {
                                        osnovica_10 = Conversions.ToDecimal(Operators.AddObject(osnovica_10, rowArray2[i]["IZNOSMINUSRABAT"]));
                                        pdv_10 = Conversions.ToDecimal(Operators.AddObject(pdv_10, rowArray2[i]["pdv"]));
                                    }

                                    // 13%
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 1005, false))
                                    {
                                        osnovica_13 = Conversions.ToDecimal(Operators.AddObject(osnovica_13, rowArray2[i]["IZNOSMINUSRABAT"]));
                                        pdv_13 = Conversions.ToDecimal(Operators.AddObject(pdv_13, rowArray2[i]["pdv"]));
                                    }
                                    // 25%
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 21, false))
                                    {
                                        osnovica_25 = Conversions.ToDecimal(Operators.AddObject(osnovica_25, rowArray2[i]["IZNOSMINUSRABAT"]));
                                        pdv_25 = Conversions.ToDecimal(Operators.AddObject(pdv_25, rowArray2[i]["pdv"]));
                                    }

                                    // neoporezivo usluge
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 10, false))
                                    {
                                        neoporezivo_usluge = Conversions.ToDecimal(Operators.AddObject(neoporezivo_usluge, rowArray2[i]["IZNOSMINUSRABAT"]));
                                    }

                                    //neoporezivo dobra
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 9, false))
                                    {
                                        neoporezivo_dobra = Conversions.ToDecimal(Operators.AddObject(neoporezivo_dobra, rowArray2[i]["IZNOSMINUSRABAT"]));
                                    }

                                    // tuzemni prijenos (medjutrans u bazi)
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 7, false))
                                    {
                                        tuzemni_prijenos = Conversions.ToDecimal(Operators.AddObject(tuzemni_prijenos, rowArray2[i]["IZNOSMINUSRABAT"]));
                                    }

                                    //u tuzemstvu
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 14, false))
                                    {
                                        u_tuzemstvu = Conversions.ToDecimal(Operators.AddObject(u_tuzemstvu, rowArray2[i]["IZNOSMINUSRABAT"]));
                                    }

                                    //izvoz
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 15, false))
                                    {
                                        izvoz = Conversions.ToDecimal(Operators.AddObject(izvoz, rowArray2[i]["IZNOSMINUSRABAT"]));
                                    }

                                    //ostalo
                                    if (Operators.ConditionalCompareObjectEqual(rowArray2[i]["OSNOVICAUKNIZIIRA"], 16, false))
                                    {
                                        ostalo = Conversions.ToDecimal(Operators.AddObject(ostalo, rowArray2[i]["IZNOSMINUSRABAT"]));
                                    }
                                }
                                set2.Clear();
                                set4.Clear();
                                adapter.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(set2, Conversions.ToInteger(row4["shemairadokiddokument"]), Conversions.ToInteger(row2["idracun"]), mipsed.application.framework.Application.ActiveYear);
                                adapter2.FillByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(set4, mipsed.application.framework.Application.ActiveYear, Conversions.ToInteger(row4["shemairadokiddokument"]), Conversions.ToInteger(row2["idracun"]));
                                if (set2.GKSTAVKA.Rows.Count == 0)
                                {
                                    DataRow[] childRows = row4.GetChildRows("SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE");
                                    int num17 = childRows.Length - 1;
                                    for (int j = 0; j <= num17; j++)
                                    {
                                        this.BindingContext[dataSet, "GKSTAVKA"].AddNew();
                                        DataRowView view = (DataRowView) this.BindingContext[dataSet, "GKSTAVKA"].Current;
                                        view["datumdokumenta"] = RuntimeHelpers.GetObjectValue(row2["datum"]);
                                        view["brojdokumenta"] = RuntimeHelpers.GetObjectValue(row2["idracun"]);
                                        view["brojstavke"] = j + 1;
                                        view["iddokument"] = RuntimeHelpers.GetObjectValue(row4["shemairadokiddokument"]);
                                        view["OPIS"] = "IRA-" + Conversions.ToString(row2["idracun"]) + "-" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear);
                                        view["zatvoreniiznos"] = 0;
                                        view["statusgk"] = 0;

                                        // 1    Ukupan iznos računa
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 1, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = DB.N20(RuntimeHelpers.GetObjectValue(row2["sveukupno"]));
                                                view["potrazuje"] = 0;
                                                view["idpartner"] = RuntimeHelpers.GetObjectValue(row2["idpartner"]);
                                                view["gkdatumvalute"] = RuntimeHelpers.GetObjectValue(row2["valuta"]);
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = DB.N20(RuntimeHelpers.GetObjectValue(row2["sveukupno"]));
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 14    Osnovica 25%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 14, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = osnovica_25;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = osnovica_25;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 15    PDV 25%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 15, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = pdv_25;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = pdv_25;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 2    Osnovica 23%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 2, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = osnovica_23;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = osnovica_23;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 5    PDV 23%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 5, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = pdv_23;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = pdv_23;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 4    Osnovica 10%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 4, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = osnovica_10;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = osnovica_10;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 7    PDV 10%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 7, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = pdv_10;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = pdv_10;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }
                                        // 4    Osnovica 13%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 16, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = osnovica_13;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = osnovica_13;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 7    PDV 13%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 17, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = pdv_13;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = pdv_13;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }
                                        // 8    Ne podliježe oporezivanju
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 8, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = neoporezivo_dobra + neoporezivo_usluge;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = neoporezivo_dobra + neoporezivo_usluge;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        //  9   Izvoz
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 9, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = izvoz;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = izvoz;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        //  10  Međunarodni prijevoz
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 10, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = tuzemni_prijenos;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = tuzemni_prijenos;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 11   U tuzemstvu
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 11, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = u_tuzemstvu;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = u_tuzemstvu;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 12   Ostalo
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 12, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = ostalo;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = ostalo;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }

                                        // 13   Osnovica i PDV 0%
                                        if (Operators.ConditionalCompareObjectEqual(childRows[j]["IDIRAVRSTAIZNOSA"], 13, false))
                                        {
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 1, false))
                                            {
                                                view["duguje"] = num7;
                                                view["potrazuje"] = 0;
                                            }
                                            if (Operators.ConditionalCompareObjectEqual(childRows[j]["SHEMAIRASTRANEIDSTRANEKNJIZENJA"], 3, false))
                                            {
                                                view["duguje"] = 0;
                                                view["potrazuje"] = num7;
                                            }
                                            view["IDKONTO"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAKONTOIDKONTO"]);
                                            view["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAMTIDMJESTOTROSKA"]);
                                            view["IDORGJED"] = RuntimeHelpers.GetObjectValue(childRows[j]["SHEMAIRAOJIDORGJED"]);
                                            view["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                        }


                                        this.BindingContext[dataSet, "GKSTAVKA"].EndCurrentEdit();
                                    }
                                    num2++;
                                }
                                if (set4.IRA.Rows.Count == 0)
                                {
                                    DataRow row = set.IRA.NewRow();
                                    row["iragodidgodine"] = mipsed.application.framework.Application.ActiveYear;
                                    row["iradokiddokument"] = RuntimeHelpers.GetObjectValue(row4["shemairadokiddokument"]);
                                    row["irabroj"] = RuntimeHelpers.GetObjectValue(row2["idracun"]);
                                    row["irapartneridpartner"] = RuntimeHelpers.GetObjectValue(row2["idpartner"]);
                                    row["idtipira"] = 1;
                                    row["iradatum"] = RuntimeHelpers.GetObjectValue(row2["datum"]);
                                    row["iravaluta"] = RuntimeHelpers.GetObjectValue(row2["valuta"]);
                                    row["iranapomena"] = "Prijenos iz fakturiranja";
                                    row["iraukupno"] = RuntimeHelpers.GetObjectValue(row2["sveukupno"]);

                                    row["OSN25"] = osnovica_25;
                                    row["PDV25"] = pdv_25;

                                    row["OSN23"] = osnovica_23;
                                    row["PDV23"] = pdv_23;

                                    row["OSN10"] = osnovica_10;
                                    row["PDV10"] = pdv_10;

                                    row["OSN10"] = osnovica_13;
                                    row["PDV10"] = pdv_13;

                                    row["OSN05"] = osnovica_05;
                                    row["PDV05"] = pdv_05;

                                    row["nepodleze"] = neoporezivo_dobra;
                                    row["nepodleze_usluga"] = neoporezivo_usluge;
                                    row["izvoz"] = izvoz;
                                    row["medjtrans"] = tuzemni_prijenos;
                                    row["tuzemstvo"] = u_tuzemstvu;
                                    row["ostalo"] = ostalo;
                                    row["nula"] = num7;
                                    set.IRA.Rows.Add(row);
                                    num3++;
                                }
                                pdv_25 = new decimal();
                                osnovica_25 = new decimal();
                                pdv_05 = new decimal();
                                osnovica_05 = new decimal();
                                pdv_23 = new decimal();
                                osnovica_23 = new decimal();
                                osnovica_10 = new decimal();
                                pdv_10 = new decimal();
                                neoporezivo_usluge = new decimal();
                                neoporezivo_dobra = new decimal();
                                izvoz = new decimal();
                                tuzemni_prijenos = new decimal();
                                u_tuzemstvu = new decimal();
                                ostalo = new decimal();
                                num7 = new decimal();
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
                    Interaction.MsgBox("U glavnu knjigu prebačeno ukupno: " + Conversions.ToString(num2) + " računa", MsgBoxStyle.OkOnly, null);
                    Interaction.MsgBox("U knjigu IRA  prebačeno ukupno: " + Conversions.ToString(num3) + " računa", MsgBoxStyle.OkOnly, null);
                    adapter2.Update(set);
                    adapter.Update(dataSet);
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
                this.ParentForm.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RacuniSmartPart_Leave(object sender, EventArgs e)
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

        private void RacuniSmartPart_Load(object sender, EventArgs e)
        {
            new RACUNDataAdapter().FillByRACUNGODINAIDGODINE(this.RacunDataSet1, mipsed.application.framework.Application.ActiveYear);
            this.pocetni = mipsed.application.framework.Application.Pocetni;
            this.zavrsni = mipsed.application.framework.Application.Zavrsni;
            this.work = (UltraExplorerBarWorkspace) this.Controller.WorkItem.Workspaces["TaskPanel"];
            this.Controller.WorkItem.Workspaces["Dock"].Hide(this.work);
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["idracun"].SortIndicator = SortIndicator.Descending;
            new KORISNIKDataAdapter().Fill(this.dskorisnik);
            this.UltraGrid1.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.FilterUIType = FilterUIType.FilterRow;

            if (UltraGrid1.DisplayLayout.Bands != null)
            {
                UltraGrid1.DisplayLayout.Bands[0].Columns["Vrsta"].Hidden = true;
                UltraGrid1.DisplayLayout.Bands[0].Columns["UkupanIznos"].Hidden = true;
            }

         }

        public void SaljiMailom()
        {
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);

            bool setCustomLogo = false;

            if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "93161265507", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\regos.rpt");
            }
            else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "61456000823", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\fakturazaprudje.rpt");
            }
            else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "96443688162", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\fakturamipsed.rpt");
            }
            else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "17847110267", false))
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\ToolsFakturiranje.rpt");
                setCustomLogo = true;
            }
            else
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\fakturaproracun.rpt");
                setCustomLogo = true;
            }

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            if (this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled") == null)
            {
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            RowEnumerator enumerator = this.UltraGrid1.Selected.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IEnumerator enumerator2 = null;
                UltraGridRow current = enumerator.Current;
                RACUNDataSet set2 = new RACUNDataSet();
                set2.Merge(this.RacunDataSet1.RACUN.Select("idracun=" + Conversions.ToString(current.Cells[0].Value) + " and racungodinaidgodine= " + Conversions.ToString(current.Cells["racungodinaidgodine"].Value)));
                set2.Merge(this.RacunDataSet1.RACUNRacunStavke.Select("idracun=" + Conversions.ToString(current.Cells[0].Value) + " and racungodinaidgodine= " + Conversions.ToString(current.Cells["racungodinaidgodine"].Value)));
                document.SetDataSource(set2);

                // inicijalne postavke
                document.SetParameterValue("logoPath", string.Empty);

                if (setCustomLogo)
                {
                    // Postavljanje logotipa
                    string logoPath = AppDomain.CurrentDomain.BaseDirectory + @"Resources\logo_135_135.jpg";

                    if (System.IO.File.Exists(logoPath))
                        document.SetParameterValue("logoPath", logoPath);
                }

                if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "93161265507", false), Operators.CompareObjectNotEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "96443688162", false))))
                {
                    document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                    document.SetParameterValue("adresa", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], ", "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                    document.SetParameterValue("mjesto", dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]);

                    DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");

                    if (rowArray.Length > 0)
                    {
                        string ziro = Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]).ToString();

                        IBAN iban = new IBAN();
                        ziro = iban.GenerirajIBANIzBrojaRacuna(ziro, false, true);

                        document.SetParameterValue("ziro", Operators.ConcatenateObject("IBAN: ", ziro));
                    }
                    else
                    {
                        document.SetParameterValue("ziro", "nepoznati");
                    }
                    document.SetParameterValue("telefonfax", Operators.AddObject(Operators.AddObject(Operators.AddObject("Telefon: ", dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]), " Fax: "), dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
                    document.SetParameterValue("mail", Operators.AddObject("Email: ", dataSet.KORISNIK.Rows[0]["EMAIL"]));
                    document.SetParameterValue("OIB", Operators.AddObject("OIB:", dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
                    document.SetParameterValue("OBRACUNAO", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTOSOBA"]));
                    document.SetParameterValue("PREDSTAVNIK", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["PREZIMEIMEOVLASTENEOSOBE"]));
                    document.SetParameterValue("tipRacuna", ((bool)dataSet.KORISNIK.Rows[0]["OBVEZNIKPDVA"] ? "R-1 " : string.Empty));

                    if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "45065170578", false))
                    {
                        document.SetParameterValue("NAPOMENAPOSLOVNI", "Poslovni edukator d.o.o. upisan je u Trgovačkom sudu u Splitu:Tt-10/1130-4, MBS:060228672. \r\nTemeljni kapital 20.000,00 kn,uplaćen u cijelosti. Član uprave: Ivana Ban.");
                    }
                    else if (Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "17847110267", false))
                    {
                        document.SetParameterValue("NAPOMENAPOSLOVNI", "TOOLS4Schools d.o.o. za računovodstvo, Gračanska c. 22, Zagreb; Trgovački sud u Zagrebu MBS:080911316; Temeljni kapital: 20.000,00 uplaćen u cijelosti; Direktor: Marko Krznarić; Oznaka operatera: Boris Lemić");
                    }
                    else if (!Operators.ConditionalCompareObjectEqual(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"], "61456000823", false))
                    {
                        document.SetParameterValue("NAPOMENAPOSLOVNI", " ");
                    }
                }

                string strAttachments = My.MyProject.Computer.FileSystem.SpecialDirectories.Temp + @"\Racun_broj_" + Conversions.ToString(current.Cells[0].Value) + ".pdf";
                //string strAttachmentsZip = My.MyProject.Computer.FileSystem.SpecialDirectories.Temp + @"\Racun_broj_" + Conversions.ToString(current.Cells[0].Value) + ".gz";
                document.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachments);


                //FileStream sourceFileStream = File.OpenRead(strAttachments);
                //FileStream destFileStream = File.Create(strAttachmentsZip);

                //GZipStream compressingStream = new GZipStream(destFileStream,
                //    CompressionMode.Compress);

                //byte[] bytes = new byte[2048];
                //int bytesRead;
                //while ((bytesRead = sourceFileStream.Read(bytes, 0, bytes.Length)) != 0)
                //{
                //    compressingStream.Write(bytes, 0, bytesRead);
                //}

                //sourceFileStream.Close();
                //compressingStream.Close();
                //destFileStream.Close();


                string pattern = @"[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)[a-zA-Z0-9]@[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)(\.[a-zA-Z]{2,4})";
                try
                {
                    enumerator2 = set2.RACUN.Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        DataRow row2 = (DataRow) enumerator2.Current;
                        cSendMail mail = new cSendMail();
                        if ((DB.N2T(RuntimeHelpers.GetObjectValue(row2["partneremail"]), "") != "") && Regex.IsMatch(Conversions.ToString(row2["partneremail"]), pattern))
                        {
                            this.DesktopAlert(Conversions.ToString(Operators.ConcatenateObject("Šaljem račun ", row2["nazivpartner"])));
                            mail.SendSMTP(Conversions.ToString(dataSet.KORISNIK.Rows[0]["smtpserver"]), 
                                          Conversions.ToString(dataSet.KORISNIK.Rows[0]["emailposiljaoca"]), 
                                          Conversions.ToString(dataSet.KORISNIK.Rows[0]["nazivposiljaoca"]), 
                                          Conversions.ToString(row2["partneremail"]), 
                                          Conversions.ToString(row2["nazivpartner"]), 
                                          Conversions.ToString(dataSet.KORISNIK.Rows[0]["emailposiljaoca"]), 
                                          Conversions.ToString(dataSet.KORISNIK.Rows[0]["emailposiljaoca"]), 
                                          "Racun_broj_" + Conversions.ToString(current.Cells[0].Value), 
                                          Conversions.ToString(Operators.ConcatenateObject(("Poštovani, " + Environment.NewLine + Environment.NewLine +
                                                     "u privitku ove poruke nalazi se " + Environment.NewLine + 
                                                     "dokument Racun_broj_" + Conversions.ToString(current.Cells[0].Value))  + Environment.NewLine + Environment.NewLine, 
                                                     dataSet.KORISNIK.Rows[0]["korisnik1naziv"])), 
                                          "", 
                                          strAttachments,Conversions.ToString(dataSet.KORISNIK.Rows[0]["EmailPort"]), Conversions.ToString(dataSet.KORISNIK.Rows[0]["EmailPassword"]));
                        }
                    }
                    continue;
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
            }
        }

        private void SetSmartPartInfoInformation()
        {
            this.smartPartInfo1.Description = "Fakturiranje";
        }

        public void Storno_Racuna()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.RacunDataSet1, "RACUN"];
            if (manager.Count != 0)
            {
                IEnumerator enumerator = null;
                DataRowView current = (DataRowView) manager.Current;

                if (ProvjeraUF(Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"])))
                {
                    MessageBox.Show("Nije moguće stornirati račun koji je\n\rprenesen iz Učeničkog Fakturiranja!!!");
                    return;
                }
                
                RACUNDataAdapter adapter = new RACUNDataAdapter();
                RACUNDataSet dataSet = new RACUNDataSet();
                adapter.FillByIDRACUNRACUNGODINAIDGODINE(dataSet, Conversions.ToInteger(current["IDRACUN"]), Conversions.ToShort(current["RACUNGODINAIDGODINE"]));
                DataRow row2 = this.RacunDataSet1.RACUN.NewRACUNRow();
                row2["RACUNGODINAIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                row2["idracun"] = this.ZadnjiBrojRacunaUGodini();
                row2["zapredujam"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["zapredujam"]);
                row2["IDPARTNER"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["IDPARTNER"]);
                row2["RACUNGODINAIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                row2["DATUM"] = DateAndTime.Today;
                row2["valuta"] = DateAndTime.Today;
                row2["RAZDOBLJEOD"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["razdobljeod"]);
                row2["RAZDOBLJEDO"] = RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["razdobljedo"]);
                row2["model"] = "01";
                row2["POZIV"] = this.ZadnjiBrojRacunaUGodini().ToString() + "-" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear) + "-" + dataSet.RACUN.Rows[0]["IDPARTNER"].ToString() + Razno.KontrolniBroj(this.ZadnjiBrojRacunaUGodini().ToString() + "-" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear) + "-" + dataSet.RACUN.Rows[0]["IDPARTNER"].ToString());
                row2["NAPOMENA"] = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Storno računa br. ", current["IDRACUN"]), "-"), current["RACUNGODINAIDGODINE"]);
                row2["Vrsta"] = "SR";
                row2["UkupanIznos"] = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(dataSet.RACUN.Rows[0]["UkupanIznos"])) * -1;
                this.RacunDataSet1.RACUN.Rows.Add(row2);
                DataRow row3; 
                try
                {
                    enumerator = dataSet.RACUNRacunStavke.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        row3 = this.RacunDataSet1.RACUNRacunStavke.NewRACUNRacunStavkeRow();

                        DataRow row = (DataRow) enumerator.Current;
                        row3["IDRACUN"] = this.ZadnjiBrojRacunaUGodini();
                        row3["BROJSTAVKE"] = RuntimeHelpers.GetObjectValue(row["brojstavke"]);
                        row3["NAZIVPROIZVODRACUN"] = RuntimeHelpers.GetObjectValue(row["NAZIVPROIZVODRACUN"]);
                        row3["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(row["IDPROIZVOD"]);
                        row3["CIJENARACUN"] = RuntimeHelpers.GetObjectValue(row["CIJENARACUN"]);
                        row3["RABAT"] = RuntimeHelpers.GetObjectValue(row["RABAT"]);
                        row3["KOLICINA"] = Operators.NegateObject(row["KOLICINA"]);
                        row3["FINPOREZSTOPARACUN"] = RuntimeHelpers.GetObjectValue(row["FINPOREZSTOPARACUN"]);
                        row3["RACUNGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(row["RACUNGODINAIDGODINE"]);

                        this.RacunDataSet1.RACUNRacunStavke.Rows.Add(row3);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
               
                try
                {
                    adapter.Update(this.RacunDataSet1);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
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
                        this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                        this.UltraGrid1.ActiveRow.Selected = true;
                        this.UltraGrid1.Focus();
                    }
                }
            }
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
            if (e.Button.Name == "ToolBarButton3")
            {
                this.PrenesiUGk();
            }
            if (e.Button.Name == "ToolBarButton4")
            {
                this.Izmjena();
            }
            if (e.Button.Name == "ToolBarButton6")
            {
                this.IspisiRacun();
            }
            if (e.Button.Name == "ToolBarButton5")
            {
                this.zaduzi();
            }
            if (e.Button.Name == "ToolBarButton7")
            {
                this.Izradi_Virmane();
            }
            if (e.Button.Name == "ToolBarButton8")
            {
                this.SaljiMailom();
            }
            if (e.Button.Name == "ToolBarButton9")
            {
                this.Storno_Racuna();
            }
            if (e.Button.Name == "ToolBarButton10")
            {
                this.Kopija_racuna();
            }
        }
        
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

        public int ZadnjiBrojRacunaUGodini()
        {
            int num = 0;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            #region MBS.Complete [22.03.2016]
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(IRABROJ  AS INTEGER)) FROM IRA WHERE IRAGODIDGODINE = @GODINA And IRADOKIDDOKUMENT = 3"
            };
            #endregion
            command.Parameters.AddWithValue("@GODINA", mipsed.application.framework.Application.ActiveYear);
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

        public void zaduzi()
        {

            frmZaduzenje zaduzenje = new frmZaduzenje();
            if (zaduzenje.ShowDialog() == DialogResult.OK)
            {
                int zadnji_broj_racuna = 0;
                IEnumerator enumerator = null;
                DateTime razdoblje_od = Conversions.ToDate(zaduzenje.oddatuma.Value);
                DateTime razdoblje_do = Conversions.ToDate(zaduzenje.dodatuma.Value);
                DateTime datum_racuna = Conversions.ToDate(zaduzenje.datumracuna.Value);
                DateTime datum_valute = Conversions.ToDate(zaduzenje.valuta.Value);
                SqlCommand command = new SqlCommand
                {
                    CommandText = "select max(idracun) from racun where racungodinaIDGODINE = '" + Conversions.ToString((int)mipsed.application.framework.Application.ActiveYear) + "'",
                    CommandType = CommandType.Text
                };
                SqlConnection connection = new SqlConnection
                {
                    ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                };
                command.Connection = connection;
                connection.Open();
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(command.ExecuteScalar())))
                {
                    zadnji_broj_racuna = Conversions.ToInteger(command.ExecuteScalar());
                }
                else
                {
                    //bio 1 stavljen na nulu jer ga dolje povečavas pa ode na 2 a treba poceti od 1, pitaj branca ako nije jasno
                    zadnji_broj_racuna = 0;
                }
                connection.Close();
                PREGLEDZADUZENJADataAdapter adapter = new PREGLEDZADUZENJADataAdapter();
                PREGLEDZADUZENJADataSet dataSet = new PREGLEDZADUZENJADataSet();
                VW_ZADUZENI_PARTNERIDataAdapter adapter3 = new VW_ZADUZENI_PARTNERIDataAdapter();
                VW_ZADUZENI_PARTNERIDataSet set2 = new VW_ZADUZENI_PARTNERIDataSet();
                adapter3.Fill(set2);
                adapter.Fill(dataSet);
                RACUNDataAdapter adapter2 = new RACUNDataAdapter();
                RACUNDataSet set = new RACUNDataSet();

                KORISNIKDataAdapter adpKor = new KORISNIKDataAdapter();
                KORISNIKDataSet setKor = new KORISNIKDataSet();

                List<int> idRacuna = new List<int>();

                adpKor.Fill(setKor);

                string oib = setKor.Tables["Korisnik"].Rows[0]["KORISNIKOIB"].ToString();

                try
                {
                    enumerator = set2.VW_ZADUZENI_PARTNERI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        DataRow[] rowArray = dataSet.PARTNERZADUZENJE.Select("IDPARTNER= " + Conversions.ToString(current[0]));
                        if (rowArray.Length > 0)
                        {
                            zadnji_broj_racuna++;
                            DataRow row = set.RACUN.NewRow();
                            row["IDRACUN"] = zadnji_broj_racuna;
                            idRacuna.Add(zadnji_broj_racuna);
                            row["zapredujam"] = false;
                            row["IDPARTNER"] = RuntimeHelpers.GetObjectValue(rowArray[0]["IDPARTNER"]);
                            row["RACUNGODINAIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                            row["DATUM"] = datum_racuna;
                            row["valuta"] = datum_valute;
                            row["RAZDOBLJEOD"] = razdoblje_od;
                            row["RAZDOBLJEDO"] = razdoblje_do;

                            if (oib == "17847110267" || oib == "96443688162")
                            {
                                row["model"] = "00";
                            }
                            else
                            {
                                row["model"] = "01";
                            }

                            row["POZIV"] = zadnji_broj_racuna.ToString() + "-" + Conversions.ToString((int)mipsed.application.framework.Application.ActiveYear).Substring(2, 2) + "-" + rowArray[0]["IDPARTNER"].ToString(); // + Razno.KontrolniBroj(zadnji_broj_racuna.ToString() + "-" + Conversions.ToString((int)mipsed.application.framework.Application.ActiveYear) + "-" + rowArray[0]["IDPARTNER"].ToString());
                            row["NAPOMENA"] = rowArray[0]["UGOVORBROJ"].ToString();
                            set.RACUN.Rows.Add(row);
                            int num3 = rowArray.Length - 1;
                            for (int i = 0; i <= num3; i++)
                            {
                                DataRow row3 = set.RACUNRacunStavke.NewRow();
                                row3["IDRACUN"] = zadnji_broj_racuna;
                                row3["BROJSTAVKE"] = i + 1;
                                row3["NAZIVPROIZVODRACUN"] = RuntimeHelpers.GetObjectValue(rowArray[i]["NAZIVPROIZVOD"]);
                                row3["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(rowArray[i]["IDPROIZVOD"]);
                                row3["CIJENARACUN"] = RuntimeHelpers.GetObjectValue(rowArray[i]["CIJENAZADUZENJA"]);
                                row3["RABAT"] = RuntimeHelpers.GetObjectValue(rowArray[i]["RABATZADUZENJA"]);
                                row3["KOLICINA"] = RuntimeHelpers.GetObjectValue(rowArray[i]["KOLICINAZADUZENJA"]);
                                row3["FINPOREZSTOPARACUN"] = RuntimeHelpers.GetObjectValue(rowArray[i]["FINPOREZSTOPA"]);
                                row3["RACUNGODINAIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                                set.RACUNRacunStavke.Rows.Add(row3);
                            }
                        }
                    }
                    adapter2.Update(set);

                    foreach (var item in idRacuna)
                    {
                        UpdateVrstaUkupanIznos(item);
                    }

                    Interaction.MsgBox("Automatsko fakturiranje završeno!", MsgBoxStyle.OkOnly);
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }

        private void UpdateVrstaUkupanIznos(object id)
        {
            if (id != null)
            {
                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                string year = mipsed.application.framework.Application.ActiveYear.ToString();

                client.ExecuteNonQuery("Update RACUN Set Vrsta = Case When LEN(Vrsta) > 0 Then Vrsta Else 'Rac' End Where IDRacun = '" + id.ToString() + "' And RACUNGODINAIDGODINE = '" + year + "'");
                client.ExecuteNonQuery("Update RACUN Set UkupanIznos = Case When Vrsta Not In ('SR','SU') Then " +
                "(Select Sum(CijenaPDV) From RACUNRacunStavke Where RACUNRacunStavke.IDRACUN = '" + id.ToString() + "' And RACUNRacunStavke.RACUNGODINAIDGODINE = '" + year + "') Else " +
                "(Select Sum(CijenaPDV) * -1 From RACUNRacunStavke Where RACUNRacunStavke.IDRACUN = '" + id.ToString() + "' And RACUNRacunStavke.RACUNGODINAIDGODINE = '" + year + "') End " +
                "Where IDRacun = '" + id.ToString() + "' And RACUNGODINAIDGODINE = '" + year + "'");
            }
        }

        private AutoHideControl _TestSmartPartAutoHideControl;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaTop;

        [CreateNew]
        public RACUNWorkWithController Controller { get; set; }

        [CreateNew]
        public RACUNController Controller2 { get; set; }

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

        private ImageList ImageList2;

        private Panel Panel1;

        private RACUNDataSet RacunDataSet1;

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

        private ToolBarButton ToolBarButton10;

        private ToolBarButton ToolBarButton12;

        private ToolBarButton ToolBarButton13;

        private ToolBarButton ToolBarButton2;

        private ToolBarButton ToolBarButton3;

        private ToolBarButton ToolBarButton4;

        private ToolBarButton ToolBarButton5;

        private ToolBarButton ToolBarButton6;

        private ToolBarButton ToolBarButton7;

        private ToolBarButton ToolBarButton8;

        private ToolBarButton ToolBarButton9;

        private ToolBarButton ToolBarButton11;

        private UltraDesktopAlert UltraDesktopAlert1;

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

