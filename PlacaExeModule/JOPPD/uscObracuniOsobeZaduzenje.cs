using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using JOPPD.Enums;

namespace JOPPD
{
    public partial class uscObracuniOsobeZaduzenje : Controls.BaseUserControl
    {
        #region Svojstva

        private FormEditMode pFormEditMode
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscObracuniOsobeZaduzenje(FormEditMode vrsta_promjene)
        {
            InitializeComponent();
            pFormEditMode = vrsta_promjene;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.ObracunRazno objekt = new BusinessLogic.ObracunRazno();
            StringBuilder message = new StringBuilder();
            if (pFormEditMode == FormEditMode.Insert)
            {
                if (objekt.Insert(message))
                {
                    return true;
                }
            }
            else if (pFormEditMode == FormEditMode.Update)
            {
                if (objekt.Update(message))
                {
                    return true;
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private T IsDbNull<T>(object value)
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return default(T);
        }

        private void LoadGridOsobe()
        {
            BusinessLogic.ObracunRazno objekt = new BusinessLogic.ObracunRazno();

            ugdZaduzenje.DataSource = objekt.GetOsobeZaduzenje();
            ugdZaduzenje.DataBind();

            if (ugdZaduzenje.DisplayLayout.Bands.Count > 0)
            {
                if (ugdZaduzenje.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdZaduzenje.DisplayLayout.Bands["VrsteOsoba"].Columns["ID"].Hidden = true;
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].Columns["ID_VrstaVeze"].Hidden = true;
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].Columns["ID_Osobe"].Hidden = true;
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].Columns["ID_Opcina"].Hidden = true;
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].Columns["ID_NacinIsplate"].Hidden = true;
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].Columns["OIB"].Hidden = true;
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].Columns["Iznos"].Hidden = true;
                    ugdZaduzenje.Rows.ExpandAll(true);
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    ugdZaduzenje.DisplayLayout.Bands["VrsteOsoba"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    ugdZaduzenje.DisplayLayout.Bands["VrsteOsoba"].ColHeadersVisible = false;
                    ugdZaduzenje.DisplayLayout.Bands["OdabraneOsobe"].ColHeadersVisible = false;
                }
            }
        }

        private void LoadNacinIsplate()
        {
            BusinessLogic.ObracunRazno objekt = new BusinessLogic.ObracunRazno();

            ucbNacinIsplate.DataSource = objekt.GetNacinIsplate();
            ucbNacinIsplate.DataBind();
        }

        private string LoadNazivOpcine(string id)
        {
            BusinessLogic.ObracunRazno objekt = new BusinessLogic.ObracunRazno();

            return objekt.GetNazivOpcine(id);
        }

        private bool UpdateOsobeValues()
        {
            if (ugdZaduzenje.DisplayLayout.Bands.Count > 0)
            {
                if (ugdZaduzenje.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    if (ugdZaduzenje.ActiveRow.Band.ToString() == "OdabraneOsobe")
                    {
                        DataRow[] s = BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("ID_Osobe = " + ugdZaduzenje.ActiveRow.Cells["ID_Osobe"].Value);
                        s[0]["Iznos"] = uneIznos.Value;
                        s[0]["ID_NacinIsplate"] = ucbNacinIsplate.Value;
                        NapuniPrikaz();
                        return true;
                    }
                }
            }
            return false;
        }

        private bool UpdateOsobeSvima()
        {
            if (ugdZaduzenje.DisplayLayout.Bands.Count > 0)
            {
                if (ugdZaduzenje.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    foreach (DataRow red in BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows)
                    {
                        red["Iznos"] = uneIznos.Value;
                        red["ID_NacinIsplate"] = ucbNacinIsplate.Value;
                    }
                    if (ugdZaduzenje.ActiveRow.Band.ToString() == "OdabraneOsobe")
                    {
                        NapuniPrikaz();
                    }
                    return true;
                }
            }
            return false;
        }

        private void NapuniPrikaz()
        {
            lblPrikazOpcina.Text = lblOpcinaPrebivalista.Text;
            lblPrikazOpcinaRada.Text = "00000";
            lblPrikazOIB.Text = lblOIB.Text;
            lblPrikazIme.Text = ugdZaduzenje.ActiveRow.Cells["Ime"].Value.ToString() + " " + ugdZaduzenje.ActiveRow.Cells["Prezime"].Value.ToString();
            lblPrikazIznos.Text = String.Format("{0:F2}", uneIznos.Value);
            lblPrikazNacinIsplate.Text = ucbNacinIsplate.SelectedItem.ToString();
            lblPrikazIsplata.Text = String.Format("{0:F2}", uneIznos.Value);
            lblMjesec.Text = BusinessLogic.ObracunRazno.pMjesec.ToString();
            lblGodina.Text = BusinessLogic.ObracunRazno.pGodina.ToString();

            int zadnji_dan = DateTime.DaysInMonth((int)BusinessLogic.ObracunRazno.pGodina, (int)BusinessLogic.ObracunRazno.pMjesec);
            lblPrikazRazdobljeDO.Text = new DateTime((int)BusinessLogic.ObracunRazno.pGodina, (int)BusinessLogic.ObracunRazno.pMjesec, zadnji_dan).ToString("dd.MM.yyyy");
            lblPrikazRazdobljeOD.Text = new DateTime((int)BusinessLogic.ObracunRazno.pGodina, (int)BusinessLogic.ObracunRazno.pMjesec, 1).ToString("dd.MM.yyyy");

            if (lblVrstaObracuna.Text == Enums.Vrstaobracuna.PrijevozNezaposleni.ToString())
            {
                lblPrikazOznakaPrimitka.Text = "0000";
                lblPrikazOznakaNeoporezivog.Text = "27";
                lblPrikazOznakaStjecatelja.Text = "0000";
            }
            else if (lblVrstaObracuna.Text == Enums.Vrstaobracuna.NagradeNatjecanja.ToString())
            {
                lblPrikazOznakaPrimitka.Text = "0000";
                lblPrikazOznakaNeoporezivog.Text = "14";
                lblPrikazOznakaStjecatelja.Text = "0000";
            }
            else if (lblVrstaObracuna.Text == Enums.Vrstaobracuna.NagradePraksa.ToString())
            {
                lblPrikazOznakaPrimitka.Text = "0000";
                lblPrikazOznakaNeoporezivog.Text = "13";
                lblPrikazOznakaStjecatelja.Text = "0000";
            }
            else if (lblVrstaObracuna.Text == Enums.Vrstaobracuna.Stipendije.ToString())
            {
                lblPrikazOznakaPrimitka.Text = "0000";
                lblPrikazOznakaNeoporezivog.Text = "28";
                lblPrikazOznakaStjecatelja.Text = "0000";
            }
            else if (lblVrstaObracuna.Text == Enums.Vrstaobracuna.StudentServisNeoporezivo.ToString())
            {
                lblPrikazOznakaPrimitka.Text = "5104";
                lblPrikazOznakaNeoporezivog.Text = "15";
                lblPrikazOznakaStjecatelja.Text = "5501";
            }
            else if (lblVrstaObracuna.Text == Enums.Vrstaobracuna.StudentServisOporezivo.ToString())
            {
                lblPrikazOznakaPrimitka.Text = "5104";
                lblPrikazOznakaNeoporezivog.Text = "0";
                lblPrikazOznakaStjecatelja.Text = "5501";
            }
            else if (lblVrstaObracuna.Text == Enums.Vrstaobracuna.SocijalnaNaknada.ToString())
            {
                lblPrikazOznakaPrimitka.Text = "0000";
                lblPrikazOznakaNeoporezivog.Text = "07";
                lblPrikazOznakaStjecatelja.Text = "0000";
            }
        }

        #endregion

        #region Događaji

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            ContainerForm.DialogResult = DialogResult.OK;
            ContainerForm.Close();
        }

        private void btnSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ContainerForm.DialogResult = DialogResult.OK;
                ContainerForm.Close();
            }
        }

        private void uscObracuniOsobeZaduzenje_Load(object sender, EventArgs e)
        {
            lblVrstaObracuna.Text = BusinessLogic.ObracunRazno.pVrstaObracuna;
            lblMjesec.Text = BusinessLogic.ObracunRazno.pMjesec.ToString();
            lblGodina.Text = BusinessLogic.ObracunRazno.pGodina.ToString();
            LoadNacinIsplate();
            LoadGridOsobe();
        }

        private void ugdZaduzenje_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (ugdZaduzenje.DisplayLayout.Bands.Count > 0)
            {
                if (ugdZaduzenje.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    if (ugdZaduzenje.ActiveRow.Band.ToString() == "OdabraneOsobe")
                    {
                        lblOpcinaPrebivalista.Text = LoadNazivOpcine(ugdZaduzenje.ActiveRow.Cells["ID_Opcina"].Value.ToString());
                        lblOIB.Text = ugdZaduzenje.ActiveRow.Cells["OIB"].Value.ToString();
                        uneIznos.Value = ugdZaduzenje.ActiveRow.Cells["Iznos"].Value;
                        ucbNacinIsplate.Value = ugdZaduzenje.ActiveRow.Cells["ID_NacinIsplate"].Value;
                        NapuniPrikaz();
                    }
                }
            }
        }

        private void btnZaduzi_Click(object sender, EventArgs e)
        {
            if (UpdateOsobeValues())
            {
                
            }
        }

        private void btnZaduziSvima_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Uneseni iznos i način isplate biti će dodjeljen svim osobama u obracun.", "Zaduživanje", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (UpdateOsobeSvima())
                { }
            }
        }

        #endregion

    }
}
