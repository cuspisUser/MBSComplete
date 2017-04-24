using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rest
{
    public partial class frmLogoPath : Form
    {
        Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

        public frmLogoPath()
        {
            InitializeComponent();
        }

        private void frmLogoPath_Load(object sender, EventArgs e)
        {
            string putanja = client.ExecuteScalar("Select Top 1 Logo From Korisnik").ToString();

            if (putanja.Length > 0)
            {
                lblPutanja.Text = "Postavljena putanja za logo je: \n\r" + putanja;
            }
            else
            {
                lblPutanja.Text = "Odaberite lokaciju na kojoj će se nalaziit logo.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdLogo.ShowDialog();

            if (result == DialogResult.OK)
            {
                string putanja = ofdLogo.FileName;
                try 
                {
                    client.ExecuteNonQuery("Update Korisnik Set Logo = '" + putanja + "'");

                    lblPutanja.Text = "Postavljena putanja za logo je: \n\r" + putanja;
                }
                catch { }
            }
        }
    }
}
