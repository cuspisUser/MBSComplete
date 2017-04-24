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
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using NetAdvantage.WorkItems;
using System.Runtime.CompilerServices;
using Placa;

namespace Materijalno.UI.Dokumenti
{
    [SmartPart]
    public partial class IzdatnicaFormPregled : UserControl, ISmartPartInfoProvider
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

        public IzdatnicaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Unos Izdatnice - pregled", "Unos izdatnice - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridData()
        {
            using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
            {
                ugdFormPregled.DataSource = objekt.GetMainGridData();
                ugdFormPregled.DataBind();
                Utils.Tools.UltraGridStyling(ugdFormPregled);

                if (ugdFormPregled.DisplayLayout.Bands.Count > 0)
                {
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Zaduzen"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["ID_Izdatnice"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["UkupanIznos"].Format = "F2";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Ukupno"].Format = "F2";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Kolicina"].Format = "F4";

                    //db - 9.11.2016
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Width = 20;

                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Header.Caption = "Šifra";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["DatumNastajanja"].Header.Caption = "Datum nastajanja";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Skladiste"].Header.Caption = "Skladište";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Stavka"].Header.Caption = "Proizvod";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["UkupanIznos"].Header.Caption = "Ukupno";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Kolicina"].Header.Caption = "Količina";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["NabavnaCijena"].Header.Caption = "Nabavna cijena";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["IDPROIZVOD"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["RedniBroj"].Header.Caption = "Rbr.";


                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Sifra"].Width = 55;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Dokument"].Width = 180;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Skladiste"].Width = 130;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["UkupanIznos"].Width = 80;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Napomena"].Width = 200;

                }
                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (row.Index == BusinessLogic.Izdatnica.pSelectedIndex)
                    {
                        ugdFormPregled.ActiveRow = row;
                    }
                }
            }
        }

        #endregion

        #region Events

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (IzdatnicaForm objekt = new IzdatnicaForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Izdatnica") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.Izdatnica.pSelectedIndex = ugdFormPregled.Rows.Count;
                    }
                    catch { }
                    LoadGridData();

                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                try
                {
                    BusinessLogic.Izdatnica.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);
                }
                catch { }
                using (IzdatnicaForm objekt = new IzdatnicaForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Izdatnica") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.Izdatnica.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Izdatnica.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati Izdatnicu '{0}-{1}'?", BusinessLogic.Izdatnica.pID, ugdFormPregled.ActiveRow.Cells["Sifra"].Value),
                    "Brisanje Izdatnice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                    {
                        StringBuilder message = new StringBuilder();

                        if (!objekt.Delete(message))
                        {
                            MessageBox.Show(message.ToString());
                        }
                        try
                        {
                            BusinessLogic.Izdatnica.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Izdatnica.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (IzdatnicaForm objekt = new IzdatnicaForm(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("Izdatnica") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.Izdatnica.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Izdatnica.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        [CommandHandler("Ispis")]
        public void Ispis(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnica.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                BusinessLogic.Izdatnica.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                {
                    rpt.SetDataSource(objekt.GetIzdatnicaIspis());

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

        //db - 10.11.2016
        [CommandHandler("IspisOzn")]
        public void IspisOzn(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnicaIspisOznacenih.rpt");
                //rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnica2.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                Dictionary<int, int> oznaceni = VratiOznaceneIzdatnice(ugdFormPregled.Rows);

                if (oznaceni.Count > 0)
                {
                    BusinessLogic.Izdatnica.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                    using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                    {
                        rpt.SetDataSource(objekt.GetIzdatnicaIspisOznaceni(oznaceni));

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

            //if (ugdFormPregled.ActiveRow != null)
            //{
            //    Dictionary<int, int> oznaceni = VratiOznaceneIzdatnice(ugdFormPregled.Rows);

            //    if (oznaceni.Count > 0)
            //    {
            //        BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica();

            //        ReportDocument rpt = new ReportDocument();
            //        rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpIzdatnica.rpt");

            //        // Set connection string from config in existing LogonProperties
            //        rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            //        rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            //        rpt.DataSourceConnections[0].IntegratedSecurity = false;

            //        rpt.SetDataSource(objekt.GetIzdatnicaIspisOznaceni(oznaceni));

            //        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            //        PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            //        if (item == null)
            //        {
            //            item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            //        }
            //        item.Izvjestaj = rpt;
            //        item.Activate();
            //        item.Show(item.Workspaces["main"]);
            //    }
            //}
        }

        private Dictionary<int, int> VratiOznaceneIzdatnice(RowsCollection rowsCollection)
        {
            Dictionary<int, int> oznaceni = new Dictionary<int, int>();

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rowsCollection)
            {
                if (row.Cells["Ozn"].Value.ToString() == "True")
                {
                    oznaceni.Add(Convert.ToInt32(row.Cells["ID"].Value), Convert.ToInt32(row.Cells["Sifra"].Value));
                }
            }

            return oznaceni;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Izdatnica.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        private void FormDoubleClick(object sender, EventArgs e)
        {
            //Update(null, null);
        }

        #endregion

        private void ugdFormPregled_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D0)
            {
                if (ugdFormPregled.DisplayLayout.Bands.Count > 0)
                {
                    if (ugdFormPregled.DisplayLayout.Bands[0] == ugdFormPregled.ActiveRow.Band)
                    {
                        if (ugdFormPregled.ActiveRow.Cells["Zaduzen"].Value.ToString() == "False")
                        {
                            DialogResult result = MessageBox.Show("želite li zadužiti označenu izdatnicu na skladište?", "Izdatnica na skladište", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                                {
                                    StringBuilder message = new StringBuilder();

                                    objekt.IzdatnicaNaSkladiste(message, Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value));

                                    if (message.Length > 0)
                                    {
                                        MessageBox.Show(message.ToString());
                                    }
                                    else
                                    {
                                        MessageBox.Show("Izdatnica usješno zadužena!");
                                    }
                                }

                                BusinessLogic.Izdatnica.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                                LoadGridData();
                                this.Cursor = Cursors.Default;
                            }
                        }
                    }
                }
            }
        }
    }
}
