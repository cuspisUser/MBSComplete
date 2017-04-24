using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmPregledIzvjestaja : Form
{
    private IContainer components { get; set; }
    private object Izvjestaj;

    public frmPregledIzvjestaja()
    {
        base.Load += new EventHandler(this.frmPregledIzvjestaja_Load);
        this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmPregledIzvjestaja_Load(object sender, EventArgs e)
    {
        this.ReportViewerControl.ReportSource = RuntimeHelpers.GetObjectValue(this.Izvjestaj);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledIzvjestaja));
            this.ReportViewerControl = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewerControl
            // 
            this.ReportViewerControl.ActiveViewIndex = -1;
            this.ReportViewerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewerControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerControl.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerControl.Name = "ReportViewerControl";
            this.ReportViewerControl.ShowGroupTreeButton = false;
            this.ReportViewerControl.ShowParameterPanelButton = false;
            this.ReportViewerControl.ShowRefreshButton = false;
            this.ReportViewerControl.ShowTextSearchButton = false;
            this.ReportViewerControl.Size = new System.Drawing.Size(816, 453);
            this.ReportViewerControl.TabIndex = 0;
            this.ReportViewerControl.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPregledIzvjestaja
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(816, 453);
            this.Controls.Add(this.ReportViewerControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPregledIzvjestaja";
            this.Text = "Pregled izvještaja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

    }

    public void Postavi_Izvjestaj(ref object izvjestajJ)
    {
        this.Izvjestaj = RuntimeHelpers.GetObjectValue(izvjestajJ);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
        {
            bool flag = false;
            return flag;
        }
        if (keyData == Keys.Escape)
        {
            this.Close();
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private CrystalReportViewer ReportViewerControl;
}

