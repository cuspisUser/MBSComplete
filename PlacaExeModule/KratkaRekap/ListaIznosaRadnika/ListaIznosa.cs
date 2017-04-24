namespace ListaIznosaRadnika
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
    using My.Resources;
    using NetAdvantage.Controllers;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [SmartPart]
    public class ListaIznosa : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        private string obracun;
        private SmartPartInfo smartPartInfo1;

        public ListaIznosa(string id = null)
        {
            base.Load += new EventHandler(this.ListaIznosa_Load);
            this.obracun = id;
            this.smartPartInfo1 = new SmartPartInfo("Lista iznosa zaposlenika", "ListaIznosa");
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
            this.components = new Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("SP_LISTA_IZNOSA_RADNIKA", -1);
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column10 = new UltraGridColumn("PREZIME");
            UltraGridColumn column11 = new UltraGridColumn("IME");
            UltraGridColumn column12 = new UltraGridColumn("satibruto");
            UltraGridColumn column13 = new UltraGridColumn("ukupnobruto");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            UltraGridColumn column14 = new UltraGridColumn("KOEFICIJENT");
            UltraGridColumn column15 = new UltraGridColumn("ukupnodoprinosi");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            UltraGridColumn column16 = new UltraGridColumn("ukupnoporeziprirez");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            UltraGridColumn column17 = new UltraGridColumn("netoplaca");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            UltraGridColumn column2 = new UltraGridColumn("ukupnonetonaknade");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            UltraGridColumn column3 = new UltraGridColumn("netoprimanja");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            UltraGridColumn column4 = new UltraGridColumn("ukupnoobustave");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            UltraGridColumn column5 = new UltraGridColumn("UKUPNOZAISPLATU");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            UltraGridColumn column6 = new UltraGridColumn("ukupnoolaksice");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            UltraGridColumn column7 = new UltraGridColumn("UKUPNODOPRINOSINA");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            UltraGridColumn column8 = new UltraGridColumn("POREZKRIZNI");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            UltraGridColumn column9 = new UltraGridColumn("netoplacamanjekrizni");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, new Guid("17370e15-8546-4b2c-a95d-3e8bc54df39a"));
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("17370e15-8546-4b2c-a95d-3e8bc54df39a");
            DockableControlPane pane = new DockableControlPane(new Guid("85626e07-f839-4f38-96b7-5f7acb8b4b20"), floatingParentId, -1, dockedParentId, -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.GroupBox1 = new GroupBox();
            this.sifraObracuna = new UltraMaskedEdit();
            this.radiobtnObracun = new RadioButton();
            this.GroupBox2 = new GroupBox();
            this.radiobtnSortiranjeSifra = new RadioButton();
            this.radiobtnSortiranjePrezime = new RadioButton();
            this.GroupBox3 = new GroupBox();
            this.radiobtnPapirUspravno = new RadioButton();
            this.radiobtnPolozeniIspis = new RadioButton();
            this.SP_LISTA_IZNOSA_RADNIKADataSet1 = new SP_LISTA_IZNOSA_RADNIKADataSet();
            this.gridPregledEkran = new UltraGrid();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._ListaIznosaUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._ListaIznosaUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._ListaIznosaUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._ListaIznosaUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._ListaIznosaAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SP_LISTA_IZNOSA_RADNIKADataSet1.BeginInit();
            ((ISupportInitialize) this.gridPregledEkran).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            appearance2.BackColor = Color.WhiteSmoke;
            this.UltraGroupBox1.Appearance = appearance2;
            this.UltraGroupBox1.Controls.Add(this.GroupBox1);
            this.UltraGroupBox1.Controls.Add(this.GroupBox2);
            this.UltraGroupBox1.Controls.Add(this.GroupBox3);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(0x2db, 0xe2);
            this.UltraGroupBox1.TabIndex = 15;
            this.UltraGroupBox1.Text = "Parametri ispisa";
            this.GroupBox1.Controls.Add(this.sifraObracuna);
            this.GroupBox1.Controls.Add(this.radiobtnObracun);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.GroupBox1.Location = new System.Drawing.Point(6, 0x13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(0x130, 0x33);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Obračun ";
            appearance.BackColor = Color.Yellow;
            this.sifraObracuna.Appearance = appearance;
            this.sifraObracuna.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.sifraObracuna.EditAs = EditAsType.String;
            this.sifraObracuna.Location = new System.Drawing.Point(120, 0x10);
            this.sifraObracuna.Name = "sifraObracuna";
            this.sifraObracuna.PromptChar = ' ';
            this.sifraObracuna.ReadOnly = true;
            this.sifraObracuna.Size = new System.Drawing.Size(100, 20);
            this.sifraObracuna.TabIndex = 2;
            this.sifraObracuna.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.sifraObracuna.TabStop = false;
            this.radiobtnObracun.Checked = true;
            this.radiobtnObracun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.radiobtnObracun.Location = new System.Drawing.Point(10, 0x10);
            this.radiobtnObracun.Name = "radiobtnObracun";
            this.radiobtnObracun.Size = new System.Drawing.Size(0x70, 20);
            this.radiobtnObracun.TabIndex = 0;
            this.radiobtnObracun.TabStop = true;
            this.radiobtnObracun.Text = "&Broj obračuna:";
            this.GroupBox2.Controls.Add(this.radiobtnSortiranjeSifra);
            this.GroupBox2.Controls.Add(this.radiobtnSortiranjePrezime);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.GroupBox2.Location = new System.Drawing.Point(6, 0x48);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(0x130, 0x2a);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Poredak";
            this.radiobtnSortiranjeSifra.Checked = true;
            this.radiobtnSortiranjeSifra.Location = new System.Drawing.Point(8, 0x10);
            this.radiobtnSortiranjeSifra.Name = "radiobtnSortiranjeSifra";
            this.radiobtnSortiranjeSifra.Size = new System.Drawing.Size(0x72, 20);
            this.radiobtnSortiranjeSifra.TabIndex = 0;
            this.radiobtnSortiranjeSifra.TabStop = true;
            this.radiobtnSortiranjeSifra.Text = "&Šifra radnika";
            this.radiobtnSortiranjePrezime.Location = new System.Drawing.Point(0xb6, 0x10);
            this.radiobtnSortiranjePrezime.Name = "radiobtnSortiranjePrezime";
            this.radiobtnSortiranjePrezime.Size = new System.Drawing.Size(0x74, 20);
            this.radiobtnSortiranjePrezime.TabIndex = 1;
            this.radiobtnSortiranjePrezime.Text = "&Prezime i ime";
            this.GroupBox3.Controls.Add(this.radiobtnPapirUspravno);
            this.GroupBox3.Controls.Add(this.radiobtnPolozeniIspis);
            this.GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.GroupBox3.Location = new System.Drawing.Point(6, 0x77);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(0x130, 0x67);
            this.GroupBox3.TabIndex = 5;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Orijentacija papira";
            this.radiobtnPapirUspravno.Checked = true;
            //this.radiobtnPapirUspravno.Image = My.Resources.Resources.portrait;
            this.radiobtnPapirUspravno.Location = new System.Drawing.Point(8, 0x10);
            this.radiobtnPapirUspravno.Name = "radiobtnPapirUspravno";
            this.radiobtnPapirUspravno.Size = new System.Drawing.Size(0x72, 0x51);
            this.radiobtnPapirUspravno.TabIndex = 0;
            this.radiobtnPapirUspravno.TabStop = true;
            this.radiobtnPapirUspravno.Text = "&Uspravno";
            this.radiobtnPapirUspravno.TextAlign = ContentAlignment.BottomCenter;
            this.radiobtnPapirUspravno.TextImageRelation = TextImageRelation.ImageAboveText;
            //this.radiobtnPolozeniIspis.Image = My.Resources.Resources.landscape;
            this.radiobtnPolozeniIspis.Location = new System.Drawing.Point(0xab, 0x10);
            this.radiobtnPolozeniIspis.Name = "radiobtnPolozeniIspis";
            this.radiobtnPolozeniIspis.Size = new System.Drawing.Size(0x74, 0x51);
            this.radiobtnPolozeniIspis.TabIndex = 1;
            this.radiobtnPolozeniIspis.Text = "P&oloženo";
            this.radiobtnPolozeniIspis.TextAlign = ContentAlignment.BottomCenter;
            this.radiobtnPolozeniIspis.TextImageRelation = TextImageRelation.ImageAboveText;
            this.SP_LISTA_IZNOSA_RADNIKADataSet1.DataSetName = "SP_LISTA_IZNOSA_RADNIKADataSet";
            this.gridPregledEkran.DataMember = "SP_LISTA_IZNOSA_RADNIKA";
            this.gridPregledEkran.DataSource = this.SP_LISTA_IZNOSA_RADNIKADataSet1;
            appearance3.BackColor = Color.White;
            this.gridPregledEkran.DisplayLayout.Appearance = appearance3;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.Caption = "Šifra";
            column.Header.VisiblePosition = 0;
            column.Width = 0x34;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.VisiblePosition = 1;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 2;
            column11.Width = 0x58;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.Caption = "Sati";
            column12.Header.VisiblePosition = 3;
            column12.Width = 0x37;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance4.TextHAlignAsString = "Right";
            column13.CellAppearance = appearance4;
            appearance5.TextHAlignAsString = "Right";
            column13.Header.Appearance = appearance5;
            column13.Header.Caption = "Bruto";
            column13.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column13.Header.VisiblePosition = 5;
            column13.MaskInput = "{LOC} n,nnn,nnn.nn";
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 4;
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.TextHAlignAsString = "Right";
            column15.CellAppearance = appearance6;
            appearance7.TextHAlignAsString = "Right";
            column15.Header.Appearance = appearance7;
            column15.Header.Caption = "Doprinosi";
            column15.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column15.Header.VisiblePosition = 6;
            column15.MaskInput = "{LOC} n,nnn,nnn.nn";
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance8.TextHAlignAsString = "Right";
            column16.CellAppearance = appearance8;
            appearance9.TextHAlignAsString = "Right";
            column16.Header.Appearance = appearance9;
            column16.Header.Caption = "Porez i prirez";
            column16.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column16.Header.VisiblePosition = 8;
            column16.MaskInput = "{LOC} n,nnn,nnn.nn";
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance10.TextHAlignAsString = "Right";
            column17.CellAppearance = appearance10;
            appearance11.TextHAlignAsString = "Right";
            column17.Header.Appearance = appearance11;
            column17.Header.Caption = "Neto plaća";
            column17.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column17.Header.VisiblePosition = 9;
            column17.MaskInput = "{LOC} n,nnn,nnn.nn";
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance13.TextHAlignAsString = "Right";
            column2.CellAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            column2.Header.Appearance = appearance14;
            column2.Header.Caption = "Neto naknade";
            column2.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column2.Header.VisiblePosition = 11;
            column2.MaskInput = "{LOC} n,nnn,nnn.nn";
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance15.TextHAlignAsString = "Right";
            column3.CellAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            column3.Header.Appearance = appearance16;
            column3.Header.Caption = "Neto primanja";
            column3.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column3.Header.VisiblePosition = 13;
            column3.MaskInput = "{LOC} n,nnn,nnn.nn";
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance17.TextHAlignAsString = "Right";
            column4.CellAppearance = appearance17;
            appearance18.TextHAlignAsString = "Right";
            column4.Header.Appearance = appearance18;
            column4.Header.Caption = "Obustave";
            column4.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column4.Header.VisiblePosition = 14;
            column4.MaskInput = "{LOC} n,nnn,nnn.nn";
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance19.TextHAlignAsString = "Right";
            column5.CellAppearance = appearance19;
            appearance20.TextHAlignAsString = "Right";
            column5.Header.Appearance = appearance20;
            column5.Header.Caption = "Za isplatu";
            column5.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column5.Header.VisiblePosition = 15;
            column5.MaskInput = "{LOC} n,nnn,nnn.nn";
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance21.TextHAlignAsString = "Right";
            column6.CellAppearance = appearance21;
            appearance22.TextHAlignAsString = "Right";
            column6.Header.Appearance = appearance22;
            column6.Header.Caption = "Olakšice";
            column6.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column6.Header.VisiblePosition = 7;
            column6.MaskInput = "{LOC} n,nnn,nnn.nn";
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance24.TextHAlignAsString = "Right";
            column7.CellAppearance = appearance24;
            appearance25.TextHAlignAsString = "Right";
            column7.Header.Appearance = appearance25;
            column7.Header.Caption = "Doprinosi na";
            column7.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column7.Header.VisiblePosition = 0x10;
            column7.MaskInput = "{LOC} n,nnn,nnn.nn";
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance26.TextHAlignAsString = "Right";
            column8.CellAppearance = appearance26;
            appearance27.TextHAlignAsString = "Right";
            column8.Header.Appearance = appearance27;
            column8.Header.Caption = "Pos.por.";
            column8.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column8.Header.VisiblePosition = 10;
            column8.MaskInput = "{LOC} n,nnn,nnn.nn";
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance28.TextHAlignAsString = "Right";
            column9.CellAppearance = appearance28;
            appearance29.TextHAlignAsString = "Right";
            column9.Header.Appearance = appearance29;
            column9.Header.Caption = "Neto - pos.por";
            column9.Header.TextOrientation = new TextOrientationInfo(0, TextFlowDirection.Horizontal);
            column9.Header.VisiblePosition = 12;
            column9.MaskInput = "{LOC} n,nnn,nnn.nn";
            band.Columns.AddRange(new object[] { 
                column, column10, column11, column12, column13, column14, column15, column16, column17, column2, column3, column4, column5, column6, column7, column8, 
                column9
             });
            this.gridPregledEkran.DisplayLayout.BandsSerializer.Add(band);
            this.gridPregledEkran.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.gridPregledEkran.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.gridPregledEkran.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.gridPregledEkran.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance12.BackColor = Color.Transparent;
            this.gridPregledEkran.DisplayLayout.Override.CardAreaAppearance = appearance12;
            this.gridPregledEkran.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.gridPregledEkran.DisplayLayout.Override.CellPadding = 3;
            this.gridPregledEkran.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance23.TextHAlignAsString = "Left";
            this.gridPregledEkran.DisplayLayout.Override.HeaderAppearance = appearance23;
            this.gridPregledEkran.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance30.BorderColor = Color.LightGray;
            appearance30.TextVAlignAsString = "Middle";
            this.gridPregledEkran.DisplayLayout.Override.RowAppearance = appearance30;
            this.gridPregledEkran.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance31.BackColor = Color.LightSteelBlue;
            appearance31.BorderColor = Color.Black;
            appearance31.ForeColor = Color.Black;
            this.gridPregledEkran.DisplayLayout.Override.SelectedRowAppearance = appearance31;
            this.gridPregledEkran.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.gridPregledEkran.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            this.gridPregledEkran.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.gridPregledEkran.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.gridPregledEkran.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.gridPregledEkran.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.gridPregledEkran.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.gridPregledEkran.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.gridPregledEkran.Dock = DockStyle.Fill;
            this.gridPregledEkran.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.gridPregledEkran.Location = new System.Drawing.Point(0, 0xf9);
            this.gridPregledEkran.Name = "gridPregledEkran";
            this.gridPregledEkran.Size = new System.Drawing.Size(0x2db, 240);
            this.gridPregledEkran.TabIndex = 14;
            this.gridPregledEkran.UseFlatMode = DefaultableBoolean.True;
            pane.Control = this.UltraGroupBox1;
            Rectangle rectangle = new Rectangle(3, 3, 0x142, 0xb2);
            pane.OriginalControlBounds = rectangle;
            pane.Size = new System.Drawing.Size(100, 100);
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            pane2.Size = new System.Drawing.Size(0x2db, 0xf4);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = WindowStyle.Office2007;
            this._ListaIznosaUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._ListaIznosaUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ListaIznosaUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._ListaIznosaUnpinnedTabAreaLeft.Name = "_ListaIznosaUnpinnedTabAreaLeft";
            this._ListaIznosaUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._ListaIznosaUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x1e9);
            this._ListaIznosaUnpinnedTabAreaLeft.TabIndex = 0x10;
            this._ListaIznosaUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._ListaIznosaUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ListaIznosaUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x2db, 0);
            this._ListaIznosaUnpinnedTabAreaRight.Name = "_ListaIznosaUnpinnedTabAreaRight";
            this._ListaIznosaUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._ListaIznosaUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x1e9);
            this._ListaIznosaUnpinnedTabAreaRight.TabIndex = 0x11;
            this._ListaIznosaUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._ListaIznosaUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ListaIznosaUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._ListaIznosaUnpinnedTabAreaTop.Name = "_ListaIznosaUnpinnedTabAreaTop";
            this._ListaIznosaUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._ListaIznosaUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x2db, 0);
            this._ListaIznosaUnpinnedTabAreaTop.TabIndex = 0x12;
            this._ListaIznosaUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._ListaIznosaUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ListaIznosaUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x1e9);
            this._ListaIznosaUnpinnedTabAreaBottom.Name = "_ListaIznosaUnpinnedTabAreaBottom";
            this._ListaIznosaUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._ListaIznosaUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x2db, 0);
            this._ListaIznosaUnpinnedTabAreaBottom.TabIndex = 0x13;
            this._ListaIznosaAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._ListaIznosaAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._ListaIznosaAutoHideControl.Name = "_ListaIznosaAutoHideControl";
            this._ListaIznosaAutoHideControl.Owner = this.UltraDockManager1;
            this._ListaIznosaAutoHideControl.Size = new System.Drawing.Size(0, 0x1e9);
            this._ListaIznosaAutoHideControl.TabIndex = 20;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(0x2db, 0xf9);
            this.WindowDockingArea1.TabIndex = 0x15;
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(0x2db, 0xf4);
            this.DockableWindow1.TabIndex = 0x16;
            this.Controls.Add(this._ListaIznosaAutoHideControl);
            this.Controls.Add(this.gridPregledEkran);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._ListaIznosaUnpinnedTabAreaTop);
            this.Controls.Add(this._ListaIznosaUnpinnedTabAreaBottom);
            this.Controls.Add(this._ListaIznosaUnpinnedTabAreaLeft);
            this.Controls.Add(this._ListaIznosaUnpinnedTabAreaRight);
            this.Name = "ListaIznosa";
            this.Size = new System.Drawing.Size(0x2db, 0x1e9);

            this.UltraGroupBox1.Click += new EventHandler(this.UltraGroupBox1_Click);

            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.SP_LISTA_IZNOSA_RADNIKADataSet1.EndInit();
            ((ISupportInitialize) this.gridPregledEkran).EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Ispis()
        {
            string str = string.Empty;
            string str2 = string.Empty;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            string cmdText = "SELECT mjesecobracuna, godinaobracuna FROM OBRACUN WHERE idobracun = @idobracun";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@idobracun", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(this.sifraObracuna.Value);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    str2 = int.Parse(Conversions.ToString(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(0))))).ToString("00");
                    str = int.Parse(Conversions.ToString(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(1))))).ToString("0000");
                }
                else
                {
                    str2 = "00";
                    str = "0000";
                }
                reader.Close();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //MessageBox.Show("Greška prilikom izrade izvješća!");
                //return;
            }
            finally
            {
                connection.Close();
            }
            this.SP_LISTA_IZNOSA_RADNIKADataSet1.Clear();
            ReportDocument document = new ReportDocument();
            if (this.radiobtnPapirUspravno.Checked)
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptLIZaposlenikPolozeno.rpt");
            }
            else
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptLIZaposlenik.rpt");
            }
            SP_LISTA_IZNOSA_RADNIKADataAdapter adapter2 = new SP_LISTA_IZNOSA_RADNIKADataAdapter();
            int sORT = 0;
            if (this.radiobtnSortiranjeSifra.Checked)
            {
                sORT = 0;
            }
            else
            {
                sORT = 1;
            }
            if (this.radiobtnObracun.Checked)
            {
                adapter2.Fill(this.SP_LISTA_IZNOSA_RADNIKADataSet1, Conversions.ToString(this.sifraObracuna.Value), null, null, sORT);
                ((TextObject) document.ReportDefinition.ReportObjects["txtNaslov"]).Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("IZNOSI ZAPOSLENIKA ZA: ", this.sifraObracuna.Value), "  (MJESEC OBRAČUNA: "), str2), " / "), str), ")"));
            }
            document.SetDataSource(this.SP_LISTA_IZNOSA_RADNIKADataSet1);
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);
            document.SetParameterValue("USTANOVA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ADRESA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
            document.SetParameterValue("ADRESA2", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            document.SetParameterValue("MB", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["MBKORISNIK"]));
            document.SetParameterValue("TELEFON", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
            document.SetParameterValue("FAX", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Lista iznosa zaposlenika",
                Description = "Pregled izvještaja - Lista iznosa zaposlenika",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        [LocalCommandHandler("IspisiListu")]
        public void IspisiListuHandler(object sender, EventArgs e)
        {
            this.Ispis();
        }

        private void ListaIznosa_Load(object sender, EventArgs e)
        {
            this.radiobtnPolozeniIspis.Checked = true;
            IEnumerator<object> enumerator = this.Controller.WorkItem.Workspaces["main"].SmartParts.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is ObracunSmartPart)
                {
                    ObracunSmartPart current = (ObracunSmartPart) enumerator.Current;
                    if (current.sifraobracuna != "")
                    {
                        this.sifraObracuna.Value = current.sifraobracuna;
                        this.Ispis();
                    }
                }
            }
        }

        private void Odaberi_Obracun()
        {
            using (frmPregledObracuna obracuna = new frmPregledObracuna())
            {
                obracuna.ShowDialog();
                if (obracuna.ObracunSelected != null)
                {
                    this.radiobtnObracun.Checked = true;
                    this.sifraObracuna.Value = obracuna.ObracunSelected;
                }
            }
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        [LocalCommandHandler("ZaGodinu")]
        public void ZaGodinuHandler(object sender, EventArgs e)
        {
            this.Odaberi_Obracun();
        }

        [LocalCommandHandler("ZaMjesec")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            this.Odaberi_Obracun();
        }

        [LocalCommandHandler("ZaObracun")]
        public void ZaObracunHandler(object sender, EventArgs e)
        {
            this.Odaberi_Obracun();
            this.Ispis();
        }

        private AutoHideControl _ListaIznosaAutoHideControl;

        private UnpinnedTabArea _ListaIznosaUnpinnedTabAreaBottom;

        private UnpinnedTabArea _ListaIznosaUnpinnedTabAreaLeft;

        private UnpinnedTabArea _ListaIznosaUnpinnedTabAreaRight;

        private UnpinnedTabArea _ListaIznosaUnpinnedTabAreaTop;

        [CreateNew]
        public ListaIznosaController Controller { get; set; }

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

        private UltraGrid gridPregledEkran;

        private GroupBox GroupBox1;

        private GroupBox GroupBox2;

        private GroupBox GroupBox3;

        private RadioButton radiobtnObracun;

        private RadioButton radiobtnPapirUspravno;

        private RadioButton radiobtnPolozeniIspis;

        private RadioButton radiobtnSortiranjePrezime;

        private RadioButton radiobtnSortiranjeSifra;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraMaskedEdit sifraObracuna;

        private SP_LISTA_IZNOSA_RADNIKADataSet SP_LISTA_IZNOSA_RADNIKADataSet1;

        private UltraDockManager UltraDockManager1;

        private UltraGroupBox UltraGroupBox1;

        private WindowDockingArea WindowDockingArea1;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

