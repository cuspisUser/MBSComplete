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

namespace JavnaNabava.UI.Nabava
{
    [SmartPart]
    public partial class RegistarNabaveFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public RegistarNabaveFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("REGISTAR NABAVE - pregled", "REGISTAR NABAVE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridRegistarNabave()
        {
            BusinessLogic.RegistarNabave registar_nabave = new BusinessLogic.RegistarNabave();

            ugdRegistarNabave.DataSource = registar_nabave.GetRegistarNabaveMainGrid();
            ugdRegistarNabave.DataBind();
            Utils.Tools.UltraGridStyling(ugdRegistarNabave);

            if (ugdRegistarNabave.DisplayLayout.Bands.Count > 0)
            {
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["ID_CPV_Oznaka"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["ID_StopaPoreza"].Hidden = true;
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["BezPDVa"].Format = "N2";
                ugdRegistarNabave.DisplayLayout.Bands[0].Columns["SaPDVom"].Format = "N2";
            }

            foreach (UltraGridRow row in ugdRegistarNabave.Rows)
            {
                if (row.Index == BusinessLogic.RegistarNabave.pSelectedIndex)
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
            using (uscRegistarNabave registar_nabave = new uscRegistarNabave(Enums.FormEditMode.Insert))
            {
                if (registar_nabave.ShowDialogForm("Registar nabave") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.RegistarNabave.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridRegistarNabave();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdRegistarNabave.ActiveRow != null)
            {
                BusinessLogic.RegistarNabave.pID = Convert.ToInt32(ugdRegistarNabave.ActiveRow.Cells["ID"].Value);

                using (uscRegistarNabave registar_nabave = new uscRegistarNabave(Enums.FormEditMode.Update))
                {
                    if (registar_nabave.ShowDialogForm("Registar nabave") == DialogResult.OK)
                    {
                        BusinessLogic.RegistarNabave.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
                        LoadGridRegistarNabave();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdRegistarNabave.ActiveRow != null)
            {
                BusinessLogic.RegistarNabave.pID = Convert.ToInt32(ugdRegistarNabave.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati registar nabave '{0}-{1}'?", BusinessLogic.RegistarNabave.pID, ugdRegistarNabave.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje registra nabave", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.RegistarNabave registar_nabave = new BusinessLogic.RegistarNabave();
                    if (!registar_nabave.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja registra nabave.\nKontaktirajte administratora [Error:00012]");
                    }
                    LoadGridRegistarNabave();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdRegistarNabave.ActiveRow != null)
            {
                BusinessLogic.RegistarNabave.pID = Convert.ToInt32(ugdRegistarNabave.ActiveRow.Cells["ID"].Value);

                using (uscRegistarNabave registar_nabave = new uscRegistarNabave(Enums.FormEditMode.Copy))
                {
                    if (registar_nabave.ShowDialogForm("Registar nabave") == DialogResult.OK)
                    {
                        BusinessLogic.RegistarNabave.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
                        LoadGridRegistarNabave();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.RegistarNabave.pSelectedIndex = ugdRegistarNabave.ActiveRow.Index;
            }
            catch { }
            LoadGridRegistarNabave();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog sfdExcel = new SaveFileDialog();
            sfdExcel.DefaultExt = "xls";
            sfdExcel.Filter = "Excel file (*.xls)|*.xls";
            sfdExcel.FileName = "Registar nabave";

            if (sfdExcel.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(ugdRegistarNabave, sfdExcel.FileName);
                Process.Start(sfdExcel.FileName);
            }
        }

        private void RegistarNabaveFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridRegistarNabave();
        }

        private void ugdRegistarNabave_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion

    }
}
