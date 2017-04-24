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
    public partial class uscNeoporeziviPrimitakElementPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscNeoporeziviPrimitakElementPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Neoporeziv primitak element - pregled", "Neoporeziv primitak element - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridNNeoporeziviPrimitakElement()
        {
            BusinessLogic element = new BusinessLogic();

            ugdNeoporeziviPrimitakElement.DataSource = element.GetNeoporeziviPrimitakElement();
            ugdNeoporeziviPrimitakElement.DataBind();

            Tools.UltraGridStyling(ugdNeoporeziviPrimitakElement);
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscNeoporeziviPrimitakElement user_control = new uscNeoporeziviPrimitakElement(Enums.FormEditMode.Insert))
            {
                if (user_control.ShowDialogForm("Neoporezivi primitak element") == DialogResult.OK)
                    LoadGridNNeoporeziviPrimitakElement();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNeoporeziviPrimitakElement.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNeoporeziviPrimitakElement.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pJOPPDOznaka = (int)ugdNeoporeziviPrimitakElement.ActiveRow.Cells["JOPPDOznakaNeoporezivogPrimitkaID"].Value;
                BusinessLogic.pElement = (int)ugdNeoporeziviPrimitakElement.ActiveRow.Cells["IDELEMENT"].Value;

                using (uscNeoporeziviPrimitakElement user_control = new uscNeoporeziviPrimitakElement(Enums.FormEditMode.Update))
                {
                    if (user_control.ShowDialogForm("Naeoporezivi primitak element") == DialogResult.OK)
                        LoadGridNNeoporeziviPrimitakElement();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdNeoporeziviPrimitakElement.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdNeoporeziviPrimitakElement.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pElement = (int)ugdNeoporeziviPrimitakElement.ActiveRow.Cells["IDELEMENT"].Value;

                if (MessageBox.Show(string.Format("Obrisati neoporezivi primitak element '{0}-{1}'?", BusinessLogic.pID, BusinessLogic.pElement),
                    "Brisanje neoporezivog primitka element", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic delete = new BusinessLogic();
                    delete.DeleteNeoporeziviPrimitakElement();
                    LoadGridNNeoporeziviPrimitakElement();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridNNeoporeziviPrimitakElement();
        }

        private void uscStjecateljPrimitkaPregled_Load(object sender, EventArgs e)
        {
            LoadGridNNeoporeziviPrimitakElement();
        }

        private void ugdStjecateljPrimitka_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion
    }
}
