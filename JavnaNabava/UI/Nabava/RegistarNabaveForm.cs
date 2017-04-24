using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavnaNabava.Enums;
using NetAdvantage.WorkItems;
using Microsoft.Practices.CompositeUI;

namespace JavnaNabava.UI.Nabava
{
    public partial class uscRegistarNabave : Controls.BaseUserControl
    {

        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscRegistarNabave(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private void LoadVrstaNabave(BusinessLogic.RegistarNabave registar_nabave)
        {
            ucbVrstaNabave.DataSource = registar_nabave.GetVrsteNabave().DefaultView;
            ucbVrstaNabave.DataBind();
        }

        private void LoadCPVOznake(BusinessLogic.RegistarNabave registar_nabave)
        {
            ucbCPVOznaka.DataSource = registar_nabave.GetCPVOznake().DefaultView;
            ucbCPVOznaka.DataBind();
        }

        private void LoadPartner(BusinessLogic.RegistarNabave registar_nabave)
        {
            ucbPartner.DataSource = registar_nabave.GetPartneri().DefaultView;
            ucbPartner.DataBind();
        }

        private void LoadOrganizacijskaJedinica(BusinessLogic.RegistarNabave registar_nabave)
        {
            ucbOrganizacijskeJedinice.DataSource = registar_nabave.GetOrganizacijskaJedinica().DefaultView;
            ucbOrganizacijskeJedinice.DataBind();
        }

        private void LoadMjestoTroska(BusinessLogic.RegistarNabave registar_nabave)
        {
            ucbMjestoTroska.DataSource = registar_nabave.GetMjestoTroska().DefaultView;
            ucbMjestoTroska.DataBind();
        }

        private void LoadEVRStruktura(BusinessLogic.RegistarNabave registar_nabave)
        {
            ucbEVRStruktura.DataSource = registar_nabave.GetEVRStruktura().DefaultView;
            ucbEVRStruktura.DataBind();
        }

        private void LoadStopaPoreza(BusinessLogic.RegistarNabave registar_nabave)
        {
            ucbPoreznaStopa.DataSource = registar_nabave.GetStopePoreza().DefaultView;
            ucbPoreznaStopa.DataBind();

            if (ucbPoreznaStopa.DisplayLayout.Bands.Count > 0)
            {
                ucbPoreznaStopa.DisplayLayout.Bands[0].ColHeadersVisible = false;
                ucbPoreznaStopa.DisplayLayout.Bands[0].Columns[0].Hidden = true;
                ucbPoreznaStopa.DisplayLayout.Bands[0].Columns[2].Hidden = true;
            }
        }
       
        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.RegistarNabave.pID_VrstaNabave = (int?)ucbVrstaNabave.Value;
            BusinessLogic.RegistarNabave.pID_CPV_Oznaka = (int?)ucbCPVOznaka.Value;
            BusinessLogic.RegistarNabave.pNaziv = uteNaziv.Text;
            BusinessLogic.RegistarNabave.pID_Partner = (int?)ucbPartner.Value;
            BusinessLogic.RegistarNabave.pDatumPocetka = (DateTime?)udtDatumPocetka.Value;
            BusinessLogic.RegistarNabave.pID_StopaPoreza = (int?)ucbPoreznaStopa.Value;
            BusinessLogic.RegistarNabave.pBezPDVa = Convert.ToDecimal(uneBezPDVa.Value);
            BusinessLogic.RegistarNabave.pSaPDVom = Convert.ToDecimal(uneSaPDVom.Value);
            BusinessLogic.RegistarNabave.pDatumZavrsetka = (DateTime?)udtDatumZavrsetka.Value;
            BusinessLogic.RegistarNabave.pDatumIsporuke = (DateTime?)udtPocetakIsporuke.Value;
            BusinessLogic.RegistarNabave.pID_EVR = (int?)ucbEVRStruktura.Value;
            BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica = (int?)ucbOrganizacijskeJedinice.Value;
            BusinessLogic.RegistarNabave.pID_MjestoTroska = (int?)ucbMjestoTroska.Value;
            

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                BusinessLogic.RegistarNabave registar_nabave = new BusinessLogic.RegistarNabave();

                BusinessLogic.RegistarNabave.pID_RegistarNabave = GetMaxIDRegistarnabave(registar_nabave);
                BusinessLogic.RegistarNabave.pEVR_Broj = GetEVRBroj(registar_nabave);

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (registar_nabave.Insert(message))
                    {
                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {
                    if (registar_nabave.Update(message))
                    {
                        return true;
                    }
                }
            }
            
            lblValidationMessages.Text = message.ToString();
            
            return false;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.RegistarNabave.pID_VrstaNabave == null)
            {
                message.Append(" - Vrsta nabave je obavezno polje");
            }
            if (BusinessLogic.RegistarNabave.pNaziv.Length == 0)
            {
                message.Append(" - Naziv je obavezno polje");
            }
            else if (BusinessLogic.RegistarNabave.pNaziv.Length > 50)
            {
                message.Append(" - Naziv nesmije biti duži od 50 znakova");
            }
            if (BusinessLogic.RegistarNabave.pID_Partner == null)
            {
                message.Append(" - Partner je obavezno polje");
            }
            if (BusinessLogic.RegistarNabave.pBezPDVa == 0)
            {
                message.Append(" - Iznos bez PDV-a je obavezno polje");
            }
            if (ucbOrganizacijskeJedinice.Visible == true & BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica == null)
            {
                message.Append(" - Organizacijska jedinica je obavezno polje");
            }
            if (ucbMjestoTroska.Visible == true & BusinessLogic.RegistarNabave.pID_MjestoTroska == null)
            {
                message.Append(" - Mjesto troška je obavezno polje");
            }

