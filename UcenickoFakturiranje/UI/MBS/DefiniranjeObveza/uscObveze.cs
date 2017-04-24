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

namespace UcenickoFakturiranje.UI.MBS.DefiniranjeObveza
{
    public partial class uscObveze : Controls.BaseUserControl
    {
        private FormEditMode FormEditMode
        {
            get;
            set;
        }

        public uscObveze(FormEditMode formEditMode)
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

            using (BusinessLogic.Obveze objekt = new BusinessLogic.Obveze())
            {
                objekt.ZaLijekove = lbxZaLijekove.Items;
                objekt.ZaSanitetski = lbxSanitetski.Items;
                objekt.Zivezne = lbxZivezne.Items;
                objekt.ZaEnergiju = lbxZaEnergiju.Items;
                objekt.ZaOstale = lbxZaOstale.Items;
                objekt.ZaProizvodne = lbxZaProizvodne.Items;
                objekt.ZaOpremu = lbxZaOpremu.Items;
                objekt.pObveze = lbxObveze.Items;
                objekt.ObvezeDruge = lbxObvezeDruge.Items;
                objekt.Komitentne = lbxKomitentne.Items;
                objekt.Nespomenute = lbxNespomenute.Items;
                objekt.HZZO = lbxHZZO.Items;

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

        private void LoadForm(BusinessLogic.Obveze objekt)
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

            foreach (var item in items)
            {
                lbxZaOpremu.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(8);

            foreach (var item in items)
            {
                lbxObveze.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(9);

            foreach (var item in items)
            {
                lbxObvezeDruge.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(10);

            foreach (var item in items)
            {
                lbxKomitentne.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(11);

            foreach (var item in items)
            {
                lbxNespomenute.Items.Add(item.konto);
            }

            items = objekt.GetZaLijekove(12);

            foreach (var item in items)
            {
                lbxHZZO.Items.Add(item.konto);
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
            using (BusinessLogic.Obveze objekt = new BusinessLogic.Obveze())
            {
                LoadKontoZaLijekove(objekt);
                LoadKontoZaSanitetski(objekt);
                LoadKontoZivezne(objekt);
                LoadKontoZaEnergiju(objekt);
                LoadKontoZaOstale(objekt);
                LoadKontoZaProizvodne(objekt);
                LoadKontoZaOpremu(objekt);
                LoadKontoObveze(objekt);
                LoadKontoObvezeDruge(objekt);
                LoadKontoKomitentne(objekt);
                LoadKontoNespomenute(objekt);
                LoadKontoHZZO(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }

        private void LoadKontoZaLijekove(BusinessLogic.Obveze objekt)
        {
            uceKontoZaLijekove.DataSource = objekt.GetKonto();
            uceKontoZaLijekove.DataBind();
        }
        private void LoadKontoZaSanitetski(BusinessLogic.Obveze objekt)
        {
            uceKontoSanitetski.DataSource = objekt.GetKonto();
            uceKontoSanitetski.DataBind();
        }
        private void LoadKontoZivezne(BusinessLogic.Obveze objekt)
        {
            uceKontoZivezne.DataSource = objekt.GetKonto();
            uceKontoZivezne.DataBind();
        }
        private void LoadKontoZaEnergiju(BusinessLogic.Obveze objekt)
        {
            uceKontoZaEnergiju.DataSource = objekt.GetKonto();
            uceKontoZaEnergiju.DataBind();
        }
        private void LoadKontoZaOstale(BusinessLogic.Obveze objekt)
        {
            uceKontoZaOstale.DataSource = objekt.GetKonto();
            uceKontoZaOstale.DataBind();
        }
        private void LoadKontoZaProizvodne(BusinessLogic.Obveze objekt)
        {
            uceKontoZaProizvodne.DataSource = objekt.GetKonto();
            uceKontoZaProizvodne.DataBind();
        }
        private void LoadKontoZaOpremu(BusinessLogic.Obveze objekt)
        {
            uceKontoZaOpremu.DataSource = objekt.GetKonto();
            uceKontoZaOpremu.DataBind();
        }
        private void LoadKontoObveze(BusinessLogic.Obveze objekt)
        {
            uceKontoObveze.DataSource = objekt.GetKonto();
            uceKontoObveze.DataBind();
        }
        private void LoadKontoObvezeDruge(BusinessLogic.Obveze objekt)
        {
            uceKontoObvezeDruge.DataSource = objekt.GetKonto();
            uceKontoObvezeDruge.DataBind();
        }
        private void LoadKontoKomitentne(BusinessLogic.Obveze objekt)
        {
            uceKontoKomitentne.DataSource = objekt.GetKonto();
            uceKontoKomitentne.DataBind();
        }
        private void LoadKontoNespomenute(BusinessLogic.Obveze objekt)
        {
            uceKontoNespomenute.DataSource = objekt.GetKonto();
            uceKontoNespomenute.DataBind();
        }
        private void LoadKontoHZZO(BusinessLogic.Obveze objekt)
        {
            uceKontoHZZO.DataSource = objekt.GetKonto();
            uceKontoHZZO.DataBind();
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
        private void btnAddZaOpremu_Click(object sender, EventArgs e)
        {
            if (uceKontoZaOpremu.Value != null)
            {
                foreach (var item in lbxZaOpremu.Items)
                {
                    if (item.ToString() == uceKontoZaOpremu.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxZaOpremu.Items.Add(string.Format(uceKontoZaOpremu.Text));
            }
        }
        private void btnRemoveZaOpremu_Click(object sender, EventArgs e)
        {
            if (lbxZaOpremu.SelectedIndex > -1)
            {
                lbxZaOpremu.Items.Remove(lbxZaOpremu.SelectedItem);
            }
        }
        private void uceAddObveze_Click(object sender, EventArgs e)
        {
            if (uceKontoObveze.Value != null)
            {
                foreach (var item in lbxObveze.Items)
                {
                    if (item.ToString() == uceKontoObveze.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxObveze.Items.Add(string.Format(uceKontoObveze.Text));
            }
        }
        private void uceRemoveObveze_Click(object sender, EventArgs e)
        {
            if (lbxObveze.SelectedIndex > -1)
            {
                lbxObveze.Items.Remove(lbxObveze.SelectedItem);
            }
        }
        private void btnAddObvezeDruge_Click(object sender, EventArgs e)
        {
            if (uceKontoObvezeDruge.Value != null)
            {
                foreach (var item in lbxObvezeDruge.Items)
                {
                    if (item.ToString() == uceKontoObvezeDruge.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxObvezeDruge.Items.Add(string.Format(uceKontoObvezeDruge.Text));
            }
        }
        private void btnRemoveObvezeDruge_Click(object sender, EventArgs e)
        {
            if (lbxObvezeDruge.SelectedIndex > -1)
            {
                lbxObvezeDruge.Items.Remove(lbxObvezeDruge.SelectedItem);
            }
        }
        private void btnAddKomitentne_Click(object sender, EventArgs e)
        {
            if (uceKontoKomitentne.Value != null)
            {
                foreach (var item in lbxKomitentne.Items)
                {
                    if (item.ToString() == uceKontoKomitentne.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxKomitentne.Items.Add(string.Format(uceKontoKomitentne.Text));
            }
        }
        private void btnRemoveKomitentne_Click(object sender, EventArgs e)
        {
            if (lbxKomitentne.SelectedIndex > -1)
            {
                lbxKomitentne.Items.Remove(lbxKomitentne.SelectedItem);
            }
        }
        private void bntAddNespomenute_Click(object sender, EventArgs e)
        {
            if (uceKontoNespomenute.Value != null)
            {
                foreach (var item in lbxNespomenute.Items)
                {
                    if (item.ToString() == uceKontoNespomenute.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxNespomenute.Items.Add(string.Format(uceKontoNespomenute.Text));
            }
        }
        private void btnRemoveNespomenute_Click(object sender, EventArgs e)
        {
            if (lbxNespomenute.SelectedIndex > -1)
            {
                lbxNespomenute.Items.Remove(lbxNespomenute.SelectedItem);
            }
        }
        private void btnAddHZZO_Click(object sender, EventArgs e)
        {
            if (uceKontoHZZO.Value != null)
            {
                foreach (var item in lbxHZZO.Items)
                {
                    if (item.ToString() == uceKontoHZZO.Text)
                    {
                        MessageBox.Show("Konto je već dodan u listu!");
                        return;
                    }
                }

                lbxHZZO.Items.Add(string.Format(uceKontoHZZO.Text));
            }
        }
        private void btnRemoveHZZO_Click(object sender, EventArgs e)
        {
            if (lbxHZZO.SelectedIndex > -1)
            {
                lbxHZZO.Items.Remove(lbxHZZO.SelectedItem);
            }
        }
    }
}
