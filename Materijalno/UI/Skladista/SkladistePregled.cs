using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Commands;
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid;

namespace Materijalno.UI.Skladista
{
    [SmartPart]
    public partial class SkladistePregled : UserControl, ISmartPartInfoProvider
    {
        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

        private SmartPartInfo smartPartInfo1;
        private SmartPartInfoProvider infoProvider;

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

        #endregion

        #region Methods

        public SkladistePregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Prikaz skladišta - pregled", "Prikaz skladišta - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridData()
        {
            using (BusinessLogic.OtvaranjeSkladista objekt = new BusinessLogic.OtvaranjeSkladista())
            {
                ugdFormPregled.DataSource = objekt.GetMainGridDataSkladista(frmSkladiste.pSkladiste);
                ugdFormPregled.DataBind();
                Utils.Tools.UltraGridStyling(ugdFormPregled);

                if (ugdFormPregled.DisplayLayout.Bands.Count > 0)
                {
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["ID_Skladiste"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Skladiste"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["IDJEDINICAMJERE"].Hidden = true;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["NazivJedinicaMjere"].Hidden = true;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Skladiste"].Header.Caption = "Skladište";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Header.Caption = "Šifra proizvoda";
                    
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Header.VisiblePosition = 1;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Proizvod"].Header.VisiblePosition = 2;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Kolicina"].Header.VisiblePosition = 3;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["NazivJedinicaMjere"].Header.VisiblePosition = 4;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["BasePrice"].Header.VisiblePosition = 5;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Saldo"].Header.VisiblePosition = 6;

                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Kolicina"].Header.Caption = "Količina";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["NazivJedinicaMjere"].Header.Caption = "Mjerna jedinica";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Proizvod"].Header.Caption = "Naziv proizvoda";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Saldo"].Header.Caption = "Ukupna vrijednost";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Saldo"].Width = 120;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Proizvod"].Width = 170;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Width = 100;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["BasePrice"].Header.Caption = "Cijena";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["BasePrice"].Format = "F4";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Saldo"].Format = "F4";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "F4";
                }

                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (row.Index == BusinessLogic.GrupeProizvoda.pSelectedIndex)
                    {
                        ugdFormPregled.ActiveRow = row;
                    }
                }
            }
        }

        #endregion
        
        #region Events


        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        [CommandHandler("Skladiste")]
        public void Skladiste(object sender, EventArgs e)
        {
            UI.Skladista.frmSkladiste objekt = new UI.Skladista.frmSkladiste();

            if (objekt.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                }
                catch { }
                LoadGridData();
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        private void FormDoubleClick(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
