using FinPosModule;
using My.Resources;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FinPosModule.GK
{
    public class frmListaDokumenataGK : Form
    {
        private IContainer components;

        public frmListaDokumenataGK()
        {
            base.Load += new EventHandler(this.frmListaDokumenataGK_Load);
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

        private void frmListaDokumenataGK_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            this.daDokumenti.SelectCommand.Connection = connection;
            this.daDokumenti.SelectCommand.Parameters["@GODINA"].Value = mipsed.application.framework.Application.ActiveYear;
            this.daDokumenti.Fill(this.Dokumenti1);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Table", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJDOKUMENTA");

            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OpisDokumenta");

            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DUGUJE");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTRAZUJE");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SKRACENIDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSTAVAKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STATUSGK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDOKUMENTA");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaDokumenataGK));
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("e6f71f7d-f90f-407b-92ad-6dc9a09b8d07"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("04401f54-2998-4eee-8692-39378f40f6d1"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("e6f71f7d-f90f-407b-92ad-6dc9a09b8d07"), -1);
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Dokumenti1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Dokumenti1 = new dsDokumenti();
            this.UltraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.daDokumenti = new System.Data.SqlClient.SqlDataAdapter();
            this.SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.SqlConnection5 = new System.Data.SqlClient.SqlConnection();
            this.SqlConnection3 = new System.Data.SqlClient.SqlConnection();
            this.SqlConnection2 = new System.Data.SqlClient.SqlConnection();
            this.SqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.imlAkcije = new System.Windows.Forms.ImageList(this.components);
            this.SqlConnection4 = new System.Data.SqlClient.SqlConnection();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmDokumentiGKUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmDokumentiGKUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmDokumentiGKUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmDokumentiGKUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmDokumentiGKAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dokumenti1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dokumenti1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "Table";
            this.UltraGrid1.DataSource = this.Dokumenti1BindingSource;
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance7.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Appearance = appearance7;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.Caption = "Broj dok.";
            ultraGridColumn1.Header.VisiblePosition = 1;


            this.UltraGrid1.DisplayLayout.Appearance = appearance7;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "Opis";
            ultraGridColumn10.Header.VisiblePosition = 2;

            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.TextHAlignAsString = "Right";
            ultraGridColumn2.CellAppearance = appearance6;
            ultraGridColumn2.Format = "#,##0.00";
            ultraGridColumn2.Header.Caption = "Duguje";
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance8.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance8;
            ultraGridColumn3.Format = "#,##0.00";
            ultraGridColumn3.Header.Caption = "Potražuje";
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "Dok";
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn4.Width = 80;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Br.sta.";
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "Šif dok";
            ultraGridColumn6.Header.VisiblePosition = 7;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "Knjižen";
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "Datum";
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn10,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.Name = "Microsoft Sans Serif";
            appearance9.FontData.SizeInPoints = 8F;
            appearance9.ForeColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand1.Header.Appearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.MidnightBlue;
            appearance10.ForeColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand1.Override.HeaderAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.Lavender;
            ultraGridBand1.Override.RowAlternateAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.DarkGray;
            ultraGridBand1.Override.RowAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.CadetBlue;
            appearance13.ForeColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand1.Override.SelectedRowAppearance = appearance13;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance2.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.UltraGrid1.DisplayLayout.CaptionAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.UltraGrid1.DisplayLayout.MaxBandDepth = 1;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            this.UltraGrid1.Location = new System.Drawing.Point(0, 18);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(618, 544);
            this.UltraGrid1.TabIndex = 101;
            this.UltraGrid1.UseAppStyling = false;
            this.UltraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // Dokumenti1BindingSource
            // 
            this.Dokumenti1BindingSource.DataSource = this.Dokumenti1;
            this.Dokumenti1BindingSource.Position = 0;
            // 
            // Dokumenti1
            // 
            this.Dokumenti1.DataSetName = "DOKUMENTI";
            this.Dokumenti1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UltraExplorerBar1
            // 
            this.UltraExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarItem1.Key = "Knjizi";
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            ultraExplorerBarItem1.Settings.AppearancesSmall.Appearance = appearance1;
            ultraExplorerBarItem1.Text = "Proknjiži sve";
            ultraExplorerBarItem2.Key = "Odaberi";
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            ultraExplorerBarItem2.Settings.AppearancesSmall.Appearance = appearance3;
            ultraExplorerBarItem2.Text = "Odaberi";
            ultraExplorerBarItem3.Key = "Zatvori";
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            ultraExplorerBarItem3.Settings.AppearancesSmall.Appearance = appearance4;
            ultraExplorerBarItem3.Text = "Izlaz";
            ultraExplorerBarItem4.Key = "Ispis";
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            ultraExplorerBarItem4.Settings.AppearancesSmall.Appearance = appearance5;
            ultraExplorerBarItem4.Text = "Ispis temeljnica";
            ultraExplorerBarItem4.Visible = false;
            ultraExplorerBarGroup1.Items.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem[] {
            ultraExplorerBarItem1,
            ultraExplorerBarItem2,
            ultraExplorerBarItem3,
            ultraExplorerBarItem4});
            ultraExplorerBarGroup1.Text = "Zadaci";
            this.UltraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.UltraExplorerBar1.Location = new System.Drawing.Point(623, 0);
            this.UltraExplorerBar1.Name = "UltraExplorerBar1";
            this.UltraExplorerBar1.Size = new System.Drawing.Size(161, 562);
            this.UltraExplorerBar1.TabIndex = 102;
            this.UltraExplorerBar1.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.UltraExplorerBar1_ItemClick);
            // 
            // ImageList2
            // 
            this.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // daDokumenti
            // 
            this.daDokumenti.SelectCommand = this.SqlSelectCommand1;
            this.daDokumenti.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("BROJDOKUMENTA", "BROJDOKUMENTA"),
                        new System.Data.Common.DataColumnMapping("OpisDokumenta", "OpisDokumenta"),
                        new System.Data.Common.DataColumnMapping("DUGUJE", "DUGUJE"),
                        new System.Data.Common.DataColumnMapping("POTRAZUJE", "POTRAZUJE"),
                        new System.Data.Common.DataColumnMapping("skracenidokument", "skracenidokument"),
                        new System.Data.Common.DataColumnMapping("BROJSTAVAKA", "BROJSTAVAKA"),
                        new System.Data.Common.DataColumnMapping("IDDOKUMENT", "IDDOKUMENT"),
                        new System.Data.Common.DataColumnMapping("statusgk", "statusgk"),
                        new System.Data.Common.DataColumnMapping("DATUMDOKUMENTA", "DATUMDOKUMENTA")})});
            // 
            // SqlSelectCommand1
            // 
            this.SqlSelectCommand1.CommandText = resources.GetString("SqlSelectCommand1.CommandText");
            this.SqlSelectCommand1.Connection = this.SqlConnection5;
            this.SqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@godina", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GKGODIDGODINE", System.Data.DataRowVersion.Current, "2010")});
            // 
            // SqlConnection5
            // 
            this.SqlConnection5.FireInfoMessageEventOnUserErrors = false;
            // 
            // SqlConnection3
            // 
            this.SqlConnection3.FireInfoMessageEventOnUserErrors = false;
            // 
            // SqlConnection2
            // 
            this.SqlConnection2.FireInfoMessageEventOnUserErrors = false;
            // 
            // SqlConnection1
            // 
            this.SqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // imlAkcije
            // 
            this.imlAkcije.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlAkcije.ImageSize = new System.Drawing.Size(16, 16);
            this.imlAkcije.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SqlConnection4
            // 
            this.SqlConnection4.FireInfoMessageEventOnUserErrors = false;
            // 
            // UltraDockManager1
            // 
            dockableControlPane1.Control = this.UltraGrid1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(-1, 0, 548, 331);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "...";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(726, 562);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _frmDokumentiGKUnpinnedTabAreaLeft
            // 
            this._frmDokumentiGKUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmDokumentiGKUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmDokumentiGKUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmDokumentiGKUnpinnedTabAreaLeft.Name = "_frmDokumentiGKUnpinnedTabAreaLeft";
            this._frmDokumentiGKUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmDokumentiGKUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 562);
            this._frmDokumentiGKUnpinnedTabAreaLeft.TabIndex = 103;
            // 
            // _frmDokumentiGKUnpinnedTabAreaRight
            // 
            this._frmDokumentiGKUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmDokumentiGKUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmDokumentiGKUnpinnedTabAreaRight.Location = new System.Drawing.Point(784, 0);
            this._frmDokumentiGKUnpinnedTabAreaRight.Name = "_frmDokumentiGKUnpinnedTabAreaRight";
            this._frmDokumentiGKUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmDokumentiGKUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 562);
            this._frmDokumentiGKUnpinnedTabAreaRight.TabIndex = 104;
            // 
            // _frmDokumentiGKUnpinnedTabAreaTop
            // 
            this._frmDokumentiGKUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmDokumentiGKUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmDokumentiGKUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmDokumentiGKUnpinnedTabAreaTop.Name = "_frmDokumentiGKUnpinnedTabAreaTop";
            this._frmDokumentiGKUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmDokumentiGKUnpinnedTabAreaTop.Size = new System.Drawing.Size(784, 0);
            this._frmDokumentiGKUnpinnedTabAreaTop.TabIndex = 105;
            // 
            // _frmDokumentiGKUnpinnedTabAreaBottom
            // 
            this._frmDokumentiGKUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmDokumentiGKUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmDokumentiGKUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 562);
            this._frmDokumentiGKUnpinnedTabAreaBottom.Name = "_frmDokumentiGKUnpinnedTabAreaBottom";
            this._frmDokumentiGKUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmDokumentiGKUnpinnedTabAreaBottom.Size = new System.Drawing.Size(784, 0);
            this._frmDokumentiGKUnpinnedTabAreaBottom.TabIndex = 106;
            // 
            // _frmDokumentiGKAutoHideControl
            // 
            this._frmDokumentiGKAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmDokumentiGKAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmDokumentiGKAutoHideControl.Name = "_frmDokumentiGKAutoHideControl";
            this._frmDokumentiGKAutoHideControl.Owner = this.UltraDockManager1;
            this._frmDokumentiGKAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._frmDokumentiGKAutoHideControl.TabIndex = 107;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(623, 562);
            this.WindowDockingArea1.TabIndex = 108;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraGrid1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(618, 562);
            this.DockableWindow1.TabIndex = 109;
            // 
            // frmListaDokumenataGK
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this._frmDokumentiGKAutoHideControl);
            this.Controls.Add(this.UltraExplorerBar1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._frmDokumentiGKUnpinnedTabAreaTop);
            this.Controls.Add(this._frmDokumentiGKUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmDokumentiGKUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmDokumentiGKUnpinnedTabAreaRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimizeBox = false;
            this.Name = "frmListaDokumenataGK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista knjiženih dokumenata u glavnoj knjizi";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dokumenti1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dokumenti1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void KnjiziSveKojiNisuProknjizeni(SqlConnection CNN, DataRow DR)
        {
            IEnumerator<dsDokumenti.TableRow> enumerator = null;
            try
            {
                enumerator = this.Dokumenti1.Table.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DR = enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(DR["STATUSGK"], false, false))
                    {
                        SqlCommand command = new SqlCommand {
                            CommandType = CommandType.StoredProcedure,
                            Connection = CNN,
                            CommandText = "S_FIN_PROMJENA_STATUSA"
                        };
                        command.Parameters.Add("@BROJDOKUMENTA", SqlDbType.Char, 5).Value = RuntimeHelpers.GetObjectValue(DR["BROJDOKUMENTA"]);
                        command.Parameters.Add("@IDDOKUMENT", SqlDbType.Char, 5).Value = RuntimeHelpers.GetObjectValue(DR["iddokument"]);
                        command.Parameters.Add("@GODINA", SqlDbType.Int).Value = mipsed.application.framework.Application.ActiveYear;
                        command.Parameters.Add("@STATUSGK", SqlDbType.Bit).Value = true;
                        try
                        {
                            command.ExecuteNonQuery();
                            DR["STATUSGK"] = true;
                            continue;
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                            
                            //DR["STATUSGK"] = false;
                            
                            //continue;
                        }
                    }
                }
            }
            finally
            {
                if (enumerator != null)
                {
                    enumerator.Dispose();
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
            switch (keyData)
            {
                case Keys.Escape:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    return true;

                case Keys.F10:
                    this.Proknjizi_Sve();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Proknjizi_Sve()
        {
            DataRow row = null;
            SqlConnection cNN = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            cNN.Open();
            this.KnjiziSveKojiNisuProknjizeni(cNN, row);
            cNN.Close();
        }

        private void UltraExplorerBar1_ItemClick(object sender, ItemEventArgs e)
        {
            switch (e.Item.Key)
            {
                case "Odaberi":
                    CurrencyManager manager = (CurrencyManager)this.BindingContext[this.Dokumenti1BindingSource, "TABLE"];

                    if (manager.Count != 0)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Molimo, odaberite dokument.");
                    }

                    break;
                case "Knjizi":
                    this.Proknjizi_Sve();
                    break;

                case "Zatvori":
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
                case "Ispis":

                    using (frmIspisDokumenta objekt = new frmIspisDokumenta())
                    {
                        if (objekt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                            this.Close();
                        }
                    }
                    break;        
            }
        }

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private AutoHideControl _frmDokumentiGKAutoHideControl;

        private UnpinnedTabArea _frmDokumentiGKUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmDokumentiGKUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmDokumentiGKUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmDokumentiGKUnpinnedTabAreaTop;

        public string brojdokumenta
        {
            get
            {
                CurrencyManager manager = (CurrencyManager)this.BindingContext[this.Dokumenti1BindingSource, "TABLE"];

                if (manager.Count == 0)
                    return null;

                DataRowView current = (DataRowView) manager.Current;
                return Conversions.ToString(current["brojdokumenta"]);
            }
        }


        public string opisDokumenta
        {
            get
            {
                CurrencyManager manager = (CurrencyManager)this.BindingContext[this.Dokumenti1BindingSource, "TABLE"];

                if (manager.Count == 0)
                    return null;

                DataRowView current = (DataRowView)manager.Current;
                try
                {
                    return Conversions.ToString(current["OpisDokumenta"]);
                }
                catch { return ""; }
            }
        }

        private SqlDataAdapter daDokumenti;

        private DockableWindow DockableWindow1;

        private dsDokumenti Dokumenti1;

        private BindingSource Dokumenti1BindingSource;

        public string iddokument
        {
            get
            {
                CurrencyManager manager = (CurrencyManager) this.BindingContext[this.Dokumenti1BindingSource, "TABLE"];

                if (manager.Count == 0)
                    return null;

                DataRowView current = (DataRowView) manager.Current;
                return Conversions.ToString(current["iddokument"]);
            }
        }

        private ImageList ImageList2;

        private ImageList imlAkcije;

        private SqlConnection SqlConnection1;

        private SqlConnection SqlConnection2;

        private SqlConnection SqlConnection3;

        private SqlConnection SqlConnection4;

        private SqlConnection SqlConnection5;

        private SqlCommand SqlSelectCommand1;

        private UltraDockManager UltraDockManager1;

        private UltraExplorerBar UltraExplorerBar1;

        private UltraGrid UltraGrid1;

        private WindowDockingArea WindowDockingArea1;
    }
}

