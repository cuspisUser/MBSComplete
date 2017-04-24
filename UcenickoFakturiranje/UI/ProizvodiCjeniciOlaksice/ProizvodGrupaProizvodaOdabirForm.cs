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
    public partial class ProizvodGrupaProizvodaOdabirForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }
        public List<Entitet.Proizvod> gSelektirani;

        public UltraGrid Ppod_stavke { get; set;}

        public ProizvodGrupaProizvodaOdabirForm(int? id)
        {
            InitializeComponent();

            ID = id;
        }

        #region Event Handlers

        private void ProizvodGrupaProizvodaOdabirForm_Load(object sender, EventArgs e)
        {
            LoadProizvod();
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            //if (!SaveData())
            //{
            //    MessageBox.Show("Niste odabrali niti jedan proizvod!");
            //}
            //else 
            //{
            //    base.ContainerForm.DialogResult = DialogResult.OK;
            //    base.ContainerForm.Close();
            //}
            Ppod_stavke = UltraGridPodProizvodi;
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            Ppod_stavke = UltraGridPodProizvodi;
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        #endregion


        private void LoadProizvod()
        {
            Mipsed7.DataAccessLayer.SqlClient cl = new Mipsed7.DataAccessLayer.SqlClient();
            BusinessLogic.ProizvodiGrupeProizvoda proizvodi = new BusinessLogic.ProizvodiGrupeProizvoda();

            DataSet ds = proizvodi.GetProizvodiOdaberList(ID);

            UltraGridPodProizvodi.DataSource = ds;
            UltraGridPodProizvodi.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridPodProizvodi);

            if (UltraGridPodProizvodi.DisplayLayout.Bands.Count > 0)
                if (UltraGridPodProizvodi.DisplayLayout.Bands[0].Columns.Count > 0)
                    UltraGridPodProizvodi.DisplayLayout.Bands[0].Columns[0].CellActivation =
                        Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
        }

        private void UltraGridPodProizvodi_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Column.Key.Equals("SEL"))
            {
                e.Cell.Value = !bool.Parse(e.Cell.Value.ToString());                
            }
        }

        private void btnProizvodiOdznaciSve_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in UltraGridPodProizvodi.Rows)
            {
                if (bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    row.Cells["SEL"].Value = false;
                }

            }
        }

        private void btnProizvodiOznaciSve_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in UltraGridPodProizvodi.Rows)
            {
                if (!bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    row.Cells["SEL"].Value = true;
                }

            }
        }

        

       
    }
}
