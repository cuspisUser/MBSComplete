namespace FinPosModule.GK
{
    partial class frmIspisDokumenta
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
            this.btnIspis = new System.Windows.Forms.Button();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uneOd = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneDo = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.uneOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(108, 65);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(57, 23);
            this.btnIspis.TabIndex = 0;
            this.btnIspis.Text = "Ispis";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(9, 65);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(61, 23);
            this.btnZatvori.TabIndex = 1;
            this.btnZatvori.Text = "Odustani";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Do temeljnice:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Od temeljnice:";
            // 
            // uneOd
            // 
            this.uneOd.Location = new System.Drawing.Point(86, 5);
            this.uneOd.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneOd.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneOd.MaxValue = 9999999999D;
            this.uneOd.MinValue = 0D;
            this.uneOd.Name = "uneOd";
            this.uneOd.Nullable = true;
            this.uneOd.NullText = " ";
            this.uneOd.PromptChar = ' ';
            this.uneOd.Size = new System.Drawing.Size(79, 21);
            this.uneOd.TabIndex = 78;
            // 
            // uneDo
            // 
            this.uneDo.Location = new System.Drawing.Point(86, 29);
            this.uneDo.MaskInput = "{LOC}-nnnnnnnnnn";
            this.uneDo.MaximumSize = new System.Drawing.Size(9999, 0);
            this.uneDo.MaxValue = 9999999999D;
            this.uneDo.MinValue = 0D;
            this.uneDo.Name = "uneDo";
            this.uneDo.Nullable = true;
            this.uneDo.NullText = " ";
            this.uneDo.PromptChar = ' ';
            this.uneDo.Size = new System.Drawing.Size(79, 21);
            this.uneDo.TabIndex = 79;
            // 
            // frmIspisDokumenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 119);
            this.ControlBox = false;
            this.Controls.Add(this.uneDo);
            this.Controls.Add(this.uneOd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.btnIspis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIspisDokumenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ispis temeljnica";
            ((System.ComponentModel.ISupportInitialize)(this.uneOd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIspis;
        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneOd;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneDo;
    }
}