using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class uscShemaKontiranje : Controls.BaseUserControl
    {
        #region Svojstva

        public static string pID_konto
        {
            get;
            set;
        }

        public static int pID_strane_knjizenja
        {
            get;
            set;
        }

        public static int pID_ira_vrsta_iznosa
        {
            get;
            set;
        }

        public int pID_mjesto_troska
        {
            get;
            set;
        }

        public int pID_org_jed
        {
            get;
            set;
        }

        public string pKonto
        {
            get;
            set;
        }

        public string pStrana_knjizenja
        {
            get;
            set;
        }

        public string pVrsta_iznosa
        {
            get;
            set;
        }

        public string pSifra_mt
        {
            get;
            set;
        }

        public string pSifra_oj
        {
            get;
            set;
        }

        private FormEditMode FormEditMode
        {
            get;
            set;
        }

        #endregion


        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscShemaKontiranje(FormEditMode formEditMode)
        {
            InitializeComponent();
            LoadShemeKontiranja();

            FormEditMode = formEditMode;
        }

        private void LoadShemeKontiranja()
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            uceKonto.DataSource = Obracuni.GetKonto().DefaultView;
            uceKonto.DataBind();

            uceStranaKnjizenja.DataSource = Obracuni.GetStranaKnjizenja().DefaultView;
            uceStranaKnjizenja.DataBind();

            uceVrstaIznosa.DataSource = Obracuni.GetVrstaIznosa().DefaultView;
            uceVrstaIznosa.DataBind();

            uceSifraMT.DataSource = Obracuni.GetSifraMT().DefaultView;
            uceSifraMT.DataBind();

            uceSifraOJ.DataSource = Obracuni.GetSifraOJ().DefaultView;
            uceSifraOJ.DataBind();
        }

        private bool SaveData()
        {
            if (FormEditMode == Enums.FormEditMode.Insert)
            {
                StringBuilder message = ValidateDataInput();
                if (message.Length == 0)
                {
                    bool provjera = false;
                    foreach (DataRow red_shema in uscShema.pShemaKontiranja.Rows)
                    {
                        if (red_shema["ID_KONTO"].ToString().Trim() == uceKonto.Value.ToString().Trim() && 
                            red_shema["ID_STRANE_KNJIZENJA"].ToString().Trim() == uceStranaKnjizenja.Value.ToString().Trim())
                        {
                            provjera = true;
                        }
                    }
                    if (!provjera)
                    {
                        object[] red = new object[10];
                        red[0] = uceKonto.Value.ToString().Trim();
                        red[1] = uceStranaKnjizenja.Value.ToString().Trim();
                        red[2] = uceVrstaIznosa.Value.ToString().Trim();
                        red[3] = uceSifraMT.Value.ToString().Trim();
                        red[4] = uceSifraOJ.Value.ToString().Trim();
                        red[5] = uceKonto.Text.Trim();
                        red[6] = uceStranaKnjizenja.Text.Trim();
                        red[7] = uceVrstaIznosa.Text.Trim();
                        red[8] = uceSifraMT.Text.Trim();
                        red[9] = uceSifraOJ.Text.Trim();
                        uscShema.pShemaKontiranja.Rows.Add(red);
                    }
                    else
                    {
                        MessageBox.Show("Nije moguće dodati dva zapisa sa istim kontom i stranom knjiženja");
                    }
                }
                else
                {
                    lblValidationMessages.Text = message.ToString();
                    return false;
                }
            }
            else 
            {
                foreach (DataRow red in uscShema.pShemaKontiranja.Rows)
                {
                    if (red["ID_KONTO"].ToString().Trim() == pID_konto && red["ID_STRANE_KNJIZENJA"].ToString().Trim() == pID_strane_knjizenja.ToString())
                    {
                        red.BeginEdit();
                        red["ID_IRA_VRSTA_IZNOSA"] = uceVrstaIznosa.Value;
                        red["VrstaIznosa"] = uceVrstaIznosa.Text;
                        red["ID_MJESTO_TROSKA"] = uceSifraMT.Value;
                        red["SifraMT"] = uceSifraMT.Text;
                        red["ID_ORG_JED"] = uceSifraOJ.Value;
                        red["SifraOJ"] = uceSifraOJ.Text;

                        red.EndEdit();
                    }
                }
                uscShema.pShemaKontiranja.AcceptChanges();
            }
            return true;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();
            if (uceKonto.Value == null)
            {
                message.Append(" - Konto je obavezan");
            }
            if (uceStranaKnjizenja.Value == null)
            {
                message.Append(" - Strana knjiženja je obavezna");
            }
            if (uceVrstaIznosa.Value == null)
            {
                message.Append(" - Vrsta iznosa je obavezna");
            }
            if (uceSifraMT.Value == null)
            {
                message.Append(" - Mjesto troška je obavezno");
            }
            if (uceSifraOJ.Value == null)
            {
                message.Append(" - Organizaciska jedinica je obavezna");
            }

            return message;
        }

        private void btnCjenikOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
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

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                uceKonto.SelectedIndex = -1;
                uceSifraMT.SelectedIndex = -1;
                uceSifraOJ.SelectedIndex = -1;
                uceStranaKnjizenja.SelectedIndex = -1;
                uceVrstaIznosa.SelectedIndex = -1;
            }
        }

        private void NapuniFormuShemaKontiranje()
        {
            uceKonto.Text = pKonto;
            uceVrstaIznosa.Value = pID_ira_vrsta_iznosa;
            uceStranaKnjizenja.Value = pID_strane_knjizenja;
            uceSifraMT.Value = pID_mjesto_troska;
            uceSifraOJ.Value = pID_org_jed;
        }

        private void uscShemaKontiranje_Load(object sender, EventArgs e)
        {
            if (FormEditMode == FormEditMode.Update)
            {
                NapuniFormuShemaKontiranje();
                uceStranaKnjizenja.Enabled = false;
                uceKonto.Enabled = false;
                ToolStripButtonSpremi.Enabled = false;
            }
            else
            {
                uceStranaKnjizenja.Enabled = true;
                uceKonto.Enabled = true;
                ToolStripButtonSpremi.Enabled = true;
            }
        }

        public void ObrisiShemaKontiranje()
        {
            foreach (DataRow red in uscShema.pShemaKontiranja.Rows)
            {
                if (red["ID_KONTO"].ToString().Trim() == pID_konto && red["ID_STRANE_KNJIZENJA"].ToString().Trim() == pID_strane_knjizenja.ToString())
                {
                    red.BeginEdit();
                    red.Delete();
                    red.EndEdit();
                    uscShema.pShemaKontiranja.AcceptChanges();
                    return;
                }
            }
        }
    }
}
