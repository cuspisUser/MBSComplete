using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DDModule;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using mipsed.application.framework;
using Placa;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace DDModule.NetAdvantage.SmartParts
{
    [SmartPart]
    public class IDDSMARTPART : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IDDDataset ds = new IDDDataset();
        private string godinaisplate = null;
        private SmartPartInfoProvider infoProvider = new SmartPartInfoProvider();
        private string mjesecisplate = null;
        private SmartPartInfo smartPartInfo1 = new SmartPartInfo("IDD Obrazac", "IDDObrazac");

        public IDDSMARTPART()
        {
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
            this.CrystalReportViewer1 = new CrystalReportViewer();
            this.SuspendLayout();
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = Cursors.Arrow;
            this.CrystalReportViewer1.Dock = DockStyle.Fill;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.Size = new System.Drawing.Size(0x381, 0x25a);
            this.CrystalReportViewer1.TabIndex = 0;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Name = "IDDSMARTPART";
            this.Size = new System.Drawing.Size(0x381, 0x25a);
            this.ResumeLayout(false);
        }

        public void Otvori()
        {
            this.ds.Clear();
            ReportDocument document = new ReportDocument();
            frmDDPregledMjeseciGodina godina = new frmDDPregledMjeseciGodina();
            godina.ShowDialog();
            DataRow row = this.ds.test.NewRow();
            row["idtest"] = 0x63;
            this.ds.test.Rows.Add(row);
            if (godina.DialogResult != DialogResult.Cancel)
            {
                if ((godina.OdabraniGodinaIsplate != null) & (godina.OdabraniMjesecIsplate != null))
                {
                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja",
                        Description = "Pregled",
                        Icon = ImageResourcesNew.mbs
                    };
                    SqlConnection connection = new SqlConnection();
                    SqlCommand command = new SqlCommand {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "S_DD_IDD"
                    };
                    connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
                    command.Connection = connection;
                    SqlDataAdapter adapter2 = new SqlDataAdapter {
                        SelectCommand = command
                    };
                    adapter2.SelectCommand.Connection = connection;
                    command.Parameters.AddWithValue("@mjesecisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate));
                    command.Parameters.AddWithValue("@godinaisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniGodinaIsplate));
                    command.Parameters.AddWithValue("@KOLONA", 3);
                    adapter2.Fill(this.ds, "kolona3");
                    SqlCommand command2 = new SqlCommand {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "S_DD_IDD",
                        Connection = connection
                    };
                    SqlDataAdapter adapter3 = new SqlDataAdapter {
                        SelectCommand = command2
                    };
                    adapter3.SelectCommand.Connection = connection;
                    command2.Parameters.AddWithValue("@mjesecisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate));
                    command2.Parameters.AddWithValue("@godinaisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniGodinaIsplate));
                    command2.Parameters.AddWithValue("@KOLONA", 4);
                    adapter3.Fill(this.ds, "kolona4");
                    SqlCommand command3 = new SqlCommand {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "S_DD_IDD",
                        Connection = connection
                    };
                    SqlDataAdapter adapter4 = new SqlDataAdapter {
                        SelectCommand = command3
                    };
                    adapter4.SelectCommand.Connection = connection;
                    command3.Parameters.AddWithValue("@mjesecisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate));
                    command3.Parameters.AddWithValue("@godinaisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniGodinaIsplate));
                    command3.Parameters.AddWithValue("@KOLONA", 5);
                    adapter4.Fill(this.ds, "kolona5");
                    SqlCommand command4 = new SqlCommand {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "S_DD_IDD",
                        Connection = connection
                    };
                    SqlDataAdapter adapter5 = new SqlDataAdapter {
                        SelectCommand = command4
                    };
                    adapter5.SelectCommand.Connection = connection;
                    command4.Parameters.AddWithValue("@mjesecisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate));
                    command4.Parameters.AddWithValue("@godinaisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniGodinaIsplate));
                    command4.Parameters.AddWithValue("@KOLONA", 6);
                    adapter5.Fill(this.ds, "kolona6");
                    SqlCommand command5 = new SqlCommand {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "S_DD_IDD",
                        Connection = connection
                    };
                    SqlDataAdapter adapter6 = new SqlDataAdapter {
                        SelectCommand = command5
                    };
                    adapter6.SelectCommand.Connection = connection;
                    command5.Parameters.AddWithValue("@mjesecisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate));
                    command5.Parameters.AddWithValue("@godinaisplate", RuntimeHelpers.GetObjectValue(godina.OdabraniGodinaIsplate));
                    command5.Parameters.AddWithValue("@KOLONA", 7);
                    adapter6.Fill(this.ds, "kolona7");
                }
                this.mjesecisplate = string.Format("{0:00}", RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate));
                this.godinaisplate = string.Format("{0:0000}", RuntimeHelpers.GetObjectValue(godina.OdabraniGodinaIsplate));
                string str = DB.MjesecNazivDativ(Conversions.ToInteger(godina.OdabraniMjesecIsplate)).ToUpper() + " " + this.godinaisplate + ". godine";
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(dataSet);
                document.Load(System.Windows.Forms.Application.StartupPath + @"\ddIzvjestaji\idd2009.rpt");
                document.SetDataSource(this.ds);
                document.SetParameterValue("mjesecgodina", str);
                document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                document.SetParameterValue("sjediste", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], ", "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                document.SetParameterValue("porezni", dataSet.KORISNIK.Rows[0]["KORISNIKOIB"].ToString());
                this.CrystalReportViewer1.ReportSource = document;
            }
        }

        [LocalCommandHandler("OtvoriMjesecGodinu")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            this.Otvori();
        }

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        public CrystalReportViewer CrystalReportViewer1;

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

