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
    public partial class OlaksiceFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public OlaksiceFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("OLAKŠICE - pregled", "OLAKŠICE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void OlaksiceFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridOlaksice();
        }

        private void UltraGridProizvodi_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void LoadGridOlaksice()
        {
            BusinessLogic.Olaksice olaksice = new BusinessLogic.Olaksice();
            olaksice.InsertNultaOlaksica();
            UltraOlaksice.DataSource = olaksice.GetOlaksiceMainGrid();
           
            this.UltraOlaksice.DataBind();
            this.UltraOlaksice.UpdateData();

            Utils.Tools.UltraGridStyling(this.UltraOlaksice);

            foreach (UltraGridRow row in UltraOlaksice.Rows)
            {
                if (row.Index == BusinessLogic.Olaksice.pSelectedIndex)
                {
                    UltraOlaksice.ActiveRow = row;
                }
            }
        }

        #region Command's - command handlers for WorkItems

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            OlaksiceForm olaksiceForm = new OlaksiceForm(Enums.FormEditMode.Insert, null);
            olaksiceForm.ShowDialogForm("Proizvodi, cjenici, olakšice > Olakšice");
            try
            {
                BusinessLogic.Olaksice.pSelectedIndex = UltraOlaksice.ActiveRow.Index;
            }
            catch { }
            LoadGridOlaksice();
            
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraOlaksice.ActiveRow != null)
            {
                decimal? iznos = null;
                decimal? postotak = null;
                try
                {
                    iznos = (decimal?)UltraOlaksice.ActiveRow.Cells["OlaksicaIznos"].Value;
                }
                catch { }
                try
                {
                    postotak = (decimal?)UltraOlaksice.ActiveRow.Cells["OlaksicaPostotak"].Value;
                }
                catch { }

                if (postotak == null || iznos == null)
                {
                    int id = Convert.ToInt32(this.UltraOlaksice.ActiveRow.Cells["ID"].Value);
                    OlaksiceForm olaksiceForm = new OlaksiceForm(Enums.FormEditMode.Update, id);
                    olaksiceForm.ShowDialogForm("Proizvodi, cjenici, olakšice > Olakšice");
                    BusinessLogic.Olaksice.pSelectedIndex = UltraOlaksice.ActiveRow.Index;
                    LoadGridOlaksice();
                }
                else
                {
                    MessageBox.Show("Nije moguće mjenjati nultu olakšicu");
                }

            }
            
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraOlaksice.ActiveRow != null)
            {
                decimal? iznos = null;
                decimal? postotak = null;
                try
                {
                    iznos = (decimal?)UltraOlaksice.ActiveRow.Cells["OlaksicaIznos"].Value;
                }
                catch { }
                try
                {
                    postotak = (decimal?)UltraOlaksice.ActiveRow.Cells["OlaksicaPostotak"].Value;
                }
                catch { }

                if (postotak == null || iznos == null)
                {
                    try
                    {
                        int id = Convert.ToInt32(this.UltraOlaksice.ActiveRow.Cells["ID"].Value);
                        if (MessageBox.Show(string.Format("Obrisati olakšicu '{0}-{1}'?", id, this.UltraOlaksice.ActiveRow.Cells["Naziv"].Value),
                            "Brisanje olakšice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            BusinessLogic.Olaksice olaksice = new BusinessLogic.Olaksice();
                            olaksice.Delete(id);

                            if (olaksice.IsValid)
                            {
                                olaksice.Persist();
                                LoadGridOlaksice();
                            }
                            else
                            {
                                olaksice.DisplayValidationMessages();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Za brisanje olakšice proizvoda potrebno je otići u cjenik.", "Olakšice proizvod"
                                  , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    }
                }
                else
                {
                    MessageBox.Show("Nije moguće brisati nultu olakšicu");
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraOlaksice.ActiveRow != null)
            {
                decimal? iznos = null;
                decimal? postotak = null;
                try
                {
                    iznos = (decimal?)UltraOlaksice.ActiveRow.Cells["OlaksicaIznos"].Value;
                }
                catch { }
                try
                {
                    postotak = (decimal?)UltraOlaksice.ActiveRow.Cells["OlaksicaPostotak"].Value;
                }
                catch { }

                if (postotak == null || iznos == null)
                {
                    int id = Convert.ToInt32(this.UltraOlaksice.ActiveRow.Cells["ID"].Value);

                    OlaksiceForm olaksice = new OlaksiceForm(Enums.FormEditMode.Copy, id);

                    if (olaksice.ShowDialogForm("Proizvodi, cjenici, olakšice > Proizvodi / grupe proizvoda") == DialogResult.OK)
                    {
                        BusinessLogic.Olaksice.pSelectedIndex = UltraOlaksice.ActiveRow.Index;
                        LoadGridOlaksice();
                    }
                }
                else
                {
                    MessageBox.Show("Nije moguće kopirati nultu olakšicu");
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Olaksice.pSelectedIndex = UltraOlaksice.ActiveRow.Index;
            }
            catch { }
            LoadGridOlaksice();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Olakšice";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraOlaksice, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
            
        }

        #endregion
    }
}