            return message;
        }

        private void LoadRegistarNabaveByID(BusinessLogic.RegistarNabave registar_nabave)
        {
            if (registar_nabave.RegistarNabaveByID())
            {
                ucbVrstaNabave.Value = BusinessLogic.RegistarNabave.pID_VrstaNabave;
                ucbCPVOznaka.Value = BusinessLogic.RegistarNabave.pID_CPV_Oznaka;
                uteNaziv.Text = BusinessLogic.RegistarNabave.pNaziv;
                ucbPartner.Value = BusinessLogic.RegistarNabave.pID_Partner;
                udtDatumPocetka.Value = BusinessLogic.RegistarNabave.pDatumPocetka;
                ucbPoreznaStopa.Value = BusinessLogic.RegistarNabave.pID_StopaPoreza;
                uneBezPDVa.Value = BusinessLogic.RegistarNabave.pBezPDVa;
                uneSaPDVom.Value = BusinessLogic.RegistarNabave.pSaPDVom;
                udtDatumZavrsetka.Value = BusinessLogic.RegistarNabave.pDatumZavrsetka;
                udtPocetakIsporuke.Value = BusinessLogic.RegistarNabave.pDatumIsporuke;
                ucbEVRStruktura.Value = BusinessLogic.RegistarNabave.pID_EVR;
                ucbOrganizacijskeJedinice.Value = BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica;
                ucbMjestoTroska.Value = BusinessLogic.RegistarNabave.pID_MjestoTroska;
            }
        }

        private void ProvjeraEVRStrukture(string id)
        {
            BusinessLogic.RegistarNabave registar_nabave = new BusinessLogic.RegistarNabave();
            DataRow red_evr = registar_nabave.GetEVRStrukturabyID(id);
            if (red_evr["OrganizacijskaJedinica"].ToString() == "True")
            {
                lblOrganizacijskaJedinica.Visible = true;
                ucbOrganizacijskeJedinice.Visible = true;
            }
            else
            {
                lblOrganizacijskaJedinica.Visible = false;
                ucbOrganizacijskeJedinice.Visible = false;
                ucbOrganizacijskeJedinice.Value = null;
            }
            if (red_evr["MjestoTroska"].ToString() == "True")
            {
                lblMjestoTroska.Visible = true;
                ucbMjestoTroska.Visible = true;
            }
            else
            {
                lblMjestoTroska.Visible = false;
                ucbMjestoTroska.Visible = false;
                ucbMjestoTroska.Value = null;
            }
        }

        private int GetMaxIDRegistarnabave(BusinessLogic.RegistarNabave registar_nabave)
        {
            int id_registar_nabave = registar_nabave.MaxIDRegistarNabave();
            return id_registar_nabave;
        }

