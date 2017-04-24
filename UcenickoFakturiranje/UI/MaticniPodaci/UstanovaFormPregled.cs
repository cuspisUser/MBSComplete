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

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    [SmartPart]
    public partial class UstanovaFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public UstanovaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("USTANOVE - pregled", "USTANOVE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers
        
        private void UstanovaFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridUstanove();
        }

        private void UltraGridUstanove_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void LoadGridUstanove()
        {
            BusinessLogic.Ustanove ustanove = new BusinessLogic.Ustanove();

            this.UltraGridUstanove.DataSource = ustanove.GetUstanoveMainGrid();
            this.UltraGridUstanove.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridUstanove);

            foreach(UltraGridRow row in UltraGridUstanove.Rows)
            {
                if(row.Index == BusinessLogic.Ustanove.pSelectedIndex)
                {
                    UltraGridUstanove.ActiveRow = row;
                }
            }
        }

        #region Command's - command handlers for WorkItems

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            UstanovaForm ustanovaForm = new UstanovaForm(Enums.FormEditMode.Insert, null);

            if (ustanovaForm.ShowDialogForm("Ustanova") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.Ustanove.pSelectedIndex = UltraGridUstanove.ActiveRow.Index;
                }
                catch { }
                LoadGridUstanove();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridUstanove.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanove.ActiveRow.Cells["ID"].Value);

                UstanovaForm ustanovaForm = new UstanovaForm(Enums.FormEditMode.Update, id);
                if (ustanovaForm.ShowDialogForm("Ustanova") == DialogResult.OK)
                {
                    BusinessLogic.Ustanove.pSelectedIndex = UltraGridUstanove.ActiveRow.Index;
                    LoadGridUstanove();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridUstanove.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanove.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati ustanovu '{0}-{1}'?", id, this.UltraGridUstanove.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje ustanove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Ustanove ustanove = new BusinessLogic.Ustanove();
                    ustanove.Delete(id);

                    if (ustanove.IsValid)
                    {
                        ustanove.Persist();
                        LoadGridUstanove();
                    }
                    else
                    {
                        ustanove.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridUstanove.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUstanove.ActiveRow.Cells["ID"].Value);

                UstanovaForm ustanovaForm = new UstanovaForm(Enums.FormEditMode.Copy, id);

                if (ustanovaForm.ShowDialogForm("Ustanova") == DialogResult.OK)
                {
                    LoadGridUstanove();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Ustanove.pSelectedIndex = UltraGridUstanove.ActiveRow.Index;
            }
            catch { }
            LoadGridUstanove();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Ustanove";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridUstanove, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        #endregion

    }
}
