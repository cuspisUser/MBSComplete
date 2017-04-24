namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using Deklarit.Practices.CompositeUI;
    using Hlp;
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
    public class Zap1 : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private SmartPartInfoProvider infoProvider = new SmartPartInfoProvider();
        private SmartPartInfo smartPartInfo1 = new SmartPartInfo("ZAP-1 Obrazac", "zap1");
        private string strSifraObracuna = "";

        public Zap1()
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
            this.Preglednik = new CrystalReportViewer();
            this.Sp_zap1DataSet1 = new sp_zap1DataSet();
            this.Sp_zap1DataSet1.BeginInit();
            this.SuspendLayout();
            this.Preglednik.ActiveViewIndex = -1;
            this.Preglednik.BorderStyle = BorderStyle.FixedSingle;
            this.Preglednik.Dock = DockStyle.Fill;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.Preglednik.Location = point;
            this.Preglednik.Name = "Preglednik";
            this.Preglednik.ShowGroupTreeButton = false;
            this.Preglednik.ShowParameterPanelButton = false;
            Size size = new System.Drawing.Size(0x160, 0x132);
            this.Preglednik.Size = size;
            this.Preglednik.TabIndex = 1;
            this.Preglednik.ToolPanelView = ToolPanelViewType.None;
            this.Sp_zap1DataSet1.DataSetName = "sp_zap1DataSet";
            this.Controls.Add(this.Preglednik);
            this.Name = "Zap1";
            size = new System.Drawing.Size(0x160, 0x132);
            this.Size = size;
            this.Sp_zap1DataSet1.EndInit();
            this.ResumeLayout(false);
        }

        private void Ispis()
        {
            string str = string.Empty;
            string str2 = string.Empty;
            this.Sp_zap1DataSet1.Clear();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            string cmdText = "SELECT mjesecobracuna, godinaobracuna FROM OBRACUN WHERE idobracun = @idobracun";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@idobracun", SqlDbType.VarChar).Value = this.strSifraObracuna;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    str2 = int.Parse(Conversions.ToString(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(0))))).ToString("00");
                    str = int.Parse(Conversions.ToString(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(1))))).ToString("0000");
                }
                else
                {
                    str2 = "00";
                    str = "0000";
                }
                reader.Close();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            finally
            {
                connection.Close();
            }
            this.Cursor = Cursors.WaitCursor;
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptZap1.rpt");
            ((TextObject) document.ReportDefinition.ReportObjects["txtNaslov"]).Text = "OBRAČUN DOHOTKA - PLAĆE ZA: " + str2 + " / " + str;
            new sp_zap1DataAdapter().Fill(this.Sp_zap1DataSet1, this.strSifraObracuna);
            document.SetDataSource(this.Sp_zap1DataSet1);
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);
            document.SetParameterValue("NAZIV_FIRME", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ZIRO", Operators.ConcatenateObject(Operators.ConcatenateObject(dataSet.KORISNIKLevel1.Rows[0]["vbdikorisnik"], "-"), dataSet.KORISNIKLevel1.Rows[0]["zirokorisnik"]));
            this.Cursor = Cursors.Default;
            this.Preglednik.ReportSource = document;
        }

        private void IzborObracuna()
        {
            frmPregledObracuna obracuna = new frmPregledObracuna();
            obracuna.ShowDialog();
            if (obracuna.ObracunSelected != null)
            {
                this.strSifraObracuna = obracuna.ObracunSelected.ToString();
            }
        }

        [LocalCommandHandler("ZaObracun")]
        public void ZaObracun1Handler(object sender, EventArgs e)
        {
            this.IzborObracuna();
            this.Ispis();
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

        public CrystalReportViewer Preglednik;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        public sp_zap1DataSet Sp_zap1DataSet1;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

