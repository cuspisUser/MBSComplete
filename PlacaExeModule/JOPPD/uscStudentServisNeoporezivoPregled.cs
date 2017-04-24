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
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;

namespace JOPPD
{
    [SmartPart]
    public partial class uscStudentServisNeoporezivoPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public uscStudentServisNeoporezivoPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Student servis neoporezivo - pregled", "Student servis neoporezivo - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadDataMainGrid()
        {
            BusinessLogic.ObracunRazno element = new BusinessLogic.ObracunRazno();

            ugdNagradeNatjecanja.DataSource = element.GetStudentServisNeoporezivo();
            ugdNagradeNatjecanja.DataBind();

            Tools.UltraGridStyling(ugdNagradeNatjecanja);

            if (ugdNagradeNatjecanja.DisplayLayout.Bands.Count > 0)
            {
                ugdNagradeNatjecanja.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                ugdNagradeNatjecanja.DisplayLayout.Bands[1].Columns["ID"].Hidden = true;
                ugdNagradeNatjecanja.DisplayLayout.Bands[1].Columns["ID_JOPPDObracunRazno"].Hidden = true;
            }
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscObracuni objekt = new uscObracuni(Enums.FormEditMode.Insert, Enums.Vrstaobracuna.StudentServisNeoporezivo))
            {
                if (objekt.ShowDialogForm("StudentServisNeoporezivo") == DialogResult.OK)
                    LoadDataMainGrid();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNagradeNatjecanja.ActiveRow != null)
            {
                BusinessLogic.ObracunRazno.pID_ObracunRazno = Convert.ToInt32(ugdNagradeNatjecanja.ActiveRow.Cells["ID"].Value);

                using (uscObracuni objekt = new uscObracuni(Enums.FormEditMode.Update, Enums.Vrstaobracuna.StudentServisNeoporezivo))
                {
                    if (objekt.ShowDialogForm("StudentServisNeoporezivo") == DialogResult.OK)
                        LoadDataMainGrid();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdNagradeNatjecanja.ActiveRow != null)
            {
                BusinessLogic.ObracunRazno.pID_ObracunRazno = (int)ugdNagradeNatjecanja.ActiveRow.Cells["ID"].Value;
                BusinessLogic.ObracunRazno.pNaziv = ugdNagradeNatjecanja.ActiveRow.Cells["Naziv"].Value.ToString();

                if (MessageBox.Show(string.Format("Obrisati obračun '{0}-{1}'?", BusinessLogic.ObracunRazno.pID_ObracunRazno, BusinessLogic.ObracunRazno.pNaziv),
                    "Brisanje obračuna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.ObracunRazno element = new BusinessLogic.ObracunRazno();
                    StringBuilder message = new StringBuilder();
                    if (!element.Delete(message))
                    {
                        MessageBox.Show(message.ToString());
                    }
                    LoadDataMainGrid();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            LoadDataMainGrid();
        }

        [CommandHandler("Virmani")]
        public void Virmani(object sender, EventArgs e)
        {
            if (this.ugdNagradeNatjecanja.ActiveRow != null)
            {
                this.Tag = Convert.ToInt32(ugdNagradeNatjecanja.ActiveRow.Cells["ID"].Value);
                this.Controls["ugdNagradeNatjecanja"].Text = ugdNagradeNatjecanja.ActiveRow.Cells["Naziv"].Value.ToString();

                VirmaniWorkItemUser.OsobeIzObracuna.obracunRaznoVrsta = Enums.Vrstaobracuna.StudentServisNeoporezivo;

                VirmaniWorkItemUser item = this.Controller.WorkItem.Items.Get<VirmaniWorkItemUser>("Obračuni razno");
            InitializeAgain:
                if (item != null)
                {
                    item.Terminate();
                    item.Dispose();
                    item = null;
                    goto InitializeAgain;
                }
                else
                {
                    item = this.Controller.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Obračuni razno");
                }

                item.Show(item.Workspaces["main"]);
            }
        }

        private void ugdNagrade_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        private void uscNagradePregled_Load(object sender, EventArgs e)
        {
            LoadDataMainGrid();
        }

        #endregion

    }
}
