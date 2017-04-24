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
    public partial class uscOznakaPrimitkaPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscOznakaPrimitkaPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Oznaka primitka - pregled", "Oznaka primitka - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridOznakaPrimitka()
        {
            BusinessLogic oznaka_primitka = new BusinessLogic();

            ugdOznakaPrimitka.DataSource = oznaka_primitka.GetOznakaPrimitka();
            ugdOznakaPrimitka.DataBind();

            Tools.UltraGridStyling(ugdOznakaPrimitka);
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscOznakaPrimitka user_control = new uscOznakaPrimitka(Enums.FormEditMode.Insert))
            {
                if (user_control.ShowDialogForm("Oznaka primitka") == DialogResult.OK)
                    LoadGridOznakaPrimitka();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdOznakaPrimitka.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdOznakaPrimitka.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pOznaka = ugdOznakaPrimitka.ActiveRow.Cells["Oznaka"].Value.ToString();
                BusinessLogic.pKratkiOpis = ugdOznakaPrimitka.ActiveRow.Cells["KratkiOpis"].Value.ToString();
                BusinessLogic.pDugiOpis = ugdOznakaPrimitka.ActiveRow.Cells["DugiOpis"].Value.ToString();

                using (uscOznakaPrimitka user_control = new uscOznakaPrimitka(Enums.FormEditMode.Update))
                {
                    if (user_control.ShowDialogForm("Oznaka primitka") == DialogResult.OK)
                        LoadGridOznakaPrimitka();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdOznakaPrimitka.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdOznakaPrimitka.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pOznaka = ugdOznakaPrimitka.ActiveRow.Cells["Oznaka"].Value.ToString();

                if (MessageBox.Show(string.Format("Obrisati oznaku primitka '{0}-{1}'?", BusinessLogic.pID, BusinessLogic.pOznaka),
                    "Brisanje oznake primitka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic delete = new BusinessLogic();
                    delete.Delete("JOPPDOznakaPrimitka");
                    LoadGridOznakaPrimitka();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridOznakaPrimitka();
        }

        private void uscOznakaPrimitkaPregled_Load(object sender, EventArgs e)
        {
            LoadGridOznakaPrimitka();
        }

        private void ugdOznakaPrimitka_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion

        
    }
}
