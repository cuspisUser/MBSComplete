using System;
using System.Text;
using System.Windows.Forms;
using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.MBS.DefiniranjePokazatelji
{
    public partial class uscPokazatelji : Controls.BaseUserControl
    {
        private FormEditMode FormEditMode
        {
            get;
            set;
        }

        public uscPokazatelji(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }


        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = new StringBuilder();

            using (BusinessLogic.Pokazatelji objekt = new BusinessLogic.Pokazatelji())
            {
                objekt.PrihodiOdHZZO = lbxPrihodiOdHZZO.Items;
                objekt.ProracuniBolnica = lbxProracuniBolnica.Items;
                objekt.DopunskoZdravstvenoOsiguranje = lbxDopunskoZdravstvenoOsiguranje.Items;
                objekt.UgovorPrimarZdravZastitu = lbxUgovorPrimarZdravZastitu.Items;
                objekt.ZaUslugeIzvanUgovorenogLimita = lbxZaUslugeIzvanUgovorenogLimita.Items;
                objekt.SOsnovaOzljedaNaRaduIProfBol = lbxSOsnovaOzljedaNaRaduIProfBol.Items;
                objekt.PrihodiOdPruzenihUslugaDrugimZdrUstanovama = lbxPrihodiOdPruzenihUslugaDrugimZdrUstanovama.Items;
                objekt.PrihodiOdProracuna = lbxPrihodiOdProracuna.Items;
                objekt.PrihodiOdOstalihKorisnika = lbxPrihodiOdOstalihKorisnika.Items;
                objekt.PrihodOdParticipacije = lbxPrihodOdParticipacije.Items;
                objekt.OstaliIzvanredniPrihodi = lbxOstaliIzvanredniPrihodi.Items;
                objekt.PrimiciOdFinancijskeImovineIZaduzenja = lbxPrimiciOdFinancijskeImovineIZaduzenja.Items;

                objekt.Lijekovi = lbxLijekovi.Items;
                objekt.PotrosniMedicinskiMaterijal = lbxPotrosniMedicinskiMaterijal.Items;
                objekt.KrvIKrvniPripravci = lbxKrvIKrvniPripravci.Items;
                objekt.ZivezneNamirnice = lbxZivezneNamirnice.Items;
                objekt.MedicinskiPlinovi = lbxMedicinskiPlinovi.Items;
                objekt.MaterijalZaOdrzavanjeCistoce = lbxMaterijalZaOdrzavanjeCistoce.Items;
                objekt.UredskiMaterijal = lbxUredskiMaterijal.Items;
                objekt.OstaliRazniMaterijali = lbxOstaliRazniMaterijali.Items;
                objekt.UtrosenaEnergija = lbxUtrosenaEnergija.Items;
                objekt.UgradeniRezevniDijelovi = lbxUgradeniRezevniDijelovi.Items;
                objekt.PostanskiIzdaci = lbxPostanskiIzdaci.Items;
                objekt.TekuceIInvensticijskoOdrzavanje = lbxTekuceIInvensticijskoOdrzavanje.Items;

                objekt.IzdaciZaUslugeDrugihZdravUstanova = lbxIzdaciZaUslugeDrugihZdravUstanova.Items;
                objekt.OstaliIzdaci = lbxOstaliIzdaci.Items;
                objekt.BrutoPlace = lbxBrutoPlace.Items;
                objekt.OstaliRashodiZaZaposlene = lbxOstaliRashodiZaZaposlene.Items;
                objekt.DoprinosiNaPlace = lbxDoprinosiNaPlace.Items;
                objekt.IzdaciZaPrijevozZaposlenika = lbxIzdaciZaPrijevozZaposlenika.Items;
                objekt.OstaliMaterijalniRashodiZaZaposlene = lbxOstaliMaterijalniRashodiZaZaposlene.Items;
                objekt.FinancijskiRashodi = lbxFinancijskiRashodi.Items;
                objekt.IzdaciZaKapitalnaUlaganja = lbxIzdaciZaKapitalnaUlaganja.Items;
                objekt.OstaliIIzvanredniIzdaci = lbxOstaliIIzvanredniIzdaci.Items;
                objekt.IzdaciZaFinancijskuImovinuIOtplateZajmova = lbxIzdaciZaFinancijskuImovinuIOtplateZajmova.Items;
                objekt.NabavnaVrijednostProdaneRode = lbxNabavnaVrijednostProdaneRode.Items;

                if (this.FormEditMode == Enums.FormEditMode.Update)
                {
                    if (objekt.Update(message, objekt))
                    {
                        return true;
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private void LoadForm(BusinessLogic.Pokazatelji objekt)
        {
            var items = objekt.GetZaLijekove(1);

            foreach (var item in items)
            {
                lbxPrihodiOdHZZO.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(2);

            foreach (var item in items)
            {
                lbxProracuniBolnica.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(3);

            foreach (var item in items)
            {
                lbxDopunskoZdravstvenoOsiguranje.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(4);

            foreach (var item in items)
            {
                lbxUgovorPrimarZdravZastitu.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(5);

            foreach (var item in items)
            {
                lbxZaUslugeIzvanUgovorenogLimita.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(6);

            foreach (var item in items)
            {
                lbxSOsnovaOzljedaNaRaduIProfBol.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(7);

            foreach (var item in items)
            {
                lbxPrihodiOdPruzenihUslugaDrugimZdrUstanovama.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(8);

            foreach (var item in items)
            {
                lbxPrihodiOdProracuna.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(9);

            foreach (var item in items)
            {
                lbxPrihodiOdOstalihKorisnika.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(10);

            foreach (var item in items)
            {
                lbxPrihodOdParticipacije.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(11);

            foreach (var item in items)
            {
                lbxOstaliIzvanredniPrihodi.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(12);

            foreach (var item in items)
            {
                lbxPrimiciOdFinancijskeImovineIZaduzenja.Items.Add(item.konto);
            }
            items = objekt.GetZaLijekove(13);

            foreach (var item in items)
            {
                lbxLijekovi.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(14);

            foreach (var item in items)
            {
                lbxPotrosniMedicinskiMaterijal.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(15);

            foreach (var item in items)
            {
                lbxKrvIKrvniPripravci.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(16);

            foreach (var item in items)
            {
                lbxZivezneNamirnice.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(17);

            foreach (var item in items)
            {
                lbxMedicinskiPlinovi.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(18);

            foreach (var item in items)
            {
                lbxMaterijalZaOdrzavanjeCistoce.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(19);

            foreach (var item in items)
            {
                lbxUredskiMaterijal.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(20);

            foreach (var item in items)
            {
                lbxOstaliRazniMaterijali.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(21);

            foreach (var item in items)
            {
                lbxUtrosenaEnergija.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(22);

            foreach (var item in items)
            {
                lbxUgradeniRezevniDijelovi.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(23);

            foreach (var item in items)
            {
                lbxPostanskiIzdaci.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(24);

            foreach (var item in items)
            {
                lbxTekuceIInvensticijskoOdrzavanje.Items.Add(item.konto);
            }
            items = objekt.GetZaLijekove(25);

            foreach (var item in items)
            {
                lbxIzdaciZaUslugeDrugihZdravUstanova.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(26);

            foreach (var item in items)
            {
                lbxOstaliIzdaci.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(27);

            foreach (var item in items)
            {
                lbxBrutoPlace.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(28);

            foreach (var item in items)
            {
                lbxOstaliRashodiZaZaposlene.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(29);

            foreach (var item in items)
            {
                lbxDoprinosiNaPlace.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(30);

            foreach (var item in items)
            {
                lbxIzdaciZaPrijevozZaposlenika.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(31);

            foreach (var item in items)
            {
                lbxOstaliMaterijalniRashodiZaZaposlene.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(32);

            foreach (var item in items)
            {
                lbxFinancijskiRashodi.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(33);

            foreach (var item in items)
            {
                lbxIzdaciZaKapitalnaUlaganja.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(34);

            foreach (var item in items)
            {
                lbxOstaliIIzvanredniIzdaci.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(35);

            foreach (var item in items)
            {
                lbxIzdaciZaFinancijskuImovinuIOtplateZajmova.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(36);

            foreach (var item in items)
            {
                lbxNabavnaVrijednostProdaneRode.Items.Add(item.konto);
            }

        }

        private void tbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }
        private void tbOdustaniZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            using (BusinessLogic.Pokazatelji objekt = new BusinessLogic.Pokazatelji())
            {
                LoadKontoPrihodiOdHZZO(objekt);
                LoadKontoProracuniBolnica(objekt);
                LoadKontoDopunskoZdravstvenoOsiguranje(objekt);
                LoadKontoUgovorPrimarZdravZastitu(objekt);
                LoadKontoZaUslugeIzvanUgovorenogLimita(objekt);
                LoadKontoSOsnovaOzljedaNaRaduIProfBol(objekt);
                LoadKontoPrihodiOdPruzenihUslugaDrugimZdrUstanovama(objekt);
                LoadKontoPrihodiOdProracuna(objekt);
                LoadKontoPrihodiOdOstalihKorisnika(objekt);
                LoadKontoPrihodOdParticipacije(objekt);
                LoadKontoOstaliIzvanredniPrihodi(objekt);
                LoadKontoPrimiciOdFinancijskeImovineIZaduzenja(objekt);
                LoadKontoLijekovi(objekt);
                LoadKontoPotrosniMedicinskiMaterijal(objekt);
                LoadKontoKrvIKrvniPripravci(objekt);
                LoadKontoZivezneNamirnice(objekt);
                LoadKontoMedicinskiPlinovi(objekt);
                LoadKontoMaterijalZaOdrzavanjeCistoce(objekt);
                LoadKontoUredskiMaterijal(objekt);
                LoadKontoOstaliRazniMaterijali(objekt);
                LoadKontoUtrosenaEnergija(objekt);
                LoadKontoUgradeniRezevniDijelovi(objekt);
                LoadKontoPostanskiIzdaci(objekt);
                LoadKontoTekuceIInvensticijskoOdrzavanje(objekt);
                LoadKontoIzdaciZaUslugeDrugihZdravUstanova(objekt);
                LoadKontoOstaliIzdaci(objekt);
                LoadKontoBrutoPlace(objekt);
                LoadKontoOstaliRashodiZaZaposlene(objekt);
                LoadKontoDoprinosiNaPlace(objekt);
                LoadKontoIzdaciZaPrijevozZaposlenika(objekt);
                LoadKontoOstaliMaterijalniRashodiZaZaposlene(objekt);
                LoadKontoFinancijskiRashodi(objekt);
                LoadKontoIzdaciZaKapitalnaUlaganja(objekt);
                LoadKontoOstaliIIzvanredniIzdaci(objekt);
                LoadKontoIzdaciZaFinancijskuImovinuIOtplateZajmova(objekt);
                LoadKontoNabavnaVrijednostProdaneRode(objekt);
                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }

        private void LoadKontoNabavnaVrijednostProdaneRode(BusinessLogic.Pokazatelji objekt)
        {
            uceNabavnaVrijednostProdaneRode.DataSource = objekt.GetKonto();
            uceNabavnaVrijednostProdaneRode.DataBind();
        }
        private void LoadKontoIzdaciZaFinancijskuImovinuIOtplateZajmova(BusinessLogic.Pokazatelji objekt)
        {
            uceIzdaciZaFinancijskuImovinuIOtplateZajmova.DataSource = objekt.GetKonto();
            uceIzdaciZaFinancijskuImovinuIOtplateZajmova.DataBind();
        }
        private void LoadKontoOstaliIIzvanredniIzdaci(BusinessLogic.Pokazatelji objekt)
        {
            uceOstaliIIzvanredniIzdaci.DataSource = objekt.GetKonto();
            uceOstaliIIzvanredniIzdaci.DataBind();
        }
        private void LoadKontoIzdaciZaKapitalnaUlaganja(BusinessLogic.Pokazatelji objekt)
        {
            uceIzdaciZaKapitalnaUlaganja.DataSource = objekt.GetKonto();
            uceIzdaciZaKapitalnaUlaganja.DataBind();
        }
        private void LoadKontoFinancijskiRashodi(BusinessLogic.Pokazatelji objekt)
        {
            uceFinancijskiRashodi.DataSource = objekt.GetKonto();
            uceFinancijskiRashodi.DataBind();
        }
        private void LoadKontoOstaliMaterijalniRashodiZaZaposlene(BusinessLogic.Pokazatelji objekt)
        {
            uceOstaliMaterijalniRashodiZaZaposlene.DataSource = objekt.GetKonto();
            uceOstaliMaterijalniRashodiZaZaposlene.DataBind();
        }
        private void LoadKontoIzdaciZaPrijevozZaposlenika(BusinessLogic.Pokazatelji objekt)
        {
            uceIzdaciZaPrijevozZaposlenika.DataSource = objekt.GetKonto();
            uceIzdaciZaPrijevozZaposlenika.DataBind();
        }
        private void LoadKontoDoprinosiNaPlace(BusinessLogic.Pokazatelji objekt)
        {
            uceDoprinosiNaPlace.DataSource = objekt.GetKonto();
            uceDoprinosiNaPlace.DataBind();
        }
        private void LoadKontoOstaliRashodiZaZaposlene(BusinessLogic.Pokazatelji objekt)
        {
            uceOstaliRashodiZaZaposlene.DataSource = objekt.GetKonto();
            uceOstaliRashodiZaZaposlene.DataBind();
        }
        private void LoadKontoBrutoPlace(BusinessLogic.Pokazatelji objekt)
        {
            uceBrutoPlace.DataSource = objekt.GetKonto();
            uceBrutoPlace.DataBind();
        }
        private void LoadKontoOstaliIzdaci(BusinessLogic.Pokazatelji objekt)
        {
            uceOstaliIzdaci.DataSource = objekt.GetKonto();
            uceOstaliIzdaci.DataBind();
        }
        private void LoadKontoIzdaciZaUslugeDrugihZdravUstanova(BusinessLogic.Pokazatelji objekt)
        {
            uceIzdaciZaUslugeDrugihZdravUstanova.DataSource = objekt.GetKonto();
            uceIzdaciZaUslugeDrugihZdravUstanova.DataBind();
        }
        private void LoadKontoTekuceIInvensticijskoOdrzavanje(BusinessLogic.Pokazatelji objekt)
        {
            uceTekuceIInvensticijskoOdrzavanje.DataSource = objekt.GetKonto();
            uceTekuceIInvensticijskoOdrzavanje.DataBind();
        }
        private void LoadKontoPostanskiIzdaci(BusinessLogic.Pokazatelji objekt)
        {
            ucePostanskiIzdaci.DataSource = objekt.GetKonto();
            ucePostanskiIzdaci.DataBind();
        }
        private void LoadKontoUgradeniRezevniDijelovi(BusinessLogic.Pokazatelji objekt)
        {
            uceUgradeniRezevniDijelovi.DataSource = objekt.GetKonto();
            uceUgradeniRezevniDijelovi.DataBind();
        }
        private void LoadKontoUtrosenaEnergija(BusinessLogic.Pokazatelji objekt)
        {
            uceUtrosenaEnergija.DataSource = objekt.GetKonto();
            uceUtrosenaEnergija.DataBind();
        }
        private void LoadKontoOstaliRazniMaterijali(BusinessLogic.Pokazatelji objekt)
        {
            uceOstaliRazniMaterijali.DataSource = objekt.GetKonto();
            uceOstaliRazniMaterijali.DataBind();
        }
        private void LoadKontoUredskiMaterijal(BusinessLogic.Pokazatelji objekt)
        {
            uceUredskiMaterijal.DataSource = objekt.GetKonto();
            uceUredskiMaterijal.DataBind();
        }
        private void LoadKontoMaterijalZaOdrzavanjeCistoce(BusinessLogic.Pokazatelji objekt)
        {
            uceMaterijalZaOdrzavanjeCistoce.DataSource = objekt.GetKonto();
            uceMaterijalZaOdrzavanjeCistoce.DataBind();
        }
        private void LoadKontoMedicinskiPlinovi(BusinessLogic.Pokazatelji objekt)
        {
            uceMedicinskiPlinovi.DataSource = objekt.GetKonto();
            uceMedicinskiPlinovi.DataBind();
        }
        private void LoadKontoPrihodiOdHZZO(BusinessLogic.Pokazatelji objekt)
        {
            ucePrihodiOdHZZO.DataSource = objekt.GetKonto();
            ucePrihodiOdHZZO.DataBind();
        }
        private void LoadKontoProracuniBolnica(BusinessLogic.Pokazatelji objekt)
        {
            uceProracuniBolnica.DataSource = objekt.GetKonto();
            uceProracuniBolnica.DataBind();
        }
        private void LoadKontoDopunskoZdravstvenoOsiguranje(BusinessLogic.Pokazatelji objekt)
        {
            uceDopunskoZdravstvenoOsiguranje.DataSource = objekt.GetKonto();
            uceDopunskoZdravstvenoOsiguranje.DataBind();
        }
        private void LoadKontoUgovorPrimarZdravZastitu(BusinessLogic.Pokazatelji objekt)
        {
            uceUgovorPrimarZdravZastitu.DataSource = objekt.GetKonto();
            uceUgovorPrimarZdravZastitu.DataBind();
        }
        private void LoadKontoZaUslugeIzvanUgovorenogLimita(BusinessLogic.Pokazatelji objekt)
        {
            uceZaUslugeIzvanUgovorenogLimita.DataSource = objekt.GetKonto();
            uceZaUslugeIzvanUgovorenogLimita.DataBind();
        }
        private void LoadKontoSOsnovaOzljedaNaRaduIProfBol(BusinessLogic.Pokazatelji objekt)
        {
            uceSOsnovaOzljedaNaRaduIProfBol.DataSource = objekt.GetKonto();
            uceSOsnovaOzljedaNaRaduIProfBol.DataBind();
        }
        private void LoadKontoPrihodiOdPruzenihUslugaDrugimZdrUstanovama(BusinessLogic.Pokazatelji objekt)
        {
            ucePrihodiOdPruzenihUslugaDrugimZdrUstanovama.DataSource = objekt.GetKonto();
            ucePrihodiOdPruzenihUslugaDrugimZdrUstanovama.DataBind();
        }
        private void LoadKontoPrihodiOdProracuna(BusinessLogic.Pokazatelji objekt)
        {
            ucePrihodiOdProracuna.DataSource = objekt.GetKonto();
            ucePrihodiOdProracuna.DataBind();
        }
        private void LoadKontoPrihodiOdOstalihKorisnika(BusinessLogic.Pokazatelji objekt)
        {
            ucePrihodiOdOstalihKorisnika.DataSource = objekt.GetKonto();
            ucePrihodiOdOstalihKorisnika.DataBind();
        }
        private void LoadKontoPrihodOdParticipacije(BusinessLogic.Pokazatelji objekt)
        {
            ucePrihodOdParticipacije.DataSource = objekt.GetKonto();
            ucePrihodOdParticipacije.DataBind();
        }
        private void LoadKontoOstaliIzvanredniPrihodi(BusinessLogic.Pokazatelji objekt)
        {
            uceOstaliIzvanredniPrihodi.DataSource = objekt.GetKonto();
            uceOstaliIzvanredniPrihodi.DataBind();
        }
        private void LoadKontoPrimiciOdFinancijskeImovineIZaduzenja(BusinessLogic.Pokazatelji objekt)
        {
            ucePrimiciOdFinancijskeImovineIZaduzenja.DataSource = objekt.GetKonto();
            ucePrimiciOdFinancijskeImovineIZaduzenja.DataBind();
        }
        private void LoadKontoLijekovi(BusinessLogic.Pokazatelji objekt)
        {
            uceLijekovi.DataSource = objekt.GetKonto();
            uceLijekovi.DataBind();
        }
        private void LoadKontoPotrosniMedicinskiMaterijal(BusinessLogic.Pokazatelji objekt)
        {
            ucePotrosniMedicinskiMaterijal.DataSource = objekt.GetKonto();
            ucePotrosniMedicinskiMaterijal.DataBind();
        }
        private void LoadKontoKrvIKrvniPripravci(BusinessLogic.Pokazatelji objekt)
        {
            uceKrvIKrvniPripravci.DataSource = objekt.GetKonto();
            uceKrvIKrvniPripravci.DataBind();
        }
        private void LoadKontoZivezneNamirnice(BusinessLogic.Pokazatelji objekt)
        {
            uceZivezneNamirnice.DataSource = objekt.GetKonto();
            uceZivezneNamirnice.DataBind();
        }


        private void btnAddPrihodiOdHZZO_Click(object sender, EventArgs e)
        {
            if (ucePrihodiOdHZZO.Value != null)
            {
                foreach (var item in lbxPrihodiOdHZZO.Items)
                {
                    if (item.ToString() == ucePrihodiOdHZZO.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPrihodiOdHZZO.Items.Add(string.Format(ucePrihodiOdHZZO.Text));
            }
        }
        private void btnRemovePrihodiOdHZZO_Click(object sender, EventArgs e)
        {
            if (lbxPrihodiOdHZZO.SelectedIndex > -1)
            {
                lbxPrihodiOdHZZO.Items.Remove(lbxPrihodiOdHZZO.SelectedItem);
            }
        }
        private void btnAddProracuniBolnica_Click(object sender, EventArgs e)
        {
            if (uceProracuniBolnica.Value != null)
            {
                foreach (var item in lbxProracuniBolnica.Items)
                {
                    if (item.ToString() == uceProracuniBolnica.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxProracuniBolnica.Items.Add(string.Format(uceProracuniBolnica.Text));
            }
        }
        private void btnRemoveProracuniBolnica_Click(object sender, EventArgs e)
        {

        }
        private void btnAddDopunskoZdravstvenoOsiguranje_Click(object sender, EventArgs e)
        {
            if (uceDopunskoZdravstvenoOsiguranje.Value != null)
            {
                foreach (var item in lbxDopunskoZdravstvenoOsiguranje.Items)
                {
                    if (item.ToString() == uceDopunskoZdravstvenoOsiguranje.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxDopunskoZdravstvenoOsiguranje.Items.Add(string.Format(uceDopunskoZdravstvenoOsiguranje.Text));
            }
        }
        private void btnRemoveDopunskoZdravstvenoOsiguranje_Click(object sender, EventArgs e)
        {
            if (lbxDopunskoZdravstvenoOsiguranje.SelectedIndex > -1)
            {
                lbxDopunskoZdravstvenoOsiguranje.Items.Remove(lbxDopunskoZdravstvenoOsiguranje.SelectedItem);
            }
        }
        private void btnAddUgovorPrimarZdravZastitu_Click(object sender, EventArgs e)
        {
            if (uceUgovorPrimarZdravZastitu.Value != null)
            {
                foreach (var item in lbxUgovorPrimarZdravZastitu.Items)
                {
                    if (item.ToString() == uceUgovorPrimarZdravZastitu.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxUgovorPrimarZdravZastitu.Items.Add(string.Format(uceUgovorPrimarZdravZastitu.Text));
            }
        }
        private void btnRemoveUgovorPrimarZdravZastitu_Click(object sender, EventArgs e)
        {
            if (lbxUgovorPrimarZdravZastitu.SelectedIndex > -1)
            {
                lbxUgovorPrimarZdravZastitu.Items.Remove(lbxUgovorPrimarZdravZastitu.SelectedItem);
            }
        }
        private void btnAddZaZaUslugeIzvanUgovorenogLimita_Click(object sender, EventArgs e)
        {
            if (uceZaUslugeIzvanUgovorenogLimita.Value != null)
            {
                foreach (var item in lbxZaUslugeIzvanUgovorenogLimita.Items)
                {
                    if (item.ToString() == uceZaUslugeIzvanUgovorenogLimita.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZaUslugeIzvanUgovorenogLimita.Items.Add(string.Format(uceZaUslugeIzvanUgovorenogLimita.Text));
            }
        }
        private void btnRemoveZaUslugeIzvanUgovorenogLimita_Click(object sender, EventArgs e)
        {
            if (lbxZaUslugeIzvanUgovorenogLimita.SelectedIndex > -1)
            {
                lbxZaUslugeIzvanUgovorenogLimita.Items.Remove(lbxZaUslugeIzvanUgovorenogLimita.SelectedItem);
            }
        }
        private void btnAddSOsnovaOzljedaNaRaduIProfBol_Click(object sender, EventArgs e)
        {
            if (uceSOsnovaOzljedaNaRaduIProfBol.Value != null)
            {
                foreach (var item in lbxSOsnovaOzljedaNaRaduIProfBol.Items)
                {
                    if (item.ToString() == uceSOsnovaOzljedaNaRaduIProfBol.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxSOsnovaOzljedaNaRaduIProfBol.Items.Add(string.Format(uceSOsnovaOzljedaNaRaduIProfBol.Text));
            }
        }
        private void btnRemoveSOsnovaOzljedaNaRaduIProfBol_Click(object sender, EventArgs e)
        {
            if (lbxSOsnovaOzljedaNaRaduIProfBol.SelectedIndex > -1)
            {
                lbxSOsnovaOzljedaNaRaduIProfBol.Items.Remove(lbxSOsnovaOzljedaNaRaduIProfBol.SelectedItem);
            }
        }
        private void btnAddPrihodiOdPruzenihUslugaDrugimZdrUstanovama_Click(object sender, EventArgs e)
        {
            if (ucePrihodiOdPruzenihUslugaDrugimZdrUstanovama.Value != null)
            {
                foreach (var item in lbxPrihodiOdPruzenihUslugaDrugimZdrUstanovama.Items)
                {
                    if (item.ToString() == ucePrihodiOdPruzenihUslugaDrugimZdrUstanovama.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPrihodiOdPruzenihUslugaDrugimZdrUstanovama.Items.Add(string.Format(ucePrihodiOdPruzenihUslugaDrugimZdrUstanovama.Text));
            }
        }
        private void btnRemovePrihodiOdPruzenihUslugaDrugimZdrUstanovama_Click(object sender, EventArgs e)
        {
            if (lbxPrihodiOdPruzenihUslugaDrugimZdrUstanovama.SelectedIndex > -1)
            {
                lbxPrihodiOdPruzenihUslugaDrugimZdrUstanovama.Items.Remove(lbxPrihodiOdPruzenihUslugaDrugimZdrUstanovama.SelectedItem);
            }
        }
        private void btnAddPrihodiOdProracuna_Click(object sender, EventArgs e)
        {
            if (ucePrihodiOdProracuna.Value != null)
            {
                foreach (var item in lbxPrihodiOdProracuna.Items)
                {
                    if (item.ToString() == ucePrihodiOdProracuna.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPrihodiOdProracuna.Items.Add(string.Format(ucePrihodiOdProracuna.Text));
            }
        }
        private void btnRemovePrihodiOdProracuna_Click(object sender, EventArgs e)
        {
            if (lbxPrihodiOdProracuna.SelectedIndex > -1)
            {
                lbxPrihodiOdProracuna.Items.Remove(lbxPrihodiOdProracuna.SelectedItem);
            }
        }
        private void btnAddPrihodiOdOstalihKorisnika_Click(object sender, EventArgs e)
        {
            if (ucePrihodiOdOstalihKorisnika.Value != null)
            {
                foreach (var item in lbxPrihodiOdOstalihKorisnika.Items)
                {
                    if (item.ToString() == ucePrihodiOdOstalihKorisnika.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPrihodiOdOstalihKorisnika.Items.Add(string.Format(ucePrihodiOdOstalihKorisnika.Text));
            }
        }
        private void btnRemovePrihodiOdOstalihKorisnika_Click(object sender, EventArgs e)
        {
            if (lbxPrihodiOdOstalihKorisnika.SelectedIndex > -1)
            {
                lbxPrihodiOdOstalihKorisnika.Items.Remove(lbxPrihodiOdOstalihKorisnika.SelectedItem);
            }
        }
        private void btnAddPrihodOdParticipacije_Click(object sender, EventArgs e)
        {
            if (ucePrihodOdParticipacije.Value != null)
            {
                foreach (var item in lbxPrihodOdParticipacije.Items)
                {
                    if (item.ToString() == ucePrihodOdParticipacije.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPrihodOdParticipacije.Items.Add(string.Format(ucePrihodOdParticipacije.Text));
            }
        }
        private void btnRemovePrihodOdParticipacije_Click(object sender, EventArgs e)
        {
            if (lbxPrihodOdParticipacije.SelectedIndex > -1)
            {
                lbxPrihodOdParticipacije.Items.Remove(lbxPrihodOdParticipacije.SelectedItem);
            }
        }
        private void bntAddOstaliIzvanredniPrihodi_Click(object sender, EventArgs e)
        {
            if (uceOstaliIzvanredniPrihodi.Value != null)
            {
                foreach (var item in lbxOstaliIzvanredniPrihodi.Items)
                {
                    if (item.ToString() == uceOstaliIzvanredniPrihodi.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxOstaliIzvanredniPrihodi.Items.Add(string.Format(uceOstaliIzvanredniPrihodi.Text));
            }
        }
        private void btnRemoveOstaliIzvanredniPrihodi_Click(object sender, EventArgs e)
        {
            if (lbxOstaliIzvanredniPrihodi.SelectedIndex > -1)
            {
                lbxOstaliIzvanredniPrihodi.Items.Remove(lbxOstaliIzvanredniPrihodi.SelectedItem);
            }
        }
        private void btnAddPrimiciOdFinancijskeImovineIZaduzenja_Click(object sender, EventArgs e)
        {
            if (ucePrimiciOdFinancijskeImovineIZaduzenja.Value != null)
            {
                foreach (var item in lbxPrimiciOdFinancijskeImovineIZaduzenja.Items)
                {
                    if (item.ToString() == ucePrimiciOdFinancijskeImovineIZaduzenja.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPrimiciOdFinancijskeImovineIZaduzenja.Items.Add(string.Format(ucePrimiciOdFinancijskeImovineIZaduzenja.Text));
            }
        }
        private void btnRemovePrimiciOdFinancijskeImovineIZaduzenja_Click(object sender, EventArgs e)
        {
            if (lbxPrimiciOdFinancijskeImovineIZaduzenja.SelectedIndex > -1)
            {
                lbxPrimiciOdFinancijskeImovineIZaduzenja.Items.Remove(lbxPrimiciOdFinancijskeImovineIZaduzenja.SelectedItem);
            }
        }
        private void btnAddLijekovi_Click(object sender, EventArgs e)
        {
            if (uceLijekovi.Value != null)
            {
                foreach (var item in lbxLijekovi.Items)
                {
                    if (item.ToString() == uceLijekovi.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxLijekovi.Items.Add(string.Format(uceLijekovi.Text));
            }

        }
        private void btnRemoveLijekovi_Click(object sender, EventArgs e)
        {
            if (lbxLijekovi.SelectedIndex > -1)
            {
                lbxLijekovi.Items.Remove(lbxLijekovi.SelectedItem);
            }
        }
        private void btnAddPotrosniMedicinskiMaterijal_Click(object sender, EventArgs e)
        {
            if (ucePotrosniMedicinskiMaterijal.Value != null)
            {
                foreach (var item in lbxPotrosniMedicinskiMaterijal.Items)
                {
                    if (item.ToString() == ucePotrosniMedicinskiMaterijal.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPotrosniMedicinskiMaterijal.Items.Add(string.Format(ucePotrosniMedicinskiMaterijal.Text));
            }
        }
        private void btnRemovePotrosniMedicinskiMaterijal_Click(object sender, EventArgs e)
        {
            if (lbxPotrosniMedicinskiMaterijal.SelectedIndex > -1)
            {
                lbxPotrosniMedicinskiMaterijal.Items.Remove(lbxPotrosniMedicinskiMaterijal.SelectedItem);
            }
        }
        private void btnAddKrvIKrvniPripravci_Click(object sender, EventArgs e)
        {
            if (uceKrvIKrvniPripravci.Value != null)
            {
                foreach (var item in lbxKrvIKrvniPripravci.Items)
                {
                    if (item.ToString() == uceKrvIKrvniPripravci.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxKrvIKrvniPripravci.Items.Add(string.Format(uceKrvIKrvniPripravci.Text));
            }
        }
        private void btnRemoveKrvIKrvniPripravci_Click(object sender, EventArgs e)
        {
            if (lbxKrvIKrvniPripravci.SelectedIndex > -1)
            {
                lbxKrvIKrvniPripravci.Items.Remove(lbxKrvIKrvniPripravci.SelectedItem);
            }
        }
        private void btnAddZivezneNamirnice_Click(object sender, EventArgs e)
        {
            if (uceZivezneNamirnice.Value != null)
            {
                foreach (var item in lbxZivezneNamirnice.Items)
                {
                    if (item.ToString() == uceZivezneNamirnice.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZivezneNamirnice.Items.Add(string.Format(uceZivezneNamirnice.Text));
            }
        }
        private void btnRemoveZivezneNamirnice_Click(object sender, EventArgs e)
        {
            if (lbxZivezneNamirnice.SelectedIndex > -1)
            {
                lbxZivezneNamirnice.Items.Remove(lbxZivezneNamirnice.SelectedItem);
            }
        }
        private void btnAddMedicinskiPlinovi_Click(object sender, EventArgs e)
        {
            if (uceMedicinskiPlinovi.Value != null)
            {
                foreach (var item in lbxMedicinskiPlinovi.Items)
                {
                    if (item.ToString() == uceMedicinskiPlinovi.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxMedicinskiPlinovi.Items.Add(string.Format(uceMedicinskiPlinovi.Text));
            }
        }
        private void btnRemoveMedicinskiPlinovi_Click(object sender, EventArgs e)
        {
            if (lbxMedicinskiPlinovi.SelectedIndex > -1)
            {
                lbxMedicinskiPlinovi.Items.Remove(lbxMedicinskiPlinovi.SelectedItem);
            }
        }
        private void btnAddMaterijalZaOdrzavanjeCistoce_Click(object sender, EventArgs e)
        {
            if (uceMaterijalZaOdrzavanjeCistoce.Value != null)
            {
                foreach (var item in lbxMaterijalZaOdrzavanjeCistoce.Items)
                {
                    if (item.ToString() == uceMaterijalZaOdrzavanjeCistoce.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxMaterijalZaOdrzavanjeCistoce.Items.Add(string.Format(uceMaterijalZaOdrzavanjeCistoce.Text));
            }
        }
        private void btnRemoveMaterijalZaOdrzavanjeCistoce_Click(object sender, EventArgs e)
        {
            if (lbxMaterijalZaOdrzavanjeCistoce.SelectedIndex > -1)
            {
                lbxMaterijalZaOdrzavanjeCistoce.Items.Remove(lbxMaterijalZaOdrzavanjeCistoce.SelectedItem);
            }
        }
        private void btnAddUredskiMaterijal_Click(object sender, EventArgs e)
        {
            if (uceUredskiMaterijal.Value != null)
            {
                foreach (var item in lbxUredskiMaterijal.Items)
                {
                    if (item.ToString() == uceUredskiMaterijal.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxUredskiMaterijal.Items.Add(string.Format(uceUredskiMaterijal.Text));
            }
        }
        private void btnRemoveUredskiMaterijal_Click(object sender, EventArgs e)
        {
            if (lbxUredskiMaterijal.SelectedIndex > -1)
            {
                lbxUredskiMaterijal.Items.Remove(lbxUredskiMaterijal.SelectedItem);
            }
        }
        private void btnAddOstaliRazniMaterijali_Click(object sender, EventArgs e)
        {
            if (uceOstaliRazniMaterijali.Value != null)
            {
                foreach (var item in lbxOstaliRazniMaterijali.Items)
                {
                    if (item.ToString() == uceOstaliRazniMaterijali.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxOstaliRazniMaterijali.Items.Add(string.Format(uceOstaliRazniMaterijali.Text));
            }
        }
        private void btnRemoveOstaliRazniMaterijali_Click(object sender, EventArgs e)
        {
            if (lbxOstaliRazniMaterijali.SelectedIndex > -1)
            {
                lbxOstaliRazniMaterijali.Items.Remove(lbxOstaliRazniMaterijali.SelectedItem);
            }
        }
        private void btnAddUtrosenaEnergija_Click(object sender, EventArgs e)
        {
            if (uceUtrosenaEnergija.Value != null)
            {
                foreach (var item in lbxUtrosenaEnergija.Items)
                {
                    if (item.ToString() == uceUtrosenaEnergija.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxUtrosenaEnergija.Items.Add(string.Format(uceUtrosenaEnergija.Text));
            }
        }
        private void btnRemoveUtrosenaEnergija_Click(object sender, EventArgs e)
        {
            if (lbxUtrosenaEnergija.SelectedIndex > -1)
            {
                lbxUtrosenaEnergija.Items.Remove(lbxUtrosenaEnergija.SelectedItem);
            }
        }
        private void btnAddUgradeniRezevniDijelovi_Click(object sender, EventArgs e)
        {
            if (uceUgradeniRezevniDijelovi.Value != null)
            {
                foreach (var item in lbxUgradeniRezevniDijelovi.Items)
                {
                    if (item.ToString() == uceUgradeniRezevniDijelovi.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxUgradeniRezevniDijelovi.Items.Add(string.Format(uceUgradeniRezevniDijelovi.Text));
            }
        }
        private void btnRemoveUgradeniRezevniDijelovi_Click(object sender, EventArgs e)
        {
            if (lbxUgradeniRezevniDijelovi.SelectedIndex > -1)
            {
                lbxUgradeniRezevniDijelovi.Items.Remove(lbxUgradeniRezevniDijelovi.SelectedItem);
            }
        }
        private void btnAddPostanskiIzdaci_Click(object sender, EventArgs e)
        {
            if (ucePostanskiIzdaci.Value != null)
            {
                foreach (var item in lbxPostanskiIzdaci.Items)
                {
                    if (item.ToString() == ucePostanskiIzdaci.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxPostanskiIzdaci.Items.Add(string.Format(ucePostanskiIzdaci.Text));
            }
        }
        private void btnRemovePostanskiIzdaci_Click(object sender, EventArgs e)
        {
            if (lbxPostanskiIzdaci.SelectedIndex > -1)
            {
                lbxPostanskiIzdaci.Items.Remove(lbxPostanskiIzdaci.SelectedItem);
            }
        }
        private void btnAddTekuceIInvensticijskoOdrzavanje_Click(object sender, EventArgs e)
        {
            if (uceTekuceIInvensticijskoOdrzavanje.Value != null)
            {
                foreach (var item in lbxTekuceIInvensticijskoOdrzavanje.Items)
                {
                    if (item.ToString() == uceTekuceIInvensticijskoOdrzavanje.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxTekuceIInvensticijskoOdrzavanje.Items.Add(string.Format(uceTekuceIInvensticijskoOdrzavanje.Text));
            }
        }
        private void btnRemoveTekuceIInvensticijskoOdrzavanje_Click(object sender, EventArgs e)
        {
            if (lbxTekuceIInvensticijskoOdrzavanje.SelectedIndex > -1)
            {
                lbxTekuceIInvensticijskoOdrzavanje.Items.Remove(lbxTekuceIInvensticijskoOdrzavanje.SelectedItem);
            }
        }
        private void btnAddIzdaciZaUslugeDrugihZdravUstanova_Click(object sender, EventArgs e)
        {
            if (uceIzdaciZaUslugeDrugihZdravUstanova.Value != null)
            {
                foreach (var item in lbxIzdaciZaUslugeDrugihZdravUstanova.Items)
                {
                    if (item.ToString() == uceIzdaciZaUslugeDrugihZdravUstanova.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxIzdaciZaUslugeDrugihZdravUstanova.Items.Add(string.Format(uceIzdaciZaUslugeDrugihZdravUstanova.Text));
            }
        }
        private void btnRemoveIzdaciZaUslugeDrugihZdravUstanova_Click(object sender, EventArgs e)
        {
            if (lbxIzdaciZaUslugeDrugihZdravUstanova.SelectedIndex > -1)
            {
                lbxIzdaciZaUslugeDrugihZdravUstanova.Items.Remove(lbxIzdaciZaUslugeDrugihZdravUstanova.SelectedItem);
            }
        }
        private void btnAddOstaliIzdaci_Click(object sender, EventArgs e)
        {
            if (uceOstaliIzdaci.Value != null)
            {
                foreach (var item in lbxOstaliIzdaci.Items)
                {
                    if (item.ToString() == uceOstaliIzdaci.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxOstaliIzdaci.Items.Add(string.Format(uceOstaliIzdaci.Text));
            }
        }
        private void btnRemoveOstaliIzdaci_Click(object sender, EventArgs e)
        {
            if (lbxOstaliIzdaci.SelectedIndex > -1)
            {
                lbxOstaliIzdaci.Items.Remove(lbxOstaliIzdaci.SelectedItem);
            }
        }
        private void btnAddBrutoPlace_Click(object sender, EventArgs e)
        {
            if (uceBrutoPlace.Value != null)
            {
                foreach (var item in lbxBrutoPlace.Items)
                {
                    if (item.ToString() == uceBrutoPlace.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxBrutoPlace.Items.Add(string.Format(uceBrutoPlace.Text));
            }
        }
        private void btnRemoveBrutoPlace_Click(object sender, EventArgs e)
        {
            if (lbxBrutoPlace.SelectedIndex > -1)
            {
                lbxBrutoPlace.Items.Remove(lbxBrutoPlace.SelectedItem);
            }
        }
        private void btnAddOstaliRashodiZaZaposlene_Click(object sender, EventArgs e)
        {
            if (uceOstaliRashodiZaZaposlene.Value != null)
            {
                foreach (var item in lbxOstaliRashodiZaZaposlene.Items)
                {
                    if (item.ToString() == uceOstaliRashodiZaZaposlene.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxOstaliRashodiZaZaposlene.Items.Add(string.Format(uceOstaliRashodiZaZaposlene.Text));
            }
        }
        private void btnRemoveOstaliRashodiZaZaposlene_Click(object sender, EventArgs e)
        {
            if (lbxOstaliRashodiZaZaposlene.SelectedIndex > -1)
            {
                lbxOstaliRashodiZaZaposlene.Items.Remove(lbxOstaliRashodiZaZaposlene.SelectedItem);
            }
        }
        private void btnAddDoprinosiNaPlace_Click(object sender, EventArgs e)
        {
            if (uceDoprinosiNaPlace.Value != null)
            {
                foreach (var item in lbxDoprinosiNaPlace.Items)
                {
                    if (item.ToString() == uceDoprinosiNaPlace.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxDoprinosiNaPlace.Items.Add(string.Format(uceDoprinosiNaPlace.Text));
            }
        }
        private void btnRemoveDoprinosiNaPlace_Click(object sender, EventArgs e)
        {
            if (lbxDoprinosiNaPlace.SelectedIndex > -1)
            {
                lbxDoprinosiNaPlace.Items.Remove(lbxDoprinosiNaPlace.SelectedItem);
            }
        }
        private void btnAddIzdaciZaPrijevozZaposlenika_Click(object sender, EventArgs e)
        {
            if (uceIzdaciZaPrijevozZaposlenika.Value != null)
            {
                foreach (var item in lbxIzdaciZaPrijevozZaposlenika.Items)
                {
                    if (item.ToString() == uceIzdaciZaPrijevozZaposlenika.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxIzdaciZaPrijevozZaposlenika.Items.Add(string.Format(uceIzdaciZaPrijevozZaposlenika.Text));
            }
        }
        private void btnRemoveIzdaciZaPrijevozZaposlenika_Click(object sender, EventArgs e)
        {
            if (lbxIzdaciZaPrijevozZaposlenika.SelectedIndex > -1)
            {
                lbxIzdaciZaPrijevozZaposlenika.Items.Remove(lbxIzdaciZaPrijevozZaposlenika.SelectedItem);
            }
        }
        private void btnAddOstaliMaterijalniRashodiZaZaposlene_Click(object sender, EventArgs e)
        {
            if (uceOstaliMaterijalniRashodiZaZaposlene.Value != null)
            {
                foreach (var item in lbxOstaliMaterijalniRashodiZaZaposlene.Items)
                {
                    if (item.ToString() == uceOstaliMaterijalniRashodiZaZaposlene.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxOstaliMaterijalniRashodiZaZaposlene.Items.Add(string.Format(uceOstaliMaterijalniRashodiZaZaposlene.Text));
            }
        }
        private void btnRemoveOstaliMaterijalniRashodiZaZaposlene_Click(object sender, EventArgs e)
        {
            if (lbxOstaliMaterijalniRashodiZaZaposlene.SelectedIndex > -1)
            {
                lbxOstaliMaterijalniRashodiZaZaposlene.Items.Remove(lbxOstaliMaterijalniRashodiZaZaposlene.SelectedItem);
            }
        }
        private void btnAddFinancijskiRashodi_Click(object sender, EventArgs e)
        {
            if (uceFinancijskiRashodi.Value != null)
            {
                foreach (var item in lbxFinancijskiRashodi.Items)
                {
                    if (item.ToString() == uceFinancijskiRashodi.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxFinancijskiRashodi.Items.Add(string.Format(uceFinancijskiRashodi.Text));
            }
        }
        private void btnRemoveFinancijskiRashodi_Click(object sender, EventArgs e)
        {
            if (lbxFinancijskiRashodi.SelectedIndex > -1)
            {
                lbxFinancijskiRashodi.Items.Remove(lbxFinancijskiRashodi.SelectedItem);
            }
        }
        private void btnAddIzdaciZaKapitalnaUlaganja_Click(object sender, EventArgs e)
        {
            if (uceIzdaciZaKapitalnaUlaganja.Value != null)
            {
                foreach (var item in lbxIzdaciZaKapitalnaUlaganja.Items)
                {
                    if (item.ToString() == uceIzdaciZaKapitalnaUlaganja.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxIzdaciZaKapitalnaUlaganja.Items.Add(string.Format(uceIzdaciZaKapitalnaUlaganja.Text));
            }
        }
        private void btnRemoveIzdaciZaKapitalnaUlaganja_Click(object sender, EventArgs e)
        {
            if (lbxIzdaciZaKapitalnaUlaganja.SelectedIndex > -1)
            {
                lbxIzdaciZaKapitalnaUlaganja.Items.Remove(lbxIzdaciZaKapitalnaUlaganja.SelectedItem);
            }
        }
        private void btnAddOstaliIIzvanredniIzdaci_Click(object sender, EventArgs e)
        {
            if (uceOstaliIIzvanredniIzdaci.Value != null)
            {
                foreach (var item in lbxOstaliIIzvanredniIzdaci.Items)
                {
                    if (item.ToString() == uceOstaliIIzvanredniIzdaci.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxOstaliIIzvanredniIzdaci.Items.Add(string.Format(uceOstaliIIzvanredniIzdaci.Text));
            }
        }
        private void btnRemoveOstaliIIzvanredniIzdaci_Click(object sender, EventArgs e)
        {
            if (lbxOstaliIIzvanredniIzdaci.SelectedIndex > -1)
            {
                lbxOstaliIIzvanredniIzdaci.Items.Remove(lbxOstaliIIzvanredniIzdaci.SelectedItem);
            }
        }
        private void btnAddIzdaciZaFinancijskuImovinuIOtplateZajmova_Click(object sender, EventArgs e)
        {
            if (uceIzdaciZaFinancijskuImovinuIOtplateZajmova.Value != null)
            {
                foreach (var item in lbxIzdaciZaFinancijskuImovinuIOtplateZajmova.Items)
                {
                    if (item.ToString() == uceIzdaciZaFinancijskuImovinuIOtplateZajmova.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxIzdaciZaFinancijskuImovinuIOtplateZajmova.Items.Add(string.Format(uceIzdaciZaFinancijskuImovinuIOtplateZajmova.Text));
            }
        }
        private void btnRemoveIzdaciZaFinancijskuImovinuIOtplateZajmova_Click(object sender, EventArgs e)
        {
            if (lbxIzdaciZaFinancijskuImovinuIOtplateZajmova.SelectedIndex > -1)
            {
                lbxIzdaciZaFinancijskuImovinuIOtplateZajmova.Items.Remove(lbxIzdaciZaFinancijskuImovinuIOtplateZajmova.SelectedItem);
            }
        }
        private void btnAddNabavnaVrijednostProdaneRode_Click(object sender, EventArgs e)
        {
            if (uceNabavnaVrijednostProdaneRode.Value != null)
            {
                foreach (var item in lbxNabavnaVrijednostProdaneRode.Items)
                {
                    if (item.ToString() == uceNabavnaVrijednostProdaneRode.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxNabavnaVrijednostProdaneRode.Items.Add(string.Format(uceNabavnaVrijednostProdaneRode.Text));
            }
        }
        private void btnRemoveNabavnaVrijednostProdaneRode_Click(object sender, EventArgs e)
        {
            if (lbxNabavnaVrijednostProdaneRode.SelectedIndex > -1)
            {
                lbxNabavnaVrijednostProdaneRode.Items.Remove(lbxNabavnaVrijednostProdaneRode.SelectedItem);
            }
        }
    }
}