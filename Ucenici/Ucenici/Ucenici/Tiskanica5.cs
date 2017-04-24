using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;

using Mipsed7.DataAccessLayer;
using System.IO;
using Placa;

using EnvDTE;
using EnvDTE100;
using System.Runtime.InteropServices;

namespace Ucenici.Ucenici
{
    [SmartPart]
    public class Tiskanica5 : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private SmartPartInfoProvider infoProvider;
        private ListView ListView_Ucenici;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private CheckBox CheckBox_13a12;
        private CheckBox CheckBox_13a11;
        private CheckBox CheckBox_13a10;
        private CheckBox CheckBox_13a9;
        private CheckBox CheckBox_13a8;
        private CheckBox CheckBox_13a7;
        private CheckBox CheckBox_13a6;
        private CheckBox CheckBox_13a5;
        private CheckBox CheckBox_13a4;
        private CheckBox CheckBox_13a3;
        private CheckBox CheckBox_13a2;
        private CheckBox CheckBox_13a1;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private DateTimePicker dtpDatumPredaje;
        private TextBox txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva;
        private TextBox txtOsnovniPodaci_MjestoPredaje;
        private TextBox txtObveznikUplate_OIB;
        private TextBox txtObveznikUplate_Adresa;
        private TextBox txtObveznikUplate_Naziv;
        private RadioButton rdbPrijava;
        private RadioButton rdbOdjava;
        private RadioButton rdbPromjena;
        private Button btnGenerirajTiskanicu;
        private DateTimePicker dtpPrijava;
        private Label lblPrijavaOdjavaPromjena;
        private Button btnOznaciSve;
        private Button btnOdznaciSve;
        private GroupBox groupBox3;
        private DateTimePicker dtpDatotekaHZZO_OD;
        private Label label7;
        private DateTimePicker dtpDatotekaHZZO_DO;
        private Label label8;
        private Button btnDatotekaHZZO_Generiraj;
        private TextBox txtStatus;
        private SmartPartInfo smartPartInfo1;

        public enum EnumTipTiskanice
        {
            None,
            Prijava,
            Odjava,
            Promjena
        }

        public EnumTipTiskanice TipTiskanice { get; set; }

