namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using Deklarit.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class Tablica018 : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        [AccessedThroughProperty("m_cm")]
        private CurrencyManager _m_cm;
        private S_PLACA_TABLICA018DataAdapter da = new S_PLACA_TABLICA018DataAdapter();
        private S_PLACA_TABLICA018DataSet ds = new S_PLACA_TABLICA018DataSet();
        private string godinaisplate = null;
        private SmartPartInfoProvider infoProvider = new SmartPartInfoProvider();
        private SmartPartInfo smartPartInfo1 = new SmartPartInfo("Mirovinsko Tablica01/10", "Tablica0110");

        public Tablica018()
        {
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.CrystalReportViewer1 = new CrystalReportViewer();
            this.SuspendLayout();
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Dock = DockStyle.Fill;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.CrystalReportViewer1.Location = point;
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowCloseButton = false;
            this.CrystalReportViewer1.ShowGotoPageButton = false;
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.ShowParameterPanelButton = false;
            this.CrystalReportViewer1.ShowRefreshButton = false;
            this.CrystalReportViewer1.ShowTextSearchButton = false;
            Size size = new System.Drawing.Size(0x338, 0x205);
            this.CrystalReportViewer1.Size = size;
            this.CrystalReportViewer1.TabIndex = 0;
            this.CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Name = "IPPObrazac";
            size = new System.Drawing.Size(0x338, 0x205);
            this.Size = size;
            this.ResumeLayout(false);
        }

        public void OtvoriObracun_Za_Mjesec()
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            frmPreglediGodinaObracuna obracuna = new frmPreglediGodinaObracuna();
            obracuna.ShowDialog();
            if (obracuna.DialogResult != DialogResult.Cancel)
            {
                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;
                string str4 = string.Empty;
                if (obracuna.OdabraniGodinaObracuna != null)
                {
                    this.ds.Clear();
                    this.godinaisplate = Conversions.ToString(obracuna.OdabraniGodinaObracuna);
                    this.da.Fill(this.ds, Conversions.ToString(obracuna.OdabraniGodinaObracuna));
                }
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(dataSet);
                ReportDocument document = new ReportDocument();
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\RPTTABLICA018.rpt");
                document.SetDataSource(this.ds);
                if (dataSet.KORISNIK.Rows.Count > 0)
                {
                    str2 = "NAZIV OBVEZNIKA PLAĆANJA DOPRINOSA:" + Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                    str = "MATIČNI BROJ POSLOVNOG SUBJEKTA:" + Conversions.ToString(dataSet.KORISNIK.Rows[0]["MBKORISNIK"]);
                    str4 = "REGISTARSKI BROJ:________________________________________________";
                    str3 = "RAČUN: ________________________________________________________________";
                }
                document.SetParameterValue("firmanaziv", str2);
                document.SetParameterValue("firmamb", str);
                document.SetParameterValue("REGISTARSKI", str4);
                document.SetParameterValue("RACUN", str3);
                document.SetParameterValue("NASLOV", "REKAPITULACIJA OSNOVICA ZA OBRAČUNAVANJE I UPLATU OBVEZNIH DOPRINOSA ZA MIROVINSKO OSIGURANJE NA TEMELJU GENERACIJSKE SOLIDARNOSTI " + this.godinaisplate + ". GODINE");
                this.CrystalReportViewer1.ReportSource = document;
            }
        }

        [LocalCommandHandler("ZaGodinu")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            this.OtvoriObracun_Za_Mjesec();
        }

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        internal CrystalReportViewer CrystalReportViewer1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._CrystalReportViewer1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._CrystalReportViewer1 = value;
            }
        }

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

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
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

