namespace NetAdvantage.SmartParts
{
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
    public class PARTNERWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridPARTNER")]
        private PARTNERUserDataGrid _userControlDataGridPARTNER;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public PARTNERWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.PARTNERDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.PARTNERDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridPARTNER.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<PARTNERDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<PARTNERDataSet>(this.userControlDataGridPARTNER.DataGrid);
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
            if (!this.userControlDataGridPARTNER.DataGrid.GridLoading && ((this.userControlDataGridPARTNER.DataGrid.ActiveRow != null) && (this.userControlDataGridPARTNER.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridPARTNER.DataGrid.Rows.Count > 0) && (this.userControlDataGridPARTNER.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridPARTNER.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridPARTNER.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridPARTNER.DataGrid.FillByPage;
                this.userControlDataGridPARTNER.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridPARTNER.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                this.userControlDataGridPARTNER.FillMethod = "Fill";
                this.userControlDataGridPARTNER.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((PARTNERSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPARTNER.DataView.Table.DataSet;
                }
                else
                {
                    ((PARTNERWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPARTNER.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(PARTNERWorkWith));
            this.userControlDataGridPARTNER = new PARTNERUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.userControlDataGridPARTNER.Name = "userControlDataGridPARTNER";
            this.userControlDataGridPARTNER.Dock = DockStyle.Fill;
            this.userControlDataGridPARTNER.DockPadding.All = 5;
            this.userControlDataGridPARTNER.FillAtStartup = false;
            this.userControlDataGridPARTNER.TabIndex = 6;
            Size size = new System.Drawing.Size(0x2d8, 400);
            this.userControlDataGridPARTNER.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridPARTNER.DataGrid;
            this.Controls.Add(this.userControlDataGridPARTNER);
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "PARTNERWorkWith";
            this.Text = "Work With PARTNER";
            this.Load += new EventHandler(this.PARTNERWorkWith_Load);
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

        private void PARTNERWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridPARTNER.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridPARTNER.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridPARTNER.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridPARTNER.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridPARTNER.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridPARTNER.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridPARTNER.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.userControlDataGridPARTNER.FillByPage = false;
            this.FillData();
        }

        [LocalCommandHandler("Ponisti")]
        public void PonistiHandler(object sender, EventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            UltraGrid dataGrid = new UltraGrid();
            dataGrid = this.userControlDataGridPARTNER.DataGrid;
            ColumnEnumerator enumerator = dataGrid.DisplayLayout.Bands[0].Columns.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.DataType.ToString() == "System.String")
                {
                    dataGrid.DisplayLayout.Bands[0].ColumnFilters["nazivpartner"].FilterConditions.Clear();
                }
            }
        }

        [LocalCommandHandler("PrebaciDOSKonto")]
        public void PrebaciDOSKontoHandler(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            KONTODataSet set2 = new KONTODataSet();
            KONTODataAdapter adapter = new KONTODataAdapter();
            dataSet.EnforceConstraints = false;
            OpenFileDialog dialog = new OpenFileDialog {
                InitialDirectory = @"c:\",
                Filter = "txt files (*.dbf)|*.dbf|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str2 = dialog.FileName.ToUpper().Replace(@"\KONTO.DBF", "");
                string prompt = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + str2 + ";Extended Properties=dBase IV;";
                Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
                OleDbConnection selectConnection = new OleDbConnection(prompt);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter("select * from KONTO ORDER BY SIFRA", selectConnection);
                try
                {
                    IEnumerator enumerator = null;
                    adapter2.Fill(dataSet, "POMOCNI");
                    try
                    {
                        enumerator = dataSet.Tables["pomocni"].Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow) enumerator.Current;
                            DataRow row = set2.KONTO.NewRow();
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["SIFRA"])))
                            {
                                row["idKONTO"] = DB.Ko437to852(Conversions.ToString(current["SIFRA"]));
                            }
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["NAZIV"])))
                            {
                                row["NAZIVkonto"] = DB.Ko437to852(Conversions.ToString(current["NAZIV"]));
                            }
                            row["idaktivnost"] = 1;
                            try
                            {
                                set2.KONTO.Rows.Add(row);
                                continue;
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
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
                    Interaction.MsgBox("Broj importiranih slogova: " + Conversions.ToString(dataSet.Tables["POMOCNI"].Rows.Count), MsgBoxStyle.OkOnly, null);
                    if (Interaction.MsgBox("Želite li zadržati importirane slogove", MsgBoxStyle.OkCancel, null) == MsgBoxResult.Cancel)
                    {
                        dataSet.RejectChanges();
                    }
                    else
                    {
                        try
                        {
                            adapter.Update(set2);
                        }
                        catch (System.Exception exception4)
                        {
                            throw exception4;
                            //System.Exception exception2 = exception4;
                            //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                        }
                    }
                }
                catch (OleDbException exception5)
                {
                    throw exception5;
                    //OleDbException exception3 = exception5;
                    //Interaction.MsgBox("Nije datoteka kontnog plana", MsgBoxStyle.OkOnly, null);
                }
            }
        }


        [LocalCommandHandler("PrikazUcenici")]
        public void PrikazUceniciHandler(object sender, EventArgs e)
        {
            if (PARTNERDataAdapter.prikaz_ucenika == false)
            {
                PARTNERDataAdapter.prikaz_ucenika = true;
            }
            else
            {
                PARTNERDataAdapter.prikaz_ucenika = false;
            }

            this.FillData();
        }

        [LocalCommandHandler("PrebaciDOSPartner")]
        public void PrebaciDOSPartnerHandler(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            PARTNERDataSet set2 = new PARTNERDataSet();
            PARTNERDataAdapter adapter = new PARTNERDataAdapter();
            dataSet.EnforceConstraints = true;
            OpenFileDialog dialog = new OpenFileDialog {
                InitialDirectory = @"c:\",
                Filter = "txt files (*.dbf)|*.dbf|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str2 = dialog.FileName.ToUpper().Replace(@"\PARTNER.DBF", "");
                OleDbConnection selectConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str2 + ";Extended Properties=dBase IV;");
                OleDbDataAdapter adapter2 = new OleDbDataAdapter("select * from PARTNER", selectConnection);
                try
                {
                    IEnumerator enumerator = null;
                    adapter2.Fill(dataSet, "POMOCNI");
                    try
                    {
                        enumerator = dataSet.Tables["pomocni"].Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow) enumerator.Current;
                            DataRow row = set2.PARTNER.NewRow();
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["naziv"])))
                            {
                                row["nazivpartner"] = DB.Ko437to852(Conversions.ToString(current["naziv"]));
                            }
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["adresa"])))
                            {
                                row["partnerulica"] = DB.Ko437to852(Conversions.ToString(current["adresa"]));
                            }
                            else
                            {
                                row["partnerulica"] = " ";
                            }
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["grad"])))
                            {
                                row["partnermjesto"] = DB.Ko437to852(Conversions.ToString(current["grad"]));
                            }
                            else
                            {
                                row["partnermjesto"] = " ";
                            }
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["telefon"])))
                            {
                                row["partnertelefon"] = DB.Ko437to852(Conversions.ToString(current["telefon"]));
                            }
                            else
                            {
                                row["partnertelefon"] = " ";
                            }
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["fax"])))
                            {
                                row["partnerfax"] = DB.Ko437to852(Conversions.ToString(current["fax"]));
                            }
                            else
                            {
                                row["partnerfax"] = " ";
                            }
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["ziro"])))
                            {
                                row["partnerziro1"] = DB.Ko437to852(Conversions.ToString(current["ziro"]));
                            }
                            else
                            {
                                row["partnerziro1"] = " ";
                            }
                            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["matbroj"])))
                            {
                                row["mb"] = DB.Ko437to852(Conversions.ToString(current["matbroj"]));
                            }
                            else
                            {
                                row["mb"] = " ";
                            }
                            row["idpartner"] = Conversions.ToInteger(current["sifra"]);
                            row["partneroib"] = "00000000000";
                            try
                            {
                                set2.PARTNER.Rows.Add(row);
                                continue;
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                                
                                
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
                    Interaction.MsgBox("Broj importiranih slogova: " + Conversions.ToString(dataSet.Tables["POMOCNI"].Rows.Count), MsgBoxStyle.OkOnly, null);
                    if (Interaction.MsgBox("Želite li zadržati importirane slogove", MsgBoxStyle.OkCancel, null) == MsgBoxResult.Cancel)
                    {
                        dataSet.RejectChanges();
                    }
                    else
                    {
                        try
                        {
                            adapter.Update(set2);
                        }
                        catch (System.Exception exception4)
                        {
                            throw exception4;
                            //System.Exception exception2 = exception4;
                            //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                            
                        }
                    }
                }
                catch (OleDbException exception5)
                {
                    throw exception5;
                    //OleDbException exception3 = exception5;
                    //Interaction.MsgBox(exception3.Message, MsgBoxStyle.OkOnly, null);
                    //Interaction.MsgBox("Nije datoteka partnera", MsgBoxStyle.OkOnly, null);
                    
                }
            }
        }

        [LocalCommandHandler("Pretrazi")]
        public void PretraziHandler(object sender, EventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            UltraGrid dataGrid = new UltraGrid();
            dataGrid = this.userControlDataGridPARTNER.DataGrid;
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo 
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Unesite tekst za pretraživanje",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            UnosPojma smartPart = this.Controller.WorkItem.Items.AddNew<UnosPojma>();
            workspace.Show(smartPart, smartPartInfo);
            if (smartPart.ParentForm.DialogResult == DialogResult.OK)
            {
                ColumnEnumerator enumerator = dataGrid.DisplayLayout.Bands[0].Columns.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.DataType.ToString() == "System.String")
                    {
                        dataGrid.DisplayLayout.Bands[0].ColumnFilters["nazivpartner"].FilterConditions.Add(FilterComparisionOperator.Contains, smartPart.UneseniString);
                    }
                }
            }
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

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PARTNER", Thread=ThreadOption.UserInterface)]
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
            UIElement lastElementEntered = this.userControlDataGridPARTNER.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} PARTNER ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} PARTNER ", Deklarit.Resources.Resources.Workwith);
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
        public PARTNERWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridPARTNER.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridPARTNER.DataView[this.userControlDataGridPARTNER.DataGrid.CurrentRowIndex].Row;
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

        private PARTNERUserDataGrid userControlDataGridPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridPARTNER = value;
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

