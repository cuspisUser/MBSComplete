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
    public partial class NacinIsporukeFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public NacinIsporukeFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("NACIN ISPORUKE - pregled", "NACIN ISPORUKE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridNacinIsporuke()
        {
            BusinessLogic.NacinIsporuke objekt = new BusinessLogic.NacinIsporuke();

            ugdNacinIsporuke.DataSource = objekt.GetNacinIsporukeMainGrid();
            ugdNacinIsporuke.DataBind();
            Utils.Tools.UltraGridStyling(ugdNacinIsporuke);

            foreach (UltraGridRow row in ugdNacinIsporuke.Rows)
            {
                if (row.Index == BusinessLogic.NacinIsporuke.pSelectedIndex)
                {
                    ugdNacinIsporuke.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscNacinIsporukeForm objekt = new uscNacinIsporukeForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Način isporuke") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.NacinIsporuke.pSelectedIndex = ugdNacinIsporuke.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridNacinIsporuke();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNacinIsporuke.ActiveRow != null)
            {
                BusinessLogic.NacinIsporuke.pID = Convert.ToInt32(ugdNacinIsporuke.ActiveRow.Cells["ID"].Value);
                BusinessLogic.NacinIsporuke.pNaziv = ugdNacinIsporuke.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscNacinIsporukeForm objekt = new uscNacinIsporukeForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Način isporuke") == DialogResult.OK)
                    {
                        BusinessLogic.NacinIsporuke.pSelectedIndex = ugdNacinIsporuke.ActiveRow.Index;
                        LoadGridNacinIsporuke();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdNacinIsporuke.ActiveRow != null)
            {
                BusinessLogic.NacinIsporuke.pID = Convert.ToInt32(ugdNacinIsporuke.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati nacin isporuke '{0}-{1}'?", BusinessLogic.CPVOznake.pID, ugdNacinIsporuke.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje način isporuke", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.NacinIsporuke objekt = new BusinessLogic.NacinIsporuke();
                    if (!objekt.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja načina isporuke.\nKontaktirajte administratora [Error:00022]");
                    }
                    LoadGridNacinIsporuke();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdNacinIsporuke.ActiveRow != null)
            {
                BusinessLogic.NacinIsporuke.pID = (int)ugdNacinIsporuke.ActiveRow.Cells["ID"].Value;
                BusinessLogic.NacinIsporuke.pNaziv = ugdNacinIsporuke.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscNacinIsporukeForm objekt = new uscNacinIsporukeForm(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("Način isporuke") == DialogResult.OK)
                    {
                        BusinessLogic.NacinIsporuke.pSelectedIndex = ugdNacinIsporuke.ActiveRow.Index;
                        LoadGridNacinIsporuke();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.NacinIsporuke.pSelectedIndex = ugdNacinIsporuke.ActiveRow.Index;
            }
            catch { }
            LoadGridNacinIsporuke();
        }

        private void ugdNacinIsporuke_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        private void NacinIsporukeFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridNacinIsporuke();
        }

        #endregion

    }
}
