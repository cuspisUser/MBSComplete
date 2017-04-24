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

namespace JavnaNabava.UI.MaticniPodaci
{
    [SmartPart]
    public partial class NacinPlacanjaFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public NacinPlacanjaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("NACIN PLACANJA - pregled", "NACIN PLACANJA - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridNacinPlacanja()
        {
            BusinessLogic.NacinPlacanja objekt = new BusinessLogic.NacinPlacanja();

            ugdNacinPlacanja.DataSource = objekt.GetNacinPlacanjaMainGrid();
            ugdNacinPlacanja.DataBind();
            Utils.Tools.UltraGridStyling(ugdNacinPlacanja);

            foreach (UltraGridRow row in ugdNacinPlacanja.Rows)
            {
                if (row.Index == BusinessLogic.NacinPlacanja.pSelectedIndex)
                {
                    ugdNacinPlacanja.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscNacinPlacanjaForm objekt = new uscNacinPlacanjaForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Način plačanja") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.NacinPlacanja.pSelectedIndex = ugdNacinPlacanja.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridNacinPlacanja();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNacinPlacanja.ActiveRow != null)
            {
                BusinessLogic.NacinPlacanja.pID = Convert.ToInt32(ugdNacinPlacanja.ActiveRow.Cells["ID"].Value);
                BusinessLogic.NacinPlacanja.pNaziv = ugdNacinPlacanja.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscNacinPlacanjaForm objekt = new uscNacinPlacanjaForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Način plačanja") == DialogResult.OK)
                    {
                        BusinessLogic.NacinPlacanja.pSelectedIndex = ugdNacinPlacanja.ActiveRow.Index;
                        LoadGridNacinPlacanja();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdNacinPlacanja.ActiveRow != null)
            {
                BusinessLogic.NacinPlacanja.pID = Convert.ToInt32(ugdNacinPlacanja.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati nacin placanja '{0}-{1}'?", BusinessLogic.CPVOznake.pID, ugdNacinPlacanja.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje nacina placanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.NacinPlacanja objekt = new BusinessLogic.NacinPlacanja();
                    if (!objekt.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja načina plačanja.\nKontaktirajte administratora [Error:00021]");
                    }
                    LoadGridNacinPlacanja();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdNacinPlacanja.ActiveRow != null)
            {
                BusinessLogic.NacinPlacanja.pID = (int)ugdNacinPlacanja.ActiveRow.Cells["ID"].Value;
                BusinessLogic.NacinPlacanja.pNaziv = ugdNacinPlacanja.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscNacinPlacanjaForm objekt = new uscNacinPlacanjaForm(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("Način plačanja") == DialogResult.OK)
                    {
                        BusinessLogic.NacinPlacanja.pSelectedIndex = ugdNacinPlacanja.ActiveRow.Index;
                        LoadGridNacinPlacanja();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.NacinPlacanja.pSelectedIndex = ugdNacinPlacanja.ActiveRow.Index;
            }
            catch { }
            LoadGridNacinPlacanja();
        }

        private void ugdNacinPlacanja_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        private void NacinPlacanjaFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridNacinPlacanja();
        }

        #endregion

    }
}
