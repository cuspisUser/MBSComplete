namespace NetAdvantage.SmartParts
{
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.VisualBasic;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class UnosNazivaBaze : UserControl
    {
        private IContainer components;
        private sp_maticni_kartonDataAdapter da;
        private sp_maticni_kartonDataSet ds;
        private DatabaseCollection popisbaza;

        public UnosNazivaBaze()
        {
            base.Load += new EventHandler(this.UnosNazivaBaze_Load);
            this.da = new sp_maticni_kartonDataAdapter();
            this.ds = new sp_maticni_kartonDataSet();
            this.InitializeComponent();
        }

        public bool Baza_valid(string s)
        {
            bool flag = false;
            int num2 = this.popisbaza.Count - 1;
            int num = 0;
            while (num <= num2)
            {
                if (s.ToUpper() == this.popisbaza[num].Name.ToUpper())
                {
                    return false;
                }
                return true;
            }
            return flag;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.PregledRadnikaDataSet1 = new PregledRadnikaDataSet();
            this.Baze1BindingSource = new BindingSource(this.components);
            this.Baze1 = new Baze();
            this.UltraButton1 = new UltraButton();
            this.UltraTextEditor1 = new UltraTextEditor();
            this.UltraLabel1 = new UltraLabel();
            this.UltraButton2 = new UltraButton();
            this.PregledRadnikaDataSet1.BeginInit();
            ((ISupportInitialize) this.Baze1BindingSource).BeginInit();
            this.Baze1.BeginInit();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            this.SuspendLayout();
            this.PregledRadnikaDataSet1.DataSetName = "PregledRadnikaDataSet";
            this.Baze1BindingSource.DataSource = this.Baze1;
            this.Baze1BindingSource.Position = 0;
            this.Baze1.DataSetName = "Baze";
            this.Baze1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            System.Drawing.Point point = new System.Drawing.Point(0x114, 0x29);
            this.UltraButton1.Location = point;
            this.UltraButton1.Name = "UltraButton1";
            Size size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton1.Size = size;
            this.UltraButton1.TabIndex = 1;
            this.UltraButton1.Text = "Potvrdi";
            this.UltraButton1.UseAppStyling = false;
            point = new System.Drawing.Point(0x71, 14);
            this.UltraTextEditor1.Location = point;
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            size = new System.Drawing.Size(0x14d, 0x15);
            this.UltraTextEditor1.Size = size;
            this.UltraTextEditor1.TabIndex = 0;
            this.UltraTextEditor1.Text = "UltraTextEditor1";
            this.UltraTextEditor1.UseAppStyling = false;
            point = new System.Drawing.Point(3, 0x11);
            this.UltraLabel1.Location = point;
            this.UltraLabel1.Name = "UltraLabel1";
            size = new System.Drawing.Size(0x6a, 0x17);
            this.UltraLabel1.Size = size;
            this.UltraLabel1.TabIndex = 3;
            this.UltraLabel1.Text = "Unesite naziv baze:";
            this.UltraLabel1.UseAppStyling = false;
            point = new System.Drawing.Point(0x16b, 0x29);
            this.UltraButton2.Location = point;
            this.UltraButton2.Name = "UltraButton2";
            size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton2.Size = size;
            this.UltraButton2.TabIndex = 2;
            this.UltraButton2.Text = "Odustani";
            this.UltraButton2.UseAppStyling = false;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.UltraButton2);
            this.Controls.Add(this.UltraLabel1);
            this.Controls.Add(this.UltraTextEditor1);
            this.Controls.Add(this.UltraButton1);
            this.Name = "UnosNazivaBaze";
            size = new System.Drawing.Size(0x1d1, 0x4a);
            this.Size = size;

            this.UltraButton1.Click += new EventHandler(this.UltraButton1_Click);
            this.UltraButton2.Click += new EventHandler(this.UltraButton2_Click);

            this.PregledRadnikaDataSet1.EndInit();
            ((ISupportInitialize) this.Baze1BindingSource).EndInit();
            this.Baze1.EndInit();
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            if (this.Baza_valid(this.UltraTextEditor1.Text))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.ParentForm.Close();
            }
            else
            {
                Interaction.MsgBox("Zadana baza postoji!", MsgBoxStyle.OkOnly, null);
            }
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void UnosNazivaBaze_Load(object sender, EventArgs e)
        {
            this.UltraTextEditor1.Text = "";
            this.UltraTextEditor1.SelectAll();
        }

        public DatabaseCollection Baze
        {
            set
            {
                this.popisbaza = value;
            }
        }

        internal Baze Baze1;

        internal BindingSource Baze1BindingSource;

        public string NazivBaze
        {
            get
            {
                if (this.ParentForm.DialogResult == DialogResult.OK)
                {
                    return this.UltraTextEditor1.Text.ToUpper();
                }
                return null;
            }
        }

        internal PregledRadnikaDataSet PregledRadnikaDataSet1;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraLabel UltraLabel1;

        internal UltraTextEditor UltraTextEditor1;
    }
}

