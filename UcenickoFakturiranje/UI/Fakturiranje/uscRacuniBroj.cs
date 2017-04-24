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
    public partial class uscRacuniBroj : Controls.BaseUserControl, ISmartPartInfoProvider, IFilteredView
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

        public int pyear { get; set; }
        public int pod { get; set; }
        public int pdo { get; set; }
        private bool pVrsta { get; set;}

        #region Dogadaji

        private void btnVirmani_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            int parser;
            if (!Int32.TryParse(uteOD.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format početnog broja računa!");
            }

            if (!Int32.TryParse(uteDo.Value.ToString(), out parser))
            {
                message.Append(" - krivi format završnog broja računa!");
            }

            if (ucbGodina.Value == null)
            {
                message.Append(" - potrebno je odabrati godinu!");
            }

            if (message.Length == 0)
            {
                pod = Convert.ToInt32(uteOD.Value);
                pdo = Convert.ToInt32(uteDo.Value);
                pyear = Convert.ToInt32(ucbGodina.Value);

                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
            else
            {
                MessageBox.Show(message.ToString());
            }
        }

 
        #endregion

        #region Metode

        public uscRacuniBroj(bool vrsta)
        {
            InitializeComponent();

            if (vrsta)
            {
                lblName1.Text = "Ispis računa od broja do broja za godinu";
                btnIspis.Text = "Ispis";
            }
            else
            {
                lblName1.Text = "Prijenos računa od broja do broja za godinu";
                btnIspis.Text = "Prenesi";
            }

            LoadGodina();
        }

        private void LoadGodina()
        {
            using(BusinessLogic.Racuni objekt = new Racuni())
            {
                ucbGodina.DataSource = objekt.LoadGodina();
            }
        }


        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        #endregion

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void lblName1_Click(object sender, EventArgs e)
        {

        }
    }
}
