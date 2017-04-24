using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetAdvantage.WorkItems;
using UcenickoFakturiranje.Enums;
using UcenickoFakturiranje.UI.Fakturiranje;
using UcenickoFakturiranje.BusinessLogic;
using System.Collections;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Practices.CompositeUI.WinForms;


namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class uscRekapitulacijaRazrednoOdjeljenje : Controls.BaseUserControl, ISmartPartInfoProvider, IFilteredView
    {

        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

        private SmartPartInfoProvider infoProvider { get; set; }
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

        
        #region Dogadaji

        private void btnObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void btnVirmani_Click(object sender, EventArgs e)
        {
            if (ucbUstanova.Value != null && ucbRazrednaOdjeljenja.Value != null)
            {
                Obracuni.pRazrednoOdjeljenje = (int)ucbRazrednaOdjeljenja.Value;
                Obracuni.pUstanova = (int)ucbUstanova.Value;


                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
            else
            {
                MessageBox.Show("Odaberite ustanovu i razredno odjeljenje!!!");
            }
        }

 
        #endregion

        #region Metode

        public uscRekapitulacijaRazrednoOdjeljenje()
        {
            InitializeComponent();
            lblObracun.Text = Obracuni.pNaziv;
            LoadCombo();
        }

        public void LoadCombo()
        {
            Obracuni Obracuni = new Obracuni();

            ucbRazrednaOdjeljenja.DataSource = Obracuni.GetRazrednaOdjeljenja();
            ucbRazrednaOdjeljenja.DataBind();

            ucbUstanova.DataSource = Obracuni.GetUstanova();
            ucbUstanova.DataBind();
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public object DBNullToString(object value, string defaultValue)
        {
            if (value == DBNull.Value)
                return defaultValue;

            return value;
        }

        #endregion

    }
}
