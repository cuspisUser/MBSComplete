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
using Deklarit.Practices.CompositeUI.Workspaces;
using CrystalDecisions.CrystalReports.Engine;
using NetAdvantage.WorkItems;

namespace Materijalno.UI.Dokumenti
{
    [SmartPart]
    public partial class PrimkaFormPregled : UserControl, ISmartPartInfoProvider
    {
        private static string prijenos = "";

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

        public PrimkaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Unos Primke - pregled", "Unos Primke - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridData()
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                ugdFormPregled.DataSource = objekt.GetMainGridData();
                ugdFormPregled.DataBind();
                Utils.Tools.UltraGridStyling(ugdFormPregled);

                if (ugdFormPregled.DisplayLayout.Bands.Count > 0)
                {
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["ID_Skladista"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["ID_Primke"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["NazivPartner"].Hidden = true;

                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Neto"].Format = "F2";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Bruto"].Format = "F2";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Uk.Bruto"].Format = "F2";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Uk.Neto"].Format = "F2";

                    ugdFormPregled.DisplayLayout.Bands[0].Columns["NetoPrimke"].Format = "F2";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["BrutoPrimke"].Format = "F2";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["PDVPrimke"].Format = "F2";

                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Preneseno"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Width = 55;

                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Opis"].Header.Caption = "Šifra          Opis";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["DatumNastajanja"].Header.Caption = "Datum nastajanja";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["NazivPartner"].Header.Caption = "Partner";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["NazivPartner"].Width = 120;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["BrojUlaznogDokumenta"].Header.Caption = "Ulazni dokument";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["NetoPrimke"].Header.Caption = "Neto";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["BrutoPrimke"].Header.Caption = "Bruto";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["PDVPrimke"].Header.Caption = "PDV";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Preneseno"].Header.Caption = "Zaduženo na skladište";
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Preneseno"].Width = 80;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Skladiste"].Header.Caption = "Skladište";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["RedniBroj"].Header.Caption = "Rbr.";

                    ugdFormPregled.DisplayLayout.Bands[1].Columns["NazivProizvod"].Header.Caption = "Proizvod";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["NazivJedinicaMjere"].Header.Caption = "Mjerna jedinica";
                    ugdFormPregled.DisplayLayout.Bands[1].Columns["Kolicina"].Header.Caption = "Količina";

                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Width = 55;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Opis"].Width = 100;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["DatumNastajanja"].Width = 65;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["BrojUlaznogDokumenta"].Width = 65;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Skladiste"].Width = 130;


                }
                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (row.Index == BusinessLogic.Primka.pSelectedIndex)
                    {
                        ugdFormPregled.ActiveRow = row;
                    }
                }
            }
        }

        private Dictionary<int, int> GetOznacenePrimke()
        {
            Dictionary<int, int> primka = new Dictionary<int, int>();

            foreach (UltraGridRow row in ugdFormPregled.Rows)
            {
                if ((bool)row.Cells["Ozn"].Value && !(bool)row.Cells["Preneseno"].Value)
                {
                    primka.Add((int)row.Cells["ID"].Value, (int)row.Cells["ID_Skladista"].Value);
                }
            }

            return primka;
        }

        private void PostavniDaJePreneseno(Dictionary<int, int> primke, StringBuilder message)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                objekt.SetPreneseno(primke, message);
            }
        }

        #endregion
        
        #region Events

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            BusinessLogic.Primka.kontrola_stavke = false;
            BusinessLogic.Primka.pPrimkaStavke = null;
            using (PrimkaForm objekt = new PrimkaForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Primka") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.Primka.pSelectedIndex = ugdFormPregled.Rows.Count;
                    }
                    catch { }
                    LoadGridData();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            BusinessLogic.Primka.kontrola_stavke = false;
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Primka.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                using (PrimkaForm objekt = new PrimkaForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Primka") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.Primka.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
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
                BusinessLogic.Primka.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati Primku '{0}-{1}'?", BusinessLogic.Primka.pID, ugdFormPregled.ActiveRow.Cells["Opis"].Value),
                    "Brisanje Primke", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
                    {
                        StringBuilder message = new StringBuilder();

                        if (ugdFormPregled.ActiveRow.Cells["Preneseno"].Value.ToString() == "True")
                        {
                            MessageBox.Show("Nije moguće brisati priimku koja je prenesena na skladiste!");
                        }
                        else
                        {

                            if (!objekt.Delete(message))
                            {
                                MessageBox.Show(message.ToString());
                            }
                            try
                            {
                                BusinessLogic.Primka.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                            }
                            catch { }
                            LoadGridData();
                        }
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.Primka.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (PrimkaForm objekt = new PrimkaForm(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("Primka") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.Primka.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
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
                BusinessLogic.Primka.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
            prijenos = "";
        }

        [CommandHandler("Ispis")]
        public void Ispis(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpPrimka.rpt");
                //rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpPrimka2.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                BusinessLogic.Primka.pID = (int)ugdFormPregled.ActiveRow.Cells["ID"].Value;

                using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
                {
                    rpt.SetDataSource(objekt.GetPrimkaIspis());

                    //db - 26.10.2016
                    //rpt.Subreports[0].SetDataSource(objekt.GetPrimkaGrupe((int)BusinessLogic.Primka.pID));
               
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

        [CommandHandler("PrimkaSkladiste")]
        public void PrimkaSkladiste(object sender, EventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("Jeste li sigurni da zelite napraviti prijenos?", "Prijenos na skladište", MessageBoxButtons.YesNo);

            if (Dialog == DialogResult.Yes)
            {
                StringBuilder message = new StringBuilder();

                //         ID   ID_Skladiste
                Dictionary<int, int> primke = GetOznacenePrimke();

                if (primke.Count > 0)
                {
                    using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
                    {
                        if (objekt.InsertStavkeSkladiste(primke, message))
                        {
                            try
                            {
                                PostavniDaJePreneseno(primke, message);
                                BusinessLogic.Primka.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                                MessageBox.Show("Prijenos na skladište je uspješno izvršen!");
                            }
                            catch { }
                            LoadGridData();
                        }

                        if (message.Length > 0)
                        {
                            MessageBox.Show(message.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Označene primke su već prenesene na skladište!");
                }
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Primka.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
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
            prijenos += e.KeyChar;
            int brojac = 0;

            if (prijenos == "prn1")
            {
                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (brojac > 150)
                    {
                        break;
                    }
                    brojac++;
                    row.Cells["Ozn"].Value = true;
                }

                ugdFormPregled.Refresh();
                prijenos = "";
            }

            if (prijenos == "prn2")
            {
                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (brojac > 150 & brojac < 300)
                    {
                        row.Cells["Ozn"].Value = true;
                    }
                    brojac++;
                }

                ugdFormPregled.Refresh();
                prijenos = "";
            }

            if (prijenos == "prn3")
            {
                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (brojac >= 300 && brojac < 450)
                    {
                        row.Cells["Ozn"].Value = true;
                    }
                    brojac++;
                }

                ugdFormPregled.Refresh();
                prijenos = "";
            }

            if (prijenos == "prn4")
            {
                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (brojac >= 450)
                    {
                        row.Cells["Ozn"].Value = true;
                    }
                    brojac++;
                }

                ugdFormPregled.Refresh();
                prijenos = "";
            }
        }
    }
}
