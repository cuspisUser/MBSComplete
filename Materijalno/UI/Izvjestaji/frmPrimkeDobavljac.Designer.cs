namespace Materijalno.UI.Izvjestaji
{
    partial class frmPrimkeDobavljac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnIspis = new System.Windows.Forms.Button();
            this.cmbDobavljac = new System.Windows.Forms.ComboBox();
            this.udtDatumDo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udtDatumOd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dobavljač:";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(83, 93);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 9;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(238, 93);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(75, 23);
            this.btnIspis.TabIndex = 10;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // cmbDobavljac
            // 
            this.cmbDobavljac.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDobavljac.FormattingEnabled = true;
            this.cmbDobavljac.Location = new System.Drawing.Point(83, 12);
            this.cmbDobavljac.Name = "cmbDobavljac";
            this.cmbDobavljac.Size = new System.Drawing.Size(230, 21);
            this.cmbDobavljac.TabIndex = 11;
            this.cmbDobavljac.TextChanged += new System.EventHandler(this.cmbDobavljac_TextChanged);
            this.cmbDobavljac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDobavljac_KeyPress);
            // 
            // udtDatumDo
            // 
            this.udtDatumDo.Location = new System.Drawing.Point(83, 65);
            this.udtDatumDo.MaskInput = "{date}";
            this.udtDatumDo.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumDo.Name = "udtDatumDo";
            this.udtDatumDo.Size = new System.Drawing.Size(230, 21);
            this.udtDatumDo.TabIndex = 19;
            this.udtDatumDo.Value = null;
            // 
            // udtDatumOd
            // 
            this.udtDatumOd.Location = new System.Drawing.Point(83, 39);
            this.udtDatumOd.MaskInput = "{date}";
            this.udtDatumOd.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumOd.Name = "udtDatumOd";
            this.udtDatumOd.Size = new System.Drawing.Size(230, 21);
            this.udtDatumOd.TabIndex = 18;
            this.udtDatumOd.Value = null;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Datum od:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Datum do:";
            // 
            // frmPrimkeDobavljac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 147);
            this.ControlBox = false;
            this.Controls.Add(this.udtDatumDo);
            this.Controls.Add(this.udtDatumOd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDobavljac);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPrimkeDobavljac";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primke po dobavljaču";
            this.Load += new System.EventHandler(this.frmPrimkeDobavljac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnIspis;
        private System.Windows.Forms.ComboBox cmbDobavljac;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumDo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumOd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}