namespace Rest
{
    partial class frmLogoPath
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
            this.lblPutanja = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogo = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblPutanja
            // 
            this.lblPutanja.Location = new System.Drawing.Point(10, 6);
            this.lblPutanja.Name = "lblPutanja";
            this.lblPutanja.Size = new System.Drawing.Size(214, 42);
            this.lblPutanja.TabIndex = 0;
            this.lblPutanja.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odaberite logo:";
            // 
            // btnLogo
            // 
            this.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogo.Location = new System.Drawing.Point(117, 55);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(107, 23);
            this.btnLogo.TabIndex = 4;
            this.btnLogo.Text = "Logo";
            this.btnLogo.UseVisualStyleBackColor = true;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(117, 96);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(107, 23);
            this.btnSpremi.TabIndex = 5;
            this.btnSpremi.Text = "Ok";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // ofdLogo
            // 
            this.ofdLogo.FileName = "openFileDialog1";
            // 
            // frmLogoPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.btnLogo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPutanja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLogoPath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logo";
            this.Load += new System.EventHandler(this.frmLogoPath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPutanja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogo;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.OpenFileDialog ofdLogo;
    }
}