using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmPregledObrazacaOPPD : Form
{
    public int? JOPPDID = null;
    public int id_vrsta = 0;
    private UltraButton btnObrisiObrazac;
    private UltraButton btnZatvori;

    private IContainer components { get; set; }

    public frmPregledObrazacaOPPD()
    {
        base.Load += new EventHandler(this.frmPregledObrazacaJOPPD_Load);
        this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    private void frmPregledObrazacaJOPPD_Load(object sender, EventArgs e)
    {
        // load DATASET's
        GetObracunJOPPD();
    }

    private void GetObracunJOPPD()
    {
        string sqlQuery = "SELECT dbo.JOPPDA.ID AS JoppdaID, OznakaIzvjesca, (CAST(dbo.JOPPDAVrstaIzvjesca.Sifra as nvarchar(3)) + ' - ' + dbo.JOPPDAVrstaIzvjesca.Naziv) as VrstaIzvjesca, " +
            "OznakaIzvjescaDatum, (SELECT COUNT(DISTINCT OIBStjecatelja) FROM dbo.JOPPDB WHERE dbo.JOPPDB.JOPPDAID = dbo.JOPPDA.ID) AS BrojOsoba, " +
            "(SELECT COUNT(1) FROM dbo.JOPPDB WHERE dbo.JOPPDB.JOPPDAID = dbo.JOPPDA.ID) AS BrojRedaka " +
            "FROM dbo.JOPPDA " + 
            "INNER JOIN dbo.JOPPDAVrstaIzvjesca ON dbo.JOPPDA.VrstaIzvjescaID = dbo.JOPPDAVrstaIzvjesca.ID " +
            "ORDER BY OznakaIzvjescaDatum DESC, dbo.JOPPDAVrstaIzvjesca.Sifra DESC, dbo.JOPPDA.ID DESC";

        Mipsed7.DataAccessLayer.SqlClient sqlClient = new Mipsed7.DataAccessLayer.SqlClient();
        
        this.UltraGrid1.DataSource = sqlClient.GetDataTable(sqlQuery);
        this.UltraGrid1.DataBind();

        sqlClient.CloseConnection();


        if (this.UltraGrid1.Rows.Count > 0)
        {
            this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[0];
        }
    }

    private void InitializeComponent()
    {
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JoppdaID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OznakaIzvjesca");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VrstaIzvjesca");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BrojOsoba");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BrojRedaka");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDObracunID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OznakaIzvjescaDatum");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.frmPregledJOPPDObracuna_Fill_Panel = new System.Windows.Forms.Panel();
            this.btnZatvori = new Infragistics.Win.Misc.UltraButton();
            this.btnObrisiObrazac = new Infragistics.Win.Misc.UltraButton();
            this.btnOdaberiObrazac = new Infragistics.Win.Misc.UltraButton();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.frmPregledJOPPDObracuna_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // frmPregledJOPPDObracuna_Fill_Panel
            // 
            this.frmPregledJOPPDObracuna_Fill_Panel.Controls.Add(this.btnZatvori);
            this.frmPregledJOPPDObracuna_Fill_Panel.Controls.Add(this.btnObrisiObrazac);
            this.frmPregledJOPPDObracuna_Fill_Panel.Controls.Add(this.btnOdaberiObrazac);
            this.frmPregledJOPPDObracuna_Fill_Panel.Controls.Add(this.UltraGrid1);
            this.frmPregledJOPPDObracuna_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmPregledJOPPDObracuna_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmPregledJOPPDObracuna_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.frmPregledJOPPDObracuna_Fill_Panel.Name = "frmPregledJOPPDObracuna_Fill_Panel";
            this.frmPregledJOPPDObracuna_Fill_Panel.Size = new System.Drawing.Size(961, 626);
            this.frmPregledJOPPDObracuna_Fill_Panel.TabIndex = 0;
            // 
            // btnZatvori
            // 
            this.btnZatvori.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnZatvori.Location = new System.Drawing.Point(289, 10);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(123, 23);
            this.btnZatvori.TabIndex = 47;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // btnObrisiObrazac
            // 
            this.btnObrisiObrazac.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnObrisiObrazac.Location = new System.Drawing.Point(149, 10);
            this.btnObrisiObrazac.Name = "btnObrisiObrazac";
            this.btnObrisiObrazac.Size = new System.Drawing.Size(123, 23);
            this.btnObrisiObrazac.TabIndex = 46;
            this.btnObrisiObrazac.Text = "Obriši obrazac";
            this.btnObrisiObrazac.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnObrisiObrazac.Click += new System.EventHandler(this.btnObrisiObrazac_Click);
            // 
            // btnOdaberiObrazac
            // 
            this.btnOdaberiObrazac.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOdaberiObrazac.Location = new System.Drawing.Point(9, 10);
            this.btnOdaberiObrazac.Name = "btnOdaberiObrazac";
            this.btnOdaberiObrazac.Size = new System.Drawing.Size(123, 23);
            this.btnOdaberiObrazac.TabIndex = 45;
            this.btnOdaberiObrazac.Text = "Odaberi obrazac";
            this.btnOdaberiObrazac.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnOdaberiObrazac.Click += new System.EventHandler(this.btnOdaberiObrazac_Click);
            // 
            // UltraGrid1
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance6;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance8.FontData.BoldAsString = "True";
            ultraGridColumn2.CellAppearance = appearance8;
            ultraGridColumn2.Header.Caption = "Oznaka izvješća";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 114;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.Caption = "Vrsta izvješća";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 144;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.Caption = "Broj osoba";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 75;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.Caption = "Broj redaka";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 96;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "OD - obračun dohotka";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 140;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.Caption = "OH - obračun drugog dohotka";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 170;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Format = "dd.MM.yyyy";
            ultraGridColumn8.Header.Caption = "Izvješće na dan";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            ultraGridBand1.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance9;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance10.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance11.BorderColor = System.Drawing.Color.LightGray;
            appearance11.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance11;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance12.BorderColor = System.Drawing.Color.Black;
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell;
            this.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(9, 41);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(940, 585);
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UltraGrid1_KeyDown);
            this.UltraGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UltraGrid1_MouseDown);
            // 
            // frmPregledObrazacaOPPD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 626);
            this.Controls.Add(this.frmPregledJOPPDObracuna_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledObrazacaOPPD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregled JOPPD obrazaca";
            this.frmPregledJOPPDObracuna_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            this.ResumeLayout(false);

    }

    private void btnOdaberiObrazac_Click(object sender, EventArgs e)
    {
        this.OdaberiObracun();
    }

    private void UltraGrid1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
        {
            OdaberiObracun();
        }
    }

    private void OdaberiObracun()
    {
        if (this.UltraGrid1.Selected != null)
        {
            if (this.UltraGrid1.Selected.Rows.Count > 0)
            {
                this.JOPPDID = (int)this.UltraGrid1.Selected.Rows[0].Cells["JoppdaID"].Value;
                ProvjeraVrsteObracuna(JOPPDID);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }

    private void ProvjeraVrsteObracuna(int? id)
    {
        Mipsed7.DataAccessLayer.SqlClient database = new Mipsed7.DataAccessLayer.SqlClient();

        try
        {
            id_vrsta = Convert.ToInt32(database.ExecuteScalar("Select OznakaPodnositelja From JOPPDA Where ID = '" + id + "'"));

        }
        catch { id_vrsta = 1;}
    }

    private Panel frmPregledJOPPDObracuna_Fill_Panel;

    private UltraButton btnOdaberiObrazac;

    private UltraGrid UltraGrid1;

    private void btnObrisiObrazac_Click(object sender, EventArgs e)
    {
        if (this.UltraGrid1.Selected == null)
            return;

        if (this.UltraGrid1.Selected.Rows.Count == 0)
            return;

        if (MessageBox.Show("Nastaviti sa brisanjem obrasca?\n\nNAPOMENA: brisanjem obrasca NE brišete obračune već samo JOPPD izvještaj!", "Brisanje JOPPD obrasca", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
        {
            int joppdID = (int)this.UltraGrid1.Selected.Rows[0].Cells["JoppdaID"].Value;

            Mipsed7.DataAccessLayer.SqlClient database = new Mipsed7.DataAccessLayer.SqlClient();

            database.ExecuteNonQuery(string.Format("DELETE FROM dbo.JOPPDB WHERE JOPPDAID = {0}", joppdID));
            database.ExecuteNonQuery(string.Format("DELETE FROM dbo.JOPPDA WHERE ID = {0}", joppdID));
            database.ExecuteNonQuery(string.Format("DELETE FROM dbo.JOPPDAObracun WHERE JOPPDA_ID = {0}", joppdID));

            GetObracunJOPPD();
        }
    }

    private void btnZatvori_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }


    private void UltraGrid1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            btnObrisiObrazac_Click(null, null);
        }
    }

}

