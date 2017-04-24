using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UcenickoFakturiranje.Enums;
using Infragistics.Win.UltraWinGrid;

namespace UcenickoFakturiranje.UI.MBS.DefiniranjePotrazivanje
{
    public partial class uscPotrazivanja : Controls.BaseUserControl
    {
        private FormEditMode FormEditMode
        {
            get;
            set;
        }

        public uscPotrazivanja(FormEditMode formEditMode)
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

            using (BusinessLogic.Potrazivanja objekt = new BusinessLogic.Potrazivanja())
            {
                objekt.ZaLijekove = lbxZaLijekove.Items;
                objekt.ZaSanitetski = lbxSanitetski.Items;
                objekt.Zivezne = lbxZivezne.Items;
                objekt.ZaEnergiju = lbxZaEnergiju.Items;
                objekt.ZaOstale = lbxZaOstale.Items;
                objekt.ZaProizvodne = lbxZaProizvodne.Items;

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

        private void LoadForm(BusinessLogic.Potrazivanja objekt)
        {
            var items = objekt.GetZaLijekove(1);

            foreach (var item in items)
            {
                lbxZaLijekove.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(2);

            foreach (var item in items)
            {
                lbxSanitetski.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(3);

            foreach (var item in items)
            {
                lbxZivezne.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(4);

            foreach (var item in items)
            {
                lbxZaEnergiju.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(5);

            foreach (var item in items)
            {
                lbxZaOstale.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(6);

            foreach (var item in items)
            {
                lbxZaProizvodne.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(7);

         
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
            using (BusinessLogic.Potrazivanja objekt = new BusinessLogic.Potrazivanja())
            {
                LoadKontoZaLijekove(objekt);
                LoadKontoZaSanitetski(objekt);
                LoadKontoZivezne(objekt);
                LoadKontoZaEnergiju(objekt);
                LoadKontoZaOstale(objekt);
                LoadKontoZaProizvodne(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }

        private void LoadKontoZaLijekove(BusinessLogic.Potrazivanja objekt)
        {
            uceKontoZaLijekove.DataSource = objekt.GetKonto();
            uceKontoZaLijekove.DataBind();
        }
        private void LoadKontoZaSanitetski(BusinessLogic.Potrazivanja objekt)
        {
            uceKontoSanitetski.DataSource = objekt.GetKonto();
            uceKontoSanitetski.DataBind();
        }
        private void LoadKontoZivezne(BusinessLogic.Potrazivanja objekt)
        {
            uceKontoZivezne.DataSource = objekt.GetKonto();
            uceKontoZivezne.DataBind();
        }
        private void LoadKontoZaEnergiju(BusinessLogic.Potrazivanja objekt)
        {
            uceKontoZaEnergiju.DataSource = objekt.GetKonto();
            uceKontoZaEnergiju.DataBind();
        }
        private void LoadKontoZaOstale(BusinessLogic.Potrazivanja objekt)
        {
            uceKontoZaOstale.DataSource = objekt.GetKonto();
            uceKontoZaOstale.DataBind();
        }
        private void LoadKontoZaProizvodne(BusinessLogic.Potrazivanja objekt)
        {
            uceKontoZaProizvodne.DataSource = objekt.GetKonto();
            uceKontoZaProizvodne.DataBind();
        }
       
        private void btnAddZaLijekove_Click(object sender, EventArgs e)
        {
            if (uceKontoZaLijekove.Value != null)
            {
                foreach (var item in lbxZaLijekove.Items)
                {
                    if (item.ToString() == uceKontoZaLijekove.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZaLijekove.Items.Add(string.Format(uceKontoZaLijekove.Text));
            }
        }
        private void btnRemoveZaLijekove_Click(object sender, EventArgs e)
        {
            if (lbxZaLijekove.SelectedIndex > -1)
            {
                lbxZaLijekove.Items.Remove(lbxZaLijekove.SelectedItem);
            }
        }
        private void btnAddSanitetski_Click(object sender, EventArgs e)
        {
            if (uceKontoSanitetski.Value != null)
            {
                foreach (var item in lbxSanitetski.Items)
                {
                    if (item.ToString() == uceKontoSanitetski.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxSanitetski.Items.Add(string.Format(uceKontoSanitetski.Text));
            }
        }
        private void btnRemoveSanitetski_Click(object sender, EventArgs e)
        {
            if (lbxSanitetski.SelectedIndex > -1)
            {
                lbxSanitetski.Items.Remove(lbxSanitetski.SelectedItem);
            }
        }
        private void btnAddZivezne_Click(object sender, EventArgs e)
        {
            if (uceKontoZivezne.Value != null)
            {
                foreach (var item in lbxZivezne.Items)
                {
                    if (item.ToString() == uceKontoZivezne.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZivezne.Items.Add(string.Format(uceKontoZivezne.Text));
            }
        }
        private void btnRemoveZivezne_Click(object sender, EventArgs e)
        {
            if (lbxZivezne.SelectedIndex > -1)
            {
                lbxZivezne.Items.Remove(lbxZivezne.SelectedItem);
            }
        }
        private void btnAddZaEnergiju_Click(object sender, EventArgs e)
        {
            if (uceKontoZaEnergiju.Value != null)
            {
                foreach (var item in lbxZaEnergiju.Items)
                {
                    if (item.ToString() == uceKontoZaEnergiju.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZaEnergiju.Items.Add(string.Format(uceKontoZaEnergiju.Text));
            }
        }
        private void btnRemoveZaEnergiju_Click(object sender, EventArgs e)
        {
            if (lbxZaEnergiju.SelectedIndex > -1)
            {
                lbxZaEnergiju.Items.Remove(lbxZaEnergiju.SelectedItem);
            }
        }
        private void btnAddZaOstale_Click(object sender, EventArgs e)
        {
            if (uceKontoZaOstale.Value != null)
            {
                foreach (var item in lbxZaOstale.Items)
                {
                    if (item.ToString() == uceKontoZaOstale.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZaOstale.Items.Add(string.Format(uceKontoZaOstale.Text));
            }
        }
        private void btnRemoveZaOstale_Click(object sender, EventArgs e)
        {
            if (lbxZaOstale.SelectedIndex > -1)
            {
                lbxZaOstale.Items.Remove(lbxZaOstale.SelectedItem);
            }
        }
        private void btnAddZaProizvodne_Click(object sender, EventArgs e)
        {
            if (uceKontoZaProizvodne.Value != null)
            {
                foreach (var item in lbxZaProizvodne.Items)
                {
                    if (item.ToString() == uceKontoZaProizvodne.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZaProizvodne.Items.Add(string.Format(uceKontoZaProizvodne.Text));
            }
        }
        private void btnRemoveZaProizvodne_Click(object sender, EventArgs e)
        {
            if (lbxZaProizvodne.SelectedIndex > -1)
            {
                lbxZaProizvodne.Items.Remove(lbxZaProizvodne.SelectedItem);
            }
        }
    
    }
}
