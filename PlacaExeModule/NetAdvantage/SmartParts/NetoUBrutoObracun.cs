namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDataSource;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class NetoUBrutoObracun : UserControl
    {
        [AccessedThroughProperty("Baze1")]
        private Baze _Baze1;
        [AccessedThroughProperty("Baze1BindingSource")]
        private BindingSource _Baze1BindingSource;
        [AccessedThroughProperty("daPodaci")]
        private SqlDataAdapter _daPodaci;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("PregledRadnikaDataSet1")]
        private PregledRadnikaDataSet _PregledRadnikaDataSet1;
        [AccessedThroughProperty("SqlConnection1")]
        private SqlConnection _SqlConnection1;
        [AccessedThroughProperty("SqlInsertCommand1")]
        private SqlCommand _SqlInsertCommand1;
        [AccessedThroughProperty("SqlSelectCommand1")]
        private SqlCommand _SqlSelectCommand1;
        [AccessedThroughProperty("UltraButton1")]
        private UltraButton _UltraButton1;
        [AccessedThroughProperty("UltraDataSource1")]
        private UltraDataSource _UltraDataSource1;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("UltraGridExcelExporter1")]
        private UltraGridExcelExporter _UltraGridExcelExporter1;
        private IContainer components;
        private RADNIKDataAdapter da;
        private DataSet ds;
        private RADNIKDataSet dsradnik;
        private string m_godinaisplate;
        private string m_idradnik;
        private string m_mjesecisplate;

        public NetoUBrutoObracun()
        {
            base.Load += new EventHandler(this.NetoUBrutoObracun_Load);
            this.ds = new DataSet();
            this.dsradnik = new RADNIKDataSet();
            this.da = new RADNIKDataAdapter();
            this.InitializeComponent();
        }

        public void Dodaj_Iz_Zposlenika(string prezimeime, decimal prirez, int X)
        {
            DataRow row = this.Baze1.Podaci.NewRow();
            row["pb"] = 0;
            row["pn"] = 0;
            row["oo"] = 0;
            row["prirez"] = prirez;
            row["trazenineto"] = 0;
            row["izracunatibruto"] = 0;
            row["prezimeiime"] = prezimeime;
            row["NAZIVBAZE"] = X;
            this.Baze1.Podaci.Rows.Add(row);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(NetoUBrutoObracun));
            UltraGridBand band = new UltraGridBand("Podaci", -1);
            UltraGridColumn column = new UltraGridColumn("pb");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridColumn column2 = new UltraGridColumn("pn");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            UltraGridColumn column3 = new UltraGridColumn("oo");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            UltraGridColumn column4 = new UltraGridColumn("prirez");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            UltraGridColumn column5 = new UltraGridColumn("trazenineto");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            UltraGridColumn column6 = new UltraGridColumn("izracunatibruto");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            UltraGridColumn column7 = new UltraGridColumn("PREZIMEIIME");
            UltraGridColumn column8 = new UltraGridColumn("nazivbaze");
            this.PregledRadnikaDataSet1 = new PregledRadnikaDataSet();
            this.Label8 = new Label();
            this.Label7 = new Label();
            this.daPodaci = new SqlDataAdapter();
            this.SqlInsertCommand1 = new SqlCommand();
            this.SqlSelectCommand1 = new SqlCommand();
            this.SqlConnection1 = new SqlConnection();
            this.UltraGrid1 = new UltraGrid();
            this.Baze1BindingSource = new BindingSource(this.components);
            this.Baze1 = new Baze();
            this.UltraDataSource1 = new UltraDataSource(this.components);
            this.UltraButton1 = new UltraButton();
            this.UltraGridExcelExporter1 = new UltraGridExcelExporter(this.components);
            this.PregledRadnikaDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            ((ISupportInitialize) this.Baze1BindingSource).BeginInit();
            this.Baze1.BeginInit();
            ((ISupportInitialize) this.UltraDataSource1).BeginInit();
            this.SuspendLayout();
            this.PregledRadnikaDataSet1.DataSetName = "PregledRadnikaDataSet";
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            System.Drawing.Point point = new System.Drawing.Point(3, 0x22);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            Size size = new System.Drawing.Size(0x161, 0x17);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0x75;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.Label7.ForeColor = Color.Black;
            point = new System.Drawing.Point(3, 0);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new System.Drawing.Size(0x175, 0x17);
            this.Label7.Size = size;
            this.Label7.TabIndex = 0x76;
            this.daPodaci.InsertCommand = this.SqlInsertCommand1;
            this.daPodaci.SelectCommand = this.SqlSelectCommand1;
            this.daPodaci.TableMappings.AddRange(new DataTableMapping[] { new DataTableMapping("Table", "V_OD_OBRACUN_RADNIK_TOTALI_PO_MJESECU_ISPLATE", new DataColumnMapping[] { 
                new DataColumnMapping("MJESECISPLATE", "MJESECISPLATE"), new DataColumnMapping("GODINAISPLATE", "GODINAISPLATE"), new DataColumnMapping("IDRADNIK", "IDRADNIK"), new DataColumnMapping("UKUPNOBRUTO", "UKUPNOBRUTO"), new DataColumnMapping("UKUPNOOSNOVICAZADOPRINOS", "UKUPNOOSNOVICAZADOPRINOS"), new DataColumnMapping("UKUPNODOPRINOSI", "UKUPNODOPRINOSI"), new DataColumnMapping("UKUPNOOO", "UKUPNOOO"), new DataColumnMapping("UKUPNOOLAKSICE", "UKUPNOOLAKSICE"), new DataColumnMapping("UKUPNOPOREZNOPRIZNATEOLAKSICE", "UKUPNOPOREZNOPRIZNATEOLAKSICE"), new DataColumnMapping("POREZNAOSNOVICA", "POREZNAOSNOVICA"), new DataColumnMapping("UKUPNOPOREZ", "UKUPNOPOREZ"), new DataColumnMapping("UKUPNOPRIREZ", "UKUPNOPRIREZ"), new DataColumnMapping("UKUPNOPOREZIPRIREZ", "UKUPNOPOREZIPRIREZ"), new DataColumnMapping("NETOPLACA", "NETOPLACA"), new DataColumnMapping("UKUPNONETONAKNADE", "UKUPNONETONAKNADE"), new DataColumnMapping("NETOPRIMANJA", "NETOPRIMANJA"), 
                new DataColumnMapping("UKUPNOOBUSTAVE", "UKUPNOOBUSTAVE"), new DataColumnMapping("UKUPNOZAISPLATU", "UKUPNOZAISPLATU")
             }) });
            this.SqlInsertCommand1.CommandText = manager.GetString("SqlInsertCommand1.CommandText");
            this.SqlInsertCommand1.Parameters.AddRange(new SqlParameter[] { 
                new SqlParameter("@MJESECISPLATE", SqlDbType.NVarChar, 2, "MJESECISPLATE"), new SqlParameter("@GODINAISPLATE", SqlDbType.NVarChar, 4, "GODINAISPLATE"), new SqlParameter("@IDRADNIK", SqlDbType.Int, 4, "IDRADNIK"), new SqlParameter("@UKUPNOBRUTO", SqlDbType.Money, 8, "UKUPNOBRUTO"), new SqlParameter("@UKUPNOOSNOVICAZADOPRINOS", SqlDbType.Money, 8, "UKUPNOOSNOVICAZADOPRINOS"), new SqlParameter("@UKUPNODOPRINOSI", SqlDbType.Money, 8, "UKUPNODOPRINOSI"), new SqlParameter("@UKUPNOOO", SqlDbType.Money, 8, "UKUPNOOO"), new SqlParameter("@UKUPNOOLAKSICE", SqlDbType.Money, 8, "UKUPNOOLAKSICE"), new SqlParameter("@UKUPNOPOREZNOPRIZNATEOLAKSICE", SqlDbType.Money, 8, "UKUPNOPOREZNOPRIZNATEOLAKSICE"), new SqlParameter("@POREZNAOSNOVICA", SqlDbType.Money, 8, "POREZNAOSNOVICA"), new SqlParameter("@UKUPNOPOREZ", SqlDbType.Money, 8, "UKUPNOPOREZ"), new SqlParameter("@UKUPNOPRIREZ", SqlDbType.Money, 8, "UKUPNOPRIREZ"), new SqlParameter("@UKUPNOPOREZIPRIREZ", SqlDbType.Money, 8, "UKUPNOPOREZIPRIREZ"), new SqlParameter("@NETOPLACA", SqlDbType.Money, 8, "NETOPLACA"), new SqlParameter("@UKUPNONETONAKNADE", SqlDbType.Money, 8, "UKUPNONETONAKNADE"), new SqlParameter("@NETOPRIMANJA", SqlDbType.Money, 8, "NETOPRIMANJA"), 
                new SqlParameter("@UKUPNOOBUSTAVE", SqlDbType.Money, 8, "UKUPNOOBUSTAVE"), new SqlParameter("@UKUPNOZAISPLATU", SqlDbType.Money, 8, "UKUPNOZAISPLATU")
             });
            this.SqlSelectCommand1.CommandText = manager.GetString("SqlSelectCommand1.CommandText");
            this.SqlSelectCommand1.Connection = this.SqlConnection1;
            this.SqlSelectCommand1.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@mjesec", SqlDbType.Variant, 0x400, "MJESECISPLATE"), new SqlParameter("@idradnik", SqlDbType.Int, 0x400, "IDRADNIK"), new SqlParameter("@godina", SqlDbType.Variant, 0x400, "GODINAISPLATE") });
            this.SqlConnection1.ConnectionString = @"Data Source=srecko\sqlexpress;Initial Catalog=rudes;Integrated Security=True";
            this.SqlConnection1.FireInfoMessageEventOnUserErrors = false;
            this.UltraGrid1.DataMember = "Podaci";
            this.UltraGrid1.DataSource = this.Baze1BindingSource;
            this.UltraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance.TextHAlignAsString = "Right";
            column.CellAppearance = appearance;
            column.Header.Caption = "Prethodni bruto";
            column.Header.VisiblePosition = 1;
            column.MaskInput = "{LOC} n,nnn,nnn.nn";
            column.Width = 0x7e;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance2.TextHAlignAsString = "Right";
            column2.CellAppearance = appearance2;
            column2.Header.Caption = "Prethodni neto";
            column2.Header.VisiblePosition = 2;
            column2.MaskInput = "{LOC} n,nnn,nnn.nn";
            column2.Width = 0x7d;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance3.TextHAlignAsString = "Right";
            column3.CellAppearance = appearance3;
            column3.Header.Caption = "Odbici";
            column3.Header.VisiblePosition = 3;
            column3.MaskInput = "{LOC} n,nnn,nnn.nn";
            column3.Width = 0x84;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance4.TextHAlignAsString = "Right";
            column4.CellAppearance = appearance4;
            column4.Header.Caption = "Prirez";
            column4.Header.VisiblePosition = 4;
            column4.MaskInput = "{LOC} n,nnn,nnn.nn";
            column4.Width = 0x7f;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance5.TextHAlignAsString = "Right";
            column5.CellAppearance = appearance5;
            column5.Header.Caption = "Traženi neto";
            column5.Header.VisiblePosition = 5;
            column5.MaskInput = "{LOC} n,nnn,nnn.nn";
            column5.Width = 130;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.TextHAlignAsString = "Right";
            column6.CellAppearance = appearance6;
            column6.Header.Caption = "Bruto po formuli";
            column6.Header.VisiblePosition = 6;
            column6.MaskInput = "{LOC} n,nnn,nnn.nn";
            column6.Width = 140;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.AutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            column7.CellActivation = Activation.NoEdit;
            column7.Header.Caption = "Prezime i ime zaposlenika";
            column7.Header.VisiblePosition = 0;
            column7.Width = 0xd7;
            column8.Header.VisiblePosition = 7;
            column8.Hidden = true;
            column8.Width = 0x5b;
            band.Columns.AddRange(new object[] { column, column2, column3, column4, column5, column6, column7, column8 });
            band.Override.RowSelectorStyle = HeaderStyle.WindowsVista;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x22);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            size = new System.Drawing.Size(0x3f8, 250);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 120;
            this.UltraGrid1.Text = "Popis zaposlenika za NETO u BRUTO izračun";
            this.Baze1BindingSource.DataSource = this.Baze1;
            this.Baze1BindingSource.Position = 0;
            this.Baze1.DataSetName = "Baze";
            this.Baze1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            point = new System.Drawing.Point(6, 5);
            this.UltraButton1.Location = point;
            this.UltraButton1.Name = "UltraButton1";
            size = new System.Drawing.Size(0x99, 0x17);
            this.UltraButton1.Size = size;
            this.UltraButton1.TabIndex = 0x79;
            this.UltraButton1.Text = "Izvoz u MS EXCEL format";
            this.UltraButton1.UseAppStyling = false;
            this.UltraButton1.UseFlatMode = DefaultableBoolean.True;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Controls.Add(this.UltraButton1);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label8);
            this.Name = "NetoUBrutoObracun";
            size = new System.Drawing.Size(0x3fb, 0x11f);
            this.Size = size;
            this.PregledRadnikaDataSet1.EndInit();
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            ((ISupportInitialize) this.Baze1BindingSource).EndInit();
            this.Baze1.EndInit();
            ((ISupportInitialize) this.UltraDataSource1).EndInit();
            this.ResumeLayout(false);
        }

        private void Izvrsi_Izracun()
        {
            // MATIJA BOŽIČEVIĆ
            // Ova funkcionalnost je crash-irala program pošto je ovu metodu zvao event handler "AfterCellUpdate".
            // Pošto je ova ista metoda update-ala sami taj grid došli smo do beskonačnog loop-a,
            // tj. konkretnije, ova metoda se izvršavala 228 puta za redom, nakon čega je puknulo u System.Windows.Forms.dll
            // RIJEŠENJE je bilo ISKLJUČITI event handler na početku izračuna, te na kraju ga ponovno uključiti.
            this.UltraGrid1.AfterCellUpdate -= new CellEventHandler(UltraGrid1_AfterCellUpdate);

            decimal num = 0;
            decimal num3 = new decimal();
            double num7 = (Conversions.ToDouble(this.UltraGrid1.ActiveRow.Cells["PRIREZ"].Value) / 100.0) + 1.0;
            double num5 = 100.0 / (100.0 - (25.0 * num7));
            double num6 = 100.0 / (100.0 - (40.0 * num7));
            decimal num9 = Conversions.ToDecimal(this.UltraGrid1.ActiveRow.Cells["OO"].Value);
            decimal num4 = decimal.Add(Conversions.ToDecimal(this.UltraGrid1.ActiveRow.Cells["TRAZENINETO"].Value), Conversions.ToDecimal(this.UltraGrid1.ActiveRow.Cells["PN"].Value));
            decimal num2 = Conversions.ToDecimal(this.UltraGrid1.ActiveRow.Cells["PB"].Value);
            if (decimal.Compare(num4, num9) <= 0)
            {
                num = new decimal(Convert.ToDouble(num4) * 1.25);
            }
            else if (Convert.ToDouble(num4) <= ((3600.0 - (432.0 * num7)) + Convert.ToDouble(num9)))
            {
                num = new decimal((Convert.ToDouble(decimal.Subtract(num4, num9)) / (1.0 - (0.12 * num7))) + Convert.ToDouble(num9));
                num = new decimal(Convert.ToDouble(num) / 0.8);
            }
            else if (Convert.ToDouble(num4) <= ((10800.0 - (2232.0 * num7)) + Convert.ToDouble(num9)))
            {
                num = new decimal(Convert.ToDouble(decimal.Add(3600M, num9)) + ((Convert.ToDouble(num4) - ((3600.0 - (432.0 * num7)) + Convert.ToDouble(num9))) * num5));
                num = new decimal(Convert.ToDouble(num) / 0.8);
            }
            else if ((Convert.ToDouble(num4) > ((10800.0 - (2232.0 * num7)) + Convert.ToDouble(num9))) & (Convert.ToDouble(num4) <= ((37036.8 - (((26236.8 - Convert.ToDouble(num9)) * 0.4) * num7)) + (2232.0 * num7))))
            {
                num = new decimal(Convert.ToDouble(decimal.Add(10800M, num9)) + ((Convert.ToDouble(num4) - ((10800.0 - (2232.0 * num7)) + Convert.ToDouble(num9))) * num6));
                num = new decimal(Convert.ToDouble(num) / 0.8);
            }
            num3 = decimal.Subtract(num, num2);

            this.UltraGrid1.ActiveRow.Cells["IZRACUNaTIBRUTO"].Value = num3;

            // ponovna uspostava handlera
            this.UltraGrid1.AfterCellUpdate += new CellEventHandler(UltraGrid1_AfterCellUpdate);
        }

        private void NetoUBrutoObracun_Load(object sender, EventArgs e)
        {
            IEnumerator<object> enumerator = this.Controller.WorkItem.Workspaces["main"].SmartParts.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UserControl current;
                if (enumerator.Current is UserControl)
                {
                    current = (UserControl) enumerator.Current;
                    if (current.Name.ToLower() == "radnikworkwith")
                    {
                        int x = 0;
                        RowEnumerator enumerator2 = ((RADNIKDataGrid) current.Controls[0].Controls[0]).Selected.Rows.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            UltraGridRow row = enumerator2.Current;
                            this.Dodaj_Iz_Zposlenika(string.Format("{0} {1}", RuntimeHelpers.GetObjectValue(row.Cells["prezime"].Value), RuntimeHelpers.GetObjectValue(row.Cells["ime"].Value)), Conversions.ToDecimal(row.Cells["opcinastanovanjaprirez"].Value), x);
                            x++;
                        }
                    }
                }
                if (enumerator.Current is UserControl)
                {
                    current = (UserControl) enumerator.Current;
                    if (current.Name.ToLower() == "obracunsmartpart")
                    {
                        int num2 = 0;
                        RowEnumerator enumerator3 = ((ObracunSmartPart)current).UltraGrid1.Rows.GetEnumerator();
                        while (enumerator3.MoveNext())
                        {
                            UltraGridRow row2 = enumerator3.Current;
                            if (Conversions.ToBoolean(Operators.AndObject(this.m_mjesecisplate != null, Operators.CompareObjectEqual(row2.Cells["OZNACEN"].Value, true, false))))
                            {
                                this.ds.Clear();
                                this.daPodaci.SelectCommand.Parameters[0].Value = this.m_mjesecisplate;
                                this.daPodaci.SelectCommand.Parameters[1].Value = RuntimeHelpers.GetObjectValue(row2.Cells["idradnik"].Value);
                                this.daPodaci.SelectCommand.Parameters[2].Value = this.m_godinaisplate;
                                Configuration configuration = new Configuration();
                                SqlConnection connection = new SqlConnection {
                                    ConnectionString = Configuration.ConnectionString
                                };
                                this.daPodaci.SelectCommand.Connection = connection;
                                this.daPodaci.Fill(this.ds);
                                DataRow row3 = this.Baze1.Podaci.NewRow();
                                row3["pb"] = RuntimeHelpers.GetObjectValue(this.ds.Tables[0].Rows[0][3]);
                                row3["pn"] = RuntimeHelpers.GetObjectValue(this.ds.Tables[0].Rows[0][13]);
                                row3["oo"] = Operators.MultiplyObject(((ObracunSmartPart) current).osnovnioo, row2.Cells["FAKTOO"].Value);
                                row3["prirez"] = RuntimeHelpers.GetObjectValue(row2.Cells["OPCINASTANOVANJAPRIREZ"].Value);
                                row3["trazenineto"] = 0;
                                row3["izracunatibruto"] = 0;
                                row3["prezimeiime"] = string.Format("{0} {1}", RuntimeHelpers.GetObjectValue(row2.Cells["prezime"].Value), RuntimeHelpers.GetObjectValue(row2.Cells["ime"].Value));
                                row3["NAZIVBAZE"] = num2;
                                this.Baze1.Podaci.Rows.Add(row3);
                            }
                            num2++;
                        }
                    }
                }
            }
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog2 = new SaveFileDialog {
                InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                FileName = "NETO_U_BRUTO.XLS",
                RestoreDirectory = true
            };
            SaveFileDialog dialog = dialog2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.UltraGridExcelExporter1.Export(this.UltraGrid1, dialog.FileName);
                    Interaction.MsgBox("Datoteka uspješno  kreirana! ", MsgBoxStyle.OkOnly, null);
                }
                catch (System.Exception exception1)
                {
                    Interaction.MsgBox("Datoteka nije kreirana! " + exception1.Message, MsgBoxStyle.OkOnly, null);
                    throw exception1;
                }
            }
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key != "PREZIMEIME")
            {
                this.Izvrsi_Izracun();
            }
        }

        private Baze Baze1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Baze1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Baze1 = value;
            }
        }

        private BindingSource Baze1BindingSource
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Baze1BindingSource;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Baze1BindingSource = value;
            }
        }

        [CreateNew]
        public VIRMANIController Controller { get; set; }

        private SqlDataAdapter daPodaci
        {
            [DebuggerNonUserCode]
            get
            {
                return this._daPodaci;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._daPodaci = value;
            }
        }

        public string GodinaIsplate
        {
            set
            {
                this.m_godinaisplate = value;
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

        public string MjesecIsplate
        {
            set
            {
                this.m_mjesecisplate = value;
            }
        }

        internal PregledRadnikaDataSet PregledRadnikaDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._PregledRadnikaDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._PregledRadnikaDataSet1 = value;
            }
        }

        public int radnik
        {
            set
            {
                this.m_idradnik = Conversions.ToString(value);
            }
        }

        internal SqlConnection SqlConnection1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SqlConnection1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SqlConnection1 = value;
            }
        }

        internal SqlCommand SqlInsertCommand1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SqlInsertCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SqlInsertCommand1 = value;
            }
        }

        internal SqlCommand SqlSelectCommand1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SqlSelectCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SqlSelectCommand1 = value;
            }
        }

        private UltraButton UltraButton1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraButton1_Click);
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click -= handler;
                }
                this._UltraButton1 = value;
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click += handler;
                }
            }
        }

        private UltraDataSource UltraDataSource1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDataSource1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraDataSource1 = value;
            }
        }

        private UltraGrid UltraGrid1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CellEventHandler handler = new CellEventHandler(this.UltraGrid1_AfterCellUpdate);
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.AfterCellUpdate -= handler;
                }
                this._UltraGrid1 = value;
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.AfterCellUpdate += handler;
                }
            }
        }

        private UltraGridExcelExporter UltraGridExcelExporter1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGridExcelExporter1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGridExcelExporter1 = value;
            }
        }
    }
}

