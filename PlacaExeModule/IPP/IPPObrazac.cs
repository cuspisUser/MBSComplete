namespace IPP
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using Deklarit.Practices.CompositeUI;
    using Hlp;
    using Microsoft.Office.Interop.Excel;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
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
    public class IPPObrazac : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private S_OD_IPPDataAdapter da = new S_OD_IPPDataAdapter();
        private S_OD_IPPDataSet ds = new S_OD_IPPDataSet();
        private string godinaisplate = null;
        private SmartPartInfoProvider infoProvider = new SmartPartInfoProvider();
        private string mjesecisplate = null;
        private dsipp por = new dsipp();
        private SmartPartInfo smartPartInfo1 = new SmartPartInfo("IPP Obrazac", "IPPObrazac");

        public IPPObrazac()
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
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Dock = DockStyle.Fill;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowCloseButton = false;
            this.CrystalReportViewer1.ShowGotoPageButton = false;
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.ShowParameterPanelButton = false;
            this.CrystalReportViewer1.ShowRefreshButton = false;
            this.CrystalReportViewer1.ShowTextSearchButton = false;
            this.CrystalReportViewer1.Size = new System.Drawing.Size(0x338, 0x205);
            this.CrystalReportViewer1.TabIndex = 0;
            this.CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Name = "IPPObrazac";
            this.Size = new System.Drawing.Size(0x338, 0x205);
            this.ResumeLayout(false);
        }

        public void OtvoriObracun_Za_Mjesec()
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            frmPregledMjeseciGodina godina = new frmPregledMjeseciGodina();
            godina.ShowDialog();
            if (godina.DialogResult != DialogResult.Cancel)
            {
                DataRow row = null;
                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;
                if ((godina.OdabraniGodinaIsplate != null) & (godina.OdabraniMjesecIsplate != null))
                {
                    this.ds.Clear();
                    this.por.Clear();
                    this.mjesecisplate = Conversions.ToString(godina.OdabraniMjesecIsplate);
                    this.godinaisplate = Conversions.ToString(godina.OdabraniGodinaIsplate);
                    this.da.Fill(this.ds, Conversions.ToString(godina.OdabraniMjesecIsplate), Conversions.ToString(godina.OdabraniGodinaIsplate));
                    DataRow row2 = this.por.porez.NewRow();
                    row2["rbr"] = 1;
                    row2["vrsta"] = "Plaća";
                    row2["broj"] = DB.N20(RuntimeHelpers.GetObjectValue(this.ds.S_OD_IPP.Rows[0]["brojradnika"]));
                    if ((Conversions.ToInteger(godina.OdabraniGodinaIsplate) >= 0x7da) & (Conversions.ToInteger(godina.OdabraniMjesecIsplate) >= 7))
                    {
                        row2["osnovica"] = DB.RoundUP(Convert.ToDouble(DB.N20(RuntimeHelpers.GetObjectValue(this.ds.S_OD_IPP.Rows[0]["krizniporez"]))) / 0.04);
                        row2["porez"] = DB.N20(RuntimeHelpers.GetObjectValue(this.ds.S_OD_IPP.Rows[0]["krizniporez"]));
                    }
                    else
                    {
                        row2["osnovica"] = DB.N20(RuntimeHelpers.GetObjectValue(this.ds.S_OD_IPP.Rows[0]["osnovicakriznogporeza"]));
                        row2["porez"] = DB.N20(RuntimeHelpers.GetObjectValue(this.ds.S_OD_IPP.Rows[0]["krizniporez"]));
                    }
                    this.por.porez.Rows.Add(row2);
                    S_DD_IPPDataAdapter adapter2 = new S_DD_IPPDataAdapter();
                    S_DD_IPPDataSet set2 = new S_DD_IPPDataSet();
                    adapter2.Fill(set2, DB.BrojVodeceNule(RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate), 2, 0, false, ""), Conversions.ToString(godina.OdabraniGodinaIsplate));
                    row = this.por.porez.NewRow();
                    row["rbr"] = 3;
                    row["vrsta"] = "Drugi dohodak";
                    row["broj"] = DB.N20(RuntimeHelpers.GetObjectValue(set2.S_DD_IPP.Rows[0]["brojradnika"]));
                    if ((Conversions.ToInteger(godina.OdabraniGodinaIsplate) >= 0x7da) & (Conversions.ToInteger(godina.OdabraniMjesecIsplate) >= 7))
                    {
                        row["osnovica"] = DB.RoundUP(Convert.ToDouble(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_DD_IPP.Rows[0]["krizniporez"]))) / 0.04);
                        row["porez"] = DB.N20(RuntimeHelpers.GetObjectValue(set2.S_DD_IPP.Rows[0]["krizniporez"]));
                    }
                    else
                    {
                        row["osnovica"] = DB.N20(RuntimeHelpers.GetObjectValue(set2.S_DD_IPP.Rows[0]["osnovicakriznogporeza"]));
                        row["porez"] = DB.N20(RuntimeHelpers.GetObjectValue(set2.S_DD_IPP.Rows[0]["krizniporez"]));
                    }
                    this.por.porez.Rows.Add(row);
                }
                row = this.por.porez.NewRow();
                row["rbr"] = 2;
                row["vrsta"] = "Mirovina";
                row["broj"] = 0;
                row["osnovica"] = 0.0;
                row["porez"] = 0.0;
                this.por.porez.Rows.Add(row);
                row = this.por.porez.NewRow();
                row["rbr"] = 4;
                row["vrsta"] = "Dividende i udjeli u dobiti";
                row["broj"] = 0;
                row["osnovica"] = 0.0;
                row["porez"] = 0.0;
                this.por.porez.Rows.Add(row);
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(dataSet);
                ReportDocument document = new ReportDocument();
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptIPP.rpt");
                document.SetDataSource(this.por);
                if (dataSet.KORISNIK.Rows.Count > 0)
                {
                    str3 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                    str = string.Format("{0}, {1}", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]), RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                    str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
                }
                document.SetParameterValue("ustanova", str3);
                document.SetParameterValue("adresa", str);
                document.SetParameterValue("mb", str2);
                document.SetParameterValue("datum", DateTime.Today);
                document.SetParameterValue("mjesec_ime", DB.MjesecNazivDativ(Conversions.ToInteger(this.mjesecisplate)).ToUpper());
                document.SetParameterValue("godina", this.godinaisplate + ".");
                this.CrystalReportViewer1.ReportSource = document;
            }
        }

        [LocalCommandHandler("ZaMjesec")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            Workbook workbook;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) Interaction.CreateObject("Excel.Application", "");
            try
            {
                workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\rad1m.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                Worksheet worksheet = (Worksheet) workbook.Sheets["Stranica 1"];
                KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                adapter.Fill(dataSet);
                NewLateBinding.LateSetComplex(worksheet.Cells[5, 0x13], null, "Value", new object[] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]) }, null, null, false, true);
                worksheet.get_Range("M39", Missing.Value).set_Value(Missing.Value, "LKLKLK");
                worksheet.get_Range("M40", Missing.Value).set_Value(Missing.Value, "LKLKLK");
                worksheet.get_Range("M41", Missing.Value).set_Value(Missing.Value, "LKLKLK");
                worksheet.get_Range("M42", Missing.Value).set_Value(Missing.Value, "LKLKLK");
                worksheet.get_Range("R39", Missing.Value).set_Value(Missing.Value, "LKLKLK");
                worksheet.get_Range("R40", Missing.Value).set_Value(Missing.Value, "LKLKLK");
                worksheet.get_Range("R41", Missing.Value).set_Value(Missing.Value, "LKLKLK");
                worksheet.get_Range("R42", Missing.Value).set_Value(Missing.Value, "LKLKLK");
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                //application.Quit();
                //return;
            }

            SaveFileDialog dialog = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                FileName = "Smjenski_rad_",
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

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private CrystalReportViewer CrystalReportViewer1;

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

