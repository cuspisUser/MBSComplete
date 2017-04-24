using Hlp;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FinPosModule
{
    public class frmZaduzenje : Form
    {
        private IContainer components { get; set; }

        public frmZaduzenje()
        {
            base.Load += new EventHandler(this.frmOdabirDatuma_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void frmOdabirDatuma_Load(object sender, EventArgs e)
        {
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            this.oddatuma.Value = DateTime.Now;
            this.dodatuma.Value = DateTime.Now;
            this.datumracuna.Value = DateTime.Now;
            this.valuta.Value = DateTime.Now.AddDays(8.0);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZaduzenje));
            this.oddatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dodatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.datumracuna = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.valuta = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.oddatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumracuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuta)).BeginInit();
            this.SuspendLayout();
            // 
            // oddatuma
            // 
            this.oddatuma.Location = new System.Drawing.Point(126, 12);
            this.oddatuma.Name = "oddatuma";
            this.oddatuma.Size = new System.Drawing.Size(144, 21);
            this.oddatuma.TabIndex = 0;
            // 
            // dodatuma
            // 
            this.dodatuma.Location = new System.Drawing.Point(126, 39);
            this.dodatuma.Name = "dodatuma";
            this.dodatuma.Size = new System.Drawing.Size(144, 21);
            this.dodatuma.TabIndex = 1;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(195, 131);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Ispiši";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Od datuma:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(62, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Do datuma:";
            // 
            // datumracuna
            // 
            this.datumracuna.Location = new System.Drawing.Point(126, 66);
            this.datumracuna.Name = "datumracuna";
            this.datumracuna.Size = new System.Drawing.Size(144, 21);
            this.datumracuna.TabIndex = 5;
            // 
            // valuta
            // 
            this.valuta.Location = new System.Drawing.Point(126, 93);
            this.valuta.Name = "valuta";
            this.valuta.Size = new System.Drawing.Size(144, 21);
            this.valuta.TabIndex = 6;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(13, 70);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Datum računa";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(13, 97);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(37, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Valuta";
            // 
            // frmZaduzenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 162);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.valuta);
            this.Controls.Add(this.datumracuna);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.dodatuma);
            this.Controls.Add(this.oddatuma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmZaduzenje";
            this.Text = "Odabir datuma";
            ((System.ComponentModel.ISupportInitialize)(this.oddatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumracuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button Button1;

        public UltraDateTimeEditor datumracuna;

        public UltraDateTimeEditor dodatuma;

        private Label Label1;

        private Label Label2;

        private Label Label3;

        private Label Label4;

        public UltraDateTimeEditor oddatuma;

        public UltraDateTimeEditor valuta;
    }
}

