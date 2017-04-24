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
    public partial class uscNeoporezivPrimitakPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscNeoporezivPrimitakPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Neoporezivi primitak - pregled", "Neoporezivi primitak - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridNeoporeziviPrimitak()
        {
            BusinessLogic neoporezivi_primitak = new BusinessLogic();

            ugdNeoporeziviPrimitak.DataSource = neoporezivi_primitak.GetNeoporeziviPrimitak();
            ugdNeoporeziviPrimitak.DataBind();

            Tools.UltraGridStyling(ugdNeoporeziviPrimitak);
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscNeoporezivPrimitak user_control = new uscNeoporezivPrimitak(Enums.FormEditMode.Insert))
            {
                if (user_control.ShowDialogForm("Neoporeziv primitak") == DialogResult.OK)
                    LoadGridNeoporeziviPrimitak();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNeoporeziviPrimitak.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNeoporeziviPrimitak.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pOznaka = ugdNeoporeziviPrimitak.ActiveRow.Cells["Oznaka"].Value.ToString();
                BusinessLogic.pKratkiOpis = ugdNeoporeziviPrimitak.ActiveRow.Cells["KratkiOpis"].Value.ToString();
                BusinessLogic.pDugiOpis = ugdNeoporeziviPrimitak.ActiveRow.Cells["DugiOpis"].Value.ToString();

                using (uscNeoporezivPrimitak user_control = new uscNeoporezivPrimitak(Enums.FormEditMode.Update))
                {
                    if (user_control.ShowDialogForm("Neoporeziv primitak") == DialogResult.OK)
                        LoadGridNeoporeziviPrimitak();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdNeoporeziviPrimitak.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNeoporeziviPrimitak.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pOznaka = ugdNeoporeziviPrimitak.ActiveRow.Cells["Oznaka"].Value.ToString();

                if (MessageBox.Show(string.Format("Obrisati neoporezivi primitak '{0}-{1}'?", BusinessLogic.pID, BusinessLogic.pOznaka),
                    "Brisanje neoporezivog primitka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic delete = new BusinessLogic();
                    delete.Delete("JOPPDOznakaNeoporezivogPrimitka");
                    LoadGridNeoporeziviPrimitak();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridNeoporeziviPrimitak();
        }

        private void uscNeoporezivPrimitakPregled_Load(object sender, EventArgs e)
        {
            LoadGridNeoporeziviPrimitak();
        }

        private void ugdNeoporeziviPrimitak_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion

    }
}
