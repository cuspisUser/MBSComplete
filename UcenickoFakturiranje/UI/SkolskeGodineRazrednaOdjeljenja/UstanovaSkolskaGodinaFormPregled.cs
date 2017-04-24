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
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Microsoft.VisualBasic;
using Infragistics.Win.UltraWinGrid;

namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    [SmartPart]
    public partial class UstanovaSkolskaGodinaFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public UstanovaSkolskaGodinaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("USTANOVE / ŠKOLSKE GODINE - pregled", "USTANOVE / ŠKOLSKE GODINE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void UstanovaSkolskaGodinaFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridUstanoveSkolskeGodine();
        }

        private void UltraGridUstanoveSkolskeGodine_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        public void LoadGridUstanoveSkolskeGodine()
        {
            BusinessLogic.UstanoveSkolskeGodine ustanoveSkolskeGodine = new BusinessLogic.UstanoveSkolskeGodine();

            this.UltraGridUstanoveSkolskeGodine.DataSource = ustanoveSkolskeGodine.GetUstanoveSkolskeGodineMainGrid();
            this.UltraGridUstanoveSkolskeGodine.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridUstanoveSkolskeGodine);

            foreach (UltraGridRow row in UltraGridUstanoveSkolskeGodine.Rows)
            {
                if (row.Index == BusinessLogic.UstanoveSkolskeGodine.pSelectedIndex)
                {
                    UltraGridUstanoveSkolskeGodine.ActiveRow = row;
                }
            }
        }

        #region Command's - command handlers for WorkItems

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            UstanovaSkolskaGodinaForm ustanovaSkolskaGodinaForm = new UstanovaSkolskaGodinaForm(Enums.FormEditMode.Insert, null);

            if (ustanovaSkolskaGodinaForm.ShowDialogForm("Ustanova / školska godina") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.UstanoveSkolskeGodine.pSelectedIndex = UltraGridUstanoveSkolskeGodine.ActiveRow.Index;
                }
                catch { }
                LoadGridUstanoveSkolskeGodine();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridUstanoveSkolskeGodine.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanoveSkolskeGodine.ActiveRow.Cells["ID"].Value);

                UstanovaSkolskaGodinaForm ustanovaSkolskaGodinaForm = new UstanovaSkolskaGodinaForm(Enums.FormEditMode.Update, id);

                if (ustanovaSkolskaGodinaForm.ShowDialogForm("Ustanova / školska godina") == DialogResult.OK)
                {
                    BusinessLogic.UstanoveSkolskeGodine.pSelectedIndex = UltraGridUstanoveSkolskeGodine.ActiveRow.Index;
                    LoadGridUstanoveSkolskeGodine();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridUstanoveSkolskeGodine.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanoveSkolskeGodine.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati ustanovu / školsku godinu '{0}-{1} / {2}'?", id, this.UltraGridUstanoveSkolskeGodine.ActiveRow.Cells["Ustanova"].Value, 
                    this.UltraGridUstanoveSkolskeGodine.ActiveRow.Cells["SkolskaGodina"].Value),
                    "Brisanje ustanove / školske godine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.UstanoveSkolskeGodine ustanoveSkolskeGodine = new BusinessLogic.UstanoveSkolskeGodine();
                    ustanoveSkolskeGodine.Delete(id);

                    if (ustanoveSkolskeGodine.IsValid)
                    {
                        ustanoveSkolskeGodine.Persist();
                        LoadGridUstanoveSkolskeGodine();
                    }
                    else
                    {
                        ustanoveSkolskeGodine.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridUstanoveSkolskeGodine.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanoveSkolskeGodine.ActiveRow.Cells["ID"].Value);

                UstanovaSkolskaGodinaForm ustanovaSkolskaGodinaForm = new UstanovaSkolskaGodinaForm(Enums.FormEditMode.Copy, id);

                if (ustanovaSkolskaGodinaForm.ShowDialogForm("Ustanova / školska godina") == DialogResult.OK)
                {
                    BusinessLogic.UstanoveSkolskeGodine.pSelectedIndex = UltraGridUstanoveSkolskeGodine.ActiveRow.Index;
                    LoadGridUstanoveSkolskeGodine();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.UstanoveSkolskeGodine.pSelectedIndex = UltraGridUstanoveSkolskeGodine.ActiveRow.Index;
            }
            catch { }
            LoadGridUstanoveSkolskeGodine();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Ustanove - školske godine";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridUstanoveSkolskeGodine, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        #endregion
    }
}
