namespace NetAdvantage.SmartParts
{
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class UnosPojma : UserControl
    {
        [AccessedThroughProperty("UltraButton1")]
        private UltraButton _UltraButton1;
        [AccessedThroughProperty("UltraLabel1")]
        private UltraLabel _UltraLabel1;
        [AccessedThroughProperty("UltraTextEditor1")]
        private UltraTextEditor _UltraTextEditor1;

        public UnosPojma()
        {
            base.Load += new EventHandler(this.UserControl1_Load);
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.UltraButton1 = new UltraButton();
            this.UltraLabel1 = new UltraLabel();
            this.UltraTextEditor1 = new UltraTextEditor();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            this.SuspendLayout();
            this.UltraButton1.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            System.Drawing.Point point = new System.Drawing.Point(0x17d, 0x27);
            this.UltraButton1.Location = point;
            this.UltraButton1.Name = "UltraButton1";
            Size size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton1.Size = size;
            this.UltraButton1.TabIndex = 2;
            this.UltraButton1.Text = "Ok";
            point = new System.Drawing.Point(15, 0x10);
            this.UltraLabel1.Location = point;
            this.UltraLabel1.Name = "UltraLabel1";
            size = new System.Drawing.Size(160, 0x11);
            this.UltraLabel1.Size = size;
            this.UltraLabel1.TabIndex = 3;
            this.UltraLabel1.Text = "Unesite tekst za pretraživanje";
            this.UltraLabel1.UseAppStyling = false;
            point = new System.Drawing.Point(0xb5, 12);
            this.UltraTextEditor1.Location = point;
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            size = new System.Drawing.Size(0x113, 0x15);
            this.UltraTextEditor1.Size = size;
            this.UltraTextEditor1.TabIndex = 1;
            this.UltraTextEditor1.UseAppStyling = false;
            this.Controls.Add(this.UltraTextEditor1);
            this.Controls.Add(this.UltraLabel1);
            this.Controls.Add(this.UltraButton1);
            this.Name = "UnosPojma";
            size = new System.Drawing.Size(0x1d7, 0x49);
            this.Size = size;
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
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
            Keys keys = keyData;
            if (keys == Keys.Escape)
            {
                this.ParentForm.Close();
                return true;
            }
            if (keys != Keys.Return)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if (DB.N2T(RuntimeHelpers.GetObjectValue(this.UltraTextEditor1.Value), "") == "")
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            else
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            return true;
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UltraTextEditor1_GotFocus(object sender, EventArgs e)
        {
            this.UltraTextEditor1.SelectAll();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.UltraTextEditor1.Focus();
        }

        private UltraButton UltraButton1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraButton1_Click);
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click -= handler;
                }
                this._UltraButton1 = value;
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click += handler;
                }
            }
        }

        private UltraLabel UltraLabel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel1 = value;
            }
        }

        internal UltraTextEditor UltraTextEditor1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraTextEditor1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraTextEditor1_GotFocus);
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.GotFocus -= handler;
                }
                this._UltraTextEditor1 = value;
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.GotFocus += handler;
                }
            }
        }

        public string UneseniString
        {
            get
            {
                return Conversions.ToString(this.UltraTextEditor1.Value);
            }
        }
    }
}

