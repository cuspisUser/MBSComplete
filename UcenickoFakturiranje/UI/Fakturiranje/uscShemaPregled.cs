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

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    [SmartPart]
    public partial class uscShemaPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscShemaPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Shema UF - pregled", "Shema UF - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridShema()
        {
            BusinessLogic.Obracuni obracuni = new BusinessLogic.Obracuni();

            ugdShema.DataSource = obracuni.GetShema();
            ugdShema.DataBind();

            Utils.Tools.UltraGridStyling(ugdShema);
        }

        #endregion

        #region Dogadaji

        private void uscShemaPregled_Load(object sender, EventArgs e)
        {
            LoadGridShema();
        }

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            //if (ugdShema.ActiveRow != null)
            //{
            //    MessageBox.Show("Nije moguče napravit više od jedne sheme\nknjiženja za učeničko fakturiranje.");
            //}
            //else
            //{
                
            //}

            using (uscShema uscShema = new uscShema(Enums.FormEditMode.Insert, -1))
            {
                uscShema.ShowDialogForm("Shema učeničko fakturiranje");
                LoadGridShema();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdShema.ActiveRow != null)
            {
                BusinessLogic.Obracuni.pIDShema = (int)ugdShema.ActiveRow.Cells["ID"].Value;

                using (uscShema uscShema = new uscShema(Enums.FormEditMode.Update, BusinessLogic.Obracuni.pIDShema))
                {
                    uscShema.ShowDialogForm("Shema učeničko fakturiranje");
                    LoadGridShema();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdShema.ActiveRow != null)
            {
                BusinessLogic.Obracuni.pIDShema = Convert.ToInt32(ugdShema.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati shemu '{0}-{1}'?", BusinessLogic.Obracuni.pIDShema, ugdShema.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje sheme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Obracuni obracuni = new BusinessLogic.Obracuni();
                    obracuni.DeleteShema();
                    LoadGridShema();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadGridShema();
        }

        #endregion

        private void ugdShema_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

    }
}
