using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Materijalno.UI.Izvjestaji
{
    public partial class frmKarticeArtikala : Form
    {
        #region svojstva
        public static int pProizvod
        {
            get;
            set;
        }
        public static Nullable <int> pSkladiste { get; set; }
        public static Nullable<DateTime> naDan { get; set; }
        public static Nullable<DateTime> razdobljeDatumOd { get; set; }
        public static Nullable<DateTime> razdobljeDatumDo { get; set; }

        #endregion

        public frmKarticeArtikala()
        {
            InitializeComponent();

            NapuniProizvod();
            NapuniSkladiste();
        }

        private void NapuniProizvod()
        {
            BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod();
            cmbProizvod.DisplayMember = "Naziv";
            cmbProizvod.ValueMember = "ID";
            cmbProizvod.Items.AddRange(objekt.GetProizvod1());
        }

        private void NapuniSkladiste()
        {
            BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod();
            cmbSkladiste.DisplayMember = "Naziv";
            cmbSkladiste.ValueMember = "ID";

            DataTable skladista = objekt.GetSkladiste();

            DataRow row = skladista.NewRow();
            row["ID"] = -1;
            row["Naziv"] = "<-Sva skladišta->";
            skladista.Rows.InsertAt(row, 0);

            cmbSkladiste.DataSource = skladista;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            naDan = null;
            razdobljeDatumDo = null;
            razdobljeDatumOd = null;

            if (cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(this.cmbProizvod.SelectedItem, null) != null) //ako baci SelectedItem = null, puca
            {
                pProizvod = (int)cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null);
                if ((int)cmbSkladiste.SelectedValue != -1)
                {
                    pSkladiste = (int)cmbSkladiste.SelectedValue;
                }
                else
                {
                    pSkladiste = null;
                }

                if (tcDatum.SelectedTab == tcNaDan)
                {
                    if (udtNaDan.Value != null)
                    {
                        naDan = udtNaDan.DateTime;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        // db - 14.101.2016
                        naDan = DateTime.Now.Date;
                        udtNaDan.Value = DateTime.Now.Date;
                        //MessageBox.Show("Potrebno je odabrati datum za koji se radi izvještaj!");
                        return;
                    }
                }
                else
                {
                    if (udtRazdobljeDatumOd.Value != null & udtRazdobljeDatumDo.Value != null)
                    {
                        razdobljeDatumOd = udtRazdobljeDatumOd.DateTime;
                        razdobljeDatumDo = udtRazdobljeDatumDo.DateTime;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Potrebno je datumsko razdoblje za koje se radi izvještaj!");
                        return;
                    }
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void cmbProizvod_KeyPress(object sender, KeyPressEventArgs e)
        {
            uceDokumentKeyPressed();
        }

        private void cmbProizvod_TextChanged(object sender, EventArgs e)
        {
            if (cmbProizvod.Text.Length == 0) uceDokumentKeyPressed();
        }
        private void uceDokumentKeyPressed()
        {
            cmbProizvod.DroppedDown = true;

            object[] originalList = (object[])cmbProizvod.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[cmbProizvod.Items.Count];
                cmbProizvod.Items.CopyTo(originalList, 0);
                cmbProizvod.Tag = originalList;
            }

            // prepare list of matching items
            string s = cmbProizvod.Text.ToLower();
            IEnumerable<object> newList = originalList;



            if (s.Length > 0)
            {

                newList = originalList.Where(item => item.GetType().GetProperty("Naziv").GetValue(item, null).ToString().ToLower().Contains(s));

                //newList = originalList.Where(item => item[1].ToString().ToLower().Contains(s));
            }

            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            while (cmbProizvod.Items.Count > 0)
            {
                cmbProizvod.Items.RemoveAt(0);
            }

            // re-set list
            cmbProizvod.Items.AddRange(newList.ToArray());
            cmbProizvod.DisplayMember = "Naziv";
            cmbProizvod.ValueMember = "ID";
        }

    }
}
