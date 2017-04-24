
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.SmartParts;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace Obracun
{

    public class frmEleBrisiSvi : Form
    {
        public ObracunSmartPart __Parent_Obracun;
        public string _vrsta_elementa;
        private IContainer components { get; set; }

        public frmEleBrisiSvi()
        {
            base.Load += new EventHandler(this.frmEleBrisiSvi_Load);
            this.InitializeComponent();
        }

        private bool Brisi()
        {
            bool flag = false;
            string str = string.Empty;
            this.cbSifra.Enabled = false;
            if (!this.ProvjeraPrijeSpremanja())
            {
                this.cbSifra.Enabled = true;
                return false;
            }
            RowEnumerator enumerator = this.__Parent_Obracun.UltraGrid1.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string str3 = string.Empty;
                UltraGridRow current = enumerator.Current;
                if (Conversions.ToBoolean(current.Cells["oznacen"].Value))
                {
                    DataView defaultView = this.__Parent_Obracun.ObracunDataSet1.ObracunElementi.DefaultView;
                    defaultView.RowFilter = string.Format("IDRADNIK = {0} AND IDELEMENT = {1}", RuntimeHelpers.GetObjectValue(current.Cells["IDRADNIK"].Value), RuntimeHelpers.GetObjectValue(this.cbSifra.Value));
                    if (defaultView.Count > 0)
                    {
                        str3 = defaultView[0]["IDRADNIK"].ToString();
                        defaultView[0].Delete();
                    }
                }
                if (str != "")
                {
                    str = str + ", ";
                }
                str = str + str3;
            }
            if (str == "")
            {
                MessageBox.Show("Element_nije_pronađen_ni_na_jednom_označenom_zaposleniku");
            }
            else
            {
                MessageBox.Show("Element_je_uspješno_obrisan_označenim_zaposlenicima");
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            return flag;
        }

        private void cbSifra_GotFocus(object sender, EventArgs e)
        {
            this.cbSifra.ToggleDropdown();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmEleBrisiSvi_Load(object sender, EventArgs e)
        {
            this.NapuniElemente();
            this.cbSifra.Select();
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ELEMENT", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVRSTAELEMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTAELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSNOVAOSIGURANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSNOVAOSIGURANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZDOBLJESESMIJEPREKLAPATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTOTAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZBRAJASATEUFONDSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTAVLJAMZPZSVIMVIRMANIMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EL");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEleBrisiSvi));
            this.lblSifEle = new Infragistics.Win.Misc.UltraLabel();
            this.cbSifra = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ElementDataSet1 = new Placa.ELEMENTDataSet();
            this.Naziv = new Infragistics.Win.Misc.UltraLabel();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton4 = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSifEle
            // 
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.lblSifEle.Appearance = appearance12;
            this.lblSifEle.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblSifEle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSifEle.Location = new System.Drawing.Point(17, 19);
            this.lblSifEle.Name = "lblSifEle";
            this.lblSifEle.Size = new System.Drawing.Size(123, 23);
            this.lblSifEle.TabIndex = 24;
            this.lblSifEle.Tag = "";
            this.lblSifEle.Text = "Bruto element:";
            this.lblSifEle.UseAppStyling = false;
            // 
            // cbSifra
            // 
            appearance11.BackColor = System.Drawing.Color.Lavender;
            appearance11.FontData.BoldAsString = "True";
            this.cbSifra.Appearance = appearance11;
            appearance13.TextHAlignAsString = "Center";
            this.cbSifra.ButtonAppearance = appearance13;
            appearance14.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance14;
            editorButton1.Text = "...";
            this.cbSifra.ButtonsRight.Add(editorButton1);
            this.cbSifra.CausesValidation = false;
            this.cbSifra.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbSifra.DataSource = this.ElementDataSet1.ELEMENT;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbSifra.DisplayLayout.Appearance = appearance15;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(148, 0);
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(663, 0);
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn17.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17});
            ultraGridBand1.UseRowLayout = true;
            this.cbSifra.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbSifra.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbSifra.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.GroupByBox.Appearance = appearance16;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.BandLabelAppearance = appearance17;
            this.cbSifra.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance.BackColor2 = System.Drawing.SystemColors.Control;
            appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbSifra.DisplayLayout.GroupByBox.PromptAppearance = appearance;
            this.cbSifra.DisplayLayout.MaxColScrollRegions = 1;
            this.cbSifra.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSifra.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            appearance3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbSifra.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.cbSifra.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbSifra.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbSifra.DisplayLayout.Override.CellAppearance = appearance5;
            this.cbSifra.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cbSifra.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.cbSifra.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.cbSifra.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.cbSifra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbSifra.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            this.cbSifra.DisplayLayout.Override.RowAppearance = appearance8;
            this.cbSifra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbSifra.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.cbSifra.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cbSifra.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cbSifra.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cbSifra.DisplayMember = "NAZIVELEMENT";
            this.cbSifra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbSifra.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbSifra.DropDownWidth = 400;
            this.cbSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbSifra.LimitToList = true;
            this.cbSifra.Location = new System.Drawing.Point(120, 20);
            this.cbSifra.MaxDropDownItems = 20;
            this.cbSifra.Name = "cbSifra";
            this.cbSifra.Size = new System.Drawing.Size(467, 22);
            this.cbSifra.TabIndex = 160;
            this.cbSifra.UseAppStyling = false;
            this.cbSifra.ValueMember = "IDELEMENT";
            this.cbSifra.GotFocus += new System.EventHandler(this.cbSifra_GotFocus);
            // 
            // ElementDataSet1
            // 
            this.ElementDataSet1.DataSetName = "ELEMENTDataSet";
            this.ElementDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // Naziv
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.TextVAlignAsString = "Middle";
            this.Naziv.Appearance = appearance10;
            this.Naziv.BackColorInternal = System.Drawing.SystemColors.ControlLight;
            this.Naziv.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Naziv.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Naziv.Location = new System.Drawing.Point(184, 56);
            this.Naziv.Name = "Naziv";
            this.Naziv.Size = new System.Drawing.Size(450, 22);
            this.Naziv.TabIndex = 173;
            this.Naziv.Tag = "NAZIVELEMENT";
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.UltraButton3);
            this.UltraGroupBox1.Controls.Add(this.UltraButton4);
            this.UltraGroupBox1.Controls.Add(this.lblSifEle);
            this.UltraGroupBox1.Controls.Add(this.cbSifra);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(625, 95);
            this.UltraGroupBox1.TabIndex = 176;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraButton3
            // 
            this.UltraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton3.Location = new System.Drawing.Point(485, 57);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(128, 23);
            this.UltraButton3.TabIndex = 177;
            this.UltraButton3.Text = "Odustani";
            this.UltraButton3.UseAppStyling = false;
            this.UltraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton3.Click += new System.EventHandler(this.UltraButton3_Click);
            // 
            // UltraButton4
            // 
            this.UltraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.UltraButton4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton4.Location = new System.Drawing.Point(352, 57);
            this.UltraButton4.Name = "UltraButton4";
            this.UltraButton4.Size = new System.Drawing.Size(123, 23);
            this.UltraButton4.TabIndex = 176;
            this.UltraButton4.Text = "Spremi";
            this.UltraButton4.UseAppStyling = false;
            this.UltraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton4.Click += new System.EventHandler(this.UltraButton4_Click);
            // 
            // frmEleBrisiSvi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(625, 95);
            this.Controls.Add(this.UltraGroupBox1);
            this.Controls.Add(this.Naziv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEleBrisiSvi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brisanje elementa označenim zaposlenicima";
            ((System.ComponentModel.ISupportInitialize)(this.cbSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void NapuniElemente()
        {
            ELEMENTDataAdapter adapter = new ELEMENTDataAdapter();
            this.ElementDataSet1.Clear();
            adapter.FillByIDVRSTAELEMENTA(this.ElementDataSet1, Conversions.ToShort(this._vrsta_elementa));
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

        private bool ProvjeraPrijeSpremanja()
        {
            if (this.cbSifra.Value == null)
            {
                string str = string.Format("Polje element obavezno za unos! Molimo ispravite unos! ", Conversions.ToString(Interaction.IIf(Conversions.ToDouble(this._vrsta_elementa) == 1.0, "Neto", "Bruto")));
                return false;
            }
            return true;
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void UltraButton4_Click(object sender, EventArgs e)
        {
            if (!this.Brisi())
            {
            }
        }

        private UltraCombo cbSifra;

        private ELEMENTDataSet ElementDataSet1;

        public UltraLabel lblSifEle;

        private UltraLabel Naziv;

        private UltraButton UltraButton3;

        private UltraButton UltraButton4;

        private UltraGroupBox UltraGroupBox1;
    }
}

