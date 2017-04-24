namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Resources;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class OBRACUNFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkOBRFIKSNIH")]
        private UltraCheckEditor _checkOBRFIKSNIH;
        [AccessedThroughProperty("checkOBRKREDITNIH")]
        private UltraCheckEditor _checkOBRKREDITNIH;
        [AccessedThroughProperty("checkOBRPOSTOTNIH")]
        private UltraCheckEditor _checkOBRPOSTOTNIH;
        [AccessedThroughProperty("checkZAKLJ")]
        private UltraCheckEditor _checkZAKLJ;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMISPLATE")]
        private UltraDateTimeEditor _datePickerDATUMISPLATE;
        [AccessedThroughProperty("datePickerDATUMOBRACUNASTAZA")]
        private UltraDateTimeEditor _datePickerDATUMOBRACUNASTAZA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelObracunRadnici")]
        private UltraGrid _grdLevelObracunRadnici;
        [AccessedThroughProperty("label1DATUMISPLATE")]
        private UltraLabel _label1DATUMISPLATE;
        [AccessedThroughProperty("label1DATUMOBRACUNASTAZA")]
        private UltraLabel _label1DATUMOBRACUNASTAZA;
        [AccessedThroughProperty("label1GODINAISPLATE")]
        private UltraLabel _label1GODINAISPLATE;
        [AccessedThroughProperty("label1GODINAOBRACUNA")]
        private UltraLabel _label1GODINAOBRACUNA;
        [AccessedThroughProperty("label1IDOBRACUN")]
        private UltraLabel _label1IDOBRACUN;
        [AccessedThroughProperty("label1MJESECISPLATE")]
        private UltraLabel _label1MJESECISPLATE;
        [AccessedThroughProperty("label1MJESECNIFONDSATIOBRACUN")]
        private UltraLabel _label1MJESECNIFONDSATIOBRACUN;
        [AccessedThroughProperty("label1MJESECOBRACUNA")]
        private UltraLabel _label1MJESECOBRACUNA;
        [AccessedThroughProperty("label1OBRACUNSKAOSNOVICA")]
        private UltraLabel _label1OBRACUNSKAOSNOVICA;
        [AccessedThroughProperty("label1OBRFIKSNIH")]
        private UltraLabel _label1OBRFIKSNIH;
        [AccessedThroughProperty("label1OBRKREDITNIH")]
        private UltraLabel _label1OBRKREDITNIH;
        [AccessedThroughProperty("label1OBRPOSTOTNIH")]
        private UltraLabel _label1OBRPOSTOTNIH;
        [AccessedThroughProperty("label1OSNOVNIOO")]
        private UltraLabel _label1OSNOVNIOO;
        [AccessedThroughProperty("label1SVRHAOBRACUNA")]
        private UltraLabel _label1SVRHAOBRACUNA;
        [AccessedThroughProperty("label1tjednifondsatiobracun")]
        private UltraLabel _label1tjednifondsatiobracun;
        [AccessedThroughProperty("label1VRSTAOBRACUNA")]
        private UltraLabel _label1VRSTAOBRACUNA;
        [AccessedThroughProperty("label1ZAKLJ")]
        private UltraLabel _label1ZAKLJ;
        [AccessedThroughProperty("linkLabelObracunRadnici")]
        private UltraLabel _linkLabelObracunRadnici;
        [AccessedThroughProperty("linkLabelObracunRadniciAdd")]
        private UltraLabel _linkLabelObracunRadniciAdd;
        [AccessedThroughProperty("linkLabelObracunRadniciDelete")]
        private UltraLabel _linkLabelObracunRadniciDelete;
        [AccessedThroughProperty("linkLabelObracunRadniciUpdate")]
        private UltraLabel _linkLabelObracunRadniciUpdate;
        [AccessedThroughProperty("panelactionsObracunRadnici")]
        private Panel _panelactionsObracunRadnici;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textGODINAISPLATE")]
        private UltraTextEditor _textGODINAISPLATE;
        [AccessedThroughProperty("textGODINAOBRACUNA")]
        private UltraTextEditor _textGODINAOBRACUNA;
        [AccessedThroughProperty("textIDOBRACUN")]
        private UltraTextEditor _textIDOBRACUN;
        [AccessedThroughProperty("textMJESECISPLATE")]
        private UltraTextEditor _textMJESECISPLATE;
        [AccessedThroughProperty("textMJESECNIFONDSATIOBRACUN")]
        private UltraNumericEditor _textMJESECNIFONDSATIOBRACUN;
        [AccessedThroughProperty("textMJESECOBRACUNA")]
        private UltraTextEditor _textMJESECOBRACUNA;
        [AccessedThroughProperty("textOBRACUNSKAOSNOVICA")]
        private UltraNumericEditor _textOBRACUNSKAOSNOVICA;
        [AccessedThroughProperty("textOSNOVNIOO")]
        private UltraNumericEditor _textOSNOVNIOO;
        [AccessedThroughProperty("textSVRHAOBRACUNA")]
        private UltraTextEditor _textSVRHAOBRACUNA;
        [AccessedThroughProperty("texttjednifondsatiobracun")]
        private UltraNumericEditor _texttjednifondsatiobracun;
        [AccessedThroughProperty("textVRSTAOBRACUNA")]
        private UltraTextEditor _textVRSTAOBRACUNA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOBRACUN;
        private BindingSource bindingSourceObracunRadnici;
        private IContainer components = null;
        private OBRACUNDataSet dsOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformOBRACUN;
        protected TableLayoutPanel layoutManagerpanelactionsObracunRadnici;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OBRACUNDataSet.OBRACUNRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OBRACUN";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OBRACUNDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OBRACUNFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptInLinesDOPRINOSIDDOPRINOS(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.OBRACUNController.SelectDOPRINOSIDDOPRINOS("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["IDDOPRINOS"]);
                    row3["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["VBDIDOPRINOS"]);
                    row3["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["ZRNDOPRINOS"]);
                    row3["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["NAZIVDOPRINOS"]);
                    row3["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["IDVRSTADOPRINOS"]);
                    row3["STOPA"] = RuntimeHelpers.GetObjectValue(row2["STOPA"]);
                    row3["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MODOPRINOS"]);
                    row3["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["PODOPRINOS"]);
                    row3["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MZDOPRINOS"]);
                    row3["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["PZDOPRINOS"]);
                    row3["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJDOPRINOS1"]);
                    row3["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJDOPRINOS2"]);
                    row3["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJADOPRINOS"]);
                    row3["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJADOPRINOS"]);
                    row3["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MINDOPRINOS"]);
                    row3["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MAXDOPRINOS"]);
                    row3["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["NAZIVVRSTADOPRINOS"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesKREDITORIDKREDITOR(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.OBRACUNController.SelectKREDITORIDKREDITOR("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["IDKREDITOR"]);
                    row3["NAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["NAZIVKREDITOR"]);
                    row3["VBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["VBDIKREDITOR"]);
                    row3["ZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["ZRNKREDITOR"]);
                    row3["PRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKREDITOR1"]);
                    row3["PRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKREDITOR2"]);
                    row3["PRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKREDITOR3"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesKRIZNIPOREZIDKRIZNIPOREZ(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.OBRACUNController.SelectKRIZNIPOREZIDKRIZNIPOREZ("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(row2["IDKRIZNIPOREZ"]);
                    row3["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(row2["NAZIVKRIZNIPOREZ"]);
                    row3["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(row2["KRIZNISTOPA"]);
                    row3["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["MOKRIZNI"]);
                    row3["POKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["POKRIZNI"]);
                    row3["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["MZKRIZNI"]);
                    row3["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["PZKRIZNI"]);
                    row3["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKRIZNI1"]);
                    row3["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKRIZNI2"]);
                    row3["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKRIZNI3"]);
                    row3["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJAKRIZNI"]);
                    row3["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJAKRIZNI"]);
                    row3["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["VBDIKRIZNI"]);
                    row3["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["ZRNKRIZNI"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesOBUSTAVAIDOBUSTAVA(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.OBRACUNController.SelectOBUSTAVAIDOBUSTAVA("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["IDOBUSTAVA"]);
                    row3["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["NAZIVOBUSTAVA"]);
                    row3["MOOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["MOOBUSTAVA"]);
                    row3["POOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["POOBUSTAVA"]);
                    row3["MZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["MZOBUSTAVA"]);
                    row3["PZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["PZOBUSTAVA"]);
                    row3["VBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["VBDIOBUSTAVA"]);
                    row3["ZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["ZRNOBUSTAVA"]);
                    row3["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOBUSTAVA1"]);
                    row3["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOBUSTAVA2"]);
                    row3["PRIMATELJOBUSTAVA3"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOBUSTAVA3"]);
                    row3["SIFRAOPISAPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJAOBUSTAVA"]);
                    row3["OPISPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJAOBUSTAVA"]);
                    row3["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(row2["VRSTAOBUSTAVE"]);
                    row3["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(row2["NAZIVVRSTAOBUSTAVE"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesOLAKSICEIDOLAKSICE(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.OBRACUNController.SelectOLAKSICEIDOLAKSICE("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["IDOLAKSICE"]);
                    row3["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["NAZIVOLAKSICE"]);
                    row3["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["IDGRUPEOLAKSICA"]);
                    row3["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["IDTIPOLAKSICE"]);
                    row3["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["VBDIOLAKSICA"]);
                    row3["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["ZRNOLAKSICA"]);
                    row3["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOLAKSICA1"]);
                    row3["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOLAKSICA2"]);
                    row3["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOLAKSICA3"]);
                    row3["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["NAZIVGRUPEOLAKSICA"]);
                    row3["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(row2["MAXIMALNIIZNOSGRUPE"]);
                    row3["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["NAZIVTIPOLAKSICE"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesPOREZIDPOREZ(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.OBRACUNController.SelectPOREZIDPOREZ("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDPOREZ"] = RuntimeHelpers.GetObjectValue(row2["IDPOREZ"]);
                    row3["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(row2["NAZIVPOREZ"]);
                    row3["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(row2["STOPAPOREZA"]);
                    row3["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(row2["POREZMJESECNO"]);
                    row3["MOPOREZ"] = RuntimeHelpers.GetObjectValue(row2["MOPOREZ"]);
                    row3["POPOREZ"] = RuntimeHelpers.GetObjectValue(row2["POPOREZ"]);
                    row3["MZPOREZ"] = RuntimeHelpers.GetObjectValue(row2["MZPOREZ"]);
                    row3["PZPOREZ"] = RuntimeHelpers.GetObjectValue(row2["PZPOREZ"]);
                    row3["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJPOREZ1"]);
                    row3["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJPOREZ2"]);
                    row3["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJAPOREZ"]);
                    row3["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJAPOREZ"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsOBRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceOBRACUN.DataSource = this.OBRACUNController.DataSet;
            this.dsOBRACUNDataSet1 = this.OBRACUNController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, DataView enumList, string Id, string Name, bool overrideList)
        {
            ValueList myValueList = null;
            if (overrideList && dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists[valueListName];
                myValueList.ValueListItems.Clear();
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (myValueList != null)
            {
                LoadValueList(myValueList, enumList, Id, Name);
            }
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsOBRACUNDataSet1.OBRACUN.Rows.GetEnumerator();
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
                if (this.OBRACUNController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if (column.CellActivation == Activation.AllowEdit)
            {
                switch (Conversions.ToString(column.Tag))
                {
                    case "RADNIKIDRADNIKAddNew":
                        this.PictureBoxClickedInLinesIDRADNIK(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DOPRINOSIDDOPRINOS":
                        this.CallPromptInLinesDOPRINOSIDDOPRINOS(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "POREZIDPOREZ":
                        this.CallPromptInLinesPOREZIDPOREZ(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "OLAKSICEIDOLAKSICE":
                        this.CallPromptInLinesOLAKSICEIDOLAKSICE(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KREDITORIDKREDITOR":
                        this.CallPromptInLinesKREDITORIDKREDITOR(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "OBUSTAVAIDOBUSTAVA":
                        this.CallPromptInLinesOBUSTAVAIDOBUSTAVA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "ELEMENTIDELEMENTAddNew":
                        this.PictureBoxClickedInLinesIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KRIZNIPOREZIDKRIZNIPOREZ":
                        this.CallPromptInLinesKRIZNIPOREZIDKRIZNIPOREZ(RuntimeHelpers.GetObjectValue(sender), e);
                        break;
                }
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

        private void EndEditCurrentRow()
        {
            if (this.grdLevelObracunRadnici.ActiveRow != null)
            {
                this.grdLevelObracunRadnici.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grd_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
        }

        private void grd_CellListSelect(object sender, CellEventArgs e)
        {
            if (e.Cell.ValueListResolved != null)
            {
                DataView tag = (DataView) ((ValueList) e.Cell.ValueListResolved).Tag;
                int selectedItemIndex = e.Cell.ValueListResolved.SelectedItemIndex;
                DataRow result = null;
                if ((tag.Count > selectedItemIndex) && (selectedItemIndex >= 0))
                {
                    result = tag[selectedItemIndex].Row;
                }
                if (e.Cell.Column.Key == "IDRADNIK")
                {
                    this.UpdateValuesIDRADNIK(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "IDELEMENT")
                {
                    this.UpdateValuesIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelObracunRadnici_AfterRowActivate(object sender, EventArgs e)
        {
            string oBRACUNObracunRadniciLevelDescription = StringResources.OBRACUNObracunRadniciLevelDescription;
            if (this.grdLevelObracunRadnici.ActiveRow != null)
            {
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunDoprinosi"))
                {
                    oBRACUNObracunRadniciLevelDescription = StringResources.OBRACUNObracunDoprinosiLevelDescription;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunPorezi"))
                {
                    oBRACUNObracunRadniciLevelDescription = StringResources.OBRACUNObracunPoreziLevelDescription;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunOlaksice"))
                {
                    oBRACUNObracunRadniciLevelDescription = StringResources.OBRACUNObracunOlaksiceLevelDescription;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_OBRACUNKrediti"))
                {
                    oBRACUNObracunRadniciLevelDescription = StringResources.OBRACUNOBRACUNKreditiLevelDescription;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_OBRACUNObustave"))
                {
                    oBRACUNObracunRadniciLevelDescription = StringResources.OBRACUNOBRACUNObustaveLevelDescription;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunElementi"))
                {
                    oBRACUNObracunRadniciLevelDescription = StringResources.OBRACUNObracunElementiLevelDescription;
                }
            }
            this.linkLabelObracunRadniciAdd.Text = Deklarit.Resources.Resources.Add + " " + oBRACUNObracunRadniciLevelDescription;
            this.linkLabelObracunRadniciUpdate.Text = Deklarit.Resources.Resources.Update + " " + oBRACUNObracunRadniciLevelDescription;
            this.linkLabelObracunRadniciDelete.Text = Deklarit.Resources.Resources.Delete + " " + oBRACUNObracunRadniciLevelDescription;
        }

        private void grdLevelObracunRadnici_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceOBRACUN.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceOBRACUN.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelObracunRadnici_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.ObracunRadniciUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelObracunRadnici_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceOBRACUN, this.OBRACUNController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OBRACUN", this.m_Mode, this.dsOBRACUNDataSet1, this.dsOBRACUNDataSet1.OBRACUN.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceOBRACUN, "DATUMISPLATE", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerDATUMISPLATE.DataBindings["Text"] != null)
            {
                this.datePickerDATUMISPLATE.DataBindings.Remove(this.datePickerDATUMISPLATE.DataBindings["Text"]);
            }
            this.datePickerDATUMISPLATE.DataBindings.Add(binding);
            Binding binding2 = new Binding("Text", this.bindingSourceOBRACUN, "DATUMOBRACUNASTAZA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMOBRACUNASTAZA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMOBRACUNASTAZA.DataBindings.Remove(this.datePickerDATUMOBRACUNASTAZA.DataBindings["Text"]);
            }
            this.datePickerDATUMOBRACUNASTAZA.DataBindings.Add(binding2);
            Binding binding5 = new Binding("CheckState", this.bindingSourceOBRACUN, "OBRPOSTOTNIH", true);
            binding5.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding5.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkOBRPOSTOTNIH.DataBindings["CheckState"] != null)
            {
                this.checkOBRPOSTOTNIH.DataBindings.Remove(this.checkOBRPOSTOTNIH.DataBindings["CheckState"]);
            }
            this.checkOBRPOSTOTNIH.DataBindings.Add(binding5);
            Binding binding3 = new Binding("CheckState", this.bindingSourceOBRACUN, "OBRFIKSNIH", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkOBRFIKSNIH.DataBindings["CheckState"] != null)
            {
                this.checkOBRFIKSNIH.DataBindings.Remove(this.checkOBRFIKSNIH.DataBindings["CheckState"]);
            }
            this.checkOBRFIKSNIH.DataBindings.Add(binding3);
            Binding binding4 = new Binding("CheckState", this.bindingSourceOBRACUN, "OBRKREDITNIH", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding4.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkOBRKREDITNIH.DataBindings["CheckState"] != null)
            {
                this.checkOBRKREDITNIH.DataBindings.Remove(this.checkOBRKREDITNIH.DataBindings["CheckState"]);
            }
            this.checkOBRKREDITNIH.DataBindings.Add(binding4);
            Binding binding6 = new Binding("CheckState", this.bindingSourceOBRACUN, "ZAKLJ", true);
            binding6.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding6.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkZAKLJ.DataBindings["CheckState"] != null)
            {
                this.checkZAKLJ.DataBindings.Remove(this.checkZAKLJ.DataBindings["CheckState"]);
            }
            this.checkZAKLJ.DataBindings.Add(binding6);
            if (!this.m_DataGrids.Contains(this.grdLevelObracunRadnici))
            {
                this.m_DataGrids.Add(this.grdLevelObracunRadnici);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOBRACUNDataSet1.OBRACUN[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OBRACUNDataSet.OBRACUNRow) ((DataRowView) this.bindingSourceOBRACUN.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OBRACUNFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOBRACUN = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBRACUN).BeginInit();
            this.bindingSourceObracunRadnici = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunRadnici).BeginInit();
            this.layoutManagerformOBRACUN = new TableLayoutPanel();
            this.layoutManagerformOBRACUN.SuspendLayout();
            this.layoutManagerformOBRACUN.AutoSize = true;
            this.layoutManagerformOBRACUN.Dock = DockStyle.Fill;
            this.layoutManagerformOBRACUN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOBRACUN.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOBRACUN.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOBRACUN.Size = size;
            this.layoutManagerformOBRACUN.ColumnCount = 2;
            this.layoutManagerformOBRACUN.RowCount = 0x13;
            this.layoutManagerformOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUN.RowStyles.Add(new RowStyle());
            this.label1IDOBRACUN = new UltraLabel();
            this.textIDOBRACUN = new UltraTextEditor();
            this.label1VRSTAOBRACUNA = new UltraLabel();
            this.textVRSTAOBRACUNA = new UltraTextEditor();
            this.label1MJESECOBRACUNA = new UltraLabel();
            this.textMJESECOBRACUNA = new UltraTextEditor();
            this.label1GODINAOBRACUNA = new UltraLabel();
            this.textGODINAOBRACUNA = new UltraTextEditor();
            this.label1MJESECISPLATE = new UltraLabel();
            this.textMJESECISPLATE = new UltraTextEditor();
            this.label1GODINAISPLATE = new UltraLabel();
            this.textGODINAISPLATE = new UltraTextEditor();
            this.label1DATUMISPLATE = new UltraLabel();
            this.datePickerDATUMISPLATE = new UltraDateTimeEditor();
            this.label1tjednifondsatiobracun = new UltraLabel();
            this.texttjednifondsatiobracun = new UltraNumericEditor();
            this.label1MJESECNIFONDSATIOBRACUN = new UltraLabel();
            this.textMJESECNIFONDSATIOBRACUN = new UltraNumericEditor();
            this.label1OSNOVNIOO = new UltraLabel();
            this.textOSNOVNIOO = new UltraNumericEditor();
            this.label1OBRACUNSKAOSNOVICA = new UltraLabel();
            this.textOBRACUNSKAOSNOVICA = new UltraNumericEditor();
            this.label1DATUMOBRACUNASTAZA = new UltraLabel();
            this.datePickerDATUMOBRACUNASTAZA = new UltraDateTimeEditor();
            this.label1OBRPOSTOTNIH = new UltraLabel();
            this.checkOBRPOSTOTNIH = new UltraCheckEditor();
            this.label1OBRFIKSNIH = new UltraLabel();
            this.checkOBRFIKSNIH = new UltraCheckEditor();
            this.label1OBRKREDITNIH = new UltraLabel();
            this.checkOBRKREDITNIH = new UltraCheckEditor();
            this.label1ZAKLJ = new UltraLabel();
            this.checkZAKLJ = new UltraCheckEditor();
            this.label1SVRHAOBRACUNA = new UltraLabel();
            this.textSVRHAOBRACUNA = new UltraTextEditor();
            this.grdLevelObracunRadnici = new UltraGrid();
            this.panelactionsObracunRadnici = new Panel();
            this.layoutManagerpanelactionsObracunRadnici = new TableLayoutPanel();
            this.layoutManagerpanelactionsObracunRadnici.AutoSize = true;
            this.layoutManagerpanelactionsObracunRadnici.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsObracunRadnici.ColumnCount = 4;
            this.layoutManagerpanelactionsObracunRadnici.RowCount = 1;
            this.layoutManagerpanelactionsObracunRadnici.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsObracunRadnici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunRadnici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunRadnici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunRadnici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunRadnici.RowStyles.Add(new RowStyle());
            this.linkLabelObracunRadniciAdd = new UltraLabel();
            this.linkLabelObracunRadniciUpdate = new UltraLabel();
            this.linkLabelObracunRadniciDelete = new UltraLabel();
            this.linkLabelObracunRadnici = new UltraLabel();
            ((ISupportInitialize) this.textIDOBRACUN).BeginInit();
            ((ISupportInitialize) this.textVRSTAOBRACUNA).BeginInit();
            ((ISupportInitialize) this.textMJESECOBRACUNA).BeginInit();
            ((ISupportInitialize) this.textGODINAOBRACUNA).BeginInit();
            ((ISupportInitialize) this.textMJESECISPLATE).BeginInit();
            ((ISupportInitialize) this.textGODINAISPLATE).BeginInit();
            ((ISupportInitialize) this.texttjednifondsatiobracun).BeginInit();
            ((ISupportInitialize) this.textMJESECNIFONDSATIOBRACUN).BeginInit();
            ((ISupportInitialize) this.textOSNOVNIOO).BeginInit();
            ((ISupportInitialize) this.textOBRACUNSKAOSNOVICA).BeginInit();
            ((ISupportInitialize) this.textSVRHAOBRACUNA).BeginInit();
            ((ISupportInitialize) this.grdLevelObracunRadnici).BeginInit();
            this.panelactionsObracunRadnici.SuspendLayout();
            this.layoutManagerpanelactionsObracunRadnici.SuspendLayout();
            UltraGridBand band9 = new UltraGridBand("ObracunRadnici", -1);
            UltraGridColumn column183 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column185 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column186 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column222 = new UltraGridColumn("PREZIME");
            UltraGridColumn column190 = new UltraGridColumn("IME");
            UltraGridColumn column233 = new UltraGridColumn("ulica");
            UltraGridColumn column198 = new UltraGridColumn("mjesto");
            UltraGridColumn column195 = new UltraGridColumn("kucnibroj");
            UltraGridColumn column192 = new UltraGridColumn("JMBG");
            UltraGridColumn column176 = new UltraGridColumn("DATUMRODJENJA");
            UltraGridColumn column210 = new UltraGridColumn("OPCINARADAIDOPCINE");
            UltraGridColumn column211 = new UltraGridColumn("OPCINARADANAZIVOPCINE");
            UltraGridColumn column212 = new UltraGridColumn("OPCINARADAPRIREZ");
            UltraGridColumn column213 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column214 = new UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            UltraGridColumn column215 = new UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            UltraGridColumn column226 = new UltraGridColumn("SIFRAOPCINESTANOVANJA");
            UltraGridColumn column181 = new UltraGridColumn("IDBENEFICIRANI");
            UltraGridColumn column202 = new UltraGridColumn("NAZIVBENEFICIRANI");
            UltraGridColumn column172 = new UltraGridColumn("BROJPRIZNATIHMJESECI");
            UltraGridColumn column180 = new UltraGridColumn("IDBANKE");
            UltraGridColumn column199 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column200 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column201 = new UltraGridColumn("NAZIVBANKE3");
            UltraGridColumn column235 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column237 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column228 = new UltraGridColumn("TEKUCI");
            UltraGridColumn column227 = new UltraGridColumn("SIFRAOPISAPLACANJANETO");
            UltraGridColumn column216 = new UltraGridColumn("OPISPLACANJANETO");
            UltraGridColumn column171 = new UltraGridColumn("BROJMIROVINSKOG");
            UltraGridColumn column173 = new UltraGridColumn("BROJZDRAVSTVENOG");
            UltraGridColumn column196 = new UltraGridColumn("MBO");
            UltraGridColumn column219 = new UltraGridColumn("POSTOTAKOSLOBODJENJAODPOREZA");
            UltraGridColumn column193 = new UltraGridColumn("KOEFICIJENT");
            UltraGridColumn column207 = new UltraGridColumn("OBRACUNSKIKOEFICIJENT");
            UltraGridColumn column187 = new UltraGridColumn("IDRADNOMJESTO");
            UltraGridColumn column203 = new UltraGridColumn("NAZIVRADNOMJESTO");
            UltraGridColumn column231 = new UltraGridColumn("TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
            UltraGridColumn column232 = new UltraGridColumn("TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            UltraGridColumn column220 = new UltraGridColumn("POTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
            UltraGridColumn column221 = new UltraGridColumn("POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            UltraGridColumn column188 = new UltraGridColumn("IDSTRUKA");
            UltraGridColumn column204 = new UltraGridColumn("NAZIVSTRUKA");
            UltraGridColumn column224 = new UltraGridColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column225 = new UltraGridColumn("RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column170 = new UltraGridColumn("AKTIVAN");
            UltraGridColumn column191 = new UltraGridColumn("ISKORISTENOOO");
            UltraGridColumn column206 = new UltraGridColumn("OBRACUNATIPRIREZ");
            UltraGridColumn column178 = new UltraGridColumn("faktoo");
            UltraGridColumn column177 = new UltraGridColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI");
            UltraGridColumn column229 = new UltraGridColumn("TJEDNIFONDSATI");
            UltraGridColumn column230 = new UltraGridColumn("TJEDNIFONDSATISTAZ");
            UltraGridColumn column179 = new UltraGridColumn("GODINESTAZA");
            UltraGridColumn column197 = new UltraGridColumn("MJESECISTAZA");
            UltraGridColumn column174 = new UltraGridColumn("DANISTAZA");
            UltraGridColumn column175 = new UltraGridColumn("DATUMPRESTANKARADNOGODNOSA");
            UltraGridColumn column189 = new UltraGridColumn("IDTITULA");
            UltraGridColumn column205 = new UltraGridColumn("NAZIVTITULA");
            UltraGridColumn column236 = new UltraGridColumn("ZBIRNINETO");
            UltraGridColumn column234 = new UltraGridColumn("UZIMAUOBZIROSNOVICEDOPRINOSA");
            UltraGridColumn column184 = new UltraGridColumn("IDORGDIO");
            UltraGridColumn column217 = new UltraGridColumn("ORGANIZACIJSKIDIO");
            UltraGridColumn column182 = new UltraGridColumn("IDIPIDENT");
            UltraGridColumn column209 = new UltraGridColumn("OIB");
            UltraGridColumn column218 = new UltraGridColumn("POSTOTAKNASTAZ");
            UltraGridColumn column223 = new UltraGridColumn("RADNIKOBRACUNOSNOVICA");
            UltraGridColumn column194 = new UltraGridColumn("KOREKCIJAPRIREZA");
            UltraGridColumn column208 = new UltraGridColumn("ODBITAKPRIJEKOREKCIJE");
            UltraGridBand band = new UltraGridBand("ObracunRadnici_ObracunDoprinosi", 0);
            UltraGridColumn column2 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column3 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column4 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column21 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column22 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column10 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column5 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column11 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column20 = new UltraGridColumn("STOPA");
            UltraGridColumn column8 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column15 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column9 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column18 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column16 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column17 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column19 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column13 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column12 = new UltraGridColumn("OBRACUNATIDOPRINOS");
            UltraGridColumn column14 = new UltraGridColumn("OSNOVICADOPRINOS");
            UltraGridColumn column7 = new UltraGridColumn("MINDOPRINOS");
            UltraGridColumn column6 = new UltraGridColumn("MAXDOPRINOS");
            UltraGridBand band8 = new UltraGridBand("ObracunRadnici_ObracunPorezi", 0);
            UltraGridColumn column153 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column155 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column156 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column154 = new UltraGridColumn("IDPOREZ");
            UltraGridColumn column159 = new UltraGridColumn("NAZIVPOREZ");
            UltraGridColumn column169 = new UltraGridColumn("STOPAPOREZA");
            UltraGridColumn column164 = new UltraGridColumn("POREZMJESECNO");
            UltraGridColumn column157 = new UltraGridColumn("MOPOREZ");
            UltraGridColumn column163 = new UltraGridColumn("POPOREZ");
            UltraGridColumn column158 = new UltraGridColumn("MZPOREZ");
            UltraGridColumn column167 = new UltraGridColumn("PZPOREZ");
            UltraGridColumn column165 = new UltraGridColumn("PRIMATELJPOREZ1");
            UltraGridColumn column166 = new UltraGridColumn("PRIMATELJPOREZ2");
            UltraGridColumn column168 = new UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            UltraGridColumn column161 = new UltraGridColumn("OPISPLACANJAPOREZ");
            UltraGridColumn column160 = new UltraGridColumn("OBRACUNATIPOREZ");
            UltraGridColumn column162 = new UltraGridColumn("OSNOVICAPOREZ");
            UltraGridBand band7 = new UltraGridBand("ObracunRadnici_ObracunOlaksice", 0);
            UltraGridColumn column131 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column133 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column134 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column132 = new UltraGridColumn("IDOLAKSICE");
            UltraGridColumn column141 = new UltraGridColumn("NAZIVOLAKSICE");
            UltraGridColumn column130 = new UltraGridColumn("IDGRUPEOLAKSICA");
            UltraGridColumn column140 = new UltraGridColumn("NAZIVGRUPEOLAKSICA");
            UltraGridColumn column137 = new UltraGridColumn("MAXIMALNIIZNOSGRUPE");
            UltraGridColumn column135 = new UltraGridColumn("IDTIPOLAKSICE");
            UltraGridColumn column142 = new UltraGridColumn("NAZIVTIPOLAKSICE");
            UltraGridColumn column151 = new UltraGridColumn("VBDIOLAKSICA");
            UltraGridColumn column152 = new UltraGridColumn("ZRNOLAKSICA");
            UltraGridColumn column146 = new UltraGridColumn("PRIMATELJOLAKSICA1");
            UltraGridColumn column147 = new UltraGridColumn("PRIMATELJOLAKSICA2");
            UltraGridColumn column148 = new UltraGridColumn("PRIMATELJOLAKSICA3");
            UltraGridColumn column139 = new UltraGridColumn("MZOLAKSICA");
            UltraGridColumn column149 = new UltraGridColumn("PZOLAKSICA");
            UltraGridColumn column138 = new UltraGridColumn("MOOLAKSICA");
            UltraGridColumn column145 = new UltraGridColumn("POOLAKSICA");
            UltraGridColumn column150 = new UltraGridColumn("SIFRAOPISAPLACANJAOLAKSICA");
            UltraGridColumn column144 = new UltraGridColumn("OPISPLACANJAOLAKSICA");
            UltraGridColumn column136 = new UltraGridColumn("IZNOSOLAKSICE");
            UltraGridColumn column143 = new UltraGridColumn("OBRACUNATAOLAKSICA");
            UltraGridBand band3 = new UltraGridBand("ObracunRadnici_OBRACUNKrediti", 0);
            UltraGridColumn column45 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column46 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column47 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column44 = new UltraGridColumn("IDKREDITOR");
            UltraGridColumn column42 = new UltraGridColumn("DATUMUGOVORA");
            UltraGridColumn column48 = new UltraGridColumn("NAZIVKREDITOR");
            UltraGridColumn column61 = new UltraGridColumn("VBDIKREDITOR");
            UltraGridColumn column64 = new UltraGridColumn("ZRNKREDITOR");
            UltraGridColumn column57 = new UltraGridColumn("PRIMATELJKREDITOR1");
            UltraGridColumn column58 = new UltraGridColumn("PRIMATELJKREDITOR2");
            UltraGridColumn column59 = new UltraGridColumn("PRIMATELJKREDITOR3");
            UltraGridColumn column56 = new UltraGridColumn("OBRSIFRAOPISAPLACANJAKREDITOR");
            UltraGridColumn column53 = new UltraGridColumn("OBROPISPLACANJAKREDITOR");
            UltraGridColumn column51 = new UltraGridColumn("OBRMOKREDITOR");
            UltraGridColumn column54 = new UltraGridColumn("OBRPOKREDITOR");
            UltraGridColumn column52 = new UltraGridColumn("OBRMZKREDITOR");
            UltraGridColumn column55 = new UltraGridColumn("OBRPZKREDITOR");
            UltraGridColumn column50 = new UltraGridColumn("OBRIZNOSRATEKREDITOR");
            UltraGridColumn column49 = new UltraGridColumn("OBRACUNATIKUNSKIIZNOS");
            UltraGridColumn column62 = new UltraGridColumn("VECOTPLACENOBROJRATA");
            UltraGridColumn column63 = new UltraGridColumn("VECOTPLACENOUKUPNIIZNOS");
            UltraGridColumn column60 = new UltraGridColumn("UKUPNIZNOSKREDITA");
            UltraGridColumn column43 = new UltraGridColumn("DOSADAOBUSTAVLJENO");
            UltraGridColumn column41 = new UltraGridColumn("BRRATADOSADA");
            UltraGridBand band6 = new UltraGridBand("ObracunRadnici_OBRACUNObustave", 0);
            UltraGridColumn column104 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column106 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column107 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column105 = new UltraGridColumn("IDOBUSTAVA");
            UltraGridColumn column112 = new UltraGridColumn("NAZIVOBUSTAVA");
            UltraGridColumn column110 = new UltraGridColumn("MOOBUSTAVA");
            UltraGridColumn column119 = new UltraGridColumn("POOBUSTAVA");
            UltraGridColumn column111 = new UltraGridColumn("MZOBUSTAVA");
            UltraGridColumn column124 = new UltraGridColumn("PZOBUSTAVA");
            UltraGridColumn column127 = new UltraGridColumn("VBDIOBUSTAVA");
            UltraGridColumn column129 = new UltraGridColumn("ZRNOBUSTAVA");
            UltraGridColumn column121 = new UltraGridColumn("PRIMATELJOBUSTAVA1");
            UltraGridColumn column122 = new UltraGridColumn("PRIMATELJOBUSTAVA2");
            UltraGridColumn column123 = new UltraGridColumn("PRIMATELJOBUSTAVA3");
            UltraGridColumn column126 = new UltraGridColumn("SIFRAOPISAPLACANJAOBUSTAVA");
            UltraGridColumn column118 = new UltraGridColumn("OPISPLACANJAOBUSTAVA");
            UltraGridColumn column128 = new UltraGridColumn("VRSTAOBUSTAVE");
            UltraGridColumn column113 = new UltraGridColumn("NAZIVVRSTAOBUSTAVE");
            UltraGridColumn column109 = new UltraGridColumn("IZNOSOBUSTAVE");
            UltraGridColumn column120 = new UltraGridColumn("POSTOTAKOBUSTAVE");
            UltraGridColumn column114 = new UltraGridColumn("OBRACUNATAOBUSTAVAUKUNAMA");
            UltraGridColumn column108 = new UltraGridColumn("ISPLACENOKASA");
            UltraGridColumn column125 = new UltraGridColumn("SALDOKASA");
            UltraGridColumn column115 = new UltraGridColumn("OBUSTAVLJENODOSADA");
            UltraGridColumn column116 = new UltraGridColumn("OBUSTAVLJENODOSADABROJRATA");
            UltraGridColumn column117 = new UltraGridColumn("OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE");
            UltraGridBand band2 = new UltraGridBand("ObracunRadnici_ObracunElementi", 0);
            UltraGridColumn column27 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column29 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column30 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column25 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column26 = new UltraGridColumn("columnIDELEMENTAddNew", 1);
            UltraGridColumn column24 = new UltraGridColumn("ELEMENTRAZDOBLJEOD");
            UltraGridColumn column23 = new UltraGridColumn("ELEMENTRAZDOBLJEDO");
            UltraGridColumn column28 = new UltraGridColumn("IDOSNOVAOSIGURANJA");
            UltraGridColumn column33 = new UltraGridColumn("NAZIVOSNOVAOSIGURANJA");
            UltraGridColumn column39 = new UltraGridColumn("RAZDOBLJESESMIJEPREKLAPATI");
            UltraGridColumn column37 = new UltraGridColumn("OBRSATI");
            UltraGridColumn column38 = new UltraGridColumn("OBRSATNICA");
            UltraGridColumn column35 = new UltraGridColumn("OBRIZNOS");
            UltraGridColumn column32 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column31 = new UltraGridColumn("IDVRSTAELEMENTA");
            UltraGridColumn column34 = new UltraGridColumn("NAZIVVRSTAELEMENT");
            UltraGridColumn column36 = new UltraGridColumn("OBRPOSTOTAK");
            UltraGridColumn column40 = new UltraGridColumn("ZBRAJASATEUFONDSATI");
            UltraGridBand band5 = new UltraGridBand("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni", 0);
            UltraGridColumn column82 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column83 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column84 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column81 = new UltraGridColumn("IDKRIZNIPOREZ");
            UltraGridColumn column88 = new UltraGridColumn("NAZIVKRIZNIPOREZ");
            UltraGridColumn column85 = new UltraGridColumn("KRIZNISTOPA");
            UltraGridColumn column86 = new UltraGridColumn("MOKRIZNI");
            UltraGridColumn column93 = new UltraGridColumn("POKRIZNI");
            UltraGridColumn column87 = new UltraGridColumn("MZKRIZNI");
            UltraGridColumn column100 = new UltraGridColumn("PZKRIZNI");
            UltraGridColumn column97 = new UltraGridColumn("PRIMATELJKRIZNI1");
            UltraGridColumn column98 = new UltraGridColumn("PRIMATELJKRIZNI2");
            UltraGridColumn column99 = new UltraGridColumn("PRIMATELJKRIZNI3");
            UltraGridColumn column101 = new UltraGridColumn("SIFRAOPISAPLACANJAKRIZNI");
            UltraGridColumn column89 = new UltraGridColumn("OPISPLACANJAKRIZNI");
            UltraGridColumn column102 = new UltraGridColumn("VBDIKRIZNI");
            UltraGridColumn column103 = new UltraGridColumn("ZRNKRIZNI");
            UltraGridColumn column90 = new UltraGridColumn("OSNOVICAKRIZNI");
            UltraGridColumn column94 = new UltraGridColumn("POREZKRIZNI");
            UltraGridColumn column91 = new UltraGridColumn("OSNOVICAPRETHODNA");
            UltraGridColumn column92 = new UltraGridColumn("OSNOVICAUKUPNA");
            UltraGridColumn column95 = new UltraGridColumn("POREZPRETHODNI");
            UltraGridColumn column96 = new UltraGridColumn("POREZUKUPNO");
            UltraGridBand band4 = new UltraGridBand("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece", 0);
            UltraGridColumn column65 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column67 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column68 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column66 = new UltraGridColumn("IDOBRACUNIZUZECE");
            UltraGridColumn column74 = new UltraGridColumn("PRIMATELJIZUZECE1");
            UltraGridColumn column75 = new UltraGridColumn("PRIMATELJIZUZECE2");
            UltraGridColumn column76 = new UltraGridColumn("PRIMATELJIZUZECE3");
            UltraGridColumn column78 = new UltraGridColumn("SIFRAOPISAPLACANJAIZUZECE");
            UltraGridColumn column72 = new UltraGridColumn("OPISPLACANJAIZUZECE");
            UltraGridColumn column80 = new UltraGridColumn("VBDIIZUZECE");
            UltraGridColumn column79 = new UltraGridColumn("TEKUCIIZUZECE");
            UltraGridColumn column70 = new UltraGridColumn("MOIZUZECE");
            UltraGridColumn column73 = new UltraGridColumn("POIZUZECE");
            UltraGridColumn column71 = new UltraGridColumn("MZIZUZECE");
            UltraGridColumn column77 = new UltraGridColumn("PZIZUZECE");
            UltraGridColumn column69 = new UltraGridColumn("IZNOSIZUZECA");
            this.dsOBRACUNDataSet1 = new OBRACUNDataSet();
            this.dsOBRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOBRACUNDataSet1.DataSetName = "dsOBRACUN";
            this.dsOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOBRACUN.DataSource = this.dsOBRACUNDataSet1;
            this.bindingSourceOBRACUN.DataMember = "OBRACUN";
            ((ISupportInitialize) this.bindingSourceOBRACUN).BeginInit();
            this.bindingSourceObracunRadnici.DataSource = this.bindingSourceOBRACUN;
            this.bindingSourceObracunRadnici.DataMember = "OBRACUN_ObracunRadnici";
            point = new System.Drawing.Point(0, 0);
            this.label1IDOBRACUN.Location = point;
            this.label1IDOBRACUN.Name = "label1IDOBRACUN";
            this.label1IDOBRACUN.TabIndex = 1;
            this.label1IDOBRACUN.Tag = "labelIDOBRACUN";
            this.label1IDOBRACUN.Text = ":";
            this.label1IDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDOBRACUN.AutoSize = true;
            this.label1IDOBRACUN.Anchor = AnchorStyles.Left;
            this.label1IDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBRACUN.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOBRACUN.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOBRACUN.ImageSize = size;
            this.label1IDOBRACUN.Appearance.ForeColor = Color.Black;
            this.label1IDOBRACUN.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1IDOBRACUN, 0, 0);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1IDOBRACUN, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1IDOBRACUN, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x10, 0x17);
            this.label1IDOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOBRACUN.Location = point;
            this.textIDOBRACUN.Name = "textIDOBRACUN";
            this.textIDOBRACUN.Tag = "IDOBRACUN";
            this.textIDOBRACUN.TabIndex = 0;
            this.textIDOBRACUN.Anchor = AnchorStyles.Left;
            this.textIDOBRACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOBRACUN.ReadOnly = false;
            this.textIDOBRACUN.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUN, "IDOBRACUN"));
            this.textIDOBRACUN.MaxLength = 11;
            this.layoutManagerformOBRACUN.Controls.Add(this.textIDOBRACUN, 1, 0);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textIDOBRACUN, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textIDOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textIDOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VRSTAOBRACUNA.Location = point;
            this.label1VRSTAOBRACUNA.Name = "label1VRSTAOBRACUNA";
            this.label1VRSTAOBRACUNA.TabIndex = 1;
            this.label1VRSTAOBRACUNA.Tag = "labelVRSTAOBRACUNA";
            this.label1VRSTAOBRACUNA.Text = "VRSTAOBRACUNA:";
            this.label1VRSTAOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1VRSTAOBRACUNA.AutoSize = true;
            this.label1VRSTAOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1VRSTAOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRSTAOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1VRSTAOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1VRSTAOBRACUNA, 0, 1);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1VRSTAOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1VRSTAOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRSTAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRSTAOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x83, 0x17);
            this.label1VRSTAOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRSTAOBRACUNA.Location = point;
            this.textVRSTAOBRACUNA.Name = "textVRSTAOBRACUNA";
            this.textVRSTAOBRACUNA.Tag = "VRSTAOBRACUNA";
            this.textVRSTAOBRACUNA.TabIndex = 0;
            this.textVRSTAOBRACUNA.Anchor = AnchorStyles.Left;
            this.textVRSTAOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVRSTAOBRACUNA.ReadOnly = false;
            this.textVRSTAOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUN, "VRSTAOBRACUNA"));
            this.textVRSTAOBRACUNA.MaxLength = 2;
            this.layoutManagerformOBRACUN.Controls.Add(this.textVRSTAOBRACUNA, 1, 1);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textVRSTAOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textVRSTAOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRSTAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textVRSTAOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textVRSTAOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MJESECOBRACUNA.Location = point;
            this.label1MJESECOBRACUNA.Name = "label1MJESECOBRACUNA";
            this.label1MJESECOBRACUNA.TabIndex = 1;
            this.label1MJESECOBRACUNA.Tag = "labelMJESECOBRACUNA";
            this.label1MJESECOBRACUNA.Text = "Mjesec obraeuna:";
            this.label1MJESECOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1MJESECOBRACUNA.AutoSize = true;
            this.label1MJESECOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1MJESECOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1MJESECOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1MJESECOBRACUNA, 0, 2);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1MJESECOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1MJESECOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESECOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESECOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x7c, 0x17);
            this.label1MJESECOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESECOBRACUNA.Location = point;
            this.textMJESECOBRACUNA.Name = "textMJESECOBRACUNA";
            this.textMJESECOBRACUNA.Tag = "MJESECOBRACUNA";
            this.textMJESECOBRACUNA.TabIndex = 0;
            this.textMJESECOBRACUNA.Anchor = AnchorStyles.Left;
            this.textMJESECOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMJESECOBRACUNA.ReadOnly = false;
            this.textMJESECOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUN, "MJESECOBRACUNA"));
            this.textMJESECOBRACUNA.MaxLength = 2;
            this.layoutManagerformOBRACUN.Controls.Add(this.textMJESECOBRACUNA, 1, 2);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textMJESECOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textMJESECOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GODINAOBRACUNA.Location = point;
            this.label1GODINAOBRACUNA.Name = "label1GODINAOBRACUNA";
            this.label1GODINAOBRACUNA.TabIndex = 1;
            this.label1GODINAOBRACUNA.Tag = "labelGODINAOBRACUNA";
            this.label1GODINAOBRACUNA.Text = "Godina obraeuna:";
            this.label1GODINAOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1GODINAOBRACUNA.AutoSize = true;
            this.label1GODINAOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1GODINAOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINAOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1GODINAOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1GODINAOBRACUNA, 0, 3);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1GODINAOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1GODINAOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GODINAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINAOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x7d, 0x17);
            this.label1GODINAOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINAOBRACUNA.Location = point;
            this.textGODINAOBRACUNA.Name = "textGODINAOBRACUNA";
            this.textGODINAOBRACUNA.Tag = "GODINAOBRACUNA";
            this.textGODINAOBRACUNA.TabIndex = 0;
            this.textGODINAOBRACUNA.Anchor = AnchorStyles.Left;
            this.textGODINAOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textGODINAOBRACUNA.ReadOnly = false;
            this.textGODINAOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUN, "GODINAOBRACUNA"));
            this.textGODINAOBRACUNA.MaxLength = 4;
            this.layoutManagerformOBRACUN.Controls.Add(this.textGODINAOBRACUNA, 1, 3);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textGODINAOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textGODINAOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MJESECISPLATE.Location = point;
            this.label1MJESECISPLATE.Name = "label1MJESECISPLATE";
            this.label1MJESECISPLATE.TabIndex = 1;
            this.label1MJESECISPLATE.Tag = "labelMJESECISPLATE";
            this.label1MJESECISPLATE.Text = "Mjesec isplate:";
            this.label1MJESECISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1MJESECISPLATE.AutoSize = true;
            this.label1MJESECISPLATE.Anchor = AnchorStyles.Left;
            this.label1MJESECISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECISPLATE.Appearance.ForeColor = Color.Black;
            this.label1MJESECISPLATE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1MJESECISPLATE, 0, 4);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1MJESECISPLATE, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1MJESECISPLATE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESECISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESECISPLATE.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1MJESECISPLATE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESECISPLATE.Location = point;
            this.textMJESECISPLATE.Name = "textMJESECISPLATE";
            this.textMJESECISPLATE.Tag = "MJESECISPLATE";
            this.textMJESECISPLATE.TabIndex = 0;
            this.textMJESECISPLATE.Anchor = AnchorStyles.Left;
            this.textMJESECISPLATE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMJESECISPLATE.ReadOnly = false;
            this.textMJESECISPLATE.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUN, "MJESECISPLATE"));
            this.textMJESECISPLATE.MaxLength = 2;
            this.layoutManagerformOBRACUN.Controls.Add(this.textMJESECISPLATE, 1, 4);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textMJESECISPLATE, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textMJESECISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECISPLATE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECISPLATE.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECISPLATE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GODINAISPLATE.Location = point;
            this.label1GODINAISPLATE.Name = "label1GODINAISPLATE";
            this.label1GODINAISPLATE.TabIndex = 1;
            this.label1GODINAISPLATE.Tag = "labelGODINAISPLATE";
            this.label1GODINAISPLATE.Text = "Godina isplate:";
            this.label1GODINAISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1GODINAISPLATE.AutoSize = true;
            this.label1GODINAISPLATE.Anchor = AnchorStyles.Left;
            this.label1GODINAISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINAISPLATE.Appearance.ForeColor = Color.Black;
            this.label1GODINAISPLATE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1GODINAISPLATE, 0, 5);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1GODINAISPLATE, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1GODINAISPLATE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINAISPLATE.MinimumSize = size;
            size = new System.Drawing.Size(0x6c, 0x17);
            this.label1GODINAISPLATE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINAISPLATE.Location = point;
            this.textGODINAISPLATE.Name = "textGODINAISPLATE";
            this.textGODINAISPLATE.Tag = "GODINAISPLATE";
            this.textGODINAISPLATE.TabIndex = 0;
            this.textGODINAISPLATE.Anchor = AnchorStyles.Left;
            this.textGODINAISPLATE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textGODINAISPLATE.ReadOnly = false;
            this.textGODINAISPLATE.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUN, "GODINAISPLATE"));
            this.textGODINAISPLATE.MaxLength = 4;
            this.layoutManagerformOBRACUN.Controls.Add(this.textGODINAISPLATE, 1, 5);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textGODINAISPLATE, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textGODINAISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMISPLATE.Location = point;
            this.label1DATUMISPLATE.Name = "label1DATUMISPLATE";
            this.label1DATUMISPLATE.TabIndex = 1;
            this.label1DATUMISPLATE.Tag = "labelDATUMISPLATE";
            this.label1DATUMISPLATE.Text = "Datum isplate:";
            this.label1DATUMISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1DATUMISPLATE.AutoSize = true;
            this.label1DATUMISPLATE.Anchor = AnchorStyles.Left;
            this.label1DATUMISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMISPLATE.Appearance.ForeColor = Color.Black;
            this.label1DATUMISPLATE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1DATUMISPLATE, 0, 6);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1DATUMISPLATE, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1DATUMISPLATE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMISPLATE.MinimumSize = size;
            size = new System.Drawing.Size(0x6a, 0x17);
            this.label1DATUMISPLATE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMISPLATE.Location = point;
            this.datePickerDATUMISPLATE.Name = "datePickerDATUMISPLATE";
            this.datePickerDATUMISPLATE.Tag = "DATUMISPLATE";
            this.datePickerDATUMISPLATE.TabIndex = 0;
            this.datePickerDATUMISPLATE.Anchor = AnchorStyles.Left;
            this.datePickerDATUMISPLATE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMISPLATE.ContextMenu = this.contextMenu1;
            this.datePickerDATUMISPLATE.Enabled = true;
            this.layoutManagerformOBRACUN.Controls.Add(this.datePickerDATUMISPLATE, 1, 6);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.datePickerDATUMISPLATE, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.datePickerDATUMISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMISPLATE.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMISPLATE.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMISPLATE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1tjednifondsatiobracun.Location = point;
            this.label1tjednifondsatiobracun.Name = "label1tjednifondsatiobracun";
            this.label1tjednifondsatiobracun.TabIndex = 1;
            this.label1tjednifondsatiobracun.Tag = "labeltjednifondsatiobracun";
            this.label1tjednifondsatiobracun.Text = "Tjedni fond sati:";
            this.label1tjednifondsatiobracun.StyleSetName = "FieldUltraLabel";
            this.label1tjednifondsatiobracun.AutoSize = true;
            this.label1tjednifondsatiobracun.Anchor = AnchorStyles.Left;
            this.label1tjednifondsatiobracun.Appearance.TextVAlign = VAlign.Middle;
            this.label1tjednifondsatiobracun.Appearance.ForeColor = Color.Black;
            this.label1tjednifondsatiobracun.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1tjednifondsatiobracun, 0, 7);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1tjednifondsatiobracun, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1tjednifondsatiobracun, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1tjednifondsatiobracun.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1tjednifondsatiobracun.MinimumSize = size;
            size = new System.Drawing.Size(0x74, 0x17);
            this.label1tjednifondsatiobracun.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.texttjednifondsatiobracun.Location = point;
            this.texttjednifondsatiobracun.Name = "texttjednifondsatiobracun";
            this.texttjednifondsatiobracun.Tag = "tjednifondsatiobracun";
            this.texttjednifondsatiobracun.TabIndex = 0;
            this.texttjednifondsatiobracun.Anchor = AnchorStyles.Left;
            this.texttjednifondsatiobracun.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.texttjednifondsatiobracun.ReadOnly = false;
            this.texttjednifondsatiobracun.PromptChar = ' ';
            this.texttjednifondsatiobracun.Enter += new EventHandler(this.numericEditor_Enter);
            this.texttjednifondsatiobracun.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUN, "tjednifondsatiobracun"));
            this.texttjednifondsatiobracun.NumericType = NumericType.Integer;
            this.texttjednifondsatiobracun.MaskInput = "{LOC}-nnn";
            this.layoutManagerformOBRACUN.Controls.Add(this.texttjednifondsatiobracun, 1, 7);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.texttjednifondsatiobracun, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.texttjednifondsatiobracun, 1);
            padding = new Padding(0, 1, 3, 2);
            this.texttjednifondsatiobracun.Margin = padding;
            size = new System.Drawing.Size(0x26, 0x16);
            this.texttjednifondsatiobracun.MinimumSize = size;
            size = new System.Drawing.Size(0x26, 0x16);
            this.texttjednifondsatiobracun.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MJESECNIFONDSATIOBRACUN.Location = point;
            this.label1MJESECNIFONDSATIOBRACUN.Name = "label1MJESECNIFONDSATIOBRACUN";
            this.label1MJESECNIFONDSATIOBRACUN.TabIndex = 1;
            this.label1MJESECNIFONDSATIOBRACUN.Tag = "labelMJESECNIFONDSATIOBRACUN";
            this.label1MJESECNIFONDSATIOBRACUN.Text = "Mjeseeni fond sati:";
            this.label1MJESECNIFONDSATIOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1MJESECNIFONDSATIOBRACUN.AutoSize = true;
            this.label1MJESECNIFONDSATIOBRACUN.Anchor = AnchorStyles.Left;
            this.label1MJESECNIFONDSATIOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECNIFONDSATIOBRACUN.Appearance.ForeColor = Color.Black;
            this.label1MJESECNIFONDSATIOBRACUN.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1MJESECNIFONDSATIOBRACUN, 0, 8);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1MJESECNIFONDSATIOBRACUN, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1MJESECNIFONDSATIOBRACUN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESECNIFONDSATIOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESECNIFONDSATIOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x84, 0x17);
            this.label1MJESECNIFONDSATIOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESECNIFONDSATIOBRACUN.Location = point;
            this.textMJESECNIFONDSATIOBRACUN.Name = "textMJESECNIFONDSATIOBRACUN";
            this.textMJESECNIFONDSATIOBRACUN.Tag = "MJESECNIFONDSATIOBRACUN";
            this.textMJESECNIFONDSATIOBRACUN.TabIndex = 0;
            this.textMJESECNIFONDSATIOBRACUN.Anchor = AnchorStyles.Left;
            this.textMJESECNIFONDSATIOBRACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMJESECNIFONDSATIOBRACUN.ReadOnly = false;
            this.textMJESECNIFONDSATIOBRACUN.PromptChar = ' ';
            this.textMJESECNIFONDSATIOBRACUN.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMJESECNIFONDSATIOBRACUN.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUN, "MJESECNIFONDSATIOBRACUN"));
            this.textMJESECNIFONDSATIOBRACUN.NumericType = NumericType.Integer;
            this.textMJESECNIFONDSATIOBRACUN.MaskInput = "{LOC}-nnn";
            this.layoutManagerformOBRACUN.Controls.Add(this.textMJESECNIFONDSATIOBRACUN, 1, 8);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textMJESECNIFONDSATIOBRACUN, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textMJESECNIFONDSATIOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECNIFONDSATIOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x26, 0x16);
            this.textMJESECNIFONDSATIOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x26, 0x16);
            this.textMJESECNIFONDSATIOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSNOVNIOO.Location = point;
            this.label1OSNOVNIOO.Name = "label1OSNOVNIOO";
            this.label1OSNOVNIOO.TabIndex = 1;
            this.label1OSNOVNIOO.Tag = "labelOSNOVNIOO";
            this.label1OSNOVNIOO.Text = "Osnovni osobni odbitak:";
            this.label1OSNOVNIOO.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVNIOO.AutoSize = true;
            this.label1OSNOVNIOO.Anchor = AnchorStyles.Left;
            this.label1OSNOVNIOO.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSNOVNIOO.Appearance.ForeColor = Color.Black;
            this.label1OSNOVNIOO.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1OSNOVNIOO, 0, 9);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1OSNOVNIOO, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1OSNOVNIOO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSNOVNIOO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSNOVNIOO.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 0x17);
            this.label1OSNOVNIOO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSNOVNIOO.Location = point;
            this.textOSNOVNIOO.Name = "textOSNOVNIOO";
            this.textOSNOVNIOO.Tag = "OSNOVNIOO";
            this.textOSNOVNIOO.TabIndex = 0;
            this.textOSNOVNIOO.Anchor = AnchorStyles.Left;
            this.textOSNOVNIOO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSNOVNIOO.ReadOnly = false;
            this.textOSNOVNIOO.PromptChar = ' ';
            this.textOSNOVNIOO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSNOVNIOO.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUN, "OSNOVNIOO"));
            this.textOSNOVNIOO.NumericType = NumericType.Double;
            this.textOSNOVNIOO.MaxValue = 79228162514264337593543950335M;
            this.textOSNOVNIOO.MinValue = -79228162514264337593543950335M;
            this.textOSNOVNIOO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUN.Controls.Add(this.textOSNOVNIOO, 1, 9);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textOSNOVNIOO, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textOSNOVNIOO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSNOVNIOO.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSNOVNIOO.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSNOVNIOO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRACUNSKAOSNOVICA.Location = point;
            this.label1OBRACUNSKAOSNOVICA.Name = "label1OBRACUNSKAOSNOVICA";
            this.label1OBRACUNSKAOSNOVICA.TabIndex = 1;
            this.label1OBRACUNSKAOSNOVICA.Tag = "labelOBRACUNSKAOSNOVICA";
            this.label1OBRACUNSKAOSNOVICA.Text = "Obraeunska osnovica:";
            this.label1OBRACUNSKAOSNOVICA.StyleSetName = "FieldUltraLabel";
            this.label1OBRACUNSKAOSNOVICA.AutoSize = true;
            this.label1OBRACUNSKAOSNOVICA.Anchor = AnchorStyles.Left;
            this.label1OBRACUNSKAOSNOVICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRACUNSKAOSNOVICA.Appearance.ForeColor = Color.Black;
            this.label1OBRACUNSKAOSNOVICA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1OBRACUNSKAOSNOVICA, 0, 10);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1OBRACUNSKAOSNOVICA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1OBRACUNSKAOSNOVICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRACUNSKAOSNOVICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRACUNSKAOSNOVICA.MinimumSize = size;
            size = new System.Drawing.Size(0x97, 0x17);
            this.label1OBRACUNSKAOSNOVICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRACUNSKAOSNOVICA.Location = point;
            this.textOBRACUNSKAOSNOVICA.Name = "textOBRACUNSKAOSNOVICA";
            this.textOBRACUNSKAOSNOVICA.Tag = "OBRACUNSKAOSNOVICA";
            this.textOBRACUNSKAOSNOVICA.TabIndex = 0;
            this.textOBRACUNSKAOSNOVICA.Anchor = AnchorStyles.Left;
            this.textOBRACUNSKAOSNOVICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRACUNSKAOSNOVICA.ReadOnly = false;
            this.textOBRACUNSKAOSNOVICA.PromptChar = ' ';
            this.textOBRACUNSKAOSNOVICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRACUNSKAOSNOVICA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUN, "OBRACUNSKAOSNOVICA"));
            this.textOBRACUNSKAOSNOVICA.NumericType = NumericType.Double;
            this.textOBRACUNSKAOSNOVICA.MaxValue = 79228162514264337593543950335M;
            this.textOBRACUNSKAOSNOVICA.MinValue = -79228162514264337593543950335M;
            this.textOBRACUNSKAOSNOVICA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUN.Controls.Add(this.textOBRACUNSKAOSNOVICA, 1, 10);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textOBRACUNSKAOSNOVICA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textOBRACUNSKAOSNOVICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRACUNSKAOSNOVICA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNSKAOSNOVICA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNSKAOSNOVICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMOBRACUNASTAZA.Location = point;
            this.label1DATUMOBRACUNASTAZA.Name = "label1DATUMOBRACUNASTAZA";
            this.label1DATUMOBRACUNASTAZA.TabIndex = 1;
            this.label1DATUMOBRACUNASTAZA.Tag = "labelDATUMOBRACUNASTAZA";
            this.label1DATUMOBRACUNASTAZA.Text = "Datum obračuna staža:";
            this.label1DATUMOBRACUNASTAZA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMOBRACUNASTAZA.AutoSize = true;
            this.label1DATUMOBRACUNASTAZA.Anchor = AnchorStyles.Left;
            this.label1DATUMOBRACUNASTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMOBRACUNASTAZA.Appearance.ForeColor = Color.Black;
            this.label1DATUMOBRACUNASTAZA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1DATUMOBRACUNASTAZA, 0, 11);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1DATUMOBRACUNASTAZA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1DATUMOBRACUNASTAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMOBRACUNASTAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMOBRACUNASTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x9f, 0x17);
            this.label1DATUMOBRACUNASTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMOBRACUNASTAZA.Location = point;
            this.datePickerDATUMOBRACUNASTAZA.Name = "datePickerDATUMOBRACUNASTAZA";
            this.datePickerDATUMOBRACUNASTAZA.Tag = "DATUMOBRACUNASTAZA";
            this.datePickerDATUMOBRACUNASTAZA.TabIndex = 0;
            this.datePickerDATUMOBRACUNASTAZA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMOBRACUNASTAZA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMOBRACUNASTAZA.Enabled = true;
            this.layoutManagerformOBRACUN.Controls.Add(this.datePickerDATUMOBRACUNASTAZA, 1, 11);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.datePickerDATUMOBRACUNASTAZA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.datePickerDATUMOBRACUNASTAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMOBRACUNASTAZA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMOBRACUNASTAZA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMOBRACUNASTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRPOSTOTNIH.Location = point;
            this.label1OBRPOSTOTNIH.Name = "label1OBRPOSTOTNIH";
            this.label1OBRPOSTOTNIH.TabIndex = 1;
            this.label1OBRPOSTOTNIH.Tag = "labelOBRPOSTOTNIH";
            this.label1OBRPOSTOTNIH.Text = "Obračun postotnih:";
            this.label1OBRPOSTOTNIH.StyleSetName = "FieldUltraLabel";
            this.label1OBRPOSTOTNIH.AutoSize = true;
            this.label1OBRPOSTOTNIH.Anchor = AnchorStyles.Left;
            this.label1OBRPOSTOTNIH.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRPOSTOTNIH.Appearance.ForeColor = Color.Black;
            this.label1OBRPOSTOTNIH.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1OBRPOSTOTNIH, 0, 12);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1OBRPOSTOTNIH, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1OBRPOSTOTNIH, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRPOSTOTNIH.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRPOSTOTNIH.MinimumSize = size;
            size = new System.Drawing.Size(0x86, 0x17);
            this.label1OBRPOSTOTNIH.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkOBRPOSTOTNIH.Location = point;
            this.checkOBRPOSTOTNIH.Name = "checkOBRPOSTOTNIH";
            this.checkOBRPOSTOTNIH.Tag = "OBRPOSTOTNIH";
            this.checkOBRPOSTOTNIH.TabIndex = 0;
            this.checkOBRPOSTOTNIH.Anchor = AnchorStyles.Left;
            this.checkOBRPOSTOTNIH.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkOBRPOSTOTNIH.Enabled = true;
            this.layoutManagerformOBRACUN.Controls.Add(this.checkOBRPOSTOTNIH, 1, 12);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.checkOBRPOSTOTNIH, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.checkOBRPOSTOTNIH, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkOBRPOSTOTNIH.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkOBRPOSTOTNIH.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkOBRPOSTOTNIH.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRFIKSNIH.Location = point;
            this.label1OBRFIKSNIH.Name = "label1OBRFIKSNIH";
            this.label1OBRFIKSNIH.TabIndex = 1;
            this.label1OBRFIKSNIH.Tag = "labelOBRFIKSNIH";
            this.label1OBRFIKSNIH.Text = "Obračun fiksnih:";
            this.label1OBRFIKSNIH.StyleSetName = "FieldUltraLabel";
            this.label1OBRFIKSNIH.AutoSize = true;
            this.label1OBRFIKSNIH.Anchor = AnchorStyles.Left;
            this.label1OBRFIKSNIH.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRFIKSNIH.Appearance.ForeColor = Color.Black;
            this.label1OBRFIKSNIH.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1OBRFIKSNIH, 0, 13);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1OBRFIKSNIH, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1OBRFIKSNIH, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRFIKSNIH.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRFIKSNIH.MinimumSize = size;
            size = new System.Drawing.Size(0x75, 0x17);
            this.label1OBRFIKSNIH.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkOBRFIKSNIH.Location = point;
            this.checkOBRFIKSNIH.Name = "checkOBRFIKSNIH";
            this.checkOBRFIKSNIH.Tag = "OBRFIKSNIH";
            this.checkOBRFIKSNIH.TabIndex = 0;
            this.checkOBRFIKSNIH.Anchor = AnchorStyles.Left;
            this.checkOBRFIKSNIH.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkOBRFIKSNIH.Enabled = true;
            this.layoutManagerformOBRACUN.Controls.Add(this.checkOBRFIKSNIH, 1, 13);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.checkOBRFIKSNIH, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.checkOBRFIKSNIH, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkOBRFIKSNIH.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkOBRFIKSNIH.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkOBRFIKSNIH.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRKREDITNIH.Location = point;
            this.label1OBRKREDITNIH.Name = "label1OBRKREDITNIH";
            this.label1OBRKREDITNIH.TabIndex = 1;
            this.label1OBRKREDITNIH.Tag = "labelOBRKREDITNIH";
            this.label1OBRKREDITNIH.Text = "Obračun kreditnih:";
            this.label1OBRKREDITNIH.StyleSetName = "FieldUltraLabel";
            this.label1OBRKREDITNIH.AutoSize = true;
            this.label1OBRKREDITNIH.Anchor = AnchorStyles.Left;
            this.label1OBRKREDITNIH.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRKREDITNIH.Appearance.ForeColor = Color.Black;
            this.label1OBRKREDITNIH.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1OBRKREDITNIH, 0, 14);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1OBRKREDITNIH, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1OBRKREDITNIH, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRKREDITNIH.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRKREDITNIH.MinimumSize = size;
            size = new System.Drawing.Size(0x83, 0x17);
            this.label1OBRKREDITNIH.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkOBRKREDITNIH.Location = point;
            this.checkOBRKREDITNIH.Name = "checkOBRKREDITNIH";
            this.checkOBRKREDITNIH.Tag = "OBRKREDITNIH";
            this.checkOBRKREDITNIH.TabIndex = 0;
            this.checkOBRKREDITNIH.Anchor = AnchorStyles.Left;
            this.checkOBRKREDITNIH.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkOBRKREDITNIH.Enabled = true;
            this.layoutManagerformOBRACUN.Controls.Add(this.checkOBRKREDITNIH, 1, 14);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.checkOBRKREDITNIH, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.checkOBRKREDITNIH, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkOBRKREDITNIH.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkOBRKREDITNIH.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkOBRKREDITNIH.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZAKLJ.Location = point;
            this.label1ZAKLJ.Name = "label1ZAKLJ";
            this.label1ZAKLJ.TabIndex = 1;
            this.label1ZAKLJ.Tag = "labelZAKLJ";
            this.label1ZAKLJ.Text = "Zaključano:";
            this.label1ZAKLJ.StyleSetName = "FieldUltraLabel";
            this.label1ZAKLJ.AutoSize = true;
            this.label1ZAKLJ.Anchor = AnchorStyles.Left;
            this.label1ZAKLJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZAKLJ.Appearance.ForeColor = Color.Black;
            this.label1ZAKLJ.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1ZAKLJ, 0, 15);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1ZAKLJ, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1ZAKLJ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZAKLJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZAKLJ.MinimumSize = size;
            size = new System.Drawing.Size(0x57, 0x17);
            this.label1ZAKLJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkZAKLJ.Location = point;
            this.checkZAKLJ.Name = "checkZAKLJ";
            this.checkZAKLJ.Tag = "ZAKLJ";
            this.checkZAKLJ.TabIndex = 0;
            this.checkZAKLJ.Anchor = AnchorStyles.Left;
            this.checkZAKLJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkZAKLJ.Enabled = true;
            this.layoutManagerformOBRACUN.Controls.Add(this.checkZAKLJ, 1, 15);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.checkZAKLJ, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.checkZAKLJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkZAKLJ.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkZAKLJ.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkZAKLJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SVRHAOBRACUNA.Location = point;
            this.label1SVRHAOBRACUNA.Name = "label1SVRHAOBRACUNA";
            this.label1SVRHAOBRACUNA.TabIndex = 1;
            this.label1SVRHAOBRACUNA.Tag = "labelSVRHAOBRACUNA";
            this.label1SVRHAOBRACUNA.Text = "Svrha obračuna:";
            this.label1SVRHAOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1SVRHAOBRACUNA.AutoSize = true;
            this.label1SVRHAOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1SVRHAOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SVRHAOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1SVRHAOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUN.Controls.Add(this.label1SVRHAOBRACUNA, 0, 0x10);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.label1SVRHAOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.label1SVRHAOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SVRHAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SVRHAOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x74, 0x17);
            this.label1SVRHAOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSVRHAOBRACUNA.Location = point;
            this.textSVRHAOBRACUNA.Name = "textSVRHAOBRACUNA";
            this.textSVRHAOBRACUNA.Tag = "SVRHAOBRACUNA";
            this.textSVRHAOBRACUNA.TabIndex = 0;
            this.textSVRHAOBRACUNA.Anchor = AnchorStyles.Left;
            this.textSVRHAOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSVRHAOBRACUNA.ContextMenu = this.contextMenu1;
            this.textSVRHAOBRACUNA.ReadOnly = false;
            this.textSVRHAOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUN, "SVRHAOBRACUNA"));
            this.textSVRHAOBRACUNA.Nullable = true;
            this.textSVRHAOBRACUNA.MaxLength = 100;
            this.layoutManagerformOBRACUN.Controls.Add(this.textSVRHAOBRACUNA, 1, 0x10);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.textSVRHAOBRACUNA, 1);
            this.layoutManagerformOBRACUN.SetRowSpan(this.textSVRHAOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSVRHAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textSVRHAOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textSVRHAOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelObracunRadnici.Location = point;
            this.grdLevelObracunRadnici.Name = "grdLevelObracunRadnici";
            this.layoutManagerformOBRACUN.Controls.Add(this.grdLevelObracunRadnici, 0, 0x11);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.grdLevelObracunRadnici, 2);
            this.layoutManagerformOBRACUN.SetRowSpan(this.grdLevelObracunRadnici, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelObracunRadnici.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelObracunRadnici.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelObracunRadnici.Size = size;
            this.grdLevelObracunRadnici.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsObracunRadnici.Location = point;
            this.panelactionsObracunRadnici.Name = "panelactionsObracunRadnici";
            this.panelactionsObracunRadnici.BackColor = Color.Transparent;
            this.panelactionsObracunRadnici.Controls.Add(this.layoutManagerpanelactionsObracunRadnici);
            this.layoutManagerformOBRACUN.Controls.Add(this.panelactionsObracunRadnici, 0, 0x12);
            this.layoutManagerformOBRACUN.SetColumnSpan(this.panelactionsObracunRadnici, 2);
            this.layoutManagerformOBRACUN.SetRowSpan(this.panelactionsObracunRadnici, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsObracunRadnici.Margin = padding;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsObracunRadnici.MinimumSize = size;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsObracunRadnici.Size = size;
            this.panelactionsObracunRadnici.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunRadniciAdd.Location = point;
            this.linkLabelObracunRadniciAdd.Name = "linkLabelObracunRadniciAdd";
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunRadniciAdd.Size = size;
            this.linkLabelObracunRadniciAdd.Text = " Add OBRACUNLevel1  ";
            this.linkLabelObracunRadniciAdd.Click += new EventHandler(this.ObracunRadniciAdd_Click);
            this.linkLabelObracunRadniciAdd.BackColor = Color.Transparent;
            this.linkLabelObracunRadniciAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunRadniciAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunRadniciAdd.Cursor = Cursors.Hand;
            this.linkLabelObracunRadniciAdd.AutoSize = true;
            this.layoutManagerpanelactionsObracunRadnici.Controls.Add(this.linkLabelObracunRadniciAdd, 0, 0);
            this.layoutManagerpanelactionsObracunRadnici.SetColumnSpan(this.linkLabelObracunRadniciAdd, 1);
            this.layoutManagerpanelactionsObracunRadnici.SetRowSpan(this.linkLabelObracunRadniciAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunRadniciAdd.Margin = padding;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunRadniciAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunRadniciAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunRadniciUpdate.Location = point;
            this.linkLabelObracunRadniciUpdate.Name = "linkLabelObracunRadniciUpdate";
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunRadniciUpdate.Size = size;
            this.linkLabelObracunRadniciUpdate.Text = " Update OBRACUNLevel1  ";
            this.linkLabelObracunRadniciUpdate.Click += new EventHandler(this.ObracunRadniciUpdate_Click);
            this.linkLabelObracunRadniciUpdate.BackColor = Color.Transparent;
            this.linkLabelObracunRadniciUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunRadniciUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunRadniciUpdate.Cursor = Cursors.Hand;
            this.linkLabelObracunRadniciUpdate.AutoSize = true;
            this.layoutManagerpanelactionsObracunRadnici.Controls.Add(this.linkLabelObracunRadniciUpdate, 1, 0);
            this.layoutManagerpanelactionsObracunRadnici.SetColumnSpan(this.linkLabelObracunRadniciUpdate, 1);
            this.layoutManagerpanelactionsObracunRadnici.SetRowSpan(this.linkLabelObracunRadniciUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunRadniciUpdate.Margin = padding;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunRadniciUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunRadniciUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunRadniciDelete.Location = point;
            this.linkLabelObracunRadniciDelete.Name = "linkLabelObracunRadniciDelete";
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunRadniciDelete.Size = size;
            this.linkLabelObracunRadniciDelete.Text = " Delete OBRACUNLevel1  ";
            this.linkLabelObracunRadniciDelete.Click += new EventHandler(this.ObracunRadniciDelete_Click);
            this.linkLabelObracunRadniciDelete.BackColor = Color.Transparent;
            this.linkLabelObracunRadniciDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunRadniciDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunRadniciDelete.Cursor = Cursors.Hand;
            this.linkLabelObracunRadniciDelete.AutoSize = true;
            this.layoutManagerpanelactionsObracunRadnici.Controls.Add(this.linkLabelObracunRadniciDelete, 2, 0);
            this.layoutManagerpanelactionsObracunRadnici.SetColumnSpan(this.linkLabelObracunRadniciDelete, 1);
            this.layoutManagerpanelactionsObracunRadnici.SetRowSpan(this.linkLabelObracunRadniciDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunRadniciDelete.Margin = padding;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunRadniciDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunRadniciDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunRadnici.Location = point;
            this.linkLabelObracunRadnici.Name = "linkLabelObracunRadnici";
            this.layoutManagerpanelactionsObracunRadnici.Controls.Add(this.linkLabelObracunRadnici, 3, 0);
            this.layoutManagerpanelactionsObracunRadnici.SetColumnSpan(this.linkLabelObracunRadnici, 1);
            this.layoutManagerpanelactionsObracunRadnici.SetRowSpan(this.linkLabelObracunRadnici, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunRadnici.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunRadnici.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunRadnici.Size = size;
            this.linkLabelObracunRadnici.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformOBRACUN);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOBRACUN;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            column183.CellActivation = Activation.Disabled;
            column183.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column183.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column183.Width = 0x5d;
            column183.Format = "";
            column183.CellAppearance = appearance174;
            column183.Hidden = true;
            Infragistics.Win.Appearance appearance176 = new Infragistics.Win.Appearance();
            column185.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column185.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column185.Width = 0x69;
            column185.Format = "";
            column185.CellAppearance = appearance176;
            column186.AllowGroupBy = DefaultableBoolean.False;
            column186.AutoSizeEdit = DefaultableBoolean.False;
            column186.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column186.CellAppearance.BorderAlpha = Alpha.Transparent;
            column186.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column186.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column186.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column186.Header.Enabled = false;
            column186.Header.Fixed = true;
            column186.Header.Caption = "";
            column186.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column186.Width = 20;
            column186.MinWidth = 20;
            column186.MaxWidth = 20;
            column186.Tag = "RADNIKIDRADNIKAddNew";
            Infragistics.Win.Appearance appearance212 = new Infragistics.Win.Appearance();
            column222.CellActivation = Activation.Disabled;
            column222.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column222.Header.Caption = StringResources.OBRACUNPREZIMEDescription;
            column222.Width = 0x128;
            column222.Format = "";
            column222.CellAppearance = appearance212;
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            column190.CellActivation = Activation.Disabled;
            column190.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column190.Header.Caption = StringResources.OBRACUNIMEDescription;
            column190.Width = 0x128;
            column190.Format = "";
            column190.CellAppearance = appearance180;
            Infragistics.Win.Appearance appearance223 = new Infragistics.Win.Appearance();
            column233.CellActivation = Activation.Disabled;
            column233.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column233.Header.Caption = StringResources.OBRACUNulicaDescription;
            column233.Width = 0x128;
            column233.Format = "";
            column233.CellAppearance = appearance223;
            Infragistics.Win.Appearance appearance188 = new Infragistics.Win.Appearance();
            column198.CellActivation = Activation.Disabled;
            column198.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column198.Header.Caption = StringResources.OBRACUNmjestoDescription;
            column198.Width = 0x128;
            column198.Format = "";
            column198.CellAppearance = appearance188;
            Infragistics.Win.Appearance appearance185 = new Infragistics.Win.Appearance();
            column195.CellActivation = Activation.Disabled;
            column195.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column195.Header.Caption = StringResources.OBRACUNkucnibrojDescription;
            column195.Width = 0x56;
            column195.Format = "";
            column195.CellAppearance = appearance185;
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            column192.CellActivation = Activation.Disabled;
            column192.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column192.Header.Caption = StringResources.OBRACUNJMBGDescription;
            column192.Width = 0x6b;
            column192.Format = "";
            column192.CellAppearance = appearance182;
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            column176.CellActivation = Activation.Disabled;
            column176.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column176.Header.Caption = StringResources.OBRACUNDATUMRODJENJADescription;
            column176.Width = 0x6b;
            column176.MinValue = DateTime.MinValue;
            column176.MaxValue = DateTime.MaxValue;
            column176.Format = "d";
            column176.CellAppearance = appearance167;
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            column210.CellActivation = Activation.Disabled;
            column210.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column210.Header.Caption = StringResources.OBRACUNOPCINARADAIDOPCINEDescription;
            column210.Width = 0x87;
            column210.Format = "";
            column210.CellAppearance = appearance200;
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            column211.CellActivation = Activation.Disabled;
            column211.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column211.Header.Caption = StringResources.OBRACUNOPCINARADANAZIVOPCINEDescription;
            column211.Width = 0x128;
            column211.Format = "";
            column211.CellAppearance = appearance201;
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            column212.CellActivation = Activation.Disabled;
            column212.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column212.Header.Caption = StringResources.OBRACUNOPCINARADAPRIREZDescription;
            column212.Width = 0x66;
            appearance202.TextHAlign = HAlign.Right;
            column212.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column212.PromptChar = ' ';
            column212.Format = "F2";
            column212.CellAppearance = appearance202;
            Infragistics.Win.Appearance appearance203 = new Infragistics.Win.Appearance();
            column213.CellActivation = Activation.Disabled;
            column213.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column213.Header.Caption = StringResources.OBRACUNOPCINASTANOVANJAIDOPCINEDescription;
            column213.Width = 0xb1;
            column213.Format = "";
            column213.CellAppearance = appearance203;
            Infragistics.Win.Appearance appearance204 = new Infragistics.Win.Appearance();
            column214.CellActivation = Activation.Disabled;
            column214.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column214.Header.Caption = StringResources.OBRACUNOPCINASTANOVANJANAZIVOPCINEDescription;
            column214.Width = 0x128;
            column214.Format = "";
            column214.CellAppearance = appearance204;
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            column215.CellActivation = Activation.Disabled;
            column215.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column215.Header.Caption = StringResources.OBRACUNOPCINASTANOVANJAPRIREZDescription;
            column215.Width = 0xb7;
            appearance205.TextHAlign = HAlign.Right;
            column215.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column215.PromptChar = ' ';
            column215.Format = "F2";
            column215.CellAppearance = appearance205;
            Infragistics.Win.Appearance appearance216 = new Infragistics.Win.Appearance();
            column226.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column226.Header.Caption = StringResources.OBRACUNSIFRAOPCINESTANOVANJADescription;
            column226.Width = 100;
            column226.Format = "";
            column226.CellAppearance = appearance216;
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            column181.CellActivation = Activation.Disabled;
            column181.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column181.Header.Caption = StringResources.OBRACUNIDBENEFICIRANIDescription;
            column181.Width = 240;
            column181.Format = "";
            column181.CellAppearance = appearance172;
            Infragistics.Win.Appearance appearance192 = new Infragistics.Win.Appearance();
            column202.CellActivation = Activation.Disabled;
            column202.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column202.Header.Caption = StringResources.OBRACUNNAZIVBENEFICIRANIDescription;
            column202.Width = 0x128;
            column202.Format = "";
            column202.CellAppearance = appearance192;
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            column172.CellActivation = Activation.Disabled;
            column172.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column172.Header.Caption = StringResources.OBRACUNBROJPRIZNATIHMJESECIDescription;
            column172.Width = 0x120;
            appearance163.TextHAlign = HAlign.Right;
            column172.MaskInput = "{LOC}-nn";
            column172.PromptChar = ' ';
            column172.Format = "";
            column172.CellAppearance = appearance163;
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            column180.CellActivation = Activation.Disabled;
            column180.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column180.Header.Caption = StringResources.OBRACUNIDBANKEDescription;
            column180.Width = 0x5c;
            appearance171.TextHAlign = HAlign.Right;
            column180.MaskInput = "{LOC}-nnnnn";
            column180.PromptChar = ' ';
            column180.Format = "";
            column180.CellAppearance = appearance171;
            Infragistics.Win.Appearance appearance189 = new Infragistics.Win.Appearance();
            column199.CellActivation = Activation.Disabled;
            column199.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column199.Header.Caption = StringResources.OBRACUNNAZIVBANKE1Description;
            column199.Width = 0x9c;
            column199.Format = "";
            column199.CellAppearance = appearance189;
            Infragistics.Win.Appearance appearance190 = new Infragistics.Win.Appearance();
            column200.CellActivation = Activation.Disabled;
            column200.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column200.Header.Caption = StringResources.OBRACUNNAZIVBANKE2Description;
            column200.Width = 0x9c;
            column200.Format = "";
            column200.CellAppearance = appearance190;
            Infragistics.Win.Appearance appearance191 = new Infragistics.Win.Appearance();
            column201.CellActivation = Activation.Disabled;
            column201.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column201.Header.Caption = StringResources.OBRACUNNAZIVBANKE3Description;
            column201.Width = 0x9c;
            column201.Format = "";
            column201.CellAppearance = appearance191;
            Infragistics.Win.Appearance appearance225 = new Infragistics.Win.Appearance();
            column235.CellActivation = Activation.Disabled;
            column235.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column235.Header.Caption = StringResources.OBRACUNVBDIBANKEDescription;
            column235.Width = 170;
            column235.Format = "";
            column235.CellAppearance = appearance225;
            Infragistics.Win.Appearance appearance227 = new Infragistics.Win.Appearance();
            column237.CellActivation = Activation.Disabled;
            column237.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column237.Header.Caption = StringResources.OBRACUNZRNBANKEDescription;
            column237.Width = 170;
            column237.Format = "";
            column237.CellAppearance = appearance227;
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            column228.CellActivation = Activation.Disabled;
            column228.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column228.Header.Caption = StringResources.OBRACUNTEKUCIDescription;
            column228.Width = 100;
            column228.Format = "";
            column228.CellAppearance = appearance218;
            Infragistics.Win.Appearance appearance217 = new Infragistics.Win.Appearance();
            column227.CellActivation = Activation.Disabled;
            column227.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column227.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJANETODescription;
            column227.Width = 0x121;
            column227.Format = "";
            column227.CellAppearance = appearance217;
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            column216.CellActivation = Activation.Disabled;
            column216.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column216.Header.Caption = StringResources.OBRACUNOPISPLACANJANETODescription;
            column216.Width = 0x10c;
            column216.Format = "";
            column216.CellAppearance = appearance206;
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            column171.CellActivation = Activation.Disabled;
            column171.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column171.Header.Caption = StringResources.OBRACUNBROJMIROVINSKOGDescription;
            column171.Width = 0x128;
            column171.Format = "";
            column171.CellAppearance = appearance162;
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            column173.CellActivation = Activation.Disabled;
            column173.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column173.Header.Caption = StringResources.OBRACUNBROJZDRAVSTVENOGDescription;
            column173.Width = 0x128;
            column173.Format = "";
            column173.CellAppearance = appearance164;
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            column196.CellActivation = Activation.Disabled;
            column196.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column196.Header.Caption = StringResources.OBRACUNMBODescription;
            column196.Width = 0x128;
            column196.Format = "";
            column196.CellAppearance = appearance186;
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            column219.CellActivation = Activation.Disabled;
            column219.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column219.Header.Caption = StringResources.OBRACUNPOSTOTAKOSLOBODJENJAODPOREZADescription;
            column219.Width = 0x123;
            appearance209.TextHAlign = HAlign.Right;
            column219.MaskInput = "{LOC}-nnn.nn";
            column219.PromptChar = ' ';
            column219.Format = "F2";
            column219.CellAppearance = appearance209;
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            column193.CellActivation = Activation.Disabled;
            column193.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column193.Header.Caption = StringResources.OBRACUNKOEFICIJENTDescription;
            column193.Width = 0x88;
            appearance183.TextHAlign = HAlign.Right;
            column193.MaskInput = "{LOC}-nnnnnnn.nnnnnnnnnn";
            column193.PromptChar = ' ';
            column193.Format = "F10";
            column193.CellAppearance = appearance183;
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            column207.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column207.Header.Caption = StringResources.OBRACUNOBRACUNSKIKOEFICIJENTDescription;
            column207.Width = 170;
            appearance197.TextHAlign = HAlign.Right;
            column207.MaskInput = "{LOC}-nnnnnnn.nnnnnnnnnn";
            column207.PromptChar = ' ';
            column207.Format = "F10";
            column207.CellAppearance = appearance197;
            Infragistics.Win.Appearance appearance177 = new Infragistics.Win.Appearance();
            column187.CellActivation = Activation.Disabled;
            column187.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column187.Header.Caption = StringResources.OBRACUNIDRADNOMJESTODescription;
            column187.Width = 0x92;
            appearance177.TextHAlign = HAlign.Right;
            column187.MaskInput = "{LOC}-nnnnn";
            column187.PromptChar = ' ';
            column187.Format = "";
            column187.CellAppearance = appearance177;
            Infragistics.Win.Appearance appearance193 = new Infragistics.Win.Appearance();
            column203.CellActivation = Activation.Disabled;
            column203.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column203.Header.Caption = StringResources.OBRACUNNAZIVRADNOMJESTODescription;
            column203.Width = 0x128;
            column203.Format = "";
            column203.CellAppearance = appearance193;
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            column231.CellActivation = Activation.Disabled;
            column231.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column231.Header.Caption = StringResources.OBRACUNTRENUTNASTRUCNASPREMAIDSTRUCNASPREMADescription;
            column231.Width = 0x99;
            appearance221.TextHAlign = HAlign.Right;
            column231.MaskInput = "{LOC}-nnnnn";
            column231.PromptChar = ' ';
            column231.Format = "";
            column231.CellAppearance = appearance221;
            Infragistics.Win.Appearance appearance222 = new Infragistics.Win.Appearance();
            column232.CellActivation = Activation.Disabled;
            column232.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column232.Header.Caption = StringResources.OBRACUNTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMADescription;
            column232.Width = 0x128;
            column232.Format = "";
            column232.CellAppearance = appearance222;
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            column220.CellActivation = Activation.Disabled;
            column220.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column220.Header.Caption = StringResources.OBRACUNPOTREBNASTRUCNASPREMAIDSTRUCNASPREMADescription;
            column220.Width = 0xd5;
            appearance210.TextHAlign = HAlign.Right;
            column220.MaskInput = "{LOC}-nnnnn";
            column220.PromptChar = ' ';
            column220.Format = "";
            column220.CellAppearance = appearance210;
            Infragistics.Win.Appearance appearance211 = new Infragistics.Win.Appearance();
            column221.CellActivation = Activation.Disabled;
            column221.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column221.Header.Caption = StringResources.OBRACUNPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMADescription;
            column221.Width = 0x128;
            column221.Format = "";
            column221.CellAppearance = appearance211;
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            column188.CellActivation = Activation.Disabled;
            column188.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column188.Header.Caption = StringResources.OBRACUNIDSTRUKADescription;
            column188.Width = 0x63;
            appearance178.TextHAlign = HAlign.Right;
            column188.MaskInput = "{LOC}-nnnnn";
            column188.PromptChar = ' ';
            column188.Format = "";
            column188.CellAppearance = appearance178;
            Infragistics.Win.Appearance appearance194 = new Infragistics.Win.Appearance();
            column204.CellActivation = Activation.Disabled;
            column204.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column204.Header.Caption = StringResources.OBRACUNNAZIVSTRUKADescription;
            column204.Width = 0x128;
            column204.Format = "";
            column204.CellAppearance = appearance194;
            Infragistics.Win.Appearance appearance214 = new Infragistics.Win.Appearance();
            column224.CellActivation = Activation.Disabled;
            column224.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column224.Header.Caption = StringResources.OBRACUNRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSADescription;
            column224.Width = 0xea;
            appearance214.TextHAlign = HAlign.Right;
            column224.MaskInput = "{LOC}-nnnnn";
            column224.PromptChar = ' ';
            column224.Format = "";
            column224.CellAppearance = appearance214;
            Infragistics.Win.Appearance appearance215 = new Infragistics.Win.Appearance();
            column225.CellActivation = Activation.Disabled;
            column225.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column225.Header.Caption = StringResources.OBRACUNRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSADescription;
            column225.Width = 0x128;
            column225.Format = "";
            column225.CellAppearance = appearance215;
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            column170.CellActivation = Activation.Disabled;
            column170.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column170.Header.Caption = StringResources.OBRACUNAKTIVANDescription;
            column170.Width = 0x41;
            column170.Format = "";
            column170.CellAppearance = appearance161;
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            column191.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column191.Header.Caption = StringResources.OBRACUNISKORISTENOOODescription;
            column191.Width = 0x6d;
            appearance181.TextHAlign = HAlign.Right;
            column191.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column191.PromptChar = ' ';
            column191.Format = "F2";
            column191.CellAppearance = appearance181;
            Infragistics.Win.Appearance appearance196 = new Infragistics.Win.Appearance();
            column206.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column206.Header.Caption = StringResources.OBRACUNOBRACUNATIPRIREZDescription;
            column206.Width = 0x81;
            appearance196.TextHAlign = HAlign.Right;
            column206.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column206.PromptChar = ' ';
            column206.Format = "F2";
            column206.CellAppearance = appearance196;
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            column178.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column178.Header.Caption = StringResources.OBRACUNfaktooDescription;
            column178.Width = 0x3e;
            appearance169.TextHAlign = HAlign.Right;
            column178.MaskInput = "{LOC}-nnn.nn";
            column178.PromptChar = ' ';
            column178.Format = "F2";
            column178.CellAppearance = appearance169;
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            column177.CellActivation = Activation.Disabled;
            column177.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column177.Header.Caption = StringResources.OBRACUNDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIDescription;
            column177.Width = 0x128;
            column177.MinValue = DateTime.MinValue;
            column177.MaxValue = DateTime.MaxValue;
            column177.Format = "d";
            column177.CellAppearance = appearance168;
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            column229.CellActivation = Activation.Disabled;
            column229.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column229.Header.Caption = StringResources.OBRACUNTJEDNIFONDSATIDescription;
            column229.Width = 0xd9;
            appearance219.TextHAlign = HAlign.Right;
            column229.MaskInput = "{LOC}-nnn.nn";
            column229.PromptChar = ' ';
            column229.Format = "F2";
            column229.CellAppearance = appearance219;
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            column230.CellActivation = Activation.Disabled;
            column230.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column230.Header.Caption = StringResources.OBRACUNTJEDNIFONDSATISTAZDescription;
            column230.Width = 0x102;
            appearance220.TextHAlign = HAlign.Right;
            column230.MaskInput = "{LOC}-nnn.nn";
            column230.PromptChar = ' ';
            column230.Format = "F2";
            column230.CellAppearance = appearance220;
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            column179.CellActivation = Activation.Disabled;
            column179.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column179.Header.Caption = StringResources.OBRACUNGODINESTAZADescription;
            column179.Width = 180;
            appearance170.TextHAlign = HAlign.Right;
            column179.MaskInput = "{LOC}-nn";
            column179.PromptChar = ' ';
            column179.Format = "";
            column179.CellAppearance = appearance170;
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            column197.CellActivation = Activation.Disabled;
            column197.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column197.Header.Caption = StringResources.OBRACUNMJESECISTAZADescription;
            column197.Width = 0xba;
            appearance187.TextHAlign = HAlign.Right;
            column197.MaskInput = "{LOC}-nn";
            column197.PromptChar = ' ';
            column197.Format = "";
            column197.CellAppearance = appearance187;
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            column174.CellActivation = Activation.Disabled;
            column174.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column174.Header.Caption = StringResources.OBRACUNDANISTAZADescription;
            column174.Width = 0xa6;
            appearance165.TextHAlign = HAlign.Right;
            column174.MaskInput = "{LOC}-nnn";
            column174.PromptChar = ' ';
            column174.Format = "";
            column174.CellAppearance = appearance165;
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            column175.CellActivation = Activation.Disabled;
            column175.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column175.Header.Caption = StringResources.OBRACUNDATUMPRESTANKARADNOGODNOSADescription;
            column175.Width = 0xdb;
            column175.MinValue = DateTime.MinValue;
            column175.MaxValue = DateTime.MaxValue;
            column175.Format = "d";
            column175.CellAppearance = appearance166;
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            column189.CellActivation = Activation.Disabled;
            column189.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column189.Header.Caption = StringResources.OBRACUNIDTITULADescription;
            column189.Width = 0x63;
            appearance179.TextHAlign = HAlign.Right;
            column189.MaskInput = "{LOC}-nnnnn";
            column189.PromptChar = ' ';
            column189.Format = "";
            column189.CellAppearance = appearance179;
            Infragistics.Win.Appearance appearance195 = new Infragistics.Win.Appearance();
            column205.CellActivation = Activation.Disabled;
            column205.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column205.Header.Caption = StringResources.OBRACUNNAZIVTITULADescription;
            column205.Width = 0x128;
            column205.Format = "";
            column205.CellAppearance = appearance195;
            Infragistics.Win.Appearance appearance226 = new Infragistics.Win.Appearance();
            column236.CellActivation = Activation.Disabled;
            column236.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column236.Header.Caption = StringResources.OBRACUNZBIRNINETODescription;
            column236.Width = 170;
            column236.Format = "";
            column236.CellAppearance = appearance226;
            Infragistics.Win.Appearance appearance224 = new Infragistics.Win.Appearance();
            column234.CellActivation = Activation.Disabled;
            column234.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column234.Header.Caption = StringResources.OBRACUNUZIMAUOBZIROSNOVICEDOPRINOSADescription;
            column234.Width = 0x128;
            column234.Format = "";
            column234.CellAppearance = appearance224;
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            column184.CellActivation = Activation.Disabled;
            column184.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column184.Header.Caption = StringResources.OBRACUNIDORGDIODescription;
            column184.Width = 0xd5;
            appearance175.TextHAlign = HAlign.Right;
            column184.MaskInput = "{LOC}-nnnnn";
            column184.PromptChar = ' ';
            column184.Format = "";
            column184.CellAppearance = appearance175;
            Infragistics.Win.Appearance appearance207 = new Infragistics.Win.Appearance();
            column217.CellActivation = Activation.Disabled;
            column217.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column217.Header.Caption = StringResources.OBRACUNORGANIZACIJSKIDIODescription;
            column217.Width = 0x128;
            column217.Format = "";
            column217.CellAppearance = appearance207;
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            column182.CellActivation = Activation.Disabled;
            column182.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column182.Header.Caption = StringResources.OBRACUNIDIPIDENTDescription;
            column182.Width = 0x4e;
            appearance173.TextHAlign = HAlign.Right;
            column182.MaskInput = "{LOC}-nnnnn";
            column182.PromptChar = ' ';
            column182.Format = "";
            column182.CellAppearance = appearance173;
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            column209.CellActivation = Activation.Disabled;
            column209.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column209.Header.Caption = StringResources.OBRACUNOIBDescription;
            column209.Width = 0x5d;
            column209.Format = "";
            column209.CellAppearance = appearance199;
            Infragistics.Win.Appearance appearance208 = new Infragistics.Win.Appearance();
            column218.CellActivation = Activation.Disabled;
            column218.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column218.Header.Caption = StringResources.OBRACUNPOSTOTAKNASTAZDescription;
            column218.Width = 0x74;
            appearance208.TextHAlign = HAlign.Right;
            column218.MaskInput = "{LOC}-nnn.nn";
            column218.PromptChar = ' ';
            column218.Format = "F2";
            column218.CellAppearance = appearance208;
            Infragistics.Win.Appearance appearance213 = new Infragistics.Win.Appearance();
            column223.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column223.Header.Caption = StringResources.OBRACUNRADNIKOBRACUNOSNOVICADescription;
            column223.Width = 0xa3;
            appearance213.TextHAlign = HAlign.Right;
            column223.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column223.PromptChar = ' ';
            column223.Format = "F2";
            column223.CellAppearance = appearance213;
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            column194.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column194.Header.Caption = StringResources.OBRACUNKOREKCIJAPRIREZADescription;
            column194.Width = 0x81;
            appearance184.TextHAlign = HAlign.Right;
            column194.MaskInput = "{LOC}-nnn.nn";
            column194.PromptChar = ' ';
            column194.Format = "F2";
            column194.CellAppearance = appearance184;
            Infragistics.Win.Appearance appearance198 = new Infragistics.Win.Appearance();
            column208.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column208.Header.Caption = StringResources.OBRACUNODBITAKPRIJEKOREKCIJEDescription;
            column208.Width = 0xa3;
            appearance198.TextHAlign = HAlign.Right;
            column208.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column208.PromptChar = ' ';
            column208.Format = "F2";
            column208.CellAppearance = appearance198;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column2.Width = 0x5d;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column3.Width = 0x69;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OBRACUNIDDOPRINOSDescription;
            column.Width = 0x77;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.Disabled;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.OBRACUNVBDIDOPRINOSDescription;
            column21.Width = 0x80;
            column21.Format = "";
            column21.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.Disabled;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.OBRACUNZRNDOPRINOSDescription;
            column22.Width = 170;
            column22.Format = "";
            column22.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.Disabled;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.OBRACUNNAZIVDOPRINOSDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.Disabled;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OBRACUNIDVRSTADOPRINOSDescription;
            column5.Width = 0x9f;
            appearance4.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.OBRACUNNAZIVVRSTADOPRINOSDescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.Disabled;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.OBRACUNSTOPADescription;
            column20.Width = 0x37;
            appearance19.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.Disabled;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.OBRACUNMODOPRINOSDescription;
            column8.Width = 0xbf;
            column8.Format = "";
            column8.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.Disabled;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.OBRACUNPODOPRINOSDescription;
            column15.Width = 0xbf;
            column15.Format = "";
            column15.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.OBRACUNMZDOPRINOSDescription;
            column9.Width = 0xbf;
            column9.Format = "";
            column9.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.Disabled;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.OBRACUNPZDOPRINOSDescription;
            column18.Width = 0xbf;
            column18.Format = "";
            column18.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.Disabled;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.OBRACUNPRIMATELJDOPRINOS1Description;
            column16.Width = 0x9c;
            column16.Format = "";
            column16.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.Disabled;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.OBRACUNPRIMATELJDOPRINOS2Description;
            column17.Width = 0xb1;
            column17.Format = "";
            column17.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.Disabled;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJADOPRINOSDescription;
            column19.Width = 0xe2;
            column19.Format = "";
            column19.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.OBRACUNOPISPLACANJADOPRINOSDescription;
            column13.Width = 0x10c;
            column13.Format = "";
            column13.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.OBRACUNOBRACUNATIDOPRINOSDescription;
            column12.Width = 0x8f;
            appearance11.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.OBRACUNOSNOVICADOPRINOSDescription;
            column14.Width = 0x81;
            appearance13.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.OBRACUNMINDOPRINOSDescription;
            column7.Width = 0x11d;
            appearance6.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.OBRACUNMAXDOPRINOSDescription;
            column6.Width = 0x123;
            appearance5.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance5;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 2;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 3;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 6;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 8;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 9;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 10;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 11;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 12;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 13;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 14;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 15;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x10;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x11;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0x12;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x13;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 20;
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            column153.CellActivation = Activation.Disabled;
            column153.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column153.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column153.Width = 0x5d;
            column153.Format = "";
            column153.CellAppearance = appearance145;
            column153.Hidden = true;
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            column155.CellActivation = Activation.Disabled;
            column155.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column155.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column155.Width = 0x69;
            column155.Format = "";
            column155.CellAppearance = appearance147;
            column155.Hidden = true;
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            column154.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column154.Header.Caption = StringResources.OBRACUNIDPOREZDescription;
            column154.Width = 0x63;
            appearance146.TextHAlign = HAlign.Right;
            column154.MaskInput = "{LOC}-nnnnn";
            column154.PromptChar = ' ';
            column154.Format = "";
            column154.CellAppearance = appearance146;
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            column159.CellActivation = Activation.Disabled;
            column159.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column159.Header.Caption = StringResources.OBRACUNNAZIVPOREZDescription;
            column159.Width = 0x128;
            column159.Format = "";
            column159.CellAppearance = appearance150;
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            column169.CellActivation = Activation.Disabled;
            column169.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column169.Header.Caption = StringResources.OBRACUNSTOPAPOREZADescription;
            column169.Width = 0x66;
            appearance160.TextHAlign = HAlign.Right;
            column169.MaskInput = "{LOC}-nn.nn";
            column169.PromptChar = ' ';
            column169.Format = "F2";
            column169.CellAppearance = appearance160;
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            column164.CellActivation = Activation.Disabled;
            column164.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column164.Header.Caption = StringResources.OBRACUNPOREZMJESECNODescription;
            column164.Width = 0xd9;
            appearance155.TextHAlign = HAlign.Right;
            column164.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column164.PromptChar = ' ';
            column164.Format = "F2";
            column164.CellAppearance = appearance155;
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            column157.CellActivation = Activation.Disabled;
            column157.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column157.Header.Caption = StringResources.OBRACUNMOPOREZDescription;
            column157.Width = 170;
            column157.Format = "";
            column157.CellAppearance = appearance148;
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            column163.CellActivation = Activation.Disabled;
            column163.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column163.Header.Caption = StringResources.OBRACUNPOPOREZDescription;
            column163.Width = 0xe2;
            column163.Format = "";
            column163.CellAppearance = appearance154;
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            column158.CellActivation = Activation.Disabled;
            column158.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column158.Header.Caption = StringResources.OBRACUNMZPOREZDescription;
            column158.Width = 170;
            column158.Format = "";
            column158.CellAppearance = appearance149;
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            column167.CellActivation = Activation.Disabled;
            column167.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column167.Header.Caption = StringResources.OBRACUNPZPOREZDescription;
            column167.Width = 0xe2;
            column167.Format = "";
            column167.CellAppearance = appearance158;
            Infragistics.Win.Appearance appearance156 = new Infragistics.Win.Appearance();
            column165.CellActivation = Activation.Disabled;
            column165.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column165.Header.Caption = StringResources.OBRACUNPRIMATELJPOREZ1Description;
            column165.Width = 0x9c;
            column165.Format = "";
            column165.CellAppearance = appearance156;
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            column166.CellActivation = Activation.Disabled;
            column166.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column166.Header.Caption = StringResources.OBRACUNPRIMATELJPOREZ2Description;
            column166.Width = 0x9c;
            column166.Format = "";
            column166.CellAppearance = appearance157;
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            column168.CellActivation = Activation.Disabled;
            column168.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column168.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAPOREZDescription;
            column168.Width = 0xcd;
            column168.Format = "";
            column168.CellAppearance = appearance159;
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            column161.CellActivation = Activation.Disabled;
            column161.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column161.Header.Caption = StringResources.OBRACUNOPISPLACANJAPOREZDescription;
            column161.Width = 0x10c;
            column161.Format = "";
            column161.CellAppearance = appearance152;
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            column160.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column160.Header.Caption = StringResources.OBRACUNOBRACUNATIPOREZDescription;
            column160.Width = 0x7b;
            appearance151.TextHAlign = HAlign.Right;
            column160.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column160.PromptChar = ' ';
            column160.Format = "F2";
            column160.CellAppearance = appearance151;
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            column162.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column162.Header.Caption = StringResources.OBRACUNOSNOVICAPOREZDescription;
            column162.Width = 0x6d;
            appearance153.TextHAlign = HAlign.Right;
            column162.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column162.PromptChar = ' ';
            column162.Format = "F2";
            column162.CellAppearance = appearance153;
            band8.Columns.Add(column155);
            column155.Header.VisiblePosition = 0;
            band8.Columns.Add(column154);
            column154.Header.VisiblePosition = 1;
            band8.Columns.Add(column159);
            column159.Header.VisiblePosition = 2;
            band8.Columns.Add(column169);
            column169.Header.VisiblePosition = 3;
            band8.Columns.Add(column164);
            column164.Header.VisiblePosition = 4;
            band8.Columns.Add(column157);
            column157.Header.VisiblePosition = 5;
            band8.Columns.Add(column163);
            column163.Header.VisiblePosition = 6;
            band8.Columns.Add(column158);
            column158.Header.VisiblePosition = 7;
            band8.Columns.Add(column167);
            column167.Header.VisiblePosition = 8;
            band8.Columns.Add(column165);
            column165.Header.VisiblePosition = 9;
            band8.Columns.Add(column166);
            column166.Header.VisiblePosition = 10;
            band8.Columns.Add(column168);
            column168.Header.VisiblePosition = 11;
            band8.Columns.Add(column161);
            column161.Header.VisiblePosition = 12;
            band8.Columns.Add(column160);
            column160.Header.VisiblePosition = 13;
            band8.Columns.Add(column162);
            column162.Header.VisiblePosition = 14;
            band8.Columns.Add(column153);
            column153.Header.VisiblePosition = 15;
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            column131.CellActivation = Activation.Disabled;
            column131.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column131.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column131.Width = 0x5d;
            column131.Format = "";
            column131.CellAppearance = appearance124;
            column131.Hidden = true;
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            column133.CellActivation = Activation.Disabled;
            column133.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column133.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column133.Width = 0x69;
            column133.Format = "";
            column133.CellAppearance = appearance126;
            column133.Hidden = true;
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            column132.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column132.Header.Caption = StringResources.OBRACUNIDOLAKSICEDescription;
            column132.Width = 0x70;
            appearance125.TextHAlign = HAlign.Right;
            column132.MaskInput = "{LOC}-nnnnnnnn";
            column132.PromptChar = ' ';
            column132.Format = "";
            column132.CellAppearance = appearance125;
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            column141.CellActivation = Activation.Disabled;
            column141.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column141.Header.Caption = StringResources.OBRACUNNAZIVOLAKSICEDescription;
            column141.Width = 0x128;
            column141.Format = "";
            column141.CellAppearance = appearance133;
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            column130.CellActivation = Activation.Disabled;
            column130.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column130.Header.Caption = StringResources.OBRACUNIDGRUPEOLAKSICADescription;
            column130.Width = 0x99;
            appearance123.TextHAlign = HAlign.Right;
            column130.MaskInput = "{LOC}-nnnnn";
            column130.PromptChar = ' ';
            column130.Format = "";
            column130.CellAppearance = appearance123;
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            column140.CellActivation = Activation.Disabled;
            column140.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column140.Header.Caption = StringResources.OBRACUNNAZIVGRUPEOLAKSICADescription;
            column140.Width = 0x128;
            column140.Format = "";
            column140.CellAppearance = appearance132;
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            column137.CellActivation = Activation.Disabled;
            column137.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column137.Header.Caption = StringResources.OBRACUNMAXIMALNIIZNOSGRUPEDescription;
            column137.Width = 210;
            appearance129.TextHAlign = HAlign.Right;
            column137.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column137.PromptChar = ' ';
            column137.Format = "F2";
            column137.CellAppearance = appearance129;
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            column135.CellActivation = Activation.Disabled;
            column135.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column135.Header.Caption = StringResources.OBRACUNIDTIPOLAKSICEDescription;
            column135.Width = 0x63;
            appearance127.TextHAlign = HAlign.Right;
            column135.MaskInput = "{LOC}-nnnnn";
            column135.PromptChar = ' ';
            column135.Format = "";
            column135.CellAppearance = appearance127;
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            column142.CellActivation = Activation.Disabled;
            column142.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column142.Header.Caption = StringResources.OBRACUNNAZIVTIPOLAKSICEDescription;
            column142.Width = 0x128;
            column142.Format = "";
            column142.CellAppearance = appearance134;
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            column151.CellActivation = Activation.Disabled;
            column151.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column151.Header.Caption = StringResources.OBRACUNVBDIOLAKSICADescription;
            column151.Width = 0xbf;
            column151.Format = "";
            column151.CellAppearance = appearance143;
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            column152.CellActivation = Activation.Disabled;
            column152.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column152.Header.Caption = StringResources.OBRACUNZRNOLAKSICADescription;
            column152.Width = 0xbf;
            column152.Format = "";
            column152.CellAppearance = appearance144;
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            column146.CellActivation = Activation.Disabled;
            column146.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column146.Header.Caption = StringResources.OBRACUNPRIMATELJOLAKSICA1Description;
            column146.Width = 170;
            column146.Format = "";
            column146.CellAppearance = appearance138;
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            column147.CellActivation = Activation.Disabled;
            column147.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column147.Header.Caption = StringResources.OBRACUNPRIMATELJOLAKSICA2Description;
            column147.Width = 170;
            column147.Format = "";
            column147.CellAppearance = appearance139;
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            column148.CellActivation = Activation.Disabled;
            column148.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column148.Header.Caption = StringResources.OBRACUNPRIMATELJOLAKSICA3Description;
            column148.Width = 170;
            column148.Format = "";
            column148.CellAppearance = appearance140;
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            column139.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column139.Header.Caption = StringResources.OBRACUNMZOLAKSICADescription;
            column139.Width = 0x79;
            column139.Format = "";
            column139.CellAppearance = appearance131;
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            column149.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column149.Header.Caption = StringResources.OBRACUNPZOLAKSICADescription;
            column149.Width = 0xb1;
            column149.Format = "";
            column149.CellAppearance = appearance141;
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            column138.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column138.Header.Caption = StringResources.OBRACUNMOOLAKSICADescription;
            column138.Width = 0xb8;
            column138.Format = "";
            column138.CellAppearance = appearance130;
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            column145.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column145.Header.Caption = StringResources.OBRACUNPOOLAKSICADescription;
            column145.Width = 240;
            column145.Format = "";
            column145.CellAppearance = appearance137;
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            column150.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column150.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAOLAKSICADescription;
            column150.Width = 0xdb;
            column150.Format = "";
            column150.CellAppearance = appearance142;
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            column144.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column144.Header.Caption = StringResources.OBRACUNOPISPLACANJAOLAKSICADescription;
            column144.Width = 0x10c;
            column144.Format = "";
            column144.CellAppearance = appearance136;
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            column136.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column136.Header.Caption = StringResources.OBRACUNIZNOSOLAKSICEDescription;
            column136.Width = 0x74;
            appearance128.TextHAlign = HAlign.Right;
            column136.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column136.PromptChar = ' ';
            column136.Format = "F2";
            column136.CellAppearance = appearance128;
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            column143.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column143.Header.Caption = StringResources.OBRACUNOBRACUNATAOLAKSICADescription;
            column143.Width = 0x8f;
            appearance135.TextHAlign = HAlign.Right;
            column143.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column143.PromptChar = ' ';
            column143.Format = "F2";
            column143.CellAppearance = appearance135;
            band7.Columns.Add(column133);
            column133.Header.VisiblePosition = 0;
            band7.Columns.Add(column132);
            column132.Header.VisiblePosition = 1;
            band7.Columns.Add(column141);
            column141.Header.VisiblePosition = 2;
            band7.Columns.Add(column130);
            column130.Header.VisiblePosition = 3;
            band7.Columns.Add(column140);
            column140.Header.VisiblePosition = 4;
            band7.Columns.Add(column137);
            column137.Header.VisiblePosition = 5;
            band7.Columns.Add(column135);
            column135.Header.VisiblePosition = 6;
            band7.Columns.Add(column142);
            column142.Header.VisiblePosition = 7;
            band7.Columns.Add(column151);
            column151.Header.VisiblePosition = 8;
            band7.Columns.Add(column152);
            column152.Header.VisiblePosition = 9;
            band7.Columns.Add(column146);
            column146.Header.VisiblePosition = 10;
            band7.Columns.Add(column147);
            column147.Header.VisiblePosition = 11;
            band7.Columns.Add(column148);
            column148.Header.VisiblePosition = 12;
            band7.Columns.Add(column139);
            column139.Header.VisiblePosition = 13;
            band7.Columns.Add(column149);
            column149.Header.VisiblePosition = 14;
            band7.Columns.Add(column138);
            column138.Header.VisiblePosition = 15;
            band7.Columns.Add(column145);
            column145.Header.VisiblePosition = 0x10;
            band7.Columns.Add(column150);
            column150.Header.VisiblePosition = 0x11;
            band7.Columns.Add(column144);
            column144.Header.VisiblePosition = 0x12;
            band7.Columns.Add(column136);
            column136.Header.VisiblePosition = 0x13;
            band7.Columns.Add(column143);
            column143.Header.VisiblePosition = 20;
            band7.Columns.Add(column131);
            column131.Header.VisiblePosition = 0x15;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column45.CellActivation = Activation.Disabled;
            column45.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column45.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column45.Width = 0x5d;
            column45.Format = "";
            column45.CellAppearance = appearance42;
            column45.Hidden = true;
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            column46.CellActivation = Activation.Disabled;
            column46.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column46.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column46.Width = 0x69;
            column46.Format = "";
            column46.CellAppearance = appearance43;
            column46.Hidden = true;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.Header.Caption = StringResources.OBRACUNIDKREDITORDescription;
            column44.Width = 0x55;
            appearance41.TextHAlign = HAlign.Right;
            column44.MaskInput = "{LOC}-nnnnnnnn";
            column44.PromptChar = ' ';
            column44.Format = "";
            column44.CellAppearance = appearance41;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.OBRACUNDATUMUGOVORADescription;
            column42.Width = 100;
            column42.MinValue = DateTime.MinValue;
            column42.MaxValue = DateTime.MaxValue;
            column42.Format = "d";
            column42.CellAppearance = appearance39;
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            column48.CellActivation = Activation.Disabled;
            column48.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column48.Header.Caption = StringResources.OBRACUNNAZIVKREDITORDescription;
            column48.Width = 0x9c;
            column48.Format = "";
            column48.CellAppearance = appearance44;
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            column61.CellActivation = Activation.Disabled;
            column61.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column61.Header.Caption = StringResources.OBRACUNVBDIKREDITORDescription;
            column61.Width = 100;
            column61.Format = "";
            column61.CellAppearance = appearance57;
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            column64.CellActivation = Activation.Disabled;
            column64.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column64.Header.Caption = StringResources.OBRACUNZRNKREDITORDescription;
            column64.Width = 0x5d;
            column64.Format = "";
            column64.CellAppearance = appearance60;
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            column57.CellActivation = Activation.Disabled;
            column57.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column57.Header.Caption = StringResources.OBRACUNPRIMATELJKREDITOR1Description;
            column57.Width = 0x9c;
            column57.Format = "";
            column57.CellAppearance = appearance53;
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            column58.CellActivation = Activation.Disabled;
            column58.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column58.Header.Caption = StringResources.OBRACUNPRIMATELJKREDITOR2Description;
            column58.Width = 0x9c;
            column58.Format = "";
            column58.CellAppearance = appearance54;
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            column59.CellActivation = Activation.Disabled;
            column59.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column59.Header.Caption = StringResources.OBRACUNPRIMATELJKREDITOR3Description;
            column59.Width = 0x9c;
            column59.Format = "";
            column59.CellAppearance = appearance55;
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            column56.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column56.Header.Caption = StringResources.OBRACUNOBRSIFRAOPISAPLACANJAKREDITORDescription;
            column56.Width = 0xc6;
            column56.Format = "";
            column56.CellAppearance = appearance52;
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            column53.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column53.Header.Caption = StringResources.OBRACUNOBROPISPLACANJAKREDITORDescription;
            column53.Width = 0x10c;
            column53.Format = "";
            column53.CellAppearance = appearance49;
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            column51.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column51.Header.Caption = StringResources.OBRACUNOBRMOKREDITORDescription;
            column51.Width = 0x6b;
            column51.Format = "";
            column51.CellAppearance = appearance47;
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            column54.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column54.Header.Caption = StringResources.OBRACUNOBRPOKREDITORDescription;
            column54.Width = 170;
            column54.Format = "";
            column54.CellAppearance = appearance50;
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            column52.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column52.Header.Caption = StringResources.OBRACUNOBRMZKREDITORDescription;
            column52.Width = 0x6b;
            column52.Format = "";
            column52.CellAppearance = appearance48;
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            column55.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column55.Header.Caption = StringResources.OBRACUNOBRPZKREDITORDescription;
            column55.Width = 170;
            column55.Format = "";
            column55.CellAppearance = appearance51;
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            column50.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column50.Header.Caption = StringResources.OBRACUNOBRIZNOSRATEKREDITORDescription;
            column50.Width = 0x9c;
            appearance46.TextHAlign = HAlign.Right;
            column50.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column50.PromptChar = ' ';
            column50.Format = "F2";
            column50.CellAppearance = appearance46;
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            column49.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column49.Header.Caption = StringResources.OBRACUNOBRACUNATIKUNSKIIZNOSDescription;
            column49.Width = 0xa3;
            appearance45.TextHAlign = HAlign.Right;
            column49.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column49.PromptChar = ' ';
            column49.Format = "F2";
            column49.CellAppearance = appearance45;
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            column62.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column62.Header.Caption = StringResources.OBRACUNVECOTPLACENOBROJRATADescription;
            column62.Width = 0x66;
            appearance58.TextHAlign = HAlign.Right;
            column62.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column62.PromptChar = ' ';
            column62.Format = "F2";
            column62.CellAppearance = appearance58;
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            column63.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column63.Header.Caption = StringResources.OBRACUNVECOTPLACENOUKUPNIIZNOSDescription;
            column63.Width = 0x66;
            appearance59.TextHAlign = HAlign.Right;
            column63.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column63.PromptChar = ' ';
            column63.Format = "F2";
            column63.CellAppearance = appearance59;
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            column60.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column60.Header.Caption = StringResources.OBRACUNUKUPNIZNOSKREDITADescription;
            column60.Width = 0x66;
            appearance56.TextHAlign = HAlign.Right;
            column60.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column60.PromptChar = ' ';
            column60.Format = "F2";
            column60.CellAppearance = appearance56;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column43.CellActivation = Activation.Disabled;
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.Header.Caption = StringResources.OBRACUNDOSADAOBUSTAVLJENODescription;
            column43.Width = 0x66;
            appearance40.TextHAlign = HAlign.Right;
            column43.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column43.PromptChar = ' ';
            column43.Format = "F2";
            column43.CellAppearance = appearance40;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column41.CellActivation = Activation.Disabled;
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.OBRACUNBRRATADOSADADescription;
            column41.Width = 0x66;
            appearance38.TextHAlign = HAlign.Right;
            column41.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column41.PromptChar = ' ';
            column41.Format = "F2";
            column41.CellAppearance = appearance38;
            band3.Columns.Add(column46);
            column46.Header.VisiblePosition = 0;
            band3.Columns.Add(column44);
            column44.Header.VisiblePosition = 1;
            band3.Columns.Add(column42);
            column42.Header.VisiblePosition = 2;
            band3.Columns.Add(column48);
            column48.Header.VisiblePosition = 3;
            band3.Columns.Add(column61);
            column61.Header.VisiblePosition = 4;
            band3.Columns.Add(column64);
            column64.Header.VisiblePosition = 5;
            band3.Columns.Add(column57);
            column57.Header.VisiblePosition = 6;
            band3.Columns.Add(column58);
            column58.Header.VisiblePosition = 7;
            band3.Columns.Add(column59);
            column59.Header.VisiblePosition = 8;
            band3.Columns.Add(column56);
            column56.Header.VisiblePosition = 9;
            band3.Columns.Add(column53);
            column53.Header.VisiblePosition = 10;
            band3.Columns.Add(column51);
            column51.Header.VisiblePosition = 11;
            band3.Columns.Add(column54);
            column54.Header.VisiblePosition = 12;
            band3.Columns.Add(column52);
            column52.Header.VisiblePosition = 13;
            band3.Columns.Add(column55);
            column55.Header.VisiblePosition = 14;
            band3.Columns.Add(column50);
            column50.Header.VisiblePosition = 15;
            band3.Columns.Add(column49);
            column49.Header.VisiblePosition = 0x10;
            band3.Columns.Add(column62);
            column62.Header.VisiblePosition = 0x11;
            band3.Columns.Add(column63);
            column63.Header.VisiblePosition = 0x12;
            band3.Columns.Add(column60);
            column60.Header.VisiblePosition = 0x13;
            band3.Columns.Add(column43);
            column43.Header.VisiblePosition = 20;
            band3.Columns.Add(column41);
            column41.Header.VisiblePosition = 0x15;
            band3.Columns.Add(column45);
            column45.Header.VisiblePosition = 0x16;
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            column104.CellActivation = Activation.Disabled;
            column104.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column104.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column104.Width = 0x5d;
            column104.Format = "";
            column104.CellAppearance = appearance98;
            column104.Hidden = true;
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            column106.CellActivation = Activation.Disabled;
            column106.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column106.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column106.Width = 0x69;
            column106.Format = "";
            column106.CellAppearance = appearance100;
            column106.Hidden = true;
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            column105.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column105.Header.Caption = StringResources.OBRACUNIDOBUSTAVADescription;
            column105.Width = 0x70;
            appearance99.TextHAlign = HAlign.Right;
            column105.MaskInput = "{LOC}-nnnnnnnn";
            column105.PromptChar = ' ';
            column105.Format = "";
            column105.CellAppearance = appearance99;
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            column112.CellActivation = Activation.Disabled;
            column112.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column112.Header.Caption = StringResources.OBRACUNNAZIVOBUSTAVADescription;
            column112.Width = 0x128;
            column112.Format = "";
            column112.CellAppearance = appearance105;
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            column110.CellActivation = Activation.Disabled;
            column110.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column110.Header.Caption = StringResources.OBRACUNMOOBUSTAVADescription;
            column110.Width = 0x79;
            column110.Format = "";
            column110.CellAppearance = appearance103;
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            column119.CellActivation = Activation.Disabled;
            column119.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column119.Header.Caption = StringResources.OBRACUNPOOBUSTAVADescription;
            column119.Width = 240;
            column119.Format = "";
            column119.CellAppearance = appearance112;
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            column111.CellActivation = Activation.Disabled;
            column111.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column111.Header.Caption = StringResources.OBRACUNMZOBUSTAVADescription;
            column111.Width = 0xb8;
            column111.Format = "";
            column111.CellAppearance = appearance104;
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            column124.CellActivation = Activation.Disabled;
            column124.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column124.Header.Caption = StringResources.OBRACUNPZOBUSTAVADescription;
            column124.Width = 240;
            column124.Format = "";
            column124.CellAppearance = appearance117;
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            column127.CellActivation = Activation.Disabled;
            column127.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column127.Header.Caption = StringResources.OBRACUNVBDIOBUSTAVADescription;
            column127.Width = 0xbf;
            column127.Format = "";
            column127.CellAppearance = appearance120;
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            column129.CellActivation = Activation.Disabled;
            column129.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column129.Header.Caption = StringResources.OBRACUNZRNOBUSTAVADescription;
            column129.Width = 0xbf;
            column129.Format = "";
            column129.CellAppearance = appearance122;
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            column121.CellActivation = Activation.Disabled;
            column121.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column121.Header.Caption = StringResources.OBRACUNPRIMATELJOBUSTAVA1Description;
            column121.Width = 0x9c;
            column121.Format = "";
            column121.CellAppearance = appearance114;
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            column122.CellActivation = Activation.Disabled;
            column122.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column122.Header.Caption = StringResources.OBRACUNPRIMATELJOBUSTAVA2Description;
            column122.Width = 0x9c;
            column122.Format = "";
            column122.CellAppearance = appearance115;
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            column123.CellActivation = Activation.Disabled;
            column123.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column123.Header.Caption = StringResources.OBRACUNPRIMATELJOBUSTAVA3Description;
            column123.Width = 0x9c;
            column123.Format = "";
            column123.CellAppearance = appearance116;
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            column126.CellActivation = Activation.Disabled;
            column126.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column126.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAOBUSTAVADescription;
            column126.Width = 0x9c;
            column126.Format = "";
            column126.CellAppearance = appearance119;
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            column118.CellActivation = Activation.Disabled;
            column118.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column118.Header.Caption = StringResources.OBRACUNOPISPLACANJAOBUSTAVADescription;
            column118.Width = 0x10c;
            column118.Format = "";
            column118.CellAppearance = appearance111;
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            column128.CellActivation = Activation.Disabled;
            column128.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column128.Header.Caption = StringResources.OBRACUNVRSTAOBUSTAVEDescription;
            column128.Width = 0x70;
            appearance121.TextHAlign = HAlign.Right;
            column128.MaskInput = "{LOC}-nn";
            column128.PromptChar = ' ';
            column128.Format = "";
            column128.CellAppearance = appearance121;
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            column113.CellActivation = Activation.Disabled;
            column113.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column113.Header.Caption = StringResources.OBRACUNNAZIVVRSTAOBUSTAVEDescription;
            column113.Width = 0x128;
            column113.Format = "";
            column113.CellAppearance = appearance106;
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            column109.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column109.Header.Caption = StringResources.OBRACUNIZNOSOBUSTAVEDescription;
            column109.Width = 0x6d;
            appearance102.TextHAlign = HAlign.Right;
            column109.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column109.PromptChar = ' ';
            column109.Format = "F2";
            column109.CellAppearance = appearance102;
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            column120.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column120.Header.Caption = StringResources.OBRACUNPOSTOTAKOBUSTAVEDescription;
            column120.Width = 0x81;
            appearance113.TextHAlign = HAlign.Right;
            column120.MaskInput = "{LOC}-nnn.nn";
            column120.PromptChar = ' ';
            column120.Format = "F2";
            column120.CellAppearance = appearance113;
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            column114.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column114.Header.Caption = StringResources.OBRACUNOBRACUNATAOBUSTAVAUKUNAMADescription;
            column114.Width = 190;
            appearance107.TextHAlign = HAlign.Right;
            column114.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column114.PromptChar = ' ';
            column114.Format = "F2";
            column114.CellAppearance = appearance107;
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            column108.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column108.Header.Caption = StringResources.OBRACUNISPLACENOKASADescription;
            column108.Width = 0x6d;
            appearance101.TextHAlign = HAlign.Right;
            column108.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column108.PromptChar = ' ';
            column108.Format = "F2";
            column108.CellAppearance = appearance101;
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            column125.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column125.Header.Caption = StringResources.OBRACUNSALDOKASADescription;
            column125.Width = 0x66;
            appearance118.TextHAlign = HAlign.Right;
            column125.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column125.PromptChar = ' ';
            column125.Format = "F2";
            column125.CellAppearance = appearance118;
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            column115.CellActivation = Activation.Disabled;
            column115.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column115.Header.Caption = StringResources.OBRACUNOBUSTAVLJENODOSADADescription;
            column115.Width = 0x8f;
            appearance109.TextHAlign = HAlign.Right;
            column115.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column115.PromptChar = ' ';
            column115.Format = "F2";
            column115.CellAppearance = appearance109;
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            column116.CellActivation = Activation.Disabled;
            column116.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column116.Header.Caption = StringResources.OBRACUNOBUSTAVLJENODOSADABROJRATADescription;
            column116.Width = 0xc5;
            appearance108.TextHAlign = HAlign.Right;
            column116.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column116.PromptChar = ' ';
            column116.Format = "F2";
            column116.CellAppearance = appearance108;
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            column117.CellActivation = Activation.Disabled;
            column117.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column117.Header.Caption = StringResources.OBRACUNOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEDescription;
            column117.Width = 0x123;
            appearance110.TextHAlign = HAlign.Right;
            column117.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column117.PromptChar = ' ';
            column117.Format = "F2";
            column117.CellAppearance = appearance110;
            band6.Columns.Add(column106);
            column106.Header.VisiblePosition = 0;
            band6.Columns.Add(column105);
            column105.Header.VisiblePosition = 1;
            band6.Columns.Add(column112);
            column112.Header.VisiblePosition = 2;
            band6.Columns.Add(column110);
            column110.Header.VisiblePosition = 3;
            band6.Columns.Add(column119);
            column119.Header.VisiblePosition = 4;
            band6.Columns.Add(column111);
            column111.Header.VisiblePosition = 5;
            band6.Columns.Add(column124);
            column124.Header.VisiblePosition = 6;
            band6.Columns.Add(column127);
            column127.Header.VisiblePosition = 7;
            band6.Columns.Add(column129);
            column129.Header.VisiblePosition = 8;
            band6.Columns.Add(column121);
            column121.Header.VisiblePosition = 9;
            band6.Columns.Add(column122);
            column122.Header.VisiblePosition = 10;
            band6.Columns.Add(column123);
            column123.Header.VisiblePosition = 11;
            band6.Columns.Add(column126);
            column126.Header.VisiblePosition = 12;
            band6.Columns.Add(column118);
            column118.Header.VisiblePosition = 13;
            band6.Columns.Add(column128);
            column128.Header.VisiblePosition = 14;
            band6.Columns.Add(column113);
            column113.Header.VisiblePosition = 15;
            band6.Columns.Add(column109);
            column109.Header.VisiblePosition = 0x10;
            band6.Columns.Add(column120);
            column120.Header.VisiblePosition = 0x11;
            band6.Columns.Add(column114);
            column114.Header.VisiblePosition = 0x12;
            band6.Columns.Add(column108);
            column108.Header.VisiblePosition = 0x13;
            band6.Columns.Add(column125);
            column125.Header.VisiblePosition = 20;
            band6.Columns.Add(column115);
            column115.Header.VisiblePosition = 0x15;
            band6.Columns.Add(column116);
            column116.Header.VisiblePosition = 0x16;
            band6.Columns.Add(column117);
            column117.Header.VisiblePosition = 0x17;
            band6.Columns.Add(column104);
            column104.Header.VisiblePosition = 0x18;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.Disabled;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column27.Width = 0x5d;
            column27.Format = "";
            column27.CellAppearance = appearance25;
            column27.Hidden = true;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.Disabled;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column29.Width = 0x69;
            column29.Format = "";
            column29.CellAppearance = appearance27;
            column29.Hidden = true;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.OBRACUNIDELEMENTDescription;
            column25.Width = 0x70;
            column25.Format = "";
            column25.CellAppearance = appearance24;
            column26.AllowGroupBy = DefaultableBoolean.False;
            column26.AutoSizeEdit = DefaultableBoolean.False;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column26.CellAppearance.BorderAlpha = Alpha.Transparent;
            column26.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column26.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column26.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column26.Header.Enabled = false;
            column26.Header.Fixed = true;
            column26.Header.Caption = "";
            column26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column26.Width = 20;
            column26.MinWidth = 20;
            column26.MaxWidth = 20;
            column26.Tag = "ELEMENTIDELEMENTAddNew";
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            column24.Width = 100;
            column24.MinValue = DateTime.MinValue;
            column24.MaxValue = DateTime.MaxValue;
            column24.Format = "d";
            column24.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.OBRACUNELEMENTRAZDOBLJEDODescription;
            column23.Width = 100;
            column23.MinValue = DateTime.MinValue;
            column23.MaxValue = DateTime.MaxValue;
            column23.Format = "d";
            column23.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.Disabled;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.OBRACUNIDOSNOVAOSIGURANJADescription;
            column28.Width = 0xb1;
            column28.Format = "";
            column28.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.Disabled;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.OBRACUNNAZIVOSNOVAOSIGURANJADescription;
            column33.Width = 0x128;
            column33.Format = "";
            column33.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column39.CellActivation = Activation.Disabled;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.OBRACUNRAZDOBLJESESMIJEPREKLAPATIDescription;
            column39.Width = 0xdb;
            column39.Format = "";
            column39.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.OBRACUNOBRSATIDescription;
            column37.Width = 0x37;
            appearance34.TextHAlign = HAlign.Right;
            column37.MaskInput = "{LOC}-nnn.nn";
            column37.PromptChar = ' ';
            column37.Format = "F2";
            column37.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.OBRACUNOBRSATNICADescription;
            column38.Width = 0x66;
            appearance35.TextHAlign = HAlign.Right;
            column38.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column38.PromptChar = ' ';
            column38.Format = "F8";
            column38.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.OBRACUNOBRIZNOSDescription;
            column35.Width = 0x66;
            appearance32.TextHAlign = HAlign.Right;
            column35.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column35.PromptChar = ' ';
            column35.Format = "F2";
            column35.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.Disabled;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.OBRACUNNAZIVELEMENTDescription;
            column32.Width = 0x128;
            column32.Format = "";
            column32.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.Disabled;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.OBRACUNIDVRSTAELEMENTADescription;
            column31.Width = 0x99;
            appearance28.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnnn";
            column31.PromptChar = ' ';
            column31.Format = "";
            column31.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.Disabled;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.OBRACUNNAZIVVRSTAELEMENTDescription;
            column34.Width = 0xbf;
            column34.Format = "";
            column34.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.OBRACUNOBRPOSTOTAKDescription;
            column36.Width = 0x37;
            appearance33.TextHAlign = HAlign.Right;
            column36.MaskInput = "{LOC}-nnn.nn";
            column36.PromptChar = ' ';
            column36.Format = "F2";
            column36.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column40.CellActivation = Activation.Disabled;
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.OBRACUNZBRAJASATEUFONDSATIDescription;
            column40.Width = 170;
            column40.Format = "";
            column40.CellAppearance = appearance37;
            band2.Columns.Add(column29);
            column29.Header.VisiblePosition = 0;
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 1;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 2;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 3;
            band2.Columns.Add(column28);
            column28.Header.VisiblePosition = 4;
            band2.Columns.Add(column33);
            column33.Header.VisiblePosition = 5;
            band2.Columns.Add(column39);
            column39.Header.VisiblePosition = 6;
            band2.Columns.Add(column37);
            column37.Header.VisiblePosition = 7;
            band2.Columns.Add(column38);
            column38.Header.VisiblePosition = 8;
            band2.Columns.Add(column35);
            column35.Header.VisiblePosition = 9;
            band2.Columns.Add(column32);
            column32.Header.VisiblePosition = 10;
            band2.Columns.Add(column31);
            column31.Header.VisiblePosition = 11;
            band2.Columns.Add(column34);
            column34.Header.VisiblePosition = 12;
            band2.Columns.Add(column36);
            column36.Header.VisiblePosition = 13;
            band2.Columns.Add(column40);
            column40.Header.VisiblePosition = 14;
            band2.Columns.Add(column27);
            column27.Header.VisiblePosition = 15;
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            column82.CellActivation = Activation.Disabled;
            column82.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column82.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column82.Width = 0x5d;
            column82.Format = "";
            column82.CellAppearance = appearance77;
            column82.Hidden = true;
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            column83.CellActivation = Activation.Disabled;
            column83.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column83.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column83.Width = 0x69;
            column83.Format = "";
            column83.CellAppearance = appearance78;
            column83.Hidden = true;
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            column81.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column81.Header.Caption = StringResources.OBRACUNIDKRIZNIPOREZDescription;
            column81.Width = 0x69;
            appearance76.TextHAlign = HAlign.Right;
            column81.MaskInput = "{LOC}-nnnnn";
            column81.PromptChar = ' ';
            column81.Format = "";
            column81.CellAppearance = appearance76;
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            column88.CellActivation = Activation.Disabled;
            column88.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column88.Header.Caption = StringResources.OBRACUNNAZIVKRIZNIPOREZDescription;
            column88.Width = 0x128;
            column88.Format = "";
            column88.CellAppearance = appearance82;
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            column85.CellActivation = Activation.Disabled;
            column85.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column85.Header.Caption = StringResources.OBRACUNKRIZNISTOPADescription;
            column85.Width = 0x60;
            appearance79.TextHAlign = HAlign.Right;
            column85.MaskInput = "{LOC}-nnn.nn";
            column85.PromptChar = ' ';
            column85.Format = "F2";
            column85.CellAppearance = appearance79;
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            column86.CellActivation = Activation.Disabled;
            column86.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column86.Header.Caption = StringResources.OBRACUNMOKRIZNIDescription;
            column86.Width = 0x48;
            column86.Format = "";
            column86.CellAppearance = appearance80;
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            column93.CellActivation = Activation.Disabled;
            column93.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column93.Header.Caption = StringResources.OBRACUNPOKRIZNIDescription;
            column93.Width = 170;
            column93.Format = "";
            column93.CellAppearance = appearance87;
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            column87.CellActivation = Activation.Disabled;
            column87.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column87.Header.Caption = StringResources.OBRACUNMZKRIZNIDescription;
            column87.Width = 0x48;
            column87.Format = "";
            column87.CellAppearance = appearance81;
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            column100.CellActivation = Activation.Disabled;
            column100.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column100.Header.Caption = StringResources.OBRACUNPZKRIZNIDescription;
            column100.Width = 170;
            column100.Format = "";
            column100.CellAppearance = appearance94;
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            column97.CellActivation = Activation.Disabled;
            column97.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column97.Header.Caption = StringResources.OBRACUNPRIMATELJKRIZNI1Description;
            column97.Width = 0x9c;
            column97.Format = "";
            column97.CellAppearance = appearance91;
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            column98.CellActivation = Activation.Disabled;
            column98.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column98.Header.Caption = StringResources.OBRACUNPRIMATELJKRIZNI2Description;
            column98.Width = 0x9c;
            column98.Format = "";
            column98.CellAppearance = appearance92;
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            column99.CellActivation = Activation.Disabled;
            column99.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column99.Header.Caption = StringResources.OBRACUNPRIMATELJKRIZNI3Description;
            column99.Width = 0x9c;
            column99.Format = "";
            column99.CellAppearance = appearance93;
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            column101.CellActivation = Activation.Disabled;
            column101.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column101.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAKRIZNIDescription;
            column101.Width = 0xb8;
            column101.Format = "";
            column101.CellAppearance = appearance95;
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            column89.CellActivation = Activation.Disabled;
            column89.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column89.Header.Caption = StringResources.OBRACUNOPISPLACANJAKRIZNIDescription;
            column89.Width = 0x10c;
            column89.Format = "";
            column89.CellAppearance = appearance83;
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            column102.CellActivation = Activation.Disabled;
            column102.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column102.Header.Caption = StringResources.OBRACUNVBDIKRIZNIDescription;
            column102.Width = 0x56;
            column102.Format = "";
            column102.CellAppearance = appearance96;
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            column103.CellActivation = Activation.Disabled;
            column103.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column103.Header.Caption = StringResources.OBRACUNZRNKRIZNIDescription;
            column103.Width = 0x56;
            column103.Format = "";
            column103.CellAppearance = appearance97;
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            column90.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column90.Header.Caption = StringResources.OBRACUNOSNOVICAKRIZNIDescription;
            column90.Width = 0x74;
            appearance84.TextHAlign = HAlign.Right;
            column90.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column90.PromptChar = ' ';
            column90.Format = "F2";
            column90.CellAppearance = appearance84;
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            column94.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column94.Header.Caption = StringResources.OBRACUNPOREZKRIZNIDescription;
            column94.Width = 0x66;
            appearance88.TextHAlign = HAlign.Right;
            column94.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column94.PromptChar = ' ';
            column94.Format = "F2";
            column94.CellAppearance = appearance88;
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            column91.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column91.Header.Caption = StringResources.OBRACUNOSNOVICAPRETHODNADescription;
            column91.Width = 0x88;
            appearance85.TextHAlign = HAlign.Right;
            column91.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column91.PromptChar = ' ';
            column91.Format = "F2";
            column91.CellAppearance = appearance85;
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            column92.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column92.Header.Caption = StringResources.OBRACUNOSNOVICAUKUPNADescription;
            column92.Width = 0x74;
            appearance86.TextHAlign = HAlign.Right;
            column92.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column92.PromptChar = ' ';
            column92.Format = "F2";
            column92.CellAppearance = appearance86;
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            column95.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column95.Header.Caption = StringResources.OBRACUNPOREZPRETHODNIDescription;
            column95.Width = 0x74;
            appearance89.TextHAlign = HAlign.Right;
            column95.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column95.PromptChar = ' ';
            column95.Format = "F2";
            column95.CellAppearance = appearance89;
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            column96.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column96.Header.Caption = StringResources.OBRACUNPOREZUKUPNODescription;
            column96.Width = 0x66;
            appearance90.TextHAlign = HAlign.Right;
            column96.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column96.PromptChar = ' ';
            column96.Format = "F2";
            column96.CellAppearance = appearance90;
            band5.Columns.Add(column83);
            column83.Header.VisiblePosition = 0;
            band5.Columns.Add(column81);
            column81.Header.VisiblePosition = 1;
            band5.Columns.Add(column88);
            column88.Header.VisiblePosition = 2;
            band5.Columns.Add(column85);
            column85.Header.VisiblePosition = 3;
            band5.Columns.Add(column86);
            column86.Header.VisiblePosition = 4;
            band5.Columns.Add(column93);
            column93.Header.VisiblePosition = 5;
            band5.Columns.Add(column87);
            column87.Header.VisiblePosition = 6;
            band5.Columns.Add(column100);
            column100.Header.VisiblePosition = 7;
            band5.Columns.Add(column97);
            column97.Header.VisiblePosition = 8;
            band5.Columns.Add(column98);
            column98.Header.VisiblePosition = 9;
            band5.Columns.Add(column99);
            column99.Header.VisiblePosition = 10;
            band5.Columns.Add(column101);
            column101.Header.VisiblePosition = 11;
            band5.Columns.Add(column89);
            column89.Header.VisiblePosition = 12;
            band5.Columns.Add(column102);
            column102.Header.VisiblePosition = 13;
            band5.Columns.Add(column103);
            column103.Header.VisiblePosition = 14;
            band5.Columns.Add(column90);
            column90.Header.VisiblePosition = 15;
            band5.Columns.Add(column94);
            column94.Header.VisiblePosition = 0x10;
            band5.Columns.Add(column91);
            column91.Header.VisiblePosition = 0x11;
            band5.Columns.Add(column92);
            column92.Header.VisiblePosition = 0x12;
            band5.Columns.Add(column95);
            column95.Header.VisiblePosition = 0x13;
            band5.Columns.Add(column96);
            column96.Header.VisiblePosition = 20;
            band5.Columns.Add(column82);
            column82.Header.VisiblePosition = 0x15;
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            column65.CellActivation = Activation.Disabled;
            column65.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column65.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column65.Width = 0x5d;
            column65.Format = "";
            column65.CellAppearance = appearance61;
            column65.Hidden = true;
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            column67.CellActivation = Activation.Disabled;
            column67.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column67.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column67.Width = 0x69;
            column67.Format = "";
            column67.CellAppearance = appearance63;
            column67.Hidden = true;
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            column66.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column66.Header.Caption = StringResources.OBRACUNIDOBRACUNIZUZECEDescription;
            column66.Width = 0x10c;
            column66.Format = "";
            column66.CellAppearance = appearance62;
            column66.Hidden = true;
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            column74.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column74.Header.Caption = StringResources.OBRACUNPRIMATELJIZUZECE1Description;
            column74.Width = 0x9c;
            column74.Format = "";
            column74.CellAppearance = appearance69;
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            column75.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column75.Header.Caption = StringResources.OBRACUNPRIMATELJIZUZECE2Description;
            column75.Width = 0x9c;
            column75.Format = "";
            column75.CellAppearance = appearance70;
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            column76.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column76.Header.Caption = StringResources.OBRACUNPRIMATELJIZUZECE3Description;
            column76.Width = 0x9c;
            column76.Format = "";
            column76.CellAppearance = appearance71;
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            column78.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column78.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAIZUZECEDescription;
            column78.Width = 0xbf;
            column78.Format = "";
            column78.CellAppearance = appearance73;
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            column72.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column72.Header.Caption = StringResources.OBRACUNOPISPLACANJAIZUZECEDescription;
            column72.Width = 0x10c;
            column72.Format = "";
            column72.CellAppearance = appearance67;
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            column80.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column80.Header.Caption = StringResources.OBRACUNVBDIIZUZECEDescription;
            column80.Width = 0x5d;
            column80.Format = "";
            column80.CellAppearance = appearance75;
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            column79.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column79.Header.Caption = StringResources.OBRACUNTEKUCIIZUZECEDescription;
            column79.Width = 0x6b;
            column79.Format = "";
            column79.CellAppearance = appearance74;
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            column70.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column70.Header.Caption = StringResources.OBRACUNMOIZUZECEDescription;
            column70.Width = 0x4f;
            column70.Format = "";
            column70.CellAppearance = appearance65;
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            column73.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column73.Header.Caption = StringResources.OBRACUNPOIZUZECEDescription;
            column73.Width = 170;
            column73.Format = "";
            column73.CellAppearance = appearance68;
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            column71.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column71.Header.Caption = StringResources.OBRACUNMZIZUZECEDescription;
            column71.Width = 0x4f;
            column71.Format = "";
            column71.CellAppearance = appearance66;
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            column77.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column77.Header.Caption = StringResources.OBRACUNPZIZUZECEDescription;
            column77.Width = 170;
            column77.Format = "";
            column77.CellAppearance = appearance72;
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            column69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column69.Header.Caption = StringResources.OBRACUNIZNOSIZUZECADescription;
            column69.Width = 0x66;
            appearance64.TextHAlign = HAlign.Right;
            column69.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column69.PromptChar = ' ';
            column69.Format = "F2";
            column69.CellAppearance = appearance64;
            band4.Columns.Add(column67);
            column67.Header.VisiblePosition = 0;
            band4.Columns.Add(column74);
            column74.Header.VisiblePosition = 1;
            band4.Columns.Add(column75);
            column75.Header.VisiblePosition = 2;
            band4.Columns.Add(column76);
            column76.Header.VisiblePosition = 3;
            band4.Columns.Add(column78);
            column78.Header.VisiblePosition = 4;
            band4.Columns.Add(column72);
            column72.Header.VisiblePosition = 5;
            band4.Columns.Add(column80);
            column80.Header.VisiblePosition = 6;
            band4.Columns.Add(column79);
            column79.Header.VisiblePosition = 7;
            band4.Columns.Add(column70);
            column70.Header.VisiblePosition = 8;
            band4.Columns.Add(column73);
            column73.Header.VisiblePosition = 9;
            band4.Columns.Add(column71);
            column71.Header.VisiblePosition = 10;
            band4.Columns.Add(column77);
            column77.Header.VisiblePosition = 11;
            band4.Columns.Add(column69);
            column69.Header.VisiblePosition = 12;
            band4.Columns.Add(column65);
            column65.Header.VisiblePosition = 13;
            band4.Columns.Add(column66);
            column66.Header.VisiblePosition = 14;
            band9.Columns.Add(column185);
            column185.Header.VisiblePosition = 0;
            band9.Columns.Add(column222);
            column222.Header.VisiblePosition = 1;
            band9.Columns.Add(column190);
            column190.Header.VisiblePosition = 2;
            band9.Columns.Add(column233);
            column233.Header.VisiblePosition = 3;
            band9.Columns.Add(column198);
            column198.Header.VisiblePosition = 4;
            band9.Columns.Add(column195);
            column195.Header.VisiblePosition = 5;
            band9.Columns.Add(column192);
            column192.Header.VisiblePosition = 6;
            band9.Columns.Add(column176);
            column176.Header.VisiblePosition = 7;
            band9.Columns.Add(column210);
            column210.Header.VisiblePosition = 8;
            band9.Columns.Add(column211);
            column211.Header.VisiblePosition = 9;
            band9.Columns.Add(column212);
            column212.Header.VisiblePosition = 10;
            band9.Columns.Add(column213);
            column213.Header.VisiblePosition = 11;
            band9.Columns.Add(column214);
            column214.Header.VisiblePosition = 12;
            band9.Columns.Add(column215);
            column215.Header.VisiblePosition = 13;
            band9.Columns.Add(column226);
            column226.Header.VisiblePosition = 14;
            band9.Columns.Add(column181);
            column181.Header.VisiblePosition = 15;
            band9.Columns.Add(column202);
            column202.Header.VisiblePosition = 0x10;
            band9.Columns.Add(column172);
            column172.Header.VisiblePosition = 0x11;
            band9.Columns.Add(column180);
            column180.Header.VisiblePosition = 0x12;
            band9.Columns.Add(column199);
            column199.Header.VisiblePosition = 0x13;
            band9.Columns.Add(column200);
            column200.Header.VisiblePosition = 20;
            band9.Columns.Add(column201);
            column201.Header.VisiblePosition = 0x15;
            band9.Columns.Add(column235);
            column235.Header.VisiblePosition = 0x16;
            band9.Columns.Add(column237);
            column237.Header.VisiblePosition = 0x17;
            band9.Columns.Add(column228);
            column228.Header.VisiblePosition = 0x18;
            band9.Columns.Add(column227);
            column227.Header.VisiblePosition = 0x19;
            band9.Columns.Add(column216);
            column216.Header.VisiblePosition = 0x1a;
            band9.Columns.Add(column171);
            column171.Header.VisiblePosition = 0x1b;
            band9.Columns.Add(column173);
            column173.Header.VisiblePosition = 0x1c;
            band9.Columns.Add(column196);
            column196.Header.VisiblePosition = 0x1d;
            band9.Columns.Add(column219);
            column219.Header.VisiblePosition = 30;
            band9.Columns.Add(column193);
            column193.Header.VisiblePosition = 0x1f;
            band9.Columns.Add(column207);
            column207.Header.VisiblePosition = 0x20;
            band9.Columns.Add(column187);
            column187.Header.VisiblePosition = 0x21;
            band9.Columns.Add(column203);
            column203.Header.VisiblePosition = 0x22;
            band9.Columns.Add(column231);
            column231.Header.VisiblePosition = 0x23;
            band9.Columns.Add(column232);
            column232.Header.VisiblePosition = 0x24;
            band9.Columns.Add(column220);
            column220.Header.VisiblePosition = 0x25;
            band9.Columns.Add(column221);
            column221.Header.VisiblePosition = 0x26;
            band9.Columns.Add(column188);
            column188.Header.VisiblePosition = 0x27;
            band9.Columns.Add(column204);
            column204.Header.VisiblePosition = 40;
            band9.Columns.Add(column224);
            column224.Header.VisiblePosition = 0x29;
            band9.Columns.Add(column225);
            column225.Header.VisiblePosition = 0x2a;
            band9.Columns.Add(column170);
            column170.Header.VisiblePosition = 0x2b;
            band9.Columns.Add(column191);
            column191.Header.VisiblePosition = 0x2c;
            band9.Columns.Add(column206);
            column206.Header.VisiblePosition = 0x2d;
            band9.Columns.Add(column178);
            column178.Header.VisiblePosition = 0x2e;
            band9.Columns.Add(column177);
            column177.Header.VisiblePosition = 0x2f;
            band9.Columns.Add(column229);
            column229.Header.VisiblePosition = 0x30;
            band9.Columns.Add(column230);
            column230.Header.VisiblePosition = 0x31;
            band9.Columns.Add(column179);
            column179.Header.VisiblePosition = 50;
            band9.Columns.Add(column197);
            column197.Header.VisiblePosition = 0x33;
            band9.Columns.Add(column174);
            column174.Header.VisiblePosition = 0x34;
            band9.Columns.Add(column175);
            column175.Header.VisiblePosition = 0x35;
            band9.Columns.Add(column189);
            column189.Header.VisiblePosition = 0x36;
            band9.Columns.Add(column205);
            column205.Header.VisiblePosition = 0x37;
            band9.Columns.Add(column236);
            column236.Header.VisiblePosition = 0x38;
            band9.Columns.Add(column234);
            column234.Header.VisiblePosition = 0x39;
            band9.Columns.Add(column184);
            column184.Header.VisiblePosition = 0x3a;
            band9.Columns.Add(column217);
            column217.Header.VisiblePosition = 0x3b;
            band9.Columns.Add(column182);
            column182.Header.VisiblePosition = 60;
            band9.Columns.Add(column209);
            column209.Header.VisiblePosition = 0x3d;
            band9.Columns.Add(column218);
            column218.Header.VisiblePosition = 0x3e;
            band9.Columns.Add(column223);
            column223.Header.VisiblePosition = 0x3f;
            band9.Columns.Add(column194);
            column194.Header.VisiblePosition = 0x40;
            band9.Columns.Add(column208);
            column208.Header.VisiblePosition = 0x41;
            band9.Columns.Add(column183);
            column183.Header.VisiblePosition = 0x42;
            this.grdLevelObracunRadnici.Visible = true;
            this.grdLevelObracunRadnici.Name = "grdLevelObracunRadnici";
            this.grdLevelObracunRadnici.Tag = "ObracunRadnici";
            this.grdLevelObracunRadnici.TabIndex = 40;
            this.grdLevelObracunRadnici.Dock = DockStyle.Fill;
            this.grdLevelObracunRadnici.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelObracunRadnici.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelObracunRadnici.DataSource = this.bindingSourceObracunRadnici;
            this.grdLevelObracunRadnici.Enter += new EventHandler(this.grdLevelObracunRadnici_Enter);
            this.grdLevelObracunRadnici.AfterRowInsert += new RowEventHandler(this.grdLevelObracunRadnici_AfterRowInsert);
            this.grdLevelObracunRadnici.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelObracunRadnici.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelObracunRadnici.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelObracunRadnici.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelObracunRadnici_DoubleClick);
            this.grdLevelObracunRadnici.AfterRowActivate += new EventHandler(this.grdLevelObracunRadnici_AfterRowActivate);
            this.grdLevelObracunRadnici.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelObracunRadnici.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band9);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band8);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band7);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band3);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band6);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band2);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band5);
            this.grdLevelObracunRadnici.DisplayLayout.BandsSerializer.Add(band4);
            this.Name = "OBRACUNFormUserControl";
            this.Text = "Obraeun";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OBRACUNFormUserControl_Load);
            this.layoutManagerformOBRACUN.ResumeLayout(false);
            this.layoutManagerformOBRACUN.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOBRACUN).EndInit();
            ((ISupportInitialize) this.bindingSourceObracunRadnici).EndInit();
            ((ISupportInitialize) this.textIDOBRACUN).EndInit();
            ((ISupportInitialize) this.textVRSTAOBRACUNA).EndInit();
            ((ISupportInitialize) this.textMJESECOBRACUNA).EndInit();
            ((ISupportInitialize) this.textGODINAOBRACUNA).EndInit();
            ((ISupportInitialize) this.textMJESECISPLATE).EndInit();
            ((ISupportInitialize) this.textGODINAISPLATE).EndInit();
            ((ISupportInitialize) this.texttjednifondsatiobracun).EndInit();
            ((ISupportInitialize) this.textMJESECNIFONDSATIOBRACUN).EndInit();
            ((ISupportInitialize) this.textOSNOVNIOO).EndInit();
            ((ISupportInitialize) this.textOBRACUNSKAOSNOVICA).EndInit();
            ((ISupportInitialize) this.textSVRHAOBRACUNA).EndInit();
            ((ISupportInitialize) this.grdLevelObracunRadnici).EndInit();
            this.panelactionsObracunRadnici.ResumeLayout(true);
            this.panelactionsObracunRadnici.PerformLayout();
            this.layoutManagerpanelactionsObracunRadnici.ResumeLayout(false);
            this.layoutManagerpanelactionsObracunRadnici.PerformLayout();
            this.dsOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOBRACUN, this.OBRACUNController.WorkItem, this))
            {
                return false;
            }
            this.EndEditCurrentRow();
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private static void LoadValueList(ValueList myValueList, DataView enumList, string Id, string Name)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = enumList.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRowView current = (DataRowView) enumerator.Current;
                    DataRow row = current.Row;
                    ValueListItem item = new ValueListItem {
                        DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                        DisplayText = row[Name].ToString()
                    };
                    myValueList.ValueListItems.Add(item);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            myValueList.Tag = enumList;
        }

        private void Localize()
        {
            this.label1IDOBRACUN.Text = StringResources.OBRACUNIDOBRACUNDescription;
            this.label1VRSTAOBRACUNA.Text = StringResources.OBRACUNVRSTAOBRACUNADescription;
            this.label1MJESECOBRACUNA.Text = StringResources.OBRACUNMJESECOBRACUNADescription;
            this.label1GODINAOBRACUNA.Text = StringResources.OBRACUNGODINAOBRACUNADescription;
            this.label1MJESECISPLATE.Text = StringResources.OBRACUNMJESECISPLATEDescription;
            this.label1GODINAISPLATE.Text = StringResources.OBRACUNGODINAISPLATEDescription;
            this.label1DATUMISPLATE.Text = StringResources.OBRACUNDATUMISPLATEDescription;
            this.label1tjednifondsatiobracun.Text = StringResources.OBRACUNtjednifondsatiobracunDescription;
            this.label1MJESECNIFONDSATIOBRACUN.Text = StringResources.OBRACUNMJESECNIFONDSATIOBRACUNDescription;
            this.label1OSNOVNIOO.Text = StringResources.OBRACUNOSNOVNIOODescription;
            this.label1OBRACUNSKAOSNOVICA.Text = StringResources.OBRACUNOBRACUNSKAOSNOVICADescription;
            this.label1DATUMOBRACUNASTAZA.Text = StringResources.OBRACUNDATUMOBRACUNASTAZADescription;
            this.label1OBRPOSTOTNIH.Text = StringResources.OBRACUNOBRPOSTOTNIHDescription;
            this.label1OBRFIKSNIH.Text = StringResources.OBRACUNOBRFIKSNIHDescription;
            this.label1OBRKREDITNIH.Text = StringResources.OBRACUNOBRKREDITNIHDescription;
            this.label1ZAKLJ.Text = StringResources.OBRACUNZAKLJDescription;
            this.label1SVRHAOBRACUNA.Text = StringResources.OBRACUNSVRHAOBRACUNADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRSMA")]
        public void NewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.NewRSMA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void ObracunDoprinosiInsert()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("ObracunRadnici_ObracunDoprinosi");
                this.OBRACUNController.AddObracunDoprinosi(parentRow);
            }
        }

        private void ObracunDoprinosiUpdate()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                this.OBRACUNController.UpdateObracunDoprinosi(listObject.Row);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void ObracunElementiIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new ELEMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetELEMENTDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["ELEMENT"]) {
                Sort = "EL"
            };
            CreateValueList(this.grdLevelObracunRadnici, "ELEMENTIDELEMENT", enumList, "IDELEMENT", "EL", true);
        }

        private void ObracunElementiInsert()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("ObracunRadnici_ObracunElementi");
                this.OBRACUNController.AddObracunElementi(parentRow);
            }
        }

        private void ObracunElementiUpdate()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                this.OBRACUNController.UpdateObracunElementi(listObject.Row);
            }
        }

        private void OBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OBRACUNDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelObracunRadniciAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OBRACUNObracunRadniciLevelDescription;
            this.linkLabelObracunRadniciUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OBRACUNObracunRadniciLevelDescription;
            this.linkLabelObracunRadniciDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OBRACUNObracunRadniciLevelDescription;
        }

        private void OBRACUNKreditiInsert()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("ObracunRadnici_OBRACUNKrediti");
                this.OBRACUNController.AddOBRACUNKrediti(parentRow);
            }
        }

        private void OBRACUNKreditiUpdate()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                this.OBRACUNController.UpdateOBRACUNKrediti(listObject.Row);
            }
        }

        private void OBRACUNObustaveInsert()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("ObracunRadnici_OBRACUNObustave");
                this.OBRACUNController.AddOBRACUNObustave(parentRow);
            }
        }

        private void OBRACUNObustaveUpdate()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                this.OBRACUNController.UpdateOBRACUNObustave(listObject.Row);
            }
        }

        private void ObracunOlaksiceInsert()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("ObracunRadnici_ObracunOlaksice");
                this.OBRACUNController.AddObracunOlaksice(parentRow);
            }
        }

        private void ObracunOlaksiceUpdate()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                this.OBRACUNController.UpdateObracunOlaksice(listObject.Row);
            }
        }

        private void ObracunPoreziInsert()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("ObracunRadnici_ObracunPorezi");
                this.OBRACUNController.AddObracunPorezi(parentRow);
            }
        }

        private void ObracunPoreziUpdate()
        {
            if (this.grdLevelObracunRadnici.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelObracunRadnici.ActiveRow.ListObject;
                this.OBRACUNController.UpdateObracunPorezi(listObject.Row);
            }
        }

        private void ObracunRadniciAdd_Click(object sender, EventArgs e)
        {
            if (this.grdLevelObracunRadnici.ActiveRow != null)
            {
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunDoprinosi"))
                {
                    this.ObracunDoprinosiInsert();
                    return;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunPorezi"))
                {
                    this.ObracunPoreziInsert();
                    return;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunOlaksice"))
                {
                    this.ObracunOlaksiceInsert();
                    return;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_OBRACUNKrediti"))
                {
                    this.OBRACUNKreditiInsert();
                    return;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_OBRACUNObustave"))
                {
                    this.OBRACUNObustaveInsert();
                    return;
                }
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunElementi"))
                {
                    this.ObracunElementiInsert();
                    return;
                }
            }
            this.ObracunRadniciInsert();
        }

        private void ObracunRadniciDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunRadnici);
            if ((currentRowListIndex != -1) && (this.grdLevelObracunRadnici.Selected.Rows.Count > 0))
            {
                this.grdLevelObracunRadnici.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelObracunRadnici).Selected = true;
                this.grdLevelObracunRadnici.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
        public void ObracunRadniciIDRADNIK_Add(object sender, ComponentEventArgs e)
        {
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            CreateValueList(this.grdLevelObracunRadnici, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME", true);
        }

        private void ObracunRadniciInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceOBRACUN, this.OBRACUNController.WorkItem, this))
            {
                this.OBRACUNController.AddObracunRadnici(this.m_CurrentRow);
            }
        }

        private void ObracunRadniciUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunRadnici) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelObracunRadnici);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OBRACUNController.UpdateObracunRadnici(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunRadniciUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelObracunRadnici.ActiveRow != null)
            {
                if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunDoprinosi"))
                {
                    this.ObracunDoprinosiUpdate();
                }
                else if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunPorezi"))
                {
                    this.ObracunPoreziUpdate();
                }
                else if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunOlaksice"))
                {
                    this.ObracunOlaksiceUpdate();
                }
                else if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_OBRACUNKrediti"))
                {
                    this.OBRACUNKreditiUpdate();
                }
                else if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_OBRACUNObustave"))
                {
                    this.OBRACUNObustaveUpdate();
                }
                else if (this.grdLevelObracunRadnici.ActiveRow.Band.Key.EndsWith("_ObracunElementi"))
                {
                    this.ObracunElementiUpdate();
                }
                else
                {
                    this.ObracunRadniciUpdate();
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PictureBoxClickedInLinesIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesIDRADNIK(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNIK", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.OBRACUNController.WorkItem.Items.Contains("OBRACUN|OBRACUN"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceOBRACUN, "OBRACUN|OBRACUN");
            }
            if (!this.OBRACUNController.WorkItem.Items.Contains("OBRACUN|ObracunRadnici"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunRadnici, "OBRACUN|ObracunRadnici");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOBRACUNDataSet1.OBRACUN.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OBRACUNController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OBRACUNController.Update(this))
            {
                this.OBRACUNController.DataSet = new OBRACUNDataSet();
                DataSetUtil.AddEmptyRow(this.OBRACUNController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OBRACUNController.DataSet.OBRACUN[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            CreateValueList(this.grdLevelObracunRadnici, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDRADNIK");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelObracunRadnici.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
            gridColumn.Width = 370;
            UltraGridColumn column = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDDOPRINOS");
            column.Tag = "DOPRINOSIDDOPRINOS";
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column7 = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDPOREZ");
            column7.Tag = "POREZIDPOREZ";
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column6 = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDOLAKSICE");
            column6.Tag = "OLAKSICEIDOLAKSICE";
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDKREDITOR");
            column3.Tag = "KREDITORIDKREDITOR";
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDOBUSTAVA");
            column5.Tag = "OBUSTAVAIDOBUSTAVA";
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            DataSet dataSet = new ELEMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetELEMENTDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["ELEMENT"]) {
                Sort = "EL"
            };
            CreateValueList(this.grdLevelObracunRadnici, "ELEMENTIDELEMENT", enumList, "IDELEMENT", "EL", false);
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDELEMENT");
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.grdLevelObracunRadnici.DisplayLayout.ValueLists["ELEMENTIDELEMENT"];
            column2.Width = 370;
            UltraGridColumn column4 = FormHelperClass.GetGridColumn(this.grdLevelObracunRadnici, "IDKRIZNIPOREZ");
            column4.Tag = "KRIZNIPOREZIDKRIZNIPOREZ";
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelObracunRadnici.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelObracunRadnici.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDOBRACUN.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesIDELEMENT(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDELEMENT"] = RuntimeHelpers.GetObjectValue(result["IDELEMENT"]);
                    row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(result["NAZIVELEMENT"]);
                    row["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(result["IDVRSTAELEMENTA"]);
                    row["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(result["ZBRAJASATEUFONDSATI"]);
                    row["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(result["IDOSNOVAOSIGURANJA"]);
                    row["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTAELEMENT"]);
                    row["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(result["NAZIVOSNOVAOSIGURANJA"]);
                    row["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(result["RAZDOBLJESESMIJEPREKLAPATI"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesIDRADNIK(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDRADNIK"] = RuntimeHelpers.GetObjectValue(result["IDRADNIK"]);
                    row["PREZIME"] = RuntimeHelpers.GetObjectValue(result["PREZIME"]);
                    row["IME"] = RuntimeHelpers.GetObjectValue(result["IME"]);
                    row["ulica"] = RuntimeHelpers.GetObjectValue(result["ulica"]);
                    row["mjesto"] = RuntimeHelpers.GetObjectValue(result["mjesto"]);
                    row["kucnibroj"] = RuntimeHelpers.GetObjectValue(result["kucnibroj"]);
                    row["JMBG"] = RuntimeHelpers.GetObjectValue(result["JMBG"]);
                    row["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(result["DATUMRODJENJA"]);
                    row["TEKUCI"] = RuntimeHelpers.GetObjectValue(result["TEKUCI"]);
                    row["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(result["SIFRAOPISAPLACANJANETO"]);
                    row["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(result["OPISPLACANJANETO"]);
                    row["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(result["BROJMIROVINSKOG"]);
                    row["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(result["BROJZDRAVSTVENOG"]);
                    row["MBO"] = RuntimeHelpers.GetObjectValue(result["MBO"]);
                    row["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(result["POSTOTAKOSLOBODJENJAODPOREZA"]);
                    row["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(result["KOEFICIJENT"]);
                    row["AKTIVAN"] = RuntimeHelpers.GetObjectValue(result["AKTIVAN"]);
                    row["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(result["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"]);
                    row["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(result["TJEDNIFONDSATI"]);
                    row["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(result["TJEDNIFONDSATISTAZ"]);
                    row["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(result["GODINESTAZA"]);
                    row["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(result["MJESECISTAZA"]);
                    row["DANISTAZA"] = RuntimeHelpers.GetObjectValue(result["DANISTAZA"]);
                    row["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(result["DATUMPRESTANKARADNOGODNOSA"]);
                    row["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(result["ZBIRNINETO"]);
                    row["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(result["UZIMAUOBZIROSNOVICEDOPRINOSA"]);
                    row["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(result["IDIPIDENT"]);
                    row["OIB"] = RuntimeHelpers.GetObjectValue(result["OIB"]);
                    row["IDBANKE"] = RuntimeHelpers.GetObjectValue(result["IDBANKE"]);
                    row["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(result["IDBENEFICIRANI"]);
                    row["IDTITULA"] = RuntimeHelpers.GetObjectValue(result["IDTITULA"]);
                    row["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(result["IDRADNOMJESTO"]);
                    row["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(result["IDSTRUKA"]);
                    row["IDORGDIO"] = RuntimeHelpers.GetObjectValue(result["IDORGDIO"]);
                    row["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(result["OPCINARADAIDOPCINE"]);
                    row["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(result["OPCINASTANOVANJAIDOPCINE"]);
                    row["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(result["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]);
                    row["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(result["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]);
                    row["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(result["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]);
                    row["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE1"]);
                    row["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE2"]);
                    row["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE3"]);
                    row["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(result["VBDIBANKE"]);
                    row["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(result["ZRNBANKE"]);
                    row["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(result["NAZIVBENEFICIRANI"]);
                    row["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(result["BROJPRIZNATIHMJESECI"]);
                    row["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(result["NAZIVTITULA"]);
                    row["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(result["NAZIVRADNOMJESTO"]);
                    row["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(result["NAZIVSTRUKA"]);
                    row["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(result["ORGANIZACIJSKIDIO"]);
                    row["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(result["OPCINARADANAZIVOPCINE"]);
                    row["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(result["OPCINASTANOVANJANAZIVOPCINE"]);
                    row["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(result["OPCINASTANOVANJAPRIREZ"]);
                    row["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(result["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"]);
                    row["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(result["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"]);
                    row["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(result["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        [LocalCommandHandler("ViewRSMA")]
        public void ViewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.ViewRSMA(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkOBRFIKSNIH
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkOBRFIKSNIH;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkOBRFIKSNIH = value;
            }
        }

        protected virtual UltraCheckEditor checkOBRKREDITNIH
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkOBRKREDITNIH;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkOBRKREDITNIH = value;
            }
        }

        protected virtual UltraCheckEditor checkOBRPOSTOTNIH
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkOBRPOSTOTNIH;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkOBRPOSTOTNIH = value;
            }
        }

        protected virtual UltraCheckEditor checkZAKLJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkZAKLJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkZAKLJ = value;
            }
        }

        private ContextMenu contextMenu1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._contextMenu1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._contextMenu1 = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMISPLATE = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMOBRACUNASTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMOBRACUNASTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMOBRACUNASTAZA = value;
            }
        }

        private ErrorProvider errorProvider1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProvider1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProvider1 = value;
            }
        }

        private ErrorProviderValidator errorProviderValidator1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProviderValidator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProviderValidator1 = value;
            }
        }

        protected virtual UltraGrid grdLevelObracunRadnici
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelObracunRadnici;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelObracunRadnici = value;
            }
        }

        protected virtual UltraLabel label1DATUMISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMISPLATE = value;
            }
        }

        protected virtual UltraLabel label1DATUMOBRACUNASTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMOBRACUNASTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMOBRACUNASTAZA = value;
            }
        }

        protected virtual UltraLabel label1GODINAISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINAISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINAISPLATE = value;
            }
        }

        protected virtual UltraLabel label1GODINAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINAOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1IDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOBRACUN = value;
            }
        }

        protected virtual UltraLabel label1MJESECISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESECISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESECISPLATE = value;
            }
        }

        protected virtual UltraLabel label1MJESECNIFONDSATIOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESECNIFONDSATIOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESECNIFONDSATIOBRACUN = value;
            }
        }

        protected virtual UltraLabel label1MJESECOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESECOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESECOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1OBRACUNSKAOSNOVICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRACUNSKAOSNOVICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRACUNSKAOSNOVICA = value;
            }
        }

        protected virtual UltraLabel label1OBRFIKSNIH
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRFIKSNIH;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRFIKSNIH = value;
            }
        }

        protected virtual UltraLabel label1OBRKREDITNIH
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRKREDITNIH;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRKREDITNIH = value;
            }
        }

        protected virtual UltraLabel label1OBRPOSTOTNIH
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRPOSTOTNIH;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRPOSTOTNIH = value;
            }
        }

        protected virtual UltraLabel label1OSNOVNIOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSNOVNIOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSNOVNIOO = value;
            }
        }

        protected virtual UltraLabel label1SVRHAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SVRHAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SVRHAOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1tjednifondsatiobracun
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1tjednifondsatiobracun;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1tjednifondsatiobracun = value;
            }
        }

        protected virtual UltraLabel label1VRSTAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRSTAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRSTAOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1ZAKLJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZAKLJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZAKLJ = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunRadnici
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunRadnici;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunRadnici = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunRadniciAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunRadniciAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunRadniciAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunRadniciDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunRadniciDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunRadniciDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunRadniciUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunRadniciUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunRadniciUpdate = value;
            }
        }

        public DeklaritMode Mode
        {
            get
            {
                return this.m_Mode;
            }
            set
            {
                this.m_Mode = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.OBRACUNController OBRACUNController { get; set; }

        protected virtual Panel panelactionsObracunRadnici
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsObracunRadnici;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsObracunRadnici = value;
            }
        }

        private MenuItem SetNullItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SetNullItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SetNullItem = value;
            }
        }

        protected virtual UltraTextEditor textGODINAISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINAISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINAISPLATE = value;
            }
        }

        protected virtual UltraTextEditor textGODINAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINAOBRACUNA = value;
            }
        }

        protected virtual UltraTextEditor textIDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOBRACUN = value;
            }
        }

        protected virtual UltraTextEditor textMJESECISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESECISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESECISPLATE = value;
            }
        }

        protected virtual UltraNumericEditor textMJESECNIFONDSATIOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESECNIFONDSATIOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESECNIFONDSATIOBRACUN = value;
            }
        }

        protected virtual UltraTextEditor textMJESECOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESECOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESECOBRACUNA = value;
            }
        }

        protected virtual UltraNumericEditor textOBRACUNSKAOSNOVICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRACUNSKAOSNOVICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRACUNSKAOSNOVICA = value;
            }
        }

        protected virtual UltraNumericEditor textOSNOVNIOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSNOVNIOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSNOVNIOO = value;
            }
        }

        protected virtual UltraTextEditor textSVRHAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSVRHAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSVRHAOBRACUNA = value;
            }
        }

        protected virtual UltraNumericEditor texttjednifondsatiobracun
        {
            [DebuggerNonUserCode]
            get
            {
                return this._texttjednifondsatiobracun;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._texttjednifondsatiobracun = value;
            }
        }

        protected virtual UltraTextEditor textVRSTAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRSTAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRSTAOBRACUNA = value;
            }
        }

        private System.Windows.Forms.ToolTip toolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._toolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._toolTip1 = value;
            }
        }
    }
}

