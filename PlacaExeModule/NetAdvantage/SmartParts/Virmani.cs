namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using DatotekeZaBanku;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
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
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using RSM;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;


    [SmartPart]
    public class Virmani : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private VIRMANIDataAdapter davirmani;
        private bool dd;
        private bool disableValueChange;
        private bool fin;
        private SmartPartInfoProvider infoProvider;
        private string odabrani;
        private SmartPartInfo smartPartInfo1;
        private UltraLabel ultraLabel8;
        private UltraMaskedEdit pnbzMjesecGodina;
        private UltraMaskedEdit pnbzOIB;
        private UltraMaskedEdit pnbzBrojModela;
        private UltraCombo ultraComboTipIsplate = new Infragistics.Win.UltraWinGrid.UltraCombo();
        private UltraButton ButtonPrimjeniBrojZaduzenja;

        private Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("ba0d6b83-99c6-4890-8765-e653aacf2034"));
        private WindowDockingArea WindowDockingArea1;
        private SaveFileDialog sfdVirmani;
        private DockableWindow dockableWindow1;

        //napravljeno da kada se mjenja platitelj da se povuce u datoteci i virmanima
        static bool invalidi = false;

        public static string vrsta_izvjesca;

        private int pID
        {
            get;
            set;
        }

        private bool uf = false;
        private bool obracunRazno = false;

        public Virmani()
        {
            base.Load += new EventHandler(this.Virmani_Load_1);
            this.dd = false;
            this.fin = false;
            this.disableValueChange = false;
            this.davirmani = new VIRMANIDataAdapter();
            this.odabrani = "";
            this.smartPartInfo1 = new SmartPartInfo("Virmani", "Virmani");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private static object Brisi_Virmane_Obracuna(string sifraobracuna)
        {
            object obj2 = new object();
            using (SqlCommand command = new SqlCommand())
            {
                SqlConnection connection2 = new SqlConnection
                {
                    ConnectionString = Configuration.ConnectionString
                };
                SqlConnection connection = connection2;
                command.CommandText = "delete from virmani where sifraobracunavirman = '" + sifraobracuna + "'";
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteScalar();
                connection.Close();
            }
            return obj2;
        }

        private void DATUMIZVRSENJA_ValueChanged(object sender, EventArgs e)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    current["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            if (!this.fin)
            {
                try
                {
                    this.davirmani.Update(this.VirmaniDataSet1);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }

        private void DATUMPREDAJE_ValueChanged(object sender, EventArgs e)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    current["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            if (!this.fin)
            {
                try
                {
                    this.davirmani.Update(this.VirmaniDataSet1);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }

        private bool ProvjeraModel(RowsCollection rowsCollection)
        {
            foreach (var item in rowsCollection)
            {
                try
                {
                    if (item.Cells["ModelZaduzenja"].Value.ToString().Trim() == "")
                    {
                        return true;
                    }
                }
                catch { }
            }
            return false;
        }

        private object GetOznaka(object radnik, object obrracun, Mipsed7.DataAccessLayer.SqlClient client)
        {
            DataTable tbl = client.GetDataTable("Select Element.VrstaPrimanja From Element Inner Join ObracunElementi On ELEMENT.IDELEMENT = ObracunElementi.IDELEMENT  " +
                                       "Where ObracunElementi.IDRADNIK = '" + radnik + "' And ObracunElementi.IDOBRACUN = '" + obrracun + "'");

            foreach (DataRow row in tbl.Rows)
            {
                if (row["VrstaPrimanja"].ToString() == "100")
                {
                    return "100";
                }
            }

            if (tbl.Rows.Count > 1)
            {
                return "110";
            }
            else
            {
                return tbl.Rows[0]["VrstaPrimanja"].ToString();
            }
        }

        private bool ProvjeraModelOdobrenja(RowsCollection rowsCollection)
        {
            foreach (var item in rowsCollection)
            {
                try
                {
                    if (item.Cells["ModelOdobrenja"].Value.ToString().Trim() == "")
                    {
                        return true;
                    }
                }
                catch { }
            }
            return false;
        }

        private void SepaDatoteka(bool vrsta)
        {
            if (ProvjeraModel(UltraGrid1.Rows) && sifraobracuna.Tag != "URA" && sifraobracuna.Tag != "RAZNO")
            {
                MessageBox.Show("Nisu popunjeni svi modeli zaduženja!!!");
                return;
            }

            if (ProvjeraModelOdobrenja(UltraGrid1.Rows))
            {
                MessageBox.Show("Nisu popunjeni svi modeli odobrenja!!!");
                return;
            }

            string brojNaloga;
            using (Sepa.frmBrojNaloga objekt = new Sepa.frmBrojNaloga())
            {
                objekt.ShowDialog();

                brojNaloga = objekt.brojNaloga;
            }

            if (Convert.ToInt32(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1")) == 0)
            {
                MessageBox.Show("Nema označenih virmana!");
                return;
            }

            IBAN iban = new IBAN();

            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;

            try
            {
                sqlComm = new SqlCommand("spSepaPlace", client.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@Obracun", this.sifraobracuna.Value);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(dtRedovi);
            }
            catch { }


            //kalkulacija ukoliko se iskljuci nesto sto je SALA
            DataRow[] calculateVirmani = VirmaniDataSet1.VIRMANI.Select("OZNACEN=0 AND (HUB3_SIFRANAMJENE='SALA' OR NAMJENA = 'Izuzeto iz ovrhe')");
            foreach (var item in calculateVirmani)
            {
                foreach (DataRow item2 in dtRedovi.Rows)
                {
                    if (item["BROJRACUNAPRI"].ToString() == string.Format("{0}-{1}", item2["VBDIBANKE"].ToString(), item2["TEKUCI"].ToString()))
                    {
                        item2["UKUPNOZAISPLATU"] = Convert.ToDecimal(item2["UKUPNOZAISPLATU"]) - Convert.ToDecimal(item["IZNOS"]);
                    }
                }
            }
            for (int i = dtRedovi.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToDecimal(dtRedovi.Rows[i]["UKUPNOZAISPLATU"]) == 0)
                {
                    dtRedovi.Rows[i].Delete();
                }
            }
            dtRedovi.AcceptChanges();


            int brojRedovaPlaca = dtRedovi.Rows.Count + Convert.ToInt32(VirmaniDataSet1.VIRMANI.Compute("count(idvirman)", "(OZNACEN=1 AND HUB3_SIFRANAMJENE='NITX' AND NAMJENA<>'Izuzeto iz ovrhe') OR (OZNACEN=1 And OpisPlacanja='Rucni virman')"));

            DataRow[] virmaniPlace = VirmaniDataSet1.VIRMANI.Select("(OZNACEN=1 AND HUB3_SIFRANAMJENE='NITX' AND NAMJENA<>'Izuzeto iz ovrhe') OR (OZNACEN=1 And OpisPlacanja='Rucni virman')");

            string izvorDokumenta = this.VirmaniDataSet1.VIRMANI.Rows[0]["izvordokumenta"].ToString();
            string ibanPlatitelja = iban.GenerirajIBANIzBrojaRacuna(VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"].ToString(), true, false);
            string oznakaValutePlacanja = "HRK"; // za vrstu naloga, mora biti HRK
            string ukupanBrojNaloga = VirmaniDataSet1.VIRMANI.Compute("count(idvirman)", "OZNACEN=1").ToString();
            decimal ukupanIznosNaloga = Decimal.Round(Convert.ToDecimal(VirmaniDataSet1.VIRMANI.Compute("SUM(IZNOS)", "OZNACEN=1")), 2);
            DateTime datumIzvrsenjaNaloga = (DateTime)this.DATUMIZVRSENJA.Value;
            string korisnik = this.KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIK1NAZIV"].ToString();
            string korisnikAdresa = KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIK1ADRESA"].ToString();
            string korisnikMjesto = KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIK1MJESTO"].ToString();
            string korisnikOIB = KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIKOIB"].ToString();


            DataRow[] temp;

            try
            {
                //podesavanje oznaka
                temp = dtRedovi.Select("Vrsta='NITX'");

                //zasticeni
                foreach (DataRow row in temp)
                {
                    foreach (DataRow row2 in dtRedovi.Rows)
                    {
                        if (row["IDRADNIK"].ToString() == row2["IDRADNIK"].ToString())
                        {
                            if (row["Vrsta"].ToString() == row2["Vrsta"].ToString())
                            {
                                row2["Oznaka"] = "";
                            }
                            else
                            {
                                row2["Oznaka"] = "120";
                            }
                        }

                        if (row2["Vrsta"].ToString() == "NITX")
                        {
                            row2["Oznaka"] = "399";
                        }
                    }
                }
            }
            catch { }

            foreach (DataRow row in dtRedovi.Rows)
            {
                if (row["Vrsta"].ToString() == "SALA" && row["Oznaka"].ToString().Length == 0)
                {
                    row["Oznaka"] = GetOznaka(row["IDRADNIK"], this.sifraobracuna.Value, client);
                }
            }

            #region Glava
            Sepa07052015.Document document = new Sepa07052015.Document();

            Sepa07052015.CustomerCreditTransferInitiationV03 customCredeit = new Sepa07052015.CustomerCreditTransferInitiationV03();

            Sepa07052015.GroupHeader32 groupHeader = new Sepa07052015.GroupHeader32();

            Sepa07052015.PartyIdentification32_1 partyIndentifier = new Sepa07052015.PartyIdentification32_1();
            partyIndentifier.Nm = korisnik;

            try
            {
                groupHeader.CreDtTm = Convert.ToDateTime(DATUMPREDAJE.Value).ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
            catch { groupHeader.CreDtTm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"); }

            groupHeader.CtrlSum = ukupanIznosNaloga;
            groupHeader.CtrlSumSpecified = true;
            groupHeader.InitgPty = partyIndentifier;

            try
            {
                if (vrsta)
                {
                    groupHeader.MsgId = string.Format("UN{3}{0}000{1}{2}", Convert.ToDateTime(DATUMPREDAJE.Value).ToString("yyyyMMdd"), brojNaloga, izvorDokumenta, korisnikOIB);
                }
                else
                {
                    groupHeader.MsgId = string.Format("UN{0}000{1}{2}", Convert.ToDateTime(DATUMPREDAJE.Value).ToString("yyyyMMdd"), brojNaloga, izvorDokumenta);
                }
            }
            catch
            {
                if (vrsta)
                {
                    groupHeader.MsgId = string.Format("UN{3}{0}000{1}{2}", DateTime.Now.ToString("yyyyMMdd"), brojNaloga, izvorDokumenta, korisnikOIB);
                }
                else
                {
                    groupHeader.MsgId = string.Format("UN{0}000{1}{2}", DateTime.Now.ToString("yyyyMMdd"), brojNaloga, izvorDokumenta);
                }
            }

            if (this.sifraobracuna.Value.ToString() == "PutniNalog" || this.sifraobracuna.Tag == "DD" || this.sifraobracuna.Tag == "URA" || sifraobracuna.Tag == "RAZNO")
            {
                groupHeader.NbOfTxs = ukupanBrojNaloga;
            }
            else
            {
                groupHeader.NbOfTxs = brojRedovaPlaca.ToString();
            }

            Sepa07052015.PaymentInstructionInformation3[] paymentInsturstions = new Sepa07052015.PaymentInstructionInformation3[1];

            Sepa07052015.PartyIdentification32_2 partyIdentifier2 = new Sepa07052015.PartyIdentification32_2();
            partyIdentifier2.Nm = korisnik;

            Sepa07052015.PostalAddress6 address = new Sepa07052015.PostalAddress6();
            address.AdrLine = new string[] { korisnikAdresa, korisnikMjesto };
            partyIdentifier2.PstlAdr = address;

            Sepa07052015.OrganisationIdentification4 organization = new Sepa07052015.OrganisationIdentification4();
            Sepa07052015.GenericOrganisationIdentification1 genOrg = new Sepa07052015.GenericOrganisationIdentification1();
            genOrg.Id = korisnikOIB;
            organization.Item = genOrg;
            Sepa07052015.Party6Choice party6 = new Sepa07052015.Party6Choice();
            party6.Item = organization;
            partyIdentifier2.Id = party6;

            Sepa07052015.PaymentInstructionInformation3 pay = new Sepa07052015.PaymentInstructionInformation3();
            pay.BtchBookg = false;
            pay.BtchBookgSpecified = true;

            pay.ChrgBrSpecified = false;
            pay.CtrlSum = ukupanIznosNaloga;
            pay.CtrlSumSpecified = true;
            pay.Dbtr = partyIdentifier2;

            Sepa07052015.CashAccount16_HR cashHR = new Sepa07052015.CashAccount16_HR();

            Sepa07052015.AccountIdentification4Choice_HR accountHR = new Sepa07052015.AccountIdentification4Choice_HR();
            accountHR.IBAN = ibanPlatitelja;
            cashHR.Id = accountHR;
            pay.DbtrAcct = cashHR;

            Sepa07052015.BranchAndFinancialInstitutionIdentification4_1 branch2 = new Sepa07052015.BranchAndFinancialInstitutionIdentification4_1();

            Sepa07052015.FinancialInstitutionIdentification7_1 financial2 = new Sepa07052015.FinancialInstitutionIdentification7_1();

            Sepa07052015.GenericFinancialIdentification1 orgGen = new Sepa07052015.GenericFinancialIdentification1();
            orgGen.Id = Sepa07052015.Max35Text_NP.NOTPROVIDED;

            financial2.Item = orgGen;
            branch2.FinInstnId = financial2;
            pay.DbtrAgt = branch2;

            if (this.sifraobracuna.Value.ToString() == "PutniNalog" || this.sifraobracuna.Tag == "DD" || this.sifraobracuna.Tag == "URA" || sifraobracuna.Tag == "RAZNO")
            {
                pay.NbOfTxs = ukupanBrojNaloga;
            }
            else
            {
                pay.NbOfTxs = brojRedovaPlaca.ToString();
            }

            pay.PmtInfId = "GRUPA1";
            pay.PmtMtd = Sepa07052015.PaymentMethod3Code.TRF;

            Sepa07052015.PaymentTypeInformation19_1 payment2 = new Sepa07052015.PaymentTypeInformation19_1();
            payment2.InstrPrty = Sepa07052015.Priority2Code.NORM;
            payment2.InstrPrtySpecified = true;
            pay.PmtTpInf = payment2;
            pay.ReqdExctnDt = datumIzvrsenjaNaloga;


            partyIndentifier = new Sepa07052015.PartyIdentification32_1();
            Sepa07052015.Party6Choice partChice6 = new Sepa07052015.Party6Choice();
            Sepa07052015.OrganisationIdentification4 orgIdent = new Sepa07052015.OrganisationIdentification4();
            Sepa07052015.GenericOrganisationIdentification1 geNorg1 = new Sepa07052015.GenericOrganisationIdentification1();
            geNorg1.Id = "00000000000";
            orgIdent.Item = geNorg1;
            partChice6.Item = orgIdent;
            partyIndentifier.Id = partChice6;
            //pay.UltmtDbtr = partyIndentifier;
            #endregion

            Sepa07052015.CreditTransferTransactionInformation10[] creditTransaction10Field;
            int counter = 0;
            string ibanPrimatelja;
            decimal iznos;
            string primatelj1;
            string primatelj2;
            string primatelj3;
            string opisPlacanja;
            string ibanEndToEnd;
            string hub3_sifraNamjene;
            string pozivRef;
            bool nepotpuno = false;

            #region Ostalo
            if (this.sifraobracuna.Value.ToString() == "PutniNalog" || this.sifraobracuna.Tag == "DD" || this.sifraobracuna.Tag == "URA" || sifraobracuna.Tag == "RAZNO")
            {
                creditTransaction10Field = new Sepa07052015.CreditTransferTransactionInformation10[Convert.ToInt32(ukupanBrojNaloga)];

                foreach (DataRow dr in VirmaniDataSet1.VIRMANI.Rows)
                {
                    if ((bool)dr["OZNACEN"])
                    {
                        if (sifraobracuna.Tag == "RAZNO")
                        {
                            ibanPrimatelja = dr["BROJRACUNAPRI"].ToString();
                        }
                        else
                        {
                            ibanPrimatelja = iban.GenerirajIBANIzBrojaRacuna(dr["BROJRACUNAPRI"].ToString(), false, true);
                        }

                        if (dr["IZNOS"] != DBNull.Value)
                        {
                            iznos = Decimal.Round(Convert.ToDecimal(dr["IZNOS"]), 2);
                        }
                        else
                        {
                            iznos = 0;
                        }

                        if (dr["OPISPLACANJAVIRMAN"] != DBNull.Value)
                        {
                            opisPlacanja = dr["OPISPLACANJAVIRMAN"].ToString();
                        }
                        else
                        {
                            opisPlacanja = "";
                        }
                        if (dr["PRI1"] != DBNull.Value)
                        {
                            primatelj1 = dr["PRI1"].ToString();
                        }
                        else
                        {
                            primatelj1 = "";
                        }
                        if (dr["PRI2"] != DBNull.Value)
                        {
                            primatelj2 = dr["PRI2"].ToString();
                        }
                        else
                        {
                            primatelj2 = "";
                        }
                        if (dr["PRI3"] != DBNull.Value)
                        {
                            primatelj3 = dr["PRI3"].ToString();
                        }
                        else
                        {
                            primatelj3 = "";
                        }

                        if (dr["MODELZADUZENJA"] != DBNull.Value)
                        {
                            ibanEndToEnd = "HR" + dr["MODELZADUZENJA"].ToString().Trim() + dr["POZIVZADUZENJA"].ToString();

                            if (sifraobracuna.Tag == "URA")
                            {
                                if (dr["MODELZADUZENJA"].ToString().Trim().Length == 0)
                                {
                                    ibanEndToEnd = "HR99";
                                }
                            }

                            if (sifraobracuna.Tag == "RAZNO")
                            {
                                if (dr["MODELZADUZENJA"].ToString().Trim().Length == 0)
                                {
                                    ibanEndToEnd = "HR99";
                                }
                            }
                        }
                        else
                        {
                            ibanEndToEnd = "";
                        }


                        if (dr["MODELODOBRENJA"] != DBNull.Value)
                        {
                            pozivRef = "HR" + dr["MODELODOBRENJA"].ToString().Trim() + dr["POZIVODOBRENJA"].ToString();

                            if (sifraobracuna.Tag == "URA")
                            {
                                if (dr["MODELODOBRENJA"].ToString().Trim().Length == 0)
                                {
                                    pozivRef = "HR99";
                                }
                            }

                            if (sifraobracuna.Tag == "RAZNO")
                            {
                                if (dr["MODELODOBRENJA"].ToString().Trim().Length == 0)
                                {
                                    pozivRef = "HR99";
                                }
                            }
                        }
                        else
                        {
                            pozivRef = "";
                        }

                        if (dr["HUB3_SIFRANAMJENE"] != DBNull.Value)
                        {
                            hub3_sifraNamjene = dr["HUB3_SIFRANAMJENE"].ToString();
                        }
                        else
                        {
                            hub3_sifraNamjene = "";
                        }

                        if (sifraobracuna.Tag == "URA")
                        {
                            hub3_sifraNamjene = "OTHR";
                        }


                        if (hub3_sifraNamjene == "SALA")
                        {
                            pozivRef = "HR6940002-" + korisnikOIB + "-" + dr["OpisPlacanja"].ToString();
                        }

                        Sepa07052015.CreditTransferTransactionInformation10 creditTransaction10 = new Sepa07052015.CreditTransferTransactionInformation10();

                        Sepa07052015.PaymentIdentification1 payment1 = new Sepa07052015.PaymentIdentification1();
                        payment1.EndToEndId = ibanEndToEnd;
                        creditTransaction10.PmtId = payment1;

                        Sepa07052015.AmountType3Choice amount = new Sepa07052015.AmountType3Choice();
                        Sepa07052015.ActiveOrHistoricCurrencyAndAmount account = new Sepa07052015.ActiveOrHistoricCurrencyAndAmount();
                        account.Ccy = oznakaValutePlacanja;
                        account.Value = iznos;

                        amount.InstdAmt = account;
                        creditTransaction10.Amt = amount;

                        partyIdentifier2 = new Sepa07052015.PartyIdentification32_2();
                        partyIdentifier2.Nm = primatelj1;

                        address = new Sepa07052015.PostalAddress6();

                        address.AdrLine = new string[] { primatelj2 };

                        if (primatelj2.Length > 0)
                        {
                            partyIdentifier2.PstlAdr = address;
                        }
                        creditTransaction10.Cdtr = partyIdentifier2;

                        Sepa07052015.CashAccount16_2 cash16 = new Sepa07052015.CashAccount16_2();
                        Sepa07052015.AccountIdentification4Choice_2 accountChoice = new Sepa07052015.AccountIdentification4Choice_2();
                        accountChoice.Item = ibanPrimatelja.Replace(" ", ""); ;
                        cash16.Id = accountChoice;
                        creditTransaction10.CdtrAcct = cash16;

                        creditTransaction10.ChrgBrSpecified = false;

                        Sepa07052015.Purpose2Choice purpose = new Sepa07052015.Purpose2Choice();
                        purpose.Cd = hub3_sifraNamjene;
                        creditTransaction10.Purp = purpose;

                        Sepa07052015.RemittanceInformation5 remittance = new Sepa07052015.RemittanceInformation5();
                        Sepa07052015.StructuredRemittanceInformation7 structureRemittanceinformation = new Sepa07052015.StructuredRemittanceInformation7();
                        Sepa07052015.CreditorReferenceInformation2 credit = new Sepa07052015.CreditorReferenceInformation2();
                        Sepa07052015.CreditorReferenceType2 creditType2 = new Sepa07052015.CreditorReferenceType2();
                        Sepa07052015.CreditorReferenceType1Choice creditType1 = new Sepa07052015.CreditorReferenceType1Choice();
                        creditType1.Cd = Sepa07052015.DocumentType3Code.SCOR;
                        creditType2.CdOrPrtry = creditType1;
                        credit.Tp = creditType2;
                        credit.Ref = pozivRef;
                        structureRemittanceinformation.CdtrRefInf = credit;
                        structureRemittanceinformation.AddtlRmtInf = opisPlacanja;
                        remittance.Item = structureRemittanceinformation;

                        creditTransaction10.RmtInf = remittance;

                        creditTransaction10Field[counter] = creditTransaction10;
                        counter++;
                    }
                }

            }
            #endregion
            else
            {
                creditTransaction10Field = new Sepa07052015.CreditTransferTransactionInformation10[brojRedovaPlaca];

                //dio iz virmana
                foreach (DataRow dr in virmaniPlace)
                {
                    if (sifraobracuna.Tag == "RAZNO")
                    {
                        ibanPrimatelja = dr["BROJRACUNAPRI"].ToString();
                    }
                    else
                    {
                        ibanPrimatelja = iban.GenerirajIBANIzBrojaRacuna(dr["BROJRACUNAPRI"].ToString(), false, true);
                    }

                    if (dr["IZNOS"] != DBNull.Value)
                    {
                        iznos = Decimal.Round(Convert.ToDecimal(dr["IZNOS"]), 2);
                    }
                    else
                    {
                        iznos = 0;
                    }

                    if (dr["OPISPLACANJAVIRMAN"] != DBNull.Value)
                    {
                        opisPlacanja = dr["OPISPLACANJAVIRMAN"].ToString();
                    }
                    else
                    {
                        opisPlacanja = "";
                    }
                    if (dr["PRI1"] != DBNull.Value)
                    {
                        primatelj1 = dr["PRI1"].ToString();
                    }
                    else
                    {
                        primatelj1 = "";
                    }
                    if (dr["PRI2"] != DBNull.Value)
                    {
                        primatelj2 = dr["PRI2"].ToString();
                    }
                    else
                    {
                        primatelj2 = "";
                    }
                    if (dr["PRI3"] != DBNull.Value)
                    {
                        primatelj3 = dr["PRI3"].ToString();
                    }
                    else
                    {
                        primatelj3 = "";
                    }


                    if (dr["MODELZADUZENJA"] != DBNull.Value && dr["POZIVZADUZENJA"] != DBNull.Value)
                    {
                        ibanEndToEnd = "HR" + dr["MODELZADUZENJA"].ToString().Trim() + dr["POZIVZADUZENJA"].ToString();
                    }
                    else
                    {
                        ibanEndToEnd = "";
                    }

                    if (dr["MODELODOBRENJA"] != DBNull.Value && dr["POZIVODOBRENJA"] != DBNull.Value)
                    {
                        pozivRef = "HR" + dr["MODELODOBRENJA"].ToString().Trim() + dr["POZIVODOBRENJA"].ToString();
                    }
                    else
                    {
                        pozivRef = "";
                    }

                    if (dr["MODELZADUZENJA"].ToString() == "99" && dr["POZIVZADUZENJA"].ToString().Length == 0)
                    {
                        ibanEndToEnd = "HR" + dr["MODELZADUZENJA"].ToString().Trim();
                    }

                    if (dr["MODELODOBRENJA"].ToString() == "99" && dr["POZIVODOBRENJA"].ToString().Length == 0)
                    {
                        pozivRef = "HR" + dr["MODELODOBRENJA"].ToString().Trim();
                    }

                    if (dr["HUB3_SIFRANAMJENE"] != DBNull.Value)
                    {
                        hub3_sifraNamjene = dr["HUB3_SIFRANAMJENE"].ToString();
                    }
                    else
                    {
                        hub3_sifraNamjene = "";
                    }

                    Sepa07052015.CreditTransferTransactionInformation10 creditTransaction10 = new Sepa07052015.CreditTransferTransactionInformation10();

                    Sepa07052015.PaymentIdentification1 payment1 = new Sepa07052015.PaymentIdentification1();
                    payment1.EndToEndId = ibanEndToEnd;
                    creditTransaction10.PmtId = payment1;

                    Sepa07052015.AmountType3Choice amount = new Sepa07052015.AmountType3Choice();
                    Sepa07052015.ActiveOrHistoricCurrencyAndAmount account = new Sepa07052015.ActiveOrHistoricCurrencyAndAmount();
                    account.Ccy = oznakaValutePlacanja;
                    account.Value = iznos;

                    amount.InstdAmt = account;
                    creditTransaction10.Amt = amount;

                    partyIdentifier2 = new Sepa07052015.PartyIdentification32_2();
                    partyIdentifier2.Nm = primatelj1;

                    address = new Sepa07052015.PostalAddress6();

                    address.AdrLine = new string[] { primatelj2 };

                    if (primatelj2.Length > 0)
                    {
                        partyIdentifier2.PstlAdr = address;
                    }
                    creditTransaction10.Cdtr = partyIdentifier2;

                    Sepa07052015.CashAccount16_2 cash16 = new Sepa07052015.CashAccount16_2();
                    Sepa07052015.AccountIdentification4Choice_2 accountChoice = new Sepa07052015.AccountIdentification4Choice_2();
                    accountChoice.Item = ibanPrimatelja.Replace(" ", "");
                    cash16.Id = accountChoice;
                    creditTransaction10.CdtrAcct = cash16;

                    creditTransaction10.ChrgBrSpecified = false;

                    Sepa07052015.Purpose2Choice purpose = new Sepa07052015.Purpose2Choice();
                    purpose.Cd = hub3_sifraNamjene;
                    creditTransaction10.Purp = purpose;

                    Sepa07052015.RemittanceInformation5 remittance = new Sepa07052015.RemittanceInformation5();
                    Sepa07052015.StructuredRemittanceInformation7 structureRemittanceinformation = new Sepa07052015.StructuredRemittanceInformation7();
                    Sepa07052015.CreditorReferenceInformation2 credit = new Sepa07052015.CreditorReferenceInformation2();
                    Sepa07052015.CreditorReferenceType2 creditType2 = new Sepa07052015.CreditorReferenceType2();
                    Sepa07052015.CreditorReferenceType1Choice creditType1 = new Sepa07052015.CreditorReferenceType1Choice();
                    creditType1.Cd = Sepa07052015.DocumentType3Code.SCOR;
                    creditType2.CdOrPrtry = creditType1;
                    credit.Tp = creditType2;
                    credit.Ref = pozivRef;
                    structureRemittanceinformation.CdtrRefInf = credit;
                    structureRemittanceinformation.AddtlRmtInf = opisPlacanja;
                    remittance.Item = structureRemittanceinformation;

                    creditTransaction10.RmtInf = remittance;

                    creditTransaction10Field[counter] = creditTransaction10;
                    counter++;
                }

                //dio za sumarno za svaku osobu
                foreach (DataRow dr in dtRedovi.Rows)
                {
                    ibanPrimatelja = iban.GenerirajIBANIzBrojaRacuna(dr["VBDIBANKE"].ToString() + "-" + dr["TEKUCI"].ToString(), false, true);

                    iznos = Decimal.Round(Convert.ToDecimal(dr["UKUPNOZAISPLATU"]), 2);

                    opisPlacanja = dr["OPISPLACANJANETO"].ToString();

                    if (dr["nazivbanke1"] != DBNull.Value)
                    {
                        primatelj1 = dr["nazivbanke1"].ToString();
                    }
                    else
                    {
                        primatelj1 = "";
                    }

                    if (dr["MjestoBanka"] != DBNull.Value)
                    {
                        primatelj2 = dr["MjestoBanka"].ToString();
                    }
                    else
                    {
                        primatelj2 = "";
                    }

                    if (dr["MZBANKA"] != DBNull.Value && dr["PZBANKA"] != DBNull.Value)
                    {
                        ibanEndToEnd = "HR" + dr["MZBANKA"].ToString().Trim() + dr["PZBANKA"].ToString();
                        pozivRef = "HR" + dr["MZBANKA"].ToString().Trim() + dr["PZBANKA"].ToString();
                    }
                    else
                    {
                        ibanEndToEnd = "";
                        pozivRef = "";
                    }
                    if (dr["Vrsta"] != DBNull.Value)
                    {
                        hub3_sifraNamjene = dr["Vrsta"].ToString();
                    }
                    else
                    {
                        hub3_sifraNamjene = "";
                    }


                    if (dr["Oznaka"].ToString() == "" && dr["Vrsta"].ToString() != "NITX")
                    {
                        MessageBox.Show("Nisu unesene sve šifre vrste osobnih primanja za sve djelatnike.\n\rUnesite sve vrste da bi mogli generirati SEPA obrazac.");
                        nepotpuno = true;
                        break;
                    }

                    pozivRef = "HR6940002-" + korisnikOIB + "-" + dr["Oznaka"].ToString();

                    Sepa07052015.CreditTransferTransactionInformation10 creditTransaction10 = new Sepa07052015.CreditTransferTransactionInformation10();

                    Sepa07052015.PaymentIdentification1 payment1 = new Sepa07052015.PaymentIdentification1();
                    payment1.EndToEndId = ibanEndToEnd;
                    creditTransaction10.PmtId = payment1;

                    Sepa07052015.AmountType3Choice amount = new Sepa07052015.AmountType3Choice();
                    Sepa07052015.ActiveOrHistoricCurrencyAndAmount account = new Sepa07052015.ActiveOrHistoricCurrencyAndAmount();
                    account.Ccy = oznakaValutePlacanja;
                    account.Value = iznos;

                    amount.InstdAmt = account;
                    creditTransaction10.Amt = amount;

                    partyIdentifier2 = new Sepa07052015.PartyIdentification32_2();
                    partyIdentifier2.Nm = primatelj1;

                    address = new Sepa07052015.PostalAddress6();

                    address.AdrLine = new string[] { primatelj2 };

                    if (primatelj2.Length > 0)
                    {
                        partyIdentifier2.PstlAdr = address;
                    }

                    creditTransaction10.Cdtr = partyIdentifier2;

                    Sepa07052015.CashAccount16_2 cash16 = new Sepa07052015.CashAccount16_2();
                    Sepa07052015.AccountIdentification4Choice_2 accountChoice = new Sepa07052015.AccountIdentification4Choice_2();
                    accountChoice.Item = ibanPrimatelja.Replace(" ", ""); ;
                    cash16.Id = accountChoice;
                    creditTransaction10.CdtrAcct = cash16;

                    creditTransaction10.ChrgBrSpecified = false;

                    Sepa07052015.Purpose2Choice purpose = new Sepa07052015.Purpose2Choice();
                    purpose.Cd = hub3_sifraNamjene;
                    creditTransaction10.Purp = purpose;

                    Sepa07052015.RemittanceInformation5 remittance = new Sepa07052015.RemittanceInformation5();
                    Sepa07052015.StructuredRemittanceInformation7 structureRemittanceinformation = new Sepa07052015.StructuredRemittanceInformation7();
                    Sepa07052015.CreditorReferenceInformation2 credit = new Sepa07052015.CreditorReferenceInformation2();
                    Sepa07052015.CreditorReferenceType2 creditType2 = new Sepa07052015.CreditorReferenceType2();
                    Sepa07052015.CreditorReferenceType1Choice creditType1 = new Sepa07052015.CreditorReferenceType1Choice();
                    creditType1.Cd = Sepa07052015.DocumentType3Code.SCOR;
                    creditType2.CdOrPrtry = creditType1;
                    credit.Tp = creditType2;
                    credit.Ref = pozivRef;
                    structureRemittanceinformation.CdtrRefInf = credit;
                    structureRemittanceinformation.AddtlRmtInf = opisPlacanja;
                    remittance.Item = structureRemittanceinformation;

                    creditTransaction10.RmtInf = remittance;

                    creditTransaction10Field[counter] = creditTransaction10;
                    counter++;
                }
            }

            if (nepotpuno)
                return;

            pay.CdtTrfTxInf = creditTransaction10Field;
            paymentInsturstions[0] = pay;
            customCredeit.GrpHdr = groupHeader;
            customCredeit.PmtInf = paymentInsturstions;
            document.CstmrCdtTrfInitn = customCredeit;

            try
            {
                SaveFileDialog dialog2 = new SaveFileDialog
                {
                    FileName = string.Format("UN.{0}.000{1}.{2}.xml", DateTime.Now.ToString("yyyyMMdd"), brojNaloga, izvorDokumenta),
                    RestoreDirectory = true
                };

                SaveFileDialog dialog = dialog2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dialog.FileName, false, new UTF8Encoding(true)))
                    {
                        //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        ////namespaces.Add("common-types", "http://www.fina.hr/regzap/common-types/v0.6");

                        new XmlSerializer(typeof(Sepa07052015.Document), "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03").Serialize(writer, document);

                        writer.Close();
                    }

                    string xmlText = File.ReadAllText(dialog.FileName);
                    string utf = xmlText.Replace("utf-8", "UTF-8");
                    string xmlns = utf.Remove(49, 99);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlns);

                    doc.Save(dialog.FileName);

                    MessageBox.Show("Datoteka uspješno spremljena u: " + dialog.FileName);
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show("Dogodila se greška prilikom kreiranja datoteke!!!\nKontaktirajete administratora.\n" + greska.Message);
            }
        }

        private void Disketa()
        {
            if (this.dd)
            {
                Interaction.MsgBox("Korištenje moguće samo u obračunu plaća!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                frmRadSaBankama frmRadSaBankama = new frmRadSaBankama();
                frmRadSaBankama.gm_sIDObracun = this.sifraobracuna.Text;
                frmRadSaBankama.gm_sZiro = Conversions.ToString(Operators.AddObject(Operators.AddObject(this.vbdi.Value, "-"), this.ziro.Value));
                frmRadSaBankama.VirmaniDataSet1 = this.VirmaniDataSet1;

                frmRadSaBankama.ShowDialog();
            }
        }

        private void IzradiDatotekuZbrojnogNaloga()
        {
            if (Convert.ToInt32(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1")) == 0)
            {
                MessageBox.Show("Nema označenih virmana!");
                return;
            }

            // Instanciramo korištenje datoteke
            DatotekaZbrojnogNaloga datoteka = new DatotekaZbrojnogNaloga();
            datoteka.InicijalizirajDatoteku();

            // Instanciramo generiranje IBAN-a
            IBAN iban = new IBAN();


            // *************************************************************************
            // Generiranje sloga 300
            // *************************************************************************
            string vrstaNaloga = "1"; // 1 - nacionalna plaćanja u HRK
            string izvorDokumenta = this.VirmaniDataSet1.VIRMANI.Rows[0]["izvordokumenta"].ToString();

            datoteka.GenerirajSLOG_300((DateTime)this.DATUMPREDAJE.Value, vrstaNaloga, izvorDokumenta, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            // -------------------------------------------------------------------------


            // *************************************************************************
            // Generiranje sloga 301
            // *************************************************************************
            string ibanPlatitelja = iban.GenerirajIBANIzBrojaRacuna(VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"].ToString(), true, false);
            string oznakaValutePlacanja = "HRK"; // za vrstu naloga, mora biti HRK
            string ukupanBrojNaloga = VirmaniDataSet1.VIRMANI.Compute("count(idvirman)", "OZNACEN=1").ToString();
            string ukupanIznosNaloga = Decimal.Round(Convert.ToDecimal(VirmaniDataSet1.VIRMANI.Compute("SUM(IZNOS)", "OZNACEN=1")), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty);
            DateTime datumIzvrsenjaNaloga = (DateTime)this.DATUMIZVRSENJA.Value;

            datoteka.GenerirajSLOG_301(ibanPlatitelja, oznakaValutePlacanja, string.Empty, string.Empty, ukupanBrojNaloga, ukupanIznosNaloga, datumIzvrsenjaNaloga, string.Empty);

            // -------------------------------------------------------------------------


            // *************************************************************************
            // Generiranje sloga 309 - jedan redak za SVAKI virman
            // *************************************************************************

            foreach (DataRow dr in VirmaniDataSet1.VIRMANI.Rows)
            {
                if ((bool)dr["OZNACEN"])
                {
                    string ibanPrimatelja = iban.GenerirajIBANIzBrojaRacuna(dr["BROJRACUNAPRI"].ToString(), true, false);
                    string primatelj1 = string.Empty;
                    string primatelj2 = string.Empty;
                    string primatelj3 = string.Empty;
                    string modelZaduzenja = string.Empty;
                    string pozivZaduzenja = string.Empty;
                    string modelOdobrenja = string.Empty;
                    string pozivOdobrenja = string.Empty;
                    string hub3_sifraNamjene = string.Empty;
                    string hub3_hitnost = string.Empty;
                    string opisPlacanja = string.Empty;
                    string iznos = string.Empty;

                    hub3_hitnost = "0";

                    if (dr["PRI1"] != DBNull.Value)
                    {
                        primatelj1 = dr["PRI1"].ToString();
                    }

                    if (dr["PRI2"] != DBNull.Value)
                    {
                        primatelj2 = dr["PRI2"].ToString();
                    }

                    if (dr["PRI3"] != DBNull.Value)
                    {
                        primatelj3 = dr["PRI3"].ToString();
                    }

                    if (dr["MODELZADUZENJA"] != DBNull.Value)
                    {
                        if (!string.IsNullOrWhiteSpace(dr["MODELZADUZENJA"].ToString()))
                        {
                            modelZaduzenja = "HR" + dr["MODELZADUZENJA"].ToString().Trim();
                        }
                    }

                    if (dr["POZIVZADUZENJA"] != DBNull.Value)
                    {
                        pozivZaduzenja = dr["POZIVZADUZENJA"].ToString();
                    }

                    if (dr["MODELODOBRENJA"] != DBNull.Value)
                    {
                        if (!string.IsNullOrWhiteSpace(dr["MODELODOBRENJA"].ToString()))
                        {
                            modelOdobrenja = "HR" + dr["MODELODOBRENJA"].ToString().Trim();
                        }
                    }

                    if (dr["POZIVODOBRENJA"] != DBNull.Value)
                    {
                        pozivOdobrenja = dr["POZIVODOBRENJA"].ToString();
                    }

                    if (dr["HUB3_SIFRANAMJENE"] != DBNull.Value)
                    {
                        hub3_sifraNamjene = dr["HUB3_SIFRANAMJENE"].ToString();
                    }

                    if (dr["HUB3_HITNO"] != DBNull.Value)
                    {
                        if ((bool)dr["HUB3_HITNO"])
                        {
                            hub3_hitnost = "1";
                        }
                    }

                    if (dr["OPISPLACANJAVIRMAN"] != DBNull.Value)
                    {
                        opisPlacanja = dr["OPISPLACANJAVIRMAN"].ToString();
                    }

                    if (dr["IZNOS"] != DBNull.Value)
                    {
                        iznos = Decimal.Round(Convert.ToDecimal(dr["IZNOS"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty);
                    }

                    datoteka.GenerirajSLOG_309(ibanPrimatelja, primatelj1, primatelj2, primatelj3, string.Empty,
                                               modelZaduzenja, pozivZaduzenja, hub3_sifraNamjene, opisPlacanja, iznos,
                                               modelOdobrenja, pozivOdobrenja, string.Empty, string.Empty, string.Empty,
                                               string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                               hub3_hitnost, string.Empty, string.Empty);

                }
            }


            // -------------------------------------------------------------------------


            // *************************************************************************
            // Generiranje sloga 399
            // *************************************************************************
            datoteka.GenerirajSLOG_399(string.Empty);



            // SPREMANJE datoteke

            datoteka.SpremiDatoteku((DateTime)this.DATUMPREDAJE.Value);
        }

        [Obsolete("Ova funkcija se više NE koristi od 01.01.2013!")]
        private void DisketaFina()
        {
            if (Operators.ConditionalCompareObjectEqual(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1"), 0, false))
            {
                Interaction.MsgBox("Nema označenih virmana!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                Encoding encoding = Encoding.GetEncoding(0x4e2);
                string path = "MM" + Strings.Format(RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value), "ddMMyy") + ".zap";
                using (IDisposable obj2 = new StreamWriter(path, false, encoding))
                {
                    this.Fina_Slog0((StreamWriter)obj2);
                    this.Fina_Slog9((StreamWriter)obj2);
                    this.Fina_Slog1((StreamWriter)obj2);
                    NewLateBinding.LateCall(obj2, null, "Close", new object[0], null, null, null, true);
                }
                Snimi_Izlaznu_datoteku_Za_Finu(path);
            }
        }

        [LocalCommandHandler("SnimiDatoteku")]
        public void DisketaFinaHandler(object sender, EventArgs e)
        {
            this.IzradiDatotekuZbrojnogNaloga();
        }

        [LocalCommandHandler("DisketaHZZO")]
        public void DisketaHZZOCommandHandler(object sender, EventArgs e)
        {
            invalidi = false;
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = true,
                Title = "Izrada diskete za HZZO (rekapitulacija olakšica)",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            DatotekaHZZO smartPart = this.Controller.WorkItem.Items.AddNew<DatotekaHZZO>();
            smartPart.Obracun = Conversions.ToString(this.sifraobracuna.Value);
            workspace.Show(smartPart, smartPartInfo);
        }

        private void Dodaj_Oznake_Svima()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    current["oznacen"] = true;
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            try
            {
                this.davirmani.Update(this.VirmaniDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;

            }
        }

        private void Fina_Slog0(StreamWriter outputStream)
        {
            outputStream.Write(Strings.Space(0x12));
            string str = (DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["PLA1"]), "") + DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["PLA2"]), "") + DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["PLA3"]), "")).PadRight(60);
            outputStream.Write(str);
            str = Strings.Format(RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value), "ddMMyy");
            outputStream.Write(str);
            outputStream.Write("000");
            outputStream.Write(Strings.Space(7));
            outputStream.Write(Strings.Space(1));
            outputStream.Write(Strings.Space(2));
            outputStream.Write(DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["izvordokumenta"]), "   "));
            str = Strings.Left(DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"]), "0000000"), 7);
            outputStream.Write(str.PadRight(7));
            str = Strings.Mid(DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"]), "000000000"), 9);
            outputStream.Write(str.PadRight(0x12));
            outputStream.Write(Strings.Space(0x74));
            str = Strings.Format(RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value), "ddMMyyyy");
            outputStream.Write(str);
            outputStream.WriteLine("0");
        }

        private void Fina_Slog1(StreamWriter izlaznaDatoteka)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["OZNACEN"], true, false))
                    {
                        izlaznaDatoteka.Write(Strings.Space(0x12));
                        string expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI1"]), "") + DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI2"]), "") + DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI3"]), "");
                        if (Strings.Len(expression) > 60)
                        {
                            expression = Strings.Left(expression, 60);
                        }
                        else
                        {
                            expression = expression.PadRight(60);
                        }
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELZADUZENJA"]), Strings.Space(2));
                        if (Strings.Len(expression) > 2)
                        {
                            expression = Strings.Left(expression, 2);
                        }
                        else
                        {
                            expression = expression.PadRight(2);
                        }
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVZADUZENJA"]), Strings.Space(0x16));
                        if (Strings.Len(expression) > 0x16)
                        {
                            expression = Strings.Left(expression, 0x16);
                        }
                        else
                        {
                            expression = expression.PadRight(0x16);
                        }
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["OPISPLACANJAVIRMAN"]), Strings.Space(0x24));
                        if (Strings.Len(expression) > 0x24)
                        {
                            expression = Strings.Left(expression, 0x24);
                        }
                        else
                        {
                            expression = expression.PadRight(0x24);
                        }
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["SIFRAOPISAPLACANJAVIRMAN"]), Strings.Space(2));
                        if (Strings.Len(expression) > 2)
                        {
                            expression = Strings.Left(expression, 2);
                        }
                        else
                        {
                            expression = expression.PadRight(2);
                        }
                        izlaznaDatoteka.Write(expression);
                        izlaznaDatoteka.Write(Strings.Space(4));
                        expression = DB.DoubleToStringKRACI(Conversions.ToDecimal(current["IZNOS"]));
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELODOBRENJA"]), Strings.Space(2));
                        if (Strings.Len(expression) > 2)
                        {
                            expression = Strings.Left(expression, 2);
                        }
                        else
                        {
                            expression = expression.PadRight(2);
                        }
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVODOBRENJA"]), Strings.Space(0x16));
                        if (Strings.Len(expression) > 0x16)
                        {
                            expression = Strings.Left(expression, 0x16);
                        }
                        else
                        {
                            expression = expression.PadRight(0x16);
                        }
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(RuntimeHelpers.GetObjectValue(current["BROJRACUNAPRI"]), Strings.Space(7));
                        if (Strings.Len(expression) > 7)
                        {
                            expression = Strings.Left(expression, 7);
                        }
                        else
                        {
                            expression = expression.PadRight(7);
                        }
                        izlaznaDatoteka.Write(expression);
                        expression = DB.N2T(Strings.Mid(Conversions.ToString(current["BROJRACUNAPRI"]), 9), Strings.Space(9));
                        izlaznaDatoteka.Write(expression.PadRight(0x12));
                        izlaznaDatoteka.Write(Strings.Space(2));
                        izlaznaDatoteka.Write(Strings.Space(0x29));
                        izlaznaDatoteka.WriteLine("1");
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

        private void Fina_Slog9(StreamWriter outputFile)
        {
            outputFile.Write(Strings.Space(0x12));
            string str = (DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["PLA1"]), "") + DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["PLA2"]), "") + DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["PLA3"]), "")).PadRight(60);
            outputFile.Write(str);
            str = DB.DoubleToString(Conversions.ToDecimal(this.VirmaniDataSet1.VIRMANI.Compute("SUM(IZNOS)", "OZNACEN=1")));
            outputFile.Write(str);
            str = Conversions.ToInteger(this.VirmaniDataSet1.VIRMANI.Compute("count(idvirman)", "OZNACEN=1")).ToString("00000;00000;00000");
            outputFile.Write(str);
            str = Strings.Left(DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"]), "0000000"), 7);
            outputFile.Write(str.PadRight(7));
            str = Strings.Mid(DB.N2T(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"]), "000000000"), 9);
            outputFile.Write(str.PadRight(0x12));
            str = Strings.Format(RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value), "ddMMyyyy");
            outputFile.Write(str);
            outputFile.Write(Strings.Space(0x76));
            outputFile.WriteLine("9");
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [LocalCommandHandler("HUB11lASER")]
        public void HUB11lASERHandler(object sender, EventArgs e)
        {
            invalidi = false;
            this.Hub11Laserski();
        }

        private void Hub11Laserski()
        {
            DataSet ds = this.VirmaniDataSet1;
            this.VirmaniDataSet1 = (VIRMANIDataSet)ds;
            new frmPregledVirmana(ref ds, this.CheckBox1.Checked, Conversions.ToDate(this.DATUMPREDAJE.Value), Conversions.ToDate(this.DATUMIZVRSENJA.Value)).ShowDialog();
        }

        private void HUB11Matricni()
        {
            if (Operators.ConditionalCompareObjectEqual(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1"), 0, false))
            {
                Interaction.MsgBox("Nema označenih virmana!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                IEnumerator enumerator = null;
                Encoding encoding = Encoding.GetEncoding(0x354);
                StreamWriter writer = new StreamWriter("virmani.txt", false, encoding);
                try
                {
                    enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        if (Operators.ConditionalCompareObjectEqual(current["oznacen"], true, false))
                        {
                            string str = string.Empty;
                            string str2 = string.Empty;
                            string str10 = string.Empty;
                            string str7 = Strings.Format(RuntimeHelpers.GetObjectValue(current["iznos"]), "n");
                            str7 = ("* " + str7).PadLeft(14);
                            string str11 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla1"]), Strings.Space(0x15));
                            string str12 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla2"]), Strings.Space(0x15));
                            string kojistring = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla3"]), Strings.Space(0x15));
                            string str14 = DB.N2T(RuntimeHelpers.GetObjectValue(current["brojracunapla"]), Strings.Space(0x12));
                            string str15 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELZADUZENJA"]), Strings.Space(2));
                            string str16 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVZADUZENJA"]), Strings.Space(0x15));
                            string str4 = DB.N2T(RuntimeHelpers.GetObjectValue(current["BROJRACUNAPRI"]), Strings.Space(0x12));
                            string str5 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELODOBRENJA"]), Strings.Space(2));
                            string str6 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVODOBRENJA"]), Strings.Space(0x15));
                            string str9 = DB.N2T(RuntimeHelpers.GetObjectValue(current["OPISPLACANJAVIRMAN"]), Strings.Space(0x24));
                            string str8 = DB.N2T(RuntimeHelpers.GetObjectValue(current["SIFRAOPISAPLACANJAVIRMAN"]), Strings.Space(2));
                            str11 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla1"]), Strings.Space(0x15));
                            str12 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla2"]), Strings.Space(0x15));
                            kojistring = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla3"]), Strings.Space(0x15));
                            str14 = DB.N2T(RuntimeHelpers.GetObjectValue(current["brojracunapla"]), Strings.Space(0x12));
                            str15 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELZADUZENJA"]), Strings.Space(2));
                            str16 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVZADUZENJA"]), Strings.Space(0x15));
                            string str17 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI1"]), Strings.Space(0x15));
                            string str18 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI2"]), Strings.Space(0x15));
                            string str19 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI3"]), Strings.Space(0x15));
                            if (str17.Length < 0x15)
                            {
                                str17 = str17 + Strings.Space(0x15 - str17.Length);
                            }
                            if (str18.Length < 0x15)
                            {
                                str18 = str18 + Strings.Space(0x15 - str18.Length);
                            }
                            if (str19.Length < 0x15)
                            {
                                str19 = str19 + Strings.Space(0x15 - str19.Length);
                            }
                            str4 = DB.N2T(RuntimeHelpers.GetObjectValue(current["BROJRACUNAPRI"]), Strings.Space(0x12));
                            str5 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELODOBRENJA"]), Strings.Space(2));
                            str6 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVODOBRENJA"]), Strings.Space(0x15));
                            str9 = DB.N2T(RuntimeHelpers.GetObjectValue(current["OPISPLACANJAVIRMAN"]), Strings.Space(1));
                            str8 = DB.N2T(RuntimeHelpers.GetObjectValue(current["SIFRAOPISAPLACANJAVIRMAN"]), Strings.Space(2));
                            if (this.CheckBox1.Checked)
                            {
                                str = Conversions.ToString(current["DATUMVALUTE"]);
                                str2 = Conversions.ToString(current["DATUMPODNOSENJA"]);
                            }
                            else
                            {
                                str = "";
                                str2 = "";
                            }
                            str17 = Strings.Left(str17, 0x15);
                            str18 = Strings.Left(str18, 0x15);
                            str11 = Strings.Left(str11, 0x15);
                            str12 = Strings.Left(str12, 0x15);
                            str15 = Strings.Left(str15, 2);
                            str5 = Strings.Left(str5, 2);
                            str11 = DB.Ko852to437(str11);
                            str12 = DB.Ko852to437(str12);
                            kojistring = DB.Ko852to437(kojistring);
                            str17 = DB.Ko852to437(str17);
                            str18 = DB.Ko852to437(str18);
                            str19 = DB.Ko852to437(str19);
                            str9 = DB.Ko852to437(str9);
                            writer.WriteLine("\x001bM");
                            writer.WriteLine();
                            writer.WriteLine();
                            writer.WriteLine(Strings.Space(0x34) + str7 + Strings.Space(15) + str7);
                            writer.WriteLine();
                            writer.WriteLine(Strings.Space(2) + str11 + Strings.Space(2) + str15 + Strings.Space(6) + str14 + Strings.Space(20) + Strings.Trim(str11));
                            writer.WriteLine(Strings.Space(2) + str12);
                            writer.WriteLine(Strings.Space(2) + kojistring + Strings.Space(2) + str16 + Strings.Space(0x19) + str15 + Strings.Space(3) + Strings.Trim(str16));
                            writer.WriteLine();
                            writer.WriteLine(Strings.Space(2) + str17 + Strings.Space(2) + str5 + Strings.Space(6) + str4 + Strings.Space(20) + Strings.Trim(str4));
                            writer.WriteLine(Strings.Space(2) + str18);
                            writer.WriteLine(Strings.Space(2) + str19 + Strings.Space(2) + str6 + Strings.Space(0x19) + str5 + Strings.Space(2) + Strings.Trim(str6));
                            writer.WriteLine();
                            writer.WriteLine(Strings.Space(12) + str8 + Strings.Space(5) + str9 + Strings.Space(1) + Strings.Trim(str10));
                            writer.WriteLine();
                            writer.WriteLine(Strings.Space(5) + str);
                            writer.WriteLine();
                            writer.WriteLine(Strings.Space(5) + str2);
                            writer.WriteLine();
                            writer.WriteLine();
                            writer.WriteLine();
                            writer.WriteLine();
                            writer.WriteLine();
                            writer.WriteLine();
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
                writer.Close();
                PrintDialog dialog = new PrintDialog
                {
                    PrinterSettings = new PrinterSettings()
                };
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DOSPrinter.SendFileToPrinter(dialog.PrinterSettings.PrinterName, "virmani.txt");
                }
            }
        }

        [LocalCommandHandler("HUB11matricni")]
        public void HUB11Matricni(object sender, EventArgs e)
        {
            invalidi = false;
            this.HUB11Matricni();
        }

        private void HUB1Matricni()
        {
            if (Operators.ConditionalCompareObjectEqual(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1"), 0, false))
            {
                Interaction.MsgBox("Nema označenih virmana!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                Encoding encoding = Encoding.GetEncoding(0x354);
                using (StreamWriter writer = new StreamWriter("virmani.txt", false, encoding))
                {
                    IEnumerator enumerator = null;
                    try
                    {
                        enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            if (Operators.ConditionalCompareObjectEqual(current["oznacen"], true, false))
                            {
                                string str2 = string.Empty;
                                string str3 = string.Empty;
                                string str7 = Strings.Format(DB.N20(RuntimeHelpers.GetObjectValue(current["iznos"])), "n");
                                str7 = ("* " + str7).PadLeft(14);
                                string str = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla1"]), Strings.Space(0x15)).PadRight(0x15);
                                string str12 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla2"]), Strings.Space(0x15)).PadRight(0x15);
                                string kojistring = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla3"]), Strings.Space(0x15)).PadRight(0x15);
                                string str14 = DB.N2T(RuntimeHelpers.GetObjectValue(current["brojracunapla"]), Strings.Space(0x12));
                                string str15 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELZADUZENJA"]), Strings.Space(2));
                                string str16 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVZADUZENJA"]), Strings.Space(0x15));
                                string str17 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI1"]), Strings.Space(0x15)).PadRight(0x15);
                                string str18 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI2"]), Strings.Space(0x15)).PadRight(0x15);
                                string str19 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI3"]), Strings.Space(0x15)).PadRight(0x15);
                                string str4 = DB.N2T(RuntimeHelpers.GetObjectValue(current["BROJRACUNAPRI"]), Strings.Space(0x12));
                                string str5 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELODOBRENJA"]), Strings.Space(2));
                                string str6 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVODOBRENJA"]), Strings.Space(0x15));
                                string str9 = DB.N2T(RuntimeHelpers.GetObjectValue(current["OPISPLACANJAVIRMAN"]), Strings.Space(0x24));
                                string str8 = DB.N2T(RuntimeHelpers.GetObjectValue(current["SIFRAOPISAPLACANJAVIRMAN"]), Strings.Space(2));
                                str14 = DB.N2T(RuntimeHelpers.GetObjectValue(current["brojracunapla"]), Strings.Space(0x12));
                                str15 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELZADUZENJA"]), Strings.Space(2));
                                str16 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVZADUZENJA"]), Strings.Space(0x15));
                                str4 = DB.N2T(RuntimeHelpers.GetObjectValue(current["BROJRACUNAPRI"]), Strings.Space(0x12));
                                str5 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELODOBRENJA"]), Strings.Space(2));
                                str6 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVODOBRENJA"]), Strings.Space(0x15));
                                str9 = DB.N2T(RuntimeHelpers.GetObjectValue(current["OPISPLACANJAVIRMAN"]), Strings.Space(1));
                                str8 = DB.N2T(RuntimeHelpers.GetObjectValue(current["SIFRAOPISAPLACANJAVIRMAN"]), Strings.Space(2));
                                if (this.CheckBox1.Checked)
                                {
                                    str2 = Conversions.ToString(current["DATUMVALUTE"]);
                                    str3 = Conversions.ToString(current["DATUMPODNOSENJA"]);
                                }
                                else
                                {
                                    str2 = "";
                                    str3 = "";
                                }
                                str17 = Strings.Left(str17, 0x15);
                                str18 = Strings.Left(str18, 0x15);
                                str = Strings.Left(str, 0x15);
                                str12 = Strings.Left(str12, 0x15);
                                str15 = Strings.Left(str15, 2);
                                str5 = Strings.Left(str5, 2);
                                str = DB.Ko852to437(str);
                                str12 = DB.Ko852to437(str12);
                                kojistring = DB.Ko852to437(kojistring);
                                str17 = DB.Ko852to437(str17);
                                str18 = DB.Ko852to437(str18);
                                str19 = DB.Ko852to437(str19);
                                str9 = DB.Ko852to437(str9);
                                writer.WriteLine("\x001bM");
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine(Strings.Space(0x34) + str7);
                                writer.WriteLine();
                                writer.WriteLine(Strings.Space(2) + str + Strings.Space(2) + str15 + Strings.Space(6) + str14);
                                writer.WriteLine(Strings.Space(2) + str12);
                                writer.WriteLine(Strings.Space(2) + kojistring + Strings.Space(8) + str16);
                                writer.WriteLine();
                                writer.WriteLine(Strings.Space(2) + str17 + Strings.Space(2) + str5 + Strings.Space(6) + str4);
                                writer.WriteLine(Strings.Space(2) + str18);
                                writer.WriteLine(Strings.Space(2) + str19 + Strings.Space(8) + str6);
                                writer.WriteLine();
                                writer.WriteLine(Strings.Space(12) + str8 + Strings.Space(5) + str9);
                                writer.WriteLine();
                                writer.WriteLine(Strings.Space(5) + str2);
                                writer.WriteLine();
                                writer.WriteLine(Strings.Space(5) + str3);
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
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
                    writer.Close();
                }
                PrintDialog dialog2 = new PrintDialog
                {
                    PrinterSettings = new PrinterSettings()
                };
                PrintDialog dialog = dialog2;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DOSPrinter.SendFileToPrinter(dialog.PrinterSettings.PrinterName, "virmani.txt");
                }
            }
        }

        [LocalCommandHandler("HUB1MATRICNI")]
        public void HUB1Matricni(object sender, EventArgs e)
        {
            invalidi = false;
            this.HUB1Matricni();
        }

        [LocalCommandHandler("HUB3Alaser")]
        public void HUB3AlaserHandler(object sender, EventArgs e)
        {
            this.HUB3Alaserski();
            UpdateFlagaVirmani();
        }

        [LocalCommandHandler("HUB3matricni")]
        public void HUB3matricniHandler(object sender, EventArgs e)
        {
            invalidi = false;
            this.HUB3matricni();
            UpdateFlagaVirmani();
        }

        private void HUB3Alaserski()
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);

            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "HUB 3A virman",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };


            IBAN iban = new IBAN();

            //Pomoćni DataSet koji nam služi za prikaz IBAN-a, pošto na trenutnom ne smijemo raditi izmjene
            IBANDataSet dsIBAN = new IBANDataSet();

            DataRow korisnik_level1 = KorisnikDataSet1.Tables["KorisnikLevel1"].Select("IDZIRO = " + (int)UltraCombo1.Value)[0];

            // IBAN
            foreach (DataRow drRow in this.VirmaniDataSet1.VIRMANI.Rows)
            {
                if (drRow["BROJRACUNAPRI"] != DBNull.Value && drRow["BROJRACUNAPLA"] != DBNull.Value)
                {
                    if (sifraobracuna.Tag == "RAZNO")
                    {
                        dsIBAN.IBAN.AddIBANRow(int.Parse(drRow["IDVIRMAN"].ToString()), drRow["BROJRACUNAPRI"].ToString(),
                            iban.GenerirajIBANIzBrojaRacuna(drRow["BROJRACUNAPLA"].ToString(), false, true));
                    }
                    else
                    {
                        dsIBAN.IBAN.AddIBANRow(int.Parse(drRow["IDVIRMAN"].ToString()),
                            iban.GenerirajIBANIzBrojaRacuna(drRow["BROJRACUNAPRI"].ToString(), false, true),
                            iban.GenerirajIBANIzBrojaRacuna(drRow["BROJRACUNAPLA"].ToString(), false, true));
                    }
                }

                //16.02.2015 gleda dali treba ispisivati datum na virmanima
                //24.02.2015 ukoliko se promjeni platittelj da se manifestira i na vrimanima
                drRow.BeginEdit();
                if (!CheckBox1.Checked)
                {
                    drRow["DATUMPODNOSENJA"] = DBNull.Value;
                    drRow["DATUMVALUTE"] = DBNull.Value;
                }
                else
                {
                    drRow["DATUMPODNOSENJA"] = DATUMPREDAJE.Value;
                    drRow["DATUMVALUTE"] = DATUMIZVRSENJA.Value;
                }

                if ((drRow["BROJRACUNAPLA"].ToString() == "neprimjenjivo" && drRow["SIFRAOBRACUNAVIRMAN"].ToString().Length < 5) || (drRow["BROJRACUNAPLA"].ToString() == "" && drRow["SIFRAOBRACUNAVIRMAN"].ToString() == "xxx"))
                {
                }
                else
                {
                    drRow["pla1"] = korisnik_level1["NAZIVZIRO"].ToString();
                    drRow["pla2"] = korisnik_level1["ULICAZIRO"].ToString();
                    drRow["pla3"] = korisnik_level1["MJESTOZIRO"].ToString();
                }

                drRow.EndEdit();
                drRow.AcceptChanges();

            }

            if (uf)
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptVirmaniUF.rpt");

                // Set connection string from config in existing LogonProperties
                //document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                //document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                //document.DataSourceConnections[0].IntegratedSecurity = false;
            }
            else if (obracunRazno)
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptVirmaniRazno.rpt");
            }
            else
            {
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptHUB3AVirman.rpt");
            }

            // Ucitavanje margina iz regedita
            PageMargins pageMargins = new PageMargins();
            if (!string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Margine))
            {
                Array margine = Mipsed7.Core.ApplicationDatabaseInformation.Margine.Split(';');
                pageMargins.topMargin = Convert.ToInt32(((string[])(margine))[0]);
                pageMargins.bottomMargin = Convert.ToInt32(((string[])(margine))[1]);
                pageMargins.leftMargin = Convert.ToInt32(((string[])(margine))[2]);
                pageMargins.rightMargin = Convert.ToInt32(((string[])(margine))[3]);

                document.PrintOptions.ApplyPageMargins(pageMargins);
            }

            // Punimo izvještaj sa podacima
            document.Database.Tables[0].SetDataSource(this.VirmaniDataSet1);
            document.Database.Tables[1].SetDataSource(dsIBAN);

            if (uf)
            {
                string OIBUstanova = GetOIBUstanova(VirmaniWorkItemUser.OsobeIzObracuna.ustanova);

                document.SetParameterValue("OIBUstanova", OIBUstanova);
            }
            else if (obracunRazno)
            {
                string oibKorisnik = KorisnikDataSet1.Tables["Korisnik"].Rows[0]["KORISNIKOIB"].ToString();

                document.SetParameterValue("OIBUstanova", oibKorisnik);
            }

            if (uf || obracunRazno)
            {
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Activate();
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                //hrvoje ispis virmana u pdf zbog toga jer direktno iz cristal reporta ne radi dobro
                sfdVirmani.FileName = "Virmani.pdf";
                string putanja = string.Empty;
                sfdVirmani.Filter = "(*.pdf)|*.pdf|All Files (*.*)|*.*";
                if (sfdVirmani.ShowDialog() == DialogResult.OK)
                {
                    document.ExportToDisk(ExportFormatType.PortableDocFormat, sfdVirmani.FileName);
                }
                try
                {
                    System.Diagnostics.Process.Start(sfdVirmani.FileName);
                }
                catch { }
            }
        }

        private string GetOIBUstanova(int id)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Select OIB From UF_Ustanova Where ID = @ID";
            sqlUpit.Parameters.Add(new SqlParameter("@ID", id));

            string oib = string.Empty;

            try
            {
                oib = sqlUpit.ExecuteScalar().ToString();
            }
            catch
            { }
            return oib;
        }


        private void UpdateFlagaVirmani()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_Obracun set Virmani = 'true' Where ID = @ID";
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            { }
        }

        private void HUB3matricni()
        {
            if (Operators.ConditionalCompareObjectEqual(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1"), 0, false))
            {
                Interaction.MsgBox("Nema označenih virmana!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                Encoding encoding = Encoding.GetEncoding(0x354);
                using (StreamWriter writer = new StreamWriter("virmani.txt", false, encoding))
                {
                    IEnumerator enumerator = null;
                    try
                    {
                        IBAN iban = new IBAN();

                        enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            if (Operators.ConditionalCompareObjectEqual(current["oznacen"], true, false))
                            {
                                string datum1 = string.Empty;
                                string datum2 = string.Empty;

                                string iznos = Strings.Format(DB.N20(RuntimeHelpers.GetObjectValue(current["iznos"])), "n");
                                iznos = "=" + iznos;
                                iznos = iznos.PadLeft(15);

                                string teret1 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla1"]), Strings.Space(21)).PadRight(21);
                                string teret2 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla2"]), Strings.Space(21)).PadRight(21);
                                string TERET3 = DB.N2T(RuntimeHelpers.GetObjectValue(current["pla3"]), Strings.Space(21)).PadRight(21);

                                string teretbroj = DB.N2T(RuntimeHelpers.GetObjectValue(current["brojracunapla"]), Strings.Space(18));
                                string teretpoz1 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELZADUZENJA"]), Strings.Space(4));
                                string teretpoz2 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVZADUZENJA"]), Strings.Space(21));

                                string ukorist1 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI1"]), Strings.Space(21)).PadRight(21);
                                string ukorist2 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI2"]), Strings.Space(21)).PadRight(21);
                                string UKORIST3 = DB.N2T(RuntimeHelpers.GetObjectValue(current["PRI3"]), Strings.Space(21)).PadRight(21);

                                string korbroj = DB.N2T(RuntimeHelpers.GetObjectValue(current["BROJRACUNAPRI"]), Strings.Space(18));
                                string korpoz1 = DB.N2T(RuntimeHelpers.GetObjectValue(current["MODELODOBRENJA"]), Strings.Space(4));
                                string korpoz2 = DB.N2T(RuntimeHelpers.GetObjectValue(current["POZIVODOBRENJA"]), Strings.Space(21));

                                string svrha1 = DB.N2T(RuntimeHelpers.GetObjectValue(current["OPISPLACANJAVIRMAN"]), Strings.Space(36));

                                string sifraNamjene = DB.N2T(RuntimeHelpers.GetObjectValue(current["HUB3_SIFRANAMJENE"]), Strings.Space(1));
                                string hitno = DB.N2T(RuntimeHelpers.GetObjectValue(current["HUB3_HITNO"]), Strings.Space(1));
                                string valutaPlacanja = DB.N2T("HRK", Strings.Space(3));

                                hitno = " ";

                                if (current["HUB3_HITNO"] != DBNull.Value)
                                    if ((bool)current["HUB3_HITNO"])
                                        hitno = "X";

                                if (this.CheckBox1.Checked)
                                {
                                    datum1 = Conversions.ToString(current["DATUMVALUTE"]);
                                    datum2 = Conversions.ToString(current["DATUMPODNOSENJA"]);
                                }
                                else
                                {
                                    datum1 = "";
                                    datum2 = "";
                                }

                                ukorist1 = Strings.Left(ukorist1, 21);
                                ukorist2 = Strings.Left(ukorist2, 21);
                                teret1 = Strings.Left(teret1, 21);
                                teret2 = Strings.Left(teret2, 21);


                                if (!string.IsNullOrWhiteSpace(teretpoz1.Trim()))
                                    teretpoz1 = "HR" + teretpoz1;


                                if (!string.IsNullOrWhiteSpace(korpoz1.Trim()))
                                    korpoz1 = "HR" + korpoz1;

                                teretpoz1 = Strings.Left(teretpoz1, 4);
                                korpoz1 = Strings.Left(korpoz1, 4);

                                teret1 = DB.Ko852to437(teret1);
                                teret2 = DB.Ko852to437(teret2);
                                TERET3 = DB.Ko852to437(TERET3);
                                ukorist1 = DB.Ko852to437(ukorist1);
                                ukorist2 = DB.Ko852to437(ukorist2);
                                UKORIST3 = DB.Ko852to437(UKORIST3);
                                svrha1 = DB.Ko852to437(svrha1);




                                // writer.WriteLine("\x001bM");
                                // ovo je poseban znak + M (ovo je očito znak da je novi virman u pitanju)
                                // writer.Write(Strings.Chr(27) + Strings.Chr(77));
                                writer.Write("\x001bM");
                                writer.Write(Strings.Space(25) + hitno + Strings.Space(7) + valutaPlacanja + Strings.Space(15) + iznos); // Strings.Space(52) + iznos
                                writer.WriteLine();

                                // PLATITELJ
                                writer.WriteLine(teret1 + Strings.Space(12) + iban.GenerirajIBANIzBrojaRacuna(teretbroj, false, true));
                                writer.WriteLine(teret2);
                                writer.WriteLine(TERET3 + Strings.Space(1) + teretpoz1 + Strings.Space(5) + teretpoz2);

                                // PRIMATELJ - IBAN
                                writer.WriteLine(Strings.Space(12) + iban.GenerirajIBANIzBrojaRacuna(korbroj, false, true));
                                writer.WriteLine();
                                writer.WriteLine(ukorist1 + Strings.Space(1) + korpoz1 + Strings.Space(5) + korpoz2);
                                writer.WriteLine(ukorist2 + Strings.Space(15) + svrha1);
                                writer.WriteLine(UKORIST3 + Strings.Space(1) + sifraNamjene);
                                writer.WriteLine();
                                writer.WriteLine(Strings.Space(22) + datum1); // Strings.Space(12) + sifra1 + Strings.Space(5) - šifra opisa plaćanja
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
                                writer.WriteLine();
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
                    writer.Close();
                }
                PrintDialog dialog2 = new PrintDialog
                {
                    PrinterSettings = new PrinterSettings()
                };
                PrintDialog dialog = dialog2;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DOSPrinter.SendFileToPrinter(dialog.PrinterSettings.PrinterName, "virmani.txt");
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TIPISPLATE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTIPISPLATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIV");
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KORISNIKLevel1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKORISNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZIRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVZIRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ULICAZIRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESTOZIRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIKORISNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZIROKORISNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAIZVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVIZVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZIPRIREZZAJEDNICKI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POZIVIZADUZENJA");
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VIRMANI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVIRMAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOBRACUNAVIRMAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLA1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLA2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLA3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJRACUNAPLA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MODELZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POZIVZADUZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRI1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRI2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRI3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJRACUNAPRI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MODELODOBRENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POZIVODOBRENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAVIRMAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAVIRMAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMVALUTE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMPODNOSENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZVORDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OZNACEN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAMJENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HUB3_SIFRANAMJENE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HUB3_HITNO");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance(17802860);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("ba0d6b83-99c6-4890-8765-e653aacf2034"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("1641d499-4e65-490f-ab5d-307a5e1b395d"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("ba0d6b83-99c6-4890-8765-e653aacf2034"), -1);
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ButtonPrimjeniBrojZaduzenja = new Infragistics.Win.Misc.UltraButton();
            this.ultraComboTipIsplate = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.pnbzMjesecGodina = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.pnbzOIB = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.pnbzBrojModela = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.mb = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.vbdi = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ziro = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.pla3 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.pla2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.pla1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.izvordokumenta = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraCombo1 = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.KorisnikDataSet1 = new Placa.KORISNIKDataSet();
            this.poreziprirez = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.CheckBox1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pozivzaduzenja = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.DATUMIZVRSENJA = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.DATUMPREDAJE = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.sifraobracuna = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.VirmaniDataSet1 = new Placa.VIRMANIDataSet();
            this.VirmaniUF = new DataTable();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Virmani_Fill_Panel = new System.Windows.Forms.Panel();
            this.UltraDockManager2 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._VirmaniUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._VirmaniUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._VirmaniUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._VirmaniUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._VirmaniAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.sfdVirmani = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboTipIsplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCombo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KorisnikDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATUMIZVRSENJA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATUMPREDAJE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VirmaniDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            this.Virmani_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager2)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.ButtonPrimjeniBrojZaduzenja);
            this.UltraGroupBox1.Controls.Add(this.ultraComboTipIsplate);
            this.UltraGroupBox1.Controls.Add(this.pnbzMjesecGodina);
            this.UltraGroupBox1.Controls.Add(this.pnbzOIB);
            this.UltraGroupBox1.Controls.Add(this.pnbzBrojModela);
            this.UltraGroupBox1.Controls.Add(this.ultraLabel8);
            this.UltraGroupBox1.Controls.Add(this.UltraButton1);
            this.UltraGroupBox1.Controls.Add(this.mb);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel6);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel4);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.vbdi);
            this.UltraGroupBox1.Controls.Add(this.ziro);
            this.UltraGroupBox1.Controls.Add(this.pla3);
            this.UltraGroupBox1.Controls.Add(this.pla2);
            this.UltraGroupBox1.Controls.Add(this.pla1);
            this.UltraGroupBox1.Controls.Add(this.izvordokumenta);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo1);
            this.UltraGroupBox1.Controls.Add(this.poreziprirez);
            this.UltraGroupBox1.Controls.Add(this.CheckBox1);
            this.UltraGroupBox1.Controls.Add(this.pozivzaduzenja);
            this.UltraGroupBox1.Controls.Add(this.DATUMIZVRSENJA);
            this.UltraGroupBox1.Controls.Add(this.DATUMPREDAJE);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel7);
            this.UltraGroupBox1.Controls.Add(this.sifraobracuna);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(1222, 169);
            this.UltraGroupBox1.TabIndex = 8;
            this.UltraGroupBox1.UseAppStyling = false;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ButtonPrimjeniBrojZaduzenja
            // 
            this.ButtonPrimjeniBrojZaduzenja.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.ButtonPrimjeniBrojZaduzenja.Location = new System.Drawing.Point(607, 182);
            this.ButtonPrimjeniBrojZaduzenja.Name = "ButtonPrimjeniBrojZaduzenja";
            this.ButtonPrimjeniBrojZaduzenja.Size = new System.Drawing.Size(213, 23);
            this.ButtonPrimjeniBrojZaduzenja.TabIndex = 41;
            this.ButtonPrimjeniBrojZaduzenja.Text = "Primjeni poziv na broj zaduženja";
            this.ButtonPrimjeniBrojZaduzenja.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ButtonPrimjeniBrojZaduzenja.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ButtonPrimjeniBrojZaduzenja.Click += new System.EventHandler(this.ButtonPrimjeniBrojZaduzenja_Click);
            // 
            // ultraComboTipIsplate
            // 
            this.ultraComboTipIsplate.AllowNull = Infragistics.Win.DefaultableBoolean.True;
            this.ultraComboTipIsplate.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance31.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance31;
            editorButton1.Text = "...";
            this.ultraComboTipIsplate.ButtonsRight.Add(editorButton1);
            this.ultraComboTipIsplate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            appearance42.BackColor = System.Drawing.SystemColors.Window;
            appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ultraComboTipIsplate.DisplayLayout.Appearance = appearance42;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 65;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 300;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.ultraComboTipIsplate.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraComboTipIsplate.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraComboTipIsplate.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraComboTipIsplate.DisplayLayout.GroupByBox.Appearance = appearance53;
            appearance63.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraComboTipIsplate.DisplayLayout.GroupByBox.BandLabelAppearance = appearance63;
            this.ultraComboTipIsplate.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance64.BackColor2 = System.Drawing.SystemColors.Control;
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance64.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraComboTipIsplate.DisplayLayout.GroupByBox.PromptAppearance = appearance64;
            this.ultraComboTipIsplate.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraComboTipIsplate.DisplayLayout.MaxRowScrollRegions = 1;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            appearance65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraComboTipIsplate.DisplayLayout.Override.ActiveCellAppearance = appearance65;
            appearance.BackColor = System.Drawing.SystemColors.Highlight;
            appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ultraComboTipIsplate.DisplayLayout.Override.ActiveRowAppearance = appearance;
            this.ultraComboTipIsplate.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraComboTipIsplate.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            this.ultraComboTipIsplate.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ultraComboTipIsplate.DisplayLayout.Override.CellAppearance = appearance3;
            this.ultraComboTipIsplate.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ultraComboTipIsplate.DisplayLayout.Override.CellPadding = 0;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraComboTipIsplate.DisplayLayout.Override.GroupByRowAppearance = appearance4;
            appearance5.TextHAlignAsString = "Left";
            this.ultraComboTipIsplate.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.ultraComboTipIsplate.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraComboTipIsplate.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            this.ultraComboTipIsplate.DisplayLayout.Override.RowAppearance = appearance6;
            this.ultraComboTipIsplate.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ultraComboTipIsplate.DisplayLayout.Override.TemplateAddRowAppearance = appearance7;
            this.ultraComboTipIsplate.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraComboTipIsplate.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraComboTipIsplate.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraComboTipIsplate.DisplayMember = "NAZIV";
            this.ultraComboTipIsplate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraComboTipIsplate.Location = new System.Drawing.Point(343, 182);
            this.ultraComboTipIsplate.Name = "ultraComboTipIsplate";
            this.ultraComboTipIsplate.Size = new System.Drawing.Size(250, 22);
            this.ultraComboTipIsplate.TabIndex = 40;
            this.ultraComboTipIsplate.Tag = "";
            this.ultraComboTipIsplate.UseAppStyling = false;
            this.ultraComboTipIsplate.ValueMember = "IDTIPISPLATE";
            // 
            // pnbzMjesecGodina
            // 
            appearance28.BackColor = System.Drawing.SystemColors.Info;
            appearance28.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance28.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            this.pnbzMjesecGodina.Appearance = appearance28;
            this.pnbzMjesecGodina.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.pnbzMjesecGodina.Enabled = false;
            this.pnbzMjesecGodina.Location = new System.Drawing.Point(294, 183);
            this.pnbzMjesecGodina.Name = "pnbzMjesecGodina";
            this.pnbzMjesecGodina.PromptChar = ' ';
            this.pnbzMjesecGodina.Size = new System.Drawing.Size(43, 20);
            this.pnbzMjesecGodina.TabIndex = 39;
            this.pnbzMjesecGodina.Text = "0000";
            this.pnbzMjesecGodina.UseAppStyling = false;
            // 
            // pnbzOIB
            // 
            appearance29.BackColor = System.Drawing.SystemColors.Info;
            appearance29.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance29.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance29.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            this.pnbzOIB.Appearance = appearance29;
            this.pnbzOIB.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.pnbzOIB.Enabled = false;
            this.pnbzOIB.Location = new System.Drawing.Point(184, 183);
            this.pnbzOIB.Name = "pnbzOIB";
            this.pnbzOIB.PromptChar = ' ';
            this.pnbzOIB.Size = new System.Drawing.Size(104, 20);
            this.pnbzOIB.TabIndex = 38;
            this.pnbzOIB.UseAppStyling = false;
            // 
            // pnbzBrojModela
            // 
            appearance30.BackColor = System.Drawing.SystemColors.Info;
            appearance30.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance30.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            this.pnbzBrojModela.Appearance = appearance30;
            this.pnbzBrojModela.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.pnbzBrojModela.Enabled = false;
            this.pnbzBrojModela.Location = new System.Drawing.Point(149, 183);
            this.pnbzBrojModela.Name = "pnbzBrojModela";
            this.pnbzBrojModela.PromptChar = ' ';
            this.pnbzBrojModela.Size = new System.Drawing.Size(29, 20);
            this.pnbzBrojModela.TabIndex = 37;
            this.pnbzBrojModela.Text = "67";
            this.pnbzBrojModela.UseAppStyling = false;
            // 
            // ultraLabel8
            // 
            appearance36.BackColor = System.Drawing.Color.Transparent;
            appearance36.TextHAlignAsString = "Left";
            this.ultraLabel8.Appearance = appearance36;
            this.ultraLabel8.Location = new System.Drawing.Point(11, 186);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(137, 18);
            this.ultraLabel8.TabIndex = 36;
            this.ultraLabel8.Text = "Poziv na broj zaduženja:";
            this.ultraLabel8.UseAppStyling = false;
            this.ultraLabel8.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.Location = new System.Drawing.Point(11, 136);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(88, 23);
            this.UltraButton1.TabIndex = 35;
            this.UltraButton1.Text = "Dodaj virman";
            this.UltraButton1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // mb
            // 
            appearance37.BackColor = System.Drawing.Color.SteelBlue;
            appearance37.BackColor2 = System.Drawing.Color.SteelBlue;
            appearance37.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance37.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            this.mb.Appearance = appearance37;
            this.mb.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mb.Enabled = false;
            this.mb.Location = new System.Drawing.Point(577, 77);
            this.mb.Name = "mb";
            this.mb.PromptChar = ' ';
            this.mb.Size = new System.Drawing.Size(97, 20);
            this.mb.TabIndex = 34;
            this.mb.UseAppStyling = false;
            // 
            // UltraLabel6
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextHAlignAsString = "Left";
            this.UltraLabel6.Appearance = appearance1;
            this.UltraLabel6.Location = new System.Drawing.Point(11, 106);
            this.UltraLabel6.Name = "UltraLabel6";
            this.UltraLabel6.Size = new System.Drawing.Size(117, 23);
            this.UltraLabel6.TabIndex = 33;
            this.UltraLabel6.Text = "Datum izvršenja:";
            this.UltraLabel6.UseAppStyling = false;
            this.UltraLabel6.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // UltraLabel5
            // 
            appearance38.BackColor = System.Drawing.Color.Transparent;
            appearance38.TextHAlignAsString = "Left";
            this.UltraLabel5.Appearance = appearance38;
            this.UltraLabel5.Location = new System.Drawing.Point(11, 76);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(88, 23);
            this.UltraLabel5.TabIndex = 32;
            this.UltraLabel5.Text = "Datum predaje:";
            this.UltraLabel5.UseAppStyling = false;
            this.UltraLabel5.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // UltraLabel2
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.TextHAlignAsString = "Left";
            this.UltraLabel2.Appearance = appearance8;
            this.UltraLabel2.Location = new System.Drawing.Point(11, 22);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(128, 23);
            this.UltraLabel2.TabIndex = 31;
            this.UltraLabel2.Text = "Odabrani obračun:";
            this.UltraLabel2.UseAppStyling = false;
            this.UltraLabel2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // UltraLabel4
            // 
            appearance23.BackColor = System.Drawing.Color.Transparent;
            appearance23.TextHAlignAsString = "Left";
            this.UltraLabel4.Appearance = appearance23;
            this.UltraLabel4.Location = new System.Drawing.Point(11, 50);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(128, 23);
            this.UltraLabel4.TabIndex = 30;
            this.UltraLabel4.Text = "Odaberite isplatni račun:";
            this.UltraLabel4.UseAppStyling = false;
            this.UltraLabel4.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // UltraLabel3
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.TextHAlignAsString = "Right";
            this.UltraLabel3.Appearance = appearance9;
            this.UltraLabel3.Location = new System.Drawing.Point(373, 80);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(97, 23);
            this.UltraLabel3.TabIndex = 29;
            this.UltraLabel3.Text = "Izvor dokumenta";
            this.UltraLabel3.UseAppStyling = false;
            this.UltraLabel3.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // UltraLabel1
            // 
            appearance39.BackColor = System.Drawing.Color.Transparent;
            appearance39.TextHAlignAsString = "Right";
            this.UltraLabel1.Appearance = appearance39;
            this.UltraLabel1.Location = new System.Drawing.Point(412, 53);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(58, 23);
            this.UltraLabel1.TabIndex = 28;
            this.UltraLabel1.Text = "Žiro račun";
            this.UltraLabel1.UseAppStyling = false;
            // 
            // vbdi
            // 
            appearance27.BackColor = System.Drawing.SystemColors.Info;
            appearance27.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance27.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            this.vbdi.Appearance = appearance27;
            this.vbdi.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.vbdi.Enabled = false;
            this.vbdi.Location = new System.Drawing.Point(474, 50);
            this.vbdi.Name = "vbdi";
            this.vbdi.PromptChar = ' ';
            this.vbdi.Size = new System.Drawing.Size(97, 20);
            this.vbdi.TabIndex = 27;
            this.vbdi.UseAppStyling = false;
            // 
            // ziro
            // 
            appearance26.BackColor = System.Drawing.SystemColors.Info;
            appearance26.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance26.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            this.ziro.Appearance = appearance26;
            this.ziro.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.ziro.Enabled = false;
            this.ziro.Location = new System.Drawing.Point(577, 50);
            this.ziro.Name = "ziro";
            this.ziro.PromptChar = ' ';
            this.ziro.Size = new System.Drawing.Size(97, 20);
            this.ziro.TabIndex = 26;
            this.ziro.UseAppStyling = false;
            // 
            // pla3
            // 
            appearance25.BackColor = System.Drawing.SystemColors.Info;
            appearance25.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance25.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance25.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            this.pla3.Appearance = appearance25;
            this.pla3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.pla3.Enabled = false;
            this.pla3.Location = new System.Drawing.Point(680, 19);
            this.pla3.Name = "pla3";
            this.pla3.PromptChar = ' ';
            this.pla3.Size = new System.Drawing.Size(97, 20);
            this.pla3.TabIndex = 25;
            this.pla3.UseAppStyling = false;
            // 
            // pla2
            // 
            appearance24.BackColor = System.Drawing.SystemColors.Info;
            appearance24.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance24.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.pla2.Appearance = appearance24;
            this.pla2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.pla2.Enabled = false;
            this.pla2.Location = new System.Drawing.Point(577, 19);
            this.pla2.Name = "pla2";
            this.pla2.PromptChar = ' ';
            this.pla2.Size = new System.Drawing.Size(97, 20);
            this.pla2.TabIndex = 24;
            this.pla2.UseAppStyling = false;
            // 
            // pla1
            // 
            appearance40.BackColor = System.Drawing.SystemColors.Info;
            appearance40.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance40.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance40.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            this.pla1.Appearance = appearance40;
            this.pla1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.pla1.Enabled = false;
            this.pla1.Location = new System.Drawing.Point(474, 19);
            this.pla1.Name = "pla1";
            this.pla1.PromptChar = ' ';
            this.pla1.Size = new System.Drawing.Size(97, 20);
            this.pla1.TabIndex = 23;
            this.pla1.UseAppStyling = false;
            // 
            // izvordokumenta
            // 
            appearance21.BackColor = System.Drawing.Color.SteelBlue;
            appearance21.BackColor2 = System.Drawing.Color.SteelBlue;
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance21.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            this.izvordokumenta.Appearance = appearance21;
            this.izvordokumenta.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.izvordokumenta.Enabled = false;
            this.izvordokumenta.Location = new System.Drawing.Point(474, 77);
            this.izvordokumenta.Name = "izvordokumenta";
            this.izvordokumenta.PromptChar = ' ';
            this.izvordokumenta.Size = new System.Drawing.Size(97, 20);
            this.izvordokumenta.TabIndex = 22;
            this.izvordokumenta.UseAppStyling = false;
            // 
            // UltraCombo1
            // 
            this.UltraCombo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UltraCombo1.DataMember = "KORISNIKLevel1";
            this.UltraCombo1.DataSource = this.KorisnikDataSet1;
            appearance32.BackColor = System.Drawing.Color.Gainsboro;
            appearance32.BackColor2 = System.Drawing.Color.DarkGray;
            appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal;
            this.UltraCombo1.DisplayLayout.Appearance = appearance32;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Caption = "platitelj";
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "platitelj";
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.Caption = "platitelj";
            ultraGridColumn7.Header.VisiblePosition = 4;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "VBDI Platit.";
            ultraGridColumn8.Header.VisiblePosition = 5;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.Caption = "ŽRN Pla";
            ultraGridColumn9.Header.VisiblePosition = 6;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.Caption = "Izvod dok.";
            ultraGridColumn10.Header.VisiblePosition = 7;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 8;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Caption = "Porez i prir";
            ultraGridColumn12.Header.VisiblePosition = 9;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.VisiblePosition = 10;
            ultraGridColumn13.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
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
            ultraGridColumn13});
            this.UltraCombo1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraCombo1.DisplayLayout.InterBandSpacing = 10;
            this.UltraCombo1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraCombo1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraCombo1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraCombo1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            appearance33.BackColor = System.Drawing.Color.Transparent;
            this.UltraCombo1.DisplayLayout.Override.CardAreaAppearance = appearance33;
            this.UltraCombo1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraCombo1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance34.BackColor = System.Drawing.Color.DarkGray;
            appearance34.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance34.FontData.Name = "Tahoma";
            appearance34.FontData.SizeInPoints = 9F;
            appearance34.TextHAlignAsString = "Left";
            appearance34.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.UltraCombo1.DisplayLayout.Override.HeaderAppearance = appearance34;
            this.UltraCombo1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance35.BackColor = System.Drawing.Color.DarkGray;
            appearance35.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            this.UltraCombo1.DisplayLayout.Override.RowSelectorAppearance = appearance35;
            this.UltraCombo1.DisplayLayout.Override.RowSelectorWidth = 20;
            this.UltraCombo1.DisplayLayout.Override.RowSpacingAfter = 1;
            this.UltraCombo1.DisplayLayout.Override.RowSpacingBefore = 3;
            this.UltraCombo1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraCombo1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraCombo1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraCombo1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Gray;
            this.UltraCombo1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.UltraCombo1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraCombo1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraCombo1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraCombo1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraCombo1.DisplayMember = "NAZIVZIRO";
            this.UltraCombo1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.UltraCombo1.Location = new System.Drawing.Point(149, 45);
            this.UltraCombo1.Name = "UltraCombo1";
            this.UltraCombo1.Size = new System.Drawing.Size(257, 22);
            this.UltraCombo1.TabIndex = 21;
            this.UltraCombo1.UseAppStyling = false;
            this.UltraCombo1.ValueMember = "IDZIRO";
            this.UltraCombo1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraCombo1_InitializeLayout);
            this.UltraCombo1.ValueChanged += new System.EventHandler(this.UltraCombo1_ValueChanged);
            // 
            // KorisnikDataSet1
            // 
            this.KorisnikDataSet1.DataSetName = "KORISNIKDataSet";
            // 
            // poreziprirez
            // 
            appearance41.BackColor = System.Drawing.SystemColors.Info;
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance41.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            this.poreziprirez.Appearance = appearance41;
            this.poreziprirez.BackColor = System.Drawing.SystemColors.Info;
            this.poreziprirez.BackColorInternal = System.Drawing.SystemColors.Info;
            this.poreziprirez.Enabled = false;
            this.poreziprirez.Location = new System.Drawing.Point(474, 129);
            this.poreziprirez.Name = "poreziprirez";
            this.poreziprirez.Size = new System.Drawing.Size(221, 20);
            this.poreziprirez.TabIndex = 20;
            this.poreziprirez.Text = "Zajednički virman poreza i prireza";
            this.poreziprirez.UseAppStyling = false;
            // 
            // CheckBox1
            // 
            appearance43.BackColor = System.Drawing.Color.Transparent;
            appearance43.BackColor2 = System.Drawing.Color.Transparent;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            this.CheckBox1.Appearance = appearance43;
            this.CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox1.BackColorInternal = System.Drawing.Color.Transparent;
            this.CheckBox1.Location = new System.Drawing.Point(149, 129);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(196, 20);
            this.CheckBox1.TabIndex = 18;
            this.CheckBox1.Text = "Ispis datuma na virmanima";
            this.CheckBox1.Checked = true;
            // 
            // pozivzaduzenja
            // 
            appearance44.BackColor = System.Drawing.SystemColors.Info;
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance44.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.pozivzaduzenja.Appearance = appearance44;
            this.pozivzaduzenja.BackColor = System.Drawing.SystemColors.Info;
            this.pozivzaduzenja.BackColorInternal = System.Drawing.SystemColors.Info;
            this.pozivzaduzenja.Enabled = false;
            this.pozivzaduzenja.Location = new System.Drawing.Point(474, 103);
            this.pozivzaduzenja.Name = "pozivzaduzenja";
            this.pozivzaduzenja.Size = new System.Drawing.Size(221, 20);
            this.pozivzaduzenja.TabIndex = 17;
            this.pozivzaduzenja.Text = "Virmani sa pozivima na broj zaduženja";
            this.pozivzaduzenja.UseAppStyling = false;
            // 
            // DATUMIZVRSENJA
            // 
            this.DATUMIZVRSENJA.Location = new System.Drawing.Point(149, 102);
            this.DATUMIZVRSENJA.Name = "DATUMIZVRSENJA";
            this.DATUMIZVRSENJA.Size = new System.Drawing.Size(98, 21);
            this.DATUMIZVRSENJA.TabIndex = 16;
            this.DATUMIZVRSENJA.UseAppStyling = false;
            this.DATUMIZVRSENJA.ValueChanged += new System.EventHandler(this.DATUMIZVRSENJA_ValueChanged);
            // 
            // DATUMPREDAJE
            // 
            this.DATUMPREDAJE.Location = new System.Drawing.Point(149, 73);
            this.DATUMPREDAJE.Name = "DATUMPREDAJE";
            this.DATUMPREDAJE.Size = new System.Drawing.Size(98, 21);
            this.DATUMPREDAJE.TabIndex = 15;
            this.DATUMPREDAJE.UseAppStyling = false;
            this.DATUMPREDAJE.Value = null;
            this.DATUMPREDAJE.ValueChanged += new System.EventHandler(this.DATUMPREDAJE_ValueChanged);
            // 
            // UltraLabel7
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            appearance22.TextHAlignAsString = "Right";
            this.UltraLabel7.Appearance = appearance22;
            this.UltraLabel7.Location = new System.Drawing.Point(426, 22);
            this.UltraLabel7.Name = "UltraLabel7";
            this.UltraLabel7.Size = new System.Drawing.Size(44, 23);
            this.UltraLabel7.TabIndex = 14;
            this.UltraLabel7.Text = "Platitelj";
            this.UltraLabel7.UseAppStyling = false;
            // 
            // sifraobracuna
            // 
            appearance12.BackColor = System.Drawing.SystemColors.Info;
            appearance12.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Info;
            appearance12.BackColorDisabled2 = System.Drawing.SystemColors.Info;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.sifraobracuna.Appearance = appearance12;
            this.sifraobracuna.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.sifraobracuna.Enabled = false;
            this.sifraobracuna.Location = new System.Drawing.Point(149, 19);
            this.sifraobracuna.Name = "sifraobracuna";
            this.sifraobracuna.PromptChar = ' ';
            this.sifraobracuna.Size = new System.Drawing.Size(97, 20);
            this.sifraobracuna.TabIndex = 6;
            this.sifraobracuna.UseAppStyling = false;
            // 
            // VirmaniDataSet1
            // 
            this.VirmaniDataSet1.DataSetName = "VIRMANIDataSet";
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "VIRMANI";
            this.UltraGrid1.DataSource = this.VirmaniDataSet1;
            appearance10.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance10;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.Header.VisiblePosition = 3;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.Header.VisiblePosition = 4;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn19.Header.Caption = "";
            ultraGridColumn19.Header.VisiblePosition = 5;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.Header.Caption = "Model zaduženja";
            ultraGridColumn20.Header.VisiblePosition = 12;
            ultraGridColumn20.Width = 100;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn21.Header.Caption = "Poziv na broj zaduženja";
            ultraGridColumn21.Header.VisiblePosition = 13;
            ultraGridColumn21.Width = 130;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn22.Header.Caption = "Primatelj";
            ultraGridColumn22.Header.VisiblePosition = 9;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn23.Header.Caption = "Primatelj";
            ultraGridColumn23.Header.VisiblePosition = 10;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn24.Header.Caption = "Primatelj";
            ultraGridColumn24.Header.VisiblePosition = 11;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn25.Header.Caption = "Račun primatelja";
            ultraGridColumn25.Header.VisiblePosition = 14;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn26.Header.Caption = "Model odobrenja";
            ultraGridColumn26.Header.VisiblePosition = 15;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn27.Header.Caption = "Poziv na broj odobrenja";
            ultraGridColumn27.Header.VisiblePosition = 16;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn28.Header.Caption = "Šifra opisa plaćanja";
            ultraGridColumn28.Header.VisiblePosition = 17;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn29.Header.Caption = "Opis plaćanja";
            ultraGridColumn29.Header.VisiblePosition = 18;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn30.Header.VisiblePosition = 19;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn31.Header.VisiblePosition = 20;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn32.Header.VisiblePosition = 21;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn33.Header.Caption = "Označen";
            ultraGridColumn33.Header.VisiblePosition = 7;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn34.Header.Caption = "Iznos";
            ultraGridColumn34.Header.VisiblePosition = 8;
            ultraGridColumn34.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn35.Header.Caption = "Namjena";
            ultraGridColumn35.Header.VisiblePosition = 6;
            ultraGridColumn35.Width = 47;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn36.Header.Caption = "HUB 3/3A - šifra namjene";
            ultraGridColumn36.Header.VisiblePosition = 22;
            ultraGridColumn36.Width = 150;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn37.Header.Caption = "HUB 3/3A - Hitno";
            ultraGridColumn37.Header.VisiblePosition = 23;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37});
            ultraGridBand3.HeaderVisible = true;
            ultraGridBand3.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance11;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance17.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance17;
            appearance18.BorderColor = System.Drawing.Color.LightGray;
            appearance18.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance19.BorderColor = System.Drawing.Color.Black;
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Location = new System.Drawing.Point(0, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1222, 524);
            this.UltraGrid1.TabIndex = 9;
            this.UltraGrid1.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            this.UltraGrid1.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.UltraGrid1_BeforeCellDeactivate);
            // 
            // Virmani_Fill_Panel
            // 
            this.Virmani_Fill_Panel.Controls.Add(this.UltraGrid1);
            this.Virmani_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Virmani_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Virmani_Fill_Panel.Location = new System.Drawing.Point(0, 192);
            this.Virmani_Fill_Panel.Name = "Virmani_Fill_Panel";
            this.Virmani_Fill_Panel.Size = new System.Drawing.Size(1222, 524);
            this.Virmani_Fill_Panel.TabIndex = 0;
            // 
            // UltraDockManager2
            // 
            appearance20.FontData.BoldAsString = "True";
            this.UltraDockManager2.Appearances.Add(appearance20);
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(22, 27, 1033, 253);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Podaci o isplatitelju i načinima kreiranja virmana";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1222, 187);
            this.UltraDockManager2.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager2.HostControl = this;
            this.UltraDockManager2.ShowCloseButton = false;
            this.UltraDockManager2.ShowPinButton = false;
            this.UltraDockManager2.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _VirmaniUnpinnedTabAreaLeft
            // 
            this._VirmaniUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._VirmaniUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._VirmaniUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._VirmaniUnpinnedTabAreaLeft.Name = "_VirmaniUnpinnedTabAreaLeft";
            this._VirmaniUnpinnedTabAreaLeft.Owner = this.UltraDockManager2;
            this._VirmaniUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 716);
            this._VirmaniUnpinnedTabAreaLeft.TabIndex = 1;
            // 
            // _VirmaniUnpinnedTabAreaRight
            // 
            this._VirmaniUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._VirmaniUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._VirmaniUnpinnedTabAreaRight.Location = new System.Drawing.Point(1222, 0);
            this._VirmaniUnpinnedTabAreaRight.Name = "_VirmaniUnpinnedTabAreaRight";
            this._VirmaniUnpinnedTabAreaRight.Owner = this.UltraDockManager2;
            this._VirmaniUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 716);
            this._VirmaniUnpinnedTabAreaRight.TabIndex = 2;
            // 
            // _VirmaniUnpinnedTabAreaTop
            // 
            this._VirmaniUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._VirmaniUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._VirmaniUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._VirmaniUnpinnedTabAreaTop.Name = "_VirmaniUnpinnedTabAreaTop";
            this._VirmaniUnpinnedTabAreaTop.Owner = this.UltraDockManager2;
            this._VirmaniUnpinnedTabAreaTop.Size = new System.Drawing.Size(1222, 0);
            this._VirmaniUnpinnedTabAreaTop.TabIndex = 3;
            // 
            // _VirmaniUnpinnedTabAreaBottom
            // 
            this._VirmaniUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._VirmaniUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._VirmaniUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 716);
            this._VirmaniUnpinnedTabAreaBottom.Name = "_VirmaniUnpinnedTabAreaBottom";
            this._VirmaniUnpinnedTabAreaBottom.Owner = this.UltraDockManager2;
            this._VirmaniUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1222, 0);
            this._VirmaniUnpinnedTabAreaBottom.TabIndex = 4;
            // 
            // _VirmaniAutoHideControl
            // 
            this._VirmaniAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._VirmaniAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._VirmaniAutoHideControl.Name = "_VirmaniAutoHideControl";
            this._VirmaniAutoHideControl.Owner = this.UltraDockManager2;
            this._VirmaniAutoHideControl.Size = new System.Drawing.Size(0, 605);
            this._VirmaniAutoHideControl.TabIndex = 5;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.dockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager2;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1222, 192);
            this.WindowDockingArea1.TabIndex = 6;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.UltraGroupBox1);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.UltraDockManager2;
            this.dockableWindow1.Size = new System.Drawing.Size(1222, 187);
            this.dockableWindow1.TabIndex = 7;
            // 
            // Virmani
            // 
            this.Controls.Add(this._VirmaniAutoHideControl);
            this.Controls.Add(this.Virmani_Fill_Panel);
            this.Controls.Add(this._VirmaniUnpinnedTabAreaLeft);
            this.Controls.Add(this._VirmaniUnpinnedTabAreaTop);
            this.Controls.Add(this._VirmaniUnpinnedTabAreaBottom);
            this.Controls.Add(this._VirmaniUnpinnedTabAreaRight);
            this.Controls.Add(this.WindowDockingArea1);
            this.Name = "Virmani";
            this.Size = new System.Drawing.Size(1222, 716);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboTipIsplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCombo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KorisnikDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATUMIZVRSENJA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATUMPREDAJE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VirmaniDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            this.Virmani_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager2)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        [LocalCommandHandler("IspisiListuBanaka")]
        public void IspisiListuBanakaHandler(object sender, EventArgs e)
        {
            invalidi = false;
            this.Rekapitulacije_Isplata_Za_sve_Banke_Samo_Zbirni_Neto();
        }

        [LocalCommandHandler("IspisiListuBanakaSvi")]
        public void IspisiListuBanakaSviHandler(object sender, EventArgs e)
        {
            invalidi = false;
            this.Rekapitulacije_Isplata_Za_sve_Banke();
        }

        [LocalCommandHandler("IspisiZN")]
        public void IspisiZNHandler(object sender, EventArgs e)
        {
            invalidi = false;
            this.Zbrojni_Nalog();
        }

        [LocalCommandHandler("IspisiZNOsobe")]
        public void IspisiZNOsobeHandler(object sender, EventArgs e)
        {
            invalidi = false;
            this.Zbrojni_NalogOsobe();
        }

        [LocalCommandHandler("IzradiDatotekuBanke")]
        public void IzradiDatotekuBankeHandler(object sender, EventArgs e)
        {
            this.Disketa();
        }


        [LocalCommandHandler("SepaDatoteka")]
        public void SepaDatoteka(object sender, EventArgs e)
        {
            SepaDatoteka(false);
        }

        [LocalCommandHandler("SepaDatotekaFina")]
        public void SepaDatotekaFina(object sender, EventArgs e)
        {
            SepaDatoteka(true);
        }


        private void Makni_Oznake_Svima()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.VirmaniDataSet1.VIRMANI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    current["oznacen"] = false;
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
        }

        [LocalCommandHandler("Nista")]
        public void Nista(object sender, EventArgs e)
        {
            invalidi = false;
            this.Makni_Oznake_Svima();
        }

        [LocalCommandHandler("Otvori")]
        public void OtvoriHandler(object sender, EventArgs e)
        {
            invalidi = false;
            using (frmPregledObracuna obracuna = new frmPregledObracuna())
            {
                obracuna.ShowDialog();
                if (obracuna.DialogResult == DialogResult.Cancel)
                {
                    return;
                }
                this.odabrani = Conversions.ToString(obracuna.ObracunSelected);
                this.sifraobracuna.Value = this.odabrani;
            }
            this.PrikaziVirmaneOdabranogObracuna();
        }

        [LocalCommandHandler("PonovnoStvori")]
        public void PonovnoStvoriHandler(object sender, EventArgs e)
        {
            invalidi = false;
            this.StvoriPonovnoVirmane();
        }

        public void Poziv_Zaduzenja_Srednji_Broj()
        {
            if (Interaction.MsgBox("Želite li promijeniti aktivnost na pozivu na broj zaduženja", MsgBoxStyle.YesNo, "Obračun plaća - promjena aktivnosti virmana") != MsgBoxResult.No)
            {
                frmIdentifikator identifikator = new frmIdentifikator
                {
                    Text = "Unesite aktivnost"
                };
                identifikator.Label1.Text = "Aktivnost";
                identifikator.rsmIdent.MaxLength = 7;
                if (identifikator.ShowDialog() == DialogResult.OK)
                {
                    IEnumerator enumerator = null;
                    try
                    {
                        enumerator = this.VirmaniDataSet1.VIRMANI.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            string[] strArray = current["pozivzaduzenja"].ToString().Split(new char[] { '-' });
                            if (strArray.Length == 3)
                            {
                                current["pozivzaduzenja"] = strArray[0] + "-" + identifikator.UneseniIdentifikator.ToString() + "-" + strArray[2];
                                current.AcceptChanges();
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
                    this.davirmani.Update(this.VirmaniDataSet1);
                }
            }
        }

        private void PrikaziVirmaneOdabranogObracuna()
        {
            if (this.dd)
            {
                this.StvoriPonovnoVirmane();
                this.PrikaziZajednickePodatkeVirmana();
                this.UltraGrid1.Select();
                if (this.UltraGrid1.Rows.Count > 0)
                {
                    this.UltraGrid1.Rows[0].Selected = true;
                    this.UltraGrid1.Rows[0].Activated = true;
                }
            }
            else
            {
                this.VirmaniDataSet1.Clear();
                this.davirmani.FillBySIFRAOBRACUNAVIRMAN(this.VirmaniDataSet1, Conversions.ToString(this.sifraobracuna.Value));
                if (this.VirmaniDataSet1.VIRMANI.Rows.Count == 0)
                {
                    this.StvoriPonovnoVirmane();
                }
                else if (MessageBox.Show(string.Format("Virmani za ovaj obračun već postoje! Želite li ponovno izraditi virmane?? \r\nYES - Program ponovno kreira virmane\r\nNO - Nastavljate rad sa prethodno kreiranim virmanima", "\r\n"), "Virmani", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.StvoriPonovnoVirmane();
                }
                this.PrikaziZajednickePodatkeVirmana();
                this.UltraGrid1.Select();
                if (this.UltraGrid1.Rows.Count > 0)
                {
                    this.UltraGrid1.Rows[0].Selected = true;
                    this.UltraGrid1.Rows[0].Activated = true;
                }
            }
            this.disableValueChange = true;
            int num2 = this.UltraCombo1.Rows.Count - 1;

            if (this.UltraGrid1.Rows.Count == 0)
                return;

            for (int i = 0; i <= num2; i++)
            {
                if (Operators.ConditionalCompareObjectEqual(Operators.AddObject(Operators.AddObject(this.UltraCombo1.Rows[i].Cells[5].Value, "-"), this.UltraCombo1.Rows[i].Cells[6].Value), this.UltraGrid1.Rows[0].Cells["brojracunapla"].Value, false))
                {
                    this.UltraCombo1.Rows[i].Selected = true;
                }
            }
            this.disableValueChange = false;
            this.pozivzaduzenja.Checked = Conversions.ToBoolean(this.UltraCombo1.SelectedRow.Cells["pozivizaduzenja"].Value);
            this.poreziprirez.Checked = Conversions.ToBoolean(this.UltraCombo1.SelectedRow.Cells["poreziprirezzajednicki"].Value);
            this.izvordokumenta.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["sifraizvora"].Value);
            this.pla1.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["nazivziro"].Value);
            this.pla2.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["ulicaziro"].Value);
            this.pla3.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["mjestoziro"].Value);
            this.vbdi.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["vbdikorisnik"].Value);
            this.ziro.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["zirokorisnik"].Value);


            Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();
            // poziv na broj zaduženja
            this.pnbzBrojModela.Value = 67;
            this.pnbzOIB.Value = db.ExecuteScalar("SELECT KORISNIKOIB FROM dbo.KORISNIK WHERE IDKORISNIK = 1");

            object mjesecObracuna = db.ExecuteScalar("SELECT MJESECOBRACUNA FROM dbo.OBRACUN WHERE IDOBRACUN = '" + this.sifraobracuna.Value.ToString() + "'");
            object godinaObracuna = db.ExecuteScalar("SELECT GODINAOBRACUNA FROM dbo.OBRACUN WHERE IDOBRACUN = '" + this.sifraobracuna.Value.ToString() + "'");

            if (VirmaniWorkItemUser.oznaka_izvjesca.Length > 0)
            {
                pnbzMjesecGodina.Value = VirmaniWorkItemUser.oznaka_izvjesca;
            }
            else
            {
                object trenutni_broj = null;
                try
                {
                    trenutni_broj = db.ExecuteScalar("SELECT DISTINCT SUBSTRING([POZIVODOBRENJA], LEN([POZIVODOBRENJA]) - CHARINDEX('-',REVERSE([POZIVODOBRENJA])) + 2, LEN([POZIVODOBRENJA])) " +
                    "FROM VIRMANI  WHERE SIFRAOBRACUNAVIRMAN = '" + sifraobracuna.Value.ToString() + "' AND (NAMJENA like '%Doprinosi%' OR NAMJENA like '%Porez%' OR NAMJENA like '%Prirez%')");

                    this.pnbzMjesecGodina.Value = trenutni_broj.ToString();
                }
                catch
                {
                    this.pnbzMjesecGodina.Value = "0000";
                }

            }


            DataTable dtTipoviIsplate = new DataTable();
            dtTipoviIsplate.Columns.Add("IDTIPISPLATE");
            dtTipoviIsplate.Columns.Add("NAZIV");

            DataRow drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 0;
            drRow["NAZIV"] = "0 - isplata plaće u cijelosti";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 1;
            drRow["NAZIV"] = "1 - isplata prvog dijela plaće";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 2;
            drRow["NAZIV"] = "2 - isplata drugog dijela plaće";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 3;
            drRow["NAZIV"] = "3 - isplata bez doprinosa za II stup MIO";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 4;
            drRow["NAZIV"] = "4 - isplata bez doprinosa na osnovicu";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 8;
            drRow["NAZIV"] = "8 - isplata drugog dohotka";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 9;
            drRow["NAZIV"] = "9 - isplata naknade plaće od strane poslodavca";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 10;
            drRow["NAZIV"] = "10 - isplata mirovine";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 11;
            drRow["NAZIV"] = "11 - isplata dohotka od osiguranja";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 12;
            drRow["NAZIV"] = "12 - isplata dohotka od kapitala";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 13;
            drRow["NAZIV"] = "13 - isplata dohotka od posebne vrste imovine";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 14;
            drRow["NAZIV"] = "14 - dohodak od imovinskih prava";
            dtTipoviIsplate.Rows.Add(drRow);

            drRow = dtTipoviIsplate.NewRow();
            drRow["IDTIPISPLATE"] = 15;
            drRow["NAZIV"] = "15 - drugi dohodak kod umirovljenika";
            dtTipoviIsplate.Rows.Add(drRow);

            this.ultraComboTipIsplate.ValueMember = "IDTIPISPLATE";
            this.ultraComboTipIsplate.DisplayMember = "NAZIV";
            this.ultraComboTipIsplate.DataSource = dtTipoviIsplate;
            this.ultraComboTipIsplate.DataBind();

            this.ultraComboTipIsplate.Value = 0;
        }

        private void PrikaziZajednickePodatkeVirmana()
        {
            if (this.VirmaniDataSet1.VIRMANI.Rows.Count > 0)
            {
                this.DATUMPREDAJE.Value = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["datumpodnosenja"]);
                this.DATUMIZVRSENJA.Value = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["datumvalute"]);
                this.izvordokumenta.Value = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["izvordokumenta"]);
            }

            foreach (DataRow drRow in this.VirmaniDataSet1.VIRMANI.Rows)
            {
                // Postavi šifru namjene:
                //       - SALA - neto elemeni i neto plaća
                //       - NITX - sve ostalo (109)
                if (drRow["HUB3_SIFRANAMJENE"] == DBNull.Value)
                {
                    string namjena = string.Empty;

                    if (drRow["namjena"] != DBNull.Value)
                        namjena = RuntimeHelpers.GetObjectValue(drRow["namjena"]).ToString();

                    if (namjena.ToLower().Contains("neto"))
                    {
                        drRow["HUB3_SIFRANAMJENE"] = "SALA";
                    }
                    else
                    {
                        drRow["HUB3_SIFRANAMJENE"] = "NITX";
                    }
                }

                if (drRow["HUB3_HITNO"] == DBNull.Value)
                {
                    drRow["HUB3_HITNO"] = false;
                }
            }
        }

        [LocalCommandHandler("Prilog1")]
        public void Prilog1Handler(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo info2 = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Prilog-1 obrazac",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowSmartPartInfo smartPartInfo = info2;
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Prilog1 smartPart = this.Controller.WorkItem.Items.AddNew<Prilog1>();
            int num2 = 0;
            decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Compute("SUM(IZNOS)", "OZNACEN = 1")));
            num2 = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Compute("COUNT(IDVIRMAN)", "OZNACEN = 1"))));
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
            SqlCommand command = new SqlCommand("SELECT mjesecoBRACUNArsm FROM RSMA WHERE idobracun = @idobracun", connection);
            command.Parameters.Add("@idobracun", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(this.sifraobracuna.Value);
            connection.Open();
            bool flag = Conversions.ToBoolean(Interaction.IIf(DB.N2T(RuntimeHelpers.GetObjectValue(command.ExecuteScalar()), "") == "00", true, false));
            connection.Close();
            if (flag)
            {
                smartPart.jbBroj.Value = num2;
                smartPart.jbIznos.Value = num;
            }
            else
            {
                smartPart.plBroj.Value = num2;
                smartPart.plIznos.Value = num;
            }
            smartPart.tkBroj.Value = 0;
            smartPart.tkSvota.Value = 0;
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("PromjenaBrojaZaduzenja")]
        public void PromjenaBrojaZaduzenjaCommandHanlder(object sender, EventArgs e)
        {
            invalidi = false;
            this.Poziv_Zaduzenja_Srednji_Broj();
        }

        [LocalCommandHandler("VirmanInvalide")]
        public void VirmaniInvalidiCommandHanlder(object sender, EventArgs e)
        {
            using (JOPPDBroj objekt = new JOPPDBroj())
            {
                if (objekt.ShowDialog() == DialogResult.OK)
                {
                    Virmani_Iz_Obracuna(this.odabrani, true);
                    invalidi = true;
                }
            }


        }

        public void Rekapitulacije_Isplata_Za_sve_Banke()
        {
            if (this.dd)
            {
                Interaction.MsgBox("Korištenje moguće samo u obračunu plaća!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                sp_REKAP_ISPLATADataAdapter adapter = new sp_REKAP_ISPLATADataAdapter();
                sp_REKAP_ISPLATADataSet dataSet = new sp_REKAP_ISPLATADataSet();
                adapter.Fill(dataSet, Conversions.ToString(this.sifraobracuna.Value), null);
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Rekapitulacija isplata za banke",
                    Description = "Pregled izvještaja - Rekapitulacija isplata za banke",
                    Icon = ImageResourcesNew.mbs
                };
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptIsplate.rpt");
                KORISNIKDataAdapter adapter2 = new KORISNIKDataAdapter();
                KORISNIKDataSet set2 = new KORISNIKDataSet();
                adapter2.Fill(set2);

                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;

                try
                {
                    str = Conversions.ToString(Operators.AddObject(Operators.AddObject(set2.KORISNIK.Rows[0]["korisnik1naziv"], ", "), set2.KORISNIK.Rows[0]["korisnik1mjesto"]));
                    str2 = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnikoib"]);
                    str3 = Conversions.ToString(set2.KORISNIK.Rows[0]["rkp"]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Greška u pokretanju izvještaja, zbog nepostojanja podataka!\n\nMolimo, pod 'Korisnik aplikacije' provjerite da li su upisani NAZIV, MJESTO, OIB, te RKP!", "Greška u izvještaju");
                }

                document.SetDataSource(dataSet);
                document.SetParameterValue("OBRACUN", this.odabrani);
                document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla1"]));
                document.SetParameterValue("ADRESA", RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla2"]));
                document.SetParameterValue("ADRESA2", RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla3"]));
                document.SetParameterValue("mb", RuntimeHelpers.GetObjectValue(this.KorisnikDataSet1.KORISNIK.Rows[0]["mbkorisnik"]));
                document.SetParameterValue("nazivimjesto", str);
                document.SetParameterValue("oib", str2);
                document.SetParameterValue("rkdp", str3);


                IBAN iban = new IBAN();

                string ibanPlatitelja = iban.GenerirajIBANIzBrojaRacuna(this.VirmaniDataSet1.VIRMANI.Rows[0]["brojracunapla"].ToString(), false, true);
                document.SetParameterValue("BROJRACUNA", ibanPlatitelja);

                string ibanBanke = string.Empty;

                //if (dataSet.sp_REKAP_ISPLATA.Rows.Count > 0)
                //    ibanBanke = iban.GenerirajIBANIzBrojaRacuna(string.Format("{0}-{1}", dataSet.sp_REKAP_ISPLATA.Rows[0]["VBDIBANKE"], dataSet.sp_REKAP_ISPLATA.Rows[0]["ZRNBANKE"]), false, true);
                //foreach(DataRow row in dataSet.sp_REKAP_ISPLATA.Rows){
                //    row["VBDIBANKE"] = iban.GenerirajIBANIzBrojaRacuna(string.Format("{0}-{1}", row["VBDIBANKE"], row["ZRNBANKE"]), false, true);
                //}
                document.SetParameterValue("IBANBANKE", "");
                //document.SetParameterValue("IBANBANKE", "");

                // TEKUĆI -> IBAN
                foreach (DataRow row in dataSet.sp_REKAP_ISPLATA.Rows)
                {
                    row["TEKUCI"] = iban.GenerirajIBANIzBrojaRacuna(row["VBDIBANKE"].ToString() + row["TEKUCI"].ToString(), false, true);
                }


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

        public void Rekapitulacije_Isplata_Za_sve_Banke_Samo_Zbirni_Neto()
        {
            if (this.dd)
            {
                Interaction.MsgBox("Korištenje moguće samo u obračunu plaća!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                sp_REKAP_ISPLATADataAdapter adapter = new sp_REKAP_ISPLATADataAdapter();
                sp_REKAP_ISPLATADataSet dataSet = new sp_REKAP_ISPLATADataSet();
                adapter.Fill(dataSet, Conversions.ToString(this.sifraobracuna.Value), null);
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Rekapitulacija isplata za banke",
                    Description = "Pregled izvještaja - Rekapitulacija isplata za banke",
                    Icon = ImageResourcesNew.mbs
                };
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptIsplate.rpt");
                document.SetDataSource(dataSet);
                document.RecordSelectionFormula = "{sp_rekap_isplata.ZBIRNINETO} = True";
                document.SetParameterValue("OBRACUN", this.odabrani);
                KORISNIKDataAdapter adapter2 = new KORISNIKDataAdapter();
                KORISNIKDataSet set2 = new KORISNIKDataSet();
                adapter2.Fill(set2);

                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;

                try
                {
                    str = Conversions.ToString(Operators.AddObject(Operators.AddObject(set2.KORISNIK.Rows[0]["korisnik1naziv"], ", "), set2.KORISNIK.Rows[0]["korisnik1mjesto"]));
                    str2 = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnikoib"]);
                    str3 = Conversions.ToString(set2.KORISNIK.Rows[0]["rkp"]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Greška u pokretanju izvještaja, zbog nepostojanja podataka!\n\nMolimo, pod 'Korisnik aplikacije' provjerite da li su upisani NAZIV, MJESTO, OIB, te RKP!", "Greška u izvještaju");
                }

                document.SetDataSource(dataSet);
                document.SetParameterValue("OBRACUN", this.odabrani);
                document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla1"]));
                document.SetParameterValue("ADRESA", RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla2"]));
                document.SetParameterValue("ADRESA2", RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla3"]));
                document.SetParameterValue("BROJRACUNA", RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["brojracunapla"]));
                document.SetParameterValue("mb", RuntimeHelpers.GetObjectValue(this.KorisnikDataSet1.KORISNIK.Rows[0]["mbkorisnik"]));
                document.SetParameterValue("nazivimjesto", str);
                document.SetParameterValue("oib", str2);
                document.SetParameterValue("rkdp", str3);


                IBAN iban = new IBAN();

                string ibanPlatitelja = iban.GenerirajIBANIzBrojaRacuna(this.VirmaniDataSet1.VIRMANI.Rows[0]["brojracunapla"].ToString(), false, true);
                document.SetParameterValue("BROJRACUNA", ibanPlatitelja);

                string ibanBanke = string.Empty;

                if (dataSet.sp_REKAP_ISPLATA.Rows.Count > 0)
                    ibanBanke = iban.GenerirajIBANIzBrojaRacuna(string.Format("{0}-{1}", dataSet.sp_REKAP_ISPLATA.Rows[0]["VBDIBANKE"], dataSet.sp_REKAP_ISPLATA.Rows[0]["ZRNBANKE"]), false, true);

                document.SetParameterValue("IBANBANKE", ibanBanke);

                // TEKUĆI -> IBAN
                foreach (DataRow row in dataSet.sp_REKAP_ISPLATA.Rows)
                {
                    row["TEKUCI"] = iban.GenerirajIBANIzBrojaRacuna(row["VBDIBANKE"].ToString() + row["TEKUCI"].ToString(), false, true);
                }


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

        private static void Snimi_Izlaznu_datoteku_Za_Finu(string datoteka)
        {
            try
            {
                SaveFileDialog dialog2 = new SaveFileDialog
                {
                    InitialDirectory = Conversions.ToString(0),
                    FileName = datoteka,
                    RestoreDirectory = true
                };
                SaveFileDialog dialog = dialog2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(datoteka, dialog.FileName, true);
                        Interaction.MsgBox("Disketa uspješno kreirana!", MsgBoxStyle.OkOnly, null);
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }
                }
            }
            catch (System.Exception exception3)
            {
                throw exception3;
            }
        }

        private void StvoriPonovnoVirmane()
        {
            if (this.dd)
            {
                this.VirmaniDataSet1.VIRMANI.Clear();
                this.Virmani_Iz_Obracuna(this.odabrani, false);
            }
            else
            {
                Brisi_Virmane_Obracuna(this.odabrani);
                this.VirmaniDataSet1.VIRMANI.Clear();
                try
                {
                    this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                this.Virmani_Iz_Obracuna(this.odabrani, false);
            }
        }

        [LocalCommandHandler("Sve")]
        public void Sve(object sender, EventArgs e)
        {
            invalidi = false;
            this.Dodaj_Oznake_Svima();
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            //if (this.VirmaniDataSet1.VIRMANI.Rows.Count == 0)
            //    return;

            //DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();
            //row["sifraobracunavirman"] = this.sifraobracuna.Text;
            //row["namjena"] = "Dodani virman";
            //row["datumpodnosenja"] = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["datumpodnosenja"]);
            //row["datumvalute"] = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["datumvalute"]);
            //row["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["izvordokumenta"]);
            //row["oznacen"] = true;
            //row["pla1"] = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla1"]);
            //row["pla2"] = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla2"]);
            //row["pla3"] = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["pla3"]);
            //row["iznos"] = 0;
            //row["brojracunapla"] = RuntimeHelpers.GetObjectValue(this.VirmaniDataSet1.VIRMANI.Rows[0]["brojracunapla"]);
            //row["brojracunapri"] = Strings.Space(0x12);
            //this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
            //this.BindingContext[this.VirmaniDataSet1, "virmani"].Position = this.BindingContext[this.VirmaniDataSet1, "virmani"].Count;

            DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();
            row["sifraobracunavirman"] = this.sifraobracuna.Text;
            row["namjena"] = "Dodani virman";
            row["oznacen"] = true;
            row["iznos"] = 0;
            row["izvordokumenta"] = izvordokumenta.Value;
            row["brojracunapla"] = vbdi.Value + "-" + ziro.Value;
            row["brojracunapri"] = "";
            row["OpisPlacanja"] = "Rucni virman";
            row["Cijena"] = 0;
            row["Kolicina"] = 0;
            this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
            this.BindingContext[this.VirmaniDataSet1, "virmani"].Position = this.BindingContext[this.VirmaniDataSet1, "virmani"].Count;
        }

        private void UltraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraCombo1_ValueChanged(object sender, EventArgs e)
        {
            if (!this.disableValueChange)
            {
                this.pozivzaduzenja.Checked = Conversions.ToBoolean(this.UltraCombo1.SelectedRow.Cells["pozivizaduzenja"].Value);
                this.poreziprirez.Checked = Conversions.ToBoolean(this.UltraCombo1.SelectedRow.Cells["poreziprirezzajednicki"].Value);
                this.izvordokumenta.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["sifraizvora"].Value);
                this.pla1.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["nazivziro"].Value);
                this.pla2.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["ulicaziro"].Value);
                this.pla3.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["mjestoziro"].Value);
                this.vbdi.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["vbdikorisnik"].Value);
                this.ziro.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["zirokorisnik"].Value);

                SetForm_BrojZaduzenja();

                if (this.fin)
                {
                    IEnumerator enumerator = null;
                    try
                    {
                        enumerator = this.VirmaniDataSet1.VIRMANI.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            current["pla1"] = RuntimeHelpers.GetObjectValue(this.pla1.Value);
                            current["pla2"] = RuntimeHelpers.GetObjectValue(this.pla2.Value);
                            current["pla3"] = RuntimeHelpers.GetObjectValue(this.pla3.Value);
                            current["brojracunapla"] = Operators.AddObject(Operators.AddObject(this.vbdi.Value, "-"), this.ziro.Value);
                            current["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.izvordokumenta.Value);
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
                        this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
                        return;
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                        //return;
                    }
                }
                this.StvoriPonovnoVirmane();
            }
            else if (invalidi)
            {
                try
                {
                    this.pozivzaduzenja.Checked = Conversions.ToBoolean(this.UltraCombo1.SelectedRow.Cells["pozivizaduzenja"].Value);
                    this.poreziprirez.Checked = Conversions.ToBoolean(this.UltraCombo1.SelectedRow.Cells["poreziprirezzajednicki"].Value);
                    this.izvordokumenta.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["sifraizvora"].Value);
                    this.pla1.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["nazivziro"].Value);
                    this.pla2.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["ulicaziro"].Value);
                    this.pla3.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["mjestoziro"].Value);
                    this.vbdi.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["vbdikorisnik"].Value);
                    this.ziro.Value = RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["zirokorisnik"].Value);

                    SetForm_BrojZaduzenja();

                    IEnumerator enumerator = null;
                    try
                    {
                        enumerator = this.VirmaniDataSet1.VIRMANI.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            current["pla1"] = RuntimeHelpers.GetObjectValue(this.pla1.Value);
                            current["pla2"] = RuntimeHelpers.GetObjectValue(this.pla2.Value);
                            current["pla3"] = RuntimeHelpers.GetObjectValue(this.pla3.Value);
                            current["brojracunapla"] = Operators.AddObject(Operators.AddObject(this.vbdi.Value, "-"), this.ziro.Value);
                            current["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.izvordokumenta.Value);
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
                        this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
                        return;
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                        //return;
                    }
                }
                catch { }
            }
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            this.BindingContext[this.VirmaniDataSet1, "VIRMANI"].EndCurrentEdit();
            try
            {
                this.davirmani.Update(this.VirmaniDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        private void UltraGrid1_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            object objectValue = @"^\d{7}-\d{10}$";
            if (this.UltraGrid1.ActiveCell.Column.Key == "BROJRACUNAPRI")
            {
                object[] objArray = new object[2];
                UltraGridCell activeCell = this.UltraGrid1.ActiveCell;
                objArray[0] = RuntimeHelpers.GetObjectValue(activeCell.Value);
                objArray[1] = RuntimeHelpers.GetObjectValue(objectValue);
                object[] arguments = objArray;
                bool[] copyBack = new bool[] { true, true };
                if (copyBack[0])
                {
                    activeCell.Value = RuntimeHelpers.GetObjectValue(arguments[0]);
                }
                if (copyBack[1])
                {
                    objectValue = RuntimeHelpers.GetObjectValue(arguments[1]);
                }
                if (Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(null, typeof(Regex), "IsMatch", arguments, null, null, copyBack))))
                {
                    Interaction.MsgBox("Greška kod unosa broja računa primatelja!", MsgBoxStyle.OkOnly, null);
                    e.Cancel = false;
                }
            }
            this.BindingContext[this.VirmaniDataSet1, "VIRMANI"].EndCurrentEdit();
            try
            {
                this.davirmani.Update(this.VirmaniDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }


        public void Virmani_IZ_Ira(ref UltraGrid con)
        {
            this.UltraCombo1.ReadOnly = true;
            PARTNERDataAdapter adapter = new PARTNERDataAdapter();
            PARTNERDataSet dataSet = new PARTNERDataSet();
            RowEnumerator enumerator = con.Selected.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraGridRow current = enumerator.Current;
                dataSet.Clear();
                adapter.FillByIDPARTNER(dataSet, Conversions.ToInteger(current.Cells["idpartner"].Value));
                if (Conversions.ToBoolean(Operators.AndObject(dataSet.PARTNER.Rows.Count > 0, Operators.CompareObjectGreater(current.Cells["sveukupno"].Value, 0, false))))
                {
                    DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();
                    row["oznacen"] = true;
                    row["sifraobracunavirman"] = "xxx";
                    row["pla1"] = Strings.Left(DB.N2T(dataSet.PARTNER.Rows[0]["nazivpartner"].ToString(), ""), 0x13);
                    row["pla2"] = Strings.Left(DB.N2T(dataSet.PARTNER.Rows[0]["partnermjesto"].ToString(), ""), 0x13);
                    row["pla3"] = Strings.Left(DB.N2T(dataSet.PARTNER.Rows[0]["partnerulica"].ToString(), ""), 0x13);
                    row["brojracunapla"] = "";
                    row["modelzaduzenja"] = "  ";
                    row["pozivzaduzenja"] = "  ";
                    row["pri1"] = RuntimeHelpers.GetObjectValue(this.pla1.Value);
                    row["pri2"] = RuntimeHelpers.GetObjectValue(this.pla2.Value);
                    row["pri3"] = RuntimeHelpers.GetObjectValue(this.pla3.Value);
                    row["brojracunapri"] = Operators.AddObject(Operators.AddObject(this.vbdi.Value, "-"), this.ziro.Value);
                    row["modelodobrenja"] = DB.N2T(RuntimeHelpers.GetObjectValue(current.Cells["model"].Value), "  ");
                    row["pozivodobrenja"] = DB.N2T(RuntimeHelpers.GetObjectValue(current.Cells["poziv"].Value), "");
                    row["sifraopisaplacanjavirman"] = "01";
                    row["OPISPLACANJAVIRMAN"] = Strings.Left(Conversions.ToString(Operators.ConcatenateObject("Plaćanje računa: ", current.Cells["idracun"].Value)), 0x21);
                    row["OZNACEN"] = true;
                    row["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value);
                    row["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value);
                    row["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.izvordokumenta.Value);
                    row["iznos"] = RuntimeHelpers.GetObjectValue(current.Cells["sveukupno"].Value);
                    row["namjena"] = "FIN";
                    this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
                }
            }
            try
            {
                this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        private void Virmani_Iz_Obracuna(string sifraobracuna, bool buttonkontrola)
        {
            sp_VIRMANIDataAdapter adapter = new sp_VIRMANIDataAdapter();
            using (sp_VIRMANIDataSet set = new sp_VIRMANIDataSet())
            {
                DataRow current = null;
                string str3 = string.Empty;
                string str4 = string.Empty;
                IEnumerator enumerator = null;
                IEnumerator enumerator2 = null;
                if (this.pozivzaduzenja.Checked)
                {
                    str3 = Conversions.ToString(1);
                }
                else
                {
                    str3 = Conversions.ToString(0);
                }
                if (this.poreziprirez.Checked)
                {
                    str4 = Conversions.ToString(0);
                }
                else
                {
                    str4 = Conversions.ToString(1);
                }
                string mb = Conversions.ToString(this.KorisnikDataSet1.KORISNIK.Rows[0]["korisnikoib"]);

                string joppd_vrsta = "";
                string[] poziv_na_broj;
                bool kontorlka = false;

                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                if (sifraobracuna.Length > 0)
                {
                    DataTable tbl = client.GetDataTable("Select Distinct OznakaIzvjesca From JOPPDA Inner Join JOPPDAObracun ON JOPPDA.ID = JOPPDAObracun.JOPPDA_ID Where Obracun_ID = '" + sifraobracuna + "'");

                    if (tbl.Rows.Count > 0)
                        joppd_vrsta = tbl.Rows[0][0].ToString();
                }

                adapter.Fill(set, sifraobracuna, str3, str4, this.pla1.Value.ToString(), this.pla2.Value.ToString(), this.pla3.Value.ToString(), this.vbdi.Value.ToString(), this.ziro.Value.ToString(), mb, (this.dd ? "1" : "0").ToString());

                try
                {
                    //ukoliko se radi rucno virman za invalde, u suprotnom odraduje staro                    
                    if (!buttonkontrola)
                    {
                        bool usao = false;
                        enumerator = set.Tables[0].Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            usao = true;
                            current = (DataRow)enumerator.Current;
                            DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();
                            row["oznacen"] = true;
                            row["sifraobracunavirman"] = sifraobracuna;
                            row["pla1"] = RuntimeHelpers.GetObjectValue(current["pla1"]);
                            row["pla2"] = RuntimeHelpers.GetObjectValue(current["pla2"]);
                            row["pla3"] = RuntimeHelpers.GetObjectValue(current["pla3"]);
                            row["brojracunapla"] = RuntimeHelpers.GetObjectValue(current["brojracunapla"]);

                            if (VirmaniWorkItemUser.isprazni_model)
                            {
                                row["modelzaduzenja"] = "99";
                                row["pozivzaduzenja"] = "";
                                kontorlka = true;
                            }
                            else
                            {
                                row["modelzaduzenja"] = RuntimeHelpers.GetObjectValue(current["modelzaduzenja"]);
                                row["pozivzaduzenja"] = RuntimeHelpers.GetObjectValue(current["pozivzaduzenja"]);
                            }
                            row["pri1"] = RuntimeHelpers.GetObjectValue(current["pri1"]);
                            row["pri2"] = RuntimeHelpers.GetObjectValue(current["pri2"]);
                            row["pri3"] = RuntimeHelpers.GetObjectValue(current["pri3"]);
                            row["brojracunapri"] = RuntimeHelpers.GetObjectValue(current["brojracunapri"]);
                            row["modelodobrenja"] = RuntimeHelpers.GetObjectValue(current["modelodobrenja"]);

                            if (RuntimeHelpers.GetObjectValue(current["namjena"]).ToString() == "Doprinosi" || RuntimeHelpers.GetObjectValue(current["namjena"]).ToString() == "Porez i prirez"
                                || RuntimeHelpers.GetObjectValue(current["namjena"]).ToString() == "Porez" || RuntimeHelpers.GetObjectValue(current["namjena"]).ToString() == "Prirez")
                            {
                                if (!VirmaniWorkItemUser.kontorla_potvde)
                                {
                                    poziv_na_broj = RuntimeHelpers.GetObjectValue(current["pozivodobrenja"]).ToString().Split('-');

                                    if (poziv_na_broj.Length > 1)
                                    {
                                        row["pozivodobrenja"] = poziv_na_broj[0] + "-" + poziv_na_broj[1] + "-" + joppd_vrsta;
                                    }
                                    else
                                    {
                                        row["pozivodobrenja"] = RuntimeHelpers.GetObjectValue(current["pozivodobrenja"]);
                                    }
                                }
                                else
                                {
                                    poziv_na_broj = RuntimeHelpers.GetObjectValue(current["pozivodobrenja"]).ToString().Split('-');

                                    if (poziv_na_broj.Length > 1)
                                    {
                                        row["pozivodobrenja"] = poziv_na_broj[0] + "-" + poziv_na_broj[1] + "-" + VirmaniWorkItemUser.oznaka_izvjesca;
                                    }
                                    else
                                    {
                                        row["pozivodobrenja"] = RuntimeHelpers.GetObjectValue(current["pozivodobrenja"]);
                                    }
                                }
                            }
                            else
                            {
                                row["pozivodobrenja"] = RuntimeHelpers.GetObjectValue(current["pozivodobrenja"]);
                            }

                            row["sifraopisaplacanjavirman"] = RuntimeHelpers.GetObjectValue(current["sifraopisaplacanjavirman"]);
                            row["OPISPLACANJAVIRMAN"] = RuntimeHelpers.GetObjectValue(current["OPISPLACANJAVIRMAN"]);
                            row["OZNACEN"] = true;
                            row["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value);
                            row["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value);
                            row["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.izvordokumenta.Value);
                            row["iznos"] = RuntimeHelpers.GetObjectValue(current["iznos"]);
                            row["namjena"] = RuntimeHelpers.GetObjectValue(current["namjena"]);

                            // Postavi šifru namjene:
                            //       - SALA - neto elemeni i neto plaća
                            //       - NITX - sve ostalo (109)
                            string namjena = RuntimeHelpers.GetObjectValue(current["namjena"]).ToString();

                            if (namjena.ToLower().Contains("neto"))
                            {
                                row["HUB3_SIFRANAMJENE"] = "SALA";

                                if (dd)
                                {
                                    string kategorija;
                                    try
                                    {
                                        kategorija = client.ExecuteScalar("Select IDKATEGORIJA From DDOBRACUNRadnici Where DDOBRACUNIDOBRACUN = '" + sifraobracuna + "' And DDIDRADNIK = '" + current["IDRADNIK"] + "'").ToString();
                                    }
                                    catch { kategorija = "0"; }

                                    row["OpisPlacanja"] = VratiOznaku(kategorija);
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                row["HUB3_SIFRANAMJENE"] = "NITX";
                            }

                            row["HUB3_HITNO"] = false;

                            this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
                        }
                        if (kontorlka)
                        {
                            VirmaniWorkItemUser.isprazni_model = false;
                        }

                        //generiranje virmana za invalide
                        if (VirmaniWorkItemUser.invalid && usao)
                        {
                            DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();

                            row["oznacen"] = true;
                            row["sifraobracunavirman"] = sifraobracuna;
                            row["pla1"] = RuntimeHelpers.GetObjectValue(current["pla1"]);
                            row["pla2"] = RuntimeHelpers.GetObjectValue(current["pla2"]);
                            row["pla3"] = RuntimeHelpers.GetObjectValue(current["pla3"]);
                            row["modelzaduzenja"] = "34";
                            row["pozivzaduzenja"] = "";
                            row["pri1"] = "Državni proračun RH";
                            row["pri2"] = "Naknada za invalide";
                            row["pri3"] = "";
                            row["brojracunapri"] = "1001005-1863000160";
                            row["modelodobrenja"] = "68";
                            row["sifraopisaplacanjavirman"] = "08";
                            row["OPISPLACANJAVIRMAN"] = "Uplata naknade";
                            row["OZNACEN"] = true;
                            row["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value);
                            row["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value);
                            row["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.izvordokumenta.Value);
                            row["namjena"] = "Doprinosi";
                            row["HUB3_SIFRANAMJENE"] = "NITX";
                            row["HUB3_HITNO"] = false;
                            row["brojracunapla"] = "";
                            try
                            {
                                row["iznos"] = KorisnikDataSet1.KORISNIK.Rows[0]["StopaZaInvalide"].ToString();
                            }
                            catch { row["iznos"] = 0; }
                            row["pozivodobrenja"] = "5118-" + KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIKOIB"].ToString() + "-" + joppd_vrsta;


                            this.VirmaniDataSet1.VIRMANI.Rows.Add(row);

                            usao = false;
                        }
                    }
                    else
                    {
                        string sifra_obracun = "";
                        string poziv_odobrenja = "";
                        Nullable<DateTime> datum_izvrsenja = new DateTime();
                        Nullable<DateTime> datum_predaje = new DateTime();
                        Nullable<int> izvor_dokumenta = null;
                        int id_virman = 0;
                        Nullable<decimal> iznos = null;

                        if (!NoviVirman(client))
                        {
                            DialogResult result = MessageBox.Show(string.Format(
                            "Virman za {0} mjesec je već napravljen i nije moguće napraviti još jedan.\nŽelite li otvoriti postojeći virman?",
                            DateTime.Now.Month), "Virman za invalide", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                DataRow red = client.GetDataTable("Select Distinct IDVIRMAN, SIFRAOBRACUNAVIRMAN, POZIVODOBRENJA, DATUMVALUTE, DATUMPODNOSENJA, IZVORDOKUMENTA, IZNOS " + 
                                                                  "From VIRMANI Where YEAR(DATUMPODNOSENJA) = " + DateTime.Now.Year + "And MONTH(DATUMPODNOSENJA) = " +
                                                                  DateTime.Now.Month + " And SIFRAOBRACUNAVIRMAN Like 'INV-%'").Rows[0];

                                sifra_obracun = red["SIFRAOBRACUNAVIRMAN"].ToString();
                                poziv_odobrenja = red["POZIVODOBRENJA"].ToString();
                                datum_izvrsenja = Convert.ToDateTime(red["DATUMVALUTE"]);
                                datum_predaje = Convert.ToDateTime(red["DATUMPODNOSENJA"]);
                                izvor_dokumenta = Convert.ToInt32(red["IZVORDOKUMENTA"]);
                                id_virman = Convert.ToInt32(red["IDVIRMAN"]);
                                iznos = Convert.ToDecimal(red["IZNOS"]);

                                //28.10.2016
                                if (izvor_dokumenta != null)
                                {
                                    if ((int)izvor_dokumenta != Convert.ToInt32(izvordokumenta.Value))
                                    {
                                        izvor_dokumenta = Convert.ToInt32(izvordokumenta.Value);

                                        client.ExecuteNonQuery("Update VIRMANI Set IZVORDOKUMENTA = '" + izvor_dokumenta + "', PLA1 = '" + pla1.Value.ToString() + "', " + 
                                                "PLA2 = '" + pla2.Value.ToString() + "', PLA3 = '" + pla3.Value.ToString() + "', BROJRACUNAPLA = '" + 
                                                vbdi.Value.ToString() + "-" + ziro.Value.ToString() + "' Where IDVIRMAN = " + id_virman);
                                    }
                                }


                                client.ExecuteNonQuery("Delete from VIRMANI Where YEAR(DATUMPODNOSENJA) = " + DateTime.Now.Year +
                                                       "And MONTH(DATUMPODNOSENJA) = " + DateTime.Now.Month + " And SIFRAOBRACUNAVIRMAN Like 'INV-%'");



                                DataRow find = this.VirmaniDataSet1.VIRMANI.FindByIDVIRMAN(id_virman);

                                if (find != null)
                                {
                                    this.VirmaniDataSet1.VIRMANI.Rows.Remove(find);
                                }
                            }
                            else
                            {
                                return;
                            }
                        }

                        DataRow korisnik_level1 = KorisnikDataSet1.Tables["KorisnikLevel1"].Select("IDZIRO = " + (int)UltraCombo1.Value)[0];

                        DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();

                        string zadnji = client.ExecuteScalar("Select Max(CAST(SUBSTRING(SIFRAOBRACUNAVIRMAN,5,7) as int)) From VIRMANI Where SIFRAOBRACUNAVIRMAN Like 'INV-%'").ToString();

                        try
                        {
                            zadnji = (Convert.ToInt32(zadnji) + 1).ToString();
                        }
                        catch { zadnji = "1"; }

                        row["oznacen"] = true;

                        if (sifra_obracun.Length == 0)
                        {
                            row["sifraobracunavirman"] = "INV-" + zadnji;
                            row["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value);
                            row["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value);
                            row["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.izvordokumenta.Value);
                            row["pozivodobrenja"] = "5118-" + KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIKOIB"].ToString() + "-" + vrsta_izvjesca;
                            try
                            {
                                row["iznos"] = KorisnikDataSet1.KORISNIK.Rows[0]["StopaZaInvalide"].ToString();
                            }
                            catch { row["iznos"] = 0; }
                        }
                        else
                        {
                            row["sifraobracunavirman"] = sifra_obracun;
                            row["DATUMVALUTE"] = datum_izvrsenja;
                            row["DATUMPODNOSENJA"] = datum_predaje;
                            row["izvordokumenta"] = izvor_dokumenta;
                            row["pozivodobrenja"] = poziv_odobrenja;
                            row["iznos"] = iznos;
                        }

                        row["pla1"] = korisnik_level1["NAZIVZIRO"].ToString();
                        row["pla2"] = korisnik_level1["ULICAZIRO"].ToString();
                        row["pla3"] = korisnik_level1["MJESTOZIRO"].ToString();
                        row["modelzaduzenja"] = "34";
                        row["pozivzaduzenja"] = "";
                        row["pri1"] = "Državni proračun RH";
                        row["pri2"] = "Naknada za invalide";
                        row["pri3"] = "";
                        row["brojracunapri"] = "1001005-1863000160";
                        row["modelodobrenja"] = "68";
                        row["sifraopisaplacanjavirman"] = "08";
                        row["OPISPLACANJAVIRMAN"] = "Uplata naknade";
                        row["OZNACEN"] = true;
                        row["namjena"] = "Doprinosi";
                        row["HUB3_SIFRANAMJENE"] = "NITX";
                        row["HUB3_HITNO"] = false;
                        row["brojracunapla"] = korisnik_level1["VBDIKORISNIK"].ToString() + "-" + korisnik_level1["ZIROKORISNIK"].ToString();

                        this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
                    }
                }
                finally
                {
                    if (kontorlka)
                    {
                        VirmaniWorkItemUser.isprazni_model = false;
                    }
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                int num = 1;
                try
                {
                    enumerator2 = this.VirmaniDataSet1.VIRMANI.Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        current = (DataRow)enumerator2.Current;
                        current["idvirman"] = num;
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
            }
            if (this.dd)
            {
                try
                {
                    this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
                    return;
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
            try
            {
                this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            }
            catch (System.Exception exception4)
            {
                throw exception4;

            }
            try
            {
                this.davirmani.Update(this.VirmaniDataSet1);
            }
            catch (System.Exception exception5)
            {
                throw exception5;
            }
        }

        private object VratiOznaku(string kategorija)
        {
            //if (kategorija == "1" || kategorija == "2")
            //{
            //    return "130";
            //}
            //else if (kategorija == "3" || kategorija == "4")
            //{
            //    return "130";
            //}
            //else if (kategorija == "0")
            //{
            //    return "399";
            //}
            //else
            //{
            //    return "160";
            //}

            //db - 18.1.2017
            if (kategorija == "1" || kategorija == "2" || kategorija == "990" || kategorija == "989")
            {
                return "130";
            }

            else if (kategorija == "0" || kategorija == "3" || kategorija == "4" || kategorija == "988" || kategorija == "987" || kategorija == "7" || kategorija == "8" || kategorija == "9" || kategorija == "10" || kategorija == "984" || kategorija == "983" || kategorija == "982" || kategorija == "981")
            {
                return "399";
            }
            else
            {
                return "160";
            }
        }

        private bool NoviVirman(Mipsed7.DataAccessLayer.SqlClient client)
        {
            int count = Convert.ToInt32(client.ExecuteScalar("Select Count(SIFRAOBRACUNAVIRMAN) From VIRMANI Where YEAR(DATUMPODNOSENJA) = " +
                                DateTime.Now.Year + "And MONTH(DATUMPODNOSENJA) = " + DateTime.Now.Month + " And SIFRAOBRACUNAVIRMAN Like 'INV-%'"));

            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Virmani_IZ_Ura(ref UltraGrid con)
        {
            PARTNERDataAdapter adapter = new PARTNERDataAdapter();
            PARTNERDataSet dataSet = new PARTNERDataSet();
            RowEnumerator enumerator = con.Selected.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraGridRow current = enumerator.Current;
                dataSet.Clear();
                adapter.FillByIDPARTNER(dataSet, Conversions.ToInteger(current.Cells["urapartneridpartner"].Value));
                if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(dataSet.PARTNER.Rows.Count > 0, Operators.CompareObjectGreater(current.Cells["uraukupno"].Value, 0, false)), DB.N2T(RuntimeHelpers.GetObjectValue(dataSet.PARTNER.Rows[0]["partnerziro1"]), "") != "")))
                {
                    DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();
                    row["oznacen"] = true;
                    row["sifraobracunavirman"] = "xxx";
                    row["pla1"] = RuntimeHelpers.GetObjectValue(this.pla1.Value);
                    row["pla2"] = RuntimeHelpers.GetObjectValue(this.pla2.Value);
                    row["pla3"] = RuntimeHelpers.GetObjectValue(this.pla3.Value);
                    row["brojracunapla"] = Operators.AddObject(Operators.AddObject(this.vbdi.Value, "-"), this.ziro.Value);
                    row["modelzaduzenja"] = "";
                    row["pozivzaduzenja"] = "";
                    row["pri1"] = Strings.Left(DB.N2T(dataSet.PARTNER.Rows[0]["nazivpartner"].ToString(), ""), 0x13);
                    row["pri2"] = Strings.Left(DB.N2T(dataSet.PARTNER.Rows[0]["partnermjesto"].ToString(), ""), 0x13);
                    row["pri3"] = Strings.Left(DB.N2T(dataSet.PARTNER.Rows[0]["partnerulica"].ToString(), ""), 0x13);
                    row["brojracunapri"] = DB.N2T(dataSet.PARTNER.Rows[0]["partnerziro1"].ToString(), "");
                    row["modelodobrenja"] = DB.N2T(RuntimeHelpers.GetObjectValue(current.Cells["uramodel"].Value), "");
                    row["pozivodobrenja"] = DB.N2T(RuntimeHelpers.GetObjectValue(current.Cells["urapozivnabroj"].Value), "");
                    row["sifraopisaplacanjavirman"] = "01";
                    row["OPISPLACANJAVIRMAN"] = Strings.Left(Conversions.ToString(Operators.ConcatenateObject("Plaćanje računa:", current.Cells["urabrojracunadobavljaca"].Value)), 0x21);
                    row["OZNACEN"] = true;
                    row["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value);
                    row["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value);
                    row["izvordokumenta"] = RuntimeHelpers.GetObjectValue(this.izvordokumenta.Value);
                    row["iznos"] = RuntimeHelpers.GetObjectValue(current.Cells["uraukupno"].Value);
                    row["namjena"] = "FIN";
                    this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
                }
            }
            try
            {
                this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        private int GetRazrednoOdjeljenjeID(int id_ucenik, int id_obracun, Mipsed7.DataAccessLayer.SqlClient client)
        {
            string odjeljenje = string.Empty;
            odjeljenje = client.ExecuteScalar("Select RazrednoOdjeljenjeID From UF_ObracunStavka Where ObracunID = " + id_obracun + " And UcenikID = " + id_ucenik).ToString();
            return Convert.ToInt32(odjeljenje);
        }

        //ucenicko fakturiranje virmani
        public void Virmani_IZ_UF(ref UltraGrid con, int id_obracuna, string naziv_obracuna, List<int> ucenici, int ustanova)
        {
            string poziv_na_broj = string.Empty;
            string mjesec = string.Empty;
            string rkp = string.Empty;
            bool pdv_napomena = false;
            bool otvoreni_iznos = false;
            string opis_placanja = string.Empty;

            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtUcenici = new DataTable();
            DataTable dtVirmani = new DataTable();

            pdv_napomena = Convert.ToBoolean(client.ExecuteScalar("Select PDVNapomena From UF_Ustanova Where ID = " + ustanova));
            otvoreni_iznos = Convert.ToBoolean(client.ExecuteScalar("Select OtvoreneStavke From UF_Ustanova Where ID = " + ustanova));

            dtUcenici = client.GetDataTable("Select Distinct UcenikID, ZaPlatiti From [UF_UcenikZaduzenje] Where ObracunID = '" + id_obracuna + "'");

            if (ucenici == null)
            {
                dtVirmani = client.GetDataTable("Select UcenikID, UstanovaID, ZaPlatiti, PozNaBrOdobrenjaIzracun, Ime, Prezime, Ucenik_adresa, Ucenik_grad, Ustanova_broj_racuna, " +
                                      "Ustanova_broj_banke, Sifra_vrste_racuna, Naziv_ustanove, Adresa_ustanove, Ustanova_grad, Ustanova_postanski_broj, Ustanova_OIB, Sifra_ustanove, Godina, Mjesec, " +
                                      "Model, PozivNaBroj01, OIB_Ucenik, ModelOdobrenja2, Broj, ModelOdobrenja, PozivNaBrojOdobrenja, '' As Otvoreno, StvarnaKolicina, Cijena, opisProizvod, ImeRoditelj, " +
                                      "PrezimeRoditelj, OIBRoditelj From V_UF_ObracunVirmani Where ObracunID = '" + id_obracuna + "' And UstanovaID = " + ustanova);
            }
            else
            {
                string id_ucenici = string.Empty;
                foreach (int id in ucenici)
                {
                    if (id_ucenici.Length == 0)
                    {
                        id_ucenici = id.ToString();
                    }
                    else
                    {
                        id_ucenici += "," + id.ToString();
                    }
                }
                dtVirmani = client.GetDataTable("Select UcenikID, UstanovaID, ZaPlatiti, PozNaBrOdobrenjaIzracun, Ime, Prezime, Ucenik_adresa, Ucenik_grad, Ustanova_broj_racuna, " +
                                        "Ustanova_broj_banke, Sifra_vrste_racuna, Naziv_ustanove, Adresa_ustanove, Ustanova_grad, Ustanova_postanski_broj, Ustanova_OIB, Sifra_ustanove, Godina, Mjesec, " +
                                        "Model, PozivNaBroj01, OIB_Ucenik, ModelOdobrenja2, Broj, ModelOdobrenja, PozivNaBrojOdobrenja, '' As Otvoreno, StvarnaKolicina, Cijena, opisProizvod, ImeRoditelj, " +
                                        "PrezimeRoditelj, OIBRoditelj From V_UF_ObracunVirmani Where ObracunID = '" + id_obracuna + "' And UcenikID IN (" + id_ucenici + ") And UstanovaID = " + ustanova);
            }

            rkp = client.ExecuteScalar("Select Top(1) RKP From KORISNIK").ToString();

            foreach (DataRow red_virmani in dtVirmani.Rows)
            {
                //nepotrebno za to jersad prikazujemo svaku stavku koja je u obracunu
                //foreach (DataRow red_ucenici in dtUcenici.Rows)
                //{
                //    if (red_ucenici["UcenikID"].ToString() == red_virmani["UcenikID"].ToString())
                //    {
                //        cijena = Convert.ToDecimal(red_ucenici["ZaPlatiti"]) + Convert.ToDecimal(red_virmani["ZaPlatiti"]);
                //        red_virmani["ZaPlatiti"] = cijena;
                //    }
                //}

                //otvoreni iznos
                red_virmani["Otvoreno"] = GetOtvoreno(red_virmani["UcenikID"].ToString()).ToString("F");

            }

            foreach (DataRow red_virmani in dtVirmani.Rows)
            {
                if ((int)red_virmani["Mjesec"] < 10)
                    mjesec = "0" + red_virmani["Mjesec"].ToString();
                else
                    mjesec = red_virmani["Mjesec"].ToString();

                DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();

                if (red_virmani["Sifra_ustanove"].ToString().Length > 2)
                {
                    MessageBox.Show("Šifra ustanove je neispravna.\nŠifra ustanove može sadržavati maksimalno 2 znaka.");
                    return;
                }

                if (red_virmani["Broj"].ToString() == "1")
                {

                    if (red_virmani["Model"].ToString().Length > 0)
                    {
                        poziv_na_broj = red_virmani["PozivNaBroj01"].ToString().Trim() + "-" + rkp + "-" + red_virmani["OIB_Ucenik"].ToString().Trim();
                        row["modelodobrenja"] = red_virmani["Model"].ToString();
                    }
                    else
                    {
                        poziv_na_broj = red_virmani["Sifra_ustanove"].ToString() + mjesec + red_virmani["Godina"].ToString().Substring(2) + "-" + red_virmani["UcenikID"].ToString() + "-" + red_virmani["PozNaBrOdobrenjaIzracun"].ToString();
                    }
                }
                else if (red_virmani["Broj"].ToString() == "2")
                {
                    int id_raz_odjeljenje = GetRazrednoOdjeljenjeID(Convert.ToInt32(red_virmani["UcenikID"]), id_obracuna, client);
                    string raz_odjeljenje = string.Empty;
                    if (id_raz_odjeljenje.ToString().Length > 2)
                    {
                        raz_odjeljenje = id_raz_odjeljenje.ToString().Substring(0, 2);
                    }
                    else if (id_raz_odjeljenje.ToString().Length == 1)
                    {
                        raz_odjeljenje = "0" + id_raz_odjeljenje.ToString();
                    }
                    else
                    {
                        raz_odjeljenje = id_raz_odjeljenje.ToString();
                    }

                    poziv_na_broj = mjesec + red_virmani["Godina"].ToString().Substring(2) + "-" + red_virmani["Sifra_ustanove"].ToString() +
                                     raz_odjeljenje + "-" + red_virmani["OIB_Ucenik"].ToString().Trim();

                    row["modelodobrenja"] = red_virmani["ModelOdobrenja2"].ToString();
                }
                else if (red_virmani["Broj"].ToString() == "3")
                {
                    if (red_virmani["UcenikID"].ToString().Length == 1)
                    {
                        poziv_na_broj = red_virmani["PozivNaBrojOdobrenja"].ToString().Trim() + "-" + red_virmani["OIB_Ucenik"].ToString().Trim() + "-000" + red_virmani["UcenikID"].ToString().Trim();
                    }
                    else if (red_virmani["UcenikID"].ToString().Length == 2)
                    {
                        poziv_na_broj = red_virmani["PozivNaBrojOdobrenja"].ToString().Trim() + "-" + red_virmani["OIB_Ucenik"].ToString().Trim() + "-00" + red_virmani["UcenikID"].ToString().Trim();
                    }
                    else if (red_virmani["UcenikID"].ToString().Length == 3)
                    {
                        poziv_na_broj = red_virmani["PozivNaBrojOdobrenja"].ToString().Trim() + "-" + red_virmani["OIB_Ucenik"].ToString().Trim() + "-0" + red_virmani["UcenikID"].ToString().Trim();
                    }
                    else if (red_virmani["UcenikID"].ToString().Length == 4)
                    {
                        poziv_na_broj = red_virmani["PozivNaBrojOdobrenja"].ToString().Trim() + "-" + red_virmani["OIB_Ucenik"].ToString().Trim() + "-" + red_virmani["UcenikID"].ToString().Trim();
                    }
                    row["modelodobrenja"] = red_virmani["ModelOdobrenja"].ToString();
                }

                row["modelzaduzenja"] = "00";
                row["namjena"] = "FIN";
                row["oznacen"] = true;
                row["sifraobracunavirman"] = id_obracuna;
                row["pla1"] = red_virmani["Ime"].ToString() + " " + red_virmani["Prezime"].ToString();

                if (red_virmani["Ucenik_adresa"].ToString().Length > 30)
                    row["pla2"] = red_virmani["Ucenik_adresa"].ToString().Substring(0, 30);
                else
                    row["pla2"] = red_virmani["Ucenik_adresa"].ToString();

                if (red_virmani["Ucenik_grad"].ToString().Length > 30)
                    row["pla3"] = red_virmani["Ucenik_grad"].ToString().Substring(0, 30);
                else
                    row["pla3"] = red_virmani["Ucenik_grad"].ToString();

                row["brojracunapla"] = "neprimjenjivo";
                row["pozivzaduzenja"] = "";

                if (red_virmani["Naziv_ustanove"].ToString().Length > 30)
                    row["pri1"] = red_virmani["Naziv_ustanove"].ToString().Substring(0, 30);
                else
                    row["pri1"] = red_virmani["Naziv_ustanove"].ToString();

                if (red_virmani["Adresa_ustanove"].ToString().Length > 30)
                    row["pri2"] = red_virmani["Adresa_ustanove"].ToString().Substring(0, 30);
                else
                    row["pri2"] = red_virmani["Adresa_ustanove"].ToString();

                if ((red_virmani["Ustanova_postanski_broj"] + ", " + red_virmani["Ustanova_grad"].ToString()).Length > 30)
                    row["pri3"] = (red_virmani["Ustanova_postanski_broj"] + ", " + red_virmani["Ustanova_grad"].ToString()).Substring(0, 30);
                else
                    row["pri3"] = red_virmani["Ustanova_postanski_broj"] + ", " + red_virmani["Ustanova_grad"].ToString();

                row["brojracunapri"] = red_virmani["Ustanova_broj_banke"].ToString() + "-" + red_virmani["Ustanova_broj_racuna"].ToString();
                row["pozivodobrenja"] = poziv_na_broj;
                row["sifraopisaplacanjavirman"] = "";

                opis_placanja = "";
                decimal otvoreno = Convert.ToDecimal(red_virmani["Otvoreno"]);
                if (otvoreni_iznos)
                {
                    if (otvoreno < 0)
                    {
                        opis_placanja = "Na dan " + DateTime.Now.Date.ToString("dd.MM.yyyy.") + " dug je " + Math.Abs(otvoreno).ToString() + "kn ";
                    }
                    else if (otvoreno > 0)
                    {
                        opis_placanja = "Na dan " + DateTime.Now.Date.ToString("dd.MM.yyyy.") + " preplata je " + Math.Abs(otvoreno).ToString() + "kn ";
                    }
                    else
                    {
                        opis_placanja = "Na dan " + DateTime.Now.Date.ToString("dd.MM.yyyy.") + " nema dugovanja ";
                    }

                }
                if (pdv_napomena)
                {
                    opis_placanja += "OSL.PL.PDV po čl.39 zakona o PDV ";
                }

                row["OPISPLACANJAVIRMAN"] = naziv_obracuna;
                row["OZNACEN"] = true;
                row["DATUMVALUTE"] = DateTime.Now;
                row["DATUMPODNOSENJA"] = DateTime.Now;
                row["izvordokumenta"] = red_virmani["Sifra_vrste_racuna"];

                //maknuto jer se prikazuje svaka stavka
                //row["iznos"] = red_virmani["ZaPlatiti"];
                row["iznos"] = red_virmani["Cijena"].ToString();

                row["HUB3_SIFRANAMJENE"] = "OTHR";
                row["OpisPlacanja"] = opis_placanja;
                row["Roditelj"] = red_virmani["ImeRoditelj"].ToString() + " " + red_virmani["PrezimeRoditelj"].ToString();
                //spremamo oib roditelja umjesto adrese
                row["RoditeljAdresa"] = red_virmani["OIBRoditelj"].ToString();
                row["OpisProizvoda"] = red_virmani["opisProizvod"].ToString();
                row["Cijena"] = red_virmani["Cijena"].ToString();
                row["Kolicina"] = red_virmani["StvarnaKolicina"].ToString();

                this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
            }
            try
            {
                this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            pID = id_obracuna;

        }

        private decimal GetOtvoreno(string id_ucenik)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Select ISNULL(SUM(GKSTAVKA.POTRAZUJE - GKSTAVKA.Duguje), 0) From GKSTAVKA Inner Join PARTNER On GKSTAVKA.IDPARTNER = PARTNER.IDPARTNER Inner Join UF_Ucenik On " +
                                  "PARTNER.PARTNEROIB = UF_Ucenik.OIB Where UF_Ucenik.ID =@ID And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) And IDKONTO Not Like '9%'";
            sqlUpit.Parameters.Add(new SqlParameter("@ID", id_ucenik));

            decimal otvoreno = 0;

            try
            {
                otvoreno = Convert.ToDecimal(sqlUpit.ExecuteScalar());
            }
            catch
            { }
            return otvoreno;
        }


        private object GetZasticeniNaziv(string naziv, string idRadnik, Mipsed7.DataAccessLayer.SqlClient client)
        {
            string vrati = "";

            try { vrati = client.ExecuteScalar("Select Top 1 ZADTEKUCIIZUZECE From RADNIKIzuzeceOdOvrhe Where IDRADNIK = '" + idRadnik + "'").ToString(); }
            catch { }

            if (vrati.Length > 0)
            {
                return client.ExecuteScalar("Select NazivBanke1 From RADNIKIzuzeceOdOvrhe Inner Join BANKE On RADNIKIzuzeceOdOvrhe.BANKAZASTICENOIDBANKE = BANKE.IDBANKE " +
                        "Where RADNIKIzuzeceOdOvrhe.IDRADNIK = '" + idRadnik + "'").ToString();
            }

            return vbdi;
        }

        private object GetZasticeniVBDI(string vbdi, string idRadnik, Mipsed7.DataAccessLayer.SqlClient client)
        {
            string vrati = "";

            try { vrati = client.ExecuteScalar("Select Top 1 ZADTEKUCIIZUZECE From RADNIKIzuzeceOdOvrhe Where IDRADNIK = '" + idRadnik + "'").ToString(); }
            catch { }

            if (vrati.Length > 0)
            {
                return client.ExecuteScalar("Select VBDIBANKE From RADNIKIzuzeceOdOvrhe Inner Join BANKE On RADNIKIzuzeceOdOvrhe.BANKAZASTICENOIDBANKE = BANKE.IDBANKE " +
                        "Where RADNIKIzuzeceOdOvrhe.IDRADNIK = '" + idRadnik + "'").ToString();
            }

            return vbdi;
        }

        private object GetZasticeniTekuci(string tekuci, string idRadnik, Mipsed7.DataAccessLayer.SqlClient client)
        {
            string vrati = "";

            try { vrati = client.ExecuteScalar("Select Top 1 ZADTEKUCIIZUZECE From RADNIKIzuzeceOdOvrhe Where IDRADNIK = '" + idRadnik + "'").ToString(); }
            catch { }

            if (vrati.Length > 0)
                return vrati;

            return tekuci;
        }


        private void VirmaniPutniNalog(ref UltraGrid con, string id_obracuna, string naziv_obracuna, DataRow korisnik_red)
        {

            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtPutniNalog = client.GetDataTable("Select Distinct RegistarPutnihNaloga.ID_Radnik, CAST(0 as money) As Iznos, " +
            "(Case When RegistarPutnihNaloga.VrstaDjelatnika = 1 Then RADNIK.IME Else DDRADNIK.DDIME End) As IME, (Case When RegistarPutnihNaloga.VrstaDjelatnika = 1 Then RADNIK.PREZIME Else DDRADNIK.DDPREZIME End) As PREZIME,  " +
            "(Case When RegistarPutnihNaloga.VrstaDjelatnika = 1 Then RADNIK.mjesto Else DDRADNIK.DDMJESTO End) As Mjesto, (Case When RegistarPutnihNaloga.VrstaDjelatnika = 1 Then RADNIK.ulica + ' ' + " +
            "RADNIK.kucnibroj Else DDRADNIK.DDADRESA + ' ' + DDRADNIK.DDkucnibroj End) As Adresa, (Case When RegistarPutnihNaloga.VrstaDjelatnika = 1 Then RADNIK.TEKUCI Else DDRADNIK.DDZRN End) As Tekuci, " +
            "(Case When RegistarPutnihNaloga.VrstaDjelatnika = 1 Then (Select NAZIVBANKE1 From BANKE Inner Join RADNIK On RADNIK.IDBANKE = BANKE.IDBANKE Where RADNIK.IDRADNIK = RegistarPutnihNaloga.ID_Radnik) " +
            "Else (Select NAZIVBANKE1 From BANKE Inner Join DDRADNIK On DDRADNIK.IDBANKE = BANKE.IDBANKE Where DDRADNIK.DDIDRADNIK = RegistarPutnihNaloga.ID_Radnik) End) As NazivBanke1, " +
            "(Case When RegistarPutnihNaloga.VrstaDjelatnika = 1 Then (Select VBDIBANKE From BANKE Inner Join RADNIK On RADNIK.IDBANKE = BANKE.IDBANKE Where RADNIK.IDRADNIK = RegistarPutnihNaloga.ID_Radnik) " +
            "Else (Select VBDIBANKE From BANKE Inner Join DDRADNIK On DDRADNIK.IDBANKE = BANKE.IDBANKE Where DDRADNIK.DDIDRADNIK = RegistarPutnihNaloga.ID_Radnik) End) As VBDIBANKE, " +
            "(Case When TroskoviVlastitogVozila > 0 Then '200' Else '200' End) As VrstaPrimanja, RegistarPutnihNaloga.VrstaDjelatnika From RegistarPutnihNaloga " +
            "Left Join RADNIK On RegistarPutnihNaloga.ID_Radnik = RADNIK.IDRADNIK Left Join DDRADNIK On RegistarPutnihNaloga.ID_Radnik = DDRADNIK.DDIDRADNIK " +
            "Where (TroskoviPutovanja + TroskoviVlastitogVozila + OstaliTroskovi + Dnevnice + TroskoviSmjestaja - Akontacija) > 0 And ID IN(" + id_obracuna + ") And ID_NacinIsplate = 2");

            foreach (DataRow nalog in dtPutniNalog.Rows)
            {
                nalog["Tekuci"] = GetZasticeniTekuci(nalog["Tekuci"].ToString(), nalog["ID_Radnik"].ToString(), client);
                nalog["VBDIBANKE"] = GetZasticeniVBDI(nalog["VBDIBANKE"].ToString(), nalog["ID_Radnik"].ToString(), client);
                nalog["NazivBanke1"] = GetZasticeniNaziv(nalog["NazivBanke1"].ToString(), nalog["ID_Radnik"].ToString(), client);

                nalog["Iznos"] = client.ExecuteScalar("Select Case When (IsTroskoviAutoputa = 1 And IsDrugiTroskovi = 1 And IsTroskoviSmjestaja = 1) " +
                "Then Sum(TroskoviVlastitogVozila + Dnevnice - Akontacija) When (IsTroskoviAutoputa = 1 And IsDrugiTroskovi = 1 And IsTroskoviSmjestaja = 0) " +
                "Then Sum(TroskoviVlastitogVozila + TroskoviSmjestaja + Dnevnice - Akontacija) When (IsTroskoviAutoputa = 1 And IsDrugiTroskovi = 0 And IsTroskoviSmjestaja = 0) " +
                "Then Sum(TroskoviVlastitogVozila + TroskoviSmjestaja + OstaliTroskovi + Dnevnice - Akontacija) " +
                "When (IsTroskoviAutoputa = 1 And IsDrugiTroskovi = 0 And IsTroskoviSmjestaja = 1) Then Sum(TroskoviVlastitogVozila + OstaliTroskovi + Dnevnice - Akontacija) " +
                "When (IsTroskoviAutoputa = 0 And IsDrugiTroskovi = 1 And IsTroskoviSmjestaja = 1) Then Sum(TroskoviVlastitogVozila + TroskoviPutovanja + Dnevnice - Akontacija) " +
                "When (IsTroskoviAutoputa = 0 And IsDrugiTroskovi = 0 And IsTroskoviSmjestaja = 1) Then Sum(TroskoviVlastitogVozila + TroskoviPutovanja + OstaliTroskovi + Dnevnice - Akontacija) " +
                "When (IsTroskoviAutoputa = 0 And IsDrugiTroskovi = 1 And IsTroskoviSmjestaja = 0) Then Sum(TroskoviVlastitogVozila + TroskoviPutovanja + TroskoviSmjestaja + Dnevnice - Akontacija) " +
                "Else Sum(TroskoviPutovanja + TroskoviVlastitogVozila + OstaliTroskovi + Dnevnice + TroskoviSmjestaja - Akontacija) END " +
                "From RegistarPutnihNaloga Where (TroskoviPutovanja + TroskoviVlastitogVozila + OstaliTroskovi + Dnevnice + TroskoviSmjestaja - Akontacija) > 0 " +
                "And ID_Radnik = '" + nalog["ID_Radnik"].ToString() + "' And ID_NacinIsplate = 2 And ID IN(" + id_obracuna + ") And VrstaDjelatnika = " + nalog["VrstaDjelatnika"] + " Group By IsTroskoviSmjestaja, IsTroskoviAutoputa, IsDrugiTroskovi");
            }

            foreach (DataRow nalog in dtPutniNalog.Rows)
            {
                DataRow row = this.VirmaniDataSet1.VIRMANI.NewRow();

                row["modelzaduzenja"] = "";
                row["namjena"] = "FIN";
                row["oznacen"] = true;
                row["sifraobracunavirman"] = "putni_nalog";
                row["pri1"] = nalog["IME"].ToString() + " " + nalog["PREZIME"].ToString();

                if (nalog["Adresa"].ToString().Length > 30)
                    row["pri2"] = nalog["Adresa"].ToString().Substring(0, 30);
                else
                    row["pri2"] = nalog["Adresa"].ToString();

                if (nalog["mjesto"].ToString().Length > 30)
                    row["pri3"] = nalog["mjesto"].ToString().Substring(0, 30);
                else
                    row["pri3"] = nalog["mjesto"].ToString();

                row["brojracunapla"] = korisnik_red["VBDIKORISNIK"].ToString() + "-" + korisnik_red["ZIROKORISNIK"].ToString();
                row["pozivzaduzenja"] = "";

                if (korisnik_red["NAZIVZIRO"].ToString().Length > 30)
                    row["pla1"] = korisnik_red["NAZIVZIRO"].ToString().Substring(0, 30);
                else
                    row["pla1"] = korisnik_red["NAZIVZIRO"].ToString();

                if (korisnik_red["ULICAZIRO"].ToString().Length > 30)
                    row["pla2"] = korisnik_red["ULICAZIRO"].ToString().Substring(0, 30);
                else
                    row["pla2"] = korisnik_red["ULICAZIRO"].ToString();

                if (korisnik_red["MJESTOZIRO"].ToString().Length > 30)
                    row["pla3"] = korisnik_red["MJESTOZIRO"].ToString().Substring(0, 30);
                else
                    row["pla3"] = korisnik_red["MJESTOZIRO"].ToString();

                row["brojracunapri"] = nalog["VBDIBANKE"].ToString() + "-" + nalog["TEKUCI"].ToString();
                row["izvordokumenta"] = korisnik_red["SifraIzvora"];

                row["pozivodobrenja"] = "";
                row["sifraopisaplacanjavirman"] = "";
                row["OPISPLACANJAVIRMAN"] = naziv_obracuna;
                row["OZNACEN"] = true;
                row["DATUMVALUTE"] = DateTime.Now;
                row["DATUMPODNOSENJA"] = DateTime.Now;
                row["iznos"] = nalog["Iznos"];
                row["HUB3_SIFRANAMJENE"] = "OTHR";
                row["OpisPlacanja"] = nalog["VrstaPrimanja"].ToString();

                this.VirmaniDataSet1.VIRMANI.Rows.Add(row);
            }
            try
            {
                this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();

                this.sifraobracuna.Value = "PutniNalog";
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        private void Virmani_Load_1(object sender, EventArgs e)
        {
            if (this.smartPartInfo1.Title == "Virmani")
            {
                this.dd = false;
            }
            else
            {
                this.dd = true;
            }

            MainWorkItem item = new MainWorkItem();
            IEnumerator<WorkItem> enumerator2 = this.Controller.WorkItem.RootWorkItem.WorkItems.FindByType<WorkItem>().GetEnumerator();

            this.DATUMPREDAJE.Value = DateAndTime.Today;
            this.DATUMIZVRSENJA.Value = DateAndTime.Today;
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            adapter.Fill(this.KorisnikDataSet1);

            if (this.KorisnikDataSet1.KORISNIK.Rows.Count == 0)
            {
                Interaction.MsgBox("Nema otvorenog sloga u KorisnikAplikacije", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                if ((this.KorisnikDataSet1.KORISNIK.Rows.Count - 1) > 0)
                {

                    KORISNIKSelectionListWorkItem item2 = this.Controller.WorkItem.Items.AddNew<KORISNIKSelectionListWorkItem>("test");
                    DataRow row = item2.ShowModal(true, "", null);
                    item2.Terminate();
                    if (row == null)
                    {
                        return;
                    }
                    this.KorisnikDataSet1.Clear();
                    adapter.FillByIDKORISNIK(this.KorisnikDataSet1, Conversions.ToInteger(row["IDKORISNIK"]));
                }
                this.mb.Text = Conversions.ToString(this.KorisnikDataSet1.KORISNIK.Rows[0]["mbkorisnik"]);

                if (this.KorisnikDataSet1.KORISNIKLevel1.Rows.Count == 0)
                {
                    Interaction.MsgBox("Nema otvorenih Žiro računa korisnika", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    try
                    {
                        this.UltraCombo1.Rows[0].Selected = true;

                        IEnumerator<object> enumerator = this.Controller.WorkItem.Workspaces["main"].SmartParts.GetEnumerator();

                        while (enumerator.MoveNext())
                        {

                            if (enumerator.Current is UserControl)
                            {
                                UserControl current = (UserControl)enumerator.Current;
                                if (current.Name.ToLower() == "obracunsmartpart")
                                {
                                    this.dd = false;
                                    UltraTextEditor editor = (UltraTextEditor)InfraCustom.FindControl(current, "txtsifraobracuna");
                                    if (Operators.ConditionalCompareObjectNotEqual(editor.Value, "", false))
                                    {
                                        this.sifraobracuna.Value = RuntimeHelpers.GetObjectValue(editor.Value);
                                        this.odabrani = Conversions.ToString(editor.Value);
                                        this.sifraobracuna.Tag = "PL";
                                        uf = false;
                                        obracunRazno = false;
                                        this.PrikaziVirmaneOdabranogObracuna();
                                    }
                                }
                                else
                                {
                                    if (current.Name.ToLower() == "obracunddsmartpart")
                                    {
                                        this.dd = true;
                                        UltraTextEditor editor2 = (UltraTextEditor)InfraCustom.FindControl(current, "ultraSifraObracuna");
                                        if (Operators.ConditionalCompareObjectNotEqual(editor2.Value, "", false))
                                        {
                                            this.sifraobracuna.Value = RuntimeHelpers.GetObjectValue(editor2.Value);
                                            this.sifraobracuna.Tag = "DD";
                                            this.odabrani = Conversions.ToString(editor2.Value);
                                            uf = false;
                                            obracunRazno = false;
                                            this.PrikaziVirmaneOdabranogObracuna();
                                        }
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "urasmartpart")
                                    {
                                        this.sifraobracuna.Tag = "URA";
                                        this.fin = true;
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "UltraGrid1");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        this.UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = false;
                                        this.Virmani_IZ_Ura(ref con);
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "racunismartpartuser")
                                    {
                                        this.fin = true;
                                        UltraGrid grid2 = (UltraGrid)InfraCustom.FindControl(current, "UltraGrid1");
                                        DataRow[] rowArray2 = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray2.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        this.UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray2[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = false;
                                        this.Virmani_IZ_Ira(ref grid2);
                                    }
                                    //ucenicko fakturiranje dodavanje virmana
                                    if (current.Name.ToLower() == "uscobracunipregled")
                                    {
                                        this.fin = true;

                                        int id_obracuna = (int)VirmaniWorkItemUser.OsobeIzObracuna.id;

                                        string naziv_obracuna = current.Controls["ugdObracuni"].Text;
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdObracuni");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = true;
                                        obracunRazno = false;
                                        this.Virmani_IZ_UF(ref con, id_obracuna, naziv_obracuna, VirmaniWorkItemUser.OsobeIzObracuna.ucenici, VirmaniWorkItemUser.OsobeIzObracuna.ustanova);
                                        continue;

                                    }
                                    //putni nalozi dodavanje virmana
                                    if (current.Name.ToLower() == "uscregistarnabavepregled")
                                    {
                                        this.fin = true;
                                        string id_obracuna = current.Tag.ToString();
                                        string naziv_obracuna = current.Controls["ugdRegistarNabave"].Text;
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdRegistarNabave");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = false;
                                        VirmaniPutniNalog(ref con, id_obracuna, naziv_obracuna, rowArray[0]);
                                        continue;
                                    }
                                    //obracuni razno
                                    if (current.Name.ToLower() == "uscnagradenatjecanjapregled" && VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta == JOPPD.Enums.Vrstaobracuna.NagradeNatjecanja)
                                    {
                                        this.sifraobracuna.Tag = "RAZNO";
                                        this.fin = true;
                                        string id = current.Tag.ToString();
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdNagradeNatjecanja");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = true;
                                        VirmaniObracuniRazno(ref con, id, rowArray[0]);
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "uscnagradepregled" && VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta == JOPPD.Enums.Vrstaobracuna.NagradePraksa)
                                    {
                                        this.sifraobracuna.Tag = "RAZNO";
                                        this.fin = true;
                                        string id = current.Tag.ToString();
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdNagrade");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = true;
                                        VirmaniObracuniRazno(ref con, id, rowArray[0]);
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "uscsocijalnanaknadapregled" && VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta == JOPPD.Enums.Vrstaobracuna.SocijalnaNaknada)
                                    {
                                        this.sifraobracuna.Tag = "RAZNO";
                                        this.fin = true;
                                        string id = current.Tag.ToString();
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdSocijalnaNaknada");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = true;
                                        VirmaniObracuniRazno(ref con, id, rowArray[0]);
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "uscsocijalnapotporapregled" && VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta == JOPPD.Enums.Vrstaobracuna.PrijevozNezaposleni)
                                    {
                                        this.sifraobracuna.Tag = "RAZNO";
                                        this.fin = true;
                                        string id = current.Tag.ToString();
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdSocijalnaPotpora");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = true;
                                        VirmaniObracuniRazno(ref con, id, rowArray[0]);
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "uscstipendijepregled" && VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta == JOPPD.Enums.Vrstaobracuna.Stipendije)
                                    {
                                        this.sifraobracuna.Tag = "RAZNO";
                                        this.fin = true;
                                        string id = current.Tag.ToString();
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdStipendije");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = true;
                                        VirmaniObracuniRazno(ref con, id, rowArray[0]);
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "uscnagradenatjecanjapregled" && VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta == JOPPD.Enums.Vrstaobracuna.StudentServisNeoporezivo)
                                    {
                                        this.sifraobracuna.Tag = "RAZNO";
                                        this.fin = true;
                                        string id = current.Tag.ToString();
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdNagradeNatjecanja");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = true;
                                        VirmaniObracuniRazno(ref con, id, rowArray[0]);
                                        continue;
                                    }
                                    if (current.Name.ToLower() == "uscnagradenatjecanjapregled" && VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta == JOPPD.Enums.Vrstaobracuna.StudentServisOporezivo)
                                    {
                                        this.sifraobracuna.Tag = "RAZNO";
                                        this.fin = true;
                                        string id = current.Tag.ToString();
                                        UltraGrid con = (UltraGrid)InfraCustom.FindControl(current, "ugdNagradeNatjecanja");
                                        DataRow[] rowArray = this.KorisnikDataSet1.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
                                        if (rowArray.Length <= 0)
                                        {
                                            throw new Exception("Ne postoji otvoreni račun poslovne banke");
                                        }
                                        UltraCombo1.Value = RuntimeHelpers.GetObjectValue(rowArray[0]["idziro"]);
                                        uf = false;
                                        obracunRazno = true;
                                        VirmaniObracuniRazno(ref con, id, rowArray[0]);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception greska)
                    {
                        MessageBox.Show(greska.Message);
                    }
                }
            }

            SetForm_BrojZaduzenja();
            try
            {
                UltraGrid1.DisplayLayout.Bands[0].Columns["OpisPlacanja"].CellActivation = Activation.NoEdit;
            }
            catch { }
        }

        private void VirmaniObracuniRazno(ref UltraGrid con, string id_obracuna, DataRow korisnikRow)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtObracun = client.GetDataTable("Select JOPPDObracunRazno.Sifra, JOPPDObracunRaznoStavke.ID_VrstaVeze, JOPPDObracunRazno.Naziv, JOPPDObracunRazno.VrstaObracuna, JOPPDObracunRazno.Mjesec, " +
                                  "JOPPDObracunRazno.Godina, JOPPDObracunRaznoStavke.Iznos, JOPPDObracunRaznoStavke.Ime, JOPPDObracunRaznoStavke.Prezime, JOPPDObracunRaznoStavke.OIB, " +
                                  "JOPPDObracunRaznoStavke.ID_Opcina, (Case When JOPPDObracunRaznoStavke.ID_VrstaVeze = 1 Then (Select ImeRoditelj + ' ' + PrezimeRoditelj From UF_Ucenik " +
                                  "Where UF_Ucenik.OIB = JOPPDObracunRaznoStavke.OIB) When JOPPDObracunRaznoStavke.ID_VrstaVeze = 8 Then (Select IMERODITELJA + ' ' + PrezimeRoditelj From UCENIK " +
                                  "Where UCENIK.OIBUCENIK = JOPPDObracunRaznoStavke.OIB) When JOPPDObracunRaznoStavke.ID_VrstaVeze = 9 Then (JOPPDObracunRaznoStavke.Ime + ' ' + JOPPDObracunRaznoStavke.Prezime) " +
                                  "When JOPPDObracunRaznoStavke.ID_VrstaVeze = 2 Then (JOPPDObracunRaznoStavke.Ime + ' ' + JOPPDObracunRaznoStavke.Prezime) End) As Roditelj, " +
                                  "(Case When JOPPDObracunRaznoStavke.ID_VrstaVeze = 1 Then " +
                                  "(Select OIBRoditelj From UF_Ucenik Where UF_Ucenik.OIB = JOPPDObracunRaznoStavke.OIB) When JOPPDObracunRaznoStavke.ID_VrstaVeze = 8 Then " +
                                  "(Select OIBRoditelj From UCENIK Where UCENIK.OIBUCENIK = JOPPDObracunRaznoStavke.OIB)  When JOPPDObracunRaznoStavke.ID_VrstaVeze In (2,9) Then (JOPPDObracunRaznoStavke.OIB) " +
                                  " End) As OIBRoditelj, (Case When JOPPDObracunRaznoStavke.ID_VrstaVeze In (1,2,4)  Then " +
                                  "(Select Distinct UlicaKucniBroj From UF_Ucenik Where UF_Ucenik.OIB = JOPPDObracunRaznoStavke.OIB Or UF_Ucenik.OIBRoditelj = JOPPDObracunRaznoStavke.OIB) " +
                                  "When JOPPDObracunRaznoStavke.ID_VrstaVeze In (8,9) Then (Select Distinct ULICAIBROJ From UCENIK Where UCENIK.OIBUCENIK = JOPPDObracunRaznoStavke.OIB Or " +
                                  "UCENIK.OIBRoditelj = JOPPDObracunRaznoStavke.OIB) End) As Adresa, (Case When JOPPDObracunRaznoStavke.ID_VrstaVeze In (1,2,4)  Then " +
                                  "(Select Distinct Naselje From UF_Ucenik Where UF_Ucenik.OIB = JOPPDObracunRaznoStavke.OIB Or UF_Ucenik.OIBRoditelj = JOPPDObracunRaznoStavke.OIB) " +
                                  "When JOPPDObracunRaznoStavke.ID_VrstaVeze In (8,9) Then (Select Distinct NASELJE From UCENIK Where UCENIK.OIBUCENIK = JOPPDObracunRaznoStavke.OIB Or " +
                                  "UCENIK.OIBRoditelj = JOPPDObracunRaznoStavke.OIB) End) As Naselje, (Case When JOPPDObracunRaznoStavke.ID_VrstaVeze In (1,2,4) Then " +
                                  "(Select IBANRoditelj From UF_Ucenik Where UF_Ucenik.OIB = JOPPDObracunRaznoStavke.OIB Or UF_Ucenik.OIBRoditelj = JOPPDObracunRaznoStavke.OIB) " +
                                  "When JOPPDObracunRaznoStavke.ID_VrstaVeze In (8,9) Then (Select IBANRoditelj From UCENIK Where " +
                                  "UCENIK.OIBUCENIK = JOPPDObracunRaznoStavke.OIB Or UCENIK.OIBRoditelj = JOPPDObracunRaznoStavke.OIB) End) As IBAN From JOPPDObracunRazno " +
                                  "Inner Join JOPPDObracunRaznoStavke On JOPPDObracunRazno.ID = JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno " +
                                  "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                  "Where JOPPDOznakaNacinaIsplate.Oznaka In (1,2,6) And JOPPDObracunRazno.ID = '" + id_obracuna + "'");

            foreach (DataRow row in dtObracun.Rows)
            {
                DataRow newRow = this.VirmaniDataSet1.VIRMANI.NewRow();

                //db - 8.11.2016 --> Ivan rekao da ostane 99 za sve
                newRow["modelzaduzenja"] = "99";

                newRow["namjena"] = "FIN";
                newRow["oznacen"] = true;
                newRow["sifraobracunavirman"] = row["Sifra"].ToString() + "-" + row["Mjesec"].ToString() + "-" + row["Godina"].ToString();
                newRow["pri1"] = row["Ime"].ToString() + " " + row["Prezime"].ToString();

                if (row["Adresa"].ToString().Length > 30)
                    newRow["pri2"] = row["Adresa"].ToString().Substring(0, 30);
                else
                    newRow["pri2"] = row["Adresa"].ToString();

                if (row["Naselje"].ToString().Length > 30)
                    newRow["pri3"] = row["Naselje"].ToString().Substring(0, 30);
                else
                    newRow["pri3"] = row["Naselje"].ToString();

                newRow["brojracunapri"] = "HR" + row["IBAN"].ToString();

                newRow["pozivzaduzenja"] = "";

                if (korisnikRow["NAZIVZIRO"].ToString().Length > 30)
                    newRow["pla1"] = korisnikRow["NAZIVZIRO"].ToString().Substring(0, 30);
                else
                    newRow["pla1"] = korisnikRow["NAZIVZIRO"].ToString();

                if (korisnikRow["ULICAZIRO"].ToString().Length > 30)
                    newRow["pla2"] = korisnikRow["ULICAZIRO"].ToString().Substring(0, 30);
                else
                    newRow["pla2"] = korisnikRow["ULICAZIRO"].ToString();

                if (korisnikRow["MJESTOZIRO"].ToString().Length > 30)
                    newRow["pla3"] = korisnikRow["MJESTOZIRO"].ToString().Substring(0, 30);
                else
                    newRow["pla3"] = korisnikRow["MJESTOZIRO"].ToString();

                newRow["brojracunapla"] = korisnikRow["VBDIKORISNIK"].ToString() + "-" + korisnikRow["ZIROKORISNIK"].ToString();
                newRow["izvordokumenta"] = korisnikRow["SifraIzvora"];




                newRow["pozivodobrenja"] = "";
                newRow["sifraopisaplacanjavirman"] = "";
                //naziv obracuna
                newRow["OPISPLACANJAVIRMAN"] = row["Naziv"].ToString();
                newRow["OZNACEN"] = true;
                newRow["DATUMVALUTE"] = DateTime.Now;
                newRow["DATUMPODNOSENJA"] = DateTime.Now;
                newRow["iznos"] = row["Iznos"];
                newRow["HUB3_SIFRANAMJENE"] = "OTHR";


                newRow["Roditelj"] = row["Roditelj"].ToString();
                newRow["OpisPlacanja"] = row["VrstaObracuna"].ToString();
                //oib roditelja ako postoji i ako se rdi o uceniku
                newRow["RoditeljAdresa"] = row["OIBRoditelj"].ToString();
                //oib osobe
                newRow["OpisProizvoda"] = row["OIB"].ToString();

                this.VirmaniDataSet1.VIRMANI.Rows.Add(newRow);
            }
            try
            {
                this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        private void Zbrojni_Nalog()
        {
            if (this.VirmaniDataSet1.VIRMANI.Rows.Count != 0)
            {
                if (Operators.ConditionalCompareObjectEqual(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1"), 0, false))
                {
                    Interaction.MsgBox("Nema označenih virmana!", MsgBoxStyle.OkOnly, null);
                }
                else
                {

                    ReportDocument document = new ReportDocument();
                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja - FINA - Zbrojni nalog",
                        Description = "Pregled izvještaja - FINA - Zbrojni nalog",
                        Icon = ImageResourcesNew.mbs
                    };
                    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptFinaNalog.rpt");

                    IBAN iban = new IBAN();

                    // Pomoćni DataSet koji nam služi za prikaz IBAN-a, pošto na trenutnom ne smijemo raditi izmjene
                    IBANDataSet dsIBAN = new IBANDataSet();

                    foreach (DataRow drRow in this.VirmaniDataSet1.VIRMANI.Rows)
                    {

                        if (drRow["BROJRACUNAPRI"] != DBNull.Value)
                        {
                            if (sifraobracuna.Tag == "RAZNO")
                            {
                                dsIBAN.IBAN.AddIBANRow(int.Parse(drRow["IDVIRMAN"].ToString()), drRow["BROJRACUNAPRI"].ToString(), iban.GenerirajIBANIzBrojaRacuna(this.VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"].ToString(), false, true));
                            }
                            else
                            {
                                // za svaki postojeći virman, u pomoćnom dataset-u upisujemo njegov ID i novo-generirani IBAN
                                dsIBAN.IBAN.AddIBANRow(int.Parse(drRow["IDVIRMAN"].ToString()),
                                    iban.GenerirajIBANIzBrojaRacuna(drRow["BROJRACUNAPRI"].ToString(), false, true),
                                    // iako je za svaki virman broj računa platitelja ISTI, koristimo ovo polje, 
                                    // kako ne bi trebali proširivati polje u tablici dbo.VIRMANI zbog nedostatka vremena
                                    iban.GenerirajIBANIzBrojaRacuna(this.VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"].ToString(), false, true));
                            }

                        }
                    }

                    string korisnikOIB = KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIKOIB"].ToString();

                    foreach (DataRow drRow in this.VirmaniDataSet1.VIRMANI.Rows)
                    {
                        if (drRow["HUB3_SIFRANAMJENE"].ToString() != "NITX" || drRow["HUB3_SIFRANAMJENE"].ToString() != "SALA" || drRow["HUB3_SIFRANAMJENE"].ToString() == "")
                        {
                            if (drRow["ModelZaduzenja"].ToString().Trim() == "")
                            {
                                drRow["ModelZaduzenja"] = "99";
                            }
                        }

                        if (drRow["HUB3_SIFRANAMJENE"].ToString() == "SALA")
                        {
                            drRow["MODELODOBRENJA"] = "69";
                            drRow["POZIVODOBRENJA"] = "40002-" + korisnikOIB + " - " + drRow["OpisPlacanja"].ToString();
                        }
                    }



                    document.Database.Tables[0].SetDataSource(this.VirmaniDataSet1);
                    document.Database.Tables[1].SetDataSource(dsIBAN);


                    document.SetParameterValue("datumpredaje", RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value));

                    document.SetParameterValue("datumizvrsenja", RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value));
                    int num = Conversions.ToInteger(this.VirmaniDataSet1.VIRMANI.Compute("COUNT(OZNACEN)", "OZNACEN=1"));

                    document.SetParameterValue("brojnaloga", num);

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
        }

        private void Zbrojni_NalogOsobe()
        {
            if (this.VirmaniDataSet1.VIRMANI.Rows.Count != 0)
            {
                if (Operators.ConditionalCompareObjectEqual(this.VirmaniDataSet1.VIRMANI.Compute("count(oznacen)", "OZNACEN=1"), 0, false))
                {
                    Interaction.MsgBox("Nema označenih virmana!", MsgBoxStyle.OkOnly, null);
                }
                else
                {

                    ReportDocument document = new ReportDocument();
                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja - FINA - Zbrojni nalog",
                        Description = "Pregled izvještaja - FINA - Zbrojni nalog",
                        Icon = ImageResourcesNew.mbs
                    };
                    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptFinaNalogOsoba.rpt");

                    IBAN iban = new IBAN();

                    string ibanPlatitelja = iban.GenerirajIBANIzBrojaRacuna(VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"].ToString(), true, false);

                    Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
                    DataTable dtRedovi = new DataTable("Redovi");
                    SqlCommand sqlComm;

                    try
                    {
                        sqlComm = new SqlCommand("spSepaPlace", client.sqlConnection);
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.Parameters.AddWithValue("@Obracun", this.sifraobracuna.Value);
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlComm;
                        da.Fill(dtRedovi);
                    }
                    catch { }


                    //kalkulacija ukoliko se iskljuci nesto sto je SALA
                    DataRow[] calculateVirmani = VirmaniDataSet1.VIRMANI.Select("OZNACEN=0 AND (HUB3_SIFRANAMJENE='SALA' OR NAMJENA = 'Izuzeto iz ovrhe')");
                    foreach (var item in calculateVirmani)
                    {
                        foreach (DataRow item2 in dtRedovi.Rows)
                        {
                            if (item["BROJRACUNAPRI"].ToString() == string.Format("{0}-{1}", item2["VBDIBANKE"].ToString(), item2["TEKUCI"].ToString()))
                            {
                                item2["UKUPNOZAISPLATU"] = Convert.ToDecimal(item2["UKUPNOZAISPLATU"]) - Convert.ToDecimal(item["IZNOS"]);
                            }
                        }
                    }
                    for (int i = dtRedovi.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToDecimal(dtRedovi.Rows[i]["UKUPNOZAISPLATU"]) == 0)
                        {
                            dtRedovi.Rows[i].Delete();
                        }
                    }
                    dtRedovi.AcceptChanges();


                    DataRow[] temp;

                    try
                    {
                        //podesavanje oznaka
                        temp = dtRedovi.Select("Vrsta='NITX'");

                        //zasticeni
                        foreach (DataRow row in temp)
                        {
                            foreach (DataRow row2 in dtRedovi.Rows)
                            {
                                if (row["IDRADNIK"].ToString() == row2["IDRADNIK"].ToString())
                                {
                                    if (row["Vrsta"].ToString() == row2["Vrsta"].ToString())
                                    {
                                        row2["Oznaka"] = "";
                                    }
                                    else
                                    {
                                        row2["Oznaka"] = "120";
                                    }
                                }

                                if (row2["Vrsta"].ToString() == "NITX")
                                {
                                    row2["Oznaka"] = "399";
                                }
                            }
                        }
                    }
                    catch { }

                    foreach (DataRow row in dtRedovi.Rows)
                    {
                        if (row["Vrsta"].ToString() == "SALA" && row["Oznaka"].ToString().Length == 0)
                        {
                            row["Oznaka"] = GetOznaka(row["IDRADNIK"], this.sifraobracuna.Value, client);
                        }
                    }

                    string korisnik = this.KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIK1NAZIV"].ToString();

                    string korisnikOIB = KorisnikDataSet1.KORISNIK.Rows[0]["KORISNIKOIB"].ToString();

                    foreach (DataRow row in dtRedovi.Rows)
                    {
                        row["POBANKA"] = "6940002-" + korisnikOIB + "-" + row["Oznaka"].ToString();
                    }



                    DataRow[] virmaniPlace = VirmaniDataSet1.VIRMANI.Select("(OZNACEN=1 AND HUB3_SIFRANAMJENE='NITX' AND NAMJENA<>'Izuzeto iz ovrhe') OR (OZNACEN=1 And OpisPlacanja='Rucni virman')");


                    int num = dtRedovi.Rows.Count + Convert.ToInt32(VirmaniDataSet1.VIRMANI.Compute("count(idvirman)", "(OZNACEN=1 AND HUB3_SIFRANAMJENE='NITX' AND NAMJENA<>'Izuzeto iz ovrhe') OR (OZNACEN=1 And OpisPlacanja='Rucni virman')"));

                    foreach (var row in virmaniPlace)
                    {
                        dtRedovi.Rows.Add(row["IDVIRMAN"].ToString(), row[8].ToString() + " - " + row[9].ToString(), null, row["BROJRACUNAPRI"].ToString(), null,
                            null, row[15].ToString(), row[20], null, null, row[6].ToString(), row[7].ToString(), null, row[14].ToString(), row[12].ToString() + row[13].ToString(), null, null);
                    }


                    foreach (DataRow drRow in dtRedovi.Rows)
                    {
                        drRow["ZIRORACUNBANKE"] = iban.GenerirajIBANIzBrojaRacuna(drRow[3].ToString() + drRow[4].ToString(), false, true);
                    }


                    //document.Database.Tables[0].SetDataSource(this.VirmaniDataSet1);
                    //document.Database.Tables[0].SetDataSource(dsIBAN);
                    document.Database.Tables[0].SetDataSource(dtRedovi);


                    document.SetParameterValue("datumpredaje", RuntimeHelpers.GetObjectValue(this.DATUMPREDAJE.Value));

                    document.SetParameterValue("datumizvrsenja", RuntimeHelpers.GetObjectValue(this.DATUMIZVRSENJA.Value));
                    document.SetParameterValue("ibanPlatitelja", ibanPlatitelja);
                    document.SetParameterValue("korisnik", korisnik);

                    document.SetParameterValue("brojnaloga", num);

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem items = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (items == null)
                    {
                        items = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    items.Izvjestaj = document;
                    items.Show(items.Workspaces["main"]);
                }
            }
        }


        private AutoHideControl _VirmaniAutoHideControl;

        private UnpinnedTabArea _VirmaniUnpinnedTabAreaBottom;

        private UnpinnedTabArea _VirmaniUnpinnedTabAreaLeft;

        private UnpinnedTabArea _VirmaniUnpinnedTabAreaRight;

        private UnpinnedTabArea _VirmaniUnpinnedTabAreaTop;

        private UltraCheckEditor CheckBox1;

        [CreateNew]
        public VIRMANIController Controller { get; set; }

        private UltraDateTimeEditor DATUMIZVRSENJA;

        private UltraDateTimeEditor DATUMPREDAJE;

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

        private UltraMaskedEdit izvordokumenta;

        private KORISNIKDataSet KorisnikDataSet1;

        private UltraMaskedEdit mb;

        private UltraMaskedEdit pla1;

        private UltraMaskedEdit pla2;

        private UltraMaskedEdit pla3;

        private UltraCheckEditor poreziprirez;

        private UltraCheckEditor pozivzaduzenja;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraMaskedEdit sifraobracuna;

        private UltraButton UltraButton1;

        private UltraCombo UltraCombo1;

        private UltraDockManager UltraDockManager1 { get; set; }

        private UltraDockManager UltraDockManager2;

        private UltraGrid UltraGrid1;

        private UltraGroupBox UltraGroupBox1;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel3;

        private UltraLabel UltraLabel4;

        private UltraLabel UltraLabel5;

        private UltraLabel UltraLabel6;

        private UltraLabel UltraLabel7;

        private UltraMaskedEdit vbdi;

        private Panel Virmani_Fill_Panel;

        private VIRMANIDataSet VirmaniDataSet1;

        private DataTable VirmaniUF;

        private Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }

        private UltraMaskedEdit ziro;

        private void SetForm_BrojZaduzenja()
        {
            if (this.UltraDockManager2 != null)
            {
                if (this.UltraCombo1.SelectedRow != null)
                {
                    object idZiro = this.UltraCombo1.SelectedRow.Cells["IDZIRO"].Value;

                    Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();

                    // 530 - Riznica
                    // 701 - Vlastiti račun
                    object sifraIzvora = db.ExecuteScalar("SELECT SIFRAIZVORA FROM dbo.KORISNIKLevel1 WHERE IDZIRO = " + idZiro.ToString());

                    if (sifraIzvora != null)
                    {
                        // VLASTITI RAČUN
                        if (sifraIzvora.ToString() == "701")
                        {
                            this.UltraDockManager2.DockAreas[0].DockAreaPane.Size = new Size(this.UltraDockManager2.DockAreas[0].DockAreaPane.Size.Width, 250);
                        }
                        // OSTALO
                        else
                        {
                            this.UltraDockManager2.DockAreas[0].DockAreaPane.Size = new Size(this.UltraDockManager2.DockAreas[0].DockAreaPane.Size.Width, 187);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Matija Božičević - 28.08.2012
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrimjeniBrojZaduzenja_Click(object sender, EventArgs e)
        {
            if (this.ultraComboTipIsplate.Value == null)
                return;

            IEnumerator enumerator = null;
            try
            {
                enumerator = this.VirmaniDataSet1.VIRMANI.Select("oznacen=1").GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;

                    if (current["NAMJENA"].ToString().Contains("Prirez") | current["NAMJENA"].ToString().Contains("Porez") | current["NAMJENA"].ToString().Contains("Doprinosi"))
                    {
                        current["MODELZADUZENJA"] = "99";
                        current["POZIVZADUZENJA"] = "";
                    }
                    current["MODELZADUZENJA"] = this.pnbzBrojModela.Value;
                    current["POZIVZADUZENJA"] = this.pnbzOIB.Value.ToString() + "-" + this.pnbzMjesecGodina.Value.ToString() + "-" + this.ultraComboTipIsplate.Value.ToString();
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.BindingContext[this.VirmaniDataSet1.VIRMANI].EndCurrentEdit();
            if (!this.fin)
            {
                try
                {
                    this.davirmani.Update(this.VirmaniDataSet1);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }
    }
}

