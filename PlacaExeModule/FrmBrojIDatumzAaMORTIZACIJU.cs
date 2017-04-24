using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class FrmBrojIDatumzAaMORTIZACIJU : Form
{
    private IContainer components { get; set; }

    public FrmBrojIDatumzAaMORTIZACIJU()
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
        SqlCommand command = new SqlCommand();
        SqlConnection connection = new SqlConnection();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT MAX(OSDATUMDOK) FROM OSTEMELJNICA WHERE IDOSDOKUMENT = 2 and osbrojdokumenta > 0";
        connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
        command.Connection = connection;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
            reader.Read();

            DateTime dateTime = reader.GetDateTime(0);
            this.ODDATUMA.Value = dateTime.AddDays(1.0);
            this.DODATUMA.Value = dateTime.AddYears(1);
        }
        catch (System.Exception)
        {            
            this.ODDATUMA.Value = DateAndTime.DateSerial(DateTime.Now.Year, 1, 1);
            this.DODATUMA.Value = DateAndTime.DateSerial(DateTime.Now.Year, 12, 31);
        }

        connection.Close();
        this.BROJTEMELJNICE.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["BROJDOK"])), 1, RuntimeHelpers.GetObjectValue(dataSet.S_OS_BROJ_I_DATUM.Rows[0]["BROJDOK"])));
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
    }

    private void InitializeComponent()
    {
        Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
        this.Button1 = new Button();
        this.BROJTEMELJNICE = new UltraNumericEditor();
        this.Label1 = new Label();
        this.Label2 = new Label();
        this.Label3 = new Label();
        this.ODDATUMA = new UltraDateTimeEditor();
        this.DODATUMA = new UltraDateTimeEditor();
        ((ISupportInitialize) this.BROJTEMELJNICE).BeginInit();
        ((ISupportInitialize) this.ODDATUMA).BeginInit();
        ((ISupportInitialize) this.DODATUMA).BeginInit();
        this.SuspendLayout();
        this.Button1.Location = new System.Drawing.Point(0x127, 0x3d);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
        this.Button1.TabIndex = 2;
        this.Button1.Text = "Potvrdi";
        this.Button1.UseVisualStyleBackColor = true;
        this.BROJTEMELJNICE.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
        this.BROJTEMELJNICE.Location = new System.Drawing.Point(0x3d, 0x26);
        this.BROJTEMELJNICE.Name = "BROJTEMELJNICE";
        this.BROJTEMELJNICE.PromptChar = ' ';
        this.BROJTEMELJNICE.Size = new System.Drawing.Size(100, 0x15);
        this.BROJTEMELJNICE.TabIndex = 1;
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label1.Location = new System.Drawing.Point(12, 0x2c);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(0x1d, 13);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Broj";
        this.Label2.AutoSize = true;
        this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label2.Location = new System.Drawing.Point(12, 0x11);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(0x2b, 13);
        this.Label2.TabIndex = 5;
        this.Label2.Text = "Datum";
        this.Label3.AutoSize = true;
        this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
        this.Label3.Location = new System.Drawing.Point(0xbf, 15);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(0x2b, 13);
        this.Label3.TabIndex = 7;
        this.Label3.Text = "Datum";
        appearance.BackColor = Color.Lavender;
        appearance.FontData.BoldAsString = "True";
        appearance.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ODDATUMA.Appearance = appearance;
        this.ODDATUMA.BackColor = Color.Lavender;
        this.ODDATUMA.DisplayStyle = EmbeddableElementDisplayStyle.WindowsVista;
        this.ODDATUMA.Location = new System.Drawing.Point(0x3d, 13);
        this.ODDATUMA.Name = "ODDATUMA";
        this.ODDATUMA.Size = new System.Drawing.Size(0x5c, 0x15);
        this.ODDATUMA.TabIndex = 0x68;
        this.ODDATUMA.UseAppStyling = false;
        appearance2.BackColor = Color.Lavender;
        appearance2.FontData.BoldAsString = "True";
        appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.DODATUMA.Appearance = appearance2;
        this.DODATUMA.BackColor = Color.Lavender;
        this.DODATUMA.DisplayStyle = EmbeddableElementDisplayStyle.WindowsVista;
        this.DODATUMA.Location = new System.Drawing.Point(0xf8, 11);
        this.DODATUMA.Name = "DODATUMA";
        this.DODATUMA.Size = new System.Drawing.Size(0x5c, 0x15);
        this.DODATUMA.TabIndex = 0x69;
        this.DODATUMA.UseAppStyling = false;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(0x19d, 100);
        this.ControlBox = false;
        this.Controls.Add(this.DODATUMA);
        this.Controls.Add(this.ODDATUMA);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.BROJTEMELJNICE);
        this.Controls.Add(this.Button1);
        this.Name = "FrmBrojIDatumzAaMORTIZACIJU";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Unesite broj i razdoblje za obračun amortizacije (ESC za izlaz)";


        this.Button1.Click += new EventHandler(this.Button1_Click);


        ((ISupportInitialize) this.BROJTEMELJNICE).EndInit();
        ((ISupportInitialize) this.ODDATUMA).EndInit();
        ((ISupportInitialize) this.DODATUMA).EndInit();
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
        if (!Operators.ConditionalCompareObjectGreater(this.BROJTEMELJNICE.Value, this.BROJTEMELJNICE.MaxValue, false))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    public int ___broj
    {
        get
        {
            return Conversions.ToInteger(this.BROJTEMELJNICE.Value);
        }
        set
        {
            this.___broj = value;
        }
    }

    public DateTime __DODATUMA
    {
        get
        {
            return Conversions.ToDate(this.DODATUMA.Value);
        }
        set
        {
            this.__DODATUMA = value;
        }
    }

    public DateTime __ODDATUMA
    {
        get
        {
            return Conversions.ToDate(this.ODDATUMA.Value);
        }
        set
        {
            this.__ODDATUMA = value;
        }
    }

    private UltraNumericEditor BROJTEMELJNICE;

    private Button Button1;

    private UltraDateTimeEditor DODATUMA;

    private Label Label1;

    private Label Label2;

    private Label Label3;

    private UltraDateTimeEditor ODDATUMA;
}

