namespace Ucenici
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmPregledObracuna : Form
    {
        private IContainer components { get; set; }

        [DebuggerNonUserCode]
        public frmPregledObracuna()
        {
            base.Load += new EventHandler(this.frmPregledRadnika_Load_1);
            this.InitializeComponent();
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

        private void frmPregledRadnika_Load_1(object sender, EventArgs e)
        {
            new UCENIKOBRACUNDataAdapter().Fill(this.UcenikobracunDataSet1);
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UCENIKOBRACUN", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UCOBRMJESEC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UCOBRGODINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UCOBROPIS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICAPODANU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVANZARSM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UCOBRMJESEC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UCOBRGODINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDUCENIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIMEUCENIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IMEUCENIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJDANAPRAKSE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNOSNOVICEPRAKSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZRED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ODJELJENJE");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledObracuna));
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UcenikobracunDataSet1 = new Placa.UCENIKOBRACUNDataSet();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonOdustani = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcenikobracunDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.DataMember = "UCENIKOBRACUN";
            this.UltraGrid2.DataSource = this.UcenikobracunDataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid2.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            ultraGridBand1.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 3;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 4;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 5;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 6;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 7;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 8;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BorderColor = System.Drawing.Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid2.Location = new System.Drawing.Point(3, -2);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(646, 527);
            this.UltraGrid2.TabIndex = 43;
            this.UltraGrid2.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid2_AfterCellUpdate);
            this.UltraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
            this.UltraGrid2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UltraGrid2_MouseDown);
            // 
            // UcenikobracunDataSet1
            // 
            this.UcenikobracunDataSet1.DataSetName = "UCENIKOBRACUNDataSet";
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(684, 12);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 44;
            this.ButtonOK.Text = "Formiraj";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonOdustani
            // 
            this.ButtonOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonOdustani.Location = new System.Drawing.Point(684, 55);
            this.ButtonOdustani.Name = "ButtonOdustani";
            this.ButtonOdustani.Size = new System.Drawing.Size(75, 23);
            this.ButtonOdustani.TabIndex = 45;
            this.ButtonOdustani.Text = "Odustani";
            this.ButtonOdustani.UseVisualStyleBackColor = true;
            this.ButtonOdustani.Click += new System.EventHandler(this.ButtonOdustani_Click);
            // 
            // frmPregledObracuna
            // 
            this.ClientSize = new System.Drawing.Size(801, 528);
            this.Controls.Add(this.ButtonOdustani);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.UltraGrid2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledObracuna";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Označite obračune za koji želite izradu RSM-a";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcenikobracunDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        private void UltraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraCombo1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void UltraGrid2_AfterCellUpdate(object sender, CellEventArgs e)
        {
        }

        private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_MouseDown(object sender, MouseEventArgs e)
        {
            this.UltraGrid2.ActiveRow = null;
            if (e.Button == MouseButtons.Left)
            {
                UltraGridRow context = null;
                context = (UltraGridRow) this.UltraGrid2.DisplayLayout.UIElement.ElementFromPoint(e.Location).GetContext(typeof(UltraGridRow));
                if ((context != null) && context.IsDataRow)
                {
                    context.Selected = true;
                    context.Cells["aktivanzarsm"].Value = !Conversions.ToBoolean(context.Cells["aktivanzarsm"].Value);
                }
            }
            this.UltraGrid2.UpdateData();
            new UCENIKOBRACUNDataAdapter().Update(this.UcenikobracunDataSet1);
        }

        private void UltraGrid2_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private UCENIKOBRACUNDataSet UcenikobracunDataSet1;
        private Button ButtonOK;
        private Button ButtonOdustani;
        private UltraGrid UltraGrid2;

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ButtonOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

