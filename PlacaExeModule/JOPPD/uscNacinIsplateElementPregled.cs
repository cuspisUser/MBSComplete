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
    public partial class uscNacinIsplateElementPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscNacinIsplateElementPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Način isplate element - pregled", "Način isplate element - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridNacinIsplateElement()
        {
            BusinessLogic element = new BusinessLogic();

            ugdNacinIsplateElementPregled.DataSource = element.GetNacinIsplateElement();
            ugdNacinIsplateElementPregled.DataBind();

            Tools.UltraGridStyling(ugdNacinIsplateElementPregled);
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscNacinIsplateElement user_control = new uscNacinIsplateElement(Enums.FormEditMode.Insert))
            {
                if (user_control.ShowDialogForm("Način isplate element") == DialogResult.OK)
                    LoadGridNacinIsplateElement();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNacinIsplateElementPregled.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNacinIsplateElementPregled.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pJOPPDOznaka = (int)ugdNacinIsplateElementPregled.ActiveRow.Cells["JOPPDOznakaNacinaIsplateID"].Value;
                BusinessLogic.pElement = (int)ugdNacinIsplateElementPregled.ActiveRow.Cells["IDELEMENT"].Value;

                using (uscNacinIsplateElement user_control = new uscNacinIsplateElement(Enums.FormEditMode.Update))
                {
                    if (user_control.ShowDialogForm("Način isplate element") == DialogResult.OK)
                        LoadGridNacinIsplateElement();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdNacinIsplateElementPregled.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNacinIsplateElementPregled.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pElement = (int)ugdNacinIsplateElementPregled.ActiveRow.Cells["IDELEMENT"].Value;

                if (MessageBox.Show(string.Format("Obrisati način ispate element '{0}-{1}'?", BusinessLogic.pID, BusinessLogic.pElement),
                    "Brisanje načina ispalte element", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic delete = new BusinessLogic();
                    delete.DeleteNacinIsplateElement();
                    LoadGridNacinIsplateElement();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridNacinIsplateElement();
        }

        private void uscStjecateljPrimitkaPregled_Load(object sender, EventArgs e)
        {
            LoadGridNacinIsplateElement();
        }

        private void ugdStjecateljPrimitka_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion
    }
}
