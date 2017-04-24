namespace Ucenici
{
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmPregledUcenika : Form
    {
        private IContainer components { get; set; }

        public frmPregledUcenika()
        {
            base.Load += new EventHandler(this.frmPregledRadnika_Load_1);
            this.InitializeComponent();
        }

        private int BrojOznacenihRadnika()
        {
            int num2 = 0;
            int num4 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                if (Conversions.ToBoolean(this.UltraGrid2.Rows[i].Cells["oznacen"].Value))
                {
                    num2++;
                }
            }
            return num2;
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
            new UCENIKDataAdapter().Fill(this.UcenikDataSet1);
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("UCENIK", -1);
            UltraGridColumn column = new UltraGridColumn("IDUCENIK");
            UltraGridColumn column2 = new UltraGridColumn("PREZIMEUCENIK");
            UltraGridColumn column3 = new UltraGridColumn("IMEUCENIK");
            UltraGridColumn column4 = new UltraGridColumn("OIBUCENIK");
            UltraGridColumn column5 = new UltraGridColumn("RAZRED");
            UltraGridColumn column6 = new UltraGridColumn("ODJELJENJE");
            UltraGridColumn column7 = new UltraGridColumn("oznacen", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.UltraButton1 = new UltraButton();
            this.UltraButton2 = new UltraButton();
            this.UltraButton3 = new UltraButton();
            this.OrgdioDataSet1 = new ORGDIODataSet();
            this.UltraGrid2 = new UltraGrid();
            this.UcenikDataSet1 = new UCENIKDataSet();
            this.PregledRadnikaDataset2 = new PregledRadnikaSvihDataSet();
            this.OrgdioDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraGrid2).BeginInit();
            this.UcenikDataSet1.BeginInit();
            this.PregledRadnikaDataset2.BeginInit();
            this.SuspendLayout();
            this.UltraButton1.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.Location = new System.Drawing.Point(12, 12);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(0x7b, 0x17);
            this.UltraButton1.TabIndex = 1;
            this.UltraButton1.Text = "Dodaj oznake svima";
            this.UltraButton1.UseAppStyling = false;
            this.UltraButton1.UseOsThemes = DefaultableBoolean.False;
            this.UltraButton2.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton2.Location = new System.Drawing.Point(0x8d, 11);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(0x80, 0x17);
            this.UltraButton2.TabIndex = 2;
            this.UltraButton2.Text = "Ukloni oznake svima";
            this.UltraButton2.UseAppStyling = false;
            this.UltraButton2.UseOsThemes = DefaultableBoolean.False;
            this.UltraButton3.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton3.Location = new System.Drawing.Point(0x113, 11);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(0x7b, 0x17);
            this.UltraButton3.TabIndex = 0x2c;
            this.UltraButton3.Text = "Potvrda odabira";
            this.UltraButton3.UseAppStyling = false;
            this.UltraButton3.UseOsThemes = DefaultableBoolean.False;
            this.OrgdioDataSet1.DataSetName = "ORGDIODataSet";
            this.UltraGrid2.DataMember = "UCENIK";
            this.UltraGrid2.DataSource = this.UcenikDataSet1;
            appearance.BackColor = Color.White;
            this.UltraGrid2.DisplayLayout.Appearance = appearance;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 0;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 2;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 3;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 4;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 5;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.Header.VisiblePosition = 6;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column7.DataType = typeof(bool);
            column7.DefaultCellValue = false;
            column7.Header.Caption = "Označen";
            column7.Header.VisiblePosition = 1;
            band.Columns.AddRange(new object[] { column, column2, column3, column4, column5, column6, column7 });
            band.Override.RowSelectors = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance2.BackColor = Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance4.BorderColor = Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = Color.LightSteelBlue;
            appearance5.BorderColor = Color.Black;
            appearance5.ForeColor = Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid2.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid2.Location = new System.Drawing.Point(-1, 0x2b);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(800, 0x20f);
            this.UltraGrid2.TabIndex = 0x2b;
            this.UcenikDataSet1.DataSetName = "UCENIKDataSet";
            this.PregledRadnikaDataset2.DataSetName = "PregledRadnikaDataset2";
            this.ClientSize = new System.Drawing.Size(0x325, 0x25d);
            this.Controls.Add(this.UltraButton3);
            this.Controls.Add(this.UltraGrid2);
            this.Controls.Add(this.UltraButton2);
            this.Controls.Add(this.UltraButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledUcenika";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterScreen;


            this.UltraGrid2.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
            this.UltraGrid2.MouseDown += new MouseEventHandler(this.UltraGrid2_MouseDown);
            this.UltraButton3.Click += new EventHandler(this.UltraButton3_Click);
            this.UltraButton2.Click += new EventHandler(this.UltraButton2_Click);
            this.UltraButton1.Click += new EventHandler(this.UltraButton1_Click);


            this.OrgdioDataSet1.EndInit();
            ((ISupportInitialize) this.UltraGrid2).EndInit();
            this.UcenikDataSet1.EndInit();
            this.PregledRadnikaDataset2.EndInit();
            this.ResumeLayout(false);
        }

        public void odaberi()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Parametri_OznaciSve()
        {
            int num2 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
            }
            this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " učenika / studenata";
        }

        private void Parametri_SkiniOznakeSvima()
        {
            int num2 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid2.Rows[i].Cells["oznacen"].Value = false;
            }
            this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " učenika / studenata";
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.Parametri_OznaciSve();
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            this.Parametri_SkiniOznakeSvima();
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            if (this.BrojOznacenihRadnika() == 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void UltraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraCombo1_ValueChanged(object sender, EventArgs e)
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
                    context.Cells["oznacen"].Value = !Conversions.ToBoolean(context.Cells["oznacen"].Value);
                }
            }
            this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " učenika studenata";
        }

        private void UltraGrid2_MouseUp(object sender, MouseEventArgs e)
        {
        }

        public int Vrati1(object vnumber)
        {
            int num = 0;
            if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(vnumber)) | (vnumber == null))
            {
                return -1;
            }
            if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(vnumber)))
            {
                return -1;
            }
            try
            {
                num = int.Parse(Conversions.ToString(vnumber));
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //num = -1;
                
            }
            return num;
        }

        public object OdabraniUcenici
        {
            get
            {
                object obj2 = new object();
                if (this.UltraGrid2.Rows.Count != 0)
                {
                    obj2 = this.UltraGrid2;
                }
                return obj2;
            }
            set
            {
                this.OdabraniUcenici = RuntimeHelpers.GetObjectValue(value);
            }
        }

        private ORGDIODataSet OrgdioDataSet1;

        private PregledRadnikaSvihDataSet PregledRadnikaDataset2;

        private UCENIKDataSet UcenikDataSet1;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraButton UltraButton3;

        private UltraGrid UltraGrid2;
    }
}

