using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Materijalno.Enums;
using System.Globalization;

namespace Materijalno.UI.Dokumenti
{
    public partial class ProizvodForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public ProizvodForm(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
                {
                    objekt.pSifra = Convert.ToInt32(uteSifra.Value);
                    objekt.pNaziv = uteNaziv.Value.ToString();
                    objekt.pCijena = Convert.ToDouble(uneCijena.Value);
                    objekt.pJedinicaMjere = (int)uceJedinicaMjere.Value;
                    objekt.pPorez = (int)ucePorez.Value;
                    objekt.pCijenaPDV = Convert.ToDouble(uneCijenaPDV.Value);

                    if (uceGrupa.Value != null)
                    {
                        objekt.grupaProizvod = Convert.ToInt32(uceGrupa.Value);
                    }
                    else
                    {
                        objekt.grupaProizvod = null;
                    }


                    if (FormEditMode == Enums.FormEditMode.Insert)
                    {
                        if (objekt.Insert(message, objekt))
                        {
                            FormEditMode = Enums.FormEditMode.Update;
                            return true;
                        }
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();
            int parser;

            if (uteSifra.Value == null)
            {
                message.Append(" - Sifra je obavezno polje");
            }
            else if(!Int32.TryParse(uteSifra.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format šifre!");
            }
            else if (ProvjeraSifre(Convert.ToInt32(uteSifra.Value)))
            {
                message.Append(" - Odabrana šifra već postoji odaberite drugu šifru!!!");
            }

            if (uteNaziv.Value == null)
            {
                message.Append(" - Naziv proizvoda je obavezno polje!");
            }
            else if (uteNaziv.Text.Length > 500)
            {
                message.Append(" - Naziv proizvoda nesmije sadržavati više od 500 znakova!");
            }

            if (uceJedinicaMjere.Value == null)
            {
                message.Append(" - Jedinica mjere je obavezan!");
            }

            if (ucePorez.Value == null)
            {
                message.Append(" - Porez je obavezan!");
            }

            if (uneCijena.Value == null | uneCijenaPDV.Value == null)
            {
                message.Append(" - Cijena je obavezna!");
            }

            return message;
        }

        private bool ProvjeraSifre(int sifra)
        {
            using(BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
            {
                return objekt.ProvjeraSifre(sifra);
            }
        }


        #endregion

        #region Dogadaji

        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void tsbSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
                {
                    GetSifraProizvod(objekt);
                }
                uneCijena.Value = null;
                uneCijenaPDV.Value = null;
                ucePorez.Value = null;
                uceJedinicaMjere.Value = null;
                uteNaziv.Value = null;
                lblStopaPoreza.Text = "";
                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
            {
                LoadJedinicaMjere(objekt);
                LoadPorez(objekt);
                LoadGrupa(objekt);
                GetSifraProizvod(objekt);
            }
        }

        private void LoadJedinicaMjere(BusinessLogic.Proizvod objekt)
        {
            uceJedinicaMjere.DataSource = objekt.GetJedinicaMjere();
            uceJedinicaMjere.DataBind();
        }

        private void LoadPorez(BusinessLogic.Proizvod objekt)
        {
            ucePorez.DataSource = objekt.GetPorez();
            ucePorez.DataBind();
        }

        private void LoadGrupa(BusinessLogic.Proizvod objekt)
        {
            uceGrupa.DataSource = objekt.GetGrupa();
            uceGrupa.DataBind();
        }

        private void GetSifraProizvod(BusinessLogic.Proizvod objekt)
        {
            uteSifra.Value = objekt.GetSifraPorez();
        }

        private void ucePorez_ValueChanged(object sender, EventArgs e)
        {
            using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
            {
                try
                {
                    double stopa = objekt.GetStopaPorez((int)ucePorez.Value);
                    lblStopaPoreza.Text = stopa.ToString("N2", CultureInfo.InvariantCulture);

                    if (uneCijena.Value != null)
                    {
                        double porez = stopa * Convert.ToDouble(uneCijena.Value) / 100;
                        uneCijenaPDV.Value = Convert.ToDouble(uneCijena.Value) + porez;
                    }
                    else if (uneCijenaPDV.Value != null)
                    {
                        uneCijena.Value = Convert.ToDouble(uneCijenaPDV.Value) / (1+ (stopa / 100));
                    }
                }
                catch { }

            }
        }

        private void uneCijena_ValueChanged(object sender, EventArgs e)
        {
            if (ucePorez.Value != null)
            {
                using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
                {
                    try
                    {
                        double porez = objekt.GetStopaPorez((int)ucePorez.Value) * Convert.ToDouble(uneCijena.Value) / 100;
                        uneCijenaPDV.Value = Convert.ToDouble(uneCijena.Value) + porez;
                    }
                    catch { }
                }
            }
        }

        private void uneCijenaPDV_ValueChanged(object sender, EventArgs e)
        {
            if (ucePorez.Value != null)
            {
                using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
                {
                    try
                    {
                        uneCijena.Value = Convert.ToDouble(uneCijenaPDV.Value) / (1 + (objekt.GetStopaPorez((int)ucePorez.Value) / 100));
                    }
                    catch { }
                }
            }
        }

        #endregion


    }
}
