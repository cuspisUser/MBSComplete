using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmPregledVirmana : Form
{
    private IContainer components { get; set; }
    private DateTime dp;
    private DataSet dsa;
    private DateTime dv;
    private bool mPrikaziDatum;

    public frmPregledVirmana(ref DataSet ds, bool prikazidatum, DateTime datumvalute, DateTime datumpodnosenja)
    {
        base.Load += new EventHandler(this.frmPregledVirmana_Load);
        this.InitializeComponent();
        this.dsa = new DataSet();
        this.dsa = ds;
        this.mPrikaziDatum = prikazidatum;
        this.dv = datumvalute;
        this.dp = datumpodnosenja;
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

    private void frmPregledVirmana_Load(object sender, EventArgs e)
    {
        this.ReportViewer1.Reset();
        this.ReportViewer1.ProcessingMode = ProcessingMode.Local;
        this.ReportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Izvjestaji\virmani.rdlc";
        ReportDataSource item = new ReportDataSource();
        VIRMANIDataSet set = new VIRMANIDataSet();
        foreach (DataRow row in this.dsa.Tables[0].Select("OZNACEN = True"))
        {
            if (!this.mPrikaziDatum)
            {
                row["datumvalute"] = DBNull.Value;
                row["datumpodnosenja"] = DBNull.Value;
            }
            else
            {
                row["datumvalute"] = this.dv;
                row["datumpodnosenja"] = this.dp;
            }
            set.Tables[0].ImportRow(row);
        }
        item.Name = "MARIJADataSet_VIRMANI";
        item.Value = set.Tables[0];
        this.ReportViewer1.LocalReport.DataSources.Add(item);
        this.ReportViewer1.RefreshReport();
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledVirmana));
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.ReportViewer1.Size = new System.Drawing.Size(785, 419);
            this.ReportViewer1.TabIndex = 0;
            // 
            // frmPregledVirmana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 419);
            this.Controls.Add(this.ReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPregledVirmana";
            this.Text = "Pregled virmana prije ispisa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

    }

    private ReportViewer ReportViewer1;
}

