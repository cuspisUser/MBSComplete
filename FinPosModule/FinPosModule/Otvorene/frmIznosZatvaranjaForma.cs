using Hlp;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FinPosModule.Otvorene
{

    public class frmIznosZatvaranjaForma : Form
    {
        private IContainer components;

        public frmIznosZatvaranjaForma()
        {
            base.Load += new EventHandler(this.frmIznosZatvaranjaForma_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Iznos.Value = 0;
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

        private void frmIznosZatvaranjaForma_Load(object sender, EventArgs e)
        {
            this.Iznos.MinValue = 0;
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIznosZatvaranjaForma));
            this.Label1 = new System.Windows.Forms.Label();
            this.Iznos = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(9, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(136, 23);
            this.Label1.TabIndex = 99;
            this.Label1.Text = "Iznos kojim želite zatvarati";
            // 
            // Iznos
            // 
            this.Iznos.AlwaysInEditMode = true;
            this.Iznos.Location = new System.Drawing.Point(152, 6);
            this.Iznos.MaskInput = "{LOC}nnnnnnnnnnnn.nn";
            this.Iznos.MaxValue = 992147483647D;
            this.Iznos.MinValue = -992147483648D;
            this.Iznos.Name = "Iznos";
            this.Iznos.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Iznos.PromptChar = ' ';
            this.Iznos.Size = new System.Drawing.Size(120, 21);
            this.Iznos.TabIndex = 100;
            // 
            // ImageList2
            // 
            this.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(50, 35);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 101;
            this.Button1.Text = "OK";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(152, 35);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 102;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // frmIznosZatvaranjaForma
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(276, 65);
            this.ControlBox = false;
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIznosZatvaranjaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "...";
            ((System.ComponentModel.ISupportInitialize)(this.Iznos)).EndInit();
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
            if (keyData == Keys.Escape)
            {
                this.Iznos.Value = 0;
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Button Button1;

        private Button Button2;

        private ImageList ImageList2;

        public UltraNumericEditor Iznos;

        private Label Label1;

        public object UneseniIznos
        {
            get
            {
                object[] objArray = new object[1];
                UltraNumericEditor iznos = this.Iznos;
                objArray[0] = RuntimeHelpers.GetObjectValue(iznos.Value);
                object[] arguments = objArray;
                bool[] copyBack = new bool[] { true };
                if (copyBack[0])
                {
                    iznos.Value = RuntimeHelpers.GetObjectValue(arguments[0]);
                }
                return RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", arguments, null, null, copyBack));
            }
        }
    }
}

