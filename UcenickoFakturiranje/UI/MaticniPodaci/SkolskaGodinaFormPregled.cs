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

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    [SmartPart]
    public partial class SkolskaGodinaFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        /// <summary>
        /// Composite UI
        /// ------------------------------------------------------------------ 
        /// Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)
        /// </summary>
        #region Composite UI - ALL code necessary

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

        public SkolskaGodinaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("ŠKOLSKE GODINE - pregled", "ŠKOLSKE GODINE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void SkolskaGodinaFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridSkolskeGodine();
        }

        private void UltraGridSkolskeGodine_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void LoadGridSkolskeGodine()
        {
            BusinessLogic.SkolskeGodine skolskeGodine = new BusinessLogic.SkolskeGodine();

            this.UltraGridSkolskeGodine.DataSource = skolskeGodine.GetSkolskeGodineMainGrid();
            this.UltraGridSkolskeGodine.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridSkolskeGodine);
        }

        #region Command's - command handlers for buttons

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            SkolskaGodinaForm skolskaGodinaForm = new SkolskaGodinaForm(Enums.FormEditMode.Insert, null);

            if (skolskaGodinaForm.ShowDialogForm("Školska godina") == DialogResult.OK)
                LoadGridSkolskeGodine();
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridSkolskeGodine.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridSkolskeGodine.ActiveRow.Cells["ID"].Value);

                SkolskaGodinaForm skolskaGodinaForm = new SkolskaGodinaForm(Enums.FormEditMode.Update, id);

                if (skolskaGodinaForm.ShowDialogForm("Školska godina") == DialogResult.OK)
                    LoadGridSkolskeGodine();
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridSkolskeGodine.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridSkolskeGodine.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati školsku godinu '{0}-{1}'?", id, this.UltraGridSkolskeGodine.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje školske godine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.SkolskeGodine skolskeGodine = new BusinessLogic.SkolskeGodine();
                    skolskeGodine.Delete(id);

                    if (skolskeGodine.IsValid)
                    {
                        skolskeGodine.Persist();
                        LoadGridSkolskeGodine();
                    }
                    else
                    {
                        skolskeGodine.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridSkolskeGodine.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridSkolskeGodine.ActiveRow.Cells["ID"].Value);

                SkolskaGodinaForm skolskaGodinaForm = new SkolskaGodinaForm(Enums.FormEditMode.Copy, id);

                if (skolskaGodinaForm.ShowDialogForm("Školska godina") == DialogResult.OK)
                    LoadGridSkolskeGodine();
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridSkolskeGodine();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Školske godine";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridSkolskeGodine, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        #endregion

    }
}
