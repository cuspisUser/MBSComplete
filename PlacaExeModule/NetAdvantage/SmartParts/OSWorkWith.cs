namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Deklarit.Resources;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Printing;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Globalization;
    using System.IO;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    [SmartPart]
    public class OSWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridOS")]
        private OSUserDataGrid _userControlDataGridOS;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public OSWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.OSDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.OSDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridOS.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<OSDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<OSDataSet>(this.userControlDataGridOS.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        [LocalCommandHandler("Copy")]
        public void CopyHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Copy(this.CurrentDataRow);
            }
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.CurrentDataRow != null)
            {
                this.Controller.CurrentRow = this.CurrentDataRow;
            }
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (!this.userControlDataGridOS.DataGrid.GridLoading && ((this.userControlDataGridOS.DataGrid.ActiveRow != null) && (this.userControlDataGridOS.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridOS.DataGrid.Rows.Count > 0) && (this.userControlDataGridOS.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridOS.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("Delete")]
        public void DeleteHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Delete(this.CurrentDataRow);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [LocalCommandHandler("DosImport")]
        public void DosImportHandler(object sender, EventArgs e)
        {
            int num = 0;
            OSDataSet dataSet = new OSDataSet();
            OSDataAdapter adapter2 = new OSDataAdapter();
            if (Interaction.MsgBox("Ukoliko prebacujete OS pritisnite tipku <YES>", MsgBoxStyle.YesNo, "Osnovna sredstva / SI") == MsgBoxResult.Yes)
            {
                num = 1;
            }
            else
            {
                num = 2;
            }
            if (Interaction.MsgBox("Postojeća  OS  biti će obrisane, želite li stvarno nastaviti???", MsgBoxStyle.YesNo, "Osnovna sredstva / SI") != MsgBoxResult.No)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.userControlDataGridOS.DataGrid.DataSet.OS.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ((DataRow) enumerator.Current).Delete();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                AMSKUPINEDataSet set3 = new AMSKUPINEDataSet();
                new AMSKUPINEDataAdapter().Fill(set3);
                adapter2.Update(this.userControlDataGridOS.DataGrid.DataSet);
                OpenFileDialog dialog = new OpenFileDialog {
                    InitialDirectory = @"c:\",
                    Filter = "txt files (*.dbf)|*.dbf|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OleDbDataAdapter adapter;
                    string str3 = dialog.FileName.ToUpper().Replace(@"\OSM.DBF", "");
                    string prompt = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str3 + ";Extended Properties=dBase IV;";
                    Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
                    OleDbConnection selectConnection = new OleDbConnection(prompt);
                    if (Interaction.MsgBox("Želite li prebaciti i sredstva sa količinom 0", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                    {
                        adapter = new OleDbDataAdapter("select * FROM OSM", selectConnection);
                    }
                    else
                    {
                        adapter = new OleDbDataAdapter("select * FROM OSM where KOLU > 0", selectConnection);
                    }
                    DataSet set2 = new DataSet();
                    adapter.Fill(set2, "OSA");
                    if (Interaction.MsgBox("Broj pronađenih zapisa: " + Conversions.ToString(set2.Tables["OSA"].Rows.Count) + "\r\n\r\nŽelite li zadržati importirane zapise?", MsgBoxStyle.YesNo, null) == MsgBoxResult.No)
                    {
                        set2.RejectChanges();
                    }
                    else
                    {
                        IEnumerator enumerator2 = null;
                        int num2 = 1;
                        try
                        {
                            enumerator2 = set2.Tables["OSA"].Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                DataRow current = (DataRow) enumerator2.Current;
                                DataRow row = dataSet.OS.NewRow();
                                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["SIFRA"])))
                                {
                                    DateTime now;
                                    DateTime time2;
                                    string str4 = string.Empty;
                                    string str6 = string.Empty;
                                    string str5 = string.Empty;
                                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["NAZIV"])))
                                    {
                                        str5 = DB.Ko437to852(Conversions.ToString(current["NAZIV"])).Substring(0, DB.Ko437to852(Conversions.ToString(current["NAZIV"])).Length - 1);
                                    }
                                    else
                                    {
                                        str5 = "Nije postojao upisani naziv";
                                    }
                                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["DATUM"])))
                                    {
                                        now = Conversions.ToDate(Interaction.IIf(Information.IsDate(RuntimeHelpers.GetObjectValue(current["DATUM"])), Conversions.ToDate(current["DATUM"]), DateTime.Now));
                                    }
                                    else
                                    {
                                        now = DateTime.Now;
                                    }
                                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["DATUMUP"])))
                                    {
                                        time2 = Conversions.ToDate(Interaction.IIf(Information.IsDate(RuntimeHelpers.GetObjectValue(current["DATUMUP"])), Conversions.ToDate(current["DATUMUP"]), DateTime.Now));
                                    }
                                    else
                                    {
                                        time2 = DateTime.Now;
                                    }
                                    if (DateTime.Compare(time2, Conversions.ToDate("01/01/1754")) < 0)
                                    {
                                        time2 = DateTime.Now;
                                    }
                                    if (DateTime.Compare(now, Conversions.ToDate("01/01/1754")) < 0)
                                    {
                                        now = DateTime.Now;
                                    }
                                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["AMORT"])))
                                    {
                                        str6 = Conversions.ToString(current["AMORT"]);
                                    }
                                    else
                                    {
                                        str6 = "";
                                    }
                                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["NAPOMENA"])))
                                    {
                                        str4 = DB.Ko437to852(Conversions.ToString(current["NAPOMENA"])).Substring(0, DB.Ko437to852(Conversions.ToString(current["NAPOMENA"])).Length - 1);
                                    }
                                    else
                                    {
                                        str4 = "Nije postojala upisana napomena";
                                    }
                                    row["invbroj"] = Conversions.ToInteger(current["SIFRA"]);
                                    row["nazivos"] = Strings.Left(str5, 0x31);
                                    row["datumnabavke"] = now;
                                    row["datumuporabe"] = time2;
                                    if (set3.AMSKUPINE.Select("kratkasifra = '" + str6 + "'").Length == 0)
                                    {
                                        row["idamskupine"] = 0x270f;
                                    }
                                    else
                                    {
                                        row["idamskupine"] = RuntimeHelpers.GetObjectValue(set3.AMSKUPINE.Select("kratkasifra = '" + str6 + "'")[0]["idamskupine"]);
                                    }
                                    row["idosvrsta"] = num;
                                    row["napomenaos"] = Strings.Left(str4, 0x31);
                                    dataSet.OS.Rows.Add(row);
                                    DataRow row4 = dataSet.OSTEMELJNICA.NewRow();
                                    row4["invbroj"] = Conversions.ToInteger(current["SIFRA"]);
                                    row4["idosdokument"] = 1;
                                    row4["osbrojdokumenta"] = 0;
                                    row4["osdatumdok"] = time2;
                                    row4["oskolicina"] = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(current["KOLU"])));
                                    row4["osstopa"] = 0;
                                    row4["ososnovica"] = 0;
                                    if (Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(current["KOLU"]))) > 0)
                                    {
                                        row4["osduguje"] = decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(current["NABVRI"])), new decimal(Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(current["KOLU"])))));
                                    }
                                    else
                                    {
                                        row4["osduguje"] = DB.N20(RuntimeHelpers.GetObjectValue(current["NABVRI"]));
                                    }
                                    row4["ospotrazuje"] = 0;
                                    row4["osOPIS"] = "PS-Nabavna";
                                    dataSet.OSTEMELJNICA.Rows.Add(row4);
                                    row4 = dataSet.OSTEMELJNICA.NewRow();
                                    row4["invbroj"] = Conversions.ToInteger(current["SIFRA"]);
                                    row4["idosdokument"] = 2;
                                    row4["osbrojdokumenta"] = 0;
                                    row4["osdatumdok"] = time2;
                                    row4["oskolicina"] = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(current["KOLU"])));
                                    row4["osstopa"] = 0;
                                    row4["ososnovica"] = 0;
                                    row4["osduguje"] = 0;
                                    if (Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(current["KOLU"]))) > 0)
                                    {
                                        row4["ospotrazuje"] = decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(current["ISPVRI"])), new decimal(Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(current["KOLU"])))));
                                    }
                                    else
                                    {
                                        row4["ospotrazuje"] = DB.N20(RuntimeHelpers.GetObjectValue(current["ISPVRI"]));
                                    }
                                    row4["osOPIS"] = "PS-Ispravak";
                                    dataSet.OSTEMELJNICA.Rows.Add(row4);
                                    num2++;
                                    try
                                    {
                                        adapter2.Update(dataSet);
                                        continue;
                                    }
                                    catch (System.Exception exception1)
                                    {
                                        throw exception1;
                                        //continue;
                                    }
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
                        MessageBox.Show("Importiranje OS/SI  završeno!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        adapter2.Fill(this.userControlDataGridOS.DataGrid.DataSet);
                    }
                }
            }
        }

        [LocalCommandHandler("ExportExcel")]
        public void ExportExcelHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    DefaultExt = "xls",
                    Filter = "Excel file (*.xls)|*.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    new UltraGridExcelExporter().Export(this.userControlDataGridOS.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridOS.DataGrid.FillByPage;
                this.userControlDataGridOS.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridOS.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                if (fillByMethod == "FillByIDOSVRSTA")
                {
                    this.FillFillByIDOSVRSTA();
                }
                else if (fillByMethod == "FillByIDAMSKUPINE")
                {
                    this.FillFillByIDAMSKUPINE();
                }
                else
                {
                    this.userControlDataGridOS.FillMethod = "Fill";
                }
                this.userControlDataGridOS.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((OSSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridOS.DataView.Table.DataSet;
                }
                else
                {
                    ((OSWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridOS.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByIDAMSKUPINE()
        {
            string str = "";
            this.userControlDataGridOS.FillMethod = "FillByIDAMSKUPINE";
            this.userControlDataGridOS.FillByIDAMSKUPINEIDAMSKUPINE = Conversions.ToInteger(this.GetValueFromRow("IDAMSKUPINE", "IDAMSKUPINE"));
            str = str + "," + this.userControlDataGridOS.FillByIDAMSKUPINEIDAMSKUPINE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "OS " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "OS " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDOSVRSTA()
        {
            string str = "";
            this.userControlDataGridOS.FillMethod = "FillByIDOSVRSTA";
            this.userControlDataGridOS.FillByIDOSVRSTAIDOSVRSTA = Conversions.ToInteger(this.GetValueFromRow("IDOSVRSTA", "IDOSVRSTA"));
            str = str + "," + this.userControlDataGridOS.FillByIDOSVRSTAIDOSVRSTA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "OS " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "OS " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        [LocalCommandHandler("FilterNista")]
        public void FilterNistaHandler(object sender, EventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            UltraGrid grid = new UltraGrid();
            this.userControlDataGridOS.DataGrid.DisplayLayout.Bands[0].ColumnFilters["idosvrsta"].FilterConditions.Clear();
            this.Text = "PrikazanO sve";
        }

        [LocalCommandHandler("FilterSI")]
        public void FilterSIHandler(object sender, EventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            UltraGrid dataGrid = new UltraGrid();
            dataGrid = this.userControlDataGridOS.DataGrid;
            dataGrid.DisplayLayout.Bands[0].ColumnFilters["idosvrsta"].FilterConditions.Clear();
            dataGrid.DisplayLayout.Bands[0].ColumnFilters["idosvrsta"].FilterConditions.Add(FilterComparisionOperator.Match, 2);
            this.Text = "Prikazana SI";
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private object GetValueFromRow(string fieldSuperTypeName, string fieldName)
        {
            if (this.m_FillByRow.Table.Columns.Contains(fieldSuperTypeName))
            {
                return this.m_FillByRow[fieldSuperTypeName];
            }
            return this.m_FillByRow[fieldName];
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OSWorkWith));
            this.userControlDataGridOS = new OSUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.userControlDataGridOS.Name = "userControlDataGridOS";
            this.userControlDataGridOS.Dock = DockStyle.Fill;
            this.userControlDataGridOS.DockPadding.All = 5;
            this.userControlDataGridOS.FillAtStartup = false;
            this.userControlDataGridOS.TabIndex = 6;
            Size size = new System.Drawing.Size(0x2d8, 400);
            this.userControlDataGridOS.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridOS.DataGrid;
            this.Controls.Add(this.userControlDataGridOS);
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "OSWorkWith";
            this.Text = "Work With OS";
            this.Load += new EventHandler(this.OSWorkWith_Load);
            this.ResumeLayout(false);
        }

        [LocalCommandHandler("Insert")]
        public void InsertHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.Controller.Insert(this.m_FillByRow);
            }
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        public void Ispis_Naljepnica_MaliFORMAT()
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIVZANALJEPNICE"]);
            Encoding encoding = Encoding.GetEncoding(0x4e2);
            StreamWriter writer = new StreamWriter("maleN.txt", false, encoding);
            RowEnumerator enumerator = this.userControlDataGridOS.DataGrid.Selected.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                int num3 = 0;
                int num4 = 0;
                UltraGridRow current = enumerator.Current;
                foreach (DataRow row2 in this.userControlDataGridOS.DataGrid.DataSet.OSTEMELJNICA.Select(Conversions.ToString(Operators.ConcatenateObject("INVBROJ = ", current.Cells["INVBROJ"].Value))))
                {
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(row2["idosdokument"], 1, false), Operators.CompareObjectEqual(row2["idosdokument"], 6, false))))
                    {
                        num4 = Conversions.ToInteger(Operators.AddObject(num4, row2["OSKOLICINA"]));
                    }
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(row2["idosdokument"], 3, false), Operators.CompareObjectEqual(row2["idosdokument"], 7, false))))
                    {
                        num3 = Conversions.ToInteger(Operators.AddObject(num3, row2["OSKOLICINA"]));
                    }
                }
                int num2 = num4 + num3;
                num4 = 0;
                num3 = 0;
                int num7 = num2;
                for (int i = 1; i <= num7; i++)
                {
                    string str3 = "\"" + str + "\"";
                    string str4 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\"", current.Cells["NAZIVOS"].Value), "\""));
                    string str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\"", current.Cells["INVBROJ"].Value), "\""));
                    writer.WriteLine("");
                    writer.WriteLine("N");
                    writer.WriteLine("I8,B,001");
                    writer.WriteLine("Q152,32");
                    writer.WriteLine("q100");
                    writer.WriteLine("rN");
                    writer.WriteLine("S2");
                    writer.WriteLine("D7");
                    writer.WriteLine("ZB");
                    writer.WriteLine("JF");
                    writer.WriteLine("OD");
                    writer.WriteLine("R60,0");
                    writer.WriteLine("A210,26,0,1,1,1,N," + str3);
                    writer.WriteLine("A210,46,0,1,1,1,N," + str4);
                    writer.WriteLine("B210,65,0,1,2,2,60,B," + str2);
                    writer.WriteLine("P1");
                }
            }
            writer.Close();
            if (Interaction.MsgBox("Izrada naljepnica završena. Želite li ispisati naljepnice na ZEBRA printer?", MsgBoxStyle.YesNo, "OS-Ispis naljepnica") == MsgBoxResult.Yes)
            {
                PrintDialog dialog = new PrintDialog {
                    PrinterSettings = new PrinterSettings()
                };
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DOSPrinter.SendFileToPrinter(dialog.PrinterSettings.PrinterName, "maleN.txt");
                }
                else
                {
                    Interaction.MsgBox("Odustali ste od ispisa naljepnica!", MsgBoxStyle.OkOnly, "OS-Ispis naljepnica");
                }
            }
        }

        [LocalCommandHandler("BilancaOS")]
        public void IspisBilance(object sender, EventArgs e)
        {
            frmUvjetiBilanca bilanca = new frmUvjetiBilanca();
            if (bilanca.ShowDialog() == DialogResult.OK)
            {
                string str = string.Empty;
                ReportDocument document = new ReportDocument();
                if (bilanca.___PoNosiocu)
                {
                    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptOSBilancaPoNosiocu.rpt");
                }
                else
                {
                    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptOSBilanca.rpt");
                }
                S_OS_BILANCA_STANJA_NA_DANDataAdapter adapter = new S_OS_BILANCA_STANJA_NA_DANDataAdapter();
                S_OS_BILANCA_STANJA_NA_DANDataSet dataSet = new S_OS_BILANCA_STANJA_NA_DANDataSet();
                S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataAdapter adapter2 = new S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataAdapter();
                S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet set2 = new S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet();
                if (bilanca.___PoNosiocu)
                {
                    adapter2.Fill(set2, bilanca.__nadan, Conversions.ToString(bilanca.__Sort), Conversions.ToInteger(bilanca.__Vrsta));
                    document.SetDataSource(set2);
                }
                else
                {
                    adapter.Fill(dataSet, bilanca.__nadan, Conversions.ToString(bilanca.__Sort), Conversions.ToShort(bilanca.__Vrsta));
                    document.SetDataSource(dataSet);
                }
                DateTimeFormatInfo dateTimeFormat = new CultureInfo("hr-HR").DateTimeFormat;
                if (Operators.ConditionalCompareObjectEqual(bilanca.__Vrsta, 1, false))
                {
                    if (bilanca.___PoNosiocu)
                    {
                        str = "Stanje osnovnih sredstava po lokacijama na dan: " + bilanca.__nadan.ToString("d", dateTimeFormat);
                    }
                    else
                    {
                        str = "Stanje osnovnih sredstava na dan: " + bilanca.__nadan.ToString("d", dateTimeFormat);
                    }
                }
                else if (bilanca.___PoNosiocu)
                {
                    str = "Stanje sitnog inventara po lokacijama  na dan: " + bilanca.__nadan.ToString("d", dateTimeFormat);
                }
                else
                {
                    str = "Stanje sitnog inventara  na dan: " + bilanca.__nadan.ToString("d", dateTimeFormat);
                }
                KORISNIKDataSet set3 = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(set3);
                document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(set3.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                document.SetParameterValue("ustanova2", Operators.AddObject(Operators.AddObject(set3.KORISNIK.Rows[0]["KORISNIK1ADRESA"], " "), set3.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                document.SetParameterValue("tel", RuntimeHelpers.GetObjectValue(set3.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                document.SetParameterValue("fax", RuntimeHelpers.GetObjectValue(set3.KORISNIK.Rows[0]["KONTAKTFAX"]));
                document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(set3.KORISNIK.Rows[0]["KORISNIKOIB"]));
                document.SetParameterValue("naslov", str);
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Activate();
                item.Show(item.Workspaces["main"]);
            }
        }

        [LocalCommandHandler("KarticaOS")]
        public void IspisKarticeOS(object sender, EventArgs e)
        {
            frmUvjetiBilanca bilanca = new frmUvjetiBilanca();
            OSDataSet set = new OSDataSet();
            ReportDocument document = new ReportDocument();
            int index = 0;
            RowEnumerator enumerator = this.userControlDataGridOS.DataGrid.Selected.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraGridRow current = enumerator.Current;
                DataRow[] rowArray = this.userControlDataGridOS.DataGrid.DataSet.OS.Select(Conversions.ToString(Operators.ConcatenateObject("invbroj = ", current.Cells["invbroj"].Value)));
                DataRow[] rowArray2 = this.userControlDataGridOS.DataGrid.DataSet.OSTEMELJNICA.Select(Conversions.ToString(Operators.ConcatenateObject("invbroj = ", current.Cells["invbroj"].Value)));
                set.OS.ImportRow(rowArray[0]);
                int num2 = rowArray2.Length - 1;
                for (index = 0; index <= num2; index++)
                {
                    set.OSTEMELJNICA.ImportRow(rowArray2[index]);
                }
            }
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptOSKartica.rpt");
            document.SetDataSource(set);
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            document.SetParameterValue("ustanova", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ustanova2", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], " "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            document.SetParameterValue("tel", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
            document.SetParameterValue("fax", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
            document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Activate();
            item.Show(item.Workspaces["main"]);
        }

        [LocalCommandHandler("IspisNaljepnicaMale")]
        public void IspisNaljepnicaMaleHandler(object sender, EventArgs e)
        {
            this.Ispis_Naljepnica_MaliFORMAT();
        }

        public void naljepnice_po_nosiocu()
        {
            LOKACIJESelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<LOKACIJESelectionListWorkItem>("test");
            DataRow row2 = item.ShowModal(true, "", null);
            item.Terminate();
            if (row2 != null)
            {
                IEnumerator enumerator = null;
                S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter adapter2 = new S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter();
                S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet = new S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet();
                adapter2.Fill(dataSet, Conversions.ToInteger(row2["idlokacije"]));
                KORISNIKDataSet set = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(set);
                string str = Conversions.ToString(set.KORISNIK.Rows[0]["KORISNIK1NAZIVZANALJEPNICE"]);
                Encoding encoding = Encoding.GetEncoding(0x4e2);
                StreamWriter writer = new StreamWriter("maleN.txt", false, encoding);
                try
                {
                    enumerator = dataSet.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        int num2 = Conversions.ToInteger(current["stanje"]);
                        int num4 = num2;
                        for (int i = 1; i <= num4; i++)
                        {
                            string str3 = "\"" + str + "\"";
                            string str4 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\"", current["NAZIVOS"]), "\""));
                            string str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\"", current["INVBROJ"]), "\""));
                            writer.WriteLine("");
                            writer.WriteLine("N");
                            writer.WriteLine("I8,B,001");
                            writer.WriteLine("Q152,32");
                            writer.WriteLine("q100");
                            writer.WriteLine("rN");
                            writer.WriteLine("S2");
                            writer.WriteLine("D7");
                            writer.WriteLine("ZB");
                            writer.WriteLine("JF");
                            writer.WriteLine("OD");
                            writer.WriteLine("R60,0");
                            writer.WriteLine("A210,26,0,1,1,1,N," + str3);
                            writer.WriteLine("A210,46,0,1,1,1,N," + str4);
                            writer.WriteLine("B210,65,0,1,2,2,60,B," + str2);
                            writer.WriteLine("P1");
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
                writer.Close();
                if (Interaction.MsgBox("Izrada naljepnica završena. Želite li ispisati naljepnice na ZEBRA printer?", MsgBoxStyle.YesNo, "OS-Ispis naljepnica") == MsgBoxResult.Yes)
                {
                    PrintDialog dialog = new PrintDialog {
                        PrinterSettings = new PrinterSettings()
                    };
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DOSPrinter.SendFileToPrinter(dialog.PrinterSettings.PrinterName, "maleN.txt");
                    }
                    else
                    {
                        Interaction.MsgBox("Odustali ste od ispisa naljepnica!", MsgBoxStyle.OkOnly, "OS-Ispis naljepnica");
                    }
                }
            }
        }

        [LocalCommandHandler("IspisNaljepnicaMalePoNosiocu")]
        public void NaljepnicePoNosiocuHandler(object sender, EventArgs e)
        {
            this.naljepnice_po_nosiocu();
        }

        private void OSWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridOS.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridOS.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridOS.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridOS.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridOS.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridOS.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridOS.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.FillData();
        }

        [LocalCommandHandler("FilterOS")]
        public void PretraziHandler(object sender, EventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            UltraGrid dataGrid = new UltraGrid();
            dataGrid = this.userControlDataGridOS.DataGrid;
            dataGrid.DisplayLayout.Bands[0].ColumnFilters["idosvrsta"].FilterConditions.Clear();
            dataGrid.DisplayLayout.Bands[0].ColumnFilters["idosvrsta"].FilterConditions.Add(FilterComparisionOperator.Match, 1);
            this.Text = "Prikazana OS";
        }

        [LocalCommandHandler("Print")]
        public void PrintHandler(object sender, EventArgs e)
        {
            if (Information.IsNothing(this.ultraPrintPreviewDialog1.Document))
            {
                this.ultraPrintPreviewDialog1.Document = this.ultraGridPrintDocument1;
                this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
                this.ultraPrintPreviewDialog1.Document.DocumentName = "";
                this.ultraPrintPreviewDialog1.Text = "";
            }
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.ultraPrintPreviewDialog1.ShowDialog(this);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/OS", Thread=ThreadOption.UserInterface)]
        public void RefreshGrid(object sender, ComponentEventArgs args)
        {
            this.FillData();
        }

        [LocalCommandHandler("Refresh")]
        public void RefreshHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridOS.DataGrid.DisplayLayout.UIElement.LastElementEntered;
            if (lastElementEntered is RowUIElement)
            {
                ancestor = (RowUIElement) lastElementEntered;
            }
            else
            {
                ancestor = (RowUIElement) lastElementEntered.GetAncestor(typeof(RowUIElement));
            }
            if (ancestor != null)
            {
                this.SelectHandler(RuntimeHelpers.GetObjectValue(sender), e);
            }
        }

        [LocalCommandHandler("Select")]
        public void SelectHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.m_RowSelected = this.CurrentDataRow;
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetSmartPartInfoInformation()
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.smartPartInfo1.Title = string.Format("{0} OS ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} OS ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [LocalCommandHandler("Update")]
        public void UpdateHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("View")]
        public void View(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.View(this.CurrentDataRow);
            }
        }

        [CreateNew]
        public OSWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridOS.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridOS.DataView[this.userControlDataGridOS.DataGrid.CurrentRowIndex].Row;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
            }
        }

        public string FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        private OSUserDataGrid userControlDataGridOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridOS = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }
    }
}

