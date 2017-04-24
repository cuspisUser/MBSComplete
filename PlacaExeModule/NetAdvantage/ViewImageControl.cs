namespace NetAdvantage
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinEditors;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ViewImageControl : UserControl
    {
        [AccessedThroughProperty("button1")]
        private System.Windows.Forms.Button _button1;
        private Container components = null;
        private Panel panel1;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;

        public event EventHandler SelectImage;

        public ViewImageControl()
        {
            this.InitializeComponent();
            this.button1.FlatStyle = FlatStyle.System;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler selectImageEvent = this.SelectImage;
            if (selectImageEvent != null)
            {
                selectImageEvent(this, EventArgs.Empty);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            appearance.ImageHAlign = HAlign.Left;
            appearance.ImageVAlign = VAlign.Top;
            this.ultraPictureBox1.Appearance = appearance;
            this.ultraPictureBox1.BorderShadowColor = Color.Empty;
            this.ultraPictureBox1.Dock = DockStyle.Fill;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.ultraPictureBox1.Location = point;
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            Size size = new System.Drawing.Size(150, 150);
            this.ultraPictureBox1.Size = size;
            this.ultraPictureBox1.TabIndex = 0;
            this.button1.Dock = DockStyle.Left;
            point = new System.Drawing.Point(0, 0);
            this.button1.Location = point;
            this.button1.Name = "button1";
            size = new System.Drawing.Size(0x18, 20);
            this.button1.Size = size;
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = DockStyle.Top;
            point = new System.Drawing.Point(0, 0);
            this.panel1.Location = point;
            this.panel1.Name = "panel1";
            size = new System.Drawing.Size(150, 20);
            this.panel1.Size = size;
            this.panel1.TabIndex = 2;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ultraPictureBox1);
            this.Name = "ViewImageControl";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.Button Button
        {
            get
            {
                return this.button1;
            }
        }

        internal System.Windows.Forms.Button button1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.button1_Click);
                if (this._button1 != null)
                {
                    this._button1.Click -= handler;
                }
                this._button1 = value;
                if (this._button1 != null)
                {
                    this._button1.Click += handler;
                }
            }
        }

        public new ControlBindingsCollection DataBindings
        {
            get
            {
                return this.ultraPictureBox1.DataBindings;
            }
        }

        public new object Tag
        {
            get
            {
                return this.ultraPictureBox1.Tag;
            }
            set
            {
                this.ultraPictureBox1.Tag = RuntimeHelpers.GetObjectValue(value);
            }
        }

        public Infragistics.Win.UltraWinEditors.UltraPictureBox UltraPictureBox
        {
            get
            {
                return this.ultraPictureBox1;
            }
        }
    }
}

