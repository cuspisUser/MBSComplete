namespace NetAdvantage.SmartParts
{
    partial class JOPPDBroj
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
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            this.UltraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.txtOznakaIzvjesca = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UltraLabel7
            // 
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel7.Appearance = appearance32;
            this.UltraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel7.Location = new System.Drawing.Point(12, 11);
            this.UltraLabel7.Name = "UltraLabel7";
            this.UltraLabel7.Size = new System.Drawing.Size(289, 23);
            this.UltraLabel7.TabIndex = 117;
            this.UltraLabel7.Text = "Unesite oznaku JOPPD-a";
            this.UltraLabel7.UseAppStyling = false;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(12, 80);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(64, 23);
            this.btnOdustani.TabIndex = 119;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(121, 80);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(67, 23);
            this.btnSpremi.TabIndex = 118;
            this.btnSpremi.Text = "Potvrdi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // txtOznakaIzvjesca
            // 
            this.txtOznakaIzvjesca.Location = new System.Drawing.Point(12, 40);
            this.txtOznakaIzvjesca.Name = "txtOznakaIzvjesca";
            this.txtOznakaIzvjesca.Size = new System.Drawing.Size(176, 20);
            this.txtOznakaIzvjesca.TabIndex = 120;
            // 
            // JOPPDBroj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 137);
            this.ControlBox = false;
            this.Controls.Add(this.txtOznakaIzvjesca);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.UltraLabel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "JOPPDBroj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oznaka izvješća JOPPD-a";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel UltraLabel7;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnSpremi;
        public System.Windows.Forms.TextBox txtOznakaIzvjesca;
    }
}