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
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Microsoft.VisualBasic;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Practices.CompositeUI.WinForms;
using Deklarit.Practices.CompositeUI.Workspaces;

using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    [SmartPart]
    public partial class UstanovaSkolskaGodinaRazrednoOdjeljenjeForm : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        /// <summary>
        /// Composite UI
        /// ------------------------------------------------------------------ 
        /// Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)
        /// </summary>
        #region Composite UI - ALL code necessary

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

        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }
        private bool kontrola_za_editiranje { get; set; }
        /// <summary>
        /// globalna kontrola za refreshanje grida (UltraGridUstanoveSkolskeGodineRazrednaOdjeljenja). "Nije moguce drugacije napraviti zbog nemogucnosti pristupanja formi"
        /// </summary>
        public static bool refresh_grida = false; 

        public UstanovaSkolskaGodinaRazrednoOdjeljenjeForm()
        {
            InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("RAZREDNO ODJELJENJE", "RAZREDNO ODJELJENJE");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);

            if (Screen.PrimaryScreen.Bounds.Width <= 1366)
            {
                spcVertical.SplitterDistance = 620;
                spcHorizontal.SplitterDistance = 500;
            }
        }

        #region Event Handlers

        private void UstanovaSkolskaGodinaRazrednoOdjeljenjeForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxUstanoveSkolskeGodine();
            LoadComboBoxRazredi();
            LoadComboBoxOdjeljenja();
            LoadComboBoxVoditelji();

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormUstanovaSkolskaGodinaRazrednoOdjeljenje();
                LoadGridUstanovaSkolskaGodinaRazrednoOdjeljenjeUcenik();
            }

            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                FormPreviewEdit(PreviewEdit.Edit);
            }
            else
            {
                FormPreviewEdit(PreviewEdit.Preview);
            }
        }

        private void ToolStripButtonIzmijeni_Click(object sender, EventArgs e)
        {
            FormPreviewEdit(PreviewEdit.Edit);
            kontrola_za_editiranje = true;
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (ID == null)
                FormEditMode = Enums.FormEditMode.Insert;
            else
                FormEditMode = Enums.FormEditMode.Update;

            if (SaveData())
            {
                ComboBoxOdjeljenje.SelectedIndex = -1;
                ComboBoxRazred.SelectedIndex = -1;
                ComboBoxUstanovaSkolskaGodina.SelectedIndex = - 1;
                ComboBoxVoditelj.SelectedIndex = -1;
                UltraGridUcenici.DataSource = null;
            }
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (ID == null)
                FormEditMode = Enums.FormEditMode.Insert;
            else
                FormEditMode = Enums.FormEditMode.Update;

            if (SaveData())
            {
                refresh_grida = true;
                this.Dispose();
            }
        }

        private void btnRazrednoOdjeljenjeZatvori_Click(object sender, EventArgs e)
        {
            refresh_grida = true;
            this.Dispose();
        }

        #endregion

        private enum PreviewEdit
        {
            Preview,
            Edit
        }

        private void FormPreviewEdit(PreviewEdit previewEdit)
        {
            this.TableLayoutPanelPreview.Visible = (previewEdit == PreviewEdit.Preview);
            this.TableLayoutPanelEdit.Visible = (previewEdit == PreviewEdit.Edit);

            this.ToolStripButtonIzmijeni.Visible = (previewEdit == PreviewEdit.Preview);
            this.ToolStripButtonSpremi.Visible = (previewEdit == PreviewEdit.Edit);
            this.ToolStripButtonSpremiZatvori.Visible = (previewEdit == PreviewEdit.Edit);
            //this.btnRazrednoOdjeljenjeZatvori.Visible = (previewEdit == PreviewEdit.Edit);

            if (previewEdit == PreviewEdit.Edit)
            {
                this.ComboBoxUstanovaSkolskaGodina.Focus();
            }
        }

        private void LoadComboBoxUstanoveSkolskeGodine()
        {
            this.FormEditMode = ((UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem)this.Controller.WorkItem).FormEditMode;
            this.ID = ((UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem)this.Controller.WorkItem).RazrednoOdjeljenjeID;
            this.kontrola_za_editiranje = ((UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem)this.Controller.WorkItem).kontrola_za_editiranje;

            BusinessLogic.UstanoveSkolskeGodine ustanoveSkolskeGodine = new BusinessLogic.UstanoveSkolskeGodine();

            this.ComboBoxUstanovaSkolskaGodina.DataSource = ustanoveSkolskeGodine.GetUstanoveSkolskeGodineComboBox();
            this.ComboBoxUstanovaSkolskaGodina.DataBind();
        }

        private void LoadComboBoxRazredi()
        {
            BusinessLogic.Razredi razredi = new BusinessLogic.Razredi();

            this.ComboBoxRazred.DataSource = razredi.GetRazrediComboBox();
            this.ComboBoxRazred.DataBind();
        }

        private void LoadComboBoxOdjeljenja()
        {
            BusinessLogic.Odjeljenja odjeljenja = new BusinessLogic.Odjeljenja();

            this.ComboBoxOdjeljenje.DataSource = odjeljenja.GetOdjeljenjaComboBox();
            this.ComboBoxOdjeljenje.DataBind();
        }

        private void LoadComboBoxVoditelji()
        {
            BusinessLogic.Voditelji voditelji = new BusinessLogic.Voditelji();

            this.ComboBoxVoditelj.DataSource = voditelji.GetVoditeljiComboBox(this.ID, true);
            this.ComboBoxVoditelj.DataBind();
        }

        private void LoadFormUstanovaSkolskaGodinaRazrednoOdjeljenje()
        {
            BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja ustanoveSkolskeGodineRazrednaOdjeljenja = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja();

            var ustanovaSkolskaGodinaRazrednoOdjeljenje = ustanoveSkolskeGodineRazrednaOdjeljenja.GetUstanovaSkolskaGodinaRazredOdjeljenje(this.ID.GetValueOrDefault(0));

            this.ComboBoxUstanovaSkolskaGodina.Value = ustanovaSkolskaGodinaRazrednoOdjeljenje.UstanovaSkolskaGodinaID;
            this.ComboBoxRazred.Value = ustanovaSkolskaGodinaRazrednoOdjeljenje.RazredID;
            this.ComboBoxOdjeljenje.Value = ustanovaSkolskaGodinaRazrednoOdjeljenje.OdjeljenjeID;
            this.ComboBoxVoditelj.Value = ustanovaSkolskaGodinaRazrednoOdjeljenje.VoditeljID.GetValueOrDefault(0);

            this.LabelUstanovaSkolskaGodina.Text = string.Format("{0} / {1}",
                ustanovaSkolskaGodinaRazrednoOdjeljenje.UF_UstanovaSkolskaGodina.UF_Ustanova.Naziv,
                ustanovaSkolskaGodinaRazrednoOdjeljenje.UF_UstanovaSkolskaGodina.UF_SkolskaGodina.Naziv);

            this.LabelRazrednoOdjeljenje.Text = string.Format("{0} {1}",
                ustanovaSkolskaGodinaRazrednoOdjeljenje.UF_Razred.Naziv,
                ustanovaSkolskaGodinaRazrednoOdjeljenje.UF_Odjeljenje.Naziv);

            if (ustanovaSkolskaGodinaRazrednoOdjeljenje.VoditeljID != null)
            {
                this.LabelVoditelj.Text = string.Format("{0} {1}",
                    ustanovaSkolskaGodinaRazrednoOdjeljenje.UF_Voditelj.Ime,
                    ustanovaSkolskaGodinaRazrednoOdjeljenje.UF_Voditelj.Prezime);
            }
            else
            {
                this.LabelVoditelj.Text = string.Empty;
            }
        }

        private void LoadGridUstanovaSkolskaGodinaRazrednoOdjeljenjeUcenik()
        {
            BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici ustanoveSkolskeGodineRazrednaOdjeljenjaUcenici = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici();

            this.UltraGridUcenici.DataSource = ustanoveSkolskeGodineRazrednaOdjeljenjaUcenici.GetUstanovaSkolskaGodinaRazredOdjeljenjeUcenikMainGrid(this.ID.GetValueOrDefault(0));
            this.UltraGridUcenici.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridUcenici, new string[] { "Oznacen" });

            foreach (UltraGridRow row in UltraGridUcenici.Rows)
            {
                if (row.Index == BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici.pSelectedIndex)
                {
                    UltraGridUcenici.ActiveRow = row;
                }
            }
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja ustanoveSkolskeGodineRazrednaOdjeljenja = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja();


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                ustanoveSkolskeGodineRazrednaOdjeljenja.Add((int?)(this.ComboBoxUstanovaSkolskaGodina.Value != null ? this.ComboBoxUstanovaSkolskaGodina.Value : null),
                    (int?)(this.ComboBoxRazred.Value != null ? this.ComboBoxRazred.Value : null),
                    (int?)(this.ComboBoxOdjeljenje.Value != null ? this.ComboBoxOdjeljenje.Value : null),
                    (int?)(this.ComboBoxVoditelj.Value != null ? this.ComboBoxVoditelj.Value : null));
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                ustanoveSkolskeGodineRazrednaOdjeljenja.Update(this.ID.Value, (int?)(this.ComboBoxUstanovaSkolskaGodina.Value != null ? this.ComboBoxUstanovaSkolskaGodina.Value : null),
                    (int?)(this.ComboBoxRazred.Value != null ? this.ComboBoxRazred.Value : null),
                    (int?)(this.ComboBoxOdjeljenje.Value != null ? this.ComboBoxOdjeljenje.Value : null),
                    (int?)(this.ComboBoxVoditelj.Value != null ? this.ComboBoxVoditelj.Value : null));
            }

            if (ustanoveSkolskeGodineRazrednaOdjeljenja.IsValid)
            {
                bool result = ustanoveSkolskeGodineRazrednaOdjeljenja.Persist();

                if (ustanoveSkolskeGodineRazrednaOdjeljenja.RazrednoOdjeljenje != null)
                    this.ID = ustanoveSkolskeGodineRazrednaOdjeljenja.RazrednoOdjeljenje.ID;

                return result;
            }
            else
            {
                ustanoveSkolskeGodineRazrednaOdjeljenja.DisplayValidationMessages(this);
            }

            return false;
        }

        private void GridSelectDeselectAll(bool isChecked)
        {
            foreach (UltraGridRow row in this.UltraGridUcenici.Rows)
            {
                row.Cells["Oznacen"].Value = isChecked;
            }
        }

        #region Command's - command handlers for WorkItems

        [CommandHandler("DodajUcenika")]
        public void DodajUcenika(object sender, EventArgs e)
        {
            if (kontrola_za_editiranje)
            {
                if (this.ID == null) // save only when is NEW
                    if (!SaveData()) // exit scope if save with exception
                        return;


                UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregledWorkItem item = this.Controller.WorkItem.Items.Get<UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregledWorkItem>("UF.UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregled");

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
                    item = this.Controller.WorkItem.Items.AddNew<UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregledWorkItem>("UF.UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregled");
                }

                // Pass parameter
                item.RazrednoOdjeljenjeID = this.ID;

                // Show selection window
                item.ShowModal(true, string.Empty, null);


                BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici ucenici = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici();

                if (item.UceniciSelected != null)
                {
                    foreach (int ucenikID in item.UceniciSelected)
                    {
                        ucenici.Add(this.ID.Value, ucenikID);

                        if (ucenici.IsValid)
                        {
                            ucenici.Persist();
                        }
                        else
                        {
                            ucenici.DisplayValidationMessages();
                            return;
                        }
                    }
                }

                item.Terminate();
                item.Dispose();

                // Reload data
                try
                {
                    BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
                }
                catch { }
                LoadGridUstanovaSkolskaGodinaRazrednoOdjeljenjeUcenik();
            }
            else
            {
                MessageBox.Show("Da bi izmjenili ili unjeli podatke potrebno je pritisnuti gumb\n\"Izmjeni\""
                              + " u ljevom gornjem kutu.\nMolimo ne zaboravite spremiti podatke nakon izmjene!", "Razredna odjeljenja"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
            }
        }

        [CommandHandler("OznaciSve")]
        public void OznaciSve(object sender, EventArgs e)
        {
            if (kontrola_za_editiranje)
            {
                GridSelectDeselectAll(true);
            }
        }

        [CommandHandler("OdznaciSve")]
        public void OdznaciSve(object sender, EventArgs e)
        {
            if (kontrola_za_editiranje)
            {
                GridSelectDeselectAll(false);
            }
        }

        [CommandHandler("ObrisiOdabraneUcenike")]
        public void ObrisiOdabraneUcenike(object sender, EventArgs e)
        {
            if (kontrola_za_editiranje)
            {
                if (MessageBox.Show("Obrisati odabrane učenike?", "Brisanje učenika", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici razrednoOdjeljenjeUcenici = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici();

                    foreach (UltraGridRow row in this.UltraGridUcenici.Rows)
                    {
                        if ((bool)row.Cells["Oznacen"].Value)
                        {
                            int id = (int)row.Cells["ID"].Value;
                            razrednoOdjeljenjeUcenici.Delete(id);

                            if (razrednoOdjeljenjeUcenici.IsValid)
                            {
                                razrednoOdjeljenjeUcenici.Persist();
                            }
                            else
                            {
                                razrednoOdjeljenjeUcenici.DisplayValidationMessages();

                                break;
                            }
                        }
                    }

                    LoadGridUstanovaSkolskaGodinaRazrednoOdjeljenjeUcenik();
                }
            }
            else
            {
                MessageBox.Show("Da bi izmjenili ili unjeli podatke potrebno je pritisnuti gumb\n\"Izmjeni\""
                              + " u ljevom gornjem kutu.\nMolimo ne zaboravite spremiti podatke nakon izmjene!", "Razredna odjeljenja"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
            LoadGridUstanovaSkolskaGodinaRazrednoOdjeljenjeUcenik();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            if (kontrola_za_editiranje)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xls";
                saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
                saveFileDialog.FileName = "Učenici";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    new UltraGridExcelExporter().Export(this.UltraGridUcenici, saveFileDialog.FileName);
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }

        #endregion

    }
}
