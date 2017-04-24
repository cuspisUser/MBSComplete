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
    public partial class uscOznakaPrimitkaElementPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscOznakaPrimitkaElementPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Oznaka primitka element - pregled", "Oznaka primitka element - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridOznakaPrimitakElement()
        {
            BusinessLogic element = new BusinessLogic();

            ugdOznakaPrimitkaElement.DataSource = element.GetOznakaPrimitkaElement();
            ugdOznakaPrimitkaElement.DataBind();

            Tools.UltraGridStyling(ugdOznakaPrimitkaElement);
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscOznakaPrimitkaElement user_control = new uscOznakaPrimitkaElement(Enums.FormEditMode.Insert))
            {
                if (user_control.ShowDialogForm("Oznaka primitka element") == DialogResult.OK)
                    LoadGridOznakaPrimitakElement();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdOznakaPrimitkaElement.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdOznakaPrimitkaElement.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pJOPPDOznaka = (int)ugdOznakaPrimitkaElement.ActiveRow.Cells["JOPPDOznakaPrimitkaID"].Value;
                BusinessLogic.pElement = (int)ugdOznakaPrimitkaElement.ActiveRow.Cells["IDELEMENT"].Value;

                using (uscOznakaPrimitkaElement user_control = new uscOznakaPrimitkaElement(Enums.FormEditMode.Update))
                {
                    if (user_control.ShowDialogForm("Oznaka primitka element") == DialogResult.OK)
                        LoadGridOznakaPrimitakElement();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.ugdOznakaPrimitkaElement.ActiveRow != null)
            {
                BusinessLogic.pID = (int)ugdOznakaPrimitkaElement.ActiveRow.Cells["ID"].Value;
                BusinessLogic.pElement = (int)ugdOznakaPrimitkaElement.ActiveRow.Cells["IDELEMENT"].Value;

                if (MessageBox.Show(string.Format("Obrisati Oznaka primitka element '{0}-{1}'?", BusinessLogic.pID, BusinessLogic.pElement),
                    "Brisanje Oznaka primitka element", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic delete = new BusinessLogic();
                    delete.DeleteOznakaPrimitkaElement();
                    LoadGridOznakaPrimitakElement();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridOznakaPrimitakElement();
        }

        private void uscStjecateljPrimitkaPregled_Load(object sender, EventArgs e)
        {
            LoadGridOznakaPrimitakElement();
        }

        private void ugdStjecateljPrimitka_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion
    }
}
