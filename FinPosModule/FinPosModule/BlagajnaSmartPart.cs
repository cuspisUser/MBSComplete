using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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

namespace FinPosModule
{

    [SmartPart]
    public class BlagajnaSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private BLAGAJNADataAdapter da;
        private int dokument;
        private DataRowView drv;
        private SmartPartInfoProvider infoProvider;
        private string kontoblag;
        private string mjesto;
        private DateTime pocetni;
        private SmartPartInfo smartPartInfo1;
        private DateTime zavrsni;

        public BlagajnaSmartPart()
        {
            base.Load += new EventHandler(this.BlagajnaSmartPart_Load);
            this.da = new BLAGAJNADataAdapter();
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Blagajničko poslovanje", "BlagajnaSmartPart");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void BlagajnaSmartPart_Load(object sender, EventArgs e)
        {
            new BLGVRSTEDOKDataAdapter().Fill(this.BlgvrstedokDataSet1);
            KONTODataAdapter adapter2 = new KONTODataAdapter();
            ORGJEDDataAdapter adapter4 = new ORGJEDDataAdapter();
            MJESTOTROSKADataAdapter adapter3 = new MJESTOTROSKADataAdapter();
            adapter2.Fill(this.KontoDataSet1);
            adapter4.Fill(this.OrgjedDataSet1);
            adapter3.Fill(this.MjestotroskaDataSet1);
            DateTime pocetni = mipsed.application.framework.Application.Pocetni;
            DateTime zavrsni = mipsed.application.framework.Application.Zavrsni;
            this.MakeEnterActLikeTab(this.UltraGrid1);
            this.MakeEnterActLikeTab(this.UltraGrid2);
        }

        public void Brisi_stavku()
        {
            if (this.BlagajnaDataSet1.BLAGAJNA.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite blagajnu", MsgBoxStyle.Information, "Financijsko poslovanje");
            }
            else
            {
                if (this.UltraGrid1.ActiveRow != null)
                {
                    int index = this.UltraGrid1.ActiveRow.Index;
                }
                DataRowView current = (DataRowView) this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne"].Current;
                if (Interaction.MsgBox("Želite li stvarno obrisati redak?", MsgBoxStyle.YesNo, "Potvrdite brisanje") == MsgBoxResult.Yes)
                {
                    current.Delete();
                    this.Spremi_Promjene();
                }
            }
        }

        public void Brisi_stavku_kontiranja()
        {
            if (this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne.BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Count == 0)
            {
                Interaction.MsgBox("Za odabranu isplatnicu / uplatnicu ne postoji kontiranje", MsgBoxStyle.Critical, "Blagajna");
            }
            else
            {
                if (this.UltraGrid1.ActiveRow != null)
                {
                    int index = this.UltraGrid1.ActiveRow.Index;
                }
                DataRowView current = (DataRowView) this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne.BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Current;
                if (Interaction.MsgBox("Želite li stvarno obrisati redak?", MsgBoxStyle.YesNo, "Blagajna-potvrda brisanja") == MsgBoxResult.Yes)
                {
                    current.Delete();
                    this.Spremi_Promjene();
                }
            }
        }

        public object Broj_Dokumenta_U_GK()
        {
            object objectValue = new object();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(BROJDOKUMENTA) FROM GKSTAVKA WHERE IDDOKUMENT = @IDDOKUMENT and gkgodidgodine =" + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear)
            };
            command.Parameters.AddWithValue("@IDDOKUMENT", this.dokument);
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

        public int Broj_Isplatnice()
        {
            if (this.BlagajnaDataSet1.BLAGAJNAStavkeBlagajne.Rows.Count > 0)
            {
                return Convert.ToInt32(decimal.Add(DB.N20(RuntimeHelpers.GetObjectValue(this.BlagajnaDataSet1.BLAGAJNAStavkeBlagajne.Compute("Max(blgbrojdokumenta)", "idblgvrstedok = 2 and blggodineidgodine = " + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear)))), decimal.One));
            }
            return 1;
        }

        public int Broj_Uplatnice()
        {
            if (this.BlagajnaDataSet1.BLAGAJNAStavkeBlagajne.Rows.Count > 0)
            {
                return Convert.ToInt32(decimal.Add(DB.N20(RuntimeHelpers.GetObjectValue(this.BlagajnaDataSet1.BLAGAJNAStavkeBlagajne.Compute("Max(blgbrojdokumenta)", "idblgvrstedok = 1 and blggodineidgodine = " + Conversions.ToString((int) mipsed.application.framework.Application.ActiveYear)))), decimal.One));
            }
            return 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Unos();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Unos_Kontiranja();
        }

