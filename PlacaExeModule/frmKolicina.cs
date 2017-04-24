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

public class frmKolicina : Form
{
    private IContainer components { get; set; }

    public frmKolicina()
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
        this.kolicina.Focus();
        this.kolicina.SelectAll();
    }
    

    private void InitializeComponent()
    {
        this.Button1 = new Button();
        this.kolicina = new UltraNumericEditor();
        this.Label1 = new Label();
        ((ISupportInitialize) this.kolicina).BeginInit();
        this.SuspendLayout();
        this.Button1.Location = new System.Drawing.Point(0x109, 0x2c);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
        this.Button1.TabIndex = 2;
        this.Button1.Text = "Potvrdi";
        this.Button1.UseVisualStyleBackColor = true;
        this.kolicina.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
        this.kolicina.Location = new System.Drawing.Point(0x62, 0x11);
        this.kolicina.Name = "kolicina";
        this.kolicina.PromptChar = ' ';
        this.kolicina.Size = new System.Drawing.Size(100, 0x15);
        this.kolicina.TabIndex = 1;
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label1.Location = new System.Drawing.Point(0x17, 0x15);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(0x38, 13);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Količina:";
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(0x160, 0x4f);
        this.ControlBox = false;
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.kolicina);
        this.Controls.Add(this.Button1);
        this.Name = "frmKolicina";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Molimo unesite količinu i enter za kraj ili ESC za prekid";


        this.kolicina.ValueChanged += new EventHandler(this.kolicina_ValueChanged);
        this.kolicina.ValidationError += new UltraNumericEditorBase.ValidationErrorEventHandler(this.kolicina_ValidationError);

        this.Button1.Click += new EventHandler(this.Button1_Click);


        ((ISupportInitialize) this.kolicina).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void kolicina_ValidationError(object sender, ValidationErrorEventArgs e)
    {
        e.Beep = true;
        Interaction.MsgBox("Količina nemože biti veća od " + Conversions.ToString(this.kolicina.MaxValue), MsgBoxStyle.OkOnly, null);
    }

    private void kolicina_ValueChanged(object sender, EventArgs e)
    {
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
                this.kolicina.Value = 0;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    public void Zatvori()
    {
        if (Operators.ConditionalCompareObjectGreater(this.kolicina.Value, this.kolicina.MaxValue, false))
        {
            Interaction.MsgBox("Količina ne može biti veća od " + Conversions.ToString(this.kolicina.MaxValue), MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    private Button Button1;

    public UltraNumericEditor kolicina;

    private Label Label1;
}

