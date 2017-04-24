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

public class frmUvjetiBilanca : Form
{
    private IContainer components { get; set; }

    [DebuggerNonUserCode]
    public frmUvjetiBilanca()
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
        this.datumtemeljnice.Value = DateTime.Now;
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
    }

    private void InitializeComponent()
    {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUvjetiBilanca));
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSI = new System.Windows.Forms.RadioButton();
            this.rbOS = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSortNaziv = new System.Windows.Forms.RadioButton();
            this.rbSortInv = new System.Windows.Forms.RadioButton();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.datumtemeljnice = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datumtemeljnice)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label2.Location = new System.Drawing.Point(26, 27);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(137, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Stanje OS / SI na dan:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbSI);
            this.GroupBox1.Controls.Add(this.rbOS);
            this.GroupBox1.Location = new System.Drawing.Point(29, 61);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(329, 72);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Vrsta (OS ili SI)";
            // 
            // rbSI
            // 
            this.rbSI.AutoSize = true;
            this.rbSI.Location = new System.Drawing.Point(6, 42);
            this.rbSI.Name = "rbSI";
            this.rbSI.Size = new System.Drawing.Size(90, 17);
            this.rbSI.TabIndex = 4;
            this.rbSI.Text = "Sitan inventar";
            this.rbSI.UseVisualStyleBackColor = true;
            // 
            // rbOS
            // 
            this.rbOS.AutoSize = true;
            this.rbOS.Checked = true;
            this.rbOS.Location = new System.Drawing.Point(6, 19);
            this.rbOS.Name = "rbOS";
            this.rbOS.Size = new System.Drawing.Size(111, 17);
            this.rbOS.TabIndex = 3;
            this.rbOS.TabStop = true;
            this.rbOS.Text = "Osnovna sredstva";
            this.rbOS.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.rbSortNaziv);
            this.GroupBox2.Controls.Add(this.rbSortInv);
            this.GroupBox2.Location = new System.Drawing.Point(29, 139);
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
            this.Button1.Location = new System.Drawing.Point(206, 277);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 10;
            this.Button1.Text = "Potvrdi";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(288, 277);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 11;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // datumtemeljnice
            // 
            appearance.BackColor = System.Drawing.Color.Lavender;
            appearance.FontData.BoldAsString = "True";
            appearance.ForeColor = System.Drawing.Color.Black;
            this.datumtemeljnice.Appearance = appearance;
            this.datumtemeljnice.BackColor = System.Drawing.Color.Lavender;
            this.datumtemeljnice.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.datumtemeljnice.Location = new System.Drawing.Point(178, 23);
            this.datumtemeljnice.Name = "datumtemeljnice";
            this.datumtemeljnice.Size = new System.Drawing.Size(103, 21);
            this.datumtemeljnice.TabIndex = 1;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.CheckBox1);
            this.GroupBox3.Location = new System.Drawing.Point(29, 220);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(329, 51);
            this.GroupBox3.TabIndex = 12;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Ispis po nosiocu/lokaciji";
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(17, 20);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(116, 17);
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.Text = "Bilanca po nosiocu";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // frmUvjetiBilanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 321);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.datumtemeljnice);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUvjetiBilanca";
            this.Text = "Parametri ispisa bilance stanja OS / SI";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datumtemeljnice)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    public bool ___PoNosiocu
    {
        get
        {
            return this.CheckBox1.Checked;
        }
    }

    public DateTime __nadan
    {
        get
        {
            return Conversions.ToDate(this.datumtemeljnice.Value);
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
            return RuntimeHelpers.GetObjectValue(Interaction.IIf(this.rbOS.Checked, 1, 2));
        }
    }

    private Button Button1;

    private Button Button2;

    private CheckBox CheckBox1;

    private UltraDateTimeEditor datumtemeljnice;

    private GroupBox GroupBox1;

    private GroupBox GroupBox2;

    private GroupBox GroupBox3;

    private Label Label2;

    private RadioButton rbOS;

    private RadioButton rbSI;

    private RadioButton rbSortInv;

    private RadioButton rbSortNaziv;
}

