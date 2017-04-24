namespace Deklarit.Controls
{
    using Deklarit;
    using Deklarit.Resources;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(UltraComboEditor))]
    public class DeklaritComboBox : UserControl
    {
        private bool m_AddEmptyValue;
        private bool m_FillAtStartup;
        private bool m_showPictureBox;
        protected static TypeConverter.StandardValuesCollection myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill" });

        public event EventHandler PictureBoxClicked;

        public event EventHandler SelectionChanged;

        public DeklaritComboBox()
        {
            base.SizeChanged += new EventHandler(this.DeklaritComboBox_SizeChanged);
            base.Load += new EventHandler(this.DeklaritComboBox_Load);
            base.EnabledChanged += new EventHandler(this.DeklaritComboBox_EnabledChanged);
            this.m_showPictureBox = false;
            this.m_FillAtStartup = true;
            this.InitializeComponent();
        }

        private void comboBox1_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.comboBox1.Enabled)
            {
                this.comboBox1.Dock = DockStyle.Fill;
                this.pictureBox1.Enabled = false;
            }
            else
            {
                this.comboBox1.Dock = DockStyle.None;
                this.pictureBox1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventArgs args = new EventArgs();
            EventHandler selectionChangedEvent = this.SelectionChanged;
            if (selectionChangedEvent != null)
            {
                selectionChangedEvent(this, args);
            }
        }

        private void comboBox1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.ShowPictureBox)
            {
                this.pictureBox1.Visible = this.comboBox1.Visible;
            }
        }

        private void DeklaritComboBox_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled)
            {
                this.comboBox1.Dock = DockStyle.Fill;
                this.pictureBox1.Enabled = false;
            }
            else
            {
                this.comboBox1.Dock = DockStyle.None;
                this.pictureBox1.Enabled = true;
            }
        }

        private void DeklaritComboBox_Load(object sender, EventArgs e)
        {
        }

        private void DeklaritComboBox_SizeChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Dock == DockStyle.None)
            {
                Size size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - 1);
                this.comboBox1.Size = size;
            }
            else
            {
                this.comboBox1.Size = this.Size;
            }
        }

        public int FindStringExact(string s)
        {
            return this.comboBox1.FindStringExact(s);
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.EnabledChanged += new System.EventHandler(this.comboBox1_EnabledChanged);
            this.comboBox1.VisibleChanged += new System.EventHandler(this.comboBox1_VisibleChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(130, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 17);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DeklaritComboBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DeklaritComboBox";
            this.Size = new System.Drawing.Size(146, 22);
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected void InvokeFillByMethod(string method, IDataAdapter da, DataSet ds, MethodInfo info)
        {
            try
            {
                object[] parameters = new object[(info.GetParameters().Length - 1) + 1];
                parameters[0] = ds;
                int index = 0;
                foreach (ParameterInfo info2 in info.GetParameters())
                {
                    if (index == 0)
                    {
                        parameters[0] = ds;
                    }
                    else
                    {
                        parameters[index] = RuntimeHelpers.GetObjectValue(this.GetType().GetProperty(method + info2.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(this, null));
                    }
                    index++;
                }
                info.Invoke(da, parameters);
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
        }

        protected void InvokeFillByMethod(string method, IDataAdapter da, DataSet ds, MethodInfo info, int start, int size)
        {
            try
            {
                object[] parameters = new object[(info.GetParameters().Length - 1) + 1];
                parameters[0] = ds;
                int index = 0;
                foreach (ParameterInfo info2 in info.GetParameters())
                {
                    if (index == 0)
                    {
                        parameters[0] = ds;
                    }
                    else if (index < (info.GetParameters().Length - 2))
                    {
                        parameters[index] = RuntimeHelpers.GetObjectValue(this.GetType().GetProperty(method + info2.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(this, null));
                    }
                    index++;
                }
                parameters[info.GetParameters().Length - 2] = start;
                parameters[info.GetParameters().Length - 1] = size;
                info.Invoke(da, parameters);
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            EventArgs args = new EventArgs();
            EventHandler pictureBoxClickedEvent = this.PictureBoxClicked;
            if (pictureBoxClickedEvent != null)
            {
                pictureBoxClickedEvent(this, args);
            }
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, Deklarit.Resources.Resources.DeklaritCombo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [Description("Add Empty Value to comboBox items."), DefaultValue(false), Category("Deklarit")]
        public bool AddEmptyValue
        {
            get
            {
                return this.m_AddEmptyValue;
            }
            set
            {
                this.m_AddEmptyValue = value;
            }
        }

        public new Color BackColor
        {
            get
            {
                return this.comboBox1.BackColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    base.BackColor = value;
                }
                else
                {
                    this.comboBox1.BackColor = value;
                }
            }
        }

        [Browsable(false)]
        public UltraComboEditor ComboBox
        {
            get
            {
                return this.comboBox1;
            }
        }

        public UltraComboEditor comboBox1;

        public new ControlBindingsCollection DataBindings
        {
            get
            {
                return this.comboBox1.DataBindings;
            }
        }

        public object DataSource
        {
            get
            {
                return this.comboBox1.DataSource;
            }
            set
            {
                this.comboBox1.DataSource = RuntimeHelpers.GetObjectValue(value);
            }
        }

        public string DisplayMember
        {
            get
            {
                return this.comboBox1.DisplayMember;
            }
            set
            {
                this.comboBox1.DisplayMember = value;
            }
        }

        public Infragistics.Win.DropDownStyle DropDownStyle
        {
            get
            {
                return this.comboBox1.DropDownStyle;
            }
            set
            {
                this.comboBox1.DropDownStyle = value;
            }
        }

        [Category("Deklarit"), Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true)]
        public bool FillAtStartup
        {
            get
            {
                return this.m_FillAtStartup;
            }
            set
            {
                this.m_FillAtStartup = value;
            }
        }

        public new System.Drawing.Font Font
        {
            get
            {
                return this.comboBox1.Font;
            }
            set
            {
                this.comboBox1.Font = value;
            }
        }

        public new Color ForeColor
        {
            get
            {
                return this.comboBox1.ForeColor;
            }
            set
            {
                this.comboBox1.ForeColor = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ValueListItemsCollection Items
        {
            get
            {
                return this.comboBox1.Items;
            }
        }

        [Browsable(false)]
        public System.Windows.Forms.PictureBox PictureBox
        {
            get
            {
                return this.pictureBox1;
            }
        }

        private System.Windows.Forms.PictureBox pictureBox1;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                return this.comboBox1.SelectedIndex;
            }
            set
            {
                this.comboBox1.SelectedIndex = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ValueListItem SelectedItem
        {
            get
            {
                return this.comboBox1.SelectedItem;
            }
            set
            {
                this.comboBox1.SelectedItem = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get
            {
                return this.comboBox1.SelectedText;
            }
            set
            {
                this.comboBox1.SelectedText = value;
            }
        }

        public bool ShowPictureBox
        {
            get
            {
                return this.m_showPictureBox;
            }
            set
            {
                pictureBox1.Image = ImageResourcesNew.page_white_edit;
                this.m_showPictureBox = value;
                this.pictureBox1.Visible = this.m_showPictureBox;
                if (this.m_showPictureBox)
                {
                    this.comboBox1.Dock = DockStyle.None;
                    this.DeklaritComboBox_SizeChanged(null, null);
                }
            }
        }

        public new object Tag
        {
            get
            {
                return this.comboBox1.Tag;
            }
            set
            {
                this.comboBox1.Tag = RuntimeHelpers.GetObjectValue(value);
            }
        }

        public new string Text
        {
            get
            {
                return this.comboBox1.Text;
            }
            set
            {
                this.comboBox1.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public object Value
        {
            get
            {
                return this.comboBox1.Value;
            }
            set
            {
                this.comboBox1.Value = RuntimeHelpers.GetObjectValue(value);
            }
        }

        public string ValueMember
        {
            get
            {
                return this.comboBox1.ValueMember;
            }
            set
            {
                this.comboBox1.ValueMember = value;
            }
        }

        internal class FillMethodsConverter : StringConverter
        {
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return DeklaritComboBox.myFillMethods;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        }
    }
}

