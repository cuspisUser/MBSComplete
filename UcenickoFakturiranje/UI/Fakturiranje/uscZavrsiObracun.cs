using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Deklarit.Practices.CompositeUI;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Deklarit.Practices.CompositeUI.Workspaces;
using Deklarit.Resources;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class uscZavrsiObracun : Controls.BaseUserControl
    {
        public uscZavrsiObracun()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void btnZavrsiObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void btnZavrsiObracunSpremi_Click(object sender, EventArgs e)
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();
            Obracuni.ZakljucajObracun();
            bool persist = false;
            persist = Obracuni.Persist();
        }

        private void btnZavrsiObracunVirmani_Click(object sender, EventArgs e)
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            if (Obracuni.VratiDaliJeZakljucan())
            {
                base.ContainerForm.DialogResult = DialogResult.Ignore;
                base.ContainerForm.Close();
            }
            else
            {
                MessageBox.Show("Ukoliko ste završili sa obračunom potrebno ga je zaključati da bi se kreirali virmani.\n Nakon toga više nije moguće mjenjati obračun.");
            }

            
        }

        private void btnZavrsiObracunZaduzi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkcionalnost u izradi!!!");
        }
    }
}
