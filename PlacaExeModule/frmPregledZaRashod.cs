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

public class frmPregledZaRashod : Form
{
    private IContainer components { get; set; }
    private S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter da;

    public frmPregledZaRashod()
    {
        base.Load += new EventHandler(this.frmPregledZaRashod_Load);
        this.da = new S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter();
        this.InitializeComponent();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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

    private void frmPregledZaRashod_Load(object sender, EventArgs e)
    {
        this.da.Fill(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1);
    }

    private void InitializeComponent()
    {
        Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_OS_STANJE_LOKACIJA_SVI_BROJEVI", -1);
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDLOKACIJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("INVBROJ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ULAZ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZLAZ");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STANJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISLOKACIJE");
        Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOS");
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledZaRashod));
        this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
        this.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1 = new Placa.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet();
        this.Button2 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1)).BeginInit();
        this.SuspendLayout();
        // 
        // UltraGrid1
        // 
        this.UltraGrid1.DataMember = "S_OS_STANJE_LOKACIJA_SVI_BROJEVI";
        this.UltraGrid1.DataSource = this.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1;
        ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn1.Header.VisiblePosition = 0;
        ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn2.Header.VisiblePosition = 1;
        ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn3.Header.VisiblePosition = 2;
        ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn4.Header.VisiblePosition = 3;
        ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn5.Header.VisiblePosition = 4;
        ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn6.Header.VisiblePosition = 5;
        ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        ultraGridColumn7.Header.VisiblePosition = 6;
        ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
        this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
        this.UltraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
        this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        this.UltraGrid1.Location = new System.Drawing.Point(2, 1);
        this.UltraGrid1.Name = "UltraGrid1";
        this.UltraGrid1.Size = new System.Drawing.Size(680, 426);
        this.UltraGrid1.TabIndex = 1;
        this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
        this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
        // 
        // S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1
        // 
        this.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1.DataSetName = "S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet";
        // 
        // Button2
        // 
        this.Button2.Location = new System.Drawing.Point(688, 1);
        this.Button2.Name = "Button2";
        this.Button2.Size = new System.Drawing.Size(75, 23);
        this.Button2.TabIndex = 3;
        this.Button2.Text = "Odustani";
        this.Button2.UseVisualStyleBackColor = true;
        this.Button2.Click += new System.EventHandler(this.Button2_Click);
        // 
        // frmPregledZaRashod
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(764, 424);
        this.Controls.Add(this.Button2);
        this.Controls.Add(this.UltraGrid1);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "frmPregledZaRashod";
        this.Text = "frmPregledZaRashod";
        ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1)).EndInit();
        this.ResumeLayout(false);

    }

    private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
    }

    internal Button Button2;

    public DataRowView RedakRashoda
    {
        get
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1, "S_OS_STANJE_LOKACIJA_SVI_BROJEVI"];
            if (manager.Count == 0)
            {
                return null;
            }
            return (DataRowView) manager.Current;
        }
    }

    private S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet1;

    private UltraGrid UltraGrid1;
}

