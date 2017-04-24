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
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using Placa;
using System.Runtime.CompilerServices;
using Deklarit.Practices.CompositeUI.Workspaces;
using NetAdvantage.WorkItems;
using Infragistics.Win.UltraWinGrid;

namespace Materijalno.UI.Dokumenti
{
    [SmartPart]
    public partial class UnosMeduskladisniceFormPregled : UserControl, ISmartPartInfoProvider
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

        public UnosMeduskladisniceFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Unos međuskladišnice - pregled", "Unos međuskladišnice - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridData()
        {
            BusinessLogic.Meduskladisnica objekt = new BusinessLogic.Meduskladisnica();

            ugdFormPregled.DataSource = objekt.GetMainGridData();
            ugdFormPregled.DataBind();
            Utils.Tools.UltraGridStyling(ugdFormPregled);

            if (ugdFormPregled.DisplayLayout.Bands.Count > 0)
            {
                ugdFormPregled.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;

                ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Header.Caption = "Šifra";
                ugdFormPregled.DisplayLayout.Bands[0].Columns["IzlaznoSkladiste"].Header.Caption = "Izlazno skladište";
                ugdFormPregled.DisplayLayout.Bands[0].Columns["UlaznoSkladiste"].Header.Caption = "Ulazno skladište";
                ugdFormPregled.DisplayLayout.Bands[1].Columns["ID_Meduskladisnice"].Hidden = true;
                ugdFormPregled.DisplayLayout.Bands[1].Columns["Kolicina"].Header.Caption = "Količina";
                ugdFormPregled.DisplayLayout.Bands[1].Columns["Kolicina"].Format = "F4";
                ugdFormPregled.DisplayLayout.Bands[1].Columns["IDPROIZVOD"].Header.Caption = "Šifra";

                ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Width = 80;
                ugdFormPregled.DisplayLayout.Bands[0].Columns["IzlaznoSkladiste"].Width = 100;
            }
            foreach (UltraGridRow row in ugdFormPregled.Rows)
            {
                if (row.Index == BusinessLogic.Meduskladisnica.pSelectedIndex)
                {
                    ugdFormPregled.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Events

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (UnosMeduskladisniceStavkeForm objekt = new UnosMeduskladisniceStavkeForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("UnosMeduskladisnice") == DialogResult.OK)
                    LoadGridData();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Meduskladisnica.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                using (UnosMeduskladisniceStavkeForm objekt = new UnosMeduskladisniceStavkeForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("UnosMeduskladisnice") == DialogResult.OK)
                        LoadGridData();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Meduskladisnica.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati Međuskladišnicu '{0}-{1}'?", BusinessLogic.Meduskladisnica.pID, ugdFormPregled.ActiveRow.Cells["Sifra"].Value),
                    "Brisanje Međuskladišnice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Meduskladisnica objekt = new BusinessLogic.Meduskladisnica();
                    StringBuilder message = new StringBuilder();

                    if (!objekt.Delete(message))
                    {
                        MessageBox.Show(message.ToString());
                    }
                    LoadGridData();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Meduskladisnica.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (UnosMeduskladisniceStavkeForm objekt = new UnosMeduskladisniceStavkeForm(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("UnosMeduskladisnice") == DialogResult.OK)
                        LoadGridData();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridData();
        }

        [CommandHandler("Ispis")]
        public void Ispis(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpMeduskladisnica.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                BusinessLogic.Meduskladisnica.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (BusinessLogic.Meduskladisnica objekt = new BusinessLogic.Meduskladisnica())
                {
                    rpt.SetDataSource(objekt.GetMeduskladisnicaIspis());

                    KORISNIKDataSet set2 = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set2);

                    if (set2.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("Adresa", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                    }

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Activate();
                    item.Show(item.Workspaces["main"]);
                }
            }
        }

        private void UnosMeduskladisniceFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void ugdFormPregled_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion
    }
}
