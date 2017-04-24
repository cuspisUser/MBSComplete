using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmOdabirPostojece : Form
{
    private IContainer components { get; set; }

    public frmOdabirPostojece()
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
        S_OS_BROJ_I_DATUMDataAdapter adapter = new S_OS_BROJ_I_DATUMDataAdapter();
        S_OS_BROJ_I_DATUMDataSet dataSet = new S_OS_BROJ_I_DATUMDataSet();
        adapter.Fill(dataSet);
        this.BROJTEMELJNICE.MaxValue = Operators.SubtractObject(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["BROJDOK"], 1);
        this.BROJTEMELJNICE.Value = Operators.SubtractObject(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["BROJDOK"], 1);
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
    }

    private void InitializeComponent()
    {
        this.Button1 = new Button();
        this.BROJTEMELJNICE = new UltraNumericEditor();
        this.Label1 = new Label();
        ((ISupportInitialize) this.BROJTEMELJNICE).BeginInit();
        this.SuspendLayout();
        this.Button1.Location = new System.Drawing.Point(0x109, 0x2c);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
        this.Button1.TabIndex = 2;
        this.Button1.Text = "Potvrdi";
        this.Button1.UseVisualStyleBackColor = true;
        this.Button1.Click += new EventHandler(Button1_Click);
        this.BROJTEMELJNICE.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
        this.BROJTEMELJNICE.Location = new System.Drawing.Point(0x8d, 0x11);
        this.BROJTEMELJNICE.Name = "BROJTEMELJNICE";
        this.BROJTEMELJNICE.PromptChar = ' ';
        this.BROJTEMELJNICE.Size = new System.Drawing.Size(100, 0x15);
        this.BROJTEMELJNICE.TabIndex = 1;
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label1.Location = new System.Drawing.Point(0x5d, 0x15);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(0x1d, 13);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Broj";
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(0x160, 0x4f);
        this.ControlBox = false;
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.BROJTEMELJNICE);
        this.Controls.Add(this.Button1);
        this.Name = "frmOdabirPostojece";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Unesite broj postojeće temeljnice";
        ((ISupportInitialize) this.BROJTEMELJNICE).EndInit();
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
                this.BROJTEMELJNICE.Value = 0;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    public void Zatvori()
    {
        if (Operators.ConditionalCompareObjectGreater(this.BROJTEMELJNICE.Value, this.BROJTEMELJNICE.MaxValue, false))
        {
            Interaction.MsgBox("Broj temeljnice nemože biti veći od  " + Conversions.ToString(this.BROJTEMELJNICE.MaxValue), MsgBoxStyle.OkOnly, null);
        }
        else
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    public decimal __Kolicina
    {
        get
        {
            return Conversions.ToDecimal(this.BROJTEMELJNICE.Value);
        }
        set
        {
            this.__Kolicina = value;
        }
    }

    private UltraNumericEditor BROJTEMELJNICE;

    private Button Button1;

    private Label Label1;
}

