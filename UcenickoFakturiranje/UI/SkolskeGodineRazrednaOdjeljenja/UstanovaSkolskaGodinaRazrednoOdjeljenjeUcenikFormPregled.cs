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
using UcenickoFakturiranje.UI.MaticniPodaci;

namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    [SmartPart]
    public partial class UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public List<int> UceniciSelected { get; set; }

        public UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("UČENICI - pregled", "UČENICI - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);

            this.Width = 860;
            this.Height = 820;
        }

        #region Event handlers 

        private void UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridUcenici();
        }

        #endregion

        private void LoadGridUcenici()
        {
            BusinessLogic.Ucenici ucenici = new BusinessLogic.Ucenici();

            // Conditions
            int? razrednoOdjeljenjeID = ((UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregledWorkItem)this.Controller.WorkItem).RazrednoOdjeljenjeID;

            this.UltraGridUcenici.DataSource = ucenici.GetUceniciForAddingToRazrednoOdjeljenje(razrednoOdjeljenjeID);
            this.UltraGridUcenici.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridUcenici, new string[] { "Oznacen" });

            foreach (UltraGridRow row in UltraGridUcenici.Rows)
            {
                if (row.Index == BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici.pSelectedIndex)
                {
                    UltraGridUcenici.ActiveRow = row;
                }
            }
        }

        private void GridSelectDeselectAll(bool isChecked)
        {
            foreach (UltraGridRow row in this.UltraGridUcenici.Rows)
            {
                row.Cells["Oznacen"].Value = isChecked;
            }
        }

        #region Command's - command handlers for WorkItems

        /// <summary>
        /// "SELECT" je skriveni command handler koji se javlja AUTOMATSKI ako je WorkItem nasljeđen od "SelectionListWorkItemBase"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [CommandHandler("Select")]
        public void OdaberiUcenike(object sender, EventArgs e)
        {
            this.UceniciSelected = new List<int>();

            // Remember selected ID's
            foreach (UltraGridRow row in this.UltraGridUcenici.Rows)
            {
                if ((bool)row.Cells["Oznacen"].Value)
                    this.UceniciSelected.Add((int)row.Cells["ID"].Value);
            }

            // Pass ID list to WorkItem
            ((UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregledWorkItem)this.Controller.WorkItem).UceniciSelected = this.UceniciSelected;

            this.Dispose();
        }

        [CommandHandler("OznaciSve2")]
        public void OznaciSve(object sender, EventArgs e)
        {
            GridSelectDeselectAll(true);
        }

        [CommandHandler("OdznaciSve2")]
        public void OdznaciSve(object sender, EventArgs e)
        {
            GridSelectDeselectAll(false);
        }

        [CommandHandler("Refresh2")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
            }
            catch { }
            LoadGridUcenici();
        }

        [CommandHandler("ExportExcel2")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Učenici";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridUcenici, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }
        [CommandHandler("Dodaj")]
        public void Insert(object sender, EventArgs e)
        {

            UcenikForm ucenikForm = new UcenikForm(Enums.FormEditMode.Insert, null);

            if (ucenikForm.ShowDialogForm("Učenik") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
                }
                catch { }
                LoadGridUcenici();
            }
        }

        #endregion
    }
}
