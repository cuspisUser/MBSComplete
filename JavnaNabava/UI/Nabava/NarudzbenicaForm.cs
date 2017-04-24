using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavnaNabava.Enums;
using Infragistics.Win.UltraWinGrid;
using Deklarit.Practices.CompositeUI;
using System.Runtime.CompilerServices;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace JavnaNabava.UI.Nabava
{
    public partial class uscNarudzbenica : Controls.BaseUserControl
    {
        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscNarudzbenica(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.Narudzbenica.pID_Partner == null)
            {
                message.Append(" - Partner je obavezno polje");
            }
            if (BusinessLogic.Narudzbenica.pDatumNarudzbe == null)
            {
                message.Append(" - Datum narudžbe je obavezno polje");
            }
            if (BusinessLogic.Narudzbenica.pNacinPlacanja == null)
            {
                message.Append(" - način plačanja je obavezno polje");
            }
            if (BusinessLogic.Narudzbenica.pNacinIsporuke == null)
            {
                message.Append(" - način isporuke je obavezno polje");
            }
            if (BusinessLogic.Narudzbenica.pDatumNarudzbe == null)
            {
                message.Append(" - Datum narudžbe je obavezno polje");
            }
            return message;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.Narudzbenica.pID_Partner = (int?)ucbPartner.Value;
            BusinessLogic.Narudzbenica.pBrojNarudzbe = uteBrojNarudzbe.Value.ToString();
            if(uteNapomena.Value != null)
                BusinessLogic.Narudzbenica.pNapomena = uteNapomena.Value.ToString();
            BusinessLogic.Narudzbenica.pDatumNarudzbe = (DateTime?)udtDatumNarudzbe.Value;
            BusinessLogic.Narudzbenica.pNacinIsporuke = (int?)ucbNacinIsporuke.Value;
            BusinessLogic.Narudzbenica.pNacinPlacanja = (int?)ucbNacinPlacanja.Value;

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (objekt.Insert(message, ugdNarudzbenicaProizvod))
                    {
                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {
                    if (objekt.Update(message, ugdNarudzbenicaProizvod))
                    {
                        return true;
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private void LoadPartner(BusinessLogic.Narudzbenica objekt)
        {
            ucbPartner.DataSource = objekt.GetPartner();
            ucbPartner.DataBind();
        }

        private void LoadNacinIsporuke(BusinessLogic.Narudzbenica objekt)
        {
            ucbNacinIsporuke.DataSource = objekt.GetNacinIsporuke();
            ucbNacinIsporuke.DataBind();
        }

        private void LoadNacinPlacanja(BusinessLogic.Narudzbenica objekt)
        {
            ucbNacinPlacanja.DataSource = objekt.GetNacinPlacanja();
            ucbNacinPlacanja.DataBind();
        }

        private void CalculateBrojNarudzbe(BusinessLogic.Narudzbenica objekt)
        {
            uteBrojNarudzbe.Value = objekt.GetBrojNarudzbe();
        }

        private void LoadNarudzbeniceByID(BusinessLogic.Narudzbenica objekt)
        {
            if (objekt.NarudzbenicaByID())
            {
                ucbPartner.Value = BusinessLogic.Narudzbenica.pID_Partner;
                uteBrojNarudzbe.Value = BusinessLogic.Narudzbenica.pBrojNarudzbe;
                udtDatumNarudzbe.Value = BusinessLogic.Narudzbenica.pDatumNarudzbe;
                uteNapomena.Value = BusinessLogic.Narudzbenica.pNapomena;
                ugdNarudzbenicaProizvod.DataSource = BusinessLogic.Narudzbenica.pNarudzbeProizvod.DefaultView;
                ucbNacinPlacanja.Value = BusinessLogic.Narudzbenica.pNacinPlacanja;
                ucbNacinIsporuke.Value = BusinessLogic.Narudzbenica.pNacinIsporuke;

                Utils.Tools.UltraGridStyling(ugdNarudzbenicaProizvod);

                if (ugdNarudzbenicaProizvod.DisplayLayout.Bands.Count > 0)
                {
                    ugdNarudzbenicaProizvod.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdNarudzbenicaProizvod.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdNarudzbenicaProizvod.DisplayLayout.Bands[0].Columns["ID_JedinicaMjere"].Hidden = true;
                }
            }
        }

        #endregion

        #region Dogadaji

        private void btnDodajNacinPlacanja_Click(object sender, EventArgs e)
        {
            using (MaticniPodaci.uscNacinPlacanjaForm objekt = new MaticniPodaci.uscNacinPlacanjaForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Način plačanja") == DialogResult.OK)
                {
                    BusinessLogic.Narudzbenica objekt2 = new BusinessLogic.Narudzbenica();
                    LoadNacinPlacanja(objekt2);
                }
            }
        }

        private void tsbNarudzbenicaOdustani_Click(object sender, EventArgs e)
        {
            ContainerForm.DialogResult = DialogResult.Cancel;
            ContainerForm.Close();
        }

        private void tsbNarudzbenicaSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ContainerForm.DialogResult = DialogResult.OK;
                ContainerForm.Close();
            }
        }

        private void tsbNarudzbenicaSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                FormEditMode = Enums.FormEditMode.Insert;
                uteNapomena.Value = null;
                ugdNarudzbenicaProizvod.DataSource = null;
                BusinessLogic.Narudzbenica.pNarudzbeProizvod.Clear();
                BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();
                CalculateBrojNarudzbe(objekt);
            }
        }

        private void btnBrisiOznacene_Click(object sender, EventArgs e)
        {
            for (int i = ugdNarudzbenicaProizvod.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdNarudzbenicaProizvod.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    ugdNarudzbenicaProizvod.Rows[i].Delete();
                }
            }
        }

        private void btnNoviProizvod_Click(object sender, EventArgs e)
        {
            using (NarudzbenicaProizvodForm objekt = new NarudzbenicaProizvodForm())
            {
                BusinessLogic.Narudzbenica.pOdabraniProizvodi.Clear();
                foreach (UltraGridRow red in ugdNarudzbenicaProizvod.Rows)
                {
                    BusinessLogic.Narudzbenica.pOdabraniProizvodi.Add(red.Cells["ID Proizvod"].Value.ToString());
                }

                objekt.ShowDialogForm("Narudžbenice proizvod");
                ugdNarudzbenicaProizvod.DataSource = BusinessLogic.Narudzbenica.pNarudzbeProizvod.DefaultView;
                ugdNarudzbenicaProizvod.DataBind();
            }

            Utils.Tools.UltraGridStyling(ugdNarudzbenicaProizvod);

            if (ugdNarudzbenicaProizvod.DisplayLayout.Bands.Count > 0)
            {
                ugdNarudzbenicaProizvod.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdNarudzbenicaProizvod.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                ugdNarudzbenicaProizvod.DisplayLayout.Bands[0].Columns["ID_JedinicaMjere"].Hidden = true;
            }
        }

        private void uscNarudzbenica_Load(object sender, EventArgs e)
        {
            BusinessLogic.Narudzbenica.pNarudzbeProizvod = new DataTable();
            BusinessLogic.Narudzbenica.pNarudzbeProizvod.Columns.Add("SEL", typeof(bool));
            BusinessLogic.Narudzbenica.pNarudzbeProizvod.Columns.Add("ID Proizvod", typeof(int));
            BusinessLogic.Narudzbenica.pNarudzbeProizvod.Columns.Add("Naziv proizvoda", typeof(string));
            BusinessLogic.Narudzbenica.pNarudzbeProizvod.Columns.Add("Jedinica mjere", typeof(string));
            BusinessLogic.Narudzbenica.pNarudzbeProizvod.Columns.Add("Količina", typeof(decimal));
            BusinessLogic.Narudzbenica.pNarudzbeProizvod.Columns.Add("ID_JedinicaMjere", typeof(int));
            BusinessLogic.Narudzbenica.pOdabraniProizvodi = new List<string>();

            BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();
            LoadPartner(objekt);
            LoadNacinIsporuke(objekt);
            LoadNacinPlacanja(objekt);

            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadNarudzbeniceByID(objekt);
            }
            if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
            {
                CalculateBrojNarudzbe(objekt);            
            }
        }

        private void ugdNarudzbenicaProizvod_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void bnDodajNacinIsporuke_Click(object sender, EventArgs e)
        {
            using (MaticniPodaci.uscNacinIsporukeForm objekt = new MaticniPodaci.uscNacinIsporukeForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Način isporuke") == DialogResult.OK)
                {
                    BusinessLogic.Narudzbenica objekt2 = new BusinessLogic.Narudzbenica();
                    LoadNacinIsporuke(objekt2);
                }
            }
        }

        #endregion

    }
}
