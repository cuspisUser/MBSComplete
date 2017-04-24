namespace RadnikExtension
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmUvjetiEvidencijaRadnika : Form
    {
        private IContainer components { get; set; }

        public frmUvjetiEvidencijaRadnika()
        {
            base.Load += new EventHandler(this.frmUvjetiBilanca_Load);
            this.InitializeComponent();
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

        private void frmUvjetiBilanca_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUvjetiEvidencijaRadnika));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAktivni = new System.Windows.Forms.RadioButton();
            this.rbSvi = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPrezime = new System.Windows.Forms.RadioButton();
            this.rbSifra = new System.Windows.Forms.RadioButton();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbAktivni);
            this.GroupBox1.Controls.Add(this.rbSvi);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(357, 72);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Status zaposlenika";
            // 
            // rbAktivni
            // 
            this.rbAktivni.AutoSize = true;
            this.rbAktivni.Location = new System.Drawing.Point(6, 42);
            this.rbAktivni.Name = "rbAktivni";
            this.rbAktivni.Size = new System.Drawing.Size(86, 17);
            this.rbAktivni.TabIndex = 4;
            this.rbAktivni.Text = "Samo aktivni";
            this.rbAktivni.UseVisualStyleBackColor = true;
            // 
            // rbSvi
            // 
            this.rbSvi.AutoSize = true;
            this.rbSvi.Checked = true;
            this.rbSvi.Location = new System.Drawing.Point(6, 19);
            this.rbSvi.Name = "rbSvi";
            this.rbSvi.Size = new System.Drawing.Size(40, 17);
            this.rbSvi.TabIndex = 3;
            this.rbSvi.TabStop = true;
            this.rbSvi.Text = "Svi";
            this.rbSvi.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.rbPrezime);
            this.GroupBox2.Controls.Add(this.rbSifra);
            this.GroupBox2.Location = new System.Drawing.Point(12, 90);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(357, 72);
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Redoslijed ispisa";
            // 
            // rbPrezime
            // 
            this.rbPrezime.AutoSize = true;
            this.rbPrezime.Location = new System.Drawing.Point(6, 42);
            this.rbPrezime.Name = "rbPrezime";
            this.rbPrezime.Size = new System.Drawing.Size(62, 17);
            this.rbPrezime.TabIndex = 7;
            this.rbPrezime.Text = "Prezime";
            this.rbPrezime.UseVisualStyleBackColor = true;
            // 
            // rbSifra
            // 
            this.rbSifra.AutoSize = true;
            this.rbSifra.Checked = true;
            this.rbSifra.Location = new System.Drawing.Point(6, 19);
            this.rbSifra.Name = "rbSifra";
            this.rbSifra.Size = new System.Drawing.Size(46, 17);
            this.rbSifra.TabIndex = 6;
            this.rbSifra.TabStop = true;
            this.rbSifra.Text = "Šifra";
            this.rbSifra.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(198, 178);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 10;
            this.Button1.Text = "Potvrdi";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(289, 178);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 11;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // frmUvjetiEvidencijaRadnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 214);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUvjetiEvidencijaRadnika";
            this.Text = "Parametri ispisa evidencije o zaposlenicima";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        public object __Sort
        {
            get
            {
                return RuntimeHelpers.GetObjectValue(Interaction.IIf(this.rbSifra.Checked, "0", "1"));
            }
        }

        public object __Vrsta
        {
            get
            {
                return RuntimeHelpers.GetObjectValue(Interaction.IIf(this.rbSvi.Checked, "0", "1"));
            }
        }

        private Button Button1;

        private Button Button2;

        private GroupBox GroupBox1;

        private GroupBox GroupBox2;

        private RadioButton rbAktivni;

        private RadioButton rbPrezime;

        private RadioButton rbSifra;

        private RadioButton rbSvi;
    }
}

