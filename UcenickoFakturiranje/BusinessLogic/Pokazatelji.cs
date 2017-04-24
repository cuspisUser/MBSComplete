using Mipsed7.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Pokazatelji : Base, IDisposable
    {
        SqlClient client = null;
        public Pokazatelji()
            : base()
        {
            client = new SqlClient();
        }

        public void Dispose()
        {

        }

        #region Properties

        public ListBox.ObjectCollection PrihodiOdHZZO { get; set; }
        public ListBox.ObjectCollection ProracuniBolnica { get; set; }
        public ListBox.ObjectCollection DopunskoZdravstvenoOsiguranje { get; set; }
        public ListBox.ObjectCollection UgovorPrimarZdravZastitu { get; set; }
        public ListBox.ObjectCollection ZaUslugeIzvanUgovorenogLimita { get; set; }
        public ListBox.ObjectCollection SOsnovaOzljedaNaRaduIProfBol { get; set; }
        public ListBox.ObjectCollection PrihodiOdPruzenihUslugaDrugimZdrUstanovama { get; set; }
        public ListBox.ObjectCollection PrihodiOdProracuna { get; set; }
        public ListBox.ObjectCollection PrihodiOdOstalihKorisnika { get; set; }
        public ListBox.ObjectCollection PrihodOdParticipacije { get; set; }
        public ListBox.ObjectCollection OstaliIzvanredniPrihodi { get; set; }
        public ListBox.ObjectCollection PrimiciOdFinancijskeImovineIZaduzenja { get; set; }
        public ListBox.ObjectCollection Lijekovi { get; set; }
        public ListBox.ObjectCollection PotrosniMedicinskiMaterijal { get; set; }
        public ListBox.ObjectCollection KrvIKrvniPripravci { get; set; }
        public ListBox.ObjectCollection ZivezneNamirnice { get; set; }
        public ListBox.ObjectCollection MedicinskiPlinovi { get; set; }
        public ListBox.ObjectCollection MaterijalZaOdrzavanjeCistoce { get; set; }
        public ListBox.ObjectCollection UredskiMaterijal { get; set; }
        public ListBox.ObjectCollection OstaliRazniMaterijali { get; set; }
        public ListBox.ObjectCollection UtrosenaEnergija { get; set; }
        public ListBox.ObjectCollection UgradeniRezevniDijelovi { get; set; }
        public ListBox.ObjectCollection PostanskiIzdaci { get; set; }
        public ListBox.ObjectCollection TekuceIInvensticijskoOdrzavanje { get; set; }
        public ListBox.ObjectCollection IzdaciZaUslugeDrugihZdravUstanova { get; set; }
        public ListBox.ObjectCollection OstaliIzdaci { get; set; }
        public ListBox.ObjectCollection BrutoPlace { get; set; }
        public ListBox.ObjectCollection OstaliRashodiZaZaposlene { get; set; }
        public ListBox.ObjectCollection DoprinosiNaPlace { get; set; }
        public ListBox.ObjectCollection IzdaciZaPrijevozZaposlenika { get; set; }
        public ListBox.ObjectCollection OstaliMaterijalniRashodiZaZaposlene { get; set; }
        public ListBox.ObjectCollection FinancijskiRashodi { get; set; }
        public ListBox.ObjectCollection IzdaciZaKapitalnaUlaganja { get; set; }
        public ListBox.ObjectCollection OstaliIIzvanredniIzdaci { get; set; }
        public ListBox.ObjectCollection IzdaciZaFinancijskuImovinuIOtplateZajmova { get; set; }
        public ListBox.ObjectCollection NabavnaVrijednostProdaneRode { get; set; }

        #endregion


        internal bool Delete(StringBuilder message)
        {
            try
            {
                client.ExecuteNonQuery("Delete from DefiniranjePokazateljiStavke");
                return true;
            }
            catch (Exception error)
            {
                message.Append(error.Message);
                return false;
            }
        }

        internal bool Insert(StringBuilder message, Pokazatelji objekt)
        {
            throw new NotImplementedException();
        }

        internal bool Update(StringBuilder message, Pokazatelji objekt)
        {
            if (Delete(message))
            {
                string konto;
                try
                {
                    foreach (var item in PrihodiOdHZZO)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (1, '" + konto + "')");
                    }

                    foreach (var item in ProracuniBolnica)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (2, '" + konto + "')");
                    }

                    foreach (var item in DopunskoZdravstvenoOsiguranje)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (3, '" + konto + "')");
                    }

                    foreach (var item in UgovorPrimarZdravZastitu)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (4, '" + konto + "')");
                    }

                    foreach (var item in ZaUslugeIzvanUgovorenogLimita)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (5, '" + konto + "')");
                    }

                    foreach (var item in SOsnovaOzljedaNaRaduIProfBol)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (6, '" + konto + "')");
                    }

                    foreach (var item in PrihodiOdPruzenihUslugaDrugimZdrUstanovama)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (7, '" + konto + "')");
                    }

                    foreach (var item in PrihodiOdProracuna)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (8, '" + konto + "')");
                    }

                    foreach (var item in PrihodiOdOstalihKorisnika)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (9, '" + konto + "')");
                    }

                    foreach (var item in PrihodOdParticipacije)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (10, '" + konto + "')");
                    }

                    foreach (var item in OstaliIzvanredniPrihodi)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (11, '" + konto + "')");
                    }

                    foreach (var item in PrimiciOdFinancijskeImovineIZaduzenja)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (12, '" + konto + "')");
                    }
                    foreach (var item in Lijekovi)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (13, '" + konto + "')");
                    }

                    foreach (var item in PotrosniMedicinskiMaterijal)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (14, '" + konto + "')");
                    }

                    foreach (var item in KrvIKrvniPripravci)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (15, '" + konto + "')");
                    }

                    foreach (var item in ZivezneNamirnice)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (16, '" + konto + "')");
                    }

                    foreach (var item in MedicinskiPlinovi)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (17, '" + konto + "')");
                    }

                    foreach (var item in MaterijalZaOdrzavanjeCistoce)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (18, '" + konto + "')");
                    }

                    foreach (var item in UredskiMaterijal)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (19, '" + konto + "')");
                    }

                    foreach (var item in OstaliRazniMaterijali)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (20, '" + konto + "')");
                    }

                    foreach (var item in UtrosenaEnergija)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (21, '" + konto + "')");
                    }

                    foreach (var item in UgradeniRezevniDijelovi)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (22, '" + konto + "')");
                    }

                    foreach (var item in PostanskiIzdaci)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (23, '" + konto + "')");
                    }

                    foreach (var item in TekuceIInvensticijskoOdrzavanje)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (24, '" + konto + "')");
                    }

                    foreach (var item in IzdaciZaUslugeDrugihZdravUstanova)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (25, '" + konto + "')");
                    }

                    foreach (var item in OstaliIzdaci)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (26, '" + konto + "')");
                    }

                    foreach (var item in BrutoPlace)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (27, '" + konto + "')");
                    }

                    foreach (var item in OstaliRashodiZaZaposlene)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (28, '" + konto + "')");
                    }

                    foreach (var item in DoprinosiNaPlace)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (29, '" + konto + "')");
                    }

                    foreach (var item in IzdaciZaPrijevozZaposlenika)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (30, '" + konto + "')");
                    }

                    foreach (var item in OstaliMaterijalniRashodiZaZaposlene)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (31, '" + konto + "')");
                    }

                    foreach (var item in FinancijskiRashodi)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (32, '" + konto + "')");
                    }

                    foreach (var item in IzdaciZaKapitalnaUlaganja)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (33, '" + konto + "')");
                    }

                    foreach (var item in OstaliIIzvanredniIzdaci)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (34, '" + konto + "')");
                    }

                    foreach (var item in IzdaciZaFinancijskuImovinuIOtplateZajmova)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (35, '" + konto + "')");
                    }

                    foreach (var item in NabavnaVrijednostProdaneRode)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePokazateljiStavke (idDefiniranjePokazatelj, idKonto) Values (36, '" + konto + "')");
                    }
                    return true;
                }
                catch (Exception error)
                {
                    message.Append(error.Message);
                }
            }

            return false;
        }

        internal object GetSelected()
        {
            throw new NotImplementedException();
        }

        internal object GetKonto()
        {
            return client.GetDataTable("Select IDKONTO, (IDKONTO + ' | ' + NAZIVKONTO) As Naziv From KONTO");
        }

        internal List<ListKonto> GetZaLijekove(int vrsta)
        {
            List<ListKonto> list = new List<ListKonto>();

            DataTable konto = client.GetDataTable("Select KONTO.IDKONTO + ' | ' + KONTO.NAZIVKONTO From DefiniranjePokazateljiStavke Inner Join " +
                              "KONTO On DefiniranjePokazateljiStavke.idKonto = KONTO.IDKONTO Where idDefiniranjePokazatelj = " + vrsta + " Order by KONTO.IDKONTO");

            ListKonto listKonto;

            foreach (DataRow item in konto.Rows)
            {
                listKonto = new ListKonto();
                listKonto.konto = item[0].ToString();
                list.Add(listKonto);
            }

            return list;
        }
    }


}
