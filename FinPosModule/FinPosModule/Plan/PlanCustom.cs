using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using FinPosModule.NetAdvantage.SmartParts;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinCalcManager;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
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
using System.Text;
using System.Windows.Forms;


namespace FinPosModule.Plan
{
    [SmartPart]
    public class PlanCustom : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private PRPLACEDataAdapter dapriprema;
        private int godina;
        private int idplan;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public PlanCustom()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Planiranje", "Planiranje");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Unos_Stavke();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DataRowView current = null;
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Izvršenje plana",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            IzvrsenjePlana smartPart = this.Controller.WorkItem.Items.AddNew<IzvrsenjePlana>();
            if (this.BindingContext[this.PlanDataSet1, "PLANORG"].Current != null)
            {
                current = (DataRowView) this.BindingContext[this.PlanDataSet1, "PLANORG"].Current;
            }
            smartPart.UltraTextEditor1.Value = RuntimeHelpers.GetObjectValue(current["planojidorgjed"]);
            workspace.Show(smartPart, smartPartInfo);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Izvršenje plana",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            IzvrsenjePlana smartPart = this.Controller.WorkItem.Items.AddNew<IzvrsenjePlana>();
            if (this.BindingContext[this.PlanDataSet1, "PLANORG"].Current != null)
            {
                DataRowView current = (DataRowView) this.BindingContext[this.PlanDataSet1, "PLANORG"].Current;
            }
            StringBuilder builder = new StringBuilder();
            RowEnumerator enumerator = this.UltraGrid1.Selected.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraGridRow row2 = enumerator.Current;
                if (builder.Length > 0)
                {
                    builder.Append(",");
                }
                builder.Append(RuntimeHelpers.GetObjectValue(row2.Cells["PLANOJIDORGJED"].Value));
            }
            smartPart.UltraTextEditor1.Value = builder.ToString();
            workspace.Show(smartPart, smartPartInfo);
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ORGJED", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oj");
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("zaposlenik");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PLANORG", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPLAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANGODINAIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANOJIDORGJED", -1, "UltraDropDown2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANOJNAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANORG_PLANORGKON");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PLANORG_PLANORGKON", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPLAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANGODINAIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANOJIDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANKONTOIDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANIRANIIZNOS");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PLANORGKON", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPLAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANGODINAIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANOJIDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANKONTOIDKONTO", -1, "UltraDropDown3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANIRANIIZNOS");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("9373afb2-5358-4618-b4be-9d6c44b6bcce"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("c9a6ddcd-81e9-4c0d-8781-8476eda2fe81"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb"), -1);
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtRashodiOJ = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.txtPrihodiOJ = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.txtRashodi = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.txtPrihodi = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.Button1 = new System.Windows.Forms.Button();
            this.UltraDropDown3 = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.UltraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.UltraDropDown2 = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.UltraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.PlanDataSet1 = new Placa.PLANDataSet();
            this.UltraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UltraDropDown1 = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PripremaPlaceCustomAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRashodiOJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrihodiOJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRashodi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrihodi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.Button3);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.txtRashodiOJ);
            this.UltraGroupBox1.Controls.Add(this.txtPrihodiOJ);
            this.UltraGroupBox1.Controls.Add(this.txtRashodi);
            this.UltraGroupBox1.Controls.Add(this.txtPrihodi);
            this.UltraGroupBox1.Controls.Add(this.Button1);
            this.UltraGroupBox1.Controls.Add(this.UltraDropDown3);
            this.UltraGroupBox1.Controls.Add(this.UltraDropDown2);
            this.UltraGroupBox1.Controls.Add(this.UltraTextEditor1);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(1158, 151);
            this.UltraGroupBox1.TabIndex = 1;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(590, 119);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(142, 23);
            this.Button3.TabIndex = 21;
            this.Button3.Text = "Izvršenje plana";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // UltraLabel2
            // 
            this.UltraLabel2.AutoSize = true;
            this.UltraLabel2.Location = new System.Drawing.Point(10, 128);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(219, 14);
            this.UltraLabel2.TabIndex = 20;
            this.UltraLabel2.Text = "Prihodi / rashodi - za OJ / izvor financiranja";
            this.UltraLabel2.UseAppStyling = false;
            // 
            // UltraLabel1
            // 
            this.UltraLabel1.AutoSize = true;
            this.UltraLabel1.ImageTransparentColor = System.Drawing.Color.Turquoise;
            this.UltraLabel1.Location = new System.Drawing.Point(95, 104);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(133, 14);
            this.UltraLabel1.TabIndex = 19;
            this.UltraLabel1.Text = "Prihodi / rashodi - ukupno";
            this.UltraLabel1.UseAppStyling = false;
            // 
            // txtRashodiOJ
            // 
            this.txtRashodiOJ.Location = new System.Drawing.Point(342, 124);
            this.txtRashodiOJ.Name = "txtRashodiOJ";
            this.txtRashodiOJ.Size = new System.Drawing.Size(100, 21);
            this.txtRashodiOJ.TabIndex = 18;
            this.txtRashodiOJ.UseAppStyling = false;
            // 
            // txtPrihodiOJ
            // 
            this.txtPrihodiOJ.Location = new System.Drawing.Point(236, 124);
            this.txtPrihodiOJ.Name = "txtPrihodiOJ";
            this.txtPrihodiOJ.Size = new System.Drawing.Size(100, 21);
            this.txtPrihodiOJ.TabIndex = 17;
            this.txtPrihodiOJ.UseAppStyling = false;
            // 
            // txtRashodi
            // 
            this.txtRashodi.Location = new System.Drawing.Point(342, 99);
            this.txtRashodi.Name = "txtRashodi";
            this.txtRashodi.Size = new System.Drawing.Size(100, 21);
            this.txtRashodi.TabIndex = 16;
            this.txtRashodi.UseAppStyling = false;
            // 
            // txtPrihodi
            // 
            this.txtPrihodi.Location = new System.Drawing.Point(236, 99);
            this.txtPrihodi.Name = "txtPrihodi";
            this.txtPrihodi.Size = new System.Drawing.Size(100, 21);
            this.txtPrihodi.TabIndex = 15;
            this.txtPrihodi.UseAppStyling = false;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(471, 119);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(104, 23);
            this.Button1.TabIndex = 13;
            this.Button1.Text = "Započni unos";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // UltraDropDown3
            // 
            this.UltraDropDown3.CalcManager = this.UltraCalcManager1;
            this.UltraDropDown3.DataMember = "KONTO";
            this.UltraDropDown3.DataSource = this.KontoDataSet1;
            appearance5.BackColor = System.Drawing.Color.White;
            this.UltraDropDown3.DisplayLayout.Appearance = appearance5;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 0;
            ultraGridColumn16.Width = 150;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 3;
            ultraGridColumn19.Width = 300;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 4;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20});
            this.UltraDropDown3.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.UltraDropDown3.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraDropDown3.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDropDown3.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDropDown3.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.UltraDropDown3.DisplayLayout.Override.CardAreaAppearance = appearance6;
            this.UltraDropDown3.DisplayLayout.Override.CellPadding = 3;
            appearance8.TextHAlignAsString = "Left";
            this.UltraDropDown3.DisplayLayout.Override.HeaderAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.LightGray;
            appearance9.TextVAlignAsString = "Middle";
            this.UltraDropDown3.DisplayLayout.Override.RowAppearance = appearance9;
            this.UltraDropDown3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BorderColor = System.Drawing.Color.Black;
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.UltraDropDown3.DisplayLayout.Override.SelectedRowAppearance = appearance10;
            this.UltraDropDown3.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraDropDown3.Location = new System.Drawing.Point(799, 3);
            this.UltraDropDown3.Name = "UltraDropDown3";
            this.UltraDropDown3.Size = new System.Drawing.Size(261, 74);
            this.UltraDropDown3.TabIndex = 12;
            this.UltraDropDown3.ValueMember = "IDKONTO";
            this.UltraDropDown3.Visible = false;
            // 
            // UltraCalcManager1
            // 
            this.UltraCalcManager1.ContainingControl = this;
            // 
            // KontoDataSet1
            // 
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            // 
            // UltraDropDown2
            // 
            this.UltraDropDown2.CalcManager = this.UltraCalcManager1;
            this.UltraDropDown2.DataMember = "ORGJED";
            this.UltraDropDown2.DataSource = this.OrgjedDataSet1;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 0;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 1;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 2;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23});
            this.UltraDropDown2.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.UltraDropDown2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraDropDown2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDropDown2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDropDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraDropDown2.Location = new System.Drawing.Point(516, 15);
            this.UltraDropDown2.Name = "UltraDropDown2";
            this.UltraDropDown2.Size = new System.Drawing.Size(261, 61);
            this.UltraDropDown2.TabIndex = 2;
            this.UltraDropDown2.Text = "UltraDropDown2";
            this.UltraDropDown2.ValueMember = "IDORGJED";
            this.UltraDropDown2.Visible = false;
            // 
            // OrgjedDataSet1
            // 
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            // 
            // UltraTextEditor1
            // 
            editorButton1.Key = "zaposlenik";
            editorButton1.Text = "Kliknite za odabir";
            this.UltraTextEditor1.ButtonsRight.Add(editorButton1);
            this.UltraTextEditor1.Location = new System.Drawing.Point(16, 33);
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            this.UltraTextEditor1.Size = new System.Drawing.Size(445, 21);
            this.UltraTextEditor1.TabIndex = 11;
            this.UltraTextEditor1.Text = "Odaberite plan proračuna";
            this.UltraTextEditor1.ValueChanged += new System.EventHandler(this.UltraTextEditor1_ValueChanged);
            this.UltraTextEditor1.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.UltraTextEditor1_EditorButtonClick);
            // 
            // UltraGroupBox2
            // 
            this.UltraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.UltraGroupBox2.Controls.Add(this.UltraGrid1);
            this.UltraGroupBox2.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(369, 278);
            this.UltraGroupBox2.TabIndex = 8;
            this.UltraGroupBox2.UseAppStyling = false;
            this.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.CalcManager = this.UltraCalcManager1;
            this.UltraGrid1.DataMember = "PLANORG";
            this.UltraGrid1.DataSource = this.PlanDataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 240;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 1;
            ultraGridColumn7.Width = 189;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 3;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            ultraGridBand2.Hidden = true;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance15;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance16.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance16;
            appearance17.BorderColor = System.Drawing.Color.LightGray;
            appearance17.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance17;
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BorderColor = System.Drawing.Color.Black;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(363, 275);
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.UseAppStyling = false;
            this.UltraGrid1.AfterRowActivate += new System.EventHandler(this.UltraGrid1_AfterRowActivate);
            // 
            // PlanDataSet1
            // 
            this.PlanDataSet1.DataSetName = "PLANDataSet";
            // 
            // UltraGroupBox3
            // 
            this.UltraGroupBox3.Controls.Add(this.UltraGrid2);
            this.UltraGroupBox3.Controls.Add(this.UltraDropDown1);
            this.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox3.Location = new System.Drawing.Point(374, 174);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(784, 296);
            this.UltraGroupBox3.TabIndex = 9;
            this.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.CalcManager = this.UltraCalcManager1;
            this.UltraGrid2.DataMember = "PLANORG.PLANORG_PLANORGKON";
            this.UltraGrid2.DataSource = this.PlanDataSet1;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.FontData.BoldAsString = "True";
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.UltraGrid2.DisplayLayout.Appearance = appearance7;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn14.Width = 276;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn15.CellAppearance = appearance3;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn15.Header.Appearance = appearance4;
            ultraGridColumn15.Header.Caption = "Planirani iznos";
            ultraGridColumn15.Header.VisiblePosition = 4;
            ultraGridColumn15.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn15.Width = 156;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance11;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            appearance12.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance12;
            appearance13.BorderColor = System.Drawing.Color.LightGray;
            appearance13.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance14.BorderColor = System.Drawing.Color.Black;
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance14;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid2.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(778, 293);
            this.UltraGrid2.TabIndex = 7;
            this.UltraGrid2.UseAppStyling = false;
            this.UltraGrid2.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid2_AfterCellUpdate);
            this.UltraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
            this.UltraGrid2.AfterEnterEditMode += new System.EventHandler(this.UltraGrid2_AfterEnterEditMode);
            this.UltraGrid2.AfterRowsDeleted += new System.EventHandler(this.UltraGrid2_AfterRowsDeleted);
            this.UltraGrid2.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid2_AfterRowInsert);
            this.UltraGrid2.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid2_AfterRowUpdate);
            this.UltraGrid2.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid2_CellChange);
            this.UltraGrid2.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.UltraGrid2_BeforeRowDeactivate);
            this.UltraGrid2.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UltraGrid2_CellDataError);
            this.UltraGrid2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UltraGrid2_KeyDown);
            // 
            // UltraDropDown1
            // 
            this.UltraDropDown1.CalcManager = this.UltraCalcManager1;
            this.UltraDropDown1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraDropDown1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDropDown1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDropDown1.DisplayMember = "IDRADNIK";
            this.UltraDropDown1.Location = new System.Drawing.Point(44, 227);
            this.UltraDropDown1.Name = "UltraDropDown1";
            this.UltraDropDown1.Size = new System.Drawing.Size(556, 32);
            this.UltraDropDown1.TabIndex = 1;
            this.UltraDropDown1.Text = "UltraDropDown1";
            this.UltraDropDown1.ValueMember = "IDRADNIK";
            this.UltraDropDown1.Visible = false;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb");
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(4, 3, 613, 77);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Odabir postojećeg financijskog plana";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1158, 169);
            dockableControlPane2.Control = this.UltraGroupBox2;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(47, 123, 260, 225);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Organizacijske jedinice / izvori financiranja";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(369, 296);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _PripremaPlaceCustomUnpinnedTabAreaLeft
            // 
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Name = "_PripremaPlaceCustomUnpinnedTabAreaLeft";
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.TabIndex = 10;
            // 
            // _PripremaPlaceCustomUnpinnedTabAreaRight
            // 
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Location = new System.Drawing.Point(1158, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Name = "_PripremaPlaceCustomUnpinnedTabAreaRight";
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.TabIndex = 11;
            // 
            // _PripremaPlaceCustomUnpinnedTabAreaTop
            // 
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Name = "_PripremaPlaceCustomUnpinnedTabAreaTop";
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Size = new System.Drawing.Size(1158, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.TabIndex = 12;
            // 
            // _PripremaPlaceCustomUnpinnedTabAreaBottom
            // 
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Name = "_PripremaPlaceCustomUnpinnedTabAreaBottom";
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1158, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.TabIndex = 13;
            // 
            // _PripremaPlaceCustomAutoHideControl
            // 
            this._PripremaPlaceCustomAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._PripremaPlaceCustomAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomAutoHideControl.Name = "_PripremaPlaceCustomAutoHideControl";
            this._PripremaPlaceCustomAutoHideControl.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._PripremaPlaceCustomAutoHideControl.TabIndex = 14;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1158, 174);
            this.WindowDockingArea1.TabIndex = 15;
            // 
            // DockableWindow3
            // 
            this.DockableWindow3.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(1158, 169);
            this.DockableWindow3.TabIndex = 18;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraGroupBox2);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(369, 296);
            this.DockableWindow1.TabIndex = 19;
            // 
            // WindowDockingArea3
            // 
            this.WindowDockingArea3.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea3.Location = new System.Drawing.Point(0, 174);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(374, 296);
            this.WindowDockingArea3.TabIndex = 17;
            // 
            // PlanCustom
            // 
            this.Controls.Add(this._PripremaPlaceCustomAutoHideControl);
            this.Controls.Add(this.UltraGroupBox3);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaTop);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaBottom);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaLeft);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaRight);
            this.Name = "PlanCustom";
            this.Size = new System.Drawing.Size(1158, 470);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRashodiOJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrihodiOJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRashodi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrihodi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea3.ResumeLayout(false);
            this.ResumeLayout(false);

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

        private void Priprema_Load(object sender, EventArgs e)
        {
            this.MakeEnterActLikeTab(this.UltraGrid2);
            this.MakeEnterActLikeTab(this.UltraGrid1);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            if (keyData != Keys.Escape)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if (this.UltraGrid2.ActiveRow != null)
            {
                UltraGridRow activeRow = this.UltraGrid2.ActiveRow;
                if (activeRow == null)
                {
                    return true;
                }
                if (!((DataRowView) activeRow.ListObject).IsNew)
                {
                    this.UltraGrid2.PerformAction(UltraGridAction.ExitEditMode);
                    activeRow.CancelUpdate();
                    activeRow.Delete(false);
                    this.UltraGrid2.ActiveRow = null;
                    return true;
                }
                if (((DataRowView) activeRow.ListObject).IsNew)
                {
                    activeRow.CancelUpdate();
                    activeRow.Delete(false);
                    this.UltraGrid2.ActiveRow = null;
                    return true;
                }
            }
            return true;
        }

        public void Racunaj_iznose()
        {
            DataRowView current = null;
            if (this.BindingContext[this.PlanDataSet1, "PLANORG"].Current != null)
            {
                current = (DataRowView) this.BindingContext[this.PlanDataSet1, "PLANORG"].Current;
            }
            PLANDataSet set = new PLANDataSet();
            decimal num3 = DB.N20(RuntimeHelpers.GetObjectValue(this.PlanDataSet1.PLANORGKON.Compute("SUM(PLANIRANIIZNOS)", "PLANKONTOIDKONTO LIKE '6%' OR PLANKONTOIDKONTO LIKE '7%'")));
            decimal num4 = DB.N20(RuntimeHelpers.GetObjectValue(this.PlanDataSet1.PLANORGKON.Compute("SUM(PLANIRANIIZNOS)", "PLANKONTOIDKONTO LIKE '3%' OR PLANKONTOIDKONTO LIKE '4%'")));
            decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.PlanDataSet1.PLANORGKON.Compute("SUM(PLANIRANIIZNOS)", Conversions.ToString(Operators.ConcatenateObject("(PLANKONTOIDKONTO LIKE '6%' OR PLANKONTOIDKONTO LIKE '7%') AND PLANOJIDORGJED = ", current["PLANOJIDORGJED"])))));
            decimal num2 = DB.N20(RuntimeHelpers.GetObjectValue(this.PlanDataSet1.PLANORGKON.Compute("SUM(PLANIRANIIZNOS)", Conversions.ToString(Operators.ConcatenateObject("(PLANKONTOIDKONTO LIKE '3%' OR PLANKONTOIDKONTO LIKE '4%') AND PLANOJIDORGJED = ", current["PLANOJIDORGJED"])))));
            this.txtPrihodiOJ.Value = num;
            this.txtRashodiOJ.Value = num2;
            this.txtPrihodi.Value = num3;
            this.txtRashodi.Value = num4;
        }

        public void Spremi_Promjene()
        {
            try
            {
                ((CurrencyManager) this.BindingContext[RuntimeHelpers.GetObjectValue(this.UltraGrid2.DataSource), this.UltraGrid2.DataMember]).EndCurrentEdit();
                new PLANDataAdapter().Update(this.PlanDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                //this.PlanDataSet1.PLANORGKON.RejectChanges();
                
            }
        }

        private void UltraGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            this.Racunaj_iznose();
        }

        private void UltraGrid2_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "PLANIRANIIZNOS")
            {
                this.Spremi_Promjene();
            }
            this.Racunaj_iznose();
        }

        private void UltraGrid2_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.UltraGrid2.ActiveCell.Column.Key == "PLANKONTOIDKONTO")
            {
                this.UltraGrid2.ActiveCell.EditorResolved.DropDown();
            }
            if (this.UltraGrid2.ActiveCell.Column.Key == "PLANIRANIIZNOS")
            {
                this.UltraGrid2.ActiveCell.SelectAll();
            }
        }

        private void UltraGrid2_AfterRowInsert(object sender, RowEventArgs e)
        {
            DataRowView current = (DataRowView) this.BindingContext[this.PlanDataSet1, "PLANORG"].Current;
            e.Row.Cells["planiraniiznos"].Value = 0;
            e.Row.Cells["IDPLAN"].Value = RuntimeHelpers.GetObjectValue(current["IDPLAN"]);
            e.Row.Cells["PLANGODINAIDGODINE"].Value = RuntimeHelpers.GetObjectValue(current["PLANGODINAIDGODINE"]);
            e.Row.Cells["planOJIDORGJED"].Value = RuntimeHelpers.GetObjectValue(current["planOJIDORGJED"]);
        }

        private void UltraGrid2_AfterRowsDeleted(object sender, EventArgs e)
        {
            this.Spremi_Promjene();
            this.Racunaj_iznose();
        }

        private void UltraGrid2_AfterRowUpdate(object sender, RowEventArgs e)
        {
            this.Racunaj_iznose();
        }

        private void UltraGrid2_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
        }

        private void UltraGrid2_CellChange(object sender, CellEventArgs e)
        {
        }

        private void UltraGrid2_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (((UltraGrid) sender).ActiveCell.Column.Key == "PLANKONTOIDKONTO")
            {
                Interaction.MsgBox("Ne postoji konto u kontnome planu", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
            }
        }

        private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.UltraGrid2.ActiveCell != null) && (((e.KeyCode == Keys.Tab) | (e.KeyCode == Keys.Return)) & (this.UltraGrid2.ActiveCell.Column.Key == "PLANIRANIIZNOS")))
            {
                this.Unos_Stavke();
                e.Handled = true;
            }
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                this.KontoDataSet1.Clear();
                PLANSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<PLANSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    this.PlanDataSet1.Clear();
                    KONTODataAdapter adapter = new KONTODataAdapter();
                    ORGJEDDataAdapter adapter2 = new ORGJEDDataAdapter();
                    KONTODataSet dataSet = new KONTODataSet();
                    adapter.Fill(dataSet);
                    this.KontoDataSet1.Merge(dataSet.KONTO.Select("len(idkonto) = 4 and (idkonto like '6%' or idkonto like '3%' or idkonto like '4%' or idkonto like '7%')"));
                    this.OrgjedDataSet1.Clear();
                    adapter2.Fill(this.OrgjedDataSet1);
                    PLANDataAdapter adapter3 = new PLANDataAdapter();
                    this.idplan = Conversions.ToInteger(row["idplan"]);
                    this.godina = Conversions.ToInteger(row["plangodinaidgodine"]);
                    adapter3.FillByIDPLANPLANGODINAIDGODINE(this.PlanDataSet1, Conversions.ToInteger(row["idplan"]), Conversions.ToShort(row["plangodinaidgodine"]));
                    this.UltraTextEditor1.Value = RuntimeHelpers.GetObjectValue(row["radninazivplana"]);
                    ((CurrencyManager) this.BindingContext[RuntimeHelpers.GetObjectValue(this.UltraGrid2.DataSource), this.UltraGrid2.DataMember]).EndCurrentEdit();
                }
            }
        }

        private void UltraTextEditor1_ValueChanged(object sender, EventArgs e)
        {
        }

        public void Unos_Stavke()
        {
            try
            {
                this.UltraGrid2.UpdateData();
                new PLANDataAdapter().Update(this.PlanDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                //return;
            }
            this.PlanDataSet1.EnforceConstraints = false;
            this.BindingContext[this.PlanDataSet1, "PLANORG.PLANORG_PLANORGKON"].AddNew();
            DataRowView current = (DataRowView) this.BindingContext[this.PlanDataSet1, "PLANORG.PLANORG_PLANORGKON"].Current;
            current["planiraniiznos"] = 0;
            this.UltraGrid2.ActiveRow = this.UltraGrid2.Rows[this.UltraGrid2.Rows.Count - 1];
            this.UltraGrid2.PerformAction(UltraGridAction.ActivateCell);
            this.UltraGrid2.PerformAction(UltraGridAction.EnterEditModeAndDropdown);
        }

        private AutoHideControl _PripremaPlaceCustomAutoHideControl;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaBottom;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaLeft;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaRight;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaTop;

        private Button Button1;

        private Button Button3;

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

        private KONTODataSet KontoDataSet1;

        private ORGJEDDataSet OrgjedDataSet1;

        private PLANDataSet PlanDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraCurrencyEditor txtPrihodi;

        private UltraCurrencyEditor txtPrihodiOJ;

        private UltraCurrencyEditor txtRashodi;

        private UltraCurrencyEditor txtRashodiOJ;

        private UltraCalcManager UltraCalcManager1;

        private UltraDockManager UltraDockManager1;

        private UltraDropDown UltraDropDown1;

        private UltraDropDown UltraDropDown2;

        private UltraDropDown UltraDropDown3;

        private UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox2;

        private UltraGroupBox UltraGroupBox3;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel2;

        private UltraTextEditor UltraTextEditor1;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea3;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