        private void DOKUMENTWorkWith_Load(object sender, EventArgs e)
        {
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BLAGAJNAStavkeBlagajne", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGDOKIDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBLGVRSTEDOK", -1, "MT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("blggodineIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTEDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGBROJDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGDATUMDOKUMENTA", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGSVRHA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGDOKIDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBLGVRSTEDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("blggodineIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGBROJDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGSTAVKEBLAGAJNEKONTOIDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGSTAVKEBLAGAJNEKONTONAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGMTIDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGMTNAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGORGJEDIDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGORGJEDNAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGIZNOSKONTIRANJA");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGDOKIDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBLGVRSTEDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("blggodineIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGBROJDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGSTAVKEBLAGAJNEKONTOIDKONTO", -1, "KONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGSTAVKEBLAGAJNEKONTONAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGMTIDMJESTOTROSKA", -1, "UltraDropDown1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGMTNAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGORGJEDIDORGJED", -1, "OJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGORGJEDNAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BLGIZNOSKONTIRANJA");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("eae30258-ba98-45f2-ad7e-c916484da5f3"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("b67426b5-5ebc-4f2f-ae65-0118bb54250c"), new System.Guid("56197279-6a36-4904-a6e2-61717380db85"), 0, new System.Guid("eae30258-ba98-45f2-ad7e-c916484da5f3"), 0);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("3963cbf2-b6bd-485e-8877-d2d1c747ea40"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("eb851090-b466-4325-b0ee-69cb39602968"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("3963cbf2-b6bd-485e-8877-d2d1c747ea40"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("5ead4618-d915-4548-91d0-7f2c735f16a8"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("86be24ba-4a90-4b7b-9622-354516d4b205"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("5ead4618-d915-4548-91d0-7f2c735f16a8"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane4 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("56197279-6a36-4904-a6e2-61717380db85"));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BLGVRSTEDOK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBLGVRSTEDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTEDOK");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MJESTOTROSKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mt");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ORGJED", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oj");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.ToolBar1 = new System.Windows.Forms.ToolBar();
            this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.BlagajnaDataSet1 = new Placa.BLAGAJNADataSet();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.ToolBar2 = new System.Windows.Forms.ToolBar();
            this.ToolBar2Button1 = new System.Windows.Forms.ToolBarButton();
            this.ToolBar2Button2 = new System.Windows.Forms.ToolBarButton();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._BlagajnaSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BlagajnaSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BlagajnaSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BlagajnaSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BlagajnaSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.MT = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.BlgvrstedokDataSet1 = new Placa.BLGVRSTEDOKDataSet();
            this.MjestotroskaDataSet1 = new Placa.MJESTOTROSKADataSet();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.UltraDropDown1 = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.OJ = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.KONTO = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea4 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlagajnaDataSet1)).BeginInit();
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlgvrstedokDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KONTO)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.WindowDockingArea3.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.ToolBar1);
            this.Panel2.Location = new System.Drawing.Point(0, 18);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1090, 62);
            this.Panel2.TabIndex = 28;
            // 
            // ToolBar1
            // 
            this.ToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBarButton1,
            this.ToolBarButton2,
            this.ToolBarButton3,
            this.ToolBarButton6,
            this.ToolBarButton4,
            this.ToolBarButton5});
            this.ToolBar1.ButtonSize = new System.Drawing.Size(32, 32);
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToolBar1.ImageList = this.ImageList1;
            this.ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ToolBar1.MinimumSize = new System.Drawing.Size(0, 60);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            this.ToolBar1.Size = new System.Drawing.Size(1090, 60);
            this.ToolBar1.TabIndex = 1;
            this.ToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
            // 
            // ToolBarButton1
            // 
            this.ToolBarButton1.ImageIndex = 12;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.Text = "Unesi";
            // 
            // ToolBarButton2
            // 
            this.ToolBarButton2.ImageIndex = 11;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.Text = "Briši";
            // 
            // ToolBarButton3
            // 
            this.ToolBarButton3.ImageIndex = 5;
            this.ToolBarButton3.Name = "ToolBarButton3";
            this.ToolBarButton3.Text = "Ispiši dnevnik";
            // 
            // ToolBarButton6
            // 
            this.ToolBarButton6.ImageIndex = 4;
            this.ToolBarButton6.Name = "ToolBarButton6";
            this.ToolBarButton6.Text = "Prijenos u GK";
            // 
            // ToolBarButton4
            // 
            this.ToolBarButton4.ImageIndex = 7;
            this.ToolBarButton4.Name = "ToolBarButton4";
            this.ToolBarButton4.Text = "Uplatnice";
            // 
            // ToolBarButton5
            // 
            this.ToolBarButton5.ImageIndex = 7;
            this.ToolBarButton5.Name = "ToolBarButton5";
            this.ToolBarButton5.Text = "Isplatnice";
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.UltraGrid1);
            this.Panel1.Location = new System.Drawing.Point(0, 18);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1090, 283);
            this.Panel1.TabIndex = 27;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "BLAGAJNAStavkeBlagajne";
            this.UltraGrid1.DataSource = this.BlagajnaDataSet1;
            appearance20.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance20;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "Dokument";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn2.Width = 99;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Broj dok.";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "Datum";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 115;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "Svrha";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 434;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "Iznos";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn8.Width = 114;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            ultraGridBand1.SummaryFooterCaption = "Totali:";
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 1;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 3;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 4;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 5;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 6;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 7;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 8;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 9;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 10;
            ultraGridBand2.Columns.AddRange(new object[] {
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
            ultraGridColumn20});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance21;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance22.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance22;
            appearance23.BorderColor = System.Drawing.Color.LightGray;
            appearance23.FontData.BoldAsString = "True";
            appearance23.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance23;
            appearance25.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance25.BorderColor = System.Drawing.Color.Black;
            appearance25.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance25;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(0, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1090, 283);
            this.UltraGrid1.TabIndex = 18;
            this.UltraGrid1.TabStop = false;
            this.UltraGrid1.UseAppStyling = false;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.UltraGrid1_InitializeRow);
            this.UltraGrid1.AfterEnterEditMode += new System.EventHandler(this.UltraGrid1_AfterEnterEditMode);
            this.UltraGrid1.AfterRowsDeleted += new System.EventHandler(this.UltraGrid1_AfterRowsDeleted);
            this.UltraGrid1.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid1_AfterRowUpdate);
            this.UltraGrid1.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.UltraGrid1_BeforeCellActivate);
            this.UltraGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UltraGrid1_KeyDown);
            // 
            // BlagajnaDataSet1
            // 
            this.BlagajnaDataSet1.DataSetName = "BLAGAJNADataSet";
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.ToolBar2);
            this.Panel4.Location = new System.Drawing.Point(0, 18);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1090, 61);
            this.Panel4.TabIndex = 30;
            // 
            // ToolBar2
            // 
            this.ToolBar2.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBar2Button1,
            this.ToolBar2Button2});
            this.ToolBar2.ButtonSize = new System.Drawing.Size(32, 32);
            this.ToolBar2.DropDownArrows = true;
            this.ToolBar2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToolBar2.ImageList = this.ImageList1;
            this.ToolBar2.Location = new System.Drawing.Point(0, 0);
            this.ToolBar2.MinimumSize = new System.Drawing.Size(0, 60);
            this.ToolBar2.Name = "ToolBar2";
            this.ToolBar2.ShowToolTips = true;
            this.ToolBar2.Size = new System.Drawing.Size(1090, 60);
            this.ToolBar2.TabIndex = 2;
            this.ToolBar2.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar2_ButtonClick);
            // 
            // ToolBar2Button1
            // 
            this.ToolBar2Button1.ImageIndex = 12;
            this.ToolBar2Button1.Name = "ToolBar2Button1";
            this.ToolBar2Button1.Text = "Unos stavke";
            // 
            // ToolBar2Button2
            // 
            this.ToolBar2Button2.ImageIndex = 11;
            this.ToolBar2Button2.Name = "ToolBar2Button2";
            this.ToolBar2Button2.Text = "Briši stavku";
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.DataMember = "BLAGAJNAStavkeBlagajne.BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajn" +
                "eKontiranje";
            this.UltraGrid2.DataSource = this.BlagajnaDataSet1;
            appearance15.BackColor = System.Drawing.Color.White;
            this.UltraGrid2.DisplayLayout.Appearance = appearance15;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 7;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 8;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 9;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 10;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 2;
            ultraGridColumn25.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn26.Header.VisiblePosition = 4;
            ultraGridColumn26.Width = 127;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 1;
            ultraGridColumn27.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn28.Header.VisiblePosition = 5;
            ultraGridColumn28.Width = 142;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 0;
            ultraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn30.Header.VisiblePosition = 6;
            ultraGridColumn30.Width = 148;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.Caption = "Iznos kontiranja";
            ultraGridColumn31.Header.VisiblePosition = 3;
            ultraGridColumn31.MaskInput = "-nnnnnnnnn.nn";
            ultraGridBand3.Columns.AddRange(new object[] {
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
            ultraGridBand3.SummaryFooterCaption = "Totali:";
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance16;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            appearance17.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance17;
            appearance18.BorderColor = System.Drawing.Color.LightGray;
            appearance18.FontData.BoldAsString = "True";
            appearance18.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance19.BorderColor = System.Drawing.Color.Black;
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid2.Location = new System.Drawing.Point(0, 475);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(1090, 342);
            this.UltraGrid2.TabIndex = 19;
            this.UltraGrid2.TabStop = false;
            this.UltraGrid2.UseAppStyling = false;
            this.UltraGrid2.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid2_AfterCellUpdate);
            this.UltraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
            this.UltraGrid2.AfterEnterEditMode += new System.EventHandler(this.UltraGrid2_AfterEnterEditMode);
            this.UltraGrid2.AfterRowsDeleted += new System.EventHandler(this.UltraGrid2_AfterRowsDeleted);
            this.UltraGrid2.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid2_AfterRowUpdate);
            this.UltraGrid2.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.UltraGrid2_BeforeCellDeactivate);
            this.UltraGrid2.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UltraGrid2_CellDataError);
            this.UltraGrid2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UltraGrid2_KeyDown);
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("3963cbf2-b6bd-485e-8877-d2d1c747ea40");
            dockableControlPane1.Control = this.Panel2;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(29, 35, 644, 68);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Uplatnice / isplatnice";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1090, 80);
            dockAreaPane2.DockedBefore = new System.Guid("5ead4618-d915-4548-91d0-7f2c735f16a8");
            dockableControlPane2.Control = this.Panel1;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(468, 109, 200, 100);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Popis uplatnica i isplatnica";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(1090, 301);
            dockAreaPane3.DockedBefore = new System.Guid("56197279-6a36-4904-a6e2-61717380db85");
            dockableControlPane3.Control = this.Panel4;
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(19, 385, 843, 56);
            dockableControlPane3.Size = new System.Drawing.Size(100, 100);
            dockableControlPane3.Text = "Kontiranje uplatnica / isplatnica";
            dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane3});
            dockAreaPane3.Size = new System.Drawing.Size(1090, 79);
            dockAreaPane4.Size = new System.Drawing.Size(1090, 80);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3,
            dockAreaPane4});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _BlagajnaSmartPartUnpinnedTabAreaLeft
            // 
            this._BlagajnaSmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._BlagajnaSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._BlagajnaSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._BlagajnaSmartPartUnpinnedTabAreaLeft.Name = "_BlagajnaSmartPartUnpinnedTabAreaLeft";
            this._BlagajnaSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._BlagajnaSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 817);
            this._BlagajnaSmartPartUnpinnedTabAreaLeft.TabIndex = 13;
            // 
            // _BlagajnaSmartPartUnpinnedTabAreaRight
            // 
            this._BlagajnaSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._BlagajnaSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._BlagajnaSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1090, 0);
            this._BlagajnaSmartPartUnpinnedTabAreaRight.Name = "_BlagajnaSmartPartUnpinnedTabAreaRight";
            this._BlagajnaSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._BlagajnaSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 817);
            this._BlagajnaSmartPartUnpinnedTabAreaRight.TabIndex = 14;
            // 
            // _BlagajnaSmartPartUnpinnedTabAreaTop
            // 
            this._BlagajnaSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._BlagajnaSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._BlagajnaSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._BlagajnaSmartPartUnpinnedTabAreaTop.Name = "_BlagajnaSmartPartUnpinnedTabAreaTop";
            this._BlagajnaSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._BlagajnaSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1090, 0);
            this._BlagajnaSmartPartUnpinnedTabAreaTop.TabIndex = 15;
            // 
            // _BlagajnaSmartPartUnpinnedTabAreaBottom
            // 
            this._BlagajnaSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._BlagajnaSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._BlagajnaSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 817);
            this._BlagajnaSmartPartUnpinnedTabAreaBottom.Name = "_BlagajnaSmartPartUnpinnedTabAreaBottom";
            this._BlagajnaSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._BlagajnaSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1090, 0);
            this._BlagajnaSmartPartUnpinnedTabAreaBottom.TabIndex = 16;
            // 
            // _BlagajnaSmartPartAutoHideControl
            // 
            this._BlagajnaSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._BlagajnaSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._BlagajnaSmartPartAutoHideControl.Name = "_BlagajnaSmartPartAutoHideControl";
            this._BlagajnaSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._BlagajnaSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 817);
            this._BlagajnaSmartPartAutoHideControl.TabIndex = 17;
            // 
            // MT
            // 
            this.MT.DataMember = "BLGVRSTEDOK";
            this.MT.DataSource = this.BlgvrstedokDataSet1;
            appearance2.BackColor = System.Drawing.Color.White;
            this.MT.DisplayLayout.Appearance = appearance2;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn43.Header.Caption = "Šif.dok.";
            ultraGridColumn43.Header.VisiblePosition = 0;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn44.Header.Caption = "Vrsta dok.";
            ultraGridColumn44.Header.VisiblePosition = 1;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn43,
            ultraGridColumn44});
            ultraGridBand7.UseRowLayout = true;
            this.MT.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.MT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.MT.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.MT.DisplayLayout.Override.CellPadding = 3;
            appearance4.TextHAlignAsString = "Left";
            this.MT.DisplayLayout.Override.HeaderAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.LightGray;
            appearance5.TextVAlignAsString = "Middle";
            this.MT.DisplayLayout.Override.RowAppearance = appearance5;
            this.MT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance6.BorderColor = System.Drawing.Color.Black;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.MT.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.MT.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.MT.DisplayMember = "NAZIVVRSTEDOK";
            this.MT.Location = new System.Drawing.Point(898, 237);
            this.MT.Name = "MT";
            this.MT.Size = new System.Drawing.Size(160, 80);
            this.MT.TabIndex = 21;
            this.MT.ValueMember = "IDBLGVRSTEDOK";
            this.MT.Visible = false;
            // 
            // BlgvrstedokDataSet1
            // 
            this.BlgvrstedokDataSet1.DataSetName = "BLGVRSTEDOKDataSet";
            // 
            // MjestotroskaDataSet1
            // 
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            // 
            // OrgjedDataSet1
            // 
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            // 
            // KontoDataSet1
            // 
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            // 
            // UltraDropDown1
            // 
            this.UltraDropDown1.DataMember = "MJESTOTROSKA";
            this.UltraDropDown1.DataSource = this.MjestotroskaDataSet1;
            appearance14.BackColor = System.Drawing.Color.White;
            this.UltraDropDown1.DisplayLayout.Appearance = appearance14;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 0;
            ultraGridColumn32.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(136, 0);
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn33.Header.VisiblePosition = 1;
            ultraGridColumn33.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(423, 0);
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 2;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34});
            ultraGridBand4.UseRowLayout = true;
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.UltraDropDown1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance24.BackColor = System.Drawing.Color.Transparent;
            this.UltraDropDown1.DisplayLayout.Override.CardAreaAppearance = appearance24;
            this.UltraDropDown1.DisplayLayout.Override.CellPadding = 3;
            appearance26.TextHAlignAsString = "Left";
            this.UltraDropDown1.DisplayLayout.Override.HeaderAppearance = appearance26;
            appearance7.BorderColor = System.Drawing.Color.LightGray;
            appearance7.TextVAlignAsString = "Middle";
            this.UltraDropDown1.DisplayLayout.Override.RowAppearance = appearance7;
            this.UltraDropDown1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance8.BorderColor = System.Drawing.Color.Black;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.UltraDropDown1.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.UltraDropDown1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraDropDown1.DisplayMember = "IDMJESTOTROSKA";
            this.UltraDropDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraDropDown1.Location = new System.Drawing.Point(898, 126);
            this.UltraDropDown1.Name = "UltraDropDown1";
            this.UltraDropDown1.Size = new System.Drawing.Size(160, 80);
            this.UltraDropDown1.TabIndex = 23;
            this.UltraDropDown1.ValueMember = "IDMJESTOTROSKA";
            this.UltraDropDown1.Visible = false;
            // 
            // OJ
            // 
            this.OJ.DataMember = "ORGJED";
            this.OJ.DataSource = this.OrgjedDataSet1;
            appearance9.BackColor = System.Drawing.Color.White;
            this.OJ.DisplayLayout.Appearance = appearance9;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 0;
            ultraGridColumn35.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn35.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn35.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(142, 0);
            ultraGridColumn35.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn35.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.VisiblePosition = 1;
            ultraGridColumn36.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn36.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn36.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(420, 0);
            ultraGridColumn36.RowLayoutColumnInfo.SpanX = 10;
            ultraGridColumn36.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 2;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37});
            ultraGridBand5.UseRowLayout = true;
            this.OJ.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.OJ.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.OJ.DisplayLayout.Override.CardAreaAppearance = appearance10;
            this.OJ.DisplayLayout.Override.CellPadding = 3;
            appearance11.TextHAlignAsString = "Left";
            this.OJ.DisplayLayout.Override.HeaderAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.LightGray;
            appearance12.TextVAlignAsString = "Middle";
            this.OJ.DisplayLayout.Override.RowAppearance = appearance12;
            this.OJ.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance13.BorderColor = System.Drawing.Color.Black;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.OJ.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            this.OJ.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.OJ.Location = new System.Drawing.Point(949, 341);
            this.OJ.Name = "OJ";
            this.OJ.Size = new System.Drawing.Size(99, 70);
            this.OJ.TabIndex = 24;
            this.OJ.ValueMember = "IDORGJED";
            this.OJ.Visible = false;
            // 
            // KONTO
            // 
            this.KONTO.DataMember = "KONTO";
            this.KONTO.DataSource = this.KontoDataSet1;
            appearance27.BackColor = System.Drawing.Color.White;
            this.KONTO.DisplayLayout.Appearance = appearance27;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 0;
            ultraGridColumn38.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn38.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn38.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(135, 0);
            ultraGridColumn38.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn38.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn39.Header.VisiblePosition = 1;
            ultraGridColumn39.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn39.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn39.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(382, 0);
            ultraGridColumn39.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn39.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn40.Header.VisiblePosition = 2;
            ultraGridColumn40.Hidden = true;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn41.Header.VisiblePosition = 3;
            ultraGridColumn41.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn41.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn41.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn41.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn42.Header.VisiblePosition = 4;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42});
            ultraGridBand6.UseRowLayout = true;
            this.KONTO.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.KONTO.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.KONTO.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.KONTO.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.KONTO.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance28.BackColor = System.Drawing.Color.Transparent;
            this.KONTO.DisplayLayout.Override.CardAreaAppearance = appearance28;
            this.KONTO.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.KONTO.DisplayLayout.Override.CellPadding = 3;
            this.KONTO.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance29.TextHAlignAsString = "Left";
            this.KONTO.DisplayLayout.Override.HeaderAppearance = appearance29;
            this.KONTO.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance30.BorderColor = System.Drawing.Color.LightGray;
            appearance30.TextVAlignAsString = "Middle";
            this.KONTO.DisplayLayout.Override.RowAppearance = appearance30;
            appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance.BorderColor = System.Drawing.Color.Black;
            appearance.ForeColor = System.Drawing.Color.Black;
            this.KONTO.DisplayLayout.Override.SelectedRowAppearance = appearance;
            this.KONTO.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.KONTO.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.KONTO.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.KONTO.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.KONTO.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.KONTO.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.KONTO.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.KONTO.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.KONTO.Location = new System.Drawing.Point(961, 35);
            this.KONTO.Name = "KONTO";
            this.KONTO.Size = new System.Drawing.Size(97, 80);
            this.KONTO.TabIndex = 26;
            this.KONTO.ValueMember = "IDKONTO";
            this.KONTO.Visible = false;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1090, 85);
            this.WindowDockingArea1.TabIndex = 31;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.Panel2);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(1090, 80);
            this.DockableWindow1.TabIndex = 34;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 85);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(1090, 306);
            this.WindowDockingArea2.TabIndex = 32;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(1090, 301);
            this.DockableWindow2.TabIndex = 35;
            // 
            // WindowDockingArea3
            // 
            this.WindowDockingArea3.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea3.Location = new System.Drawing.Point(0, 391);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(1090, 84);
            this.WindowDockingArea3.TabIndex = 33;
            // 
            // DockableWindow3
            // 
            this.DockableWindow3.Controls.Add(this.Panel4);
            this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(1090, 79);
            this.DockableWindow3.TabIndex = 36;
            // 
            // WindowDockingArea4
            // 
            this.WindowDockingArea4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea4.Location = new System.Drawing.Point(4, 4);
            this.WindowDockingArea4.Name = "WindowDockingArea4";
            this.WindowDockingArea4.Owner = this.UltraDockManager1;
            this.WindowDockingArea4.Size = new System.Drawing.Size(1090, 80);
            this.WindowDockingArea4.TabIndex = 0;
            // 
            // BlagajnaSmartPart
            // 
            this.Controls.Add(this._BlagajnaSmartPartAutoHideControl);
            this.Controls.Add(this.UltraGrid2);
            this.Controls.Add(this.UltraDropDown1);
            this.Controls.Add(this.OJ);
            this.Controls.Add(this.KONTO);
            this.Controls.Add(this.MT);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._BlagajnaSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._BlagajnaSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._BlagajnaSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._BlagajnaSmartPartUnpinnedTabAreaRight);
            this.Name = "BlagajnaSmartPart";
            this.Size = new System.Drawing.Size(1090, 817);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlagajnaDataSet1)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlgvrstedokDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KONTO)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.WindowDockingArea3.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void Ispisi_Dnevnik()
        {
            if (this.BlagajnaDataSet1.BLAGAJNA.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite blagajnu", MsgBoxStyle.Information, "Financijsko poslovanje");
            }
            else
            {
                frmParametriFakturiranja fakturiranja = new frmParametriFakturiranja("NotURA") {
                    Text = "Odabir razdoblja"

                };
                fakturiranja.oddatuma.Value = mipsed.application.framework.Application.Pocetni;
                fakturiranja.dodatuma.Value = mipsed.application.framework.Application.Zavrsni;

            showOdabirDatumaDialog:
                if (fakturiranja.ShowDialog() == DialogResult.OK)
                {
                    if (((DateTime)fakturiranja.oddatuma.Value) > ((DateTime)fakturiranja.dodatuma.Value))
                    {
                        MessageBox.Show("GREŠKA: 'datum OD' je veći od 'datuma DO'!", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        fakturiranja.oddatuma.Value = fakturiranja.dodatuma.Value;

                        goto showOdabirDatumaDialog;
                    }

                    this.Cursor = Cursors.WaitCursor;

                    this.pocetni = Conversions.ToDate(fakturiranja.oddatuma.Value);
                    this.zavrsni = Conversions.ToDate(fakturiranja.dodatuma.Value);

                    try
                    {
                        DateTime time = DateTime.Now;
                        decimal num = 0;
                        S_FIN_DNEVNIKBLAGAJNEDataSet dataSet = new S_FIN_DNEVNIKBLAGAJNEDataSet();
                        new S_FIN_DNEVNIKBLAGAJNEDataAdapter().Fill(dataSet, this.pocetni, this.zavrsni, 5);
                        ReportDocument rpt = new ReportDocument();
                        ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Modal = true,
                            Title = "Pregled izvještaja",
                            Description = "Pregled",
                            Icon = ImageResourcesNew.mbs
                        };
                        rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptDnevnikBlagajne.rpt");
                        rpt.SetDataSource(dataSet);
                        this.Stanje_Na_Dan(ref num, ref time);
                        rpt.SetParameterValue("naziv", "NAZIV KORISNIKA");
                        rpt.SetParameterValue("ADRESA", "ADRESA");
                        rpt.SetParameterValue("opisblg", "Blagajna: ");
                        rpt.SetParameterValue("SALDO", num);
                        rpt.SetParameterValue("NADATUM", time);
                        rpt.SetParameterValue("dodatuma", this.zavrsni);
                        rpt.SetParameterValue("naslov", "Dnevnik blagajne za razdoblje od: " + Conversions.ToString(this.pocetni) + "-" + Conversions.ToString(this.zavrsni));
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
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        public void Ispisi_iSPLATNICE()
        {
            if (this.BlagajnaDataSet1.BLAGAJNA.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite blagajnu", MsgBoxStyle.Information, "Financijsko poslovanje");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;

                int activeYear = mipsed.application.framework.Application.ActiveYear;
                SortedList list = new SortedList();
                RowEnumerator enumerator = this.UltraGrid1.Selected.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    UltraGridRow current = enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(current.Cells["IDBLGVRSTEDOK"].Value, 2, false))
                    {
                        list.Add(RuntimeHelpers.GetObjectValue(current.Cells["BLGBROJDOKUMENTA"].Value), RuntimeHelpers.GetObjectValue(current.Cells["BLGBROJDOKUMENTA"].Value));
                    }
                }

                if (list.Count != 0)
                {
                    try
                    {
                        IEnumerator enumerator2 = null;
                        S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet = new S_FIN_DNEVNIKBLAGAJNEODDODataSet();
                        new S_FIN_DNEVNIKBLAGAJNEODDODataAdapter().Fill(dataSet, Conversions.ToInteger(list.GetByIndex(0)), Conversions.ToInteger(list.GetByIndex(list.Count - 1)), 2, 5, (short)activeYear);
                        try
                        {
                            enumerator2 = dataSet.S_FIN_DNEVNIKBLAGAJNEODDO.Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                DataRow row2 = (DataRow)enumerator2.Current;
                                row2.BeginEdit();
                                row2["BLGslovima"] = Razno.Cash2Text(Conversions.ToDouble(row2["izdatak"]));
                                row2.EndEdit();
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                        ReportDocument document = new ReportDocument();
                        PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                        ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Modal = true,
                            Title = "Pregled izvještaja",
                            Description = "Pregled",
                            Icon = ImageResourcesNew.mbs
                        };
                        document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptUplIspl.rpt");
                        document.SetDataSource(dataSet);
                        document.SetParameterValue("mjesto", this.mjesto);
                        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                        item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                        if (item == null)
                        {
                            item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                        }
                        item.Izvjestaj = document;
                        item.Show(item.Workspaces["main"], info);
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
            }
        }

        public void Ispisi_Uplatnice()
        {
            if (this.BlagajnaDataSet1.BLAGAJNA.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite blagajnu", MsgBoxStyle.Information, "Financijsko poslovanje");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;

                int activeYear = mipsed.application.framework.Application.ActiveYear;
                SortedList list = new SortedList();
                RowEnumerator enumerator = this.UltraGrid1.Selected.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    UltraGridRow current = enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(current.Cells["IDBLGVRSTEDOK"].Value, 1, false))
                    {
                        list.Add(RuntimeHelpers.GetObjectValue(current.Cells["BLGBROJDOKUMENTA"].Value), RuntimeHelpers.GetObjectValue(current.Cells["BLGBROJDOKUMENTA"].Value));
                    }
                }
                if (list.Count != 0)
                {
                    try
                    {
                        IEnumerator enumerator2 = null;
                        S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet = new S_FIN_DNEVNIKBLAGAJNEODDODataSet();
                        new S_FIN_DNEVNIKBLAGAJNEODDODataAdapter().Fill(dataSet, Conversions.ToInteger(list.GetByIndex(0)), Conversions.ToInteger(list.GetByIndex(list.Count - 1)), 1, 5, (short)activeYear);
                        try
                        {
                            enumerator2 = dataSet.S_FIN_DNEVNIKBLAGAJNEODDO.Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                DataRow row2 = (DataRow)enumerator2.Current;
                                row2.BeginEdit();
                                row2["BLGslovima"] = Razno.Cash2Text(Conversions.ToDouble(row2["primitak"]));
                                row2.EndEdit();
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                        ReportDocument document = new ReportDocument();
                        ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Modal = true,
                            Title = "Pregled izvještaja",
                            Description = "Pregled",
                            Icon = ImageResourcesNew.mbs
                        };
                        document.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptUplIspl.rpt");
                        document.SetDataSource(dataSet);
                        document.SetParameterValue("mjesto", this.mjesto);
                        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                        PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                        if (item == null)
                        {
                            item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                        }
                        item.Izvjestaj = document;
                        item.Show(item.Workspaces["main"], info);
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
            }
        }

        private void MakeEnterActLikeTab(UltraGrid Grid)
        {
            GridKeyActionMappings.GridKeyActionMappingEnumerator enumerator = Grid.KeyActionMappings.GetEnumerator();
            while (enumerator.MoveNext())
            {
                GridKeyActionMapping current = enumerator.Current;
                if (current.KeyCode == Keys.Tab)
                {
                    GridKeyActionMapping mapping = new GridKeyActionMapping(Keys.Return, current.ActionCode, current.StateDisallowed, current.StateRequired, current.SpecialKeysDisallowed, current.SpecialKeysRequired);
                    Grid.KeyActionMappings.Add(mapping);
                }
            }
        }

        public void Prenesi()
        {
            if (this.BlagajnaDataSet1.BLAGAJNA.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite blagajnu", MsgBoxStyle.Information, "Financijsko poslovanje");
            }
            else
            {
                frmParametriFakturiranja fakturiranja = new frmParametriFakturiranja("NotURA")
                {
                    Text = "Odabir razdoblja",
                };

                fakturiranja.oddatuma.Value = mipsed.application.framework.Application.Pocetni;
                fakturiranja.dodatuma.Value = mipsed.application.framework.Application.Zavrsni;
                fakturiranja.Button1.Text = "Prenesi";

            showOdabirDatumaDialog:
                if (fakturiranja.ShowDialog() == DialogResult.OK)
                {
                    if (((DateTime)fakturiranja.oddatuma.Value) > ((DateTime)fakturiranja.dodatuma.Value))
                    {
                        MessageBox.Show("GREŠKA: 'datum OD' je veći od 'datuma DO'!", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        fakturiranja.oddatuma.Value = fakturiranja.dodatuma.Value;

                        goto showOdabirDatumaDialog;
                    }

                    int num2 = 0;
                    DataRow current = null;
                    IEnumerator enumerator = null;
                    this.pocetni = Conversions.ToDate(fakturiranja.oddatuma.Value);
                    this.zavrsni = Conversions.ToDate(fakturiranja.dodatuma.Value);
                    S_FIN_BLAGAJNA_U_GKDataSet dataSet = new S_FIN_BLAGAJNA_U_GKDataSet();
                    new S_FIN_BLAGAJNA_U_GKDataAdapter().Fill(dataSet, this.pocetni, this.zavrsni, this.dokument);
                    GKSTAVKADataSet set2 = new GKSTAVKADataSet();
                    int num = Conversions.ToInteger(Operators.AddObject(this.Broj_Dokumenta_U_GK(), 1));
                    short num3 = 1;
                    set2.EnforceConstraints = false;
                    decimal num4 = new decimal();
                    decimal num5 = new decimal();
                    try
                    {
                        enumerator = dataSet.S_FIN_BLAGAJNA_U_GK.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (DataRow)enumerator.Current;
                            if (current["blgstavkeblagajnekontoidkonto"] == DBNull.Value)
                            {
                                num2++;
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
                    if (num2 > 0)
                    {
                        Interaction.MsgBox("Prijenos u GK nije moguće napraviti, postoji " + Conversions.ToString(num2) + "  nekontiranih stavki\r Nekontirane uplatnice/isplatnice označene su crvenom bojom", MsgBoxStyle.Information, "Prijenos blagajne u glavnu knjigu");
                    }
                    else
                    {
                        DataRow row2 = null;
                        IEnumerator enumerator2 = null;
                        try
                        {
                            enumerator2 = dataSet.S_FIN_BLAGAJNA_U_GK.Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                decimal num6 = 0;
                                decimal num7 = 0;
                                current = (DataRow)enumerator2.Current;
                                row2 = set2.GKSTAVKA.NewRow();
                                row2["iddokument"] = this.dokument;
                                row2["brojdokumenta"] = num;
                                row2["DATUMDOKUMENTA"] = this.zavrsni;
                                row2["BROJSTAVKE"] = num3;
                                row2["idorgjed"] = RuntimeHelpers.GetObjectValue(current["blgorgjedidorgjed"]);
                                row2["idmjestotroska"] = RuntimeHelpers.GetObjectValue(current["blgmtidmjestotroska"]);
                                row2["idkonto"] = RuntimeHelpers.GetObjectValue(current["blgstavkeblagajnekontoidkonto"]);
                                row2["opis"] = RuntimeHelpers.GetObjectValue(current["opis"]);
                                row2["gkgodidgodine"] = mipsed.application.framework.Application.ActiveYear;
                                if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(current["izdatak"])), decimal.Zero) > 0)
                                {
                                    num5 = decimal.Add(num5, DB.N20(RuntimeHelpers.GetObjectValue(current["izdatak"])));
                                }
                                else
                                {
                                    num4 = decimal.Add(num4, DB.N20(RuntimeHelpers.GetObjectValue(current["primitak"])));
                                }
                                row2["duguje"] = DB.N20(RuntimeHelpers.GetObjectValue(current["izdatak"]));
                                row2["potrazuje"] = DB.N20(RuntimeHelpers.GetObjectValue(current["primitak"]));
                                row2["idpartner"] = DBNull.Value;
                                row2["zatvoreniizNos"] = 0;
                                row2["STATUSGK"] = 0;
                                num7 = decimal.Add(num7, DB.N20(RuntimeHelpers.GetObjectValue(current["PRIMITAK"])));
                                num6 = decimal.Add(num6, DB.N20(RuntimeHelpers.GetObjectValue(current["IZDATAK"])));
                                set2.GKSTAVKA.Rows.Add(row2);
                                num3 = (short)(num3 + 1);
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                        if (decimal.Compare(num4, decimal.Zero) > 0)
                        {
                            row2 = set2.GKSTAVKA.NewRow();
                            row2["iddokument"] = this.dokument;
                            row2["brojdokumenta"] = num;
                            row2["DATUMDOKUMENTA"] = this.zavrsni;
                            row2["BROJSTAVKE"] = num3;
                            row2["idorgjed"] = RuntimeHelpers.GetObjectValue(current["blgorgjedidorgjed"]);
                            row2["idmjestotroska"] = RuntimeHelpers.GetObjectValue(current["blgmtidmjestotroska"]);
                            row2["idkonto"] = this.kontoblag;
                            row2["opis"] = "Promet blagajne od: " + Conversions.ToString(this.pocetni) + " do " + Conversions.ToString(this.zavrsni);
                            row2["duguje"] = num4;
                            row2["potrazuje"] = 0;
                            row2["idpartner"] = DBNull.Value;
                            row2["zatvoreniizNos"] = 0;
                            row2["STATUSGK"] = 0;
                            row2["gkgodidgodine"] = mipsed.application.framework.Application.ActiveYear;
                            set2.GKSTAVKA.Rows.Add(row2);
                            num3 = (short)(num3 + 1);
                        }
                        if (decimal.Compare(num5, decimal.Zero) > 0)
                        {
                            row2 = set2.GKSTAVKA.NewRow();
                            row2["iddokument"] = this.dokument;
                            row2["brojdokumenta"] = num;
                            row2["DATUMDOKUMENTA"] = this.zavrsni;
                            row2["BROJSTAVKE"] = num3;
                            row2["idorgjed"] = RuntimeHelpers.GetObjectValue(current["blgorgjedidorgjed"]);
                            row2["idmjestotroska"] = RuntimeHelpers.GetObjectValue(current["blgmtidmjestotroska"]);
                            row2["idkonto"] = this.kontoblag;
                            row2["opis"] = "Promet blagajne od: " + Conversions.ToString(this.pocetni) + " do " + Conversions.ToString(this.zavrsni);
                            row2["duguje"] = 0;
                            row2["potrazuje"] = num5;
                            row2["idpartner"] = DBNull.Value;
                            row2["zatvoreniizNos"] = 0;
                            row2["STATUSGK"] = 0;
                            row2["gkgodidgodine"] = mipsed.application.framework.Application.ActiveYear;
                            set2.GKSTAVKA.Rows.Add(row2);
                            num3 = (short)(num3 + 1);
                        }
                        new GKSTAVKADataAdapter().Update(set2);

                        MessageBox.Show("Prijenos u GK je obavljen USPJEŠNO!", "Prijenos u GK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void SetSmartPartInfoInformation()
        {
            this.smartPartInfo1.Description = "test";
        }

        public void Spremi_Promjene()
        {
            try
            {
                this.da.Update(this.BlagajnaDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
        }

        public object Stanje_Na_Dan(ref decimal iznos, ref DateTime datum)
        {
            decimal num = 0;
            decimal num2 = 0;
            object obj2 = new object();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text
            };
            connection.Open();
            command.CommandText = "SELECT sum(blgiznos) FROM blagajnastavkeblagajne WHERE blgDATUMDOKUMENTA < @DATUM AND IDBLGVRSTEDOK = 1  and BLGDOKIDDOKUMENT = 5";
            command.Parameters.AddWithValue("@DATUM", this.pocetni);
            command.Connection = connection;
            try
            {
                num2 = DB.N20(RuntimeHelpers.GetObjectValue(command.ExecuteScalar()));
                if (Information.IsDBNull(num2))
                {
                    num2 = new decimal();
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            command.CommandText = "SELECT sum(blgiznos) FROM blagajnastavkeblagajne WHERE blgDATUMDOKUMENTA < @DATUM AND IDBLGVRSTEDOK = 2  and BLGDOKIDDOKUMENT = 5";
            command.Connection = connection;
            try
            {
                num = DB.N20(RuntimeHelpers.GetObjectValue(command.ExecuteScalar()));
                if (Information.IsDBNull(num))
                {
                    num = new decimal();
                }
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Exception exception2 = exception3;
                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                
            }
            iznos = decimal.Subtract(num2, num);
            datum = this.pocetni;
            datum = datum.AddDays(-1.0);
            connection.Close();
            return obj2;
        }

        private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Name == "ToolBarButton1")
            {
                this.Unos();
            }
            if (e.Button.Name == "ToolBarButton2")
            {
                this.Brisi_stavku();
            }
            if (e.Button.Name == "ToolBarButton3")
            {
                this.Ispisi_Dnevnik();
            }
            if (e.Button.Name == "ToolBarButton4")
            {
                this.Ispisi_Uplatnice();
            }
            if (e.Button.Name == "ToolBarButton5")
            {
                this.Ispisi_iSPLATNICE();
            }
            if (e.Button.Name == "ToolBarButton6")
            {
                this.Prenesi();
            }
        }

        private void ToolBar2_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Name == "ToolBar2Button1")
            {
                this.Unos_Kontiranja();
            }
            if (e.Button.Name == "ToolBar2Button2")
            {
                this.Brisi_stavku_kontiranja();
            }
        }

        private void UltraGrid1_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.UltraGrid1.ActiveCell.Column.Key == "IDBLGVRSTEDOK")
            {
                this.UltraGrid1.ActiveCell.EditorResolved.DropDown();
            }
        }

        private void UltraGrid1_AfterRowsDeleted(object sender, EventArgs e)
        {
            try
            {
                this.UltraGrid1.UpdateData();
                this.da.Update(this.BlagajnaDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
            try
            {
                this.UltraGrid1.UpdateData();
                this.da.Update(this.BlagajnaDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
        }

        private void UltraGrid1_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Column.Key == "IDBLGVRSTEDOK")
            {
                if (this.UltraGrid1.ActiveRow.Cells["IDBLGVRSTEDOK"].Value == DBNull.Value)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            if (e.Cell.Column.Key == "BLGBROJDOKUMENTA")
            {
                if (this.UltraGrid1.ActiveRow.Cells["BLGBROJDOKUMENTA"].Value == DBNull.Value)
                {
                    if (this.UltraGrid1.ActiveRow.Cells["IDBLGVRSTEDOK"].Value != DBNull.Value)
                    {
                        if (this.UltraGrid1.ActiveRow.Cells["IDBLGVRSTEDOK"].Value.ToString() == "1")
                        {
                            this.drv["blgbrojdokumenta"] = this.Broj_Uplatnice();
                        }
                        else
                        {
                            this.drv["blgbrojdokumenta"] = this.Broj_Isplatnice();
                        }
                    }
                    else
                    {
                        this.drv["blgbrojdokumenta"] = this.Broj_Isplatnice();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (!e.Row.HasChild())
            {
                e.Row.Appearance.ForeColor = Color.Red;
            }
        }

        private void UltraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.UltraGrid1.ActiveRow != null) && ((e.KeyCode == Keys.Escape) & (this.UltraGrid1.ActiveRow.Cells["BLGBROJDOKUMENTA"].Text == "")))
            {
                this.UltraGrid1.ActiveRow.Delete(false);
                e.Handled = true;
            }
            if ((this.UltraGrid1.ActiveCell != null) && (((e.KeyCode == Keys.Tab) | (e.KeyCode == Keys.Return)) & (this.UltraGrid1.ActiveCell.Column.Key == "BLGIZNOS")))
            {
                this.Unos();
                e.Handled = true;
            }
        }

        private void UltraGrid2_AfterCellUpdate(object sender, CellEventArgs e)
        {
        }

        private void UltraGrid2_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.UltraGrid2.ActiveCell.Column.Key == "BLGSTAVKEBLAGAJNEKONTOIDKONTO")
            {
                this.UltraGrid2.ActiveCell.EditorResolved.DropDown();
            }
            if (this.UltraGrid2.ActiveCell.Column.Key == "BLGORGJEDIDORGJED")
            {
                this.UltraGrid2.ActiveCell.EditorResolved.DropDown();
            }
            if (this.UltraGrid2.ActiveCell.Column.Key == "BLGMTIDMJESTOTROSKA")
            {
                this.UltraGrid2.ActiveCell.EditorResolved.DropDown();
            }
            if (this.UltraGrid2.ActiveCell.Column.Key == "BLGIZNOSKONTIRANJA")
            {
                this.UltraGrid2.ActiveCell.SelectAll();
            }
        }

        private void UltraGrid2_AfterRowsDeleted(object sender, EventArgs e)
        {
            this.Spremi_Promjene();
        }

        private void UltraGrid2_AfterRowUpdate(object sender, RowEventArgs e)
        {
            this.Spremi_Promjene();
        }

        private void UltraGrid2_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if ((((UltraGrid) sender).ActiveCell.Column.Key == "BLGMTIDMJESTOTROSKA") && (((UltraGrid) sender).ActiveCell.Value == DBNull.Value))
            {
                e.Cancel = true;
            }
        }

        private void UltraGrid2_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (((UltraGrid) sender).ActiveCell.Column.Key == "BLGSTAVKEBLAGAJNEKONTOIDKONTO")
            {
                Interaction.MsgBox("Ne postoji konto u kontnome planu", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
            }
            if (((UltraGrid) sender).ActiveCell.Column.Key == "BLGMTIDMJESTOTROSKA")
            {
                Interaction.MsgBox("Ne postoji mjesto troška", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
            }
            if (((UltraGrid) sender).ActiveCell.Column.Key == "BLGORGJEDIDORGJED")
            {
                Interaction.MsgBox("Ne postoji organizacijska jedinica", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
            }
        }

        private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.UltraGrid2.ActiveCell != null) && (((e.KeyCode == Keys.Tab) | (e.KeyCode == Keys.Return)) & (this.UltraGrid2.ActiveCell.Column.Key == "BLGIZNOSKONTIRANJA")))
            {
                this.Unos_Kontiranja();
                e.Handled = true;
            }
            if ((this.UltraGrid2.ActiveRow != null) && ((e.KeyCode == Keys.Escape) & (this.UltraGrid2.ActiveRow.Cells["BLGORGJEDIDORGJED"].Text == "")))
            {
                this.UltraGrid2.ActiveRow.Delete(false);
                e.Handled = true;
            }
        }

        public void Unos()
        {
            if (this.BlagajnaDataSet1.BLAGAJNA.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite blagajnu", MsgBoxStyle.Information, "Financijsko poslovanje");
            }
            else
            {
                this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne"].AddNew();
                this.drv = (DataRowView) this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne"].Current;
                this.drv["blgdokiddokument"] = this.dokument;
                if ((DateTime.Compare(DateAndTime.Today, this.pocetni) >= 0) & (DateTime.Compare(DateAndTime.Today, this.zavrsni) <= 0))
                {
                    this.drv["blgdatumdokumenta"] = DateAndTime.Today;
                }
                else
                {
                    this.drv["blgdatumdokumenta"] = this.pocetni;
                }
                this.drv["blgsvrha"] = "";
                this.drv["blgiznos"] = 0.0;
                this.drv["blggodineidgodine"] = mipsed.application.framework.Application.ActiveYear;
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        public void Unos_Kontiranja()
        {
            if (this.BlagajnaDataSet1.BLAGAJNA.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite blagajnu", MsgBoxStyle.Information, "Financijsko poslovanje");
            }
            else
            {
                try
                {
                    this.UltraGrid2.UpdateData();
                    this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne.BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].EndCurrentEdit();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    //return;
                }

                this.drv = (DataRowView)this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne"].Current;
                this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne.BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].AddNew();
                DataRowView current = (DataRowView)this.BindingContext[this.BlagajnaDataSet1, "BLAGAJNAStavkeBlagajne.BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje"].Current;
                current["blgdokiddokument"] = RuntimeHelpers.GetObjectValue(this.drv["blgdokiddokument"]);
                current["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.drv["IDBLGVRSTEDOK"]);
                current["BLGBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.drv["BLGBROJDOKUMENTA"]);

                // Matija - ukoliko i dalje puca, onda ovaj uvjet staviti u navodnike i istestirati
                decimal left = DB.N20(RuntimeHelpers.GetObjectValue(this.BlagajnaDataSet1.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.Compute("SUM(BLGIZNOSKONTIRANJA)", 
                    Conversions.ToString("BLGDOKIDDOKUMENT= '" + this.drv["blgdokiddokument"] + "' AND IDBLGVRSTEDOK = '" + this.drv["IDBLGVRSTEDOK"] + "' AND BLGBROJDOKUMENTA = '" + 
                    this.drv["BLGBROJDOKUMENTA"] + "'"))));

                
                if (Operators.ConditionalCompareObjectLessEqual(left, this.drv["BLGIZNOS"], false))
                {
                    current["BLGIZNOSKONTIRANJA"] = Operators.SubtractObject(this.drv["BLGIZNOS"], left);
                }
                else
                {
                    current["BLGIZNOSKONTIRANJA"] = 0;
                }

                if (this.UltraGrid2.Rows.Count > 0)
                {
                    this.UltraGrid2.ActiveRow = this.UltraGrid2.Rows[this.UltraGrid2.Rows.Count - 1];
                    this.UltraGrid2.PerformAction(UltraGridAction.ActivateCell);
                    this.UltraGrid2.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }

        [LocalCommandHandler("OtvoriPostojecu")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            BLAGAJNASelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<BLAGAJNASelectionListWorkItem>("test");
            DataRow row2 = item.ShowModal(true, "", null);
            item.Terminate();
            if (row2 != null)
            {
                IEnumerator enumerator = null;
                this.pocetni = mipsed.application.framework.Application.Pocetni;
                this.zavrsni = mipsed.application.framework.Application.Zavrsni;
                this.BlagajnaDataSet1.Clear();
                this.dokument = Conversions.ToInteger(row2["blgdokiddokument"]);
                this.kontoblag = Conversions.ToString(row2["blgkontoidkonto"]);
                this.da.FillByBLGDOKIDDOKUMENT(this.BlagajnaDataSet1, this.dokument);
                short activeYear = mipsed.application.framework.Application.ActiveYear;
                try
                {
                    enumerator = this.BlagajnaDataSet1.BLAGAJNAStavkeBlagajne.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        if (Operators.ConditionalCompareObjectNotEqual(current["BLGGODINEIDGODINE"], activeYear, false))
                        {
                            current.Delete();
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
                this.BlagajnaDataSet1.AcceptChanges();
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(dataSet);
                this.mjesto = DB.N2T(RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]), "");
            }
        }

        private AutoHideControl _BlagajnaSmartPartAutoHideControl;

        private UnpinnedTabArea _BlagajnaSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _BlagajnaSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _BlagajnaSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _BlagajnaSmartPartUnpinnedTabAreaTop;

        private BLAGAJNADataSet BlagajnaDataSet1;

        private BLGVRSTEDOKDataSet BlgvrstedokDataSet1;

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

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

        private DockableWindow DockableWindow2;

        private DockableWindow DockableWindow3;

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

        private UltraDropDown KONTO;

        private KONTODataSet KontoDataSet1;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private UltraDropDown MT;

        private UltraDropDown OJ;

        private ORGJEDDataSet OrgjedDataSet1;

        private Panel Panel1;

        private Panel Panel2;

        private Panel Panel4;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private ToolBar ToolBar1;

        private ToolBar ToolBar2;

        private ToolBarButton ToolBar2Button1;

        private ToolBarButton ToolBar2Button2;

        private ToolBarButton ToolBarButton1;

        private ToolBarButton ToolBarButton2;

        private ToolBarButton ToolBarButton3;

        private ToolBarButton ToolBarButton4;

        private ToolBarButton ToolBarButton5;

        private ToolBarButton ToolBarButton6;

        private UltraDockManager UltraDockManager1;

        private UltraDropDown UltraDropDown1;

        private UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        private WindowDockingArea WindowDockingArea3;

        private WindowDockingArea WindowDockingArea4;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

