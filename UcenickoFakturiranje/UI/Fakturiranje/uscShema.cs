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

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class uscShema : Controls.BaseUserControl
    {
        #region Svojstva

        private int ID
        {
            get;
            set;
        }
        private FormEditMode FormEditMode
        {
            get;
            set;
        }

        public static DataTable pShemaKontiranja
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscShema(FormEditMode formEditMode, int id)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
            ID = id;

            pShemaKontiranja = new DataTable("UF_ShemaKontiranje");
            pShemaKontiranja.Columns.Add("ID_KONTO", typeof(string));
            pShemaKontiranja.Columns.Add("ID_STRANE_KNJIZENJA", typeof(int));
            pShemaKontiranja.Columns.Add("ID_IRA_VRSTA_IZNOSA", typeof(int));
            pShemaKontiranja.Columns.Add("ID_MJESTO_TROSKA", typeof(int));
            pShemaKontiranja.Columns.Add("ID_ORG_JED", typeof(int));
            pShemaKontiranja.Columns.Add("Konto", typeof(string));
            pShemaKontiranja.Columns.Add("StranaKnjizenja", typeof(string));
            pShemaKontiranja.Columns.Add("VrstaIznosa", typeof(string));
            pShemaKontiranja.Columns.Add("SifraMT", typeof(string));
            pShemaKontiranja.Columns.Add("SifraOJ", typeof(string));
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        private void LoadDokumenti()
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            ucbDokumentiShema.DataSource = Obracuni.GetDokumenti();
            ucbDokumentiShema.DataBind();
        }

        private void LoadShema()
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();
            ugdShema.DataSource = pShemaKontiranja;
            ugdShema.DataBind();
            ugdShema.UpdateData();

            Utils.Tools.UltraGridStyling(ugdShema);

            if (ugdShema.DisplayLayout.Bands.Count > 0)
                if (ugdShema.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdShema.DisplayLayout.Bands[0].Columns[0].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[1].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[2].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[3].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[4].Hidden = true;
                }
        }

        #endregion

        private void btnOdjeljenjaZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void llbDodajShemu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (uscShemaKontiranje ShemaKontiranja = new uscShemaKontiranje(Enums.FormEditMode.Insert))
            {
                ShemaKontiranja.ShowDialogForm("Shema kontiranja");
                LoadShema();
            }
        }

        private void llbIzmjeniShemu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ugdShema.ActiveRow != null)
            {
                uscShemaKontiranje.pID_konto = ugdShema.ActiveRow.Cells["ID_KONTO"].Value.ToString().Trim();
                uscShemaKontiranje.pID_ira_vrsta_iznosa = Convert.ToInt32(ugdShema.ActiveRow.Cells["ID_IRA_VRSTA_IZNOSA"].Value);
                uscShemaKontiranje.pID_strane_knjizenja = Convert.ToInt32(ugdShema.ActiveRow.Cells["ID_STRANE_KNJIZENJA"].Value);

                using (uscShemaKontiranje ShemaKontiranja = new uscShemaKontiranje(Enums.FormEditMode.Update))
                {
                    ShemaKontiranja.pID_mjesto_troska = Convert.ToInt32(ugdShema.ActiveRow.Cells["ID_MJESTO_TROSKA"].Value);
                    ShemaKontiranja.pID_org_jed = Convert.ToInt32(ugdShema.ActiveRow.Cells["ID_ORG_JED"].Value);
                    ShemaKontiranja.pKonto = ugdShema.ActiveRow.Cells["Konto"].Value.ToString().Trim();
                    ShemaKontiranja.pStrana_knjizenja = ugdShema.ActiveRow.Cells["StranaKnjizenja"].Value.ToString().Trim();
                    ShemaKontiranja.pVrsta_iznosa = ugdShema.ActiveRow.Cells["VrstaIznosa"].Value.ToString().Trim();
                    ShemaKontiranja.pSifra_mt = ugdShema.ActiveRow.Cells["SifraMT"].Value.ToString().Trim();
                    ShemaKontiranja.pSifra_oj = ugdShema.ActiveRow.Cells["SifraOJ"].Value.ToString().Trim();

                    ShemaKontiranja.ShowDialogForm("Shema kontiranja");
                    LoadShema();
                }
            }
        }

        private void lblObrisiShemu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ugdShema.ActiveRow != null)
            {
                uscShemaKontiranje.pID_konto = ugdShema.ActiveRow.Cells["ID_KONTO"].Value.ToString().Trim();
                uscShemaKontiranje.pID_ira_vrsta_iznosa = Convert.ToInt32(ugdShema.ActiveRow.Cells["ID_IRA_VRSTA_IZNOSA"].Value);
                uscShemaKontiranje.pID_strane_knjizenja = Convert.ToInt32(ugdShema.ActiveRow.Cells["ID_STRANE_KNJIZENJA"].Value);

                using (uscShemaKontiranje ShemaKontiranja = new uscShemaKontiranje(Enums.FormEditMode.Update))
                {
                    ShemaKontiranja.ObrisiShemaKontiranje();
                    LoadShema();
                }
            }
        }

        private void uscShema_Load(object sender, EventArgs e)
        {
            LoadDokumenti();
            if (FormEditMode == Enums.FormEditMode.Update)
            {
                NapuniFormuZaEditiranje();
            }
        }

        private void NapuniFormuZaEditiranje()
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();
            DataRow shema = Obracuni.GetShemaById(ID);
            txtNaziv.Text = shema["Naziv"].ToString();
            ucbDokumentiShema.Value = shema["IDDOKUMENT"].ToString();

            pShemaKontiranja = Obracuni.GetShemaKontiranjeByID(ID);

            ugdShema.DataSource = pShemaKontiranja;
            ugdShema.DataBind();
            ugdShema.UpdateData();

            Utils.Tools.UltraGridStyling(ugdShema);

            if (ugdShema.DisplayLayout.Bands.Count > 0)
                if (ugdShema.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdShema.DisplayLayout.Bands[0].Columns[0].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[1].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[2].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[3].Hidden = true;
                    ugdShema.DisplayLayout.Bands[0].Columns[4].Hidden = true;
                }

        }

        private void ugdShema_DoubleClick(object sender, EventArgs e)
        {
            llbIzmjeniShemu_LinkClicked(null, null);
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                Obracuni.pShema_id_dokumenta = (int)ucbDokumentiShema.Value;
                Obracuni.pShema_naziv = txtNaziv.Text.Trim();

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (!Obracuni.InsertShema())
                        return false;
                }
                else if (FormEditMode == Enums.FormEditMode.Update)
                {
                    if (!Obracuni.EditShema())
                        return false;
                }
                bool persist = Obracuni.Persist();
                if (persist)
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    return true;
                }
                return false;
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return false;
            }
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();
            if (txtNaziv.Value == null)
            {
                message.Append(" - Naziv je obavezan");
            }
            if (ucbDokumentiShema.Value == null)
            {
                message.Append(" - Dokument je obavezna");
            }
            if (ugdShema.Rows.Count < 1)
            {
                message.Append(" - Potrebno je dodjeliti shemu kontiranja");
            }
            return message;
        }
    }
}
