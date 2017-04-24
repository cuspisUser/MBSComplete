namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class OdabirSheme
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucbShema = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnObracunOdustani = new System.Windows.Forms.Button();
            this.btnZaduzi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ucbShema)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberite shemu po kojoj želite financijski zadužiti:";
            // 
            // ucbShema
            // 
            this.ucbShema.DisplayMember = "NAZIV";
            this.ucbShema.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbShema.Location = new System.Drawing.Point(9, 37);
            this.ucbShema.MaxDropDownItems = 20;
            this.ucbShema.Name = "ucbShema";
            this.ucbShema.Size = new System.Drawing.Size(253, 21);
            this.ucbShema.TabIndex = 109;
            this.ucbShema.ValueMember = "ID";
            // 
            // btnObracunOdustani
            // 
            this.btnObracunOdustani.Location = new System.Drawing.Point(9, 75);
            this.btnObracunOdustani.Name = "btnObracunOdustani";
            this.btnObracunOdustani.Size = new System.Drawing.Size(69, 25);
            this.btnObracunOdustani.TabIndex = 110;
            this.btnObracunOdustani.Text = "Odustani";
            this.btnObracunOdustani.UseVisualStyleBackColor = true;
            this.btnObracunOdustani.Click += new System.EventHandler(this.btnObracunOdustani_Click);
            // 
            // btnZaduzi
            // 
            this.btnZaduzi.Location = new System.Drawing.Point(193, 75);
            this.btnZaduzi.Name = "btnZaduzi";
            this.btnZaduzi.Size = new System.Drawing.Size(69, 25);
            this.btnZaduzi.TabIndex = 111;
            this.btnZaduzi.Text = "Zaduži";
            this.btnZaduzi.UseVisualStyleBackColor = true;
            this.btnZaduzi.Click += new System.EventHandler(this.btnZaduzi_Click);
            // 
            // OdabirSheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnZaduzi);
            this.Controls.Add(this.btnObracunOdustani);
            this.Controls.Add(this.ucbShema);
            this.Controls.Add(this.label1);
            this.Name = "OdabirSheme";
            this.Size = new System.Drawing.Size(305, 163);
            ((System.ComponentModel.ISupportInitialize)(this.ucbShema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbShema;
        private System.Windows.Forms.Button btnObracunOdustani;
        private System.Windows.Forms.Button btnZaduzi;
    }
}