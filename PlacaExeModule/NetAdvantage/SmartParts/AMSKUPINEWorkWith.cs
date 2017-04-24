namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
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
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class AMSKUPINEWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public AMSKUPINEWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.AMSKUPINEDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.AMSKUPINEDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridAMSKUPINE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<AMSKUPINEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<AMSKUPINEDataSet>(this.userControlDataGridAMSKUPINE.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void AMSKUPINEWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridAMSKUPINE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridAMSKUPINE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridAMSKUPINE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridAMSKUPINE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridAMSKUPINE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridAMSKUPINE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridAMSKUPINE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.userControlDataGridAMSKUPINE.FillByPage = false;
            this.FillData();
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
            if (!this.userControlDataGridAMSKUPINE.DataGrid.GridLoading && ((this.userControlDataGridAMSKUPINE.DataGrid.ActiveRow != null) && (this.userControlDataGridAMSKUPINE.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridAMSKUPINE.DataGrid.Rows.Count > 0) && (this.userControlDataGridAMSKUPINE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridAMSKUPINE.DataGrid.Rows[0].Activate();
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
            AMSKUPINEDataSet dataSet = new AMSKUPINEDataSet();
            AMSKUPINEDataAdapter adapter2 = new AMSKUPINEDataAdapter();
            if (Interaction.MsgBox("Postojeće AM skupine biti će obrisane, želite li stvarno nastaviti???", MsgBoxStyle.YesNo, "Osnovna sredstva / SI") != MsgBoxResult.No)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.userControlDataGridAMSKUPINE.DataGrid.DataSet.AMSKUPINE.Rows.GetEnumerator();
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
                adapter2.Update(this.userControlDataGridAMSKUPINE.DataGrid.DataSet);
                OpenFileDialog dialog = new OpenFileDialog {
                    InitialDirectory = @"c:\",
                    Filter = "txt files (*.dbf)|*.dbf|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string str4 = dialog.FileName.ToUpper().Replace(@"\OSM.DBF", "");
                    string prompt = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str4 + ";Extended Properties=dBase IV;";
                    Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
                    OleDbConnection selectConnection = new OleDbConnection(prompt);
                    OleDbDataAdapter adapter = new OleDbDataAdapter("select * from OSA ORDER BY SIFRA", selectConnection);
                    DataSet set2 = new DataSet();
                    try
                    {
                        adapter.Fill(set2, "OSA");
                        if (Interaction.MsgBox("Broj pronađenih zapisa: " + Conversions.ToString(set2.Tables["OSA"].Rows.Count) + "\r\n\r\nŽelite li zadržati importirane zapise?", MsgBoxStyle.YesNo, null) == MsgBoxResult.No)
                        {
                            set2.RejectChanges();
                        }
                        else
                        {
                            DataRow row3;
                            IEnumerator enumerator2 = null;
                            int num2 = 1;
                            try
                            {
                                enumerator2 = set2.Tables["OSA"].Rows.GetEnumerator();
                                while (enumerator2.MoveNext())
                                {
                                    DataRow current = (DataRow) enumerator2.Current;
                                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["sifra"])))
                                    {
                                        string str = string.Empty;
                                        decimal num = 0;
                                        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["NAZIV"])))
                                        {
                                            str = DB.Ko437to852(Conversions.ToString(current["NAZIV"])).Substring(0, DB.Ko437to852(Conversions.ToString(current["NAZIV"])).Length - 1);
                                        }
                                        else
                                        {
                                            str = "Nije bila upisana";
                                        }
                                        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["stopa"])))
                                        {
                                            num = new decimal();
                                        }
                                        else
                                        {
                                            num = Conversions.ToDecimal(current["stopa"]);
                                        }
                                        str = Strings.Left(str, 0x31);
                                        row3 = dataSet.AMSKUPINE.NewRow();
                                        row3["IDAMSKUPINE"] = num2;
                                        row3["kratkasifra"] = RuntimeHelpers.GetObjectValue(current["SIFRA"]);
                                        row3["OPISAMSKUPINE"] = str;
                                        row3["AMSKUPINASTOPA"] = num;
                                        row3["KTONABAVKEIDKONTO"] = "0";
                                        row3["KTOISPRAVKAIDKONTO"] = "0";
                                        row3["KTOIZVORAIDKONTO"] = "9";
                                        dataSet.AMSKUPINE.Rows.Add(row3);
                                        try
                                        {
                                            adapter2.Update(dataSet);
                                        }
                                        catch (System.Exception exception1)
                                        {
                                            throw exception1;
                                            
                                            
                                            
                                        }
                                    }
                                    num2++;
                                }
                            }
                            finally
                            {
                                if (enumerator2 is IDisposable)
                                {
                                    (enumerator2 as IDisposable).Dispose();
                                }
                            }
                            row3 = dataSet.AMSKUPINE.NewRow();
                            row3["IDAMSKUPINE"] = 0x270f;
                            row3["OPISAMSKUPINE"] = "Nepostojeća skupina";
                            row3["AMSKUPINASTOPA"] = 0;
                            row3["KTONABAVKEIDKONTO"] = "0";
                            row3["KTOISPRAVKAIDKONTO"] = "0";
                            row3["KTOIZVORAIDKONTO"] = "9";
                            dataSet.AMSKUPINE.Rows.Add(row3);
                            try
                            {
                                adapter2.Update(dataSet);
                            }
                            catch (System.Exception exception4)
                            {
                                throw exception4;
                                //System.Exception exception2 = exception4;
                                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                            }
                            MessageBox.Show("Importiranje skupina amortizacije završeno!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            adapter2.Fill(this.userControlDataGridAMSKUPINE.DataGrid.DataSet);
                        }
                    }
                    catch (System.Exception exception5)
                    {
                        throw exception5;
                        //System.Exception exception3 = exception5;
                        //Interaction.MsgBox("Greška prilikom prebacivanja podataka!" + exception3.Message, MsgBoxStyle.OkOnly, null);
                        
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridAMSKUPINE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridAMSKUPINE.DataGrid.FillByPage;
                this.userControlDataGridAMSKUPINE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridAMSKUPINE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                if (fillByMethod == "FillByKTOIZVORAIDKONTO")
                {
                    this.FillFillByKTOIZVORAIDKONTO();
                }
                else if (fillByMethod == "FillByKTOISPRAVKAIDKONTO")
                {
                    this.FillFillByKTOISPRAVKAIDKONTO();
                }
                else if (fillByMethod == "FillByKTONABAVKEIDKONTO")
                {
                    this.FillFillByKTONABAVKEIDKONTO();
                }
                else
                {
                    this.userControlDataGridAMSKUPINE.FillMethod = "Fill";
                }
                this.userControlDataGridAMSKUPINE.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((AMSKUPINESelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridAMSKUPINE.DataView.Table.DataSet;
                }
                else
                {
                    ((AMSKUPINEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridAMSKUPINE.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByKTOISPRAVKAIDKONTO()
        {
            string str = "";
            this.userControlDataGridAMSKUPINE.FillMethod = "FillByKTOISPRAVKAIDKONTO";
            this.userControlDataGridAMSKUPINE.FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO = Conversions.ToString(this.GetValueFromRow("IDKONTO", "KTOISPRAVKAIDKONTO"));
            str = str + "," + this.userControlDataGridAMSKUPINE.FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Amortizacijske skupine " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Amortizacijske skupine " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByKTOIZVORAIDKONTO()
        {
            string str = "";
            this.userControlDataGridAMSKUPINE.FillMethod = "FillByKTOIZVORAIDKONTO";
            this.userControlDataGridAMSKUPINE.FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO = Conversions.ToString(this.GetValueFromRow("IDKONTO", "KTOIZVORAIDKONTO"));
            str = str + "," + this.userControlDataGridAMSKUPINE.FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Amortizacijske skupine " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Amortizacijske skupine " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByKTONABAVKEIDKONTO()
        {
            string str = "";
            this.userControlDataGridAMSKUPINE.FillMethod = "FillByKTONABAVKEIDKONTO";
            this.userControlDataGridAMSKUPINE.FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO = Conversions.ToString(this.GetValueFromRow("IDKONTO", "KTONABAVKEIDKONTO"));
            str = str + "," + this.userControlDataGridAMSKUPINE.FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Amortizacijske skupine " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Amortizacijske skupine " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userControlDataGridAMSKUPINE = new NetAdvantage.SmartParts.AMSKUPINEUserDataGrid();
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            // 
            // userControlDataGridAMSKUPINE
            // 
            this.userControlDataGridAMSKUPINE.Description = "Work with Amortizacijske skupine";
            this.userControlDataGridAMSKUPINE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDataGridAMSKUPINE.FillAtStartup = false;
            this.userControlDataGridAMSKUPINE.FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO = null;
            this.userControlDataGridAMSKUPINE.FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO = null;
            this.userControlDataGridAMSKUPINE.FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO = null;
            this.userControlDataGridAMSKUPINE.FillByPage = false;
            this.userControlDataGridAMSKUPINE.Location = new System.Drawing.Point(5, 5);
            this.userControlDataGridAMSKUPINE.Name = "userControlDataGridAMSKUPINE";
            this.userControlDataGridAMSKUPINE.Padding = new System.Windows.Forms.Padding(5);
            this.userControlDataGridAMSKUPINE.Size = new System.Drawing.Size(140, 140);
            this.userControlDataGridAMSKUPINE.TabIndex = 6;
            this.userControlDataGridAMSKUPINE.Title = "Work with Amortizacijske skupine";
            // 
            // ultraGridPrintDocument1
            // 
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridAMSKUPINE.DataGrid;
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // AMSKUPINEWorkWith
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlDataGridAMSKUPINE);
            this.Name = "AMSKUPINEWorkWith";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.AMSKUPINEWorkWith_Load);
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

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/AMSKUPINE", Thread=ThreadOption.UserInterface)]
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
            UIElement lastElementEntered = this.userControlDataGridAMSKUPINE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} Amortizacijske skupine ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} Amortizacijske skupine ", Deklarit.Resources.Resources.Workwith);
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
        public AMSKUPINEWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridAMSKUPINE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridAMSKUPINE.DataView[this.userControlDataGridAMSKUPINE.DataGrid.CurrentRowIndex].Row;
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

        private AMSKUPINEUserDataGrid userControlDataGridAMSKUPINE;

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

