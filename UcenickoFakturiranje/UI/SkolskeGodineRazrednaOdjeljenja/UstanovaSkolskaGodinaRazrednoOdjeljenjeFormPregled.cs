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
    public partial class UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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
        public Microsoft.Practices.CompositeUI.Controller Controller 
        { 
            get; set; 
        }

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

        public UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("ORGANIZACIJA RAZREDNIH ODJELJENJA - pregled", "ORGANIZACIJA RAZREDNIH ODJELJENJA - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void UstanovaSkolskaGodinaRazrednoOdjeljenjeFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridUstanoveSkolskeGodineRazrednaOdjeljenja();
        }

        private void UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        public void LoadGridUstanoveSkolskeGodineRazrednaOdjeljenja()
        {
            BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja ustanoveSkolskeGodineRazrednaOdjeljenja = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja();

            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DataSource = ustanoveSkolskeGodineRazrednaOdjeljenja.GetUstanovaSkolskaGodinaRazredOdjeljenjeMainGrid();
            this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja);

            foreach (UltraGridRow row in UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.Rows)
            {
                if (row.Index == BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja.pSelectedIndex)
                {
                    UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow = row;
                }
            }
        }

        #region Command's - command handlers for WorkItems

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem item = this.Controller.WorkItem.Items.Get<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem>("UF.OrganizacijaRazrednihOdjeljenjaUcenik");

        InitializeAgain:

            if (item != null)
            {
                item.Terminate();
                item.Dispose();
                item = null;

                goto InitializeAgain;
            }
            else
            {
                item = this.Controller.WorkItem.Items.AddNew<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem>("UF.OrganizacijaRazrednihOdjeljenjaUcenik");
            }
            item.FormEditMode = Enums.FormEditMode.Insert;
            item.RazrednoOdjeljenjeID = null;
            item.kontrola_za_editiranje = true;
            item.Show(item.Workspaces["main"]);

        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow.Cells["ID"].Value);

                UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem item = this.Controller.WorkItem.Items.Get<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem>("UF.OrganizacijaRazrednihOdjeljenjaUcenik");

            InitializeAgain:

                if (item != null)
                {
                    item.Terminate();
                    item.Dispose();
                    item = null;

                    goto InitializeAgain;
                }
                else
                {
                    item = this.Controller.WorkItem.Items.AddNew<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem>("UF.OrganizacijaRazrednihOdjeljenjaUcenik");
                }

                item.FormEditMode = Enums.FormEditMode.Update;
                item.RazrednoOdjeljenjeID = id;
                item.kontrola_za_editiranje = false;
                item.Show(item.Workspaces["main"]);

            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati razredno odjeljenje '{0}-{1}'?", id, this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow.Cells["RazredOdjeljenje"].Value),
                    "Brisanje razrednog odjeljenja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja ustanoveSkolskeGodineRazrednaOdjeljenja = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja();
                    ustanoveSkolskeGodineRazrednaOdjeljenja.Delete(id);

                    if (ustanoveSkolskeGodineRazrednaOdjeljenja.IsValid)
                    {
                        ustanoveSkolskeGodineRazrednaOdjeljenja.Persist();
                        LoadGridUstanoveSkolskeGodineRazrednaOdjeljenja();
                    }
                    else
                    {
                        ustanoveSkolskeGodineRazrednaOdjeljenja.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow.Cells["ID"].Value);

                UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem item = this.Controller.WorkItem.Items.Get<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem>("UF.OrganizacijaRazrednihOdjeljenjaUcenik");

            InitializeAgain:

                if (item != null)
                {
                    item.Terminate();
                    item.Dispose();
                    item = null;

                    goto InitializeAgain;
                }
                else
                {
                    item = this.Controller.WorkItem.Items.AddNew<UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem>("UF.OrganizacijaRazrednihOdjeljenjaUcenik");
                }
                item.FormEditMode = Enums.FormEditMode.Copy;
                item.RazrednoOdjeljenjeID = id;
                item.Show(item.Workspaces["main"]);
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja.pSelectedIndex = UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja.ActiveRow.Index;
            }
            catch { }
            LoadGridUstanoveSkolskeGodineRazrednaOdjeljenja();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Razredna odjeljenja";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        #endregion

        private void UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja_MouseHover(object sender, EventArgs e)
        {
        }

        private void UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja_Enter(object sender, EventArgs e)
        {
            if (UstanovaSkolskaGodinaRazrednoOdjeljenjeForm.refresh_grida)
            {
                LoadGridUstanoveSkolskeGodineRazrednaOdjeljenja();
                UstanovaSkolskaGodinaRazrednoOdjeljenjeForm.refresh_grida = false;
            }
        }

    }
}
