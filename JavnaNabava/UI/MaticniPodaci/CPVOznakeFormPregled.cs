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
    public partial class CPVOznakeFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public CPVOznakeFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("CPV OZNAKE - pregled", "CPV OZNAKE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridCPVOznake()
        {
            BusinessLogic.CPVOznake cpv_oznake = new BusinessLogic.CPVOznake();

            ugdCPVOznake.DataSource = cpv_oznake.GetCPVOznakeMainGrid();
            ugdCPVOznake.DataBind();
            Utils.Tools.UltraGridStyling(ugdCPVOznake);

            foreach (UltraGridRow row in ugdCPVOznake.Rows)
            {
                if (row.Index == BusinessLogic.CPVOznake.pSelectedIndex)
                {
                    ugdCPVOznake.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscCPVOznake cpv_oznake = new uscCPVOznake(Enums.FormEditMode.Insert))
            {
                if (cpv_oznake.ShowDialogForm("CPVOznake") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.CPVOznake.pSelectedIndex = ugdCPVOznake.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridCPVOznake();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdCPVOznake.ActiveRow != null)
            {
                BusinessLogic.CPVOznake.pID = Convert.ToInt32(ugdCPVOznake.ActiveRow.Cells["ID"].Value);
                BusinessLogic.CPVOznake.pNaziv = ugdCPVOznake.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscCPVOznake cpv_oznake = new uscCPVOznake(Enums.FormEditMode.Update))
                {
                    if (cpv_oznake.ShowDialogForm("CPVOznake") == DialogResult.OK)
                    {
                        BusinessLogic.CPVOznake.pSelectedIndex = ugdCPVOznake.ActiveRow.Index;
                        LoadGridCPVOznake();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdCPVOznake.ActiveRow != null)
            {
                BusinessLogic.CPVOznake.pID = Convert.ToInt32(ugdCPVOznake.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati CPV oznaku '{0}-{1}'?", BusinessLogic.CPVOznake.pID, ugdCPVOznake.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje CPV oznake", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.CPVOznake cpv_oznake = new BusinessLogic.CPVOznake();
                    if (!cpv_oznake.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja CPV oznake.\nKontaktirajte administratora [Error:00006]");
                    }
                    LoadGridCPVOznake();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdCPVOznake.ActiveRow != null)
            {
                BusinessLogic.CPVOznake.pID = (int)ugdCPVOznake.ActiveRow.Cells["ID"].Value;
                BusinessLogic.CPVOznake.pNaziv = ugdCPVOznake.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscCPVOznake cpv_oznake = new uscCPVOznake(Enums.FormEditMode.Copy))
                {
                    if (cpv_oznake.ShowDialogForm("CPVOznake") == DialogResult.OK)
                    {
                        BusinessLogic.CPVOznake.pSelectedIndex = ugdCPVOznake.ActiveRow.Index;
                        LoadGridCPVOznake();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.CPVOznake.pSelectedIndex = ugdCPVOznake.ActiveRow.Index;
            }
            catch { }
            LoadGridCPVOznake();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog sfdExcel = new SaveFileDialog();
            sfdExcel.DefaultExt = "xls";
            sfdExcel.Filter = "Excel file (*.xls)|*.xls";
            sfdExcel.FileName = "CPV oznake";

            if (sfdExcel.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(ugdCPVOznake, sfdExcel.FileName);
                Process.Start(sfdExcel.FileName);
            }
        }

        private void CPVOznakeFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridCPVOznake();
        }

        #endregion

        private void ugdCPVOznake_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

    }
}
