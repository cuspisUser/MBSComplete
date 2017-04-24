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

public class FrmBrojIDatum : Form
{
    private IContainer components { get; set; }

    public FrmBrojIDatum()
    {
        base.Load += new EventHandler(this.frmIdentifikator_Load);
        this.InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.Zatvori();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.BROJTEMELJNICE.MinValue = 0;
        this.BROJTEMELJNICE.Value = 0;
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
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
        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["BROJDOK"])))
        {
            this.BROJTEMELJNICE.MinValue = 1;
            this.BROJTEMELJNICE.Value = 1;
        }
        else
        {
            this.BROJTEMELJNICE.Value = RuntimeHelpers.GetObjectValue(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["BROJDOK"]);
        }
        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["ZADNJIDATUM"])))
        {
            this.DATUMTEMELJNICE.MinDate = DateTime.Now;
            this.DATUMTEMELJNICE.Value = DateTime.Now;
        }
        else
        {
            this.DATUMTEMELJNICE.MinDate = Conversions.ToDate(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["ZADNJIDATUM"]);
            this.DATUMTEMELJNICE.Value = Conversions.ToDate(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["ZADNJIDATUM"]);
        }
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
        this.Button1 = new Button();
        this.BROJTEMELJNICE = new UltraNumericEditor();
        this.Label1 = new Label();
        this.DATUMTEMELJNICE = new DateTimePicker();
        this.Label2 = new Label();
        this.Button2 = new Button();
        ((ISupportInitialize) this.BROJTEMELJNICE).BeginInit();
        this.SuspendLayout();
        this.Button1.Location = new System.Drawing.Point(0xd4, 0x2c);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
        this.Button1.TabIndex = 2;
        this.Button1.Text = "Potvrdi";
        this.Button1.UseVisualStyleBackColor = true;
        this.BROJTEMELJNICE.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
        this.BROJTEMELJNICE.Location = new System.Drawing.Point(0x55, 12);
        this.BROJTEMELJNICE.Name = "BROJTEMELJNICE";
        this.BROJTEMELJNICE.PromptChar = ' ';
        this.BROJTEMELJNICE.Size = new System.Drawing.Size(100, 0x15);
        this.BROJTEMELJNICE.TabIndex = 1;
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label1.Location = new System.Drawing.Point(12, 0x11);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(0x1d, 13);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Broj";
        this.DATUMTEMELJNICE.Format = DateTimePickerFormat.Short;
        this.DATUMTEMELJNICE.Location = new System.Drawing.Point(0x55, 0x2c);
        this.DATUMTEMELJNICE.Name = "DATUMTEMELJNICE";
        this.DATUMTEMELJNICE.Size = new System.Drawing.Size(100, 20);
        this.DATUMTEMELJNICE.TabIndex = 4;
        this.Label2.AutoSize = true;
        this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label2.Location = new System.Drawing.Point(12, 0x31);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(0x2b, 13);
        this.Label2.TabIndex = 5;
        this.Label2.Text = "Datum";
        this.Button2.Location = new System.Drawing.Point(0x127, 0x2b);
        this.Button2.Name = "Button2";
        this.Button2.Size = new System.Drawing.Size(0x4b, 0x17);
        this.Button2.TabIndex = 6;
        this.Button2.Text = "Odustani";
        this.Button2.UseVisualStyleBackColor = true;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(0x184, 0x4f);
        this.ControlBox = false;
        this.Controls.Add(this.Button2);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.DATUMTEMELJNICE);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.BROJTEMELJNICE);
        this.Controls.Add(this.Button1);
        this.Name = "FrmBrojIDatum";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Unesite broj i datum temeljnice (ESC za izlaz)";


        this.Button2.Click += new EventHandler(this.Button2_Click);
        this.Button1.Click += new EventHandler(this.Button1_Click);


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

    public UltraNumericEditor BROJTEMELJNICE;

    private Button Button1;

    private Button Button2;

    public DateTimePicker DATUMTEMELJNICE;

    private Label Label1;

    private Label Label2;
}

