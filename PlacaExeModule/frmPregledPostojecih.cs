using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmPregledPostojecih : Form
{
    private IContainer components { get; set; }
    private S_OS_POSTOJECI_DOKUMENTIDataAdapter da;
    private S_OS_POSTOJECI_DOKUMENTIDataSet ds;
    private Button btnObrisi;
    private object M_uvjet;

    public frmPregledPostojecih(object uvjet)
    {
        base.Load += new EventHandler(this.frmIdentifikator_Load);
        this.da = new S_OS_POSTOJECI_DOKUMENTIDataAdapter();
        this.ds = new S_OS_POSTOJECI_DOKUMENTIDataSet();
        this.InitializeComponent();
        this.M_uvjet = RuntimeHelpers.GetObjectValue(uvjet);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmIdentifikator_Load(object sender, EventArgs e)
    {
        this.S_OS_POSTOJECI_DOKUMENTIDataSet1.Clear();
        this.ds.S_OS_POSTOJECI_DOKUMENTI.Clear();

        this.da.Fill(this.S_OS_POSTOJECI_DOKUMENTIDataSet1);
        if (Operators.ConditionalCompareObjectEqual(this.M_uvjet, 2, false))
        {
            foreach (DataRow row in this.S_OS_POSTOJECI_DOKUMENTIDataSet1.S_OS_POSTOJECI_DOKUMENTI.Select("IDOSDOKUMENT = 2 and osbrojdokumenta > 0"))
            {
                this.ds.S_OS_POSTOJECI_DOKUMENTI.ImportRow(row);
            }
        }
        else if (Operators.ConditionalCompareObjectEqual(this.M_uvjet, 0, false))
        {
            foreach (DataRow row2 in this.S_OS_POSTOJECI_DOKUMENTIDataSet1.S_OS_POSTOJECI_DOKUMENTI.Select("IDOSDOKUMENT <> 2 and osbrojdokumenta > 0"))
            {
                this.ds.S_OS_POSTOJECI_DOKUMENTI.ImportRow(row2);
            }
        }
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
    }

    private void InitializeComponent()
    {
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_OS_POSTOJECI_DOKUMENTI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSDATUMDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSBROJDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOPIS");
            this.Button1 = new System.Windows.Forms.Button();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.S_OS_POSTOJECI_DOKUMENTIDataSet1 = new Placa.S_OS_POSTOJECI_DOKUMENTIDataSet();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OS_POSTOJECI_DOKUMENTIDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(693, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Potvrdi";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "S_OS_POSTOJECI_DOKUMENTI";
            this.UltraGrid1.DataSource = this.S_OS_POSTOJECI_DOKUMENTIDataSet1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.Caption = "Šif.dok";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "Dat.dok.";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "Broj.dok";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "Opis";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 273;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(-2, -1);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(680, 495);
            this.UltraGrid1.TabIndex = 3;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // S_OS_POSTOJECI_DOKUMENTIDataSet1
            // 
            this.S_OS_POSTOJECI_DOKUMENTIDataSet1.DataSetName = "S_OS_POSTOJECI_DOKUMENTIDataSet";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(693, 31);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 4;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(693, 60);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 5;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // frmPregledPostojecih
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(777, 494);
            this.ControlBox = false;
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.Button1);
            this.Name = "frmPregledPostojecih";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregled postojećih temeljnica";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_OS_POSTOJECI_DOKUMENTIDataSet1)).EndInit();
            this.ResumeLayout(false);

    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
        {
            bool flag = false;
            return flag;
        }
        switch (keyData)
        {
            case Keys.Return:
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return true;

            case Keys.Escape:
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
    }

    public object ___Datum
    {
        get
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.ds.S_OS_POSTOJECI_DOKUMENTI];
            if (manager.Count == 0)
            {
                return null;
            }
            return RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["osdatumdok"]);
        }
        set
        {
            this.___Datum = RuntimeHelpers.GetObjectValue(value);
        }
    }

    public object ___Vrsta
    {
        get
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.ds.S_OS_POSTOJECI_DOKUMENTI];
            if (manager.Count == 0)
            {
                return null;
            }
            return RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["idosdokument"]);
        }
        set
        {
            this.___Vrsta = RuntimeHelpers.GetObjectValue(value);
        }
    }

    public object __BrojPostojeceg
    {
        get
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.ds.S_OS_POSTOJECI_DOKUMENTI];
            if (manager.Count == 0)
            {
                return null;
            }
            return RuntimeHelpers.GetObjectValue(((DataRowView) manager.Current)["OSBROJDOKUMENTA"]);
        }
        set
        {
            this.__BrojPostojeceg = RuntimeHelpers.GetObjectValue(value);
        }
    }

    private Button Button1;

    private Button Button2;

    private S_OS_POSTOJECI_DOKUMENTIDataSet S_OS_POSTOJECI_DOKUMENTIDataSet1;

    private UltraGrid UltraGrid1;

    private void btnObrisi_Click(object sender, EventArgs e)
    {
        string sifra_os = string.Empty;
        string broj_os = string.Empty;
        int index = UltraGrid1.ActiveRow.Index;

        sifra_os = UltraGrid1.Rows[index].Cells[0].Value.ToString();
        broj_os = UltraGrid1.Rows[index].Cells[2].Value.ToString();

        Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

        client.ExecuteNonQuery("Delete From OSTEMELJNICA Where IDOSDOKUMENT = '" + sifra_os + "' And OSBROJDOKUMENTA = '" + broj_os + "'");

        client.CloseConnection();

        UltraGrid1.DeleteSelectedRows();
    }
}

