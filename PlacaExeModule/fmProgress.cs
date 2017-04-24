using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class fmProgress : Form
{
    private IContainer components { get; set; }

    public fmProgress()
    {
        base.Load += new EventHandler(this.fmProgress_Load);
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

    private void fmProgress_Load(object sender, EventArgs e)
    {
    }

    private void InitializeComponent()
    {
        this.lblDescription = new Label();
        this.progressBar1 = new ProgressBar();
        this.SuspendLayout();
        this.lblDescription.Location = new System.Drawing.Point(0x2f, 0x19);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Size = new System.Drawing.Size(0x85, 13);
        this.lblDescription.TabIndex = 0;
        this.progressBar1.Location = new System.Drawing.Point(0x12, 0x39);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new System.Drawing.Size(0xbf, 0x17);
        this.progressBar1.TabIndex = 1;
        SizeF ef = new System.Drawing.SizeF(6f, 13f);
        this.AutoScaleDimensions = ef;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(0xe5, 0x5c);
        this.ControlBox = false;
        this.Controls.Add(this.progressBar1);
        this.Controls.Add(this.lblDescription);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "fmProgress";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Sačekajte trenutak";
        this.ResumeLayout(false);
    }

    public Label lblDescription;

    public ProgressBar progressBar1;
}

