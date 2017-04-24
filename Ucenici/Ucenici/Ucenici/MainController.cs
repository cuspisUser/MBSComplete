namespace Ucenici.Ucenici
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using Mipsed7.DataAccessLayer;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections;
    using System.Data;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
   

    public class MainController : Controller
    {
        [CommandHandler("IDD-1")]
        public void IDD1Command(object sender, EventArgs e)
        {
            int nMjesec = 0;
            int num = 0;
            decimal num3 = 0;
            IEnumerator enumerator = null;
            UCENIKOBRACUNDataSet dataSet = new UCENIKOBRACUNDataSet();
            new UCENIKOBRACUNDataAdapter().Fill(dataSet);
            try
            {
                enumerator = dataSet.UCENIKOBRACUN.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                    if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue, new object[] { "aktivanzarsm" }, null), true, false))
                    {
                        DataRow current1 = (DataRow)enumerator.Current;
                        nMjesec = (int)(current1["ucobrmjesec"]);

                        IEnumerator enumerator2 = null;
                        try
                        {
                            enumerator2 = dataSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                DataRow current = (DataRow) enumerator2.Current;
                                if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(current["ucobrmjesec"], NewLateBinding.LateIndexGet(objectValue, new object[] { "ucobrmjesec" }, null), false), Operators.CompareObjectEqual(current["ucobrgodina"], NewLateBinding.LateIndexGet(objectValue, new object[] { "ucobrgodina" }, null), false))))
                                {
                                    num3 = Conversions.ToDecimal(Operators.AddObject(num3, current["obracunosnovicepraksa"]));
                                    num++;
                                }
                            }
                            continue;
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
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
            decimal num2 = DB.RoundUP(decimal.Divide(decimal.Multiply(num3, 5M), 100M));
            decimal num4 = DB.RoundUP((Convert.ToDouble(num3) * 0.5) / 100.0);
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - IDD-1",
                Description = "Pregled izvještaja - IDD-1",
                Icon = ImageResourcesNew.mbs
            };
            KORISNIKDataAdapter adapter2 = new KORISNIKDataAdapter();
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            adapter2.Fill(set2);
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptObrazacIDD-1.RPT");
            document.SetParameterValue("USTANOVA", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ADRESA", Operators.AddObject(Operators.AddObject(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"], ","), set2.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            document.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
            document.SetParameterValue("TOCKA33", num2);
            document.SetParameterValue("TOCKA38", num4);
            document.SetParameterValue("OSNOVICA", num3);
            document.SetParameterValue("BROJKOMADA", num);
            document.SetParameterValue("DATUM", DateAndTime.Today);
            document.SetParameterValue("naslov", "o isplaćenoj naknadi plaće te o osnovicama i obračunatim i uplaćenim doprinosima za obvezna osiguranja u mjesecu " + DB.MjesecNazivDativ(nMjesec));
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        [CommandHandler("Import")]
        public void ImportUcenika(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Please Select a File",
                InitialDirectory = @"C\:Desktop",
                Filter = "XML datoteke (*.xml)|*.xml|All files (*.*)|*.*",
                FileName = ""
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IEnumerator enumerator = null;
                IEnumerator enumeratorOdjeljenje = null;

                string fileName = dialog.FileName.ToString();
                DataSet set = new DataSet();
                set.ReadXml(fileName);

                if (set.Tables[0] == null || set.Tables[3] == null)
                {
                    Interaction.MsgBox("XML datoteka za importiranje učenika, nije pravilno formatirana!", MsgBoxStyle.OkOnly, null);
                    return;
                }

                Ucenik[] ucenikArray = new Ucenik[set.Tables[3].Rows.Count + 1];
                int index = 0;
                try
                {
                    if (set.Tables[0].Columns["Textbox36"] == null)
                    {
                        throw new System.Exception("XML datoteka ne sadrži informaciju RAZREDA i ODJELJENJA!");
                    }

                    enumerator = set.Tables[3].Rows.GetEnumerator();
                    enumeratorOdjeljenje = set.Tables[0].Rows.GetEnumerator();

                    string razred, odjeljenje;

                    enumeratorOdjeljenje.MoveNext();
                    DataRow currentOdjeljenje = (DataRow)enumeratorOdjeljenje.Current;
                    string strData = currentOdjeljenje["Textbox36"].ToString();


                    // parsiramo string
                    if (strData.Contains(". razred osnovne škole, odjeljenje:"))
                    {
                        razred = strData.Substring(0, strData.IndexOf(". razred osnovne škole")).Trim();
                        odjeljenje = strData.Substring(strData.IndexOf(":") + 1, strData.Length - strData.IndexOf(":") - 1).Trim();
                    }
                    else if (strData.Contains(". razred srednje škole, odjeljenje:"))
                    {
                        razred = strData.Substring(0, strData.IndexOf(". razred srednje škole")).Trim();
                        odjeljenje = strData.Substring(strData.IndexOf(":") + 1, strData.Length - strData.IndexOf(":") - 1).Trim();
                    }
                    else
                    {
                        // nije prošlo niti jedno parsiranje
                        throw new System.Exception("eMatica - XML datoteka // Nepoznati format podatka '" + currentOdjeljenje["Textbox36"] + "'");
                    }

                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;

                        ucenikArray[index].sifra = Conversions.ToString(DBNullToString(current["ucenik_id"], "-"));
                        ucenikArray[index].ime = Conversions.ToString(DBNullToString(current["ime"], "-"));
                        ucenikArray[index].prezime = Conversions.ToString(DBNullToString(current["prezime"], "-"));
                        ucenikArray[index].SPOL = Conversions.ToString(DBNullToString(current["Spol"], "-"));

                        // 5? - "XXI/4581"?? -> Matični broj?

                        ucenikArray[index].oib = Conversions.ToString(DBNullToString(current["OIB"], "-"));
                        ucenikArray[index].JMBG = Conversions.ToString(DBNullToString(current["JMBG"], "-"));

                        // 9? - "Hrvatska"??

                        ucenikArray[index].DATUMRODJ = Conversions.ToDate(DBNullToString(current["DatumRodjenja"], "-"));

                        // Matija Božičević - 21.09.2012
                        // eMatica je mijenjala shemu XML-a
                        ucenikArray[index].raz = razred;
                        ucenikArray[index].odj = odjeljenje;

                        ucenikArray[index].ULICAIBROJ = string.Empty;
                        ucenikArray[index].NASELJE = string.Empty;
                        ucenikArray[index].POSTANSKIBROJ = "0"; // NEPOZNATA POŠTA

                        index++;
                    }

                    UCENIKDataAdapter adapter = new UCENIKDataAdapter();
                    UCENIKDataSet dataSet = new UCENIKDataSet();
                    int num2 = ucenikArray.Length - 1;
                    index = 0;
                    while (index <= num2)
                    {
                        if (ucenikArray[index].sifra != null)
                        {
                            DataRow row = dataSet.UCENIK.NewRow();
                            try
                            {
                                row["iducenik"] = ucenikArray[index].sifra;
                                row["prezimeucenik"] = ucenikArray[index].prezime;
                                row["imeucenik"] = ucenikArray[index].ime;
                                row["oibucenik"] = ucenikArray[index].oib;
                                row["razred"] = ucenikArray[index].raz;
                                row["odjeljenje"] = ucenikArray[index].odj;
                                row["SPOLUCENIKA"] = ucenikArray[index].SPOL;
                                row["ULICAIBROJ"] = ucenikArray[index].ULICAIBROJ;
                                row["NASELJE"] = ucenikArray[index].NASELJE;
                                row["JMBGUCENIKA"] = ucenikArray[index].JMBG;
                                row["DATUMRODJENJAUCENIKA"] = ucenikArray[index].DATUMRODJ;
                                row["POSTANSKIBROJ"] = ucenikArray[index].POSTANSKIBROJ;
                                row["IMERODITELJA"] = "";

                                dataSet.UCENIK.Rows.Add(row);
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                            }
                        }

                        index++;
                    }

                    adapter.Update(dataSet);

                    Interaction.MsgBox("Prebačeno: " + Conversions.ToString(index) + " učenika", MsgBoxStyle.OkOnly, null);
                }
                catch (System.Exception exception)
                {
                    new Mipsed7.Emailing.SendException(exception).Send();
                    Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly);
                    
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }

        [CommandHandler("Import2")]
        public void Import2Ucenika(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Please Select a File",
                InitialDirectory = @"C\:Desktop",
                Filter = "XML datoteke (*.xml)|*.xml|All files (*.*)|*.*",
                FileName = ""
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IEnumerator enumerator = null;
  
                string fileName = dialog.FileName.ToString();
                DataSet set = new DataSet();
                set.ReadXml(fileName);

                if (set.Tables[0] == null || set.Tables[1] == null)
                {
                    Interaction.MsgBox("XML datoteka za importiranje učenika, nije pravilno formatirana!", MsgBoxStyle.OkOnly, null);
                    return;
                }

                Ucenik[] ucenikArray = new Ucenik[set.Tables[1].Rows.Count + 1];
                int index = 0;
                try
                {
                    SqlClient client = new SqlClient();
                    int id_ucenik; 
                    try
                    {
                        id_ucenik = (int)client.ExecuteScalar("Select Max(IDUCENIK + 1) From UCENIK");
                    }
                    catch
                    {
                        id_ucenik = 1;
                    }

                    enumerator = set.Tables[1].Rows.GetEnumerator();

                    string razred, odjeljenje,timeString;
                    DateTime dateVal;
                    var usCulture = "en-US";

                    try
                    {
                        razred = dialog.SafeFileName.Split('.')[0].ToString();
                        odjeljenje = dialog.SafeFileName.Split('.')[1].ToString();
                    }
                    catch 
                    {
                        Interaction.MsgBox("Nije moguće odrediti Razred i odjeljenje!", MsgBoxStyle.OkOnly, null);
                        return;
                    }

                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;

                        if(current["A"].ToString() == "Ime" && current["B"].ToString() == "Prezime")
                        {
                            continue;
                        }

                        ucenikArray[index].sifra = Conversions.ToString(DBNullToString(id_ucenik, "-"));
                        ucenikArray[index].ime = Conversions.ToString(DBNullToString(current["A"], "-"));
                        ucenikArray[index].prezime = Conversions.ToString(DBNullToString(current["B"], "-"));
                        ucenikArray[index].SPOL = Conversions.ToString(DBNullToString(current["L"], "-"));

                        ucenikArray[index].oib = Conversions.ToString(DBNullToString(current["C"], "-"));
                        ucenikArray[index].JMBG = Conversions.ToString(DBNullToString("-", "-"));


                        timeString = current["D"].ToString().Split(' ')[0];

                        dateVal = DateTime.Parse(timeString, new CultureInfo(usCulture, false));

                        ucenikArray[index].DATUMRODJ =dateVal;

                        ucenikArray[index].raz = razred;
                        ucenikArray[index].odj = odjeljenje;

                        ucenikArray[index].ULICAIBROJ = string.Empty;
                        ucenikArray[index].NASELJE = string.Empty;
                        ucenikArray[index].POSTANSKIBROJ = "0";

                        index++;
                        id_ucenik++;
                    }

                    UCENIKDataAdapter adapter = new UCENIKDataAdapter();
                    UCENIKDataSet dataSet = new UCENIKDataSet();
                    int num2 = ucenikArray.Length - 1;
                    index = 0;
                    while (index <= num2)
                    {
                        if (ucenikArray[index].sifra != null)
                        {
                            DataRow row = dataSet.UCENIK.NewRow();
                            try
                            {
                                row["iducenik"] = ucenikArray[index].sifra;
                                row["prezimeucenik"] = ucenikArray[index].prezime;
                                row["imeucenik"] = ucenikArray[index].ime;
                                row["oibucenik"] = ucenikArray[index].oib;
                                row["razred"] = ucenikArray[index].raz;
                                row["odjeljenje"] = ucenikArray[index].odj;
                                row["SPOLUCENIKA"] = ucenikArray[index].SPOL;
                                row["ULICAIBROJ"] = ucenikArray[index].ULICAIBROJ;
                                row["NASELJE"] = ucenikArray[index].NASELJE;
                                row["JMBGUCENIKA"] = ucenikArray[index].JMBG;
                                row["DATUMRODJENJAUCENIKA"] = ucenikArray[index].DATUMRODJ;
                                row["POSTANSKIBROJ"] = ucenikArray[index].POSTANSKIBROJ;
                                row["IMERODITELJA"] = "";

                                dataSet.UCENIK.Rows.Add(row);
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                            }
                        }

                        index++;
                    }

                    adapter.Update(dataSet);

                    Interaction.MsgBox("Prebačeno: " + set.Tables[1].Rows.Count + " učenika", MsgBoxStyle.OkOnly, null);
                }
                catch (System.Exception exception)
                {
                    new Mipsed7.Emailing.SendException(exception).Send();
                    Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly);

                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }

        public object DBNullToString(object value, string defaultValue)
        {
            if (value == DBNull.Value)
                return defaultValue;

            return value;
        }

        [CommandHandler("Ucenik.Obracun")]
        public void UcenikObracunHandler(object sender, EventArgs e)
        {
            UceniciCustomWorkItem item = this.WorkItem.Items.Get<UceniciCustomWorkItem>("Ucenik.Obracun");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UceniciCustomWorkItem>("Ucenik.Obracun");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Placa.UCENIKCommand")]
        public void UCENIKpREGLEDCommand(object sender, EventArgs e)
        {
            UCENIKWorkWithWorkItem item = this.WorkItem.Items.Get<UCENIKWorkWithWorkItem>("Placa.UCENIK");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<UCENIKWorkWithWorkItem>("Placa.UCENIK");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Tiskanica-5")]
        public void IspisTiskanice5(object sender, EventArgs e)
        {
            Tiskanica5WorkItem item = this.WorkItem.Items.Get<Tiskanica5WorkItem>("Tiskanica-5");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<Tiskanica5WorkItem>("Tiskanica-5");
            }
            item.Show(item.Workspaces["main"]);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Ucenik
        {
            public string sifra;
            public string ime;
            public string prezime;
            public string oib;
            public string raz;
            public string odj;
            public string SPOL;
            public string ULICAIBROJ;
            public string NASELJE;
            public string JMBG;
            public DateTime DATUMRODJ;
            public string POSTANSKIBROJ;
        }
    }
}

