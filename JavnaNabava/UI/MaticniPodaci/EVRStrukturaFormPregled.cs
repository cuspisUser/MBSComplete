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

namespace JavnaNabava.UI.MaticniPodaci
{
    [SmartPart]
    public partial class EVRStrukturaFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public EVRStrukturaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("EVR Struktura - pregled", "EVR Struktura - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridEVRStruktura()
        {
            BusinessLogic.EVRStruktura evr_struktura = new BusinessLogic.EVRStruktura();

            ugdEVRStruktura.DataSource = evr_struktura.GetEVRStrukturaMainGrid();
            ugdEVRStruktura.DataBind();
            Utils.Tools.UltraGridStyling(ugdEVRStruktura);

            foreach (UltraGridRow row in ugdEVRStruktura.Rows)
            {
                if (row.Index == BusinessLogic.EVRStruktura.pSelectedIndex)
                {
                    ugdEVRStruktura.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscEVRStruktura evr_struktura = new uscEVRStruktura(Enums.FormEditMode.Insert))
            {
                if (evr_struktura.ShowDialogForm("EVRStruktura") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.EVRStruktura.pSelectedIndex = ugdEVRStruktura.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridEVRStruktura();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdEVRStruktura.ActiveRow != null)
            {
                BusinessLogic.EVRStruktura.pID = Convert.ToInt32(ugdEVRStruktura.ActiveRow.Cells["ID"].Value);

                using (uscEVRStruktura evr_struktura = new uscEVRStruktura(Enums.FormEditMode.Update))
                {
                    if (evr_struktura.ShowDialogForm("EVRStruktira") == DialogResult.OK)
                    {
                        BusinessLogic.EVRStruktura.pSelectedIndex = ugdEVRStruktura.ActiveRow.Index;
                        LoadGridEVRStruktura();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdEVRStruktura.ActiveRow != null)
            {
                BusinessLogic.EVRStruktura.pID = Convert.ToInt32(ugdEVRStruktura.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati EVR strukturu '{0}-{1}'?", BusinessLogic.EVRStruktura.pID, ugdEVRStruktura.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje EVR strukture", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.EVRStruktura evr_struktura = new BusinessLogic.EVRStruktura();
                    if (!evr_struktura.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja EVR strukture.\nKontaktirajte administratora [Error:00015]");
                    }
                    LoadGridEVRStruktura();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdEVRStruktura.ActiveRow != null)
            {
                BusinessLogic.EVRStruktura.pID = (int)ugdEVRStruktura.ActiveRow.Cells["ID"].Value;

                using (uscEVRStruktura evr_struktura = new uscEVRStruktura(Enums.FormEditMode.Copy))
                {
                    if (evr_struktura.ShowDialogForm("EVRStruktura") == DialogResult.OK)
                    {
                        BusinessLogic.EVRStruktura.pSelectedIndex = ugdEVRStruktura.ActiveRow.Index;
                        LoadGridEVRStruktura();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.EVRStruktura.pSelectedIndex = ugdEVRStruktura.ActiveRow.Index;
            }
            catch { }
            LoadGridEVRStruktura();
        }

        private void EVRStrukturaFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridEVRStruktura();
        }

        private void ugdEVRStruktura_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion

    }
}
