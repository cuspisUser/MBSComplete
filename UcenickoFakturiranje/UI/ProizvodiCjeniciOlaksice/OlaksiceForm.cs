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
using Infragistics.Win.UltraWinEditors;

namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    public partial class OlaksiceForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        public OlaksiceForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxNaziv.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region Event Handlers

        private void OlaksiceForm_Load(object sender, EventArgs e)
        {

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormOlaksice();
            }
            else 
            {
                ultraNumericPostotakOlaksice.Value = ultraNumericIznosOlaksice.Value = null;
            }
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                TextBoxNaziv.Text = string.Empty;
                ultraNumericIznosOlaksice.Value = null;
                ultraNumericPostotakOlaksice.Value = null;
            }
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }
             
        #endregion

        private void LoadFormOlaksice()
        {
            /*
             * Jure Males 09.07.2013 
             * tijelo funkcije
             */
            BusinessLogic.Olaksice olaksica = new BusinessLogic.Olaksice();
            var item = olaksica.GetOlaksica(this.ID.GetValueOrDefault(0));

            TextBoxNaziv.Text = item.Naziv;
            ultraNumericPostotakOlaksice.Value = item.OlaksicaPostotak;
            ultraNumericIznosOlaksice.Value = item.OlaksicaIznos;
            
            
            
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.Olaksice olak = new BusinessLogic.Olaksice();

            decimal? iznos = null, postotak = null;
            if (ultraNumericIznosOlaksice.Value != null)
            {
                iznos = Decimal.Parse(ultraNumericIznosOlaksice.Value.ToString());
            }
            if (ultraNumericPostotakOlaksice.Value != null)
            {
                postotak = Decimal.Parse(ultraNumericPostotakOlaksice.Value.ToString());
            }


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                
                olak.Add(TextBoxNaziv.Text, postotak, iznos);
                
                    
                    
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                olak.Update(this.ID.Value,
                    this.TextBoxNaziv.Text.Trim(),
                    postotak,
                    iznos);
            }

            if (olak.IsValid)
            {
                return olak.Persist();
            }
            else
            {
                olak.DisplayValidationMessages(this);
            }

            return false;
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            /*
             * ultraNumericPostotakOlaksice valueChanged
             * ultraNumericIznosOlaksice valueChanged
             * **/
            UltraNumericEditor num = (UltraNumericEditor)sender;
            if (num.Value != null)
            {
                if (num.Value.ToString().Length == 0)
                {
                    num.Value = null;
                }
            }
            KontrolaUnosaIznosPostotak();
            
            
        }

        private void KontrolaUnosaIznosPostotak()
        {
            if (ultraNumericIznosOlaksice.Value == null && ultraNumericPostotakOlaksice.Value == null)
            {
                ultraNumericPostotakOlaksice.Enabled = ultraNumericIznosOlaksice.Enabled = true;
            }
            else if (ultraNumericPostotakOlaksice.Value == null)
            {
                ultraNumericIznosOlaksice.Enabled = true;
                ultraNumericPostotakOlaksice.Enabled = false;
            }
            else if (ultraNumericIznosOlaksice.Value == null) 
            {
                ultraNumericIznosOlaksice.Enabled = false;
                ultraNumericPostotakOlaksice.Enabled = true;
            }
        }

        private void btnOlaksiceZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }
    }
}
