namespace UcenickoFakturiranje.UI.Izvjestaji
{
    partial class frmOtvoreneStavke
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRazred = new System.Windows.Forms.ComboBox();
            this.cmbUstanova = new System.Windows.Forms.ComboBox();
            this.dtpDoDatuma = new System.Windows.Forms.DateTimePicker();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnIspis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Razred:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ustanova:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Do datuma:";
            // 
            // cmbRazred
            // 
            this.cmbRazred.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbRazred.FormattingEnabled = true;
            this.cmbRazred.Location = new System.Drawing.Point(104, 82);
            this.cmbRazred.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbRazred.Name = "cmbRazred";
            this.cmbRazred.Size = new System.Drawing.Size(356, 24);
            this.cmbRazred.TabIndex = 5;
            // 
            // cmbUstanova
            // 
            this.cmbUstanova.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbUstanova.FormattingEnabled = true;
            this.cmbUstanova.Location = new System.Drawing.Point(104, 47);
            this.cmbUstanova.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbUstanova.Name = "cmbUstanova";
            this.cmbUstanova.Size = new System.Drawing.Size(356, 24);
            this.cmbUstanova.TabIndex = 6;
            this.cmbUstanova.SelectedIndexChanged += new System.EventHandler(this.cmbUstanova_SelectedIndexChanged);
            // 
            // dtpDoDatuma
            // 
            this.dtpDoDatuma.Location = new System.Drawing.Point(104, 11);
            this.dtpDoDatuma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDoDatuma.Name = "dtpDoDatuma";
            this.dtpDoDatuma.Size = new System.Drawing.Size(356, 22);
            this.dtpDoDatuma.TabIndex = 8;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(104, 130);
            this.btnOdustani.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(100, 28);
            this.btnOdustani.TabIndex = 9;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(361, 130);
            this.btnIspis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(100, 28);
            this.btnIspis.TabIndex = 10;
            this.btnIspis.Text = "Ispiši";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Click += new System.EventHandler(this.btnIspis_Click);
            // 
            // frmOtvoreneStavke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 258);
            this.ControlBox = false;
            this.Controls.Add(this.btnIspis);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.dtpDoDatuma);
            this.Controls.Add(this.cmbUstanova);
            this.Controls.Add(this.cmbRazred);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmOtvoreneStavke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otvorene stavke po razredima";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRazred;
        private System.Windows.Forms.ComboBox cmbUstanova;
        private System.Windows.Forms.DateTimePicker dtpDoDatuma;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnIspis;
    }
}