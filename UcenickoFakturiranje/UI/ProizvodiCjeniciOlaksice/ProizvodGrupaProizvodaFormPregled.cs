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
using System.Data.SqlClient;
using Infragistics.Win.UltraWinGrid;

namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    [SmartPart]
    public partial class ProizvodGrupaProizvodaFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public ProizvodGrupaProizvodaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("PROIZVODI - pregled", "PROIZVODI - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void ProizvodGrupaProizvodaFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridProizvodi();
            
        }

        private void UltraGridProizvodi_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void LoadGridProizvodi()
        {

            BusinessLogic.ProizvodiGrupeProizvoda proizvodi = new BusinessLogic.ProizvodiGrupeProizvoda();
            Mipsed7.DataAccessLayer.SqlClient sql = new Mipsed7.DataAccessLayer.SqlClient();
            DataSet ds = new DataSet();

            DataTable UF_Proizvodi = sql.GetDataTable(" SELECT     UF_Proizvod.ID, UF_Proizvod.Naziv, JEDINICAMJERE.NAZIVJEDINICAMJERE AS JedinicaMjere, UF_Proizvod.Cijena As [Jedinična cijena], UF_ProizvodTipKolicine.Naziv as TipObracunskeKolicine, " +
                                                        "                       UF_Proizvod.IsGrupa AS Grupa " +
                                                        " FROM         UF_Proizvod INNER JOIN " +
                                                        "                      JEDINICAMJERE ON UF_Proizvod.JedinicaMjereID = JEDINICAMJERE.IDJEDINICAMJERE INNER JOIN " +
                                                        "                      UF_ProizvodTipKolicine ON UF_Proizvod.TipKolicineID = UF_ProizvodTipKolicine.ID " +
                                                        " order by UF_Proizvod.ID ");
            UF_Proizvodi.Columns["Grupa"].ReadOnly = false;
            foreach (DataRow row in UF_Proizvodi.Rows)
            {
                if (row["Grupa"] == null)
                {
                    row["Grupa"] = false;
                }
                else if (row["Grupa"].ToString().Length == 0)
                {
                    row["Grupa"] = false;
                }
            }
            DataTable UF_ProizvodiStavke = sql.GetDataTable("SELECT     UF_ProizvodStavka.ProizvodID, UF_ProizvodStavka.ProizvodStavkaID as Stavka, UF_Proizvod.Naziv, JEDINICAMJERE.NAZIVJEDINICAMJERE as 'Jedinica mjere', UF_ProizvodTipKolicine.Naziv AS 'Tip količine u obračunu'  " +
                                                            " FROM         UF_ProizvodStavka INNER JOIN " +
                                                            "                      UF_Proizvod ON UF_ProizvodStavka.ProizvodStavkaID = UF_Proizvod.ID INNER JOIN " +
                                                            "                      UF_ProizvodTipKolicine ON UF_Proizvod.TipKolicineID = UF_ProizvodTipKolicine.ID INNER JOIN " +
                                                            "                      JEDINICAMJERE ON UF_Proizvod.JedinicaMjereID = JEDINICAMJERE.IDJEDINICAMJERE ");
            ds.Tables.Add(UF_Proizvodi);
            ds.Tables.Add(UF_ProizvodiStavke);
            
            DataRelation rel = new DataRelation("relation", UF_Proizvodi.Columns["ID"], UF_ProizvodiStavke.Columns["ProizvodID"]);
            ds.Relations.Add(rel);

            
            this.UltraGridProizvodi.DataSource = ds;
            
           
            this.UltraGridProizvodi.DataBind();
            this.UltraGridProizvodi.UpdateData();
            //this.UltraGridProizvodi.Refresh();

            Utils.Tools.UltraGridStyling(this.UltraGridProizvodi);

            UltraGridProizvodi.DisplayLayout.Bands[0].Columns["Naziv"].Width = 280;
            UltraGridProizvodi.DisplayLayout.Bands[0].Columns["JedinicaMjere"].Width = 100;

            foreach (UltraGridRow row in UltraGridProizvodi.Rows)
            {
                if (row.Index == BusinessLogic.ProizvodiGrupeProizvoda.pSelectedIndex)
                {
                    UltraGridProizvodi.ActiveRow = row;
                }
            }
            
        }

        #region Command's - command handlers for WorkItems

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            NacinKolicinskogObracuna();

            ProizvodGrupaProizvodaForm proizvodiGrupaProizvodaForm = new ProizvodGrupaProizvodaForm(Enums.FormEditMode.Insert, null);
            if (proizvodiGrupaProizvodaForm.ShowDialogForm("Proizvodi, cjenici, olakšice > Proizvodi / grupe proizvoda") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.ProizvodiGrupeProizvoda.pSelectedIndex = UltraGridProizvodi.ActiveRow.Index;
                }
                catch { }
                LoadGridProizvodi();
            }

            
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridProizvodi.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridProizvodi.ActiveRow.Cells["ID"].Value);
                ProizvodGrupaProizvodaForm proizvodiGrupaProizvodaForm = new ProizvodGrupaProizvodaForm(Enums.FormEditMode.Update, id);

                if (proizvodiGrupaProizvodaForm.ShowDialogForm("Proizvodi, cjenici, olakšice > Proizvodi / grupe proizvoda") == DialogResult.OK)
                {
                    BusinessLogic.ProizvodiGrupeProizvoda.pSelectedIndex = UltraGridProizvodi.ActiveRow.Index;
                    LoadGridProizvodi();   
                }
            }
            
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridProizvodi.ActiveRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(this.UltraGridProizvodi.ActiveRow.Cells["ID"].Value);
                    if (MessageBox.Show(string.Format("Obrisati proizvod / grupu proizvoda '{0}-{1}'?", id, this.UltraGridProizvodi.ActiveRow.Cells["Naziv"].Value),
                        "Brisanje proizvoda / grupe proizvoda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        BusinessLogic.ProizvodiGrupeProizvoda proizvodiGrupeProizvoda = new BusinessLogic.ProizvodiGrupeProizvoda();
                        proizvodiGrupeProizvoda.Delete(id);

                        if (proizvodiGrupeProizvoda.IsValid)
                        {
                            proizvodiGrupeProizvoda.Persist();
                            LoadGridProizvodi();
                        }
                        else
                        {
                            proizvodiGrupeProizvoda.DisplayValidationMessages();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Za brisanje stavke proizvoda potrebno je ući u proizvod.", "Proizvodi stavke"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                }
            }
            
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            /*
             * Jure Males, 09.07.2013
             * napisao tijelo funkicje
             * */
            if (this.UltraGridProizvodi.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridProizvodi.ActiveRow.Cells["ID"].Value);

                ProizvodGrupaProizvodaForm ustanovaSkolskaGodinaForm = new ProizvodGrupaProizvodaForm(Enums.FormEditMode.Copy, id);

                if (ustanovaSkolskaGodinaForm.ShowDialogForm("Proizvodi, cjenici, olakšice > Proizvodi / grupe proizvoda") == DialogResult.OK)
                {
                    BusinessLogic.ProizvodiGrupeProizvoda.pSelectedIndex = UltraGridProizvodi.ActiveRow.Index;
                    LoadGridProizvodi();
                }
            }
            
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.ProizvodiGrupeProizvoda.pSelectedIndex = UltraGridProizvodi.ActiveRow.Index;
            }
            catch { }
            LoadGridProizvodi();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Proizvodi grupe proizvoda";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridProizvodi, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
            
        }

        #endregion

        /// <summary>
        /// Punjenje vrijednosti u tablicu PrizvodiTipKolicine ukoliko je prazna, u suprotnom ne radi nista
        /// </summary>
        private void NacinKolicinskogObracuna()
        {
            Mipsed7.DataAccessLayer.SqlClient sql_client = new Mipsed7.DataAccessLayer.SqlClient();

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = sql_client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Select ID from UF_ProizvodTipKolicine";
            
            SqlDataReader sqlReader = sqlUpit.ExecuteReader();
            if (!sqlReader.HasRows)
            {
                sqlUpit.CommandText = "Insert Into UF_ProizvodTipKolicine Values(1, 'Dnevna'), (2, 'Mjesečna - 1')";

                try
                {
                    sqlReader.Close();
                    sqlUpit.ExecuteNonQuery();
                }
                catch { }
            }
            else
                sqlReader.Close();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_proizvod"></param>
        /// <param name="id_stavka"></param>
        private int GetStavkaID(int id_proizvod, int id_stavka)
        {
            Mipsed7.DataAccessLayer.SqlClient sql_client = new Mipsed7.DataAccessLayer.SqlClient();

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = sql_client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Select ID from UF_ProizvodStavka Where ProizvodID = '" + id_proizvod + "' and ProizvodStavkaID = '" + id_stavka + "'";

            SqlDataReader sqlReader = sqlUpit.ExecuteReader();
            if (sqlReader.Read())
            {
                int id = Convert.ToInt32(sqlReader["ID"]);
                sqlReader.Close();
                return id;
            }
            else
            {
                sqlReader.Close();
                return -1;
            }
            
            
        }
    }
}