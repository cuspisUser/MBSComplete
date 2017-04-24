namespace NetAdvantage
{
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class LinkUltraLabelPrompt : UserControl
    {
        [AccessedThroughProperty("button1")]
        private UltraButton _button1;
        [AccessedThroughProperty("ultraLabel1")]
        private Infragistics.Win.Misc.UltraLabel _ultraLabel1;
        private Container components;
        private string m_DescriptionTag;
        private string m_Text;
        private Panel panel1;
        private UltraTextEditor ultraTextEditor1;

        public event EventHandler EditorButtonClick;

        public event EventHandler LabelClick;

        public LinkUltraLabelPrompt()
        {
            base.Load += new EventHandler(this.LinkUltraLabelPrompt_Load);
            base.Paint += new PaintEventHandler(this.LinkUltraLabelPrompt_Paint);
            this.components = null;
            this.m_Text = "";
            this.m_DescriptionTag = "";
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler editorButtonClickEvent = this.EditorButtonClick;
            if (editorButtonClickEvent != null)
            {
                editorButtonClickEvent(this, EventArgs.Empty);
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
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.button1 = new UltraButton();
            this.panel1 = new Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            appearance.FontData.UnderlineAsString = "True";
            appearance.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.ultraLabel1.Appearance = appearance;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Cursor = Cursors.Hand;
            this.ultraLabel1.Dock = DockStyle.Bottom;
            System.Drawing.Point point = new System.Drawing.Point(1, 7);
            this.ultraLabel1.Location = point;
            this.ultraLabel1.Name = "ultraLabel1";
            Size size = new System.Drawing.Size(60, 14);
            this.ultraLabel1.Size = size;
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = " ";
            this.button1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            point = new System.Drawing.Point(0x55, 1);
            this.button1.Location = point;
            this.button1.Name = "button1";
            this.button1.ShowOutline = false;
            this.button1.ShowFocusRect = false;
            size = new System.Drawing.Size(20, 20);
            this.button1.Size = size;
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ultraLabel1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.DockPadding.All = 1;
            point = new System.Drawing.Point(1, 1);
            this.panel1.Location = point;
            this.panel1.Name = "panel1";
            size = new System.Drawing.Size(110, 0x16);
            this.panel1.Size = size;
            this.panel1.TabIndex = 2;
            this.Controls.Add(this.panel1);
            this.DockPadding.All = 1;
            this.Name = "LinkUltraLabelPrompt";
            size = new System.Drawing.Size(0x70, 0x18);
            this.Size = size;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void LinkUltraLabelPrompt_Load(object sender, EventArgs e)
        {
            this.ultraTextEditor1 = new UltraTextEditor();
            AppearanceData appearance = new AppearanceData();
            AppearancePropFlags requestedProps = AppearancePropFlags.BackColor | AppearancePropFlags.ForeColor | AppearancePropFlags.BackColorDisabled | AppearancePropFlags.ForeColorDisabled;
            this.ultraTextEditor1.ResolveAppearance(ref appearance, ref requestedProps);
            this.ultraLabel1.Appearance.ForeColor = appearance.ForeColor;
            this.ultraLabel1.Appearance.ForeColorDisabled = appearance.ForeColorDisabled;
            if (this.Enabled)
            {
                this.panel1.BackColor = appearance.BackColor;
            }
            else
            {
                this.panel1.BackColor = appearance.BackColorDisabled;
            }
        }

        private void LinkUltraLabelPrompt_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(SystemColors.ControlDark, 1f);
            graphics.DrawRectangle(pen, (int) (this.panel1.Left - 1), (int) (this.panel1.Top - 1), (int) (this.panel1.Width + 1), (int) (this.panel1.Height + 1));
        }

        private void ultraLabel1_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs) e).Button == MouseButtons.Left)
            {
                EventHandler labelClickEvent = this.LabelClick;
                if (labelClickEvent != null)
                {
                    labelClickEvent(this, EventArgs.Empty);
                }
            }
        }

        public UltraButton Button
        {
            get
            {
                return this.button1;
            }
        }

        private UltraButton button1
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

        public string DescriptionTag
        {
            get
            {
                return this.m_DescriptionTag;
            }
            set
            {
                this.m_DescriptionTag = value;
            }
        }

        public new object Tag
        {
            get
            {
                return this.ultraLabel1.Tag;
            }
            set
            {
                this.ultraLabel1.Tag = RuntimeHelpers.GetObjectValue(value);
                base.Tag = RuntimeHelpers.GetObjectValue(value);
            }
        }

        public new string Text
        {
            get
            {
                return this.m_Text;
            }
            set
            {
                this.m_Text = value;
                this.ultraLabel1.Text = this.m_Text;
            }
        }

        public Infragistics.Win.Misc.UltraLabel UltraLabel
        {
            get
            {
                return this.ultraLabel1;
            }
        }

        internal Infragistics.Win.Misc.UltraLabel ultraLabel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ultraLabel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ultraLabel1_Click);
                if (this._ultraLabel1 != null)
                {
                    this._ultraLabel1.Click -= handler;
                }
                this._ultraLabel1 = value;
                if (this._ultraLabel1 != null)
                {
                    this._ultraLabel1.Click += handler;
                }
            }
        }
    }
}

