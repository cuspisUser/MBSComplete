using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace EVModule.Ev
{
    [SmartPart]
    public class OdabirUvjetaEvidencija : UserControl
    {
        public int[] ar;
        public decimal brojsati;
        private IContainer components;
        public int godina;
        
        public int mjesec;

        public OdabirUvjetaEvidencija()
        {
            base.Load += new EventHandler(this.UserControl1_Load);
            this.ar = new int[0x20];
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            IEnumerator enumerator = null;
            int index = 0;
            do
            {
                this.ar[index] = 0;
                index++;
            }
            while (index <= 0x1f);
            index = 0;
            try
            {
                enumerator = this.ListBox1.SelectedItems.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string[] strArray = Conversions.ToString(enumerator.Current).Split(new char[] { '-' });
                    this.ar[index] = Conversions.ToInteger(strArray[0]);
                    index++;
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.brojsati = Conversions.ToDecimal(this.UltraNumericEditor1.Value);
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.S_OD_REKAP_NETODataSet1 = new S_OD_REKAP_NETODataSet();
            this.S_od_rekap_brutoDataSet1 = new s_od_rekap_brutoDataSet();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._BrutoUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._BrutoAutoHideControl = new AutoHideControl();
            this.Button1 = new Button();
            this.RadioButton1 = new RadioButton();
            this.RadioButton2 = new RadioButton();
            this.RadioButton3 = new RadioButton();
            this.bop = new RadioButton();
            this.bof = new RadioButton();
            this.go = new RadioButton();
            this.pd = new RadioButton();
            this.nepd = new RadioButton();
            this.rd = new RadioButton();
            this.Blagdan = new RadioButton();
            this.Button2 = new Button();
            this.ListBox1 = new ListBox();
            this.subote = new CheckBox();
            this.nedjelje = new CheckBox();
            this.chkMedju = new RadioButton();
            this.UltraNumericEditor1 = new UltraNumericEditor();
            this.S_OD_REKAP_NETODataSet1.BeginInit();
            this.S_od_rekap_brutoDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            ((ISupportInitialize) this.UltraNumericEditor1).BeginInit();
            this.SuspendLayout();
            this.S_OD_REKAP_NETODataSet1.DataSetName = "S_OD_REKAP_NETODataSet";
            this.S_od_rekap_brutoDataSet1.DataSetName = "s_od_rekap_brutoDataSet";
            this.UltraDockManager1.HostControl = this;
            this._BrutoUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._BrutoUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._BrutoUnpinnedTabAreaLeft.Name = "_BrutoUnpinnedTabAreaLeft";
            this._BrutoUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x1eb);
            this._BrutoUnpinnedTabAreaLeft.TabIndex = 7;
            this._BrutoUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._BrutoUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x220, 0);
            this._BrutoUnpinnedTabAreaRight.Name = "_BrutoUnpinnedTabAreaRight";
            this._BrutoUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x1eb);
            this._BrutoUnpinnedTabAreaRight.TabIndex = 8;
            this._BrutoUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._BrutoUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._BrutoUnpinnedTabAreaTop.Name = "_BrutoUnpinnedTabAreaTop";
            this._BrutoUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x220, 0);
            this._BrutoUnpinnedTabAreaTop.TabIndex = 9;
            this._BrutoUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._BrutoUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x1eb);
            this._BrutoUnpinnedTabAreaBottom.Name = "_BrutoUnpinnedTabAreaBottom";
            this._BrutoUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._BrutoUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x220, 0);
            this._BrutoUnpinnedTabAreaBottom.TabIndex = 10;
            this._BrutoAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._BrutoAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._BrutoAutoHideControl.Name = "_BrutoAutoHideControl";
            this._BrutoAutoHideControl.Owner = this.UltraDockManager1;
            this._BrutoAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._BrutoAutoHideControl.TabIndex = 11;
            this.Button1.Location = new System.Drawing.Point(0x16b, 0x1c6);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(0x4b, 0x17);
            this.Button1.TabIndex = 0x10;
            this.Button1.Text = "Potvrdi";
            this.Button1.UseVisualStyleBackColor = true;
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            this.RadioButton1.Location = new System.Drawing.Point(0x12, 15);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(0x45, 0x11);
            this.RadioButton1.TabIndex = 0x11;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "Smjena 1";
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new System.Drawing.Point(0x12, 0x27);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new System.Drawing.Size(0x45, 0x11);
            this.RadioButton2.TabIndex = 0x12;
            this.RadioButton2.Text = "Smjena 2";
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.RadioButton3.AutoSize = true;
            this.RadioButton3.Location = new System.Drawing.Point(0x12, 0x3e);
            this.RadioButton3.Name = "RadioButton3";
            this.RadioButton3.Size = new System.Drawing.Size(0xad, 0x11);
            this.RadioButton3.TabIndex = 0x13;
            this.RadioButton3.Text = "Dvokratno (smjena1 / smjena2)";
            this.RadioButton3.UseVisualStyleBackColor = true;
            this.bop.AutoSize = true;
            this.bop.Location = new System.Drawing.Point(0x12, 0x6a);
            this.bop.Name = "bop";
            this.bop.Size = new System.Drawing.Size(130, 0x11);
            this.bop.TabIndex = 20;
            this.bop.Text = "Bolovanje poslodavac";
            this.bop.UseVisualStyleBackColor = true;
            this.bof.AutoSize = true;
            this.bof.Location = new System.Drawing.Point(0x12, 0x81);
            this.bof.Name = "bof";
            this.bof.Size = new System.Drawing.Size(0x60, 0x11);
            this.bof.TabIndex = 0x15;
            this.bof.Text = "Bolovanje fond";
            this.bof.UseVisualStyleBackColor = true;
            this.go.AutoSize = true;
            this.go.Location = new System.Drawing.Point(0x12, 0x98);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(0x5e, 0x11);
            this.go.TabIndex = 0x16;
            this.go.Text = "Godišnji odmor";
            this.go.UseVisualStyleBackColor = true;
            this.pd.AutoSize = true;
            this.pd.Location = new System.Drawing.Point(0x12, 0xaf);
            this.pd.Name = "pd";
            this.pd.Size = new System.Drawing.Size(0x5f, 0x11);
            this.pd.TabIndex = 0x17;
            this.pd.Text = "Plaćeni dopust";
            this.pd.UseVisualStyleBackColor = true;
            this.nepd.AutoSize = true;
            this.nepd.Location = new System.Drawing.Point(0x12, 0xc6);
            this.nepd.Name = "nepd";
            this.nepd.Size = new System.Drawing.Size(0x6c, 0x11);
            this.nepd.TabIndex = 0x18;
            this.nepd.Text = "Neplaćeni dopust";
            this.nepd.UseVisualStyleBackColor = true;
            this.rd.AutoSize = true;
            this.rd.Location = new System.Drawing.Point(0x12, 0xdd);
            this.rd.Name = "rd";
            this.rd.Size = new System.Drawing.Size(0x5e, 0x11);
            this.rd.TabIndex = 0x19;
            this.rd.Text = "Rodiljni dopust";
            this.rd.UseVisualStyleBackColor = true;
            this.Blagdan.AutoSize = true;
            this.Blagdan.Location = new System.Drawing.Point(0x12, 0x54);
            this.Blagdan.Name = "Blagdan";
            this.Blagdan.Size = new System.Drawing.Size(0x40, 0x11);
            this.Blagdan.TabIndex = 0x1b;
            this.Blagdan.TabStop = true;
            this.Blagdan.Text = "Blagdan";
            this.Blagdan.UseVisualStyleBackColor = true;
            this.Button2.Location = new System.Drawing.Point(0x1ca, 0x1c6);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(0x4b, 0x17);
            this.Button2.TabIndex = 0x1c;
            this.Button2.Text = "Odustani";
            this.Button2.UseVisualStyleBackColor = true;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(0xc5, 50);
            this.ListBox1.MultiColumn = true;
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.SelectionMode = SelectionMode.MultiSimple;
            this.ListBox1.Size = new System.Drawing.Size(0x150, 0x170);
            this.ListBox1.TabIndex = 0x1d;
            this.subote.AutoSize = true;
            this.subote.Location = new System.Drawing.Point(0x134, 0x1b);
            this.subote.Name = "subote";
            this.subote.Size = new System.Drawing.Size(0x5b, 0x11);
            this.subote.TabIndex = 30;
            this.subote.Text = "Ukloni subote";
            this.subote.UseVisualStyleBackColor = true;
            this.nedjelje.AutoSize = true;
            this.nedjelje.Location = new System.Drawing.Point(0x1ad, 0x1b);
            this.nedjelje.Name = "nedjelje";
            this.nedjelje.Size = new System.Drawing.Size(0x5f, 0x11);
            this.nedjelje.TabIndex = 0x1f;
            this.nedjelje.Text = "Ukloni nedjelje";
            this.nedjelje.UseVisualStyleBackColor = true;
            this.chkMedju.AutoSize = true;
            this.chkMedju.Location = new System.Drawing.Point(0x69, 15);
            this.chkMedju.Name = "chkMedju";
            this.chkMedju.Size = new System.Drawing.Size(0x56, 0x11);
            this.chkMedju.TabIndex = 0x20;
            this.chkMedju.Text = "Međusmjena";
            this.chkMedju.UseVisualStyleBackColor = true;
            this.chkMedju.Visible = false;
            this.UltraNumericEditor1.DisplayStyle = EmbeddableElementDisplayStyle.VisualStudio2005;
            this.UltraNumericEditor1.FormatString = "#,##0.00";
            this.UltraNumericEditor1.Location = new System.Drawing.Point(0xc5, 11);
            this.UltraNumericEditor1.MaskInput = "nnnnnnnnnn.nn";
            this.UltraNumericEditor1.Name = "UltraNumericEditor1";
            this.UltraNumericEditor1.NumericType = NumericType.Double;
            this.UltraNumericEditor1.Size = new System.Drawing.Size(0x43, 0x15);
            this.UltraNumericEditor1.TabIndex = 0x38;
            this.UltraNumericEditor1.TabNavigation = MaskedEditTabNavigation.NextControl;
            this.UltraNumericEditor1.Visible = false;
            this.Controls.Add(this._BrutoAutoHideControl);
            this.Controls.Add(this.UltraNumericEditor1);
            this.Controls.Add(this.chkMedju);
            this.Controls.Add(this.nedjelje);
            this.Controls.Add(this.subote);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Blagdan);
            this.Controls.Add(this.rd);
            this.Controls.Add(this.nepd);
            this.Controls.Add(this.pd);
            this.Controls.Add(this.go);
            this.Controls.Add(this.bof);
            this.Controls.Add(this.bop);
            this.Controls.Add(this.RadioButton3);
            this.Controls.Add(this.RadioButton2);
            this.Controls.Add(this.RadioButton1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this._BrutoUnpinnedTabAreaTop);
            this.Controls.Add(this._BrutoUnpinnedTabAreaBottom);
            this.Controls.Add(this._BrutoUnpinnedTabAreaLeft);
            this.Controls.Add(this._BrutoUnpinnedTabAreaRight);
            this.Name = "OdabirUvjetaEvidencija";
            this.Size = new System.Drawing.Size(0x220, 0x1eb);
            this.S_OD_REKAP_NETODataSet1.EndInit();
            this.S_od_rekap_brutoDataSet1.EndInit();

            this.Button1.Click += new EventHandler(Button1_Click);
            this.Button2.Click += new EventHandler(Button2_Click);
            this.ListBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);
            this.nedjelje.CheckedChanged += new EventHandler(nedjelje_CheckedChanged);
            this.subote.CheckedChanged += new EventHandler(subote_CheckedChanged);

            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            ((ISupportInitialize) this.UltraNumericEditor1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void nedjelje_CheckedChanged(object sender, EventArgs e)
        {
            this.Puni();
        }

        private void obracun_ValueChanged(object sender, EventArgs e)
        {
        }

        public void Puni()
        {
            this.ListBox1.Items.Clear();
            int num = 1;
            do
            {
                if (Information.IsDate(Conversions.ToString(num) + "/" + Conversions.ToString(this.mjesec) + "/" + Conversions.ToString(this.godina)))
                {
                    string str = string.Empty;
                    if (DateAndTime.DateSerial(this.godina, this.mjesec, num).DayOfWeek == DayOfWeek.Friday)
                    {
                        str = "Petak";
                    }
                    else if (DateAndTime.DateSerial(this.godina, this.mjesec, num).DayOfWeek == DayOfWeek.Monday)
                    {
                        str = "Ponedjeljak";
                    }
                    else if (DateAndTime.DateSerial(this.godina, this.mjesec, num).DayOfWeek == DayOfWeek.Saturday)
                    {
                        str = "Subota";
                    }
                    else if (DateAndTime.DateSerial(this.godina, this.mjesec, num).DayOfWeek == DayOfWeek.Sunday)
                    {
                        str = "Nedjelja";
                    }
                    else if (DateAndTime.DateSerial(this.godina, this.mjesec, num).DayOfWeek == DayOfWeek.Thursday)
                    {
                        str = "Cetvrtak";
                    }
                    else if (DateAndTime.DateSerial(this.godina, this.mjesec, num).DayOfWeek == DayOfWeek.Tuesday)
                    {
                        str = "Utorak";
                    }
                    else if (DateAndTime.DateSerial(this.godina, this.mjesec, num).DayOfWeek == DayOfWeek.Wednesday)
                    {
                        str = "Srijeda";
                    }
                    if (str == "Subota")
                    {
                        if (!this.subote.Checked)
                        {
                            this.ListBox1.Items.Add(Conversions.ToString(num) + "-" + str);
                        }
                    }
                    else if (str == "Nedjelja")
                    {
                        if (!this.nedjelje.Checked)
                        {
                            this.ListBox1.Items.Add(Conversions.ToString(num) + "-" + str);
                        }
                    }
                    else
                    {
                        this.ListBox1.Items.Add(Conversions.ToString(num) + "-" + str);
                    }
                }
                num++;
            }
            while (num <= 0x1f);
        }

        private void subote_CheckedChanged(object sender, EventArgs e)
        {
            this.Puni();
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UltraNumericEditor1_GotFocus(object sender, EventArgs e)
        {
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                SMJENESelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<SMJENESelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row == null)
                {
                }
            }
        }

        private void UltraTextEditor2_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                SMJENESelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<SMJENESelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row == null)
                {
                }
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.Puni();
        }

        private AutoHideControl _BrutoAutoHideControl;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaBottom;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaLeft;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaRight;

        private UnpinnedTabArea _BrutoUnpinnedTabAreaTop;

        public RadioButton Blagdan;

        public RadioButton bof;

        public RadioButton bop;

        private Button Button1;

        private Button Button2;

        private RadioButton chkMedju;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        public RadioButton go;

        public ListBox ListBox1;

        public CheckBox nedjelje;

        public RadioButton nepd;

        public RadioButton pd;

        public RadioButton RadioButton1;

        public RadioButton RadioButton2;

        public RadioButton RadioButton3;

        public RadioButton rd;

        private s_od_rekap_brutoDataSet S_od_rekap_brutoDataSet1;

        private S_OD_REKAP_NETODataSet S_OD_REKAP_NETODataSet1;

        private CheckBox subote;

        private UltraDockManager UltraDockManager1;

        private UltraNumericEditor UltraNumericEditor1;
    }
}

