using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SmartPart]
public class TablicniRazmjestajSredstava : UserControl
{
    private IContainer components;
    private LOKACIJEDataAdapter dalok;
    private OSDataAdapter daosnovna;
    private S_OS_STANJE_LOKACIJADataAdapter daStanje;
    private S_OS_STANJE_LOKACIJADataSet ds;
    private LOKACIJEDataSet dslokacije;
    private OSDataSet dsosnovna;
    private bool m_bDisablePosCHange;
    private object m_cmDisable;

    public TablicniRazmjestajSredstava()
    {
        base.Load += new EventHandler(this.IznosiNabave_Load);
        this.ds = new S_OS_STANJE_LOKACIJADataSet();
        this.dalok = new LOKACIJEDataAdapter();
        this.dslokacije = new LOKACIJEDataSet();
        this.daStanje = new S_OS_STANJE_LOKACIJADataAdapter();
        this.m_cmDisable = true;
        this.dsosnovna = new OSDataSet();
        this.daosnovna = new OSDataAdapter();
        this.InitializeComponent();

    }

    private void __CurrencyManager_PositionChanged(object sender, EventArgs e)
    {
        if (!this.m_bDisablePosCHange && (this.__CurrencyManager.Count > 0))
        {
            object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.__CurrencyManager.Current, new object[] { "INVBROJ" }, null));
            this.ds.S_OS_STANJE_LOKACIJA.Clear();
            this.daStanje.Fill(this.ds, Conversions.ToLong(objectValue));
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.Spremi();
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    private void InitializeComponent()
    {
        this.components = new Container();
        DockAreaPane pane5 = new DockAreaPane(DockedLocation.DockedTop, new Guid("9fcab504-0a13-42fd-9f58-78a46d130c05"));
        DockableControlPane pane = new DockableControlPane(new Guid("11c9b829-bcf6-4c91-b17e-caaed5331d68"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("9fcab504-0a13-42fd-9f58-78a46d130c05"), -1);
        DockAreaPane pane6 = new DockAreaPane(DockedLocation.DockedLeft, new Guid("578c4d27-d187-4281-b90b-e82f7988eed6"));
        DockableControlPane pane2 = new DockableControlPane(new Guid("4aad70a1-238f-4a30-9368-6a54b171578c"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("578c4d27-d187-4281-b90b-e82f7988eed6"), -1);
        DockAreaPane pane7 = new DockAreaPane(DockedLocation.DockedLeft, new Guid("c089ddbf-7c00-4a50-9d19-413910c2f81f"));
        DockableControlPane pane3 = new DockableControlPane(new Guid("34b7c2cc-8313-46a9-9f6b-f4b1b936b9b7"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("c089ddbf-7c00-4a50-9d19-413910c2f81f"), -1);
        DockAreaPane pane8 = new DockAreaPane(DockedLocation.DockedLeft, new Guid("2a475fef-9517-44d0-8aeb-3bd980f41054"));
        DockableControlPane pane4 = new DockableControlPane(new Guid("300898e4-f79d-4e84-93d2-bd00e4edda2a"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("2a475fef-9517-44d0-8aeb-3bd980f41054"), -1);
        this.Panel4 = new Panel();
        this.UltraGrid3 = new UltraGrid();
        this.Panel2 = new Panel();
        this.UltraGrid1 = new UltraGrid();
        this.Panel1 = new Panel();
        this.UltraButton2 = new UltraButton();
        this.UltraButton1 = new UltraButton();
        this.Panel3 = new Panel();
        this.UltraGrid2 = new UltraGrid();
        this.DatasetKratkaRekap1 = new datasetKratkaRekap();
        this.DsIPObrazac1 = new dsIPObrazac();
        this.UltraDockManager1 = new UltraDockManager(this.components);
        this._RazmjestajSredstavaUnpinnedTabAreaLeft = new UnpinnedTabArea();
        this._RazmjestajSredstavaUnpinnedTabAreaRight = new UnpinnedTabArea();
        this._RazmjestajSredstavaUnpinnedTabAreaTop = new UnpinnedTabArea();
        this._RazmjestajSredstavaUnpinnedTabAreaBottom = new UnpinnedTabArea();
        this._RazmjestajSredstavaAutoHideControl = new AutoHideControl();
        this.WindowDockingArea1 = new WindowDockingArea();
        this.DockableWindow1 = new DockableWindow();
        this.WindowDockingArea2 = new WindowDockingArea();
        this.DockableWindow2 = new DockableWindow();
        this.WindowDockingArea3 = new WindowDockingArea();
        this.DockableWindow3 = new DockableWindow();
        this.WindowDockingArea4 = new WindowDockingArea();
        this.DockableWindow4 = new DockableWindow();
        this.Panel4.SuspendLayout();
        ((ISupportInitialize) this.UltraGrid3).BeginInit();
        this.Panel2.SuspendLayout();
        ((ISupportInitialize) this.UltraGrid1).BeginInit();
        this.Panel1.SuspendLayout();
        this.Panel3.SuspendLayout();
        ((ISupportInitialize) this.UltraGrid2).BeginInit();
        this.DatasetKratkaRekap1.BeginInit();
        this.DsIPObrazac1.BeginInit();
        ((ISupportInitialize) this.UltraDockManager1).BeginInit();
        this.WindowDockingArea1.SuspendLayout();
        this.DockableWindow1.SuspendLayout();
        this.WindowDockingArea2.SuspendLayout();
        this.DockableWindow2.SuspendLayout();
        this.WindowDockingArea3.SuspendLayout();
        this.DockableWindow3.SuspendLayout();
        this.WindowDockingArea4.SuspendLayout();
        this.DockableWindow4.SuspendLayout();
        this.SuspendLayout();
        this.Panel4.Controls.Add(this.UltraGrid3);
        this.Panel4.Location = new System.Drawing.Point(0, 20);
        this.Panel4.Name = "Panel4";
        this.Panel4.Size = new System.Drawing.Size(0x39b, 0x148);
        this.Panel4.TabIndex = 15;
        this.UltraGrid3.Dock = DockStyle.Fill;
        this.UltraGrid3.Location = new System.Drawing.Point(0, 0);
        this.UltraGrid3.Name = "UltraGrid3";
        this.UltraGrid3.Size = new System.Drawing.Size(0x39b, 0x148);
        this.UltraGrid3.TabIndex = 2;
        this.Panel2.Controls.Add(this.UltraGrid1);
        this.Panel2.Location = new System.Drawing.Point(0, 20);
        this.Panel2.Name = "Panel2";
        this.Panel2.Size = new System.Drawing.Size(0x1b5, 220);
        this.Panel2.TabIndex = 14;
        this.UltraGrid1.Dock = DockStyle.Fill;
        this.UltraGrid1.Location = new System.Drawing.Point(0, 0);
        this.UltraGrid1.Name = "UltraGrid1";
        this.UltraGrid1.Size = new System.Drawing.Size(0x1b5, 220);
        this.UltraGrid1.TabIndex = 0;
        this.Panel1.Controls.Add(this.UltraButton2);
        this.Panel1.Controls.Add(this.UltraButton1);
        this.Panel1.Location = new System.Drawing.Point(0, 20);
        this.Panel1.Name = "Panel1";
        this.Panel1.Size = new System.Drawing.Size(0x69, 220);
        this.Panel1.TabIndex = 4;
        this.UltraButton2.Location = new System.Drawing.Point(10, 0x2c);
        this.UltraButton2.Name = "UltraButton2";
        this.UltraButton2.Size = new System.Drawing.Size(0x4b, 0x17);
        this.UltraButton2.TabIndex = 3;
        this.UltraButton2.Text = "Prebaci dio";
        this.UltraButton1.Location = new System.Drawing.Point(10, 15);
        this.UltraButton1.Name = "UltraButton1";
        this.UltraButton1.Size = new System.Drawing.Size(0x4b, 0x17);
        this.UltraButton1.TabIndex = 2;
        this.UltraButton1.Text = "Prebaci sve";
        this.Panel3.AutoSize = true;
        this.Panel3.Controls.Add(this.UltraGrid2);
        this.Panel3.Location = new System.Drawing.Point(0, 20);
        this.Panel3.Name = "Panel3";
        this.Panel3.Size = new System.Drawing.Size(0x16c, 220);
        this.Panel3.TabIndex = 6;
        this.UltraGrid2.Dock = DockStyle.Fill;
        this.UltraGrid2.Location = new System.Drawing.Point(0, 0);
        this.UltraGrid2.Name = "UltraGrid2";
        this.UltraGrid2.Size = new System.Drawing.Size(0x16c, 220);
        this.UltraGrid2.TabIndex = 1;
        this.DatasetKratkaRekap1.DataSetName = "datasetKratkaRekap";
        this.DatasetKratkaRekap1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
        this.DsIPObrazac1.DataSetName = "dsIPObrazac";
        this.DsIPObrazac1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
        pane5.DockedBefore = new Guid("578c4d27-d187-4281-b90b-e82f7988eed6");
        pane.Control = this.Panel4;
        pane.OriginalControlBounds = new Rectangle(0xeb, 0x23, 0x196, 0x4e);
        pane.Size = new System.Drawing.Size(100, 100);
        pane.Text = "POPIS OSNOVNIH SREDSTAVA";
        pane5.Panes.AddRange(new DockablePaneBase[] { pane });
        pane5.Size = new System.Drawing.Size(0x39b, 0x15c);
        pane6.DockedBefore = new Guid("c089ddbf-7c00-4a50-9d19-413910c2f81f");
        pane2.Control = this.Panel2;
        pane2.OriginalControlBounds = new Rectangle(0x102, 0x7c, 0x196, 0xa6);
        pane2.Size = new System.Drawing.Size(100, 100);
        pane2.Text = "STANJE PO LOKACIJAMA";
        pane6.Panes.AddRange(new DockablePaneBase[] { pane2 });
        pane6.Size = new System.Drawing.Size(0x1b5, 240);
        pane7.DockedBefore = new Guid("2a475fef-9517-44d0-8aeb-3bd980f41054");
        pane3.Control = this.Panel1;
        pane3.OriginalControlBounds = new Rectangle(0x56, 0x6a, 0x73, 0xb8);
        pane3.Size = new System.Drawing.Size(100, 100);
        pane3.Text = "...";
        pane7.Panes.AddRange(new DockablePaneBase[] { pane3 });
        pane7.Size = new System.Drawing.Size(0x69, 240);
        pane8.Maximized = true;
        pane4.Control = this.Panel3;
        pane4.Maximized = true;
        pane4.OriginalControlBounds = new Rectangle(0x298, 30, 0x196, 0x158);
        pane4.Size = new System.Drawing.Size(100, 100);
        pane4.Text = "RASPOLOŽIVE LOKACIJE";
        pane8.Panes.AddRange(new DockablePaneBase[] { pane4 });
        pane8.Size = new System.Drawing.Size(0x16c, 240);
        this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane5, pane6, pane7, pane8 });
        this.UltraDockManager1.HostControl = this;
        this.UltraDockManager1.UseAppStyling = false;
        this.UltraDockManager1.UseFlatMode = DefaultableBoolean.False;
        this.UltraDockManager1.WindowStyle = WindowStyle.VisualStudio2008;
        this._RazmjestajSredstavaUnpinnedTabAreaLeft.Dock = DockStyle.Left;
        this._RazmjestajSredstavaUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this._RazmjestajSredstavaUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
        this._RazmjestajSredstavaUnpinnedTabAreaLeft.Name = "_RazmjestajSredstavaUnpinnedTabAreaLeft";
        this._RazmjestajSredstavaUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
        this._RazmjestajSredstavaUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x251);
        this._RazmjestajSredstavaUnpinnedTabAreaLeft.TabIndex = 7;
        this._RazmjestajSredstavaUnpinnedTabAreaRight.Dock = DockStyle.Right;
        this._RazmjestajSredstavaUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this._RazmjestajSredstavaUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x39b, 0);
        this._RazmjestajSredstavaUnpinnedTabAreaRight.Name = "_RazmjestajSredstavaUnpinnedTabAreaRight";
        this._RazmjestajSredstavaUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
        this._RazmjestajSredstavaUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x251);
        this._RazmjestajSredstavaUnpinnedTabAreaRight.TabIndex = 8;
        this._RazmjestajSredstavaUnpinnedTabAreaTop.Dock = DockStyle.Top;
        this._RazmjestajSredstavaUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this._RazmjestajSredstavaUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
        this._RazmjestajSredstavaUnpinnedTabAreaTop.Name = "_RazmjestajSredstavaUnpinnedTabAreaTop";
        this._RazmjestajSredstavaUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
        this._RazmjestajSredstavaUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x39b, 0);
        this._RazmjestajSredstavaUnpinnedTabAreaTop.TabIndex = 9;
        this._RazmjestajSredstavaUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
        this._RazmjestajSredstavaUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this._RazmjestajSredstavaUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x251);
        this._RazmjestajSredstavaUnpinnedTabAreaBottom.Name = "_RazmjestajSredstavaUnpinnedTabAreaBottom";
        this._RazmjestajSredstavaUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
        this._RazmjestajSredstavaUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x39b, 0);
        this._RazmjestajSredstavaUnpinnedTabAreaBottom.TabIndex = 10;
        this._RazmjestajSredstavaAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this._RazmjestajSredstavaAutoHideControl.Location = new System.Drawing.Point(0, 0);
        this._RazmjestajSredstavaAutoHideControl.Name = "_RazmjestajSredstavaAutoHideControl";
        this._RazmjestajSredstavaAutoHideControl.Owner = this.UltraDockManager1;
        this._RazmjestajSredstavaAutoHideControl.Size = new System.Drawing.Size(0, 0x179);
        this._RazmjestajSredstavaAutoHideControl.TabIndex = 11;
        this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
        this.WindowDockingArea1.Dock = DockStyle.Top;
        this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
        this.WindowDockingArea1.Name = "WindowDockingArea1";
        this.WindowDockingArea1.Owner = this.UltraDockManager1;
        this.WindowDockingArea1.Size = new System.Drawing.Size(0x39b, 0x161);
        this.WindowDockingArea1.TabIndex = 0x10;
        this.DockableWindow1.Controls.Add(this.Panel4);
        this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
        this.DockableWindow1.Name = "DockableWindow1";
        this.DockableWindow1.Owner = this.UltraDockManager1;
        this.DockableWindow1.Size = new System.Drawing.Size(0x39b, 0x15c);
        this.DockableWindow1.TabIndex = 20;
        this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
        this.WindowDockingArea2.Dock = DockStyle.Left;
        this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0x161);
        this.WindowDockingArea2.Name = "WindowDockingArea2";
        this.WindowDockingArea2.Owner = this.UltraDockManager1;
        this.WindowDockingArea2.Size = new System.Drawing.Size(0x1ba, 240);
        this.WindowDockingArea2.TabIndex = 0x11;
        this.DockableWindow2.Controls.Add(this.Panel2);
        this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
        this.DockableWindow2.Name = "DockableWindow2";
        this.DockableWindow2.Owner = this.UltraDockManager1;
        this.DockableWindow2.Size = new System.Drawing.Size(0x1b5, 240);
        this.DockableWindow2.TabIndex = 0x15;
        this.WindowDockingArea3.Controls.Add(this.DockableWindow3);
        this.WindowDockingArea3.Dock = DockStyle.Left;
        this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this.WindowDockingArea3.Location = new System.Drawing.Point(0x1ba, 0x161);
        this.WindowDockingArea3.Name = "WindowDockingArea3";
        this.WindowDockingArea3.Owner = this.UltraDockManager1;
        this.WindowDockingArea3.Size = new System.Drawing.Size(110, 240);
        this.WindowDockingArea3.TabIndex = 0x12;
        this.DockableWindow3.Controls.Add(this.Panel1);
        this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
        this.DockableWindow3.Name = "DockableWindow3";
        this.DockableWindow3.Owner = this.UltraDockManager1;
        this.DockableWindow3.Size = new System.Drawing.Size(0x69, 240);
        this.DockableWindow3.TabIndex = 0x16;
        this.WindowDockingArea4.Controls.Add(this.DockableWindow4);
        this.WindowDockingArea4.Dock = DockStyle.Left;
        this.WindowDockingArea4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
        this.WindowDockingArea4.Location = new System.Drawing.Point(0x228, 0x161);
        this.WindowDockingArea4.Name = "WindowDockingArea4";
        this.WindowDockingArea4.Owner = this.UltraDockManager1;
        this.WindowDockingArea4.Size = new System.Drawing.Size(0x171, 240);
        this.WindowDockingArea4.TabIndex = 0x13;
        this.DockableWindow4.Controls.Add(this.Panel3);
        this.DockableWindow4.Location = new System.Drawing.Point(0, 0);
        this.DockableWindow4.Name = "DockableWindow4";
        this.DockableWindow4.Owner = this.UltraDockManager1;
        this.DockableWindow4.Size = new System.Drawing.Size(0x16c, 240);
        this.DockableWindow4.TabIndex = 0x17;
        this.Controls.Add(this._RazmjestajSredstavaAutoHideControl);
        this.Controls.Add(this.WindowDockingArea4);
        this.Controls.Add(this.WindowDockingArea3);
        this.Controls.Add(this.WindowDockingArea2);
        this.Controls.Add(this.WindowDockingArea1);
        this.Controls.Add(this._RazmjestajSredstavaUnpinnedTabAreaTop);
        this.Controls.Add(this._RazmjestajSredstavaUnpinnedTabAreaBottom);
        this.Controls.Add(this._RazmjestajSredstavaUnpinnedTabAreaLeft);
        this.Controls.Add(this._RazmjestajSredstavaUnpinnedTabAreaRight);
        this.Name = "TablicniRazmjestajSredstava";
        this.Size = new System.Drawing.Size(0x39b, 0x251);


        this.UltraGrid3.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid3_InitializeLayout);
        this.UltraGrid2.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
        this.UltraGrid1.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
        this.UltraButton2.Click += new EventHandler(this.UltraButton2_Click);
        this.UltraButton1.Click += new EventHandler(this.UltraButton1_Click);


        this.Panel4.ResumeLayout(false);
        ((ISupportInitialize) this.UltraGrid3).EndInit();
        this.Panel2.ResumeLayout(false);
        ((ISupportInitialize) this.UltraGrid1).EndInit();
        this.Panel1.ResumeLayout(false);
        this.Panel3.ResumeLayout(false);
        ((ISupportInitialize) this.UltraGrid2).EndInit();
        this.DatasetKratkaRekap1.EndInit();
        this.DsIPObrazac1.EndInit();
        ((ISupportInitialize) this.UltraDockManager1).EndInit();
        this.WindowDockingArea1.ResumeLayout(false);
        this.DockableWindow1.ResumeLayout(false);
        this.WindowDockingArea2.ResumeLayout(false);
        this.DockableWindow2.ResumeLayout(false);
        this.WindowDockingArea3.ResumeLayout(false);
        this.DockableWindow3.ResumeLayout(false);
        this.WindowDockingArea4.ResumeLayout(false);
        this.DockableWindow4.ResumeLayout(false);
        this.DockableWindow4.PerformLayout();
        this.ResumeLayout(false);
    }

    public void IzbaciLokacije()
    {
    }

    private void IznosiNabave_Load(object sender, EventArgs e)
    {
        UltraGridColumn current;
        this.__CurrencyManager = (CurrencyManager)this.BindingContext[this.dsosnovna.OS];
        this.__CurrencyManager.PositionChanged += new EventHandler(this.__CurrencyManager_PositionChanged);
        this.__CurrencyManager_PositionChanged(null, null);
        this.daosnovna.Fill(this.dsosnovna);
        this.m_cm = (CurrencyManager)this.BindingContext[this.ds.S_OS_STANJE_LOKACIJA];
        this.m_cm.PositionChanged += new EventHandler(this.m_cm_PositionChanged);
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        if (this.dsosnovna.OS.Rows.Count > 0)
        {
            this.daStanje.Fill(this.ds, Conversions.ToLong(this.dsosnovna.OS.Rows[0]["invbroj"]));
        }
        this.m_bDisablePosCHange = false;
        this.dalok.Fill(this.dslokacije);
        this.IzbaciLokacije();
        this.UltraGrid1.DataSource = this.ds.S_OS_STANJE_LOKACIJA;
        this.UltraGrid2.DataSource = this.dslokacije.LOKACIJE;
        this.UltraGrid3.DataSource = this.dsosnovna.OS;
        this.m_cmDisable = false;
        this.m_cm_PositionChanged(null, null);
        this.UltraGrid1.Text = "";
        this.UltraGrid2.Text = "";
        this.UltraGrid2.DisplayLayout.Bands[0].Columns[2].Hidden = true;
        this.UltraGrid2.DisplayLayout.Bands[0].Columns[0].Header.Caption = "Šif.lokacije";
        this.UltraGrid2.DisplayLayout.Bands[0].Columns[1].Header.Caption = "Lokacija";
        this.UltraGrid1.DisplayLayout.Bands[0].Columns[2].Hidden = true;
        this.UltraGrid1.DisplayLayout.Bands[0].Columns[3].Hidden = true;
        this.UltraGrid3.DisplayLayout.Bands[0].Override.AllowUpdate = DefaultableBoolean.False;
        this.UltraGrid3.DisplayLayout.Bands[1].Hidden = true;
        this.UltraGrid3.DisplayLayout.Bands[0].Override.CellClickAction = CellClickAction.RowSelect;
        ColumnEnumerator enumerator = this.UltraGrid3.DisplayLayout.Bands[0].Columns.GetEnumerator();
        while (enumerator.MoveNext())
        {
            current = enumerator.Current;
            if ((current.Key == "INVBROJ") | (current.Key == "NAZIVOS"))
            {
                current.Hidden = false;
            }
            else
            {
                current.Hidden = true;
            }
        }
        ColumnEnumerator enumerator2 = this.UltraGrid1.DisplayLayout.Bands[0].Columns.GetEnumerator();
        while (enumerator2.MoveNext())
        {
            current = enumerator2.Current;
            if (current.Key == "STANJE")
            {
                current.MaskInput = "-nnnnnnnnn.nn";
            }
        }
        this.UltraGrid3.DisplayLayout.Bands[0].Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
        this.UltraGrid2.DisplayLayout.Bands[0].Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
        this.UltraGrid1.DisplayLayout.Bands[0].Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
    }

    public void m_cm_PositionChanged(object sender, EventArgs e)
    {
        if (!Operators.ConditionalCompareObjectEqual(this.m_cmDisable, true, false) && (this.m_cm.Count != 0))
        {
            DataRowView current = (DataRowView) this.m_cm.Current;
            this.dslokacije.Clear();
            this.dalok.Fill(this.dslokacije);
            DataRow[] rowArray = this.dslokacije.LOKACIJE.Select(Conversions.ToString(Operators.ConcatenateObject("idlokacije = ", current["idlokacije"])));
            if (rowArray.Length > 0)
            {
                rowArray[0].Delete();
            }
        }
    }

    public void Spremi()
    {
        BindingSource bindingSource = this.OSController.OSFormDefinition.GetBindingSource("OS");
        try
        {
            bindingSource.EndEdit();
        }
        catch (System.Exception exception1)
        {
            throw exception1;
            
            //Interaction.MsgBox("Greška, podaci nisu uneseni prema pravilima! ", MsgBoxStyle.OkOnly, null);
            //return;
        }
        this.OSController.Update(this.Parent.Parent);
        this.OSController.OSFormDefinition.GetBindingSource("OSLOKACIJE").EndEdit();
    }

    public void TekuceStanje()
    {
        this.ds.Clear();
        this.m_cmDisable = true;
        this.daStanje.Fill(this.ds, Conversions.ToLong(this.OSController.DataSet.OS.Rows[0]["invbroj"]));
        this.m_cmDisable = false;
        this.m_cm_PositionChanged(null, null);
    }

    private void UltraButton1_Click(object sender, EventArgs e)
    {
        CurrencyManager manager = (CurrencyManager) this.BindingContext[this.ds.S_OS_STANJE_LOKACIJA];
        CurrencyManager manager2 = (CurrencyManager) this.BindingContext[this.dslokacije.LOKACIJE];
        OSRAZMJESTAJDataAdapter adapter = new OSRAZMJESTAJDataAdapter();
        OSRAZMJESTAJDataSet dataSet = new OSRAZMJESTAJDataSet();
        DataRow row = dataSet.OSRAZMJESTAJ.NewRow();
        DataRow row2 = dataSet.OSRAZMJESTAJ.NewRow();
        row["idlokacije"] = RuntimeHelpers.GetObjectValue(((DataRowView) manager2.Current)["idlokacije"]);
        row["invbroj"] = RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["invbroj"]);
        row["kolicinaulaza"] = RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["stanje"]);
        row["kolicinarashoda"] = 0;
        row2["idlokacije"] = RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["idlokacije"]);
        row2["invbroj"] = RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["invbroj"]);
        row2["kolicinaulaza"] = 0;
        row2["kolicinarashoda"] = 0 - Conversions.ToInteger(((DataRowView) manager.Current)["stanje"]);
        dataSet.OSRAZMJESTAJ.Rows.Add(row);
        dataSet.OSRAZMJESTAJ.Rows.Add(row2);
        adapter.Update(dataSet);
        this.ds.Clear();
        this.m_cmDisable = true;
        this.daStanje.Fill(this.ds, Conversions.ToLong(NewLateBinding.LateGet(this.__CurrencyManager.Current, null, "item", new object[] { 0 }, null, null, null)));
        this.IzbaciLokacije();
        this.m_cmDisable = false;
        this.m_cm_PositionChanged(null, null);
    }

    private void UltraButton2_Click(object sender, EventArgs e)
    {
        CurrencyManager manager = (CurrencyManager) this.BindingContext[this.ds.S_OS_STANJE_LOKACIJA];
        frmKolicina kolicina = new frmKolicina {
            kolicina = { MaxValue = RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["stanje"]), Value = RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["stanje"]) }
        };
        if (kolicina.ShowDialog() == DialogResult.OK)
        {
            int num = Convert.ToInt32(kolicina.kolicina.Value);

            if (num > 0)
            {
                CurrencyManager manager2 = (CurrencyManager)this.BindingContext[this.dslokacije.LOKACIJE];
                OSRAZMJESTAJDataAdapter adapter = new OSRAZMJESTAJDataAdapter();
                OSRAZMJESTAJDataSet dataSet = new OSRAZMJESTAJDataSet();
                DataRow row = dataSet.OSRAZMJESTAJ.NewRow();
                DataRow row2 = dataSet.OSRAZMJESTAJ.NewRow();
                row["idlokacije"] = RuntimeHelpers.GetObjectValue(((DataRowView)manager2.Current)["idlokacije"]);
                row["invbroj"] = RuntimeHelpers.GetObjectValue(((DataRowView)manager.Current)["invbroj"]);
                row["kolicinaulaza"] = num;
                row["kolicinarashoda"] = 0;
                row2["idlokacije"] = RuntimeHelpers.GetObjectValue(((DataRowView)manager.Current)["idlokacije"]);
                row2["invbroj"] = RuntimeHelpers.GetObjectValue(((DataRowView)manager.Current)["invbroj"]);
                row2["kolicinaulaza"] = 0;
                row2["kolicinarashoda"] = 0 - num;
                dataSet.OSRAZMJESTAJ.Rows.Add(row);
                dataSet.OSRAZMJESTAJ.Rows.Add(row2);
                adapter.Update(dataSet);
                this.m_cmDisable = true;
                this.ds.Clear();
                this.daStanje.Fill(this.ds, Conversions.ToLong(NewLateBinding.LateGet(this.__CurrencyManager.Current, null, "item", new object[] { 0 }, null, null, null)));
                this.IzbaciLokacije();
                this.m_cmDisable = false;
                this.m_cm_PositionChanged(null, null);
            }
        }
    }

    private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        this.UltraGrid2.DisplayLayout.Bands[0].PerformAutoResizeColumns(false, PerformAutoSizeType.AllRowsInBand);
    }

    private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        this.UltraGrid2.DisplayLayout.Bands[0].PerformAutoResizeColumns(false, PerformAutoSizeType.AllRowsInBand);
    }

    private void UltraGrid3_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
    }

    private CurrencyManager __CurrencyManager;

    private AutoHideControl _RazmjestajSredstavaAutoHideControl;

    private UnpinnedTabArea _RazmjestajSredstavaUnpinnedTabAreaBottom;

    private UnpinnedTabArea _RazmjestajSredstavaUnpinnedTabAreaLeft;

    private UnpinnedTabArea _RazmjestajSredstavaUnpinnedTabAreaRight;

    private UnpinnedTabArea _RazmjestajSredstavaUnpinnedTabAreaTop;

    private datasetKratkaRekap DatasetKratkaRekap1;

    private DockableWindow DockableWindow1;

    private DockableWindow DockableWindow2;

    private DockableWindow DockableWindow3;

    private DockableWindow DockableWindow4;

    private dsIPObrazac DsIPObrazac1;

    private CurrencyManager m_cm;

    [CreateNew, Browsable(false)]
    public NetAdvantage.Controllers.OSController OSController { get; set; }

    private Panel Panel1;

    private Panel Panel2;

    private Panel Panel3;

    private Panel Panel4;

    private UltraButton UltraButton1;

    private UltraButton UltraButton2;

    private UltraDockManager UltraDockManager1;

    private UltraGrid UltraGrid1;

    private UltraGrid UltraGrid2;

    private UltraGrid UltraGrid3;

    private WindowDockingArea WindowDockingArea1;

    private WindowDockingArea WindowDockingArea2;

    private WindowDockingArea WindowDockingArea3;

    private WindowDockingArea WindowDockingArea4;
}

