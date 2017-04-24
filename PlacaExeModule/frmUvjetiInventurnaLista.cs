using Hlp;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmUvjetiInventurnaLista : Form
{
    private IContainer components { get; set; }

    public frmUvjetiInventurnaLista()
    {
        base.Load += new EventHandler(this.frmUvjetiBilanca_Load);
        this.InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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

    private void frmUvjetiBilanca_Load(object sender, EventArgs e)
    {
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUvjetiInventurnaLista));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBezLokacija = new System.Windows.Forms.RadioButton();
            this.rbLokacija = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSortNaziv = new System.Windows.Forms.RadioButton();
            this.rbSortInv = new System.Windows.Forms.RadioButton();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbBezLokacija);
            this.GroupBox1.Controls.Add(this.rbLokacija);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(329, 72);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Grupiranje";
            // 
            // rbBezLokacija
            // 
            this.rbBezLokacija.AutoSize = true;
            this.rbBezLokacija.Location = new System.Drawing.Point(6, 42);
            this.rbBezLokacija.Name = "rbBezLokacija";
            this.rbBezLokacija.Size = new System.Drawing.Size(92, 17);
            this.rbBezLokacija.TabIndex = 4;
            this.rbBezLokacija.Text = "Bez grupiranja";
            this.rbBezLokacija.UseVisualStyleBackColor = true;
            // 
            // rbLokacija
            // 
            this.rbLokacija.AutoSize = true;
            this.rbLokacija.Checked = true;
            this.rbLokacija.Location = new System.Drawing.Point(6, 19);
            this.rbLokacija.Name = "rbLokacija";
            this.rbLokacija.Size = new System.Drawing.Size(91, 17);
            this.rbLokacija.TabIndex = 3;
            this.rbLokacija.TabStop = true;
            this.rbLokacija.Text = "Po lokacijama";
            this.rbLokacija.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.rbSortNaziv);
            this.GroupBox2.Controls.Add(this.rbSortInv);
            this.GroupBox2.Location = new System.Drawing.Point(12, 90);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(329, 72);
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Redoslijed ispisa";
            // 
            // rbSortNaziv
            // 
            this.rbSortNaziv.AutoSize = true;
            this.rbSortNaziv.Location = new System.Drawing.Point(6, 42);
            this.rbSortNaziv.Name = "rbSortNaziv";
            this.rbSortNaziv.Size = new System.Drawing.Size(115, 17);
            this.rbSortNaziv.TabIndex = 7;
            this.rbSortNaziv.Text = "Po nazivu sredstva";
            this.rbSortNaziv.UseVisualStyleBackColor = true;
            // 
            // rbSortInv
            // 
            this.rbSortInv.AutoSize = true;
            this.rbSortInv.Checked = true;
            this.rbSortInv.Location = new System.Drawing.Point(6, 19);
            this.rbSortInv.Name = "rbSortInv";
            this.rbSortInv.Size = new System.Drawing.Size(125, 17);
            this.rbSortInv.TabIndex = 6;
            this.rbSortInv.TabStop = true;
            this.rbSortInv.Text = "Po inventarnom broju";
            this.rbSortInv.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(189, 228);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 10;
            this.Button1.Text = "Potvrdi";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(271, 228);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 11;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.CheckBox1);
            this.GroupBox3.Location = new System.Drawing.Point(12, 171);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(329, 51);
            this.GroupBox3.TabIndex = 12;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Knjigovodstvene količine";
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(17, 20);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(177, 17);
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.Text = "Prikaži knjigovodstvene količine";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // frmUvjetiInventurnaLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 260);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUvjetiInventurnaLista";
            this.Text = "Parametri ispisa bilance stanja OS / SI";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

    }

    public bool ___sAkOLICINAMA
    {
        get
        {
            return this.CheckBox1.Checked;
        }
    }

    public object __Sort
    {
        get
        {
            return RuntimeHelpers.GetObjectValue(Interaction.IIf(this.rbSortInv.Checked, "0", "1"));
        }
    }

    public object __Vrsta
    {
        get
        {
            return RuntimeHelpers.GetObjectValue(Interaction.IIf(this.rbLokacija.Checked, 1, 2));
        }
    }

    private Button Button1;

    private Button Button2;

    private CheckBox CheckBox1;

    private GroupBox GroupBox1;

    private GroupBox GroupBox2;

    private GroupBox GroupBox3;

    private RadioButton rbBezLokacija;

    private RadioButton rbLokacija;

    private RadioButton rbSortInv;

    private RadioButton rbSortNaziv;
}

