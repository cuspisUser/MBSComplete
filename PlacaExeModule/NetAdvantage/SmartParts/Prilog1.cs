namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class Prilog1 : UserControl
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("jbBroj")]
        private UltraNumericEditor _jbBroj;
        [AccessedThroughProperty("jbIznos")]
        private UltraNumericEditor _jbIznos;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;

        [AccessedThroughProperty("LabelHR1")]
        private Label _LabelHR1;
        [AccessedThroughProperty("LabelHR2")]
        private Label _LabelHR2;
        [AccessedThroughProperty("LabelRacun1")]
        private Label _LabelRacun1;
        [AccessedThroughProperty("LabelRacun2")]
        private Label _LabelRacun2;

        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("plBroj")]
        private UltraNumericEditor _plBroj;
        [AccessedThroughProperty("plIznos")]
        private UltraNumericEditor _plIznos;
        [AccessedThroughProperty("tkBroj")]
        private UltraNumericEditor _tkBroj;

        [AccessedThroughProperty("uneHR1")]
        private UltraTextEditor _uneHR1;
        [AccessedThroughProperty("uneHR2")]
        private UltraTextEditor _uneHR2;
        [AccessedThroughProperty("uneRacun1")]
        private UltraTextEditor _uneRacun1;
        [AccessedThroughProperty("uneHRacun2")]
        private UltraTextEditor _uneRacun2;

        [AccessedThroughProperty("tkSvota")]
        private UltraNumericEditor _tkSvota;
        [AccessedThroughProperty("unueSveukupnoBroj")]
        private UltraNumericEditor _unueSveukupnoBroj;
        [AccessedThroughProperty("unueSveukupnoSvota")]
        private UltraNumericEditor _unueSveukupnoSvota;
        

        public Prilog1()
        {
            base.Load += new EventHandler(this.UserControl1_Load);
            this.InitializeComponent();
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            this.Ispis_Prilog1_Obrasca();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Ispis_Prilog1_Obrasca();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.GroupBox1 = new GroupBox();
            this.Button2 = new Button();
            this.Button1 = new Button();
            this.Label8 = new Label();
            this.unueSveukupnoSvota = new UltraNumericEditor();
            this.Label7 = new Label();
            this.tkSvota = new UltraNumericEditor();
            this.Label6 = new Label();
            this.jbIznos = new UltraNumericEditor();
            this.Label5 = new Label();
            this.unueSveukupnoBroj = new UltraNumericEditor();
            this.tkBroj = new UltraNumericEditor();
            this.jbBroj = new UltraNumericEditor();
            this.plBroj = new UltraNumericEditor();
            this.plIznos = new UltraNumericEditor();
            this.Label4 = new Label();
            this.Label3 = new Label();
            this.Label2 = new Label();
            this.Label1 = new Label();
            this.LabelHR1 = new Label();
            this.LabelHR2 = new Label();
            this.LabelRacun1 = new Label();
            this.LabelRacun2 = new Label();

            this.uneHR1 = new UltraTextEditor();
            this.uneHR2 = new UltraTextEditor();
            this.uneRacun1 = new UltraTextEditor();
            this.uneRacun2 = new UltraTextEditor();

            this.GroupBox1.SuspendLayout();
            ((ISupportInitialize) this.unueSveukupnoSvota).BeginInit();
            ((ISupportInitialize) this.tkSvota).BeginInit();
            ((ISupportInitialize) this.jbIznos).BeginInit();
            ((ISupportInitialize) this.unueSveukupnoBroj).BeginInit();
            ((ISupportInitialize) this.tkBroj).BeginInit();
            ((ISupportInitialize) this.jbBroj).BeginInit();
            ((ISupportInitialize) this.plBroj).BeginInit();
            ((ISupportInitialize) this.plIznos).BeginInit();

            ((ISupportInitialize)this.uneHR2).BeginInit();
            ((ISupportInitialize)this.uneHR1).BeginInit();
            ((ISupportInitialize)this.uneRacun1).BeginInit();
            ((ISupportInitialize)this.uneRacun2).BeginInit();

            this.SuspendLayout();
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.unueSveukupnoSvota);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.tkSvota);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.jbIznos);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.unueSveukupnoBroj);
            this.GroupBox1.Controls.Add(this.tkBroj);
            this.GroupBox1.Controls.Add(this.jbBroj);
            this.GroupBox1.Controls.Add(this.plBroj);
            this.GroupBox1.Controls.Add(this.plIznos);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);

            this.GroupBox1.Controls.Add(this.LabelHR1);
            this.GroupBox1.Controls.Add(this.LabelHR2);
            this.GroupBox1.Controls.Add(this.LabelRacun1);
            this.GroupBox1.Controls.Add(this.LabelRacun2);
            this.GroupBox1.Controls.Add(this.uneHR1);
            this.GroupBox1.Controls.Add(this.uneHR2);
            this.GroupBox1.Controls.Add(this.uneRacun1);
            this.GroupBox1.Controls.Add(this.uneRacun2);

            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            System.Drawing.Point point = new System.Drawing.Point(-8, 3);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new System.Drawing.Size(526, 220);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            point = new System.Drawing.Point(346, 184);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new System.Drawing.Size(0x4b, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 0x12;
            this.Button2.Text = "Izlaz";
            this.Button2.UseVisualStyleBackColor = true;
            point = new System.Drawing.Point(130, 184);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new System.Drawing.Size(0x4b, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 0x11;
            this.Button1.Text = "Ispis";
            this.Button1.UseVisualStyleBackColor = true;
            
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x128, 114);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new System.Drawing.Size(0x51, 20);
            this.Label8.Size = size;
            this.Label8.TabIndex = 15;
            this.Label8.Text = "Sveukupno:";
            this.Label8.TextAlign = ContentAlignment.MiddleRight;

            this.LabelHR1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x16, 134);
            this.LabelHR1.Location = point;
            this.LabelHR1.Name = "LabelHR1";
            size = new System.Drawing.Size(0x51, 20);
            this.LabelHR1.Size = size;
            this.LabelHR1.TabIndex = 15;
            this.LabelHR1.Text = "HR1:";
            this.LabelHR1.TextAlign = ContentAlignment.MiddleRight;

            this.LabelHR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x128, 134);
            this.LabelHR2.Location = point;
            this.LabelHR2.Name = "LabelHR2";
            size = new System.Drawing.Size(0x51, 20);
            this.LabelHR2.Size = size;
            this.LabelHR2.TabIndex = 15;
            this.LabelHR2.Text = "HR2:";
            this.LabelHR2.TextAlign = ContentAlignment.MiddleRight;

            this.LabelRacun1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x16, 157);
            this.LabelRacun1.Location = point;
            this.LabelRacun1.Name = "LabelHR1";
            size = new System.Drawing.Size(0x51, 20);
            this.LabelRacun1.Size = size;
            this.LabelRacun1.TabIndex = 15;
            this.LabelRacun1.Text = "Račun1:";
            this.LabelRacun1.TextAlign = ContentAlignment.MiddleRight;

            this.LabelRacun2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x128, 157);
            this.LabelRacun2.Location = point;
            this.LabelRacun2.Name = "LabelHR2";
            size = new System.Drawing.Size(0x51, 20);
            this.LabelRacun2.Size = size;
            this.LabelRacun2.TabIndex = 15;
            this.LabelRacun2.Text = "Račun2:";
            this.LabelRacun2.TextAlign = ContentAlignment.MiddleRight;


            this.uneHR1.AlwaysInEditMode = true;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.ForeColor = Color.MidnightBlue;
            this.uneHR1.Appearance = appearance8;
            this.uneHR1.AutoSize = false;
            this.uneHR1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uneHR1.BorderStyle = UIElementBorderStyle.None;
            this.uneHR1.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.uneHR1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.uneHR1.ForeColor = Color.MidnightBlue;
            point = new System.Drawing.Point(261, 132);
            this.uneHR1.Location = point;
            uneHR1.MaxLength = 2;
            this.uneHR1.Text = "84";
            this.uneHR1.Name = "uneHR1";
            size = new System.Drawing.Size(30, 0x16);
            this.uneHR1.Size = size;
            this.uneHR1.TabIndex = 3;
            this.uneHR1.UseFlatMode = DefaultableBoolean.True;
            this.uneHR1.UseOsThemes = DefaultableBoolean.False;


            this.uneHR2.AlwaysInEditMode = true;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.ForeColor = Color.MidnightBlue;
            this.uneHR2.Appearance = appearance8;
            this.uneHR2.AutoSize = false;
            this.uneHR2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uneHR2.BorderStyle = UIElementBorderStyle.None;
            this.uneHR2.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.uneHR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.uneHR2.ForeColor = Color.MidnightBlue;
            point = new System.Drawing.Point(466, 132);
            this.uneHR2.Location = point;
            uneHR2.MaxLength = 2;
            this.uneHR2.Name = "uneHR2";
            size = new System.Drawing.Size(30, 0x16);
            this.uneHR2.Size = size;
            this.uneHR2.TabIndex = 3;
            this.uneHR2.UseFlatMode = DefaultableBoolean.True;
            this.uneHR2.UseOsThemes = DefaultableBoolean.False;
            this.uneHR2.Text = "00";


            this.uneRacun1.AlwaysInEditMode = true;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.ForeColor = Color.MidnightBlue;
            this.uneRacun1.Appearance = appearance8;
            this.uneRacun1.AutoSize = false;
            this.uneRacun1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uneRacun1.BorderStyle = UIElementBorderStyle.None;
            this.uneRacun1.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.uneRacun1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.uneRacun1.ForeColor = Color.MidnightBlue;
            point = new System.Drawing.Point(180, 158);
            this.uneRacun1.Location = point;
            uneRacun1.MaxLength = 10;
            this.uneRacun1.Name = "uneRacun1";
            size = new System.Drawing.Size(0x70, 0x16);
            this.uneRacun1.Size = size;
            this.uneRacun1.TabIndex = 3;
            this.uneRacun1.UseFlatMode = DefaultableBoolean.True;
            this.uneRacun1.UseOsThemes = DefaultableBoolean.False;
            this._uneRacun1.Text = "00472";


            this.uneRacun2.AlwaysInEditMode = true;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.ForeColor = Color.MidnightBlue;
            this.uneRacun2.Appearance = appearance8;
            this.uneRacun2.AutoSize = false;
            this.uneRacun2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uneRacun2.BorderStyle = UIElementBorderStyle.None;
            this.uneRacun2.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.uneRacun2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.uneRacun2.ForeColor = Color.MidnightBlue;
            uneRacun2.MaxLength = 10;
            point = new System.Drawing.Point(385, 158);
            this.uneRacun2.Location = point;
            this.uneRacun2.Name = "uneRacun2";
            size = new System.Drawing.Size(0x70, 0x16);
            this.uneRacun2.Size = size;
            this.uneRacun2.TabIndex = 3;
            this.uneRacun2.UseFlatMode = DefaultableBoolean.True;
            this.uneRacun2.UseOsThemes = DefaultableBoolean.False;



            this.unueSveukupnoSvota.AlwaysInEditMode = true;
            appearance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance.ForeColor = Color.MidnightBlue;
            this.unueSveukupnoSvota.Appearance = appearance;
            this.unueSveukupnoSvota.AutoSize = false;
            this.unueSveukupnoSvota.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.unueSveukupnoSvota.BorderStyle = UIElementBorderStyle.None;
            this.unueSveukupnoSvota.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.unueSveukupnoSvota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.unueSveukupnoSvota.ForeColor = Color.MidnightBlue;
            this.unueSveukupnoSvota.FormatString = "#,##0.00";
            point = new System.Drawing.Point(0x181, 0x6c);
            this.unueSveukupnoSvota.Location = point;
            this.unueSveukupnoSvota.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            decimal num = new decimal(new int[] { -1, -1, -1, 0 });
            this.unueSveukupnoSvota.MaxValue = num;
            this.unueSveukupnoSvota.MinValue = 0;
            this.unueSveukupnoSvota.Name = "unueSveukupnoSvota";
            this.unueSveukupnoSvota.NumericType = NumericType.Double;
            this.unueSveukupnoSvota.PromptChar = ' ';
            this.unueSveukupnoSvota.ReadOnly = true;
            size = new System.Drawing.Size(0x70, 0x16);
            this.unueSveukupnoSvota.Size = size;
            this.unueSveukupnoSvota.TabIndex = 0x10;
            this.unueSveukupnoSvota.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.unueSveukupnoSvota.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.unueSveukupnoSvota.UseFlatMode = DefaultableBoolean.True;
            this.unueSveukupnoSvota.UseOsThemes = DefaultableBoolean.False;
            point = new System.Drawing.Point(0x128, 0x48);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new System.Drawing.Size(0x26, 20);
            this.Label7.Size = size;
            this.Label7.TabIndex = 10;
            this.Label7.Text = "Iznos:";
            this.Label7.TextAlign = ContentAlignment.MiddleRight;
            this.tkSvota.AlwaysInEditMode = true;
            appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance2.ForeColor = Color.MidnightBlue;
            this.tkSvota.Appearance = appearance2;
            this.tkSvota.AutoSize = false;
            this.tkSvota.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tkSvota.BorderStyle = UIElementBorderStyle.None;
            this.tkSvota.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.tkSvota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.tkSvota.ForeColor = Color.MidnightBlue;
            this.tkSvota.FormatString = "#,##0.00";
            point = new System.Drawing.Point(0x181, 70);
            this.tkSvota.Location = point;
            this.tkSvota.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.tkSvota.MaxValue = num;
            this.tkSvota.MinValue = 0;
            this.tkSvota.Name = "tkSvota";
            this.tkSvota.NumericType = NumericType.Double;
            this.tkSvota.PromptChar = ' ';
            size = new System.Drawing.Size(0x70, 0x16);
            this.tkSvota.Size = size;
            this.tkSvota.TabIndex = 11;
            this.tkSvota.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.tkSvota.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.tkSvota.UseFlatMode = DefaultableBoolean.True;
            this.tkSvota.UseOsThemes = DefaultableBoolean.False;
            point = new System.Drawing.Point(0x128, 0x2e);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new System.Drawing.Size(0x26, 20);
            this.Label6.Size = size;
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Iznos:";
            this.Label6.TextAlign = ContentAlignment.MiddleRight;
            this.jbIznos.AlwaysInEditMode = true;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.ForeColor = Color.MidnightBlue;
            this.jbIznos.Appearance = appearance3;
            this.jbIznos.AutoSize = false;
            this.jbIznos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.jbIznos.BorderStyle = UIElementBorderStyle.None;
            this.jbIznos.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.jbIznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.jbIznos.ForeColor = Color.MidnightBlue;
            this.jbIznos.FormatString = "#,##0.00";
            point = new System.Drawing.Point(0x181, 0x2c);
            this.jbIznos.Location = point;
            this.jbIznos.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.jbIznos.MaxValue = num;
            this.jbIznos.MinValue = 0;
            this.jbIznos.Name = "jbIznos";
            this.jbIznos.NumericType = NumericType.Double;
            this.jbIznos.PromptChar = ' ';
            size = new System.Drawing.Size(0x70, 0x16);
            this.jbIznos.Size = size;
            this.jbIznos.TabIndex = 7;
            this.jbIznos.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.jbIznos.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.jbIznos.UseFlatMode = DefaultableBoolean.True;
            this.jbIznos.UseOsThemes = DefaultableBoolean.False;
            point = new System.Drawing.Point(0x128, 20);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new System.Drawing.Size(0x26, 20);
            this.Label5.Size = size;
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Iznos:";
            this.Label5.TextAlign = ContentAlignment.MiddleRight;
            this.unueSveukupnoBroj.AlwaysInEditMode = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.ForeColor = Color.MidnightBlue;
            this.unueSveukupnoBroj.Appearance = appearance4;
            this.unueSveukupnoBroj.AutoSize = false;
            this.unueSveukupnoBroj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.unueSveukupnoBroj.BorderStyle = UIElementBorderStyle.None;
            this.unueSveukupnoBroj.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.unueSveukupnoBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.unueSveukupnoBroj.ForeColor = Color.MidnightBlue;
            this.unueSveukupnoBroj.FormatString = "#0";
            point = new System.Drawing.Point(0xde, 0x6c);
            this.unueSveukupnoBroj.Location = point;
            this.unueSveukupnoBroj.MaskInput = "{LOC}nnn,nnn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.unueSveukupnoBroj.MaxValue = num;
            this.unueSveukupnoBroj.MinValue = 0;
            this.unueSveukupnoBroj.Name = "unueSveukupnoBroj";
            this.unueSveukupnoBroj.NumericType = NumericType.Double;
            this.unueSveukupnoBroj.PromptChar = ' ';
            this.unueSveukupnoBroj.ReadOnly = true;
            size = new System.Drawing.Size(0x44, 0x16);
            this.unueSveukupnoBroj.Size = size;
            this.unueSveukupnoBroj.TabIndex = 14;
            this.unueSveukupnoBroj.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.unueSveukupnoBroj.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.unueSveukupnoBroj.UseFlatMode = DefaultableBoolean.True;
            this.unueSveukupnoBroj.UseOsThemes = DefaultableBoolean.False;
            this.tkBroj.AlwaysInEditMode = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.ForeColor = Color.MidnightBlue;
            this.tkBroj.Appearance = appearance5;
            this.tkBroj.AutoSize = false;
            this.tkBroj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tkBroj.BorderStyle = UIElementBorderStyle.None;
            this.tkBroj.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.tkBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.tkBroj.ForeColor = Color.MidnightBlue;
            this.tkBroj.FormatString = "#0";
            point = new System.Drawing.Point(0xde, 70);
            this.tkBroj.Location = point;
            this.tkBroj.MaskInput = "{LOC}nnn,nnn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.tkBroj.MaxValue = num;
            this.tkBroj.MinValue = 0;
            this.tkBroj.Name = "tkBroj";
            this.tkBroj.NumericType = NumericType.Double;
            this.tkBroj.PromptChar = ' ';
            size = new System.Drawing.Size(0x44, 0x16);
            this.tkBroj.Size = size;
            this.tkBroj.TabIndex = 9;
            this.tkBroj.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.tkBroj.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.tkBroj.UseFlatMode = DefaultableBoolean.True;
            this.tkBroj.UseOsThemes = DefaultableBoolean.False;
            this.jbBroj.AlwaysInEditMode = true;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.ForeColor = Color.MidnightBlue;
            this.jbBroj.Appearance = appearance6;
            this.jbBroj.AutoSize = false;
            this.jbBroj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.jbBroj.BorderStyle = UIElementBorderStyle.None;
            this.jbBroj.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.jbBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.jbBroj.ForeColor = Color.MidnightBlue;
            this.jbBroj.FormatString = "#0";
            point = new System.Drawing.Point(0xde, 0x2c);
            this.jbBroj.Location = point;
            this.jbBroj.MaskInput = "{LOC}nnn,nnn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.jbBroj.MaxValue = num;
            this.jbBroj.MinValue = 0;
            this.jbBroj.Name = "jbBroj";
            this.jbBroj.NumericType = NumericType.Double;
            this.jbBroj.PromptChar = ' ';
            size = new System.Drawing.Size(0x44, 0x16);
            this.jbBroj.Size = size;
            this.jbBroj.TabIndex = 5;
            this.jbBroj.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.jbBroj.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.jbBroj.UseFlatMode = DefaultableBoolean.True;
            this.jbBroj.UseOsThemes = DefaultableBoolean.False;
            this.plBroj.AlwaysInEditMode = true;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.ForeColor = Color.MidnightBlue;
            this.plBroj.Appearance = appearance7;
            this.plBroj.AutoSize = false;
            this.plBroj.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plBroj.BorderStyle = UIElementBorderStyle.None;
            this.plBroj.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.plBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.plBroj.ForeColor = Color.MidnightBlue;
            this.plBroj.FormatString = "#0";
            point = new System.Drawing.Point(0xde, 0x12);
            this.plBroj.Location = point;
            this.plBroj.MaskInput = "{LOC}nnn,nnn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.plBroj.MaxValue = num;
            this.plBroj.MinValue = 0;
            this.plBroj.Name = "plBroj";
            this.plBroj.NumericType = NumericType.Double;
            this.plBroj.PromptChar = ' ';
            size = new System.Drawing.Size(0x44, 0x16);
            this.plBroj.Size = size;
            this.plBroj.TabIndex = 1;
            this.plBroj.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.plBroj.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.plBroj.UseFlatMode = DefaultableBoolean.True;
            this.plBroj.UseOsThemes = DefaultableBoolean.False;
            this.plIznos.AlwaysInEditMode = true;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.ForeColor = Color.MidnightBlue;
            this.plIznos.Appearance = appearance8;
            this.plIznos.AutoSize = false;
            this.plIznos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plIznos.BorderStyle = UIElementBorderStyle.None;
            this.plIznos.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.plIznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.plIznos.ForeColor = Color.MidnightBlue;
            this.plIznos.FormatString = "#,##0.00";
            point = new System.Drawing.Point(0x181, 0x12);
            this.plIznos.Location = point;
            this.plIznos.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.plIznos.MaxValue = num;
            this.plIznos.MinValue = 0;
            this.plIznos.Name = "plIznos";
            this.plIznos.NumericType = NumericType.Double;
            this.plIznos.PromptChar = ' ';
            size = new System.Drawing.Size(0x70, 0x16);
            this.plIznos.Size = size;
            this.plIznos.TabIndex = 3;
            this.plIznos.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.plIznos.Tag = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.plIznos.UseFlatMode = DefaultableBoolean.True;
            this.plIznos.UseOsThemes = DefaultableBoolean.False;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x16, 110);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new System.Drawing.Size(0xc2, 20);
            this.Label4.Size = size;
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Sveukupno naloga:";
            this.Label4.TextAlign = ContentAlignment.MiddleLeft;
            point = new System.Drawing.Point(0x16, 0x48);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new System.Drawing.Size(0xc2, 20);
            this.Label3.Size = size;
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Broj naloga za tekuće izdatke:";
            this.Label3.TextAlign = ContentAlignment.MiddleLeft;
            point = new System.Drawing.Point(0x16, 0x2e);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new System.Drawing.Size(0xb7, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Broj naloga za jubilarne nagrade:";
            this.Label2.TextAlign = ContentAlignment.MiddleLeft;
            point = new System.Drawing.Point(0x16, 20);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new System.Drawing.Size(0xc2, 20);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Broj naloga za plaću:";
            this.Label1.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(this.GroupBox1);
            this.Name = "Prilog1";
            size = new System.Drawing.Size(525, 230);
            this.Size = size;
            this.GroupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.unueSveukupnoSvota).EndInit();
            ((ISupportInitialize) this.tkSvota).EndInit();
            ((ISupportInitialize) this.jbIznos).EndInit();
            ((ISupportInitialize) this.unueSveukupnoBroj).EndInit();
            ((ISupportInitialize) this.tkBroj).EndInit();
            ((ISupportInitialize) this.jbBroj).EndInit();
            ((ISupportInitialize) this.plBroj).EndInit();
            ((ISupportInitialize) this.plIznos).EndInit();
            this.ResumeLayout(false);
        }

        private void Ispis_Prilog1_Obrasca()
        {
            string str = string.Empty;
            string str2 = string.Empty;
            this.Cursor = Cursors.WaitCursor;
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Prilog 1",
                Description = "Pregled izvještaja - Prilog 1",
                Icon = ImageResourcesNew.mbs
            };
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPrilog1.rpt");
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            this.ParentForm.Close();
            item.Izvjestaj = document;
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);
            document.SetParameterValue("USTANOVA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ADRESA2", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            document.SetParameterValue("RKDP", DB.N20(RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["rkp"])));
            document.SetParameterValue("PLACABROJ", DB.N20(RuntimeHelpers.GetObjectValue(this.plBroj.Value)));
            document.SetParameterValue("PLACASVOTA", DB.N20(RuntimeHelpers.GetObjectValue(this.plIznos.Value)));
            document.SetParameterValue("JUBILARNEBROJ", DB.N20(RuntimeHelpers.GetObjectValue(this.jbBroj.Value)));
            document.SetParameterValue("JUBILARNESVOTA", DB.N20(RuntimeHelpers.GetObjectValue(this.jbIznos.Value)));
            document.SetParameterValue("TEKUCIBROJ", DB.N20(RuntimeHelpers.GetObjectValue(this.tkBroj.Value)));
            document.SetParameterValue("TEKUCISVOTA", DB.N20(RuntimeHelpers.GetObjectValue(this.tkSvota.Value)));

            string ziroRacun = string.Empty;

            DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik = 1001005");
            if (rowArray.Length > 0)
            {
                str = string.Format("{0} {1} {2}", Conversions.ToString(rowArray[0]["nazivziro"]), Conversions.ToString(rowArray[0]["ulicaziro"]), Conversions.ToString(rowArray[0]["mjestoziro"]));
                str2 = Conversions.ToString(rowArray[0]["zirokorisnik"]);

                ziroRacun = Conversions.ToString(rowArray[0]["VBDIKORISNIK"]) + Conversions.ToString(rowArray[0]["zirokorisnik"]);
            }
            else
            {
                str = "";
                str2 = "";
            }

            IBAN iban = new IBAN();

            document.SetParameterValue("ziro", iban.GenerirajIBANIzBrojaRacuna(ziroRacun, false, true));
            document.SetParameterValue("ministarstvo", str);
            document.SetParameterValue("HR1", uneHR1.Text);
            document.SetParameterValue("HR2", uneHR2.Text);
            document.SetParameterValue("Racun1", uneRacun1.Text);
            document.SetParameterValue("Racun2", uneRacun2.Text);
            item.Show(item.Workspaces["main"], info);
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        }

        internal Button Button1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button1_Click);
                if (this._Button1 != null)
                {
                    this._Button1.Click -= handler;
                }
                this._Button1 = value;
                if (this._Button1 != null)
                {
                    this._Button1.Click += handler;
                }
            }
        }

        internal Button Button2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button2_Click);
                if (this._Button2 != null)
                {
                    this._Button2.Click -= handler;
                }
                this._Button2 = value;
                if (this._Button2 != null)
                {
                    this._Button2.Click += handler;
                }
            }
        }

        [CreateNew]
        public Prilog1Controller Controller { get; set; }

        internal GroupBox GroupBox1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._GroupBox1 = value;
            }
        }

        internal UltraNumericEditor jbBroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._jbBroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._jbBroj = value;
            }
        }

        internal UltraNumericEditor jbIznos
        {
            [DebuggerNonUserCode]
            get
            {
                return this._jbIznos;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._jbIznos = value;
            }
        }

        private Label Label1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label1 = value;
            }
        }

        private Label LabelHR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._LabelHR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._LabelHR1 = value;
            }
        }

        private Label LabelHR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._LabelHR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._LabelHR2 = value;
            }
        }

        private Label LabelRacun1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._LabelRacun1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._LabelRacun1 = value;
            }
        }

        private Label LabelRacun2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._LabelRacun2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._LabelRacun2 = value;
            }
        }

        private Label Label2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label2 = value;
            }
        }

        private Label Label3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label3 = value;
            }
        }

        private Label Label4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label4 = value;
            }
        }

        private Label Label5
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label5 = value;
            }
        }

        private Label Label6
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label6 = value;
            }
        }

        private Label Label7
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label7 = value;
            }
        }

        private Label Label8
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label8 = value;
            }
        }

        internal UltraNumericEditor plBroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._plBroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._plBroj = value;
            }
        }

        internal UltraNumericEditor plIznos
        {
            [DebuggerNonUserCode]
            get
            {
                return this._plIznos;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._plIznos = value;
            }
        }

        internal UltraNumericEditor tkBroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._tkBroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._tkBroj = value;
            }
        }

        internal UltraTextEditor uneHR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._uneHR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._uneHR1 = value;
            }
        }

        internal UltraTextEditor uneHR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._uneHR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._uneHR2 = value;
            }
        }

        internal UltraTextEditor uneRacun1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._uneRacun1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._uneRacun1 = value;
            }
        }

        internal UltraTextEditor uneRacun2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._uneRacun2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._uneRacun2 = value;
            }
        }

        internal UltraNumericEditor tkSvota
        {
            [DebuggerNonUserCode]
            get
            {
                return this._tkSvota;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._tkSvota = value;
            }
        }

        protected virtual UltraNumericEditor unueSveukupnoBroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._unueSveukupnoBroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._unueSveukupnoBroj = value;
            }
        }

        protected virtual UltraNumericEditor unueSveukupnoSvota
        {
            [DebuggerNonUserCode]
            get
            {
                return this._unueSveukupnoSvota;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._unueSveukupnoSvota = value;
            }
        }
    }
}

