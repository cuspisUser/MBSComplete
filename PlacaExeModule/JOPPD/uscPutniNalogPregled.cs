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
using Infragistics.Win.UltraWinGrid;

namespace JOPPD
{
    [SmartPart]
    public partial class uscPutniNalogPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

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

        #region Metode

        public uscPutniNalogPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Putni nalog - pregled", "Putni nalog - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridPutniNalog()
        {
            BusinessLogic element = new BusinessLogic();

            ugdRegistarNabave.DataSource = element.GetPutniNalog().DefaultView;
            ugdRegistarNabave.DataBind();

            Tools.UltraGridStyling(ugdRegistarNabave);

            if (ugdRegistarNabave.DisplayLayout.Bands.Count > 0)
            {
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["ID_Likvidator"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["IDRADNOMJESTO"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["ID_NacinIsplate"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["TroskoviPutovanja"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["TroskoviVlastitogVozila"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["OstaliTroskovi"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["Dnevnice"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["Trošak putnog naloga"].Format = "N2";
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["IsTroskoviSmjestaja"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["IsDrugiTroskovi"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["IsTroskoviAutoputa"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["TroskoviSmjestaja"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["Akontacija"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["DatumObracuna"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["VrstaDjelatnika"].Hidden = true;
            }


            foreach (UltraGridRow row in ugdRegistarNabave.Rows)
            {
                if (row.Index == BusinessLogic.pSelectedIndex)
                {
                    ugdRegistarNabave.ActiveRow = row;
                }
            }
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscPutniNalog user_control = new uscPutniNalog(Enums.FormEditMode.Insert))
            {
                if (user_control.ShowDialogForm("Unos putnog naloga") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridPutniNalog();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdRegistarNabave.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdRegistarNabave.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pID_Radnik = (int)ugdRegistarNabave.ActiveRow.Cells["Šifra radnika"].Value;
                BusinessLogic.pDatumPutnogNaloga = (DateTime)ugdRegistarNabave.ActiveRow.Cells["Datum putnog naloga"].Value;
                BusinessLogic.pID_Likvidator = (int)ugdRegistarNabave.ActiveRow.Cells["ID_Likvidator"].Value;
                BusinessLogic.pSifraPutnogNaloga = ugdRegistarNabave.ActiveRow.Cells["Šifra putnog naloga"].Value.ToString();
                BusinessLogic.pID_NacinIsplate = (int)ugdRegistarNabave.ActiveRow.Cells["ID_NacinIsplate"].Value;
                BusinessLogic.pTroskoviPutovanja = (decimal)ugdRegistarNabave.ActiveRow.Cells["TroskoviPutovanja"].Value;
                BusinessLogic.pTroskoviVlastitogVozila = (decimal)ugdRegistarNabave.ActiveRow.Cells["TroskoviVlastitogVozila"].Value;
                BusinessLogic.pOstaliTroskovi = (decimal)ugdRegistarNabave.ActiveRow.Cells["OstaliTroskovi"].Value;
                BusinessLogic.pDnevnice = (decimal)ugdRegistarNabave.ActiveRow.Cells["Dnevnice"].Value;
                BusinessLogic.pTroskoviSmjestaja = (decimal)ugdRegistarNabave.ActiveRow.Cells["TroskoviSmjestaja"].Value;
                BusinessLogic.pIsTroskoviSmjestaja = (bool)ugdRegistarNabave.ActiveRow.Cells["IsTroskoviSmjestaja"].Value;
                BusinessLogic.pIsTroskoviAutoputa = (bool)ugdRegistarNabave.ActiveRow.Cells["IsTroskoviAutoputa"].Value;
                BusinessLogic.pIsDrugiTroskovi = (bool)ugdRegistarNabave.ActiveRow.Cells["IsDrugiTroskovi"].Value;
                BusinessLogic.pAkontacija = (decimal)ugdRegistarNabave.ActiveRow.Cells["Akontacija"].Value;
                if (ugdRegistarNabave.ActiveRow.Cells["DatumObracuna"].Value != DBNull.Value)
                    BusinessLogic.pDatumObracuna = (DateTime)ugdRegistarNabave.ActiveRow.Cells["DatumObracuna"].Value;
                else
                    BusinessLogic.pDatumObracuna = null;
                BusinessLogic.pVrstaRadnika = Convert.ToInt16(ugdRegistarNabave.ActiveRow.Cells["VrstaDjelatnika"].Value);

                using (uscPutniNalog user_control = new uscPutniNalog(Enums.FormEditMode.Update))
                {
                    if (user_control.ShowDialogForm("Unos putnog naloga") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridPutniNalog();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdRegistarNabave.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdRegistarNabave.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pSifraPutnogNaloga = ugdRegistarNabave.ActiveRow.Cells["Šifra putnog naloga"].Value.ToString();

                if (MessageBox.Show(string.Format("Obrisati putni nalog '{0}-{1}'?", BusinessLogic.pID, BusinessLogic.pSifraPutnogNaloga),
                    "Brisanje putnog naloga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic element = new BusinessLogic();

                    if (element.ProvjeraJOPPD())
                    {

                        element.DeletePutniNalog();
                    }
                    else
                    {
                        MessageBox.Show("Nije moguće brisati putni nalog za koji postoji JOPPD!\n\rPrvo obrišite JOPPD da bi mogli putni nalog.");
                    }

                    try
                    {
                        BusinessLogic.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridPutniNalog();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
            }
            catch { }
            LoadGridPutniNalog();
        }

        [CommandHandler("Virmani")]
        public void Virmani(object sender, EventArgs e)
        {
            if (this.ugdRegistarNabave.ActiveRow != null)
            {
                this.Tag = VratiOznacenePutneNaloge();

                if (this.Tag.ToString() != "False")
                {
                    this.Controls["ugdRegistarNabave"].Text = "Putni nalog";
                    VirmaniWorkItemUser item = this.Controller.WorkItem.Items.Get<VirmaniWorkItemUser>("Putni nalog");
                InitializeAgain:
                    if (item != null)
                    {
                        item.Terminate();
                        item.Dispose();
                        item = null;
                        goto InitializeAgain;
                    }
                    else
                    {
                        item = this.Controller.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Putni nalog");
                    }

                    item.Show(item.Workspaces["main"]);
                }
            }
        }

        private string VratiOznacenePutneNaloge()
        {
            string putni_nalozi = string.Empty;

            int broj_obracuna = 0;
            int nacin_isplate = 0;
            int broj_oznacenih = 0;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdRegistarNabave.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                {
                    broj_obracuna++;
                }
            }
            broj_oznacenih = broj_obracuna;

            for (int i = 0; i < ugdRegistarNabave.Rows.Count; i++)
            {
                if (ugdRegistarNabave.Rows[i].Cells["Ozn"].Value.ToString() == "True")
                {
                    broj_obracuna--;
                    if (broj_obracuna == 0)
                    {
                        putni_nalozi += "'" + ugdRegistarNabave.Rows[i].Cells["ID"].Value.ToString().Trim() + "'";
                    }
                    else
                    {
                        putni_nalozi += "'" + ugdRegistarNabave.Rows[i].Cells["ID"].Value.ToString().Trim() + "',";
                    }

                    if (ugdRegistarNabave.Rows[i].Cells["ID_NacinIsplate"].Value.ToString() != "2")
                    {
                        nacin_isplate++;
                    }
                }
            }

            if (broj_oznacenih == 0)
            {
                return "False";
            }
            if (nacin_isplate > 0)
            {
                MessageBox.Show("Virmani se mogu kreirati samo kod putnih naloga\nkoji imaju određenu isplatu na tekući račun", "Putni nalozi");
                if (nacin_isplate == broj_oznacenih)
                    return "False";
            }

            return putni_nalozi;
        }

        private void ugdRegistarNabave_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        private void uscRegistarNabavePregled_Load(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
            }
            catch { }
            LoadGridPutniNalog();
        }

        #endregion
    }
}
