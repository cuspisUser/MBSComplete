namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
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
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [SmartPart]
    public class ProsjekBolovanje : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public ProsjekBolovanje()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Prosjek plaće za bolovanje na teret poslodavca", "Bolovanje");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("zaposlenik");
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("92f6b63e-efa0-435d-af25-7decacd7f421"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a"), -1);
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_OD_BOLOVANJE_POSLODAVAC", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSBRUTO");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SATIUKUPNO");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINAMJESEC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PROSJECNASATNICA");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PROSJECNASATNICA_85POSTO");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraCombo2 = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.UltraCombo1 = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ProsjekgodisnjiAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.UltraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.S_OD_BOLOVANJE_POSLODAVACDataSet1 = new Placa.S_OD_BOLOVANJE_POSLODAVACDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCombo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCombo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_BOLOVANJE_POSLODAVACDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.UltraTextEditor1);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo2);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo1);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(1037, 121);
            this.UltraGroupBox1.TabIndex = 1;
            this.UltraGroupBox1.Text = "Odabir razdoblja";
            // 
            // UltraTextEditor1
            // 
            editorButton1.Key = "zaposlenik";
            editorButton1.Text = "Zaposlenik";
            this.UltraTextEditor1.ButtonsRight.Add(editorButton1);
            this.UltraTextEditor1.Location = new System.Drawing.Point(222, 84);
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            this.UltraTextEditor1.ReadOnly = true;
            this.UltraTextEditor1.Size = new System.Drawing.Size(401, 21);
            this.UltraTextEditor1.TabIndex = 12;
            this.UltraTextEditor1.Text = "Odaberite zaposlenika";
            this.UltraTextEditor1.ValueChanged += new System.EventHandler(this.UltraTextEditor1_ValueChanged);
            this.UltraTextEditor1.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.UltraTextEditor1_EditorButtonClick);
            // 
            // UltraLabel2
            // 
            this.UltraLabel2.Location = new System.Drawing.Point(21, 60);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(184, 23);
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Text = "Do godine i mjeseca obračuna";
            // 
            // UltraLabel1
            // 
            this.UltraLabel1.Location = new System.Drawing.Point(21, 32);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(184, 23);
            this.UltraLabel1.TabIndex = 9;
            this.UltraLabel1.Text = "Od godine i mjeseca obračuna";
            // 
            // UltraCombo2
            // 
            this.UltraCombo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UltraCombo2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraCombo2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraCombo2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraCombo2.Location = new System.Drawing.Point(222, 56);
            this.UltraCombo2.Name = "UltraCombo2";
            this.UltraCombo2.Size = new System.Drawing.Size(200, 22);
            this.UltraCombo2.TabIndex = 7;
            this.UltraCombo2.Text = "UltraCombo2";
            // 
            // UltraCombo1
            // 
            this.UltraCombo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UltraCombo1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraCombo1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraCombo1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraCombo1.LimitToList = true;
            this.UltraCombo1.Location = new System.Drawing.Point(222, 28);
            this.UltraCombo1.Name = "UltraCombo1";
            this.UltraCombo1.Size = new System.Drawing.Size(200, 22);
            this.UltraCombo1.TabIndex = 6;
            this.UltraCombo1.Text = "UltraCombo1";
            // 
            // UltraDockManager1
            // 
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(-15, -15, 200, 110);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "....";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1037, 139);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            // 
            // _ProsjekgodisnjiUnpinnedTabAreaLeft
            // 
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Name = "_ProsjekgodisnjiUnpinnedTabAreaLeft";
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 565);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.TabIndex = 2;
            // 
            // _ProsjekgodisnjiUnpinnedTabAreaRight
            // 
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Location = new System.Drawing.Point(1037, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Name = "_ProsjekgodisnjiUnpinnedTabAreaRight";
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 565);
            this._ProsjekgodisnjiUnpinnedTabAreaRight.TabIndex = 3;
            // 
            // _ProsjekgodisnjiUnpinnedTabAreaTop
            // 
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Name = "_ProsjekgodisnjiUnpinnedTabAreaTop";
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Size = new System.Drawing.Size(1037, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaTop.TabIndex = 4;
            // 
            // _ProsjekgodisnjiUnpinnedTabAreaBottom
            // 
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 565);
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Name = "_ProsjekgodisnjiUnpinnedTabAreaBottom";
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1037, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.TabIndex = 5;
            // 
            // _ProsjekgodisnjiAutoHideControl
            // 
            this._ProsjekgodisnjiAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ProsjekgodisnjiAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiAutoHideControl.Name = "_ProsjekgodisnjiAutoHideControl";
            this._ProsjekgodisnjiAutoHideControl.Owner = this.UltraDockManager1;
            this._ProsjekgodisnjiAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._ProsjekgodisnjiAutoHideControl.TabIndex = 6;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1037, 144);
            this.WindowDockingArea1.TabIndex = 7;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(1037, 139);
            this.DockableWindow1.TabIndex = 8;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "S_OD_BOLOVANJE_POSLODAVAC";
            this.UltraGrid1.DataSource = this.S_OD_BOLOVANJE_POSLODAVACDataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 110;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance13.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance13;
            ultraGridColumn4.Format = "N2";
            ultraGridColumn4.Header.Caption = "Ukupni bruto";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 99;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance14.TextHAlignAsString = "Right";
            ultraGridColumn5.CellAppearance = appearance14;
            ultraGridColumn5.Format = "N2";
            ultraGridColumn5.Header.Caption = "Sati";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "Obračun";
            ultraGridColumn6.Header.VisiblePosition = 7;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance15.TextHAlignAsString = "Right";
            ultraGridColumn7.CellAppearance = appearance15;
            ultraGridColumn7.Format = "N2";
            ultraGridColumn7.Header.Caption = "Prosječna satnica";
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance16.TextHAlignAsString = "Right";
            ultraGridColumn8.CellAppearance = appearance16;
            ultraGridColumn8.Format = "N2";
            ultraGridColumn8.Header.Caption = "Prosječna satnica / 85%";
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance4.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.LightGray;
            appearance5.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance5;
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BorderColor = System.Drawing.Color.Black;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(0, 144);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1037, 421);
            this.UltraGrid1.TabIndex = 0;
            // 
            // S_OD_BOLOVANJE_POSLODAVACDataSet1
            // 
            this.S_OD_BOLOVANJE_POSLODAVACDataSet1.DataSetName = "S_OD_BOLOVANJE_POSLODAVACDataSet";
            // 
            // ProsjekBolovanje
            // 
            this.Controls.Add(this._ProsjekgodisnjiAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaTop);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaBottom);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaLeft);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaRight);
            this.Name = "ProsjekBolovanje";
            this.Size = new System.Drawing.Size(1037, 565);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCombo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCombo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_BOLOVANJE_POSLODAVACDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        public void Podaci(int sifra = 0)
        {
            decimal num2 = 0;
            decimal num4 = 0;
            decimal num5 = 0;
            this.S_OD_BOLOVANJE_POSLODAVACDataSet1.Clear();
            new S_OD_BOLOVANJE_POSLODAVACDataAdapter().Fill(this.S_OD_BOLOVANJE_POSLODAVACDataSet1, Conversions.ToString(this.UltraCombo1.Value), Conversions.ToString(this.UltraCombo2.Value), sifra);
            short num = 0;
            if (this.S_OD_BOLOVANJE_POSLODAVACDataSet1.S_OD_BOLOVANJE_POSLODAVAC.Rows.Count > 0)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.S_OD_BOLOVANJE_POSLODAVACDataSet1.S_OD_BOLOVANJE_POSLODAVAC.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        num5 = decimal.Add(num5, Conversions.ToDecimal(current["satiukupno"]));
                        num2 = decimal.Add(num2, Conversions.ToDecimal(current["iznosbruto"]));
                        num = (short) (num + 1);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
            if (decimal.Compare(num5, decimal.Zero) > 0)
            {
                num4 = DB.RoundUP(decimal.Divide(num2, num5));
            }
            decimal num3 = DB.RoundUP(decimal.Divide(decimal.Multiply(num4, 85M), 100M));
            this.Sumar(num4, num3);
        }

        private void Priprema_Load(object sender, EventArgs e)
        {
            GODINA_I_MJESEC_OBRACUNADataAdapter adapter = new GODINA_I_MJESEC_OBRACUNADataAdapter();
            GODINA_I_MJESEC_OBRACUNADataSet dataSet = new GODINA_I_MJESEC_OBRACUNADataSet();

            adapter.Fill(dataSet);

            this.UltraCombo1.DataSource = dataSet;
            this.UltraCombo2.DataSource = dataSet;
            this.UltraCombo1.DataMember = "GODINA_I_MJESEC_OBRACUNA";
            this.UltraCombo2.DataMember = "GODINA_I_MJESEC_OBRACUNA";

            if (this.UltraCombo1.Rows.Count > 0)
                this.UltraCombo1.SelectedRow = this.UltraCombo1.Rows[0];

            if (this.UltraCombo2.Rows.Count > 0)
                this.UltraCombo2.SelectedRow = this.UltraCombo2.Rows[0];

            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            this.UltraCombo1.ValueMember = "godinaimjesecobracuna";
            this.UltraCombo2.ValueMember = "godinaimjesecobracuna";
            ColumnEnumerator enumerator = this.UltraGrid1.DisplayLayout.Bands[0].Columns.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraGridColumn current = enumerator.Current;
                if (current.DataType == Type.GetType("System.Decimal"))
                {
                    if (current.Key != "koeficijent")
                    {
                        current.MaskInput = "{double:9.2}";
                    }
                    else
                    {
                        current.MaskInput = "{double:4.3}";
                    }
                }
            }
        }

        [CommandHandler("Snimi")]
        public void SnimiHandler(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            SaveFileDialog dialog2 = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                FileName = "Bolovanje_poslodavac",
                RestoreDirectory = true
            };
            dialog2.ShowDialog();
            try
            {
                this.UltraGridExcelExporter1.Export(this.UltraGrid1, dialog2.FileName);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        public void Sumar(decimal pros, decimal pros85)
        {
            UltraGridBand band = this.UltraGrid1.DisplayLayout.Bands[0];
            band.Summaries.Clear();


            SummarySettings settings = band.Summaries.Add("Ukupnobruto", SummaryType.Custom, new OrderTotalsSummary(), band.Columns["iznosbruto"], SummaryPosition.UseSummaryPositionColumn, band.Columns["iznosbruto"]);
            settings.DisplayFormat = "{0:N2}";
            settings.Appearance.TextHAlign = HAlign.Right;
            settings.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            settings.Appearance.FontData.Bold = DefaultableBoolean.True;
            settings.Appearance.ForeColor = Color.Black;
            settings.Appearance.BackColor = Color.WhiteSmoke;
            band.SummaryFooterCaption = "Prosjek";


            SummarySettings settings2 = band.Summaries.Add("satiukupno", SummaryType.Custom, new SatiUkupnoSumar(), band.Columns["satiukupno"], SummaryPosition.UseSummaryPositionColumn, band.Columns["satiukupno"]);
            settings2.DisplayFormat = "{0:N2}";
            settings2.Appearance.TextHAlign = HAlign.Right;
            settings2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            settings2.Appearance.FontData.Bold = DefaultableBoolean.True;
            settings2.Appearance.ForeColor = Color.Black;
            settings2.Appearance.BackColor = Color.WhiteSmoke;


            SummarySettings settings3 = band.Summaries.Add("PROSJECNASATNICA", SummaryType.Custom, new pROSJEKsATI(), band.Columns["PROSJECNASATNICA"], SummaryPosition.UseSummaryPositionColumn, band.Columns["PROSJECNASATNICA"]);
            settings3.DisplayFormat = "{0:N2}";
            settings3.Appearance.TextHAlign = HAlign.Right;
            settings3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            settings3.Appearance.FontData.Bold = DefaultableBoolean.True;
            settings3.Appearance.ForeColor = Color.Black;
            settings3.Appearance.BackColor = Color.WhiteSmoke;


            SummarySettings settings4 = band.Summaries.Add("PROSJECNASATNICA_85POSTO", SummaryType.Custom, new pROSJEKsATI85(), band.Columns["PROSJECNASATNICA_85POSTO"], SummaryPosition.UseSummaryPositionColumn, band.Columns["PROSJECNASATNICA_85POSTO"]);
            settings4.DisplayFormat = "{0:N2}";
            settings4.Appearance.TextHAlign = HAlign.Right;
            settings4.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            settings4.Appearance.FontData.Bold = DefaultableBoolean.True;
            settings4.Appearance.ForeColor = Color.Black;
            settings4.Appearance.BackColor = Color.WhiteSmoke;



            this.UltraGrid1.DisplayLayout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.SummaryFooterAppearance.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Override.SummaryFooterAppearance.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionAppearance.BackColor = Color.Red;
            this.UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionAppearance.ForeColor = Color.White;
        }

        [CommandHandler("Ucitaj")]
        public void UcitajHandler(object sender, EventArgs e)
        {
            this.Podaci(0);
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                RADNIKSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row == null)
                {
                    return;
                }
                this.UltraTextEditor1.Text = Conversions.ToString(row["prezime"]) + "/" + Conversions.ToString(row["ime"]);
                this.Podaci(Conversions.ToInteger(row["idradnik"]));
            }
            if (this.UltraGrid1.Rows.Count > 0)
            {
                this.UltraGrid1.Rows[0].Selected = true;
            }
        }

        private void UltraTextEditor1_ValueChanged(object sender, EventArgs e)
        {
        }

        public AutoHideControl _ProsjekgodisnjiAutoHideControl;

        public UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaBottom;

        public UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaLeft;

        public UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaRight;

        public UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaTop;

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

        public DockableWindow DockableWindow1;

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

        public S_OD_BOLOVANJE_POSLODAVACDataSet S_OD_BOLOVANJE_POSLODAVACDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraCombo UltraCombo1;

        private UltraCombo UltraCombo2;

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private UltraGridExcelExporter UltraGridExcelExporter1;

        private UltraGroupBox UltraGroupBox1;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel2;

        public UltraTextEditor UltraTextEditor1;

        public WindowDockingArea WindowDockingArea1;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

