partial class frmPokazateljRazdoblje
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
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnGeneriraj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.udtDatumOd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.udtDatumDo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(37, 80);
            this.btnOdustani.Margin = new System.Windows.Forms.Padding(2);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(66, 24);
            this.btnOdustani.TabIndex = 1;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnGeneriraj
            // 
            this.btnGeneriraj.Location = new System.Drawing.Point(187, 80);
            this.btnGeneriraj.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneriraj.Name = "btnGeneriraj";
            this.btnGeneriraj.Size = new System.Drawing.Size(74, 24);
            this.btnGeneriraj.TabIndex = 2;
            this.btnGeneriraj.Text = "Generiraj";
            this.btnGeneriraj.UseVisualStyleBackColor = true;
            this.btnGeneriraj.Click += new System.EventHandler(this.btnGeneriraj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Odaberite razdoblje";
            // 
            // udtDatumOd
            // 
            this.udtDatumOd.Location = new System.Drawing.Point(37, 27);
            this.udtDatumOd.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumOd.Name = "udtDatumOd";
            this.udtDatumOd.Size = new System.Drawing.Size(224, 21);
            this.udtDatumOd.TabIndex = 12;
            this.udtDatumOd.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Od:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Do:";
            // 
            // udtDatumDo
            // 
            this.udtDatumDo.Location = new System.Drawing.Point(37, 53);
            this.udtDatumDo.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.udtDatumDo.Name = "udtDatumDo";
            this.udtDatumDo.Size = new System.Drawing.Size(224, 21);
            this.udtDatumDo.TabIndex = 14;
            this.udtDatumDo.Value = null;
            // 
            // frmPokazateljRazdoblje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 143);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.udtDatumDo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.udtDatumOd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGeneriraj);
            this.Controls.Add(this.btnOdustani);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPokazateljRazdoblje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPokazatelj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumOd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumDo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOdustani;
    private System.Windows.Forms.Button btnGeneriraj;
    private System.Windows.Forms.Label label1;
    private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumOd;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumDo;
}
