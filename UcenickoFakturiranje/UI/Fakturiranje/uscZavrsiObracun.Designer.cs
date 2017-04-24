namespace UcenickoFakturiranje.UI.Fakturiranje
{
    partial class uscZavrsiObracun
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
            this.btnZavrsiObracunSpremi = new System.Windows.Forms.Button();
            this.btnZavrsiObracunVirmani = new System.Windows.Forms.Button();
            this.btnZavrsiObracunOdustani = new System.Windows.Forms.Button();
            this.btnZavrsiObracunZaduzi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZavrsiObracunSpremi
            // 
            this.btnZavrsiObracunSpremi.Location = new System.Drawing.Point(14, 12);
            this.btnZavrsiObracunSpremi.Name = "btnZavrsiObracunSpremi";
            this.btnZavrsiObracunSpremi.Size = new System.Drawing.Size(117, 25);
            this.btnZavrsiObracunSpremi.TabIndex = 0;
            this.btnZavrsiObracunSpremi.Text = "Zaključaj obračun";
            this.btnZavrsiObracunSpremi.UseVisualStyleBackColor = true;
            this.btnZavrsiObracunSpremi.Click += new System.EventHandler(this.btnZavrsiObracunSpremi_Click);
            // 
            // btnZavrsiObracunVirmani
            // 
            this.btnZavrsiObracunVirmani.Location = new System.Drawing.Point(150, 51);
            this.btnZavrsiObracunVirmani.Name = "btnZavrsiObracunVirmani";
            this.btnZavrsiObracunVirmani.Size = new System.Drawing.Size(117, 25);
            this.btnZavrsiObracunVirmani.TabIndex = 1;
            this.btnZavrsiObracunVirmani.Text = "Virmani";
            this.btnZavrsiObracunVirmani.UseVisualStyleBackColor = true;
            this.btnZavrsiObracunVirmani.Click += new System.EventHandler(this.btnZavrsiObracunVirmani_Click);
            // 
            // btnZavrsiObracunOdustani
            // 
            this.btnZavrsiObracunOdustani.Location = new System.Drawing.Point(14, 51);
            this.btnZavrsiObracunOdustani.Name = "btnZavrsiObracunOdustani";
            this.btnZavrsiObracunOdustani.Size = new System.Drawing.Size(117, 25);
            this.btnZavrsiObracunOdustani.TabIndex = 3;
            this.btnZavrsiObracunOdustani.Text = "Odustani";
            this.btnZavrsiObracunOdustani.UseVisualStyleBackColor = true;
            this.btnZavrsiObracunOdustani.Click += new System.EventHandler(this.btnZavrsiObracunOdustani_Click);
            // 
            // btnZavrsiObracunZaduzi
            // 
            this.btnZavrsiObracunZaduzi.Location = new System.Drawing.Point(150, 12);
            this.btnZavrsiObracunZaduzi.Name = "btnZavrsiObracunZaduzi";
            this.btnZavrsiObracunZaduzi.Size = new System.Drawing.Size(117, 23);
            this.btnZavrsiObracunZaduzi.TabIndex = 4;
            this.btnZavrsiObracunZaduzi.Text = "Financijski zaduži";
            this.btnZavrsiObracunZaduzi.UseVisualStyleBackColor = true;
            this.btnZavrsiObracunZaduzi.Click += new System.EventHandler(this.btnZavrsiObracunZaduzi_Click);
            // 
            // uscZavrsiObracun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnZavrsiObracunZaduzi);
            this.Controls.Add(this.btnZavrsiObracunOdustani);
            this.Controls.Add(this.btnZavrsiObracunVirmani);
            this.Controls.Add(this.btnZavrsiObracunSpremi);
            this.Name = "uscZavrsiObracun";
            this.Size = new System.Drawing.Size(290, 114);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnZavrsiObracunSpremi;
        private System.Windows.Forms.Button btnZavrsiObracunVirmani;
        private System.Windows.Forms.Button btnZavrsiObracunOdustani;
        private System.Windows.Forms.Button btnZavrsiObracunZaduzi;
    }
}
