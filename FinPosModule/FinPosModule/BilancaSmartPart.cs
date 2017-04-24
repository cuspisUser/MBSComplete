

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Evolve.Wpf.Samples;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using Microsoft.Practices.CompositeUI;
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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;


namespace FinPosModule
{

    [SmartPart]
    public class BilancaSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private S_FIN_BILANCADataAdapter DABILANCA;
        private S_FIN_BILANCADataSet DSBILANCA;
        private SmartPartInfoProvider infoProvider;
        
        private DateTime POCETNI;
        private ReportDocument rpt;
        private SmartPartInfo smartPartInfo1;
        private DateTime ZAVRSNI;

        public BilancaSmartPart()
        {
            base.Load += new EventHandler(this.BilancaSmartPart_Load);
            this.DABILANCA = new S_FIN_BILANCADataAdapter();
            this.DSBILANCA = new S_FIN_BILANCADataSet();
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Izvještaji-GK-Bilanca", "Izvještaji-GK-Bilanca");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void BackgroundUpdate()
        {
            new ProgressDialog { WindowStartupLocation = WindowStartupLocation.CenterScreen, DialogText = "Pripremam izvještaj bilanca!", IsCancellingEnabled = false, AutoIncrementInterval = 150 }.RunWorkerThread(1, new DoWorkEventHandler(this.CountUntilCancelled));
        }

        private void BilancaSmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
            this.ZAVRSNI = mipsed.application.framework.Application.Zavrsni;
            this.RadioButton3.Checked = true;
            this.dtPocetni.Value = this.POCETNI;
            this.dtZavrsni.Value = this.ZAVRSNI;
            new ORGJEDDataAdapter().Fill(this.OrgjedDataSet1);
            new MJESTOTROSKADataAdapter().Fill(this.MjestotroskaDataSet1);
            new DOKUMENTDataAdapter().Fill(this.DokumentDataSet1);
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            this.PopulateTree();
            this.Oznaci();
            this.UltraTree1.ExpandAll(ExpandAllType.OnlyNodesWithChildren);
            this.UltraTree1.Focus();
            UltraTree tree = this.UltraTree1;
            tree.Appearance.BackColor = Color.WhiteSmoke;
            tree.ExpandAll();
            NodeEnumerator enumerator = tree.Nodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraTreeNode current = enumerator.Current;
                if (current.HasNodes)
                {
                    current.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.True;
                    current.Override.NodeAppearance.FontData.Name = "Verdana";
                    current.Override.NodeAppearance.FontData.SizeInPoints = 8f;
                    NodeEnumerator enumerator2 = current.Nodes.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        UltraTreeNode node2 = enumerator2.Current;
                        node2.Override.NodeAppearance.FontData.Bold = DefaultableBoolean.False;
                        node2.Override.NodeAppearance.FontData.Name = "Verdana";
                        node2.Override.NodeAppearance.FontData.SizeInPoints = 7f;
                    }
                }
            }
        }

        private void CountUntilCancelled(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker) sender;
            int num3 = Conversions.ToInteger(e.Argument);
            try
            {
                string text;
                int num2 = 0;
                this.rpt = new ReportDocument();
                this.rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\rptBilanca.rpt");
                SqlConnection connection = new SqlConnection();
                this.rpt.SetParameterValue("POCETNI", RuntimeHelpers.GetObjectValue(this.dtPocetni.Value));
                this.rpt.SetParameterValue("ZAVRSNI", RuntimeHelpers.GetObjectValue(this.dtZavrsni.Value));
                string oRG = InfraCustom.OznaceneOJ(this.UltraTree1);
                string mT = InfraCustom.OznaceneMT(this.UltraTree1);
                string dOK = InfraCustom.OznaceneDOK(this.UltraTree1);
                DateTime rAZDOBLJEOD = Conversions.ToDate(this.dtPocetni.Value);
                DateTime rAZDOBLJEDO = Conversions.ToDate(this.dtZavrsni.Value);
                int num = 5;
                if (this.skraceno.Checked)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
                int num4 = 0x63;
                if (this.txtKlasa.Text != "")
                {
                    if (this.rbSkupina.Checked)
                    {
                        num4 = 1;
                    }
                    if (this.RadioButton3.Checked)
                    {
                        num4 = 0x63;
                    }
                    if (this.rbPodSkupina.Checked)
                    {
                        num4 = 2;
                    }
                    if (this.rbOdjeljak.Checked)
                    {
                        num4 = 3;
                    }
                    if (this.rbPodOdjeljak.Checked)
                    {
                        num4 = 4;
                    }
                    text = this.txtKlasa.Text;
                }
                else
                {
                    num4 = 0x63;
                    if (this.rbSkupina.Checked)
                    {
                        num4 = 1;
                    }
                    if (this.rbPodSkupina.Checked)
                    {
                        num4 = 2;
                    }
                    if (this.rbOdjeljak.Checked)
                    {
                        num4 = 3;
                    }
                    if (this.rbPodOdjeljak.Checked)
                    {
                        num4 = 4;
                    }
                    text = " ";
                }
                this.DSBILANCA.Clear();
                try
                {
                    this.DABILANCA.Fill(this.DSBILANCA, rAZDOBLJEOD, rAZDOBLJEDO, oRG, mT, dOK, (short) num, (short) num2, text, (short) num4);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
                this.rpt.SetDataSource(this.DSBILANCA);
                this.rpt.SetParameterValue("mjestotroska", mT);
                this.rpt.SetParameterValue("dokument", dOK);
                this.rpt.SetParameterValue("organizacijska", oRG);
                this.rpt.SetParameterValue("POCETNI", RuntimeHelpers.GetObjectValue(this.dtPocetni.Value));
                this.rpt.SetParameterValue("ZAVRSNI", RuntimeHelpers.GetObjectValue(this.dtZavrsni.Value));
                mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref this.rpt);
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Exception exception2 = exception3;
                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                
            }
            worker.ReportProgress(100, "Pripremam izvještaj ...");
            worker.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("5b19b389-6f54-475c-b6bf-5d26512f4320"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("b58347ae-0f33-4207-82d8-70b2fe66cb1e"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("5b19b389-6f54-475c-b6bf-5d26512f4320"), -1);
            this.UltraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.skraceno = new System.Windows.Forms.CheckBox();
            this.dtZavrsni = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dtPocetni = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtKlasa = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.rbPodOdjeljak = new System.Windows.Forms.RadioButton();
            this.rbOdjeljak = new System.Windows.Forms.RadioButton();
            this.RadioButton3 = new System.Windows.Forms.RadioButton();
            this.rbPodSkupina = new System.Windows.Forms.RadioButton();
            this.rbSkupina = new System.Windows.Forms.RadioButton();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.MjestotroskaDataSet1 = new Placa.MJESTOTROSKADataSet();
            this.DokumentDataSet1 = new Placa.DOKUMENTDataSet();
            this.ErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmBilancaUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmBilancaUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmBilancaUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmBilancaUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmBilancaAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.RPV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtZavrsni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPocetni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DokumentDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox3
            // 
            this.UltraGroupBox3.Controls.Add(this.UltraTree1);
            this.UltraGroupBox3.Controls.Add(this.UltraGroupBox1);
            this.UltraGroupBox3.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(188, 832);
            this.UltraGroupBox3.TabIndex = 20;
            // 
            // UltraTree1
            // 
            this.UltraTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraTree1.Location = new System.Drawing.Point(3, 0);
            this.UltraTree1.Name = "UltraTree1";
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            this.UltraTree1.Override = _override1;
            this.UltraTree1.Size = new System.Drawing.Size(182, 563);
            this.UltraTree1.TabIndex = 15;
            this.UltraTree1.UseAppStyling = false;
            this.UltraTree1.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.UltraTree1_AfterCheck);
            this.UltraTree1.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.UltraTree1_AfterSelect);
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.skraceno);
            this.UltraGroupBox1.Controls.Add(this.dtZavrsni);
            this.UltraGroupBox1.Controls.Add(this.dtPocetni);
            this.UltraGroupBox1.Controls.Add(this.txtKlasa);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Controls.Add(this.rbPodOdjeljak);
            this.UltraGroupBox1.Controls.Add(this.rbOdjeljak);
            this.UltraGroupBox1.Controls.Add(this.RadioButton3);
            this.UltraGroupBox1.Controls.Add(this.rbPodSkupina);
            this.UltraGroupBox1.Controls.Add(this.rbSkupina);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UltraGroupBox1.Location = new System.Drawing.Point(3, 563);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(182, 266);
            this.UltraGroupBox1.TabIndex = 9;
            this.UltraGroupBox1.Text = "Način ispisa";
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // skraceno
            // 
            this.skraceno.BackColor = System.Drawing.Color.Transparent;
            this.skraceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skraceno.Location = new System.Drawing.Point(10, 230);
            this.skraceno.Name = "skraceno";
            this.skraceno.Size = new System.Drawing.Size(162, 24);
            this.skraceno.TabIndex = 13;
            this.skraceno.Text = "Skraćeni ispis";
            this.skraceno.UseVisualStyleBackColor = false;
            // 
            // dtZavrsni
            // 
            this.dtZavrsni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.dtZavrsni.Location = new System.Drawing.Point(86, 202);
            this.dtZavrsni.Name = "dtZavrsni";
            this.dtZavrsni.PromptChar = ' ';
            this.dtZavrsni.Size = new System.Drawing.Size(88, 21);
            this.dtZavrsni.TabIndex = 12;
            // 
            // dtPocetni
            // 
            this.dtPocetni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.dtPocetni.Location = new System.Drawing.Point(86, 178);
            this.dtPocetni.Name = "dtPocetni";
            this.dtPocetni.PromptChar = ' ';
            this.dtPocetni.Size = new System.Drawing.Size(88, 21);
            this.dtPocetni.TabIndex = 10;
            // 
            // txtKlasa
            // 
            this.txtKlasa.FormatString = "";
            this.txtKlasa.Location = new System.Drawing.Point(86, 152);
            this.txtKlasa.MaskInput = "n";
            this.txtKlasa.MaxValue = 9;
            this.txtKlasa.MinValue = 0;
            this.txtKlasa.Name = "txtKlasa";
            this.txtKlasa.Nullable = true;
            this.txtKlasa.PromptChar = ' ';
            this.txtKlasa.Size = new System.Drawing.Size(22, 21);
            this.txtKlasa.TabIndex = 8;
            this.txtKlasa.Value = null;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label2.Location = new System.Drawing.Point(10, 202);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(74, 21);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Do datuma:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label3.Location = new System.Drawing.Point(10, 152);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 21);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Klasa:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label1.Location = new System.Drawing.Point(10, 178);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 21);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Od datuma:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbPodOdjeljak
            // 
            this.rbPodOdjeljak.BackColor = System.Drawing.Color.Transparent;
            this.rbPodOdjeljak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbPodOdjeljak.Location = new System.Drawing.Point(10, 46);
            this.rbPodOdjeljak.Name = "rbPodOdjeljak";
            this.rbPodOdjeljak.Size = new System.Drawing.Size(104, 21);
            this.rbPodOdjeljak.TabIndex = 1;
            this.rbPodOdjeljak.Text = "Pododjeljak";
            this.rbPodOdjeljak.UseVisualStyleBackColor = false;
            // 
            // rbOdjeljak
            // 
            this.rbOdjeljak.BackColor = System.Drawing.Color.Transparent;
            this.rbOdjeljak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbOdjeljak.Location = new System.Drawing.Point(10, 72);
            this.rbOdjeljak.Name = "rbOdjeljak";
            this.rbOdjeljak.Size = new System.Drawing.Size(104, 21);
            this.rbOdjeljak.TabIndex = 2;
            this.rbOdjeljak.Text = "Odjeljak";
            this.rbOdjeljak.UseVisualStyleBackColor = false;
            // 
            // RadioButton3
            // 
            this.RadioButton3.BackColor = System.Drawing.Color.Transparent;
            this.RadioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButton3.Location = new System.Drawing.Point(10, 20);
            this.RadioButton3.Name = "RadioButton3";
            this.RadioButton3.Size = new System.Drawing.Size(104, 21);
            this.RadioButton3.TabIndex = 0;
            this.RadioButton3.Text = "Analitika";
            this.RadioButton3.UseVisualStyleBackColor = false;
            // 
            // rbPodSkupina
            // 
            this.rbPodSkupina.BackColor = System.Drawing.Color.Transparent;
            this.rbPodSkupina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbPodSkupina.Location = new System.Drawing.Point(10, 98);
            this.rbPodSkupina.Name = "rbPodSkupina";
            this.rbPodSkupina.Size = new System.Drawing.Size(104, 21);
            this.rbPodSkupina.TabIndex = 3;
            this.rbPodSkupina.Text = "Podskupina";
            this.rbPodSkupina.UseVisualStyleBackColor = false;
            // 
            // rbSkupina
            // 
            this.rbSkupina.BackColor = System.Drawing.Color.Transparent;
            this.rbSkupina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbSkupina.Location = new System.Drawing.Point(10, 124);
            this.rbSkupina.Name = "rbSkupina";
            this.rbSkupina.Size = new System.Drawing.Size(104, 21);
            this.rbSkupina.TabIndex = 4;
            this.rbSkupina.Text = "Skupina";
            this.rbSkupina.UseVisualStyleBackColor = false;
            // 
            // OrgjedDataSet1
            // 
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            this.OrgjedDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // MjestotroskaDataSet1
            // 
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // DokumentDataSet1
            // 
            this.DokumentDataSet1.DataSetName = "DOKUMENTDataSet";
            this.DokumentDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // ErrorProvider1
            // 
            this.ErrorProvider1.ContainerControl = this;
            // 
            // UltraDockManager1
            // 
            dockableControlPane1.Control = this.UltraGroupBox3;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(4, 28, 236, 742);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Size = new System.Drawing.Size(188, 850);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _frmBilancaUnpinnedTabAreaLeft
            // 
            this._frmBilancaUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmBilancaUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmBilancaUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmBilancaUnpinnedTabAreaLeft.Name = "_frmBilancaUnpinnedTabAreaLeft";
            this._frmBilancaUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 850);
            this._frmBilancaUnpinnedTabAreaLeft.TabIndex = 25;
            // 
            // _frmBilancaUnpinnedTabAreaRight
            // 
            this._frmBilancaUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmBilancaUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmBilancaUnpinnedTabAreaRight.Location = new System.Drawing.Point(884, 0);
            this._frmBilancaUnpinnedTabAreaRight.Name = "_frmBilancaUnpinnedTabAreaRight";
            this._frmBilancaUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 850);
            this._frmBilancaUnpinnedTabAreaRight.TabIndex = 26;
            // 
            // _frmBilancaUnpinnedTabAreaTop
            // 
            this._frmBilancaUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmBilancaUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmBilancaUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmBilancaUnpinnedTabAreaTop.Name = "_frmBilancaUnpinnedTabAreaTop";
            this._frmBilancaUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaTop.Size = new System.Drawing.Size(884, 0);
            this._frmBilancaUnpinnedTabAreaTop.TabIndex = 27;
            // 
            // _frmBilancaUnpinnedTabAreaBottom
            // 
            this._frmBilancaUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmBilancaUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmBilancaUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 850);
            this._frmBilancaUnpinnedTabAreaBottom.Name = "_frmBilancaUnpinnedTabAreaBottom";
            this._frmBilancaUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaBottom.Size = new System.Drawing.Size(884, 0);
            this._frmBilancaUnpinnedTabAreaBottom.TabIndex = 28;
            // 
            // _frmBilancaAutoHideControl
            // 
            this._frmBilancaAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmBilancaAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmBilancaAutoHideControl.Name = "_frmBilancaAutoHideControl";
            this._frmBilancaAutoHideControl.Owner = this.UltraDockManager1;
            this._frmBilancaAutoHideControl.Size = new System.Drawing.Size(0, 850);
            this._frmBilancaAutoHideControl.TabIndex = 29;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(193, 850);
            this.WindowDockingArea1.TabIndex = 30;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.UltraGroupBox3);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(188, 850);
            this.DockableWindow2.TabIndex = 113;
            // 
            // RPV
            // 
            this.RPV.ActiveViewIndex = -1;
            this.RPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPV.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPV.DisplayBackgroundEdge = false;
            this.RPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPV.Location = new System.Drawing.Point(193, 0);
            this.RPV.Name = "RPV";
            this.RPV.ShowGotoPageButton = false;
            this.RPV.ShowGroupTreeButton = false;
            this.RPV.ShowParameterPanelButton = false;
            this.RPV.ShowRefreshButton = false;
            this.RPV.Size = new System.Drawing.Size(691, 850);
            this.RPV.TabIndex = 112;
            this.RPV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // BilancaSmartPart
            // 
            this.Controls.Add(this._frmBilancaAutoHideControl);
            this.Controls.Add(this.RPV);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaTop);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaRight);
            this.Name = "BilancaSmartPart";
            this.Size = new System.Drawing.Size(884, 850);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtZavrsni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPocetni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DokumentDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void Ispisi()
        {
            this.BackgroundUpdate();
            frmPregledBilance bilance = new frmPregledBilance {
                ds = this.DSBILANCA
            };
            if (bilance.ShowDialog() == DialogResult.OK)
            {
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Analitička bruto bilanca",
                    Description = "Pregled izvještaja - Analitička bruto bilanca",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = this.rpt;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [LocalCommandHandler("Kreiraj")]
        public void KreirajHandler(object sender, EventArgs e)
        {
            this.Ispisi();
        }

        public void Oznaci()
        {
            UltraTreeNode node = new UltraTreeNode();
            NodeEnumerator enumerator = this.UltraTree1.Nodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.CheckedState = CheckState.Checked;
            }
        }

        public void PopulateTree()
        {
            DataRow current;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            IEnumerator enumerator3 = null;
            this.UltraTree1.Nodes.Clear();
            UltraTreeNode node3 = new UltraTreeNode {
                Key = "ORGJED",
                Text = "Organizacijske jedinice"
            };
            this.UltraTree1.Nodes.Add(node3);
            UltraTreeNode node2 = new UltraTreeNode {
                Key = "MT",
                Text = "Mjesta troška"
            };
            this.UltraTree1.Nodes.Add(node2);
            UltraTreeNode node = new UltraTreeNode {
                Key = "DOK",
                Text = "Dokumenti"
            };
            this.UltraTree1.Nodes.Add(node);
            int num = 1;
            try
            {
                enumerator = this.OrgjedDataSet1.ORGJED.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    UltraTreeNode node4 = new UltraTreeNode {
                        Key = Conversions.ToString(num),
                        Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(current["IDORGJED"], " - "), current["NAZIVORGJED"])),
                        Tag = current
                    };
                    try
                    {
                        node3.Nodes.Add(node4);
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                        
                        
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
            try
            {
                enumerator2 = this.MjestotroskaDataSet1.MJESTOTROSKA.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    current = (DataRow) enumerator2.Current;
                    UltraTreeNode node5 = new UltraTreeNode {
                        Key = Conversions.ToString(num),
                        Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(current["IDMJESTOTROSKA"], " - "), current["NAZIVMJESTOTROSKA"])),
                        Tag = current
                    };
                    try
                    {
                        node2.Nodes.Add(node5);
                    }
                    catch (System.Exception exception4)
                    {
                        throw exception4;
                        //Exception exception2 = exception4;
                        
                    }
                    num++;
                }
            }
            finally
            {
                if (enumerator2 is IDisposable)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
            }
            try
            {
                enumerator3 = this.DokumentDataSet1.DOKUMENT.Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    current = (DataRow) enumerator3.Current;
                    UltraTreeNode node6 = new UltraTreeNode {
                        Key = Conversions.ToString(num),
                        Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(current["IDDOKUMENT"], " - "), current["NAZIVDOKUMENT"])),
                        Tag = current
                    };
                    try
                    {
                        node.Nodes.Add(node6);
                    }
                    catch (System.Exception exception5)
                    {
                        throw exception5;
                        //Exception exception3 = exception5;
                        
                    }
                    num++;
                }
            }
            finally
            {
                if (enumerator3 is IDisposable)
                {
                    (enumerator3 as IDisposable).Dispose();
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
                case Keys.F4:
                    this.Ispisi();
                    break;

                case Keys.Escape:
                    this.ParentForm.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UltraTree1_AfterCheck(object sender, NodeEventArgs e)
        {
            UltraTreeNode node = new UltraTreeNode();
            NodeEnumerator enumerator = e.TreeNode.Nodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.CheckedState = e.TreeNode.CheckedState;
            }
        }

        private void UltraTree1_AfterSelect(object sender, SelectEventArgs e)
        {
        }

        public void ViewerTabs(CrystalReportViewer viewer, bool visible)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = viewer.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control current = (Control) enumerator.Current;
                    if (current is PageView)
                    {
                        System.Drawing.Size size = new System.Drawing.Size();
                        TabControl control2 = (TabControl) ((PageView) current).Controls[0];
                        if (!visible)
                        {
                            size = new System.Drawing.Size(0, 1);
                            control2.ItemSize = size;
                            control2.SizeMode = TabSizeMode.Fixed;
                            control2.Appearance = TabAppearance.Buttons;
                        }
                        else
                        {
                            size = new System.Drawing.Size(0x43, 0x12);
                            control2.ItemSize = size;
                            control2.SizeMode = TabSizeMode.Normal;
                            control2.Appearance = TabAppearance.Normal;
                        }
                    }
                    if (current is ToolStrip)
                    {
                        ((ToolStrip) current).Items.Add("lskdls");
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
        }

        private AutoHideControl _frmBilancaAutoHideControl;

        private UnpinnedTabArea _frmBilancaUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmBilancaUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmBilancaUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmBilancaUnpinnedTabAreaTop;

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

        private DockableWindow DockableWindow2;

        private DOKUMENTDataSet DokumentDataSet1;

        private UltraDateTimeEditor dtPocetni;

        private UltraDateTimeEditor dtZavrsni;

        private ErrorProvider ErrorProvider1;

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

        private Label Label1;

        private Label Label2;

        private Label Label3;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private ORGJEDDataSet OrgjedDataSet1;

        private RadioButton RadioButton3;

        private RadioButton rbOdjeljak;

        private RadioButton rbPodOdjeljak;

        private RadioButton rbPodSkupina;

        private RadioButton rbSkupina;

        private CrystalReportViewer RPV;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private CheckBox skraceno;

        private UltraNumericEditor txtKlasa;

        private UltraDockManager UltraDockManager1;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox3;

        private UltraTree UltraTree1;

        private WindowDockingArea WindowDockingArea1;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

