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
    public partial class FiskalneGodineFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public FiskalneGodineFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("FISKALNE GODINE - pregled", "FISKALNE GODINE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridFiskalneGodine()
        {
            BusinessLogic.FiskalneGodine fiskalne_godine = new BusinessLogic.FiskalneGodine();

            ugdFiskalneGodine.DataSource = fiskalne_godine.GetFiskalneGodineMainGrid();
            ugdFiskalneGodine.DataBind();
            Utils.Tools.UltraGridStyling(ugdFiskalneGodine);

            foreach (UltraGridRow row in ugdFiskalneGodine.Rows)
            {
                if (row.Index == BusinessLogic.FiskalneGodine.pSelectedIndex)
                {
                    ugdFiskalneGodine.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscFiskalneGodine fiskalne_godine = new uscFiskalneGodine(Enums.FormEditMode.Insert))
            {
                if (fiskalne_godine.ShowDialogForm("Fiskalne godine") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.FiskalneGodine.pSelectedIndex = ugdFiskalneGodine.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridFiskalneGodine();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdFiskalneGodine.ActiveRow != null)
            {
                BusinessLogic.FiskalneGodine.pID = Convert.ToInt32(ugdFiskalneGodine.ActiveRow.Cells["IDGODINE"].Value);
                BusinessLogic.FiskalneGodine.pAktivna = Convert.ToBoolean(ugdFiskalneGodine.ActiveRow.Cells["GODINEAKTIVNA"].Value);

                using (uscFiskalneGodine fiskalne_godine = new uscFiskalneGodine(Enums.FormEditMode.Update))
                {
                    if (fiskalne_godine.ShowDialogForm("Fiskalne godine") == DialogResult.OK)
                    {
                        BusinessLogic.FiskalneGodine.pSelectedIndex = ugdFiskalneGodine.ActiveRow.Index;
                        LoadGridFiskalneGodine();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdFiskalneGodine.ActiveRow != null)
            {
                BusinessLogic.FiskalneGodine.pID = Convert.ToInt32(ugdFiskalneGodine.ActiveRow.Cells["IDGODINE"].Value);

                if (MessageBox.Show(string.Format("Obrisati fiskalnu godinu '{0}-{1}'?", BusinessLogic.CPVOznake.pID, BusinessLogic.CPVOznake.pID),
                    "Brisanje fiskalane godine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.FiskalneGodine fiskalne_godine = new BusinessLogic.FiskalneGodine();
                    if (!fiskalne_godine.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja fiskalne godine.\nKontaktirajte administratora [Error:00010]");
                    }
                    LoadGridFiskalneGodine();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdFiskalneGodine.ActiveRow != null)
            {
                BusinessLogic.FiskalneGodine.pID = Convert.ToInt32(ugdFiskalneGodine.ActiveRow.Cells["IDGODINE"].Value);
                BusinessLogic.FiskalneGodine.pAktivna = Convert.ToBoolean(ugdFiskalneGodine.ActiveRow.Cells["GODINEAKTIVNA"].Value);

                using (uscFiskalneGodine fiskalne_godine = new uscFiskalneGodine(Enums.FormEditMode.Copy))
                {
                    if (fiskalne_godine.ShowDialogForm("Fiskalne godine") == DialogResult.OK)
                    {
                        BusinessLogic.FiskalneGodine.pSelectedIndex = ugdFiskalneGodine.ActiveRow.Index;
                        LoadGridFiskalneGodine();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.FiskalneGodine.pSelectedIndex = ugdFiskalneGodine.ActiveRow.Index;
            }
            catch { }
            LoadGridFiskalneGodine();
        }

        #endregion

        private void FiskalneGodineFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridFiskalneGodine();
        }

        private void ugdFiskalneGodine_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }
    }
}
