namespace IPKarticeNamespace
{
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
    using My.Resources;
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
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using System.Xml;

    [SmartPart]
    public class IPKartice : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_IPKarticeAutoHideControl")]
        private AutoHideControl __IPKarticeAutoHideControl;
        [AccessedThroughProperty("_IPKarticeUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __IPKarticeUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_IPKarticeUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __IPKarticeUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_IPKarticeUnpinnedTabAreaRight")]
        private UnpinnedTabArea __IPKarticeUnpinnedTabAreaRight;
        [AccessedThroughProperty("_IPKarticeUnpinnedTabAreaTop")]
        private UnpinnedTabArea __IPKarticeUnpinnedTabAreaTop;
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("DsIPObrazac1")]
        private dsIPObrazac _DsIPObrazac1;
        [AccessedThroughProperty("Sp_ip_detaljiDataSet1")]
        private sp_ip_detaljiDataSet _Sp_ip_detaljiDataSet1;
        [AccessedThroughProperty("Sp_ip_zaglavljeDataSet1")]
        private sp_ip_zaglavljeDataSet _Sp_ip_zaglavljeDataSet1;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("UltraGrid2")]
        private UltraGrid _UltraGrid2;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        private IContainer components;
        private KORISNIKDataAdapter da;
        private KORISNIKDataSet ds;
        private string godina_kartica;
        private SmartPartInfoProvider infoProvider;
        
        private SmartPartInfo smartPartInfo1;

        public IPKartice()
        {
            base.Load += new EventHandler(this.Zap1_Load);
            this.ds = new KORISNIKDataSet();
            this.da = new KORISNIKDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("IP Obrasci", "IPKartice");
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("sp_ip_zaglavlje", -1);
            UltraGridColumn column = new UltraGridColumn("OZNACEN");
            UltraGridColumn column12 = new UltraGridColumn("IDIPIDENT");
            UltraGridColumn column23 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column34 = new UltraGridColumn("JMBG");
            UltraGridColumn column39 = new UltraGridColumn("PREZIME");
            UltraGridColumn column40 = new UltraGridColumn("IME");
            UltraGridColumn column41 = new UltraGridColumn("ADRESA");
            UltraGridColumn column42 = new UltraGridColumn("isplataugodini");
            UltraGridColumn column43 = new UltraGridColumn("isplatazagodinu");
            UltraGridColumn column2 = new UltraGridColumn("OIB");
            UltraGridColumn column3 = new UltraGridColumn("sp_ip_zaglavlje_sp_ip_detalji");
            UltraGridBand band2 = new UltraGridBand("sp_ip_zaglavlje_sp_ip_detalji", 0);
            UltraGridColumn column4 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("JMBG");
            UltraGridColumn column6 = new UltraGridColumn("IDIPIDENT");
            UltraGridColumn column7 = new UltraGridColumn("MJESECISPLATE");
            UltraGridColumn column8 = new UltraGridColumn("idopcinestanovanja");
            UltraGridColumn column9 = new UltraGridColumn("ukupnobruto");
            UltraGridColumn column10 = new UltraGridColumn("ukupnodoprinosi");
            UltraGridColumn column11 = new UltraGridColumn("ukupnoporeznopriznateolaksice");
            UltraGridColumn column13 = new UltraGridColumn("dohodak");
            UltraGridColumn column14 = new UltraGridColumn("UKUPNOOO");
            UltraGridColumn column15 = new UltraGridColumn("poreznaosnovica");
            UltraGridColumn column16 = new UltraGridColumn("ukupnoporeziprirez");
            UltraGridColumn column17 = new UltraGridColumn("netoisplata");
            UltraGridColumn column18 = new UltraGridColumn("OIB");
            UltraGridColumn column19 = new UltraGridColumn("POREZKRIZNI");
            UltraGridColumn column20 = new UltraGridColumn("NETOPLACA");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            UltraGridBand band3 = new UltraGridBand("sp_ip_detalji", -1);
            UltraGridColumn column21 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column22 = new UltraGridColumn("JMBG");
            UltraGridColumn column24 = new UltraGridColumn("IDIPIDENT");
            UltraGridColumn column25 = new UltraGridColumn("MJESECISPLATE");
            UltraGridColumn column26 = new UltraGridColumn("idopcinestanovanja");
            UltraGridColumn column27 = new UltraGridColumn("ukupnobruto");
            UltraGridColumn column28 = new UltraGridColumn("ukupnodoprinosi");
            UltraGridColumn column29 = new UltraGridColumn("ukupnoporeznopriznateolaksice");
            UltraGridColumn column30 = new UltraGridColumn("dohodak");
            UltraGridColumn column31 = new UltraGridColumn("UKUPNOOO");
            UltraGridColumn column32 = new UltraGridColumn("poreznaosnovica");
            UltraGridColumn column33 = new UltraGridColumn("ukupnoporeziprirez");
            UltraGridColumn column35 = new UltraGridColumn("netoisplata");
            UltraGridColumn column36 = new UltraGridColumn("OIB");
            UltraGridColumn column37 = new UltraGridColumn("POREZKRIZNI");
            UltraGridColumn column38 = new UltraGridColumn("NETOPLACA");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Guid internalId = new Guid("509a6842-a84b-4c85-85ef-6eacc8bbb3bb");
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("08ce9e68-5f3a-4cdb-a03f-430fba6262c8");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("509a6842-a84b-4c85-85ef-6eacc8bbb3bb");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            this.UltraGrid1 = new UltraGrid();
            this.DsIPObrazac1 = new dsIPObrazac();
            this.UltraGrid2 = new UltraGrid();
            this.Sp_ip_detaljiDataSet1 = new sp_ip_detaljiDataSet();
            this.Sp_ip_zaglavljeDataSet1 = new sp_ip_zaglavljeDataSet();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._IPKarticeUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._IPKarticeUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._IPKarticeUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._IPKarticeUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._IPKarticeAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.DsIPObrazac1.BeginInit();
            ((ISupportInitialize) this.UltraGrid2).BeginInit();
            this.Sp_ip_detaljiDataSet1.BeginInit();
            this.Sp_ip_zaglavljeDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            this.UltraGrid1.DataMember = "sp_ip_zaglavlje";
            this.UltraGrid1.DataSource = this.DsIPObrazac1;
            appearance10.BackColor = Color.White;
            appearance10.BackColor2 = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance10.BackGradientStyle = GradientStyle.ForwardDiagonal;
            this.UltraGrid1.DisplayLayout.Appearance = appearance10;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.Caption = "Označen";
            column.Header.VisiblePosition = 0;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.Caption = "IP Ident.";
            column12.Header.VisiblePosition = 5;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.Header.Caption = "Šifra";
            column23.Header.VisiblePosition = 1;
            column34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column34.Header.VisiblePosition = 2;
            column39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column39.Header.Caption = "Prezime";
            column39.Header.VisiblePosition = 3;
            column40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column40.Header.Caption = "Ime";
            column40.Header.VisiblePosition = 4;
            column41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column41.Header.VisiblePosition = 6;
            column41.Hidden = true;
            column42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column42.Header.VisiblePosition = 7;
            column42.Hidden = true;
            column43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column43.Header.VisiblePosition = 8;
            column43.Hidden = true;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 9;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 10;
            band.Columns.AddRange(new object[] { column, column12, column23, column34, column39, column40, column41, column42, column43, column2, column3 });
            band.Override.AllowUpdate = DefaultableBoolean.True;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 0;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 1;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.Header.VisiblePosition = 2;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.VisiblePosition = 3;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.VisiblePosition = 4;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 5;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.VisiblePosition = 6;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 7;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 8;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 9;
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.Header.VisiblePosition = 10;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.Header.VisiblePosition = 11;
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.Header.VisiblePosition = 12;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.Header.VisiblePosition = 13;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.Header.VisiblePosition = 14;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.Header.VisiblePosition = 15;
            band2.Columns.AddRange(new object[] { column4, column5, column6, column7, column8, column9, column10, column11, column13, column14, column15, column16, column17, column18, column19, column20 });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band2);
            this.UltraGrid1.DisplayLayout.InterBandSpacing = 10;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            appearance11.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance11;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance12.BackColor = Color.FromArgb(0xf7, 0xf7, 0xf9);
            appearance12.BackColor2 = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance12.BackGradientStyle = GradientStyle.Vertical;
            appearance12.ForeColor = Color.Black;
            appearance12.TextHAlignAsString = "Left";
            appearance12.ThemedElementAlpha = Alpha.Transparent;
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance.BorderColor = Color.FromArgb(0xa8, 0xa7, 0xbf);
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance;
            appearance2.BackColor = Color.FromArgb(0xf7, 0xf7, 0xf9);
            appearance2.BackColor2 = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance2.BackGradientStyle = GradientStyle.Vertical;
            this.UltraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.RowSelectorWidth = 12;
            this.UltraGrid1.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance3.BackColor = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance3.BackColor2 = Color.FromArgb(0xf7, 0xf7, 0xf9);
            appearance3.BackGradientStyle = GradientStyle.Vertical;
            appearance3.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.UltraGrid1.DisplayLayout.RowConnectorColor = Color.FromArgb(0xa8, 0xa7, 0xbf);
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.Solid;
            this.UltraGrid1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            Size size = new System.Drawing.Size(0x200, 0x1aa);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 15;
            this.DsIPObrazac1.DataSetName = "dsIPObrazac";
            this.DsIPObrazac1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.UltraGrid2.DataMember = "sp_ip_zaglavlje.sp_ip_zaglavlje_sp_ip_detalji";
            this.UltraGrid2.DataSource = this.DsIPObrazac1;
            appearance4.BackColor = Color.White;
            appearance4.BackColor2 = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance4.BackGradientStyle = GradientStyle.ForwardDiagonal;
            this.UltraGrid2.DisplayLayout.Appearance = appearance4;
            this.UltraGrid2.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.Header.VisiblePosition = 0;
            column21.Hidden = true;
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column22.Header.VisiblePosition = 1;
            column22.Hidden = true;
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column24.Header.VisiblePosition = 2;
            column24.Hidden = true;
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column25.Header.Caption = "Mjesec";
            column25.Header.VisiblePosition = 3;
            column25.Width = 10;
            column26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column26.Header.Caption = "Općina";
            column26.Header.VisiblePosition = 4;
            column26.Width = 0x15;
            column27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column27.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column27.Header.Caption = "Bruto";
            column27.Header.VisiblePosition = 5;
            column27.MaskInput = "{LOC} n,nnn,nnn.nn";
            column27.Width = 0x21;
            column28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column28.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column28.Header.Caption = "Doprinosi";
            column28.Header.VisiblePosition = 6;
            column28.MaskInput = "{LOC} n,nnn,nnn.nn";
            column28.Width = 40;
            column29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column29.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column29.Header.Caption = "Olakšice";
            column29.Header.VisiblePosition = 7;
            column29.MaskInput = "{LOC} n,nnn,nnn.nn";
            column29.Width = 40;
            column30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column30.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column30.Header.Caption = "Dohodak";
            column30.Header.VisiblePosition = 9;
            column30.MaskInput = "{LOC} n,nnn,nnn.nn";
            column30.Width = 40;
            column31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column31.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column31.Header.Caption = "Osobni odbitak";
            column31.Header.VisiblePosition = 8;
            column31.MaskInput = "{LOC} n,nnn,nnn.nn";
            column31.Width = 0x2d;
            column32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column32.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column32.Header.Caption = "Porezna osnovica";
            column32.Header.VisiblePosition = 10;
            column32.MaskInput = "{LOC} n,nnn,nnn.nn";
            column32.Width = 0x34;
            column33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column33.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column33.Header.Caption = "Porez i prirez";
            column33.Header.VisiblePosition = 11;
            column33.MaskInput = "{LOC} -n,nnn,nnn.nn";
            column33.Width = 0x29;
            column35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column35.Format = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column35.Header.Caption = "Neto";
            column35.Header.VisiblePosition = 12;
            column35.MaskInput = "{LOC} n,nnn,nnn.nn";
            column35.Width = 40;
            column36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column36.Header.VisiblePosition = 13;
            column36.Width = 0x31;
            column37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column37.Header.VisiblePosition = 14;
            column37.Width = 0x2d;
            column38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column38.Header.VisiblePosition = 15;
            column38.Width = 0x2a;
            band3.Columns.AddRange(new object[] { column21, column22, column24, column25, column26, column27, column28, column29, column30, column31, column32, column33, column35, column36, column37, column38 });
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band3);
            this.UltraGrid2.DisplayLayout.InterBandSpacing = 10;
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            appearance5.BackColor = Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance5;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance6.BackColor = Color.FromArgb(0xf7, 0xf7, 0xf9);
            appearance6.BackColor2 = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance6.BackGradientStyle = GradientStyle.Vertical;
            appearance6.ForeColor = Color.Black;
            appearance6.TextHAlignAsString = "Left";
            appearance6.ThemedElementAlpha = Alpha.Transparent;
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance7.BorderColor = Color.FromArgb(0xa8, 0xa7, 0xbf);
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance7;
            appearance8.BackColor = Color.FromArgb(0xf7, 0xf7, 0xf9);
            appearance8.BackColor2 = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance8.BackGradientStyle = GradientStyle.Vertical;
            this.UltraGrid2.DisplayLayout.Override.RowSelectorAppearance = appearance8;
            this.UltraGrid2.DisplayLayout.Override.RowSelectorWidth = 12;
            this.UltraGrid2.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance9.BackColor = Color.FromArgb(0xa8, 0xa7, 0xbf);
            appearance9.BackColor2 = Color.FromArgb(0xf7, 0xf7, 0xf9);
            appearance9.BackGradientStyle = GradientStyle.Vertical;
            appearance9.ForeColor = Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance9;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.UltraGrid2.DisplayLayout.RowConnectorColor = Color.FromArgb(0xa8, 0xa7, 0xbf);
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = RowConnectorStyle.Solid;
            this.UltraGrid2.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid2.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0x1c1);
            this.UltraGrid2.Location = point;
            this.UltraGrid2.Name = "UltraGrid2";
            size = new System.Drawing.Size(0x200, 0x141);
            this.UltraGrid2.Size = size;
            this.UltraGrid2.TabIndex = 0x10;
            this.Sp_ip_detaljiDataSet1.DataSetName = "sp_ip_detaljiDataSet";
            this.Sp_ip_zaglavljeDataSet1.DataSetName = "sp_ip_zaglavljeDataSet";
            pane.Control = this.UltraGrid1;
            Rectangle rectangle = new Rectangle(8, 8, 0x1a3, 0x127);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "P O P I S   Z A P O S L E N I K A";
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x200, 0x1bc);
            pane2.Size = size;
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = WindowStyle.Office2007;
            this._IPKarticeUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._IPKarticeUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._IPKarticeUnpinnedTabAreaLeft.Location = point;
            this._IPKarticeUnpinnedTabAreaLeft.Name = "_IPKarticeUnpinnedTabAreaLeft";
            this._IPKarticeUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 770);
            this._IPKarticeUnpinnedTabAreaLeft.Size = size;
            this._IPKarticeUnpinnedTabAreaLeft.TabIndex = 0x11;
            this._IPKarticeUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._IPKarticeUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x200, 0);
            this._IPKarticeUnpinnedTabAreaRight.Location = point;
            this._IPKarticeUnpinnedTabAreaRight.Name = "_IPKarticeUnpinnedTabAreaRight";
            this._IPKarticeUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 770);
            this._IPKarticeUnpinnedTabAreaRight.Size = size;
            this._IPKarticeUnpinnedTabAreaRight.TabIndex = 0x12;
            this._IPKarticeUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._IPKarticeUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._IPKarticeUnpinnedTabAreaTop.Location = point;
            this._IPKarticeUnpinnedTabAreaTop.Name = "_IPKarticeUnpinnedTabAreaTop";
            this._IPKarticeUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x200, 0);
            this._IPKarticeUnpinnedTabAreaTop.Size = size;
            this._IPKarticeUnpinnedTabAreaTop.TabIndex = 0x13;
            this._IPKarticeUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._IPKarticeUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 770);
            this._IPKarticeUnpinnedTabAreaBottom.Location = point;
            this._IPKarticeUnpinnedTabAreaBottom.Name = "_IPKarticeUnpinnedTabAreaBottom";
            this._IPKarticeUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x200, 0);
            this._IPKarticeUnpinnedTabAreaBottom.Size = size;
            this._IPKarticeUnpinnedTabAreaBottom.TabIndex = 20;
            this._IPKarticeAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._IPKarticeAutoHideControl.Location = point;
            this._IPKarticeAutoHideControl.Name = "_IPKarticeAutoHideControl";
            this._IPKarticeAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 770);
            this._IPKarticeAutoHideControl.Size = size;
            this._IPKarticeAutoHideControl.TabIndex = 0x15;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Location = point;
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x200, 0x1c1);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 0x16;
            this.DockableWindow1.Controls.Add(this.UltraGrid1);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Location = point;
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x200, 0x1bc);
            this.DockableWindow1.Size = size;
            this.DockableWindow1.TabIndex = 0x17;
            this.Controls.Add(this._IPKarticeAutoHideControl);
            this.Controls.Add(this.UltraGrid2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._IPKarticeUnpinnedTabAreaTop);
            this.Controls.Add(this._IPKarticeUnpinnedTabAreaBottom);
            this.Controls.Add(this._IPKarticeUnpinnedTabAreaLeft);
            this.Controls.Add(this._IPKarticeUnpinnedTabAreaRight);
            this.Name = "IPKartice";
            size = new System.Drawing.Size(0x200, 770);
            this.Size = size;
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.DsIPObrazac1.EndInit();
            ((ISupportInitialize) this.UltraGrid2).EndInit();
            this.Sp_ip_detaljiDataSet1.EndInit();
            this.Sp_ip_zaglavljeDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void IP_PopratniList(int brojac)
        {
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info2 = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - IP Popratni list",
                Description = "Pregled izvještaja - IP Popratni list",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowSmartPartInfo info = info2;
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPopratniListIPObrazac.rpt");
            document.SetDataSource(this.ds);
            document.SetParameterValue("brojdatoteka", 1);
            document.SetParameterValue("brojipobrazaca", brojac);
            document.SetParameterValue("godina", this.godina_kartica);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        private void Ispis_Oznacenih_IP_Obrazaca()
        {
            if (this.DsIPObrazac1.Tables[0].Rows.Count != 0)
            {
                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - IP Obrasci",
                    Description = "Pregled izvještaja - IP Obrasci",
                    Icon = ImageResourcesNew.mbs
                };
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptObrazacIP.rpt");
                document.SetDataSource(this.DsIPObrazac1);
                if (this.ds.KORISNIK.Rows.Count > 0)
                {
                    str2 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                    str = string.Format("{0}, {1}", RuntimeHelpers.GetObjectValue(this.ds.KORISNIK.Rows[0]["KORISNIK1ADRESA"]), RuntimeHelpers.GetObjectValue(this.ds.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                    if (this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() == "")
                    {
                        str3 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["JMBGKORISNIK"]);
                    }
                    else
                    {
                        str3 = ((this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim() == "") | (decimal.Compare(DB.N20(this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString()), decimal.Zero) == 0)) ? this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() : (this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() + this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim());
                    }
                    str3 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["KORISNIKOIB"]);
                }
                document.RecordSelectionFormula = "{ZAGLAVLJE.OZNACEN} = True";
                document.SetParameterValue("godina", this.godina_kartica);
                document.SetParameterValue("ustanova", str2);
                document.SetParameterValue("adresa", str);
                document.SetParameterValue("ustanovamb", str3);
                document.SetParameterValue("datum", DateTime.Today);
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"], info);
            }
        }

        private void Ispis_Oznacenih_IP_Obrazaca2011()
        {
            if (this.DsIPObrazac1.Tables[0].Rows.Count != 0)
            {
                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - IP Obrasci",
                    Description = "Pregled izvještaja - IP Obrasci",
                    Icon = ImageResourcesNew.mbs
                };
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptObrazacIP2011.rpt");
                document.SetDataSource(this.DsIPObrazac1);
                if (this.ds.KORISNIK.Rows.Count > 0)
                {
                    str3 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                    str = string.Format("{0}, {1}", RuntimeHelpers.GetObjectValue(this.ds.KORISNIK.Rows[0]["KORISNIK1ADRESA"]), RuntimeHelpers.GetObjectValue(this.ds.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                    if (this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() == "")
                    {
                        str2 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["JMBGKORISNIK"]);
                    }
                    else
                    {
                        str2 = ((this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim() == "") | (decimal.Compare(DB.N20(this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString()), decimal.Zero) == 0)) ? this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() : (this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() + this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim());
                    }
                    str2 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["KORISNIKOIB"]);
                }
                document.RecordSelectionFormula = "{ZAGLAVLJE.OZNACEN} = True";
                document.SetParameterValue("godina", this.godina_kartica);
                document.SetParameterValue("ustanova", str3);
                document.SetParameterValue("adresa", str);
                document.SetParameterValue("ustanovamb", str2);
                document.SetParameterValue("datum", DateTime.Today);
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [LocalCommandHandler("Ispisi2011")]
        public void Ispisi2011Handler(object sender, EventArgs e)
        {
            this.Ispis_Oznacenih_IP_Obrazaca2011();
        }

        [LocalCommandHandler("Ispisi")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.Ispis_Oznacenih_IP_Obrazaca();
        }

        [LocalCommandHandler("IspisiZbirni")]
        public void IspisiZbirniHandler(object sender, EventArgs e)
        {
            this.IspisZbirni();
        }

        private void IspisZbirni()
        {
            if (this.DsIPObrazac1.Tables[0].Rows.Count != 0)
            {
                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;
                IEnumerator enumerator = null;
                S_OD_IP_ZBIRNIDataSet dataSet = new S_OD_IP_ZBIRNIDataSet();
                new S_OD_IP_ZBIRNIDataAdapter().Fill(dataSet, this.godina_kartica);
                try
                {
                    enumerator = this.DsIPObrazac1.sp_ip_zaglavlje.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        if (Operators.ConditionalCompareObjectEqual(current["OZNACEN"], false, false) && (dataSet.S_OD_IP_ZBIRNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("OIB = '", current["OIB"]), "'"))).Count<DataRow>() > 0))
                        {
                            dataSet.S_OD_IP_ZBIRNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("OIB = '", current["OIB"]), "'")))[0].BeginEdit();
                            dataSet.S_OD_IP_ZBIRNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("OIB = '", current["OIB"]), "'")))[0].Delete();
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
                dataSet.S_OD_IP_ZBIRNI.AcceptChanges();
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - IP Obrasci",
                    Description = "Pregled izvještaja - IP Obrasci",
                    Icon = ImageResourcesNew.mbs
                };
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\ptObrazacIPZBIRNI.rpt");
                document.SetDataSource(dataSet);
                if (this.ds.KORISNIK.Rows.Count > 0)
                {
                    str3 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                    str = this.ds.KORISNIK.Rows[0]["KORISNIK1ADRESA"].ToString() + ", " + this.ds.KORISNIK.Rows[0]["KORISNIK1MJESTO"].ToString();
                    if (this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() == "")
                    {
                        str2 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["JMBGKORISNIK"]);
                    }
                    else if ((this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim() == "") | (decimal.Compare(DB.N20(this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString()), decimal.Zero) == 0))
                    {
                        str2 = this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim();
                    }
                    else
                    {
                        str2 = this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() + this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim();
                    }
                    str2 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["KORISNIKOIB"]);
                }
                document.SetParameterValue("godina", this.godina_kartica);
                document.SetParameterValue("ustanova", str3);
                document.SetParameterValue("adresa", str);
                document.SetParameterValue("mb", str2);
                document.SetParameterValue("datum", DateTime.Today);
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"], info);
            }
        }

        private void Izradi_IP_Datoteku()
        {
            if (this.DsIPObrazac1.sp_ip_zaglavlje.Rows.Count != 0)
            {
                string str5 = string.Empty;
                Ip o = new Ip {
                    IsplataUGodini = Conversions.ToInteger(this.DsIPObrazac1.sp_ip_zaglavlje.Rows[0]["isplataugodini"]),
                    storno = false
                };

                if (this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() == "")
                {
                    str5 = Conversions.ToString(this.ds.KORISNIK.Rows[0]["JMBGKORISNIK"]);
                }
                else if ((this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim() == "") | (decimal.Compare(DB.N20(this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString()), decimal.Zero) == 0))
                {
                    str5 = this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim();
                }
                else
                {
                    str5 = this.ds.KORISNIK.Rows[0]["MBKORISNIK"].ToString().Trim() + this.ds.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"].ToString().Trim();
                }
                str5 = this.ds.KORISNIK.Rows[0]["KORISNIKOIB"].ToString();
                string str3 = "IP_" + str5 + "_01.XML";
                PoslodavacTip tip3 = new PoslodavacTip();
                string pattern = @"\+((0?0?)[1-9]|(0?[1-9]\d)|[1-9]\d{2})\([1-9]\d?\)[1-9]\d{5,6}";
                string str = @"[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)[a-zA-Z0-9]@[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)(\.[a-zA-Z]{2,4})";
                KontaktOsobaTip tip = new KontaktOsobaTip();
                string[] strArray = new string[] { Conversions.ToString(this.ds.KORISNIK.Rows[0]["KONTAKTTELEFON"]), Conversions.ToString(this.ds.KORISNIK.Rows[0]["KONTAKTfax"]) };
                tip.Email = Conversions.ToString(this.ds.KORISNIK.Rows[0]["EMAIL"]);

                string [] kontakt_osoba =  Conversions.ToString(this.ds.KORISNIK.Rows[0]["KONTAKTOSOBA"]).Split(' ');

                if (kontakt_osoba.Length < 2)
                {
                    MessageBox.Show("Unesite kontakt osobu u formatu prvo ime pa prezime!!!");
                }
                else
                {
                    tip.Ime = kontakt_osoba[0];
                    tip.Prezime = kontakt_osoba[1];
                }
                tip.Telefoni = strArray;
                tip3.KontaktOsoba = tip;
                tip3.oib = str5;
                o.Poslodavac = tip3;
                IpObrazacTip[] tipArray = new IpObrazacTip[0x3e9];
                if (!Regex.IsMatch(Conversions.ToString(this.ds.KORISNIK.Rows[0]["EMAIL"]), str))
                {
                    Interaction.MsgBox("Email u korisniku aplikacije nije upisan po pravilima za predaju IP obrazaca u XML formatu!", MsgBoxStyle.OkOnly, null);
                }
                else if (!Regex.IsMatch(Conversions.ToString(this.ds.KORISNIK.Rows[0]["KONTAKTTELEFON"]), pattern))
                {
                    Interaction.MsgBox("Telefon u korisniku aplikacije nije upisan po pravilima za predaju IP obrazaca u XML formatu!", MsgBoxStyle.OkOnly, null);
                }
                else if (!Regex.IsMatch(Conversions.ToString(this.ds.KORISNIK.Rows[0]["KONTAKTfax"]), pattern))
                {
                    Interaction.MsgBox("Broj Fax-a  nije upisan po pravilima za predaju IP obrazaca u XML formatu!", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    IEnumerator enumerator = null;
                    int index = 0;
                    int num = 0;
                    try
                    {
                        enumerator = this.DsIPObrazac1.sp_ip_zaglavlje.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            IpObrazacTip tip2 = new IpObrazacTip();
                            DataRow current = (DataRow) enumerator.Current;
                            if (Conversions.ToBoolean(current["oznacen"]))
                            {
                                tip2 = new IpObrazacTip();
                                DataRow[] childRows = current.GetChildRows("sp_ip_zaglavlje_sp_ip_detalji");
                                if (childRows.Length > 0)
                                {
                                    decimal num4 = 0;
                                    decimal num5 = 0;
                                    decimal num6 = 0;
                                    decimal num7 = 0;
                                    decimal num8 = 0;
                                    decimal num9 = 0;
                                    decimal num10 = 0;
                                    decimal num11 = 0;
                                    decimal num12 = 0;

                                    if (Conversions.ToString(current["idipident"]) == "11")
                                    {
                                        continue;
                                    }

                                    if (Conversions.ToString(current["idipident"]) == "1")
                                    {
                                        tip2.identifikator = IdentifikatorIpObrascaTip.Item1;
                                    }
                                    else if (Conversions.ToString(current["idipident"]) == "2")
                                    {
                                        IdentifikatorIpObrascaTip tip9 = new IdentifikatorIpObrascaTip();
                                        tip9 = IdentifikatorIpObrascaTip.Item2;
                                        tip2.identifikator = tip9;
                                    }
                                    else if (Conversions.ToString(current["idipident"]) == "3")
                                    {
                                        tip2.identifikator = IdentifikatorIpObrascaTip.Item3;
                                    }
                                    tip2.isplataZaGodinu = Conversions.ToInteger(current["ISPLATAZAGODINU"]);
                                    RadnikTip tip8 = new RadnikTip();
                                    if (DB.FixNull(RuntimeHelpers.GetObjectValue(current["OIB"])) == "")
                                    {
                                        num++;
                                        tip8.oib = DB.BrojVodeceNule(RuntimeHelpers.GetObjectValue(current["jmbg"]), 11, 0, false, "");
                                    }
                                    else
                                    {
                                        tip8.oib = DB.FixNull(RuntimeHelpers.GetObjectValue(current["OIB"]));
                                    }
                                    tip8.VrPrimanja = VrPrimanjaRadnikTip.PL;
                                    int num3 = 0;
                                    ObveznikTip tip6 = new ObveznikTip {
                                        Item = tip8
                                    };
                                    tip2.Obveznik = tip6;
                                    MjesecniIznosiTip[] tipArray2 = new MjesecniIznosiTip[13];
                                    IznosiTip tip4 = new IznosiTip();
                                    foreach (DataRow row2 in childRows)
                                    {
                                        MjesecniIznosiTip tip10 = new MjesecniIznosiTip {
                                            mjIspl = Conversions.ToInteger(row2["mjesecisplate"]),
                                            sifGrOp = Conversions.ToString(row2["idopcinestanovanja"])
                                        };
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnobruto"])), decimal.Zero) > 0)
                                        {
                                            tip10.IsplPlMir = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnobruto"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnodoprinosi"])), decimal.Zero) > 0)
                                        {
                                            tip10.UplDopr = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnodoprinosi"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnoporeznopriznateolaksice"])), decimal.Zero) > 0)
                                        {
                                            tip10.UplPremOsig = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnoporeznopriznateolaksice"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnooo"])), decimal.Zero) > 0)
                                        {
                                            tip10.OsobOdb = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnooo"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["UKUPNOPOREZNOPRIZNATEOLAKSICE"])), decimal.Zero) != 0)
                                        {
                                            tip10.UplPremOsig = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["UKUPNOPOREZNOPRIZNATEOLAKSICE"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["dohodak"])), decimal.Zero) > 0)
                                        {
                                            tip10.Dohodak = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["dohodak"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["poreznaosnovica"])), decimal.Zero) != 0)
                                        {
                                            tip10.PorOsn = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["poreznaosnovica"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnoporeziprirez"])), decimal.Zero) != 0)
                                        {
                                            tip10.UplPorPrir = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnoporeziprirez"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["netoisplata"])), decimal.Zero) > 0)
                                        {
                                            tip10.NetoIspl = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["netoisplata"]));
                                        }
                                        if (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["POREZKRIZNI"])), decimal.Zero) > 0)
                                        {
                                            tip10.PosPorez = DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["POREZKRIZNI"]));
                                        }
                                        num7 = decimal.Add(num7, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["POREZKRIZNI"])));
                                        num4 = decimal.Add(num4, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnobruto"])));
                                        num6 = decimal.Add(num6, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnodoprinosi"])));
                                        num12 = decimal.Add(num12, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnoporeznopriznateolaksice"])));
                                        num9 = decimal.Add(num9, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnooo"])));
                                        num5 = decimal.Add(num5, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["dohodak"])));
                                        num11 = decimal.Add(num11, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["poreznaosnovica"])));
                                        num10 = decimal.Add(num10, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnoporeziprirez"])));
                                        num8 = decimal.Add(num8, DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["netoisplata"])));
                                        if ((decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnobruto"])), decimal.Zero) > 0) | (decimal.Compare(DB.RoundUP(RuntimeHelpers.GetObjectValue(row2["ukupnoporeziprirez"])), decimal.Zero) != 0))
                                        {
                                            tipArray2[num3] = tip10;
                                        }
                                        num3++;
                                    }
                                    tip2.Mjeseci = tipArray2;
                                    IznosiTip tip5 = new IznosiTip {
                                        IsplPlMir = num4,
                                        UplDopr = num6,
                                        UplPremOsig = num12,
                                        OsobOdb = num9,
                                        Dohodak = num5,
                                        PorOsn = num11,
                                        UplPorPrir = num10,
                                        NetoIspl = num8,
                                        PosPorez = num7
                                    };
                                    num4 = new decimal();
                                    num6 = new decimal();
                                    num12 = new decimal();
                                    num9 = new decimal();
                                    num5 = new decimal();
                                    num11 = new decimal();
                                    num10 = new decimal();
                                    num8 = new decimal();
                                    num7 = new decimal();
                                    tip2.Ukupno = tip5;
                                    
                                }
                                tipArray[index] = tip2;
                                index++;
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
                    o.IpObrasci = tipArray;
                    try
                    {
                        SaveFileDialog dialog2 = new SaveFileDialog {
                            InitialDirectory = Conversions.ToString(0),
                            FileName = str3,
                            RestoreDirectory = true
                        };
                        SaveFileDialog dialog = dialog2;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            string str2 = string.Empty;

                            using (TextWriter writer = new StreamWriter(dialog.FileName))
                            {
                                new XmlSerializer(typeof(Ip), "dd").Serialize(writer, o);
                                writer.Close();
                            }
                            Interaction.MsgBox("Datoteka uspješno spremljena u: " + dialog.FileName, MsgBoxStyle.OkOnly, null);

                            string xmlText = File.ReadAllText(dialog.FileName);
                            string micanje_nodova = xmlText.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", " storno=\"false\"");
                            string utf = micanje_nodova.Replace("utf-8", "UTF-8");
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(utf);
                            doc.Save(dialog.FileName);

                            Interaction.MsgBox(mipsed.application.framework.Application.ValidateXml(dialog.FileName, System.Windows.Forms.Application.StartupPath + @"\ip-obrazac_4_0.xsd", ref str2) ? "Datoteka je ispravna!" : ("Datoteka je neispravna!" + str2), MsgBoxStyle.OkOnly, null);
                            this.IP_PopratniList(index);

                        }
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;                  
                    }

                    if (num > 0)
                    {
                        Interaction.MsgBox(Conversions.ToString(num) + " zaposlenika nema upisan OIB!", MsgBoxStyle.OkOnly, null);
                    }
                }
            }
        }

        [LocalCommandHandler("OtvoriGodinu")]
        public void OtvoriGodinuHandler(object sender, EventArgs e)
        {
            this.PregledGodina();
        }

        [LocalCommandHandler("OznaciSve")]
        public void OznaciSveHandler(object sender, EventArgs e)
        {
            IEnumerator<dsIPObrazac.sp_ip_zaglavljeRow> enumerator = null;
            try
            {
                enumerator = this.DsIPObrazac1.sp_ip_zaglavlje.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = enumerator.Current;
                    current["oznacen"] = true;
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

        public void PregledGodina()
        {
            SqlConnection connection = new SqlConnection();
            this.Sp_ip_zaglavljeDataSet1.Clear();
            this.Sp_ip_detaljiDataSet1.Clear();
            connection.ConnectionString = Configuration.ConnectionString;
            frmPreglediGodina godina = new frmPreglediGodina();
            godina.ShowDialog();
            if ((godina.DialogResult != DialogResult.Cancel) && (godina.OdabraniGodinaIsplate != null))
            {
                this.godina_kartica = Conversions.ToString(godina.OdabraniGodinaIsplate);
                sp_ip_zaglavljeDataAdapter adapter2 = new sp_ip_zaglavljeDataAdapter();
                sp_ip_detaljiDataAdapter adapter = new sp_ip_detaljiDataAdapter();
                adapter2.Fill(this.Sp_ip_zaglavljeDataSet1, Conversions.ToString(godina.OdabraniGodinaIsplate));
                adapter.Fill(this.Sp_ip_detaljiDataSet1, Conversions.ToString(godina.OdabraniGodinaIsplate));
                this.DsIPObrazac1.Clear();
                this.DsIPObrazac1.Merge(this.Sp_ip_zaglavljeDataSet1.sp_ip_zaglavlje);
                this.DsIPObrazac1.Merge(this.Sp_ip_detaljiDataSet1.sp_ip_detalji);
            }
        }

        [LocalCommandHandler("SkiniOznake")]
        public void SkiniOznakeHandler(object sender, EventArgs e)
        {
            IEnumerator<dsIPObrazac.sp_ip_zaglavljeRow> enumerator = null;
            try
            {
                enumerator = this.DsIPObrazac1.sp_ip_zaglavlje.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = enumerator.Current;
                    current["oznacen"] = false;
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

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DsIPObrazac1, "sp_ip_zaglavlje"];
            if (manager.Count > -1)
            {
                DataRowView current = (DataRowView) manager.Current;
                current["OZNACEN"] = !Conversions.ToBoolean(current["OZNACEN"]);
                this.BindingContext[this.DsIPObrazac1, "sp_ip_zaglavlje"].EndCurrentEdit();
            }
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        [LocalCommandHandler("IzradiXML")]
        public void xmlHandler(object sender, EventArgs e)
        {
            this.Izradi_IP_Datoteku();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            this.da.Fill(this.ds);
        }

        internal AutoHideControl _IPKarticeAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__IPKarticeAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__IPKarticeAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _IPKarticeUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__IPKarticeUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__IPKarticeUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _IPKarticeUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__IPKarticeUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__IPKarticeUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _IPKarticeUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__IPKarticeUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__IPKarticeUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _IPKarticeUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__IPKarticeUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__IPKarticeUnpinnedTabAreaTop = value;
            }
        }

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

        internal DockableWindow DockableWindow1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow1 = value;
            }
        }

        internal dsIPObrazac DsIPObrazac1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DsIPObrazac1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DsIPObrazac1 = value;
            }
        }

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

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        internal sp_ip_detaljiDataSet Sp_ip_detaljiDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Sp_ip_detaljiDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Sp_ip_detaljiDataSet1 = value;
            }
        }

        internal sp_ip_zaglavljeDataSet Sp_ip_zaglavljeDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Sp_ip_zaglavljeDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Sp_ip_zaglavljeDataSet1 = value;
            }
        }

        private UltraDockManager UltraDockManager1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDockManager1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraDockManager1 = value;
            }
        }

        private UltraGrid UltraGrid1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                DoubleClickRowEventHandler handler = new DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
                InitializeLayoutEventHandler handler2 = new InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.DoubleClickRow -= handler;
                    this._UltraGrid1.InitializeLayout -= handler2;
                }
                this._UltraGrid1 = value;
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.DoubleClickRow += handler;
                    this._UltraGrid1.InitializeLayout += handler2;
                }
            }
        }

        private UltraGrid UltraGrid2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGrid2 = value;
            }
        }

        internal WindowDockingArea WindowDockingArea1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea1 = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

