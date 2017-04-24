namespace Ucenici.Ucenici
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinCalcManager;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
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
    using Ucenici;

    [SmartPart]
    public class UceniciCustom : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_PripremaPlaceCustomAutoHideControl")]
        private AutoHideControl __PripremaPlaceCustomAutoHideControl;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaRight")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaRight;
        [AccessedThroughProperty("_PripremaPlaceCustomUnpinnedTabAreaTop")]
        private UnpinnedTabArea __PripremaPlaceCustomUnpinnedTabAreaTop;
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("Button3")]
        private Button _Button3;
        [AccessedThroughProperty("Button4")]
        private Button _Button4;
        [AccessedThroughProperty("Button5")]
        private Button _Button5;
        [AccessedThroughProperty("DockableWindow3")]
        private DockableWindow _DockableWindow3;
        [AccessedThroughProperty("m_cm")]
        private CurrencyManager _m_cm;
        [AccessedThroughProperty("UcenikobracunDataSet1")]
        private UCENIKOBRACUNDataSet _UcenikobracunDataSet1;
        [AccessedThroughProperty("UltraCalcManager1")]
        private UltraCalcManager _UltraCalcManager1;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("UltraGridExcelExporter1")]
        private UltraGridExcelExporter _UltraGridExcelExporter1;
        [AccessedThroughProperty("UltraGroupBox1")]
        private UltraGroupBox _UltraGroupBox1;
        [AccessedThroughProperty("UltraTextEditor1")]
        private UltraTextEditor _UltraTextEditor1;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private UCENIKOBRACUNDataAdapter daUcenikObracun;
        private int godina;
        private SmartPartInfoProvider infoProvider;
        private bool m_bDisablePosCHange;
        
        private int mjesec;
        private decimal osnovicapodanu;
        private SmartPartInfo smartPartInfo1;
        private bool kontorla = false;

        public UceniciCustom()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.daUcenikObracun = new UCENIKOBRACUNDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Obračun učeničke prakse", "UcenickaPraksa");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public int Broj_Oznacenih()
        {
            int num2 = 0;
            try
            {
                int num4 = this.UltraGrid1.Rows.Count - 1;
                for (int i = 0; i <= num4; i++)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.UltraGrid1.Rows[i].Cells["OZNACEN"].Value, true, false), !this.UltraGrid1.Rows[i].IsFilteredOut)))
                    {
                        num2++;
                    }
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                //return 0;
            }
            return num2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.m_bDisablePosCHange = true;
            frmPregledUcenika ucenika = new frmPregledUcenika();
            ucenika.ShowDialog();
            if (ucenika.DialogResult != DialogResult.Cancel)
            {
                int num = 0;
                UltraGrid odabraniUcenici = new UltraGrid();
                odabraniUcenici = (UltraGrid) ucenika.OdabraniUcenici;
                int num3 = odabraniUcenici.Rows.Count - 1;
                int num2 = 0;
                while (num2 <= num3)
                {
                    if (Operators.ConditionalCompareObjectEqual(odabraniUcenici.Rows[num2].Cells["oznacen"].Value, true, false))
                    {
                        num++;
                    }
                    num2++;
                }
                if (num == 0)
                {
                    Interaction.MsgBox("Nema označenih učenika", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = client.sqlConnection;

                    int num4 = odabraniUcenici.Rows.Count - 1;
                    for (num2 = 0; num2 <= num4; num2++)
                    {
                        if (Operators.ConditionalCompareObjectEqual(odabraniUcenici.Rows[num2].Cells["oznacen"].Value, true, false))
                        {
                            DataRow row = this.UcenikobracunDataSet1.UCENIKOBRACUNUCENIKOBRACUNDETAIL.NewRow();
                            row["IDUCENIK"] = RuntimeHelpers.GetObjectValue(odabraniUcenici.Rows[num2].Cells["iducenik"].Value);
                            row["UCOBRMJESEC"] = this.mjesec;
                            row["UCOBRGODINA"] = this.godina;
                            row["BROJDANAPRAKSE"] = 0;
                            row["OBRACUNOSNOVICEPRAKSA"] = 0;
                            row["IMEUCENIK"] = odabraniUcenici.Rows[num2].Cells["IMEUCENIK"].Value;
                            row["PREZIMEUCENIK"] = odabraniUcenici.Rows[num2].Cells["PREZIMEUCENIK"].Value;
                            row["RAZRED"] = odabraniUcenici.Rows[num2].Cells["RAZRED"].Value;
                            row["ODJELJENJE"] = odabraniUcenici.Rows[num2].Cells["ODJELJENJE"].Value;
                            try
                            {
                                this.UcenikobracunDataSet1.UCENIKOBRACUNUCENIKOBRACUNDETAIL.Rows.Add(row);

                                command.CommandText = "Insert Into UCENIKOBRACUNUCENIKOBRACUNDETAIL (UCOBRMJESEC, UCOBRGODINA, IDUCENIK, BROJDANAPRAKSE, OBRACUNOSNOVICEPRAKSA) " +
                                                      "Values ('" + mjesec + "', '" + godina + "', '" + row["IDUCENIK"].ToString() + "', '0', '0')";
                                command.ExecuteNonQuery();
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                            }
                        }
                    }
                    client.CloseConnection();
                    command.Dispose();
                    //this.daUcenikObracun.Update(this.UcenikobracunDataSet1);
                    this.m_bDisablePosCHange = false;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Parametri_OznaciSve();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Parametri_MakniOznake();
        }

        bool block_AfterCellUpdate = false;

        private void Button4_Click(object sender, EventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.UcenikobracunDataSet1, "UCENIKOBRACUN.UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL"];
            if (manager.Count > 0)
            {
                DataRowView current = (DataRowView) manager.Current;
            }
            frmIznosZatvaranjaForma forma = new frmIznosZatvaranjaForma();
            forma.ShowDialog();

            block_AfterCellUpdate = true;


            UltraGridRow[] selected = UltraGrid1.Rows.GetFilteredInNonGroupByRows();

            int num2 = this.UltraGrid1.Rows.Count - 1;

            
            for (int i = 0; i <= num2; i++)
            {
                foreach (UltraGridRow row in selected)
                {
                    if (row.Cells["IDUCENIK"].Value.ToString() == UltraGrid1.Rows[i].Cells["IDUCENIK"].Value.ToString() && row.Cells["OZNACEN"].Value.ToString() == "True")
                    {
                        this.UltraGrid1.Rows[i].Cells["BROJDANAPRAKSE"].Value = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
                        this.UltraGrid1.Rows[i].Cells["OBRACUNOSNOVICEPRAKSA"].Value = DB.RoundUP(Operators.MultiplyObject(forma.UneseniIznos, this.osnovicapodanu));
                        this.UltraGrid1.Rows[i].Update();
                    }
                }
            }

            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid1.Rows[i].Cells["OBRACUNOSNOVICEPRAKSA"].Value = Convert.ToDecimal(this.UltraGrid1.Rows[i].Cells["BROJDANAPRAKSE"].Value) * this.osnovicapodanu;
            }


            //int num2 = this.UltraGrid1.Rows.Count - 1;
            //System.Collections.Generic.Dictionary<int, decimal> oznaceni = new System.Collections.Generic.Dictionary<int, decimal>();

            //for (int i = 0; i <= num2; i++)
            //{
            //    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.UltraGrid1.Rows[i].Cells["OZNACEN"].Value, true, false), 
            //        !this.UltraGrid1.Rows[i].IsFilteredOut)))
            //    {
            //        //oznaceni.Add((int)UltraGrid1.Rows[i].Cells["IDUCENIK"].Value, (decimal)UltraGrid1.Rows[i].Cells["OBRACUNOSNOVICEPRAKSA"].Value);

            //        this.UltraGrid1.Rows[i].Cells["BROJDANAPRAKSE"].Value = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
            //        this.UltraGrid1.Rows[i].Cells["OBRACUNOSNOVICEPRAKSA"].Value = DB.RoundUP(Operators.MultiplyObject(forma.UneseniIznos, this.osnovicapodanu));
            //    }
            //}

            //for (int i = 0; i <= num2; i++)
            //{
            //    manager.Position = i;
            //    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.UltraGrid1.Rows[i].Cells["OZNACEN"].Value, true, false), !this.UltraGrid1.Rows[i].IsFilteredOut)))
            //    {
            //        this.UltraGrid1.Rows[i].Cells["BROJDANAPRAKSE"].Value = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
            //        this.UltraGrid1.Rows[i].Cells["OBRACUNOSNOVICEPRAKSA"].Value = DB.RoundUP(Operators.MultiplyObject(forma.UneseniIznos, this.osnovicapodanu));
            //    }
            //    else
            //    {
            //        foreach (System.Collections.Generic.KeyValuePair<int, decimal> item in oznaceni)
            //        {
            //            if (item.Key == (int)UltraGrid1.Rows[i].Cells["IDUCENIK"].Value)
            //            {
            //                UltraGrid1.Rows[i].Cells["OBRACUNOSNOVICEPRAKSA"].Value = item.Value;
            //            }
            //        }
            //    }
            //}
            //this.UltraGrid1.Update();

            try
            {
                this.daUcenikObracun.Update(this.UcenikobracunDataSet1);
            }
            catch
            {
                //throw exception1;
            }
            finally
            {
                block_AfterCellUpdate = false;
            }
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (!block_AfterCellUpdate)
            {
                if (e.Cell.Column.Key == "BROJDANAPRAKSE")
                {
                    Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = client.sqlConnection;

                    decimal izracun = DB.RoundUP(Operators.MultiplyObject(e.Cell.Value, this.osnovicapodanu));

                    command.CommandText = "Update UCENIKOBRACUNUCENIKOBRACUNDETAIL Set OBRACUNOSNOVICEPRAKSA = '" + izracun.ToString().Replace(',', '.') +
                                          "', BROJDANAPRAKSE = '" + e.Cell.Value.ToString() + "'" + " Where UCOBRMJESEC = '" + mjesec +
                                          "' And UCOBRGODINA = '" + godina + "' And IDUCENIK = '" + ((UltraGridCell)(e.Cell.Row.Cells.All[2])).Text + "'";
                    command.ExecuteNonQuery();

                    client.CloseConnection();
                    command.Dispose();

                    block_AfterCellUpdate = true;
                    kontorla = false;
                    UltraGrid1.Rows[UltraGrid1.ActiveRow.Index].Cells["OBRACUNOSNOVICEPRAKSA"].Value = izracun;
                    
                }
            }
            UltraGrid1.Update();
            kontorla = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (this.Broj_Oznacenih() != 0)
            {
                int num2 = this.UltraGrid1.Rows.Count - 1;
                System.Collections.Generic.List<int> za_brisanje = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<int> id_ucenika = new System.Collections.Generic.List<int>();
                for (int i = num2; i > -1; i--)
                {
                    if (Convert.ToBoolean(UltraGrid1.Rows[i].Cells["oznacen"].Value))
                    {
                        za_brisanje.Add(i);
                        id_ucenika.Add((int)UltraGrid1.Rows[i].Cells["IDUCENIK"].Value);
                    }
                }

                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = client.sqlConnection;

                foreach (int odabrani in id_ucenika)
                {
                    command.CommandText = "Delete from UCENIKOBRACUNUCENIKOBRACUNDETAIL Where UCOBRMJESEC = '" + mjesec + 
                                          "' And UCOBRGODINA = '" + godina + "' And IDUCENIK = '" + odabrani + "'";
                    command.ExecuteNonQuery();

                    //for (int i = this.UltraGrid1.Rows.Count - 1; i >= 0; i += -1)
                    //{
                    //    if (UcenikobracunDataSet1.Tables[0].Rows[i].ItemArray[2].ToString() == odabrani.ToString())
                    //    {
                    //        UcenikobracunDataSet1.Tables[0].Rows[i].Delete();
                    //    }
                    //}
                }
                client.CloseConnection();
                command.Dispose();

                foreach (int odabrani in za_brisanje)
                {
                    UltraGrid1.Rows[odabrani].Delete();
                }
                UltraGrid1.Update();

                //int broj_ucenika = UltraGrid1.Rows.Count;
                //bool oznacen = false;

                //for (int i = broj_ucenika - 1; i > -1; i--)
                //{
                //    oznacen = Convert.ToBoolean(UltraGrid1.Rows[i].Cells["oznacen"].Value);
                //    if (oznacen)
                //    {
                //        ((DataRowView)this.BindingContext[this.UcenikobracunDataSet1, "UCENIKOBRACUN.UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL"].Current).Delete();
                //        UltraGrid1.Rows[i].Update();
                //    }
                //}

                //for (int i = this.UltraGrid1.Rows.Count - 1; i >= 0; i += -1)
                //{
                //    if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
                //    {
                //        this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[i];
                //        ((DataRowView) this.BindingContext[this.UcenikobracunDataSet1, "UCENIKOBRACUN.UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL"].Current).Delete();
                //    }
                //}

                //try
                //{
                //    this.daUcenikObracun.Update(this.UcenikobracunDataSet1);
                //}
                //catch (System.Exception exception1)
                //{
                //    throw exception1;
                //}
                
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            EditorButton button = new EditorButton("zaposlenik");
            Guid internalId = new Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003");
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("9373afb2-5358-4618-b4be-9d6c44b6bcce");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("UCENIKOBRACUNUCENIKOBRACUNDETAIL", -1);
            UltraGridColumn column = new UltraGridColumn("UCOBRMJESEC");
            UltraGridColumn column3 = new UltraGridColumn("UCOBRGODINA");
            UltraGridColumn column4 = new UltraGridColumn("IDUCENIK");
            UltraGridColumn column5 = new UltraGridColumn("PREZIMEUCENIK");
            UltraGridColumn column6 = new UltraGridColumn("IMEUCENIK");
            UltraGridColumn column7 = new UltraGridColumn("BROJDANAPRAKSE");
            UltraGridColumn column8 = new UltraGridColumn("OBRACUNOSNOVICEPRAKSA");
            UltraGridColumn column9 = new UltraGridColumn("RAZRED", -1, null, 0, SortIndicator.Ascending, false);
            UltraGridColumn column10 = new UltraGridColumn("ODJELJENJE", -1, null, 1, SortIndicator.Ascending, false);
            UltraGridColumn column2 = new UltraGridColumn("OZNACEN", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.UltraGroupBox1 = new UltraGroupBox();
            this.Button4 = new Button();
            this.Button5 = new Button();
            this.Button3 = new Button();
            this.Button2 = new Button();
            this.Button1 = new Button();
            this.UltraTextEditor1 = new UltraTextEditor();
            this.UltraCalcManager1 = new UltraCalcManager(this.components);
            this.UcenikobracunDataSet1 = new UCENIKOBRACUNDataSet();
            this.UltraGridExcelExporter1 = new UltraGridExcelExporter(this.components);
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._PripremaPlaceCustomAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow3 = new DockableWindow();
            this.UltraGrid1 = new UltraGrid();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            ((ISupportInitialize) this.UltraCalcManager1).BeginInit();
            this.UcenikobracunDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.Button4);
            this.UltraGroupBox1.Controls.Add(this.Button5);
            this.UltraGroupBox1.Controls.Add(this.Button3);
            this.UltraGroupBox1.Controls.Add(this.Button2);
            this.UltraGroupBox1.Controls.Add(this.Button1);
            this.UltraGroupBox1.Controls.Add(this.UltraTextEditor1);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Location = point;
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            Size size = new System.Drawing.Size(0x483, 0x57);
            this.UltraGroupBox1.Size = size;
            this.UltraGroupBox1.TabIndex = 1;
            point = new System.Drawing.Point(0xcb, 0x30);
            this.Button4.Location = point;
            this.Button4.Name = "Button4";
            size = new System.Drawing.Size(0x8f, 0x17);
            this.Button4.Size = size;
            this.Button4.TabIndex = 0x20;
            this.Button4.Text = "Pridruži dane označenim";
            this.Button4.UseVisualStyleBackColor = true;
            point = new System.Drawing.Point(0x221, 0x30);
            this.Button5.Location = point;
            this.Button5.Name = "Button5";
            size = new System.Drawing.Size(0xb1, 0x17);
            this.Button5.Size = size;
            this.Button5.TabIndex = 0x11;
            this.Button5.Text = "Briši učenike iz obračuna";
            this.Button5.UseVisualStyleBackColor = true;
            point = new System.Drawing.Point(0x59, 0x30);
            this.Button3.Location = point;
            this.Button3.Name = "Button3";
            size = new System.Drawing.Size(0x60, 0x17);
            this.Button3.Size = size;
            this.Button3.TabIndex = 14;
            this.Button3.Text = "Makni oznake";
            this.Button3.UseVisualStyleBackColor = true;
            point = new System.Drawing.Point(7, 0x30);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new System.Drawing.Size(0x4b, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 13;
            this.Button2.Text = "Označi sve";
            this.Button2.UseVisualStyleBackColor = true;
            point = new System.Drawing.Point(0x16a, 0x30);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new System.Drawing.Size(0xb1, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 12;
            this.Button1.Text = "Dodaj učenike u obračun";
            this.Button1.UseVisualStyleBackColor = true;
            button.Key = "zaposlenik";
            button.Text = "Kliknite za odabir";
            this.UltraTextEditor1.ButtonsRight.Add(button);
            point = new System.Drawing.Point(7, 15);
            this.UltraTextEditor1.Location = point;
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            size = new System.Drawing.Size(0x1bd, 0x15);
            this.UltraTextEditor1.Size = size;
            this.UltraTextEditor1.TabIndex = 11;
            this.UltraTextEditor1.Text = "Odaberite obračun učenika / studenata";
            this.UltraCalcManager1.ContainingControl = this;
            this.UcenikobracunDataSet1.DataSetName = "UCENIKOBRACUNDataSet";
            pane.Control = this.UltraGroupBox1;
            Rectangle rectangle = new Rectangle(4, 3, 0x265, 0x4d);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "...";
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x483, 0x69);
            pane2.Size = size;
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Name = "_PripremaPlaceCustomUnpinnedTabAreaLeft";
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.TabIndex = 10;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x483, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Name = "_PripremaPlaceCustomUnpinnedTabAreaRight";
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.TabIndex = 11;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Name = "_PripremaPlaceCustomUnpinnedTabAreaTop";
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x483, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.TabIndex = 12;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Location = point;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Name = "_PripremaPlaceCustomUnpinnedTabAreaBottom";
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x483, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Size = size;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.TabIndex = 13;
            this._PripremaPlaceCustomAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomAutoHideControl.Location = point;
            this._PripremaPlaceCustomAutoHideControl.Name = "_PripremaPlaceCustomAutoHideControl";
            this._PripremaPlaceCustomAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0);
            this._PripremaPlaceCustomAutoHideControl.Size = size;
            this._PripremaPlaceCustomAutoHideControl.TabIndex = 14;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Location = point;
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x483, 110);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 15;
            this.DockableWindow3.Controls.Add(this.UltraGroupBox1);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Location = point;
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x483, 0x69);
            this.DockableWindow3.Size = size;
            this.DockableWindow3.TabIndex = 0x11;
            this.UltraGrid1.CalcManager = this.UltraCalcManager1;
            this.UltraGrid1.DataMember = "UCENIKOBRACUN.UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL";
            this.UltraGrid1.DataSource = this.UcenikobracunDataSet1;
            appearance.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 1;
            column.Hidden = true;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 2;
            column3.Hidden = true;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.CellActivation = Activation.NoEdit;
            column4.Header.Caption = "Šifra";
            column4.Header.VisiblePosition = 3;
            column4.Width = 0x35;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.CellActivation = Activation.NoEdit;
            column5.Header.Caption = "Prezime";
            column5.Header.VisiblePosition = 4;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.CellActivation = Activation.NoEdit;
            column6.Header.Caption = "Ime";
            column6.Header.VisiblePosition = 5;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.Caption = "Br.dana prakse";
            column7.Header.VisiblePosition = 6;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.Caption = "Obračunato";
            column8.Header.VisiblePosition = 7;
            column8.MaskInput = "-nnnnnnnnn.nn";
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.Caption = "Raz.";
            column9.Header.VisiblePosition = 8;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.Caption = "Odj.";
            column10.Header.VisiblePosition = 9;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.CellActivation = Activation.NoEdit;
            column2.DataType = typeof(bool);
            column2.DefaultCellValue = true;
            column2.Header.Caption = "Označen";
            column2.Header.VisiblePosition = 0;
            column2.Width = 0x26;
            band.Columns.AddRange(new object[] { column, column3, column4, column5, column6, column7, column8, column9, column10, column2 });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance2.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BorderColor = Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = Color.LightSteelBlue;
            appearance5.BorderColor = Color.Black;
            appearance5.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 110);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            size = new System.Drawing.Size(0x483, 360);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 0x10;
            this.UltraGrid1.UseAppStyling = false;
            this.Controls.Add(this._PripremaPlaceCustomAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaTop);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaBottom);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaLeft);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaRight);
            this.Name = "UceniciCustom";
            size = new System.Drawing.Size(0x483, 470);
            this.Size = size;
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            ((ISupportInitialize) this.UltraCalcManager1).EndInit();
            this.UcenikobracunDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.ResumeLayout(false);
        }

        [CommandHandler("RSM")]
        public void IspisRekapitulacijeHandler(object sender, EventArgs e)
        {
            frmPregledObracuna frmPregledObracuna = new frmPregledObracuna();

            if (frmPregledObracuna.ShowDialog() == DialogResult.OK)
            {
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                RSMObrazacWorkItem item = this.Controller.WorkItem.Items.Get<RSMObrazacWorkItem>("RSMA");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<RSMObrazacWorkItem>("RSMA");
                }
                item.Show(item.Workspaces["main"]);
            }
        }

        private void m_cm_PositionChanged(object sender, EventArgs e)
        {
            if (!this.m_bDisablePosCHange && (this.m_cm.Count != 0))
            {
                DataRowView current = (DataRowView) this.m_cm.Current;
            }
        }

        private void Parametri_MakniOznake()
        {
            int num2 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid1.Rows[i].Cells["OZNACEN"].Value = false;
                this.UltraGrid1.Rows[i].Update();
            }
        }

        private void Parametri_OznaciSve()
        {
            UltraGridRow[] selected = UltraGrid1.Rows.GetFilteredInNonGroupByRows();

            int num2 = this.UltraGrid1.Rows.Count - 1;
            
            foreach (UltraGridRow row in selected)
            {
                for (int i = 0; i <= num2; i++)
                {
                    if (row.Cells["IDUCENIK"].Value.ToString() == UltraGrid1.Rows[i].Cells["IDUCENIK"].Value.ToString())
                    {
                        this.UltraGrid1.Rows[i].Cells["OZNACEN"].Value = true;
                        this.UltraGrid1.Rows[i].Update();
                    }
                }
            }
        }

        private void Priprema_Load(object sender, EventArgs e)
        {
            this.m_cm = (CurrencyManager) this.BindingContext[this.UcenikobracunDataSet1, "UCENIKOBRACUN.UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL"];
            this.m_cm_PositionChanged(null, null);
            this.UltraGrid1.Rows.ExpandAll(true);
        }

        [CommandHandler("Ucitaj")]
        public void UcitajHandler(object sender, EventArgs e)
        {
        }

        private void UltraGrid1_AfterEnterEditMode(object sender, EventArgs e)
        {
            this.UltraGrid1.ActiveCell.SelectAll();
        }

        private void UltraGrid1_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void UltraGrid1_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (kontorla)
            {
                block_AfterCellUpdate = false;
                kontorla = false;
            }
        }

        private void UltraGrid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Column.Key == "OZNACEN")
            {
                e.Cell.Value = Operators.NotObject(e.Cell.Value);
                e.Cell.Row.Update();
            }
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                this.m_bDisablePosCHange = true;
                UCENIKOBRACUNSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<UCENIKOBRACUNSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    this.UcenikobracunDataSet1.Clear();
                    this.mjesec = Conversions.ToInteger(row["ucobrmjesec"]);
                    this.godina = Conversions.ToInteger(row["ucobrgodina"]);
                    this.osnovicapodanu = Conversions.ToDecimal(row["osnovicapodanu"]);
                    this.daUcenikObracun.FillByUCOBRMJESECUCOBRGODINA(this.UcenikobracunDataSet1, this.mjesec, this.godina);
                    this.UltraTextEditor1.Value = RuntimeHelpers.GetObjectValue(row["UCOBROPIS"]);
                    this.Parametri_MakniOznake();
                    this.m_bDisablePosCHange = false;
                    this.m_cm_PositionChanged(null, null);
                }
            }
        }

        internal AutoHideControl _PripremaPlaceCustomAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__PripremaPlaceCustomUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__PripremaPlaceCustomUnpinnedTabAreaTop = value;
            }
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

        internal Button Button3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button3_Click);
                if (this._Button3 != null)
                {
                    this._Button3.Click -= handler;
                }
                this._Button3 = value;
                if (this._Button3 != null)
                {
                    this._Button3.Click += handler;
                }
            }
        }

        internal Button Button4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button4_Click);
                if (this._Button4 != null)
                {
                    this._Button4.Click -= handler;
                }
                this._Button4 = value;
                if (this._Button4 != null)
                {
                    this._Button4.Click += handler;
                }
            }
        }

        internal Button Button5
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button5;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Button5_Click);
                if (this._Button5 != null)
                {
                    this._Button5.Click -= handler;
                }
                this._Button5 = value;
                if (this._Button5 != null)
                {
                    this._Button5.Click += handler;
                }
            }
        }

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

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

        internal DockableWindow DockableWindow3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow3 = value;
            }
        }

        public DataRow FillByRow
        {
            set
            {
            }
        }

        public string FillMethod
        {
            set
            {
            }
        }

        private CurrencyManager m_cm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._m_cm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.m_cm_PositionChanged);
                if (this._m_cm != null)
                {
                    this._m_cm.PositionChanged -= handler;
                }
                this._m_cm = value;
                if (this._m_cm != null)
                {
                    this._m_cm.PositionChanged += handler;
                }
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        internal UCENIKOBRACUNDataSet UcenikobracunDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UcenikobracunDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UcenikobracunDataSet1 = value;
            }
        }

        internal UltraCalcManager UltraCalcManager1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraCalcManager1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraCalcManager1 = value;
            }
        }

        private UltraDockManager UltraDockManager1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDockManager1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraDockManager1 = value;
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
                ClickCellEventHandler handler2 = new ClickCellEventHandler(this.UltraGrid1_ClickCell);
                EventHandler handler3 = new EventHandler(this.UltraGrid1_AfterEnterEditMode);
                BeforeRowsDeletedEventHandler handler4 = new BeforeRowsDeletedEventHandler(UltraGrid1_BeforeRowsDeleted);
                BeforeCellUpdateEventHandler handler5 = new BeforeCellUpdateEventHandler(UltraGrid1_BeforeCellUpdate);
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.AfterCellUpdate -= handler;
                    this._UltraGrid1.ClickCell -= handler2;
                    this._UltraGrid1.AfterEnterEditMode -= handler3;
                    this._UltraGrid1.BeforeRowsDeleted -= handler4;
                    this._UltraGrid1.BeforeCellUpdate -= handler5;
                }
                this._UltraGrid1 = value;
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.AfterCellUpdate += handler;
                    this._UltraGrid1.ClickCell += handler2;
                    this._UltraGrid1.AfterEnterEditMode += handler3;
                    this._UltraGrid1.BeforeRowsDeleted += handler4;
                    this._UltraGrid1.BeforeCellUpdate += handler5;
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

        private UltraGroupBox UltraGroupBox1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraGroupBox1_Click);
                if (this._UltraGroupBox1 != null)
                {
                    this._UltraGroupBox1.Click -= handler;
                }
                this._UltraGroupBox1 = value;
                if (this._UltraGroupBox1 != null)
                {
                    this._UltraGroupBox1.Click += handler;
                }
            }
        }

        internal UltraTextEditor UltraTextEditor1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraTextEditor1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EditorButtonEventHandler handler = new EditorButtonEventHandler(this.UltraTextEditor1_EditorButtonClick);
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.EditorButtonClick -= handler;
                }
                this._UltraTextEditor1 = value;
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.EditorButtonClick += handler;
                }
            }
        }

        internal WindowDockingArea WindowDockingArea1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea1 = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

