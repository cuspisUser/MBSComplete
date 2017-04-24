
using CrystalDecisions.CrystalReports.Engine;
using DDModule;
using DDModule.DDModule;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using PlacaExe;

namespace ePoreznaModule.ePoreznaModule
{

    public class MainController : Controller
    {
        [CommandHandler("ID-2011")]
        public void id2011Command(object sender, EventArgs e)
        {
            dsIdObrazac obrazac = new dsIdObrazac();
            sp_id_detaljiDataAdapter adapter2 = new sp_id_detaljiDataAdapter();
            sp_id_zaglavljeDataAdapter adapter3 = new sp_id_zaglavljeDataAdapter();
            sp_id_detaljiDataSet dataSet = new sp_id_detaljiDataSet();
            sp_id_zaglavljeDataSet set3 = new sp_id_zaglavljeDataSet();
            SqlConnection connection = new SqlConnection();
            string str2 = null;
            string str = null;
            connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
            frmPregledMjeseciGodina godina = new frmPregledMjeseciGodina();
            godina.ShowDialog();
            if (godina.DialogResult != DialogResult.Cancel)
            {
                decimal num = 0;
                decimal num2 = 0;
                sPorezIprirezPremaOpciniGraduObracunatiPorez[] porezArray = null;
                decimal num3 = 0;
                if ((godina.OdabraniGodinaIsplate != null) & (godina.OdabraniMjesecIsplate != null))
                {
                    set3.Clear();
                    dataSet.Clear();
                    str2 = Conversions.ToString(godina.OdabraniMjesecIsplate);
                    str = Conversions.ToString(godina.OdabraniGodinaIsplate);
                    adapter3.Fill(set3, null, Conversions.ToString(godina.OdabraniMjesecIsplate), Conversions.ToString(godina.OdabraniGodinaIsplate), godina.Volonteri);
                    adapter2.Fill(dataSet, null, Conversions.ToString(godina.OdabraniMjesecIsplate), Conversions.ToString(godina.OdabraniGodinaIsplate), godina.Volonteri);
                    obrazac.Clear();
                    obrazac.Merge(dataSet.sp_id_detalji);
                    obrazac.Merge(set3.sp_id_zaglavlje);
                }
                KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
                KORISNIKDataSet set2 = new KORISNIKDataSet();
                adapter.Fill(set2);

                sObrazacID o = new sObrazacID();
                sIDmetapodaci dmetapodaci = new sIDmetapodaci();

                dmetapodaci.Naslov = new sNaslovTemeljni();
                dmetapodaci.Naslov.Value = "ID obrazac";
                dmetapodaci.Naslov.dc = "http://purl.org/dc/elements/1.1/title";

                dmetapodaci.Autor = new sAutorTemeljni();
                dmetapodaci.Autor.Value = "VugerGRAD d.o.o.";
                dmetapodaci.Autor.dc = "http://purl.org/dc/elements/1.1/creator";

                dmetapodaci.Datum = new sDatumTemeljni();
                dmetapodaci.Datum.Value = DateAndTime.Now.ToString("s");
                dmetapodaci.Datum.dc = "http://purl.org/dc/elements/1.1/date";

                dmetapodaci.Format = new sFormatTemeljni();
                dmetapodaci.Format.Value = PlacaExe.tFormat.textxml;
                dmetapodaci.Format.dc = "http://purl.org/dc/elements/1.1/format";

                dmetapodaci.Jezik = new sJezikTemeljni();
                dmetapodaci.Jezik.Value = PlacaExe.tJezik.hrHR;
                dmetapodaci.Jezik.dc = "http://purl.org/dc/elements/1.1/language";

                dmetapodaci.Identifikator = new sIdentifikatorTemeljni();
                dmetapodaci.Identifikator.Value = Guid.NewGuid().ToString(); //"dc0e2097-c43b-41f3-a095-dcf327268fad";
                dmetapodaci.Identifikator.dc = "http://purl.org/dc/elements/1.1/identifier";

                dmetapodaci.Uskladjenost = new sUskladjenost();
                dmetapodaci.Uskladjenost.Value = "ObrazacID-v3-0";
                dmetapodaci.Uskladjenost.dc = "http://purl.org/dc/terms/conformsTo";

                dmetapodaci.Tip = new sTipTemeljni();
                dmetapodaci.Tip.Value = PlacaExe.tTip.Elektroničkiobrazac;
                dmetapodaci.Tip.dc = "http://purl.org/dc/elements/1.1/type";

                dmetapodaci.Adresant = new sAdresantTemeljni();
                dmetapodaci.Adresant.Value = "Ministarstvo Financija, Porezna uprava, Zagreb";


                o.verzijaSheme = "3.0";
                o.Metapodaci = dmetapodaci;
                sZaglavlje zaglavlje = new sZaglavlje();
                sZaglavljePodnositeljZahtjeva zahtjeva = new sZaglavljePodnositeljZahtjeva();
                sAdresa adresa = new sAdresa();
                sRazdoblje razdoblje = new sRazdoblje();

                zahtjeva.Naziv = Conversions.ToString(set2.KORISNIK[0]["KORISNIK1NAZIV"]);
                zahtjeva.OIB = Conversions.ToString(set2.KORISNIK[0]["KORISNIKOIB"]);

                try
                {
                    adresa.Ulica = set2.KORISNIK[0]["KORISNIK1ADRESA"].ToString().Replace(DB.IzvuciSamoBrojke(set2.KORISNIK[0]["KORISNIK1ADRESA"].ToString(), false), "");
                }
                catch (Exception)
                {
                    throw new Exception("Problem u izvlačenju brojčanog kućnog broja iz ulice!");
                }

                adresa.Broj = DB.IzvuciSamoBrojke(set2.KORISNIK[0]["KORISNIK1ADRESA"].ToString(), false);
                adresa.Mjesto = Conversions.ToString(set2.KORISNIK[0]["KORISNIK1MJESTO"]);
                zahtjeva.Adresa = adresa;
                zaglavlje.PodnositeljZahtjeva = zahtjeva;
                zaglavlje.PodrucniUred = Conversions.ToString(set2.KORISNIK[0]["NADLEZNAPU"]);
                if (Operators.ConditionalCompareObjectEqual(obrazac.sp_id_zaglavlje[0]["identifikator"], 1, false))
                {
                    zaglavlje.Identifikator = sIdentifikator.Item1;
                }
                if (Operators.ConditionalCompareObjectEqual(obrazac.sp_id_zaglavlje[0]["identifikator"], 11, false))
                {
                    zaglavlje.Identifikator = sIdentifikator.Item12;
                }
                zaglavlje.Ispostava = Conversions.ToString(set2.KORISNIK[0]["BROJCANAOZNAKAPU"]);
                razdoblje.DatumOd = DateAndTime.DateSerial(Conversions.ToInteger(str), Conversions.ToInteger(str2), 1);
                razdoblje.DatumDo = DateAndTime.DateSerial(Conversions.ToInteger(str), Conversions.ToInteger(str2), DateTime.DaysInMonth(Conversions.ToInteger(str), Conversions.ToInteger(str2)));
                zaglavlje.Razdoblje = razdoblje;
                o.Zaglavlje = zaglavlje;
                sIsplaceniPrimiciIObracunPoreza poreza = new sIsplaceniPrimiciIObracunPoreza();
                sTijelo tijelo = new sTijelo();
                poreza.Podatak100 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_1"]), 2);
                poreza.Podatak200 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_2"]), 2);
                poreza.Podatak210 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_2_1_1"]), 2);
                poreza.Podatak220 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_2_1_2"]), 2);
                poreza.Podatak230 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_2_1_3"]), 2);
                poreza.Podatak300 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_3"]), 2);
                poreza.Podatak400 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_4"]), 2);
                poreza.Podatak500 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_5"]), 2);
                poreza.Podatak600 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_6"]), 2);
                poreza.Podatak610 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_6_1"]), 2);
                poreza.Podatak620 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_6_2"]), 2);
                poreza.Podatak700 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_II_7"]), 2);
                poreza.Podatak800 = Conversions.ToString(obrazac.sp_id_zaglavlje[0]["REDAK_II_8"]);
                sDoprinosiUkupno ukupno = new sDoprinosiUkupno {
                    Podatak110 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_1_1"]), 2),
                    Podatak120 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_1_2"]), 2),
                    Podatak210 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_2_1"]), 2),
                    Podatak220 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_2_2"]), 2),
                    Podatak310 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_3_1"]), 2),
                    Podatak320 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_3_2"]), 2),
                    Podatak330 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_3_3"]), 2),
                    Podatak410 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_4_1"]), 2),
                    Podatak420 = decimal.Round(Conversions.ToDecimal(obrazac.sp_id_zaglavlje[0]["REDAK_III_4_2"]), 2),
                    Podatak500 = Conversions.ToString(obrazac.sp_id_zaglavlje[0]["REDAK_III_5"])
                };
                porezArray = (sPorezIprirezPremaOpciniGraduObracunatiPorez[]) Utils.CopyArray((Array) porezArray, new sPorezIprirezPremaOpciniGraduObracunatiPorez[obrazac.sp_id_detalji.Rows.Count + 1]);
                int num5 = obrazac.sp_id_detalji.Rows.Count - 1;
                for (int i = 0; i <= num5; i++)
                {
                    porezArray[i] = new sPorezIprirezPremaOpciniGraduObracunatiPorez();
                    sPorezIprirezPremaOpciniGraduObracunatiPorez porez = porezArray[i];
                    porez.Poreza = Conversions.ToDecimal(obrazac.sp_id_detalji.Rows[i]["obracunaniporez"]);
                    num = Conversions.ToDecimal(Operators.AddObject(num, obrazac.sp_id_detalji.Rows[i]["obracunaniporez"]));
                    porez.Prireza = Conversions.ToDecimal(obrazac.sp_id_detalji.Rows[i]["obracunaniprirez"]);
                    num2 = Conversions.ToDecimal(Operators.AddObject(num2, obrazac.sp_id_detalji.Rows[i]["obracunaniprirez"]));
                    porez.Ukupno = Conversions.ToDecimal(obrazac.sp_id_detalji.Rows[i]["obracunanoukupno"]);
                    num3 = Conversions.ToDecimal(Operators.AddObject(num3, obrazac.sp_id_detalji.Rows[i]["obracunanoukupno"]));
                    porez.Sifra = Conversions.ToString(obrazac.sp_id_detalji.Rows[i]["idopcine"]);
                    porez = null;
                }
                sUkupno ukupno2 = new sUkupno {
                    Poreza = num,
                    Prireza = num2,
                    Ukupno = num3
                };
                tijelo.IsplaceniPrimiciIObracunPoreza = poreza;
                tijelo.DoprinosiUkupno = ukupno;
                tijelo.ObracunatiPorezi = porezArray;
                tijelo.Ukupno = ukupno2;
                o.Tijelo = tijelo;
                try
                {
                    SaveFileDialog dialog2 = new SaveFileDialog {
                        InitialDirectory = Conversions.ToString(0),
                        FileName = "ID-" + str + "-" + str2 + ".xml",
                        RestoreDirectory = true
                    };
                    SaveFileDialog dialog = dialog2;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter writer = new StreamWriter(dialog.FileName))
                        {
                            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                            namespaces.Add("", "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0");
                            new XmlSerializer(typeof(sObrazacID), "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0").Serialize(writer, o, namespaces);

                            writer.Close();
                        }
                        Interaction.MsgBox("Datoteka uspješno  spremljena u: " + dialog.FileName, MsgBoxStyle.OkOnly, null);
                    }
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }

