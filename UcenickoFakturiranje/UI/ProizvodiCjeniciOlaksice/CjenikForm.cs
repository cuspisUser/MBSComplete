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

namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    public partial class CjenikForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }
        private bool pStavke
        {
            get;
            set;
        }

        public CjenikForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxNaziv.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region Event Handlers

        private void CjenikForm_Load(object sender, EventArgs e)
        {
            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormCjenik();
                if (this.FormEditMode != Enums.FormEditMode.Copy)
                {
                    LoadFormCjenikStavke();    
                }
                
            }
            else 
            {
                DateTimePickerDatumDo.Value = null;
            }
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (UltraGridStavke.Rows.Count > 0)
                pStavke = true;
            else
                pStavke = false;

            if (SaveData())
            {
                TextBoxNaziv.Text = string.Empty;
                DateTimePickerDatumOd.Value = DateTime.Now;
                DateTimePickerDatumDo.Value = null;

                ID = null;
                LoadFormCjenikStavke();

                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (UltraGridStavke.Rows.Count > 0)
                pStavke = true;
            else
                pStavke = false;

            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void ButtonPodProizvodDodaj_Click(object sender, EventArgs e)
        {
            pStavke = true;
            SaveData();

            IList<int> proizvodi_id = new List<int>();
            foreach (UltraGridRow red in UltraGridStavke.Rows)
            {
                proizvodi_id.Add((int)red.Cells["ProizvodID"].Value);
            }

            CjenikStavkeForm cjenikStavkeForm = new CjenikStavkeForm(Enums.FormEditMode.Insert, null, (int)ID, proizvodi_id);
            cjenikStavkeForm.ShowDialogForm("Proizvodi, cjenici i olakšice > Cjenik stavka");
            //Makao sam provjeru ako dialog bude ok, tako da uvjek refresha
             LoadFormCjenikStavke();
        }

        private void btnIzmjeniStavku_Click(object sender, EventArgs e)
        {
            if (this.UltraGridStavke.ActiveRow != null)
            {
                int? id = Convert.ToInt32(this.UltraGridStavke.ActiveRow.Cells["ID"].Value);

                IList<int> proizvodi_id = new List<int>();
                foreach (UltraGridRow red in UltraGridStavke.Rows)
                {
                    if ((int)red.Cells["ID"].Value != id)
                        proizvodi_id.Add((int)red.Cells["ProizvodID"].Value);
                }

                CjenikStavkeForm cjenikStavkeForm = new CjenikStavkeForm(Enums.FormEditMode.Update, id, (int)ID, proizvodi_id);
                cjenikStavkeForm.ShowDialogForm("Proizvodi, cjenici i olakšice > Cjenik stavka");
                LoadFormCjenikStavke();
            }
        }

        private void UltraGridStavke_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            btnIzmjeniStavku_Click(null, null);
        }

        private void btnBrisiStavku_Click(object sender, EventArgs e)
        {
            if (this.UltraGridStavke.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridStavke.ActiveRow.Cells["ID"].Value);
                if (MessageBox.Show(string.Format("Obrisati stavku cjenika?"),
                    "Brisanje stavke cjenika", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.CjeniciStavke stavke = new BusinessLogic.CjeniciStavke();
                    stavke.Delete(id);

                    if (stavke.IsValid)
                    {
                        if (stavke.Perist())
                            LoadFormCjenikStavke();
                        else
                            MessageBox.Show("Odbijeno brisanje stavke cjenika jer se koristi u jednom od obračuna!");
                    }
                    else
                    {
                        stavke.DisplayValidationMessages();
                    }
                }
            }
        }
        #endregion
        
        private void LoadFormCjenik()
        {
            /*
             * Jure Males 12.07.2013 
             * tijelo funkcije
             */
            BusinessLogic.Cjenici cjenici = new BusinessLogic.Cjenici();
            var cjenik = cjenici.GetCjenik(this.ID.GetValueOrDefault(0));

            TextBoxNaziv.Text = cjenik.Naziv;
            DateTimePickerDatumOd.Value = cjenik.VrijediOd;
            DateTimePickerDatumDo.Value = (cjenik.VrijediDo ?? null);

        }

        private void LoadFormCjenikStavke()
        {
            BusinessLogic.CjeniciStavke stavke = new BusinessLogic.CjeniciStavke();

            vUFCJENIKSTAVKEBindingSource.DataSource = stavke.GetCjeniciStavkeMainGrid(this.ID.GetValueOrDefault(0));
            
            Utils.Tools.UltraGridStyling(this.UltraGridStavke);
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.Cjenici cjenici = new BusinessLogic.Cjenici();

            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                cjenici.Add(TextBoxNaziv.Text,
                            (DateTime)DateTimePickerDatumOd.Value,
                            (DateTimePickerDatumDo.Value == null ? null : (DateTime?)DateTimePickerDatumDo.Value), pStavke);
                    
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                cjenici.Update((int)ID,TextBoxNaziv.Text,
                            (DateTime)DateTimePickerDatumOd.Value,
                            (DateTimePickerDatumDo.Value == null ? null : (DateTime?)DateTimePickerDatumDo.Value), pStavke);
            }

            if (cjenici.IsValid)
            {
                bool persist = cjenici.Persist();
                if (this.FormEditMode == Enums.FormEditMode.Insert || this.FormEditMode == Enums.FormEditMode.Copy)
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    BusinessLogic.Cjenici cjenik = new BusinessLogic.Cjenici();
                    ID = cjenik.GetMaxId();    
                }
                return persist;
            }
            else
            {
                cjenici.DisplayValidationMessages(this);
            }
            return false;
        }

        private void btnCjenikOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }
       
    }
}
