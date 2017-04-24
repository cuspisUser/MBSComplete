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
    public partial class PrimkaStavkeUnosAmbalaza : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        public static string mjernaJedinica { get; set; }
        public static decimal  kolicina { get; set; }

        public static decimal netoNeMoze { get; set; }
        public static decimal neto { get; set; }

        public static Nullable<int> ambalazaMjerna { get; set; }
        public static string ambalazaMjernaTExt { get; set; }
        public static Nullable<decimal> ambalazaKolicina { get; set; }
        public static Nullable<decimal> ambalazaJedinicnaNeMoze { get; set; }
        public static Nullable<decimal> ambalazaJedinicnaNeto { get; set; }


        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public PrimkaStavkeUnosAmbalaza(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;

            lblJedinica.Text = mjernaJedinica;
            uneKolicinaPrenesena.Value = kolicina;

            if (ambalazaMjerna != null)
            {
                uceMjernaJedinica.Value = (int)ambalazaMjerna;
                uneKolicina.Value = (decimal)ambalazaKolicina;
                uneJedinicnaVrijednost.Value = (decimal)ambalazaJedinicnaNeMoze;
            }
        }

        private bool SaveData()
        {
            ambalazaMjerna = (int)uceMjernaJedinica.Value;
            ambalazaKolicina = Convert.ToDecimal(uneKolicina.Value);
            ambalazaJedinicnaNeMoze = Convert.ToDecimal(uneJedinicnaVrijednost.Value);
            ambalazaMjernaTExt = uceMjernaJedinica.Text;

            return true;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (uceMjernaJedinica.Value == null)
            {
                message.Append(" - Mjerna jedinica je obavezno polje");
            }
            
            decimal parser;

            if (!decimal.TryParse(uneKolicina.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format količine");
            }

            return message;
        }

        private void LoadForm()
        {
            lblJedinica.Text = mjernaJedinica;
            uneKolicinaPrenesena.Value = kolicina;
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
            ambalazaJedinicnaNeMoze = null;
            ambalazaJedinicnaNeto = null;
            ambalazaKolicina = null;
            ambalazaMjerna = null;

            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                LoadMjernaJedinica(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm();
                }
            }
        }

        private void LoadMjernaJedinica(BusinessLogic.Primka objekt)
        {
            uceMjernaJedinica.DataSource = objekt.GetMjeranaJedinica();
            uceMjernaJedinica.DataBind();
        }

        #endregion

        private void uneKolicina_ValueChanged(object sender, EventArgs e)
        {
            if (uceMjernaJedinica.Value != null)
            {
                decimal kolicina = Convert.ToDecimal(uneKolicina.Value) / Convert.ToDecimal(uneKolicinaPrenesena.Value);
                uneJedinicnaVrijednost.Value = Math.Round(netoNeMoze / kolicina, 4);

                ambalazaJedinicnaNeto = Math.Round(neto / kolicina, 4);
            }
        }
    }
}
