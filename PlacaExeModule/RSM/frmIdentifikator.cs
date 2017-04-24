
using Hlp;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace RSM
{
    public class frmIdentifikator : Form
    {
        private IContainer components { get; set; }

        public frmIdentifikator()
        {
            base.Load += new EventHandler(this.frmIdentifikator_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
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
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdentifikator));
            this.rsmIdent = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rsmIdent
            // 
            this.rsmIdent.Location = new System.Drawing.Point(109, 15);
            this.rsmIdent.Name = "rsmIdent";
            this.rsmIdent.Size = new System.Drawing.Size(96, 20);
            this.rsmIdent.TabIndex = 0;
            this.rsmIdent.GotFocus += new System.EventHandler(this.rsmIdent_GotFocus);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(16, 44);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Potvrdi";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(150, 44);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(93, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "R-Sm identifikator:";
            // 
            // frmIdentifikator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(237, 79);
            this.ControlBox = false;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.rsmIdent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIdentifikator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identifikator obrasca R-Sm";
            this.ResumeLayout(false);
            this.PerformLayout();

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
                    this.Close();
                    return true;

                case Keys.Escape:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.rsmIdent.Text = "";
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void rsmIdent_GotFocus(object sender, EventArgs e)
        {
            this.rsmIdent.SelectAll();
        }

        private Button Button1;

        private Button Button2;

        public Label Label1;

        public TextBox rsmIdent;

        public object UneseniIdentifikator
        {
            get
            {
                return this.rsmIdent.Text;
            }
            set
            {
                this.UneseniIdentifikator = RuntimeHelpers.GetObjectValue(value);
            }
        }
    }
}

