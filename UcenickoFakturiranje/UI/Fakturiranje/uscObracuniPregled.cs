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
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Mipsed7.DataAccessLayer;
using UcenickoFakturiranje.BusinessLogic;
using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using Placa;
using Infragistics.Win.UltraWinGrid;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    [SmartPart]
    public partial class uscObracuniPregled : UserControl, ISmartPartInfoProvider, IFilteredView
    {

        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

        private SmartPartInfo smartPartInfo1;
        private SmartPartInfoProvider infoProvider;
        private DataRow m_FillByRow;
        private DataRow m_RowSelected { get; set; }
        private string m_FillByMethod = "";
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller 
        { 
            get; set; 
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
            }
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
            }
        }

        public string FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
            }
        }
        #endregion

        #region Dogadaji

        private void uscObracuniPregled_Load(object sender, EventArgs e)
        {
            LoadGridObracuni();
        }

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscObracuni uscObracuni = new uscObracuni(Enums.FormEditMode.Insert, null))
            {
                uscObracuni.uneObracunKolicina.Enabled = true;
                uscObracuni.ShowDialogForm("Podaci obračuna");
                try
                {
                    BusinessLogic.Obracuni.pSelectedIndex = ugdObracuni.ActiveRow.Index;
                }
                catch { }
                LoadGridObracuni();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdObracuni.ActiveRow != null)
            {
                
                Obracuni.pID = (int)ugdObracuni.ActiveRow.Cells["ID"].Value;
                Obracuni.pNaziv = ugdObracuni.ActiveRow.Cells["Naziv"].Value.ToString();
                Obracuni.pMjesecObracuna = (int)ugdObracuni.ActiveRow.Cells["Za mjesec"].Value;
                Obracuni.pGodinaObracuna = (int)ugdObracuni.ActiveRow.Cells["Za godinu"].Value;
                Obracuni.pkolicinaZaObracun = (int)ugdObracuni.ActiveRow.Cells["Količina"].Value;
                Obracuni.pValutaPlacanja = (DateTime)ugdObracuni.ActiveRow.Cells["Valuta plačanja"].Value;
                Obracuni.zaduzen = Convert.ToBoolean(ugdObracuni.ActiveRow.Cells["Kreirani računi"].Value);

                using (uscObracuni uscObracuni = new uscObracuni(Enums.FormEditMode.Update, Obracuni.pID))
                {
                    uscObracuni.uneObracunKolicina.Enabled = false;
                    uscObracuni.ShowDialogForm("Podaci obračuna");
                    BusinessLogic.Obracuni.pSelectedIndex = ugdObracuni.ActiveRow.Index;
                    LoadGridObracuni();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.ugdObracuni.ActiveRow != null)
            {
                Obracuni.pID = (int)ugdObracuni.ActiveRow.Cells["ID"].Value;
                Obracuni.pNaziv = ugdObracuni.ActiveRow.Cells["Naziv"].Value.ToString();
                Obracuni.pMjesecObracuna = (int)ugdObracuni.ActiveRow.Cells["Za mjesec"].Value;
                Obracuni.pGodinaObracuna = (int)ugdObracuni.ActiveRow.Cells["Za godinu"].Value;

                using (uscObracuni uscObracuni = new uscObracuni(Enums.FormEditMode.Copy, Obracuni.pID))
                {
                    uscObracuni.ShowDialogForm("Podaci obračuna");
                    BusinessLogic.Obracuni.pSelectedIndex = ugdObracuni.ActiveRow.Index;
                    LoadGridObracuni();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdObracuni.ActiveRow != null)
            {
                if (!(bool)ugdObracuni.ActiveRow.Cells["Kreirani računi"].Value)
                {
                    Obracuni.pID = Convert.ToInt32(ugdObracuni.ActiveRow.Cells["ID"].Value);
                    if (MessageBox.Show(string.Format("Obrisati obračun '{0}-{1}'?", Obracuni.pID, this.ugdObracuni.ActiveRow.Cells["Naziv"].Value),
                        "Brisanje obračuna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Obracuni clsObracuni = new Obracuni();

                        if (clsObracuni.ObrisiObracun())
                        {
                            LoadGridObracuni();
                        }
                        else
                        {
                            MessageBox.Show("Dogodila se greška kod brisanja obračuna.\nKontaktirajte administratora [Error:00004]");
                            LoadGridObracuni();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nije moguće brisati obračun koji je zaključan!");
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Obracuni.pSelectedIndex = ugdObracuni.ActiveRow.Index;
            }
            catch { }
            LoadGridObracuni();
        }

        private void ugdObracuni_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }


        [CommandHandler("Racuni")]
        public void Racuni(object sender, EventArgs e)
        {
            if (this.ugdObracuni.ActiveRow != null)
            {
                Obracuni.pID = Convert.ToInt32(ugdObracuni.ActiveRow.Cells["ID"].Value);
                Obracuni.pNaziv = ugdObracuni.ActiveRow.Cells["Naziv"].Value.ToString();

                BusinessLogic.Obracuni objekt = new BusinessLogic.Obracuni();

                bool zaduzen = objekt.GetZaduzen();
                DialogResult dialogResult = DialogResult.Yes;

                if (zaduzen)
                {
                    dialogResult = MessageBox.Show("Već su napravljeni računi za obračun\n\rJeste li sigurni da ih želite ponovno napraviti?", "Prijenos", MessageBoxButtons.YesNo);
                }

                if (dialogResult == DialogResult.Yes)
                {
                    if (objekt.ProvjeraUcenikPartner())
                    {
                        using (uscVirmaniUstanova ustanova = new uscVirmaniUstanova())
                        {
                            if (ustanova.ShowDialogForm("Ustanova") == DialogResult.OK)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                if (objekt.CreateRacuni())
                                {
                                    MessageBox.Show("Uspješno kreirani računi!");
                                    objekt.ZaduziObracun();
                                    BusinessLogic.Obracuni.pSelectedIndex = ugdObracuni.ActiveRow.Index;
                                    LoadGridObracuni();
                                }
                                else
                                {
                                    MessageBox.Show("Dogodila se greška prilikom kreiranja računa a odabrani obračun.\n\rJavite se u T4S.");
                                }

                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nisu svi učenici koji se nalaze u obračunu preneseni u partnere.\n\rPrenesite sve učenike iz obračuna u partnere pa pokušajte ponovno.");
                    }
                }
            }
        }

        [CommandHandler("RacuniPojedinacno")]
        public void RacuniPojedinacno(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Obracuni.pSelectedIndex = ugdObracuni.ActiveRow.Index;
            }
            catch { }
            LoadGridObracuni();
        }

        #endregion

        # region Izvještaji
        [CommandHandler("Rekapitulacija")]
        public void Izvjestaji(object sender, EventArgs e)
        {
            if (ugdObracuni.ActiveRow != null)
            {
                BusinessLogic.Obracuni objekt = new BusinessLogic.Obracuni();

                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpRkapitulacijaUF.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                rpt.SetDataSource(objekt.GetRekapitulacijaIspis((int)ugdObracuni.ActiveRow.Cells["ID"].Value));

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

        [CommandHandler("RekapitulacijaRazrednoOdjeljenje")]
        public void IzvjestajiRazrednoOdjeljenje(object sender, EventArgs e)
        {
            if (ugdObracuni.ActiveRow != null)
            {
                BusinessLogic.Obracuni objekt = new BusinessLogic.Obracuni();

                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpRkapitulacijaRazrednoOdjeljenjeUF.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                BusinessLogic.Obracuni.pID = (int)ugdObracuni.ActiveRow.Cells["ID"].Value;

                using (uscRekapitulacijaRazrednoOdjeljenje objekt2 = new uscRekapitulacijaRazrednoOdjeljenje())
                {
                    if (objekt2.ShowDialogForm("Razredna odjeljenja") == DialogResult.OK)
                    {
                        rpt.SetDataSource(objekt.GetRekapitulacijaRazrednoOdjeljenjeIspis((int)BusinessLogic.Obracuni.pID, BusinessLogic.Obracuni.pRazrednoOdjeljenje));

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
        }
        # endregion

        #region Metode

        public uscObracuniPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Obračun - pregled", "Obračun - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public void LoadGridObracuni()
        {
            Obracuni Obracuni = new Obracuni();
            ugdObracuni.DataSource = Obracuni.GetObracuni();

            ugdObracuni.DataBind();
            ugdObracuni.UpdateData();

            Utils.Tools.UltraGridStyling(ugdObracuni);

            if (ugdObracuni.DisplayLayout.Bands.Count > 0)
                if (ugdObracuni.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdObracuni.DisplayLayout.Bands[0].Columns["Naziv"].Width = 200;
                }

            foreach (UltraGridRow row in ugdObracuni.Rows)
            {
                if (row.Index == BusinessLogic.Obracuni.pSelectedIndex)
                {
                    ugdObracuni.ActiveRow = row;
                }
            }
        }

        #endregion
    }
}
