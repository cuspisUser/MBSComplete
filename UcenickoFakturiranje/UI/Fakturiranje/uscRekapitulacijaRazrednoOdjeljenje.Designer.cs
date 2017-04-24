namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscRekapitulacijaRazrednoOdjeljenje
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
            this.btnVirmani = new System.Windows.Forms.Button();
            this.btnObracunOdustani = new System.Windows.Forms.Button();
            this.lblObracun = new System.Windows.Forms.Label();
            this.ucbRazrednaOdjeljenja = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucbUstanova = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ucbRazrednaOdjeljenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbUstanova)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName1
            // 
            this.lblName1.Location = new System.Drawing.Point(-3, 0);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(57, 23);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Obračun:";
            this.lblName1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVirmani
            // 
            this.btnVirmani.Location = new System.Drawing.Point(143, 143);
            this.btnVirmani.Name = "btnVirmani";
            this.btnVirmani.Size = new System.Drawing.Size(87, 25);
            this.btnVirmani.TabIndex = 6;
            this.btnVirmani.Text = "Rekapitulacija";
            this.btnVirmani.UseVisualStyleBackColor = true;
            this.btnVirmani.Click += new System.EventHandler(this.btnVirmani_Click);
            // 
            // btnObracunOdustani
            // 
            this.btnObracunOdustani.Location = new System.Drawing.Point(3, 143);
            this.btnObracunOdustani.Name = "btnObracunOdustani";
            this.btnObracunOdustani.Size = new System.Drawing.Size(69, 25);
            this.btnObracunOdustani.TabIndex = 7;
            this.btnObracunOdustani.Text = "Odustani";
            this.btnObracunOdustani.UseVisualStyleBackColor = true;
            this.btnObracunOdustani.Click += new System.EventHandler(this.btnObracunOdustani_Click);
            // 
            // lblObracun
            // 
            this.lblObracun.Location = new System.Drawing.Point(55, 0);
            this.lblObracun.Name = "lblObracun";
            this.lblObracun.Size = new System.Drawing.Size(158, 23);
            this.lblObracun.TabIndex = 8;
            this.lblObracun.Text = "Obračun:";
            this.lblObracun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbRazrednaOdjeljenja
            // 
            this.ucbRazrednaOdjeljenja.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucbRazrednaOdjeljenja.DisplayMember = "Naziv";
            this.ucbRazrednaOdjeljenja.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbRazrednaOdjeljenja.Location = new System.Drawing.Point(3, 101);
            this.ucbRazrednaOdjeljenja.MaxDropDownItems = 20;
            this.ucbRazrednaOdjeljenja.Name = "ucbRazrednaOdjeljenja";
            this.ucbRazrednaOdjeljenja.Size = new System.Drawing.Size(227, 21);
            this.ucbRazrednaOdjeljenja.TabIndex = 21;
            this.ucbRazrednaOdjeljenja.ValueMember = "ID";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Razredno odjeljenje:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Ustanova:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbUstanova
            // 
            this.ucbUstanova.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.ucbUstanova.DisplayMember = "Naziv";
            this.ucbUstanova.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbUstanova.Location = new System.Drawing.Point(3, 55);
            this.ucbUstanova.MaxDropDownItems = 20;
            this.ucbUstanova.Name = "ucbUstanova";
            this.ucbUstanova.Size = new System.Drawing.Size(227, 21);
            this.ucbUstanova.TabIndex = 23;
            this.ucbUstanova.ValueMember = "ID";
            // 
            // uscRekapitulacijaRazrednoOdjeljenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucbUstanova);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucbRazrednaOdjeljenja);
            this.Controls.Add(this.lblObracun);
            this.Controls.Add(this.btnObracunOdustani);
            this.Controls.Add(this.btnVirmani);
            this.Controls.Add(this.lblName1);
            this.Name = "uscRekapitulacijaRazrednoOdjeljenje";
            this.Size = new System.Drawing.Size(278, 234);
            ((System.ComponentModel.ISupportInitialize)(this.ucbRazrednaOdjeljenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbUstanova)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Button btnVirmani;
        private System.Windows.Forms.Button btnObracunOdustani;
        private System.Windows.Forms.Label lblObracun;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbRazrednaOdjeljenja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbUstanova;

    }
}
