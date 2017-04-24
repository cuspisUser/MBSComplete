using CrystalDecisions.CrystalReports.Engine;
using DDModule;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DDModule.NetAdvantage.SmartParts
{

    [SmartPart]
    public class PotvrdaSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private S_DD_POTVRDADataAdapter d;
        private S_DD_POTVRDADataSet ds;
        private string GODINA;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public PotvrdaSmartPart()
        {
            base.Load += new EventHandler(this.IP1SmartPart_Load);
            this.d = new S_DD_POTVRDADataAdapter();
            this.ds = new S_DD_POTVRDADataSet();
            this.smartPartInfo1 = new SmartPartInfo("IP-1Obrazac", "IP-1Obrazac");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            ISmartPartInfo info = null;
            return info;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DockAreaPane pane3 = new DockAreaPane(DockedLocation.DockedTop, new Guid("3753a265-b1d1-4521-b5f7-4b433ec7309f"));
            DockableControlPane pane = new DockableControlPane(new Guid("caef9f6c-f0d7-4717-a120-843e2e06a9a2"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("3753a265-b1d1-4521-b5f7-4b433ec7309f"), -1);
            DockAreaPane pane4 = new DockAreaPane(DockedLocation.DockedTop, new Guid("8a00ada4-90a0-4d1c-b58f-34510a8304dd"));
            DockableControlPane pane2 = new DockableControlPane(new Guid("a98745c7-8a2b-45df-8d20-3343dc9554d1"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("8a00ada4-90a0-4d1c-b58f-34510a8304dd"), -1);
            UltraGridBand band = new UltraGridBand("S_DD_POTVRDA", -1);
            UltraGridColumn column = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("DDPREZIME");
            UltraGridColumn column6 = new UltraGridColumn("DDIME");
            UltraGridColumn column7 = new UltraGridColumn("BRUTO");
            UltraGridColumn column8 = new UltraGridColumn("IZDACI");
            UltraGridColumn column9 = new UltraGridColumn("DOPRINOSIIZ");
            UltraGridColumn column10 = new UltraGridColumn("POREZIPRIREZ");
            UltraGridColumn column11 = new UltraGridColumn("NETO");
            UltraGridColumn column12 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column2 = new UltraGridColumn("DDDATUMOBRACUNA");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVKATEGORIJA");
            UltraGridColumn column4 = new UltraGridColumn("POSTOTAKIZDATKA");
            this.Panel2 = new Panel();
            this.BindingSource1 = new BindingSource(this.components);
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._IP1SmartPartUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._IP1SmartPartUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._IP1SmartPartUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._IP1SmartPartUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._IP1SmartPartAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.UltraGrid1 = new UltraGrid();
            this.WindowDockingArea2 = new WindowDockingArea();
            this.DockableWindow2 = new DockableWindow();
            ((ISupportInitialize) this.BindingSource1).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            this.Panel2.Location = new System.Drawing.Point(0, 0x12);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(0x42e, 3);
            this.Panel2.TabIndex = 8;
            this.BindingSource1.DataSource = typeof(S_DD_POTVRDADataSet);
            this.BindingSource1.Position = 0;
            pane3.DockedBefore = new Guid("8a00ada4-90a0-4d1c-b58f-34510a8304dd");
            pane.OriginalControlBounds = new Rectangle(20, 12, 200, 100);
            pane.Size = new System.Drawing.Size(100, 100);
            pane.Text = "Panel1";
            pane3.Panes.AddRange(new DockablePaneBase[] { pane });
            pane3.Size = new System.Drawing.Size(0x42e, 0x7c);
            pane4.ChildPaneStyle = ChildPaneStyle.VerticalSplit;
            pane2.Control = this.Panel2;
            pane2.OriginalControlBounds = new Rectangle(0x85, 0xd1, 820, 270);
            pane2.Size = new System.Drawing.Size(100, 100);
            pane2.Text = "Panel2";
            pane4.Panes.AddRange(new DockablePaneBase[] { pane2 });
            pane4.Size = new System.Drawing.Size(0x42e, 0x15);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane3, pane4 });
            this.UltraDockManager1.HostControl = this;
            this._IP1SmartPartUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._IP1SmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._IP1SmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._IP1SmartPartUnpinnedTabAreaLeft.Name = "_IP1SmartPartUnpinnedTabAreaLeft";
            this._IP1SmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x220);
            this._IP1SmartPartUnpinnedTabAreaLeft.TabIndex = 0;
            this._IP1SmartPartUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._IP1SmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._IP1SmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x42e, 0);
            this._IP1SmartPartUnpinnedTabAreaRight.Name = "_IP1SmartPartUnpinnedTabAreaRight";
            this._IP1SmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x220);
            this._IP1SmartPartUnpinnedTabAreaRight.TabIndex = 1;
            this._IP1SmartPartUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._IP1SmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._IP1SmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._IP1SmartPartUnpinnedTabAreaTop.Name = "_IP1SmartPartUnpinnedTabAreaTop";
            this._IP1SmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x42e, 0);
            this._IP1SmartPartUnpinnedTabAreaTop.TabIndex = 2;
            this._IP1SmartPartUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._IP1SmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._IP1SmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x220);
            this._IP1SmartPartUnpinnedTabAreaBottom.Name = "_IP1SmartPartUnpinnedTabAreaBottom";
            this._IP1SmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x42e, 0);
            this._IP1SmartPartUnpinnedTabAreaBottom.TabIndex = 3;
            this._IP1SmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._IP1SmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._IP1SmartPartAutoHideControl.Name = "_IP1SmartPartAutoHideControl";
            this._IP1SmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._IP1SmartPartAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._IP1SmartPartAutoHideControl.TabIndex = 4;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(0x42e, 0x81);
            this.WindowDockingArea1.TabIndex = 7;
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(0x42e, 0x7c);
            this.DockableWindow1.TabIndex = 10;
            this.UltraGrid1.DataSource = this.BindingSource1;
            column.Header.VisiblePosition = 0;
            column5.Header.VisiblePosition = 1;
            column6.Header.VisiblePosition = 2;
            column7.Header.VisiblePosition = 3;
            column8.Header.VisiblePosition = 4;
            column9.Header.VisiblePosition = 5;
            column10.Header.VisiblePosition = 6;
            column11.Header.VisiblePosition = 7;
            column12.Header.VisiblePosition = 8;
            column2.Header.VisiblePosition = 9;
            column3.Header.VisiblePosition = 10;
            column4.Header.VisiblePosition = 11;
            band.Columns.AddRange(new object[] { column, column5, column6, column7, column8, column9, column10, column11, column12, column2, column3, column4 });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Location = new System.Drawing.Point(0, 0x9b);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(0x42e, 0x185);
            this.UltraGrid1.TabIndex = 9;
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0x81);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(0x42e, 0x1a);
            this.WindowDockingArea2.TabIndex = 9;
            this.DockableWindow2.Controls.Add(this.Panel2);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(0x42e, 0x15);
            this.DockableWindow2.TabIndex = 11;
            this.Controls.Add(this._IP1SmartPartAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaRight);
            this.Name = "PotvrdaSmartPart";
            this.Size = new System.Drawing.Size(0x42e, 0x220);
            ((ISupportInitialize) this.BindingSource1).EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void IP1SmartPart_Load(object sender, EventArgs e)
        {
        }

        public void iSPISI()
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            document.Load(System.Windows.Forms.Application.StartupPath + @"\ddIzvjestaji\rptPotvrdaOIsplatidohotka.rpt");
            document.SetDataSource(this.ds);
            document.SetParameterValue("GODINA", this.GODINA);
            document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("adresa", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
            document.SetParameterValue("mb", dataSet.KORISNIK.Rows[0]["KORISNIKOIB"].ToString());
            document.SetParameterValue("mjesto", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Activate();
            item.Show(item.Workspaces["main"]);
        }

        [LocalCommandHandler("Ispisi")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.iSPISI();
        }

        public void Otvori()
        {
            ReportDocument document = new ReportDocument();
            frmDDPregleDGodina godina = new frmDDPregleDGodina();
            godina.ShowDialog();
            if (godina.DialogResult != DialogResult.Cancel)
            {
                this.ds.Clear();
                this.GODINA = Conversions.ToString(godina.OdabraniGodinaIsplate);
                this.d.Fill(this.ds, Conversions.ToString(godina.OdabraniGodinaIsplate));
                this.BindingSource1.DataSource = this.ds;
                this.BindingSource1.DataMember = "S_DD_POTVRDA";
            }
        }

        [LocalCommandHandler("OtvoriGodinu")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            this.Otvori();
        }

        private AutoHideControl _IP1SmartPartAutoHideControl;

        private UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaTop;

        private BindingSource BindingSource1;

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

        private DockableWindow DockableWindow2;

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

        private Panel Panel2;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

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