        private string GetEVRBroj(BusinessLogic.RegistarNabave registar_nabave)
        {
            string format_erv_broja = string.Empty;
            string organizacijska_jedinica = string.Empty;
            string mjesto_troska = string.Empty;
            string id_registar_nabave = string.Empty;
            DataRow evr_struktura = registar_nabave.EVRStrukturaByID();

            if (evr_struktura["Pozicija_EVR"].ToString() == "pocetak")
            {
                if (evr_struktura["DuzinaBloka"].ToString() == "2")
                {
                    if (BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString().Length == 2)
                        organizacijska_jedinica = BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();
                    else
                        organizacijska_jedinica = "0" + BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();


                    if (BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString().Length == 2)
                        mjesto_troska = BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();
                    else
                        mjesto_troska = "0" + BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();


                    if (BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString().Length == 2)
                        id_registar_nabave = BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();
                    else
                        id_registar_nabave = "0" + BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();
                    

                    if (evr_struktura["OrganizacijskaJedinica"].ToString() == "True" & evr_struktura["MjestoTroska"].ToString() == "True")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + organizacijska_jedinica + evr_struktura["SeparatorBloka"].ToString() +
                                             mjesto_troska + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "False" & evr_struktura["MjestoTroska"].ToString() == "True")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + mjesto_troska + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "True" & evr_struktura["MjestoTroska"].ToString() == "False")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + organizacijska_jedinica + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "False" & evr_struktura["MjestoTroska"].ToString() == "False")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + id_registar_nabave;
                    }
                }
                else if (evr_struktura["DuzinaBloka"].ToString() == "3")
                {
                    if (BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString().Length == 3)
                        organizacijska_jedinica = BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();
                    else if (BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString().Length == 2)
                        organizacijska_jedinica = "0" + BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();
                    else
                        organizacijska_jedinica = "00" + BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();


                    if (BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString().Length == 3)
                        mjesto_troska = BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();
                    else if (BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString().Length == 2)
                        mjesto_troska = "0" + BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();
                    else
                        mjesto_troska = "00" + BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();


                    if (BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString().Length == 3)
                        id_registar_nabave = BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();
                    else if (BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString().Length == 2)
                        id_registar_nabave = "0" + BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();
                    else
                        id_registar_nabave = "00" + BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();


                    if (evr_struktura["OrganizacijskaJedinica"].ToString() == "True" & evr_struktura["MjestoTroska"].ToString() == "True")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + organizacijska_jedinica + evr_struktura["SeparatorBloka"].ToString() +
                                             mjesto_troska + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "False" & evr_struktura["MjestoTroska"].ToString() == "True")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + mjesto_troska + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "True" & evr_struktura["MjestoTroska"].ToString() == "False")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + organizacijska_jedinica + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "False" & evr_struktura["MjestoTroska"].ToString() == "False")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + id_registar_nabave;
                    }
                }
                else if (evr_struktura["DuzinaBloka"].ToString() == "4")
                {
                    if (BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString().Length == 4)
                        organizacijska_jedinica = BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();
                    else if (BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString().Length == 3)
                        organizacijska_jedinica = "0" + BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();
                    else if (BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString().Length == 2)
                        organizacijska_jedinica = "00" + BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();
                    else 
                        organizacijska_jedinica = "000" + BusinessLogic.RegistarNabave.PID_OrganizacijskaJedinica.ToString();


                    if (BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString().Length == 4)
                        mjesto_troska = BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();
                    else if (BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString().Length == 3)
                        mjesto_troska = "0" + BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();
                    else if (BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString().Length == 2)
                        mjesto_troska = "00" + BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();
                    else
                        mjesto_troska = "000" + BusinessLogic.RegistarNabave.pID_MjestoTroska.ToString();


                    if (BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString().Length == 4)
                        id_registar_nabave = BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();
                    else if (BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString().Length == 3)
                        id_registar_nabave = "0" + BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();
                    else if (BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString().Length == 2)
                        id_registar_nabave = "00" + BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();
                    else
                        id_registar_nabave = "000" + BusinessLogic.RegistarNabave.pID_RegistarNabave.ToString();


                    if (evr_struktura["OrganizacijskaJedinica"].ToString() == "True" & evr_struktura["MjestoTroska"].ToString() == "True")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + organizacijska_jedinica + evr_struktura["SeparatorBloka"].ToString() +
                                             mjesto_troska + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "False" & evr_struktura["MjestoTroska"].ToString() == "True")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + mjesto_troska + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "True" & evr_struktura["MjestoTroska"].ToString() == "False")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + organizacijska_jedinica + evr_struktura["SeparatorBloka"].ToString() + id_registar_nabave;
                    }
                    else if (evr_struktura["OrganizacijskaJedinica"].ToString() == "False" & evr_struktura["MjestoTroska"].ToString() == "False")
                    {
                        format_erv_broja = "EVR" + evr_struktura["Separator_EVR"].ToString() + id_registar_nabave;
                    }
                }
            }
            else
            {

            }

            return format_erv_broja;
        }

        #endregion

        #region Dogadaji

        private void tsbRegistarNabaveSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ucbVrstaNabave.Value = null;
                ucbCPVOznaka.Value = null;
                uteNaziv.Text = string.Empty;
                ucbPartner.Value = null;
                udtDatumPocetka.Value = null;
                uneBezPDVa.Value = 0;
                uneSaPDVom.Value = 0;
                ucbPoreznaStopa.Value = null;
                udtDatumZavrsetka.Value = null;
                udtPocetakIsporuke.Value = null;
                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void tsbRegistarNabaveSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbRegistarNabaveOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void btnVrstaNabave_Click(object sender, EventArgs e)
        {
            using (MaticniPodaci.uscVrsteNabaveForm vrste_nabave = new MaticniPodaci.uscVrsteNabaveForm(Enums.FormEditMode.Insert))
            {
                BusinessLogic.RegistarNabave registar_nabave = new BusinessLogic.RegistarNabave();
                if (vrste_nabave.ShowDialogForm("Vrste Nabave") == DialogResult.OK)
                    LoadVrstaNabave(registar_nabave);
            }
        }

        private void btnCPVOznaka_Click(object sender, EventArgs e)
        {
            using (MaticniPodaci.uscCPVOznake cpv_oznake = new MaticniPodaci.uscCPVOznake(Enums.FormEditMode.Insert))
            {
                BusinessLogic.RegistarNabave registar_nabave = new BusinessLogic.RegistarNabave();
                if (cpv_oznake.ShowDialogForm("CPV oznake") == DialogResult.OK)
                    LoadCPVOznake(registar_nabave);
            }
        }

        private void btnNaziv_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPoreznaStopa_Click(object sender, EventArgs e)
        {

        }

        private void uscRegistarNabave_Load(object sender, EventArgs e)
        {
            BusinessLogic.RegistarNabave registar_nabave = new BusinessLogic.RegistarNabave();

            LoadVrstaNabave(registar_nabave);
            LoadCPVOznake(registar_nabave);
            LoadPartner(registar_nabave);
            LoadStopaPoreza(registar_nabave);
            LoadMjestoTroska(registar_nabave);
            LoadOrganizacijskaJedinica(registar_nabave);
            LoadEVRStruktura(registar_nabave);

            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadRegistarNabaveByID(registar_nabave);
                ucbEVRStruktura.ReadOnly = true;
                ucbMjestoTroska.ReadOnly = true;
                ucbOrganizacijskeJedinice.ReadOnly = true;
            }
            else
            {
                ucbEVRStruktura.ReadOnly = false;
                ucbMjestoTroska.ReadOnly = false;
                ucbOrganizacijskeJedinice.ReadOnly = false;
            }
        }

        private void uneBezPDVa_ValueChanged(object sender, EventArgs e)
        {
            //if (ucbPoreznaStopa.Value != null)
            //{
            //    decimal pdv = 0;
            //    decimal bez_poreza = 0;

            //    bez_poreza = Convert.ToDecimal(uneBezPDVa.Value);
            //    pdv = bez_poreza * Convert.ToDecimal(ucbPoreznaStopa.SelectedRow.Cells["Stopa"].Value.ToString()) / 100;
            //    uneSaPDVom.Value = bez_poreza + pdv;
            //}
        }

        private void ucbPoreznaStopa_SelectionChanged(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(uneBezPDVa.Value) > 0)
            //{
            //    decimal pdv = 0;
            //    decimal bez_poreza = 0;

            //    bez_poreza = Convert.ToDecimal(uneBezPDVa.Value);
            //    pdv = bez_poreza * Convert.ToDecimal(ucbPoreznaStopa.SelectedRow.Cells["Stopa"].Value.ToString()) / 100;
            //    uneSaPDVom.Value = bez_poreza + pdv;
            //}
        }

        private void ucbEVRStruktura_ValueChanged(object sender, EventArgs e)
        {
            ProvjeraEVRStrukture(ucbEVRStruktura.Value.ToString());
        }

        private void lblValidationMessages_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(lblValidationMessages, lblValidationMessages.Text);
        }

        #endregion

    }
}