        [CommandHandler("IDD")]
        public void OePoreznaIDDCommand(object sender, EventArgs e)
        {
            IDDDataset dataSet = new IDDDataset();
            ReportDocument document = new ReportDocument();
            frmDDPregledMjeseciGodina godina = new frmDDPregledMjeseciGodina();
            godina.ShowDialog();
            DataRow row = dataSet.test.NewRow();
            row["idtest"] = 0x63;
            dataSet.test.Rows.Add(row);
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
                    adapter2.Fill(dataSet, "kolona3");
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
                    adapter3.Fill(dataSet, "kolona4");
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
                    adapter4.Fill(dataSet, "kolona5");
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
                    adapter5.Fill(dataSet, "kolona6");
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
                    adapter6.Fill(dataSet, "kolona7");
                }
                string str2 = string.Format("{0:00}", RuntimeHelpers.GetObjectValue(godina.OdabraniMjesecIsplate));
                string str = string.Format("{0:0000}", RuntimeHelpers.GetObjectValue(godina.OdabraniGodinaIsplate));
                string str3 = DB.MjesecNazivDativ(Conversions.ToInteger(godina.OdabraniMjesecIsplate)).ToUpper() + " " + str + ". godine";
                KORISNIKDataSet set = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(set);
                sObrazacIDD o = new sObrazacIDD();

