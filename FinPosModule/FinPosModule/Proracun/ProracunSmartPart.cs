using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Deklarit.Practices.CompositeUI;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using Microsoft.Office.Interop.Excel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;


namespace FinPosModule.Proracun
{

    [SmartPart]
    public class ProracunSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        private DateTime POCETNI;
        private SmartPartInfo smartPartInfo1;
        private DateTime ZAVRSNI;

        public ProracunSmartPart()
        {
            base.Load += new EventHandler(this.ProracunSmartPart_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Izvještaji-Proračunski obrasci", "Izvještaji-Proračunski obrasci");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            checkSPRRAS.Checked = true;
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
            this.components = new Container();
            Override @override = new Override();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ProracunSmartPart));
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedLeft, new Guid("5b19b389-6f54-475c-b6bf-5d26512f4320"));
            Guid dockedParentId = new Guid("5b19b389-6f54-475c-b6bf-5d26512f4320");
            DockableControlPane pane = new DockableControlPane(new Guid("b58347ae-0f33-4207-82d8-70b2fe66cb1e"), new Guid("00000000-0000-0000-0000-000000000000"), -1, dockedParentId, -1);
            this.UltraGroupBox3 = new UltraGroupBox();
            this.UltraTree1 = new UltraTree();
            this.UltraGroupBox1 = new UltraGroupBox();
            this.checkBilanca = new System.Windows.Forms.CheckBox();
            this.checkSPRRAS = new System.Windows.Forms.CheckBox();
            this.checkPRRAS = new System.Windows.Forms.CheckBox();
            this.datumdo = new UltraDateTimeEditor();
            this.datumod = new UltraDateTimeEditor();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.imlIzbornik = new ImageList(this.components);
            this.OrgjedDataSet1 = new ORGJEDDataSet();
            this.imlOznake = new ImageList(this.components);
            this.MjestotroskaDataSet1 = new MJESTOTROSKADataSet();
            this.DokumentDataSet1 = new DOKUMENTDataSet();
            this.ErrorProvider1 = new ErrorProvider(this.components);
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._frmBilancaUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._frmBilancaUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._frmBilancaUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._frmBilancaUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._frmBilancaAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow2 = new DockableWindow();
            this.UltraLabel1 = new UltraLabel();
            this.OpenFileDialog1 = new OpenFileDialog();
            this.UltraButton1 = new UltraButton();
            this.UltraTextEditor1 = new UltraTextEditor();
            ((ISupportInitialize) this.UltraGroupBox3).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((ISupportInitialize) this.UltraTree1).BeginInit();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.datumdo).BeginInit();
            ((ISupportInitialize) this.datumod).BeginInit();
            this.OrgjedDataSet1.BeginInit();
            this.MjestotroskaDataSet1.BeginInit();
            this.DokumentDataSet1.BeginInit();
            ((ISupportInitialize) this.ErrorProvider1).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            this.SuspendLayout();
            this.UltraGroupBox3.Controls.Add(this.UltraTree1);
            this.UltraGroupBox3.Controls.Add(this.UltraGroupBox1);
            this.UltraGroupBox3.Location = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(0xbc, 0x340);
            this.UltraGroupBox3.TabIndex = 20;
            this.UltraTree1.Dock = DockStyle.Fill;
            this.UltraTree1.Location = new System.Drawing.Point(3, 0);
            this.UltraTree1.Name = "UltraTree1";
            @override.NodeStyle = NodeStyle.CheckBox;
            this.UltraTree1.Override = @override;
            this.UltraTree1.Size = new System.Drawing.Size(0xb6, 0x233);
            this.UltraTree1.TabIndex = 15;
            this.UltraTree1.UseAppStyling = false;
            this.UltraGroupBox1.Controls.Add(this.checkBilanca);
            this.UltraGroupBox1.Controls.Add(this.checkSPRRAS);
            this.UltraGroupBox1.Controls.Add(this.checkPRRAS);
            this.UltraGroupBox1.Controls.Add(this.datumdo);
            this.UltraGroupBox1.Controls.Add(this.datumod);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Dock = DockStyle.Bottom;
            this.UltraGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.UltraGroupBox1.Location = new System.Drawing.Point(3, 0x233);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(0xb6, 0x10a);
            this.UltraGroupBox1.TabIndex = 9;
            this.UltraGroupBox1.Text = "Način ispisa";
            this.UltraGroupBox1.ViewStyle = GroupBoxViewStyle.Office2007;
            this.checkBilanca.BackColor = Color.Transparent;
            this.checkBilanca.Checked = true;
            this.checkBilanca.CheckState = CheckState.Checked;
            this.checkBilanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.checkBilanca.Location = new System.Drawing.Point(12, 0x44);
            this.checkBilanca.Name = "checkBilanca";
            this.checkBilanca.Size = new System.Drawing.Size(0xa2, 0x18);
            this.checkBilanca.TabIndex = 15;
            this.checkBilanca.Text = "Bilanca";
            this.checkBilanca.UseVisualStyleBackColor = false;
            this.checkSPRRAS.BackColor = Color.Transparent;
            this.checkSPRRAS.Checked = false;
            this.checkSPRRAS.CheckState = CheckState.Unchecked;
            this.checkSPRRAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.checkSPRRAS.Location = new System.Drawing.Point(12, 0x2b);
            this.checkSPRRAS.Name = "checkSPRRAS";
            this.checkSPRRAS.Size = new System.Drawing.Size(0xa2, 0x18);
            this.checkSPRRAS.TabIndex = 14;
            this.checkSPRRAS.Text = "OBVEZE";
            this.checkSPRRAS.UseVisualStyleBackColor = false;
            this.checkPRRAS.BackColor = Color.Transparent;
            this.checkPRRAS.Checked = true;
            this.checkPRRAS.CheckState = CheckState.Checked;
            this.checkPRRAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.checkPRRAS.Location = new System.Drawing.Point(12, 0x13);
            this.checkPRRAS.Name = "checkPRRAS";
            this.checkPRRAS.Size = new System.Drawing.Size(0xa2, 0x18);
            this.checkPRRAS.TabIndex = 13;
            this.checkPRRAS.Text = "PR-RAS";
            this.checkPRRAS.UseVisualStyleBackColor = false;
            this.datumdo.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.datumdo.Location = new System.Drawing.Point(0x55, 0x81);
            this.datumdo.Name = "datumdo";
            this.datumdo.PromptChar = ' ';
            this.datumdo.Size = new System.Drawing.Size(0x58, 0x15);
            this.datumdo.TabIndex = 12;
            this.datumod.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.datumod.Location = new System.Drawing.Point(0x55, 0x69);
            this.datumod.Name = "datumod";
            this.datumod.PromptChar = ' ';
            this.datumod.Size = new System.Drawing.Size(0x58, 0x15);
            this.datumod.TabIndex = 10;
            this.Label2.BackColor = Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label2.Location = new System.Drawing.Point(9, 0x81);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0x4a, 0x15);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Do datuma:";
            this.Label2.TextAlign = ContentAlignment.MiddleLeft;
            this.Label1.BackColor = Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label1.Location = new System.Drawing.Point(9, 0x69);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0x4a, 0x15);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Od datuma:";
            this.Label1.TextAlign = ContentAlignment.MiddleLeft;
            /*this.imlIzbornik.ImageStream = (ImageListStreamer) manager.GetObject("imlIzbornik.ImageStream");
            this.imlIzbornik.TransparentColor = Color.Fuchsia;
            this.imlIzbornik.Images.SetKeyName(0, "");
            this.imlIzbornik.Images.SetKeyName(1, "");
            this.imlIzbornik.Images.SetKeyName(2, "");
            this.imlIzbornik.Images.SetKeyName(3, "");
            this.imlIzbornik.Images.SetKeyName(4, "");
            this.imlIzbornik.Images.SetKeyName(5, "");
            this.imlIzbornik.Images.SetKeyName(6, "");
            this.imlIzbornik.Images.SetKeyName(7, "");
            this.imlIzbornik.Images.SetKeyName(8, "");*/
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            this.OrgjedDataSet1.Locale = new CultureInfo("hr-HR");
            /*this.imlOznake.ImageStream = (ImageListStreamer) manager.GetObject("imlOznake.ImageStream");
            this.imlOznake.TransparentColor = Color.Transparent;
            this.imlOznake.Images.SetKeyName(0, "");
            this.imlOznake.Images.SetKeyName(1, "");
            this.imlOznake.Images.SetKeyName(2, "");
            this.imlOznake.Images.SetKeyName(3, "");
            this.imlOznake.Images.SetKeyName(4, "");
            this.imlOznake.Images.SetKeyName(5, "");
            this.imlOznake.Images.SetKeyName(6, "");
            this.imlOznake.Images.SetKeyName(7, "");*/
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.MjestotroskaDataSet1.Locale = new CultureInfo("hr-HR");
            this.DokumentDataSet1.DataSetName = "DOKUMENTDataSet";
            this.DokumentDataSet1.Locale = new CultureInfo("hr-HR");
            this.ErrorProvider1.ContainerControl = this;
            pane.Control = this.UltraGroupBox3;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(4, 0x1c, 0xec, 0x2e6);
            pane.OriginalControlBounds = rectangle;
            pane.Settings.AllowClose = DefaultableBoolean.False;
            pane.Size = new System.Drawing.Size(100, 100);
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            pane2.Settings.AllowClose = DefaultableBoolean.False;
            pane2.Size = new System.Drawing.Size(0xbc, 850);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = WindowStyle.Office2007;
            this._frmBilancaUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._frmBilancaUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmBilancaUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmBilancaUnpinnedTabAreaLeft.Name = "_frmBilancaUnpinnedTabAreaLeft";
            this._frmBilancaUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 850);
            this._frmBilancaUnpinnedTabAreaLeft.TabIndex = 0x19;
            this._frmBilancaUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._frmBilancaUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmBilancaUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x374, 0);
            this._frmBilancaUnpinnedTabAreaRight.Name = "_frmBilancaUnpinnedTabAreaRight";
            this._frmBilancaUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 850);
            this._frmBilancaUnpinnedTabAreaRight.TabIndex = 0x1a;
            this._frmBilancaUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._frmBilancaUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmBilancaUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmBilancaUnpinnedTabAreaTop.Name = "_frmBilancaUnpinnedTabAreaTop";
            this._frmBilancaUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x374, 0);
            this._frmBilancaUnpinnedTabAreaTop.TabIndex = 0x1b;
            this._frmBilancaUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._frmBilancaUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmBilancaUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 850);
            this._frmBilancaUnpinnedTabAreaBottom.Name = "_frmBilancaUnpinnedTabAreaBottom";
            this._frmBilancaUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmBilancaUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x374, 0);
            this._frmBilancaUnpinnedTabAreaBottom.TabIndex = 0x1c;
            this._frmBilancaAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._frmBilancaAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmBilancaAutoHideControl.Name = "_frmBilancaAutoHideControl";
            this._frmBilancaAutoHideControl.Owner = this.UltraDockManager1;
            this._frmBilancaAutoHideControl.Size = new System.Drawing.Size(0, 850);
            this._frmBilancaAutoHideControl.TabIndex = 0x1d;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea1.Dock = DockStyle.Left;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(0xc1, 850);
            this.WindowDockingArea1.TabIndex = 30;
            this.DockableWindow2.Controls.Add(this.UltraGroupBox3);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(0xbc, 850);
            this.DockableWindow2.TabIndex = 0x22;
            this.UltraLabel1.Location = new System.Drawing.Point(200, 50);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(550, 40);

            this.UltraLabel1.TabIndex = 0x1f;
            this.UltraLabel1.Text = "Molimo Vas da preuzmete tablicu sa finine web stranice i učitajte u mipsed klikom na gumb koristi drugu tablicu ili kreiraj izvještaj!http://www.fina.hr/Default.aspx?sec=915 link za FINU";
            this.OpenFileDialog1.Filter = "(*.xls)|*.xls|All files (*.*)|*.*\"";
            this.OpenFileDialog1.InitialDirectory = @"c:\Desktop";
            this.OpenFileDialog1.Title = "Pronađite željenu datoteku tablica";
            this.UltraButton1.Location = new System.Drawing.Point(200, 18);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(0x7e, 0x17);
            this.UltraButton1.TabIndex = 0x20;
            this.UltraButton1.Text = "Koristi drugu tablicu";
            this.UltraTextEditor1.Location = new System.Drawing.Point(0x15c, 30);
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            this.UltraTextEditor1.Size = new System.Drawing.Size(0x1d7, 0x15);
            this.UltraTextEditor1.TabIndex = 0x21;
            this.Controls.Add(this._frmBilancaAutoHideControl);
            this.Controls.Add(this.UltraTextEditor1);
            this.Controls.Add(this.UltraButton1);
            this.Controls.Add(this.UltraLabel1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaTop);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmBilancaUnpinnedTabAreaRight);
            this.Name = "ProracunSmartPart";
            this.Size = new System.Drawing.Size(0x374, 850);


            this.UltraTree1.AfterCheck += new AfterNodeChangedEventHandler(this.UltraTree1_AfterCheck);
            this.UltraTree1.AfterSelect += new AfterNodeSelectEventHandler(this.UltraTree1_AfterSelect);
            this.UltraGroupBox3.Click += new EventHandler(this.UltraGroupBox3_Click);
            this.UltraButton1.Click += new EventHandler(this.UltraButton1_Click);


            ((ISupportInitialize) this.UltraGroupBox3).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.UltraTree1).EndInit();
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.datumdo).EndInit();
            ((ISupportInitialize) this.datumod).EndInit();
            this.OrgjedDataSet1.EndInit();
            this.MjestotroskaDataSet1.EndInit();
            this.DokumentDataSet1.EndInit();
            ((ISupportInitialize) this.ErrorProvider1).EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// NOVO
        /// </summary>
        public void Izradi(string path)
        {
            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Interaction.CreateObject("Excel.Application", "");
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand = comm;
            System.Data.DataTable tblObveze = new System.Data.DataTable();

            if (path.Length == 0)
            {
                return;
            }

            try
            {
                int num2;
                Workbook workbook;
                Worksheet worksheet;
                SqlParameter[] parameterArray = new SqlParameter[9];
                string str5 = InfraCustom.OznaceneOJ(this.UltraTree1);
                string str4 = InfraCustom.OznaceneMT(this.UltraTree1);
                string str = InfraCustom.OznaceneDOK(this.UltraTree1);
                DateTime time2 = Conversions.ToDate(this.datumod.Value);
                DateTime time = Conversions.ToDate(this.datumdo.Value);
                int num = 9;
                if (this.checkPRRAS.Checked)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
                string str2 = " ";
                int num3 = 0x63;
                S_FIN_BILANCADataAdapter adapter = new S_FIN_BILANCADataAdapter();
                S_FIN_BILANCADataSet set = new S_FIN_BILANCADataSet();
                S_FIN_BILANCADataSet set2 = new S_FIN_BILANCADataSet();


                adapter.Fill(set, time2, time, str5, str4, str, (short)num, (short)num2, str2, (short)num3);

                adapter.Fill(set2, time2.AddYears(-1), time.AddYears(-1), str5, str4, str, (short)num, (short)num2, str2, (short)num3);


                SqlConnection connection = new SqlConnection
                {
                    ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                };
                SqlParameter[] parameterArray2 = new SqlParameter[1];
                SqlCommand command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = "S_FIN_IZVRSENJE_PLANA"
                };
                command.Parameters.Add("@ORGANIZAC", SqlDbType.VarChar, 0x3e8).Value = str5;
                command.Parameters.Add("@godina", SqlDbType.Int).Value = mipsed.application.framework.Application.ActiveYear;
                SqlDataAdapter adapter2 = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                adapter2.SelectCommand.Connection = connection;
                S_FIN_IZVRSENJE_PLANADataSet dataSet = new S_FIN_IZVRSENJE_PLANADataSet();
                dataSet.EnforceConstraints = false;
                adapter2.Fill(dataSet, "S_FIN_IZVRSENJE_PLANA");
                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                try
                {
                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(this.UltraTextEditor1.Text == ""))))
                    {
                        workbook = application.Workbooks.Open(path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    }
                    else
                    {
                        workbook = application.Workbooks.Open(this.UltraTextEditor1.Text, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                comm.Connection = connection;
                comm.CommandText = "spDopunaPRRAS";
                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.DataTable dtObveze = new System.Data.DataTable();

                comm.Parameters.AddWithValue("@datumod", time2.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@datumdo", time.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@datumZatvaranja", time.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@godina", mipsed.application.framework.Application.ActiveYear);

                adp.SelectCommand = comm;
                adp.Fill(dt);

                comm.CommandText = "spDopunaObveze";
                comm.Parameters["@datumod"].Value = new DateTime(time2.Year, 1, 1).ToString("yyyy-MM-dd");

                adp.SelectCommand = comm;
                adp.Fill(dtObveze);

                //tu ide punjenje u excel

                //punjenjeobveza
                if (this.checkSPRRAS.Checked)
                {
                    worksheet = (Worksheet)workbook.Sheets["Obv"];
                    object[] value = new object[1];
                    value[0] = dtObveze.Select("Naziv = 'A003'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[14, 4], null, "Value", value, null, null, false, true);

                    value[0] = Convert.ToDecimal(dtObveze.Select("Naziv = 'A005'")[0][1]);
                    NewLateBinding.LateSetComplex(worksheet.Cells[16, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A006'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[17, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A007'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[18, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A008'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[19, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A009'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[20, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A010'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[21, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A011'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[22, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A012'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[23, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A013'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[24, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A015'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[26, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A016'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[27, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A017'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[28, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A018'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[29, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A023'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[34, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A024'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[35, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A025'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[36, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A026'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[37, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A027'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[38, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A028'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[39, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A029'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[40, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A030'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[41, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A031'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[42, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A033'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[44, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A034'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[45, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A035'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[46, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A036'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[47, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A037'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[48, 4], null, "Value", value, null, null, false, true);

                    //value[0] = dtObveze.Select("Naziv = 'A041'")[0][1];
                    //NewLateBinding.LateSetComplex(worksheet.Cells[52, 4], null, "Value", value, null, null, false, true);

                    //value[0] = dtObveze.Select("Naziv = 'A042'")[0][1];
                    //NewLateBinding.LateSetComplex(worksheet.Cells[53, 4], null, "Value", value, null, null, false, true);

                    //value[0] = dtObveze.Select("Naziv = 'A043'")[0][1];
                    //NewLateBinding.LateSetComplex(worksheet.Cells[54, 4], null, "Value", value, null, null, false, true);

                    //value[0] = dtObveze.Select("Naziv = 'A044'")[0][1];
                    //NewLateBinding.LateSetComplex(worksheet.Cells[55, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A047'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[58, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A048'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[59, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A049'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[60, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A050'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[61, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A052'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[63, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A053'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[64, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A054'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[65, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A055'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[66, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A057'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[68, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A058'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[69, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A059'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[70, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A060'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[71, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A062'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[73, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A063'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[74, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A064'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[75, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A065'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[76, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A067'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[78, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A068'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[79, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A069'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[80, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A070'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[81, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A072'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[83, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A073'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[84, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A074'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[85, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A075'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[86, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A077'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[88, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A078'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[89, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A079'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[90, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A080'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[91, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A082'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[93, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A083'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[94, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A084'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[95, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A085'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[96, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A087'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[98, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A088'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[99, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A089'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[100, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A090'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[101, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A092'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[103, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A093'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[104, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A094'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[105, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A095'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[106, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A096'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[107, 4], null, "Value", value, null, null, false, true);

                    //value[0] = dt.Select("Naziv = 'A098'")[0][1];
                    //NewLateBinding.LateSetComplex(worksheet.Cells[109, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A099'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[110, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A100'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[111, 4], null, "Value", value, null, null, false, true);

                    value[0] = dtObveze.Select("Naziv = 'A101'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet.Cells[112, 4], null, "Value", value, null, null, false, true);
                }


                if (this.checkBilanca.Checked)
                {
                    worksheet = (Worksheet)workbook.Sheets["Bil"];
                    application.DisplayAlerts = false;
                    Worksheet worksheet3 = worksheet;
                    object[] objArray = new object[1];

                    int num7 = 12;
                    do
                    {
                        string str8 = Conversions.ToString(NewLateBinding.LateGet(worksheet3.Cells[num7, 1], null, "VALUE", new object[0], null, null, null));
                        DataRow[] rowArray3 = null;
                        if (str8 == "")
                        {
                            str8 = "preskoci";
                        }
                        rowArray3 = set.S_FIN_BILANCA.Select("konto='" + str8 + "'");

                        if (rowArray3.Length > 0)
                        {
                            try
                            {
                                object objectValue = Operators.SubtractObject(rowArray3[0]["pocetnoduguje"], rowArray3[0]["pocetnopotrazuje"]);
                                object[] arguments = new object[1];
                                object[] objArray3 = new object[2];
                                object[] objArray2 = new object[] { RuntimeHelpers.GetObjectValue(objectValue) };
                                bool[] copyBack = new bool[] { true };
                                if (copyBack[0])
                                {
                                    objectValue = RuntimeHelpers.GetObjectValue(objArray2[0]);
                                }
                                objArray3[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", objArray2, null, null, copyBack));
                                objArray3[1] = 0;
                                arguments[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Round", objArray3, null, null, null));
                                NewLateBinding.LateSetComplex(worksheet3.Cells[num7, 4], null, "Value", arguments, null, null, false, true);
                                object obj3 = Operators.SubtractObject(rowArray3[0]["duguje"], rowArray3[0]["potrazuje"]);
                                objArray2 = new object[2];
                                objArray = new object[1];
                                objArray3 = new object[] { RuntimeHelpers.GetObjectValue(obj3) };
                                copyBack = new bool[] { true };
                                if (copyBack[0])
                                {
                                    obj3 = RuntimeHelpers.GetObjectValue(objArray3[0]);
                                }
                                objArray2[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", objArray3, null, null, copyBack));
                                objArray2[1] = 0;
                                objArray[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Round", objArray2, null, null, null));
                                NewLateBinding.LateSetComplex(worksheet3.Cells[num7, 5], null, "Value", objArray, null, null, false, true);
                            }
                            catch (Exception) { } // Matija - "isolated exception" -> pošto algoritam nekada želi zapisivatu i u READ-ONLY tablicu
                        }
                        num7++;
                    }
                    while (num7 <= 257);

                    objArray[0] = dt.Select("Naziv = 'A2471'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[259, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A247'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[259, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2481'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[260, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A248'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[260, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2491'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[261, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A249'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[261, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2501'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[262, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A250'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[262, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2511'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[263, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A251'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[263, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2521'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[264, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A252'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[264, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2531'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[265, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A253'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[265, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2541'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[266, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A254'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[266, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2551'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[267, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A255'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[267, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2561'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[268, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A256'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[268, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2571'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[269, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A257'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[269, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2581'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[270, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A258'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[270, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2591'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[271, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A259'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[271, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2601'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[272, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A260'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[272, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2611'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[273, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A261'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[273, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2621'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[274, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A262'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[274, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2631'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[275, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A263'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[275, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2641'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[276, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A264'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[276, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2651'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[277, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A265'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[277, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2661'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[278, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A266'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[278, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2671'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[279, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A267'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[279, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2681'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[280, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A268'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[280, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2691'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[281, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A269'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[281, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2701'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[282, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A270'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[282, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2711'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[283, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A271'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[283, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2721'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[284, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A272'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[284, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2731'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[285, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A273'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[285, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2741'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[286, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A274'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[286, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2751'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[287, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A275'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[287, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2761'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[288, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A276'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[288, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2771'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[289, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A277'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[289, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2781'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[290, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A278'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[290, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2791'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[291, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A279'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[291, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2801'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[292, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A280'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[292, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2811'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[293, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A281'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[293, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2821'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[294, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A282'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[294, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2831'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[295, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A283'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[295, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2841'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[296, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A284'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[296, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2851'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[297, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A285'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[297, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2861'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[298, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A286'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[298, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2871'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[299, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A287'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[299, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2881'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[300, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A288'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[300, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2891'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[301, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A289'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[301, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2901'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[302, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A290'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[302, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2911'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[303, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A291'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[303, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2921'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[304, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A292'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[304, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2931'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[305, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A293'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[305, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2941'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[306, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A294'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[306, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2951'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[307, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A295'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[307, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2961'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[308, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A296'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[308, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A2971'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[309, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A297'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet3.Cells[309, 5], null, "Value", objArray, null, null, false, true);

                    worksheet3 = null;
                }
                if (this.checkPRRAS.Checked)
                {
                    object[] objArray = new object[1];
                    worksheet = (Worksheet)workbook.Sheets["PRRAS"];
                    application.DisplayAlerts = false;
                    Worksheet worksheet4 = worksheet;
                    int num8 = 12;
                    do
                    {
                        string str9 = Strings.Trim(Conversions.ToString(NewLateBinding.LateGet(worksheet4.Cells[num8, 1], null, "Value", new object[0], null, null, null)));
                        if (str9 == "")
                        {
                            str9 = "preskoci";
                        }
                        DataRow[] rowArray5 = set.S_FIN_BILANCA.Select("Konto='" + str9 + "'");
                        try
                        {
                            if (rowArray5.Length > 0)
                            {
                                double num9 = Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[] { Operators.SubtractObject(rowArray5[0]["duguje"], rowArray5[0]["potrazuje"]) }, null, null, null));
                                NewLateBinding.LateSetComplex(worksheet4.Cells[num8, 5], null, "Value", new object[] { Math.Round(num9) }, null, null, false, true);
                            }
                        }
                        catch (Exception) { } // Matija - "isolated exception" -> pošto algoritam nekada želi zapisivatu i u READ-ONLY tablicu

                        DataRow[] rowArray6 = set2.S_FIN_BILANCA.Select("Konto='" + str9 + "'");
                        try
                        {
                            if (rowArray6.Length > 0)
                            {
                                double num10 = Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[] { Operators.SubtractObject(rowArray6[0]["duguje"], rowArray6[0]["potrazuje"]) }, null, null, null));
                                NewLateBinding.LateSetComplex(worksheet4.Cells[num8, 4], null, "Value", new object[] { Math.Round(num10) }, null, null, false, true);
                            }
                        }
                        catch (Exception) { } // Matija - "isolated exception" -> pošto algoritam nekada želi zapisivatu i u READ-ONLY tablicu

                        num8++;
                    }
                    while (num8 <= 0x201);

                    objArray[0] = dt.Select("Naziv = 'A5981'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[611, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A598'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[611, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6401'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[654, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A640'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[654, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6411'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[655, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A641'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[655, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6421'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[656, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A642'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[656, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6491'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[663, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A649'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[663, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6501'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[664, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A650'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[664, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6511'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[665, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A651'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[665, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6521'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[666, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A652'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[666, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6531'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[667, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A653'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[667, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6541'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[668, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A654'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[668, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6551'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[669, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A655'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[669, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6561'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[670, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A656'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[670, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6571'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[671, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A657'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[671, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6581'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[672, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A658'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[672, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6591'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[673, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A659'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[673, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6601'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[674, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A660'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[674, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6611'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[675, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A661'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[675, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6621'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[676, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A662'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[676, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6631'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[677, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A663'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[677, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6641'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[678, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A664'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[678, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6651'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[679, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A665'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[679, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6661'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[680, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A666'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[680, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6671'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[681, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A667'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[681, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6681'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[682, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A668'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[682, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6691'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[683, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A669'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[683, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6701'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[684, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A670'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[684, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6711'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[685, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A671'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[685, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6721'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[686, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A672'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[686, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6731'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[687, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A673'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[687, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6741'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[688, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A674'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[688, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6751'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[689, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A675'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[689, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6771'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[691, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A677'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[691, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6781'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[692, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A678'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[692, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6791'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[693, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A679'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[693, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6801'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[694, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A680'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[694, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6811'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[695, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A681'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[695, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6821'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[696, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A682'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[696, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6831'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[697, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A683'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[697, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6841'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[698, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A684'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[698, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6851'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[699, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A685'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[699, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6861'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[700, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A686'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[700, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6871'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[701, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A687'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[701, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6881'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[702, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A688'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[702, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6891'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[703, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A689'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[703, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6901'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[704, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A690'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[704, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6911'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[705, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A691'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[705, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6921'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[706, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A692'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[706, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6931'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[707, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A693'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[707, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6941'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[708, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A694'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[708, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6951'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[709, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A695'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[709, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6961'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[710, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A696'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[710, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6971'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[711, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A697'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[711, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6981'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[712, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A698'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[712, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A6991'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[713, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A699'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[713, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7001'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[714, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A700'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[714, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7011'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[715, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A701'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[715, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7021'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[716, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A702'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[716, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7031'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[717, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A703'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[717, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7041'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[718, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A704'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[718, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7051'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[719, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A705'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[719, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7061'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[720, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A706'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[720, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7071'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[721, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A707'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[721, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7081'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[722, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A708'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[722, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7091'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[723, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A709'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[723, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7101'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[724, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A710'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[724, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7111'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[725, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A711'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[725, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7121'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[726, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A712'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[726, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7131'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[727, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A713'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[727, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7141'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[728, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A714'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[728, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7151'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[729, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A715'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[729, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7161'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[730, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A716'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[730, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7171'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[731, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A717'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[731, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7181'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[732, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A718'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[732, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7191'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[733, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A719'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[733, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7201'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[734, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A720'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[734, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7211'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[735, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A721'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[735, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7221'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[736, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A722'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[736, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7231'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[737, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A723'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[737, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7241'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[738, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A724'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[738, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7251'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[739, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A725'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[739, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7261'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[740, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A726'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[740, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7271'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[741, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A727'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[741, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7281'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[742, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A728'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[742, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7291'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[743, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A729'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[743, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7301'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[744, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A730'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[744, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7311'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[745, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A731'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[745, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7321'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[746, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A732'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[746, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7331'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[747, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A733'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[747, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7341'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[748, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A734'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[748, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7351'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[749, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A735'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[749, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7361'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[750, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A736'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[750, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7371'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[751, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A737'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[751, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7381'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[752, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A738'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[752, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7391'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[753, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A739'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[753, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7401'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[754, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A740'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[754, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7411'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[755, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A741'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[755, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7421'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[756, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A742'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[756, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7431'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[757, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A743'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[757, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7441'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[758, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A744'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[758, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7451'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[759, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A745'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[759, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7461'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[760, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A746'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[760, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7471'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[761, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A747'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[761, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7481'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[762, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A748'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[762, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7491'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[763, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A749'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[763, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7501'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[764, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A750'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[764, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7511'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[765, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A751'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[765, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7521'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[766, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A752'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[766, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7531'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[767, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A753'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[767, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7541'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[768, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A754'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[768, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7551'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[769, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A755'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[769, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7561'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[770, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A756'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[770, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7571'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[771, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A757'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[771, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7581'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[772, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A758'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[772, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7591'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[773, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A759'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[773, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7601'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[774, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A760'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[774, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7611'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[775, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A761'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[775, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7621'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[776, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A762'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[776, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7631'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[777, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A763'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[777, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7641'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[778, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A764'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[778, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7651'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[779, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A765'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[779, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7661'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[780, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A766'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[780, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7671'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[781, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A767'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[781, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7681'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[782, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A768'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[782, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7691'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[783, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A769'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[783, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7701'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[784, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A770'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[784, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7711'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[785, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A771'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[785, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7721'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[786, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A772'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[786, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7731'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[787, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A773'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[787, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7741'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[788, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A774'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[788, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7751'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[789, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A775'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[789, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7761'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[790, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A776'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[790, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7771'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[791, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A777'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[791, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7781'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[792, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A778'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[792, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7791'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[793, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A779'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[793, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7801'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[794, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A780'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[794, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7811'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[795, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A781'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[795, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7821'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[796, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A782'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[796, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7831'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[797, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A783'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[797, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7841'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[798, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A784'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[798, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7851'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[799, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A785'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[799, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7861'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[800, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A786'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[800, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7881'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[802, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A788'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[802, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7891'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[803, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A789'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[803, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7901'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[804, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A790'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[804, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7911'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[805, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A791'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[805, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7921'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[806, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A792'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[806, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7931'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[807, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A793'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[807, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7941'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[808, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A794'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[808, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7951'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[809, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A795'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[809, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7961'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[810, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A796'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[810, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7971'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[811, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A797'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[811, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7981'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[812, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A798'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[812, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A7991'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[813, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A799'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[813, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8001'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[814, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A800'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[814, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8011'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[815, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A801'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[815, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8021'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[816, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A802'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[816, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8031'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[817, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A803'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[817, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8041'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[818, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A804'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[818, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8051'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[819, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A805'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[819, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8061'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[820, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A806'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[820, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8071'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[821, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A807'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[821, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8081'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[822, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A808'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[822, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8091'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[823, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A809'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[823, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8101'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[824, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A810'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[824, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8111'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[825, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A811'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[825, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8121'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[826, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A812'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[826, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8131'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[827, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A813'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[827, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8141'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[828, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A814'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[828, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8151'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[829, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A815'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[829, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8161'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[830, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A816'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[830, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8171'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[831, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A817'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[831, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8181'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[832, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A818'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[832, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8191'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[833, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A819'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[833, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8201'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[834, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A820'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[834, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8211'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[835, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A821'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[835, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8221'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[836, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A822'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[836, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8231'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[837, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A823'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[837, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8241'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[838, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A824'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[838, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8251'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[839, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A825'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[839, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8261'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[840, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A826'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[840, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8271'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[841, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A827'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[841, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8281'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[842, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A828'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[842, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8291'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[843, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A829'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[843, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8301'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[844, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A830'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[844, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8311'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[845, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A831'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[845, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8321'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[846, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A832'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[846, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8331'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[847, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A833'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[847, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8341'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[848, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A834'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[848, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8351'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[849, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A835'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[849, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8361'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[850, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A836'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[850, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8371'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[851, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A837'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[851, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8381'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[852, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A838'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[852, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8391'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[853, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A839'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[853, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8401'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[854, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A840'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[854, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8411'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[855, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A841'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[855, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8421'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[856, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A842'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[856, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8431'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[857, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A843'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[857, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8441'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[858, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A844'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[858, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8451'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[859, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A845'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[859, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8461'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[860, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A846'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[860, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8471'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[861, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A847'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[861, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8481'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[862, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A848'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[862, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8491'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[863, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A849'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[863, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8501'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[864, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A850'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[864, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8511'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[865, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A851'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[865, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8521'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[866, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A852'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[866, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8531'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[867, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A853'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[867, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8541'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[868, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A854'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[868, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8551'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[869, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A855'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[869, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8561'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[870, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A856'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[870, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8571'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[871, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A857'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[871, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8581'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[872, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A858'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[872, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8591'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[873, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A859'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[873, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8601'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[874, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A860'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[874, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8611'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[875, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A861'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[875, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8621'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[876, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A862'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[876, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8631'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[877, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A863'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[877, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8641'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[878, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A864'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[878, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8651'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[879, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A865'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[879, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8661'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[880, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A866'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[880, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8671'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[881, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A867'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[881, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8681'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[882, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A868'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[882, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8691'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[883, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A869'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[883, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8701'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[884, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A870'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[884, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8711'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[885, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A871'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[885, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8721'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[886, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A872'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[886, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8741'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[888, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A874'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[888, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8751'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[889, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A875'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[889, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8761'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[890, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A876'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[890, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8771'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[891, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A877'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[891, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8781'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[892, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A878'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[892, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8791'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[893, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A879'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[893, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8801'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[894, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A880'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[894, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8811'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[895, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A881'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[895, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8821'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[896, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A882'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[896, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8831'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[897, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A883'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[897, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8841'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[898, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A884'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[898, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8851'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[899, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A885'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[899, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8861'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[900, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A886'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[900, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8871'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[901, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A887'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[901, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8881'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[902, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A888'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[902, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8891'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[903, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A889'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[903, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8901'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[904, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A890'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[904, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8911'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[905, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A891'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[905, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8921'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[906, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A892'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[906, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8931'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[907, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A893'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[907, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8941'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[908, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A894'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[908, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8951'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[909, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A895'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[909, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8961'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[910, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A896'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[910, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8971'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[911, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A897'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[911, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8981'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[912, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A898'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[912, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A8991'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[913, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A899'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[913, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9001'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[914, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A900'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[914, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9011'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[915, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A901'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[915, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9021'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[916, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A902'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[916, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9031'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[917, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A903'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[917, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9041'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[918, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A904'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[918, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9051'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[919, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A905'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[919, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9061'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[920, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A906'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[920, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9071'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[921, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A907'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[921, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9081'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[922, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A908'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[922, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9091'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[923, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A909'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[923, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9101'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[924, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A910'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[924, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9111'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[925, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A911'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[925, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9121'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[926, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A912'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[926, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9131'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[927, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A913'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[927, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9141'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[928, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A914'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[928, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9151'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[929, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A915'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[929, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9161'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[930, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A916'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[930, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9171'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[931, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A917'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[931, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9181'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[932, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A918'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[932, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9191'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[933, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A919'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[933, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9201'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[934, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A920'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[934, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9211'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[935, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A921'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[935, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9221'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[936, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A922'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[936, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9231'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[937, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A923'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[937, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9241'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[938, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A924'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[938, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9251'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[939, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A925'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[939, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9261'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[940, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A926'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[940, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9271'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[941, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A927'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[941, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9281'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[942, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A928'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[942, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9291'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[943, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A929'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[943, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9301'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[944, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A930'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[944, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9311'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[945, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A931'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[945, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9321'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[946, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A932'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[946, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9331'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[947, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A933'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[947, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9341'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[948, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A934'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[948, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9351'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[949, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A935'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[949, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9361'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[950, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A936'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[950, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9371'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[951, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A937'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[951, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9381'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[952, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A938'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[952, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9391'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[953, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A939'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[953, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9401'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[954, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A940'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[954, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9411'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[955, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A941'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[955, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9421'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[956, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A942'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[956, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9431'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[957, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A943'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[957, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9441'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[958, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A944'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[958, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9451'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[959, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A945'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[959, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9461'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[960, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A946'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[960, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9471'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[961, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A947'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[961, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9481'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[962, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A948'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[962, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9491'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[963, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A949'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[963, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9501'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[964, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A950'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[964, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9511'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[965, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A951'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[965, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9521'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[966, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A952'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[966, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9531'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[967, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A953'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[967, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9541'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[968, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A954'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[968, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9551'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[969, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A955'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[969, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9561'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[970, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A956'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[970, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A9571'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[971, 4], null, "Value", objArray, null, null, false, true);
                    objArray[0] = dt.Select("Naziv = 'A957'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[971, 5], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A959'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[976, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A960'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[977, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A961'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[978, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A962'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[979, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A963'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[980, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A964'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[981, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A965'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[982, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A966'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[983, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A967'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[984, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A968'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[985, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A969'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[986, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A970'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[987, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A971'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[988, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A972'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[989, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A973'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[990, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A974'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[991, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A975'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[992, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A976'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[993, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A977'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[994, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A978'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[995, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A979'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[996, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A980'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[997, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A981'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[998, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A982'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[999, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A983'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1000, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A984'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1001, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A985'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1002, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A986'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1003, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A987'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1004, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A988'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1005, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A989'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1006, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A990'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1007, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A991'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1008, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A992'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1009, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A993'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1010, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A994'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1011, 4], null, "Value", objArray, null, null, false, true);

                    objArray[0] = dt.Select("Naziv = 'A995'")[0][1];
                    NewLateBinding.LateSetComplex(worksheet4.Cells[1012, 4], null, "Value", objArray, null, null, false, true);


                    worksheet4 = null;
                }
                application.Visible = false;
                SaveFileDialog dialog = new SaveFileDialog
                {
                    InitialDirectory = Conversions.ToString(0),
                    Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                    FileName = "Prorac.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(dialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    Interaction.MsgBox("Tablice uspješno spremljene u " + dialog.FileName, MsgBoxStyle.OkOnly, null);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                application.Quit();
            }
        }

        [LocalCommandHandler("Kreiraj")]
        public void KreirajHandler(object sender, EventArgs e)
        {
            this.Izradi(GetFilePath());
        }

        private string GetFilePath()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                else
                {
                    return string.Empty;
                }
            }
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
                    this.Izradi(GetFilePath());
                    break;

                case Keys.Escape:
                    this.ParentForm.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ProracunSmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
            this.ZAVRSNI = mipsed.application.framework.Application.Zavrsni;
            this.datumod.Value = this.POCETNI;
            this.datumdo.Value = this.ZAVRSNI;
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

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            if (this.OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.UltraTextEditor1.Text = this.OpenFileDialog1.FileName;
            }
        }

        private void UltraGroupBox3_Click(object sender, EventArgs e)
        {
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
                        Size size;
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

        private System.Windows.Forms.CheckBox checkBilanca;

        private System.Windows.Forms.CheckBox checkPRRAS;

        private System.Windows.Forms.CheckBox checkSPRRAS;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private UltraDateTimeEditor datumdo;

        private UltraDateTimeEditor datumod;

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

        private ImageList imlIzbornik;

        private ImageList imlOznake;

        private System.Windows.Forms.Label Label1;

        private System.Windows.Forms.Label Label2;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private OpenFileDialog OpenFileDialog1;

        private ORGJEDDataSet OrgjedDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraButton UltraButton1;

        private UltraDockManager UltraDockManager1;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox3;

        private UltraLabel UltraLabel1;

        private UltraTextEditor UltraTextEditor1;

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

