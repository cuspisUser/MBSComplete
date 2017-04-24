using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using IDObrazacNamespace;
using IPKarticeNamespace;
using IPP;
using Microsoft.Office.Interop.Word;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.SmartParts;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using PlacaModule;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;


namespace PlacaModule.PlacaModule
{

    public class MainController : Controller
    {
        private string strMI = string.Empty;
        private string strGI = string.Empty;

        [CommandHandler("Placa.BANKECommand")]
        public void BANKECommand(object sender, EventArgs e)
        {
            BANKEWorkWithWorkItem item = this.WorkItem.Items.Get<BANKEWorkWithWorkItem>("Placa.BANKE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BANKEWorkWithWorkItem>("Placa.BANKE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("BazePodataka")]
        public void BazePodatakaCommandHandler(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterScreen,
                Modal = true,
                ControlBox = true,
                Title = "Servis - baze podataka",
                Icon = ImageResourcesNew.mbs
            };
            OdrzavanjeSmartPart smartPart = this.WorkItem.Items.AddNew<OdrzavanjeSmartPart>();
            this.WorkItem.RootWorkItem.Workspaces["window"].Show(smartPart, smartPartInfo);
        }

        [CommandHandler("Placa.BENEFICIRANICommand")]
        public void BENEFICIRANICommand(object sender, EventArgs e)
        {
            BENEFICIRANIWorkWithWorkItem item = this.WorkItem.Items.Get<BENEFICIRANIWorkWithWorkItem>("Placa.BENEFICIRANI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BENEFICIRANIWorkWithWorkItem>("Placa.BENEFICIRANI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Bolovanje")]
        public void BolovanjeCommandHandler(object sender, EventArgs e)
        {
            BolovanjeWorkItem item = this.WorkItem.Items.Get<BolovanjeWorkItem>("BolovanjeWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BolovanjeWorkItem>("BolovanjeWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BOLOVANJEFONDCommand")]
        public void BOLOVANJEFONDCommand(object sender, EventArgs e)
        {
            BOLOVANJEFONDWorkWithWorkItem item = this.WorkItem.Items.Get<BOLOVANJEFONDWorkWithWorkItem>("Placa.BOLOVANJEFOND");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BOLOVANJEFONDWorkWithWorkItem>("Placa.BOLOVANJEFOND");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BRACNOSTANJECommand")]
        public void BRACNOSTANJECommand(object sender, EventArgs e)
        {
            BRACNOSTANJEWorkWithWorkItem item = this.WorkItem.Items.Get<BRACNOSTANJEWorkWithWorkItem>("Placa.BRACNOSTANJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<BRACNOSTANJEWorkWithWorkItem>("Placa.BRACNOSTANJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.BrziUnosKreditaCommand")]
        public void BrziUnosKreditaCommandHandler(object sender, EventArgs e)
        {
            UnosKreditaWorkItem item = this.WorkItem.Items.Get<UnosKreditaWorkItem>("UnosKreditaWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UnosKreditaWorkItem>("UnosKreditaWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        private void CountUntilCancelledrad1g()
        {
            int num = 0;
            int num2 = 0;
            DataRow current;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            int num16 = 0;
            int num17 = 0;
            int num18 = 0;
            int num19 = 0;
            int num20 = 0;
            int num21 = 0;
            int num22 = 0;
            int num23 = 0;
            int num24 = 0;
            int num27 = 0;
            int num28 = 0;
            int num29 = 0;
            int num30 = 0;
            int num31 = 0;
            int num32 = 0;
            int num33 = 0;
            int num34 = 0;
            int num35 = 0;
            int num36 = 0;
            int num37 = 0;
            int num38 = 0;
            int num39 = 0;
            int num40 = 0;
            int num41 = 0;
            int num42 = 0;
            int num43 = 0;
            int num44 = 0;
            int num45 = 0;
            int num46 = 0;
            int num47 = 0;
            int num48 = 0;
            int num49 = 0;
            int num50 = 0;
            int num51 = 0;
            int num52 = 0;
            int num53 = 0;
            int num55 = 0;
            int num56 = 0;
            int num57 = 0;
            int num58 = 0;
            int num59 = 0;
            int num60 = 0;
            int num61 = 0;
            int num62 = 0;
            int num63 = 0;
            int num64 = 0;
            int num65 = 0;
            int num66 = 0;
            int num67 = 0;
            int num68 = 0;
            int num69 = 0;
            int num70 = 0;
            int num71 = 0;
            int num72 = 0;
            int num73 = 0;
            int num74 = 0;
            int num75 = 0;
            int num76 = 0;
            int num77 = 0;
            int num78 = 0;
            int num79 = 0;
            int num80 = 0;
            int num81 = 0;
            int num82 = 0;
            int num83 = 0;
            int num84 = 0;
            int num85 = 0;
            int num86 = 0;
            int num87 = 0;
            int num90 = 0;
            int num92 = 0;
            int num93 = 0;
            int num94 = 0;
            int num95 = 0;
            int num96 = 0;
            int num97 = 0;
            int num98 = 0;
            int num99 = 0;
            int num100 = 0;
            int num101 = 0;
            int num102 = 0;
            int num103 = 0;
            int num104 = 0;
            int num105 = 0;
            int num106 = 0;
            int num107 = 0;
            int num108 = 0;
            int num109 = 0;
            int num110 = 0;
            int num111 = 0;
            int num112 = 0;
            int num113 = 0;
            int num114 = 0;
            int num115 = 0;
            int num116 = 0;
            int num225 = 0;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            IEnumerator enumerator3 = null;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            string gODINAISPLATE = "2011";
            Microsoft.Office.Interop.Word.Application application = new ApplicationClass();
            Document document = new DocumentClass();
            application.Visible = false;

            object temp = System.Reflection.Missing.Value;

            object confirmConversions = true;
            object readOnly = true;

            object path = System.Windows.Forms.Application.StartupPath + @"\App_Data\RAD-1G2011.doc";
            document = application.Documents.Open(ref path, ref confirmConversions, ref readOnly, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp);
            document.ActiveWindow.View.ReadingLayout = false;

            S_PLACA_RAD1M_DIO1DataAdapter adapter = new S_PLACA_RAD1M_DIO1DataAdapter();
            S_PLACA_RAD1M_DIO1DataSet dataSet = new S_PLACA_RAD1M_DIO1DataSet();
            adapter.Fill(dataSet, "02", "2011");

            S_PLACA_RAD1GDataSet set2 = new S_PLACA_RAD1GDataSet();
            new S_PLACA_RAD1GDataAdapter().Fill(set2, gODINAISPLATE, "04", DateAndTime.DateSerial(Conversions.ToInteger(gODINAISPLATE), Conversions.ToInteger("03"), Conversions.ToInteger("31")), "03");

            S_PLACA_RAD1G_IIIDataSet set3 = new S_PLACA_RAD1G_IIIDataSet();
            new S_PLACA_RAD1G_IIIDataAdapter().Fill(set3, "04", "2011");

            S_PLACA_RAD1G_IVDataSet set4 = new S_PLACA_RAD1G_IVDataSet();
            new S_PLACA_RAD1G_IVDataAdapter().Fill(set4, "2010");

            S_PLACA_RAD1G_SATIDataSet set5 = new S_PLACA_RAD1G_SATIDataSet();
            new S_PLACA_RAD1G_SATIDataAdapter().Fill(set5, "2010");

            int num88 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataSet.Tables[0].Rows[0]["BROJRADNIKAUKUPNO"], dataSet.Tables[0].Rows[0]["BROJDOSLIH"]), Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJOTISLIH"])));
            int num89 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataSet.Tables[0].Rows[0]["BROJZENA"], dataSet.Tables[0].Rows[0]["BROJDOSLIHZENA"]), dataSet.Tables[0].Rows[0]["BROJOTISLIHZENA"]));
            int startIndex = 0;
            do
            {
                document.Tables[4].Cell(2, 4 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJRADNIKAUKUPNO"]).ToString(), 4, 0, false, "").Substring(startIndex, 1);
                startIndex++;
            }
            while (startIndex <= 3);
            int num118 = 0;
            do
            {
                document.Tables[4].Cell(2, 8 + num118).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJZENA"]).ToString(), 4, 0, false, "").Substring(num118, 1);
                num118++;
            }
            while (num118 <= 3);
            int num119 = 0;
            do
            {
                document.Tables[4].Cell(3, 3 + num119).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJDOSLIH"]).ToString(), 4, 0, false, "").Substring(num119, 1);
                num119++;
            }
            while (num119 <= 3);
            int num120 = 0;
            do
            {
                document.Tables[4].Cell(3, 7 + num120).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJDOSLIHZENA"]).ToString(), 4, 0, false, "").Substring(num120, 1);
                num120++;
            }
            while (num120 <= 3);
            int num121 = 0;
            do
            {
                document.Tables[4].Cell(4, 3 + num121).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJOTISLIH"]).ToString(), 4, 0, false, "").Substring(num121, 1);
                num121++;
            }
            while (num121 <= 3);
            int num122 = 0;
            do
            {
                document.Tables[4].Cell(4, 7 + num122).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJOTISLIHZENA"]).ToString(), 4, 0, false, "").Substring(num122, 1);
                num122++;
            }
            while (num122 <= 3);
            int num123 = 0;
            do
            {
                document.Tables[4].Cell(5, 3 + num123).Range.Text = DB.BrojVodecePraznine(num88.ToString(), 4, 0, false, "").Substring(num123, 1);
                num123++;
            }
            while (num123 <= 3);
            int num124 = 0;
            do
            {
                document.Tables[4].Cell(5, 7 + num124).Range.Text = DB.BrojVodecePraznine(num89.ToString(), 4, 0, false, "").Substring(num124, 1);
                num124++;
            }
            while (num124 <= 3);
            try
            {
                enumerator = set2.S_PLACA_RAD1G.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTARADNOGODNOSA"], "NE", false))
                    {
                        num53 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKAZENA"], num53));
                        num52 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKA"], num52));
                    }
                    else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTARADNOGODNOSA"], "OD", false))
                    {
                        num58 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKAZENA"], num58));
                        num57 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKA"], num57));
                    }
                    else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTARADNOGODNOSA"], "PR", false))
                    {
                        num64 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKAZENA"], num64));
                        num63 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKA"], num63));
                    }
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["RADNOVRIJEME"], "P", false))
                    {
                        num66 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKAZENA"], num66));
                        num65 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKA"], num65));
                    }
                    else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["RADNOVRIJEME"], "N", false))
                    {
                        num56 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKAZENA"], num56));
                        num55 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKA"], num55));
                    }
                    else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["RADNOVRIJEME"], "S", false))
                    {
                        num90 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKAZENA"], num90));
                        num87 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BROJRADNIKA"], num87));
                    }
                    object left = current["GODINASTAROSTI"];
                    if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 0, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x12, false))))
                    {
                        num3 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num3, current["BROJRADNIKA"]));
                        num4 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num4, current["BROJRADNIKAZENA"]));
                    }
                    else
                    {
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 0x13, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x18, false))))
                        {
                            num5 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num5, current["BROJRADNIKA"]));
                            num6 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num6, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 0x19, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x1d, false))))
                        {
                            num7 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num7, current["BROJRADNIKA"]));
                            num8 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num8, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 30, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x22, false))))
                        {
                            num9 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num9, current["BROJRADNIKA"]));
                            num10 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num10, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 0x23, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x27, false))))
                        {
                            num11 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num11, current["BROJRADNIKA"]));
                            num12 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num12, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 40, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x2c, false))))
                        {
                            num13 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num13, current["BROJRADNIKA"]));
                            num14 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num14, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 0x2d, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x31, false))))
                        {
                            num15 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num15, current["BROJRADNIKA"]));
                            num16 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num16, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 50, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x36, false))))
                        {
                            num17 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num17, current["BROJRADNIKA"]));
                            num18 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num18, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 0x37, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x3b, false))))
                        {
                            num19 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num19, current["BROJRADNIKA"]));
                            num20 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num20, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(left, 60, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(left, 0x40, false))))
                        {
                            num21 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num21, current["BROJRADNIKA"]));
                            num22 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num22, current["BROJRADNIKAZENA"]));
                            continue;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(left, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(current["GODINASTAROSTI"], 0x41, false), false))
                        {
                            num23 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num23, current["BROJRADNIKA"]));
                            num24 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num24, current["BROJRADNIKAZENA"]));
                        }
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
            int num125 = 0;
            do
            {
                num225 = (num52 + num57) + num63;
                document.Tables[5].Cell(2, 3 + num125).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 4, 0, false, "").Substring(num125, 1);
                num125++;
            }
            while (num125 <= 3);
            int num126 = 0;
            do
            {
                num225 = (num53 + num58) + num64;
                document.Tables[5].Cell(2, 7 + num126).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 4, 0, false, "").Substring(num126, 1);
                num126++;
            }
            while (num126 <= 3);
            int num127 = 0;
            do
            {
                document.Tables[5].Cell(3, 3 + num127).Range.Text = DB.BrojVodecePraznine(num52.ToString(), 4, 0, false, "").Substring(num127, 1);
                num127++;
            }
            while (num127 <= 3);
            int num128 = 0;
            do
            {
                document.Tables[5].Cell(3, 7 + num128).Range.Text = DB.BrojVodecePraznine(num53.ToString(), 4, 0, false, "").Substring(num128, 1);
                num128++;
            }
            while (num128 <= 3);
            int num129 = 0;
            do
            {
                document.Tables[5].Cell(4, 3 + num129).Range.Text = DB.BrojVodecePraznine(num57.ToString(), 4, 0, false, "").Substring(num129, 1);
                num129++;
            }
            while (num129 <= 3);
            int num130 = 0;
            do
            {
                document.Tables[5].Cell(4, 7 + num130).Range.Text = DB.BrojVodecePraznine(num58.ToString(), 4, 0, false, "").Substring(num130, 1);
                num130++;
            }
            while (num130 <= 3);
            int num131 = 0;
            do
            {
                document.Tables[5].Cell(5, 3 + num131).Range.Text = DB.BrojVodecePraznine(num63.ToString(), 4, 0, false, "").Substring(num131, 1);
                num131++;
            }
            while (num131 <= 3);
            int num132 = 0;
            do
            {
                document.Tables[5].Cell(5, 7 + num132).Range.Text = DB.BrojVodecePraznine(num64.ToString(), 4, 0, false, "").Substring(num132, 1);
                num132++;
            }
            while (num132 <= 3);
            int num133 = 0;
            do
            {
                num225 = (num65 + num55) + num87;
                document.Tables[6].Cell(2, 3 + num133).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 4, 0, false, "").Substring(num133, 1);
                num133++;
            }
            while (num133 <= 3);
            int num134 = 0;
            do
            {
                num225 = (num66 + num56) + num90;
                document.Tables[6].Cell(2, 7 + num134).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 4, 0, false, "").Substring(num134, 1);
                num134++;
            }
            while (num134 <= 3);
            int num135 = 0;
            do
            {
                document.Tables[6].Cell(3, 3 + num135).Range.Text = DB.BrojVodecePraznine(num65.ToString(), 4, 0, false, "").Substring(num135, 1);
                num135++;
            }
            while (num135 <= 3);
            int num136 = 0;
            do
            {
                document.Tables[6].Cell(3, 7 + num136).Range.Text = DB.BrojVodecePraznine(num66.ToString(), 4, 0, false, "").Substring(num136, 1);
                num136++;
            }
            while (num136 <= 3);
            int num137 = 0;
            do
            {
                document.Tables[6].Cell(4, 3 + num137).Range.Text = DB.BrojVodecePraznine(num55.ToString(), 4, 0, false, "").Substring(num137, 1);
                num137++;
            }
            while (num137 <= 3);
            int num138 = 0;
            do
            {
                document.Tables[6].Cell(4, 7 + num138).Range.Text = DB.BrojVodecePraznine(num56.ToString(), 4, 0, false, "").Substring(num138, 1);
                num138++;
            }
            while (num138 <= 3);
            int num139 = 0;
            do
            {
                document.Tables[6].Cell(5, 3 + num139).Range.Text = DB.BrojVodecePraznine(num87.ToString(), 4, 0, false, "").Substring(num139, 1);
                num139++;
            }
            while (num139 <= 3);
            int num140 = 0;
            do
            {
                document.Tables[6].Cell(5, 7 + num140).Range.Text = DB.BrojVodecePraznine(num90.ToString(), 4, 0, false, "").Substring(num140, 1);
                num140++;
            }
            while (num140 <= 3);
            try
            {
                enumerator2 = set3.S_PLACA_RAD1G_III.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    current = (DataRow) enumerator2.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(current["satibruto"], 160, false))
                    {
                        num27++;
                    }
                    else
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["satibruto"], 200, false))
                        {
                            num92++;
                            continue;
                        }
                        object obj19 = current["netoplaca"];
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x640, false))))
                        {
                            num80++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x641, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x76c, false))))
                        {
                            num81++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x76d, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x898, false))))
                        {
                            num82++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x899, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x9c4, false))))
                        {
                            num83++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x9c5, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0xaf0, false))))
                        {
                            num84++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0xaf1, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0xc1c, false))))
                        {
                            num85++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0xc1d, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0xd48, false))))
                        {
                            num86++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0xd49, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0xe74, false))))
                        {
                            num67++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0xe75, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0xfa0, false))))
                        {
                            num68++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0xfa1, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x1194, false))))
                        {
                            num69++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x1195, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x1388, false))))
                        {
                            num70++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x1389, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x157c, false))))
                        {
                            num71++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x157d, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x1770, false))))
                        {
                            num72++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x1771, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x1f40, false))))
                        {
                            num73++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x1f41, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x2710, false))))
                        {
                            num74++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x2711, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x2ee0, false))))
                        {
                            num75++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x2ee1, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x36b0, false))))
                        {
                            num76++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x36b1, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x3e80, false))))
                        {
                            num77++;
                            continue;
                        }
                        if (Conversions.ToBoolean(Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(obj19, 0x3e81, false)) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(obj19, 0x5208, false))))
                        {
                            num78++;
                            continue;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj19, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(current["netoplaca"], 0x5209, false), false))
                        {
                            num79++;
                        }
                    }
                }
            }
            finally
            {
                if (enumerator2 is IDisposable)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
            }
            int vBroj = ((((((((((((((((((((num80 + num81) + num82) + num83) + num84) + num85) + num86) + num67) + num68) + num69) + num70) + num71) + num72) + num73) + num74) + num75) + num76) + num77) + num78) + num79) + num27) + num92;
            int num141 = 0;
            do
            {
                document.Tables[7].Cell(1, 4 + num141).Range.Text = DB.BrojVodecePraznine(vBroj, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(3, 3 + num141).Range.Text = DB.BrojVodecePraznine(num27, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(4, 5 + num141).Range.Text = DB.BrojVodecePraznine(num80, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(5, 5 + num141).Range.Text = DB.BrojVodecePraznine(num81, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(6, 5 + num141).Range.Text = DB.BrojVodecePraznine(num82, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(7, 5 + num141).Range.Text = DB.BrojVodecePraznine(num83, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(8, 5 + num141).Range.Text = DB.BrojVodecePraznine(num84, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(9, 5 + num141).Range.Text = DB.BrojVodecePraznine(num85, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(10, 5 + num141).Range.Text = DB.BrojVodecePraznine(num86, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(11, 5 + num141).Range.Text = DB.BrojVodecePraznine(num67, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(12, 5 + num141).Range.Text = DB.BrojVodecePraznine(num68, 4, 0, false, "").Substring(num141, 1);
                document.Tables[7].Cell(13, 5 + num141).Range.Text = DB.BrojVodecePraznine(num69, 4, 0, false, "").Substring(num141, 1);
                num141++;
            }
            while (num141 <= 3);
            int num142 = 0;
            do
            {
                document.Tables[8].Cell(1, 5 + num142).Range.Text = DB.BrojVodecePraznine(num70, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(2, 5 + num142).Range.Text = DB.BrojVodecePraznine(num71, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(3, 5 + num142).Range.Text = DB.BrojVodecePraznine(num72, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(4, 5 + num142).Range.Text = DB.BrojVodecePraznine(num73, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(5, 5 + num142).Range.Text = DB.BrojVodecePraznine(num74, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(6, 5 + num142).Range.Text = DB.BrojVodecePraznine(num75, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(7, 5 + num142).Range.Text = DB.BrojVodecePraznine(num76, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(8, 5 + num142).Range.Text = DB.BrojVodecePraznine(num77, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(9, 5 + num142).Range.Text = DB.BrojVodecePraznine(num78, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(10, 5 + num142).Range.Text = DB.BrojVodecePraznine(num79, 4, 0, false, "").Substring(num142, 1);
                document.Tables[8].Cell(11, 4 + num142).Range.Text = DB.BrojVodecePraznine(num92, 4, 0, false, "").Substring(num142, 1);
                num142++;
            }
            while (num142 <= 3);
            try
            {
                enumerator3 = set4.S_PLACA_RAD1G_IV.Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    current = (DataRow) enumerator3.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["SPOL"], "M", false))
                    {
                        num++;
                        num59 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BRUTOPLACA"], num59));
                        num61 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["NETOPLACA"], num61));
                        object obj20 = current["SPREMA"];
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "VSS", false))
                        {
                            num49++;
                            num50 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num50, current["BRUTOPLACA"]));
                            num51 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num51, current["NETOPLACA"]));
                        }
                        else
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "VIS", false))
                            {
                                num43++;
                                num44 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num44, current["BRUTOPLACA"]));
                                num45 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num45, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "SSS", false))
                            {
                                num40++;
                                num41 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num41, current["BRUTOPLACA"]));
                                num42 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num42, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "NSS", false))
                            {
                                num34++;
                                num35 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num35, current["BRUTOPLACA"]));
                                num36 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num36, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "VKV", false))
                            {
                                num46++;
                                num47 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num47, current["BRUTOPLACA"]));
                                num48 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num48, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "KV", false))
                            {
                                num28++;
                                num29 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num29, current["BRUTOPLACA"]));
                                num30 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num30, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "PKV", false))
                            {
                                num37++;
                                num38 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num38, current["BRUTOPLACA"]));
                                num39 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num39, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, "NKV", false))
                            {
                                num31++;
                                num32 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num32, current["BRUTOPLACA"]));
                                num33 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num33, current["NETOPLACA"]));
                            }
                            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj20, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SPREMA"], "NERASP", false), false))
                            {
                            }
                        }
                    }
                    else
                    {
                        num2++;
                        num60 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["BRUTOPLACA"], num60));
                        num62 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(current["NETOPLACA"], num62));
                        object obj21 = current["SPREMA"];
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "VSS", false))
                        {
                            num114++;
                            num115 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num115, current["BRUTOPLACA"]));
                            num116 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num116, current["NETOPLACA"]));
                        }
                        else
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "VIS", false))
                            {
                                num108++;
                                num109 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num109, current["BRUTOPLACA"]));
                                num110 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num110, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "SSS", false))
                            {
                                num105++;
                                num106 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num106, current["BRUTOPLACA"]));
                                num107 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num107, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "NSS", false))
                            {
                                num99++;
                                num100 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num100, current["BRUTOPLACA"]));
                                num101 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num101, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "VKV", false))
                            {
                                num111++;
                                num112 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num112, current["BRUTOPLACA"]));
                                num113 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num113, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "KV", false))
                            {
                                num93++;
                                num94 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num94, current["BRUTOPLACA"]));
                                num95 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num95, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "PKV", false))
                            {
                                num102++;
                                num103 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num103, current["BRUTOPLACA"]));
                                num104 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num104, current["NETOPLACA"]));
                                continue;
                            }
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "NKV", false))
                            {
                                num96++;
                                num97 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num97, current["BRUTOPLACA"]));
                                num98 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num98, current["NETOPLACA"]));
                                continue;
                            }
                            Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(obj21, "NERASP", false);
                        }
                    }
                }
            }
            finally
            {
                if (enumerator3 is IDisposable)
                {
                    (enumerator3 as IDisposable).Dispose();
                }
            }
            int num143 = 0;
            do
            {
                num225 = num60 + num59;
                document.Tables[9].Cell(3, 4 + num143).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num143, 1);
                num143++;
            }
            while (num143 <= 8);
            int num144 = 0;
            do
            {
                num225 = num62 + num61;
                document.Tables[9].Cell(3, 13 + num144).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num144, 1);
                num144++;
            }
            while (num144 <= 8);
            int num145 = 0;
            do
            {
                num225 = num2 + num;
                document.Tables[9].Cell(3, 0x16 + num145).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num145, 1);
                num145++;
            }
            while (num145 <= 4);
            int num146 = 0;
            do
            {
                document.Tables[9].Cell(5, 3 + num146).Range.Text = DB.BrojVodecePraznine(num59.ToString(), 9, 0, false, "").Substring(num146, 1);
                num146++;
            }
            while (num146 <= 8);
            int num147 = 0;
            do
            {
                document.Tables[9].Cell(5, 12 + num147).Range.Text = DB.BrojVodecePraznine(num61.ToString(), 9, 0, false, "").Substring(num147, 1);
                num147++;
            }
            while (num147 <= 8);
            int num148 = 0;
            do
            {
                document.Tables[9].Cell(5, 0x15 + num148).Range.Text = DB.BrojVodecePraznine(num.ToString(), 5, 0, false, "").Substring(num148, 1);
                num148++;
            }
            while (num148 <= 4);
            int num149 = 0;
            do
            {
                document.Tables[9].Cell(6, 3 + num149).Range.Text = DB.BrojVodecePraznine(num60.ToString(), 9, 0, false, "").Substring(num149, 1);
                num149++;
            }
            while (num149 <= 8);
            int num150 = 0;
            do
            {
                document.Tables[9].Cell(6, 12 + num150).Range.Text = DB.BrojVodecePraznine(num62.ToString(), 9, 0, false, "").Substring(num150, 1);
                num150++;
            }
            while (num150 <= 8);
            int num151 = 0;
            do
            {
                document.Tables[9].Cell(6, 0x15 + num151).Range.Text = DB.BrojVodecePraznine(num2.ToString(), 5, 0, false, "").Substring(num151, 1);
                num151++;
            }
            while (num151 <= 4);
            int num152 = 0;
            do
            {
                num225 = num50 + num115;
                document.Tables[9].Cell(7, 4 + num152).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num152, 1);
                num152++;
            }
            while (num152 <= 8);
            int num153 = 0;
            do
            {
                num225 = num51 + num116;
                document.Tables[9].Cell(7, 13 + num153).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num153, 1);
                num153++;
            }
            while (num153 <= 8);
            int num154 = 0;
            do
            {
                num225 = num49 + num114;
                document.Tables[9].Cell(7, 0x16 + num154).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num154, 1);
                num154++;
            }
            while (num154 <= 4);
            int num155 = 0;
            do
            {
                num225 = num44 + num109;
                document.Tables[9].Cell(9, 3 + num155).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num155, 1);
                num155++;
            }
            while (num155 <= 8);
            int num156 = 0;
            do
            {
                num225 = num110 + num45;
                document.Tables[9].Cell(9, 12 + num156).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num156, 1);
                num156++;
            }
            while (num156 <= 8);
            int num157 = 0;
            do
            {
                num225 = num43 + num108;
                document.Tables[9].Cell(9, 0x15 + num157).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num157, 1);
                num157++;
            }
            while (num157 <= 4);
            int num158 = 0;
            do
            {
                num225 = num41 + num106;
                document.Tables[9].Cell(11, 3 + num158).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num158, 1);
                num158++;
            }
            while (num158 <= 8);
            int num159 = 0;
            do
            {
                num225 = num42 + num107;
                document.Tables[9].Cell(11, 12 + num159).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num159, 1);
                num159++;
            }
            while (num159 <= 8);
            int num160 = 0;
            do
            {
                num225 = num40 + num105;
                document.Tables[9].Cell(11, 0x15 + num160).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num160, 1);
                num160++;
            }
            while (num160 <= 4);
            int num161 = 0;
            do
            {
                num225 = num35 + num100;
                document.Tables[9].Cell(12, 3 + num161).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num161, 1);
                num161++;
            }
            while (num161 <= 8);
            int num162 = 0;
            do
            {
                num225 = num101 + num36;
                document.Tables[9].Cell(12, 12 + num162).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num162, 1);
                num162++;
            }
            while (num162 <= 8);
            int num163 = 0;
            do
            {
                num225 = num99 + num34;
                document.Tables[9].Cell(12, 0x15 + num163).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num163, 1);
                num163++;
            }
            while (num163 <= 4);
            int num164 = 0;
            do
            {
                num225 = num47 + num112;
                document.Tables[9].Cell(13, 4 + num164).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num164, 1);
                num164++;
            }
            while (num164 <= 8);
            int num165 = 0;
            do
            {
                num225 = num48 + num113;
                document.Tables[9].Cell(13, 13 + num165).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num165, 1);
                num165++;
            }
            while (num165 <= 8);
            int num166 = 0;
            do
            {
                num225 = num111 + num46;
                document.Tables[9].Cell(13, 0x16 + num166).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num166, 1);
                num166++;
            }
            while (num166 <= 4);
            int num167 = 0;
            do
            {
                num225 = num29 + num94;
                document.Tables[9].Cell(15, 3 + num167).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num167, 1);
                num167++;
            }
            while (num167 <= 8);
            int num168 = 0;
            do
            {
                num225 = num30 + num95;
                document.Tables[9].Cell(15, 12 + num168).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num168, 1);
                num168++;
            }
            while (num168 <= 8);
            int num169 = 0;
            do
            {
                num225 = num28 + num93;
                document.Tables[9].Cell(15, 0x15 + num169).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num169, 1);
                num169++;
            }
            while (num169 <= 4);
            int num170 = 0;
            do
            {
                num225 = num38 + num103;
                document.Tables[9].Cell(0x11, 3 + num170).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num170, 1);
                num170++;
            }
            while (num170 <= 8);
            int num171 = 0;
            do
            {
                num225 = num39 + num104;
                document.Tables[9].Cell(0x11, 12 + num171).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num171, 1);
                num171++;
            }
            while (num171 <= 8);
            int num172 = 0;
            do
            {
                num225 = num37 + num102;
                document.Tables[9].Cell(0x11, 0x15 + num172).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num172, 1);
                num172++;
            }
            while (num172 <= 4);
            int num173 = 0;
            do
            {
                num225 = num32 + num97;
                document.Tables[9].Cell(0x12, 3 + num173).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num173, 1);
                num173++;
            }
            while (num173 <= 8);
            int num174 = 0;
            do
            {
                num225 = num33 + num98;
                document.Tables[9].Cell(0x12, 12 + num174).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 9, 0, false, "").Substring(num174, 1);
                num174++;
            }
            while (num174 <= 8);
            int num175 = 0;
            do
            {
                num225 = num96 + num31;
                document.Tables[9].Cell(0x12, 0x15 + num175).Range.Text = DB.BrojVodecePraznine(num225.ToString(), 5, 0, false, "").Substring(num175, 1);
                num175++;
            }
            while (num175 <= 4);
            int num25 = (set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "") != DBNull.Value ? Conversions.ToInteger(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "")) : 0);
            int num26 = (set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "") != DBNull.Value ? Conversions.ToInteger(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "")) : 0);
            int num176 = 0;
            do
            {
                document.Tables[10].Cell(2, 4 + num176).Range.Text = DB.BrojVodecePraznine(num25.ToString(), 4, 0, false, "").Substring(num176, 1);
                num176++;
            }
            while (num176 <= 3);
            int num177 = 0;
            do
            {
                document.Tables[10].Cell(2, 8 + num177).Range.Text = DB.BrojVodecePraznine(num26.ToString(), 4, 0, false, "").Substring(num177, 1);
                num177++;
            }
            while (num177 <= 3);
            int num178 = 0;
            do
            {
                document.Tables[10].Cell(3, 3 + num178).Range.Text = DB.BrojVodecePraznine(num3.ToString(), 4, 0, false, "").Substring(num178, 1);
                num178++;
            }
            while (num178 <= 3);
            int num179 = 0;
            do
            {
                document.Tables[10].Cell(3, 7 + num179).Range.Text = DB.BrojVodecePraznine(num4.ToString(), 4, 0, false, "").Substring(num179, 1);
                num179++;
            }
            while (num179 <= 3);
            int num180 = 0;
            do
            {
                document.Tables[10].Cell(4, 3 + num180).Range.Text = DB.BrojVodecePraznine(num5.ToString(), 4, 0, false, "").Substring(num180, 1);
                num180++;
            }
            while (num180 <= 3);
            int num181 = 0;
            do
            {
                document.Tables[10].Cell(4, 7 + num181).Range.Text = DB.BrojVodecePraznine(num6.ToString(), 4, 0, false, "").Substring(num181, 1);
                num181++;
            }
            while (num181 <= 3);
            int num182 = 0;
            do
            {
                document.Tables[10].Cell(5, 3 + num182).Range.Text = DB.BrojVodecePraznine(num7.ToString(), 4, 0, false, "").Substring(num182, 1);
                num182++;
            }
            while (num182 <= 3);
            int num183 = 0;
            do
            {
                document.Tables[10].Cell(5, 7 + num183).Range.Text = DB.BrojVodecePraznine(num8.ToString(), 4, 0, false, "").Substring(num183, 1);
                num183++;
            }
            while (num183 <= 3);
            int num184 = 0;
            do
            {
                document.Tables[10].Cell(6, 3 + num184).Range.Text = DB.BrojVodecePraznine(num9.ToString(), 4, 0, false, "").Substring(num184, 1);
                num184++;
            }
            while (num184 <= 3);
            int num185 = 0;
            do
            {
                document.Tables[10].Cell(6, 7 + num185).Range.Text = DB.BrojVodecePraznine(num10.ToString(), 4, 0, false, "").Substring(num185, 1);
                num185++;
            }
            while (num185 <= 3);
            int num186 = 0;
            do
            {
                document.Tables[10].Cell(7, 3 + num186).Range.Text = DB.BrojVodecePraznine(num11.ToString(), 4, 0, false, "").Substring(num186, 1);
                num186++;
            }
            while (num186 <= 3);
            int num187 = 0;
            do
            {
                document.Tables[10].Cell(7, 7 + num187).Range.Text = DB.BrojVodecePraznine(num12.ToString(), 4, 0, false, "").Substring(num187, 1);
                num187++;
            }
            while (num187 <= 3);
            int num188 = 0;
            do
            {
                document.Tables[10].Cell(8, 3 + num188).Range.Text = DB.BrojVodecePraznine(num13.ToString(), 4, 0, false, "").Substring(num188, 1);
                num188++;
            }
            while (num188 <= 3);
            int num189 = 0;
            do
            {
                document.Tables[10].Cell(8, 7 + num189).Range.Text = DB.BrojVodecePraznine(num14.ToString(), 4, 0, false, "").Substring(num189, 1);
                num189++;
            }
            while (num189 <= 3);
            int num190 = 0;
            do
            {
                document.Tables[10].Cell(9, 3 + num190).Range.Text = DB.BrojVodecePraznine(num15.ToString(), 4, 0, false, "").Substring(num190, 1);
                num190++;
            }
            while (num190 <= 3);
            int num191 = 0;
            do
            {
                document.Tables[10].Cell(9, 7 + num191).Range.Text = DB.BrojVodecePraznine(num16.ToString(), 4, 0, false, "").Substring(num191, 1);
                num191++;
            }
            while (num191 <= 3);
            int num192 = 0;
            do
            {
                document.Tables[10].Cell(10, 3 + num192).Range.Text = DB.BrojVodecePraznine(num17.ToString(), 4, 0, false, "").Substring(num192, 1);
                num192++;
            }
            while (num192 <= 3);
            int num193 = 0;
            do
            {
                document.Tables[10].Cell(10, 7 + num193).Range.Text = DB.BrojVodecePraznine(num18.ToString(), 4, 0, false, "").Substring(num193, 1);
                num193++;
            }
            while (num193 <= 3);
            int num194 = 0;
            do
            {
                document.Tables[10].Cell(11, 3 + num194).Range.Text = DB.BrojVodecePraznine(num19.ToString(), 4, 0, false, "").Substring(num194, 1);
                num194++;
            }
            while (num194 <= 3);
            int num195 = 0;
            do
            {
                document.Tables[10].Cell(11, 7 + num195).Range.Text = DB.BrojVodecePraznine(num20.ToString(), 4, 0, false, "").Substring(num195, 1);
                num195++;
            }
            while (num195 <= 3);
            int num196 = 0;
            do
            {
                document.Tables[10].Cell(12, 3 + num196).Range.Text = DB.BrojVodecePraznine(num21.ToString(), 4, 0, false, "").Substring(num196, 1);
                num196++;
            }
            while (num196 <= 3);
            int num197 = 0;
            do
            {
                document.Tables[10].Cell(12, 7 + num197).Range.Text = DB.BrojVodecePraznine(num22.ToString(), 4, 0, false, "").Substring(num197, 1);
                num197++;
            }
            while (num197 <= 3);
            int num198 = 0;
            do
            {
                document.Tables[10].Cell(13, 3 + num198).Range.Text = DB.BrojVodecePraznine(num23.ToString(), 4, 0, false, "").Substring(num198, 1);
                num198++;
            }
            while (num198 <= 3);
            int num199 = 0;
            do
            {
                document.Tables[10].Cell(13, 7 + num199).Range.Text = DB.BrojVodecePraznine(num24.ToString(), 4, 0, false, "").Substring(num199, 1);
                num199++;
            }
            while (num199 <= 3);
            int num200 = 0;
            do
            {
                document.Tables[11].Cell(2, 4 + num200).Range.Text = DB.BrojVodecePraznine(num25.ToString(), 4, 0, false, "").Substring(num200, 1);
                num200++;
            }
            while (num200 <= 3);
            int num201 = 0;
            do
            {
                document.Tables[11].Cell(2, 8 + num201).Range.Text = DB.BrojVodecePraznine(num26.ToString(), 4, 0, false, "").Substring(num201, 1);
                num201++;
            }
            while (num201 <= 3);
            int num202 = 0;
            do
            {
                document.Tables[11].Cell(3, 4 + num202).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'VSS'"))).ToString(), 4, 0, false, "").Substring(num202, 1);
                num202++;
            }
            while (num202 <= 3);
            int num203 = 0;
            do
            {
                document.Tables[11].Cell(3, 8 + num203).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'VSS'"))).ToString(), 4, 0, false, "").Substring(num203, 1);
                num203++;
            }
            while (num203 <= 3);
            int num204 = 0;
            do
            {
                document.Tables[11].Cell(4, 4 + num204).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'VIS'"))).ToString(), 4, 0, false, "").Substring(num204, 1);
                num204++;
            }
            while (num204 <= 3);
            int num205 = 0;
            do
            {
                document.Tables[11].Cell(4, 8 + num205).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'VIS'"))).ToString(), 4, 0, false, "").Substring(num205, 1);
                num205++;
            }
            while (num205 <= 3);
            int num206 = 0;
            do
            {
                document.Tables[11].Cell(5, 4 + num206).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'SSS'"))).ToString(), 4, 0, false, "").Substring(num206, 1);
                num206++;
            }
            while (num206 <= 3);
            int num207 = 0;
            do
            {
                document.Tables[11].Cell(5, 8 + num207).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'SSS'"))).ToString(), 4, 0, false, "").Substring(num207, 1);
                num207++;
            }
            while (num207 <= 3);
            int num208 = 0;
            do
            {
                document.Tables[11].Cell(6, 4 + num208).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'NSS'"))).ToString(), 4, 0, false, "").Substring(num208, 1);
                num208++;
            }
            while (num208 <= 3);
            int num209 = 0;
            do
            {
                document.Tables[11].Cell(6, 8 + num209).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'NSS'"))).ToString(), 4, 0, false, "").Substring(num209, 1);
                num209++;
            }
            while (num209 <= 3);
            int num210 = 0;
            do
            {
                document.Tables[11].Cell(7, 4 + num210).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'VKV'"))).ToString(), 4, 0, false, "").Substring(num210, 1);
                num210++;
            }
            while (num210 <= 3);
            int num211 = 0;
            do
            {
                document.Tables[11].Cell(7, 8 + num211).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'VKV'"))).ToString(), 4, 0, false, "").Substring(num211, 1);
                num211++;
            }
            while (num211 <= 3);
            int num212 = 0;
            do
            {
                document.Tables[11].Cell(8, 4 + num212).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'KV'"))).ToString(), 4, 0, false, "").Substring(num212, 1);
                num212++;
            }
            while (num212 <= 3);
            int num213 = 0;
            do
            {
                document.Tables[11].Cell(8, 8 + num213).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'KV'"))).ToString(), 4, 0, false, "").Substring(num213, 1);
                num213++;
            }
            while (num213 <= 3);
            int num214 = 0;
            do
            {
                document.Tables[11].Cell(9, 4 + num214).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'PKV'"))).ToString(), 4, 0, false, "").Substring(num214, 1);
                num214++;
            }
            while (num214 <= 3);
            int num215 = 0;
            do
            {
                document.Tables[11].Cell(9, 8 + num215).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'PKV'"))).ToString(), 4, 0, false, "").Substring(num215, 1);
                num215++;
            }
            while (num215 <= 3);
            int num216 = 0;
            do
            {
                document.Tables[11].Cell(10, 4 + num216).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKA)", "SPREMA = 'NKV'"))).ToString(), 4, 0, false, "").Substring(num216, 1);
                num216++;
            }
            while (num216 <= 3);
            int num217 = 0;
            do
            {
                document.Tables[11].Cell(10, 8 + num217).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set2.S_PLACA_RAD1G.Compute("SUM(BROJRADNIKAZENA)", "SPREMA = 'NKV'"))).ToString(), 4, 0, false, "").Substring(num217, 1);
                num217++;
            }
            while (num217 <= 3);
            int vNumber = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(set5.S_PLACA_RAD1G_SATI.Rows[0]["IZV"], set5.S_PLACA_RAD1G_SATI.Rows[0]["NEIZV"]), set5.S_PLACA_RAD1G_SATI.Rows[0]["NEIZVIZVAN"]), set5.S_PLACA_RAD1G_SATI.Rows[0]["NEPLACENI"]), set5.S_PLACA_RAD1G_SATI.Rows[0]["PREKOVREMENI"]), set5.S_PLACA_RAD1G_SATI.Rows[0]["STRAJK"]));
            int num218 = 0;
            do
            {
                document.Tables[12].Cell(2, 4 + num218).Range.Text = DB.BrojVodecePraznine(DB.N20(vNumber).ToString(), 8, 0, false, "").Substring(num218, 1);
                num218++;
            }
            while (num218 <= 7);
            int num219 = 0;
            do
            {
                document.Tables[12].Cell(3, 4 + num219).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set5.S_PLACA_RAD1G_SATI.Rows[0]["IZV"])).ToString(), 8, 0, false, "").Substring(num219, 1);
                num219++;
            }
            while (num219 <= 7);
            int num220 = 0;
            do
            {
                document.Tables[12].Cell(4, 4 + num220).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set5.S_PLACA_RAD1G_SATI.Rows[0]["NEIZV"])).ToString(), 8, 0, false, "").Substring(num220, 1);
                num220++;
            }
            while (num220 <= 7);
            int num221 = 0;
            do
            {
                document.Tables[12].Cell(5, 4 + num221).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set5.S_PLACA_RAD1G_SATI.Rows[0]["NEIZVIZVAN"])).ToString(), 8, 0, false, "").Substring(num221, 1);
                num221++;
            }
            while (num221 <= 7);
            int num222 = 0;
            do
            {
                document.Tables[12].Cell(6, 4 + num222).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set5.S_PLACA_RAD1G_SATI.Rows[0]["NEPLACENI"])).ToString(), 8, 0, false, "").Substring(num222, 1);
                num222++;
            }
            while (num222 <= 7);
            int num223 = 0;
            do
            {
                document.Tables[12].Cell(7, 4 + num223).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set5.S_PLACA_RAD1G_SATI.Rows[0]["PREKOVREMENI"])).ToString(), 8, 0, false, "").Substring(num223, 1);
                num223++;
            }
            while (num223 <= 7);
            int num224 = 0;
            do
            {
                document.Tables[12].Cell(8, 4 + num224).Range.Text = DB.BrojVodecePraznine(DB.N20(RuntimeHelpers.GetObjectValue(set5.S_PLACA_RAD1G_SATI.Rows[0]["STRAJK"])).ToString(), 8, 0, false, "").Substring(num224, 1);
                num224++;
            }
            while (num224 <= 7);
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            SaveFileDialog dialog2 = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.doc)|*.doc|All files (*.*)|*.*",
                FileName = "RAD-1g2011.DOC",
                RestoreDirectory = true
            };
            dialog2.ShowDialog();
            try
            {
                SaveFileDialog dialog3 = dialog2;
                object fileName = dialog3.FileName;


                document.SaveAs(ref fileName, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp);
                dialog3.FileName = Conversions.ToString(fileName);

                //document.Close(ref temp, ref temp, ref temp);
                ((Microsoft.Office.Interop.Word._Document)document).Close(ref temp, ref temp, ref temp);

                Interaction.MsgBox("Datoteka uspješno spremljena u : " + dialog2.FileName, MsgBoxStyle.OkOnly, null);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void CountUntilCancelledrad1m()
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            frmPregledMjeseciGodina godina = new frmPregledMjeseciGodina();
            godina.ShowDialog();
            if (godina.DialogResult != DialogResult.Cancel)
            {
                decimal num = 0;
                decimal num2 = 0;
                int num3 = 0;
                decimal num4 = 0;
                decimal num5 = 0;
                DataRow current;
                decimal num7 = 0;
                decimal num8 = 0;
                decimal num9 = 0;
                decimal num10 = 0;
                IEnumerator enumerator = null;
                IEnumerator enumerator3 = null;
                IEnumerator enumerator4 = null;
                IEnumerator enumerator6 = null;
                if ((godina.OdabraniGodinaIsplate != null) & (godina.OdabraniMjesecIsplate != null))
                {
                    this.strMI = Conversions.ToString(godina.OdabraniMjesecIsplate);
                    this.strGI = Conversions.ToString(godina.OdabraniGodinaIsplate);
                }
                Microsoft.Office.Interop.Word.Application application = new ApplicationClass();
                Document document = new DocumentClass();
                application.Visible = false;

                object temp = System.Reflection.Missing.Value;

                object confirmConversions = true;
                object readOnly = true;

                object path = System.Windows.Forms.Application.StartupPath + @"\App_Data\RAD-1.doc";
                document = application.Documents.Add(ref path, ref temp ,
                                     ref confirmConversions, ref readOnly);
                document = application.Documents.Open(ref path, ref confirmConversions, ref readOnly, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp);
                document.ActiveWindow.View.ReadingLayout = false;

                S_PLACA_RAD1M_DIO1DataAdapter adapter = new S_PLACA_RAD1M_DIO1DataAdapter();
                S_PLACA_RAD1M_DIO1DataSet dataSet = new S_PLACA_RAD1M_DIO1DataSet();
                adapter.Fill(dataSet, this.strMI, this.strGI);
                S_PLACA_RAD1M_DIO2DataAdapter adapter2 = new S_PLACA_RAD1M_DIO2DataAdapter();
                S_PLACA_RAD1M_DIO2DataSet set2 = new S_PLACA_RAD1M_DIO2DataSet();
                adapter2.Fill(set2, this.strMI, this.strGI);
                S_PLACA_RAD1M_DIO3DataAdapter adapter3 = new S_PLACA_RAD1M_DIO3DataAdapter();
                S_PLACA_RAD1M_DIO3DataSet set3 = new S_PLACA_RAD1M_DIO3DataSet();
                adapter3.Fill(set3, this.strMI, this.strGI);
                KORISNIKDataSet set4 = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(set4);
                string str = "MJESEČNI IZVJEŠTAJ O ZAPOSLENIMA I ISPLAĆENOJ PLAĆI\r\n";
                str = str + "ZA MJESEC " + DB.MjesecNazivPlatna(Conversions.ToInteger(this.strMI)) + " " + this.strGI.ToString() + ".";
                document.Tables[1].Cell(2, 1).Range.Text = str;
                document.Tables[1].Cell(6, 8).Range.Text = this.strMI.Substring(0, 1);
                document.Tables[1].Cell(6, 9).Range.Text = this.strMI.Substring(1, 1);
                document.Tables[2].Cell(3, 2).Range.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("NAZIV/TVRTKA: ", set4.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                int startIndex = 0;
                do
                {
                    document.Tables[2].Cell(7, 4 + startIndex).Range.Text = set4.KORISNIK.Rows[0]["KORISNIKOIB"].ToString().Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 10);
                int num11 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataSet.Tables[0].Rows[0]["BROJRADNIKAUKUPNO"], dataSet.Tables[0].Rows[0]["BROJDOSLIH"]), Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJOTISLIH"])));
                int num12 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataSet.Tables[0].Rows[0]["BROJZENA"], dataSet.Tables[0].Rows[0]["BROJDOSLIHZENA"]), dataSet.Tables[0].Rows[0]["BROJOTISLIHZENA"]));
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(2, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJRADNIKAUKUPNO"]).ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(2, 8 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJZENA"]).ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(3, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJDOSLIH"]).ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(3, 8 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJDOSLIHZENA"]).ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(4, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJOTISLIH"]).ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(4, 8 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(dataSet.Tables[0].Rows[0]["BROJOTISLIHZENA"]).ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(5, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(num11.ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                startIndex = 0;
                do
                {
                    document.Tables[3].Cell(5, 8 + startIndex).Range.Text = DB.BrojVodecePraznine(num12.ToString(), 5, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 4);
                try
                {
                    enumerator = set2.Tables[0].Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow) enumerator.Current;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTA"], "O", false))
                        {
                            num3++;
                            num8 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num8, current["NETO"]));
                            num = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num, current["BROJRADNIKANETO"]));
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
                if (num3 > 3)
                {
                    startIndex = 0;
                    do
                    {
                        document.Tables[4].Cell(2, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(Convert.ToInt32(num8).ToString(), 12, 0, false, "").Substring(startIndex, 1);
                        startIndex++;
                    }
                    while (startIndex <= 11);
                    startIndex = 0;
                    do
                    {
                        document.Tables[4].Cell(2, 15 + startIndex).Range.Text = DB.BrojVodecePraznine(Convert.ToInt32(num).ToString(), 4, 0, false, "").Substring(startIndex, 1);
                        startIndex++;
                    }
                    while (startIndex <= 3);
                }
                else
                {
                    IEnumerator enumerator2 = null;
                    int num14 = 0;
                    try
                    {
                        enumerator2 = set2.Tables[0].Rows.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            current = (DataRow) enumerator2.Current;
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTA"], "O", false))
                            {
                                startIndex = 0;
                                do
                                {
                                    document.Tables[4].Cell(2 + num14, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(current["NETO"]).ToString(), 12, 0, false, "").Substring(startIndex, 1);
                                    startIndex++;
                                }
                                while (startIndex <= 11);
                                startIndex = 0;
                                do
                                {
                                    document.Tables[4].Cell(2 + num14, 15 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(current["BROJRADNIKANETO"]).ToString(), 4, 0, false, "").Substring(startIndex, 1);
                                    startIndex++;
                                }
                                while (startIndex <= 3);
                                document.Tables[4].Cell(2 + num14, 2).Range.Text = DB.N2T(RuntimeHelpers.GetObjectValue(current["SVRHA"]), "NEMA OPISA");
                                document.Tables[4].Cell(2 + num14, 0x13).Range.Text = DB.N2T(current["DATISP"].ToString(), "NEMA DATUMA");
                                num14++;
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                }
                try
                {
                    enumerator3 = set2.Tables[0].Rows.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                        current = (DataRow) enumerator3.Current;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTA"], "P", false))
                        {
                            num9 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num9, current["NNETO"]));
                            num2 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num2, set2.Tables[0].Rows[0]["BROJRADNIKANETOPOTPORE"]));
                        }
                    }
                }
                finally
                {
                    if (enumerator3 is IDisposable)
                    {
                        (enumerator3 as IDisposable).Dispose();
                    }
                }
                startIndex = 0;
                do
                {
                    document.Tables[5].Cell(1, 2 + startIndex).Range.Text = DB.BrojVodecePraznine(Convert.ToInt32(num9).ToString(), 12, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 11);
                startIndex = 0;
                do
                {
                    document.Tables[5].Cell(1, 14 + startIndex).Range.Text = DB.BrojVodecePraznine(Convert.ToInt32(num2).ToString(), 4, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 3);
                try
                {
                    enumerator4 = set2.Tables[0].Rows.GetEnumerator();
                    while (enumerator4.MoveNext())
                    {
                        current = (DataRow) enumerator4.Current;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTA"], "O", false))
                        {
                            num4 = decimal.Add(num4, decimal.One);
                            num5 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num5, current["BRUTO"]));
                            num10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num10, current["SATIBRUTO"]));
                        }
                    }
                }
                finally
                {
                    if (enumerator4 is IDisposable)
                    {
                        (enumerator4 as IDisposable).Dispose();
                    }
                }
                if (decimal.Compare(num4, 3M) > 0)
                {
                    startIndex = 0;
                    do
                    {
                        document.Tables[6].Cell(2, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(Convert.ToInt32(num5).ToString(), 12, 0, false, "").Substring(startIndex, 1);
                        startIndex++;
                    }
                    while (startIndex <= 11);
                    startIndex = 0;
                    do
                    {
                        document.Tables[6].Cell(2, 0x11 + startIndex).Range.Text = DB.BrojVodecePraznine(Convert.ToInt32(num10).ToString(), 7, 0, false, "").Substring(startIndex, 1);
                        startIndex++;
                    }
                    while (startIndex <= 6);
                }
                else
                {
                    IEnumerator enumerator5 = null;
                    int num15 = 0;
                    try
                    {
                        enumerator5 = set2.Tables[0].Rows.GetEnumerator();
                        while (enumerator5.MoveNext())
                        {
                            current = (DataRow) enumerator5.Current;
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTA"], "O", false))
                            {
                                startIndex = 0;
                                do
                                {
                                    document.Tables[6].Cell(2 + num15, 3 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(current["BRUTO"]).ToString(), 12, 0, false, "").Substring(startIndex, 1);
                                    startIndex++;
                                }
                                while (startIndex <= 11);
                                startIndex = 0;
                                do
                                {
                                    document.Tables[6].Cell(2 + num15, 0x11 + startIndex).Range.Text = DB.BrojVodecePraznine(Conversions.ToInteger(current["SATIBRUTO"]).ToString(), 7, 0, false, "").Substring(startIndex, 1);
                                    startIndex++;
                                }
                                while (startIndex <= 6);
                                document.Tables[6].Cell(2 + num15, 2).Range.Text = DB.N2T(RuntimeHelpers.GetObjectValue(current["SVRHA"]), "NEMA OPISA");
                                num15++;
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator5 is IDisposable)
                        {
                            (enumerator5 as IDisposable).Dispose();
                        }
                    }
                }
                try
                {
                    enumerator6 = set2.Tables[0].Rows.GetEnumerator();
                    while (enumerator6.MoveNext())
                    {
                        current = (DataRow) enumerator6.Current;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["VRSTA"], "P", false))
                        {
                            num7 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(num7, current["NBRUTO"]));
                        }
                    }
                }
                finally
                {
                    if (enumerator6 is IDisposable)
                    {
                        (enumerator6 as IDisposable).Dispose();
                    }
                }
                startIndex = 0;
                do
                {
                    document.Tables[7].Cell(1, 2 + startIndex).Range.Text = DB.BrojVodecePraznine(Convert.ToInt32(num7).ToString(), 12, 0, false, "").Substring(startIndex, 1);
                    startIndex++;
                }
                while (startIndex <= 11);
                document.Tables[8].Cell(4, 2).Range.Text = Conversions.ToString(Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(set3.Tables[0].Rows[0]["prekovremeni"]))));
                document.Tables[8].Cell(4, 3).Range.Text = Conversions.ToString(Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(set3.Tables[0].Rows[0]["bolovanjedo42dana"]))));
                document.Tables[8].Cell(4, 4).Range.Text = Conversions.ToString(Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(set3.Tables[0].Rows[0]["godisnji"]))));
                document.Tables[8].Cell(4, 5).Range.Text = Conversions.ToString(Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(set3.Tables[0].Rows[0]["BLAGDANINERADNI"]))));
                document.Tables[8].Cell(4, 6).Range.Text = Conversions.ToString(Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(set3.Tables[0].Rows[0]["PLACENIANEIZVRSENI"]))));
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                SaveFileDialog dialog2 = new SaveFileDialog {
                    InitialDirectory = @"C:\Desktop",
                    Filter = "Excel datoteke (*.doc)|*.doc|All files (*.*)|*.*",
                    FileName = "RAD-1.DOC",
                    RestoreDirectory = true
                };
                dialog2.ShowDialog();
                
                try
                {
                    SaveFileDialog dialog3 = dialog2;
                    object fileName = dialog3.FileName;
                    document.SaveAs(ref fileName, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp);
                    dialog3.FileName = Conversions.ToString(fileName);

                    //document.Close(ref temp, ref temp, ref temp);
                    ((Microsoft.Office.Interop.Word._Document)document).Close(ref temp, ref temp, ref temp);                    

                    Interaction.MsgBox("Datoteka uspješno spremljena u : " + dialog2.FileName, MsgBoxStyle.OkOnly, null);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    //document.Close(ref temp, ref temp, ref temp);
                    //((Microsoft.Office.Interop.Word._Document)document).Close(ref temp, ref temp, ref temp);  
                }
            }
        }

        [CommandHandler("Placa.DDIZDATAKCommand")]
        public void DDIZDATAKCommand(object sender, EventArgs e)
        {
            DDIZDATAKWorkWithWorkItem item = this.WorkItem.Items.Get<DDIZDATAKWorkWithWorkItem>("Placa.DDIZDATAK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDIZDATAKWorkWithWorkItem>("Placa.DDIZDATAK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDKATEGORIJACommand")]
        public void DDKATEGORIJACommand(object sender, EventArgs e)
        {
            DDKATEGORIJAWorkWithWorkItem item = this.WorkItem.Items.Get<DDKATEGORIJAWorkWithWorkItem>("Placa.DDKATEGORIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDKATEGORIJAWorkWithWorkItem>("Placa.DDKATEGORIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDKOLONAIDDCommand")]
        public void DDKOLONAIDDCommand(object sender, EventArgs e)
        {
            DDKOLONAIDDWorkWithWorkItem item = this.WorkItem.Items.Get<DDKOLONAIDDWorkWithWorkItem>("Placa.DDKOLONAIDD");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDKOLONAIDDWorkWithWorkItem>("Placa.DDKOLONAIDD");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDOBRACUNCommand")]
        public void DDOBRACUNCommand(object sender, EventArgs e)
        {
            DDOBRACUNWorkWithWorkItem item = this.WorkItem.Items.Get<DDOBRACUNWorkWithWorkItem>("Placa.DDOBRACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDOBRACUNWorkWithWorkItem>("Placa.DDOBRACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDRADNIKCommand")]
        public void DDRADNIKCommand(object sender, EventArgs e)
        {
            DDRADNIKWorkWithWorkItem item = this.WorkItem.Items.Get<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DDVRSTEPOSLACommand")]
        public void DDVRSTEPOSLACommand(object sender, EventArgs e)
        {
            DDVRSTEPOSLAWorkWithWorkItem item = this.WorkItem.Items.Get<DDVRSTEPOSLAWorkWithWorkItem>("Placa.DDVRSTEPOSLA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DDVRSTEPOSLAWorkWithWorkItem>("Placa.DDVRSTEPOSLA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DOPRINOSCommand")]
        public void DOPRINOSCommand(object sender, EventArgs e)
        {
            DOPRINOSWorkWithWorkItem item = this.WorkItem.Items.Get<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.DOSIPZAGLAVLJECommand")]
        public void DOSIPZAGLAVLJECommand(object sender, EventArgs e)
        {
            DOSIPZAGLAVLJEWorkWithWorkItem item = this.WorkItem.Items.Get<DOSIPZAGLAVLJEWorkWithWorkItem>("Placa.DOSIPZAGLAVLJE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<DOSIPZAGLAVLJEWorkWithWorkItem>("Placa.DOSIPZAGLAVLJE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ELEMENTCommand")]
        public void ELEMENTCommand(object sender, EventArgs e)
        {
            ELEMENTWorkWithWorkItem item = this.WorkItem.Items.Get<ELEMENTWorkWithWorkItem>("Placa.ELEMENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ELEMENTWorkWithWorkItem>("Placa.ELEMENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.FondBolovanje")]
        public void FondBolovanjeCommandHandler(object sender, EventArgs e)
        {
            FondBolovanjeWorkItem item = this.WorkItem.Items.Get<FondBolovanjeWorkItem>("FondBolovanjeWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<FondBolovanjeWorkItem>("FondBolovanjeWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GODINA_I_MJESEC_OBRACUNACommand")]
        public void GODINA_I_MJESEC_OBRACUNACommand(object sender, EventArgs e)
        {
            GODINA_I_MJESEC_OBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<GODINA_I_MJESEC_OBRACUNAWorkWithWorkItem>("Placa.GODINA_I_MJESEC_OBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GODINA_I_MJESEC_OBRACUNAWorkWithWorkItem>("Placa.GODINA_I_MJESEC_OBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Godisnji")]
        public void GodisnjiCommandHandler(object sender, EventArgs e)
        {
            GodisnjiWorkItem item = this.WorkItem.Items.Get<GodisnjiWorkItem>("GodisnjiWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GodisnjiWorkItem>("GodisnjiWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GOOBRACUNCommand")]
        public void GOOBRACUNCommand(object sender, EventArgs e)
        {
            GOOBRACUNWorkWithWorkItem item = this.WorkItem.Items.Get<GOOBRACUNWorkWithWorkItem>("Placa.GOOBRACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GOOBRACUNWorkWithWorkItem>("Placa.GOOBRACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GRUPEKOEFCommand")]
        public void GRUPEKOEFCommand(object sender, EventArgs e)
        {
            GRUPEKOEFWorkWithWorkItem item = this.WorkItem.Items.Get<GRUPEKOEFWorkWithWorkItem>("Placa.GRUPEKOEF");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GRUPEKOEFWorkWithWorkItem>("Placa.GRUPEKOEF");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.GRUPEOLAKSICACommand")]
        public void GRUPEOLAKSICACommand(object sender, EventArgs e)
        {
            GRUPEOLAKSICAWorkWithWorkItem item = this.WorkItem.Items.Get<GRUPEOLAKSICAWorkWithWorkItem>("Placa.GRUPEOLAKSICA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<GRUPEOLAKSICAWorkWithWorkItem>("Placa.GRUPEOLAKSICA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IDObrazacCommand")]
        public void IDObrazacCommand(object sender, EventArgs e)
        {
            IDWorkItem item = this.WorkItem.Items.Get<IDWorkItem>("IDObrazac");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IDWorkItem>("IDObrazac");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IMPORTIP")]
        public void IMPORTIPCommandHandler(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterScreen,
                Modal = true,
                ControlBox = true,
                Title = "Servis - baze podataka",
                Icon = ImageResourcesNew.mbs
            };
            DOSPodaci smartPart = this.WorkItem.Items.AddNew<DOSPodaci>();
            this.WorkItem.RootWorkItem.Workspaces["window"].Show(smartPart, smartPartInfo);
        }

        [CommandHandler("Placa.IPIDENTCommand")]
        public void IPIDENTCommand(object sender, EventArgs e)
        {
            IPIDENTWorkWithWorkItem item = this.WorkItem.Items.Get<IPIDENTWorkWithWorkItem>("Placa.IPIDENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IPIDENTWorkWithWorkItem>("Placa.IPIDENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IPKarticeCommand")]
        public void IPKarticeCommandHandler(object sender, EventArgs e)
        {
            IPKarticeWorkItem item = this.WorkItem.Items.Get<IPKarticeWorkItem>("IPKartice");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IPKarticeWorkItem>("IPKartice");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IPPObrazacCommand")]
        public void IPPCommandHandler(object sender, EventArgs e)
        {
            IPPWorkItem item = this.WorkItem.Items.Get<IPPWorkItem>("IPPWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IPPWorkItem>("IPPWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.IZVORDOKUMENTACommand")]
        public void IZVORDOKUMENTACommand(object sender, EventArgs e)
        {
            IZVORDOKUMENTAWorkWithWorkItem item = this.WorkItem.Items.Get<IZVORDOKUMENTAWorkWithWorkItem>("Placa.IZVORDOKUMENTA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<IZVORDOKUMENTAWorkWithWorkItem>("Placa.IZVORDOKUMENTA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KORISNIKCommand")]
        public void KORISNIKCommand(object sender, EventArgs e)
        {
            KORISNIKWorkWithWorkItem item = this.WorkItem.Items.Get<KORISNIKWorkWithWorkItem>("Placa.KORISNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KORISNIKWorkWithWorkItem>("Placa.KORISNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KREDITORCommand")]
        public void KREDITORCommand(object sender, EventArgs e)
        {
            KREDITORWorkWithWorkItem item = this.WorkItem.Items.Get<KREDITORWorkWithWorkItem>("Placa.KREDITOR");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KREDITORWorkWithWorkItem>("Placa.KREDITOR");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.KRIZNIPOREZCommand")]
        public void KRIZNIPOREZCommand(object sender, EventArgs e)
        {
            KRIZNIPOREZWorkWithWorkItem item = this.WorkItem.Items.Get<KRIZNIPOREZWorkWithWorkItem>("Placa.KRIZNIPOREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<KRIZNIPOREZWorkWithWorkItem>("Placa.KRIZNIPOREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("ListaIznosaCommand")]
        public void ListaIznosaCommandHandler(object sender, EventArgs e)
        {
            ListaIznosaWorkItem item = this.WorkItem.Items.Get<ListaIznosaWorkItem>("ListaIznosa");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ListaIznosaWorkItem>("ListaIznosa");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("MaticniKartonCommand")]
        public void MaticniKartonCommandHandler(object sender, EventArgs e)
        {
            MaticniKartonWorkItem item = this.WorkItem.Items.Get<MaticniKartonWorkItem>("MaticniKarton");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<MaticniKartonWorkItem>("MaticniKarton");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.MZOSTABLICECommand")]
        public void MZOSTABLICECommand(object sender, EventArgs e)
        {
            MZOSTABLICEWorkWithWorkItem item = this.WorkItem.Items.Get<MZOSTABLICEWorkWithWorkItem>("Placa.MZOSTABLICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<MZOSTABLICEWorkWithWorkItem>("Placa.MZOSTABLICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OBRACUNCommand")]
        public void OBRACUNCommand(object sender, EventArgs e)
        {
            OBRACUNWorkWithWorkItem item = this.WorkItem.Items.Get<OBRACUNWorkWithWorkItem>("Placa.OBRACUN");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OBRACUNWorkWithWorkItem>("Placa.OBRACUN");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OBUSTAVACommand")]
        public void OBUSTAVACommand(object sender, EventArgs e)
        {
            OBUSTAVAWorkWithWorkItem item = this.WorkItem.Items.Get<OBUSTAVAWorkWithWorkItem>("Placa.OBUSTAVA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OBUSTAVAWorkWithWorkItem>("Placa.OBUSTAVA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OLAKSICECommand")]
        public void OLAKSICECommand(object sender, EventArgs e)
        {
            OLAKSICEWorkWithWorkItem item = this.WorkItem.Items.Get<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OPCINACommand")]
        public void OPCINACommand(object sender, EventArgs e)
        {
            OPCINAWorkWithWorkItem item = this.WorkItem.Items.Get<OPCINAWorkWithWorkItem>("Placa.OPCINA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OPCINAWorkWithWorkItem>("Placa.OPCINA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ORGDIOCommand")]
        public void ORGDIOCommand(object sender, EventArgs e)
        {
            ORGDIOWorkWithWorkItem item = this.WorkItem.Items.Get<ORGDIOWorkWithWorkItem>("Placa.ORGDIO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ORGDIOWorkWithWorkItem>("Placa.ORGDIO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSNOVAOSIGURANJACommand")]
        public void OSNOVAOSIGURANJACommand(object sender, EventArgs e)
        {
            OSNOVAOSIGURANJAWorkWithWorkItem item = this.WorkItem.Items.Get<OSNOVAOSIGURANJAWorkWithWorkItem>("Placa.OSNOVAOSIGURANJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSNOVAOSIGURANJAWorkWithWorkItem>("Placa.OSNOVAOSIGURANJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OSOBNIODBITAKCommand")]
        public void OSOBNIODBITAKCommand(object sender, EventArgs e)
        {
            OSOBNIODBITAKWorkWithWorkItem item = this.WorkItem.Items.Get<OSOBNIODBITAKWorkWithWorkItem>("Placa.OSOBNIODBITAK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OSOBNIODBITAKWorkWithWorkItem>("Placa.OSOBNIODBITAK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.OTISLICommand")]
        public void OTISLICommand(object sender, EventArgs e)
        {
            OTISLIWorkWithWorkItem item = this.WorkItem.Items.Get<OTISLIWorkWithWorkItem>("Placa.OTISLI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<OTISLIWorkWithWorkItem>("Placa.OTISLI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.POREZCommand")]
        public void POREZCommand(object sender, EventArgs e)
        {
            POREZWorkWithWorkItem item = this.WorkItem.Items.Get<POREZWorkWithWorkItem>("Placa.POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<POREZWorkWithWorkItem>("Placa.POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PregledObracunaCommand")]
        public void PregledObracunaCommand(object sender, EventArgs e)
        {
            PregledObracunaWorkWithWorkItem item = this.WorkItem.Items.Get<PregledObracunaWorkWithWorkItem>("Placa.PregledObracuna");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PregledObracunaWorkWithWorkItem>("Placa.PregledObracuna");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PregledRadnikaCommand")]
        public void PregledRadnikaCommand(object sender, EventArgs e)
        {
            PregledRadnikaWorkWithWorkItem item = this.WorkItem.Items.Get<PregledRadnikaWorkWithWorkItem>("Placa.PregledRadnika");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PregledRadnikaWorkWithWorkItem>("Placa.PregledRadnika");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PregledRadnikaSvihCommand")]
        public void PregledRadnikaSvihCommand(object sender, EventArgs e)
        {
            PregledRadnikaSvihWorkWithWorkItem item = this.WorkItem.Items.Get<PregledRadnikaSvihWorkWithWorkItem>("Placa.PregledRadnikaSvih");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PregledRadnikaSvihWorkWithWorkItem>("Placa.PregledRadnikaSvih");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PripremaCommand")]
        public void PripremaCommand(object sender, EventArgs e)
        {
            PripremaWorkItem item = this.WorkItem.Items.Get<PripremaWorkItem>("Obracun");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PripremaWorkItem>("Obracun");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PRPLACECommandCustom")]
        public void PripremaCustomCommandHandler(object sender, EventArgs e)
        {
            PripremaPlaceWorkItem item = this.WorkItem.Items.Get<PripremaPlaceWorkItem>("PripremaPlaceWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PripremaPlaceWorkItem>("PripremaPlaceWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ProsjekPlace")]
        public void ProsjekPlaceCommandHandler(object sender, EventArgs e)
        {
            ProsjekPlaceWorkItem item = this.WorkItem.Items.Get<ProsjekPlaceWorkItem>("ProsjekPlaceWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ProsjekPlaceWorkItem>("ProsjekPlaceWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PROVIDER_BRUTOCommand")]
        public void PROVIDER_BRUTOCommand(object sender, EventArgs e)
        {
            PROVIDER_BRUTOWorkWithWorkItem item = this.WorkItem.Items.Get<PROVIDER_BRUTOWorkWithWorkItem>("Placa.PROVIDER_BRUTO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PROVIDER_BRUTOWorkWithWorkItem>("Placa.PROVIDER_BRUTO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PROVIDER_NETOCommand")]
        public void PROVIDER_NETOCommand(object sender, EventArgs e)
        {
            PROVIDER_NETOWorkWithWorkItem item = this.WorkItem.Items.Get<PROVIDER_NETOWorkWithWorkItem>("Placa.PROVIDER_NETO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PROVIDER_NETOWorkWithWorkItem>("Placa.PROVIDER_NETO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PRPLACECommand")]
        public void PRPLACECommand(object sender, EventArgs e)
        {
            PRPLACEWorkWithWorkItem item = this.WorkItem.Items.Get<PRPLACEWorkWithWorkItem>("Placa.PRPLACE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PRPLACEWorkWithWorkItem>("Placa.PRPLACE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.PrPlaceCustom")]
        public void PrPlaceCustomCommandHandler(object sender, EventArgs e)
        {
            PripremaPlaceCustomWorkItem item = this.WorkItem.Items.Get<PripremaPlaceCustomWorkItem>("PripremaPlaceCustomWorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PripremaPlaceCustomWorkItem>("PripremaPlaceCustomWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1G")]
        public void Rad1GCommand(object sender, EventArgs e)
        {
            this.CountUntilCancelledrad1g();
        }

        [CommandHandler("UnosPutnogNaloga")]
        public void UnosPutnogNalogaCommand(object sender, EventArgs e)
        {
            JOPPD.PutniNalogWorkItem item = this.WorkItem.Items.Get<JOPPD.PutniNalogWorkItem>("RegistarNabave");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.PutniNalogWorkItem>("RegistarNabave");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RAD1M")]
        public void Rad1mMjesecniCommand(object sender, EventArgs e)
        {
            this.CountUntilCancelledrad1m();
        }

        [CommandHandler("Placa.RADNIKCommand")]
        public void RADNIKCommand(object sender, EventArgs e)
        {
            RADNIKWorkWithWorkItem item = this.WorkItem.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TablicniPregledRadnika")]
        public void RadnikIspravakOsnovnihCommand(object sender, EventArgs e)
        {
            new frmIspravakOsnovnihPodataka().ShowDialog();
        }

        [CommandHandler("Placa.RadnikZaObracunCommand")]
        public void RadnikZaObracunCommand(object sender, EventArgs e)
        {
            RadnikZaObracunWorkWithWorkItem item = this.WorkItem.Items.Get<RadnikZaObracunWorkWithWorkItem>("Placa.RadnikZaObracun");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RadnikZaObracunWorkWithWorkItem>("Placa.RadnikZaObracun");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RADNOMJESTOCommand")]
        public void RADNOMJESTOCommand(object sender, EventArgs e)
        {
            RADNOMJESTOWorkWithWorkItem item = this.WorkItem.Items.Get<RADNOMJESTOWorkWithWorkItem>("Placa.RADNOMJESTO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RADNOMJESTOWorkWithWorkItem>("Placa.RADNOMJESTO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSMACommand")]
        public void RSMACommand(object sender, EventArgs e)
        {
            RSMAWorkWithWorkItem item = this.WorkItem.Items.Get<RSMAWorkWithWorkItem>("Placa.RSMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSMAWorkWithWorkItem>("Placa.RSMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSMObrazacCommand")]
        public void RSMObrazacCommand(object sender, EventArgs e)
        {
            RSMObrazacWorkItem item = this.WorkItem.Items.Get<RSMObrazacWorkItem>("RSMObrazac");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSMObrazacWorkItem>("RSMObrazac");
            }
            item.Show(item.Workspaces["main"]);
        }


        [CommandHandler("JOPPDObrazac")]
        public void JOPPDObrazacCommand(object sender, EventArgs e)
        {
            JOPPDObrazacWorkItem item = this.WorkItem.Items.Get<JOPPDObrazacWorkItem>("JOPPDObrazac");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPDObrazacWorkItem>("JOPPDObrazac");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaPrimitka")]
        public void OznakaPrimitkaCommand(object sender, EventArgs e)
        {
            JOPPD.OznakaPrimitkaWorkItem item = this.WorkItem.Items.Get<JOPPD.OznakaPrimitkaWorkItem>("JOPPD.OznakaPrimitka");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.OznakaPrimitkaWorkItem>("JOPPD.OznakaPrimitka");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaPrimitkaElement")]
        public void OznakaPrimitkaElementCommand(object sender, EventArgs e)
        {
            JOPPD.OznakaPrimitkaElementPregledWorkItem item = this.WorkItem.Items.Get<JOPPD.OznakaPrimitkaElementPregledWorkItem>("JOPPD..OznakaPrimitkaElement");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.OznakaPrimitkaElementPregledWorkItem>("JOPPD..OznakaPrimitkaElement");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaStjecatelja")]
        public void OznakaStjecateljaCommand(object sender, EventArgs e)
        {
            JOPPD.StjecateljPrimitkaWorkItem item = this.WorkItem.Items.Get<JOPPD.StjecateljPrimitkaWorkItem>("JOPPD.StjecateljPrimitka");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.StjecateljPrimitkaWorkItem>("JOPPD.StjecateljPrimitka");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaStjecateljaElement")]
        public void OznakaStjecateljaElementCommand(object sender, EventArgs e)
        {
            JOPPD.StjecateljPrimitkaElementPregledWorkItem item = this.WorkItem.Items.Get<JOPPD.StjecateljPrimitkaElementPregledWorkItem>("JOPPD..StjecateljPrimitkaElement");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.StjecateljPrimitkaElementPregledWorkItem>("JOPPD..StjecateljPrimitkaElement");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaRadnogVremena")]
        public void OOznakaRadnogVremenaCommand(object sender, EventArgs e)
        {
            JOPPD.RadnoVrijemeWorkItem item = this.WorkItem.Items.Get<JOPPD.RadnoVrijemeWorkItem>("JOPPD.RadnoVrijeme");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.RadnoVrijemeWorkItem>("JOPPD.RadnoVrijeme");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaNeoporezivog")]
        public void OznakaNeoporezivogCommand(object sender, EventArgs e)
        {
            JOPPD.NeoporezivPrimitakWorkItem item = this.WorkItem.Items.Get<JOPPD.NeoporezivPrimitakWorkItem>("JOPPD.NeoporezivPrimitak");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.NeoporezivPrimitakWorkItem>("JOPPD.NeoporezivPrimitak");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaNeoporezivogElement")]
        public void OznakaNeoporezivogElementCommand(object sender, EventArgs e)
        {
            JOPPD.NeoporeziviPrimitakElementPregledWorkItem item = this.WorkItem.Items.Get<JOPPD.NeoporeziviPrimitakElementPregledWorkItem>("JOPPD.NeoporeziviPrimitakElement");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.NeoporeziviPrimitakElementPregledWorkItem>("JOPPD.NeoporeziviPrimitakElement");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaMjesecaOsiguranja")]
        public void OznakaMjesecaOsiguranjaCommand(object sender, EventArgs e)
        {
            
            JOPPD.MjesecOsiguranjaWorkItem item = this.WorkItem.Items.Get<JOPPD.MjesecOsiguranjaWorkItem>("JOPPD.MjesecOsiguranja");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.MjesecOsiguranjaWorkItem>("JOPPD.MjesecOsiguranja");
            }
            item.Show(item.Workspaces["main"]);
        }


        [CommandHandler("Raspored")]
        public void RasporedSatiCommand(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tools4schools.hr/raspored/");
        }

        [CommandHandler("OsobeObracun")]
        public void OsobeObracunCommand(object sender, EventArgs e)
        {
            UcenickoFakturiranje.UI.MaticniPodaci.UcenikFormPregled.vrsta_osobe = true;
            UcenickoFakturiranje.UI.MaticniPodaci.UcenikFormPregledWorkItem item = this.WorkItem.Items.Get<UcenickoFakturiranje.UI.MaticniPodaci.UcenikFormPregledWorkItem>("UF.Ucenik");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UcenickoFakturiranje.UI.MaticniPodaci.UcenikFormPregledWorkItem>("UF.Ucenik");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaNacinIsplate")]
        public void OznakaNacinIsplateCommand(object sender, EventArgs e)
        {
            JOPPD.NacinIsplateWorkItem item = this.WorkItem.Items.Get<JOPPD.NacinIsplateWorkItem>("JOPPD.NacinIsplate");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.NacinIsplateWorkItem>("JOPPD.NacinIsplate");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("OznakaNacinIsplateElement")]
        public void OznakaNacinIsplateElementCommand(object sender, EventArgs e)
        {
            JOPPD.NacinIsplateElementWorkItem item = this.WorkItem.Items.Get<JOPPD.NacinIsplateElementWorkItem>("JOPPD.NacinIsplateElement");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.NacinIsplateElementWorkItem>("JOPPD.NacinIsplateElement");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("SocijalnaPotpora")]
        public void SocijalnaPotporaCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1")
            {
                JOPPD.SocijalnaPotporaWorkItem item = this.WorkItem.Items.Get<JOPPD.SocijalnaPotporaWorkItem>("JOPPD.SocijalnaPotpora");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<JOPPD.SocijalnaPotporaWorkItem>("JOPPD.SocijalnaPotpora");
                }
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }

        [CommandHandler("SocijalnaNaknada")]
        public void SocijalnaNaknadaCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1")
            {
                JOPPD.SocijalnaNaknadaWorkItem item = this.WorkItem.Items.Get<JOPPD.SocijalnaNaknadaWorkItem>("JOPPD.SocijalnaNaknada");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<JOPPD.SocijalnaNaknadaWorkItem>("JOPPD.SocijalnaNaknada");
                }
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }

        [CommandHandler("Stipendije")]
        public void StipendijeCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1")
            {
                JOPPD.StipendijeWorkItem item = this.WorkItem.Items.Get<JOPPD.StipendijeWorkItem>("JOPPD.Stipendije");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<JOPPD.StipendijeWorkItem>("JOPPD.Stipendije");
                }
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }

        [CommandHandler("NagradePraksa")]
        public void NagradePraksaCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1")
            {
                JOPPD.NagradeWorkItem item = this.WorkItem.Items.Get<JOPPD.NagradeWorkItem>("JOPPD.NagradePraksa");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<JOPPD.NagradeWorkItem>("JOPPD.NagradePraksa");
                }
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }

        [CommandHandler("NagradeNatjecanja")]
        public void NagradeNatjecanjaCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1")
            {
                JOPPD.NagradeNatjecanjaWorkItem item = this.WorkItem.Items.Get<JOPPD.NagradeNatjecanjaWorkItem>("JOPPD.NagradeNatjecanja");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<JOPPD.NagradeNatjecanjaWorkItem>("JOPPD.NagradeNatjecanja");
                }
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }

        [CommandHandler("StudentServisNeoporezivo")]
        public void StudentServisNeoporezivoCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1")
            {
                JOPPD.StudentServisNeoporezivoWorkItem item = this.WorkItem.Items.Get<JOPPD.StudentServisNeoporezivoWorkItem>("JOPPD.StudentServisNeoporezivo");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<JOPPD.StudentServisNeoporezivoWorkItem>("JOPPD.StudentServisNeoporezivo");
                }
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }


        [CommandHandler("NovaImovina.Nova")]
        public void ImovinaCommand(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://osnovnasredstva.azurewebsites.net/");
        }

        [CommandHandler("StudentServisOporezivo")]
        public void StudentServisOporezivoCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_JOPPDRazno == "1")
            {
                JOPPD.StudentServisOporezivoWorkItem item = this.WorkItem.Items.Get<JOPPD.StudentServisOporezivoWorkItem>("JOPPD.StudentServisOporezivo");
                if (item == null)
                {
                    item = this.WorkItem.Items.AddNew<JOPPD.StudentServisOporezivoWorkItem>("JOPPD.StudentServisOporezivo");
                }
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }


        [CommandHandler("IzvozXML")]
        public void IzvozXMLCommand(object sender, EventArgs e)
        {
            MessageBox.Show("Blah");
        }


        [CommandHandler("UvozXML")]
        public void UvozXMLCommand(object sender, EventArgs e)
        {
            if (Mipsed7.Core.ApplicationDatabaseInformation.Modul_COP == "1")
            {
                OpenFileDialog ofdXML = new OpenFileDialog();

                if (ofdXML.ShowDialog() == DialogResult.OK)
                {
                    DataSet xml_datoteka = new DataSet();
                    xml_datoteka.ReadXml(ofdXML.FileName);

                    using (JOPPD.BusinessLogic.COP objekt = new JOPPD.BusinessLogic.COP())
                    {
                        if (objekt.ProvjeraDaliPostojiObracunIzCOPa(xml_datoteka.Tables["StranaA"]))
                        {
                            objekt.NapuniObracun(xml_datoteka.Tables["StranaA"]);
                            if (objekt.NapuniObracunRadnici(xml_datoteka.Tables["P"]))
                            {
                                objekt.NapuniObracunDoprinosi(xml_datoteka.Tables["P"]);
                                objekt.NapuniObracunPorez(xml_datoteka.Tables["P"]);
                                objekt.NapuniObracunElementi(xml_datoteka.Tables["P"]);
                                objekt.ProvjeraIspravnostiPoreza(xml_datoteka.Tables["P"]);

                                if (!UpisJOPPDObrascaIzCOPa(objekt.pSifraObracuna, objekt.pDatumObracuna, ofdXML.FileName))
                                {
                                    MessageBox.Show("Dogodila se greška prilikom kreiranja JOPPD obrasca iz COP datoteke!\n");
                                }
                                else
                                {
                                    MessageBox.Show("JOPPD datoteka obračuna plaće uspiješno uvezena.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Postoji već obračun koje je prenesen iz ove XML JOPPD datoteke");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Da bi koristili ovu funkcionalnost kontaktirajte TOOLS4SCHOOLS D.O.O.", "Upozorenje");
            }
        }

        private bool UpisJOPPDObrascaIzCOPa(string sifra_obracuna, DateTime datum_obracuna, string file_name)
        {
            string id= string.Empty;
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            try
            {
                //upis JOPPDA
                id = client.ExecuteScalar("Insert Into JOPPDA ([OznakaIzvjescaDatum], [VrstaIzvjescaID], [OznakaPodnositelja]) " +
                                        "Values ('" + datum_obracuna.ToString("yyyy-MM-dd") + "', 1, 1) Select @@Identity").ToString();

                //upis JOPPDAObracun
                client.ExecuteNonQuery("Insert Into JOPPDAObracun ([JOPPDA_ID], [Obracun_ID], [Vrsta]) " +
                                        "Values ('" + id + "', '" + sifra_obracuna + "', 0)").ToString();
            }
            catch
            { 
                return false; 
            }

            if (!UpisJOPPDB(id, client, sifra_obracuna, file_name))
            {
                return false;
            }
            
            return true;
        }

        private bool UpisJOPPDB(string id, Mipsed7.DataAccessLayer.SqlClient client, string sifra_obracuna, string file_name)
        {
            System.Data.DataTable tblJOPPDB = client.GetDataTable("SET FMTONLY ON;SELECT [JOPPDAID],[RedniBroj],[SifraOpcinePrebivalista],[SifraOpcineRada],[OIBStjecatelja],[ImePrezimeStjecatelja]," +
                            "[OznakaStjecatelja],[OznakaPrimitka],[ObvezaDodatnogDoprinosa],[ObvezaPosebnogDoprinosa],[OznakaMjesecaOsiguranje],[OznakaRadnogVremena],[SatiRada], [NeodradeniSatiRada], " +
                            "[RazdobljeOd],[RazdobljeDo],[Primitak],[Osnovica],[DoprinosMirovinsko],[DoprinosMirovinskoII],[DoprinosZdravstveno],[DoprinosZastita],[DoprinosZaposljavanje], " +
                            "[DodatniDoprinosMirovinsko],[DodatniDoprinosMirovinskoII],[PosebanDoprinosZdravstveno],[PosebanDoprinosZaposljavanje],[Izdatak],[IzdatakDoprinosMirovinsko], " +
                            "[Dohodak],[OsobniOdbitak],[PoreznaOsnovica],[PorezNaDohodak],[Prirez],[OznakaNeoporezivogPrimitka],[NeoporezivPrimitak],[OznakaNacinaIsplate],[Isplata],[ObracunatiPrimitak] " +
                            "FROM JOPPDB; SET FMTONLY OFF;");
            using (NetAdvantage.SmartParts.JOPPDObrazac objekt = new JOPPDObrazac())
            {
                objekt.GenerirajJOPPDPlaceVolonteriStranicaB(0, ref tblJOPPDB, true, sifra_obracuna, Convert.ToInt32(id), file_name);

                if (!UpisiJOPPDB(tblJOPPDB))
                {
                    return false;
                }
            }
            return true;
        }

        private bool UpisiJOPPDB(System.Data.DataTable tbl)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            string sati_rada = string.Empty;
            string neodradeni_sati_rada = string.Empty;
            string razdoblje_od = string.Empty;
            string razdoblje_do = string.Empty;
            string primitak = string.Empty;
            string osnovica = string.Empty;
            string doprinos_mirovinsko = string.Empty;
            string doprinos_mirovinskoII = string.Empty;
            string doprinos_zdravstveno = string.Empty;
            string doprinos_zastita = string.Empty;
            string doprinos_zaposljavanje = string.Empty;
            string dodatni_doprinos_mirovinsko = string.Empty;
            string dodatni_doprinos_mirovinskoII = string.Empty;
            string poseban_doprinos_zdravstveno = string.Empty;
            string poseban_doprinos_zaposljavanje = string.Empty;
            string izdatak = string.Empty;
            string izdatak_doprinos_mirovinsko = string.Empty;
            string dohodak = string.Empty;
            string osobni_odbitak = string.Empty;
            string porezna_osnovica = string.Empty;
            string porez_na_dohodak = string.Empty;
            string prirez = string.Empty;
            string obracunati_primitak = string.Empty;
            string isplata = string.Empty;
            string neoporeziv_primitak = string.Empty;

            foreach (DataRow row in tbl.Rows)
            {
                try
                {
                    sati_rada = row["SatiRada"].ToString().Replace(',', '.');
                    neodradeni_sati_rada = row["NeodradeniSatiRada"].ToString().Replace(',', '.');
                    razdoblje_do = Convert.ToDateTime(row["RazdobljeDo"].ToString()).ToString("yyyy.MM.dd");
                    razdoblje_od = Convert.ToDateTime(row["RazdobljeoD"].ToString()).ToString("yyyy.MM.dd");
                    primitak = row["Primitak"].ToString().Replace(',', '.');
                    osnovica = row["Osnovica"].ToString().Replace(',', '.');
                    doprinos_mirovinsko = row["DoprinosMirovinsko"].ToString().Replace(',', '.');
                    doprinos_mirovinskoII = row["DoprinosMirovinskoII"].ToString().Replace(',', '.');
                    doprinos_zdravstveno = row["DoprinosZdravstveno"].ToString().Replace(',', '.');
                    doprinos_zastita = row["DoprinosZastita"].ToString().Replace(',', '.');
                    doprinos_zaposljavanje = row["DoprinosZaposljavanje"].ToString().Replace(',', '.');
                    dodatni_doprinos_mirovinsko = row["DodatniDoprinosMirovinsko"].ToString().Replace(',', '.');
                    dodatni_doprinos_mirovinskoII = row["DodatniDoprinosMirovinskoII"].ToString().Replace(',', '.');
                    poseban_doprinos_zdravstveno = row["PosebanDoprinosZdravstveno"].ToString().Replace(',', '.');
                    poseban_doprinos_zaposljavanje = row["PosebanDoprinosZaposljavanje"].ToString().Replace(',', '.');
                    izdatak = row["Izdatak"].ToString().Replace(',', '.');
                    izdatak_doprinos_mirovinsko = row["IzdatakDoprinosMirovinsko"].ToString().Replace(',', '.');
                    dohodak = row["Dohodak"].ToString().Replace(',', '.');
                    osobni_odbitak = row["OsobniOdbitak"].ToString().Replace(',', '.');
                    porezna_osnovica = row["PoreznaOsnovica"].ToString().Replace(',', '.');
                    porez_na_dohodak = row["PorezNaDohodak"].ToString().Replace(',', '.');
                    prirez = row["Prirez"].ToString().Replace(',', '.');
                    obracunati_primitak = row["ObracunatiPrimitak"].ToString().Replace(',', '.');
                    isplata = row["Isplata"].ToString().Replace(',', '.');
                    neoporeziv_primitak = row["NeoporezivPrimitak"].ToString().Replace(',', '.');


                    client.ExecuteNonQuery("Insert Into JOPPDB (JOPPDAID, RedniBroj, SifraOpcinePrebivalista, SifraOpcineRada, OIBStjecatelja, ImePrezimeStjecatelja, OznakaStjecatelja, " +
                    "OznakaPrimitka, ObvezaDodatnogDoprinosa, ObvezaPosebnogDoprinosa, OznakaMjesecaOsiguranje, OznakaRadnogVremena, SatiRada, RazdobljeOd, " +
                    "RazdobljeDo, Primitak, Osnovica, DoprinosMirovinsko, DoprinosMirovinskoII, DoprinosZdravstveno, DoprinosZastita, DoprinosZaposljavanje, " +
                    "DodatniDoprinosMirovinsko, DodatniDoprinosMirovinskoII, PosebanDoprinosZdravstveno, PosebanDoprinosZaposljavanje, Izdatak, " +
                    "IzdatakDoprinosMirovinsko, Dohodak, OsobniOdbitak, PoreznaOsnovica, PorezNaDohodak, Prirez, OznakaNeoporezivogPrimitka, NeoporezivPrimitak, " +
                    "OznakaNacinaIsplate, Isplata, ObracunatiPrimitak, NeodradeniSatiRada) Values (" + row["JOPPDAID"].ToString() + ", " + row["RedniBroj"].ToString() + ",  " +
                    "'" + row["SifraOpcinePrebivalista"].ToString() + "', '" + row["SifraOpcineRada"].ToString() + "', '" + row["OIBStjecatelja"].ToString() + "', " +
                    "'" + row["ImePrezimeStjecatelja"].ToString() + "', '" + row["OznakaStjecatelja"].ToString() + "', '" + row["OznakaPrimitka"].ToString() + "', " +
                    "" + row["ObvezaDodatnogDoprinosa"].ToString() + ", " + row["ObvezaPosebnogDoprinosa"].ToString() + ", " + row["OznakaMjesecaOsiguranje"].ToString() + ", " +
                    "" + row["OznakaRadnogVremena"].ToString() + ", " + sati_rada + ", '" + razdoblje_od + "', " +
                    "'" + razdoblje_do + "', '" + primitak + "', '" + osnovica + "', '" + doprinos_mirovinsko + "', " +
                    "'" + doprinos_mirovinskoII + "', '" + doprinos_zdravstveno + "', '" + doprinos_zastita + "', " +
                    "'" + doprinos_zaposljavanje + "', '" + dodatni_doprinos_mirovinsko + "', '" + dodatni_doprinos_mirovinskoII + "', " +
                    "'" + poseban_doprinos_zdravstveno + "', '" + poseban_doprinos_zaposljavanje + "', '" + izdatak + "', " +
                    "'" + izdatak_doprinos_mirovinsko + "', '" + dohodak + "', '" + osobni_odbitak + "', " +
                    "'" + porezna_osnovica + "', '" + porez_na_dohodak + "', '" + prirez + "', '" + row["OznakaNeoporezivogPrimitka"].ToString() + "', " +
                    "'" + neoporeziv_primitak + "', '" + row["OznakaNacinaIsplate"].ToString() + "', '" + isplata + "', '" + obracunati_primitak + "', " + neodradeni_sati_rada + ")");
                }
                catch 
                {
                    return false;
                }
            }
            return true;
        }

        [CommandHandler("UvozCSV")]
        public void UvozCSVCommand(object sender, EventArgs e)
        {
            MessageBox.Show("Usluga uvoza obračunate plaće iz sustava COP kroz CSV datoteku je u implementaciji.\nZa uvoz obračunate plaće možete koristiti i JOPPD xml datoteku");
        }

        [CommandHandler("OsobeVeze")]
        public void OsobeVezeCommand(object sender, EventArgs e)
        {
            JOPPD.OsobeVezeWorkItem item = this.WorkItem.Items.Get<JOPPD.OsobeVezeWorkItem>("JOPPD.OsobeVeze");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<JOPPD.OsobeVezeWorkItem>("JOPPD.OsobeVeze");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSVRSTEOBRACUNACommand")]
        public void RSVRSTEOBRACUNACommand(object sender, EventArgs e)
        {
            RSVRSTEOBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<RSVRSTEOBRACUNAWorkWithWorkItem>("Placa.RSVRSTEOBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSVRSTEOBRACUNAWorkWithWorkItem>("Placa.RSVRSTEOBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.RSVRSTEOBVEZNIKACommand")]
        public void RSVRSTEOBVEZNIKACommand(object sender, EventArgs e)
        {
            RSVRSTEOBVEZNIKAWorkWithWorkItem item = this.WorkItem.Items.Get<RSVRSTEOBVEZNIKAWorkWithWorkItem>("Placa.RSVRSTEOBVEZNIKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<RSVRSTEOBVEZNIKAWorkWithWorkItem>("Placa.RSVRSTEOBVEZNIKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_KRIZNI_POREZCommand")]
        public void S_DD_KRIZNI_POREZCommand(object sender, EventArgs e)
        {
            S_DD_KRIZNI_POREZWorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_DD_KRIZNI_POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_DD_KRIZNI_POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_DD_LISTA_IZNOSA_RADNIKACommand")]
        public void S_DD_LISTA_IZNOSA_RADNIKACommand(object sender, EventArgs e)
        {
            S_DD_LISTA_IZNOSA_RADNIKAWorkWithWorkItem item = this.WorkItem.Items.Get<S_DD_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.S_DD_LISTA_IZNOSA_RADNIKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_DD_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.S_DD_LISTA_IZNOSA_RADNIKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_BOLOVANJE_FONDCommand")]
        public void S_OD_BOLOVANJE_FONDCommand(object sender, EventArgs e)
        {
            S_OD_BOLOVANJE_FONDWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_BOLOVANJE_FONDWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_FOND");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_BOLOVANJE_FONDWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_FOND");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_BOLOVANJE_POSLODAVACCommand")]
        public void S_OD_BOLOVANJE_POSLODAVACCommand(object sender, EventArgs e)
        {
            S_OD_BOLOVANJE_POSLODAVACWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_BOLOVANJE_POSLODAVACWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_POSLODAVAC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_BOLOVANJE_POSLODAVACWorkWithWorkItem>("Placa.S_OD_BOLOVANJE_POSLODAVAC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_IPPCommand")]
        public void S_OD_IPPCommand(object sender, EventArgs e)
        {
            S_OD_IPPWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_IPPWorkWithWorkItem>("Placa.S_OD_IPP");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_IPPWorkWithWorkItem>("Placa.S_OD_IPP");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_KREDIT_OBRACUNATCommand")]
        public void S_OD_KREDIT_OBRACUNATCommand(object sender, EventArgs e)
        {
            S_OD_KREDIT_OBRACUNATWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_KREDIT_OBRACUNATWorkWithWorkItem>("Placa.S_OD_KREDIT_OBRACUNAT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_KREDIT_OBRACUNATWorkWithWorkItem>("Placa.S_OD_KREDIT_OBRACUNAT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_KRIZNI_POREZCommand")]
        public void S_OD_KRIZNI_POREZCommand(object sender, EventArgs e)
        {
            S_OD_KRIZNI_POREZWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_OD_KRIZNI_POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_KRIZNI_POREZWorkWithWorkItem>("Placa.S_OD_KRIZNI_POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_OBUSTAVA_OBRACUNATACommand")]
        public void S_OD_OBUSTAVA_OBRACUNATACommand(object sender, EventArgs e)
        {
            S_OD_OBUSTAVA_OBRACUNATAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_OBUSTAVA_OBRACUNATAWorkWithWorkItem>("Placa.S_OD_OBUSTAVA_OBRACUNATA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_OBUSTAVA_OBRACUNATAWorkWithWorkItem>("Placa.S_OD_OBUSTAVA_OBRACUNATA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_OO_MJESECNOCommand")]
        public void S_OD_OO_MJESECNOCommand(object sender, EventArgs e)
        {
            S_OD_OO_MJESECNOWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_OO_MJESECNOWorkWithWorkItem>("Placa.S_OD_OO_MJESECNO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_OO_MJESECNOWorkWithWorkItem>("Placa.S_OD_OO_MJESECNO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_POREZ_MJESECNOCommand")]
        public void S_OD_POREZ_MJESECNOCommand(object sender, EventArgs e)
        {
            S_OD_POREZ_MJESECNOWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_POREZ_MJESECNOWorkWithWorkItem>("Placa.S_OD_POREZ_MJESECNO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_POREZ_MJESECNOWorkWithWorkItem>("Placa.S_OD_POREZ_MJESECNO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.s_od_pripremaCommand")]
        public void s_od_pripremaCommand(object sender, EventArgs e)
        {
            s_od_pripremaWorkWithWorkItem item = this.WorkItem.Items.Get<s_od_pripremaWorkWithWorkItem>("Placa.s_od_priprema");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<s_od_pripremaWorkWithWorkItem>("Placa.s_od_priprema");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_PROSJEK_PLACECommand")]
        public void S_OD_PROSJEK_PLACECommand(object sender, EventArgs e)
        {
            S_OD_PROSJEK_PLACEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_PROSJEK_PLACEWorkWithWorkItem>("Placa.S_OD_PROSJEK_PLACE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_PROSJEK_PLACEWorkWithWorkItem>("Placa.S_OD_PROSJEK_PLACE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.s_od_rekap_brutoCommand")]
        public void s_od_rekap_brutoCommand(object sender, EventArgs e)
        {
            s_od_rekap_brutoWorkWithWorkItem item = this.WorkItem.Items.Get<s_od_rekap_brutoWorkWithWorkItem>("Placa.s_od_rekap_bruto");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<s_od_rekap_brutoWorkWithWorkItem>("Placa.s_od_rekap_bruto");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.s_od_rekap_doprinosCommand")]
        public void s_od_rekap_doprinosCommand(object sender, EventArgs e)
        {
            s_od_rekap_doprinosWorkWithWorkItem item = this.WorkItem.Items.Get<s_od_rekap_doprinosWorkWithWorkItem>("Placa.s_od_rekap_doprinos");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<s_od_rekap_doprinosWorkWithWorkItem>("Placa.s_od_rekap_doprinos");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_FIKSNECommand")]
        public void S_OD_REKAP_FIKSNECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_FIKSNEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_FIKSNEWorkWithWorkItem>("Placa.S_OD_REKAP_FIKSNE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_FIKSNEWorkWithWorkItem>("Placa.S_OD_REKAP_FIKSNE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_ISPLATACommand")]
        public void S_OD_REKAP_ISPLATACommand(object sender, EventArgs e)
        {
            S_OD_REKAP_ISPLATAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_ISPLATAWorkWithWorkItem>("Placa.S_OD_REKAP_ISPLATA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_ISPLATAWorkWithWorkItem>("Placa.S_OD_REKAP_ISPLATA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_KREDITNECommand")]
        public void S_OD_REKAP_KREDITNECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_KREDITNEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_KREDITNEWorkWithWorkItem>("Placa.S_OD_REKAP_KREDITNE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_KREDITNEWorkWithWorkItem>("Placa.S_OD_REKAP_KREDITNE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_NETOCommand")]
        public void S_OD_REKAP_NETOCommand(object sender, EventArgs e)
        {
            S_OD_REKAP_NETOWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_NETOWorkWithWorkItem>("Placa.S_OD_REKAP_NETO");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_NETOWorkWithWorkItem>("Placa.S_OD_REKAP_NETO");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_OLAKSICECommand")]
        public void S_OD_REKAP_OLAKSICECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_OLAKSICEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_OLAKSICEWorkWithWorkItem>("Placa.S_OD_REKAP_OLAKSICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_OLAKSICEWorkWithWorkItem>("Placa.S_OD_REKAP_OLAKSICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_POREZCommand")]
        public void S_OD_REKAP_POREZCommand(object sender, EventArgs e)
        {
            S_OD_REKAP_POREZWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_POREZWorkWithWorkItem>("Placa.S_OD_REKAP_POREZ");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_POREZWorkWithWorkItem>("Placa.S_OD_REKAP_POREZ");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_REKAP_POSTOTNECommand")]
        public void S_OD_REKAP_POSTOTNECommand(object sender, EventArgs e)
        {
            S_OD_REKAP_POSTOTNEWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_REKAP_POSTOTNEWorkWithWorkItem>("Placa.S_OD_REKAP_POSTOTNE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_REKAP_POSTOTNEWorkWithWorkItem>("Placa.S_OD_REKAP_POSTOTNE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_STANJE_KREDITACommand")]
        public void S_OD_STANJE_KREDITACommand(object sender, EventArgs e)
        {
            S_OD_STANJE_KREDITAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_STANJE_KREDITAWorkWithWorkItem>("Placa.S_OD_STANJE_KREDITA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_STANJE_KREDITAWorkWithWorkItem>("Placa.S_OD_STANJE_KREDITA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_STANJE_OBUSTAVACommand")]
        public void S_OD_STANJE_OBUSTAVACommand(object sender, EventArgs e)
        {
            S_OD_STANJE_OBUSTAVAWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_STANJE_OBUSTAVAWorkWithWorkItem>("Placa.S_OD_STANJE_OBUSTAVA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_STANJE_OBUSTAVAWorkWithWorkItem>("Placa.S_OD_STANJE_OBUSTAVA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.S_OD_STAT_KREDITCommand")]
        public void S_OD_STAT_KREDITCommand(object sender, EventArgs e)
        {
            S_OD_STAT_KREDITWorkWithWorkItem item = this.WorkItem.Items.Get<S_OD_STAT_KREDITWorkWithWorkItem>("Placa.S_OD_STAT_KREDIT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<S_OD_STAT_KREDITWorkWithWorkItem>("Placa.S_OD_STAT_KREDIT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SKUPPOREZAIDOPRINOSACommand")]
        public void SKUPPOREZAIDOPRINOSACommand(object sender, EventArgs e)
        {
            SKUPPOREZAIDOPRINOSAWorkWithWorkItem item = this.WorkItem.Items.Get<SKUPPOREZAIDOPRINOSAWorkWithWorkItem>("Placa.SKUPPOREZAIDOPRINOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SKUPPOREZAIDOPRINOSAWorkWithWorkItem>("Placa.SKUPPOREZAIDOPRINOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_diskete_za_bankuCommand")]
        public void sp_diskete_za_bankuCommand(object sender, EventArgs e)
        {
            sp_diskete_za_bankuWorkWithWorkItem item = this.WorkItem.Items.Get<sp_diskete_za_bankuWorkWithWorkItem>("Placa.sp_diskete_za_banku");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_diskete_za_bankuWorkWithWorkItem>("Placa.sp_diskete_za_banku");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_id_detaljiCommand")]
        public void sp_id_detaljiCommand(object sender, EventArgs e)
        {
            sp_id_detaljiWorkWithWorkItem item = this.WorkItem.Items.Get<sp_id_detaljiWorkWithWorkItem>("Placa.sp_id_detalji");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_id_detaljiWorkWithWorkItem>("Placa.sp_id_detalji");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_id_zaglavljeCommand")]
        public void sp_id_zaglavljeCommand(object sender, EventArgs e)
        {
            sp_id_zaglavljeWorkWithWorkItem item = this.WorkItem.Items.Get<sp_id_zaglavljeWorkWithWorkItem>("Placa.sp_id_zaglavlje");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_id_zaglavljeWorkWithWorkItem>("Placa.sp_id_zaglavlje");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_ip_detaljiCommand")]
        public void sp_ip_detaljiCommand(object sender, EventArgs e)
        {
            sp_ip_detaljiWorkWithWorkItem item = this.WorkItem.Items.Get<sp_ip_detaljiWorkWithWorkItem>("Placa.sp_ip_detalji");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_ip_detaljiWorkWithWorkItem>("Placa.sp_ip_detalji");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_ip_zaglavljeCommand")]
        public void sp_ip_zaglavljeCommand(object sender, EventArgs e)
        {
            sp_ip_zaglavljeWorkWithWorkItem item = this.WorkItem.Items.Get<sp_ip_zaglavljeWorkWithWorkItem>("Placa.sp_ip_zaglavlje");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_ip_zaglavljeWorkWithWorkItem>("Placa.sp_ip_zaglavlje");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SP_LISTA_IZNOSA_RADNIKACommand")]
        public void SP_LISTA_IZNOSA_RADNIKACommand(object sender, EventArgs e)
        {
            SP_LISTA_IZNOSA_RADNIKAWorkWithWorkItem item = this.WorkItem.Items.Get<SP_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.SP_LISTA_IZNOSA_RADNIKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SP_LISTA_IZNOSA_RADNIKAWorkWithWorkItem>("Placa.SP_LISTA_IZNOSA_RADNIKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_maticni_kartonCommand")]
        public void sp_maticni_kartonCommand(object sender, EventArgs e)
        {
            sp_maticni_kartonWorkWithWorkItem item = this.WorkItem.Items.Get<sp_maticni_kartonWorkWithWorkItem>("Placa.sp_maticni_karton");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_maticni_kartonWorkWithWorkItem>("Placa.sp_maticni_karton");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_RSOBRAZACCommand")]
        public void sp_RSOBRAZACCommand(object sender, EventArgs e)
        {
            sp_RSOBRAZACWorkWithWorkItem item = this.WorkItem.Items.Get<sp_RSOBRAZACWorkWithWorkItem>("Placa.sp_RSOBRAZAC");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_RSOBRAZACWorkWithWorkItem>("Placa.sp_RSOBRAZAC");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_VIRMANICommand")]
        public void sp_VIRMANICommand(object sender, EventArgs e)
        {
            sp_VIRMANIWorkWithWorkItem item = this.WorkItem.Items.Get<sp_VIRMANIWorkWithWorkItem>("Placa.sp_VIRMANI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_VIRMANIWorkWithWorkItem>("Placa.sp_VIRMANI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.sp_zap1Command")]
        public void sp_zap1Command(object sender, EventArgs e)
        {
            sp_zap1WorkWithWorkItem item = this.WorkItem.Items.Get<sp_zap1WorkWithWorkItem>("Placa.sp_zap1");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<sp_zap1WorkWithWorkItem>("Placa.sp_zap1");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.SPOLCommand")]
        public void SPOLCommand(object sender, EventArgs e)
        {
            SPOLWorkWithWorkItem item = this.WorkItem.Items.Get<SPOLWorkWithWorkItem>("Placa.SPOL");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SPOLWorkWithWorkItem>("Placa.SPOL");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.STRUCNASPREMACommand")]
        public void STRUCNASPREMACommand(object sender, EventArgs e)
        {
            STRUCNASPREMAWorkWithWorkItem item = this.WorkItem.Items.Get<STRUCNASPREMAWorkWithWorkItem>("Placa.STRUCNASPREMA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<STRUCNASPREMAWorkWithWorkItem>("Placa.STRUCNASPREMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.STRUKACommand")]
        public void STRUKACommand(object sender, EventArgs e)
        {
            STRUKAWorkWithWorkItem item = this.WorkItem.Items.Get<STRUKAWorkWithWorkItem>("Placa.STRUKA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<STRUKAWorkWithWorkItem>("Placa.STRUKA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Tablica018Command")]
        public void Tablica018CommandHaneler(object sender, EventArgs e)
        {
            Tablica018WorkItem item = this.WorkItem.Items.Get<Tablica018WorkItem>("Tablica018WorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Tablica018WorkItem>("Tablica018WorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Tablica01Command")]
        public void Tablica01CommandHandler(object sender, EventArgs e)
        {
            Tablica01WorkItem item = this.WorkItem.Items.Get<Tablica01WorkItem>("Tablica01WorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Tablica01WorkItem>("Tablica01WorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.Tablica011Command")]
        public void Tablica011CommandHandler(object sender, EventArgs e)
        {
            Tablica011WorkItem item = this.WorkItem.Items.Get<Tablica011WorkItem>("Tablica011WorkItem");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Tablica011WorkItem>("Tablica011WorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        

        [CommandHandler("Placa.TIPIZNOSACommand")]
        public void TIPIZNOSACommand(object sender, EventArgs e)
        {
            TIPIZNOSAWorkWithWorkItem item = this.WorkItem.Items.Get<TIPIZNOSAWorkWithWorkItem>("Placa.TIPIZNOSA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPIZNOSAWorkWithWorkItem>("Placa.TIPIZNOSA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TIPOLAKSICECommand")]
        public void TIPOLAKSICECommand(object sender, EventArgs e)
        {
            TIPOLAKSICEWorkWithWorkItem item = this.WorkItem.Items.Get<TIPOLAKSICEWorkWithWorkItem>("Placa.TIPOLAKSICE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TIPOLAKSICEWorkWithWorkItem>("Placa.TIPOLAKSICE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.TITULACommand")]
        public void TITULACommand(object sender, EventArgs e)
        {
            TITULAWorkWithWorkItem item = this.WorkItem.Items.Get<TITULAWorkWithWorkItem>("Placa.TITULA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<TITULAWorkWithWorkItem>("Placa.TITULA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.V_DD_PREGLED_OBRACUNACommand")]
        public void V_DD_PREGLED_OBRACUNACommand(object sender, EventArgs e)
        {
            V_DD_PREGLED_OBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<V_DD_PREGLED_OBRACUNAWorkWithWorkItem>("Placa.V_DD_PREGLED_OBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<V_DD_PREGLED_OBRACUNAWorkWithWorkItem>("Placa.V_DD_PREGLED_OBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VALUTECommand")]
        public void VALUTECommand(object sender, EventArgs e)
        {
            VALUTEWorkWithWorkItem item = this.WorkItem.Items.Get<VALUTEWorkWithWorkItem>("Placa.VALUTE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VALUTEWorkWithWorkItem>("Placa.VALUTE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VERZIJACommand")]
        public void VERZIJACommand(object sender, EventArgs e)
        {
            VERZIJAWorkWithWorkItem item = this.WorkItem.Items.Get<VERZIJAWorkWithWorkItem>("Placa.VERZIJA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VERZIJAWorkWithWorkItem>("Placa.VERZIJA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VIRMANICommand")]
        public void VIRMANICommand(object sender, EventArgs e)
        {
            VIRMANIWorkWithWorkItem item = this.WorkItem.Items.Get<VIRMANIWorkWithWorkItem>("Placa.VIRMANI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VIRMANIWorkWithWorkItem>("Placa.VIRMANI");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VirmaniUserCommand")]
        public void VirmaniUserCommand(object sender, EventArgs e)
        {
            VirmaniWorkItemUser user = this.WorkItem.Items.Get<VirmaniWorkItemUser>("Virmani");
            if (user == null)
            {
                user = this.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Virmani");
            }
            user.Show(user.Workspaces["main"]);
        }

        [CommandHandler("Placa.VRSTADOPRINOSCommand")]
        public void VRSTADOPRINOSCommand(object sender, EventArgs e)
        {
            VRSTADOPRINOSWorkWithWorkItem item = this.WorkItem.Items.Get<VRSTADOPRINOSWorkWithWorkItem>("Placa.VRSTADOPRINOS");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VRSTADOPRINOSWorkWithWorkItem>("Placa.VRSTADOPRINOS");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VRSTAELEMENTCommand")]
        public void VRSTAELEMENTCommand(object sender, EventArgs e)
        {
            VRSTAELEMENTWorkWithWorkItem item = this.WorkItem.Items.Get<VRSTAELEMENTWorkWithWorkItem>("Placa.VRSTAELEMENT");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VRSTAELEMENTWorkWithWorkItem>("Placa.VRSTAELEMENT");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VRSTAOBUSTAVECommand")]
        public void VRSTAOBUSTAVECommand(object sender, EventArgs e)
        {
            VRSTAOBUSTAVEWorkWithWorkItem item = this.WorkItem.Items.Get<VRSTAOBUSTAVEWorkWithWorkItem>("Placa.VRSTAOBUSTAVE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VRSTAOBUSTAVEWorkWithWorkItem>("Placa.VRSTAOBUSTAVE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.vw_DD_MJESECI_GODINE_ISPLATECommand")]
        public void vw_DD_MJESECI_GODINE_ISPLATECommand(object sender, EventArgs e)
        {
            vw_DD_MJESECI_GODINE_ISPLATEWorkWithWorkItem item = this.WorkItem.Items.Get<vw_DD_MJESECI_GODINE_ISPLATEWorkWithWorkItem>("Placa.vw_DD_MJESECI_GODINE_ISPLATE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<vw_DD_MJESECI_GODINE_ISPLATEWorkWithWorkItem>("Placa.vw_DD_MJESECI_GODINE_ISPLATE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VW_GODINE_ISPLATECommand")]
        public void VW_GODINE_ISPLATECommand(object sender, EventArgs e)
        {
            VW_GODINE_ISPLATEWorkWithWorkItem item = this.WorkItem.Items.Get<VW_GODINE_ISPLATEWorkWithWorkItem>("Placa.VW_GODINE_ISPLATE");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VW_GODINE_ISPLATEWorkWithWorkItem>("Placa.VW_GODINE_ISPLATE");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.VW_GODINE_OBRACUNACommand")]
        public void VW_GODINE_OBRACUNACommand(object sender, EventArgs e)
        {
            VW_GODINE_OBRACUNAWorkWithWorkItem item = this.WorkItem.Items.Get<VW_GODINE_OBRACUNAWorkWithWorkItem>("Placa.VW_GODINE_OBRACUNA");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<VW_GODINE_OBRACUNAWorkWithWorkItem>("Placa.VW_GODINE_OBRACUNA");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.vw_mjeseci_godine_isplateCommand")]
        public void vw_mjeseci_godine_isplateCommand(object sender, EventArgs e)
        {
            vw_mjeseci_godine_isplateWorkWithWorkItem item = this.WorkItem.Items.Get<vw_mjeseci_godine_isplateWorkWithWorkItem>("Placa.vw_mjeseci_godine_isplate");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<vw_mjeseci_godine_isplateWorkWithWorkItem>("Placa.vw_mjeseci_godine_isplate");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("ZAP1Command")]
        public void ZAP1CommandHandler(object sender, EventArgs e)
        {
            Zap1WorkItem item = this.WorkItem.Items.Get<Zap1WorkItem>("Zap1");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Zap1WorkItem>("Zap1");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.ZAPOSLENICommand")]
        public void ZAPOSLENICommand(object sender, EventArgs e)
        {
            ZAPOSLENIWorkWithWorkItem item = this.WorkItem.Items.Get<ZAPOSLENIWorkWithWorkItem>("Placa.ZAPOSLENI");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<ZAPOSLENIWorkWithWorkItem>("Placa.ZAPOSLENI");
            }
            item.Show(item.Workspaces["main"]);
        }
    }
}

