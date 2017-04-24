namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Office.Interop.Excel;
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
    using System.Data.SqlClient;
    using System.Deployment.Application;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [SmartPart]
    public class PripremaPlaceCustom : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_PripremaPlaceCustomAutoHideControl")]
        private AutoHideControl __PripremaPlaceCustomAutoHideControl;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaRight")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaRight;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaTop")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaTop;
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("DockableWindow3")]
        private DockableWindow _DockableWindow3;
        [AccessedThroughProperty("ElementDataSet1")]
        private ELEMENTDataSet _ElementDataSet1;
        [AccessedThroughProperty("m_cm")]
        private CurrencyManager _m_cm;
        [AccessedThroughProperty("PrplaceDataSet1")]
        private PRPLACEDataSet _PrplaceDataSet1;
        [AccessedThroughProperty("RadnikDataSet1")]
        private RADNIKDataSet _RadnikDataSet1;
        [AccessedThroughProperty("RadnikPripremaDataSet1")]
        private RadnikPripremaDataSet _RadnikPripremaDataSet1;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraDropDown1")]
        private UltraDropDown _UltraDropDown1;
        [AccessedThroughProperty("UltraDropDown2")]
        private UltraDropDown _UltraDropDown2;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("UltraGrid2")]
        private UltraGrid _UltraGrid2;
        [AccessedThroughProperty("UltraGridExcelExporter1")]
        private UltraGridExcelExporter _UltraGridExcelExporter1;
        [AccessedThroughProperty("UltraGroupBox1")]
        private UltraGroupBox _UltraGroupBox1;
        [AccessedThroughProperty("UltraGroupBox2")]
        private UltraGroupBox _UltraGroupBox2;
        [AccessedThroughProperty("UltraGroupBox3")]
        private UltraGroupBox _UltraGroupBox3;
        [AccessedThroughProperty("UltraTextEditor1")]
        private UltraTextEditor _UltraTextEditor1;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        [AccessedThroughProperty("WindowDockingArea3")]
        private WindowDockingArea _WindowDockingArea3;
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private GRUPEKOEFDataSet dsgrupe;
        private SmartPartInfoProvider infoProvider;
        private decimal OSNOVICA;
        private int prplaceid;
        private decimal SATIGLOBALNO;
        private SmartPartInfo smartPartInfo1;
        private int ZAGODINU;
        private int ZAMJESEC;

        public PripremaPlaceCustom()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.dsgrupe = new GRUPEKOEFDataSet();
            this.smartPartInfo1 = new SmartPartInfo("Priprema plaće", "PripremaPlace");
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
            UltraGridBand band = new UltraGridBand("ELEMENT", -1);
            UltraGridColumn column = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column12 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column23 = new UltraGridColumn("IDVRSTAELEMENTA");
            UltraGridColumn column34 = new UltraGridColumn("NAZIVVRSTAELEMENT");
            UltraGridColumn column45 = new UltraGridColumn("IDOSNOVAOSIGURANJA");
            UltraGridColumn column49 = new UltraGridColumn("NAZIVOSNOVAOSIGURANJA");
            UltraGridColumn column50 = new UltraGridColumn("RAZDOBLJESESMIJEPREKLAPATI");
            UltraGridColumn column51 = new UltraGridColumn("POSTOTAK");
            UltraGridColumn column52 = new UltraGridColumn("ZBRAJASATEUFONDSATI");
            UltraGridColumn column2 = new UltraGridColumn("MOELEMENT");
            UltraGridColumn column3 = new UltraGridColumn("POELEMENT");
            UltraGridColumn column4 = new UltraGridColumn("MZELEMENT");
            UltraGridColumn column5 = new UltraGridColumn("PZELEMENT");
            UltraGridColumn column6 = new UltraGridColumn("SIFRAOPISAPLACANJAELEMENT");
            UltraGridColumn column7 = new UltraGridColumn("OPISPLACANJAELEMENT");
            UltraGridColumn column8 = new UltraGridColumn("POSTAVLJAMZPZSVIMVIRMANIMA");
            UltraGridColumn column9 = new UltraGridColumn("EL");
            UltraGridBand band2 = new UltraGridBand("RADNIK", -1);
            UltraGridColumn column10 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column11 = new UltraGridColumn("SPOJENOPREZIME", -1, null, 0, SortIndicator.Ascending, false);
            UltraGridColumn column13 = new UltraGridColumn("PREZIME");
            UltraGridColumn column14 = new UltraGridColumn("IME");
            EditorButton button = new EditorButton("zaposlenik");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band3 = new UltraGridBand("PRPLACEPRPLACEELEMENTI", -1);
            UltraGridColumn column15 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column16 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column17 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column18 = new UltraGridColumn("IDELEMENT", -1, "UltraDropDown2");
            UltraGridColumn column19 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column20 = new UltraGridColumn("POSTOTAK");
            UltraGridColumn column21 = new UltraGridColumn("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK");
            UltraGridBand band4 = new UltraGridBand("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK", 0);
            UltraGridColumn column22 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column24 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column25 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column26 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column27 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column28 = new UltraGridColumn("PREZIME");
            UltraGridColumn column29 = new UltraGridColumn("IME");
            UltraGridColumn column30 = new UltraGridColumn("PRPLACESATI");
            UltraGridColumn column31 = new UltraGridColumn("PRPLACESATNICA");
            UltraGridColumn column32 = new UltraGridColumn("PRPLACEPOSTOTAK");
            UltraGridColumn column33 = new UltraGridColumn("PRPLACEIZNOS");
            UltraGridColumn column35 = new UltraGridColumn("SPOJENOPREZIME");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            UltraGridBand band5 = new UltraGridBand("PRPLACEPRPLACEELEMENTIRADNIK", -1);
            UltraGridColumn column36 = new UltraGridColumn("PRPLACEZAMJESEC");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            UltraGridColumn column37 = new UltraGridColumn("PRPLACEID");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            UltraGridColumn column38 = new UltraGridColumn("PRPLACEZAGODINU");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            UltraGridColumn column39 = new UltraGridColumn("IDELEMENT");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            UltraGridColumn column40 = new UltraGridColumn("IDRADNIK", -1, "UltraDropDown1");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            UltraGridColumn column41 = new UltraGridColumn("PREZIME", -1, null, 0, SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            UltraGridColumn column42 = new UltraGridColumn("IME");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            UltraGridColumn column43 = new UltraGridColumn("PRPLACESATI");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            UltraGridColumn column44 = new UltraGridColumn("PRPLACESATNICA");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            UltraGridColumn column46 = new UltraGridColumn("PRPLACEPOSTOTAK");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            UltraGridColumn column47 = new UltraGridColumn("PRPLACEIZNOS");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            UltraGridColumn column48 = new UltraGridColumn("SPOJENOPREZIME");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Guid internalId = new Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003");
            DockAreaPane pane3 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("9373afb2-5358-4618-b4be-9d6c44b6bcce");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            dockedParentId = new Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb");
            DockAreaPane pane4 = new DockAreaPane(DockedLocation.DockedLeft, dockedParentId);
            dockedParentId = new Guid("c9a6ddcd-81e9-4c0d-8781-8476eda2fe81");
            floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            internalId = new Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb");
            DockableControlPane pane2 = new DockableControlPane(dockedParentId, floatingParentId, -1, internalId, -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.UltraDropDown2 = new UltraDropDown();
            this.ElementDataSet1 = new ELEMENTDataSet();
            this.UltraDropDown1 = new UltraDropDown();
            this.RadnikPripremaDataSet1 = new RadnikPripremaDataSet();
            this.UltraTextEditor1 = new UltraTextEditor();
            this.UltraGroupBox2 = new UltraGroupBox();
            this.UltraGrid1 = new UltraGrid();
            this.PrplaceDataSet1 = new PRPLACEDataSet();
            this.UltraGroupBox3 = new UltraGroupBox();
            this.UltraGrid2 = new UltraGrid();
            this.UltraGridExcelExporter1 = new UltraGridExcelExporter(this.components);
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._PripremaPlaceCustomAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow3 = new DockableWindow();
            this.DockableWindow1 = new DockableWindow();
            this.WindowDockingArea3 = new WindowDockingArea();
            this.RadnikDataSet1 = new RADNIKDataSet();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraDropDown2).BeginInit();
            this.ElementDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDropDown1).BeginInit();
            this.RadnikPripremaDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            ((ISupportInitialize) this.UltraGroupBox2).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.PrplaceDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraGroupBox3).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid2).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea3.SuspendLayout();
            this.RadnikDataSet1.BeginInit();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.UltraDropDown2);
            this.UltraGroupBox1.Controls.Add(this.UltraDropDown1);
            this.UltraGroupBox1.Controls.Add(this.UltraTextEditor1);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Location = point;
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            Size size = new System.Drawing.Size(0x486, 0x4d);
            this.UltraGroupBox1.Size = size;
            this.UltraGroupBox1.TabIndex = 1;
            this.UltraDropDown2.DataMember = "ELEMENT";
            this.UltraDropDown2.DataSource = this.ElementDataSet1;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 0;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.VisiblePosition = 1;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.Header.VisiblePosition = 2;
            column23.Hidden = true;
            column34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column34.Header.VisiblePosition = 3;
            column34.Hidden = true;
            column45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column45.Header.VisiblePosition = 4;
            column45.Hidden = true;
            column49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column49.Header.VisiblePosition = 5;
            column49.Hidden = true;
            column50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column50.Header.VisiblePosition = 6;
            column50.Hidden = true;
            column51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column51.Header.VisiblePosition = 7;
            column51.Hidden = true;
            column52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column52.Header.VisiblePosition = 8;
            column52.Hidden = true;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 9;
            column2.Hidden = true;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 10;
            column3.Hidden = true;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 11;
            column4.Hidden = true;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 12;
            column5.Hidden = true;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.Header.VisiblePosition = 13;
            column6.Hidden = true;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.VisiblePosition = 14;
            column7.Hidden = true;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.VisiblePosition = 15;
            column8.Hidden = true;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 0x10;
            band.Columns.AddRange(new object[] { 
                column, column12, column23, column34, column45, column49, column50, column51, column52, column2, column3, column4, column5, column6, column7, column8, 
                column9
             });
            this.UltraDropDown2.DisplayLayout.BandsSerializer.Add(band);
            this.UltraDropDown2.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraDropDown2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraDropDown2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraDropDown2.DisplayMember = "IDELEMENT";
            this.UltraDropDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x205, 15);
            this.UltraDropDown2.Location = point;
            this.UltraDropDown2.Name = "UltraDropDown2";
            size = new System.Drawing.Size(0x105, 0x27);
            this.UltraDropDown2.Size = size;
            this.UltraDropDown2.TabIndex = 2;
            this.UltraDropDown2.Text = "UltraDropDown2";
            this.UltraDropDown2.ValueMember = "IDELEMENT";
            this.UltraDropDown2.Visible = false;
            this.ElementDataSet1.DataSetName = "ELEMENTDataSet";
            this.UltraDropDown1.DataMember = "RADNIK";
            this.UltraDropDown1.DataSource = this.RadnikPripremaDataSet1;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.Caption = "Šifra";
            column10.Header.VisiblePosition = 0;
            size = new System.Drawing.Size(0x86, 0);
            column10.RowLayoutColumnInfo.PreferredCellSize = size;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.Caption = "Prezime i ime";
            column11.Header.VisiblePosition = 1;
            size = new System.Drawing.Size(0x1bc, 0);
            column11.RowLayoutColumnInfo.PreferredCellSize = size;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 2;
            column13.Hidden = true;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 3;
            column14.Hidden = true;
            band2.Columns.AddRange(new object[] { column10, column11, column13, column14 });
            band2.UseRowLayout = true;
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band2);
            this.UltraDropDown1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraDropDown1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraDropDown1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraDropDown1.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraDropDown1.DisplayMember = "IDRADNIK";
            point = new System.Drawing.Point(0x363, 15);
            this.UltraDropDown1.Location = point;
            this.UltraDropDown1.Name = "UltraDropDown1";
            size = new System.Drawing.Size(140, 0x20);
            this.UltraDropDown1.Size = size;
            this.UltraDropDown1.TabIndex = 1;
            this.UltraDropDown1.Text = "UltraDropDown1";
            this.UltraDropDown1.ValueMember = "IDRADNIK";
            this.UltraDropDown1.Visible = false;
            this.RadnikPripremaDataSet1.DataSetName = "RadnikPripremaDataSet";
            this.UltraTextEditor1.BorderStyle = UIElementBorderStyle.TwoColor;
            button.Key = "zaposlenik";
            button.Text = "Kliknite za odabir";
            this.UltraTextEditor1.ButtonsRight.Add(button);
            point = new System.Drawing.Point(0x10, 0x21);
            this.UltraTextEditor1.Location = point;
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            size = new System.Drawing.Size(0x1bd, 0x15);
            this.UltraTextEditor1.Size = size;
            this.UltraTextEditor1.TabIndex = 11;
            this.UltraTextEditor1.Text = "Odaberite pripremu";
            this.UltraTextEditor1.UseAppStyling = false;
            this.UltraGroupBox2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.UltraGroupBox2.Controls.Add(this.UltraGrid1);
            point = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox2.Location = point;
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            size = new System.Drawing.Size(330, 0x160);
            this.UltraGroupBox2.Size = size;
            this.UltraGroupBox2.TabIndex = 8;
            this.UltraGroupBox2.UseAppStyling = false;
            this.UltraGroupBox2.ViewStyle = GroupBoxViewStyle.Office2007;
            this.UltraGrid1.DataMember = "PRPLACEPRPLACEELEMENTI";
            this.UltraGrid1.DataSource = this.PrplaceDataSet1;
            appearance.BackColor = Color.White;
            appearance.FontData.BoldAsString = "True";
            appearance.FontData.SizeInPoints = 8f;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.Header.VisiblePosition = 1;
            column15.Hidden = true;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.Header.VisiblePosition = 0;
            column16.Hidden = true;
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.Header.VisiblePosition = 2;
            column17.Hidden = true;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.CellActivation = Activation.NoEdit;
            column18.Header.VisiblePosition = 3;
            column18.Width = 0x3a;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.CellActivation = Activation.NoEdit;
            column19.Header.VisiblePosition = 4;
            column19.Width = 0xc5;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.CellActivation = Activation.NoEdit;
            column20.Header.VisiblePosition = 5;
            column20.MaskInput = "{LOC} nnn.nn";
            column20.Width = 60;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.Header.VisiblePosition = 6;
            band3.Columns.AddRange(new object[] { column15, column16, column17, column18, column19, column20, column21 });
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column22.Header.VisiblePosition = 1;
            column22.Width = 0xba;
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column24.Header.VisiblePosition = 0;
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column25.Header.VisiblePosition = 2;
            column26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column26.Header.VisiblePosition = 3;
            column27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column27.Header.VisiblePosition = 4;
            column28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column28.Header.VisiblePosition = 5;
            column29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column29.Header.VisiblePosition = 6;
            column30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column30.Header.VisiblePosition = 7;
            column31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column31.Header.VisiblePosition = 8;
            column32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column32.Header.VisiblePosition = 9;
            column33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column33.Header.VisiblePosition = 10;
            column35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column35.Header.VisiblePosition = 11;
            band4.Columns.AddRange(new object[] { column22, column24, column25, column26, column27, column28, column29, column30, column31, column32, column33, column35 });
            band4.Hidden = true;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band3);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band4);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance19.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance19;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance20.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance20;
            appearance21.BorderColor = Color.LightGray;
            appearance21.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance21;
            appearance2.BackColor = Color.LightSteelBlue;
            appearance2.BorderColor = Color.Black;
            appearance2.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(3, 0);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            size = new System.Drawing.Size(0x144, 0x15d);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.UseAppStyling = false;
            this.PrplaceDataSet1.DataSetName = "PRPLACEDataSet";
            this.UltraGroupBox3.Controls.Add(this.UltraGrid2);
            this.UltraGroupBox3.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0x14f, 100);
            this.UltraGroupBox3.Location = point;
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            size = new System.Drawing.Size(0x337, 370);
            this.UltraGroupBox3.Size = size;
            this.UltraGroupBox3.TabIndex = 9;
            this.UltraGroupBox3.ViewStyle = GroupBoxViewStyle.Office2007;
            this.UltraGrid2.DataMember = "PRPLACEPRPLACEELEMENTI.PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK";
            this.UltraGrid2.DataSource = this.PrplaceDataSet1;
            appearance12.BackColor = Color.White;
            appearance12.FontData.BoldAsString = "True";
            appearance12.ForeColorDisabled = Color.Black;
            this.UltraGrid2.DisplayLayout.Appearance = appearance12;
            column36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance3.FontData.BoldAsString = "True";
            column36.Header.Appearance = appearance3;
            column36.Header.VisiblePosition = 1;
            column36.Hidden = true;
            column37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance4.FontData.BoldAsString = "True";
            column37.Header.Appearance = appearance4;
            column37.Header.VisiblePosition = 0;
            column37.Hidden = true;
            column38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance5.FontData.BoldAsString = "True";
            column38.Header.Appearance = appearance5;
            column38.Header.VisiblePosition = 2;
            column38.Hidden = true;
            column39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.FontData.BoldAsString = "True";
            column39.Header.Appearance = appearance6;
            column39.Header.VisiblePosition = 3;
            column39.Hidden = true;
            column40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column40.CellActivation = Activation.NoEdit;
            appearance7.FontData.BoldAsString = "True";
            column40.Header.Appearance = appearance7;
            column40.Header.VisiblePosition = 4;
            column40.Width = 0x3e;
            column41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column41.CellActivation = Activation.Disabled;
            appearance8.FontData.BoldAsString = "True";
            column41.Header.Appearance = appearance8;
            column41.Header.VisiblePosition = 5;
            column41.Width = 130;
            column42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column42.CellActivation = Activation.Disabled;
            appearance9.FontData.BoldAsString = "True";
            column42.Header.Appearance = appearance9;
            column42.Header.VisiblePosition = 6;
            column42.Width = 110;
            column43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance10.FontData.BoldAsString = "True";
            column43.Header.Appearance = appearance10;
            column43.Header.Caption = "Sati";
            column43.Header.VisiblePosition = 7;
            column43.MaskInput = "nnn.nn";
            column43.Width = 0x37;
            column44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance11.FontData.BoldAsString = "True";
            column44.Header.Appearance = appearance11;
            column44.Header.Caption = "Satnica";
            column44.Header.VisiblePosition = 8;
            column44.MaskInput = "nn.nn";
            column44.Width = 0x37;
            column46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance13.FontData.BoldAsString = "True";
            column46.Header.Appearance = appearance13;
            column46.Header.Caption = "Postotak";
            column46.Header.VisiblePosition = 9;
            column46.MaskInput = "nnn.nn";
            column46.Width = 0x40;
            column47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance14.FontData.BoldAsString = "True";
            column47.Header.Appearance = appearance14;
            column47.Header.Caption = "Iznos";
            column47.Header.VisiblePosition = 10;
            column47.MaskInput = "nnnnn.nn";
            column47.Width = 0x44;
            column48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column48.Header.VisiblePosition = 11;
            column48.Hidden = true;
            band5.Columns.AddRange(new object[] { column36, column37, column38, column39, column40, column41, column42, column43, column44, column46, column47, column48 });
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band5);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance15.BackColor = Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance15;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            appearance16.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance16;
            appearance17.BorderColor = Color.LightGray;
            appearance17.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance17;
            appearance18.BackColor = Color.LightSteelBlue;
            appearance18.BorderColor = Color.Black;
            appearance18.ForeColor = Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance18;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid2.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(3, 0);
            this.UltraGrid2.Location = point;
            this.UltraGrid2.Name = "UltraGrid2";
            size = new System.Drawing.Size(0x331, 0x16f);
            this.UltraGrid2.Size = size;
            this.UltraGrid2.TabIndex = 7;
            this.UltraGrid2.UseAppStyling = false;
            dockedParentId = new Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb");
            pane3.DockedBefore = dockedParentId;
            pane.Control = this.UltraGroupBox1;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(4, 3, 0x265, 0x4d);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "Odabir postojeće pripreme plaće";
            pane3.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x486, 0x5f);
            pane3.Size = size;
            pane2.Control = this.UltraGroupBox2;
            rectangle = new System.Drawing.Rectangle(0x2f, 0x7b, 260, 0xe1);
            pane2.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane2.Size = size;
            pane2.Text = "Elementi u pripremi";
            pane4.Panes.AddRange(new DockablePaneBase[] { pane2 });
            size = new System.Drawing.Size(330, 370);
            pane4.Size = size;
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane3, pane4 });
            this.UltraDockManager1.HostControl = this;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Name = "_PripremaPlaceCustomUnpinnedTabAreaLeft";
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.TabIndex = 10;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x486, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Name = "_PripremaPlaceCustomUnpinnedTabAreaRight";
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.TabIndex = 11;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Name = "_PripremaPlaceCustomUnpinnedTabAreaTop";
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x486, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.TabIndex = 12;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Name = "_PripremaPlaceCustomUnpinnedTabAreaBottom";
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x486, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.TabIndex = 13;
            this._PripremaPlaceCustomAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomAutoHideControl.Location = point;
            this._PripremaPlaceCustomAutoHideControl.Name = "_PripremaPlaceCustomAutoHideControl";
            this._PripremaPlaceCustomAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0);
            this._PripremaPlaceCustomAutoHideControl.Size = size;
            this._PripremaPlaceCustomAutoHideControl.TabIndex = 14;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Location = point;
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x486, 100);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 15;
            this.DockableWindow3.Controls.Add(this.UltraGroupBox1);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Location = point;
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x486, 0x5f);
            this.DockableWindow3.Size = size;
            this.DockableWindow3.TabIndex = 0x12;
            this.DockableWindow1.Controls.Add(this.UltraGroupBox2);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Location = point;
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(330, 370);
            this.DockableWindow1.Size = size;
            this.DockableWindow1.TabIndex = 0x13;
            this.WindowDockingArea3.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea3.Dock = DockStyle.Left;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 100);
            this.WindowDockingArea3.Location = point;
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x14f, 370);
            this.WindowDockingArea3.Size = size;
            this.WindowDockingArea3.TabIndex = 0x11;
            this.RadnikDataSet1.DataSetName = "RADNIKDataSet";
            this.Controls.Add(this._PripremaPlaceCustomAutoHideControl);
            this.Controls.Add(this.UltraGroupBox3);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaTop);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaBottom);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaLeft);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaRight);
            this.Name = "PripremaPlaceCustom";
            size = new System.Drawing.Size(0x486, 470);
            this.Size = size;
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.UltraDropDown2).EndInit();
            this.ElementDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDropDown1).EndInit();
            this.RadnikPripremaDataSet1.EndInit();
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            ((ISupportInitialize) this.UltraGroupBox2).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.PrplaceDataSet1.EndInit();
            ((ISupportInitialize) this.UltraGroupBox3).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid2).EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea3.ResumeLayout(false);
            this.RadnikDataSet1.EndInit();
            this.ResumeLayout(false);
        }

        [LocalCommandHandler("Smjenski")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            if (this.PrplaceDataSet1.PRPLACE.Rows.Count != 0)
            {
                this.Smjenski_Rad_Tablica();
            }
        }

        public void IspisRekapitulacije()
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptRekapPripreme.rpt");
            document.SetDataSource(this.PrplaceDataSet1);
            document.SetParameterValue("ADRESA_FIRME2", str2);
            document.SetParameterValue("ADRESA_FIRME", str);
            document.SetParameterValue("NAZIV_FIRME", str6);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IspisRekapitulacijeCommand")]
        public void IspisRekapitulacijeHandler(object sender, EventArgs e)
        {
            this.IspisRekapitulacije();
        }

        public void Posebni_Srednje_Tablica()
        {
            Workbook workbook;
            IEnumerator enumerator = null;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) Interaction.CreateObject("Excel.Application", "");
            try
            {
                workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\DOD_NA_PL_POSUVJ.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                //application.Quit();
                //return;
            }
            Worksheet worksheet = (Worksheet) workbook.Sheets["DOD NA PLAĆU ZA RAD U POS-SŠ "];
            s_od_pripremaDataAdapter adapter = new s_od_pripremaDataAdapter();
            s_od_pripremaDataSet dataSet = new s_od_pripremaDataSet();
            s_od_pripremaDataSet set2 = new s_od_pripremaDataSet();
            adapter.Fill(dataSet, this.ZAGODINU, this.prplaceid, this.ZAMJESEC, "sposebni1,sposebni2,sposebni3");
            int num = 1;
            worksheet.PageSetup.PrintTitleRows = "$1:$14";
            worksheet.PageSetup.CenterVertically = false;
            worksheet.PageSetup.TopMargin = 5.0;
            worksheet.PageSetup.BottomMargin = 5.0;
            worksheet.PageSetup.CenterVertically = false;
            num = 1;
            KORISNIKDataAdapter adapter2 = new KORISNIKDataAdapter();
            KORISNIKDataSet set3 = new KORISNIKDataSet();
            adapter2.Fill(set3);
            NewLateBinding.LateSetComplex(worksheet.Cells[5, 1], null, "Value", new object[] { Operators.ConcatenateObject("Naziv škole:", set3.KORISNIK.Rows[0]["korisnik1naziv"]) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet.Cells[6, 1], null, "Value", new object[] { Operators.ConcatenateObject("Adresa:", set3.KORISNIK.Rows[0]["korisnik1adresa"]) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet.Cells[7, 1], null, "Value", new object[] { Operators.ConcatenateObject("Telefon/fax:", set3.KORISNIK.Rows[0]["kontakttelefon"]) }, null, null, false, true);
            try
            {
                enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if (((decimal.Compare(Conversions.ToDecimal(current["sposebni1iznos"]), decimal.Zero) > 0) | (decimal.Compare(Conversions.ToDecimal(current["sposebni2iznos"]), decimal.Zero) > 0)) | (decimal.Compare(Conversions.ToDecimal(current["sposebni3iznos"]), decimal.Zero) > 0))
                    {
                        decimal num4 = 0;
                        decimal num6 = 0;
                        decimal num8 = 0;
                        decimal num10 = 0;
                        NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 1], null, "Value", new object[] { num }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 2], null, "Value", new object[] { Conversions.ToString(current["imeprezime"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 3], null, "Value", new object[] { DB.N2T(RuntimeHelpers.GetObjectValue(current["nazivradnomjesto"]), "") }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 4], null, "Value", new object[] { Conversions.ToDecimal(current["DODATNIKOEFICIJENT"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 5], null, "Value", new object[] { Conversions.ToDecimal(current["sposebni1satnica"]) }, null, null, false, true);
                        if (decimal.Compare(Conversions.ToDecimal(current["sposebni1iznos"]), decimal.Zero) > 0)
                        {
                            decimal num3 = 0;
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 6], null, "Value", new object[] { this.SATIGLOBALNO }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 7], null, "Value", new object[] { Conversions.ToDecimal(current["sposebni1sati"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 8], null, "Value", new object[] { Conversions.ToDecimal(current["sposebni1iznos"]) }, null, null, false, true);
                            num4 = decimal.Add(num4, Conversions.ToDecimal(current["sposebni1iznos"]));
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["sposebni1iznos"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["sposebni2iznos"]), decimal.Zero) > 0)
                        {
                            decimal num5 = 0;
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 9], null, "Value", new object[] { this.SATIGLOBALNO }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 10], null, "Value", new object[] { Conversions.ToDecimal(current["sposebni2sati"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 11], null, "Value", new object[] { Conversions.ToDecimal(current["sposebni2iznos"]) }, null, null, false, true);
                            num6 = decimal.Add(num6, Conversions.ToDecimal(current["sposebni2iznos"]));
                            num5 = decimal.Add(num5, Conversions.ToDecimal(current["sposebni2iznos"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["sposebni3iznos"]), decimal.Zero) > 0)
                        {
                            decimal num7 = 0;
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 13], null, "Value", new object[] { Conversions.ToDecimal(current["sposebni3sati"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 14], null, "Value", new object[] { DB.RoundUP(decimal.Divide(decimal.Multiply(Conversions.ToDecimal(current["sposebni3sati"]), 7M), 100M)) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 15], null, "Value", new object[] { Conversions.ToDecimal(current["sposebni3iznos"]) }, null, null, false, true);
                            num8 = decimal.Add(num8, Conversions.ToDecimal(current["sposebni3iznos"]));
                            num7 = decimal.Add(num7, Conversions.ToDecimal(current["sposebni3iznos"]));
                        }
                        decimal num9 = decimal.Add(decimal.Add(num4, num6), num8);
                        num10 = decimal.Add(num9, num10);
                        NewLateBinding.LateSetComplex(worksheet.Cells[13 + num, 0x10], null, "Value", new object[] { num9 }, null, null, false, true);
                        num9 = new decimal();
                        num4 = new decimal();
                        num6 = new decimal();
                        num8 = new decimal();
                        num++;
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
            string str = DateAndTime.Today.ToString();
            SaveFileDialog dialog = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                FileName = "Posebni_" + Conversions.ToString(this.ZAGODINU) + "_" + Conversions.ToString(this.ZAMJESEC),
                RestoreDirectory = true
            };
            dialog.ShowDialog();
            try
            {
                workbook.SaveAs(dialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Thread.CurrentThread.CurrentCulture = currentCulture;
                application.Quit();
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Exception exception2 = exception3;
                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                //Thread.CurrentThread.CurrentCulture = currentCulture;
                //application.Quit();
            }
        }

        public void Posebni_Tablica()
        {
            DataRow current;
            decimal num3 = 0;
            decimal num5 = 0;
            decimal num7 = 0;
            decimal num10 = 0;
            decimal num12 = 0;
            decimal num13 = 0;
            Workbook workbook;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) Interaction.CreateObject("Excel.Application", "");
            try
            {
                workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\Posebni_Novo.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                //application.Quit();
                //return;
            }
            Worksheet worksheet = (Worksheet) workbook.Sheets["Dodatak na pl.2"];
            Worksheet worksheet2 = (Worksheet) workbook.Sheets["Doatak na pl.1"];
            s_od_pripremaDataAdapter adapter = new s_od_pripremaDataAdapter();
            s_od_pripremaDataSet dataSet = new s_od_pripremaDataSet();
            s_od_pripremaDataSet set2 = new s_od_pripremaDataSet();
            adapter.Fill(dataSet, this.ZAGODINU, this.prplaceid, this.ZAMJESEC, "kombinacija,kombinacija2");
            int num = 1;
            int num2 = dataSet.Tables[0].Rows.Count - 15;
            if (num2 > 0)
            {
                int num16 = num2 - 1;
                for (int i = 0; i <= num16; i++)
                {
                    worksheet2.get_Range("a16:r16", Missing.Value).Copy(Missing.Value);
                    worksheet2.get_Range("A16", Missing.Value).Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
                    worksheet2.get_Range("A16", Missing.Value).PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, Missing.Value, Missing.Value);
                    NewLateBinding.LateSetComplex(worksheet2.Rows[0x1b + i, Missing.Value], null, "rowheight", new object[] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet2.Rows[0x10, Missing.Value], null, "rowheight", new object[0], null, null, null)) }, null, null, false, true);
                }
            }
            try
            {
                enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    if ((decimal.Compare(Conversions.ToDecimal(current["KOMBINACIJAIZNOS"]), decimal.Zero) > 0) | (decimal.Compare(Conversions.ToDecimal(current["KOMBINACIJAIZNOS2"]), decimal.Zero) > 0))
                    {
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 1], null, "Value", new object[] { num }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 2], null, "Value", new object[] { Conversions.ToString(current["imeprezime"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 3], null, "Value", new object[] { DB.N2T(RuntimeHelpers.GetObjectValue(current["nazivradnomjesto"]), "") }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 4], null, "Value", new object[] { Conversions.ToDecimal(current["DODATNIKOEFICIJENT"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 5], null, "Value", new object[] { Conversions.ToDecimal(current["KOMBINACIJAPOSTOTAK"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 6], null, "Value", new object[] { Conversions.ToDecimal(current["KOMBINACIJAIZNOS"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 7], null, "Value", new object[] { Conversions.ToDecimal(current["KOMBINACIJAPOSTOTAK2"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 8], null, "Value", new object[] { Conversions.ToDecimal(current["KOMBINACIJAIZNOS2"]) }, null, null, false, true);
                        num13 = decimal.Add(num13, Conversions.ToDecimal(current["KOMBINACIJAIZNOS2"]));
                        num12 = decimal.Add(num12, Conversions.ToDecimal(current["KOMBINACIJAIZNOS"]));
                    }
                    num++;
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            if (num <= 0x10)
            {
                num = 0x10;
            }
            NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 6], null, "Value", new object[] { num12 }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet2.Cells[(14 + num) + 1, 6], null, "Value", new object[] { DB.RoundUpDecimale((Convert.ToDouble(num12) * 17.2) / 100.0, 2) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet2.Cells[(14 + num) + 2, 6], null, "Value", new object[] { decimal.Add(DB.RoundUpDecimale((Convert.ToDouble(num12) * 17.2) / 100.0, 2), num12) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet2.Cells[14 + num, 8], null, "Value", new object[] { num13 }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet2.Cells[(14 + num) + 1, 8], null, "Value", new object[] { DB.RoundUpDecimale((Convert.ToDouble(num13) * 17.2) / 100.0, 2) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet2.Cells[(14 + num) + 2, 8], null, "Value", new object[] { decimal.Add(DB.RoundUpDecimale((Convert.ToDouble(num13) * 17.2) / 100.0, 2), num13) }, null, null, false, true);
            dataSet.Clear();
            adapter.Fill(dataSet, this.ZAGODINU, this.prplaceid, this.ZAMJESEC, "posebni1,posebni2,posebni3");
            num2 = dataSet.Tables[0].Rows.Count - 10;
            if (num2 > 0)
            {
                int num17 = num2 - 1;
                for (int j = 0; j <= num17; j++)
                {
                    worksheet.get_Range("a16:r16", Missing.Value).Copy(Missing.Value);
                    worksheet.get_Range("A16", Missing.Value).Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
                    worksheet.get_Range("A16", Missing.Value).PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, Missing.Value, Missing.Value);
                    NewLateBinding.LateSetComplex(worksheet.Rows[0x1b + j, Missing.Value], null, "rowheight", new object[] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet.Rows[0x10, Missing.Value], null, "rowheight", new object[0], null, null, null)) }, null, null, false, true);
                }
            }
            worksheet.PageSetup.PrintTitleRows = "$1:$14";
            worksheet.PageSetup.CenterVertically = false;
            worksheet.PageSetup.TopMargin = 5.0;
            worksheet.PageSetup.BottomMargin = 5.0;
            worksheet.PageSetup.CenterVertically = false;
            num = 1;
            KORISNIKDataAdapter adapter2 = new KORISNIKDataAdapter();
            KORISNIKDataSet set3 = new KORISNIKDataSet();
            adapter2.Fill(set3);
            NewLateBinding.LateSetComplex(worksheet.Cells[5, 1], null, "Value", new object[] { Operators.ConcatenateObject("Naziv škole:", set3.KORISNIK.Rows[0]["korisnik1naziv"]) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet.Cells[6, 1], null, "Value", new object[] { Operators.ConcatenateObject("Adresa:", set3.KORISNIK.Rows[0]["korisnik1adresa"]) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet.Cells[7, 1], null, "Value", new object[] { Operators.ConcatenateObject("Telefon/fax:", set3.KORISNIK.Rows[0]["kontakttelefon"]) }, null, null, false, true);
            try
            {
                enumerator2 = dataSet.Tables[0].Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    current = (DataRow) enumerator2.Current;
                    if (((decimal.Compare(Conversions.ToDecimal(current["posebni1iznos"]), decimal.Zero) > 0) | (decimal.Compare(Conversions.ToDecimal(current["posebni2iznos"]), decimal.Zero) > 0)) | (decimal.Compare(Conversions.ToDecimal(current["posebni3iznos"]), decimal.Zero) > 0))
                    {
                        decimal num4 = 0;
                        decimal num6 = 0;
                        decimal num8 = 0;
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 1], null, "Value", new object[] { num }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 2], null, "Value", new object[] { Conversions.ToString(current["imeprezime"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 3], null, "Value", new object[] { DB.N2T(RuntimeHelpers.GetObjectValue(current["nazivradnomjesto"]), "") }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 4], null, "Value", new object[] { Conversions.ToDecimal(current["DODATNIKOEFICIJENT"]) }, null, null, false, true);
                        if (decimal.Compare(Conversions.ToDecimal(current["posebni1iznos"]), decimal.Zero) > 0)
                        {
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 5], null, "Value", new object[] { Conversions.ToDecimal(current["posebni1satnica"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 8], null, "Value", new object[] { Conversions.ToDecimal(current["posebni1sati"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 9], null, "Value", new object[] { Conversions.ToDecimal(current["posebni1iznos"]) }, null, null, false, true);
                            num4 = decimal.Add(num4, Conversions.ToDecimal(current["posebni1iznos"]));
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["posebni1iznos"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["posebni2iznos"]), decimal.Zero) > 0)
                        {
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 5], null, "Value", new object[] { Conversions.ToDecimal(current["posebni2satnica"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 12], null, "Value", new object[] { Conversions.ToDecimal(current["posebni2sati"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 13], null, "Value", new object[] { Conversions.ToDecimal(current["posebni2iznos"]) }, null, null, false, true);
                            num6 = decimal.Add(num6, Conversions.ToDecimal(current["posebni2iznos"]));
                            num5 = decimal.Add(num5, Conversions.ToDecimal(current["posebni2iznos"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["posebni3iznos"]), decimal.Zero) > 0)
                        {
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 5], null, "Value", new object[] { Conversions.ToDecimal(current["posebni3satnica"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 0x10], null, "Value", new object[] { Conversions.ToDecimal(current["posebni3sati"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 0x11], null, "Value", new object[] { Conversions.ToDecimal(current["posebni3iznos"]) }, null, null, false, true);
                            num8 = decimal.Add(num8, Conversions.ToDecimal(current["posebni3iznos"]));
                            num7 = decimal.Add(num7, Conversions.ToDecimal(current["posebni3iznos"]));
                        }
                        decimal num9 = decimal.Add(decimal.Add(num4, num6), num8);
                        num10 = decimal.Add(num9, num10);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 0x12], null, "Value", new object[] { num9 }, null, null, false, true);
                        num9 = new decimal();
                        num4 = new decimal();
                        num6 = new decimal();
                        num8 = new decimal();
                        num++;
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
            if (num <= 10)
            {
                num = 10;
                NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 0x13], null, "Value", new object[] { num10 }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 0x11], null, "Value", new object[] { num7 }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 13], null, "Value", new object[] { num5 }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 9], null, "Value", new object[] { num3 }, null, null, false, true);
            }
            else
            {
                NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 0x12], null, "Value", new object[] { num10 }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[(14 + num) + 1, 0x12], null, "Value", new object[] { DB.RoundUpDecimale((Convert.ToDouble(num10) * 17.2) / 100.0, 2) }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[(14 + num) + 2, 0x12], null, "Value", new object[] { decimal.Add(DB.RoundUpDecimale((Convert.ToDouble(num10) * 17.2) / 100.0, 2), num10) }, null, null, false, true);
            }
            string str = DateAndTime.Today.ToString();
            SaveFileDialog dialog = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                FileName = "Posebni_" + Conversions.ToString(this.ZAGODINU) + "_" + Conversions.ToString(this.ZAMJESEC),
                RestoreDirectory = true
            };
            dialog.ShowDialog();
            try
            {
                workbook.SaveAs(dialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Thread.CurrentThread.CurrentCulture = currentCulture;
                application.Quit();
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Exception exception2 = exception3;
                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                //Thread.CurrentThread.CurrentCulture = currentCulture;
                //application.Quit();
                
            }
        }

        [LocalCommandHandler("Posebni")]
        public void PosebniHandler(object sender, EventArgs e)
        {
            if (this.PrplaceDataSet1.PRPLACE.Rows.Count != 0)
            {
                this.Posebni_Tablica();
            }
        }

        [LocalCommandHandler("PosebniSS")]
        public void PosebniSSHandler(object sender, EventArgs e)
        {
            if (this.PrplaceDataSet1.PRPLACE.Rows.Count != 0)
            {
                this.Posebni_Srednje_Tablica();
            }
        }

        public void Preracunaj_satnice()
        {
            IEnumerator enumerator = null;
            SqlCommand command = new SqlCommand();
            SqlCommand command2 = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            adapter.SelectCommand = command;
            command.CommandText = "SELECT     idradnik,dbo.RADNIKLevel7.DODATNIKOEFICIJENT, dbo.GRUPEKOEFLevel1.IDELEMENT FROM dbo.GRUPEKOEFLevel1 INNER JOIN dbo.RADNIKLevel7 ON dbo.GRUPEKOEFLevel1.IDGRUPEKOEF = dbo.RADNIKLevel7.IDGRUPEKOEF";
            DataSet dataSet = new DataSet();
            adapter.SelectCommand.Connection = connection;
            adapter.Fill(dataSet);
            command.CommandType = CommandType.Text;
            connection.Open();
            try
            {
                enumerator = this.PrplaceDataSet1.PRPLACEPRPLACEELEMENTIRADNIK.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    decimal num = 0;
                    DataRow current = (DataRow) enumerator.Current;
                    current.BeginEdit();
                    current["PRPLACESATNICA"] = DB.RoundUpDecimale(placa.Test(Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idelement"]), Configuration.ConnectionString, this.OSNOVICA, this.SATIGLOBALNO), 2);
                    DataRow[] rowArray = dataSet.Tables[0].Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement =", current["idelement"]), " and "), "idradnik= "), current["idradnik"])));
                    if (rowArray.Length > 0)
                    {
                        num = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(rowArray[0]["DODATNIKOEFICIJENT"], this.OSNOVICA), this.SATIGLOBALNO), 2);
                    }
                    else
                    {
                        num = new decimal();
                    }
                    current["PRPLACEIZNOS"] = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(current["PRPLACESATI"], current["PRPLACESATNICA"]), current["prplacePOSTOTAK"]), 100), 2);
                    current.EndEdit();
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            new PRPLACEDataAdapter().Update(this.PrplaceDataSet1);
        }

        [LocalCommandHandler("PreracunajSatnice")]
        public void PreracunajSatniceHandler(object sender, EventArgs e)
        {
            if (this.PrplaceDataSet1.PRPLACE.Rows.Count != 0)
            {
                this.Preracunaj_satnice();
            }
        }

        private void Priprema_Load(object sender, EventArgs e)
        {
            new GRUPEKOEFDataAdapter().Fill(this.dsgrupe);
        }

        public void Smjenski_Rad_Tablica()
        {
            Workbook workbook;
            IEnumerator enumerator = null;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) Interaction.CreateObject("Excel.Application", "");
            try
            {
                workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\Smjenski_rad_OS.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                //application.Quit();
                //return;
            }
            Worksheet worksheet = (Worksheet) workbook.Sheets["OŠ-smjenski rad"];
            s_od_pripremaDataAdapter adapter = new s_od_pripremaDataAdapter();
            s_od_pripremaDataSet dataSet = new s_od_pripremaDataSet();
            adapter.Fill(dataSet, this.ZAGODINU, this.prplaceid, this.ZAMJESEC, "smjenski");
            int num2 = dataSet.Tables[0].Rows.Count - 16;
            if (num2 > 0)
            {
                int num6 = num2 - 1;
                for (int i = 0; i <= num6; i++)
                {
                    worksheet.get_Range("a15:g15", Missing.Value).Copy(Missing.Value);
                    worksheet.get_Range("A16", Missing.Value).Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
                    worksheet.get_Range("A16", Missing.Value).PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, Missing.Value, Missing.Value);
                    NewLateBinding.LateSetComplex(worksheet.Rows[0x20 + i, Missing.Value], null, "rowheight", new object[] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet.Rows[0x10, Missing.Value], null, "rowheight", new object[0], null, null, null)) }, null, null, false, true);
                }
            }
            int num = 1;
            decimal num4 = new decimal();
            KORISNIKDataAdapter adapter2 = new KORISNIKDataAdapter();
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            adapter2.Fill(set2);
            NewLateBinding.LateSetComplex(worksheet.Cells[3, 1], null, "Value", new object[] { Operators.ConcatenateObject("Naziv škole:", set2.KORISNIK.Rows[0]["korisnik1naziv"]) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet.Cells[4, 1], null, "Value", new object[] { Operators.ConcatenateObject("Adresa:", set2.KORISNIK.Rows[0]["korisnik1adresa"]) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet.Cells[5, 1], null, "Value", new object[] { Operators.ConcatenateObject("Telefon/fax:", set2.KORISNIK.Rows[0]["kontakttelefon"]) }, null, null, false, true);
            try
            {
                enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if (decimal.Compare(Conversions.ToDecimal(current["smjenskiiznos"]), decimal.Zero) > 0)
                    {
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 1], null, "Value", new object[] { num }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 2], null, "Value", new object[] { Conversions.ToString(current["imeprezime"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 3], null, "Value", new object[] { DB.N2T(RuntimeHelpers.GetObjectValue(current["nazivradnomjesto"]), "") }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 4], null, "Value", new object[] { Conversions.ToDecimal(current["DODATNIKOEFICIJENT"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 5], null, "Value", new object[] { Conversions.ToDecimal(current["smjenskisatnica"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 6], null, "Value", new object[] { Conversions.ToDecimal(current["smjenskisati"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[14 + num, 7], null, "Value", new object[] { Conversions.ToDecimal(current["smjenskiiznos"]) }, null, null, false, true);
                        num++;
                        num4 = decimal.Add(num4, Conversions.ToDecimal(current["smjenskiiznos"]));
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
            int num3 = dataSet.Tables[0].Rows.Count - 0x10;
            num3 += 0x20;
            if (dataSet.Tables[0].Rows.Count <= 0x10)
            {
                NewLateBinding.LateSetComplex(worksheet.Cells[0x1f, 7], null, "Value", new object[] { num4 }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[0x20, 7], null, "Value", new object[] { DB.RoundUpDecimale((Convert.ToDouble(num4) * 15.2) / 100.0, 2) }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[0x21, 7], null, "Value", new object[] { decimal.Add(num4, DB.RoundUpDecimale((Convert.ToDouble(num4) * 15.2) / 100.0, 2)) }, null, null, false, true);
            }
            else
            {
                NewLateBinding.LateSetComplex(worksheet.Cells[num3 - 1, 7], null, "Value", new object[] { num4 }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[num3, 7], null, "Value", new object[] { DB.RoundUpDecimale((Convert.ToDouble(num4) * 15.2) / 100.0, 2) }, null, null, false, true);
                NewLateBinding.LateSetComplex(worksheet.Cells[num3 + 1, 7], null, "Value", new object[] { decimal.Add(num4, DB.RoundUpDecimale((Convert.ToDouble(num4) * 15.2) / 100.0, 2)) }, null, null, false, true);
            }
            SaveFileDialog dialog = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                FileName = "Smjenski_rad_" + Conversions.ToString(this.ZAGODINU) + "_" + Conversions.ToString(this.ZAMJESEC),
                RestoreDirectory = true
            };
            dialog.ShowDialog();
            try
            {
                workbook.SaveAs(dialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Thread.CurrentThread.CurrentCulture = currentCulture;
                application.Quit();
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Thread.CurrentThread.CurrentCulture = currentCulture;
                //application.Quit();
            }
        }

        [CommandHandler("Snimi")]
        public void SnimiHandler(object sender, EventArgs e)
        {
        }

        [CommandHandler("Ucitaj")]
        public void UcitajHandler(object sender, EventArgs e)
        {
        }

        private void UltraDropDown1_AfterCloseUp(object sender, DropDownEventArgs e)
        {
            if (this.UltraDropDown1.SelectedRow != null && this.UltraGrid2.ActiveRow != null)
            {
                int IDRADNIK = Conversions.ToInteger(this.UltraDropDown1.SelectedRow.Cells["IDRADNIK"].Value);
                int IDELEMENT = Conversions.ToInteger(this.UltraGrid1.ActiveRow.Cells["IDELEMENT"].Value);

                this.UltraGrid2.ActiveRow.Cells["PRPLACESATNICA"].Value = DB.RoundUpDecimale(placa.Test(IDRADNIK, 
                    IDELEMENT, 
                    Configuration.ConnectionString, 
                    this.OSNOVICA, 
                    this.SATIGLOBALNO), 2);

                if (this.dsgrupe.GRUPEKOEFLevel1.Select(Conversions.ToString(Operators.ConcatenateObject("idelement = ", this.UltraGrid1.ActiveRow.Cells["idelement"].Value))).Length > 0)
                {
                    if (Operators.ConditionalCompareObjectEqual(this.dsgrupe.GRUPEKOEFLevel1.Select("idelement = " + Conversions.ToString(Conversions.ToInteger(this.UltraGrid1.ActiveRow.Cells["IDELEMENT"].Value)))[0]["idmzostablice"], 13, false))
                    {
                        this.UltraGrid2.ActiveRow.Cells["PRPLACESATI"].Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(10M, this.SATIGLOBALNO), 100M), 2);
                    }
                    if (Operators.ConditionalCompareObjectEqual(this.dsgrupe.GRUPEKOEFLevel1.Select("idelement = " + Conversions.ToString(Conversions.ToInteger(this.UltraGrid1.ActiveRow.Cells["IDELEMENT"].Value)))[0]["idmzostablice"], 14, false))
                    {
                        this.UltraGrid2.ActiveRow.Cells["PRPLACESATI"].Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(10M, this.SATIGLOBALNO), 100M), 2);
                    }
                }
            }
        }

        private void UltraGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            this.UltraGrid2.PerformAction(UltraGridAction.FirstRowInBand);
        }

        private void UltraGrid1_AfterRowInsert(object sender, RowEventArgs e)
        {
            e.Row.Cells["PRPLACEZAMJESEC"].Value = this.ZAMJESEC;
            e.Row.Cells["PRPLACEZAGODINU"].Value = this.ZAGODINU;
            e.Row.Cells["PRPLACEID"].Value = this.prplaceid;
        }

        private void UltraGrid1_AfterRowsDeleted(object sender, EventArgs e)
        {
            new PRPLACEDataAdapter().Update(this.PrplaceDataSet1);
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
            new PRPLACEDataAdapter().Update(this.PrplaceDataSet1);
        }

        private void UltraGrid1_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
            e.Band.Columns["idelement"].CellActivation = Activation.AllowEdit;
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void UltraGrid2_AfterCellActivate(object sender, EventArgs e)
        {
        }

        private void UltraGrid2_AfterCellUpdate(object sender, CellEventArgs e)
        {
            decimal num = 0;
            decimal num2 = 0;
            decimal num3 = 0;
            decimal num4 = 0;
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Cell.Row.Cells["PRPLACESATI"].Value)))
            {
                num3 = Conversions.ToDecimal(e.Cell.Row.Cells["PRPLACESATI"].Value);
            }
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Cell.Row.Cells["PRPLACESATNICA"].Value)))
            {
                num4 = Conversions.ToDecimal(e.Cell.Row.Cells["PRPLACESATNICA"].Value);
            }
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Cell.Row.Cells["PRPLACEIZNOS"].Value)))
            {
                num = Conversions.ToDecimal(e.Cell.Row.Cells["PRPLACEIZNOS"].Value);
            }
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Cell.Row.Cells["PRPLACEPOSTOTAK"].Value)))
            {
                num2 = Conversions.ToDecimal(e.Cell.Row.Cells["PRPLACEPOSTOTAK"].Value);
            }
            num = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(decimal.Multiply(num4, num3), num2), 100M), 2);
            if (((e.Cell.Column.Key == "PRPLACESATI") | (e.Cell.Column.Key == "PRPLACESATNICA")) | (e.Cell.Column.Key == "PRPLACEPOSTOTAK"))
            {
                e.Cell.Row.Cells["PRPLACEIZNOS"].Value = num;
            }
        }

        private void UltraGrid2_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.UltraGrid2.ActiveCell.Column.Key == "PRPLACESATI")
            {
                this.UltraGrid2.ActiveCell.SelectAll();
            }
            if (this.UltraGrid2.ActiveCell.Column.Key == "PRPLACESATNICA")
            {
                this.UltraGrid2.ActiveCell.SelectAll();
            }
            if (this.UltraGrid2.ActiveCell.Column.Key == "PRPLACEPOSTOTAK")
            {
                this.UltraGrid2.ActiveCell.SelectAll();
            }
            if (this.UltraGrid2.ActiveCell.Column.Key == "PRPLACEIZNOS")
            {
                this.UltraGrid2.ActiveCell.SelectAll();
            }
        }

        private void UltraGrid2_AfterRowInsert(object sender, RowEventArgs e)
        {
            e.Row.Cells["PRPLACESATI"].Value = 0;
            e.Row.Cells["PRPLACESATNICA"].Value = 0;
            e.Row.Cells["PRPLACEPOSTOTAK"].Value = RuntimeHelpers.GetObjectValue(this.UltraGrid1.ActiveRow.Cells["POSTOTAK"].Value);
            e.Row.Cells["PRPLACEIZNOS"].Value = 0;
        }

        private void UltraGrid2_AfterRowsDeleted(object sender, EventArgs e)
        {
            new PRPLACEDataAdapter().Update(this.PrplaceDataSet1);
        }

        private void UltraGrid2_AfterRowUpdate(object sender, RowEventArgs e)
        {
            new PRPLACEDataAdapter().Update(this.PrplaceDataSet1);
        }

        private void UltraGrid2_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
        }

        private void UltraGrid2_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
            e.Band.Columns["idradnik"].CellActivation = Activation.AllowEdit;
        }

        private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void UltraGrid2_InitializeRowsCollection(object sender, InitializeRowsCollectionEventArgs e)
        {
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                PRPLACESelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<PRPLACESelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row == null)
                {
                    return;
                }
                this.PrplaceDataSet1.Clear();
                new PRPLACEDataAdapter().FillByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(this.PrplaceDataSet1, Conversions.ToShort(row["PRPLACEZAMJESEC"]), Conversions.ToInteger(row["PRPLACEID"]), Conversions.ToShort(row["PRPLACEZAGODINU"]));
                this.OSNOVICA = Conversions.ToDecimal(row["PRPLACEOSNOVICA"]);
                this.SATIGLOBALNO = Conversions.ToDecimal(row["PRPLACEPROSJECNISATI"]);
                this.prplaceid = Conversions.ToInteger(row["PRPLACEID"]);
                this.ZAMJESEC = Conversions.ToInteger(row["PRPLACEZAMJESEC"]);
                this.ZAGODINU = Conversions.ToInteger(row["PRPLACEZAGODINU"]);
                this.UltraTextEditor1.Value = RuntimeHelpers.GetObjectValue(row["prplaceopis"]);
            }
            RadnikPripremaDataAdapter adapter2 = new RadnikPripremaDataAdapter();
            this.RadnikPripremaDataSet1.Clear();
            adapter2.Fill(this.RadnikPripremaDataSet1);
            ELEMENTDataAdapter adapter = new ELEMENTDataAdapter();
            this.ElementDataSet1.Clear();
            adapter.FillByIDVRSTAELEMENTA(this.ElementDataSet1, 2);
            adapter.FillByIDVRSTAELEMENTA(this.ElementDataSet1, 1);
        }

        private void UltraTextEditor1_ValueChanged(object sender, EventArgs e)
        {
        }

        public void Uvecanje_Tablica()
        {
            decimal num5 = 0;
            Workbook workbook;
            IEnumerator enumerator = null;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) Interaction.CreateObject("Excel.Application", "");
            try
            {
                workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\Uvecanje_Novo.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                //application.Quit();
                //return;
            }
            Worksheet worksheet = (Worksheet) workbook.Sheets["UVEĆANJE OSNOVNE PLAĆE-OŠ 1"];
            Worksheet worksheet2 = (Worksheet) workbook.Sheets["UVEĆANJE OSNOVNE PLAĆE-OŠ-2"];
            s_od_pripremaDataAdapter adapter = new s_od_pripremaDataAdapter();
            s_od_pripremaDataSet dataSet = new s_od_pripremaDataSet();
            adapter.Fill(dataSet, this.ZAGODINU, this.prplaceid, this.ZAMJESEC, "subotom,nedjeljom,prekovremeni,nocni,blagdan,dvokratni");
            int num2 = dataSet.Tables[0].Rows.Count - 12;
            if (num2 > 0)
            {
                int num8 = num2 - 1;
                for (int i = 0; i <= num8; i++)
                {
                    worksheet.get_Range("a13:K13", Missing.Value).Copy(Missing.Value);
                    worksheet.get_Range("A13", Missing.Value).Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
                    worksheet.get_Range("A13", Missing.Value).PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, Missing.Value, Missing.Value);
                    worksheet2.get_Range("a13:K13", Missing.Value).Copy(Missing.Value);
                    worksheet2.get_Range("A13", Missing.Value).Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
                    worksheet2.get_Range("A13", Missing.Value).PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, Missing.Value, Missing.Value);
                }
            }
            worksheet.PageSetup.PrintTitleRows = "$1:$12";
            worksheet.PageSetup.CenterVertically = false;
            worksheet.PageSetup.TopMargin = 5.0;
            worksheet.PageSetup.BottomMargin = 5.0;
            worksheet.PageSetup.CenterVertically = false;
            worksheet2.PageSetup.PrintTitleRows = "$1:$7";
            worksheet2.PageSetup.CenterVertically = false;
            worksheet2.PageSetup.TopMargin = 5.0;
            worksheet2.PageSetup.BottomMargin = 5.0;
            worksheet2.PageSetup.CenterVertically = false;
            int num = 1;
            KORISNIKDataAdapter adapter2 = new KORISNIKDataAdapter();
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            adapter2.Fill(set2);
            try
            {
                enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    decimal num3 = 0;
                    decimal num4 = 0;
                    DataRow current = (DataRow) enumerator.Current;
                    if ((((((decimal.Compare(Conversions.ToDecimal(current["nocni"]), decimal.Zero) > 0) | (decimal.Compare(Conversions.ToDecimal(current["prekovremeni"]), decimal.Zero) > 0)) | (decimal.Compare(Conversions.ToDecimal(current["subotom"]), decimal.Zero) > 0)) | (decimal.Compare(Conversions.ToDecimal(current["nedjeljom"]), decimal.Zero) > 0)) | (decimal.Compare(Conversions.ToDecimal(current["blagdan"]), decimal.Zero) > 0)) | (decimal.Compare(Conversions.ToDecimal(current["dvokratni"]), decimal.Zero) > 0))
                    {
                        NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 2], null, "Value", new object[] { Conversions.ToString(current["imeprezime"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 3], null, "Value", new object[] { DB.N2T(RuntimeHelpers.GetObjectValue(current["nazivradnomjesto"]), "") }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 4], null, "Value", new object[] { Conversions.ToDecimal(current["dodatnikoeficijent"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 5], null, "Value", new object[] { DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2) }, null, null, false, true);
                        if (decimal.Compare(Conversions.ToDecimal(current["nocni"]), decimal.Zero) > 0)
                        {
                            num4 = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2);
                            NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 6], null, "Value", new object[] { Conversions.ToDecimal(current["nocni"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 7], null, "Value", new object[] { Conversions.ToDecimal(current["nocniuvecani"]) }, null, null, false, true);
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["nocniuvecani"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["prekovremeni"]), decimal.Zero) > 0)
                        {
                            num4 = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2);
                            NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 8], null, "Value", new object[] { Conversions.ToDecimal(current["prekovremeni"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 9], null, "Value", new object[] { Conversions.ToDecimal(current["prekovremeniuvecani"]) }, null, null, false, true);
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["prekovremeniuvecani"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["subotom"]), decimal.Zero) > 0)
                        {
                            num4 = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2);
                            NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 10], null, "Value", new object[] { Conversions.ToDecimal(current["subotom"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet.Cells[12 + num, 11], null, "Value", new object[] { Conversions.ToDecimal(current["subotomuvecani"]) }, null, null, false, true);
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["subotomuvecani"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["nedjeljom"]), decimal.Zero) > 0)
                        {
                            num4 = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2);
                            NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 3], null, "Value", new object[] { Conversions.ToDecimal(current["nedjeljom"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 4], null, "Value", new object[] { Conversions.ToDecimal(current["nedjeljomuvecani"]) }, null, null, false, true);
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["nedjeljomuvecani"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["blagdan"]), decimal.Zero) > 0)
                        {
                            num4 = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2);
                            NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 5], null, "Value", new object[] { Conversions.ToDecimal(current["blagdan"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 6], null, "Value", new object[] { Conversions.ToDecimal(current["blagdanuvecani"]) }, null, null, false, true);
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["blagdanuvecani"]));
                        }
                        if (decimal.Compare(Conversions.ToDecimal(current["dvokratni"]), decimal.Zero) > 0)
                        {
                            num4 = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2);
                            NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 7], null, "Value", new object[] { Conversions.ToDecimal(current["dvokratni"]) }, null, null, false, true);
                            NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 8], null, "Value", new object[] { Conversions.ToDecimal(current["dvokratniuvecani"]) }, null, null, false, true);
                            num3 = decimal.Add(num3, Conversions.ToDecimal(current["dvokratniuvecani"]));
                        }
                        NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 2], null, "Value", new object[] { Conversions.ToString(current["imeprezime"]) }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 9], null, "Value", new object[] { num3 }, null, null, false, true);
                        NewLateBinding.LateSetComplex(worksheet2.Cells[6 + num, 10], null, "Value", new object[] { DB.RoundUpDecimale(decimal.Multiply(num3, DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(current["dodatnikoeficijent"], this.OSNOVICA), this.SATIGLOBALNO), 2)), 2) }, null, null, false, true);
                        num++;
                        num5 = decimal.Add(num5, DB.RoundUpDecimale(decimal.Multiply(num3, num4), 2));
                    }
                    num3 = new decimal();
                    num4 = new decimal();
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            if (num <= 10)
            {
                num = 10;
            }
            NewLateBinding.LateSetComplex(worksheet2.Cells[9 + num, 10], null, "Value", new object[] { num5 }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet2.Cells[10 + num, 10], null, "Value", new object[] { DB.RoundUpDecimale((Convert.ToDouble(num5) * 17.2) / 100.0, 2) }, null, null, false, true);
            NewLateBinding.LateSetComplex(worksheet2.Cells[11 + num, 10], null, "Value", new object[] { decimal.Add(DB.RoundUpDecimale((Convert.ToDouble(num5) * 17.2) / 100.0, 2), num5) }, null, null, false, true);
            SaveFileDialog dialog = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                FileName = "Uvecanje_" + Conversions.ToString(this.ZAGODINU) + "_" + Conversions.ToString(this.ZAMJESEC),
                RestoreDirectory = true
            };
            dialog.ShowDialog();
            try
            {
                workbook.SaveAs(dialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Thread.CurrentThread.CurrentCulture = currentCulture;
                application.Quit();
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Thread.CurrentThread.CurrentCulture = currentCulture;
                //application.Quit();
            }
        }

        [LocalCommandHandler("Uvecanje")]
        public void UvecanjeHandler(object sender, EventArgs e)
        {
            if (this.PrplaceDataSet1.PRPLACE.Rows.Count != 0)
            {
                this.Uvecanje_Tablica();
            }
        }

        internal AutoHideControl _PripremaPlaceCustomAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaTop = value;
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

        internal DockableWindow DockableWindow3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow3 = value;
            }
        }

        internal ELEMENTDataSet ElementDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ElementDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ElementDataSet1 = value;
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

        private CurrencyManager m_cm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._m_cm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._m_cm = value;
            }
        }

        internal PRPLACEDataSet PrplaceDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._PrplaceDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._PrplaceDataSet1 = value;
            }
        }

        internal RADNIKDataSet RadnikDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._RadnikDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._RadnikDataSet1 = value;
            }
        }

        internal RadnikPripremaDataSet RadnikPripremaDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._RadnikPripremaDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._RadnikPripremaDataSet1 = value;
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

        internal UltraDropDown UltraDropDown1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDropDown1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                DropDownEventHandler handler = new DropDownEventHandler(this.UltraDropDown1_AfterCloseUp);
                if (this._UltraDropDown1 != null)
                {
                    this._UltraDropDown1.AfterCloseUp -= handler;
                }
                this._UltraDropDown1 = value;
                if (this._UltraDropDown1 != null)
                {
                    this._UltraDropDown1.AfterCloseUp += handler;
                }
            }
        }

        internal UltraDropDown UltraDropDown2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDropDown2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraDropDown2 = value;
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
                Infragistics.Win.UltraWinGrid.InitializeRowEventHandler handler = new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.UltraGrid1_InitializeRow);
                InitializeLayoutEventHandler handler2 = new InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
                BeforeRowInsertEventHandler handler3 = new BeforeRowInsertEventHandler(this.UltraGrid1_BeforeRowInsert);
                RowEventHandler handler4 = new RowEventHandler(this.UltraGrid1_AfterRowUpdate);
                EventHandler handler5 = new EventHandler(this.UltraGrid1_AfterRowsDeleted);
                RowEventHandler handler6 = new RowEventHandler(this.UltraGrid1_AfterRowInsert);
                EventHandler handler7 = new EventHandler(this.UltraGrid1_AfterRowActivate);
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.InitializeRow -= handler;
                    this._UltraGrid1.InitializeLayout -= handler2;
                    this._UltraGrid1.BeforeRowInsert -= handler3;
                    this._UltraGrid1.AfterRowUpdate -= handler4;
                    this._UltraGrid1.AfterRowsDeleted -= handler5;
                    this._UltraGrid1.AfterRowInsert -= handler6;
                    this._UltraGrid1.AfterRowActivate -= handler7;
                }
                this._UltraGrid1 = value;
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.InitializeRow += handler;
                    this._UltraGrid1.InitializeLayout += handler2;
                    this._UltraGrid1.BeforeRowInsert += handler3;
                    this._UltraGrid1.AfterRowUpdate += handler4;
                    this._UltraGrid1.AfterRowsDeleted += handler5;
                    this._UltraGrid1.AfterRowInsert += handler6;
                    this._UltraGrid1.AfterRowActivate += handler7;
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
                Infragistics.Win.UltraWinGrid.InitializeRowEventHandler handler = new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.UltraGrid2_InitializeRow);
                InitializeLayoutEventHandler handler2 = new InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
                BeforeRowInsertEventHandler handler3 = new BeforeRowInsertEventHandler(this.UltraGrid2_BeforeRowInsert);
                CancelableCellEventHandler handler4 = new CancelableCellEventHandler(this.UltraGrid2_BeforeCellActivate);
                RowEventHandler handler5 = new RowEventHandler(this.UltraGrid2_AfterRowUpdate);
                EventHandler handler6 = new EventHandler(this.UltraGrid2_AfterRowsDeleted);
                RowEventHandler handler7 = new RowEventHandler(this.UltraGrid2_AfterRowInsert);
                EventHandler handler8 = new EventHandler(this.UltraGrid2_AfterEnterEditMode);
                CellEventHandler handler9 = new CellEventHandler(this.UltraGrid2_AfterCellUpdate);
                EventHandler handler10 = new EventHandler(this.UltraGrid2_AfterCellActivate);
                InitializeRowsCollectionEventHandler handler11 = new InitializeRowsCollectionEventHandler(this.UltraGrid2_InitializeRowsCollection);
                if (this._UltraGrid2 != null)
                {
                    this._UltraGrid2.InitializeRow -= handler;
                    this._UltraGrid2.InitializeLayout -= handler2;
                    this._UltraGrid2.BeforeRowInsert -= handler3;
                    this._UltraGrid2.BeforeCellActivate -= handler4;
                    this._UltraGrid2.AfterRowUpdate -= handler5;
                    this._UltraGrid2.AfterRowsDeleted -= handler6;
                    this._UltraGrid2.AfterRowInsert -= handler7;
                    this._UltraGrid2.AfterEnterEditMode -= handler8;
                    this._UltraGrid2.AfterCellUpdate -= handler9;
                    this._UltraGrid2.AfterCellActivate -= handler10;
                    this._UltraGrid2.InitializeRowsCollection -= handler11;
                }
                this._UltraGrid2 = value;
                if (this._UltraGrid2 != null)
                {
                    this._UltraGrid2.InitializeRow += handler;
                    this._UltraGrid2.InitializeLayout += handler2;
                    this._UltraGrid2.BeforeRowInsert += handler3;
                    this._UltraGrid2.BeforeCellActivate += handler4;
                    this._UltraGrid2.AfterRowUpdate += handler5;
                    this._UltraGrid2.AfterRowsDeleted += handler6;
                    this._UltraGrid2.AfterRowInsert += handler7;
                    this._UltraGrid2.AfterEnterEditMode += handler8;
                    this._UltraGrid2.AfterCellUpdate += handler9;
                    this._UltraGrid2.AfterCellActivate += handler10;
                    this._UltraGrid2.InitializeRowsCollection += handler11;
                }
            }
        }

        private UltraGridExcelExporter UltraGridExcelExporter1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGridExcelExporter1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGridExcelExporter1 = value;
            }
        }

        private UltraGroupBox UltraGroupBox1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGroupBox1 = value;
            }
        }

        private UltraGroupBox UltraGroupBox2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGroupBox2 = value;
            }
        }

        private UltraGroupBox UltraGroupBox3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGroupBox3 = value;
            }
        }

        internal UltraTextEditor UltraTextEditor1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraTextEditor1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraTextEditor1_ValueChanged);
                EditorButtonEventHandler handler2 = new EditorButtonEventHandler(this.UltraTextEditor1_EditorButtonClick);
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.ValueChanged -= handler;
                    this._UltraTextEditor1.EditorButtonClick -= handler2;
                }
                this._UltraTextEditor1 = value;
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.ValueChanged += handler;
                    this._UltraTextEditor1.EditorButtonClick += handler2;
                }
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

        internal WindowDockingArea WindowDockingArea3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea3 = value;
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

