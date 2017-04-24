partial class frmPokazateljMjesecno
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
            this.uneObracuniGodina = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.uneObracuniGodina)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(18, 63);
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
            this.btnGeneriraj.Location = new System.Drawing.Point(123, 63);
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
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Unesite mjesec";
            // 
            // uneObracuniGodina
            // 
            this.uneObracuniGodina.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.uneObracuniGodina.Location = new System.Drawing.Point(18, 37);
            this.uneObracuniGodina.MaskInput = "{LOC}-nn";
            this.uneObracuniGodina.MaxValue = 12;
            this.uneObracuniGodina.MinValue = 1;
            this.uneObracuniGodina.Name = "uneObracuniGodina";
            this.uneObracuniGodina.NullText = " ";
            this.uneObracuniGodina.PromptChar = ' ';
            this.uneObracuniGodina.Size = new System.Drawing.Size(179, 21);
            this.uneObracuniGodina.TabIndex = 5;
            this.uneObracuniGodina.Value = 1;
            // 
            // frmPokazateljMjesecno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 124);
            this.ControlBox = false;
            this.Controls.Add(this.uneObracuniGodina);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGeneriraj);
            this.Controls.Add(this.btnOdustani);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPokazateljMjesecno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPokazatelj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uneObracuniGodina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOdustani;
    private System.Windows.Forms.Button btnGeneriraj;
    private System.Windows.Forms.Label label1;
    private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneObracuniGodina;
}
