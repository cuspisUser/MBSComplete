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
    public partial class VoditeljFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public VoditeljFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("VODITELJI - pregled", "VODITELJI - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void VoditeljFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridVoditelji();
        }

        private void UltraGridVoditelji_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void LoadGridVoditelji()
        {
            BusinessLogic.Voditelji voditelji = new BusinessLogic.Voditelji();

            this.UltraGridVoditelji.DataSource = voditelji.GetVoditeljiMainGrid();
            this.UltraGridVoditelji.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridVoditelji);

            foreach (UltraGridRow row in UltraGridVoditelji.Rows)
            {
                if (row.Index == BusinessLogic.Voditelji.pSelectedIndex)
                {
                    UltraGridVoditelji.ActiveRow = row;
                }
            }
        }

        #region Command's - command handlers for buttons

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            VoditeljForm voditeljForm = new VoditeljForm(Enums.FormEditMode.Insert, null);

            if (voditeljForm.ShowDialogForm("Voditelj") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.Voditelji.pSelectedIndex = UltraGridVoditelji.ActiveRow.Index;
                }
                catch { }
                LoadGridVoditelji();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridVoditelji.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridVoditelji.ActiveRow.Cells["ID"].Value);

                VoditeljForm voditeljForm = new VoditeljForm(Enums.FormEditMode.Update, id);

                if (voditeljForm.ShowDialogForm("Voditelj") == DialogResult.OK)
                {
                    BusinessLogic.Voditelji.pSelectedIndex = UltraGridVoditelji.ActiveRow.Index;
                    LoadGridVoditelji();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridVoditelji.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridVoditelji.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati voditelja '{0}-{1}'?", id, this.UltraGridVoditelji.ActiveRow.Cells["ImePrezime"].Value),
                    "Brisanje voditelja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Voditelji voditelji = new BusinessLogic.Voditelji();
                    voditelji.Delete(id);

                    if (voditelji.IsValid)
                    {
                        voditelji.Persist();
                        LoadGridVoditelji();
                    }
                    else
                    {
                        voditelji.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridVoditelji.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridVoditelji.ActiveRow.Cells["ID"].Value);

                VoditeljForm voditeljForm = new VoditeljForm(Enums.FormEditMode.Copy, id);

                if (voditeljForm.ShowDialogForm("Voditelj") == DialogResult.OK)
                {
                    BusinessLogic.Voditelji.pSelectedIndex = UltraGridVoditelji.ActiveRow.Index;
                    LoadGridVoditelji();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Voditelji.pSelectedIndex = UltraGridVoditelji.ActiveRow.Index;
            }
            catch { }
            LoadGridVoditelji();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Voditelji";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridVoditelji, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        #endregion
    }
}