                sIDDmetapodaci dmetapodaci = new sIDDmetapodaci();
                DDModule.DDModule.sNaslovTemeljni temeljni7 = new DDModule.DDModule.sNaslovTemeljni();
                DDModule.DDModule.sAutorTemeljni temeljni2 = new DDModule.DDModule.sAutorTemeljni();
                DDModule.DDModule.sDatumTemeljni temeljni3 = new DDModule.DDModule.sDatumTemeljni();
                DDModule.DDModule.sFormatTemeljni temeljni4 = new DDModule.DDModule.sFormatTemeljni();
                DDModule.DDModule.sJezikTemeljni temeljni6 = new DDModule.DDModule.sJezikTemeljni();
                DDModule.DDModule.sIdentifikatorTemeljni temeljni5 = new DDModule.DDModule.sIdentifikatorTemeljni();
                DDModule.DDModule.sUskladjenost uskladjenost = new DDModule.DDModule.sUskladjenost();
                DDModule.DDModule.sTipTemeljni temeljni8 = new DDModule.DDModule.sTipTemeljni();
                DDModule.DDModule.sAdresantTemeljni temeljni = new DDModule.DDModule.sAdresantTemeljni();

                temeljni7.Value = "IDD obrazac";
                temeljni7.dc = "http://purl.org/dc/elements/1.1/title";

