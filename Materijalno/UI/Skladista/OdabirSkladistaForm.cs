using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Materijalno.Enums;

namespace Materijalno.UI.Skladista
{
    public partial class OdabirSkladistaForm : Controls.BaseUserControl
    {
        #region Properties

        private List<int> pPrimka { get; set; }
        
        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public OdabirSkladistaForm(List<int> primka)
        {
            InitializeComponent();
            pPrimka = primka;
        }

        private bool SaveData()
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                lblValidationMessages.ResetText();

                StringBuilder message = ValidateDataInput();

                //if (message.Length == 0)
                //{
                //    if (objekt.InsertStavkeSkladiste(pPrimka, message))
                //    {
                //        MessageBox.Show("Prijenos na skladište uspiješno napravljen!");
                //        return true;
                //    }
                //}

                lblValidationMessages.Text = message.ToString();
                return false;
            }
        }

        private void FillSkladista()
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                uceSkladiste.DataSource = objekt.GetSkladiste();
                uceSkladiste.DataBind();
            }
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (uceSkladiste.Value == null)
            {
                message.Append("- Odaberite skladište da bi napravili prijenos.");
            }
            if (pPrimka.Count == 0)
            {
                message.Append("- Nije odabrana primka, ili je odabrana primka koja je već prenesena!!!");
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
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void PrimkaForm_Load(object sender, EventArgs e)
        {
            FillSkladista();
        }

        #endregion

    }
}
