namespace Ucenici.Ucenici
{
    using Hlp;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmIznosZatvaranjaForma));
            this.Label1 = new Label();
            this.Iznos = new UltraNumericEditor();
            this.ImageList2 = new ImageList(this.components);
            this.Button1 = new Button();
            this.Button2 = new Button();
            ((ISupportInitialize) this.Iznos).BeginInit();
            this.SuspendLayout();
            this.Label1.Location = new System.Drawing.Point(9, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0x88, 0x17);
            this.Label1.TabIndex = 0x63;
            this.Label1.Text = "Unesite broj dana prakse";
            this.Iznos.AlwaysInEditMode = true;
            this.Iznos.Location = new System.Drawing.Point(0x98, 6);
            this.Iznos.MaskInput = "{LOC}nnnnnnnnnn.nn";
            this.Iznos.Name = "Iznos";
            this.Iznos.NumericType = NumericType.Double;
            this.Iznos.PromptChar = ' ';
            this.Iznos.Size = new System.Drawing.Size(120, 0x15);
            this.Iznos.TabIndex = 100;
            //this.ImageList2.ImageStream = (ImageListStreamer) manager.GetObject("ImageList2.ImageStream");
            this.ImageList2.TransparentColor = Color.Fuchsia;
            /*this.ImageList2.Images.SetKeyName(0, "");
            this.ImageList2.Images.SetKeyName(1, "");
            this.ImageList2.Images.SetKeyName(2, "");
            this.ImageList2.Images.SetKeyName(3, "");
            this.ImageList2.Images.SetKeyName(4, "");
            this.ImageList2.Images.SetKeyName(5, "");
            this.ImageList2.Images.SetKeyName(6, "");
            this.ImageList2.Images.SetKeyName(7, "");
            this.ImageList2.Images.SetKeyName(8, "");*/
            this.Button1.Location = new System.Drawing.Point(50, 0x23);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
            this.Button1.TabIndex = 0x65;
            this.Button1.Text = "OK";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button2.Location = new System.Drawing.Point(0x98, 0x23);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(0x4b, 0x17);
            this.Button2.TabIndex = 0x66;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(0x114, 0x41);
            this.ControlBox = false;
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIznosZatvaranjaForma";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "...";


            this.Button2.Click += new EventHandler(this.Button2_Click);
            this.Button1.Click += new EventHandler(this.Button1_Click);


            ((ISupportInitialize) this.Iznos).EndInit();
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

        private UltraNumericEditor Iznos;

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

