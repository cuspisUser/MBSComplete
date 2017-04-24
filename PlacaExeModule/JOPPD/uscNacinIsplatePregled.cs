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

namespace JOPPD
{
    [SmartPart]
    public partial class uscNacinIsplatePregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscNacinIsplatePregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Način isplate - pregled", "Način isplate - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridNacinIsplate()
        {
            BusinessLogic nacin_isplate = new BusinessLogic();

            ugdNacinIsplate.DataSource = nacin_isplate.GetNacinIsplate();
            ugdNacinIsplate.DataBind();

            Tools.UltraGridStyling(ugdNacinIsplate);
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscNacinIsplate user_control = new uscNacinIsplate(Enums.FormEditMode.Insert))
            {
                if (user_control.ShowDialogForm("Način isplate") == DialogResult.OK)
                    LoadGridNacinIsplate();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNacinIsplate.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNacinIsplate.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pOznaka = ugdNacinIsplate.ActiveRow.Cells["Oznaka"].Value.ToString();
                BusinessLogic.pKratkiOpis = ugdNacinIsplate.ActiveRow.Cells["KratkiOpis"].Value.ToString();
                BusinessLogic.pDugiOpis = ugdNacinIsplate.ActiveRow.Cells["DugiOpis"].Value.ToString();

                using (uscNacinIsplate user_control = new uscNacinIsplate(Enums.FormEditMode.Update))
                {
                    if (user_control.ShowDialogForm("Neačin isplate") == DialogResult.OK)
                        LoadGridNacinIsplate();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdNacinIsplate.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNacinIsplate.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pOznaka = ugdNacinIsplate.ActiveRow.Cells["Oznaka"].Value.ToString();

                if (MessageBox.Show(string.Format("Obrisati način isplate '{0}-{1}'?", BusinessLogic.pID, BusinessLogic.pOznaka),
                    "Brisanje načina isplate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic delete = new BusinessLogic();
                    delete.Delete("JOPPDOznakaNacinaIsplate");
                    LoadGridNacinIsplate();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridNacinIsplate();
        }

        private void uscNacinIsplatePregled_Load(object sender, EventArgs e)
        {
            LoadGridNacinIsplate();
        }

        private void ugdNacinIsplate_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion
    }
}
