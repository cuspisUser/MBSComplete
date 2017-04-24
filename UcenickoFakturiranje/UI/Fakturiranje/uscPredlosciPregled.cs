using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Commands;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.Diagnostics;

using Mipsed7.DataAccessLayer;
using UcenickoFakturiranje.BusinessLogic;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    [SmartPart]
    public partial class uscPredlosciPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        #region Svojstva

        public int pID
        {
            get;
            set;
        }

        #endregion

        #region Dogadaji

        private static bool select_deselect = false;

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscPredlosci uscPredlosci = new uscPredlosci(Enums.FormEditMode.Insert, -1))
            {
                uscPredlosci.ShowDialogForm("Zaduživanje u predlošku");
                try
                {
                    BusinessLogic.Predlosci.pSelectedIndex = ugdPredlosci.ActiveRow.Index;
                }
                catch { }
                LoadGridPredlosci();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdPredlosci.ActiveRow != null)
            {
                pID = (int)ugdPredlosci.ActiveRow.Cells["ID Predloška"].Value;

                using (uscPredlosci uscPredlosci = new uscPredlosci(Enums.FormEditMode.Update, pID))
                {
                    uscPredlosci.ShowDialogForm("Zaduživanje u predlošku");
                    BusinessLogic.Predlosci.pSelectedIndex = ugdPredlosci.ActiveRow.Index;
                    LoadGridPredlosci();
                }
            }
        }
        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdPredlosci.ActiveRow != null)
            {
                Predlosci.pId_predlozak = Convert.ToInt32(this.ugdPredlosci.ActiveRow.Cells["ID Predloška"].Value);
                if (MessageBox.Show(string.Format("Obrisati predložak '{0}-{1}'?", Predlosci.pId_predlozak, this.ugdPredlosci.ActiveRow.Cells["Naziv predloška"].Value),
                    "Brisanje predloška", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Predlosci clsPredlosci = new Predlosci();
                    clsPredlosci.DeletePredlosci();
                    LoadGridPredlosci();
                }
            }

        }
        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Predlosci.pSelectedIndex = ugdPredlosci.ActiveRow.Index;
            }
            catch { }
            LoadGridPredlosci();
        }


        [CommandHandler("SelectDeselect")]
        public void SelectDeselect(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Predlosci.pSelectedIndex = ugdPredlosci.ActiveRow.Index;
            }
            catch { }


            foreach (UltraGridRow row in ugdPredlosci.Rows)
            {
                UpdatePredlosciAktivnost((int)row.Cells["ID Predloška"].Value, select_deselect, BusinessLogic.Predlosci.pSelectedIndex);
            }
            if (!select_deselect)
            {
                select_deselect = true;
            }
            else
            {
                select_deselect = false;
            }
            LoadGridPredlosci();
        }

        private void ugdPredlosci_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        private void ugdPredlosci_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (ugdPredlosci.DisplayLayout.Bands.Count > 0)
                if (ugdPredlosci.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    UpdatePredlosciAktivnost((int)ugdPredlosci.ActiveRow.Cells["ID Predloška"].Value, !(bool)ugdPredlosci.ActiveRow.Cells["Aktivan za obračun"].Value, ugdPredlosci.ActiveRow.Index);

                    try
                    {
                        BusinessLogic.Predlosci.pSelectedIndex = ugdPredlosci.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridPredlosci();
                }
        }

        #endregion

        #region Metode

        public uscPredlosciPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Predlošci - pregled", "Predlošci - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void uscPredlosciPregled_Load(object sender, EventArgs e)
        {
            LoadGridPredlosci();
        }

        private void LoadGridPredlosci()
        {
            Predlosci Predlosci = new Predlosci();
            ugdPredlosci.DataSource = Predlosci.GetPredlosci();
            ugdPredlosci.DataBind();
            ugdPredlosci.UpdateData();

            Utils.Tools.UltraGridStyling(ugdPredlosci);

            if (ugdPredlosci.DisplayLayout.Bands.Count > 0)
                if (ugdPredlosci.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdPredlosci.DisplayLayout.Bands[0].Columns[4].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdPredlosci.DisplayLayout.Bands[0].Columns[4].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdPredlosci.DisplayLayout.Bands[0].Columns["Naziv predloška"].Width = 200;
                }

            foreach (UltraGridRow row in ugdPredlosci.Rows)
            {
                if (row.Index == BusinessLogic.Predlosci.pSelectedIndex)
                {
                    ugdPredlosci.ActiveRow = row;
                }
            }
        }

        private void UpdatePredlosciAktivnost(int id_predloska, bool aktivan, int index)
        {
            Predlosci Predlosci = new Predlosci();
            Predlosci.UpdatePredlosciAktivnost(id_predloska, aktivan);
            ugdPredlosci.Rows[index].Activate();
        }

        #endregion
    }
}