                temeljni2.Value = "VugerGRAD d.o.o.";
                temeljni2.dc = "http://purl.org/dc/elements/1.1/creator";

                temeljni3.Value = DateAndTime.Now.ToString("s");
                temeljni3.dc = "http://purl.org/dc/elements/1.1/date";

                temeljni4.Value = DDModule.DDModule.tFormat.textxml;
                temeljni4.dc = "http://purl.org/dc/elements/1.1/format";

                temeljni6.Value = DDModule.DDModule.tJezik.hrHR;
                temeljni6.dc = "http://purl.org/dc/elements/1.1/language";

                temeljni5.Value = Guid.NewGuid().ToString(); //"dc0e2097-c43b-41f3-a095-dcf327268fad";
                temeljni5.dc = "http://purl.org/dc/elements/1.1/identifier";

                uskladjenost.Value = "ObrazacIDD-v1-0";
                uskladjenost.dc = "http://purl.org/dc/terms/conformsTo";

                temeljni8.Value = DDModule.DDModule.tTip.Elektroničkiobrazac;
                temeljni8.dc = "http://purl.org/dc/elements/1.1/type";

                temeljni.Value = "Ministarstvo Financija, Porezna uprava, Zagreb";

                dmetapodaci.Naslov = temeljni7;
                dmetapodaci.Autor = temeljni2;
                dmetapodaci.Datum = temeljni3;
                dmetapodaci.Format = temeljni4;
                dmetapodaci.Jezik = temeljni6;
                dmetapodaci.Identifikator = temeljni5;
                dmetapodaci.Uskladjenost = uskladjenost;
                dmetapodaci.Tip = temeljni8;
                dmetapodaci.Adresant = temeljni;
                o.verzijaSheme = "1.0";
                o.Metapodaci = dmetapodaci;
                DDModule.DDModule.sZaglavlje zaglavlje = new DDModule.DDModule.sZaglavlje();
                DDModule.DDModule.sZaglavljePodnositeljZahtjeva zahtjeva = new DDModule.DDModule.sZaglavljePodnositeljZahtjeva();
                DDModule.DDModule.sAdresa adresa = new DDModule.DDModule.sAdresa();
                DDModule.DDModule.sRazdoblje razdoblje = new DDModule.DDModule.sRazdoblje();
                zahtjeva.Naziv = Conversions.ToString(set.KORISNIK[0]["KORISNIK1NAZIV"]);
                zahtjeva.OIB = Conversions.ToString(set.KORISNIK[0]["KORISNIKOIB"]);

                try
                {
                    adresa.Ulica = set.KORISNIK[0]["KORISNIK1ADRESA"].ToString().Replace(DB.IzvuciSamoBrojke(set.KORISNIK[0]["KORISNIK1ADRESA"].ToString(), false), "");
                }
                catch (Exception)
                {
                    throw new Exception("Problem u izvlačenju brojčanog kućnog broja iz ulice!");
                }

