using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class frmUnosPodatakaOObracunu : Form
{
    private IContainer components { get; set; }
    private PodaciObracun m_podaci;

    //db - 27.12.2016
    public bool admin_kontrola = false;
    private bool bPromjeneMoguce;
    private UltraLabel ultraLabel11;
    bool _load;

    public frmUnosPodatakaOObracunu()
    {
        base.Load += new EventHandler(this.frmUnosPodatakaOObracunu_Load);
        this.InitializeComponent();
    }

    private void AzurirajDatumObracunaStaza(object sender, EventArgs e)
    {
        bool flag = false;
        if (Operators.ConditionalCompareObjectEqual(this.datumobracunastaza.Value, DateAndTime.DateSerial(0x7d0, 1, 1), false))
        {
            flag = true;
        }
        if (((decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.godinaobracuna.Value)), decimal.Zero) > 0) & (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.mjesecobracuna.Value)), decimal.Zero) > 0)) && ((DateTime.Compare(DateTime.Parse(Conversions.ToString(this.datumobracunastaza.Value)), DateAndTime.DateSerial(Conversions.ToInteger(this.godinaobracuna.Value), Conversions.ToInteger(this.mjesecobracuna.Value), DateTime.DaysInMonth(Conversions.ToInteger(this.godinaobracuna.Value), 1))) < 0) | (DateTime.Compare(DateTime.Parse(Conversions.ToString(this.datumobracunastaza.Value)), DateAndTime.DateSerial(Conversions.ToInteger(this.godinaobracuna.Value), Conversions.ToInteger(this.mjesecobracuna.Value), DateTime.DaysInMonth(Conversions.ToInteger(this.godinaobracuna.Value), Conversions.ToInteger(this.mjesecobracuna.Value)))) > 0)))
        {
            flag = true;
        }
        if (flag)
        {
            try
            {
                this.datumobracunastaza.Value = DateAndTime.DateSerial(Conversions.ToInteger(this.godinaobracuna.Value), Conversions.ToInteger(this.mjesecobracuna.Value), 1);
                this.datumobracunastaza.Value = DateAndTime.DateAdd(DateInterval.Day, -1.0, Conversions.ToDate(this.datumobracunastaza.Value));
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
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

    private void frmUnosPodatakaOObracunu_Load(object sender, EventArgs e)
    {
        //_load = true;--> OVO IDE TEK SA 1.1.2017
        this.Podaci_o_zadnjem_Obracunu();
        this.datumobracunastaza.Value = DateAndTime.DateSerial(0x7d0, 1, 1);
        this.AzurirajDatumObracunaStaza(null, null);
        //_load = false;--> OVO IDE TEK SA 1.1.2017
    }

    private void godinaobracuna_ValueChanged(object sender, EventArgs e)
    {
        this.AzurirajDatumObracunaStaza(null, null);
    }

    private void InitializeComponent()
    {
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnosPodatakaOObracunu));
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.mjesecisplate = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.godinaisplate = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.godinaobracuna = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.mjesecobracuna = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtOpisObracuna = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tjednifond = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.datumobracunastaza = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.osnovnioo = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.obrosnovica = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.mjesecnifond = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpisObracuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tjednifond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumobracunastaza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovnioo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obrosnovica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mjesecnifond)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.ultraLabel11);
            this.UltraGroupBox1.Controls.Add(this.UltraButton3);
            this.UltraGroupBox1.Controls.Add(this.UltraButton4);
            this.UltraGroupBox1.Controls.Add(this.mjesecisplate);
            this.UltraGroupBox1.Controls.Add(this.godinaisplate);
            this.UltraGroupBox1.Controls.Add(this.godinaobracuna);
            this.UltraGroupBox1.Controls.Add(this.mjesecobracuna);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel10);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel8);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel4);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel9);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel7);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel6);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.txtOpisObracuna);
            this.UltraGroupBox1.Controls.Add(this.tjednifond);
            this.UltraGroupBox1.Controls.Add(this.datumobracunastaza);
            this.UltraGroupBox1.Controls.Add(this.osnovnioo);
            this.UltraGroupBox1.Controls.Add(this.obrosnovica);
            this.UltraGroupBox1.Controls.Add(this.mjesecnifond);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(450, 234);
            this.UltraGroupBox1.TabIndex = 83;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraButton3
            // 
            this.UltraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton3.Location = new System.Drawing.Point(302, 200);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(128, 23);
            this.UltraButton3.TabIndex = 179;
            this.UltraButton3.Text = "Odustani";
            this.UltraButton3.UseAppStyling = false;
            this.UltraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton3.Click += new System.EventHandler(this.UltraButton3_Click);
            // 
            // UltraButton4
            // 
            this.UltraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton4.Location = new System.Drawing.Point(169, 200);
            this.UltraButton4.Name = "UltraButton4";
            this.UltraButton4.Size = new System.Drawing.Size(123, 23);
            this.UltraButton4.TabIndex = 178;
            this.UltraButton4.Text = "Spremi";
            this.UltraButton4.UseAppStyling = false;
            this.UltraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton4.Click += new System.EventHandler(this.UltraButton4_Click);
            // 
            // mjesecisplate
            // 
            appearance13.BackColor = System.Drawing.Color.Lavender;
            appearance13.FontData.BoldAsString = "True";
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance13.TextHAlignAsString = "Right";
            this.mjesecisplate.Appearance = appearance13;
            this.mjesecisplate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.mjesecisplate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mjesecisplate.InputMask = "##";
            this.mjesecisplate.Location = new System.Drawing.Point(148, 35);
            this.mjesecisplate.MaxValue = "12";
            this.mjesecisplate.MinimumSize = new System.Drawing.Size(0, 1);
            this.mjesecisplate.MinValue = "01";
            this.mjesecisplate.Name = "mjesecisplate";
            this.mjesecisplate.Size = new System.Drawing.Size(48, 20);
            this.mjesecisplate.TabIndex = 95;
            this.mjesecisplate.UseAppStyling = false;
            // 
            // godinaisplate
            // 
            appearance14.BackColor = System.Drawing.Color.Lavender;
            appearance14.FontData.BoldAsString = "True";
            appearance14.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance14.TextHAlignAsString = "Right";
            this.godinaisplate.Appearance = appearance14;
            this.godinaisplate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.godinaisplate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.godinaisplate.InputMask = "####";
            this.godinaisplate.Location = new System.Drawing.Point(302, 35);
            this.godinaisplate.MaxValue = "2100";
            this.godinaisplate.MinimumSize = new System.Drawing.Size(0, 1);
            this.godinaisplate.MinValue = "1900";
            this.godinaisplate.Name = "godinaisplate";
            this.godinaisplate.Size = new System.Drawing.Size(48, 20);
            this.godinaisplate.TabIndex = 96;
            this.godinaisplate.UseAppStyling = false;
            // 
            // godinaobracuna
            // 
            appearance22.BackColor = System.Drawing.Color.Lavender;
            appearance22.FontData.BoldAsString = "True";
            appearance22.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance22.TextHAlignAsString = "Right";
            this.godinaobracuna.Appearance = appearance22;
            this.godinaobracuna.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.godinaobracuna.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.godinaobracuna.InputMask = "####";
            this.godinaobracuna.Location = new System.Drawing.Point(302, 9);
            this.godinaobracuna.MaxValue = "2100";
            this.godinaobracuna.MinimumSize = new System.Drawing.Size(0, 1);
            this.godinaobracuna.MinValue = "1900";
            this.godinaobracuna.Name = "godinaobracuna";
            this.godinaobracuna.Size = new System.Drawing.Size(48, 20);
            this.godinaobracuna.TabIndex = 94;
            this.godinaobracuna.UseAppStyling = false;
            this.godinaobracuna.ValueChanged += new System.EventHandler(this.godinaobracuna_ValueChanged);
            // 
            // mjesecobracuna
            // 
            appearance17.BackColor = System.Drawing.Color.Lavender;
            appearance17.FontData.BoldAsString = "True";
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance17.TextHAlignAsString = "Right";
            this.mjesecobracuna.Appearance = appearance17;
            this.mjesecobracuna.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.mjesecobracuna.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mjesecobracuna.InputMask = "##";
            this.mjesecobracuna.Location = new System.Drawing.Point(148, 9);
            this.mjesecobracuna.MaxValue = "12";
            this.mjesecobracuna.MinimumSize = new System.Drawing.Size(0, 1);
            this.mjesecobracuna.MinValue = "01";
            this.mjesecobracuna.Name = "mjesecobracuna";
            this.mjesecobracuna.Size = new System.Drawing.Size(48, 20);
            this.mjesecobracuna.TabIndex = 93;
            this.mjesecobracuna.UseAppStyling = false;
            this.mjesecobracuna.ValueChanged += new System.EventHandler(this.mjesecobracuna_ValueChanged);
            // 
            // UltraLabel10
            // 
            appearance20.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel10.Appearance = appearance20;
            this.UltraLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel10.Location = new System.Drawing.Point(23, 168);
            this.UltraLabel10.Name = "UltraLabel10";
            this.UltraLabel10.Size = new System.Drawing.Size(112, 14);
            this.UltraLabel10.TabIndex = 91;
            this.UltraLabel10.Text = "Opis obračuna";
            this.UltraLabel10.UseAppStyling = false;
            // 
            // UltraLabel8
            // 
            appearance.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel8.Appearance = appearance;
            this.UltraLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel8.Location = new System.Drawing.Point(209, 13);
            this.UltraLabel8.Name = "UltraLabel8";
            this.UltraLabel8.Size = new System.Drawing.Size(93, 14);
            this.UltraLabel8.TabIndex = 89;
            this.UltraLabel8.Text = "Godina obračuna";
            this.UltraLabel8.UseAppStyling = false;
            // 
            // UltraLabel5
            // 
            appearance23.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel5.Appearance = appearance23;
            this.UltraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel5.Location = new System.Drawing.Point(206, 65);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(94, 16);
            this.UltraLabel5.TabIndex = 86;
            this.UltraLabel5.Text = "Tjedni fond sati";
            this.UltraLabel5.UseAppStyling = false;
            // 
            // UltraLabel4
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel4.Appearance = appearance24;
            this.UltraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel4.Location = new System.Drawing.Point(208, 39);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(83, 14);
            this.UltraLabel4.TabIndex = 85;
            this.UltraLabel4.Text = "Godina isplate";
            this.UltraLabel4.UseAppStyling = false;
            // 
            // UltraLabel2
            // 
            appearance25.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel2.Appearance = appearance25;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(23, 117);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(117, 14);
            this.UltraLabel2.TabIndex = 83;
            this.UltraLabel2.Text = "Obračunska osnovica";
            this.UltraLabel2.UseAppStyling = false;
            // 
            // UltraLabel9
            // 
            appearance26.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel9.Appearance = appearance26;
            this.UltraLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel9.Location = new System.Drawing.Point(23, 142);
            this.UltraLabel9.Name = "UltraLabel9";
            this.UltraLabel9.Size = new System.Drawing.Size(122, 14);
            this.UltraLabel9.TabIndex = 90;
            this.UltraLabel9.Text = "Datum obračuna staža";
            this.UltraLabel9.UseAppStyling = false;
            // 
            // UltraLabel7
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            appearance27.TextHAlignAsString = "Left";
            this.UltraLabel7.Appearance = appearance27;
            this.UltraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel7.Location = new System.Drawing.Point(23, 12);
            this.UltraLabel7.Name = "UltraLabel7";
            this.UltraLabel7.Size = new System.Drawing.Size(96, 14);
            this.UltraLabel7.TabIndex = 88;
            this.UltraLabel7.Text = "Mjesec obračuna";
            this.UltraLabel7.UseAppStyling = false;
            // 
            // UltraLabel6
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.UltraLabel6.Appearance = appearance1;
            this.UltraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel6.Location = new System.Drawing.Point(23, 90);
            this.UltraLabel6.Name = "UltraLabel6";
            this.UltraLabel6.Size = new System.Drawing.Size(123, 16);
            this.UltraLabel6.TabIndex = 87;
            this.UltraLabel6.Text = "Osnovni osobni odbitak";
            this.UltraLabel6.UseAppStyling = false;
            // 
            // UltraLabel3
            // 
            appearance29.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel3.Appearance = appearance29;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(23, 37);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(87, 16);
            this.UltraLabel3.TabIndex = 84;
            this.UltraLabel3.Text = "Mjesec isplate";
            this.UltraLabel3.UseAppStyling = false;
            // 
            // UltraLabel1
            // 
            appearance30.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel1.Appearance = appearance30;
            this.UltraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel1.Location = new System.Drawing.Point(23, 64);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(96, 23);
            this.UltraLabel1.TabIndex = 82;
            this.UltraLabel1.Text = "Mjesečni fond sati";
            this.UltraLabel1.UseAppStyling = false;
            this.UltraLabel1.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtOpisObracuna
            // 
            appearance19.BackColor = System.Drawing.Color.Lavender;
            appearance19.FontData.BoldAsString = "True";
            appearance19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOpisObracuna.Appearance = appearance19;
            this.txtOpisObracuna.BackColor = System.Drawing.Color.Lavender;
            this.txtOpisObracuna.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.txtOpisObracuna.Location = new System.Drawing.Point(148, 164);
            this.txtOpisObracuna.Name = "txtOpisObracuna";
            this.txtOpisObracuna.Size = new System.Drawing.Size(285, 21);
            this.txtOpisObracuna.TabIndex = 105;
            this.txtOpisObracuna.UseAppStyling = false;
            // 
            // tjednifond
            // 
            appearance31.BackColor = System.Drawing.Color.Lavender;
            appearance31.FontData.BoldAsString = "True";
            appearance31.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance31.TextHAlignAsString = "Right";
            this.tjednifond.Appearance = appearance31;
            this.tjednifond.BackColor = System.Drawing.Color.Lavender;
            this.tjednifond.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.tjednifond.Location = new System.Drawing.Point(302, 60);
            this.tjednifond.MaskInput = "nn";
            this.tjednifond.Name = "tjednifond";
            this.tjednifond.Size = new System.Drawing.Size(48, 21);
            this.tjednifond.TabIndex = 98;
            this.tjednifond.UseAppStyling = false;
            // 
            // datumobracunastaza
            // 
            appearance18.BackColor = System.Drawing.Color.Lavender;
            appearance18.FontData.BoldAsString = "True";
            appearance18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.datumobracunastaza.Appearance = appearance18;
            this.datumobracunastaza.BackColor = System.Drawing.Color.Lavender;
            this.datumobracunastaza.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.datumobracunastaza.Location = new System.Drawing.Point(148, 137);
            this.datumobracunastaza.Name = "datumobracunastaza";
            this.datumobracunastaza.Size = new System.Drawing.Size(92, 21);
            this.datumobracunastaza.TabIndex = 103;
            this.datumobracunastaza.UseAppStyling = false;
            // 
            // osnovnioo
            // 
            appearance32.BackColor = System.Drawing.Color.Lavender;
            appearance32.FontData.BoldAsString = "True";
            appearance32.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance32.TextHAlignAsString = "Right";
            this.osnovnioo.Appearance = appearance32;
            this.osnovnioo.BackColor = System.Drawing.Color.Lavender;
            this.osnovnioo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.osnovnioo.Location = new System.Drawing.Point(285, 87);
            this.osnovnioo.MaskInput = "{LOC}nnnnnnnn.nn";
            this.osnovnioo.Name = "osnovnioo";
            this.osnovnioo.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.osnovnioo.PromptChar = ' ';
            this.osnovnioo.Size = new System.Drawing.Size(100, 21);
            this.osnovnioo.TabIndex = 99;
            this.osnovnioo.UseAppStyling = false;
            this.osnovnioo.Visible = false;
            this.osnovnioo.ValueChanged += new System.EventHandler(this.osnovnioo_ValueChanged);
            // 
            // obrosnovica
            // 
            appearance15.BackColor = System.Drawing.Color.Lavender;
            appearance15.FontData.BoldAsString = "True";
            appearance15.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance15.TextHAlignAsString = "Right";
            this.obrosnovica.Appearance = appearance15;
            this.obrosnovica.BackColor = System.Drawing.Color.Lavender;
            this.obrosnovica.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.obrosnovica.Location = new System.Drawing.Point(148, 113);
            this.obrosnovica.MaskInput = "{LOC}nnnnnnnnnn.nn";
            this.obrosnovica.Name = "obrosnovica";
            this.obrosnovica.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.obrosnovica.Size = new System.Drawing.Size(100, 21);
            this.obrosnovica.TabIndex = 102;
            this.obrosnovica.UseAppStyling = false;
            // 
            // mjesecnifond
            // 
            appearance16.BackColor = System.Drawing.Color.Lavender;
            appearance16.FontData.BoldAsString = "True";
            appearance16.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance16.TextHAlignAsString = "Right";
            this.mjesecnifond.Appearance = appearance16;
            this.mjesecnifond.BackColor = System.Drawing.Color.Lavender;
            this.mjesecnifond.Location = new System.Drawing.Point(148, 60);
            this.mjesecnifond.MaskInput = "nnn";
            this.mjesecnifond.Name = "mjesecnifond";
            this.mjesecnifond.Size = new System.Drawing.Size(48, 21);
            this.mjesecnifond.TabIndex = 97;
            this.mjesecnifond.UseAppStyling = false;
            // 
            // ultraLabel11
            // 
            appearance28.BackColor = System.Drawing.Color.Transparent;
            appearance28.TextHAlignAsString = "Left";
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance28;
            this.ultraLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel11.Location = new System.Drawing.Point(146, 90);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(123, 16);
            this.ultraLabel11.TabIndex = 180;
            this.ultraLabel11.Text = "3.800,00";
            this.ultraLabel11.UseAppStyling = false;
            // 
            // frmUnosPodatakaOObracunu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 232);
            this.Controls.Add(this.UltraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUnosPodatakaOObracunu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zadavanje podataka o obračunu";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpisObracuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tjednifond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datumobracunastaza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osnovnioo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obrosnovica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mjesecnifond)).EndInit();
            this.ResumeLayout(false);

    }

    private void Kontrola_Focus(object sender, EventArgs e)
    {
        NewLateBinding.LateCall(sender, null, "SelectAll", new object[0], null, null, null, true);
    }

    private void mjesecobracuna_ValueChanged(object sender, EventArgs e)
    {
        this.AzurirajDatumObracunaStaza(null, null);
    }

    public void Podaci_o_zadnjem_Obracunu()
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
        command.Connection = connection;
        command.CommandText = "select max(idobracun) from obracun";
        connection.Open();
        try
        {
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (!reader.IsDBNull(0))
            {
                OBRACUNDataAdapter adapter = new OBRACUNDataAdapter();
                OBRACUNDataSet dataSet = new OBRACUNDataSet();
                adapter.FillByIDOBRACUN(dataSet, reader.GetString(0));
                this.mjesecobracuna.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["mjesecobracuna"]);
                this.godinaobracuna.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["godinaobracuna"]);
                this.mjesecisplate.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["mjesecisplate"]);
                this.godinaisplate.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["godinaisplate"]);
                this.mjesecnifond.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["mjesecnifondsatiobracun"]);
                this.tjednifond.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["tjednifondsatiobracun"]);

                //22.12.2016. --> ovo se mijenja radi novog izračuna plaća
                //this.osnovnioo.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["osnovnioo"]);
                this.osnovnioo.Value = Convert.ToDecimal(3800); //--> OVO IDE TEK SA 1.1.2017
                this.osnovnioo.ReadOnly = true;

                this.obrosnovica.Value = RuntimeHelpers.GetObjectValue(dataSet.OBRACUN.Rows[0]["obracunskaosnovica"]);
                this.txtOpisObracuna.Value = "";
            }
            else
            {
                this.mjesecobracuna.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(DateAndTime.Today.Month == 1, 12, DateAndTime.Today.Month - 1));
                this.godinaobracuna.Value = RuntimeHelpers.GetObjectValue(Interaction.IIf(DateAndTime.Today.Month == 1, DateAndTime.Today.Year - 1, DateAndTime.Today.Year));
                this.mjesecisplate.Value = DateTime.Now.Month;
                this.godinaisplate.Value = DateTime.Now.Year;
                this.mjesecobracuna.Value = DB.BrojVodeceNule(this.mjesecobracuna, 2, 0, false, "");
                this.mjesecisplate.Value = DB.BrojVodeceNule(this.mjesecisplate, 2, 0, false, "");
                this.godinaobracuna.Value = DB.BrojVodeceNule(this.godinaobracuna, 4, 0, false, "");
                this.godinaisplate.Value = DB.BrojVodeceNule(this.godinaisplate, 4, 0, false, "");
                this.mjesecnifond.Value = 160;
                this.tjednifond.Value = 40;
                //this.osnovnioo.Value = 0x708;
                this.osnovnioo.Value = Convert.ToDecimal(3800); //--> Ovo je slučaj kad nema prethodnog obračuna
                this.osnovnioo.ReadOnly = true;
                this.obrosnovica.Value = 5108.84;
                this.txtOpisObracuna.Value = " ";
            }
        }
        catch (System.Exception exception1)
        {
            throw exception1;
        }
        connection.Close();
    }

    private void PripremiKontrole()
    {
        this.mjesecobracuna.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.godinaobracuna.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.mjesecisplate.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.godinaisplate.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.tjednifond.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.mjesecnifond.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.osnovnioo.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.obrosnovica.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.datumobracunastaza.GotFocus += new EventHandler(this.Kontrola_Focus);
        this.txtOpisObracuna.GotFocus += new EventHandler(this.Kontrola_Focus);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
        {
            bool flag = false;
            return flag;
        }
        if (keyData == Keys.Escape)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    public void Set_Parametri_Obracuna()
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
        command.Connection = connection;
        command.CommandText = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject("select max(idobracun) from obracun where idobracun like '", this.godinaisplate.Value), "-"), this.mjesecisplate.Value), "-%"), "'"));
        connection.Open();
        try
        {
            int num = 0;
            string str = DB.N2T(RuntimeHelpers.GetObjectValue(command.ExecuteScalar()), "").ToString().TrimEnd(new char[0]);
            if (str == "")
            {
                num = 1;
            }
            else
            {
                num = int.Parse(str.Remove(0, 8)) + 1;
            }
            this.m_podaci.sifraobracuna = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(this.godinaisplate.Value, "-"), this.mjesecisplate.Value), "-"), string.Format("{0:000}", num)));
        }
        catch (System.Exception exception1)
        {
            throw exception1;
        }
        connection.Close();
    }

    private void UltraButton3_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }

    private void UltraButton4_Click(object sender, EventArgs e)
    {
        if (((((((Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.mjesecobracuna.Value)) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.godinaobracuna.Value))) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.mjesecisplate.Value))) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.godinaisplate.Value))) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.tjednifond.Value))) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.mjesecnifond.Value))) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.osnovnioo.Value))) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.obrosnovica.Value)))
        {
            Interaction.MsgBox("Nepotpuni parametri obračuna!", MsgBoxStyle.Information, "Obračun plaća");
        }
        else
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Set_Parametri_Obracuna();
            this.m_podaci.mjesecobracuna = Conversions.ToString(this.mjesecobracuna.Value);
            this.m_podaci.godinaobracuna = Conversions.ToString(this.godinaobracuna.Value);
            this.m_podaci.mjesecisplate = Conversions.ToString(this.mjesecisplate.Value);
            this.m_podaci.godinaisplate = Conversions.ToString(this.godinaisplate.Value);
            this.m_podaci.mjesecnifond = Conversions.ToDecimal(this.mjesecnifond.Value);
            this.m_podaci.tjednifond = Conversions.ToDecimal(this.tjednifond.Value);
            this.m_podaci.osnovnioo = Conversions.ToDecimal(this.osnovnioo.Value);
            this.m_podaci.obrosnovica = Conversions.ToDecimal(this.obrosnovica.Value);
            this.m_podaci.datumobracunastaza = Conversions.ToDate(this.datumobracunastaza.Value);
            this.m_podaci.txtOpisObracuna = Conversions.ToString(this.txtOpisObracuna.Value);

        }
    }

    public PodaciObracun __Obracun
    {
        get
        {
            return this.m_podaci;
        }
        set
        {
            this.__Obracun = value;
        }
    }

    private UltraDateTimeEditor datumobracunastaza;

    private UltraMaskedEdit godinaisplate;

    private UltraMaskedEdit godinaobracuna;

    private UltraMaskedEdit mjesecisplate;

    private UltraNumericEditor mjesecnifond;

    private UltraMaskedEdit mjesecobracuna;

    private UltraNumericEditor obrosnovica;

    private UltraNumericEditor osnovnioo;

    private UltraNumericEditor tjednifond;

    private UltraTextEditor txtOpisObracuna;

    private UltraButton UltraButton3;

    private UltraButton UltraButton4;

    private UltraGroupBox UltraGroupBox1;

    private UltraLabel UltraLabel1;

    private UltraLabel UltraLabel10;

    private UltraLabel UltraLabel2;

    private UltraLabel UltraLabel3;

    private UltraLabel UltraLabel4;

    private UltraLabel UltraLabel5;

    private UltraLabel UltraLabel6;

    private UltraLabel UltraLabel7;

    private UltraLabel UltraLabel8;

    private UltraLabel UltraLabel9;

    [StructLayout(LayoutKind.Sequential)]
    public struct PodaciObracun
    {
        public string mjesecobracuna;
        public string godinaobracuna;
        public string mjesecisplate;
        public string godinaisplate;
        public decimal mjesecnifond;
        public decimal tjednifond;
        public decimal osnovnioo;
        public decimal obrosnovica;
        public string sifraobracuna;
        public DateTime datumobracunastaza;
        public string txtOpisObracuna;
        public string vrstaobracuna;
    }

    /// <summary>
    ///db 22.12.2016 - Dodaje se ovaj event radi kontrole upisane vrijednosti --> OVO IDE TEK SA 1.1.2017
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void osnovnioo_ValueChanged(object sender, EventArgs e)
    {
        //if (_load) return;

        //string vrijednost = osnovnioo.Text.Trim();

        //if(vrijednost != "2500,00")
        //{
        //    if (admin_kontrola == false)
        //    {
        //        if (!this.bPromjeneMoguce)
        //        {
        //            MessageBox.Show("Izmjene nisu moguće na trenutnom koeficientu!\r\n\r\n", "Obračun plaće", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        //            if (MessageBox.Show("unesite admin lozinku za promjenu podataka.", "Admin sučelje", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
        //            {
        //                frmAdmin admin = new frmAdmin();
        //                if (admin.ShowDialog() == DialogResult.OK)
        //                {
        //                    admin_kontrola = true;
        //                    bPromjeneMoguce = true;
        //                }
        //                else
        //                {                           
        //                    bPromjeneMoguce = false;

        //                    this.osnovnioo.Text = "2500,00";
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                bPromjeneMoguce = false;

        //                this.osnovnioo.Text = "2500,00";
        //                return;
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    return;
        //}
    }
}

