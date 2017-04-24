using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmIznosi : Form
{
    private IContainer components { get; set; }

    public frmIznosi()
    {
        base.Load += new EventHandler(this.frmIdentifikator_Load);
        this.InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.Zatvori();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmIdentifikator_Load(object sender, EventArgs e)
    {
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
        this.iznos.Focus();
        this.iznos.SelectAll();
    }

    private void InitializeComponent()
    {
        this.Button1 = new Button();
        this.iznos = new UltraNumericEditor();
        this.Label1 = new Label();
        ((ISupportInitialize) this.iznos).BeginInit();
        this.SuspendLayout();
        this.Button1.Location = new System.Drawing.Point(0xe4, 0x2c);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
        this.Button1.TabIndex = 2;
        this.Button1.Text = "Potvrdi";
        this.Button1.UseVisualStyleBackColor = true;
        this.iznos.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
        this.iznos.Location = new System.Drawing.Point(0xbc, 0x11);
        this.iznos.Name = "iznos";
        this.iznos.NumericType = NumericType.Decimal;
        this.iznos.PromptChar = ' ';
        this.iznos.Size = new System.Drawing.Size(0x73, 0x15);
        this.iznos.TabIndex = 1;
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label1.Location = new System.Drawing.Point(1, 20);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(0xa6, 13);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Iznos povećanja vrijednosti:";
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(0x13d, 0x4f);
        this.ControlBox = false;
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.iznos);
        this.Controls.Add(this.Button1);
        this.Name = "frmIznosi";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "ENTER za potvrdu  ili ESC za prekid";


        this.Button1.Click += new EventHandler(this.Button1_Click);


        ((ISupportInitialize) this.iznos).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
        {
            bool flag = false;
            return flag;
        }
        switch (keyData)
        {
            case Keys.Return:
                this.Zatvori();
                return true;

            case Keys.Escape:
                this.iznos.Value = 0;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    public void Zatvori()
    {
        if (Operators.ConditionalCompareObjectEqual(this.iznos.Value, 0, false))
        {
            Interaction.MsgBox("Iznos povećanja vrijednosti ne može biti 0" + Conversions.ToString(this.iznos.MaxValue), MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    public decimal __IznosPromjene
    {
        get
        {
            return Conversions.ToDecimal(this.iznos.Value);
        }
        set
        {
            this.__IznosPromjene = value;
        }
    }

    private Button Button1;

    public UltraNumericEditor iznos;

    private Label Label1;
}

