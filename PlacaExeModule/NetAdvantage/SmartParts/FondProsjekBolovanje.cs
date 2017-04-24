using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using Deklarit.Practices.CompositeUI;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Microsoft.Office.Interop.Word;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Placa;


namespace NetAdvantage.SmartParts
{
    [SmartPart]
    public class FondProsjekBolovanje : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_ProsjekgodisnjiAutoHideControl")]
        private AutoHideControl __ProsjekgodisnjiAutoHideControl;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaRight")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaRight;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaTop")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaTop;
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("m_cm")]
        private CurrencyManager _m_cm;
        [AccessedThroughProperty("S_OD_BOLOVANJE_FONDDataSet1")]
        private S_OD_BOLOVANJE_FONDDataSet _S_OD_BOLOVANJE_FONDDataSet1;
        [AccessedThroughProperty("UltraCombo1")]
        private UltraCombo _UltraCombo1;
        [AccessedThroughProperty("UltraCombo2")]
        private UltraCombo _UltraCombo2;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("UltraGridExcelExporter1")]
        private UltraGridExcelExporter _UltraGridExcelExporter1;
        [AccessedThroughProperty("UltraGroupBox1")]
        private UltraGroupBox _UltraGroupBox1;
        [AccessedThroughProperty("UltraLabel1")]
        private UltraLabel _UltraLabel1;
        [AccessedThroughProperty("UltraLabel2")]
        private UltraLabel _UltraLabel2;
        [AccessedThroughProperty("UltraTextEditor1")]
        private UltraTextEditor _UltraTextEditor1;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public FondProsjekBolovanje()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Prosjek plaće za bolovanje HZZO", "BolovanjeFond");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public string Dodaj_Praznine_Na_Kraj(string str, int potrebna)
        {
            string str2 = string.Empty;
            if (Strings.Len(str) < potrebna)
            {
                str2 = str + Strings.Space(potrebna - Strings.Len(str));
            }
            if (Strings.Len(str) == potrebna)
            {
                str2 = str;
            }
            if (Strings.Len(str) > potrebna)
            {
                str2 = Strings.Left(str, potrebna);
            }
            return str2;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            EditorButton button = new EditorButton("zaposlenik");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("S_OD_BOLOVANJE_FOND", -1);
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column7 = new UltraGridColumn("PREZIME");
            UltraGridColumn column8 = new UltraGridColumn("IME");
            UltraGridColumn column9 = new UltraGridColumn("JMBG");
            UltraGridColumn column10 = new UltraGridColumn("MJESECOBRACUNA");
            UltraGridColumn column11 = new UltraGridColumn("GODINAOBRACUNA");
            UltraGridColumn column12 = new UltraGridColumn("KOLONA4");
            UltraGridColumn column13 = new UltraGridColumn("KOLONA5");
            UltraGridColumn column14 = new UltraGridColumn("KOLONA6");
            UltraGridColumn column2 = new UltraGridColumn("KOLONA8");
            UltraGridColumn column3 = new UltraGridColumn("SATIUKUPNO");
            UltraGridColumn column4 = new UltraGridColumn("ukupnobruto");
            UltraGridColumn column5 = new UltraGridColumn("netoplaca");
            UltraGridColumn column6 = new UltraGridColumn("FONDMJESECA");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Guid internalId = new Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a");
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("92f6b63e-efa0-435d-af25-7decacd7f421");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.UltraTextEditor1 = new UltraTextEditor();
            this.UltraLabel2 = new UltraLabel();
            this.UltraLabel1 = new UltraLabel();
            this.UltraCombo2 = new UltraCombo();
            this.UltraCombo1 = new UltraCombo();
            this.UltraGrid1 = new UltraGrid();
            this.S_OD_BOLOVANJE_FONDDataSet1 = new S_OD_BOLOVANJE_FONDDataSet();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._ProsjekgodisnjiAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.UltraGridExcelExporter1 = new UltraGridExcelExporter(this.components);
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            ((ISupportInitialize) this.UltraCombo2).BeginInit();
            ((ISupportInitialize) this.UltraCombo1).BeginInit();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.S_OD_BOLOVANJE_FONDDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.UltraTextEditor1);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo2);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo1);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Location = point;
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            Size size = new System.Drawing.Size(0x40d, 0x80);
            this.UltraGroupBox1.Size = size;
            this.UltraGroupBox1.TabIndex = 1;
            this.UltraGroupBox1.Text = "Odabir razdoblja (godina i mjesec na koji se plaća odnosi)  i zaposlenika ";
            button.Key = "zaposlenik";
            button.Text = "Zaposlenik";
            this.UltraTextEditor1.ButtonsRight.Add(button);
            point = new System.Drawing.Point(0x15, 0x59);
            this.UltraTextEditor1.Location = point;
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            size = new System.Drawing.Size(0x191, 0x15);
            this.UltraTextEditor1.Size = size;
            this.UltraTextEditor1.TabIndex = 11;
            this.UltraTextEditor1.Text = "Odaberite zaposlenika";
            point = new System.Drawing.Point(0x15, 60);
            this.UltraLabel2.Location = point;
            this.UltraLabel2.Name = "UltraLabel2";
            size = new System.Drawing.Size(0xb8, 0x17);
            this.UltraLabel2.Size = size;
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Text = "Do godine i mjeseca obračuna";
            point = new System.Drawing.Point(0x15, 0x20);
            this.UltraLabel1.Location = point;
            this.UltraLabel1.Name = "UltraLabel1";
            size = new System.Drawing.Size(0xb8, 0x17);
            this.UltraLabel1.Size = size;
            this.UltraLabel1.TabIndex = 9;
            this.UltraLabel1.Text = "Od godine i mjeseca obračuna";
            this.UltraCombo2.CharacterCasing = CharacterCasing.Normal;
            this.UltraCombo2.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraCombo2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraCombo2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            point = new System.Drawing.Point(0xde, 0x38);
            this.UltraCombo2.Location = point;
            this.UltraCombo2.Name = "UltraCombo2";
            size = new System.Drawing.Size(200, 0x16);
            this.UltraCombo2.Size = size;
            this.UltraCombo2.TabIndex = 7;
            this.UltraCombo2.Text = "UltraCombo2";
            this.UltraCombo1.CharacterCasing = CharacterCasing.Normal;
            this.UltraCombo1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraCombo1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraCombo1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraCombo1.LimitToList = true;
            point = new System.Drawing.Point(0xde, 0x1c);
            this.UltraCombo1.Location = point;
            this.UltraCombo1.Name = "UltraCombo1";
            size = new System.Drawing.Size(200, 0x16);
            this.UltraCombo1.Size = size;
            this.UltraCombo1.TabIndex = 6;
            this.UltraCombo1.Text = "UltraCombo1";
            this.UltraGrid1.DataMember = "S_OD_BOLOVANJE_FOND";
            this.UltraGrid1.DataSource = this.S_OD_BOLOVANJE_FONDDataSet1;
            appearance.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 0;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.VisiblePosition = 1;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.VisiblePosition = 2;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 3;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.VisiblePosition = 4;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 5;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.VisiblePosition = 6;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 7;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 8;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 9;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 10;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 11;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 12;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.Header.VisiblePosition = 13;
            band.Columns.AddRange(new object[] { column, column7, column8, column9, column10, column11, column12, column13, column14, column2, column3, column4, column5, column6 });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance2.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BorderColor = Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = Color.LightSteelBlue;
            appearance5.BorderColor = Color.Black;
            appearance5.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0x97);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            size = new System.Drawing.Size(0x40d, 0x19e);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 0;
            this.S_OD_BOLOVANJE_FONDDataSet1.DataSetName = "S_OD_BOLOVANJE_FONDDataSet";
            pane.Control = this.UltraGroupBox1;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(-15, -15, 200, 110);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "...";
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x40d, 0x92);
            pane2.Size = size;
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Name = "_ProsjekgodisnjiUnpinnedTabAreaLeft";
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x235);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.TabIndex = 2;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x40d, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Name = "_ProsjekgodisnjiUnpinnedTabAreaRight";
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x235);
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.TabIndex = 3;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Name = "_ProsjekgodisnjiUnpinnedTabAreaTop";
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.TabIndex = 4;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x235);
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Name = "_ProsjekgodisnjiUnpinnedTabAreaBottom";
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.TabIndex = 5;
            this._ProsjekgodisnjiAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiAutoHideControl.Location = point;
            this._ProsjekgodisnjiAutoHideControl.Name = "_ProsjekgodisnjiAutoHideControl";
            this._ProsjekgodisnjiAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0);
            this._ProsjekgodisnjiAutoHideControl.Size = size;
            this._ProsjekgodisnjiAutoHideControl.TabIndex = 6;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Location = point;
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0x97);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 7;
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Location = point;
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0x92);
            this.DockableWindow1.Size = size;
            this.DockableWindow1.TabIndex = 8;
            this.Controls.Add(this._ProsjekgodisnjiAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaTop);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaBottom);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaLeft);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaRight);
            this.Name = "FondProsjekBolovanje";
            size = new System.Drawing.Size(0x40d, 0x235);
            this.Size = size;
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            ((ISupportInitialize) this.UltraCombo2).EndInit();
            ((ISupportInitialize) this.UltraCombo1).EndInit();
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.S_OD_BOLOVANJE_FONDDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public void Izradi_er1()
        {
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word.Document document = new Microsoft.Office.Interop.Word.DocumentClass();
            

            try
            {
                decimal num2 = 0;
                decimal num9 = 0;
                decimal num10 = 0;
                decimal num5 = 0;
                decimal num6 = 0;
                decimal num7 = 0;
                decimal num4 = 0;
                decimal num8 = 0;
                IEnumerator enumerator = null;
                application.Visible = false;

                object temp = System.Reflection.Missing.Value;

                object confirmConversions = true;
                object readOnly = true;

                object path = System.Windows.Forms.Application.StartupPath + @"\App_Data\Potvrda_o_placi.doc";

                document = application.Documents.Open(ref path, ref confirmConversions, ref readOnly, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp);

                document.ActiveWindow.View.ReadingLayout = false;

                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(dataSet);
                document.Fields[1].Result.Text = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                

                int startIndex = 0;
                do
                {
                    // Veličina ovog polja u bazi je 11 mjesta, ali se očito kod korisnika dešava da imaju po 10 mjesta
                    if (dataSet.KORISNIK.Rows[0]["KORISNIK1HZZO"].ToString().Length > startIndex)
                        document.Fields[2 + startIndex].Result.Text = dataSet.KORISNIK.Rows[0]["KORISNIK1HZZO"].ToString().Substring(startIndex, 1);

                    startIndex++;
                }
                while (startIndex <= 10);

                document.Fields[13].Result.Text = Conversions.ToString(this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["PREZIME"]);
                document.Fields[14].Result.Text = Conversions.ToString(this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["IME"]);

                startIndex = 0;
                do
                {
                    document.Fields[15 + startIndex].Result.Text = this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["jmbg"].ToString().Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 3);

                document.Fields[0x13].Result.Text = "1";
                try
                {
                    document.Fields[20].Result.Text = this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["jmbg"].ToString().Substring(4, 1);
                    document.Fields[0x15].Result.Text = this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["jmbg"].ToString().Substring(5, 1);
                    document.Fields[0x16].Result.Text = this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["jmbg"].ToString().Substring(6, 1);
                }
                catch (Exception) { }

                startIndex = 0;
                do
                {
                    document.Fields[0x17 + startIndex].Result.Text = this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["OIB"].ToString().Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 10);

                string str = DB.N2T(RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["BROJZDRAVSTVENOG"]), "");
                if (str.Trim() != "")
                {
                    startIndex = 0;
                    do
                    {
                        if (str.Length > startIndex)
                            document.Fields[0x22 + startIndex].Result.Text = str.Substring(startIndex, 1);

                        startIndex++;
                    }
                    while (startIndex <= 10);
                }

                startIndex = 0;
                do
                {
                    document.Fields[34 + startIndex].Result.Text = this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows[0]["jmbg"].ToString().Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 12);

                string str3 = Conversions.ToString(this.UltraCombo1.Value);
                string str2 = Conversions.ToString(this.UltraCombo2.Value);
                DateTime time = DateAndTime.DateSerial(Conversions.ToInteger(str3.Substring(0, 4)), Conversions.ToInteger(str3.Substring(5, 2)), Conversions.ToInteger("1"));
                DateTime time2 = DateAndTime.DateSerial(Conversions.ToInteger(str2.Substring(0, 4)), Conversions.ToInteger(str2.Substring(5, 2)), Conversions.ToInteger("1"));
                time = time.AddMonths(1);
                time2 = time2.AddMonths(2).AddDays(-1.0);
                str3 = time.ToString("ddMMyyyy", CultureInfo.InvariantCulture);
                str2 = time2.ToString("ddMMyyyy", CultureInfo.InvariantCulture);

                startIndex = 0;
                do
                {
                    document.Fields[47 + startIndex].Result.Text = str3.Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 7);

                startIndex = 0;
                do
                {
                    document.Fields[55 + startIndex].Result.Text = str2.Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 7);

                int num = 63;
                try
                {
                    enumerator = this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {

                        DataRow current = (DataRow)enumerator.Current;
                        document.Fields[num].Result.Text = Conversions.ToString(Operators.AddObject(Operators.AddObject(current["mjesecobracuna"], "/"), current["godinaobracuna"]));
                        document.Fields[num + 1].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["ukupnobruto"]));
                        document.Fields[num + 2].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["netoplaca"]));
                        document.Fields[num + 3].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["kolona4"]));
                        document.Fields[num + 4].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["kolona5"]));
                        document.Fields[num + 5].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["kolona6"]));
                        document.Fields[num + 6].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["satiukupno"]));
                        document.Fields[num + 7].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["kolona8"]));
                        document.Fields[num + 8].Result.Text = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["fondmjeseca"]));
                        num += 9;
                        num2 = Conversions.ToDecimal(Operators.AddObject(num2, current["ukupnobruto"]));
                        num9 = Conversions.ToDecimal(Operators.AddObject(num9, current["netoplaca"]));
                        num5 = Conversions.ToDecimal(Operators.AddObject(num5, current["kolona4"]));
                        num6 = Conversions.ToDecimal(Operators.AddObject(num6, current["kolona5"]));
                        num7 = Conversions.ToDecimal(Operators.AddObject(num7, current["kolona6"]));
                        num10 = Conversions.ToDecimal(Operators.AddObject(num10, current["satiukupno"]));
                        num8 = Conversions.ToDecimal(Operators.AddObject(num8, current["kolona8"]));
                        num4 = Conversions.ToDecimal(Operators.AddObject(num4, current["fondmjeseca"]));
                        if (((this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Rows.Count * 9) + 63) == num)
                        {
                            document.Fields[117].Result.Text = string.Format("{0:#,##0.00}", num2);
                            document.Fields[118].Result.Text = string.Format("{0:#,##0.00}", num9);
                            document.Fields[119].Result.Text = string.Format("{0:#,##0.00}", num5);
                            document.Fields[120].Result.Text = string.Format("{0:#,##0.00}", num6);
                            document.Fields[121].Result.Text = string.Format("{0:#,##0.00}", num7);
                            document.Fields[122].Result.Text = string.Format("{0:#,##0.00}", num10);
                            document.Fields[123].Result.Text = string.Format("{0:#,##0.00}", num8);
                            document.Fields[124].Result.Text = string.Format("{0:#,##0.00}", num4);
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
                if (decimal.Compare(num10, decimal.Zero) > 0)
                {
                    document.Fields[125].Result.Text = string.Format("{0:#,##0.00}", DB.RoundUpDecimale(decimal.Divide(num2, num10), 2));
                    document.Fields[126].Result.Text = string.Format("{0:#,##0.0000}", decimal.Divide(num9, num10), 2);
                }
                else
                {
                    document.Fields[125].Result.Text = string.Format("{0:#,##0.00}", 0);
                    document.Fields[126].Result.Text = string.Format("{0:#,##0.00}", 0);
                }
                document.Fields[127].Result.Text = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
                document.Fields[128].Result.Text = Conversions.ToString(DateAndTime.Year(DateAndTime.Today)).Substring(2, 2);
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                SaveFileDialog dialog2 = new SaveFileDialog
                {
                    InitialDirectory = @"C:\Desktop",
                    Filter = "Word datoteke (*.doc)|*.doc|All files (*.*)|*.*",
                    FileName = "Bolovanje_HZZO_Obrazac",
                    RestoreDirectory = true
                };
                dialog2.ShowDialog();

                SaveFileDialog dialog3 = dialog2;
                object fileName = dialog3.FileName;
                document.SaveAs(ref fileName, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp);
                dialog3.FileName = Conversions.ToString(fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Greška u generiranju izvještaja: 'Prosjek bolovanje/HZZO'!" + Environment.NewLine + "Molimo provjerite valjanost/postojanost podataka koji su potrebni za generiranje izvještaja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                new Mipsed7.Emailing.SendException(exception);
            }
            finally
            {
                
                //document.Close(false, Missing.Value, Missing.Value);
                ((_Document)document).Close(false, Missing.Value, Missing.Value);

                //application.Quit(false, Missing.Value, Missing.Value);
                ((_Application)application).Quit(false, Missing.Value, Missing.Value);

                // za svaki slučaj
                if (document != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(document);

                if (application != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(application);

                // isprazni varijable
                document = null;
                application = null;

                // force-amo GarbageCollector (za svaki slučaj)
                GC.Collect();

                this.Cursor = Cursors.Default;
            }
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
            this.Izradi_er1();
        }

        [CommandHandler("Ucitaj")]
        public void UcitajHandler(object sender, EventArgs e)
        {
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                RADNIKSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    this.UltraTextEditor1.Text = Conversions.ToString(Operators.AddObject(Operators.AddObject(row["prezime"], "/"), row["ime"]));
                    S_OD_BOLOVANJE_FONDDataAdapter adapter = new S_OD_BOLOVANJE_FONDDataAdapter();
                    this.S_OD_BOLOVANJE_FONDDataSet1.S_OD_BOLOVANJE_FOND.Clear();
                    adapter.Fill(this.S_OD_BOLOVANJE_FONDDataSet1, Conversions.ToString(this.UltraCombo1.Value), Conversions.ToString(this.UltraCombo2.Value), Conversions.ToInteger(row["idradnik"]));
                    if (this.UltraGrid1.Rows.Count > 0)
                    {
                        this.UltraGrid1.Rows[0].Selected = true;
                    }
                }
            }
        }

        private void UltraTextEditor1_ValueChanged(object sender, EventArgs e)
        {
        }

        internal AutoHideControl _ProsjekgodisnjiAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaTop = value;
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

        internal S_OD_BOLOVANJE_FONDDataSet S_OD_BOLOVANJE_FONDDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._S_OD_BOLOVANJE_FONDDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._S_OD_BOLOVANJE_FONDDataSet1 = value;
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

        private UltraCombo UltraCombo1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraCombo1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraCombo1 = value;
            }
        }

        private UltraCombo UltraCombo2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraCombo2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraCombo2 = value;
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
                InitializeLayoutEventHandler handler = new InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.InitializeLayout -= handler;
                }
                this._UltraGrid1 = value;
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.InitializeLayout += handler;
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

        private UltraLabel UltraLabel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel1 = value;
            }
        }

        private UltraLabel UltraLabel2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel2 = value;
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

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

