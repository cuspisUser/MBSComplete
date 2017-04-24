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
    public partial class VrsteNabaveFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public VrsteNabaveFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("VRSTE NABAVE - pregled", "VRSTE NABAVE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridVrsteNabave()
        {
            BusinessLogic.VrsteNabave vrste_nabave = new BusinessLogic.VrsteNabave();

            ugdVrsteNabave.DataSource = vrste_nabave.GetVrsteNabaveMainGrid();
            ugdVrsteNabave.DataBind();
            Utils.Tools.UltraGridStyling(ugdVrsteNabave);

            foreach (UltraGridRow row in ugdVrsteNabave.Rows)
            {
                if (row.Index == BusinessLogic.VrsteNabave.pSelectedIndex)
                {
                    ugdVrsteNabave.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscVrsteNabaveForm vrste_nabave = new uscVrsteNabaveForm(Enums.FormEditMode.Insert))
            {
                if (vrste_nabave.ShowDialogForm("Vrste Nabave") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.VrsteNabave.pSelectedIndex = ugdVrsteNabave.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridVrsteNabave();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdVrsteNabave.ActiveRow != null)
            {
                BusinessLogic.VrsteNabave.pID = Convert.ToInt32(ugdVrsteNabave.ActiveRow.Cells["ID"].Value);
                BusinessLogic.VrsteNabave.pNaziv = ugdVrsteNabave.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscVrsteNabaveForm vrste_nabave = new uscVrsteNabaveForm(Enums.FormEditMode.Update))
                {
                    if (vrste_nabave.ShowDialogForm("Vrste Nabave") == DialogResult.OK)
                    {
                        BusinessLogic.VrsteNabave.pSelectedIndex = ugdVrsteNabave.ActiveRow.Index;
                        LoadGridVrsteNabave();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdVrsteNabave.ActiveRow != null)
            {
                BusinessLogic.VrsteNabave.pID = Convert.ToInt32(ugdVrsteNabave.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati vrstu nabave '{0}-{1}'?", BusinessLogic.CPVOznake.pID, ugdVrsteNabave.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje Vrste nabave", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.VrsteNabave vrste_nabave = new BusinessLogic.VrsteNabave();
                    if (!vrste_nabave.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja vrste nabave.\nKontaktirajte administratora [Error:00008]");
                    }
                    LoadGridVrsteNabave();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdVrsteNabave.ActiveRow != null)
            {
                BusinessLogic.VrsteNabave.pID = (int)ugdVrsteNabave.ActiveRow.Cells["ID"].Value;
                BusinessLogic.VrsteNabave.pNaziv = ugdVrsteNabave.ActiveRow.Cells["Naziv"].Value.ToString();

                using (uscVrsteNabaveForm vrste_nabave = new uscVrsteNabaveForm(Enums.FormEditMode.Copy))
                {
                    if (vrste_nabave.ShowDialogForm("Vrste Nabave") == DialogResult.OK)
                    {
                        BusinessLogic.VrsteNabave.pSelectedIndex = ugdVrsteNabave.ActiveRow.Index;
                        LoadGridVrsteNabave();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.VrsteNabave.pSelectedIndex = ugdVrsteNabave.ActiveRow.Index;
            }
            catch { }
            LoadGridVrsteNabave();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog sfdExcel = new SaveFileDialog();
            sfdExcel.DefaultExt = "xls";
            sfdExcel.Filter = "Excel file (*.xls)|*.xls";
            sfdExcel.FileName = "Vrste nabave";

            if (sfdExcel.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(ugdVrsteNabave, sfdExcel.FileName);
                Process.Start(sfdExcel.FileName);
            }
        }

        private void VrsteNabaveFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridVrsteNabave();
        }

        private void ugdVrsteNabave_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion

       
    }
}
