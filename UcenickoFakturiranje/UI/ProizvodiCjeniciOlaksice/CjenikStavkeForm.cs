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
using System.Data.SqlClient;

namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    public partial class CjenikStavkeForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }
        private int CjenikID { get; set; }
        private IList<int> pOdabrani_proizvodi { get; set; }

        public CjenikStavkeForm(FormEditMode formEditMode, int? id, int CjenikID, IList<int> odabrani_proizvod)
        {
            InitializeComponent();

           

            this.FormEditMode = formEditMode;
            this.ID = id;
            this.CjenikID = CjenikID;
            pOdabrani_proizvodi = odabrani_proizvod;
        }

        #region Event Handlers

        private void CjenikStavkeForm_Load(object sender, EventArgs e)
        {
            LoadCOmboOlaksica();
            LoadComboPorez();
            LoadComboProizvod();

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormCjenikStavka();
            }
            else 
            {
                ultraNumericPostotakOlaksice.Value = ultraNumericIznosOlaksice.Value = ultraNumericCijena.Value = null;
            }

            lbStopa.Visible = false;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                pOdabrani_proizvodi.Add((int)ComboBoxProizvod.Value);
                LoadComboProizvod();
                ComboBoxPorez.SelectedIndex = -1;
                ultraNumericCijena.Value = null;
                ComboBoxOlaksica.SelectedIndex = -1;
                ultraNumericIznosOlaksice.Value = null;
                ultraNumericPostotakOlaksice.Value = null;
            }
            //this.FormEditMode = Enums.FormEditMode.Update;
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void ComboBoxPorez_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxPorez.Value != null)
            {
                BusinessLogic.Porez porez = new BusinessLogic.Porez();
                lbStopa.Text = porez.GetPorez((int)ComboBoxPorez.Value).FINPOREZSTOPA.ToString("N2");
                IzracunajCijenu();
            }


        }

        private void ComboBoxOlaksica_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxOlaksica.Value != null)
            {
                BusinessLogic.Olaksice olaksice = new BusinessLogic.Olaksice();
                var olaksica = olaksice.GetOlaksica((int)ComboBoxOlaksica.Value);

                ultraNumericIznosOlaksice.Value = olaksica.OlaksicaIznos;
                ultraNumericPostotakOlaksice.Value = olaksica.OlaksicaPostotak;

                IzracunajCijenu();
            }
        }

        private void ultraNumericCijena_ValueChanged(object sender, EventArgs e)
        {
            IzracunajCijenu();
        }

        private void ComboBoxPorez_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                ComboBoxPorez.Value = null;
                IzracunajCijenu();
            }
        }
        #endregion

        private void LoadFormCjenikStavka()
        {
            BusinessLogic.CjeniciStavke stavka = new BusinessLogic.CjeniciStavke();
            var item = stavka.GetCjenikStavka(this.ID.GetValueOrDefault(0));
            
            ComboBoxProizvod.Value = item.ProizvodID;

            if (item.OlaksicaID != null)
            {
                ComboBoxOlaksica.Value = item.OlaksicaID;
                ultraNumericPostotakOlaksice.Value = item.OlaksicaPostotak;
                ultraNumericIznosOlaksice.Value = item.OlaksicaIznos;    
            }
        }

        private void LoadComboProizvod() 
        {
            BusinessLogic.ProizvodiGrupeProizvoda proizvod = new BusinessLogic.ProizvodiGrupeProizvoda();

            this.ComboBoxProizvod.DataSource = proizvod.GetProizvodiComboBox(pOdabrani_proizvodi);
            this.ComboBoxProizvod.DataBind();
        }

        private void LoadComboPorez() 
        {
            BusinessLogic.Porez porez = new BusinessLogic.Porez();

            this.ComboBoxPorez.DataSource = porez.GetPorezComboBox();
            this.ComboBoxPorez.DataBind();
        }

        private void LoadCOmboOlaksica() 
        {
            BusinessLogic.Olaksice olaksice = new BusinessLogic.Olaksice();
            this.ComboBoxOlaksica.DataSource = olaksice.GetOlaksicaComboBox();

            this.ComboBoxOlaksica.DataBind();
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.CjeniciStavke stavke = new BusinessLogic.CjeniciStavke();
            
            decimal? iznos = null, postotak = null;
            int? porezID = null, olaksicaID = null;

            if (ultraNumericIznosOlaksice.Value != null)
            {
                iznos = Decimal.Parse(ultraNumericIznosOlaksice.Value.ToString());
            }
            if (ultraNumericPostotakOlaksice.Value != null)
            {
                postotak = Decimal.Parse(ultraNumericPostotakOlaksice.Value.ToString());
            }

            porezID = (ComboBoxPorez.Value == null ? null : (int?)ComboBoxPorez.Value);
            olaksicaID = (ComboBoxOlaksica.Value == null ? null : (int?)ComboBoxOlaksica.Value);
            
            if (!stavke.ValidateDataInput(CjenikID, ComboBoxProizvod, ComboBoxOlaksica))
            {
                stavke.DisplayValidationMessages(this);
                return false;
            }

            if (this.FormEditMode == Enums.FormEditMode.Insert || this.FormEditMode == Enums.FormEditMode.Copy)
            {
                stavke.Add(CjenikID,
                    (int)ComboBoxProizvod.Value,
                    porezID,
                    decimal.Parse(ultraNumericCijena.Value.ToString()),
                    olaksicaID,
                    postotak,
                    iznos);

            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                stavke.Update((int)ID, CjenikID,
                    (int)ComboBoxProizvod.Value,
                    porezID,
                    decimal.Parse(ultraNumericCijena.Value.ToString()),
                    olaksicaID,
                    postotak,
                    iznos);
            }

            if (stavke.IsValid)
            {
                if (this.FormEditMode == Enums.FormEditMode.Insert || this.FormEditMode == Enums.FormEditMode.Copy)
                {
                    ID = stavke.GetMaxId();    
                }
                return stavke.Perist();
            }
            
            return false;
        }

        private void IzracunajCijenu() 
        {
            if (ultraNumericCijena.Value != null)
            {
                if (ultraNumericCijena.Value.ToString().Length == 0)
                {
                    return;
                }

                decimal? pdvStopa = null, popustIznos = null, popustPosto = null;
                pdvStopa = (ComboBoxPorez.Value == null ? null : (decimal?)decimal.Parse(lbStopa.Text));
                popustIznos = (ultraNumericIznosOlaksice.Value == null ? null : (decimal?)decimal.Parse(ultraNumericIznosOlaksice.Value.ToString()));
                popustPosto = (ultraNumericPostotakOlaksice.Value == null ? null : (decimal?)decimal.Parse(ultraNumericPostotakOlaksice.Value.ToString()));    

                decimal neto_cijena = Hlp.Razno.IzracunajCijenuUF(Decimal.Parse(ultraNumericCijena.Value.ToString()),
                                                        pdvStopa,
                                                        popustPosto,
                                                        popustIznos);

                if (neto_cijena >= 0)
                    lbCijena.Text = neto_cijena.ToString("N2");
                else
                {
                    MessageBox.Show("Cijena sa olakšicom je negativna!\nOdaberite drugu olakšicu.");
                    ComboBoxOlaksica.SelectedIndex = 0;                    
                }
            }
            
        }

        private void btnCjenikStavkeOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void ComboBoxProizvod_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxProizvod.Value != null)
                PunjenjePorezCijene(Convert.ToInt32(ComboBoxProizvod.Value));
        }

        private void PunjenjePorezCijene(int id)
        {
            Mipsed7.DataAccessLayer.SqlClient sql_client = new Mipsed7.DataAccessLayer.SqlClient();

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = sql_client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Select PorezID, Cijena from UF_Proizvod Where ID = '" + id + "'";

            SqlDataReader sqlReader = sqlUpit.ExecuteReader();
            if (sqlReader.Read())
            {
                ultraNumericCijena.Value = sqlReader["Cijena"];
                ComboBoxPorez.Value = sqlReader["PorezID"];
            }
            sqlReader.Close();
        }
    }
}
