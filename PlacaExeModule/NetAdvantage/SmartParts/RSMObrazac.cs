namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using My.Resources;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using mipsed.application.framework;
    using Placa;
    using RSM;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Windows.Forms;
    using System.Text;

    [SmartPart]
    public class RSMObrazac : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private KORISNIKDataAdapter dakorisnik;
        private RSMADataAdapter daRSM;
        private RSVRSTEOBRACUNADataAdapter darsvrsteobracuna;
        private RSVRSTEOBVEZNIKADataAdapter darsvrsteobveznika;
        private bool dd;
        private KORISNIKDataSet dskorisnik;
        private frmPregledObracuna frm;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public RSMObrazac()
        {
            base.Load += new EventHandler(this.RsmObrazacLoad);
            this.darsvrsteobveznika = new RSVRSTEOBVEZNIKADataAdapter();
            this.darsvrsteobracuna = new RSVRSTEOBRACUNADataAdapter();
            this.dakorisnik = new KORISNIKDataAdapter();
            this.dskorisnik = new KORISNIKDataSet();
            this.daRSM = new RSMADataAdapter();
            this.dd = false;
            this.smartPartInfo1 = new SmartPartInfo("RSmObrazac", "RSm Obrazac");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private object brisi_RSM(string IDENT)
        {
            object obj2 = new object();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            command.CommandText = "delete from RSMA1 where IDENTIFIKATOROBRASCA = '" + IDENT + "'";
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            connection.Open();
            command.ExecuteScalar();
            command.CommandText = "delete from RSMA where IDENTIFIKATOROBRASCA = '" + IDENT + "'";
            command.CommandType = CommandType.Text;
            command.ExecuteScalar();
            connection.Close();
            return obj2;
        }

        private void cbVrstaObracuna_Validating(object sender, CancelEventArgs e)
        {
            if (((this.cbVrstaObracuna.SelectedRow != null) &&
                Operators.ConditionalCompareObjectEqual(this.cbVrstaObracuna.SelectedRow.Cells["IDRSVRSTEOBRACUNA"].Value, "03", false)) && 
                (Interaction.MsgBox(My.Resources.ResourcesPlacaExe.RSMObrazac_cbVrstaObracuna_Validating_Želite_li_svim_osiguranicima_na_stranici_B_postaviti_razdoblje_od_do_na_00_do_00, MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes))
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.RsmaDataSet1.RSMA1.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        current["OD"] = "00";
                        current["DOO"] = "00";
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
            this.RSM_Unos_u_Bazu();
        }

        private void cbVrstaObveznika_Validating(object sender, CancelEventArgs e)
        {
            this.RSM_Unos_u_Bazu();
        }

        public void Datoteka_RSM_2010()
        {
            if (this.RsmaDataSet1.RSMA.Rows.Count == 0)
            {
                Interaction.MsgBox("Potrebno je odabrati obračun!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                IEnumerator enumerator = null;

                StringBuilder slog_0 = new StringBuilder();
                StringBuilder slog_3 = new StringBuilder();
                StringBuilder slog_5 = new StringBuilder();
                StringBuilder slog_7 = new StringBuilder();
                StringBuilder slog_9 = new StringBuilder();

                int brojSlogova5 = 0;
                
                // ----------------------------------------------------------------------------------------
                // SLOG 0 - početni slog formata
                // ----------------------------------------------------------------------------------------
                slog_0.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 12)); // RS0REZ1

                // u polje OIB upisuju se prvo 2 znaka praznine (2 znaka blank) i nakon toga u istom polju OIB(11) (upute su malo ne konzistentne)
                slog_0.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 2)); // RS0IBOO - 1. dio
                slog_0.Append(GenerirajVrijednost(this.dskorisnik.KORISNIK.Rows[0]["OIBOVLASTENEOSOBE"], TipPolja.C_Alfanumeric, 11)); // RS0IBOO - 2. dio

                slog_0.Append(GenerirajVrijednost(this.dskorisnik.KORISNIK.Rows[0]["PREZIMEIMEOVLASTENEOSOBE"], TipPolja.C_Alfanumeric, 50)); // RS0NAZO
                slog_0.Append(GenerirajVrijednost(this.dskorisnik.KORISNIK.Rows[0]["ADRESAOVLASTENEOSOBE"], TipPolja.C_Alfanumeric, 50)); // RS0ADRO
                slog_0.Append(GenerirajVrijednost(this.dskorisnik.KORISNIK.Rows[0]["KONTAKTOSOBA"], TipPolja.C_Alfanumeric, 50)); // RS0OSOB
                slog_0.Append(GenerirajVrijednost(this.dskorisnik.KORISNIK.Rows[0]["KONTAKTTELEFON"], TipPolja.C_Alfanumeric, 10)); // RS0TELE
                slog_0.Append(GenerirajVrijednost(this.dskorisnik.KORISNIK.Rows[0]["EMAIL"], TipPolja.C_Alfanumeric, 30)); // RS0MAIL
                slog_0.Append(GenerirajVrijednost(Strings.Format(DateAndTime.Today, "ddMMyyyy"), TipPolja.N_Numeric, 8)); // RS0DTMN
                slog_0.Append(GenerirajVrijednost("RM500", TipPolja.C_Alfanumeric, 5)); // RS0OFOR
                slog_0.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 21)); // RS0REZE
                slog_0.Append("0"); // RS0TIPS

                slog_0.Append("\r\n");

                
                // ----------------------------------------------------------------------------------------
                // SLOG 3 - početni slog jednog obrasca R-Sm u formatu
                // ----------------------------------------------------------------------------------------
                slog_3.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 12)); // RS3REZ1

                // u polje OIB upisuju se prvo 2 znaka praznine (2 znaka blank) i nakon toga u istom polju OIB(11) (upute su malo ne konzistentne)
                slog_3.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 2)); // RS3IBOO - 1. dio
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["MBOBVEZNIKA"], TipPolja.C_Alfanumeric, 11)); // RS3IBOO - 2. dio
                
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["IDENTIFIKATOROBRASCA"], TipPolja.N_Numeric, 4)); // RS3IDOB
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["NAZIVOBVEZNIKA"], TipPolja.C_Alfanumeric, 50)); // RS3NAOB
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["ADRESA"], TipPolja.C_Alfanumeric, 50)); // RS3ADOB
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBVEZNIKA"], TipPolja.N_Numeric, 2)); // RS3VROB

                // vodi se kao jedno polje od 6 znakova
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["MJESECOBRACUNARSM"], TipPolja.N_Numeric, 2)); // RS3MMBGG - 1. dio
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["GODINAOBRACUNARSM"], TipPolja.N_Numeric, 4)); // RS3MMBGG - 2. dio

                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBRACUNA"], TipPolja.N_Numeric, 2)); // RS3VROI
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["BROJOSIGURANIKA"], TipPolja.N_Numeric, 5)); // RS3BROS
                slog_3.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["IZNOSOBRACUNANEPLACE"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS3IBRT
                slog_3.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["IZNOSOSNOVICEZADOPRINOSE"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS3IOSN
                slog_3.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["MIO1"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS3IST1
                slog_3.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["MIO2"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS3IST2
                slog_3.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["IZNOSISPLACENEPLACE"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS3INET

                // vodi se kao jedno polje od 6 znakova
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["GODINAISPLATERSM"], TipPolja.N_Numeric, 4)); // RS3IGMM - 1. dio
                slog_3.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["MJESECISPLATERSM"], TipPolja.N_Numeric, 2)); // RS3IGMM - 2. dio
                slog_3.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 24)); // RS3REZE
                slog_3.Append("3"); // RS3TIPS

                slog_3.Append("\r\n");


                // ----------------------------------------------------------------------------------------
                // SLOG 5 - slog pojedinačne transakcije obrasca R-Sm
                // ----------------------------------------------------------------------------------------
                try
                {
                    enumerator = this.RsmaDataSet1.RSMA1.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        brojSlogova5++;

                        DataRow current = (DataRow)enumerator.Current;

                        slog_5.Append(GenerirajVrijednost(current["rednibroj"], TipPolja.N_Numeric, 5)); // RS5RBRO

                        // u polje OIB upisuju se prvo 2 znaka praznine (2 znaka blank) i nakon toga u istom polju OIB(11) (upute su malo ne konzistentne)
                        slog_5.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 2)); // RS5IBOO - 1. dio
                        slog_5.Append(GenerirajVrijednost(current["mbgosiguranika"], TipPolja.C_Alfanumeric, 11)); // RS5IBOO - 2. dio

                        slog_5.Append(GenerirajVrijednost(current["prezimeiime"], TipPolja.C_Alfanumeric, 30)); // RS5PRIM
                        slog_5.Append(GenerirajVrijednost(current["sifragradarada"], TipPolja.N_Numeric, 4)); // RS5GROP

                        // vodi se kao jedno polje od 3 znaka
                        slog_5.Append(GenerirajVrijednost(current["OO"], TipPolja.N_Numeric, 2)); // RS5OSOB - 1. dio
                        slog_5.Append(GenerirajVrijednost(current["b"], TipPolja.N_Numeric, 1)); // RS5OSOB - 2. dio

                        // vodi se kao jedno polje od 4 znaka
                        slog_5.Append(GenerirajVrijednost(current["OD"], TipPolja.N_Numeric, 2)); // RS5RAZD - 1. dio
                        slog_5.Append(GenerirajVrijednost(current["DOO"], TipPolja.N_Numeric, 2)); // RS5RAZD - 2. dio

                        slog_5.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(current["iznosobracunaneplacersmb"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS5IBRT
                        slog_5.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(current["IZNOSOSNOVICEZADOPRINOSERSMB"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS5IOSN
                        slog_5.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(current["mio1rsmb"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS5IST1
                        slog_5.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(current["mio2rsmb"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS5IST2
                        slog_5.Append(GenerirajVrijednost(Decimal.Round(Convert.ToDecimal(current["IZNOSISPLACENEPLACERSMB"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty), TipPolja.N_Numeric, 15)); // RS5INET
                        slog_5.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 115)); // RS5REZE
                        slog_5.Append("5"); // RS5TIPS

                        slog_5.Append("\r\n");
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }


                // ----------------------------------------------------------------------------------------
                // SLOG 7 - završni slog jednog obrasca R-Sm u formatu
                // ----------------------------------------------------------------------------------------
                slog_7.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 12)); // RS7REZ1

                // u polje OIB upisuju se prvo 2 znaka praznine (2 znaka blank) i nakon toga u istom polju OIB(11) (upute su malo ne konzistentne)
                slog_7.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 2)); // RS7IBOO - 1. dio
                slog_7.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["MBOBVEZNIKA"], TipPolja.C_Alfanumeric, 11)); // RS7IBOO - 2. dio

                slog_7.Append(GenerirajVrijednost(this.RsmaDataSet1.RSMA.Rows[0]["IDENTIFIKATOROBRASCA"], TipPolja.N_Numeric, 4)); // RS7IDOB
                slog_7.Append(GenerirajVrijednost(brojSlogova5, TipPolja.N_Numeric, 5)); // RS7BRSL
                slog_7.Append(GenerirajVrijednost(Strings.Format(DateAndTime.Today, "ddMMyyyy"), TipPolja.N_Numeric, 8)); // RS7BRSL
                slog_7.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 207)); // RS7REZE
                slog_7.Append("7"); // RS7TIPS

                slog_7.Append("\r\n");


                // ----------------------------------------------------------------------------------------
                // SLOG 9 - završni slog formata
                // ----------------------------------------------------------------------------------------
                slog_9.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 12)); // RS9REZ1

                // u polje OIB upisuju se prvo 2 znaka praznine (2 znaka blank) i nakon toga u istom polju OIB(11) (upute su malo ne konzistentne)
                slog_9.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 2)); // RS9IBOO - 1. dio
                slog_9.Append(GenerirajVrijednost(this.dskorisnik.KORISNIK.Rows[0]["OIBOVLASTENEOSOBE"], TipPolja.C_Alfanumeric, 11)); // RS9IBOO - 2. dio

                slog_9.Append(GenerirajVrijednost(Strings.Format(DateAndTime.Today, "ddMMyyyy"), TipPolja.N_Numeric, 8)); // RS9DTMN
                slog_9.Append(GenerirajVrijednost("1", TipPolja.N_Numeric, 6)); // RS9BROJ
                slog_9.Append(GenerirajVrijednost(string.Empty, TipPolja.C_Alfanumeric, 210)); // RS9REZE
                slog_9.Append("9"); // RS9TIPS

                slog_9.Append("\r\n");


                // ----------------------------------------------------------------------------------------
                // ----------------------------------------------------------------------------------------

                #region slog_0_old
                /*
                string str2 = this.Dodaj_Vodece_Praznine(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["OIBOVLASTENEOSOBE"]), 13);
                string str9 = this.Dodaj_Vodece_Praznine(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["MBOBVEZNIKA"]), 13);
                string str11 = this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["NAZIVOBVEZNIKA"]), 50);
                string str3 = this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["PREZIMEIMEOVLASTENEOSOBE"]), 50);
                string str8 = this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["ADRESAOVLASTENEOSOBE"]), 50);
                string str5 = this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["ADRESA"]), 50);
                string str12 = this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KONTAKTOSOBA"]), 50);
                string str14 = this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KONTAKTTELEFON"]), 10);
                string str10 = this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["EMAIL"]), 30);
                string str6 = Strings.Format(DateAndTime.Today, "ddMMyyyy");
                string str7 = "RM500";
                string str13 = Strings.Space(0x15);
                string str15 = "0";
                string str17 = Strings.Space(12) + str2 + str3 + str + str12 + str14 + str10 + str6 + str7 + str13 + str15 + "\r\n";
                FileSystem.Print(1, new object[] { str17 });
                 * */
                #endregion

                #region slog_3_old
                /*
                string str18 = (((((((((Strings.Space(12) + 
                    this.Dodaj_Vodece_Praznine(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["MBOBVEZNIKA"]), 13)) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["IDENTIFIKATOROBRASCA"]), 4) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["NAZIVOBVEZNIKA"]), 50)) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["ADRESA"]), 50) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBVEZNIKA"]), 2)) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["MJESECOBRACUNARSM"]), 2) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["GODINAOBRACUNARSM"]), 4)) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBRACUNA"]), 2)) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["BROJOSIGURANIKA"]), 5) + 
                    DB.DoubleToString(Conversions.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["IZNOSOBRACUNANEPLACE"]))) + 
                    DB.DoubleToString(Conversions.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["IZNOSOSNOVICEZADOPRINOSE"])) + 
                    DB.DoubleToString(Conversions.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["MIO1"]))) + 
                    DB.DoubleToString(Conversions.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["MIO2"])) + 
                    DB.DoubleToString(Conversions.ToDecimal(this.RsmaDataSet1.RSMA.Rows[0]["IZNOSISPLACENEPLACE"]))) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["GODINAISPLATERSM"]), 4) + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["MJESECISPLATERSM"]), 2)) + Strings.Space(0x18) + "3\r\n";
                FileSystem.Print(1, new object[] { str18 });
                 * */
                #endregion

                #region slog_5_old
                /*
                try
                {
                    enumerator = this.RsmaDataSet1.RSMA1.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        string str19 = (((Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(
                            Conversions.ToString(current["rednibroj"]) + this.Dodaj_Vodece_Praznine(Conversions.ToString(current["mbgosiguranika"]), 13) + this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(current["prezimeiime"]), 30), current["sifragradarada"])), current["OO"])), current["b"])), current["OD"])), current["DOO"])) + DB.DoubleToString(Conversions.ToDecimal(current["iznosobracunaneplacersmb"]))) + DB.DoubleToString(Conversions.ToDecimal(current["IZNOSOSNOVICEZADOPRINOSERSMB"])) + DB.DoubleToString(Conversions.ToDecimal(current["mio1rsmb"]))) + DB.DoubleToString(Conversions.ToDecimal(current["mio2rsmb"])) + DB.DoubleToString(Conversions.ToDecimal(current["IZNOSISPLACENEPLACERSMB"]))) + Strings.Space(0x73) + "5\r\n";
                        FileSystem.Print(1, new object[] { str19 });
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                */
                #endregion

                #region slog_7_old
                /*
                string str20 = (((Strings.Space(12) + str9) + str8 + 
                    this.Dodaj_Praznine_Na_Kraj(Conversions.ToString(this.RsmaDataSet1.RSMA.Rows[0]["IDENTIFIKATOROBRASCA"]), 4)) + 
                    DB.BrojVodeceNule(this.RsmaDataSet1.RSMA1.Rows.Count, 5, 0, false, "") + 
                    Strings.Format(DateAndTime.Today, "ddMMyyyy")) + Strings.Space(0xcf) + "7\r\n";
                FileSystem.Print(1, new object[] { str20 });
                */
                #endregion

                #region slog_9_old
                /*
                string str21 = ((Strings.Space(12) + str2 + Strings.Format(DateAndTime.Today, "ddMMyyyy")) + "000001" + Strings.Space(0x52)) + Strings.Space(0x80) + "9\r\n";
                FileSystem.Print(1, new object[] { str21 });
                */
                #endregion

                string destFileName = string.Empty;

                try
                {
                    SaveFileDialog dialog2 = new SaveFileDialog {
                        InitialDirectory = Conversions.ToString(0),
                        FileName = "REGOS.RM0",
                        RestoreDirectory = true
                    };
                    SaveFileDialog dialog = dialog2;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        destFileName = dialog.FileName;

                        // novi način spremanja u datoteku
                        StreamWriter streamWriter = new StreamWriter(destFileName, false, Encoding.GetEncoding("Windows-1250"));
                        streamWriter.AutoFlush = true;

                        try
                        {
                            // konkataniramo string buildere
                            streamWriter.Write(slog_0.ToString() + slog_3.ToString() + slog_5.ToString() + slog_7.ToString() + slog_9.ToString());
                            streamWriter.Close();

                            Interaction.MsgBox(string.Format("Disketa '{0}' je uspješno kreirana! Pričekajte trenutak, generiram RSM stranica A sa HASHOM!", destFileName), MsgBoxStyle.OkOnly, null);
                            string str4 = GetSHA1Hash(destFileName);

                            object obj2 = Strings.Mid(str4, 1, 10);
                            object obj3 = Strings.Mid(str4, 11, 10);
                            object obj4 = Strings.Mid(str4, 0x15, 10);
                            object obj5 = Strings.Mid(str4, 0x1f, 10);
                            ReportDocument document = new ReportDocument();
                            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rsma2010.rpt");
                            document.SetDataSource(this.RsmaDataSet1);
                            document.ReportDefinition.Sections["Section5"].ReportObjects["brojstranicab1"].ObjectFormat.EnableSuppress = true;
                            if (Operators.ConditionalCompareObjectEqual(this.RsmaDataSet1.RSMA.Rows[0]["MBGOBVEZNIKA"], "0000000000000", false))
                            {
                                document.ReportDefinition.Sections["Section5"].ReportObjects["MBGOBVEZNIKA1"].ObjectFormat.EnableSuppress = true;
                            }
                            if (Operators.ConditionalCompareObjectEqual(this.RsmaDataSet1.RSMA.Rows[0]["MBOBVEZNIKA"], "00000000", false))
                            {
                                document.ReportDefinition.Sections["Section5"].ReportObjects["MBOBVEZNIKA1"].ObjectFormat.EnableSuppress = true;
                            }
                            document.SetParameterValue("brojstranicab", Conversions.ToInteger(Operators.AddObject(this.RsmaDataSet1.RSMA1.Rows.Count / 12, Interaction.IIf((this.RsmaDataSet1.RSMA1.Rows.Count % 12) > 0, 1, 0))).ToString("000;000;000"));
                            document.SetParameterValue("h1", RuntimeHelpers.GetObjectValue(obj2));
                            document.SetParameterValue("h2", RuntimeHelpers.GetObjectValue(obj3));
                            document.SetParameterValue("h3", RuntimeHelpers.GetObjectValue(obj4));
                            document.SetParameterValue("h4", RuntimeHelpers.GetObjectValue(obj5));
                            document.SetParameterValue("TELEFON", RuntimeHelpers.GetObjectValue(this.dskorisnik.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                            if (item == null)
                            {
                                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                            }
                            item.Izvjestaj = document;
                            item.Show(item.Workspaces["main"]);
                        }
                        catch (System.Exception exception4)
                        {
                            throw exception4;
                            //Exception exception2 = exception4;
                            //Interaction.MsgBox("Disketa nije kreirana! " + exception2.Message, MsgBoxStyle.OkOnly, null);
                        }
                        finally
                        {
                            streamWriter = null;
                        }
                    }
                }
                catch (System.Exception exception5)
                {
                    throw exception5;
                    //Exception exception3 = exception5;
                    //Interaction.MsgBox(My.Resources.Resources.PORUKAZAGRESKU + " " + exception3.Message, MsgBoxStyle.OkOnly, null);
                }
            }
        }

        public string Dodaj_Praznine_Na_Kraj(string str, int potrebna)
        {
            string str2 = string.Empty;
            if (Strings.Len(str) < potrebna)
            {
                str2 = str + Strings.Space(potrebna - Strings.Len(str));
            }
            if (Strings.Len(str) == potrebna)
            {
                str2 = str;
            }
            if (Strings.Len(str) > potrebna)
            {
                str2 = Strings.Left(str, potrebna);
            }
            return str2;
        }

        private enum TipPolja
        {
            /// <summary>
            /// Sva BROJČANA POLJA (NUMERIC) popunjavaju se desno poravnato i s vodećim nulama ako je podatak kraći od duljine polja.
            /// Ako podatak nije poznat, popunjavaju se sve nule u duljini polja.
            /// Za unos IZNOSA rezervirano je 15 mjesta  cijeli broj 13 znakova + 2 decimalna mjesta (bez delimitera).
            /// </summary>
            /// <remarks></remarks>
            N_Numeric,

            /// <summary>
            /// TEKSTUALNA POLJA popunjavaju se lijevo poravnato i u nastavku ostavljaju praznine ("blank") do zadane duljine ako je podatak kraći od duljine polja.
            /// </summary> 
            /// <remarks></remarks>
            C_Alfanumeric
        }

        private string GenerirajVrijednost(object vrijednost, TipPolja tipPolja, int duljina)
        {
            // provjera NULL
            if (vrijednost == DBNull.Value || vrijednost == null)
            {
                vrijednost = string.Empty;
            }

            // mičemo razmake
            vrijednost = vrijednost.ToString().Trim();

            // kratimo vrijednost ukoliko je DULJA od predviđene/dozvoljene duljine
            if (vrijednost.ToString().Length > duljina)
            {
                vrijednost = vrijednost.ToString().Substring(0, duljina);
            }

            if (tipPolja == TipPolja.C_Alfanumeric)
            {
                // slova lijevo, spaces desno
                vrijednost = vrijednost.ToString().PadRight(duljina, ' ');
            }
            else if (tipPolja == TipPolja.N_Numeric)
            {
                // vrijednost desno, nule lijevo
                vrijednost = vrijednost.ToString().PadLeft(duljina, '0');
            }

            if (vrijednost.ToString().Length != duljina)
            {
                throw new Exception("GREŠKA (Datoteka zbrojnog naloga): duljina vrijednosti NE odgovara propisanoj duljini!");
            }

            return vrijednost.ToString();
        }

        public string Dodaj_Vodece_Praznine(string str, int potrebna)
        {
            string str2 = string.Empty;
            if (Strings.Len(str) < potrebna)
            {
                str2 = Strings.Space(potrebna - Strings.Len(str)) + str;
            }
            if (Strings.Len(str) == potrebna)
            {
                str2 = str;
            }
            return str2;
        }

        private static FileStream GetFileStream(string pathName)
        {
            return new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public static string GetSHA1Hash(string pathName)
        {
            string str3 = "";
            FileStream inputStream = null;
            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            try
            {
                inputStream = GetFileStream(pathName);
                byte[] buffer = provider.ComputeHash(inputStream);
                inputStream.Close();
                str3 = BitConverter.ToString(buffer).Replace("-", "");
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
            return str3;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RSVRSTEOBRACUNA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRSVRSTEOBRACUNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVRSVRSTEOBRACUNA");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RSVRSTEOBVEZNIKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRSVRSTEOBVEZNIKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVRSVRSTEOBVEZNIKA");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RSMA1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDENTIFIKATOROBRASCA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("REDNIBROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIMEIIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MBGOSIGURANIKA");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAGRADARADA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("B");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSOBRACUNANEPLACERSMB");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSOSNOVICEZADOPRINOSERSMB");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MIO1RSMB");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MIO2RSMB");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSISPLACENEPLACERSMB");
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("66586438-bb94-4fce-9f59-dc9003d2692b"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("4f0e7f4c-2844-487c-9d86-7b72e0ac126b"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("66586438-bb94-4fce-9f59-dc9003d2692b"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("6b0b8893-11bd-4a7c-98c2-fcfef42d1774"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("46156825-a4aa-4922-8d21-2cca4d618672"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("6b0b8893-11bd-4a7c-98c2-fcfef42d1774"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("923a1938-2fc8-4c0f-a4f7-e2e55ee1844d"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("b8feaf98-5370-4cd3-9c4d-6679c28a3006"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("923a1938-2fc8-4c0f-a4f7-e2e55ee1844d"), -1);
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.BROJSTRANICA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.sifraobracuna = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.brojosiguranika = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.lblNazivVrsteObracuna = new Infragistics.Win.Misc.UltraLabel();
            this.cbVrstaObracuna = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.RsvrsteobracunaDataSet1 = new Placa.RSVRSTEOBRACUNADataSet();
            this.godObracuna = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.mjesObracuna = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.rsmIdent = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.lblNazivVrsteObveznika = new Infragistics.Win.Misc.UltraLabel();
            this.cbVrstaObveznika = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.RsvrsteobveznikaDataSet1 = new Placa.RSVRSTEOBVEZNIKADataSet();
            this.adresa = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.nazivObveznik = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.mbObveznik = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.mbgObveznik = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.iznosisplaceneplace = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.mio2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.mio1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.iznososnovicezadoprinose = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.iznosobracunaneplace = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.godIsplate = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.mjesIsplate = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.RsmaDataSet1 = new Placa.RSMADataSet();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._RSMObrazacUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BROJSTRANICA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVrstaObracuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsvrsteobracunaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbVrstaObveznika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsvrsteobveznikaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsmaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.WindowDockingArea3.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.UltraLabel7);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel6);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel4);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.BROJSTRANICA);
            this.UltraGroupBox1.Controls.Add(this.sifraobracuna);
            this.UltraGroupBox1.Controls.Add(this.brojosiguranika);
            this.UltraGroupBox1.Controls.Add(this.lblNazivVrsteObracuna);
            this.UltraGroupBox1.Controls.Add(this.cbVrstaObracuna);
            this.UltraGroupBox1.Controls.Add(this.godObracuna);
            this.UltraGroupBox1.Controls.Add(this.mjesObracuna);
            this.UltraGroupBox1.Controls.Add(this.rsmIdent);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(680, 107);
            this.UltraGroupBox1.TabIndex = 7;
            this.UltraGroupBox1.UseAppStyling = false;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraLabel7
            // 
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel7.Appearance = appearance34;
            this.UltraLabel7.Location = new System.Drawing.Point(7, 85);
            this.UltraLabel7.Name = "UltraLabel7";
            this.UltraLabel7.Size = new System.Drawing.Size(244, 23);
            this.UltraLabel7.TabIndex = 14;
            this.UltraLabel7.Text = "Vrsta obračuna";
            this.UltraLabel7.UseAppStyling = false;
            // 
            // UltraLabel6
            // 
            appearance33.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel6.Appearance = appearance33;
            this.UltraLabel6.Location = new System.Drawing.Point(7, 33);
            this.UltraLabel6.Name = "UltraLabel6";
            this.UltraLabel6.Size = new System.Drawing.Size(273, 23);
            this.UltraLabel6.TabIndex = 13;
            this.UltraLabel6.Text = "Broj osiguranika za koje se podnosi obrazac RSm";
            this.UltraLabel6.UseAppStyling = false;
            // 
            // UltraLabel5
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel5.Appearance = appearance12;
            this.UltraLabel5.Location = new System.Drawing.Point(7, 58);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(244, 23);
            this.UltraLabel5.TabIndex = 12;
            this.UltraLabel5.Text = "Broj stranica B koje se prilažu stranici A";
            this.UltraLabel5.UseAppStyling = false;
            // 
            // UltraLabel4
            // 
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel4.Appearance = appearance32;
            this.UltraLabel4.Location = new System.Drawing.Point(505, 6);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(47, 23);
            this.UltraLabel4.TabIndex = 11;
            this.UltraLabel4.Text = "i godinu";
            this.UltraLabel4.UseAppStyling = false;
            // 
            // UltraLabel3
            // 
            appearance28.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel3.Appearance = appearance28;
            this.UltraLabel3.Location = new System.Drawing.Point(376, 6);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(96, 23);
            this.UltraLabel3.TabIndex = 10;
            this.UltraLabel3.Text = "Podaci za mjesec";
            this.UltraLabel3.UseAppStyling = false;
            // 
            // UltraLabel2
            // 
            appearance.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel2.Appearance = appearance;
            this.UltraLabel2.Location = new System.Drawing.Point(7, 6);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(59, 23);
            this.UltraLabel2.TabIndex = 9;
            this.UltraLabel2.Text = "Obračun";
            this.UltraLabel2.UseAppStyling = false;
            // 
            // UltraLabel1
            // 
            appearance19.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel1.Appearance = appearance19;
            this.UltraLabel1.Location = new System.Drawing.Point(193, 6);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(108, 23);
            this.UltraLabel1.TabIndex = 8;
            this.UltraLabel1.Text = "Identifikator obrasca";
            this.UltraLabel1.UseAppStyling = false;
            // 
            // BROJSTRANICA
            // 
            this.BROJSTRANICA.Location = new System.Drawing.Point(307, 54);
            this.BROJSTRANICA.Name = "BROJSTRANICA";
            this.BROJSTRANICA.PromptChar = ' ';
            this.BROJSTRANICA.Size = new System.Drawing.Size(60, 21);
            this.BROJSTRANICA.TabIndex = 7;
            this.BROJSTRANICA.UseAppStyling = false;
            // 
            // sifraobracuna
            // 
            this.sifraobracuna.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.sifraobracuna.Location = new System.Drawing.Point(90, 3);
            this.sifraobracuna.Name = "sifraobracuna";
            this.sifraobracuna.PromptChar = ' ';
            this.sifraobracuna.Size = new System.Drawing.Size(97, 20);
            this.sifraobracuna.TabIndex = 6;
            this.sifraobracuna.UseAppStyling = false;
            // 
            // brojosiguranika
            // 
            this.brojosiguranika.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.brojosiguranika.InputMask = "#####";
            this.brojosiguranika.Location = new System.Drawing.Point(307, 29);
            this.brojosiguranika.Name = "brojosiguranika";
            this.brojosiguranika.PromptChar = ' ';
            this.brojosiguranika.Size = new System.Drawing.Size(39, 20);
            this.brojosiguranika.TabIndex = 5;
            this.brojosiguranika.UseAppStyling = false;
            // 
            // lblNazivVrsteObracuna
            // 
            appearance35.BackColor = System.Drawing.Color.Transparent;
            this.lblNazivVrsteObracuna.Appearance = appearance35;
            this.lblNazivVrsteObracuna.AutoSize = true;
            this.lblNazivVrsteObracuna.Location = new System.Drawing.Point(390, 85);
            this.lblNazivVrsteObracuna.Name = "lblNazivVrsteObracuna";
            this.lblNazivVrsteObracuna.Size = new System.Drawing.Size(62, 14);
            this.lblNazivVrsteObracuna.TabIndex = 4;
            this.lblNazivVrsteObracuna.Text = "UltraLabel1";
            this.lblNazivVrsteObracuna.UseAppStyling = false;
            // 
            // cbVrstaObracuna
            // 
            this.cbVrstaObracuna.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbVrstaObracuna.DataMember = "RSVRSTEOBRACUNA";
            this.cbVrstaObracuna.DataSource = this.RsvrsteobracunaDataSet1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.cbVrstaObracuna.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbVrstaObracuna.DisplayMember = "IDRSVRSTEOBRACUNA";
            this.cbVrstaObracuna.Location = new System.Drawing.Point(307, 81);
            this.cbVrstaObracuna.Name = "cbVrstaObracuna";
            this.cbVrstaObracuna.Size = new System.Drawing.Size(77, 22);
            this.cbVrstaObracuna.TabIndex = 3;
            this.cbVrstaObracuna.Text = "UltraCombo1";
            this.cbVrstaObracuna.UseAppStyling = false;
            this.cbVrstaObracuna.ValueMember = "IDRSVRSTEOBRACUNA";
            this.cbVrstaObracuna.Validating += new System.ComponentModel.CancelEventHandler(this.cbVrstaObracuna_Validating);
            // 
            // RsvrsteobracunaDataSet1
            // 
            this.RsvrsteobracunaDataSet1.DataSetName = "RSVRSTEOBRACUNADataSet";
            // 
            // godObracuna
            // 
            this.godObracuna.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.godObracuna.InputMask = "####";
            this.godObracuna.Location = new System.Drawing.Point(558, 3);
            this.godObracuna.Name = "godObracuna";
            this.godObracuna.PromptChar = ' ';
            this.godObracuna.Size = new System.Drawing.Size(60, 20);
            this.godObracuna.TabIndex = 2;
            this.godObracuna.UseAppStyling = false;
            this.godObracuna.ValueChanged += new System.EventHandler(this.godObracuna_ValueChanged);
            this.godObracuna.Validating += new System.ComponentModel.CancelEventHandler(this.godObracuna_Validating);
            // 
            // mjesObracuna
            // 
            this.mjesObracuna.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mjesObracuna.InputMask = "##";
            this.mjesObracuna.Location = new System.Drawing.Point(472, 4);
            this.mjesObracuna.Name = "mjesObracuna";
            this.mjesObracuna.PromptChar = ' ';
            this.mjesObracuna.Size = new System.Drawing.Size(31, 20);
            this.mjesObracuna.TabIndex = 1;
            this.mjesObracuna.UseAppStyling = false;
            this.mjesObracuna.Validating += new System.ComponentModel.CancelEventHandler(this.mjesObracuna_Validating);
            this.mjesObracuna.Validated += new System.EventHandler(this.mjesObracuna_Validated);
            // 
            // rsmIdent
            // 
            this.rsmIdent.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.rsmIdent.InputMask = "####";
            this.rsmIdent.Location = new System.Drawing.Point(307, 3);
            this.rsmIdent.Name = "rsmIdent";
            this.rsmIdent.PromptChar = ' ';
            this.rsmIdent.Size = new System.Drawing.Size(60, 20);
            this.rsmIdent.TabIndex = 0;
            this.rsmIdent.UseAppStyling = false;
            // 
            // UltraGroupBox2
            // 
            this.UltraGroupBox2.Controls.Add(this.UltraLabel12);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel11);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel10);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel9);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel8);
            this.UltraGroupBox2.Controls.Add(this.lblNazivVrsteObveznika);
            this.UltraGroupBox2.Controls.Add(this.cbVrstaObveznika);
            this.UltraGroupBox2.Controls.Add(this.adresa);
            this.UltraGroupBox2.Controls.Add(this.nazivObveznik);
            this.UltraGroupBox2.Controls.Add(this.mbObveznik);
            this.UltraGroupBox2.Controls.Add(this.mbgObveznik);
            this.UltraGroupBox2.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(680, 133);
            this.UltraGroupBox2.TabIndex = 9;
            this.UltraGroupBox2.UseAppStyling = false;
            this.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraLabel12
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel12.Appearance = appearance5;
            this.UltraLabel12.Location = new System.Drawing.Point(7, 111);
            this.UltraLabel12.Name = "UltraLabel12";
            this.UltraLabel12.Size = new System.Drawing.Size(126, 23);
            this.UltraLabel12.TabIndex = 17;
            this.UltraLabel12.Text = "5. Vrsta obveznika";
            this.UltraLabel12.UseAppStyling = false;
            // 
            // UltraLabel11
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel11.Appearance = appearance4;
            this.UltraLabel11.Location = new System.Drawing.Point(7, 85);
            this.UltraLabel11.Name = "UltraLabel11";
            this.UltraLabel11.Size = new System.Drawing.Size(126, 23);
            this.UltraLabel11.TabIndex = 16;
            this.UltraLabel11.Text = "4. Adresa obveznika";
            this.UltraLabel11.UseAppStyling = false;
            // 
            // UltraLabel10
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel10.Appearance = appearance3;
            this.UltraLabel10.Location = new System.Drawing.Point(7, 60);
            this.UltraLabel10.Name = "UltraLabel10";
            this.UltraLabel10.Size = new System.Drawing.Size(126, 23);
            this.UltraLabel10.TabIndex = 15;
            this.UltraLabel10.Text = "3. Naziv obveznika";
            this.UltraLabel10.UseAppStyling = false;
            // 
            // UltraLabel9
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel9.Appearance = appearance2;
            this.UltraLabel9.Location = new System.Drawing.Point(7, 33);
            this.UltraLabel9.Name = "UltraLabel9";
            this.UltraLabel9.Size = new System.Drawing.Size(126, 23);
            this.UltraLabel9.TabIndex = 14;
            this.UltraLabel9.Text = "2. MBG obveznika";
            this.UltraLabel9.UseAppStyling = false;
            // 
            // UltraLabel8
            // 
            appearance36.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel8.Appearance = appearance36;
            this.UltraLabel8.Location = new System.Drawing.Point(7, 7);
            this.UltraLabel8.Name = "UltraLabel8";
            this.UltraLabel8.Size = new System.Drawing.Size(155, 23);
            this.UltraLabel8.TabIndex = 13;
            this.UltraLabel8.Text = "1. MB obveznika";
            this.UltraLabel8.UseAppStyling = false;
            // 
            // lblNazivVrsteObveznika
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.lblNazivVrsteObveznika.Appearance = appearance13;
            this.lblNazivVrsteObveznika.AutoSize = true;
            this.lblNazivVrsteObveznika.Location = new System.Drawing.Point(289, 112);
            this.lblNazivVrsteObveznika.Name = "lblNazivVrsteObveznika";
            this.lblNazivVrsteObveznika.Size = new System.Drawing.Size(62, 14);
            this.lblNazivVrsteObveznika.TabIndex = 6;
            this.lblNazivVrsteObveznika.Text = "UltraLabel1";
            this.lblNazivVrsteObveznika.UseAppStyling = false;
            // 
            // cbVrstaObveznika
            // 
            this.cbVrstaObveznika.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbVrstaObveznika.DataMember = "RSVRSTEOBVEZNIKA";
            this.cbVrstaObveznika.DataSource = this.RsvrsteobveznikaDataSet1;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4});
            this.cbVrstaObveznika.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cbVrstaObveznika.DisplayMember = "IDRSVRSTEOBVEZNIKA";
            this.cbVrstaObveznika.Location = new System.Drawing.Point(168, 108);
            this.cbVrstaObveznika.Name = "cbVrstaObveznika";
            this.cbVrstaObveznika.Size = new System.Drawing.Size(115, 22);
            this.cbVrstaObveznika.TabIndex = 5;
            this.cbVrstaObveznika.Text = "UltraCombo1";
            this.cbVrstaObveznika.UseAppStyling = false;
            this.cbVrstaObveznika.ValueMember = null;
            this.cbVrstaObveznika.Validating += new System.ComponentModel.CancelEventHandler(this.cbVrstaObveznika_Validating);
            // 
            // RsvrsteobveznikaDataSet1
            // 
            this.RsvrsteobveznikaDataSet1.DataSetName = "RSVRSTEOBVEZNIKADataSet";
            // 
            // adresa
            // 
            this.adresa.AutoSize = false;
            this.adresa.Location = new System.Drawing.Point(168, 82);
            this.adresa.Name = "adresa";
            this.adresa.PromptChar = ' ';
            this.adresa.Size = new System.Drawing.Size(527, 20);
            this.adresa.TabIndex = 4;
            this.adresa.UseAppStyling = false;
            // 
            // nazivObveznik
            // 
            this.nazivObveznik.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.nazivObveznik.Location = new System.Drawing.Point(168, 56);
            this.nazivObveznik.Name = "nazivObveznik";
            this.nazivObveznik.PromptChar = ' ';
            this.nazivObveznik.Size = new System.Drawing.Size(527, 20);
            this.nazivObveznik.TabIndex = 3;
            this.nazivObveznik.UseAppStyling = false;
            // 
            // mbObveznik
            // 
            this.mbObveznik.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mbObveznik.Location = new System.Drawing.Point(168, 4);
            this.mbObveznik.Name = "mbObveznik";
            this.mbObveznik.PromptChar = ' ';
            this.mbObveznik.Size = new System.Drawing.Size(335, 20);
            this.mbObveznik.TabIndex = 2;
            this.mbObveznik.UseAppStyling = false;
            // 
            // mbgObveznik
            // 
            this.mbgObveznik.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mbgObveznik.InputMask = "#############";
            this.mbgObveznik.Location = new System.Drawing.Point(168, 30);
            this.mbgObveznik.Name = "mbgObveznik";
            this.mbgObveznik.PromptChar = ' ';
            this.mbgObveznik.Size = new System.Drawing.Size(335, 20);
            this.mbgObveznik.TabIndex = 1;
            this.mbgObveznik.UseAppStyling = false;
            // 
            // UltraGroupBox3
            // 
            this.UltraGroupBox3.Controls.Add(this.UltraLabel18);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel17);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel16);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel15);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel14);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel13);
            this.UltraGroupBox3.Controls.Add(this.iznosisplaceneplace);
            this.UltraGroupBox3.Controls.Add(this.mio2);
            this.UltraGroupBox3.Controls.Add(this.mio1);
            this.UltraGroupBox3.Controls.Add(this.iznososnovicezadoprinose);
            this.UltraGroupBox3.Controls.Add(this.iznosobracunaneplace);
            this.UltraGroupBox3.Controls.Add(this.godIsplate);
            this.UltraGroupBox3.Controls.Add(this.mjesIsplate);
            this.UltraGroupBox3.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(680, 166);
            this.UltraGroupBox3.TabIndex = 10;
            this.UltraGroupBox3.UseAppStyling = false;
            this.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraLabel18
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel18.Appearance = appearance11;
            this.UltraLabel18.Location = new System.Drawing.Point(9, 139);
            this.UltraLabel18.Name = "UltraLabel18";
            this.UltraLabel18.Size = new System.Drawing.Size(295, 23);
            this.UltraLabel18.TabIndex = 20;
            this.UltraLabel18.Text = "6. Godina i mjesec isplate plaće/naknade/drugog dohotka";
            this.UltraLabel18.UseAppStyling = false;
            // 
            // UltraLabel17
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel17.Appearance = appearance10;
            this.UltraLabel17.Location = new System.Drawing.Point(9, 113);
            this.UltraLabel17.Name = "UltraLabel17";
            this.UltraLabel17.Size = new System.Drawing.Size(263, 23);
            this.UltraLabel17.TabIndex = 19;
            this.UltraLabel17.Text = "5. Iznos isplaćene plaće/naknade";
            this.UltraLabel17.UseAppStyling = false;
            // 
            // UltraLabel16
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel16.Appearance = appearance9;
            this.UltraLabel16.Location = new System.Drawing.Point(9, 87);
            this.UltraLabel16.Name = "UltraLabel16";
            this.UltraLabel16.Size = new System.Drawing.Size(259, 23);
            this.UltraLabel16.TabIndex = 18;
            this.UltraLabel16.Text = "4. Iznos obračunanog doprinosa za II. stup";
            this.UltraLabel16.UseAppStyling = false;
            // 
            // UltraLabel15
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel15.Appearance = appearance8;
            this.UltraLabel15.Location = new System.Drawing.Point(9, 61);
            this.UltraLabel15.Name = "UltraLabel15";
            this.UltraLabel15.Size = new System.Drawing.Size(259, 23);
            this.UltraLabel15.TabIndex = 17;
            this.UltraLabel15.Text = "3. Iznos obračunanog doprinosa za I. stup";
            this.UltraLabel15.UseAppStyling = false;
            // 
            // UltraLabel14
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel14.Appearance = appearance7;
            this.UltraLabel14.Location = new System.Drawing.Point(9, 35);
            this.UltraLabel14.Name = "UltraLabel14";
            this.UltraLabel14.Size = new System.Drawing.Size(213, 23);
            this.UltraLabel14.TabIndex = 16;
            this.UltraLabel14.Text = "2. Iznos osnovice za obračun doprinosa";
            this.UltraLabel14.UseAppStyling = false;
            // 
            // UltraLabel13
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel13.Appearance = appearance6;
            this.UltraLabel13.Location = new System.Drawing.Point(9, 9);
            this.UltraLabel13.Name = "UltraLabel13";
            this.UltraLabel13.Size = new System.Drawing.Size(188, 23);
            this.UltraLabel13.TabIndex = 15;
            this.UltraLabel13.Text = "1. Iznos obračunane plaće/naknade";
            this.UltraLabel13.UseAppStyling = false;
            // 
            // iznosisplaceneplace
            // 
            appearance14.TextHAlignAsString = "Right";
            this.iznosisplaceneplace.Appearance = appearance14;
            this.iznosisplaceneplace.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.iznosisplaceneplace.InputMask = "{LOC} n,nnn,nnn.nn";
            this.iznosisplaceneplace.Location = new System.Drawing.Point(310, 110);
            this.iznosisplaceneplace.Name = "iznosisplaceneplace";
            this.iznosisplaceneplace.PromptChar = ' ';
            this.iznosisplaceneplace.Size = new System.Drawing.Size(100, 20);
            this.iznosisplaceneplace.TabIndex = 14;
            this.iznosisplaceneplace.Text = " ";
            this.iznosisplaceneplace.UseAppStyling = false;
            // 
            // mio2
            // 
            appearance17.TextHAlignAsString = "Right";
            this.mio2.Appearance = appearance17;
            this.mio2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mio2.InputMask = "{LOC} n,nnn,nnn.nn";
            this.mio2.Location = new System.Drawing.Point(310, 84);
            this.mio2.Name = "mio2";
            this.mio2.PromptChar = ' ';
            this.mio2.Size = new System.Drawing.Size(100, 20);
            this.mio2.TabIndex = 13;
            this.mio2.Text = " ";
            this.mio2.UseAppStyling = false;
            // 
            // mio1
            // 
            appearance16.TextHAlignAsString = "Right";
            this.mio1.Appearance = appearance16;
            this.mio1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mio1.InputMask = "{LOC} n,nnn,nnn.nn";
            this.mio1.Location = new System.Drawing.Point(310, 58);
            this.mio1.Name = "mio1";
            this.mio1.PromptChar = ' ';
            this.mio1.Size = new System.Drawing.Size(100, 20);
            this.mio1.TabIndex = 12;
            this.mio1.Text = " ";
            this.mio1.UseAppStyling = false;
            // 
            // iznososnovicezadoprinose
            // 
            appearance15.TextHAlignAsString = "Right";
            this.iznososnovicezadoprinose.Appearance = appearance15;
            this.iznososnovicezadoprinose.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.iznososnovicezadoprinose.InputMask = "{LOC} n,nnn,nnn.nn";
            this.iznososnovicezadoprinose.Location = new System.Drawing.Point(310, 32);
            this.iznososnovicezadoprinose.Name = "iznososnovicezadoprinose";
            this.iznososnovicezadoprinose.PromptChar = ' ';
            this.iznososnovicezadoprinose.Size = new System.Drawing.Size(100, 20);
            this.iznososnovicezadoprinose.TabIndex = 11;
            this.iznososnovicezadoprinose.Text = " ";
            this.iznososnovicezadoprinose.UseAppStyling = false;
            // 
            // iznosobracunaneplace
            // 
            appearance18.TextHAlignAsString = "Right";
            this.iznosobracunaneplace.Appearance = appearance18;
            this.iznosobracunaneplace.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.iznosobracunaneplace.InputMask = "{LOC} n,nnn,nnn.nn";
            this.iznosobracunaneplace.Location = new System.Drawing.Point(310, 6);
            this.iznosobracunaneplace.Name = "iznosobracunaneplace";
            this.iznosobracunaneplace.PromptChar = ' ';
            this.iznosobracunaneplace.Size = new System.Drawing.Size(100, 20);
            this.iznosobracunaneplace.TabIndex = 10;
            this.iznosobracunaneplace.Text = " ";
            this.iznosobracunaneplace.UseAppStyling = false;
            // 
            // godIsplate
            // 
            this.godIsplate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.godIsplate.InputMask = "####";
            this.godIsplate.Location = new System.Drawing.Point(310, 136);
            this.godIsplate.Name = "godIsplate";
            this.godIsplate.PromptChar = ' ';
            this.godIsplate.Size = new System.Drawing.Size(39, 20);
            this.godIsplate.TabIndex = 3;
            this.godIsplate.UseAppStyling = false;
            // 
            // mjesIsplate
            // 
            this.mjesIsplate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mjesIsplate.InputMask = "##";
            this.mjesIsplate.Location = new System.Drawing.Point(365, 136);
            this.mjesIsplate.Name = "mjesIsplate";
            this.mjesIsplate.PromptChar = ' ';
            this.mjesIsplate.Size = new System.Drawing.Size(31, 20);
            this.mjesIsplate.TabIndex = 2;
            this.mjesIsplate.UseAppStyling = false;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "RSMA1";
            this.UltraGrid1.DataSource = this.RsmaDataSet1;
            appearance20.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance20;
            this.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 85;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Caption = "Rbr";
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 52;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "Prezime i ime";
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.Width = 81;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance1.TextHAlignAsString = "Left";
            ultraGridColumn9.CellAppearance = appearance1;
            ultraGridColumn9.Header.Caption = "MBG Osiguranika";
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn9.Width = 96;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.Caption = "Šifra grada";
            ultraGridColumn10.Header.VisiblePosition = 5;
            ultraGridColumn10.Width = 31;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridColumn11.Width = 26;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.VisiblePosition = 7;
            ultraGridColumn12.Width = 18;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Caption = "Od";
            ultraGridColumn13.Header.VisiblePosition = 8;
            ultraGridColumn13.Width = 25;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.Caption = "Do";
            ultraGridColumn14.Header.VisiblePosition = 9;
            ultraGridColumn14.Width = 24;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance25.TextHAlignAsString = "Right";
            ultraGridColumn15.CellAppearance = appearance25;
            ultraGridColumn15.Header.Caption = "Obračunana plaća";
            ultraGridColumn15.Header.VisiblePosition = 10;
            ultraGridColumn15.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn15.Width = 70;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance26.TextHAlignAsString = "Right";
            ultraGridColumn16.CellAppearance = appearance26;
            ultraGridColumn16.Header.Caption = "Osnovica za dop.";
            ultraGridColumn16.Header.VisiblePosition = 11;
            ultraGridColumn16.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn16.Width = 63;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance27.TextHAlignAsString = "Right";
            ultraGridColumn17.CellAppearance = appearance27;
            ultraGridColumn17.Header.Caption = "MIO1";
            ultraGridColumn17.Header.VisiblePosition = 12;
            ultraGridColumn17.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn17.Width = 53;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance29.TextHAlignAsString = "Right";
            ultraGridColumn18.CellAppearance = appearance29;
            ultraGridColumn18.Header.Caption = "MIO 2";
            ultraGridColumn18.Header.VisiblePosition = 13;
            ultraGridColumn18.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn18.Width = 53;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance30.TextHAlignAsString = "Right";
            ultraGridColumn19.CellAppearance = appearance30;
            ultraGridColumn19.Header.Caption = "Isplaćena plaća";
            ultraGridColumn19.Header.VisiblePosition = 14;
            ultraGridColumn19.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn19.Width = 86;
            ultraGridBand3.Columns.AddRange(new object[] {
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
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19});
            ultraGridBand3.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance21;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance22.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance22;
            appearance23.BorderColor = System.Drawing.Color.LightGray;
            appearance23.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance23;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance24.BorderColor = System.Drawing.Color.Black;
            appearance24.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance24;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Location = new System.Drawing.Point(0, 475);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(680, 173);
            this.UltraGrid1.TabIndex = 13;
            this.UltraGrid1.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            // 
            // RsmaDataSet1
            // 
            this.RsmaDataSet1.DataSetName = "RSMADataSet";
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("6b0b8893-11bd-4a7c-98c2-fcfef42d1774");
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(52, 50, 200, 110);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "I. OSNOVNI PODACI";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Settings.AllowMinimize = Infragistics.Win.DefaultableBoolean.True;
            dockAreaPane1.Size = new System.Drawing.Size(680, 125);
            dockAreaPane2.DockedBefore = new System.Guid("923a1938-2fc8-4c0f-a4f7-e2e55ee1844d");
            dockableControlPane2.Control = this.UltraGroupBox2;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(3, 133, 680, 189);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "II. PODACI O OBVEZNIKU PODNOŠENJA PODATAKA";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(680, 151);
            dockableControlPane3.Control = this.UltraGroupBox3;
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(3, 328, 680, 189);
            dockableControlPane3.Size = new System.Drawing.Size(100, 100);
            dockableControlPane3.Text = "III. KONTROLNI PODACI PO OBVEZNIKU PODNOŠENJA PODATAKA";
            dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane3});
            dockAreaPane3.Size = new System.Drawing.Size(680, 184);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _RSMObrazacUnpinnedTabAreaLeft
            // 
            this._RSMObrazacUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._RSMObrazacUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._RSMObrazacUnpinnedTabAreaLeft.Name = "_RSMObrazacUnpinnedTabAreaLeft";
            this._RSMObrazacUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 648);
            this._RSMObrazacUnpinnedTabAreaLeft.TabIndex = 2;
            // 
            // _RSMObrazacUnpinnedTabAreaRight
            // 
            this._RSMObrazacUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._RSMObrazacUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaRight.Location = new System.Drawing.Point(680, 0);
            this._RSMObrazacUnpinnedTabAreaRight.Name = "_RSMObrazacUnpinnedTabAreaRight";
            this._RSMObrazacUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 648);
            this._RSMObrazacUnpinnedTabAreaRight.TabIndex = 3;
            // 
            // _RSMObrazacUnpinnedTabAreaTop
            // 
            this._RSMObrazacUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._RSMObrazacUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._RSMObrazacUnpinnedTabAreaTop.Name = "_RSMObrazacUnpinnedTabAreaTop";
            this._RSMObrazacUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaTop.Size = new System.Drawing.Size(680, 0);
            this._RSMObrazacUnpinnedTabAreaTop.TabIndex = 4;
            // 
            // _RSMObrazacUnpinnedTabAreaBottom
            // 
            this._RSMObrazacUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._RSMObrazacUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 648);
            this._RSMObrazacUnpinnedTabAreaBottom.Name = "_RSMObrazacUnpinnedTabAreaBottom";
            this._RSMObrazacUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaBottom.Size = new System.Drawing.Size(680, 0);
            this._RSMObrazacUnpinnedTabAreaBottom.TabIndex = 5;
            // 
            // _RSMObrazacAutoHideControl
            // 
            this._RSMObrazacAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._RSMObrazacAutoHideControl.Name = "_RSMObrazacAutoHideControl";
            this._RSMObrazacAutoHideControl.Owner = this.UltraDockManager1;
            this._RSMObrazacAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._RSMObrazacAutoHideControl.TabIndex = 6;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(680, 130);
            this.WindowDockingArea1.TabIndex = 8;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(680, 125);
            this.DockableWindow1.TabIndex = 14;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 130);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(680, 156);
            this.WindowDockingArea2.TabIndex = 11;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.UltraGroupBox2);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(680, 151);
            this.DockableWindow2.TabIndex = 15;
            // 
            // WindowDockingArea3
            // 
            this.WindowDockingArea3.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea3.Location = new System.Drawing.Point(0, 286);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(680, 189);
            this.WindowDockingArea3.TabIndex = 12;
            // 
            // DockableWindow3
            // 
            this.DockableWindow3.Controls.Add(this.UltraGroupBox3);
            this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(680, 184);
            this.DockableWindow3.TabIndex = 16;
            // 
            // RSMObrazac
            // 
            this.Controls.Add(this._RSMObrazacAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaTop);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaBottom);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaLeft);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaRight);
            this.Name = "RSMObrazac";
            this.Size = new System.Drawing.Size(680, 648);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BROJSTRANICA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVrstaObracuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsvrsteobracunaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            this.UltraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbVrstaObveznika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsvrsteobveznikaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            this.UltraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsmaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.WindowDockingArea3.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void Ispis_Stranice_A_RSM_2010()
        {
            if (this.RsmaDataSet1.RSMA.Rows.Count == 0)
            {
                Interaction.MsgBox("Potrebno je otvoriti obračun!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - RSm stranica A",
                    Description = "Pregled izvještaja - RSm stranica A",
                    Icon = ImageResourcesNew.mbs
                };
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rsma2010.rpt");
                document.SetDataSource(this.RsmaDataSet1);
                if (Operators.ConditionalCompareObjectEqual(this.RsmaDataSet1.RSMA.Rows[0]["MBGOBVEZNIKA"], "0000000000000", false))
                {
                    document.ReportDefinition.Sections["Section5"].ReportObjects["MBGOBVEZNIKA1"].ObjectFormat.EnableSuppress = true;
                }
                if (Operators.ConditionalCompareObjectEqual(this.RsmaDataSet1.RSMA.Rows[0]["MBOBVEZNIKA"], "00000000", false))
                {
                    document.ReportDefinition.Sections["Section5"].ReportObjects["MBOBVEZNIKA1"].ObjectFormat.EnableSuppress = true;
                }
                document.SetParameterValue("brojstranicab", Conversions.ToInteger(Operators.AddObject(this.RsmaDataSet1.RSMA1.Rows.Count / 12, Interaction.IIf((this.RsmaDataSet1.RSMA1.Rows.Count % 12) > 0, 1, 0))).ToString("000;000;000"));
                document.SetParameterValue("h1", "");
                document.SetParameterValue("h2", "");
                document.SetParameterValue("h3", "");
                document.SetParameterValue("h4", "");
                document.SetParameterValue("TELEFON", RuntimeHelpers.GetObjectValue(this.dskorisnik.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"]);
            }
        }

        public void Ispis_Stranice_B_RSM_2010()
        {
            if (this.RsmaDataSet1.RSMA1.Rows.Count == 0)
            {
                Interaction.MsgBox("Potrebno je otvoriti obračun!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                int num = Conversions.ToInteger(Operators.AddObject(this.RsmaDataSet1.RSMA1.Rows.Count / 12, Interaction.IIf((this.RsmaDataSet1.RSMA1.Rows.Count % 12) > 0, 1, 0)));
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - RSm stranica B",
                    Description = "Pregled izvještaja - RSm stranica B",
                    Icon = ImageResourcesNew.mbs
                };
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rsmb2010.rpt");
                document.SetDataSource(this.RsmaDataSet1);
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"], info);
            }
        }

        public void Kreiraj_Novi_RSm_Obrazac(string strIdentifikator)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            string str3 = string.Empty;
            IEnumerator enumerator = null;
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["MBGOsiguranika"].Header.Caption = "OIB";
            this.UltraLabel8.Text = "Identifikacijski broj obveznika";
            sp_RSOBRAZACDataSet dataSet = new sp_RSOBRAZACDataSet();
            sp_RSOBRAZACDataAdapter adapter = new sp_RSOBRAZACDataAdapter();
            try
            {
                if (!this.dd)
                {
                    adapter.Fill(dataSet, Conversions.ToString(this.sifraobracuna.Value), 0);
                }
                else
                {
                    adapter.Fill(dataSet, Conversions.ToString(this.sifraobracuna.Value), 1);
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }

            try
            {
                this.Podaci_obracun(Conversions.ToString(this.sifraobracuna.Value), ref str5, ref str2, ref str4, ref str);
                DataRow row2 = this.RsmaDataSet1.RSMA.NewRow();
                row2["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.sifraobracuna.Value);
                row2["mbobveznika"] = Strings.Trim(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KORISNIKOIB"]));
                row2["mbgobveznika"] = "";
                if (strIdentifikator == null)
                {
                    frmIdentifikator identifikator = new frmIdentifikator
                    {
                        rsmIdent = { MaxLength = 4 }
                    };
                    identifikator.rsmIdent.SelectAll();
                    identifikator.rsmIdent.Text = this.Vracaj_Zadnji_Broj_RSma(Conversions.ToString(this.sifraobracuna.Value), true);
                    identifikator.Text = "Unesite identifikator RSM obrasca ili pritisnite ENTER za postojeći identifikator";
                    identifikator.ShowDialog();

                    if (identifikator.UneseniIdentifikator == null)
                        throw new NullReferenceException();

                    str3 = Conversions.ToString(identifikator.UneseniIdentifikator);

                    row2["identifikatorobrasca"] = str3;
                }
                else
                {
                    row2["identifikatorobrasca"] = strIdentifikator;
                }
                if (this.dd)
                {
                    row2["IDRSVRSTEOBVEZNIKA"] = "17";
                    row2["IDRSVRSTEOBRACUNA"] = "03";
                }
                else
                {
                    row2["IDRSVRSTEOBVEZNIKA"] = "01";
                    row2["IDRSVRSTEOBRACUNA"] = "01";
                }
                row2["nazivobveznika"] = RuntimeHelpers.GetObjectValue(this.dskorisnik.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                row2["adresa"] = Strings.Trim(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KORISNIK1ADRESA"])) + "," + Strings.Trim(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                row2["mjesecobracunarsm"] = str5;
                row2["godinaobracunarsm"] = str2;
                row2["brojosiguranika"] = "";
                row2["mjesecisplatersm"] = str4;
                row2["godinaisplatersm"] = str;
                this.RsmaDataSet1.RSMA.Rows.Add(row2);
                int num2 = 0;
                int left = -1;
                int num = 1;
                try
                {
                    enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        if (Operators.ConditionalCompareObjectNotEqual(left, current["idradnik"], false))
                        {
                            num2++;
                        }
                        DataRow row = this.RsmaDataSet1.RSMA1.NewRow();
                        row["rednibroj"] = num2.ToString("00000;00000;00000");
                        row["id"] = num;
                        if (strIdentifikator == null)
                        {
                            row["identifikatorobrasca"] = str3;
                        }
                        else
                        {
                            row["identifikatorobrasca"] = strIdentifikator;
                        }
                        row["PREZIMEIIME"] = RuntimeHelpers.GetObjectValue(current["prezimeiime"]);
                        row["mbgosiguranika"] = this.Dodaj_Vodece_Praznine(Conversions.ToString(current["OIB"]), 13);
                        row["sifragradarada"] = this.Dodaj_Vodece_Praznine(Conversions.ToString(current["sifragradarada"]), 4);
                        row["oo"] = Strings.Format("{0:00}", Conversions.ToString(current["oo"]));
                        row["b"] = Strings.Format("{0:0}", Conversions.ToString(current["b"]));
                        row["od"] = Conversions.ToInteger(current["od"]).ToString("00;00;00");
                        row["doo"] = Conversions.ToInteger(current["doo"]).ToString("00;00;00");
                        row["iznosobracunaneplacersmb"] = RuntimeHelpers.GetObjectValue(current["iznosobracunaneplacersmb"]);
                        row["IZNOSOSNOVICEZADOPRINOSERSMB"] = RuntimeHelpers.GetObjectValue(current["IZNOSOSNOVICEZADOPRINOSERSMB"]);
                        row["mio1rsmb"] = RuntimeHelpers.GetObjectValue(current["mio1rsmb"]);
                        row["mio2rsmb"] = RuntimeHelpers.GetObjectValue(current["mio2rsmb"]);
                        row["IZNOSISPLACENEPLACERSMB"] = RuntimeHelpers.GetObjectValue(current["IZNOSISPLACENEPLACERSMB"]);
                        this.RsmaDataSet1.RSMA1.Rows.Add(row);
                        left = Conversions.ToInteger(current["idradnik"]);
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
                this.RsmaDataSet1.RSMA.Rows[0]["brojosiguranika"] = num2.ToString("00000;00000;00000");
                this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.cbVrstaObveznika.SelectedRow.Cells["IDRSVRSTEOBVEZNIKA"].Value);
                this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.cbVrstaObracuna.SelectedRow.Cells["IDRSVRSTEOBRACUNA"].Value);
                this.BROJSTRANICA.Value = Operators.AddObject(this.RsmaDataSet1.RSMA1.Rows.Count / 12, Interaction.IIf((this.RsmaDataSet1.RSMA1.Rows.Count % 12) > 0, 1, 0));
                this.BindingContext[this.RsmaDataSet1.RSMA1].EndCurrentEdit();
                if (Operators.ConditionalCompareObjectEqual(this.iznosobracunaneplace.Value, 0, false))
                {
                    this.RsmaDataSet1.RSMA.Rows[0]["GODINAISPLATERSM"] = "0000";
                    this.RsmaDataSet1.RSMA.Rows[0]["MJESECISPLATERSM"] = "00";
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("Conversion from type 'DBNull' to type"))
                {
                    MessageBox.Show("Greška u kreiranju novog R-Sm obrasca, zbog nepostojanja obaveznih podataka!", "Greška");
                }
                else
                {
                    throw exception;
                }
            }
        }

        public void Kreiraj_Novi_RSm_Obrazac_Za_Ucenike(string strIdentifikator, string IDOPCINE)
        {
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["MBGOsiguranika"].Header.Caption = "OIB";
            this.UltraLabel8.Text = "Identifikacijski broj obveznika";
            sp_RSOBRAZACDataSet dataSet = new sp_RSOBRAZACDataSet();
            new sp_RSOBRAZACDataAdapter().Fill(dataSet, "sifraobracuna.Value", 2);
            if (dataSet.sp_RSOBRAZAC.Rows.Count == 0)
            {
                Interaction.MsgBox("Ne postoje upisani učenici/studenti za učeničku praksu", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                try
                {
                    string str = string.Empty;
                    IEnumerator enumerator = null;
                    string str4 = "  ";
                    string str3 = "    ";
                    DataRow row3 = this.RsmaDataSet1.RSMA.NewRow();

                    // ----------------------------------------------------------------------------------------
                    // Staro hardkodiranje
                    // ----------------------------------------------------------------------------------------
                    string mjesecObracuna = "01";
                    string godinaObracuna = mipsed.application.framework.Application.ActiveYear.ToString();

                    // ----------------------------------------------------------------------------------------
                    // FIX - MANTIS #12
                    // ----------------------------------------------------------------------------------------

                    /*
                    string IDOBRACUN = this.sifraobracuna.Value.ToString();

                    Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();
                    object mjesecObracuna = db.ExecuteScalar("SELECT mjesecoBRACUNArsm FROM dbo.RSMA WHERE IDOBRACUN = '" + IDOBRACUN + "'");
                    object godinaObracuna = db.ExecuteScalar("SELECT godinaobracunarsm FROM dbo.RSMA WHERE IDOBRACUN = '" + IDOBRACUN + "'");
                    */

                    // ----------------------------------------------------------------------------------------

                    row3["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.sifraobracuna.Value);
                    row3["mbobveznika"] = Strings.Trim(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KORISNIKOIB"]));
                    row3["mbgobveznika"] = "";
                    if (strIdentifikator == null)
                    {
                        frmIdentifikator identifikator = new frmIdentifikator
                        {
                            rsmIdent = { MaxLength = 4 }
                        };
                        identifikator.rsmIdent.SelectAll();
                        identifikator.rsmIdent.Text = this.Vracaj_Zadnji_Broj_RSma(Conversions.ToString(this.sifraobracuna.Value), true);
                        identifikator.Text = "Unesite identifikator RSM obrasca ili pritisnite ENTER za postojeći identifikator";
                        identifikator.ShowDialog();

                        if (identifikator.UneseniIdentifikator == null)
                            throw new NullReferenceException();

                        row3["identifikatorobrasca"] = str3;
                    }
                    else
                    {
                        row3["identifikatorobrasca"] = strIdentifikator;
                    }
                    row3["IDRSVRSTEOBVEZNIKA"] = "40";
                    row3["IDRSVRSTEOBRACUNA"] = "11";
                    row3["nazivobveznika"] = RuntimeHelpers.GetObjectValue(this.dskorisnik.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
                    row3["adresa"] = Strings.Trim(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KORISNIK1ADRESA"])) + "," + Strings.Trim(Conversions.ToString(this.dskorisnik.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                    row3["mjesecobracunarsm"] = mjesecObracuna;
                    row3["godinaobracunarsm"] = godinaObracuna;
                    row3["brojosiguranika"] = "";
                    row3["mjesecisplatersm"] = str4;
                    row3["godinaisplatersm"] = str;
                    this.RsmaDataSet1.RSMA.Rows.Add(row3);
                    int num2 = 0;
                    int left = -1;
                    int num = 1;
                    try
                    {
                        enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            if (Operators.ConditionalCompareObjectNotEqual(left, current["idradnik"], false))
                            {
                                num2++;
                            }
                            DataRow row = this.RsmaDataSet1.RSMA1.NewRow();
                            row["rednibroj"] = num2.ToString("00000;00000;00000");
                            row["id"] = num;
                            if (strIdentifikator == null)
                            {
                                row["identifikatorobrasca"] = str3;
                            }
                            else
                            {
                                row["identifikatorobrasca"] = strIdentifikator;
                            }
                            row["PREZIMEIIME"] = RuntimeHelpers.GetObjectValue(current["prezimeiime"]);
                            row["mbgosiguranika"] = this.Dodaj_Vodece_Praznine(Conversions.ToString(current["OIB"]), 13);
                            row["sifragradarada"] = this.Dodaj_Vodece_Praznine(IDOPCINE, 4);
                            row["oo"] = Strings.Format("{0:00}", Conversions.ToString(current["oo"]));
                            row["b"] = Strings.Format("{0:0}", Conversions.ToString(current["b"]));
                            row["od"] = Conversions.ToInteger(current["od"]).ToString("00;00;00");
                            row["doo"] = Conversions.ToInteger(current["doo"]).ToString("00;00;00");
                            row["iznosobracunaneplacersmb"] = RuntimeHelpers.GetObjectValue(current["iznosobracunaneplacersmb"]);
                            row["IZNOSOSNOVICEZADOPRINOSERSMB"] = RuntimeHelpers.GetObjectValue(current["IZNOSOSNOVICEZADOPRINOSERSMB"]);
                            row["mio1rsmb"] = RuntimeHelpers.GetObjectValue(current["mio1rsmb"]);
                            row["mio2rsmb"] = RuntimeHelpers.GetObjectValue(current["mio2rsmb"]);
                            row["IZNOSISPLACENEPLACERSMB"] = RuntimeHelpers.GetObjectValue(current["IZNOSISPLACENEPLACERSMB"]);
                            this.RsmaDataSet1.RSMA1.Rows.Add(row);
                            left = Conversions.ToInteger(current["idradnik"]);
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
                    this.RsmaDataSet1.RSMA.Rows[0]["brojosiguranika"] = num2.ToString("00000;00000;00000");
                    this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.cbVrstaObveznika.SelectedRow.Cells["IDRSVRSTEOBVEZNIKA"].Value);
                    this.RsmaDataSet1.RSMA.Rows[0]["IDRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.cbVrstaObracuna.SelectedRow.Cells["IDRSVRSTEOBRACUNA"].Value);
                    this.BROJSTRANICA.Value = Operators.AddObject(this.RsmaDataSet1.RSMA1.Rows.Count / 12, Interaction.IIf((this.RsmaDataSet1.RSMA1.Rows.Count % 12) > 0, 1, 0));
                    this.BindingContext[this.RsmaDataSet1.RSMA1].EndCurrentEdit();
                    if (this.RsmaDataSet1.RSMA1.Count > 0)
                    {
                        this.UltraDockManager1.Visible = true;
                        if (this.UltraGrid1.Rows.Count > 0)
                        {
                            this.UltraGrid1.Rows[0].Selected = true;
                            this.UltraGrid1.Rows[0].Activated = true;
                        }
                        this.UltraGrid1.Select();
                    }
                    else
                    {
                        this.UltraDockManager1.Visible = false;
                    }
                    if (Operators.ConditionalCompareObjectEqual(this.iznosobracunaneplace.Value, 0, false))
                    {
                        this.godIsplate.Value = "0000";
                        this.mjesIsplate.Value = "00";
                    }


                    int od = 1;

                    if (this.mjesObracuna.Value.ToString() == "00")
                        od = 0;

                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(this.mjesObracuna.Value, 1, false), Operators.CompareObjectNotEqual(this.mjesObracuna.Value, 12, false))))
                    {
                        IEnumerator enumerator2 = null;
                        try
                        {
                            enumerator2 = this.RsmaDataSet1.RSMA1.Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                DataRow row2 = (DataRow)enumerator2.Current;
                                try
                                {
                                    row2["od"] = od.ToString("00;00;00");
                                    row2["doo"] = DateTime.DaysInMonth(Conversions.ToInteger(this.godObracuna.Value), Conversions.ToInteger(this.mjesObracuna.Value)).ToString("00;00;00");
                                }
                                catch (Exception)
                                {
                                    row2["doo"] = 0.ToString("00;00;00");
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
                }
                catch (Exception exception)
                {
                    if (exception.Message.Contains("Conversion from type 'DBNull' to type"))
                    {
                        MessageBox.Show("Greška u kreiranju novog R-Sm obrasca, zbog nepostojanja obaveznih podataka!", "Greška");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }

        private void mjesObracuna_Validated(object sender, EventArgs e)
        {
        }

        private void mjesObracuna_Validating(object sender, CancelEventArgs e)
        {
            int od = 1;

            if (this.mjesObracuna.Value.ToString() == "00")
                od = 0;

            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RsmaDataSet1.RSMA1.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    try
                    {
                        current["od"] = od.ToString("00;00;00");
                        current["doo"] = DateTime.DaysInMonth(Conversions.ToInteger(this.godObracuna.Value), Conversions.ToInteger(this.mjesObracuna.Value)).ToString("00;00;00");
                    }
                    catch (Exception)
                    {
                        current["doo"] = 0.ToString("00;00;00");
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
        
        private void godObracuna_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.mjesObracuna.Value.ToString()))
            {
                MessageBox.Show("Molimo, upišite mjesec obračuna!", "GREŠKA");
                this.mjesObracuna.Focus();
                return;
            }

            if (((int)this.mjesObracuna.Value) >= 1 && ((int)this.mjesObracuna.Value) != 12)
            {
                int od = 1;

                if (this.mjesObracuna.Value.ToString() == "00")
                    od = 0;

                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.RsmaDataSet1.RSMA1.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        try
                        {
                            current["od"] = od.ToString("00;00;00");
                            current["doo"] = DateTime.DaysInMonth(Conversions.ToInteger(this.godObracuna.Value), Conversions.ToInteger(this.mjesObracuna.Value)).ToString("00;00;00");
                        }
                        catch (Exception)
                        {
                            current["doo"] = 0.ToString("00;00;00");
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
        }

        private void godObracuna_ValueChanged(object sender, EventArgs e)
        {
        } 

        [LocalCommandHandler("Otvori")]
        public void OtvoriHandler(object sender, EventArgs e)
        {
            this.OtvoriObracun(null);
        }

        public void OtvoriObracun(string sifra = null)
        {
            if (!this.dd)
            {
                bool flag = false;
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                if ((sifra == null) & !this.dd)
                {
                    this.frm = new frmPregledObracuna();
                    this.frm.ShowDialog();
                    if (this.frm.DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    sifra = Conversions.ToString(this.frm.ObracunSelected);
                }
                if ((sifra != null) & !this.dd)
                {
                    this.sifraobracuna.Value = sifra;
                    this.RsmaDataSet1.Clear();
                    RSMADataSet dataSet = new RSMADataSet();
                    this.daRSM.FillByIDOBRACUN(dataSet, sifra);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        if (MessageBox.Show("Obrazac R-Sm za ovaj obračun postoji.\r\nYES - Izradi novi obrazac\r\nNo - Učitaj postojeći", "Obrazac R-Sm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmIdentifikator identifikator = new frmIdentifikator {
                                rsmIdent = { MaxLength = 4, Text = Conversions.ToString(dataSet.Tables[0].Rows[0][0]) }
                            };
                            if (identifikator.ShowDialog() == DialogResult.OK)
                            {
                                if ((identifikator.UneseniIdentifikator.ToString().Length <= 4) & Versioned.IsNumeric(identifikator.UneseniIdentifikator.ToString()))
                                {
                                    this.brisi_RSM(Conversions.ToString(dataSet.Tables[0].Rows[0][0]));
                                    this.Kreiraj_Novi_RSm_Obrazac(Conversions.ToString(identifikator.UneseniIdentifikator));
                                    this.RSM_Unos_u_Bazu();
                                }
                                else
                                {
                                    MessageBox.Show("Neispravan identifikator R-Sm obrasca!\r\nPonovite postupak.", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.sifraobracuna.Text = "(prazno)";
                                    flag = true;
                                }
                            }
                        }
                        else
                        {
                            this.daRSM.FillByIDENTIFIKATOROBRASCA(this.RsmaDataSet1, Conversions.ToString(dataSet.Tables[0].Rows[0][0]));
                        }
                    }
                    else
                    {
                        frmIdentifikator identifikator2 = new frmIdentifikator {
                            rsmIdent = { MaxLength = 4, Text = this.Vracaj_Zadnji_Broj_RSma(sifra, true) },
                            Text = "Povrdite ili unesite željeni identifikator R-SM obrasca."
                        };
                        if (identifikator2.ShowDialog() == DialogResult.OK)
                        {
                            if ((identifikator2.UneseniIdentifikator.ToString().Length == 4) & Versioned.IsNumeric(identifikator2.UneseniIdentifikator.ToString()))
                            {
                                this.Kreiraj_Novi_RSm_Obrazac(Conversions.ToString(identifikator2.UneseniIdentifikator));
                                this.RSM_Unos_u_Bazu();
                            }
                            else
                            {
                                MessageBox.Show("Neispravan identifikator R-Sm obrasca!\r\nPonovite postupak.", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.sifraobracuna.Text = "(prazno)";
                                flag = true;
                            }
                        }
                    }
                }
                if (!flag)
                {
                    this.UltraDockManager1.Visible = true;
                    if (this.UltraGrid1.Rows.Count > 0)
                    {
                        this.UltraGrid1.Rows[0].Selected = true;
                        this.UltraGrid1.Rows[0].Activated = true;
                    }
                    this.UltraGrid1.Select();
                }
                else
                {
                    this.UltraDockManager1.Visible = false;
                }
            }
            if (this.dd)
            {
                bool flag2 = false;
                SqlConnection connection2 = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                if ((sifra != null) & this.dd)
                {
                    SqlCommand command = new SqlCommand();
                    connection2.ConnectionString = Configuration.ConnectionString;
                    command.CommandText = "select ddrsm from ddobracun where ddobracunidobracun = '" + this.sifraobracuna.Text + "'";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection2;
                    connection2.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    frmIdentifikator identifikator3 = new frmIdentifikator();
                    if (reader.Read() & !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader.GetValue(0))))
                    {
                        int num = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(0))));
                        this.RsmaDataSet1.Clear();
                        identifikator3.rsmIdent.MaxLength = 4;
                        identifikator3.rsmIdent.Text = Conversions.ToString(num);
                        identifikator3.Text = "Unos identifikatora R-SM obrasca.";
                        identifikator3.ShowDialog();
                    }
                    else
                    {
                        this.sifraobracuna.Value = sifra;
                        this.RsmaDataSet1.Clear();
                        identifikator3.rsmIdent.MaxLength = 4;
                        identifikator3.rsmIdent.Text = this.Vracaj_Zadnji_Broj_RSma(sifra, true);
                        identifikator3.Text = "Unos identifikatora R-SM obrasca.";
                        identifikator3.ShowDialog();
                    }
                    if ((identifikator3.UneseniIdentifikator.ToString().Length == 4) & Versioned.IsNumeric(identifikator3.UneseniIdentifikator.ToString()))
                    {
                        this.Kreiraj_Novi_RSm_Obrazac(Conversions.ToString(identifikator3.UneseniIdentifikator));
                        this.RSM_Unos_u_Bazu();
                    }
                    else
                    {
                        MessageBox.Show("Neispravan identifikator R-Sm obrasca!\r\nPonovite postupak.", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.sifraobracuna.Text = "(prazno)";
                        flag2 = true;
                    }
                    connection2.Close();
                }
                if (!flag2)
                {
                    this.UltraDockManager1.Visible = true;
                    if (this.UltraGrid1.Rows.Count > 0)
                    {
                        this.UltraGrid1.Rows[0].Selected = true;
                        this.UltraGrid1.Rows[0].Activated = true;
                    }
                    this.UltraGrid1.Select();
                }
                else
                {
                    this.UltraDockManager1.Visible = false;
                }
            }
        }

        private object Podaci_obracun(string sifrobr, ref string mjesecobracuna, ref string godinaobracuna, ref string mjesecisplate, ref string godinaisplate)
        {
            object obj2 = new object();
            if (!this.dd)
            {
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                command.CommandText = "select mjesecobracuna,godinaobracuna,mjesecisplate,godinaisplate from obracun where idobracun = '" + sifrobr + "'";
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    mjesecobracuna = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(0)))).ToString("00;00;00");
                    godinaobracuna = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(1)))).ToString("0000;0000;0000");
                    mjesecisplate = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(2)))).ToString("00;00;00");
                    godinaisplate = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(3)))).ToString("0000;0000;0000");
                }
                connection.Close();
            }
            if (this.dd)
            {
                mjesecobracuna = "00";
                godinaobracuna = Conversions.ToInteger(sifrobr.Substring(0, 4)).ToString("0000;0000;0000");
                godinaisplate = sifrobr.Substring(0, 4);
                mjesecisplate = sifrobr.Substring(5, 2);
            }
            return obj2;
        }

        public void Ponovno_Izradi_Obrazac()
        {
            if (this.rsmIdent.Value != DBNull.Value)
            {
                if (!this.dd)
                {
                    frmIdentifikator identifikator = new frmIdentifikator {
                        rsmIdent = { MaxLength = 4, Text = Conversions.ToString(this.rsmIdent.Value) }
                    };
                    identifikator.rsmIdent.SelectAll();
                    identifikator.Text = "Povrdite ili unesite željeni identifikator R-SM obrasca.";
                    if (identifikator.ShowDialog() == DialogResult.OK)
                    {
                        if ((identifikator.UneseniIdentifikator.ToString().Length < 5) & Versioned.IsNumeric(identifikator.UneseniIdentifikator.ToString()))
                        {
                            this.brisi_RSM(Conversions.ToString(this.rsmIdent.Value));
                            this.RsmaDataSet1.RSMA1.Clear();
                            this.RsmaDataSet1.RSMA.Clear();
                            this.Kreiraj_Novi_RSm_Obrazac(Conversions.ToString(identifikator.UneseniIdentifikator));
                            this.RSM_Unos_u_Bazu();
                        }
                        else
                        {
                            MessageBox.Show("Neispravan identifikator R-Sm obrasca!\r\nPonovite postupak.", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (this.UltraGrid1.Rows.Count > 0)
                        {
                            this.UltraGrid1.Rows[0].Selected = true;
                            this.UltraGrid1.Rows[0].Activated = true;
                        }
                        this.UltraGrid1.Select();
                    }
                    else
                    {
                        Interaction.MsgBox("Odustali ste od kreiranja RSm obrasca", MsgBoxStyle.Information, "Obračun plaća-RSm");
                    }
                }
                if (this.dd)
                {
                    frmIdentifikator identifikator2 = new frmIdentifikator {
                        rsmIdent = { MaxLength = 4, Text = Conversions.ToString(this.rsmIdent.Value) }
                    };
                    identifikator2.rsmIdent.SelectAll();
                    identifikator2.Text = "Povrdite postojeći ili unesite novi identifikator R-SM obrasca.";
                    identifikator2.ShowDialog();
                    if ((identifikator2.UneseniIdentifikator.ToString().Length < 5) & Versioned.IsNumeric(identifikator2.UneseniIdentifikator.ToString()))
                    {
                        this.RsmaDataSet1.RSMA1.Clear();
                        this.RsmaDataSet1.RSMA.Clear();
                        this.Kreiraj_Novi_RSm_Obrazac(Conversions.ToString(identifikator2.UneseniIdentifikator));
                        this.RSM_Unos_u_Bazu();
                    }
                    else
                    {
                        MessageBox.Show("Neispravan identifikator R-Sm obrasca!\r\nPonovite postupak.", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (this.UltraGrid1.Rows.Count > 0)
                    {
                        this.UltraGrid1.Rows[0].Selected = true;
                        this.UltraGrid1.Rows[0].Activated = true;
                    }
                    this.UltraGrid1.Select();
                }
            }
        }

        [LocalCommandHandler("PonovnoStvori")]
        public void PonovnoStvoriHandler(object sender, EventArgs e)
        {
            this.Ponovno_Izradi_Obrazac();
        }

        public void RSM_Unos_u_Bazu()
        {
            if (!this.dd)
            {
                this.BindingContext[this.RsmaDataSet1, "RSMA1"].EndCurrentEdit();
                this.BindingContext[this.RsmaDataSet1, "RSMA"].EndCurrentEdit();
                try
                {
                    this.daRSM.Update(this.RsmaDataSet1);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;                    
                }
            }
            if (this.dd)
            {
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                command.CommandType = CommandType.Text;
                connection.Open();
                command.CommandText = "UPDATE DDOBRACUN SET DDRSM = '" + this.rsmIdent.Text + "' WHERE DDOBRACUNIDOBRACUN = '" + this.sifraobracuna.Text + "'";
                command.Connection = connection;
                command.ExecuteScalar();
                connection.Close();
            }
        }

        private void RsmObrazacLoad(object sender, EventArgs e)
        {
            this.dakorisnik.Fill(this.dskorisnik);
            if ((this.dskorisnik.KORISNIK.Rows.Count - 1) > 0)
            {
                KORISNIKSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<KORISNIKSelectionListWorkItem>("test");
                DataRow row2 = item.ShowModal(true, "", null);
                item.Terminate();
                if (row2 == null)
                {
                    return;
                }
                this.dskorisnik.Clear();
                this.dakorisnik.FillByIDKORISNIK(this.dskorisnik, Conversions.ToInteger(row2["IDKORISNIK"]));
            }
            this.UltraDockManager1.Visible = false;
            this.Set_Database_Binding();
            this.darsvrsteobracuna.Fill(this.RsvrsteobracunaDataSet1);
            this.darsvrsteobveznika.Fill(this.RsvrsteobveznikaDataSet1);
            this.cbVrstaObracuna.DataBindings.Add("Value", this.RsmaDataSet1, "RSMA.IDRSVRSTEOBRACUNA");
            this.lblNazivVrsteObracuna.DataBindings.Add("Text", this.RsmaDataSet1, "RSMA.NAZIVRSVRSTEOBRACUNA");
            this.cbVrstaObveznika.DataBindings.Add("Value", this.RsmaDataSet1, "RSMA.IDRSVRSTEOBVEZNIKA");
            this.lblNazivVrsteObveznika.DataBindings.Add("Text", this.RsmaDataSet1, "RSMA.NAZIVRSVRSTEOBVEZNIKA");
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            this.dd = false;
            IEnumerator<object> enumerator = this.Controller.WorkItem.Workspaces["main"].SmartParts.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is UserControl)
                {
                    UserControl current = (UserControl) enumerator.Current;
                    if (current.Name.ToLower() == "obracunsmartpart")
                    {
                        this.dd = false;
                        UltraTextEditor editor = (UltraTextEditor) InfraCustom.FindControl(current, "txtsifraobracuna");
                        if (Operators.ConditionalCompareObjectNotEqual(editor.Value, "", false))
                        {
                            this.sifraobracuna.Value = RuntimeHelpers.GetObjectValue(editor.Value);
                            this.OtvoriObracun(Conversions.ToString(this.sifraobracuna.Value));
                        }
                    }
                    else
                    {
                        if (current.Name.ToLower() == "obracunddsmartpart")
                        {
                            this.dd = true;
                            this.cbVrstaObveznika.Value = "17";
                            this.cbVrstaObracuna.Value = "03";
                            UltraTextEditor editor2 = (UltraTextEditor) InfraCustom.FindControl(current, "ultraSifraObracuna");
                            if (Operators.ConditionalCompareObjectNotEqual(editor2.Value, "", false))
                            {
                                this.sifraobracuna.Value = RuntimeHelpers.GetObjectValue(editor2.Value);
                                this.OtvoriObracun(Conversions.ToString(this.sifraobracuna.Value));
                            }
                            continue;
                        }
                        if (current.Name.ToLower() == "ucenicicustom")
                        {
                            if (MessageBox.Show("Želite li kreirati RSm obrazac za učenike u stručnoj praksi?", "RSM obrazac", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                frmIdentifikator identifikator2 = new frmIdentifikator
                                {
                                    rsmIdent = { MaxLength = 4, Text = this.Vracaj_Zadnji_Broj_RSma("sifra", true) },
                                    Text = "Povrdite ili unesite željeni identifikator R-SM obrasca."
                                };
                                if (identifikator2.ShowDialog() == DialogResult.OK)
                                {
                                    if ((identifikator2.UneseniIdentifikator.ToString().Length == 4) & Versioned.IsNumeric(identifikator2.UneseniIdentifikator.ToString()))
                                    {
                                        OPCINASelectionListWorkItem item2 = this.Controller.WorkItem.Items.AddNew<OPCINASelectionListWorkItem>("test");
                                        DataRow row4 = item2.ShowModal(true, "", null);
                                        item2.Terminate();
                                        if (row4 == null)
                                        {
                                            return;
                                        }
                                        this.cbVrstaObveznika.Value = "40";
                                        this.cbVrstaObracuna.Value = "11";
                                        this.RsmaDataSet1.Clear();

                                        UCENIKRSMIDENTDataSet dataSet = new UCENIKRSMIDENTDataSet();
                                        UCENIKRSMIDENTDataAdapter adapter = new UCENIKRSMIDENTDataAdapter();
                                        adapter.Fill(dataSet);

                                        DataRow row = dataSet.UCENIKRSMIDENT.NewRow();
                                        row["UCENIKRSMIDENT"] = identifikator2.UneseniIdentifikator;
                                        dataSet.UCENIKRSMIDENT.Rows.Add(row);
                                        adapter.Update(dataSet);

                                        this.Kreiraj_Novi_RSm_Obrazac_Za_Ucenike(identifikator2.UneseniIdentifikator.ToString(), Conversions.ToString(row4["IDOPCINE"]));
                                    }
                                    else
                                    {
                                        MessageBox.Show("Neispravan identifikator R-Sm obrasca!\r\nPonovite postupak.", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.sifraobracuna.Text = "(prazno)";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Set_Database_Binding()
        {
            this.rsmIdent.DataBindings.Add("Value", this.RsmaDataSet1, "RSMA.identifikatorobrasca");
            this.mbObveznik.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "mbobveznika");
            this.mbgObveznik.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "mbgobveznika");
            this.nazivObveznik.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "nazivobveznika");
            this.adresa.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "adresa");
            this.mjesObracuna.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "mjesecobracunarsm");
            this.godObracuna.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "godinaobracunarsm");
            this.brojosiguranika.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "brojosiguranika");
            this.mjesIsplate.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "mjesecisplatersm");
            this.godIsplate.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "godinaisplatersm");
            this.iznosobracunaneplace.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "iznosobracunaneplace");
            this.iznososnovicezadoprinose.DataBindings.Add("Value", this.RsmaDataSet1, "RSMA.iznososnovicezadoprinose");
            this.mio1.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "mio1");
            this.mio2.DataBindings.Add("Value", this.RsmaDataSet1.RSMA, "mio2");
            this.iznosisplaceneplace.DataBindings.Add("Value", this.RsmaDataSet1, "RSMA.iznosisplaceneplace");
        }

        [LocalCommandHandler("SnimiDatoteku2010")]
        public void SnimiDatotekuHandler(object sender, EventArgs e)
        {
            this.Datoteka_RSM_2010();
        }

        [LocalCommandHandler("StranicaA2010")]
        public void StranicaA2010Handler(object sender, EventArgs e)
        {
            this.Ispis_Stranice_A_RSM_2010();
        }

        [LocalCommandHandler("StranicaB2010")]
        public void StranicaB2010Handler(object sender, EventArgs e)
        {
            this.Ispis_Stranice_B_RSM_2010();
        }

        [LocalCommandHandler("Ucenici")]
        public void UceniciHandler(object sender, EventArgs e)
        {
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            this.RSM_Unos_u_Bazu();
        }

        private string Vracaj_Zadnji_Broj_RSma(string obr, bool mb)
        {
            string str = string.Empty;
            if (!this.dd)
            {
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                command.CommandText = "select max(p.identifikator) from (select max(identifikatorobrasca) as identifikator from rsma union all select max(DDRSM) as identifikator from DDOBRACUN UNION ALL SELECT MAX(UCENIKRSMIDENT) fROM UCENIKRSMIDENT ) as p";
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read() & !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader.GetValue(0))))
                {
                    int num = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(reader.GetValue(0)))) + 1;
                    if (mb)
                    {
                        str = num.ToString("0000;0000;0000");
                    }
                    else
                    {
                        str = num.ToString("000;000;000");
                    }
                }
                else
                {
                    string str6 = string.Empty;
                    string str3 = string.Empty;
                    string str4 = string.Empty;
                    string str5 = string.Empty;
                    this.Podaci_obracun(obr, ref str6, ref str4, ref str5, ref str3);

                    if (str4.Length > 0)
                        str = str4.Substring(str4.Length - 1, 1) + "001";
                }
                connection.Close();
            }
            if (this.dd)
            {
                SqlCommand command2 = new SqlCommand();
                SqlConnection connection2 = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                command2.CommandText = "select max(p.identifikator) from (select max(identifikatorobrasca) as identifikator from rsma union all select max(DDRSM) as identifikator from DDOBRACUN ) as p";
                command2.CommandType = CommandType.Text;
                command2.Connection = connection2;
                connection2.Open();
                SqlDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read() & !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader2.GetValue(0))))
                {
                    str = (Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(reader2.GetValue(0)))) + 1).ToString("0000;0000;0000");
                }
                else
                {
                    string str11 = string.Empty;
                    string str8 = string.Empty;
                    string str9 = string.Empty;
                    string str10 = string.Empty;
                    this.Podaci_obracun(obr, ref str11, ref str9, ref str10, ref str8);

                    if (str9.Length > 0)
                        str = str9.Substring(str9.Length - 1, 1) + "001";
                }
                connection2.Close();
            }
            return str;
        }

        private AutoHideControl _RSMObrazacAutoHideControl;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaBottom;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaLeft;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaRight;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaTop;

        private UltraMaskedEdit adresa;

        private UltraMaskedEdit brojosiguranika;

        private UltraNumericEditor BROJSTRANICA;

        private UltraCombo cbVrstaObracuna;

        private UltraCombo cbVrstaObveznika;

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

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow2;

        private DockableWindow DockableWindow3;

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

        private UltraMaskedEdit godIsplate;

        private UltraMaskedEdit godObracuna;

        private UltraMaskedEdit iznosisplaceneplace;

        private UltraMaskedEdit iznosobracunaneplace;

        private UltraMaskedEdit iznososnovicezadoprinose;

        private UltraLabel lblNazivVrsteObracuna;

        private UltraLabel lblNazivVrsteObveznika;

        private UltraMaskedEdit mbgObveznik;

        private UltraMaskedEdit mbObveznik;

        private UltraMaskedEdit mio1;

        private UltraMaskedEdit mio2;

        private UltraMaskedEdit mjesIsplate;

        private UltraMaskedEdit mjesObracuna;

        private UltraMaskedEdit nazivObveznik;

        private RSMADataSet RsmaDataSet1;

        private UltraMaskedEdit rsmIdent;

        private RSVRSTEOBRACUNADataSet RsvrsteobracunaDataSet1;

        private RSVRSTEOBVEZNIKADataSet RsvrsteobveznikaDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraMaskedEdit sifraobracuna;

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox2;

        private UltraGroupBox UltraGroupBox3;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel10;

        private UltraLabel UltraLabel11;

        private UltraLabel UltraLabel12;

        private UltraLabel UltraLabel13;

        private UltraLabel UltraLabel14;

        private UltraLabel UltraLabel15;

        private UltraLabel UltraLabel16;

        private UltraLabel UltraLabel17;

        private UltraLabel UltraLabel18;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel3;

        private UltraLabel UltraLabel4;

        private UltraLabel UltraLabel5;

        private UltraLabel UltraLabel6;

        private UltraLabel UltraLabel7;

        private UltraLabel UltraLabel8;

        private UltraLabel UltraLabel9;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        private WindowDockingArea WindowDockingArea3;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

