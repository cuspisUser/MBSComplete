using Hlp;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FinPosModule
{

    public class frmParametriFakturiranja : Form
    {
        private GroupBox gbxDatum;
        private GroupBox gbxBrojURE;
        public Label label3;
        public Label label4;
        public UltraNumericEditor uneDoURE;
        public UltraNumericEditor uneOdURE;
        public RadioButton rbrDatum;
        public CheckBox cbkPlaceni;
        public Button button2;
        private RadioButton rbrBrojURE;
        private IContainer components { get; set; }
        public static bool ppo { get; set; }

        public frmParametriFakturiranja(string mode)
        {
            base.Load += new EventHandler(this.frmOdabirDatuma_Load);
            this.InitializeComponent();

            if (mode == "URA")
            {
                gbxDatum.Visible = false;
                gbxBrojURE.Visible = false;
                rbrBrojURE.Enabled = true;
                rbrDatum.Checked = true;
                rbrBrojURE.Text = "Ispis po Broju URE";
                label3.Text = "OD URE:";
                label4.Text = "DO URE:";
                cbkPlaceni.Visible = true;
                button2.Visible = true;
            }
            else if (mode == "IRA")
            {
                rbrBrojURE.Text = "Ispis po Broju IRE";
                gbxDatum.Visible = false;
                gbxBrojURE.Visible = false;
                rbrBrojURE.Enabled = true;
                rbrDatum.Checked = true;
                label3.Text = "OD IRE:";
                label4.Text = "DO IRE:";
                cbkPlaceni.Visible = true;
                button2.Visible = false;
            }
            else
            {
                gbxDatum.Visible = true;
                gbxBrojURE.Visible = false;
                rbrBrojURE.Enabled = false;
                rbrDatum.Checked = true;
                rbrBrojURE.Text = "Ispis po Broju";
                cbkPlaceni.Visible = false;
                cbkPlaceni.Checked = false;
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ppo = false;
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
            this.oddatuma.Value = mipsed.application.framework.Application.Pocetni;
            if (DateTime.Compare(DateAndTime.Today, mipsed.application.framework.Application.Zavrsni) > 0)
            {
                this.dodatuma.Value = mipsed.application.framework.Application.Zavrsni;
            }
            else
            {
                this.dodatuma.Value = DateAndTime.Today;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametriFakturiranja));
            this.oddatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dodatuma = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.gbxDatum = new System.Windows.Forms.GroupBox();
            this.gbxBrojURE = new System.Windows.Forms.GroupBox();
            this.uneDoURE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneOdURE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbrDatum = new System.Windows.Forms.RadioButton();
            this.rbrBrojURE = new System.Windows.Forms.RadioButton();
            this.cbkPlaceni = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.oddatuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodatuma)).BeginInit();
            this.gbxDatum.SuspendLayout();
            this.gbxBrojURE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneDoURE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneOdURE)).BeginInit();
            this.SuspendLayout();
            // 
            // oddatuma
            // 
            this.oddatuma.Location = new System.Drawing.Point(125, 17);
            this.oddatuma.Name = "oddatuma";
            this.oddatuma.Size = new System.Drawing.Size(144, 21);
            this.oddatuma.TabIndex = 0;
            // 
            // dodatuma
            // 
            this.dodatuma.Location = new System.Drawing.Point(125, 44);
            this.dodatuma.Name = "dodatuma";
            this.dodatuma.Size = new System.Drawing.Size(144, 21);
            this.dodatuma.TabIndex = 1;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(228, 128);
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
            this.Label1.Location = new System.Drawing.Point(12, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Od datuma:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 52);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(62, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Do datuma:";
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(12, 132);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(130, 17);
            this.CheckBox1.TabIndex = 5;
            this.CheckBox1.Text = "Ispis samo neplaćenih";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // gbxDatum
            // 
            this.gbxDatum.Controls.Add(this.Label1);
            this.gbxDatum.Controls.Add(this.oddatuma);
            this.gbxDatum.Controls.Add(this.Label2);
            this.gbxDatum.Controls.Add(this.dodatuma);
            this.gbxDatum.Location = new System.Drawing.Point(12, 37);
            this.gbxDatum.Name = "gbxDatum";
            this.gbxDatum.Size = new System.Drawing.Size(279, 80);
            this.gbxDatum.TabIndex = 6;
            this.gbxDatum.TabStop = false;
            this.gbxDatum.Visible = false;
            // 
            // gbxBrojURE
            // 
            this.gbxBrojURE.Controls.Add(this.uneDoURE);
            this.gbxBrojURE.Controls.Add(this.uneOdURE);
            this.gbxBrojURE.Controls.Add(this.label3);
            this.gbxBrojURE.Controls.Add(this.label4);
            this.gbxBrojURE.Location = new System.Drawing.Point(12, 37);
            this.gbxBrojURE.Name = "gbxBrojURE";
            this.gbxBrojURE.Size = new System.Drawing.Size(297, 80);
            this.gbxBrojURE.TabIndex = 7;
            this.gbxBrojURE.TabStop = false;
            this.gbxBrojURE.Visible = false;
            // 
            // uneDoURE
            // 
            this.uneDoURE.Location = new System.Drawing.Point(125, 48);
            this.uneDoURE.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneDoURE.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneDoURE.MaxValue = 9999999D;
            this.uneDoURE.MinValue = 1;
            this.uneDoURE.Name = "uneDoURE";
            this.uneDoURE.Nullable = true;
            this.uneDoURE.NullText = " ";
            this.uneDoURE.PromptChar = ' ';
            this.uneDoURE.Size = new System.Drawing.Size(166, 21);
            this.uneDoURE.TabIndex = 53;
            // 
            // uneOdURE
            // 
            this.uneOdURE.Location = new System.Drawing.Point(125, 20);
            this.uneOdURE.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneOdURE.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneOdURE.MaxValue = 9999999D;
            this.uneOdURE.MinValue = 1;
            this.uneOdURE.Name = "uneOdURE";
            this.uneOdURE.Nullable = true;
            this.uneOdURE.NullText = " ";
            this.uneOdURE.PromptChar = ' ';
            this.uneOdURE.Size = new System.Drawing.Size(166, 21);
            this.uneOdURE.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "OD URE:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "DO URE:";
            // 
            // rbrDatum
            // 
            this.rbrDatum.AutoSize = true;
            this.rbrDatum.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbrDatum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbrDatum.Location = new System.Drawing.Point(12, 12);
            this.rbrDatum.Name = "rbrDatum";
            this.rbrDatum.Size = new System.Drawing.Size(99, 17);
            this.rbrDatum.TabIndex = 7;
            this.rbrDatum.Text = "Ispis po datumu";
            this.rbrDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbrDatum.UseVisualStyleBackColor = true;
            this.rbrDatum.CheckedChanged += new System.EventHandler(this.rbrDatum_CheckedChanged);
            // 
            // rbrBrojURE
            // 
            this.rbrBrojURE.AutoSize = true;
            this.rbrBrojURE.Location = new System.Drawing.Point(168, 12);
            this.rbrBrojURE.Name = "rbrBrojURE";
            this.rbrBrojURE.Size = new System.Drawing.Size(113, 17);
            this.rbrBrojURE.TabIndex = 8;
            this.rbrBrojURE.Text = "Ispis po broju URE";
            this.rbrBrojURE.UseVisualStyleBackColor = true;
            this.rbrBrojURE.CheckedChanged += new System.EventHandler(this.rbrDatum_CheckedChanged);
            // 
            // cbkPlaceni
            // 
            this.cbkPlaceni.AutoSize = true;
            this.cbkPlaceni.Location = new System.Drawing.Point(12, 155);
            this.cbkPlaceni.Name = "cbkPlaceni";
            this.cbkPlaceni.Size = new System.Drawing.Size(112, 17);
            this.cbkPlaceni.TabIndex = 9;
            this.cbkPlaceni.Text = "Ispis samo plaćeni";
            this.cbkPlaceni.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Ispis PPO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmParametriFakturiranja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 190);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbkPlaceni);
            this.Controls.Add(this.gbxBrojURE);
            this.Controls.Add(this.rbrBrojURE);
            this.Controls.Add(this.rbrDatum);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.gbxDatum);
            this.Controls.Add(this.Button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParametriFakturiranja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odabir parametara za ispis";
            ((System.ComponentModel.ISupportInitialize)(this.oddatuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodatuma)).EndInit();
            this.gbxDatum.ResumeLayout(false);
            this.gbxDatum.PerformLayout();
            this.gbxBrojURE.ResumeLayout(false);
            this.gbxBrojURE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneDoURE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneOdURE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Button Button1;

        public CheckBox CheckBox1;

        public UltraDateTimeEditor dodatuma;

        public Label Label1;

        public Label Label2;

        public UltraDateTimeEditor oddatuma;

        private void rbrDatum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbrDatum.Checked && !rbrBrojURE.Checked)
            {
                gbxDatum.Visible = true;
                gbxBrojURE.Visible = false;
            }
            else if (!rbrDatum.Checked && rbrBrojURE.Checked)
            {
                gbxDatum.Visible = false;
                gbxBrojURE.Visible = true;
            }
            else
            {
                gbxDatum.Visible = false;
                gbxBrojURE.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ppo = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}

