using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using JOPPD.Enums;

namespace JOPPD
{
    public partial class uscObracuniOsobe : Controls.BaseUserControl
    {
        #region Svojstva

        private FormEditMode pFormEditMode
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscObracuniOsobe(FormEditMode vrsta_promjene)
        {
            InitializeComponent();
            pFormEditMode = vrsta_promjene;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();

            DataRow[] lociranje_osobe;
            //zbog mogucnosti kombiniranja vise vrsta osoba
            DataTable temp = BusinessLogic.ObracunRazno.pOdabraneOsobe.Copy();
            DataRow[] row = null;
            BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Clear();

            if (message.Length == 0)
            {
                if (BusinessLogic.ObracunRazno.pOstalo)
                {
                    if (pFormEditMode == FormEditMode.Insert)
                    {
                        foreach (UltraGridRow red in ugdOstalo.Rows)
                        {
                            if (Convert.ToBoolean(red.Cells["Ozn"].Value))
                            {
                                BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.Ostalo,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                            }
                        }
                    }
                    else if (pFormEditMode == FormEditMode.Update)
                    {

                        foreach (UltraGridRow red in ugdOstalo.Rows)
                        {
                            if (Convert.ToBoolean(red.Cells["Ozn"].Value))
                            {
                                //ako postoji unese ga iz tempa u suprotnom dodaje novi
                                row = temp.Select("OIB = " + red.Cells["OIB"].Value);
                                if (row != null)
                                {
                                    if (row.Length > 0)
                                    {
                                        BusinessLogic.ObracunRazno.pOdabraneOsobe.ImportRow(row[0]);
                                    }
                                }

                                if (BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = " + red.Cells["OIB"].Value).Length == 0)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.Ostalo,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                                }
                            }
                            else
                            {
                                lociranje_osobe = BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = " + red.Cells["OIB"].Value);
                                if (lociranje_osobe.Length == 1)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Remove(lociranje_osobe[0]);
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.AcceptChanges();
                                }
                            }
                        }
                    }
                }
                if (BusinessLogic.ObracunRazno.pUcenik)
                {
                    if (pFormEditMode == FormEditMode.Insert)
                    {
                        foreach (UltraGridRow red in ugdUcenici.Rows)
                        {
                            if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "UF")
                            {
                                BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.Ucenik,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                            }
                            else if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "PR")
                            {
                                BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.UcenikPraksa,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                            }
                        }
                    }
                    else if (pFormEditMode == FormEditMode.Update)
                    {
                        foreach (UltraGridRow red in ugdUcenici.Rows)
                        {

                            if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "UF")
                            {
                                //ako postoji unese ga iz tempa u suprotnom dodaje novi
                                row = temp.Select("OIB = " + red.Cells["OIB"].Value);
                                if (row != null)
                                {
                                    if (row.Length > 0)
                                    {
                                        BusinessLogic.ObracunRazno.pOdabraneOsobe.ImportRow(row[0]);
                                    }
                                }

                                if (BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = " + red.Cells["OIB"].Value).Length == 0)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.Ucenik,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                             red.Cells["OIB"].Value.ToString(), 0);
                                }
                            }
                            else if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "PR")
                            {
                                //ako postoji unese ga iz tempa u suprotnom dodaje novi
                                row = temp.Select("OIB = " + red.Cells["OIB"].Value);
                                if (row != null)
                                {
                                    if (row.Length > 0)
                                    {
                                        BusinessLogic.ObracunRazno.pOdabraneOsobe.ImportRow(row[0]);
                                    }
                                }

                                if (BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = " + red.Cells["OIB"].Value).Length == 0)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.UcenikPraksa,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                                }
                            } 
                            else
                            {
                                lociranje_osobe = BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = '" + red.Cells["OIB"].Value.ToString() + "'");
                                if (lociranje_osobe.Length == 1)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Remove(lociranje_osobe[0]);
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.AcceptChanges();
                                }
                            }
                        }
                    }
                }
                if (BusinessLogic.ObracunRazno.pRoditelj)
                {
                    if (pFormEditMode == FormEditMode.Insert)
                    {
                        foreach (UltraGridRow red in ugdRoditelji.Rows)
                        {
                            if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "UF")
                            {

                                BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.Roditelj,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                            }
                            else if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "PR")
                            {
                                BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.RoditeljPraksa,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                            }
                        }
                    }
                    else if (pFormEditMode == FormEditMode.Update)
                    {
                        foreach (UltraGridRow red in ugdRoditelji.Rows)
                        {
                            if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "UF")
                            {
                                //ako postoji unese ga iz tempa u suprotnom dodaje novi
                                row = temp.Select("OIB = " + red.Cells["OIB"].Value);
                                if (row != null)
                                {
                                    if (row.Length > 0)
                                    {
                                        BusinessLogic.ObracunRazno.pOdabraneOsobe.ImportRow(row[0]);
                                    }
                                }

                                if (BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = " + red.Cells["OIB"].Value).Length == 0)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.Roditelj,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                                }
                            }
                            else if (Convert.ToBoolean(red.Cells["Ozn"].Value) && red.Cells["Tip"].Value.ToString() == "PR")
                            {
                                //ako postoji unese ga iz tempa u suprotnom dodaje novi
                                row = temp.Select("OIB = " + red.Cells["OIB"].Value);
                                if (row != null)
                                {
                                    if (row.Length > 0)
                                    {
                                        BusinessLogic.ObracunRazno.pOdabraneOsobe.ImportRow(row[0]);
                                    }
                                }

                                if (BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = " + red.Cells["OIB"].Value).Length == 0)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Add((int)red.Cells["ID"].Value, (int)Enums.VrsteOsoba.RoditeljPraksa,
                                                            red.Cells["ID_Opcina"].Value.ToString(), 0,
                                                            red.Cells["Ime"].Value.ToString(), red.Cells["Prezime"].Value.ToString(),
                                                            red.Cells["OIB"].Value.ToString(), 0);
                                }
                            }
                            else
                            {
                                lociranje_osobe = BusinessLogic.ObracunRazno.pOdabraneOsobe.Select("OIB = " + red.Cells["OIB"].Value);
                                if (lociranje_osobe.Length == 1)
                                {
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows.Remove(lociranje_osobe[0]);
                                    BusinessLogic.ObracunRazno.pOdabraneOsobe.AcceptChanges();
                                }
                            }
                        }
                    }
                }

                if (pFormEditMode == FormEditMode.Insert)
                {
                    using (uscObracuniOsobeZaduzenje objekt = new uscObracuniOsobeZaduzenje(Enums.FormEditMode.Insert))
                    {
                        if (objekt.ShowDialogForm(BusinessLogic.ObracunRazno.pVrstaObracuna) == DialogResult.OK)
                        {
                            return true;
                        }
                    }
                }
                else if (pFormEditMode == FormEditMode.Update)
                {
                    using (uscObracuniOsobeZaduzenje objekt = new uscObracuniOsobeZaduzenje(Enums.FormEditMode.Update))
                    {
                        if (objekt.ShowDialogForm(BusinessLogic.ObracunRazno.pVrstaObracuna) == DialogResult.OK)
                        {
                            return true;
                        }
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();
            bool kontrola = false;

            if (BusinessLogic.ObracunRazno.pOstalo)
            {
                foreach (UltraGridRow row in ugdOstalo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                    {
                        kontrola = true;
                    } 
                }
            }

            if (BusinessLogic.ObracunRazno.pUcenik)
            {
                foreach (UltraGridRow row in ugdUcenici.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                    {
                        kontrola = true;
                    }
                }
            }

            if (BusinessLogic.ObracunRazno.pRoditelj)
            {
                foreach (UltraGridRow row in ugdRoditelji.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                    {
                        kontrola = true;
                    }
                }
            }

            if (!kontrola)
            {
                message.Append(" - Potrebno je odabrati barem 1 osobu za nastavak");
            }

            return message;
        }

        private T IsDbNull<T>(object value)
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return default(T);
        }

        private void PrikazTabova()
        {
            BusinessLogic.ObracunRazno objekt = new BusinessLogic.ObracunRazno();

            if (!BusinessLogic.ObracunRazno.pUcenik)
            {
                tbcPrikazOsoba.TabPages.Remove(tbcPrikazOsoba.TabPages["tpUcenici"]);
            }
            else
            {
                if (BusinessLogic.ObracunRazno.pUF & !BusinessLogic.ObracunRazno.pPraksa)
                {
                    ugdUcenici.DataSource = objekt.GetUceniciUF();
                    ugdUcenici.DataBind();
                    Tools.UltraGridStyling(ugdUcenici);

                    if (ugdUcenici.DisplayLayout.Bands.Count > 0)
                    {
                        ugdUcenici.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["ID_Opcina"].Hidden = true;
                    }
                }
                else if (BusinessLogic.ObracunRazno.pUF & BusinessLogic.ObracunRazno.pPraksa)
                {
                    ugdUcenici.DataSource = objekt.GetUceniciAll();
                    ugdUcenici.DataBind();
                    Tools.UltraGridStyling(ugdUcenici);

                    if (ugdUcenici.DisplayLayout.Bands.Count > 0)
                    {
                        ugdUcenici.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["ID_Opcina"].Hidden = true;
                    }
                }
                else if (!BusinessLogic.ObracunRazno.pUF & BusinessLogic.ObracunRazno.pPraksa)
                {
                    ugdUcenici.DataSource = objekt.GetUceniciPraksa();
                    ugdUcenici.DataBind();
                    Tools.UltraGridStyling(ugdUcenici);

                    if (ugdUcenici.DisplayLayout.Bands.Count > 0)
                    {
                        ugdUcenici.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                        ugdUcenici.DisplayLayout.Bands[0].Columns["ID_Opcina"].Hidden = true;
                    }
                }

                if (pFormEditMode == FormEditMode.Update)
                {
                    foreach (UltraGridRow red in ugdUcenici.Rows)
                    {
                        foreach (DataRow red2 in BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows)
                        {
                            if (red.Cells["OIB"].Value.ToString() == red2["OIB"].ToString())
                            {
                                red.Cells["Ozn"].Value = true;
                            }
                        }
                    }
                }
            }

            if (!BusinessLogic.ObracunRazno.pRoditelj)
            {
                tbcPrikazOsoba.TabPages.Remove(tbcPrikazOsoba.TabPages["tpRoditelji"]);
            }
            else
            {
                ugdRoditelji.DataSource = objekt.GetRoditelji();
                ugdRoditelji.DataBind();
                Tools.UltraGridStyling(ugdRoditelji);

                if (ugdRoditelji.DisplayLayout.Bands.Count > 0)
                {
                    ugdRoditelji.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdRoditelji.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdRoditelji.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    ugdRoditelji.DisplayLayout.Bands[0].Columns["ID_Opcina"].Hidden = true;
                }

                if (pFormEditMode == FormEditMode.Update)
                {
                    foreach (UltraGridRow red in ugdRoditelji.Rows)
                    {
                        foreach (DataRow red2 in BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows)
                        {
                            if (red.Cells["OIB"].Value.ToString() == red2["OIB"].ToString())
                            {
                                red.Cells["Ozn"].Value = true;
                            }
                        }
                    }
                }
            }
            if (!BusinessLogic.ObracunRazno.pOstalo)
            {
                tbcPrikazOsoba.TabPages.Remove(tbcPrikazOsoba.TabPages["tpOstalo"]);
            }
            else
            {
                ugdOstalo.DataSource = objekt.GetOstalo();
                ugdOstalo.DataBind();
                Tools.UltraGridStyling(ugdOstalo);

                if (ugdOstalo.DisplayLayout.Bands.Count > 0)
                {
                    ugdOstalo.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdOstalo.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdOstalo.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    ugdOstalo.DisplayLayout.Bands[0].Columns["ID_Opcina"].Hidden = true;
                }

                if (pFormEditMode == FormEditMode.Update)
                {
                    foreach (UltraGridRow red in ugdOstalo.Rows)
                    {
                        foreach (DataRow red2 in BusinessLogic.ObracunRazno.pOdabraneOsobe.Rows)
                        {
                            if (red.Cells["OIB"].Value.ToString() == red2["OIB"].ToString())
                            {
                                red.Cells["Ozn"].Value = true;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Događaji


        private void btnKreni_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ContainerForm.DialogResult = DialogResult.OK;
                ContainerForm.Close();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            ContainerForm.DialogResult = DialogResult.OK;
            ContainerForm.Close();
        }

        private void uscObracuniOsobe_Load(object sender, EventArgs e)
        {
            PrikazTabova();
            if (pFormEditMode == FormEditMode.Insert)
            {
                BusinessLogic.ObracunRazno.pOdabraneOsobe = new DataTable("OdabraneOsobe");
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("ID_Osobe", typeof(int));
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("ID_VrstaVeze", typeof(int));
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("ID_Opcina", typeof(string));
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("ID_NacinIsplate", typeof(int));
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("Ime", typeof(string));
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("Prezime", typeof(string));
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("OIB", typeof(string));
                BusinessLogic.ObracunRazno.pOdabraneOsobe.Columns.Add("Iznos", typeof(decimal));
            }
        }

        #endregion

    }
}
