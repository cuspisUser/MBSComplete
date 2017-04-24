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

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    [SmartPart]
    public partial class RazredFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public RazredFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("RAZREDI - pregled", "RAZREDI - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridRazredi()
        {
            BusinessLogic.Razredi razredi = new BusinessLogic.Razredi();

            this.UltraGridRazredi.DataSource = razredi.GetRazrediMainGrid();
            this.UltraGridRazredi.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridRazredi);

            foreach (UltraGridRow row in UltraGridRazredi.Rows)
            {
                if (row.Index == BusinessLogic.Razredi.pSelectedIndex)
                {
                    UltraGridRazredi.ActiveRow = row;
                }
            }
        }

        #endregion

        #region Dogadaji

        private void RazredFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridRazredi();
        }

        private void UltraGridRazredi_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            RazredForm razredForm = new RazredForm(Enums.FormEditMode.Insert, null);

            if (razredForm.ShowDialogForm("Razred") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.Razredi.pSelectedIndex = UltraGridRazredi.ActiveRow.Index;
                }
                catch { }
                LoadGridRazredi();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridRazredi.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridRazredi.ActiveRow.Cells["ID"].Value);

                RazredForm razredForm = new RazredForm(Enums.FormEditMode.Update, id);

                if (razredForm.ShowDialogForm("Razred") == DialogResult.OK)
                {
                    BusinessLogic.Razredi.pSelectedIndex = UltraGridRazredi.ActiveRow.Index;
                    LoadGridRazredi();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridRazredi.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridRazredi.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati razred '{0}-{1}'?", id, this.UltraGridRazredi.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje razreda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Razredi razredi = new BusinessLogic.Razredi();
                    razredi.Delete(id);

                    if (razredi.IsValid)
                    {
                        razredi.Persist();
                        LoadGridRazredi();
                    }
                    else
                    {
                        razredi.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridRazredi.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridRazredi.ActiveRow.Cells["ID"].Value);

                RazredForm razredForm = new RazredForm(Enums.FormEditMode.Copy, id);

                if (razredForm.ShowDialogForm("Razred") == DialogResult.OK)
                {
                    BusinessLogic.Razredi.pSelectedIndex = UltraGridRazredi.ActiveRow.Index;
                    LoadGridRazredi();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Razredi.pSelectedIndex = UltraGridRazredi.ActiveRow.Index;
            }
            catch { }
            LoadGridRazredi();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Razredi";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridRazredi, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        #endregion

    }
}
