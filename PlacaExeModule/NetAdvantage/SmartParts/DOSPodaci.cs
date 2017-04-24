namespace NetAdvantage.SmartParts
{
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using My.Resources;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml;

    [SmartPart]
    public class DOSPodaci : UserControl
    {
        public DOSPodaci()
        {
            base.Load += new EventHandler(this.DOSPodaci_Load);
            this.InitializeComponent();
        }

        private void btnOtvori_Click(object sender, EventArgs e)
        {
            RADNIKDataSet dataSet = new RADNIKDataSet();
            new RADNIKDataAdapter().Fill(dataSet);
            OleDbConnection connection = new OleDbConnection();
            OpenFileDialog dialog = new OpenFileDialog {
                InitialDirectory = @"c:\",
                Filter = "DBF files (*.dbf)|*.dbf|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataRow current;
                IEnumerator enumerator = null;
                IEnumerator enumerator2 = null;
                string str4 = dialog.FileName.ToUpper().Replace(@"\DJELAT.DBF", "");
                string prompt = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str4 + ";Extended Properties=dBase IV;";
                connection.ConnectionString = prompt;
                Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
                OleDbDataAdapter adapter3 = new OleDbDataAdapter();
                OleDbConnection selectConnection = new OleDbConnection(prompt);
                OleDbDataAdapter adapter = new OleDbDataAdapter(My.Resources.ResourcesPlacaExe.DETALJI, selectConnection);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(My.Resources.ResourcesPlacaExe.ZAGLAVLJE, selectConnection);
                DataSet set = new DataSet();
                DataSet set3 = new DataSet();
                adapter.Fill(set);
                adapter2.Fill(set3);
                try
                {
                    enumerator = set3.Tables[0].Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow) enumerator.Current;
                        DataRow row = this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJE.NewRow();
                        row["DOSJMBG"] = RuntimeHelpers.GetObjectValue(current["JMBG"]);
                        if (current["PK2"].ToString().ToUpper() == "D")
                        {
                            row["DOSIPIDENT"] = 2;
                        }
                        else
                        {
                            row["DOSIPIDENT"] = 1;
                        }
                        row["DOSISPLATAZAGODINU"] = 0x7da;
                        row["DOSISPLATAUGODINI"] = 0x7da;
                        row["DOSOZNACEN"] = true;
                        try
                        {
                            this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJE.Rows.Add(row);
                            continue;
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                            //Interaction.MsgBox(RuntimeHelpers.GetObjectValue(row["SIFRA_D"]), MsgBoxStyle.OkOnly, null);
                            //continue;
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                try
                {
                    enumerator2 = set.Tables[0].Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        current = (DataRow) enumerator2.Current;
                        DataRow row4 = this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJELevel1.NewRow();
                        row4["DOSMJESECISPLATE"] = DB.BrojVodeceNule(RuntimeHelpers.GetObjectValue(current["mje_isp"]), 2, 0, false, "");
                        row4["DOSJMBG"] = RuntimeHelpers.GetObjectValue(current["jmbg"]);
                        if (current["PK2"].ToString().ToUpper() == "D")
                        {
                            row4["DOSIPIDENT"] = 2;
                        }
                        else
                        {
                            row4["DOSIPIDENT"] = 1;
                        }
                        row4["DOSUKUPNOBRUTO"] = DB.N20(RuntimeHelpers.GetObjectValue(current["bruto"]));
                        row4["DOSUKUPNODOPRINOSI"] = DB.N20(RuntimeHelpers.GetObjectValue(current["doprinos"]));
                        row4["DOSUKUPNOOLAKSICE"] = DB.N20(RuntimeHelpers.GetObjectValue(current["olaksice"]));
                        row4["DOSDOHODAK"] = DB.N20(RuntimeHelpers.GetObjectValue(current["dohodak"]));
                        row4["DOSUKUPNOOO"] = DB.N20(RuntimeHelpers.GetObjectValue(current["osobniodbitak"]));
                        row4["DOSPOREZNAOSNOVICA"] = DB.N20(RuntimeHelpers.GetObjectValue(current["poreznaosnovica"]));
                        row4["DOSUKUPNOPOREZIPRIREZ"] = DB.N20(RuntimeHelpers.GetObjectValue(current["poreziprirez"]));
                        row4["DOSUKUPNONETOISPLATA"] = DB.N20(RuntimeHelpers.GetObjectValue(current["neto"]));
                        row4["DOSPOSEBANPOREZ"] = DB.N20(RuntimeHelpers.GetObjectValue(current["krizni"]));
                        try
                        {
                            row4["DOSIDOPCINESTANOVANJA"] = current["SIFRA"].ToString().Substring(0, 3);
                        }
                        catch (System.Exception exception4)
                        {
                            throw exception4;
                            //Exception exception2 = exception4;
                            //DataRow[] rowArray = dataSet.RADNIK.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("JMBG='", current["JMBG"]), "'")));
                            //if (rowArray.Length > 0)
                            //{
                            //    row4["DOSIDOPCINESTANOVANJA"] = rowArray[0]["OPCINASTANOVANJAIDOPCINE"].ToString().Substring(0, 3);
                            //}
                            
                        }
                        try
                        {
                            this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJELevel1.Rows.Add(row4);
                            continue;
                        }
                        catch (System.Exception exception5)
                        {
                            throw exception5;
                            //Exception exception3 = exception5;
                            //Interaction.MsgBox(exception3.Message, MsgBoxStyle.OkOnly, null);
                            
                            //continue;
                        }
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            new DOSIPZAGLAVLJEDataAdapter().Update(this.DosipzaglavljeDataSet1);
        }

        private void btnBrisiMjesec_Click(object sender, EventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DosipzaglavljeDataSet1, "DOSIPZAGLAVLJE.DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1"];
            if (manager.Count > 0)
            {
                SqlConnection connection = new SqlConnection();
                DataRowView current = (DataRowView) manager.Current;
                SqlCommand command = new SqlCommand();
                try
                {
                    connection = new SqlConnection();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
                connection.ConnectionString = Configuration.ConnectionString;
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.CommandText = "DELETE FROM dosipzaglavljelevel1 where dosmjesecisplate = '" + current["dosmjesecisplate"].ToString() + "'";
                command.ExecuteNonQuery();
                connection.Close();
                this.DosipzaglavljeDataSet1.Clear();
                new DOSIPZAGLAVLJEDataAdapter().Fill(this.DosipzaglavljeDataSet1);
            }
        }

        private void btnBrisiSve_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                connection = new SqlConnection();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.ConnectionString = Configuration.ConnectionString;
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            connection.Open();
            command.CommandText = "DELETE FROM dosipzaglavljelevel1";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM dosipzaglavlje";
            command.ExecuteNonQuery();
            connection.Close();
            this.DosipzaglavljeDataSet1.Clear();
        }

        private void btnElementi_Click(object sender, EventArgs e)
        {
            new frmIspravak().ShowDialog();
        }

        private void btnImportDOS_Click(object sender, EventArgs e)
        {
            this.dos_import();
        }

        public void dos_import()
        {
            this.DosipzaglavljeDataSet1.EnforceConstraints = false;
            OpenFileDialog dialog = new OpenFileDialog {
                RestoreDirectory = true
            };
            XmlDocument document = new XmlDocument();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IEnumerator enumerator = null;
                try
                {
                    document.Load(dialog.FileName);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    //Interaction.MsgBox("Greška kod učitavanja XML datoteke!", MsgBoxStyle.OkOnly, null);
                    //return;
                }

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
                nsmgr.AddNamespace("ip", "http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0");

                try
                {
                    enumerator = document.SelectSingleNode("ip:Ip/ip:IpObrasci", nsmgr).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        IEnumerator enumerator2 = null;
                        XmlElement current = (XmlElement) enumerator.Current;
                        DataRow row = this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJE.NewRow();
                        row["DOSJMBG"] = current.SelectSingleNode("ip:Obveznik/ip:Radnik", nsmgr).Attributes.GetNamedItem("oib").Value;
                        row["DOSIPIDENT"] = current.GetAttribute("identifikator");
                        row["DOSISPLATAZAGODINU"] = current.GetAttribute("isplataZaGodinu");
                        row["DOSISPLATAUGODINI"] = document.SelectSingleNode("ip:Ip/ip:IsplataUGodini", nsmgr).InnerText;
                        row["DOSOZNACEN"] = true;
                        try
                        {
                            this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJE.Rows.Add(row);
                        }
                        catch (System.Exception exception4)
                        {
                            throw exception4;
                            //Exception exception2 = exception4;
                            //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                        }

                        try
                        {
                            enumerator2 = current.SelectSingleNode("ip:Mjeseci", nsmgr).GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                XmlElement element3 = (XmlElement) enumerator2.Current;
                                DataRow row2 = this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJELevel1.NewRow();
                                row2["DOSMJESECISPLATE"] = DB.BrojVodeceNule(element3.GetAttribute("mjIspl"), 2, 0, false, "");
                                row2["DOSJMBG"] = current.SelectSingleNode("ip:Obveznik/ip:Radnik", nsmgr).Attributes.GetNamedItem("oib").Value;
                                row2["DOSIPIDENT"] = current.GetAttribute("identifikator");
                                row2["DOSUKUPNOBRUTO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:IsplPlMir", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:IsplPlMir", nsmgr).InnerText.Replace(".", ",")));
                                row2["DOSUKUPNODOPRINOSI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:UplDopr", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:UplDopr", nsmgr).InnerText.Replace(".", ",")));
                                row2["DOSUKUPNOOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:UplPremOsig", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:UplPremOsig", nsmgr).InnerText.Replace(".", ",")));
                                row2["DOSDOHODAK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:Dohodak", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:Dohodak", nsmgr).InnerText.Replace(".", ",")));
                                row2["DOSUKUPNOOO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:OsobOdb", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:OsobOdb", nsmgr).InnerText.Replace(".", ",")));
                                row2["DOSPOREZNAOSNOVICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:PorOsn", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:PorOsn", nsmgr).InnerText.Replace(".", ",")));
                                row2["DOSUKUPNOPOREZIPRIREZ"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:UplPorPrir", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:UplPorPrir", nsmgr).InnerText.Replace(".", ",")));
                                row2["DOSUKUPNONETOISPLATA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:NetoIspl", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:NetoIspl", nsmgr).InnerText.Replace(".", ",")));
                                if (element3.SelectSingleNode("ip:PosPorez", nsmgr) != null)
                                {
                                    row2["DOSPOSEBANPOREZ"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(element3.SelectSingleNode("ip:PosPorez", nsmgr).InnerText == "", 0, element3.SelectSingleNode("ip:PosPorez", nsmgr).InnerText.Replace(".", ",")));
                                }
                                else
                                {
                                    row2["DOSPOSEBANPOREZ"] = 0;
                                }
                                row2["DOSIDOPCINESTANOVANJA"] = element3.GetAttribute("sifGrOp");
                                try
                                {
                                    this.DosipzaglavljeDataSet1.DOSIPZAGLAVLJELevel1.Rows.Add(row2);
                                    continue;
                                }
                                catch (System.Exception exception5)
                                {
                                    throw exception5;
                                    //Exception exception3 = exception5;
                                    //Interaction.MsgBox(exception3.Message, MsgBoxStyle.OkOnly, null);
                                    
                                    //continue;
                                }
                            }
                            continue;
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }

        private void DOSPodaci_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DOSIPZAGLAVLJE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSIPIDENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSJMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSISPLATAUGODINI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSISPLATAZAGODINU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSOZNACEN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSIPIDENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSJMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSMJESECISPLATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSIDOPCINESTANOVANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOBRUTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNODOPRINOSI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSDOHODAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOOO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSPOREZNAOSNOVICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOPOREZIPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNONETOISPLATA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSPOSEBANPOREZ");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DOSIPZAGLAVLJELevel1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSIPIDENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSJMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSMJESECISPLATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSIDOPCINESTANOVANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOBRUTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNODOPRINOSI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSDOHODAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOOO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSPOREZNAOSNOVICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNOPOREZIPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSUKUPNONETOISPLATA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSPOSEBANPOREZ");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DosipzaglavljeDataSet1 = new Placa.DOSIPZAGLAVLJEDataSet();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnOtvori = new System.Windows.Forms.Button();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.btnBrisiMjesec = new System.Windows.Forms.Button();
            this.btnBrisiSve = new System.Windows.Forms.Button();
            this.btnElementi = new System.Windows.Forms.Button();
            this.btnImportDOS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DosipzaglavljeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UltraGrid1.DataMember = "DOSIPZAGLAVLJE";
            this.UltraGrid1.DataSource = this.DosipzaglavljeDataSet1;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraGrid1.DisplayLayout.Appearance = appearance19;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.Caption = "IP identifikator";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "OIB";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "Isplata u godini";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "Isplata za godinu";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Označen";
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
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "IP identifikator";
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "OIB";
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "Mjesec isplate";
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "Šifra općine stanovanja";
            ultraGridColumn10.Header.VisiblePosition = 3;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.Caption = "Ukupni bruto";
            ultraGridColumn11.Header.VisiblePosition = 4;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.Caption = "Ukupni doprinosi";
            ultraGridColumn12.Header.VisiblePosition = 5;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "Ukupno olakšice";
            ultraGridColumn13.Header.VisiblePosition = 6;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "Dohodak";
            ultraGridColumn14.Header.VisiblePosition = 7;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "Ukupni osobni odbitak";
            ultraGridColumn15.Header.VisiblePosition = 8;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.Caption = "Porezna osnovica";
            ultraGridColumn16.Header.VisiblePosition = 9;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.Caption = "Ukupni porez i prirez";
            ultraGridColumn17.Header.VisiblePosition = 10;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.Caption = "Ukupna neto isplata";
            ultraGridColumn18.Header.VisiblePosition = 11;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.Caption = "Poseban porez";
            ultraGridColumn19.Header.VisiblePosition = 12;
            ultraGridBand2.Columns.AddRange(new object[] {
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
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGrid1.DisplayLayout.GroupByBox.Appearance = appearance;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance12;
            this.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance18.BackColor2 = System.Drawing.SystemColors.Control;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance18;
            this.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance4;
            appearance22.BackColor = System.Drawing.SystemColors.Highlight;
            appearance22.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance22;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance21;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraGrid1.DisplayLayout.Override.CellAppearance = appearance20;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 0;
            appearance24.BackColor = System.Drawing.SystemColors.Control;
            appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance24;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance23;
            this.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGrid1.Location = new System.Drawing.Point(15, 3);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1089, 276);
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.Text = "UltraGrid1";
            // 
            // DosipzaglavljeDataSet1
            // 
            this.DosipzaglavljeDataSet1.DataSetName = "DOSIPZAGLAVLJEDataSet";
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UltraGrid2.DataMember = "DOSIPZAGLAVLJE.DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1";
            this.UltraGrid2.DataSource = this.DosipzaglavljeDataSet1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraGrid2.DisplayLayout.Appearance = appearance8;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.Caption = "IP identifikator";
            ultraGridColumn20.Header.VisiblePosition = 0;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.Caption = "OIB";
            ultraGridColumn21.Header.VisiblePosition = 1;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.Caption = "Mjesec isplate";
            ultraGridColumn22.Header.VisiblePosition = 2;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.Caption = "Šifra općine stanovanja";
            ultraGridColumn23.Header.VisiblePosition = 3;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.Caption = "Ukupni bruto";
            ultraGridColumn24.Header.VisiblePosition = 4;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.Caption = "Ukupni doprinosi";
            ultraGridColumn25.Header.VisiblePosition = 5;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.Caption = "Ukupno olakšice";
            ultraGridColumn26.Header.VisiblePosition = 6;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.Caption = "Dohodak";
            ultraGridColumn27.Header.VisiblePosition = 7;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.Caption = "Ukupni osobni odbitak";
            ultraGridColumn28.Header.VisiblePosition = 8;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.Caption = "Porezna osnovica";
            ultraGridColumn29.Header.VisiblePosition = 9;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.Caption = "Ukupni porez i prirez";
            ultraGridColumn30.Header.VisiblePosition = 10;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.Caption = "Ukupna neto isplata";
            ultraGridColumn31.Header.VisiblePosition = 11;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.Caption = "Poseban porez";
            ultraGridColumn32.Header.VisiblePosition = 12;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32});
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.UltraGrid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGrid2.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGrid2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.UltraGrid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGrid2.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.UltraGrid2.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraGrid2.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraGrid2.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance11.BackColor = System.Drawing.SystemColors.Highlight;
            appearance11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraGrid2.DisplayLayout.Override.ActiveRowAppearance = appearance11;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraGrid2.DisplayLayout.Override.CellAppearance = appearance9;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 0;
            appearance14.BackColor = System.Drawing.SystemColors.Control;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGrid2.DisplayLayout.Override.GroupByRowAppearance = appearance14;
            appearance16.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGrid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance15;
            this.UltraGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraGrid2.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.UltraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGrid2.Location = new System.Drawing.Point(15, 285);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(1089, 426);
            this.UltraGrid2.TabIndex = 1;
            this.UltraGrid2.Text = "UltraGrid2";
            // 
            // btnOtvori
            // 
            this.btnOtvori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOtvori.Location = new System.Drawing.Point(1125, 13);
            this.btnOtvori.Name = "btnOtvori";
            this.btnOtvori.Size = new System.Drawing.Size(202, 29);
            this.btnOtvori.TabIndex = 2;
            this.btnOtvori.Text = "Otvori DBF";
            this.btnOtvori.UseVisualStyleBackColor = true;
            this.btnOtvori.Click += new System.EventHandler(this.btnOtvori_Click);
            // 
            // btnSnimi
            // 
            this.btnSnimi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnimi.Location = new System.Drawing.Point(1125, 100);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(202, 29);
            this.btnSnimi.TabIndex = 3;
            this.btnSnimi.Text = "Snimi podatke u bazu";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // btnBrisiMjesec
            // 
            this.btnBrisiMjesec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrisiMjesec.Location = new System.Drawing.Point(1125, 175);
            this.btnBrisiMjesec.Name = "btnBrisiMjesec";
            this.btnBrisiMjesec.Size = new System.Drawing.Size(202, 29);
            this.btnBrisiMjesec.TabIndex = 4;
            this.btnBrisiMjesec.Text = "Briši mj.";
            this.btnBrisiMjesec.UseVisualStyleBackColor = true;
            this.btnBrisiMjesec.Click += new System.EventHandler(this.btnBrisiMjesec_Click);
            // 
            // btnBrisiSve
            // 
            this.btnBrisiSve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrisiSve.Location = new System.Drawing.Point(1125, 210);
            this.btnBrisiSve.Name = "btnBrisiSve";
            this.btnBrisiSve.Size = new System.Drawing.Size(202, 29);
            this.btnBrisiSve.TabIndex = 5;
            this.btnBrisiSve.Text = "Briši sve";
            this.btnBrisiSve.UseVisualStyleBackColor = true;
            this.btnBrisiSve.Click += new System.EventHandler(this.btnBrisiSve_Click);
            // 
            // btnElementi
            // 
            this.btnElementi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElementi.Location = new System.Drawing.Point(1125, 245);
            this.btnElementi.Name = "btnElementi";
            this.btnElementi.Size = new System.Drawing.Size(202, 29);
            this.btnElementi.TabIndex = 6;
            this.btnElementi.Text = "Elementi";
            this.btnElementi.UseVisualStyleBackColor = true;
            this.btnElementi.Click += new System.EventHandler(this.btnElementi_Click);
            // 
            // btnImportDOS
            // 
            this.btnImportDOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportDOS.Location = new System.Drawing.Point(1125, 48);
            this.btnImportDOS.Name = "btnImportDOS";
            this.btnImportDOS.Size = new System.Drawing.Size(202, 29);
            this.btnImportDOS.TabIndex = 7;
            this.btnImportDOS.Text = "Import iz DOS ili MIPSED.NET (XML)";
            this.btnImportDOS.UseVisualStyleBackColor = true;
            this.btnImportDOS.Click += new System.EventHandler(this.btnImportDOS_Click);
            // 
            // DOSPodaci
            // 
            this.Controls.Add(this.btnImportDOS);
            this.Controls.Add(this.btnElementi);
            this.Controls.Add(this.btnBrisiSve);
            this.Controls.Add(this.btnBrisiMjesec);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.btnOtvori);
            this.Controls.Add(this.UltraGrid2);
            this.Controls.Add(this.UltraGrid1);
            this.Name = "DOSPodaci";
            this.Size = new System.Drawing.Size(1350, 714);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DosipzaglavljeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        public Button btnOtvori;

        public Button btnSnimi;

        public Button btnBrisiMjesec;

        public Button btnBrisiSve;

        public Button btnElementi;

        public Button btnImportDOS;

        public DOSIPZAGLAVLJEDataSet DosipzaglavljeDataSet1;

        private UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;
    }
}