                adresa.Broj = DB.IzvuciSamoBrojke(set.KORISNIK[0]["KORISNIK1ADRESA"].ToString(), false);
                adresa.Mjesto = Conversions.ToString(set.KORISNIK[0]["KORISNIK1MJESTO"]);
                zahtjeva.Adresa = adresa;
                zaglavlje.PodnositeljZahtjeva = zahtjeva;
                razdoblje.DatumOd = DateAndTime.DateSerial(Conversions.ToInteger(str), Conversions.ToInteger(str2), 1);
                razdoblje.DatumDo = DateAndTime.DateSerial(Conversions.ToInteger(str), Conversions.ToInteger(str2), DateTime.DaysInMonth(Conversions.ToInteger(str), Conversions.ToInteger(str2)));
                zaglavlje.Razdoblje = razdoblje;
                o.Zaglavlje = zaglavlje;
                DDModule.DDModule.sTijelo tijelo = new DDModule.DDModule.sTijelo();
                o.Tijelo = tijelo;
                sTijeloPodatak010 podatak = new sTijeloPodatak010();
                sTijeloPodatak020 podatak3 = new sTijeloPodatak020();
                sTijeloPodatak030 podatak4 = new sTijeloPodatak030();
                sTijeloPodatak040 podatak5 = new sTijeloPodatak040();
                sTijeloPodatak051 podatak6 = new sTijeloPodatak051();
                sTijeloPodatak052 podatak7 = new sTijeloPodatak052();
                sTijeloPodatak053 podatak8 = new sTijeloPodatak053();
                sTijeloPodatak054 podatak9 = new sTijeloPodatak054();
                sTijeloPodatak055 podatak10 = new sTijeloPodatak055();
                sTijeloPodatak056 podatak11 = new sTijeloPodatak056();
                sTijeloPodatak060 podatak12 = new sTijeloPodatak060();
                sTijeloPodatak070 podatak13 = new sTijeloPodatak070();
                sTijeloPodatak080 podatak14 = new sTijeloPodatak080();
                sTijeloPodatak090 podatak15 = new sTijeloPodatak090();
                sTijeloPodatak100 podatak2 = new sTijeloPodatak100();
                podatak.Iznos3 = Conversions.ToInteger(dataSet.kolona3.Rows[0]["brojprimatelja"]);
                podatak.Iznos4 = Conversions.ToInteger(dataSet.kolona4.Rows[0]["brojprimatelja"]);
                podatak.Iznos5 = Conversions.ToInteger(dataSet.kolona5.Rows[0]["brojprimatelja"]);
                podatak.Iznos6 = Conversions.ToInteger(dataSet.kolona6.Rows[0]["brojprimatelja"]);
                podatak.Iznos7 = Conversions.ToInteger(dataSet.kolona7.Rows[0]["brojprimatelja"]);
                podatak.Iznos8 = 0;
                podatak.Iznos9 = Conversions.ToInteger(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dataSet.kolona3.Rows[0]["brojprimatelja"], dataSet.kolona4.Rows[0]["brojprimatelja"]), dataSet.kolona5.Rows[0]["brojprimatelja"]), dataSet.kolona6.Rows[0]["brojprimatelja"]), dataSet.kolona7.Rows[0]["brojprimatelja"]));
                
                podatak3.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["primici"]), 2);
                podatak3.Iznos4 = decimal.Round(Conversions.ToDecimal(dataSet.kolona4.Rows[0]["primici"]), 2);
                podatak3.Iznos5 = decimal.Round(Conversions.ToDecimal(dataSet.kolona5.Rows[0]["primici"]), 2);
                podatak3.Iznos6 = decimal.Round(Conversions.ToDecimal(dataSet.kolona6.Rows[0]["primici"]), 2);
                podatak3.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["primici"]), 2);
                podatak3.Iznos8 = decimal.Round(0.00M, 2);
                podatak3.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dataSet.kolona3.Rows[0]["primici"], dataSet.kolona4.Rows[0]["primici"]), dataSet.kolona5.Rows[0]["primici"]), dataSet.kolona6.Rows[0]["primici"]), dataSet.kolona7.Rows[0]["primici"])), 2);
                
                podatak4.Iznos5 = decimal.Round(Conversions.ToDecimal(dataSet.kolona5.Rows[0]["izdatak"]), 2);
                podatak4.Iznos6 = decimal.Round(Conversions.ToDecimal(dataSet.kolona6.Rows[0]["izdatak"]), 2);
                podatak4.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["izdatak"]), 2);
                podatak4.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(dataSet.kolona5.Rows[0]["izdatak"], dataSet.kolona6.Rows[0]["izdatak"]), dataSet.kolona7.Rows[0]["izdatak"])), 2);
                
                podatak5.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["osnovicadoprinos"]), 2);
                podatak5.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["osnovicadoprinos"]), 2);
                podatak5.Iznos8 = decimal.Round(0.00M, 2);
                podatak5.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona3.Rows[0]["osnovicadoprinos"], dataSet.kolona7.Rows[0]["osnovicadoprinos"])), 2);
                
                podatak6.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["mio1"]), 2);
                podatak6.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["mio1"]), 2);
                podatak6.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona3.Rows[0]["mio1"], dataSet.kolona7.Rows[0]["mio1"])), 2);
                
                podatak7.Iznos8 = decimal.Round(0.00M, 2);
                podatak7.Iznos9 = decimal.Round(0.00M, 2);
                
                podatak8.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["mio2"]), 2);
                podatak8.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["mio2"]), 2);
                podatak8.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona3.Rows[0]["mio2"], dataSet.kolona7.Rows[0]["mio2"])), 2);
                
                podatak9.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["zdr"]), 2);
                podatak9.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["zdr"]), 2);
                podatak9.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona3.Rows[0]["zdr"], dataSet.kolona7.Rows[0]["zdr"])), 2);
                
                podatak10.Iznos8 = decimal.Round(0.00M, 2);
                podatak10.Iznos9 = decimal.Round(0.00M, 2);
                
                podatak11.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["zast"]), 2);
                podatak11.Iznos4 = decimal.Round(Conversions.ToDecimal(dataSet.kolona4.Rows[0]["zast"]), 2);
                podatak11.Iznos5 = decimal.Round(Conversions.ToDecimal(dataSet.kolona5.Rows[0]["zast"]), 2);
                podatak11.Iznos6 = decimal.Round(Conversions.ToDecimal(dataSet.kolona6.Rows[0]["zast"]), 2);
                podatak11.Iznos8 = decimal.Round(0.00M, 2);
                podatak11.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(Operators.AddObject(dataSet.kolona3.Rows[0]["zast"], dataSet.kolona4.Rows[0]["zast"]), dataSet.kolona5.Rows[0]["zast"]), dataSet.kolona6.Rows[0]["zast"])), 2);
                
                podatak12.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["izdatak"]), 2);
                podatak12.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["izdatak"]), 2);
                podatak12.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona3.Rows[0]["izdatak"], dataSet.kolona7.Rows[0]["izdatak"])), 2);
                
                podatak13.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["osnovicaporez"]), 2);
                podatak13.Iznos4 = decimal.Round(Conversions.ToDecimal(dataSet.kolona4.Rows[0]["osnovicaporez"]), 2);
                podatak13.Iznos5 = decimal.Round(Conversions.ToDecimal(dataSet.kolona5.Rows[0]["osnovicaporez"]), 2);
                podatak13.Iznos6 = decimal.Round(Conversions.ToDecimal(dataSet.kolona6.Rows[0]["osnovicaporez"]), 2);
                podatak13.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["osnovicaporez"]), 2);
                podatak13.Iznos8 = decimal.Round(0.00M, 2);
                podatak13.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dataSet.kolona3.Rows[0]["osnovicaporez"], dataSet.kolona4.Rows[0]["osnovicaporez"]), dataSet.kolona5.Rows[0]["osnovicaporez"]), dataSet.kolona6.Rows[0]["osnovicaporez"]), dataSet.kolona7.Rows[0]["osnovicaporez"])), 2);
                
                podatak14.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["porez"]), 2);
                podatak14.Iznos4 = decimal.Round(Conversions.ToDecimal(dataSet.kolona4.Rows[0]["porez"]), 2);
                podatak14.Iznos5 = decimal.Round(Conversions.ToDecimal(dataSet.kolona5.Rows[0]["porez"]), 2);
                podatak14.Iznos6 = decimal.Round(Conversions.ToDecimal(dataSet.kolona6.Rows[0]["porez"]), 2);
                podatak14.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["porez"]), 2);
                podatak14.Iznos8 = decimal.Round(0.00M, 2);
                podatak14.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dataSet.kolona3.Rows[0]["porez"], dataSet.kolona4.Rows[0]["porez"]), dataSet.kolona5.Rows[0]["porez"]), dataSet.kolona6.Rows[0]["porez"]), dataSet.kolona7.Rows[0]["porez"])), 2);
                
                podatak15.Iznos3 = decimal.Round(Conversions.ToDecimal(dataSet.kolona3.Rows[0]["prirez"]), 2);
                podatak15.Iznos4 = decimal.Round(Conversions.ToDecimal(dataSet.kolona4.Rows[0]["prirez"]), 2);
                podatak15.Iznos5 = decimal.Round(Conversions.ToDecimal(dataSet.kolona5.Rows[0]["prirez"]), 2);
                podatak15.Iznos6 = decimal.Round(Conversions.ToDecimal(dataSet.kolona6.Rows[0]["prirez"]), 2);
                podatak15.Iznos7 = decimal.Round(Conversions.ToDecimal(dataSet.kolona7.Rows[0]["prirez"]), 2);
                podatak15.Iznos8 = decimal.Round(0.00M, 2);
                podatak15.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dataSet.kolona3.Rows[0]["prirez"], dataSet.kolona4.Rows[0]["prirez"]), dataSet.kolona5.Rows[0]["prirez"]), dataSet.kolona6.Rows[0]["prirez"]), dataSet.kolona7.Rows[0]["prirez"])), 2);
                
                podatak2.Iznos3 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona3.Rows[0]["prirez"], dataSet.kolona3.Rows[0]["porez"])), 2);
                podatak2.Iznos4 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona4.Rows[0]["prirez"], dataSet.kolona4.Rows[0]["porez"])), 2);
                podatak2.Iznos5 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona5.Rows[0]["prirez"], dataSet.kolona5.Rows[0]["porez"])), 2);
                podatak2.Iznos6 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona6.Rows[0]["prirez"], dataSet.kolona6.Rows[0]["porez"])), 2);
                podatak2.Iznos7 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(dataSet.kolona7.Rows[0]["prirez"], dataSet.kolona7.Rows[0]["porez"])), 2);
                podatak2.Iznos8 = decimal.Round(0.00M, 2);
                podatak2.Iznos9 = decimal.Round(Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dataSet.kolona3.Rows[0]["prirez"], dataSet.kolona3.Rows[0]["porez"]), dataSet.kolona4.Rows[0]["prirez"]), dataSet.kolona4.Rows[0]["porez"]), dataSet.kolona5.Rows[0]["prirez"]), dataSet.kolona5.Rows[0]["porez"]), dataSet.kolona6.Rows[0]["prirez"]), dataSet.kolona6.Rows[0]["porez"]), dataSet.kolona7.Rows[0]["prirez"]), dataSet.kolona7.Rows[0]["porez"])), 2);
                
                o.Tijelo.Podatak010 = podatak;
                o.Tijelo.Podatak020 = podatak3;
                o.Tijelo.Podatak030 = podatak4;
                o.Tijelo.Podatak040 = podatak5;
                o.Tijelo.Podatak051 = podatak6;
                o.Tijelo.Podatak052 = podatak7;
                o.Tijelo.Podatak053 = podatak8;
                o.Tijelo.Podatak054 = podatak9;
                o.Tijelo.Podatak055 = podatak10;
                o.Tijelo.Podatak056 = podatak11;
                o.Tijelo.Podatak060 = podatak12;
                o.Tijelo.Podatak070 = podatak13;
                o.Tijelo.Podatak080 = podatak14;
                o.Tijelo.Podatak090 = podatak15;
                o.Tijelo.Podatak100 = podatak2;
                try
                {
                    SaveFileDialog dialog2 = new SaveFileDialog {
                        InitialDirectory = Conversions.ToString(0),
                        FileName = "IDD" + str + "-" + str2 + ".xml",
                        RestoreDirectory = true
                    };
                    SaveFileDialog dialog = dialog2;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter writer = new StreamWriter(dialog.FileName))
                        {
                            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                            namespaces.Add("", "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0");
                            new XmlSerializer(typeof(sObrazacIDD), "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0").Serialize(writer, o, namespaces);

                            writer.Close();
                        }
                        Interaction.MsgBox("Datoteka uspješno  spremljena u: " + dialog.FileName, MsgBoxStyle.OkOnly, null);
                    }
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
        }
    }
}

