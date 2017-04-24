using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chat
{
    public partial class frmRegistracija : Form
    {
        public frmRegistracija()
        {
            InitializeComponent();
            NapuniKorisnika();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (ValidacijaKorisnika())
            {
                uscChat.pKorisnickoIme = txtKorisnickoIme.Text.Trim();
                uscChat.pValidiran = true;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool ValidacijaKorisnika()
        {
            string connection_string = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                                                     "mssql6.mojsite.com,1555", "vugergrad_chat", "vugergrad_chat", "chatajMO2010");

            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient(connection_string);

            //provjera dili postoji vec to korisnicko ime
            string korisnicko_ime = txtKorisnickoIme.Text.Trim();
            if (korisnicko_ime.Length > 30)
            {
                MessageBox.Show("Korisničko ime ne smije sadržavati više od 30 znakova");
                return false;
            }

            int count = Convert.ToInt32(client.ExecuteScalar("Select Count(ID) From Korisnici Where KorisnickoIme = '" + korisnicko_ime + "'"));

            if (count > 0)
            {
                MessageBox.Show("Korisničko ime već postoji u bazi.\nUnesite drugo korisničko ime.");
                return false;
            }
            return true;
        }

        private void NapuniKorisnika()
        {
            string connection_string = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                                                     "mssql6.mojsite.com,1555", "vugergrad_chat", "vugergrad_chat", "chatajMO2010");


            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient(connection_string);

            lblNazivUstanove.Text = client.ExecuteScalar("Select Ime From Korisnici Where OIB = '" + uscChat.oib_korisnika + "'").ToString();

            if (!uscChat.pValidiran)
            {
                if (System.Environment.UserName.ToString().Length < 30)
                {
                    txtKorisnickoIme.Text = System.Environment.UserName.ToString();
                }
                else
                {
                    txtKorisnickoIme.Text = string.Empty;
                }
            }
            else
            {
                txtKorisnickoIme.Text = client.ExecuteScalar("Select KorisnickoIme From Korisnici Where OIB = '" + uscChat.oib_korisnika + "'").ToString();
            }
        }

    }
}
