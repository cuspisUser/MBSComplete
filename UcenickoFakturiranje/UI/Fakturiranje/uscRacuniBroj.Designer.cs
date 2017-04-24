namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscRacuniBroj
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName1 = new System.Windows.Forms.Label();
            this.btnIspis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ucbGodina = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uteOD = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteDo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ucbGodina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName1
            // 
            this.lblName1.Location = new System.Drawing.Point(-3, 0);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(227, 23);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Ispis računa od broja do broja za godinu";
            this.lblName1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblName1.Click += new System.EventHandler(this.lblName1_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(155, 129);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(69, 25);
            this.btnIspis.TabIndex = 6;
            this.btnIspis.Text = "Ispis";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnVirmani_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Godina:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucbGodina
            // 
            this.ucbGodina.DisplayMember = "Naziv";
            this.ucbGodina.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbGodina.Location = new System.Drawing.Point(6, 62);
            this.ucbGodina.MaxDropDownItems = 20;
            this.ucbGodina.Name = "ucbGodina";
            this.ucbGodina.Size = new System.Drawing.Size(218, 21);
            this.ucbGodina.TabIndex = 109;
            this.ucbGodina.ValueMember = "ID";
            // 
            // uteOD
            // 
            this.uteOD.Location = new System.Drawing.Point(32, 98);
            this.uteOD.MaxLength = 10;
            this.uteOD.Name = "uteOD";
            this.uteOD.Size = new System.Drawing.Size(80, 21);
            this.uteOD.TabIndex = 110;
            // 
            // uteDo
            // 
            this.uteDo.Location = new System.Drawing.Point(144, 98);
            this.uteDo.MaxLength = 10;
            this.uteDo.Name = "uteDo";
            this.uteDo.Size = new System.Drawing.Size(80, 21);
            this.uteDo.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-1, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 112;
            this.label2.Text = "OD:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(115, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 23);
            this.label3.TabIndex = 113;
            this.label3.Text = "DO:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(6, 129);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(69, 25);
            this.btnOdustani.TabIndex = 114;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // uscRacuniBroj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uteDo);
            this.Controls.Add(this.uteOD);
            this.Controls.Add(this.ucbGodina);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.lblName1);
            this.Name = "uscRacuniBroj";
            this.Size = new System.Drawing.Size(295, 236);
            ((System.ComponentModel.ISupportInitialize)(this.ucbGodina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Button btnIspis;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbGodina;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteOD;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOdustani;

    }
}
