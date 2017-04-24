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

public class frmIznosiSmanjenje : Form
{
    private IContainer components { get; set; }

    public frmIznosiSmanjenje()
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
        this.nabavnasmanjenje.Focus();
        this.nabavnasmanjenje.SelectAll();
    }

    private void InitializeComponent()
    {
        this.Button1 = new Button();
        this.nabavnasmanjenje = new UltraNumericEditor();
        this.Label1 = new Label();
        this.ISPRAVAKSMANJENJE = new UltraNumericEditor();
        this.Label2 = new Label();
        ((ISupportInitialize) this.nabavnasmanjenje).BeginInit();
        ((ISupportInitialize) this.ISPRAVAKSMANJENJE).BeginInit();
        this.SuspendLayout();
        this.Button1.Location = new System.Drawing.Point(0xe4, 80);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
        this.Button1.TabIndex = 2;
        this.Button1.Text = "Potvrdi";
        this.Button1.UseVisualStyleBackColor = true;
        this.nabavnasmanjenje.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
        this.nabavnasmanjenje.Location = new System.Drawing.Point(0xbc, 0x11);
        this.nabavnasmanjenje.Name = "nabavnasmanjenje";
        this.nabavnasmanjenje.NumericType = NumericType.Decimal;
        this.nabavnasmanjenje.PromptChar = ' ';
        this.nabavnasmanjenje.Size = new System.Drawing.Size(0x73, 0x15);
        this.nabavnasmanjenje.TabIndex = 1;
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label1.Location = new System.Drawing.Point(1, 20);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(0xb8, 13);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Smanjenje nabavne vrijednosti:";
        this.ISPRAVAKSMANJENJE.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
        this.ISPRAVAKSMANJENJE.Location = new System.Drawing.Point(0xbc, 0x2c);
        this.ISPRAVAKSMANJENJE.Name = "ISPRAVAKSMANJENJE";
        this.ISPRAVAKSMANJENJE.NumericType = NumericType.Decimal;
        this.ISPRAVAKSMANJENJE.PromptChar = ' ';
        this.ISPRAVAKSMANJENJE.Size = new System.Drawing.Size(0x73, 0x15);
        this.ISPRAVAKSMANJENJE.TabIndex = 4;
        this.Label2.AutoSize = true;
        this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label2.Location = new System.Drawing.Point(1, 0x30);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(0x79, 13);
        this.Label2.TabIndex = 5;
        this.Label2.Text = "Smanjenje ispravka:";
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(0x13d, 0x6f);
        this.ControlBox = false;
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.ISPRAVAKSMANJENJE);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.nabavnasmanjenje);
        this.Controls.Add(this.Button1);
        this.Name = "frmIznosiSmanjenje";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "ENTER za potvrdu  ili ESC za prekid";


        this.Button1.Click += new EventHandler(this.Button1_Click);


        ((ISupportInitialize) this.nabavnasmanjenje).EndInit();
        ((ISupportInitialize) this.ISPRAVAKSMANJENJE).EndInit();
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
                this.nabavnasmanjenje.Value = 0;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    public void Zatvori()
    {
        if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.nabavnasmanjenje.Value, 0, false), Operators.CompareObjectEqual(this.ISPRAVAKSMANJENJE.Value, 0, false))))
        {
            Interaction.MsgBox("Barem jedan od iznosa mora biti veći od nule" + Conversions.ToString(this.nabavnasmanjenje.MaxValue), MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    public decimal __IznosPromjeneIspravak
    {
        get
        {
            return Conversions.ToDecimal(this.ISPRAVAKSMANJENJE.Value);
        }
        set
        {
            this.__IznosPromjeneIspravak = value;
        }
    }

    public decimal __IznosPromjeneNabavna
    {
        get
        {
            return Conversions.ToDecimal(this.nabavnasmanjenje.Value);
        }
        set
        {
            this.__IznosPromjeneNabavna = value;
        }
    }

    private Button Button1;

    public UltraNumericEditor ISPRAVAKSMANJENJE;

    private Label Label1;

    private Label Label2;

    public UltraNumericEditor nabavnasmanjenje;
}

