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
    public partial class OtvaranjeSkladistaForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public OtvaranjeSkladistaForm(FormEditMode formEditMode)
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
                using (BusinessLogic.OtvaranjeSkladista objekt = new BusinessLogic.OtvaranjeSkladista())
                {
                    objekt.pSifra = uteSifraSkladista.Value == null ? objekt.pSifra = null : objekt.pSifra = uteSifraSkladista.Value.ToString();
                    objekt.pNaziv = uteNazivSkladista.Value.ToString();
                    objekt.pMjestoTroska = objekt.IsDbNull<int>(uceMjestoTroskova.Value);
                    objekt.pOrganizacijskaJedinica = objekt.IsDbNull<int>(uceOrgJedinice.Value);
                    objekt.pTipSkladista = objekt.IsDbNull<int>(uceTipSkladista.Value);
                    objekt.pPorez = Convert.ToBoolean(cbkPorez.CheckState);

                    if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                    {
                        if (objekt.Insert(message, objekt))
                        {
                            FormEditMode = Enums.FormEditMode.Update;
                            return true;
                        }
                    }
                    else if (this.FormEditMode == Enums.FormEditMode.Update)
                    {
                        if (objekt.Update(message, objekt))
                        {
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

            if (uteSifraSkladista.Value != null)
            {
                if (uteSifraSkladista.Value.ToString().Length > 50)
                {
                    message.Append(" - Šifra može sadržavati maksimalno 50 znakova");
                }
            }
            if (uteNazivSkladista.Value == null)
            {
                message.Append(" - Naziv je obavezno polje");
            }
            else if (uteNazivSkladista.Value.ToString().Length > 250)
            {
                message.Append(" - Naziv može sadržavati maksimalno 250 znakova");
            }

            return message;
        }

        private void LoadForm(BusinessLogic.OtvaranjeSkladista objekt)
        {
            var obj = objekt.GetSelectedRow();

            if (obj != null)
            {
                uteSifraSkladista.Value = obj["Sifra"].ToString();
                uteNazivSkladista.Value = obj["Naziv"].ToString();
                uceMjestoTroskova.Value = obj["ID_MjestoTroska"].ToString();
                uceOrgJedinice.Value = obj["ID_OrganizacijskaJedinica"].ToString();
                uceTipSkladista.Value = obj["ID_TipSkladista"].ToString();
                cbkPorez.Checked = Convert.ToBoolean(obj["Porez"]);
            }
        }

        private void LoadOrganizacijskaJedinica(BusinessLogic.OtvaranjeSkladista objekt)
        {
            uceOrgJedinice.DataSource = objekt.GetOrganizacijskaJedinica();
            uceOrgJedinice.DataBind();
        }

        private void LoadMjestoTroska(BusinessLogic.OtvaranjeSkladista objekt)
        {
            uceMjestoTroskova.DataSource = objekt.GetMjestoTroska();
            uceMjestoTroskova.DataBind();
        }

        private void LoadTipSkladista(BusinessLogic.OtvaranjeSkladista objekt)
        {
            uceTipSkladista.DataSource = objekt.GetTipSkladista();
            uceTipSkladista.DataBind();
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

        private void tsbSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                uteSifraSkladista.Value = null;
                uteNazivSkladista.Value = null;
                uceMjestoTroskova.Value = null;
                uceOrgJedinice.Value = null;
                uceTipSkladista.Value = null;

                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using (BusinessLogic.OtvaranjeSkladista objekt = new BusinessLogic.OtvaranjeSkladista())
            {
                LoadTipSkladista(objekt);
                LoadMjestoTroska(objekt);
                LoadOrganizacijskaJedinica(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }
        #endregion

    }
}
