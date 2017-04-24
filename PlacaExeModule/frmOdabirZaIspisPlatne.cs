using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmOdabirZaIspisPlatne : Form
{
    private IContainer components { get; set; }

    public frmOdabirZaIspisPlatne()
    {
        base.Load += new EventHandler(this.frmOdabirZaIspisPlatne_Load);
        this.InitializeComponent();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
    }

    private void Cancel_Button_Click_1(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    private void frmOdabirZaIspisPlatne_Load(object sender, EventArgs e)
    {
        GODINA_I_MJESEC_OBRACUNADataAdapter adapter = new GODINA_I_MJESEC_OBRACUNADataAdapter();
        GODINA_I_MJESEC_OBRACUNADataSet dataSet = new GODINA_I_MJESEC_OBRACUNADataSet();
        adapter.Fill(dataSet);

        this.UltraCombo1.DataSource = dataSet;
        this.UltraCombo2.DataSource = dataSet;
        this.UltraCombo1.DataMember = "GODINA_I_MJESEC_OBRACUNA";
        this.UltraCombo2.DataMember = "GODINA_I_MJESEC_OBRACUNA";

        if (this.UltraCombo1.Rows.Count > 0)
            this.UltraCombo1.SelectedRow = this.UltraCombo1.Rows[0];

        if (this.UltraCombo2.Rows.Count > 0)
            this.UltraCombo2.SelectedRow = this.UltraCombo2.Rows[0];

        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        this.UltraCombo1.ValueMember = "godinaimjesecobracuna";
        this.UltraCombo2.ValueMember = "godinaimjesecobracuna";
    }

    private void InitializeComponent()
    {
        this.UltraLabel2 = new UltraLabel();
        this.UltraLabel1 = new UltraLabel();
        this.UltraCombo2 = new UltraCombo();
        this.UltraCombo1 = new UltraCombo();
        this.TableLayoutPanel1 = new TableLayoutPanel();
        this.OK_Button = new Button();
        this.Cancel_Button = new Button();
        ((ISupportInitialize) this.UltraCombo2).BeginInit();
        ((ISupportInitialize) this.UltraCombo1).BeginInit();
        this.TableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        this.UltraLabel2.Location = new System.Drawing.Point(12, 50);
        this.UltraLabel2.Name = "UltraLabel2";
        this.UltraLabel2.Size = new System.Drawing.Size(0xb8, 0x17);
        this.UltraLabel2.TabIndex = 14;
        this.UltraLabel2.Text = "Do godine i mjeseca obračuna";
        this.UltraLabel1.Location = new System.Drawing.Point(12, 0x16);
        this.UltraLabel1.Name = "UltraLabel1";
        this.UltraLabel1.Size = new System.Drawing.Size(0xb8, 0x17);
        this.UltraLabel1.TabIndex = 13;
        this.UltraLabel1.Text = "Od godine i mjeseca obračuna";
        this.UltraCombo2.CharacterCasing = CharacterCasing.Normal;
        this.UltraCombo2.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
        this.UltraCombo2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
        this.UltraCombo2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
        this.UltraCombo2.Location = new System.Drawing.Point(0xd5, 0x2e);
        this.UltraCombo2.Name = "UltraCombo2";
        this.UltraCombo2.Size = new System.Drawing.Size(200, 0x16);
        this.UltraCombo2.TabIndex = 12;
        this.UltraCombo2.Text = "UltraCombo2";
        this.UltraCombo1.CharacterCasing = CharacterCasing.Normal;
        this.UltraCombo1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
        this.UltraCombo1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
        this.UltraCombo1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
        this.UltraCombo1.LimitToList = true;
        this.UltraCombo1.Location = new System.Drawing.Point(0xd5, 0x12);
        this.UltraCombo1.Name = "UltraCombo1";
        this.UltraCombo1.Size = new System.Drawing.Size(200, 0x16);
        this.UltraCombo1.TabIndex = 11;
        this.UltraCombo1.Text = "UltraCombo1";
        this.TableLayoutPanel1.Anchor = AnchorStyles.None;
        this.TableLayoutPanel1.ColumnCount = 2;
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 50f));
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 50f));
        this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
        this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
        this.TableLayoutPanel1.Location = new System.Drawing.Point(0x10b, 0x4f);
        this.TableLayoutPanel1.Name = "TableLayoutPanel1";
        this.TableLayoutPanel1.RowCount = 1;
        this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
        this.TableLayoutPanel1.Size = new System.Drawing.Size(0x92, 0x1d);
        this.TableLayoutPanel1.TabIndex = 15;
        this.OK_Button.Anchor = AnchorStyles.None;
        this.OK_Button.Location = new System.Drawing.Point(3, 3);
        this.OK_Button.Name = "OK_Button";
        this.OK_Button.Size = new System.Drawing.Size(0x43, 0x17);
        this.OK_Button.TabIndex = 0;
        this.OK_Button.Text = "OK";
        this.Cancel_Button.Anchor = AnchorStyles.None;
        this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Cancel_Button.Location = new System.Drawing.Point(0x4c, 3);
        this.Cancel_Button.Name = "Cancel_Button";
        this.Cancel_Button.Size = new System.Drawing.Size(0x43, 0x17);
        this.Cancel_Button.TabIndex = 1;
        this.Cancel_Button.Text = "Odustani";
        SizeF ef = new System.Drawing.SizeF(6f, 13f);
        this.AutoScaleDimensions = ef;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(0x1ab, 120);
        this.Controls.Add(this.TableLayoutPanel1);
        this.Controls.Add(this.UltraLabel2);
        this.Controls.Add(this.UltraLabel1);
        this.Controls.Add(this.UltraCombo2);
        this.Controls.Add(this.UltraCombo1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmOdabirZaIspisPlatne";
        this.ShowInTaskbar = false;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Odaberite razdoblje";


        this.OK_Button.Click += new EventHandler(this.OK_Button_Click_1);
        this.Cancel_Button.Click += new EventHandler(this.Cancel_Button_Click_1);


        ((ISupportInitialize) this.UltraCombo2).EndInit();
        ((ISupportInitialize) this.UltraCombo1).EndInit();
        this.TableLayoutPanel1.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
    }

    private void OK_Button_Click_1(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    public string __DOGODINAMJESEC
    {
        get
        {
            return Conversions.ToString(this.UltraCombo2.Value);
        }
    }

    public string __ODGODINAMJESEC
    {
        get
        {
            return Conversions.ToString(this.UltraCombo1.Value);
        }
    }

    private Button Cancel_Button;

    private Button OK_Button;

    private TableLayoutPanel TableLayoutPanel1;

    private UltraCombo UltraCombo1;

    private UltraCombo UltraCombo2;

    private UltraLabel UltraLabel1;

    private UltraLabel UltraLabel2;
}

