using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using NetAdvantage.WorkItems;
using Deklarit.Practices.CompositeUI.Workspaces;


namespace FinPosModule.NetAdvantage.SmartParts
{

    [SmartPart]
    public class IzvrsenjePlana : UserControl
    {
        private IContainer components;
        public int godina;
        
        public int mjesec;

        public IzvrsenjePlana()
        {
            base.Load += new EventHandler(this.UserControl1_Load);
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("S_FIN_IZVRSENJE_PLANA", -1);
            UltraGridColumn column = new UltraGridColumn("konto");
            UltraGridColumn column2 = new UltraGridColumn("PLANIRANO");
            UltraGridColumn column3 = new UltraGridColumn("IZVRSENO");
            UltraGridColumn column4 = new UltraGridColumn("INDEKS");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.UltraButton1 = new UltraButton();
            this.UltraGrid1 = new UltraGrid();
            this.S_FIN_IZVRSENJE_PLANADataSet1 = new S_FIN_IZVRSENJE_PLANADataSet();
            this.UltraButton2 = new UltraButton();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._BrutoUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._BrutoAutoHideControl = new AutoHideControl();
            this.UltraTextEditor1 = new UltraTextEditor();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.S_FIN_IZVRSENJE_PLANADataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            this.SuspendLayout();
            this.UltraButton1.Location = new System.Drawing.Point(13, 10);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton1.TabIndex = 2;
            this.UltraButton1.Text = "Zatvori";
            this.UltraGrid1.DataMember = "S_FIN_IZVRSENJE_PLANA";
            this.UltraGrid1.DataSource = this.S_FIN_IZVRSENJE_PLANADataSet1;
            appearance.BackColor = Color.AliceBlue;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.Caption = "Konto";
            column.Header.VisiblePosition = 0;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.Caption = "Planirano";
            column2.Header.VisiblePosition = 1;
            column2.Width = 0x7e;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.Caption = "Izvršeno";
            column3.Header.VisiblePosition = 2;
            column3.Width = 0x89;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.FontData.BoldAsString = "True";
            column4.CellAppearance = appearance6;
            column4.Header.Caption = "Indeks";
            column4.Header.VisiblePosition = 3;
            column4.MaskInput = "-nnnnnnnnn.nn";
            column4.Width = 0x80;
            band.Columns.AddRange(new object[] { column, column2, column3, column4 });
            band.HeaderVisible = true;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance2.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance4.BorderColor = Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance5.BackColor = Color.LightSteelBlue;
            appearance5.BorderColor = Color.Black;
            appearance5.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = SelectType.Single;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.UltraGrid1.Location = new System.Drawing.Point(0, 0x2a);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(0x2ba, 0x176);
            this.UltraGrid1.TabIndex = 3;
            this.UltraGrid1.UseAppStyling = false;
            this.S_FIN_IZVRSENJE_PLANADataSet1.DataSetName = "S_FIN_IZVRSENJE_PLANADataSet";
            this.UltraButton2.Location = new System.Drawing.Point(0x5e, 10);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton2.TabIndex = 5;
            this.UltraButton2.Text = "Ispiši";
            this.UltraDockManager1.HostControl = this;
            this._BrutoUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._BrutoUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._BrutoUnpinnedTabAreaLeft.Name = "_BrutoUnpinnedTabAreaLeft";
            this._BrutoUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x1a3);
            this._BrutoUnpinnedTabAreaLeft.TabIndex = 7;
            this._BrutoUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._BrutoUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x2bd, 0);
            this._BrutoUnpinnedTabAreaRight.Name = "_BrutoUnpinnedTabAreaRight";
            this._BrutoUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x1a3);
            this._BrutoUnpinnedTabAreaRight.TabIndex = 8;
            this._BrutoUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._BrutoUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._BrutoUnpinnedTabAreaTop.Name = "_BrutoUnpinnedTabAreaTop";
            this._BrutoUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x2bd, 0);
            this._BrutoUnpinnedTabAreaTop.TabIndex = 9;
            this._BrutoUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._BrutoUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x1a3);
            this._BrutoUnpinnedTabAreaBottom.Name = "_BrutoUnpinnedTabAreaBottom";
            this._BrutoUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x2bd, 0);
            this._BrutoUnpinnedTabAreaBottom.TabIndex = 10;
            this._BrutoAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._BrutoAutoHideControl.Name = "_BrutoAutoHideControl";
            this._BrutoAutoHideControl.Owner = this.UltraDockManager1;
            this._BrutoAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._BrutoAutoHideControl.TabIndex = 11;
            this.UltraTextEditor1.Location = new System.Drawing.Point(0xd1, 11);
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            this.UltraTextEditor1.Size = new System.Drawing.Size(0xee, 0x15);
            this.UltraTextEditor1.TabIndex = 12;
            this.UltraTextEditor1.Text = "UltraTextEditor1";
            this.Controls.Add(this._BrutoAutoHideControl);
            this.Controls.Add(this.UltraTextEditor1);
            this.Controls.Add(this.UltraButton1);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.UltraButton2);
            this.Controls.Add(this._BrutoUnpinnedTabAreaTop);
            this.Controls.Add(this._BrutoUnpinnedTabAreaBottom);
            this.Controls.Add(this._BrutoUnpinnedTabAreaLeft);
            this.Controls.Add(this._BrutoUnpinnedTabAreaRight);
            this.Name = "IzvrsenjePlana";
            this.Size = new System.Drawing.Size(0x2bd, 0x1a3);

            this.UltraButton1.Click += new EventHandler(UltraButton1_Click);
            this.UltraButton2.Click += new EventHandler(UltraButton2_Click);

            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.S_FIN_IZVRSENJE_PLANADataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void obracun_ValueChanged(object sender, EventArgs e)
        {
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpBudzetiranje.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            // Set connection string from config in existing LogonProperties
            rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;

            rpt.SetDataSource(S_FIN_IZVRSENJE_PLANADataSet1);

            rpt.SetParameterValue("@ORGANIZAC", this.UltraTextEditor1.Value.ToString());
            rpt.SetParameterValue("@godina", (int)mipsed.application.framework.Application.ActiveYear);

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = rpt;
            item.Activate();
            item.Show(item.Workspaces["main"]);

            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UltraNumericEditor1_GotFocus(object sender, EventArgs e)
        {
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            SqlParameter[] parameterArray = new SqlParameter[1];
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.StoredProcedure,
                Connection = connection,
                CommandText = "S_FIN_IZVRSENJE_PLANA"
            };
            command.Parameters.Add("@ORGANIZAC", SqlDbType.VarChar, 0x3e8).Value = Conversions.ToString(this.UltraTextEditor1.Value);
            command.Parameters.Add("@godina", SqlDbType.Int).Value = mipsed.application.framework.Application.ActiveYear;
            SqlDataAdapter adapter = new SqlDataAdapter {
                SelectCommand = command
            };
            adapter.SelectCommand.Connection = connection;
            this.S_FIN_IZVRSENJE_PLANADataSet1.EnforceConstraints = false;
            adapter.Fill(this.S_FIN_IZVRSENJE_PLANADataSet1, "S_FIN_IZVRSENJE_PLANA");
        }

        private AutoHideControl _BrutoAutoHideControl;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaBottom;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaLeft;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaRight;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaTop;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private S_FIN_IZVRSENJE_PLANADataSet S_FIN_IZVRSENJE_PLANADataSet1;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        public UltraTextEditor UltraTextEditor1;
    }
}

