using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Materijalno.Enums;

namespace Materijalno.UI.Dokumenti
{
    public partial class UnosMeduskladisniceStavkeForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public UnosMeduskladisniceStavkeForm(FormEditMode formEditMode)
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
                using (BusinessLogic.Meduskladisnica objekt = new BusinessLogic.Meduskladisnica())
                {
                    objekt.pSifra = Convert.ToInt32(uteBrojDokumenta.Value);
                    objekt.pIzlaznoSkladiste = (int)ucbIzlaznoSkladiste.Value;
                    objekt.pUlaznoSkladiste = (int)ucbUlaznoSkladiste.Value;
                    objekt.pDatum = udtDatum.DateTime;

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

            if (udtDatum.Value == null)
            {
                message.Append(" - Datum je obavezan!");
            }

            if (ucbIzlaznoSkladiste.Value == null)
            {
                message.Append(" - Izlazno skladište je obavezno!");
            }

            if (ucbUlaznoSkladiste.Value == null)
            {
                message.Append(" - Ulazno skladište je obavezno!");
            }

            if (ucbIzlaznoSkladiste.Value != null && ucbUlaznoSkladiste.Value != null)
            {
                if ((int)ucbIzlaznoSkladiste.Value == (int)ucbUlaznoSkladiste.Value)
                {
                    message.Append(" - ulazno i izlazno skladište nemože biti isto!");
                }
            }

            return message;
        }

        private void LoadForm(BusinessLogic.Meduskladisnica objekt)
        {
            var row = objekt.GetRow();

            if (row != null)
            {
                uteBrojDokumenta.Value = row["Sifra"].ToString();
                ucbIzlaznoSkladiste.Value = Convert.ToInt32(row["ID_IzlaznoSkladiste"].ToString());
                ucbUlaznoSkladiste.Value = Convert.ToInt32(row["ID_UlaznoSkladiste"].ToString());
                udtDatum.Value = row["Datum"].ToString();
                BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke = objekt.GetPostojeceStavke();
                BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns["ID_Proizvoda"] };
                ugdMeduskladisnicaStavke.DataSource = BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke;
                ugdMeduskladisnicaStavke.DataBind();

                Utils.Tools.UltraGridStyling(ugdMeduskladisnicaStavke);

                if (ugdMeduskladisnicaStavke.DisplayLayout.Bands.Count > 0)
                {
                    ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["ID_Meduskladisnica"].Hidden = true;
                    ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Hidden = true;
                    ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["IzlaznaCijena"].Format = "N2";
                    ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["UlaznaCijena"].Format = "N2";
                    ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "N2";
                }

                if (BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Count == 0)
                {
                    btnBrisiStavku.Enabled = false;
                    btnUrediStavku.Enabled = false;
                }
                else
                {
                    btnBrisiStavku.Enabled = true;
                    btnUrediStavku.Enabled = true;
                }
            }
        }

        private void LoadSkladiste(BusinessLogic.Meduskladisnica objekt)
        {
            ucbIzlaznoSkladiste.DataSource = objekt.GetSkladiste();
            ucbIzlaznoSkladiste.DataBind();

            ucbUlaznoSkladiste.DataSource = objekt.GetSkladiste();
            ucbUlaznoSkladiste.DataBind();
        }

        private void LoadStavke()
        {
            ugdMeduskladisnicaStavke.DataSource = BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke;
            ugdMeduskladisnicaStavke.DataBind();

            Utils.Tools.UltraGridStyling(ugdMeduskladisnicaStavke);

            if (ugdMeduskladisnicaStavke.DisplayLayout.Bands.Count > 0)
            {
                ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["ID_Meduskladisnica"].Hidden = true;
                ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Hidden = true;
                ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["IzlaznaCijena"].Format = "N2";
                ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["UlaznaCijena"].Format = "N2";
                ugdMeduskladisnicaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "N2";
            }

            if (BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Count == 0)
            {
                btnBrisiStavku.Enabled = false;
                btnUrediStavku.Enabled = false;
            }
            else
            {
                btnBrisiStavku.Enabled = true;
                btnUrediStavku.Enabled = true;
            }
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

        private void Form_Load(object sender, EventArgs e)
        {
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke = new DataTable();
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns.Add("SEL", typeof(bool));
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns.Add("ID_Meduskladisnica", typeof(int));
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns.Add("ID_Proizvoda", typeof(int));
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns.Add("Proizvod", typeof(string));
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns.Add("IzlaznaCijena", typeof(decimal));
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns.Add("UlaznaCijena", typeof(decimal));
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns.Add("Kolicina", typeof(decimal));
            BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Columns["ID_Proizvoda"] };

            using (BusinessLogic.Meduskladisnica objekt = new BusinessLogic.Meduskladisnica())
            {
                LoadSkladiste(objekt);

                udtDatum.Value = DateTime.Now;
                uteBrojDokumenta.Value = objekt.GetBrojDokumenta();

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }


        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            if (ucbIzlaznoSkladiste.Value != null)
            {
                lblValidationMessages.Text = string.Empty;
                using (UnosMeduskladisniceOdredivanjeKolicineForm objekt = new UnosMeduskladisniceOdredivanjeKolicineForm(Enums.FormEditMode.Insert, (int)ucbIzlaznoSkladiste.Value))
                {
                    if (objekt.ShowDialogForm("MeduskladisnicaStavke") == DialogResult.OK)
                    {
                        LoadStavke();
                    }
                }
            }
            else
            {
                lblValidationMessages.Text = "Potrebno je odabrati izlazno skladište!!!";
            }
        }


        private void btnUrediStavku_Click(object sender, EventArgs e)
        {
            if (ucbIzlaznoSkladiste.Value != null)
            {
                lblValidationMessages.Text = string.Empty;
                using (UnosMeduskladisniceOdredivanjeKolicineForm objekt = new UnosMeduskladisniceOdredivanjeKolicineForm(Enums.FormEditMode.Update, (int)ucbIzlaznoSkladiste.Value))
                {
                    UnosMeduskladisniceOdredivanjeKolicineForm.pProizvod = (int)ugdMeduskladisnicaStavke.ActiveRow.Cells["ID_Proizvoda"].Value;
                    UnosMeduskladisniceOdredivanjeKolicineForm.pIzlaznaCijena = IsDbNull<decimal>(ugdMeduskladisnicaStavke.ActiveRow.Cells["IzlaznaCijena"].Value);
                    UnosMeduskladisniceOdredivanjeKolicineForm.pUlaznaCijena = IsDbNull<decimal>(ugdMeduskladisnicaStavke.ActiveRow.Cells["UlaznaCijena"].Value);
                    UnosMeduskladisniceOdredivanjeKolicineForm.pKolicina = IsDbNull<decimal>(ugdMeduskladisnicaStavke.ActiveRow.Cells["Kolicina"].Value);

                    if (objekt.ShowDialogForm("MeduskladisnicaStavke") == DialogResult.OK)
                    {
                        LoadStavke();
                    }
                }
            }
            else
            {
                lblValidationMessages.Text = "Potrebno je odabrati izlazno skladište!!!";
            }
        }

        public Nullable<T> IsDbNull<T>(object value) where T : struct
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return null;
        }

        private void btnBrisiStavku_Click(object sender, EventArgs e)
        {
            for (int i = ugdMeduskladisnicaStavke.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdMeduskladisnicaStavke.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    DataRow row = BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Find(ugdMeduskladisnicaStavke.Rows[i].Cells["ID_Proizvoda"].Value);
                    BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Remove(row);
                }
            }
        }
        
        #endregion
    }
}
