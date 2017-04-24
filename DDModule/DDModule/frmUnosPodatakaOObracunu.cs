using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace DDModule
{
    public class frmUnosPodatakaOObracunu : Form
    {
        private IContainer components { get; set; }

        public frmUnosPodatakaOObracunu()
        {
            base.Load += new EventHandler(this.frmUnosPodatakaOObracunu_Load);
            this.InitializeComponent();
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

        private void frmUnosPodatakaOObracunu_Load(object sender, EventArgs e)
        {
            this.Podaci_o_zadnjem_Obracunu();
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnosPodatakaOObracunu));
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.UltraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.txtOpisObracuna = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.datumobracunastaza = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpisObracuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumobracunastaza)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.UltraButton3);
            this.UltraGroupBox1.Controls.Add(this.UltraButton4);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel10);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel9);
            this.UltraGroupBox1.Controls.Add(this.txtOpisObracuna);
            this.UltraGroupBox1.Controls.Add(this.datumobracunastaza);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(450, 104);
            this.UltraGroupBox1.TabIndex = 83;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraButton3
            // 
            this.UltraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton3.Location = new System.Drawing.Point(307, 66);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(128, 23);
            this.UltraButton3.TabIndex = 179;
            this.UltraButton3.Text = "Odustani";
            this.UltraButton3.UseAppStyling = false;
            this.UltraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton3.Click += new System.EventHandler(this.UltraButton3_Click);
            // 
            // UltraButton4
            // 
            this.UltraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton4.Location = new System.Drawing.Point(174, 66);
            this.UltraButton4.Name = "UltraButton4";
            this.UltraButton4.Size = new System.Drawing.Size(123, 23);
            this.UltraButton4.TabIndex = 178;
            this.UltraButton4.Text = "Spremi";
            this.UltraButton4.UseAppStyling = false;
            this.UltraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton4.Click += new System.EventHandler(this.UltraButton4_Click);
            // 
            // UltraLabel10
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel10.Appearance = appearance4;
            this.UltraLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel10.Location = new System.Drawing.Point(25, 43);
            this.UltraLabel10.Name = "UltraLabel10";
            this.UltraLabel10.Size = new System.Drawing.Size(112, 14);
            this.UltraLabel10.TabIndex = 91;
            this.UltraLabel10.Text = "Opis obračuna";
            this.UltraLabel10.UseAppStyling = false;
            // 
            // UltraLabel9
            // 
            appearance.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel9.Appearance = appearance;
            this.UltraLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel9.Location = new System.Drawing.Point(25, 17);
            this.UltraLabel9.Name = "UltraLabel9";
            this.UltraLabel9.Size = new System.Drawing.Size(122, 14);
            this.UltraLabel9.TabIndex = 90;
            this.UltraLabel9.Text = "Datum obračuna";
            this.UltraLabel9.UseAppStyling = false;
            // 
            // txtOpisObracuna
            // 
            appearance3.BackColor = System.Drawing.Color.Lavender;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOpisObracuna.Appearance = appearance3;
            this.txtOpisObracuna.BackColor = System.Drawing.Color.Lavender;
            this.txtOpisObracuna.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.txtOpisObracuna.Location = new System.Drawing.Point(150, 39);
            this.txtOpisObracuna.Name = "txtOpisObracuna";
            this.txtOpisObracuna.Size = new System.Drawing.Size(285, 21);
            this.txtOpisObracuna.TabIndex = 105;
            this.txtOpisObracuna.UseAppStyling = false;
            // 
            // datumobracunastaza
            // 
            appearance2.BackColor = System.Drawing.Color.Lavender;
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.datumobracunastaza.Appearance = appearance2;
            this.datumobracunastaza.BackColor = System.Drawing.Color.Lavender;
            this.datumobracunastaza.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.datumobracunastaza.Location = new System.Drawing.Point(150, 12);
            this.datumobracunastaza.Name = "datumobracunastaza";
            this.datumobracunastaza.Size = new System.Drawing.Size(92, 21);
            this.datumobracunastaza.TabIndex = 103;
            this.datumobracunastaza.UseAppStyling = false;
            // 
            // frmUnosPodatakaOObracunu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 102);
            this.Controls.Add(this.UltraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUnosPodatakaOObracunu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zadavanje podataka o obračunu honorara";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpisObracuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumobracunastaza)).EndInit();
            this.ResumeLayout(false);

        }

        private void Kontrola_Focus(object sender, EventArgs e)
        {
            NewLateBinding.LateCall(sender, null, "SelectAll", new object[0], null, null, null, true);
        }

        public void Podaci_o_zadnjem_Obracunu()
        {
            this.datumobracunastaza.Value = DateTime.Now;
            this.txtOpisObracuna.Value = "";
        }

        private void PripremiKontrole()
        {
            this.datumobracunastaza.GotFocus += new EventHandler(this.Kontrola_Focus);
            this.txtOpisObracuna.GotFocus += new EventHandler(this.Kontrola_Focus);
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
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void UltraButton4_Click(object sender, EventArgs e)
        {
            if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.datumobracunastaza.Value)))
            {
                Interaction.MsgBox("Nepotpuni parametri obračuna!", MsgBoxStyle.Information, "Obračun plaća");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        public UltraDateTimeEditor datumobracunastaza;

        public UltraTextEditor txtOpisObracuna;

        private UltraButton UltraButton3;

        private UltraButton UltraButton4;

        private UltraGroupBox UltraGroupBox1;

        private UltraLabel UltraLabel10;

        private UltraLabel UltraLabel9;
    }
}

