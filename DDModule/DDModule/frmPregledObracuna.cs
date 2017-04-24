namespace DDModule
{
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinToolbars;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmPregledObracuna : Form
    {
        private CurrencyManager cm;
        private IContainer components { get; set; }
        private DataRowView drv;
        private string m_vrstaobracuna { get; set; }

        public frmPregledObracuna()
        {
            base.Load += new EventHandler(this.frmPregledObracuna_Load);
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

        private void frmPregledObracuna_Load(object sender, EventArgs e)
        {
            this.V_DD_PREGLED_OBRACUNADataSet1.Clear();

            new V_DD_PREGLED_OBRACUNADataAdapter().Fill(this.V_DD_PREGLED_OBRACUNADataSet1);
            if (this.UltraGrid1.Rows.Count > 0)
            {
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[0];
            }
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("V_DD_PREGLED_OBRACUNA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNIDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOPISOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDDATUMOBRACUNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDZAKLJUCAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDRSM");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledObracuna));
            this.frmPregledObracuna_Fill_Panel = new System.Windows.Forms.Panel();
            this.UltraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.V_DD_PREGLED_OBRACUNADataSet1 = new Placa.V_DD_PREGLED_OBRACUNADataSet();
            this.PregledObracunaDataSet1 = new Placa.PregledObracunaDataSet();
            this.frmPregledObracuna_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_DD_PREGLED_OBRACUNADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledObracunaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // frmPregledObracuna_Fill_Panel
            // 
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton4);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton3);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton2);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton1);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraGrid1);
            this.frmPregledObracuna_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmPregledObracuna_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmPregledObracuna_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.frmPregledObracuna_Fill_Panel.Name = "frmPregledObracuna_Fill_Panel";
            this.frmPregledObracuna_Fill_Panel.Size = new System.Drawing.Size(891, 626);
            this.frmPregledObracuna_Fill_Panel.TabIndex = 0;
            // 
            // UltraButton4
            // 
            this.UltraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton4.Location = new System.Drawing.Point(401, 12);
            this.UltraButton4.Name = "UltraButton4";
            this.UltraButton4.Size = new System.Drawing.Size(123, 23);
            this.UltraButton4.TabIndex = 48;
            this.UltraButton4.Text = "Zaključaj sve";
            this.UltraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton4.Click += new System.EventHandler(this.UltraButton4_Click);
            // 
            // UltraButton3
            // 
            this.UltraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton3.Location = new System.Drawing.Point(272, 12);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(123, 23);
            this.UltraButton3.TabIndex = 47;
            this.UltraButton3.Text = "Zaključaj sve";
            this.UltraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton3.Click += new System.EventHandler(this.UltraButton3_Click);
            // 
            // UltraButton2
            // 
            this.UltraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton2.Location = new System.Drawing.Point(138, 12);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(128, 23);
            this.UltraButton2.TabIndex = 46;
            this.UltraButton2.Text = "Obriši obračun";
            this.UltraButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton2.Click += new System.EventHandler(this.UltraButton2_Click);
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.Location = new System.Drawing.Point(9, 12);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(123, 23);
            this.UltraButton1.TabIndex = 45;
            this.UltraButton1.Text = "Odaberi obračun";
            this.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "V_DD_PREGLED_OBRACUNA";
            this.UltraGrid1.DataSource = this.V_DD_PREGLED_OBRACUNADataSet1;
            appearance2.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance2;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 397;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn3.Header.Caption = "Datum isplate";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn4.Header.Caption = "Zaključan";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn5.Header.Caption = "JOPPD";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            ultraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            ultraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            ultraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance4.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.BorderColor = System.Drawing.Color.LightGray;
            appearance5.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance.BorderColor = System.Drawing.Color.Black;
            appearance.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell;
            this.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(9, 41);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(879, 585);
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.AfterRowActivate += new System.EventHandler(this.UltraGrid1_AfterRowActivate);
            this.UltraGrid1.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid1_AfterRowUpdate);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            this.UltraGrid1.DoubleClick += new System.EventHandler(this.UltraGrid1_DoubleClick);
            this.UltraGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UltraGrid1_MouseDown);
            // 
            // V_DD_PREGLED_OBRACUNADataSet1
            // 
            this.V_DD_PREGLED_OBRACUNADataSet1.DataSetName = "V_DD_PREGLED_OBRACUNADataSet";
            // 
            // PregledObracunaDataSet1
            // 
            this.PregledObracunaDataSet1.DataSetName = "PregledObracunaDataSet";
            // 
            // frmPregledObracuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 626);
            this.Controls.Add(this.frmPregledObracuna_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledObracuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregled obračuna";
            this.Load += new System.EventHandler(this.frmPregledObracuna_Load);
            this.frmPregledObracuna_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_DD_PREGLED_OBRACUNADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledObracunaDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        public void knjizi_sve()
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            connection.Open();
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                Connection = connection,
                CommandText = "update ddobracun set DDZAKLJUCAN = 1"
            };
            try
            {
                command.ExecuteNonQuery();
                RowEnumerator enumerator = this.UltraGrid1.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Cells["DDZAKLJUCAN"].Value = 1;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
            connection.Close();
        }

        private void Obrisi()
        {
            this.cm = (CurrencyManager) this.BindingContext[this.V_DD_PREGLED_OBRACUNADataSet1, "V_DD_PREGLED_OBRACUNA"];
            if (this.cm.Count != 0)
            {
                this.drv = (DataRowView) this.cm.Current;
                string mjesecisplate = this.drv["ddobracunidobracun"].ToString().Substring(5, 2);
                string godinaisplate = this.drv["ddobracunidobracun"].ToString().Substring(0, 4);
                if (Operators.ConditionalCompareObjectEqual(this.drv["ddobracunidobracun"], this.zadnji_obracun(mjesecisplate, godinaisplate), false))
                {
                    if (Interaction.MsgBox("Molim da potvrdite brisanje obračuna!", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                    {
                        OBRACUNDataSet set = new OBRACUNDataSet();
                        this.ObrisiObracun(Conversions.ToString(this.drv["ddobracunidobracun"]));
                        this.drv.Delete();
                        this.drv = null;
                    }
                }
                else
                {
                    Interaction.MsgBox("Brisanje obračuna nije moguće!", MsgBoxStyle.OkOnly, null);
                }
            }
        }

        private void ObrisiObracun(string sifraobr)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            connection.Open();
            command.CommandText = "DELETE FROM DDOBRACUNRadniciDDKrizniPorez WHERE ddobracunIDOBRACUN = '" + sifraobr + "'";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM DDOBRACUNRadniciVrstePosla WHERE ddobracunIDOBRACUN = '" + sifraobr + "'";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM DDOBRACUNRadniciDoprinosi WHERE ddobracunIDOBRACUN = '" + sifraobr + "'";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM DDOBRACUNRadniciPorezi WHERE ddobracunIDOBRACUN = '" + sifraobr + "'";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM DDOBRACUNRadniciIzdaci WHERE ddobracunIDOBRACUN = '" + sifraobr + "'";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM DDOBRACUNRadnici WHERE ddobracunIDOBRACUN = '" + sifraobr + "'";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM ddOBRACUN WHERE ddobracunIDOBRACUN = '" + sifraobr + "'";
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void Odaberi()
        {
            this.cm = (CurrencyManager) this.BindingContext[this.V_DD_PREGLED_OBRACUNADataSet1, "V_DD_PREGLED_OBRACUNA"];
            if (this.cm.Count != 0)
            {
                this.drv = (DataRowView) this.cm.Current;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        public void OdKnjizi(string OBRACUN, bool ZAKLJ)
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            connection.Open();
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                Connection = connection
            };
            if (ZAKLJ)
            {
                command.CommandText = "update DDobracun set DDzakljUCAN = 1 where DDOBRACUNIDOBRACUN = '" + OBRACUN + "'";
                try
                {
                    command.ExecuteNonQuery();
                    this.UltraButton4.Text = "Odključaj";
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
            else
            {
                command.CommandText = "update DDobracun set DDzakljUCAN = 0 where DDOBRACUNIDOBRACUN = '" + OBRACUN + "'";
                try
                {
                    command.ExecuteNonQuery();
                    this.UltraButton4.Text = "Zaključaj";
                }
                catch (System.Exception exception3)
                {
                    throw exception3;
                }
            }
            connection.Close();
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.Odaberi();
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            if (ProvjeraNapravljenogJOPPDAZaObracun())
            {
                this.Obrisi();
            }
            else
            {
                MessageBox.Show("Postoji JOPPD obrazac za označeni obračun.\nPotrebno je prvo obrisati JOPPD obrazac da bi se mogao brisati obračun.", "Upozorenje");

            }
        }

        private bool ProvjeraNapravljenogJOPPDAZaObracun()
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = Configuration.ConnectionString
            };
            connection.Open();
            SqlCommand command = new SqlCommand
            {
                CommandType = CommandType.Text,
                Connection = connection
            };

            command.CommandText = "Select ID From JOPPDAObracun Where OBRACUN_ID = '" + drv.Row.ItemArray[0].ToString() + "' And Vrsta = 1";

            try
            {
                string var = command.ExecuteScalar().ToString();
                return false;
            }
            catch
            {
                return true;
            }
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            this.knjizi_sve();
            this.PregledObracunaDataSet1.PregledObracuna.Clear();
            new PregledObracunaDataAdapter().Fill(this.PregledObracunaDataSet1);
        }

        private void UltraButton4_Click(object sender, EventArgs e)
        {
            this.cm = (CurrencyManager) this.BindingContext[this.V_DD_PREGLED_OBRACUNADataSet1, "V_DD_PREGLED_OBRACUNA"];
            if (this.cm.Count != 0)
            {
                this.drv = (DataRowView) this.cm.Current;
                if (this.UltraGrid1.Selected.Rows.Count == 0)
                {
                    Interaction.MsgBox("Odaberite obračun!", MsgBoxStyle.OkOnly, null);
                }
                else if (this.UltraGrid1.Selected.Rows.Count > 1)
                {
                    Interaction.MsgBox("Odabrati možete samo jedan redak istovremeno!", MsgBoxStyle.OkOnly, null);
                }
                else if (Operators.ConditionalCompareObjectEqual(this.drv["DDZAKLJUCAN"], 0, false))
                {
                    this.OdKnjizi(Conversions.ToString(this.drv["ddobracunIDOBRACUN"]), true);
                    this.UltraGrid1.Selected.Rows[0].Cells["DDZAKLJUCAN"].Value = true;
                }
                else
                {
                    this.OdKnjizi(Conversions.ToString(this.drv["ddobracunIDOBRACUN"]), false);
                    this.UltraGrid1.Selected.Rows[0].Cells["DDZAKLJUCAN"].Value = false;
                }
            }
        }

        private void UltraGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            this.cm = (CurrencyManager) this.BindingContext[this.V_DD_PREGLED_OBRACUNADataSet1, "V_DD_PREGLED_OBRACUNA"];
            if (this.cm.Count != 0)
            {
                this.drv = (DataRowView) this.cm.Current;
                if (Operators.ConditionalCompareObjectEqual(this.drv["DDZAKLJUCAN"], 0, false))
                {
                    this.UltraButton4.Text = "Zaključaj";
                }
                else
                {
                    this.UltraButton4.Text = "Odključaj";
                }
            }
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
            if (e.Row != null)
            {
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                connection.Open();
                SqlCommand command = new SqlCommand {
                    CommandType = CommandType.Text,
                    Connection = connection
                };
                command.Parameters.Add("@SVRHA", SqlDbType.VarChar, 100).Value = RuntimeHelpers.GetObjectValue(e.Row.Cells["ddopisobracun"].Value);
                command.CommandText = Conversions.ToString(Operators.ConcatenateObject("update ddobracun set ddopisobracun = @SVRHA where ddobracunidobracun = ", Operators.AddObject(Operators.AddObject("'", e.Row.Cells["ddobracunIDOBRACUN"].Value), "'")));
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
        }

        private void UltraGrid1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.UltraGrid1.DisplayLayout.UIElement.LastElementEntered;
            if (lastElementEntered is RowUIElement)
            {
                ancestor = (RowUIElement) lastElementEntered;
            }
            else
            {
                ancestor = (RowUIElement) lastElementEntered.GetAncestor(typeof(RowUIElement));
            }
            if ((ancestor != null) && ((e.Button == MouseButtons.Left) && (e.Clicks == 2)))
            {
                UltraGridRow context = null;
                context = (UltraGridRow) this.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(e.Location).GetContext(typeof(UltraGridRow));
                if ((context != null) && context.IsDataRow)
                {
                    context.Selected = true;
                    this.Odaberi();
                }
            }
        }

        private void UltraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
        }

        private object zadnji_obracun(string mjesecisplate, string godinaisplate)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            command.CommandText = "SELECT max(ddobracunidobracun) from ddobracun where SUBSTRING(dbo.DDOBRACUN.DDOBRACUNIDOBRACUN, 6, 2) = '" + mjesecisplate + "' and SUBSTRING(dbo.DDOBRACUN.DDOBRACUNIDOBRACUN, 1, 4)= '" + godinaisplate + "'";
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return "";
        }

        private Panel frmPregledObracuna_Fill_Panel;

        public object OdabraniObracun
        {
            get
            {
                object objectValue = new object();
                if ((this.drv != null) && (this.cm.Count != 0))
                {
                    objectValue = RuntimeHelpers.GetObjectValue(this.drv["ddobracunidobracun"]);
                }
                return objectValue;
            }
            set
            {
                this.OdabraniObracun = RuntimeHelpers.GetObjectValue(value);
            }
        }

        private PregledObracunaDataSet PregledObracunaDataSet1;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraButton UltraButton3;

        private UltraButton UltraButton4;

        private UltraGrid UltraGrid1;

        private V_DD_PREGLED_OBRACUNADataSet V_DD_PREGLED_OBRACUNADataSet1;

        private void UltraGrid1_CellChange(object sender, CellEventArgs e)
        {
            
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            string datum = Convert.ToDateTime(UltraGrid1.ActiveRow.Cells["DDDATUMOBRACUNA"].Value).ToString("yyyy-MM-dd");

            client.ExecuteNonQuery("Update DDOBRACUN Set DDDATUMOBRACUNA = '" + datum +
                                   "' Where DDOBRACUNIDOBRACUN = '" + UltraGrid1.ActiveRow.Cells["DDOBRACUNIDOBRACUN"].Value.ToString() + "'");
        }

    }
}