        public Tiskanica5()
        {
            this.smartPartInfo1 = new SmartPartInfo("Tiskanica 5", "Tiskanica5");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ListView_Ucenici = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva = new System.Windows.Forms.TextBox();
            this.txtOsnovniPodaci_MjestoPredaje = new System.Windows.Forms.TextBox();
            this.dtpDatumPredaje = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtObveznikUplate_OIB = new System.Windows.Forms.TextBox();
            this.txtObveznikUplate_Adresa = new System.Windows.Forms.TextBox();
            this.txtObveznikUplate_Naziv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpPrijava = new System.Windows.Forms.DateTimePicker();
            this.lblPrijavaOdjavaPromjena = new System.Windows.Forms.Label();
            this.CheckBox_13a12 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a11 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a10 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a9 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a8 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a7 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a6 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a5 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a4 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a3 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a2 = new System.Windows.Forms.CheckBox();
            this.CheckBox_13a1 = new System.Windows.Forms.CheckBox();
            this.rdbPrijava = new System.Windows.Forms.RadioButton();
            this.rdbOdjava = new System.Windows.Forms.RadioButton();
            this.rdbPromjena = new System.Windows.Forms.RadioButton();
            this.btnGenerirajTiskanicu = new System.Windows.Forms.Button();
            this.btnOznaciSve = new System.Windows.Forms.Button();
            this.btnOdznaciSve = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpDatotekaHZZO_DO = new System.Windows.Forms.DateTimePicker();
            this.btnDatotekaHZZO_Generiraj = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDatotekaHZZO_OD = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView_Ucenici
            // 
            this.ListView_Ucenici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ListView_Ucenici.CheckBoxes = true;
            this.ListView_Ucenici.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ListView_Ucenici.Location = new System.Drawing.Point(12, 47);
            this.ListView_Ucenici.Name = "ListView_Ucenici";
            this.ListView_Ucenici.ShowGroups = false;
            this.ListView_Ucenici.Size = new System.Drawing.Size(230, 721);
            this.ListView_Ucenici.TabIndex = 1;
            this.ListView_Ucenici.UseCompatibleStateImageBehavior = false;
            this.ListView_Ucenici.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva);
            this.groupBox1.Controls.Add(this.txtOsnovniPodaci_MjestoPredaje);
            this.groupBox1.Controls.Add(this.dtpDatumPredaje);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(269, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 138);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci";
            // 
            // txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva
            // 
            this.txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva.Location = new System.Drawing.Point(164, 98);
            this.txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva.Name = "txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva";
            this.txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva.Size = new System.Drawing.Size(235, 20);
            this.txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva.TabIndex = 7;
            // 
            // txtOsnovniPodaci_MjestoPredaje
            // 
            this.txtOsnovniPodaci_MjestoPredaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtOsnovniPodaci_MjestoPredaje.Location = new System.Drawing.Point(164, 64);
            this.txtOsnovniPodaci_MjestoPredaje.Name = "txtOsnovniPodaci_MjestoPredaje";
            this.txtOsnovniPodaci_MjestoPredaje.Size = new System.Drawing.Size(235, 21);
            this.txtOsnovniPodaci_MjestoPredaje.TabIndex = 6;
            // 
            // dtpDatumPredaje
            // 
            this.dtpDatumPredaje.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumPredaje.Location = new System.Drawing.Point(164, 30);
            this.dtpDatumPredaje.Name = "dtpDatumPredaje";
            this.dtpDatumPredaje.Size = new System.Drawing.Size(91, 20);
            this.dtpDatumPredaje.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Datum predaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ime i prezime podnositelja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mjesto predaje:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtObveznikUplate_OIB);
            this.groupBox2.Controls.Add(this.txtObveznikUplate_Adresa);
            this.groupBox2.Controls.Add(this.txtObveznikUplate_Naziv);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(269, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(858, 133);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o obvezniku uplate doprinosa";
            // 
            // txtObveznikUplate_OIB
            // 
            this.txtObveznikUplate_OIB.Location = new System.Drawing.Point(164, 96);
            this.txtObveznikUplate_OIB.Name = "txtObveznikUplate_OIB";
            this.txtObveznikUplate_OIB.Size = new System.Drawing.Size(101, 20);
            this.txtObveznikUplate_OIB.TabIndex = 9;
            this.txtObveznikUplate_OIB.Text = "49508397045";
            // 
            // txtObveznikUplate_Adresa
            // 
            this.txtObveznikUplate_Adresa.Location = new System.Drawing.Point(164, 63);
            this.txtObveznikUplate_Adresa.Name = "txtObveznikUplate_Adresa";
            this.txtObveznikUplate_Adresa.Size = new System.Drawing.Size(310, 20);
            this.txtObveznikUplate_Adresa.TabIndex = 8;
            this.txtObveznikUplate_Adresa.Text = "Zagreb, Donje Svetice 38";
            // 
            // txtObveznikUplate_Naziv
            // 
            this.txtObveznikUplate_Naziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtObveznikUplate_Naziv.Location = new System.Drawing.Point(164, 31);
            this.txtObveznikUplate_Naziv.Name = "txtObveznikUplate_Naziv";
            this.txtObveznikUplate_Naziv.Size = new System.Drawing.Size(310, 21);
            this.txtObveznikUplate_Naziv.TabIndex = 7;
            this.txtObveznikUplate_Naziv.Text = "Ministarstvo znanosti, obrazovanja i sporta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "OIB Ministarstva:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Adresa sjedišta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Naziv obveznika uplate:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dtpPrijava);
            this.groupBox4.Controls.Add(this.lblPrijavaOdjavaPromjena);
            this.groupBox4.Controls.Add(this.CheckBox_13a12);
            this.groupBox4.Controls.Add(this.CheckBox_13a11);
            this.groupBox4.Controls.Add(this.CheckBox_13a10);
            this.groupBox4.Controls.Add(this.CheckBox_13a9);
            this.groupBox4.Controls.Add(this.CheckBox_13a8);
            this.groupBox4.Controls.Add(this.CheckBox_13a7);
            this.groupBox4.Controls.Add(this.CheckBox_13a6);
            this.groupBox4.Controls.Add(this.CheckBox_13a5);
            this.groupBox4.Controls.Add(this.CheckBox_13a4);
            this.groupBox4.Controls.Add(this.CheckBox_13a3);
            this.groupBox4.Controls.Add(this.CheckBox_13a2);
            this.groupBox4.Controls.Add(this.CheckBox_13a1);
            this.groupBox4.Location = new System.Drawing.Point(267, 455);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(860, 143);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datum i slučaj osiguranja";
            // 
            // dtpPrijava
            // 
            this.dtpPrijava.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrijava.Location = new System.Drawing.Point(164, 30);
            this.dtpPrijava.Name = "dtpPrijava";
            this.dtpPrijava.Size = new System.Drawing.Size(91, 20);
            this.dtpPrijava.TabIndex = 27;
            // 
            // lblPrijavaOdjavaPromjena
            // 
            this.lblPrijavaOdjavaPromjena.AutoSize = true;
            this.lblPrijavaOdjavaPromjena.Location = new System.Drawing.Point(20, 33);
            this.lblPrijavaOdjavaPromjena.Name = "lblPrijavaOdjavaPromjena";
            this.lblPrijavaOdjavaPromjena.Size = new System.Drawing.Size(88, 13);
            this.lblPrijavaOdjavaPromjena.TabIndex = 26;
            this.lblPrijavaOdjavaPromjena.Text = "Datum PRIJAVE:";
            // 
            // CheckBox_13a12
            // 
            this.CheckBox_13a12.AutoSize = true;
            this.CheckBox_13a12.Location = new System.Drawing.Point(364, 106);
            this.CheckBox_13a12.Name = "CheckBox_13a12";
            this.CheckBox_13a12.Size = new System.Drawing.Size(62, 17);
            this.CheckBox_13a12.TabIndex = 25;
            this.CheckBox_13a12.Text = "13.a 12";
            this.CheckBox_13a12.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a11
            // 
            this.CheckBox_13a11.AutoSize = true;
            this.CheckBox_13a11.Location = new System.Drawing.Point(296, 106);
            this.CheckBox_13a11.Name = "CheckBox_13a11";
            this.CheckBox_13a11.Size = new System.Drawing.Size(62, 17);
            this.CheckBox_13a11.TabIndex = 24;
            this.CheckBox_13a11.Text = "13.a 11";
            this.CheckBox_13a11.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a10
            // 
            this.CheckBox_13a10.AutoSize = true;
            this.CheckBox_13a10.Location = new System.Drawing.Point(227, 106);
            this.CheckBox_13a10.Name = "CheckBox_13a10";
            this.CheckBox_13a10.Size = new System.Drawing.Size(62, 17);
            this.CheckBox_13a10.TabIndex = 23;
            this.CheckBox_13a10.Text = "13.a 10";
            this.CheckBox_13a10.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a9
            // 
            this.CheckBox_13a9.AutoSize = true;
            this.CheckBox_13a9.Location = new System.Drawing.Point(159, 106);
            this.CheckBox_13a9.Name = "CheckBox_13a9";
            this.CheckBox_13a9.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a9.TabIndex = 22;
            this.CheckBox_13a9.Text = "13.a 9";
            this.CheckBox_13a9.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a8
            // 
            this.CheckBox_13a8.AutoSize = true;
            this.CheckBox_13a8.Location = new System.Drawing.Point(91, 106);
            this.CheckBox_13a8.Name = "CheckBox_13a8";
            this.CheckBox_13a8.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a8.TabIndex = 21;
            this.CheckBox_13a8.Text = "13.a 8";
            this.CheckBox_13a8.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a7
            // 
            this.CheckBox_13a7.AutoSize = true;
            this.CheckBox_13a7.Location = new System.Drawing.Point(23, 106);
            this.CheckBox_13a7.Name = "CheckBox_13a7";
            this.CheckBox_13a7.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a7.TabIndex = 20;
            this.CheckBox_13a7.Text = "13.a 7";
            this.CheckBox_13a7.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a6
            // 
            this.CheckBox_13a6.AutoSize = true;
            this.CheckBox_13a6.Location = new System.Drawing.Point(364, 73);
            this.CheckBox_13a6.Name = "CheckBox_13a6";
            this.CheckBox_13a6.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a6.TabIndex = 19;
            this.CheckBox_13a6.Text = "13.a 6";
            this.CheckBox_13a6.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a5
            // 
            this.CheckBox_13a5.AutoSize = true;
            this.CheckBox_13a5.Location = new System.Drawing.Point(296, 73);
            this.CheckBox_13a5.Name = "CheckBox_13a5";
            this.CheckBox_13a5.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a5.TabIndex = 18;
            this.CheckBox_13a5.Text = "13.a 5";
            this.CheckBox_13a5.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a4
            // 
            this.CheckBox_13a4.AutoSize = true;
            this.CheckBox_13a4.Location = new System.Drawing.Point(227, 73);
            this.CheckBox_13a4.Name = "CheckBox_13a4";
            this.CheckBox_13a4.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a4.TabIndex = 17;
            this.CheckBox_13a4.Text = "13.a 4";
            this.CheckBox_13a4.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a3
            // 
            this.CheckBox_13a3.AutoSize = true;
            this.CheckBox_13a3.Location = new System.Drawing.Point(159, 73);
            this.CheckBox_13a3.Name = "CheckBox_13a3";
            this.CheckBox_13a3.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a3.TabIndex = 16;
            this.CheckBox_13a3.Text = "13.a 3";
            this.CheckBox_13a3.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a2
            // 
            this.CheckBox_13a2.AutoSize = true;
            this.CheckBox_13a2.Location = new System.Drawing.Point(91, 73);
            this.CheckBox_13a2.Name = "CheckBox_13a2";
            this.CheckBox_13a2.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a2.TabIndex = 15;
            this.CheckBox_13a2.Text = "13.a 2";
            this.CheckBox_13a2.UseVisualStyleBackColor = true;
            // 
            // CheckBox_13a1
            // 
            this.CheckBox_13a1.AutoSize = true;
            this.CheckBox_13a1.Checked = true;
            this.CheckBox_13a1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_13a1.Location = new System.Drawing.Point(23, 73);
            this.CheckBox_13a1.Name = "CheckBox_13a1";
            this.CheckBox_13a1.Size = new System.Drawing.Size(56, 17);
            this.CheckBox_13a1.TabIndex = 14;
            this.CheckBox_13a1.Text = "13.a 1";
            this.CheckBox_13a1.UseVisualStyleBackColor = true;
            // 
            // rdbPrijava
            // 
            this.rdbPrijava.AutoSize = true;
            this.rdbPrijava.Checked = true;
            this.rdbPrijava.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdbPrijava.ForeColor = System.Drawing.Color.Red;
            this.rdbPrijava.Location = new System.Drawing.Point(269, 18);
            this.rdbPrijava.Name = "rdbPrijava";
            this.rdbPrijava.Size = new System.Drawing.Size(124, 29);
            this.rdbPrijava.TabIndex = 18;
            this.rdbPrijava.TabStop = true;
            this.rdbPrijava.Text = "PRIJAVA";
            this.rdbPrijava.UseVisualStyleBackColor = true;
            this.rdbPrijava.CheckedChanged += new System.EventHandler(this.rdbPrijava_CheckedChanged);
            // 
            // rdbOdjava
            // 
            this.rdbOdjava.AutoSize = true;
            this.rdbOdjava.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdbOdjava.Location = new System.Drawing.Point(415, 18);
            this.rdbOdjava.Name = "rdbOdjava";
            this.rdbOdjava.Size = new System.Drawing.Size(120, 29);
            this.rdbOdjava.TabIndex = 19;
            this.rdbOdjava.Text = "ODJAVA";
            this.rdbOdjava.UseVisualStyleBackColor = true;
            this.rdbOdjava.CheckedChanged += new System.EventHandler(this.rdbOdjava_CheckedChanged);
            // 
            // rdbPromjena
            // 
            this.rdbPromjena.AutoSize = true;
            this.rdbPromjena.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdbPromjena.Location = new System.Drawing.Point(557, 18);
            this.rdbPromjena.Name = "rdbPromjena";
            this.rdbPromjena.Size = new System.Drawing.Size(155, 29);
            this.rdbPromjena.TabIndex = 20;
            this.rdbPromjena.Text = "PROMJENA";
            this.rdbPromjena.UseVisualStyleBackColor = true;
            this.rdbPromjena.CheckedChanged += new System.EventHandler(this.rdbPromjena_CheckedChanged);
            // 
            // btnGenerirajTiskanicu
            // 
            this.btnGenerirajTiskanicu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerirajTiskanicu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGenerirajTiskanicu.Location = new System.Drawing.Point(956, 616);
            this.btnGenerirajTiskanicu.Name = "btnGenerirajTiskanicu";
            this.btnGenerirajTiskanicu.Size = new System.Drawing.Size(171, 32);
            this.btnGenerirajTiskanicu.TabIndex = 21;
            this.btnGenerirajTiskanicu.Text = "Generiraj tiskanice";
            this.btnGenerirajTiskanicu.UseVisualStyleBackColor = true;
            this.btnGenerirajTiskanicu.Click += new System.EventHandler(this.btnGenerirajTiskanicu_Click);
            // 
            // btnOznaciSve
            // 
            this.btnOznaciSve.Location = new System.Drawing.Point(12, 13);
            this.btnOznaciSve.Name = "btnOznaciSve";
            this.btnOznaciSve.Size = new System.Drawing.Size(103, 23);
            this.btnOznaciSve.TabIndex = 23;
            this.btnOznaciSve.Text = "Odaberi SVE";
            this.btnOznaciSve.UseVisualStyleBackColor = true;
            this.btnOznaciSve.Click += new System.EventHandler(this.btnOznaciSve_Click);
            // 
            // btnOdznaciSve
            // 
            this.btnOdznaciSve.Location = new System.Drawing.Point(139, 13);
            this.btnOdznaciSve.Name = "btnOdznaciSve";
            this.btnOdznaciSve.Size = new System.Drawing.Size(103, 23);
            this.btnOdznaciSve.TabIndex = 24;
            this.btnOdznaciSve.Text = "Odznači sve";
            this.btnOdznaciSve.UseVisualStyleBackColor = true;
            this.btnOdznaciSve.Click += new System.EventHandler(this.btnOdznaciSve_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtpDatotekaHZZO_DO);
            this.groupBox3.Controls.Add(this.btnDatotekaHZZO_Generiraj);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dtpDatotekaHZZO_OD);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(267, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(860, 64);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datoteka za HZZO";
            // 
            // dtpDatotekaHZZO_DO
            // 
            this.dtpDatotekaHZZO_DO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatotekaHZZO_DO.Location = new System.Drawing.Point(290, 29);
            this.dtpDatotekaHZZO_DO.Name = "dtpDatotekaHZZO_DO";
            this.dtpDatotekaHZZO_DO.Size = new System.Drawing.Size(91, 20);
            this.dtpDatotekaHZZO_DO.TabIndex = 8;
            // 
            // btnDatotekaHZZO_Generiraj
            // 
            this.btnDatotekaHZZO_Generiraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDatotekaHZZO_Generiraj.Location = new System.Drawing.Point(405, 23);
            this.btnDatotekaHZZO_Generiraj.Name = "btnDatotekaHZZO_Generiraj";
            this.btnDatotekaHZZO_Generiraj.Size = new System.Drawing.Size(144, 28);
            this.btnDatotekaHZZO_Generiraj.TabIndex = 26;
            this.btnDatotekaHZZO_Generiraj.Text = "Izradi datoteku za HZZO";
            this.btnDatotekaHZZO_Generiraj.UseVisualStyleBackColor = true;
            this.btnDatotekaHZZO_Generiraj.Click += new System.EventHandler(this.btnDatotekaHZZO_Generiraj_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Datum DO:";
            // 
            // dtpDatotekaHZZO_OD
            // 
            this.dtpDatotekaHZZO_OD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatotekaHZZO_OD.Location = new System.Drawing.Point(91, 29);
            this.dtpDatotekaHZZO_OD.Name = "dtpDatotekaHZZO_OD";
            this.dtpDatotekaHZZO_OD.Size = new System.Drawing.Size(91, 20);
            this.dtpDatotekaHZZO_OD.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Datum OD:";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Location = new System.Drawing.Point(267, 616);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(654, 152);
            this.txtStatus.TabIndex = 27;
            this.txtStatus.Visible = false;
            // 
            // Tiskanica5
            // 
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOdznaciSve);
            this.Controls.Add(this.btnOznaciSve);
            this.Controls.Add(this.btnGenerirajTiskanicu);
            this.Controls.Add(this.rdbPromjena);
            this.Controls.Add(this.rdbOdjava);
            this.Controls.Add(this.rdbPrijava);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ListView_Ucenici);
            this.Name = "Tiskanica5";
            this.Size = new System.Drawing.Size(1149, 783);
            this.Load += new System.EventHandler(this.Tiskanica5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Tiskanica5_Load(object sender, EventArgs e)
        {
            SetFormSettings();

            LoadUcenici();
        }

        private void SetFormSettings()
        {
            if (this.rdbPrijava.Checked)
            {
                TipTiskanice = EnumTipTiskanice.Prijava;
                this.lblPrijavaOdjavaPromjena.Text = "Datum PRIJAVE:";
                RadioButton_Activate(this.rdbPrijava);
            }
            else if (this.rdbOdjava.Checked)
            {
                TipTiskanice = EnumTipTiskanice.Odjava;
                this.lblPrijavaOdjavaPromjena.Text = "Datum ODJAVE:";
                RadioButton_Activate(this.rdbOdjava);
            }
            else if (this.rdbPromjena.Checked)
            {
                TipTiskanice = EnumTipTiskanice.Promjena;
                this.lblPrijavaOdjavaPromjena.Text = "Datum PROMJENE:";
                RadioButton_Activate(this.rdbPromjena);
            }
        }

        private void RadioButton_Activate(RadioButton radioButton)
        {
            System.Drawing.Color colorDefault = System.Drawing.SystemColors.ControlText;

            // color
            this.rdbPrijava.ForeColor = colorDefault;
            this.rdbOdjava.ForeColor = colorDefault;
            this.rdbPromjena.ForeColor = colorDefault;

            // activate
            radioButton.ForeColor = System.Drawing.Color.Red;
        }

        /// <summary>
        /// Lista svih učenika
        /// </summary>
        private void LoadUcenici()
        {
            Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();
            DataTable dtUcenici = db.GetDataTable("SELECT IDUCENIK, (PREZIMEUCENIK + ' ' + IMEUCENIK) AS IMEPREZIME FROM dbo.UCENIK Where RAZRED < 20 ORDER BY IMEPREZIME");

            this.ListView_Ucenici.Items.Clear();

            foreach (DataRow drUcenik in dtUcenici.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = drUcenik["IMEPREZIME"].ToString();
                item.ToolTipText = drUcenik["IDUCENIK"].ToString();

                this.ListView_Ucenici.Items.Add(item);
            }
        }

        private void btnGenerirajTiskanicu_Click(object sender, EventArgs e)
        {
            GenerirajTiskanicu();
        }


        private void DisplayStatus(string poruka)
        {
            DisplayStatus(poruka, false);
        }

        private void DisplayStatus(string poruka, bool noviRed)
        {
            this.txtStatus.Visible = true;

            if (noviRed)
                this.txtStatus.Text += Environment.NewLine;

            this.txtStatus.Text += poruka;

            this.txtStatus.Refresh();
            this.txtStatus.Update();
        }

        private void ClearStatus()
        {
            this.txtStatus.Text = string.Empty;
        }

        private void GenerirajTiskanicu()
        {
            ClearStatus();

            // VALIDATION
            if (this.ListView_Ucenici.CheckedItems.Count == 0)
            {
                MessageBox.Show("Molimo, selektirajte barem jednog učenika!", "Tiskanica 5");
                return;
            }

            this.btnGenerirajTiskanicu.Enabled = false;

            Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtUcenikDetalji = new DataTable();

            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = new Microsoft.Office.Interop.Word.Document();

            object oMissing = System.Reflection.Missing.Value;

            try
            {
                DisplayStatus("Molimo, pričekajte kraj generiranja dokumenta!");
                DisplayStatus("----------------------------------------------------", true);

                // folder za spremanje Tiskanica 5
                string userDataFolder = Application.StartupPath + @"\USER_DATA\Tiskanica5\" + this.dtpDatumPredaje.Value.Year + "-" + this.dtpDatumPredaje.Value.Month;

                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(userDataFolder);

                if (!directory.Exists)
                    directory.Create();

                // za sve selektirane učenike
                foreach (ListViewItem lstItem in this.ListView_Ucenici.CheckedItems)
                {
                    // uzimamo ID učenika, pošto smo tu pamtili njegov ID
                    int idUcenik = int.Parse(lstItem.ToolTipText);

                    // uzimamo detalje učenika
                    dtUcenikDetalji = db.GetDataTable(string.Format("SELECT * FROM dbo.UCENIK WHERE IDUCENIK = {0}", idUcenik));

                    DisplayStatus(string.Format("{0} {1} - {2}... ",
                        dtUcenikDetalji.Rows[0]["PREZIMEUCENIK"].ToString(),
                        dtUcenikDetalji.Rows[0]["IMEUCENIK"].ToString(),
                        dtUcenikDetalji.Rows[0]["OIBUCENIK"].ToString()), true);

                    // ==============================================================================
                    // formiramo WORD dokument
                    // ==============================================================================

                    application.Visible = false;

                    // dohvaćamo WORD template
                    object documentPath = Application.StartupPath + @"\App_Data\Tiskanica_5.doc";

                    document = application.Documents.Open(ref documentPath, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    // ==============================================================================
                    // ==============================================================================
                    // popunjavamo WORD dokument
                    // ==============================================================================
                    // ==============================================================================


                    // -------------------------------------------------
                    // VAŽNI PODACI
                    // -------------------------------------------------
                    document.FormFields[163].Result = this.txtOsnovniPodaci_NazivOsobePodnositeljaZahtjeva.Text;
                    document.FormFields[164].Result = this.txtOsnovniPodaci_MjestoPredaje.Text;
                    document.FormFields[165].Result = this.dtpDatumPredaje.Value.ToShortDateString();


                    // -------------------------------------------------
                    // sekcija 1. PODATCI O OBVEZNIKU UPLATE DOPRINOSA i ostali fiksni podaci
                    // -------------------------------------------------
                    document.FormFields[36].Result = this.txtObveznikUplate_Naziv.Text;
                    document.FormFields[37].Result = this.txtObveznikUplate_Adresa.Text;
                    FillStringAndNumbers(document, this.txtObveznikUplate_OIB.Text, 38, 48);

                    // SIVO POLJE
                    // FillStringAndNumbers(document, this.txtObveznikUplate_OznakaOsnoveOsiguranja.Text, 121, 123);

                    // -------------------------------------------------
                    // sekcija 2. PODATCI O OSIGURANOJ OSOBI
                    // -------------------------------------------------
                    FillStringAndNumbers(document, dtUcenikDetalji.Rows[0]["JMBGUCENIKA"].ToString(), 49, 61);
                    FillStringAndNumbers(document, DateTime.Parse(dtUcenikDetalji.Rows[0]["DATUMRODJENJAUCENIKA"].ToString()).ToShortDateString().Replace(".", string.Empty), 62, 69);


                    switch (dtUcenikDetalji.Rows[0]["SPOLUCENIKA"].ToString())
                    {
                        case "M":
                            document.FormFields[70].CheckBox.Value = true;
                            break;
                        case "Ž":
                            document.FormFields[71].CheckBox.Value = true;
                            break;
                    }

                    FillStringAndNumbers(document, dtUcenikDetalji.Rows[0]["OIBUCENIK"].ToString(), 72, 82);
                    document.FormFields[83].Result = dtUcenikDetalji.Rows[0]["PREZIMEUCENIK"].ToString();
                    document.FormFields[84].Result = dtUcenikDetalji.Rows[0]["IMEUCENIK"].ToString();
                    document.FormFields[86].Result = dtUcenikDetalji.Rows[0]["IMERODITELJA"].ToString();
                    document.FormFields[87].Result = DateTime.Parse(dtUcenikDetalji.Rows[0]["DATUMRODJENJAUCENIKA"].ToString()).ToShortDateString();


                    string nazivPoste = db.ExecuteScalar(string.Format("SELECT NAZIVPOSTE FROM dbo.POSTANSKIBROJEVI WHERE POSTANSKIBROJ = '{0}'", dtUcenikDetalji.Rows[0]["POSTANSKIBROJ"].ToString())).ToString();

                    // ------------
                    // PREBIVALIŠTE
                    // ------------
                    FillStringAndNumbers(document, dtUcenikDetalji.Rows[0]["POSTANSKIBROJ"].ToString(), 89, 93);

                    document.FormFields[94].Result = nazivPoste;
                    document.FormFields[101].Result = dtUcenikDetalji.Rows[0]["ULICAIBROJ"].ToString();
                    document.FormFields[103].Result = dtUcenikDetalji.Rows[0]["NASELJE"].ToString();

                    // ------------
                    // BORAVAK
                    // ------------
                    FillStringAndNumbers(document, dtUcenikDetalji.Rows[0]["POSTANSKIBROJ"].ToString(), 95, 99);

                    document.FormFields[100].Result = nazivPoste;
                    document.FormFields[102].Result = dtUcenikDetalji.Rows[0]["ULICAIBROJ"].ToString();
                    document.FormFields[104].Result = dtUcenikDetalji.Rows[0]["NASELJE"].ToString();


                    switch (TipTiskanice)
                    {
                        case EnumTipTiskanice.Prijava:
                            FillStringAndNumbers(document, this.dtpPrijava.Value.ToShortDateString().Replace(".", string.Empty), 105, 112);

                            // SIVO POLJE
                            // FillStringAndNumbers(document, this.dtpPrijava.Value.ToShortDateString().Replace(".", string.Empty), 139, 146);
                            break;
                        case EnumTipTiskanice.Odjava:
                            FillStringAndNumbers(document, this.dtpPrijava.Value.ToShortDateString().Replace(".", string.Empty), 113, 120);

                            // SIVO POLJE
                            // FillStringAndNumbers(document, this.dtpPrijava.Value.ToShortDateString().Replace(".", string.Empty), 147, 154);
                            break;
                        case EnumTipTiskanice.Promjena:
                            FillStringAndNumbers(document, this.dtpPrijava.Value.ToShortDateString().Replace(".", string.Empty), 155, 162);
                            break;
                    }


                    // slučajevi osiguranja
                    document.FormFields[127].CheckBox.Value = this.CheckBox_13a1.Checked;
                    document.FormFields[128].CheckBox.Value = this.CheckBox_13a2.Checked;
                    document.FormFields[128].CheckBox.Value = this.CheckBox_13a3.Checked;
                    document.FormFields[130].CheckBox.Value = this.CheckBox_13a4.Checked;
                    document.FormFields[131].CheckBox.Value = this.CheckBox_13a5.Checked;
                    document.FormFields[132].CheckBox.Value = this.CheckBox_13a6.Checked;
                    document.FormFields[133].CheckBox.Value = this.CheckBox_13a7.Checked;
                    document.FormFields[134].CheckBox.Value = this.CheckBox_13a8.Checked;
                    document.FormFields[135].CheckBox.Value = this.CheckBox_13a9.Checked;
                    document.FormFields[136].CheckBox.Value = this.CheckBox_13a10.Checked;
                    document.FormFields[137].CheckBox.Value = this.CheckBox_13a11.Checked;
                    document.FormFields[138].CheckBox.Value = this.CheckBox_13a12.Checked;


                    // ==============================================================================
                    // spremamo WORD dokument
                    // ==============================================================================
                    string imePrezime = dtUcenikDetalji.Rows[0]["PREZIMEUCENIK"].ToString() + "_" + dtUcenikDetalji.Rows[0]["IMEUCENIK"].ToString();
                    string oib = dtUcenikDetalji.Rows[0]["OIBUCENIK"].ToString();

                    try
                    {

                        object documentPathSave = userDataFolder + @"\" + TipTiskanice.ToString() + "_" + imePrezime + "_" + oib + "_Tiskanica_5_" + string.Format("{0:yyyyMMdd}", DateTime.Today) + ".doc";

                        document.SaveAs(ref documentPathSave, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                        DisplayStatus("OK");
                    }
                    catch (System.Exception exception)
                    {
                        DisplayStatus("GREŠKA");
                        throw exception;
                    }
                    finally
                    {
                        //document.Close(ref oMissing, ref oMissing, ref oMissing);
                        ((Microsoft.Office.Interop.Word._Document)document).Close(ref oMissing, ref oMissing, ref oMissing);
                    }
                } // foreach...

                System.Diagnostics.Process.Start("explorer.exe", userDataFolder);
            }
            finally
            {
                // zatvori word application
                //application.Quit(ref oMissing, ref oMissing, ref oMissing);
                ((Microsoft.Office.Interop.Word._Application)application).Quit(ref oMissing, ref oMissing, ref oMissing);

                // and turn off the IOleMessageFilter.
                // Fix for 'Application is Busy' and 'Call was Rejected By Callee' Errors
                MessageFilter.Revoke();
                

                // za svaki slučaj
                if (document != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(document);

                if (application != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(application);


                // isprazni varijable
                document = null;
                application = null;

                // force-amo GarbageCollector (za svaki slučaj)
                GC.Collect();

                DisplayStatus("----------------------------------------------------", true);
                DisplayStatus("Generiranje završeno!", true);

                this.btnGenerirajTiskanicu.Enabled = true;

            }
        }

        /// <summary>
        /// Ova funkcija se koristi za popunjavanje polja poput OIB-a, gdje se taj podatak dijeli na više čelija - tj. 11.
        /// Npr.: od polja 72 (fieldStart) do polja 82 (fieldEnd) popuni podatke iz stringa "value".
        /// </summary>
        private void FillStringAndNumbers(Microsoft.Office.Interop.Word.Document document, string value, int fieldStart, int fieldEnd)
        {
            int index = 0;

            for (int i = fieldStart; i <= fieldEnd; i++)
            {
                try
                {
                    document.FormFields[i].Result = value.Substring(index, 1);
                }
                catch (Exception)
                {
                    // Ovaj Catch je oebavezan, za svaku slučaj ako recimo korisnik upiše OIB od 5 znakova.
                    // Naravno, podatak nije točan, ali aplikacija ne smije pucati.
                }

                index++;
            }
        }

        private void btnOznaciSve_Click(object sender, EventArgs e)
        {
            ListView_CheckUncheck(true);
        }

        private void btnOdznaciSve_Click(object sender, EventArgs e)
        {
            ListView_CheckUncheck(false);
        }

        private void ListView_CheckUncheck(bool isChecked)
        {
            foreach (ListViewItem item in this.ListView_Ucenici.Items)
                item.Checked = isChecked;
        }

        private void rdbPrijava_CheckedChanged(object sender, EventArgs e)
        {
            SetFormSettings();
        }

        private void rdbOdjava_CheckedChanged(object sender, EventArgs e)
        {
            SetFormSettings();
        }

        private void rdbPromjena_CheckedChanged(object sender, EventArgs e)
        {
            SetFormSettings();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
            }
        }

        private void btnDatotekaHZZO_Generiraj_Click(object sender, EventArgs e)
        {
            KORISNIKDataSet dsKorisnik = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dsKorisnik);
            string korisnikOIB = dsKorisnik.KORISNIK.Rows[0]["KORISNIKOIB"].ToString();


            // GENERIRANJE datoteke "<OIB_Korisnika>_t5.txt"
            string fileName = string.Format("{0}_t5.txt", korisnikOIB);

            // prikupljanje OIB-ova odabranih učenika u kontroli...
            StringBuilder odabraniUcenici = new StringBuilder();

            foreach (ListViewItem lstItem in this.ListView_Ucenici.CheckedItems)
            {
                // uzimamo ID učenika, pošto smo tu pamtili njegov ID
                if (!string.IsNullOrEmpty(odabraniUcenici.ToString()))
                    odabraniUcenici.Append(",");

                odabraniUcenici.Append(lstItem.ToolTipText);
            }

            if (odabraniUcenici.Length == 0)
                return;

            // uzimanje podataka tj. OIB-ove iz baze...
            Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();
            DataTable dtUcenici = db.GetDataTable(string.Format("SELECT PREZIMEUCENIK As Prezime, IMEUCENIK As Ime, DATUMRODJENJAUCENIKA As Rodenje, OIBUCENIK FROM dbo.UCENIK WHERE IDUCENIK IN ({0})",
                odabraniUcenici.ToString()));

            // spremanje datoteke...
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = fileName;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8);

                try
                {
                    streamWriter.AutoFlush = true;
                    DateTime datum = new DateTime();
                    // priprema za pisanje u datoteku...
                    foreach (DataRow drRow in dtUcenici.Rows)
                    {
                        datum = Convert.ToDateTime(drRow["Rodenje"]);
                        // i upisivanje podataka u formatu "89413254244:01.05.2012:05.12.2012"
                        streamWriter.WriteLine(string.Format("{3}:{4}:{5:dd.MM.yyyy}:{0}:{1:dd.MM.yyyy}:{2:dd.MM.yyyy}",
                            drRow["OIBUCENIK"].ToString(),
                            this.dtpDatotekaHZZO_OD.Value,
                            this.dtpDatotekaHZZO_DO.Value,
                            drRow["Prezime"].ToString(),
                            drRow["Ime"].ToString(),
                            datum.Date));
                    }

                    MessageBox.Show(string.Format("Datoteka '{0}' je uspješno spremljena!", saveDialog.FileName));

                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Greška u spremanju datoteke '{0}'!", saveDialog.FileName));
                    throw ex;
                }
                finally
                {
                    streamWriter.Close();
                }
            }
        }
    }

    // Fix for 'Application is Busy' and 'Call was Rejected By Callee' Errors
    public class MessageFilter : IOleMessageFilter
    {
        //
        // Class containing the IOleMessageFilter
        // thread error-handling functions.

        // Start the filter.
        public static void Register()
        {
            IOleMessageFilter newFilter = new MessageFilter();
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(newFilter, out oldFilter);
        }

        // Done with the filter, close it.
        public static void Revoke()
        {
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(null, out oldFilter);
        }

        //
        // IOleMessageFilter functions.
        // Handle incoming thread requests.
        int IOleMessageFilter.HandleInComingCall(int dwCallType,
          System.IntPtr hTaskCaller, int dwTickCount, System.IntPtr
          lpInterfaceInfo)
        {
            //Return the flag SERVERCALL_ISHANDLED.
            return 0;
        }

        // Thread call was rejected, so try again.
        int IOleMessageFilter.RetryRejectedCall(System.IntPtr
          hTaskCallee, int dwTickCount, int dwRejectType)
        {
            if (dwRejectType == 2)
            // flag = SERVERCALL_RETRYLATER.
            {
                // Retry the thread call immediately if return >=0 & 
                // <100.
                return 99;
            }
            // Too busy; cancel call.
            return -1;
        }

        int IOleMessageFilter.MessagePending(System.IntPtr hTaskCallee,
          int dwTickCount, int dwPendingType)
        {
            //Return the flag PENDINGMSG_WAITDEFPROCESS.
            return 2;
        }

        // Implement the IOleMessageFilter interface.
        [DllImport("Ole32.dll")]
        private static extern int
          CoRegisterMessageFilter(IOleMessageFilter newFilter, out 
          IOleMessageFilter oldFilter);
    }

    [ComImport(), Guid("00000016-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    interface IOleMessageFilter
    {
        [PreserveSig]
        int HandleInComingCall(
            int dwCallType,
            IntPtr hTaskCaller,
            int dwTickCount,
            IntPtr lpInterfaceInfo);

        [PreserveSig]
        int RetryRejectedCall(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwRejectType);

        [PreserveSig]
        int MessagePending(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwPendingType);
    }

}
