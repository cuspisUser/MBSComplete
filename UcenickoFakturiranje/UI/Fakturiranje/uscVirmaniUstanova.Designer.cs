namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscVirmaniUstanova
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucbUstanova = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.udtDatumIzdavanja = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ucbUstanova)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIzdavanja)).BeginInit();
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
            this.btnVirmani.Location = new System.Drawing.Point(209, 135);
            this.btnVirmani.Name = "btnVirmani";
            this.btnVirmani.Size = new System.Drawing.Size(69, 25);
            this.btnVirmani.TabIndex = 6;
            this.btnVirmani.Text = "Računi";
            this.btnVirmani.UseVisualStyleBackColor = true;
            this.btnVirmani.Click += new System.EventHandler(this.btnVirmani_Click);
            // 
            // btnObracunOdustani
            // 
            this.btnObracunOdustani.Location = new System.Drawing.Point(6, 135);
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
            this.lblObracun.Size = new System.Drawing.Size(207, 23);
            this.lblObracun.TabIndex = 8;
            this.lblObracun.Text = "Obračun:";
            this.lblObracun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ustanova:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucbUstanova
            // 
            this.ucbUstanova.DisplayMember = "Naziv";
            this.ucbUstanova.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbUstanova.Location = new System.Drawing.Point(6, 59);
            this.ucbUstanova.MaxDropDownItems = 20;
            this.ucbUstanova.Name = "ucbUstanova";
            this.ucbUstanova.Size = new System.Drawing.Size(272, 21);
            this.ucbUstanova.TabIndex = 109;
            this.ucbUstanova.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 23);
            this.label2.TabIndex = 110;
            this.label2.Text = "Datum izdavanja računa:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udtDatumIzdavanja
            // 
            this.udtDatumIzdavanja.Location = new System.Drawing.Point(9, 108);
            this.udtDatumIzdavanja.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumIzdavanja.Name = "udtDatumIzdavanja";
            this.udtDatumIzdavanja.Size = new System.Drawing.Size(269, 21);
            this.udtDatumIzdavanja.TabIndex = 111;
            // 
            // uscVirmaniUstanova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.udtDatumIzdavanja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucbUstanova);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblObracun);
            this.Controls.Add(this.btnObracunOdustani);
            this.Controls.Add(this.btnVirmani);
            this.Controls.Add(this.lblName1);
            this.Name = "uscVirmaniUstanova";
            this.Size = new System.Drawing.Size(319, 216);
            ((System.ComponentModel.ISupportInitialize)(this.ucbUstanova)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIzdavanja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Button btnVirmani;
        private System.Windows.Forms.Button btnObracunOdustani;
        private System.Windows.Forms.Label lblObracun;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbUstanova;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumIzdavanja;

    }
}
