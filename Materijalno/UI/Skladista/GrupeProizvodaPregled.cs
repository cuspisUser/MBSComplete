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
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid;

namespace Materijalno.UI.Skladista
{
    [SmartPart]
    public partial class GrupeProizvodaPregled : UserControl, ISmartPartInfoProvider
    {
        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

        private SmartPartInfo smartPartInfo1;
        private SmartPartInfoProvider infoProvider;

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

        #endregion

        #region Methods

        public GrupeProizvodaPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Unos Grupe proizvoda - pregled", "Unos Grupe proizvoda - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridData()
        {
            using (BusinessLogic.GrupeProizvoda objekt = new BusinessLogic.GrupeProizvoda())
            {
                ugdFormPregled.DataSource = objekt.GetMainGridData();
                ugdFormPregled.DataBind();
                Utils.Tools.UltraGridStyling(ugdFormPregled);

                if (ugdFormPregled.DisplayLayout.Bands.Count > 0)
                {
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    ugdFormPregled.DisplayLayout.Bands[0].Columns["Naziv"].Header.Caption = "Naziv grupe";
                }

                foreach (UltraGridRow row in ugdFormPregled.Rows)
                {
                    if (row.Index == BusinessLogic.GrupeProizvoda.pSelectedIndex)
                    {
                        ugdFormPregled.ActiveRow = row;
                    }
                }
            }
        }

        #endregion
        
        #region Events

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (GrupeProizvodaForm objekt = new GrupeProizvodaForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("GrupeProizvoda") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridData();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.GrupeProizvoda.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                using (GrupeProizvodaForm objekt = new GrupeProizvodaForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("GrupeProizvoda") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.GrupeProizvoda.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati Grupu proizvoda '{0}-{1}'?", BusinessLogic.TipSkladista.pID, ugdFormPregled.ActiveRow.Cells["Naziv"].Value),
                    "Brisanje Grupe proizvoda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (BusinessLogic.GrupeProizvoda objekt = new BusinessLogic.GrupeProizvoda())
                    {
                        StringBuilder message = new StringBuilder();

                        if (!objekt.Delete(message))
                        {
                            MessageBox.Show(message.ToString());
                        }
                        try
                        {
                            BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdFormPregled.ActiveRow != null)
            {
                BusinessLogic.GrupeProizvoda.pID = Convert.ToInt32(ugdFormPregled.ActiveRow.Cells["ID"].Value);

                using (GrupeProizvodaForm objekt = new GrupeProizvodaForm(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("GrupeProizvoda") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.GrupeProizvoda.pSelectedIndex = ugdFormPregled.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        private void FormDoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion
    }
}
