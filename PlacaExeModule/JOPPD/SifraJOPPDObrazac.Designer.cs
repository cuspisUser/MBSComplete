namespace JOPPD
{
	partial class SifraJOPPDObrazac
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
            this.txtOznakaIzvjesca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.cbkIsprazni = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkInvalid = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtOznakaIzvjesca
            // 
            this.txtOznakaIzvjesca.Location = new System.Drawing.Point(115, 51);
            this.txtOznakaIzvjesca.Name = "txtOznakaIzvjesca";
            this.txtOznakaIzvjesca.Size = new System.Drawing.Size(124, 20);
            this.txtOznakaIzvjesca.TabIndex = 0;
            this.txtOznakaIzvjesca.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unesite oznaku:";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(164, 109);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 2;
            this.btnSpremi.Text = "Potvrdi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(21, 109);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 3;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // cbkIsprazni
            // 
            this.cbkIsprazni.AutoSize = true;
            this.cbkIsprazni.Location = new System.Drawing.Point(224, 27);
            this.cbkIsprazni.Name = "cbkIsprazni";
            this.cbkIsprazni.Size = new System.Drawing.Size(15, 14);
            this.cbkIsprazni.TabIndex = 4;
            this.cbkIsprazni.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Isprazni poziv i model odobrenja:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "izradi virman za invalide:";
            // 
            // cbkInvalid
            // 
            this.cbkInvalid.AutoSize = true;
            this.cbkInvalid.Location = new System.Drawing.Point(224, 83);
            this.cbkInvalid.Name = "cbkInvalid";
            this.cbkInvalid.Size = new System.Drawing.Size(15, 14);
            this.cbkInvalid.TabIndex = 6;
            this.cbkInvalid.UseVisualStyleBackColor = true;
            // 
            // SifraJOPPDObrazac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 168);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbkInvalid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbkIsprazni);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOznakaIzvjesca);
            this.Name = "SifraJOPPDObrazac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unesite oznaku izvješća JOPPD-a";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SifraJOPPDObrazac_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Button btnOdustani;
        public System.Windows.Forms.TextBox txtOznakaIzvjesca;
        private System.Windows.Forms.CheckBox cbkIsprazni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbkInvalid;
	}
}