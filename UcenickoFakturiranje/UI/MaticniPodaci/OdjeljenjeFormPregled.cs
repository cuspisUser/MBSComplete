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

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    [SmartPart]
    public partial class OdjeljenjeFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public OdjeljenjeFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("ODJELJENJA - pregled", "ODJELJENJA - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridOdjeljenja()
        {
            BusinessLogic.Odjeljenja odjeljenja = new BusinessLogic.Odjeljenja();

            this.UltraGridOdjeljenja.DataSource = odjeljenja.GetOdjeljenjaMainGrid();
            this.UltraGridOdjeljenja.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridOdjeljenja);

            foreach (UltraGridRow row in UltraGridOdjeljenja.Rows)
            {
                if (row.Index == BusinessLogic.Odjeljenja.pSelectedIndex)
                {
                    UltraGridOdjeljenja.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        private void OdjeljenjeFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridOdjeljenja();
        }
        private void UltraGridOdjeljenja_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            OdjeljenjeForm odjeljenjeForm = new OdjeljenjeForm(Enums.FormEditMode.Insert, null);

            if (odjeljenjeForm.ShowDialogForm("Odjeljenje") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.Odjeljenja.pSelectedIndex = UltraGridOdjeljenja.ActiveRow.Index;
                }
                catch { }
                LoadGridOdjeljenja();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridOdjeljenja.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridOdjeljenja.ActiveRow.Cells["ID"].Value);

                OdjeljenjeForm odjeljenjeForm = new OdjeljenjeForm(Enums.FormEditMode.Update, id);

                if (odjeljenjeForm.ShowDialogForm("Odjeljenje") == DialogResult.OK)
                {
                    BusinessLogic.Odjeljenja.pSelectedIndex = UltraGridOdjeljenja.ActiveRow.Index;
                    LoadGridOdjeljenja();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridOdjeljenja.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridOdjeljenja.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati odjeljenje '{0}-{1}'?", id, this.UltraGridOdjeljenja.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje odjeljenja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Odjeljenja odjeljenja = new BusinessLogic.Odjeljenja();
                    odjeljenja.Delete(id);

                    if (odjeljenja.IsValid)
                    {
                        odjeljenja.Persist();
                        LoadGridOdjeljenja();
                    }
                    else
                    {
                        odjeljenja.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridOdjeljenja.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridOdjeljenja.ActiveRow.Cells["ID"].Value);

                OdjeljenjeForm odjeljenjeForm = new OdjeljenjeForm(Enums.FormEditMode.Copy, id);

                if (odjeljenjeForm.ShowDialogForm("Odjeljenje") == DialogResult.OK)
                {
                    BusinessLogic.Odjeljenja.pSelectedIndex = UltraGridOdjeljenja.ActiveRow.Index;
                    LoadGridOdjeljenja();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Odjeljenja.pSelectedIndex = UltraGridOdjeljenja.ActiveRow.Index;
            }
            catch { }
            LoadGridOdjeljenja();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Odjeljenja";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridOdjeljenja, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        #endregion
    }
}
