using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Materijalno.Enums;

namespace Materijalno.UI.Dokumenti
{
    public partial class UnosMeduskladisniceOdredivanjeKolicineForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        public static Nullable<int> pProizvod { get; set; }
        public static Nullable<decimal> pIzlaznaCijena { get; set; }
        public static Nullable<decimal> pUlaznaCijena { get; set; }
        public static Nullable<decimal> pKolicina { get; set; }
        public int pIzlaznoSkladiste { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public UnosMeduskladisniceOdredivanjeKolicineForm(FormEditMode formEditMode, int IzlaznoSkladiste)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
            pIzlaznoSkladiste = IzlaznoSkladiste;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                decimal izlazna_cijena;
                decimal ulazna_cijena;
                decimal kolicina;
                string proizvod;

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (uneIzlaznaCijena.Value == null)
                    {
                        izlazna_cijena = 0;
                    }
                    else
                    {
                        izlazna_cijena = Convert.ToDecimal(uneIzlaznaCijena.Value);
                    }

                    if (uneUlaznaCijena.Value == null)
                    {
                        ulazna_cijena = 0;
                    }
                    else
                    {
                        ulazna_cijena = Convert.ToDecimal(uneUlaznaCijena.Value);
                    }

                    if (uneKolicina.Value == null)
                    {
                        kolicina = 0;
                    }
                    else
                    {
                        kolicina = Convert.ToDecimal(uneKolicina.Value);
                    }

                    proizvod = uceProizvod.Text;

                    DataRow row = BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Find(Convert.ToInt32(uceProizvod.Value));

                    if (row != null)
                    {
                        MessageBox.Show("Proizvod je već dodan na međuskladišnicu, nije moguće dodavati 2 ista proizvoda.", "Novi proizvod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Add(false, BusinessLogic.Meduskladisnica.pID, Convert.ToInt32(uceProizvod.Value), proizvod, izlazna_cijena, ulazna_cijena, kolicina);

                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {

                    DataRow red = BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Select("ID_Proizvoda = " + pProizvod)[0];

                    BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Remove(red);
                    BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.AcceptChanges();

                    if (uneIzlaznaCijena.Value == null)
                    {
                        izlazna_cijena = 0;
                    }
                    else
                    {
                        izlazna_cijena = Convert.ToDecimal(uneIzlaznaCijena.Value);
                    }

                    if (uneUlaznaCijena.Value == null)
                    {
                        ulazna_cijena = 0;
                    }
                    else
                    {
                        ulazna_cijena = Convert.ToDecimal(uneUlaznaCijena.Value);
                    }

                    if (uneKolicina.Value == null)
                    {
                        kolicina = 0;
                    }
                    else
                    {
                        kolicina = Convert.ToDecimal(uneKolicina.Value);
                    }

                    proizvod = uceProizvod.Text;

                    BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Add(false, BusinessLogic.Meduskladisnica.pID, Convert.ToInt32(uceProizvod.Value), proizvod, izlazna_cijena, ulazna_cijena, kolicina);

                    return true;
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (uceProizvod.Value == null)
            {
                message.Append(" - Proizvod je obavezno polje");
            }

            decimal parser;
            if (!decimal.TryParse(uneIzlaznaCijena.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format cijene");
            }

            if (!decimal.TryParse(uneKolicina.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format količine");
            }
            if (parser > Convert.ToDecimal(lblStanje.Text))
            {
                message.Append("- Unesena je prevelika količina!");
            }

            return message;
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
                uceProizvod.Value = null;
                uneKolicina.Value = 0;
                uneIzlaznaCijena.Value = 0;
                uceProizvod.Focus();
                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            using (BusinessLogic.Meduskladisnica objekt = new BusinessLogic.Meduskladisnica())
            {
                LoadProizvod(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm();
                }
            }

        }

        private void LoadForm()
        {
            uceProizvod.Value = pProizvod;
            uneIzlaznaCijena.Value = pIzlaznaCijena;
            uneUlaznaCijena.Value = pUlaznaCijena;
            uneKolicina.Value = pKolicina;
        }

        private void LoadProizvod(BusinessLogic.Meduskladisnica objekt)
        {
            uceProizvod.DataSource = objekt.GetProizvodiZaSkladiste(pIzlaznoSkladiste);
            uceProizvod.DataBind();
        }

        #endregion

        private void uceProizvod_ValueChanged(object sender, EventArgs e)
        {
            if (uceProizvod.Value != null)
            {
                FillStanjeNaSkladistu(Convert.ToInt32(uceProizvod.Value));
            }
        }

        private void FillStanjeNaSkladistu(int proizvod)
        {
            using (BusinessLogic.Meduskladisnica objekt = new BusinessLogic.Meduskladisnica())
            {
                var row = objekt.GetStanjeSkladiste(proizvod, pIzlaznoSkladiste);
                lblStanje.Text = objekt.GetKolicina(proizvod.ToString(), pIzlaznoSkladiste).ToString();
                uneIzlaznaCijena.Value = row["BasePrice"];
                uneUlaznaCijena.Value = row["BasePrice"];
            }
        }

        private void uneIzlaznaCijena_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneIzlaznaCijena.SelectAll();
        }

        private void uneUlaznaCijena_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneUlaznaCijena.SelectAll();
        }

        private void uneKolicina_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneKolicina.SelectAll();
        }
    }
}
