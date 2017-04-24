using CrystalDecisions.CrystalReports.Engine;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My.Resources;
using NetAdvantage.SmartParts;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer;
using System.Runtime.InteropServices;

public class frmKonacni : Form
{
    public ObracunSmartPart _CallerForm;

    private IContainer components;
    private Button btnUpis;
    private Button btnBolovanje;
    private bool m_bDisablePosCHange { get; set; }

    public bool kontrola_za_gasenje = false;

    public frmKonacni()
    {
        base.Load += new EventHandler(this.frmKonacni_Load);
        this.InitializeComponent();
    }

    public int Broj_Oznacenih()
    {
        int num2 = 0;
        int num4 = this.UltraGrid2.Rows.Count - 1;
        for (int i = 0; i <= num4; i++)
        {
            if (Operators.ConditionalCompareObjectEqual(this.UltraGrid2.Rows[i].Cells["OZNACEN"].Value, true, false))
            {
                num2++;
            }
        }
        return num2;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (this.m_cm.Count != 0)
        {
            DataRowView current = (DataRowView) this.m_cm.Current;
            int position = this.m_cm.Position;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = "DELETE FROM  KONACNIPOMOCNA WHERE IDRADNIK = @IDRADNIK AND SIFRA = @GODINA";
            command.Parameters.Add("@IDRADNIK", SqlDbType.Int).Value = RuntimeHelpers.GetObjectValue(current["idradnik"]);
            command.Parameters.Add("@GODINA", SqlDbType.Int).Value = this._CallerForm.godinaisplate;
            connection.Open();
            command.ExecuteNonQuery();
            if (Conversions.ToBoolean(Operators.OrObject(this._CallerForm.ObracunDataSet1.ObracunPorezi.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and idporez = 999"))).Length > 0, Operators.CompareObjectNotEqual(this._CallerForm.ObracunDataSet1.ObracunRadnici.Select(Conversions.ToString(Operators.ConcatenateObject("idradnik = ", current["idradnik"])))[0]["KOREKCIJAPRIREZA"], 0, false))))
            {
                Interaction.MsgBox("Korekcije za zaposlenike VEĆ napravljene!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                decimal num = 0;
                decimal num2 = 0;
                decimal num3 = 0;
                decimal num4 = 0;
                decimal num5 = 0;
                decimal num6 = 0;
                IEnumerator enumerator = null;
                S_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter adapter3 = new S_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter();
                this.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1.Clear();
                adapter3.Fill(this.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1, this._CallerForm.sifraobracuna);
                DataRow[] rowArray = this.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1.S_OD_KONACNI_POREZ_PO_OPCINAMA.Select("sifraopcinestanovanja = '" + current["OPCINASTANOVANJAIDOPCINE"].ToString().Substring(0, 3) + "'");
                if (rowArray.Length > 0)
                {
                    string str = Conversions.ToString(rowArray[0]["sifraopcinestanovanja"]);
                    num5 = Conversions.ToDecimal(rowArray[0]["OBRACUNATOPOREZ"]);
                    num6 = Conversions.ToDecimal(rowArray[0]["OBRACUNATOPRIREZ"]);
                }
                object[] arguments = new object[1];
                UltraNumericEditor porezrazlika = this.porezrazlika;
                arguments[0] = RuntimeHelpers.GetObjectValue(porezrazlika.Value);
                object[] objArray2 = arguments;
                bool[] copyBack = new bool[] { true };
                if (copyBack[0])
                {
                    porezrazlika.Value = RuntimeHelpers.GetObjectValue(objArray2[0]);
                }
                if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(null, typeof(Math), "Abs", objArray2, null, null, copyBack), num5, false))
                {
                    if (decimal.Compare(num5, decimal.Zero) < 0)
                    {
                        num2 = Conversions.ToDecimal(this.porezkorekcija.Value);
                        num = Conversions.ToDecimal(this.porezrazlika.Value);
                    }
                    else
                    {
                        objArray2 = new object[1];
                        porezrazlika = this.porezrazlika;
                        objArray2[0] = RuntimeHelpers.GetObjectValue(porezrazlika.Value);
                        arguments = objArray2;
                        copyBack = new bool[] { true };
                        if (copyBack[0])
                        {
                            porezrazlika.Value = RuntimeHelpers.GetObjectValue(arguments[0]);
                        }
                        num2 = Conversions.ToDecimal(Operators.NegateObject(Operators.SubtractObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", arguments, null, null, copyBack), Math.Abs(num5))));
                        num = Conversions.ToDecimal(this.porezrazlika.Value);
                    }
                    Interaction.MsgBox("Nedovoljno poreza na računu općine - porez djelomično korigiran!", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    num2 = new decimal();
                    num = Conversions.ToDecimal(this.porezrazlika.Value);
                }
                objArray2 = new object[1];
                porezrazlika = this.prirezrazlika;
                objArray2[0] = RuntimeHelpers.GetObjectValue(porezrazlika.Value);
                arguments = objArray2;
                copyBack = new bool[] { true };
                if (copyBack[0])
                {
                    porezrazlika.Value = RuntimeHelpers.GetObjectValue(arguments[0]);
                }
                if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(null, typeof(Math), "Abs", arguments, null, null, copyBack), num6, false))
                {
                    if (decimal.Compare(num6, decimal.Zero) < 0)
                    {
                        num4 = Conversions.ToDecimal(this.prirezkorekcija.Value);
                        num3 = Conversions.ToDecimal(this.prirezrazlika.Value);
                    }
                    else
                    {
                        objArray2 = new object[1];
                        porezrazlika = this.prirezrazlika;
                        objArray2[0] = RuntimeHelpers.GetObjectValue(porezrazlika.Value);
                        arguments = objArray2;
                        copyBack = new bool[] { true };
                        if (copyBack[0])
                        {
                            porezrazlika.Value = RuntimeHelpers.GetObjectValue(arguments[0]);
                        }
                        num4 = Conversions.ToDecimal(Operators.NegateObject(Operators.SubtractObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", arguments, null, null, copyBack), Math.Abs(num6))));
                        num3 = Conversions.ToDecimal(this.prirezrazlika.Value);
                    }
                    Interaction.MsgBox("Nedovoljno prireza na računu općine - prirez djelomično korigiran!", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    num4 = new decimal();
                    num3 = Conversions.ToDecimal(this.prirezrazlika.Value);
                }
                if (decimal.Compare(num2, decimal.Zero) != 0)
                {
                    SqlCommand command2 = new SqlCommand();
                    SqlDataAdapter adapter4 = new SqlDataAdapter();
                    command2.CommandType = CommandType.Text;
                    command2.Connection = connection;
                    command2.CommandText = "INSERT INTO KONACNIPOMOCNA (IDRADNIK,PRI,POR,IDOBRACUN) VALUES(@IDRADNIK,@PRI,@POR,@SIFRAOBRACUNA)";
                    command2.Parameters.Add("@IDRADNIK", SqlDbType.Int).Value = RuntimeHelpers.GetObjectValue(current["idradnik"]);
                    command2.Parameters.Add("@PRI", SqlDbType.Money).Value = num4;
                    command2.Parameters.Add("@POR", SqlDbType.Money).Value = num2;
                    command2.Parameters.Add("@SIFRAOBRACUNA", SqlDbType.Int).Value = this._CallerForm.sifraobracuna;
                    command2.ExecuteNonQuery();
                }
                connection.Close();
                DataRow row = this._CallerForm.ObracunDataSet1.ObracunPorezi.NewRow();
                row["idobracun"] = this._CallerForm.sifraobracuna;
                row["idporez"] = 0x3e7;
                row["idradnik"] = RuntimeHelpers.GetObjectValue(current["idradnik"]);
                row["obracunatiporez"] = num;
                row["osnovicaporez"] = 0;
                this._CallerForm.ObracunDataSet1.ObracunPorezi.Rows.Add(row);
                this.BindingContext[this._CallerForm.ObracunDataSet1.ObracunPorezi].EndCurrentEdit();
                try
                {
                    enumerator = this._CallerForm.ObracunDataSet1.ObracunRadnici.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow row2 = (DataRow) enumerator.Current;
                        if (Operators.ConditionalCompareObjectEqual(row2["idradnik"], current["idradnik"], false))
                        {
                            decimal num7 = Conversions.ToDecimal(row2["iskoristenooo"]);
                            row2["iskoristenooo"] = RuntimeHelpers.GetObjectValue(this.odbitakkorekcija.Value);
                            row2["korekcijaprireza"] = num3;
                            row2["ODBITAKPRIJEKOREKCIJE"] = num7;
                            this.BindingContext[this._CallerForm.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
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
                new OBRACUNDataAdapter().Update(this._CallerForm.ObracunDataSet1);
                this._CallerForm.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
                this.PuniPodatke();
                this.m_cm.Position = position;

                this.m_cm.PositionChanged += new EventHandler(this.m_cm_PositionChanged);
                this.m_cm_PositionChanged(null, null);

                this.Preracunaj();
            }
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.Preracunaj();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        if (this.m_cm.Count != 0)
        {
            IEnumerator enumerator = null;
            DataRowView current = (DataRowView) this.m_cm.Current;
            int position = this.m_cm.Position;
            try
            {
                enumerator = this._CallerForm.ObracunDataSet1.ObracunRadnici.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow row = (DataRow) enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(row["idradnik"], current["idradnik"], false))
                    {
                        row["iskoristenooo"] = RuntimeHelpers.GetObjectValue(row["ODBITAKPRIJEKOREKCIJE"]);
                        row["korekcijaprireza"] = 0;
                        this.BindingContext[this._CallerForm.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
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
            try
            {
                this._CallerForm.ObracunDataSet1.ObracunPorezi.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and idporez = 999")))[0].Delete();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
            new OBRACUNDataAdapter().Update(this._CallerForm.ObracunDataSet1);
            this._CallerForm.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
            this.PuniPodatke();
            this.m_cm.Position = position;
            this.m_cm_PositionChanged(null, null);
            this.Preracunaj();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = "DELETE FROM  KONACNIPOMOCNA WHERE IDRADNIK = @IDRADNIK AND GODINA = @GODINA";
            command.Parameters.Add("@IDRADNIK", SqlDbType.Int).Value = RuntimeHelpers.GetObjectValue(current["idradnik"]);
            command.Parameters.Add("@GODINA", SqlDbType.Int).Value = this._CallerForm.godinaisplate;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        if (this.m_cm.Count != 0)
        {
            DataRowView current = (DataRowView) this.m_cm.Current;
            if (Conversions.ToBoolean(Operators.OrObject(this._CallerForm.ObracunDataSet1.ObracunPorezi.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and idporez = 999"))).Length > 0, Operators.CompareObjectNotEqual(this._CallerForm.ObracunDataSet1.ObracunRadnici.Select(Conversions.ToString(Operators.ConcatenateObject("idradnik = ", current["idradnik"])))[0]["KOREKCIJAPRIREZA"], 0, false))))
            {
                Interaction.MsgBox("Korekcije za zaposlenike VEĆ napravljene - ispis liste moguće napraviti prije korekcije poreza - obrišite korekciju poreza!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                frmPregledIzvjestaja izvjestaja = new frmPregledIzvjestaja();
                ReportDocument document = new ReportDocument();
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptKonacniObracun.rpt");
                document.SetDataSource(this.S_OD_KONACNIDataSet1);
                document.SetParameterValue("Go_olaksice", RuntimeHelpers.GetObjectValue(this.olaksicek.Value));
                document.SetParameterValue("Go_dohodak", RuntimeHelpers.GetObjectValue(this.dohodakk.Value));
                document.SetParameterValue("Go_odbitak", RuntimeHelpers.GetObjectValue(this.odbitakk.Value));
                document.SetParameterValue("Go_porezna", RuntimeHelpers.GetObjectValue(this.osnovicak.Value));
                document.SetParameterValue("Go_porez", RuntimeHelpers.GetObjectValue(this.porez.Value));
                document.SetParameterValue("Go_prirez", RuntimeHelpers.GetObjectValue(this.prirezk.Value));
                document.SetParameterValue("Go_krizni", 0);
                document.SetParameterValue("Go_neto", RuntimeHelpers.GetObjectValue(this.netok.Value));
                document.SetParameterValue("ra_odbitak", RuntimeHelpers.GetObjectValue(this.odbitakrazlika.Value));
                document.SetParameterValue("ra_porez", RuntimeHelpers.GetObjectValue(this.porezrazlika.Value));
                document.SetParameterValue("ra_prirez", RuntimeHelpers.GetObjectValue(this.prirezrazlika.Value));
                document.SetParameterValue("b12", RuntimeHelpers.GetObjectValue(this.brutokorekcija.Value));
                document.SetParameterValue("do12", RuntimeHelpers.GetObjectValue(this.doprinosikorekcija.Value));
                document.SetParameterValue("ol12", RuntimeHelpers.GetObjectValue(this.olaksicekorekcija.Value));
                document.SetParameterValue("doh12", RuntimeHelpers.GetObjectValue(this.dohodakkorekcija.Value));
                document.SetParameterValue("oo12", RuntimeHelpers.GetObjectValue(this.olaksicekorekcija.Value));
                document.SetParameterValue("osn12", RuntimeHelpers.GetObjectValue(this.osnovicakorekcija.Value));
                document.SetParameterValue("po12", RuntimeHelpers.GetObjectValue(this.porezkorekcija.Value));
                document.SetParameterValue("pri12", RuntimeHelpers.GetObjectValue(this.prirezkorekcija.Value));
                document.SetParameterValue("neto12", RuntimeHelpers.GetObjectValue(this.netokorekcija.Value));
                string str = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(current["Prezime"], " "), current["ime"]), " OIB: "), current["oib"]));
                document.SetParameterValue("radnik", str);
                object izvjestajJ = document;
                izvjestaja.Postavi_Izvjestaj(ref izvjestajJ);
                document = (ReportDocument) izvjestajJ;
                izvjestaja.Show();
            }
        }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
        this.Preracunaj_Sve();
    }

    private void Button6_Click(object sender, EventArgs e)
    {
        this.Parametri_OznaciSve();
    }

    private void Button7_Click(object sender, EventArgs e)
    {
        this.Parametri_MakniOznake();
    }

    public void DesktopAlert(string str)
    {
        this.UltraDesktopAlert1.Opacity = 0.9f;
        this.UltraDesktopAlert1.UseFlatMode = DefaultableBoolean.True;
        this.UltraDesktopAlert1.AnimationSpeed = AnimationSpeed.Fast;
        UltraDesktopAlertShowWindowInfo windowInfo = new UltraDesktopAlertShowWindowInfo {
            Image = My.Resources.ResourcesPlacaExe.oko,
            Caption = string.Format("<a>{0}</a>", "Konačni obračun u tijeku!"),
            Text = string.Format("<a>{0}</a>", str),
            FooterText = string.Format("<a>{0}</a>", "Mipsed obračun plaća"),
            Key = "MyWindow"
        };
        UltraDesktopAlertWindowInfo info2 = this.UltraDesktopAlert1.Show(windowInfo);
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    private void frmKonacni_Load(object sender, EventArgs e)
    {
        //provjera dali je obracun vec odraden
        SqlClient client = new SqlClient();
        DataTable tblProvjera = client.GetDataTable("Select ID_GODINE From GOP1 Where ID_GODINE = (Select IDGODINE From GODINE WHERE GODINEAKTIVNA = 'true') And IDOBRACUN = '" + id_obracun + "'");
        if (tblProvjera.Rows.Count > 0)
        {
            MessageBox.Show(String.Format("Za obračun '{0}' je već napravljen godišnji obračun.", id_obracun));
            this.Close();
            return;
        }


        IEnumerator enumerator2 = null;
        kontrola_za_gasenje = false;
        frmStatus status = new frmStatus();
        status.Show();
        status.Label1.Text = "Godišnji obračun u tijeku, pričekajte trenutak!";

        new PregledRadnikaSvihDataAdapter().Fill(this.PregledRadnikaSvihDataSet1);
        try
        {
            enumerator2 = this.PregledRadnikaSvihDataSet1.RADNIK.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                DataRow row = (DataRow)enumerator2.Current;
                if (this._CallerForm.ObracunDataSet1.ObracunRadnici.Select(Conversions.ToString(Operators.ConcatenateObject("idradnik = ", row["idradnik"]))).Count<DataRow>() == 0)
                {
                    row.Delete();
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
        this.m_cm = (CurrencyManager)this.BindingContext[this.PregledRadnikaSvihDataSet1, "RADNIK"];
        this._CallerForm.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
        this.m_cm_PositionChanged(null, null);


        //novo punjenje sume
        DataTable tblSuma = new DataTable();
        DataTable tblOsobniOdbitak = new DataTable();
        DataTable tblOsobniOdbitakTMP = new DataTable();
        
        
        SqlCommand sqlUpit = new SqlCommand();
        sqlUpit.Connection = client.sqlConnection;
        sqlUpit.CommandType = CommandType.Text;
        string id_radnika = string.Empty;
        string OOPG = string.Empty;
        string GIP = string.Empty;
        string DIP = string.Empty;
        string PPorez = string.Empty;
        string PPrirez = string.Empty;
        double GOPOsobniOdbitak = 0;
        double faktor = 0;
        
        string osobni_odbitak = string.Empty;

        //maknuto neispravna logika u katicnom kartonu
        //sp_maticni_kartonDataSet ds_podaci = new sp_maticni_kartonDataSet();

        //ParametriMaticnogKartona kartona = new ParametriMaticnogKartona();

        DataTable tblGodina = client.GetDataTable("Select ID_GODINE From GOP1 Where ID_GODINE = (Select IDGODINE From GODINE WHERE GODINEAKTIVNA = 'true')");

        if (tblGodina.Rows.Count > 0)
        {
            if (Interaction.MsgBox("Postoje podaci za aktivnu godinu.\nŽelite li generirati podatke ponovno?", MsgBoxStyle.YesNo, "Godišnji obračun poreza") == MsgBoxResult.Yes)
            {
                bool kontrola = false;
                foreach (UltraGridRow row in UltraGrid2.Rows)
                {
                    GOPOsobniOdbitak = 0;
                    id_radnika = row.Cells["IDRADNIK"].Value.ToString();

                    tblSuma = client.GetDataTable("Select IDRADNIK, Sum(OBRIZNOS) AS 'GIP', (Select Sum(iskoristenooo) From ObracunRadnici Inner Join Obracun on ObracunRadnici.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year + "') As 'OOPG', " +
                                      "(Select Count(Distinct Substring(IDOBRACUN,1, 7 )) From ObracunRadnici Where IDRADNIK = '" + id_radnika + "') As 'Mjesec', " +
                                      "(Select IDGODINE From GODINE Where GODINEAKTIVNA = 'true') As 'Godina', " +
                                      "(Select Sum(obracunatidoprinos) From ObracunDoprinosi  Inner Join Obracun on ObracunDoprinosi.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And IDVRSTADOPRINOS = '2' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year + "') As 'DIP', " +
                                      "(Select Sum(obracunatiporez) From ObracunPorezi Inner Join Obracun on ObracunPorezi.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year + "') As 'PPorez', " +
                                      "(Select Sum(obracunatiprirez) From ObracunRadnici Inner Join Obracun on ObracunRadnici.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year +"') As 'PPrirez' " +
                                      "From ObracunElementi Inner Join Obracun on ObracunElementi.IDOBRACUN = OBRACUN.IDOBRACUN " +
                                      "Where ObracunElementi.IDRADNIK = '" + id_radnika + "' And ObracunElementi.IDVRSTAELEMENTA = '2' " +
                                      "And OBRACUN.GODINAISPLATE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 'true') group by ObracunElementi.IDRADNIK");

                    try
                    {
                        OOPG = tblSuma.Rows[0]["OOPG"].ToString().Replace(',', '.');
                        GIP = tblSuma.Rows[0]["GIP"].ToString().Replace(',', '.');
                        DIP = tblSuma.Rows[0]["DIP"].ToString().Replace(',', '.');
                        PPorez = tblSuma.Rows[0]["PPorez"].ToString().Replace(',', '.');
                        PPrirez = tblSuma.Rows[0]["PPrirez"].ToString().Replace(',', '.');

                        if (!kontrola)
                        {
                            sqlUpit.CommandText = "Delete from GOP1 Where ID_GODINE = '" + tblSuma.Rows[0]["Godina"].ToString() + "'";

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch
                            {
                                MessageBox.Show("Dogodila se greška prilikom ponovnog generiranja podataka {Delete}");
                                status.Close();
                                return;
                            }
                            kontrola = true;
                        }

                        tblOsobniOdbitak = client.GetDataTable("Select Distinct SubString(IDOBRACUN, 1, 7) As 'Obracun' From ObracunRadnici Where IDRADNIK = '" + id_radnika + "'");

                        foreach (DataRow red in tblOsobniOdbitak.Rows)
                        {
                            tblOsobniOdbitakTMP = client.GetDataTable("Select Max(faktoo) As 'Faktor' From ObracunRadnici Where SubString(IDOBRACUN, 1, 7) = '" + red["Obracun"].ToString() +
                                                                      "' And IDRADNIK = '" + id_radnika + "'");

                            faktor = Convert.ToDouble(tblOsobniOdbitakTMP.Rows[0]["Faktor"]);

                            //22.12 Izmjenje osobni odbitak
                            GOPOsobniOdbitak += 2600 * faktor;
                        }

                        osobni_odbitak = GOPOsobniOdbitak.ToString().Replace(',', '.');

                        sqlUpit.CommandText = "Insert Into GOP1 (ID_RADNIKA, OsobniOdbitakPrijeGOPa, GodisnjiIznosPrimitaka, DoprinosiIzPlace, PlaceniPorez, PlaceniPrirez, ID_GODINE, " +
                                          "NekoristeniMjeseci, IDOBRACUN) Values " +
                                          "('" + id_radnika + "', '" + OOPG + "', '" + GIP + "', '" + DIP + "', '" + PPorez + "', '" + PPrirez + "', '" +
                                          tblSuma.Rows[0]["Godina"].ToString() + "', '" + tblSuma.Rows[0]["Mjesec"].ToString() + "', '" + id_obracun + "')";

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Dogodila se greška prilikom ponovnog generiranja podataka {Insert}");
                            status.Close();
                            return;
                        }
                    }
                    catch { }
                }
            }
        }
        else
        {
            foreach (UltraGridRow row in UltraGrid2.Rows)
            {
                GOPOsobniOdbitak = 0;
                id_radnika = row.Cells["IDRADNIK"].Value.ToString();

                tblSuma = client.GetDataTable("Select IDRADNIK, Sum(OBRIZNOS) AS 'GIP', (Select Sum(iskoristenooo) From ObracunRadnici Inner Join Obracun on ObracunRadnici.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year + "') As 'OOPG', " +
                                      "(Select Count(Distinct Substring(IDOBRACUN,1, 7 )) From ObracunRadnici Where IDRADNIK = '" + id_radnika + "') As 'Mjesec', " +
                                      "(Select IDGODINE From GODINE Where GODINEAKTIVNA = 'true') As 'Godina', " +
                                      "(Select Sum(obracunatidoprinos) From ObracunDoprinosi  Inner Join Obracun on ObracunDoprinosi.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And IDVRSTADOPRINOS = '2' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year + "') As 'DIP', " +
                                      "(Select Sum(obracunatiporez) From ObracunPorezi Inner Join Obracun on ObracunPorezi.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year + "') As 'PPorez', " +
                                      "(Select Sum(obracunatiprirez) From ObracunRadnici Inner Join Obracun on ObracunRadnici.IDOBRACUN = Obracun.IDOBRACUN Where IDRADNIK = '" + id_radnika + "' And Obracun.GODINAISPLATE = '" + DateTime.Now.Year + "') As 'PPrirez' " +
                                      "From ObracunElementi Inner Join Obracun on ObracunElementi.IDOBRACUN = OBRACUN.IDOBRACUN " +
                                      "Where ObracunElementi.IDRADNIK = '" + id_radnika + "' And ObracunElementi.IDVRSTAELEMENTA = '2' " +
                                      "And OBRACUN.GODINAISPLATE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 'true') group by ObracunElementi.IDRADNIK");

                try
                {
                    OOPG = tblSuma.Rows[0]["OOPG"].ToString().Replace(',', '.');
                    GIP = tblSuma.Rows[0]["GIP"].ToString().Replace(',', '.');
                    DIP = tblSuma.Rows[0]["DIP"].ToString().Replace(',', '.');
                    PPorez = tblSuma.Rows[0]["PPorez"].ToString().Replace(',', '.');
                    PPrirez = tblSuma.Rows[0]["PPrirez"].ToString().Replace(',', '.');

                    tblOsobniOdbitak = client.GetDataTable("Select Distinct SubString(IDOBRACUN, 1, 7) As 'Obracun' From ObracunRadnici Where IDRADNIK = '" + id_radnika + "'");

                    foreach (DataRow red in tblOsobniOdbitak.Rows)
                    {
                        tblOsobniOdbitakTMP = client.GetDataTable("Select Max(faktoo) As 'Faktor' From ObracunRadnici Where SubString(IDOBRACUN, 1, 7) = '" + red["Obracun"].ToString() +
                                                                  "' And IDRADNIK = '" + id_radnika + "'");

                        faktor = Convert.ToDouble(tblOsobniOdbitakTMP.Rows[0]["Faktor"]);
                        //22.12 Izmjenje osobni odbitak
                        GOPOsobniOdbitak += 2600 * faktor;
                    }

                    osobni_odbitak = GOPOsobniOdbitak.ToString().Replace(',', '.');

                    sqlUpit.CommandText = "Insert Into GOP1 (ID_RADNIKA, OsobniOdbitakPrijeGOPa, GodisnjiIznosPrimitaka, DoprinosiIzPlace, PlaceniPorez, PlaceniPrirez, ID_GODINE, " +
                                          "NekoristeniMjeseci, IDOBRACUN) Values " +
                                          "('" + id_radnika + "', '" + OOPG + "', '" + GIP + "', '" + DIP + "', '" + PPorez + "', '" + PPrirez + "', '" +
                                          tblSuma.Rows[0]["Godina"].ToString() + "', '" + tblSuma.Rows[0]["Mjesec"].ToString() + "', '" + id_obracun + "')";


                    try
                    {
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Dogodila se greška prilikom ponovnog generiranja podataka {Insert}");
                        status.Close();
                        return;
                    }
                }
                catch { }
            }
        }


        //provjera dali je djelatnik mjenjao opcinu prebivalista
        DataTable tblPrebivaliste = new DataTable();
        string ime_prezime = string.Empty;
        string radnici = string.Empty;
        string ukupni_faktor = string.Empty;

        for (int i = UltraGrid2.Rows.Count - 1; i > -1 ; i--)
        {
            id_radnika = UltraGrid2.Rows[i].Cells["IDRADNIK"].Value.ToString();
            ime_prezime = UltraGrid2.Rows[i].Cells["Ime"].Value.ToString() + " " + UltraGrid2.Rows[i].Cells["Prezime"].Value.ToString();
            ukupni_faktor = UltraGrid2.Rows[i].Cells["UKUPNIFAKTOR"].Value.ToString();

            //Nije radio svih 12 mjeseci
            //19.12.2014
            //tblPrebivaliste = client.GetDataTable("Select NekoristeniMjeseci From GOP1 Where ID_RADNIKA = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'");
            //if (tblPrebivaliste.Rows.Count > 0)
            //{
            //    if (Convert.ToInt32(tblPrebivaliste.Rows[0]["NekoristeniMjeseci"]) < 12)
            //    {
            //        radnici += ime_prezime + ", ";
            //        UltraGrid2.Rows[i].Delete();
            //        continue;
            //    }
            //}

            //Mijenjao je Prebivalište
            tblPrebivaliste = client.GetDataTable("Select Distinct SIFRAOPCINESTANOVANJA From ObracunRadnici Where IDRADNIK = '" + id_radnika + "' And IDOBRACUN like '" + DateTime.Now.Year + "%'");
            if (tblPrebivaliste.Rows.Count > 1)
            {
                radnici += ime_prezime + ", ";
                UltraGrid2.Rows[i].Delete();
                continue;
            }

            //PK kartica nije kod poslodavca jer nema osobni odbitak
            tblPrebivaliste = client.GetDataTable("Select IDIPIDENT From OBRACUNRADNICI Where IDRADNIK = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'");
            if (Convert.ToInt32(tblPrebivaliste.Rows[0]["IDIPIDENT"]) == 11)
            {
                    radnici += ime_prezime + ", ";
                    UltraGrid2.Rows[i].Delete();
                    continue;
            }

            //Suma uplaćenog poreza je manja ili jednaka 0
            tblPrebivaliste = client.GetDataTable("select SUM (ObracunPorezi.OBRACUNATIPOREZ) as SumaUplacenogPoreza from ObracunPorezi inner join obracun on" +
                                                  " ObracunPorezi.IDOBRACUN = OBRACUN.IDOBRACUN where OBRACUN.GODINAISPLATE = '" + DateTime.Now.Year + "' and IDRADNIK = '" + id_radnika + "'");
            if (tblPrebivaliste.Rows[0]["sumauplacenogporeza"] == DBNull.Value)
            {
                radnici += ime_prezime + ", ";
                UltraGrid2.Rows[i].Delete();
                continue;
            }
            else if (Convert.ToInt32(tblPrebivaliste.Rows[0]["sumauplacenogporeza"]) <= 0)
            {
                radnici += ime_prezime + ", ";
                UltraGrid2.Rows[i].Delete();
                continue;
            }

        }
        if (radnici.Length > 0)
        {
            radnici.Remove(radnici.Length - 2, 2);
            MessageBox.Show(String.Format("Djelatnik {0} će biti uklonjen iz godišnjeg obračuna.\nDjelatnik je mjenjao mjesto prebivališta ili nema obračun za svaki mjesec.", radnici));
        }

        status.Close();
 
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_OD_KONACNI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("poreznaosnovica");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZIPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJMJESECISAISPLATAMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPAPRIREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ODBITAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("dohodak");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOPRINOSI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FAKTOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KRIZNIPOREZ");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGDIO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNIFAKTOR");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKonacni));
            this.Button1 = new System.Windows.Forms.Button();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.krizni = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Label14 = new System.Windows.Forms.Label();
            this.olaksicek = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.netok = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.netokorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.olaksicekorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.doprinosikorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.brutokorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Button2 = new System.Windows.Forms.Button();
            this.prirezkorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.porezkorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.osnovicakorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.dohodakkorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.dohodakk = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.odbitakkorekcija = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.prirezrazlika = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.prirezk = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.prirez = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.stopaprirezainfo = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.neto = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.porezk = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.porez = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.osnovicak = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.osnovica = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.odbitakk = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.odbitak = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.dohodak = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.olaksice = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.doprinosi = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.bruto = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.odbitakrazlika = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.porezrazlika = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnIzracunaj = new System.Windows.Forms.Button();
            this.ugdSuma = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Label11 = new System.Windows.Forms.Label();
            this.UltraDesktopAlert1 = new Infragistics.Win.Misc.UltraDesktopAlert(this.components);
            this.btnUpis = new System.Windows.Forms.Button();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.PregledRadnikaSvihDataSet1 = new Placa.PregledRadnikaSvihDataSet();
            this.S_OD_KONACNIDataSet1 = new Placa.S_OD_KONACNIDataSet();
            this.S_OD_KONACNIDataSet2 = new Placa.S_OD_KONACNIDataSet();
            this.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1 = new Placa.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet();
            this.btnBolovanje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krizni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olaksicek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netokorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olaksicekorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doprinosikorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brutokorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirezkorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.porezkorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovicakorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dohodakkorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dohodakk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitakkorekcija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirezrazlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirezk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirez)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopaprirezainfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.porezk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.porez)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovicak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitakk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dohodak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olaksice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doprinosi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bruto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitakrazlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.porezrazlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDesktopAlert1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaSvihDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_KONACNIDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_KONACNIDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(305, 173);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(102, 23);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "Snimi u obračun ";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.krizni);
            this.UltraGroupBox1.Controls.Add(this.Button4);
            this.UltraGroupBox1.Controls.Add(this.Button3);
            this.UltraGroupBox1.Controls.Add(this.Label14);
            this.UltraGroupBox1.Controls.Add(this.olaksicek);
            this.UltraGroupBox1.Controls.Add(this.netok);
            this.UltraGroupBox1.Controls.Add(this.netokorekcija);
            this.UltraGroupBox1.Controls.Add(this.olaksicekorekcija);
            this.UltraGroupBox1.Controls.Add(this.doprinosikorekcija);
            this.UltraGroupBox1.Controls.Add(this.brutokorekcija);
            this.UltraGroupBox1.Controls.Add(this.Button2);
            this.UltraGroupBox1.Controls.Add(this.prirezkorekcija);
            this.UltraGroupBox1.Controls.Add(this.porezkorekcija);
            this.UltraGroupBox1.Controls.Add(this.osnovicakorekcija);
            this.UltraGroupBox1.Controls.Add(this.dohodakkorekcija);
            this.UltraGroupBox1.Controls.Add(this.dohodakk);
            this.UltraGroupBox1.Controls.Add(this.odbitakkorekcija);
            this.UltraGroupBox1.Controls.Add(this.prirezrazlika);
            this.UltraGroupBox1.Controls.Add(this.prirezk);
            this.UltraGroupBox1.Controls.Add(this.Label13);
            this.UltraGroupBox1.Controls.Add(this.Label12);
            this.UltraGroupBox1.Controls.Add(this.prirez);
            this.UltraGroupBox1.Controls.Add(this.stopaprirezainfo);
            this.UltraGroupBox1.Controls.Add(this.Label10);
            this.UltraGroupBox1.Controls.Add(this.Button1);
            this.UltraGroupBox1.Controls.Add(this.Label9);
            this.UltraGroupBox1.Controls.Add(this.Label8);
            this.UltraGroupBox1.Controls.Add(this.Label7);
            this.UltraGroupBox1.Controls.Add(this.Label6);
            this.UltraGroupBox1.Controls.Add(this.Label5);
            this.UltraGroupBox1.Controls.Add(this.Label4);
            this.UltraGroupBox1.Controls.Add(this.neto);
            this.UltraGroupBox1.Controls.Add(this.porezk);
            this.UltraGroupBox1.Controls.Add(this.porez);
            this.UltraGroupBox1.Controls.Add(this.osnovicak);
            this.UltraGroupBox1.Controls.Add(this.osnovica);
            this.UltraGroupBox1.Controls.Add(this.odbitakk);
            this.UltraGroupBox1.Controls.Add(this.odbitak);
            this.UltraGroupBox1.Controls.Add(this.dohodak);
            this.UltraGroupBox1.Controls.Add(this.olaksice);
            this.UltraGroupBox1.Controls.Add(this.doprinosi);
            this.UltraGroupBox1.Controls.Add(this.bruto);
            this.UltraGroupBox1.Controls.Add(this.odbitakrazlika);
            this.UltraGroupBox1.Controls.Add(this.porezrazlika);
            this.UltraGroupBox1.Controls.Add(this.Label3);
            this.UltraGroupBox1.Controls.Add(this.Label2);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Location = new System.Drawing.Point(12, 578);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(870, 13);
            this.UltraGroupBox1.TabIndex = 7;
            this.UltraGroupBox1.Text = "...";
            // 
            // krizni
            // 
            this.krizni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.krizni.FormatString = "#,##0.00";
            this.krizni.Location = new System.Drawing.Point(9, 150);
            this.krizni.MaskInput = "-nnnnnnnnnn.nn";
            this.krizni.Name = "krizni";
            this.krizni.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.krizni.ReadOnly = true;
            this.krizni.Size = new System.Drawing.Size(69, 21);
            this.krizni.TabIndex = 91;
            this.krizni.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.krizni.UseAppStyling = false;
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(531, 173);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(215, 23);
            this.Button4.TabIndex = 90;
            this.Button4.Text = "Ispis godišnjeg obračuna prije korekcije";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(422, 173);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(102, 23);
            this.Button3.TabIndex = 89;
            this.Button3.Text = "Briši korekcije";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(6, 133);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(142, 13);
            this.Label14.TabIndex = 88;
            this.Label14.Text = "Zadnja isplata  u 12 mjesecu";
            // 
            // olaksicek
            // 
            appearance6.BackColor = System.Drawing.Color.Maroon;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.olaksicek.Appearance = appearance6;
            this.olaksicek.BackColor = System.Drawing.Color.Maroon;
            this.olaksicek.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.olaksicek.FormatString = "#,##0.00";
            this.olaksicek.Location = new System.Drawing.Point(363, 72);
            this.olaksicek.MaskInput = "-nnnnnnnnnn.nn";
            this.olaksicek.Name = "olaksicek";
            this.olaksicek.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.olaksicek.Size = new System.Drawing.Size(69, 21);
            this.olaksicek.TabIndex = 87;
            this.olaksicek.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.olaksicek.UseAppStyling = false;
            // 
            // netok
            // 
            this.netok.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.netok.FormatString = "#,##0.00";
            this.netok.Location = new System.Drawing.Point(834, 72);
            this.netok.MaskInput = "-nnnnnnnnnn.nn";
            this.netok.Name = "netok";
            this.netok.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.netok.ReadOnly = true;
            this.netok.Size = new System.Drawing.Size(69, 21);
            this.netok.TabIndex = 86;
            this.netok.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.netok.UseAppStyling = false;
            // 
            // netokorekcija
            // 
            this.netokorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.netokorekcija.FormatString = "#,##0.00";
            this.netokorekcija.Location = new System.Drawing.Point(834, 126);
            this.netokorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.netokorekcija.Name = "netokorekcija";
            this.netokorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.netokorekcija.ReadOnly = true;
            this.netokorekcija.Size = new System.Drawing.Size(69, 21);
            this.netokorekcija.TabIndex = 85;
            this.netokorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.netokorekcija.UseAppStyling = false;
            // 
            // olaksicekorekcija
            // 
            this.olaksicekorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.olaksicekorekcija.FormatString = "#,##0.00";
            this.olaksicekorekcija.Location = new System.Drawing.Point(363, 126);
            this.olaksicekorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.olaksicekorekcija.Name = "olaksicekorekcija";
            this.olaksicekorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.olaksicekorekcija.ReadOnly = true;
            this.olaksicekorekcija.Size = new System.Drawing.Size(69, 21);
            this.olaksicekorekcija.TabIndex = 84;
            this.olaksicekorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.olaksicekorekcija.UseAppStyling = false;
            // 
            // doprinosikorekcija
            // 
            this.doprinosikorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.doprinosikorekcija.FormatString = "#,##0.00";
            this.doprinosikorekcija.Location = new System.Drawing.Point(288, 126);
            this.doprinosikorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.doprinosikorekcija.Name = "doprinosikorekcija";
            this.doprinosikorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.doprinosikorekcija.ReadOnly = true;
            this.doprinosikorekcija.Size = new System.Drawing.Size(69, 21);
            this.doprinosikorekcija.TabIndex = 83;
            this.doprinosikorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.doprinosikorekcija.UseAppStyling = false;
            // 
            // brutokorekcija
            // 
            this.brutokorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.brutokorekcija.FormatString = "#,##0.00";
            this.brutokorekcija.Location = new System.Drawing.Point(213, 126);
            this.brutokorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.brutokorekcija.Name = "brutokorekcija";
            this.brutokorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.brutokorekcija.ReadOnly = true;
            this.brutokorekcija.Size = new System.Drawing.Size(69, 21);
            this.brutokorekcija.TabIndex = 82;
            this.brutokorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.brutokorekcija.UseAppStyling = false;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(213, 173);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 81;
            this.Button2.Text = "Preračunaj";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // prirezkorekcija
            // 
            this.prirezkorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.prirezkorekcija.FormatString = "#,##0.00";
            this.prirezkorekcija.Location = new System.Drawing.Point(752, 126);
            this.prirezkorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.prirezkorekcija.Name = "prirezkorekcija";
            this.prirezkorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.prirezkorekcija.ReadOnly = true;
            this.prirezkorekcija.Size = new System.Drawing.Size(69, 21);
            this.prirezkorekcija.TabIndex = 80;
            this.prirezkorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.prirezkorekcija.UseAppStyling = false;
            // 
            // porezkorekcija
            // 
            this.porezkorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.porezkorekcija.FormatString = "#,##0.00";
            this.porezkorekcija.Location = new System.Drawing.Point(677, 126);
            this.porezkorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.porezkorekcija.Name = "porezkorekcija";
            this.porezkorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.porezkorekcija.ReadOnly = true;
            this.porezkorekcija.Size = new System.Drawing.Size(69, 21);
            this.porezkorekcija.TabIndex = 79;
            this.porezkorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.porezkorekcija.UseAppStyling = false;
            // 
            // osnovicakorekcija
            // 
            this.osnovicakorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.osnovicakorekcija.FormatString = "#,##0.00";
            this.osnovicakorekcija.Location = new System.Drawing.Point(602, 126);
            this.osnovicakorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.osnovicakorekcija.Name = "osnovicakorekcija";
            this.osnovicakorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.osnovicakorekcija.ReadOnly = true;
            this.osnovicakorekcija.Size = new System.Drawing.Size(69, 21);
            this.osnovicakorekcija.TabIndex = 78;
            this.osnovicakorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.osnovicakorekcija.UseAppStyling = false;
            // 
            // dohodakkorekcija
            // 
            this.dohodakkorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dohodakkorekcija.FormatString = "#,##0.00";
            this.dohodakkorekcija.Location = new System.Drawing.Point(443, 126);
            this.dohodakkorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.dohodakkorekcija.Name = "dohodakkorekcija";
            this.dohodakkorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.dohodakkorekcija.ReadOnly = true;
            this.dohodakkorekcija.Size = new System.Drawing.Size(69, 21);
            this.dohodakkorekcija.TabIndex = 77;
            this.dohodakkorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.dohodakkorekcija.UseAppStyling = false;
            // 
            // dohodakk
            // 
            this.dohodakk.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dohodakk.FormatString = "#,##0.00";
            this.dohodakk.Location = new System.Drawing.Point(443, 72);
            this.dohodakk.MaskInput = "-nnnnnnnnnn.nn";
            this.dohodakk.Name = "dohodakk";
            this.dohodakk.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.dohodakk.ReadOnly = true;
            this.dohodakk.Size = new System.Drawing.Size(69, 21);
            this.dohodakk.TabIndex = 76;
            this.dohodakk.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.dohodakk.UseAppStyling = false;
            // 
            // odbitakkorekcija
            // 
            this.odbitakkorekcija.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.odbitakkorekcija.FormatString = "#,##0.00";
            this.odbitakkorekcija.Location = new System.Drawing.Point(518, 126);
            this.odbitakkorekcija.MaskInput = "-nnnnnnnnnn.nn";
            this.odbitakkorekcija.Name = "odbitakkorekcija";
            this.odbitakkorekcija.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.odbitakkorekcija.ReadOnly = true;
            this.odbitakkorekcija.Size = new System.Drawing.Size(69, 21);
            this.odbitakkorekcija.TabIndex = 75;
            this.odbitakkorekcija.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.odbitakkorekcija.UseAppStyling = false;
            // 
            // prirezrazlika
            // 
            this.prirezrazlika.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.prirezrazlika.FormatString = "#,##0.00";
            this.prirezrazlika.Location = new System.Drawing.Point(752, 99);
            this.prirezrazlika.MaskInput = "-nnnnnnnnnn.nn";
            this.prirezrazlika.Name = "prirezrazlika";
            this.prirezrazlika.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.prirezrazlika.ReadOnly = true;
            this.prirezrazlika.Size = new System.Drawing.Size(69, 21);
            this.prirezrazlika.TabIndex = 74;
            this.prirezrazlika.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.prirezrazlika.UseAppStyling = false;
            // 
            // prirezk
            // 
            this.prirezk.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.prirezk.FormatString = "#,##0.00";
            this.prirezk.Location = new System.Drawing.Point(752, 72);
            this.prirezk.MaskInput = "-nnnnnnnnnn.nn";
            this.prirezk.Name = "prirezk";
            this.prirezk.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.prirezk.ReadOnly = true;
            this.prirezk.Size = new System.Drawing.Size(69, 21);
            this.prirezk.TabIndex = 73;
            this.prirezk.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.prirezk.UseAppStyling = false;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(6, 79);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(86, 13);
            this.Label13.TabIndex = 72;
            this.Label13.Text = "Godišnji obračun";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(752, 28);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(33, 13);
            this.Label12.TabIndex = 71;
            this.Label12.Text = "Prirez";
            // 
            // prirez
            // 
            this.prirez.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.prirez.FormatString = "#,##0.00";
            this.prirez.Location = new System.Drawing.Point(752, 45);
            this.prirez.MaskInput = "-nnnnnnnnnn.nn";
            this.prirez.Name = "prirez";
            this.prirez.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.prirez.ReadOnly = true;
            this.prirez.Size = new System.Drawing.Size(69, 21);
            this.prirez.TabIndex = 70;
            this.prirez.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.prirez.UseAppStyling = false;
            // 
            // stopaprirezainfo
            // 
            this.stopaprirezainfo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.stopaprirezainfo.FormatString = "#,##0.00";
            this.stopaprirezainfo.Location = new System.Drawing.Point(23, 21);
            this.stopaprirezainfo.MaskInput = "-nnnnnnnnnn.nn";
            this.stopaprirezainfo.Name = "stopaprirezainfo";
            this.stopaprirezainfo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.stopaprirezainfo.Size = new System.Drawing.Size(69, 21);
            this.stopaprirezainfo.TabIndex = 66;
            this.stopaprirezainfo.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.stopaprirezainfo.UseAppStyling = false;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(6, 106);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(176, 13);
            this.Label10.TabIndex = 68;
            this.Label10.Text = "Razlika isplaćeno - godišnji obračun";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(6, 52);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(149, 13);
            this.Label9.TabIndex = 67;
            this.Label9.Text = "Ukupno isplate tijekom godine";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(829, 28);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(30, 13);
            this.Label8.TabIndex = 65;
            this.Label8.Text = "Neto";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(438, 28);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(51, 13);
            this.Label7.TabIndex = 64;
            this.Label7.Text = "Dohodak";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(368, 28);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 13);
            this.Label6.TabIndex = 63;
            this.Label6.Text = "Olakšice";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(293, 28);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(51, 13);
            this.Label5.TabIndex = 62;
            this.Label5.Text = "Doprinosi";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(220, 28);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 13);
            this.Label4.TabIndex = 61;
            this.Label4.Text = "Bruto";
            // 
            // neto
            // 
            this.neto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.neto.FormatString = "#,##0.00";
            this.neto.Location = new System.Drawing.Point(834, 45);
            this.neto.MaskInput = "-nnnnnnnnnn.nn";
            this.neto.Name = "neto";
            this.neto.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.neto.ReadOnly = true;
            this.neto.Size = new System.Drawing.Size(69, 21);
            this.neto.TabIndex = 60;
            this.neto.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.neto.UseAppStyling = false;
            // 
            // porezk
            // 
            this.porezk.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.porezk.FormatString = "#,##0.00";
            this.porezk.Location = new System.Drawing.Point(677, 72);
            this.porezk.MaskInput = "-nnnnnnnnnn.nn";
            this.porezk.Name = "porezk";
            this.porezk.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.porezk.ReadOnly = true;
            this.porezk.Size = new System.Drawing.Size(69, 21);
            this.porezk.TabIndex = 59;
            this.porezk.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.porezk.UseAppStyling = false;
            // 
            // porez
            // 
            this.porez.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.porez.FormatString = "#,##0.00";
            this.porez.Location = new System.Drawing.Point(677, 45);
            this.porez.MaskInput = "-nnnnnnnnnn.nn";
            this.porez.Name = "porez";
            this.porez.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.porez.ReadOnly = true;
            this.porez.Size = new System.Drawing.Size(69, 21);
            this.porez.TabIndex = 58;
            this.porez.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.porez.UseAppStyling = false;
            this.porez.ValueChanged += new System.EventHandler(this.porez_ValueChanged);
            // 
            // osnovicak
            // 
            this.osnovicak.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.osnovicak.FormatString = "#,##0.00";
            this.osnovicak.Location = new System.Drawing.Point(602, 72);
            this.osnovicak.MaskInput = "-nnnnnnnnnn.nn";
            this.osnovicak.Name = "osnovicak";
            this.osnovicak.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.osnovicak.ReadOnly = true;
            this.osnovicak.Size = new System.Drawing.Size(69, 21);
            this.osnovicak.TabIndex = 57;
            this.osnovicak.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.osnovicak.UseAppStyling = false;
            // 
            // osnovica
            // 
            this.osnovica.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.osnovica.FormatString = "#,##0.00";
            this.osnovica.Location = new System.Drawing.Point(602, 45);
            this.osnovica.MaskInput = "-nnnnnnnnnn.nn";
            this.osnovica.Name = "osnovica";
            this.osnovica.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.osnovica.ReadOnly = true;
            this.osnovica.Size = new System.Drawing.Size(69, 21);
            this.osnovica.TabIndex = 56;
            this.osnovica.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.osnovica.UseAppStyling = false;
            // 
            // odbitakk
            // 
            appearance7.BackColor = System.Drawing.Color.Maroon;
            appearance7.ForeColor = System.Drawing.Color.White;
            this.odbitakk.Appearance = appearance7;
            this.odbitakk.BackColor = System.Drawing.Color.Maroon;
            this.odbitakk.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.odbitakk.FormatString = "#,##0.00";
            this.odbitakk.Location = new System.Drawing.Point(518, 72);
            this.odbitakk.MaskInput = "-nnnnnnnnnn.nn";
            this.odbitakk.Name = "odbitakk";
            this.odbitakk.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.odbitakk.Size = new System.Drawing.Size(69, 21);
            this.odbitakk.TabIndex = 55;
            this.odbitakk.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.odbitakk.UseAppStyling = false;
            this.odbitakk.ValueChanged += new System.EventHandler(this.odbitakk_ValueChanged);
            // 
            // odbitak
            // 
            this.odbitak.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.odbitak.FormatString = "#,##0.00";
            this.odbitak.Location = new System.Drawing.Point(518, 45);
            this.odbitak.MaskInput = "-nnnnnnnnnn.nn";
            this.odbitak.Name = "odbitak";
            this.odbitak.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.odbitak.ReadOnly = true;
            this.odbitak.Size = new System.Drawing.Size(69, 21);
            this.odbitak.TabIndex = 54;
            this.odbitak.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.odbitak.UseAppStyling = false;
            // 
            // dohodak
            // 
            this.dohodak.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dohodak.FormatString = "#,##0.00";
            this.dohodak.Location = new System.Drawing.Point(443, 45);
            this.dohodak.MaskInput = "-nnnnnnnnnn.nn";
            this.dohodak.Name = "dohodak";
            this.dohodak.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.dohodak.ReadOnly = true;
            this.dohodak.Size = new System.Drawing.Size(69, 21);
            this.dohodak.TabIndex = 53;
            this.dohodak.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.dohodak.UseAppStyling = false;
            // 
            // olaksice
            // 
            this.olaksice.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.olaksice.FormatString = "#,##0.00";
            this.olaksice.Location = new System.Drawing.Point(363, 45);
            this.olaksice.MaskInput = "-nnnnnnnnnn.nn";
            this.olaksice.Name = "olaksice";
            this.olaksice.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.olaksice.ReadOnly = true;
            this.olaksice.Size = new System.Drawing.Size(69, 21);
            this.olaksice.TabIndex = 52;
            this.olaksice.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.olaksice.UseAppStyling = false;
            // 
            // doprinosi
            // 
            this.doprinosi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.doprinosi.FormatString = "#,##0.00";
            this.doprinosi.Location = new System.Drawing.Point(288, 45);
            this.doprinosi.MaskInput = "-nnnnnnnnnn.nn";
            this.doprinosi.Name = "doprinosi";
            this.doprinosi.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.doprinosi.ReadOnly = true;
            this.doprinosi.Size = new System.Drawing.Size(69, 21);
            this.doprinosi.TabIndex = 51;
            this.doprinosi.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.doprinosi.UseAppStyling = false;
            // 
            // bruto
            // 
            this.bruto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.bruto.FormatString = "#,##0.00";
            this.bruto.Location = new System.Drawing.Point(213, 45);
            this.bruto.MaskInput = "-nnnnnnnnnn.nn";
            this.bruto.Name = "bruto";
            this.bruto.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.bruto.ReadOnly = true;
            this.bruto.Size = new System.Drawing.Size(69, 21);
            this.bruto.TabIndex = 50;
            this.bruto.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.bruto.UseAppStyling = false;
            // 
            // odbitakrazlika
            // 
            this.odbitakrazlika.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.odbitakrazlika.FormatString = "#,##0.00";
            this.odbitakrazlika.Location = new System.Drawing.Point(518, 99);
            this.odbitakrazlika.MaskInput = "-nnnnnnnnnn.nn";
            this.odbitakrazlika.Name = "odbitakrazlika";
            this.odbitakrazlika.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.odbitakrazlika.ReadOnly = true;
            this.odbitakrazlika.Size = new System.Drawing.Size(69, 21);
            this.odbitakrazlika.TabIndex = 48;
            this.odbitakrazlika.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.odbitakrazlika.UseAppStyling = false;
            // 
            // porezrazlika
            // 
            this.porezrazlika.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.porezrazlika.FormatString = "#,##0.00";
            this.porezrazlika.Location = new System.Drawing.Point(677, 99);
            this.porezrazlika.MaskInput = "-nnnnnnnnnn.nn";
            this.porezrazlika.Name = "porezrazlika";
            this.porezrazlika.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.porezrazlika.ReadOnly = true;
            this.porezrazlika.Size = new System.Drawing.Size(69, 21);
            this.porezrazlika.TabIndex = 47;
            this.porezrazlika.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.porezrazlika.UseAppStyling = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(677, 28);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(34, 13);
            this.Label3.TabIndex = 46;
            this.Label3.Text = "Porez";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(597, 28);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 13);
            this.Label2.TabIndex = 45;
            this.Label2.Text = "Osnovica";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(517, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(44, 13);
            this.Label1.TabIndex = 44;
            this.Label1.Text = "Odbitak";
            // 
            // btnIzracunaj
            // 
            this.btnIzracunaj.Location = new System.Drawing.Point(22, 631);
            this.btnIzracunaj.Name = "btnIzracunaj";
            this.btnIzracunaj.Size = new System.Drawing.Size(75, 23);
            this.btnIzracunaj.TabIndex = 91;
            this.btnIzracunaj.Text = "Obračunaj";
            this.btnIzracunaj.UseVisualStyleBackColor = true;
            this.btnIzracunaj.Click += new System.EventHandler(this.Button5_Click);
            // 
            // ugdSuma
            // 
            this.ugdSuma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance.BackColor = System.Drawing.Color.White;
            this.ugdSuma.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.Caption = "Por. osnovica";
            ultraGridColumn1.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn1.Header.VisiblePosition = 9;
            ultraGridColumn1.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn1.Width = 88;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn2.Header.VisiblePosition = 10;
            ultraGridColumn2.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "Općina";
            ultraGridColumn3.Header.Fixed = true;
            ultraGridColumn3.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Width = 47;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn4.Header.VisiblePosition = 11;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn5.Header.VisiblePosition = 12;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "Mj.";
            ultraGridColumn6.Header.Fixed = true;
            ultraGridColumn6.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn6.Width = 36;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "St.prirez";
            ultraGridColumn7.Header.Fixed = true;
            ultraGridColumn7.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn7.Width = 61;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "Odbitak";
            ultraGridColumn8.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn8.Width = 61;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "Dohodak";
            ultraGridColumn9.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn9.Header.VisiblePosition = 6;
            ultraGridColumn9.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn9.Width = 57;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "Olakšice";
            ultraGridColumn10.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn10.Header.VisiblePosition = 7;
            ultraGridColumn10.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn10.Width = 68;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.Caption = "Bruto";
            ultraGridColumn11.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn11.Header.VisiblePosition = 4;
            ultraGridColumn11.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn11.Width = 68;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.Caption = "Doprinosi";
            ultraGridColumn12.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn12.Header.VisiblePosition = 5;
            ultraGridColumn12.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn12.Width = 66;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "FaktOO";
            ultraGridColumn13.Header.Fixed = true;
            ultraGridColumn13.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            ultraGridColumn13.Header.VisiblePosition = 1;
            ultraGridColumn13.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn13.Width = 54;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            ultraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.ugdSuma.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugdSuma.DisplayLayout.GroupByBox.Hidden = true;
            this.ugdSuma.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.ugdSuma.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.ugdSuma.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.True;
            this.ugdSuma.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.ugdSuma.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ugdSuma.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.ugdSuma.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ugdSuma.DisplayLayout.Override.CellPadding = 3;
            appearance3.TextHAlignAsString = "Left";
            this.ugdSuma.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.ugdSuma.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BorderColor = System.Drawing.Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.ugdSuma.DisplayLayout.Override.RowAppearance = appearance4;
            this.ugdSuma.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.ugdSuma.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.ugdSuma.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugdSuma.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugdSuma.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugdSuma.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.ugdSuma.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.ugdSuma.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugdSuma.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell;
            this.ugdSuma.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugdSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugdSuma.Location = new System.Drawing.Point(12, 357);
            this.ugdSuma.Name = "ugdSuma";
            this.ugdSuma.Size = new System.Drawing.Size(1091, 205);
            this.ugdSuma.TabIndex = 1;
            this.ugdSuma.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugdSuma_AfterCellUpdate);
            this.ugdSuma.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.ugdSuma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ugdSuma_KeyPress);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(19, 606);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(425, 13);
            this.Label11.TabIndex = 92;
            this.Label11.Text = "Označavanjem radnika i pritiskom na tipku < DEL > briše se radnik iz godišnjeg ob" +
    "računa";
            // 
            // btnUpis
            // 
            this.btnUpis.Location = new System.Drawing.Point(128, 631);
            this.btnUpis.Name = "btnUpis";
            this.btnUpis.Size = new System.Drawing.Size(166, 23);
            this.btnUpis.TabIndex = 93;
            this.btnUpis.Text = "Upis GOP-a u platne liste";
            this.btnUpis.UseVisualStyleBackColor = true;
            this.btnUpis.Click += new System.EventHandler(this.btnUpis_Click);
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UltraGrid2.DataMember = "RADNIK";
            this.UltraGrid2.DataSource = this.PregledRadnikaSvihDataSet1;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn17.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn17.Width = 67;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn18.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn18.Header.VisiblePosition = 1;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn19.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn20.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn20.Header.VisiblePosition = 3;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn21.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn21.Header.VisiblePosition = 4;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn22.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn22.Header.VisiblePosition = 5;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn23.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn23.Header.VisiblePosition = 6;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn24.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn24.Header.VisiblePosition = 7;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn25.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn25.Header.VisiblePosition = 8;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25});
            appearance1.BackColor = System.Drawing.Color.Red;
            appearance1.ForeColor = System.Drawing.Color.Yellow;
            ultraGridBand2.Override.SelectedRowAppearance = appearance1;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid2.Location = new System.Drawing.Point(12, 3);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(1091, 350);
            this.UltraGrid2.TabIndex = 2;
            this.UltraGrid2.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.UltraGrid2_AfterSelectChange);
            this.UltraGrid2.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.UltraGrid2_BeforeRowsDeleted);
            // 
            // PregledRadnikaSvihDataSet1
            // 
            this.PregledRadnikaSvihDataSet1.DataSetName = "PregledRadnikaSvihDataSet";
            // 
            // S_OD_KONACNIDataSet1
            // 
            this.S_OD_KONACNIDataSet1.DataSetName = "S_OD_KONACNIDataSet";
            // 
            // S_OD_KONACNIDataSet2
            // 
            this.S_OD_KONACNIDataSet2.DataSetName = "S_OD_KONACNIDataSet";
            // 
            // S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1
            // 
            this.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1.DataSetName = "S_OD_KONACNI_POREZ_PO_OPCINAMADataSet";
            // 
            // btnBolovanje
            // 
            this.btnBolovanje.Location = new System.Drawing.Point(579, 620);
            this.btnBolovanje.Name = "btnBolovanje";
            this.btnBolovanje.Size = new System.Drawing.Size(127, 23);
            this.btnBolovanje.TabIndex = 94;
            this.btnBolovanje.Text = "Bolovanja i porodiljnji";
            this.btnBolovanje.UseVisualStyleBackColor = true;
            this.btnBolovanje.Visible = false;
            this.btnBolovanje.Click += new System.EventHandler(this.btnBolovanje_Click);
            // 
            // frmKonacni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 689);
            this.Controls.Add(this.btnBolovanje);
            this.Controls.Add(this.btnUpis);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.btnIzracunaj);
            this.Controls.Add(this.UltraGroupBox1);
            this.Controls.Add(this.UltraGrid2);
            this.Controls.Add(this.ugdSuma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKonacni";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Godišnji obračun poreza ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKonacni_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krizni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olaksicek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netokorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olaksicekorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doprinosikorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brutokorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirezkorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.porezkorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovicakorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dohodakkorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dohodakk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitakkorekcija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirezrazlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirezk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prirez)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopaprirezainfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.porezk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.porez)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovicak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitakk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dohodak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olaksice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doprinosi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bruto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odbitakrazlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.porezrazlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugdSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDesktopAlert1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaSvihDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_KONACNIDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_KONACNIDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void m_cm_PositionChanged(object sender, EventArgs e)
    {
        if (!this.m_bDisablePosCHange && (this.m_cm.Count != 0))
        {
            decimal num4 = 0;
            IEnumerator enumerator = null;
            DataRowView current = (DataRowView) this.m_cm.Current;
            this.S_OD_KONACNIDataSet1.Clear();
            this.S_OD_KONACNIDataSet1.Merge(this.S_OD_KONACNIDataSet2.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("OIB = '", current["OIB"]), "'"))));
            this.bruto.Value = 0;
            this.doprinosi.Value = 0;
            this.olaksice.Value = 0;
            this.odbitak.Value = 0;
            this.osnovica.Value = 0;
            this.porez.Value = 0;
            this.neto.Value = 0;
            if (this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Rows.Count > 0)
            {
                num4 = Conversions.ToDecimal(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Rows[0]["stopaprireza"]);
            }
            this.krizni.Value = 0;
            this.bruto.Value = 0;
            this.doprinosi.Value = 0;
            this.dohodak.Value = 0;
            this.olaksice.Value = 0;
            this.odbitak.Value = 0;
            this.osnovica.Value = 0;
            this.porez.Value = 0;
            this.prirez.Value = 0;
            decimal left = new decimal();
            decimal prirezstopa = new decimal();
            try
            {
                enumerator = this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow row = (DataRow) enumerator.Current;
                    this.bruto.Value = Operators.AddObject(this.bruto.Value, row["bruto"]);
                    this.doprinosi.Value = Operators.AddObject(this.doprinosi.Value, row["doprinosi"]);
                    this.dohodak.Value = Operators.AddObject(this.dohodak.Value, row["dohodak"]);
                    this.dohodakk.Value = Operators.AddObject(this.dohodak.Value, row["dohodak"]);
                    this.olaksice.Value = Operators.AddObject(this.olaksice.Value, row["olaksice"]);
                    this.olaksicek.Value = Operators.AddObject(this.olaksice.Value, row["olaksice"]);
                    this.odbitak.Value = Operators.AddObject(this.odbitak.Value, row["odbitak"]);
                    this.osnovica.Value = Operators.AddObject(this.osnovica.Value, row["poreznaosnovica"]);
                    this.porez.Value = Operators.AddObject(this.porez.Value, row["porez"]);
                    this.prirez.Value = Operators.AddObject(this.prirez.Value, row["prirez"]);
                    this.krizni.Value = Operators.AddObject(this.krizni.Value, row["krizniporez"]);
                    left = Conversions.ToDecimal(Operators.AddObject(left, row["faktor"]));
                    prirezstopa = Conversions.ToDecimal(row["stopaprireza"]);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.stopaprirezainfo.Value = prirezstopa;
            this.neto.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.porez.Value), this.prirez.Value);
            this.odbitakk.Value = decimal.Multiply(1800M, left);
            this.racunaj(Conversions.ToDecimal(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.olaksicek.Value), this.odbitakk.Value)), prirezstopa);
            this.osnovicak.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.olaksice.Value), this.odbitakk.Value);
            this.netok.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.porezk.Value), this.prirezk.Value);
            if (Operators.ConditionalCompareObjectLess(this.osnovicak.Value, 0, false))
            {
                this.osnovicak.Value = 0;
            }
            if (this.ugdSuma.Rows.Count > 0)
            {
                this.ugdSuma.Rows[0].Selected = true;
            }
            if (this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select("brojmjesecisaisplatama = '99'").Length > 0)
            {
                this.dohodakkorekcija.Value = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select("brojmjesecisaisplatama = '99'")[0]["dohodak"]);
                this.brutokorekcija.Value = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select("brojmjesecisaisplatama = '99'")[0]["bruto"]);
                this.doprinosikorekcija.Value = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select("brojmjesecisaisplatama = '99'")[0]["doprinosi"]);
                this.odbitakkorekcija.Value = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select("brojmjesecisaisplatama = '99'")[0]["odbitak"]);
                this.olaksicekorekcija.Value = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select("brojmjesecisaisplatama = '99'")[0]["olaksice"]);
            }
            else
            {
                this.dohodakkorekcija.Value = 0;
                this.brutokorekcija.Value = 0;
                this.doprinosikorekcija.Value = 0;
                this.odbitakkorekcija.Value = 0;
                this.olaksicekorekcija.Value = 0;
            }
        }
    }

    private void odbitakk_ValueChanged(object sender, EventArgs e)
    {
    }

    private void odbitakk_ValueChanged_1(object sender, EventArgs e)
    {
    }

    private void Parametri_MakniOznake()
    {
        int num2 = this.UltraGrid2.Rows.Count - 1;
        for (int i = 0; i <= num2; i++)
        {
            this.UltraGrid2.Rows[i].Cells["OZNACEN"].Value = false;
            this.UltraGrid2.Rows[i].Update();
        }
        this.UltraGrid2.Text = "Zaposlenici za godišnji obračun / broj označenih: " + Conversions.ToString(this.Broj_Oznacenih());
    }

    private void Parametri_OznaciSve()
    {
        int num2 = this.UltraGrid2.Rows.Count - 1;
        for (int i = 0; i <= num2; i++)
        {
            this.UltraGrid2.Rows[i].Cells["OZNACEN"].Value = true;
            this.UltraGrid2.Rows[i].Update();
        }
        this.UltraGrid2.Text = "Zaposlenici za godišnji obračun / broj označenih: " + Conversions.ToString(this.Broj_Oznacenih());
    }

    private void porez_ValueChanged(object sender, EventArgs e)
    {
    }

    public void Preracunaj()
    {
        if (this.m_cm.Count != 0)
        {
            UltraNumericEditor odbitakrazlika;
            object[] objArray;
            object[] objArray2;
            bool[] flagArray;
            DataRowView current = (DataRowView) this.m_cm.Current;
            this.odbitakrazlika.Value = 0;
            this.odbitakrazlika.Value = Operators.SubtractObject(this.odbitak.Value, this.odbitakk.Value);
            if (Operators.ConditionalCompareObjectLess(this.odbitakrazlika.Value, 0, false))
            {
                objArray = new object[1];
                odbitakrazlika = this.odbitakrazlika;
                objArray[0] = RuntimeHelpers.GetObjectValue(odbitakrazlika.Value);
                objArray2 = objArray;
                flagArray = new bool[] { true };
                if (flagArray[0])
                {
                    odbitakrazlika.Value = RuntimeHelpers.GetObjectValue(objArray2[0]);
                }
                if (Operators.ConditionalCompareObjectLessEqual(Operators.AddObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", objArray2, null, null, flagArray), this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("brojmjesecisaisplatama = '99' AND  OIB = '", current["OIB"]), "'")))[0]["odbitak"]), this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("brojmjesecisaisplatama = '99' AND  OIB = '", current["OIB"]), "'")))[0]["dohodak"], false))
                {
                    objArray2 = new object[1];
                    odbitakrazlika = this.odbitakrazlika;
                    objArray2[0] = RuntimeHelpers.GetObjectValue(odbitakrazlika.Value);
                    objArray = objArray2;
                    flagArray = new bool[] { true };
                    if (flagArray[0])
                    {
                        odbitakrazlika.Value = RuntimeHelpers.GetObjectValue(objArray[0]);
                    }
                    this.odbitakkorekcija.Value = Operators.AddObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", objArray, null, null, flagArray), this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("brojmjesecisaisplatama = '99' AND  OIB = '", current["OIB"]), "'")))[0]["odbitak"]);
                }
                else
                {
                    this.odbitakkorekcija.Value = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("brojmjesecisaisplatama = '99' AND  OIB = '", current["OIB"]), "'")))[0]["dohodak"]);
                }
            }
            else
            {
                objArray2 = new object[1];
                odbitakrazlika = this.odbitakrazlika;
                objArray2[0] = RuntimeHelpers.GetObjectValue(odbitakrazlika.Value);
                objArray = objArray2;
                flagArray = new bool[] { true };
                if (flagArray[0])
                {
                    odbitakrazlika.Value = RuntimeHelpers.GetObjectValue(objArray[0]);
                }
                this.odbitakkorekcija.Value = Operators.SubtractObject(this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("brojmjesecisaisplatama = '99' AND  OIB = '", current["OIB"]), "'")))[0]["odbitak"], NewLateBinding.LateGet(null, typeof(Math), "Abs", objArray, null, null, flagArray));
                if (Operators.ConditionalCompareObjectLess(this.odbitakkorekcija.Value, 0, false))
                {
                    this.odbitakkorekcija.Value = 0;
                }
            }
            this.porezrazlika.Value = 0;
            this.prirezrazlika.Value = 0;
            this.porezkorekcija.Value = 0;
            this.prirezkorekcija.Value = 0;
            this.racunaj(Conversions.ToDecimal(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.olaksicek.Value), this.odbitakk.Value)), Conversions.ToDecimal(this.stopaprirezainfo.Value));
            this.porezrazlika.Value = Operators.SubtractObject(this.porezk.Value, this.porez.Value);
            this.prirezrazlika.Value = Operators.SubtractObject(this.prirezk.Value, this.prirez.Value);
            if (Operators.ConditionalCompareObjectEqual(this.porezrazlika.Value, 0, false))
            {
                this.porezkorekcija.Value = 0;
            }
            else
            {
                this.porezkorekcija.Value = Operators.AddObject(this.porezrazlika.Value, this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("brojmjesecisaisplatama = '99' AND  OIB = '", current["OIB"]), "'")))[0]["porez"]);
            }
            if (Operators.ConditionalCompareObjectEqual(this.prirezrazlika.Value, 0, false))
            {
                this.prirezkorekcija.Value = 0;
            }
            else
            {
                this.prirezkorekcija.Value = Operators.AddObject(this.prirezrazlika.Value, this.S_OD_KONACNIDataSet1.S_OD_KONACNI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("brojmjesecisaisplatama = '99' AND  OIB = '", current["OIB"]), "'")))[0]["prirez"]);
            }
            this.osnovicakorekcija.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.brutokorekcija.Value, this.doprinosikorekcija.Value), this.olaksicekorekcija.Value), this.odbitakkorekcija.Value);
            this.netokorekcija.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.brutokorekcija.Value, this.doprinosikorekcija.Value), this.olaksicekorekcija.Value), this.porezkorekcija.Value), this.prirezkorekcija.Value);
        }
    }

    public void Preracunaj_Sve()
    {
        SqlClient client = new SqlClient();
        SqlCommand sqlUpit = new SqlCommand();
        sqlUpit.Connection = client.sqlConnection;
        sqlUpit.CommandType = CommandType.Text;
        DataTable tblRazlika = new DataTable();
        DataTable tblPrirez = new DataTable();
        string id_radnika = string.Empty;
        double gop_porezna_osnovica = 0;
        double porez_stopa_12 = 0;
        double porez_stopa_25 = 0;
        double porez_stopa_40 = 0;
        const double porez_stopa12_max = 26400 * 0.12;
        const double porez_stopa25_max = 132000 * 0.25;
        double porez_ukupno = 0;
        double prirez = 0;
        double gop_razlika = 0;
        double gop_porez_razlika = 0;
        double gop_prirez_razlika = 0;
        double GOPOsobniOdbitak = 0;
        double razlika_oo = 0;

        frmStatus status = new frmStatus();
        status.Show();
        status.Label1.Text = "Godišnji obračun u tijeku, pričekajte trenutak!";

        DataTable tblGodina = client.GetDataTable("Select IDGODINE From GODINE WHERE GODINEAKTIVNA = 'true'");

        foreach (UltraGridRow row in UltraGrid2.Rows)
        {
            porez_stopa_12 = 0; 
            porez_stopa_40 = 0; 
            porez_stopa_25 = 0;
            prirez = 0;
            id_radnika = row.Cells["IDRADNIK"].Value.ToString();

            //izracun razlike neiskoristenog osobnog odbitka
            tblRazlika = client.GetDataTable("Select OsobniOdbitakPrijeGOPa, GOPOsobniOdbitak, GodisnjiIznosPrimitaka, DoprinosiIzPlace, PlaceniPorez, PlaceniPrirez, GOPPorez, GOPPrirez " + 
                                             "From GOP1 Where ID_RADNIKA = '" + id_radnika + "' And ID_GODINE = '" + tblGodina.Rows[0]["IDGODINE"].ToString() + "'");

            //gop osobni odbitak uzima iz tablice osim ako je upisano
            double parser;
            if (double.TryParse(tblRazlika.Rows[0]["GOPOsobniOdbitak"].ToString(), out parser))
            {
                GOPOsobniOdbitak = Convert.ToDouble(tblRazlika.Rows[0]["GOPOsobniOdbitak"]);

                razlika_oo = GOPOsobniOdbitak - Convert.ToDouble(tblRazlika.Rows[0]["OsobniOdbitakPrijeGOPa"]);
            }
            else
            {
                GOPOsobniOdbitak = Convert.ToDouble(tblRazlika.Rows[0]["OsobniOdbitakPrijeGOPa"]);

                razlika_oo = 0;
            }
  

            //izracun poreza
            gop_porezna_osnovica = Convert.ToDouble(tblRazlika.Rows[0]["GodisnjiIznosPrimitaka"]) - Convert.ToDouble(tblRazlika.Rows[0]["DoprinosiIzPlace"]) - GOPOsobniOdbitak;

            if (gop_porezna_osnovica <= 26400)
            {
                porez_stopa_12 = gop_porezna_osnovica * 0.12;
            }
            else if (gop_porezna_osnovica > 26400 && gop_porezna_osnovica <= 158400)
            {
                gop_porezna_osnovica = gop_porezna_osnovica - 26400;
                porez_stopa_25 = gop_porezna_osnovica * 0.25 + porez_stopa12_max;
            }
            else if (gop_porezna_osnovica > 158400)
            {
                gop_porezna_osnovica = gop_porezna_osnovica - 158400;
                porez_stopa_40 = gop_porezna_osnovica * 0.40 + porez_stopa12_max + porez_stopa25_max;
            }

            porez_ukupno = porez_stopa_12 + porez_stopa_25 + porez_stopa_40;

            //izracun prireza
            tblPrirez = client.GetDataTable("Select PRIREZ From OPCINA Where IDOPCINE = '" + row.Cells["OPCINASTANOVANJAIDOPCINE"].Value.ToString() + "'");

            prirez = porez_ukupno * (Convert.ToDouble(tblPrirez.Rows[0]["PRIREZ"]) / 100);

            //Ukoliko su opcine mjenjale prirez uzima se prosjecna vrijednost
            switch (row.Cells["OPCINASTANOVANJAIDOPCINE"].Value.ToString())
            {
                    //db - 17.11.2017
                //case "0647":
                //    prirez = porez_ukupno * (9.597 /100);
                //    break;
                //case "1490":
                //    prirez = porez_ukupno * (2.482 / 100);
                //    break;
                //case "1546":
                //    prirez = porez_ukupno * (7.5 / 100);
                //    break;
                //case "1643":
                //    prirez = porez_ukupno * (9.013 / 100);
                //    break;
                //case "2194":
                //    prirez = porez_ukupno * (6.667 / 100);
                //    break;
                //case "2232":
                //    prirez = porez_ukupno * (3.477 / 100);
                //    break;
                //case "2674":
                //    prirez = porez_ukupno * (2.865 / 100);
                //    break;
                //case "3352":
                //    prirez = porez_ukupno * (9.167 / 100);
                //    break;
                //case "3735":
                //    prirez = porez_ukupno * (14.75 / 100);
                //    break;
                //case "4138":
                //    prirez = porez_ukupno * (4.082 / 100);
                //    break;
                //case "5207":
                //    prirez = porez_ukupno * (11.833 / 100);
                //    break;
                case "2755":
                    prirez = porez_ukupno * (6.417 / 100);
                    break;
            }

            //izracun gop razlike
            if ((porez_ukupno + prirez) > (Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPorez"]) + Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPrirez"])))
            {
                gop_razlika = (porez_ukupno + prirez) -(Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPorez"]) + Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPrirez"]));
            }
            else
            {
                if ((porez_ukupno + prirez) < 0)
                {
                    gop_razlika = (Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPorez"]) + Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPrirez"]));
                }
                else
                {
                    gop_razlika = (Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPorez"]) + Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPrirez"])) - (porez_ukupno + prirez);
                }
            }

            if ((porez_ukupno + prirez) < 0)
            {
                gop_porez_razlika = -Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPorez"]);
                gop_prirez_razlika = -Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPrirez"]);
            }
            else
            {
                gop_porez_razlika = porez_ukupno - Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPorez"]);
                gop_prirez_razlika = prirez - Convert.ToDouble(tblRazlika.Rows[0]["PlaceniPrirez"]);
            }


            //upis u bazu
            //korekcija iznosda poreza i prireza (zaokruzivanje)
            if (gop_porez_razlika < 0.01 && gop_porez_razlika > 0)
            {
                gop_porez_razlika = 0.00;
            }
            else if (gop_porez_razlika > -0.01 && gop_porez_razlika < 0)
            {
                gop_porez_razlika = 0.00;
            }
            if (gop_prirez_razlika < 0.01 && gop_prirez_razlika > 0)
            {
                gop_prirez_razlika = 0.00;
            }
            else if (gop_prirez_razlika > -0.01 && gop_prirez_razlika < 0)
            {
                gop_prirez_razlika = 0.00;
            }
            if (gop_razlika < 0.01 && gop_razlika > 0)
            {
                gop_razlika = 0.00;
            }
            else if (gop_razlika > -0.01 && gop_razlika < 0)
            {
                gop_razlika = 0.00;
            }

            sqlUpit.CommandText = "Update GOP1 Set GOPPorez = '" + Math.Round(porez_ukupno, 2).ToString().Replace(',', '.') + "', GOPPrirez = '" + Math.Round(prirez, 2).ToString().Replace(',', '.') +
                                  "', GOPRazlika = '" + Math.Round(gop_razlika, 2).ToString().Replace(',', '.') + "', GOPPorezRazlika = '" + Math.Round(gop_porez_razlika, 2).ToString().Replace(',', '.') + "', " +
                                  "GOPPrirezRazlika = '" + Math.Round(gop_prirez_razlika, 2).ToString().Replace(',', '.') + "', GOPOsobniOdbitak = '" + GOPOsobniOdbitak.ToString().Replace(',', '.') + "' " + 
                                  "Where ID_RADNIKA = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'";
            try
            {
                sqlUpit.ExecuteNonQuery();
                
            }
            catch
            {
                MessageBox.Show("Dogodila se greška prilikom izračuna obračuna {Izračun}");
                status.Close();
                return;
            }
        }
        status.Close();

        if (UltraGrid2.Rows.Count > 0)
        {
            try
            {
                if (UltraGrid2.ActiveRow.Index > -1)
                    UltraGrid2.Rows[UltraGrid2.ActiveRow.Index].Selected = true;
                else
                    UltraGrid2.Rows[0].Selected = true;
            }
            catch 
            {
                UltraGrid2.Rows[0].Selected = true;
            }
        }
    }

    public void PuniPodatke()
    {
        S_OD_KONACNIDataAdapter adapter = new S_OD_KONACNIDataAdapter();
        this.S_OD_KONACNIDataSet2.Clear();
        adapter.Fill(this.S_OD_KONACNIDataSet2, 0x7da, this._CallerForm.sifraobracuna);
    }

    public void racunaj(decimal osn, decimal prirezstopa)
    {
        decimal num = 0;
        decimal num2 = 0;
        decimal num3 = 0;
        decimal num4 = 0;
        decimal num5 = 0;
        decimal num9 = 0;
        while (decimal.Compare(osn, decimal.Zero) > 0)
        {
            if (decimal.Compare(decimal.Subtract(osn, 43200M), decimal.Zero) > 0)
            {
                osn = decimal.Subtract(osn, 43200M);
                num = 43200M;
            }
            else
            {
                num = Math.Abs(osn);
                break;
            }
            if (decimal.Compare(decimal.Subtract(osn, 64800M), decimal.Zero) > 0)
            {
                osn = decimal.Subtract(osn, 64800M);
                num2 = 64800M;
            }
            else
            {
                num2 = Math.Abs(osn);
                break;
            }
            if (decimal.Compare(decimal.Subtract(osn, 21600M), decimal.Zero) > 0)
            {
                osn = decimal.Subtract(osn, 21600M);
                num3 = 21600M;
            }
            else
            {
                num3 = Math.Abs(osn);
                break;
            }
            if (decimal.Compare(decimal.Subtract(osn, 172800M), decimal.Zero) > 0)
            {
                osn = decimal.Subtract(osn, 172800M);
                num4 = 172800M;
            }
            else
            {
                num4 = Math.Abs(osn);
                break;
            }
            if (decimal.Compare(decimal.Subtract(osn, 302400M), decimal.Zero) > 0)
            {
                osn = decimal.Subtract(osn, 302400M);
                num5 = 302400M;
            }
            else
            {
                num5 = Math.Abs(osn);
                break;
            }
        }
        if (decimal.Compare(num, decimal.Zero) > 0)
        {
            num9 = decimal.Add(num9, DB.RoundUpDecimale((Convert.ToDouble(num) * 13.5) / 100.0, 2));
        }
        if (decimal.Compare(num2, decimal.Zero) > 0)
        {
            num9 = decimal.Add(num9, DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(num2, 25M), 100M), 2));
        }
        if (decimal.Compare(num3, decimal.Zero) > 0)
        {
            num9 = decimal.Add(num9, DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(num3, 30M), 100M), 2));
        }
        if (decimal.Compare(num4, decimal.Zero) > 0)
        {
            num9 = decimal.Add(num9, DB.RoundUpDecimale((Convert.ToDouble(num4) * 37.5) / 100.0, 2));
        }
        if (decimal.Compare(num5, decimal.Zero) > 0)
        {
            num9 = decimal.Add(num9, DB.RoundUpDecimale((Convert.ToDouble(num5) * 42.5) / 100.0, 2));
        }
        this.porezk.Value = num9;
        this.prirezk.Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(num9, prirezstopa), 100M), 2);
        this.osnovica.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.olaksice.Value), this.odbitak.Value);
        this.osnovicak.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.olaksice.Value), this.odbitakk.Value);
        this.dohodakk.Value = Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.olaksicek.Value);
        this.neto.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.porez.Value), this.prirez.Value);
        this.osnovicak.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.olaksice.Value), this.odbitakk.Value);
        this.netok.Value = Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(this.bruto.Value, this.doprinosi.Value), this.porezk.Value), this.prirezk.Value);
    }

    private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        e.Layout.UseFixedHeaders = true;
    }

    /// <summary>
    /// povlacenje id obracuna za upis u bazu
    /// </summary>
    public static string id_obracun;

    public static bool konacni_kontrola = false;

    internal UltraNumericEditor bruto;

    internal UltraNumericEditor brutokorekcija;

    private Button Button1;

    private Button Button2;

    private Button Button3;

    private Button Button4;

    private Button btnIzracunaj;

    private UltraNumericEditor dohodak;

    private UltraNumericEditor dohodakk;

    private UltraNumericEditor dohodakkorekcija;

    private UltraNumericEditor doprinosi;

    private UltraNumericEditor doprinosikorekcija;

    private UltraNumericEditor krizni;

    private Label Label1;

    private Label Label10;

    private Label Label11;

    private Label Label12;

    private Label Label13;

    private Label Label14;

    private Label Label2;

    private Label Label3;

    private Label Label4;

    private Label Label5;

    private Label Label6;

    private Label Label7;

    private Label Label8;

    private Label Label9;

    private CurrencyManager m_cm;

    private UltraNumericEditor neto;

    private UltraNumericEditor netok;

    private UltraNumericEditor netokorekcija;

    private UltraNumericEditor odbitak;

    private UltraNumericEditor odbitakk;

    private UltraNumericEditor odbitakkorekcija;

    private UltraNumericEditor odbitakrazlika;

    private UltraNumericEditor olaksice;

    private UltraNumericEditor olaksicek;

    private UltraNumericEditor olaksicekorekcija;

    private UltraNumericEditor osnovica;

    private UltraNumericEditor osnovicak;

    private UltraNumericEditor osnovicakorekcija;

    private UltraNumericEditor porez;

    private UltraNumericEditor porezk;

    private UltraNumericEditor porezkorekcija;

    private UltraNumericEditor porezrazlika;

    private PregledRadnikaSvihDataSet PregledRadnikaSvihDataSet1;

    private UltraNumericEditor prirez;

    private UltraNumericEditor prirezk;

    private UltraNumericEditor prirezkorekcija;

    private UltraNumericEditor prirezrazlika;

    private S_OD_KONACNI_POREZ_PO_OPCINAMADataSet S_OD_KONACNI_POREZ_PO_OPCINAMADataSet1;

    private S_OD_KONACNIDataSet S_OD_KONACNIDataSet1;

    private S_OD_KONACNIDataSet S_OD_KONACNIDataSet2;

    private UltraNumericEditor stopaprirezainfo;

    private UltraDesktopAlert UltraDesktopAlert1;

    private UltraGrid ugdSuma;

    private UltraGrid UltraGrid2;

    private UltraGroupBox UltraGroupBox1;

    private void btnUpis_Click(object sender, EventArgs e)
    {
        SqlClient client = new SqlClient();
        SqlCommand sqlUpit = new SqlCommand();
        sqlUpit.Connection = client.sqlConnection;
        sqlUpit.CommandType = CommandType.Text;
        string id_radnika = string.Empty;
        double gop_porez_razlika = 0;
        double gop_prirez_razlika = 0;
        DataTable tblObracunPoreza = new DataTable();
        DataTable tblSumaPoreza = new DataTable();
        DataTable tblFondPorezPrirez = new DataTable();
        DataTable tblSumaPrireza = new DataTable();
        //double ukupni_porez = 0;
        double placeni_prirez = 0;
        DataTable tblPorezi = new DataTable();
        //double gop_osobni_odbitak = 0;
        double osobni_odbitak_prije = 0;
        
        //double gop_fond_porez_prirez = 0;
        //double ukupni_prirez = 0;
        double razlika_oo = 0;
        double ?gop_porez = 0;
        double placeni_porez = 0;
        double gop_razlika = 0;
        

        frmStatus status = new frmStatus();
        status.Show();
        status.Label1.Text = "Upis u obračun, pričekajte trenutak!";

        foreach (UltraGridRow row in UltraGrid2.Rows)
        {
            id_radnika = row.Cells["IDRADNIK"].Value.ToString();

            DataTable tblGOP = new DataTable();
            tblGOP = client.GetDataTable("Select OsobniOdbitakPrijeGOPa, GOPOsobniOdbitak, GOPPorezRazlika, GOPPrirezRazlika, GOPPrirez, GOPPorez, PlaceniPorez, GOPRazlika, PlaceniPrirez From GOP1 Where ID_RADNIKA = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'");

            try
            {

                gop_prirez_razlika = Convert.ToDouble(tblGOP.Rows[0]["GOPPrirezRazlika"]);
            }
            catch 
            {
                gop_prirez_razlika = 0;
            }

            gop_porez_razlika = Convert.ToDouble(tblGOP.Rows[0]["GOPPorezRazlika"]);
            osobni_odbitak_prije = Convert.ToDouble(tblGOP.Rows[0]["OsobniOdbitakPrijeGOPa"]);
            try
            {
                gop_porez = Convert.ToDouble(tblGOP.Rows[0]["GOPPorez"]);
            }
            catch {}
            placeni_porez = Convert.ToDouble(tblGOP.Rows[0]["PlaceniPorez"]);
            gop_razlika = Math.Round(Convert.ToDouble(tblGOP.Rows[0]["GOPRazlika"]), 2);
            placeni_prirez = Convert.ToDouble(tblGOP.Rows[0]["PlaceniPrirez"]);


            //razlika osobnog odbitka
            //gop osobni odbitak uzima iz tablice osim ako je upisano
            if (Convert.ToDouble(tblGOP.Rows[0]["GOPOsobniOdbitak"]) == Convert.ToDouble(tblGOP.Rows[0]["OsobniOdbitakPrijeGOPa"]))
            {
                razlika_oo = 0;
            }
            else
            {
                razlika_oo = Convert.ToDouble(tblGOP.Rows[0]["GOPOsobniOdbitak"]) - Convert.ToDouble(tblGOP.Rows[0]["OsobniOdbitakPrijeGOPa"]);
            }


            //izbacivanje radnika koji nema bruto element u zadnjem obracunu
            tblGOP = client.GetDataTable("Select IDRADNIK From ObracunElementi Where IDOBRACUN = '" + id_obracun + "' And IDRADNIK = '" + id_radnika + "' And IDVRSTAELEMENTA = 2");

            if (gop_porez != null && gop_razlika != 0 && (tblGOP.Rows.Count > 0 || gop_razlika > 0))
            { 
                //upis prireza
                try
                {
                    sqlUpit.CommandText = "Update ObracunRadnici Set KOREKCIJAPRIREZA = '" + Math.Round(gop_prirez_razlika, 2).ToString().Replace(',', '.') +
                                      "', ODBITAKPRIJEKOREKCIJE = ISKORISTENOOO, ISKORISTENOOO = ISKORISTENOOO + '" + razlika_oo.ToString().Replace(',', '.') + 
                                      "' Where IDRADNIK = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'";

                    sqlUpit.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis prirez}");
                    return;
                }


                //upis poreza
                tblPorezi = client.GetDataTable("SELECT [IDPOREZ],[NAZIVPOREZ],[POREZMJESECNO],[STOPAPOREZA],[MOPOREZ],[POPOREZ],[MZPOREZ],[PZPOREZ],[PRIMATELJPOREZ1] " +
                                                ",[PRIMATELJPOREZ2],[SIFRAOPISAPLACANJAPOREZ],[OPISPLACANJAPOREZ] From POREZ Where IDPOREZ = 999");

                try
                {
                    if (gop_porez_razlika == 0)
                    {
                        continue;
                    }
                    sqlUpit.CommandText = "Insert Into ObracunPorezi (IDOBRACUN, IDRADNIK, IDPOREZ, OBRACUNATIPOREZ, OSNOVICAPOREZ, NAZIVPOREZ, STOPAPOREZA, " + 
                            "POREZMJESECNO, MOPOREZ, POPOREZ, MZPOREZ, PZPOREZ, PRIMATELJPOREZ1, PRIMATELJPOREZ2, SIFRAOPISAPLACANJAPOREZ, OPISPLACANJAPOREZ) " + 
                            "Values('" + id_obracun + "', '" + id_radnika + "', '" + tblPorezi.Rows[0]["IDPOREZ"].ToString() + "', '" + 
                            gop_porez_razlika.ToString().Replace(',', '.') + "', '0', '" + tblPorezi.Rows[0]["NAZIVPOREZ"].ToString() + "', " +
                            "'" + tblPorezi.Rows[0]["STOPAPOREZA"].ToString() + "', '" + tblPorezi.Rows[0]["POREZMJESECNO"].ToString() + "', '" + 
                            tblPorezi.Rows[0]["MOPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["POPOREZ"].ToString() + "', '" + 
                            tblPorezi.Rows[0]["MZPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["PZPOREZ"].ToString() + "', " +
                            "'" + tblPorezi.Rows[0]["PRIMATELJPOREZ1"].ToString() + "', '" + tblPorezi.Rows[0]["PRIMATELJPOREZ2"].ToString() + "', " +
                            "'" + tblPorezi.Rows[0]["SIFRAOPISAPLACANJAPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["OPISPLACANJAPOREZ"].ToString() + "')";

                    sqlUpit.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis porez}");
                    return;
                }

                //upis elementa za gop
                try
                {
                    sqlUpit.CommandText = "Insert Into ObracunElementi ([IDOBRACUN], [IDRADNIK], [IDELEMENT], [ELEMENTRAZDOBLJEOD], [ELEMENTRAZDOBLJEDO], " + 
                                          "[OBRSATI], [OBRSATNICA], [OBRPOSTOTAK], [NAZIVELEMENT], [IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT], [OBRIZNOS], [OznakaMjeseca]) Values ( " + 
                                          "'" + id_obracun + "', '" + id_radnika + "', 9997, '2014-01-01', '2014-01-01', 0, 0, 0, 'Element GOP', 3, 'Element GOP', 0, 3)";

                    sqlUpit.ExecuteNonQuery();
                }
                catch 
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis element}");
                    return;
                }
            }
            #region Old
            //korekcija prireza
            //tblSumaPrireza = client.GetDataTable("Select Sum(OBRACUNATIPRIREZ) As 'Zbroj' From ObracunRadnici Where IDOBRACUN = '" + id_obracun + "' And IDRADNIK = '" + id_radnika + "'");
            //ukupni_prirez = Convert.ToDouble(tblSumaPrireza.Rows[0]["Zbroj"]);

            //if (ukupni_prirez > Math.Abs(gop_prirez_razlika))
            //{
            //    sqlUpit.CommandText = "Update ObracunRadnici Set KOREKCIJAPRIREZA = '" + Math.Round(gop_prirez_razlika, 2).ToString().Replace(',', '.') +
            //                          "' Where IDRADNIK = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'";
            //    gop_prirez_razlika = 0;
            //}
            //else
            //{
            //    gop_prirez_razlika = Math.Abs(gop_prirez_razlika) - ukupni_prirez;
            //    ukupni_prirez = ukupni_prirez * -1;
            //    sqlUpit.CommandText = "Update ObracunRadnici Set KOREKCIJAPRIREZA = '" + Math.Round(ukupni_prirez, 2).ToString().Replace(',', '.') +
            //                          "' Where IDRADNIK = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'";
                
            //}

            //try
            //{
            //    sqlUpit.ExecuteNonQuery();
            //}
            //catch
            //{
            //    MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis prirez}");
            //    return;
            //}


            ////korekcija poreza
            //tblSumaPoreza = client.GetDataTable("Select Sum(OBRACUNATIPOREZ) As 'Zbroj' From ObracunPorezi Where IDOBRACUN = '" + id_obracun + "' And IDRADNIK = '" + id_radnika + "'");
            //try
            //{


            //    if (tblSumaPoreza.Rows[0]["Zbroj"].ToString() != string.Empty) 
            //    {
            //        tblPorezi = client.GetDataTable("SELECT [IDPOREZ],[NAZIVPOREZ],[POREZMJESECNO],[STOPAPOREZA],[MOPOREZ],[POPOREZ],[MZPOREZ],[PZPOREZ],[PRIMATELJPOREZ1] " +
            //                                        ",[PRIMATELJPOREZ2],[SIFRAOPISAPLACANJAPOREZ],[OPISPLACANJAPOREZ] From POREZ Where IDPOREZ = 999");


            //        ukupni_porez = Convert.ToDouble(tblSumaPoreza.Rows[0]["Zbroj"]);
            //        gop_porez_razlika = gop_porez_razlika * -1;
            //        sqlUpit.CommandText = "Insert Into ObracunPorezi (IDOBRACUN, IDRADNIK, IDPOREZ, OBRACUNATIPOREZ, OSNOVICAPOREZ, NAZIVPOREZ, STOPAPOREZA, POREZMJESECNO, MOPOREZ, POPOREZ, " +
            //                                "MZPOREZ, PZPOREZ, PRIMATELJPOREZ1, PRIMATELJPOREZ2, SIFRAOPISAPLACANJAPOREZ, OPISPLACANJAPOREZ) Values('" + id_obracun + "', '" + id_radnika + "', " +
            //                                "'" + tblPorezi.Rows[0]["IDPOREZ"].ToString() + "', '" + gop_porez_razlika.ToString().Replace(',', '.') + "', '0', '" + tblPorezi.Rows[0]["NAZIVPOREZ"].ToString() + "', " +
            //                                "'" + tblPorezi.Rows[0]["STOPAPOREZA"].ToString() + "', '" + tblPorezi.Rows[0]["POREZMJESECNO"].ToString() + "', '" + tblPorezi.Rows[0]["MOPOREZ"].ToString() + "', " +
            //                                "'" + tblPorezi.Rows[0]["POPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["MZPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["PZPOREZ"].ToString() + "', " +
            //                                "'" + tblPorezi.Rows[0]["PRIMATELJPOREZ1"].ToString() + "', '" + tblPorezi.Rows[0]["PRIMATELJPOREZ2"].ToString() + "', " +
            //                                "'" + tblPorezi.Rows[0]["SIFRAOPISAPLACANJAPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["OPISPLACANJAPOREZ"].ToString() + "')";

            //        try
            //        {
            //            sqlUpit.ExecuteNonQuery();
            //        }
            //        catch
            //        {
            //            MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis porez 1}");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        gop_fond_porez_prirez = gop_prirez_razlika + gop_porez_razlika;
            //        sqlUpit.CommandText = "Update GOP1 Set GOPFondPorezaPrireza = '" + gop_fond_porez_prirez.ToString().Replace(',', '.') + "' Where ID_RADNIKA = '" + id_radnika + "' And IDOBRACUN = '" + id_obracun + "'";

            //        try
            //        {
            //            sqlUpit.ExecuteNonQuery();
            //        }
            //        catch
            //        {
            //            MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis porez 3}");
            //            return;
            //        }

            //        //Nepotrebna je razlika M.K. 20.11.14. - komentiraj kasnije
            //        //razlika = gop_osobni_odbitak - osobni_odbitak_prije;

            //        if (razlika > 0)
            //        {
            //            placeni_prirez = placeni_prirez * -1;
            //            sqlUpit.CommandText = "Update ObracunRadnici Set KOREKCIJAPRIREZA = '" + gop_prirez_razlika.ToString().Replace(',', '.') + "' Where IDOBRACUN = '" + id_obracun + "' And IDRADNIK = '" + id_radnika + "'";

            //            //Nesmijemo upisivati osobni odbitak drugačiji od onoga koji je već obračunat u plaći. M.K. 20.11.2014.

            //            //sqlUpit.CommandText = "Update ObracunRadnici Set OdbitakPrijeKorekcije = Iskoristenooo, Iskoristenooo = '" + osobni_odbitak_prije.ToString().Replace(',', '.') +
            //            //                  "', KOREKCIJAPRIREZA = '" + gop_prirez_razlika.ToString().Replace(',', '.') + "' Where IDOBRACUN = '" + id_obracun + "' And IDRADNIK = '" + id_radnika + "'";

            //            try
            //            {
            //                sqlUpit.ExecuteNonQuery();
            //            }
            //            catch
            //            {
            //                MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis porez 4}");
            //                return;
            //            }
            //        }

            //        tblPorezi = client.GetDataTable("SELECT [IDPOREZ],[NAZIVPOREZ],[POREZMJESECNO],[STOPAPOREZA],[MOPOREZ],[POPOREZ],[MZPOREZ],[PZPOREZ],[PRIMATELJPOREZ1] " +
            //                                            ",[PRIMATELJPOREZ2],[SIFRAOPISAPLACANJAPOREZ],[OPISPLACANJAPOREZ] From POREZ Where IDPOREZ = 999");

            //        razlika = razlika * -1;
            //        if (gop_porez < 0)
            //        {
            //            placeni_porez = placeni_porez * -1;
                        
            //            sqlUpit.CommandText = "Insert Into ObracunPorezi (IDOBRACUN, IDRADNIK, IDPOREZ, OBRACUNATIPOREZ, OSNOVICAPOREZ, NAZIVPOREZ, STOPAPOREZA, POREZMJESECNO, MOPOREZ, POPOREZ, " +
            //                              "MZPOREZ, PZPOREZ, PRIMATELJPOREZ1, PRIMATELJPOREZ2, SIFRAOPISAPLACANJAPOREZ, OPISPLACANJAPOREZ) Values('" + id_obracun + "', '" + id_radnika + "', " +
            //                              "'" + tblPorezi.Rows[0]["IDPOREZ"].ToString() + "', '" + placeni_porez.ToString().Replace(',', '.') + "', '" + gop_porez_razlika.ToString().Replace(',', '.') + "', '" + tblPorezi.Rows[0]["NAZIVPOREZ"].ToString() + "', " +
            //                              "'" + tblPorezi.Rows[0]["STOPAPOREZA"].ToString() + "', '" + tblPorezi.Rows[0]["POREZMJESECNO"].ToString() + "', '" + tblPorezi.Rows[0]["MOPOREZ"].ToString() + "', " +
            //                              "'" + tblPorezi.Rows[0]["POPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["MZPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["PZPOREZ"].ToString() + "', " +
            //                              "'" + tblPorezi.Rows[0]["PRIMATELJPOREZ1"].ToString() + "', '" + tblPorezi.Rows[0]["PRIMATELJPOREZ2"].ToString() + "', " +
            //                              "'" + tblPorezi.Rows[0]["SIFRAOPISAPLACANJAPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["OPISPLACANJAPOREZ"].ToString() + "')";
            //        }
            //        else
            //        {
            //            gop_razlika = gop_razlika * -1;
            //            sqlUpit.CommandText = "Insert Into ObracunPorezi (IDOBRACUN, IDRADNIK, IDPOREZ, OBRACUNATIPOREZ, OSNOVICAPOREZ, NAZIVPOREZ, STOPAPOREZA, POREZMJESECNO, MOPOREZ, POPOREZ, " +
            //                                  "MZPOREZ, PZPOREZ, PRIMATELJPOREZ1, PRIMATELJPOREZ2, SIFRAOPISAPLACANJAPOREZ, OPISPLACANJAPOREZ) Values('" + id_obracun + "', '" + id_radnika + "', " +
            //                                  "'" + tblPorezi.Rows[0]["IDPOREZ"].ToString() + "', '" + gop_razlika.ToString().Replace(',', '.') + "', '" + gop_porez_razlika.ToString().Replace(',', '.') + "', '" + tblPorezi.Rows[0]["NAZIVPOREZ"].ToString() + "', " +
            //                                  "'" + tblPorezi.Rows[0]["STOPAPOREZA"].ToString() + "', '" + tblPorezi.Rows[0]["POREZMJESECNO"].ToString() + "', '" + tblPorezi.Rows[0]["MOPOREZ"].ToString() + "', " +
            //                                  "'" + tblPorezi.Rows[0]["POPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["MZPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["PZPOREZ"].ToString() + "', " +
            //                                  "'" + tblPorezi.Rows[0]["PRIMATELJPOREZ1"].ToString() + "', '" + tblPorezi.Rows[0]["PRIMATELJPOREZ2"].ToString() + "', " +
            //                                  "'" + tblPorezi.Rows[0]["SIFRAOPISAPLACANJAPOREZ"].ToString() + "', '" + tblPorezi.Rows[0]["OPISPLACANJAPOREZ"].ToString() + "')";
            //        }

            //        try
            //        {
            //            sqlUpit.ExecuteNonQuery();
            //        }
            //        catch
            //        {
            //            MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis porez 2}");
            //            return;
            //        }

            //    }
            //}
            //catch 
            //{
            //    MessageBox.Show("Dogodila se greška prilikom upisa u obračun {Upis porez 3}");
            //    return;
            //}
            #endregion
        }
        status.Close();
        konacni_kontrola = true;
        kontrola_za_gasenje = true;
    }

    private void UltraGrid2_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
    {
        if (UltraGrid2.DisplayLayout.Bands.Count > 0)
            if (UltraGrid2.DisplayLayout.Bands[0].Columns.Count > 0)
            {
                SqlClient client = new SqlClient();
                DataTable tblSuma = new DataTable();
                string id_radnik = UltraGrid2.ActiveRow.Cells["IDRADNIK"].Value.ToString();

                DataTable tblFiskalnaGodina = client.GetDataTable("Select IDGODINE From GODINE Where GODINEAKTIVNA = 'true'");

                tblSuma = client.GetDataTable("Select IDOBRACUN, ID_RADNIKA As 'Šifra radnika', OsobniOdbitakPrijeGOPa As 'Osobni odbitak prije GOP-a', GodisnjiIznosPrimitaka As 'Godišnji iznos primitka', " +
                                      "DoprinosiIzPlace As 'Doprinos iz plaće', PlaceniPorez As 'Plaćeni porez', PlaceniPrirez As 'Plaćeni prirez', NekoristeniMjeseci As 'Pravo na OO u mjesecima', " +
                                      "GOPOsobniOdbitak As 'GOP osobni odbitak', GOPPorez As 'GOP porez', GOPPrirez As 'GOP prirez', GOPRazlika As 'GOP razlika' From GOP1 " +
                                      "Where ID_RADNIKA = '" + id_radnik + "' And ID_GODINE = '" + tblFiskalnaGodina.Rows[0][0].ToString() + "'");
                ugdSuma.DataSource = tblSuma;


                ugdSuma.DisplayLayout.Bands[0].Columns["Osobni odbitak prije GOP-a"].Format = "N2";
                ugdSuma.DisplayLayout.Bands[0].Columns["Osobni odbitak prije GOP-a"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                ugdSuma.DisplayLayout.Bands[0].Columns["Godišnji iznos primitka"].Format = "N2";
                ugdSuma.DisplayLayout.Bands[0].Columns["Godišnji iznos primitka"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                ugdSuma.DisplayLayout.Bands[0].Columns["Doprinos iz plaće"].Format = "N2";
                ugdSuma.DisplayLayout.Bands[0].Columns["Doprinos iz plaće"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                ugdSuma.DisplayLayout.Bands[0].Columns["Plaćeni porez"].Format = "N2";
                ugdSuma.DisplayLayout.Bands[0].Columns["Plaćeni porez"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                ugdSuma.DisplayLayout.Bands[0].Columns["Plaćeni prirez"].Format = "N2";
                ugdSuma.DisplayLayout.Bands[0].Columns["Plaćeni prirez"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                ugdSuma.DisplayLayout.Bands[0].Columns["GOP osobni odbitak"].Format = "N2";
                ugdSuma.DisplayLayout.Bands[0].Columns["GOP osobni odbitak"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                ugdSuma.DisplayLayout.Bands[0].Columns["GOP porez"].Hidden = true;
                ugdSuma.DisplayLayout.Bands[0].Columns["IDOBRACUN"].Hidden = true;
                ugdSuma.DisplayLayout.Bands[0].Columns["GOP prirez"].Hidden = true;
                ugdSuma.DisplayLayout.Bands[0].Columns["Pravo na OO u mjesecima"].Hidden = true;
                ugdSuma.DisplayLayout.Bands[0].Columns["GOP razlika"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                ugdSuma.DisplayLayout.Bands[0].Columns["GOP razlika"].Format = "N2";
            }
    }

    private void UltraGrid2_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
    {
        e.DisplayPromptMsg = false;
    }

    private void btnBolovanje_Click(object sender, EventArgs e)
    {
        
    }

    private void frmKonacni_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (kontrola_za_gasenje)
        {
            MessageBox.Show("Izvršen je godišnji obračun poreza.\nMolimo vas otvorite obračun ponovno.", "Konačni obračun poreza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _CallerForm.Controller.WorkItem.Workspaces["main"].Close(RuntimeHelpers.GetObjectValue(_CallerForm.Controller.WorkItem.Workspaces["main"].ActiveSmartPart));
        }
    }

    private void ugdSuma_AfterCellUpdate(object sender, CellEventArgs e)
    {
        string value = ugdSuma.ActiveCell.Value.ToString();
        double parser;

        string id_radnika = ugdSuma.ActiveRow.Cells["Šifra radnika"].Value.ToString();
        string id_obracun = ugdSuma.ActiveRow.Cells["IDOBRACUN"].Value.ToString();

        SqlClient client = new SqlClient();
        SqlCommand sqlUpit = new SqlCommand();
        sqlUpit.Connection = client.sqlConnection;
        sqlUpit.CommandType = CommandType.Text;

        if (Double.TryParse(value, out parser))
        {
            if (parser < 0 | parser > 500000)
            {
                MessageBox.Show("Osobni odbitak mora biti u rasponu o 0 do 500000");
            }
            else
            {
                try
                {
                    sqlUpit.CommandText = "Update GOP1 Set GOPOsobniOdbitak = '" + parser.ToString().Replace(',', '.') + "' Where ID_RADNIKA = '" + 
                                            id_radnika + "' And IDOBRACUN = '" + id_obracun + "'";

                    sqlUpit.ExecuteNonQuery();
                }
                catch 
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa osobnog odbitka {Osobni odbitak}");
                    return;
                }
            }
        }
        else
        {
            if (value.Length != 0)
            {
                MessageBox.Show("Krivi format unosa osobnog odbitka");
            }
            else
            {
                try
                {
                    sqlUpit.CommandText = "Update GOP1 Set GOPOsobniOdbitak = NULL Where ID_RADNIKA = '" +
                                            id_radnika + "' And IDOBRACUN = '" + id_obracun + "'";

                    sqlUpit.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa osobnog odbitka {Osobni odbitak}");
                    return;
                }
            }

                
        }
    }

    private void ugdSuma_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
        {
            e.Handled = false;
        }
        else
        {
            e.Handled = true;
        }

        if (e.KeyChar == '.')
        {
            e.KeyChar = ',';
        }
    }

}

