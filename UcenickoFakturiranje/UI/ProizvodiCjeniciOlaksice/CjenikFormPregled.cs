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

namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    [SmartPart]
    public partial class CjenikFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public CjenikFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("CJENICI - pregled", "Cjenici - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void CjenikFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridCjenici();
        }

        private void UltraGridProizvodi_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void LoadGridCjenici()
        {

            BusinessLogic.Cjenici olaksice = new BusinessLogic.Cjenici();
            UltraCjenici.DataSource = olaksice.GetCjeniciMainGrid();
            
            this.UltraCjenici.DataBind();
            this.UltraCjenici.UpdateData();

            Utils.Tools.UltraGridStyling(this.UltraCjenici);
            if (UltraCjenici.DisplayLayout.Bands.Count > 0)
                if (UltraCjenici.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    UltraCjenici.DisplayLayout.Bands[0].Columns["Naziv"].Width = 200;
                }

            foreach (UltraGridRow row in UltraCjenici.Rows)
            {
                if (row.Index == BusinessLogic.Cjenici.pSelectedIndex)
                {
                    UltraCjenici.ActiveRow = row;
                }
            }
        }

        #region Command's - command handlers for WorkItems

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            CjenikForm cjenikeForm = new CjenikForm(Enums.FormEditMode.Insert, null);
            cjenikeForm.ShowDialogForm("Proizvodi, cjenici, olakšice > Cjenici");
            try
            {
                BusinessLogic.Cjenici.pSelectedIndex = UltraCjenici.ActiveRow.Index;
            }
            catch { }
            LoadGridCjenici();
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraCjenici.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraCjenici.ActiveRow.Cells["ID"].Value);
                CjenikForm cjenikeForm = new CjenikForm(Enums.FormEditMode.Update, id);

                cjenikeForm.ShowDialogForm("Proizvodi, cjenici, olakšice > Cjenici");
                BusinessLogic.Cjenici.pSelectedIndex = UltraCjenici.ActiveRow.Index;
                LoadGridCjenici();   
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraCjenici.ActiveRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(this.UltraCjenici.ActiveRow.Cells["ID"].Value);
                    if (MessageBox.Show(string.Format("Obrisati cjenik ?"),
                        "Brisanje cjenika", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        BusinessLogic.Cjenici cjenici = new BusinessLogic.Cjenici();
                        cjenici.Delete(id);

                        if (cjenici.IsValid)
                        {
                            if (cjenici.Persist())
                                LoadGridCjenici();
                            else
                                MessageBox.Show("Nije moguće obrisati cjenik.\nPostoji veza na cjenik.", "Cjenik"
                                                , MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);
                        }
                        else
                        {
                            cjenici.DisplayValidationMessages();
                        }
                    }
                }
                catch 
                {
                    MessageBox.Show("Za brisanje proizvoda cjenika potrebno je otići u cjenik.", "Cjenik proizvod"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                }
            }
            
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraCjenici.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraCjenici.ActiveRow.Cells["ID"].Value);

                CjenikForm olaksice = new CjenikForm(Enums.FormEditMode.Copy, id);

                if (olaksice.ShowDialogForm("Proizvodi, cjenici, olakšice > Cjenici") == DialogResult.OK)
                {
                    BusinessLogic.Cjenici.pSelectedIndex = UltraCjenici.ActiveRow.Index;
                    LoadGridCjenici();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Cjenici.pSelectedIndex = UltraCjenici.ActiveRow.Index;
            }
            catch { }
            LoadGridCjenici();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Cjenici";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraCjenici, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }
        #endregion
    }
}