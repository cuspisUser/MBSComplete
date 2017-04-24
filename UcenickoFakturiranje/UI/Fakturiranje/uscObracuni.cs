using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    public partial class uscObracuni : Controls.BaseUserControl, ISmartPartInfoProvider, IFilteredView
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

        #region Svojstva

        private int? ID 
        { 
            get; set; 
        }
        private FormEditMode FormEditMode 
        { 
            get; set; 
        }

        #endregion

        #region Dogadaji

        private void btnObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void btnObracunKreni_Click(object sender, EventArgs e)
        {
            if (uneObracuniMjesec.Value == null)
            {
                Obracuni.pMjesecObracuna = (int?)uneObracuniMjesec.Value;
            }
            else
            {
                Obracuni.pMjesecObracuna = Convert.ToInt32(uneObracuniMjesec.Value);
            }

            Obracuni.pGodinaObracuna = (int?)uneObracuniGodina.Value;
            Obracuni.pValutaPlacanja = udtObracunValutaPlacanja.DateTime;
            Obracuni.pNaziv = uteObracunNaziv.Text;
            Obracuni.pkolicinaZaObracun = (int?)uneObracunKolicina.Value;
            if (btnObracunKreni.Tag == null)
                Obracuni.pPregledObracuna = false;
            else
                Obracuni.pPregledObracuna = true;

            using (uscIzracunObracun IzracunObracun = new uscIzracunObracun(FormEditMode, ID))
            {

                StringBuilder message = IzracunObracun.ValidateDataInput();
                if (message.Length == 0)
                {
                    IzracunObracun.SaveObracun();
                    lblValidationMessages.ResetText();
                    if (IzracunObracun.ShowDialogForm("Obračun") == DialogResult.OK)
                    {
                        base.ContainerForm.DialogResult = DialogResult.OK;
                        base.ContainerForm.Close();
                    }
                }
                else
                {
                    lblValidationMessages.Text = message.ToString();
                }
            }
        }

        private void uscObracuni_Load(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update)
            {

                uneObracuniMjesec.Value = Obracuni.pMjesecObracuna;
                uneObracuniGodina.Value = Obracuni.pGodinaObracuna;
                uneObracunKolicina.Value = Obracuni.pkolicinaZaObracun;
                if (Obracuni.pValutaPlacanja != null)
                    udtObracunValutaPlacanja.Value = Obracuni.pValutaPlacanja;
                else
                    udtObracunValutaPlacanja.Value = DateTime.Now;

                uteObracunNaziv.Text = Obracuni.pNaziv;
            }
        }

        #endregion

        #region Metode

        public uscObracuni(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();


            FormEditMode = formEditMode;
            ID = id;

            if (formEditMode == Enums.FormEditMode.Update)
            {
                btnObracunKreni.Text = "Pregledaj/Uredi obračun";
                btnObracunKreni.Tag = "Pregled";
            }
            else
            {
                btnObracunKreni.Text = "Kreni s obračunom";
                btnObracunKreni.Tag = null;
            }
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
