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
    public class OBRACUNFormObracunRadniciUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDRADNIK")]
        private PregledRadnikaComboBox _comboIDRADNIK;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelObracunDoprinosi")]
        private UltraGrid _grdLevelObracunDoprinosi;
        [AccessedThroughProperty("grdLevelObracunElementi")]
        private UltraGrid _grdLevelObracunElementi;
        [AccessedThroughProperty("grdLevelOBRACUNKrediti")]
        private UltraGrid _grdLevelOBRACUNKrediti;
        [AccessedThroughProperty("grdLevelOBRACUNObustave")]
        private UltraGrid _grdLevelOBRACUNObustave;
        [AccessedThroughProperty("grdLevelObracunOlaksice")]
        private UltraGrid _grdLevelObracunOlaksice;
        [AccessedThroughProperty("grdLevelObracunPorezi")]
        private UltraGrid _grdLevelObracunPorezi;
        [AccessedThroughProperty("label1faktoo")]
        private UltraLabel _label1faktoo;
        [AccessedThroughProperty("label1IDRADNIK")]
        private UltraLabel _label1IDRADNIK;
        [AccessedThroughProperty("label1IME")]
        private UltraLabel _label1IME;
        [AccessedThroughProperty("label1ISKORISTENOOO")]
        private UltraLabel _label1ISKORISTENOOO;
        [AccessedThroughProperty("label1JMBG")]
        private UltraLabel _label1JMBG;
        [AccessedThroughProperty("label1KOEFICIJENT")]
        private UltraLabel _label1KOEFICIJENT;
        [AccessedThroughProperty("label1OBRACUNATIPRIREZ")]
        private UltraLabel _label1OBRACUNATIPRIREZ;
        [AccessedThroughProperty("label1OBRACUNSKIKOEFICIJENT")]
        private UltraLabel _label1OBRACUNSKIKOEFICIJENT;
        [AccessedThroughProperty("label1PREZIME")]
        private UltraLabel _label1PREZIME;
        [AccessedThroughProperty("label1SIFRAOPCINESTANOVANJA")]
        private UltraLabel _label1SIFRAOPCINESTANOVANJA;
        [AccessedThroughProperty("labelIME")]
        private UltraLabel _labelIME;
        [AccessedThroughProperty("labelJMBG")]
        private UltraLabel _labelJMBG;
        [AccessedThroughProperty("labelKOEFICIJENT")]
        private UltraLabel _labelKOEFICIJENT;
        [AccessedThroughProperty("labelPREZIME")]
        private UltraLabel _labelPREZIME;
        [AccessedThroughProperty("linkLabelObracunDoprinosi")]
        private UltraLabel _linkLabelObracunDoprinosi;
        [AccessedThroughProperty("linkLabelObracunDoprinosiAdd")]
        private UltraLabel _linkLabelObracunDoprinosiAdd;
        [AccessedThroughProperty("linkLabelObracunDoprinosiDelete")]
        private UltraLabel _linkLabelObracunDoprinosiDelete;
        [AccessedThroughProperty("linkLabelObracunDoprinosiUpdate")]
        private UltraLabel _linkLabelObracunDoprinosiUpdate;
        [AccessedThroughProperty("linkLabelObracunElementi")]
        private UltraLabel _linkLabelObracunElementi;
        [AccessedThroughProperty("linkLabelObracunElementiAdd")]
        private UltraLabel _linkLabelObracunElementiAdd;
        [AccessedThroughProperty("linkLabelObracunElementiDelete")]
        private UltraLabel _linkLabelObracunElementiDelete;
        [AccessedThroughProperty("linkLabelObracunElementiUpdate")]
        private UltraLabel _linkLabelObracunElementiUpdate;
        [AccessedThroughProperty("linkLabelOBRACUNKrediti")]
        private UltraLabel _linkLabelOBRACUNKrediti;
        [AccessedThroughProperty("linkLabelOBRACUNKreditiAdd")]
        private UltraLabel _linkLabelOBRACUNKreditiAdd;
        [AccessedThroughProperty("linkLabelOBRACUNKreditiDelete")]
        private UltraLabel _linkLabelOBRACUNKreditiDelete;
        [AccessedThroughProperty("linkLabelOBRACUNKreditiUpdate")]
        private UltraLabel _linkLabelOBRACUNKreditiUpdate;
        [AccessedThroughProperty("linkLabelOBRACUNObustave")]
        private UltraLabel _linkLabelOBRACUNObustave;
        [AccessedThroughProperty("linkLabelOBRACUNObustaveAdd")]
        private UltraLabel _linkLabelOBRACUNObustaveAdd;
        [AccessedThroughProperty("linkLabelOBRACUNObustaveDelete")]
        private UltraLabel _linkLabelOBRACUNObustaveDelete;
        [AccessedThroughProperty("linkLabelOBRACUNObustaveUpdate")]
        private UltraLabel _linkLabelOBRACUNObustaveUpdate;
        [AccessedThroughProperty("linkLabelObracunOlaksice")]
        private UltraLabel _linkLabelObracunOlaksice;
        [AccessedThroughProperty("linkLabelObracunOlaksiceAdd")]
        private UltraLabel _linkLabelObracunOlaksiceAdd;
        [AccessedThroughProperty("linkLabelObracunOlaksiceDelete")]
        private UltraLabel _linkLabelObracunOlaksiceDelete;
        [AccessedThroughProperty("linkLabelObracunOlaksiceUpdate")]
        private UltraLabel _linkLabelObracunOlaksiceUpdate;
        [AccessedThroughProperty("linkLabelObracunPorezi")]
        private UltraLabel _linkLabelObracunPorezi;
        [AccessedThroughProperty("linkLabelObracunPoreziAdd")]
        private UltraLabel _linkLabelObracunPoreziAdd;
        [AccessedThroughProperty("linkLabelObracunPoreziDelete")]
        private UltraLabel _linkLabelObracunPoreziDelete;
        [AccessedThroughProperty("linkLabelObracunPoreziUpdate")]
        private UltraLabel _linkLabelObracunPoreziUpdate;
        [AccessedThroughProperty("panelactionsObracunDoprinosi")]
        private Panel _panelactionsObracunDoprinosi;
        [AccessedThroughProperty("panelactionsObracunElementi")]
        private Panel _panelactionsObracunElementi;
        [AccessedThroughProperty("panelactionsOBRACUNKrediti")]
        private Panel _panelactionsOBRACUNKrediti;
        [AccessedThroughProperty("panelactionsOBRACUNObustave")]
        private Panel _panelactionsOBRACUNObustave;
        [AccessedThroughProperty("panelactionsObracunOlaksice")]
        private Panel _panelactionsObracunOlaksice;
        [AccessedThroughProperty("panelactionsObracunPorezi")]
        private Panel _panelactionsObracunPorezi;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textfaktoo")]
        private UltraNumericEditor _textfaktoo;
        [AccessedThroughProperty("textISKORISTENOOO")]
        private UltraNumericEditor _textISKORISTENOOO;
        [AccessedThroughProperty("textOBRACUNATIPRIREZ")]
        private UltraNumericEditor _textOBRACUNATIPRIREZ;
        [AccessedThroughProperty("textOBRACUNSKIKOEFICIJENT")]
        private UltraNumericEditor _textOBRACUNSKIKOEFICIJENT;
        [AccessedThroughProperty("textSIFRAOPCINESTANOVANJA")]
        private UltraTextEditor _textSIFRAOPCINESTANOVANJA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceObracunDoprinosi;
        private BindingSource bindingSourceObracunElementi;
        private BindingSource bindingSourceOBRACUNKrediti;
        private BindingSource bindingSourceOBRACUNOBRACUNLevel1ObracunIzuzece;
        private BindingSource bindingSourceOBRACUNOBRACUNLevel1ObracunKrizni;
        private BindingSource bindingSourceOBRACUNObustave;
        private BindingSource bindingSourceObracunOlaksice;
        private BindingSource bindingSourceObracunPorezi;
        private BindingSource bindingSourceObracunRadnici;
        private IContainer components = null;
        private OBRACUNDataSet dsOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformObracunRadnici;
        protected TableLayoutPanel layoutManagerpanelactionsObracunDoprinosi;
        protected TableLayoutPanel layoutManagerpanelactionsObracunElementi;
        protected TableLayoutPanel layoutManagerpanelactionsOBRACUNKrediti;
        protected TableLayoutPanel layoutManagerpanelactionsOBRACUNObustave;
        protected TableLayoutPanel layoutManagerpanelactionsObracunOlaksice;
        protected TableLayoutPanel layoutManagerpanelactionsObracunPorezi;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OBRACUNDataSet.ObracunRadniciRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ObracunRadnici";
        private string m_FrameworkDescription = StringResources.OBRACUNDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OBRACUNFormObracunRadniciUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("ObracunRadniciAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("ObracunRadniciAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (OBRACUNDataSet.ObracunRadniciRow) ((DataRowView) this.bindingSourceObracunRadnici.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
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
            this.bindingSourceObracunRadnici.DataSource = this.OBRACUNController.DataSet;
            this.dsOBRACUNDataSet1 = this.OBRACUNController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
        public void comboIDRADNIK_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDRADNIK.Fill();
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

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if (column.CellActivation == Activation.AllowEdit)
            {
                switch (Conversions.ToString(column.Tag))
                {
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
            if (this.grdLevelObracunDoprinosi.ActiveRow != null)
            {
                this.grdLevelObracunDoprinosi.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelObracunPorezi.ActiveRow != null)
            {
                this.grdLevelObracunPorezi.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelObracunOlaksice.ActiveRow != null)
            {
                this.grdLevelObracunOlaksice.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelOBRACUNKrediti.ActiveRow != null)
            {
                this.grdLevelOBRACUNKrediti.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelOBRACUNObustave.ActiveRow != null)
            {
                this.grdLevelOBRACUNObustave.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelObracunElementi.ActiveRow != null)
            {
                this.grdLevelObracunElementi.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "IDELEMENT")
                {
                    this.UpdateValuesIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelObracunDoprinosi_AfterRowActivate(object sender, EventArgs e)
        {
            string oBRACUNObracunDoprinosiLevelDescription = StringResources.OBRACUNObracunDoprinosiLevelDescription;
            UltraGridRow activeRow = this.grdLevelObracunDoprinosi.ActiveRow;
            this.linkLabelObracunDoprinosiAdd.Text = Deklarit.Resources.Resources.Add + " " + oBRACUNObracunDoprinosiLevelDescription;
            this.linkLabelObracunDoprinosiUpdate.Text = Deklarit.Resources.Resources.Update + " " + oBRACUNObracunDoprinosiLevelDescription;
            this.linkLabelObracunDoprinosiDelete.Text = Deklarit.Resources.Resources.Delete + " " + oBRACUNObracunDoprinosiLevelDescription;
        }

        private void grdLevelObracunDoprinosi_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceObracunRadnici.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceObracunRadnici.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelObracunDoprinosi_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.ObracunDoprinosiUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelObracunDoprinosi_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this);
        }

        private void grdLevelObracunElementi_AfterRowActivate(object sender, EventArgs e)
        {
            string oBRACUNObracunElementiLevelDescription = StringResources.OBRACUNObracunElementiLevelDescription;
            UltraGridRow activeRow = this.grdLevelObracunElementi.ActiveRow;
            this.linkLabelObracunElementiAdd.Text = Deklarit.Resources.Resources.Add + " " + oBRACUNObracunElementiLevelDescription;
            this.linkLabelObracunElementiUpdate.Text = Deklarit.Resources.Resources.Update + " " + oBRACUNObracunElementiLevelDescription;
            this.linkLabelObracunElementiDelete.Text = Deklarit.Resources.Resources.Delete + " " + oBRACUNObracunElementiLevelDescription;
        }

        private void grdLevelObracunElementi_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceObracunRadnici.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceObracunRadnici.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelObracunElementi_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.ObracunElementiUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelObracunElementi_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this);
        }

        private void grdLevelOBRACUNKrediti_AfterRowActivate(object sender, EventArgs e)
        {
            string oBRACUNOBRACUNKreditiLevelDescription = StringResources.OBRACUNOBRACUNKreditiLevelDescription;
            UltraGridRow activeRow = this.grdLevelOBRACUNKrediti.ActiveRow;
            this.linkLabelOBRACUNKreditiAdd.Text = Deklarit.Resources.Resources.Add + " " + oBRACUNOBRACUNKreditiLevelDescription;
            this.linkLabelOBRACUNKreditiUpdate.Text = Deklarit.Resources.Resources.Update + " " + oBRACUNOBRACUNKreditiLevelDescription;
            this.linkLabelOBRACUNKreditiDelete.Text = Deklarit.Resources.Resources.Delete + " " + oBRACUNOBRACUNKreditiLevelDescription;
        }

        private void grdLevelOBRACUNKrediti_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceObracunRadnici.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceObracunRadnici.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelOBRACUNKrediti_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.OBRACUNKreditiUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelOBRACUNKrediti_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this);
        }

        private void grdLevelOBRACUNObustave_AfterRowActivate(object sender, EventArgs e)
        {
            string oBRACUNOBRACUNObustaveLevelDescription = StringResources.OBRACUNOBRACUNObustaveLevelDescription;
            UltraGridRow activeRow = this.grdLevelOBRACUNObustave.ActiveRow;
            this.linkLabelOBRACUNObustaveAdd.Text = Deklarit.Resources.Resources.Add + " " + oBRACUNOBRACUNObustaveLevelDescription;
            this.linkLabelOBRACUNObustaveUpdate.Text = Deklarit.Resources.Resources.Update + " " + oBRACUNOBRACUNObustaveLevelDescription;
            this.linkLabelOBRACUNObustaveDelete.Text = Deklarit.Resources.Resources.Delete + " " + oBRACUNOBRACUNObustaveLevelDescription;
        }

        private void grdLevelOBRACUNObustave_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceObracunRadnici.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceObracunRadnici.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelOBRACUNObustave_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.OBRACUNObustaveUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelOBRACUNObustave_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this);
        }

        private void grdLevelObracunOlaksice_AfterRowActivate(object sender, EventArgs e)
        {
            string oBRACUNObracunOlaksiceLevelDescription = StringResources.OBRACUNObracunOlaksiceLevelDescription;
            UltraGridRow activeRow = this.grdLevelObracunOlaksice.ActiveRow;
            this.linkLabelObracunOlaksiceAdd.Text = Deklarit.Resources.Resources.Add + " " + oBRACUNObracunOlaksiceLevelDescription;
            this.linkLabelObracunOlaksiceUpdate.Text = Deklarit.Resources.Resources.Update + " " + oBRACUNObracunOlaksiceLevelDescription;
            this.linkLabelObracunOlaksiceDelete.Text = Deklarit.Resources.Resources.Delete + " " + oBRACUNObracunOlaksiceLevelDescription;
        }

        private void grdLevelObracunOlaksice_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceObracunRadnici.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceObracunRadnici.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelObracunOlaksice_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.ObracunOlaksiceUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelObracunOlaksice_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this);
        }

        private void grdLevelObracunPorezi_AfterRowActivate(object sender, EventArgs e)
        {
            string oBRACUNObracunPoreziLevelDescription = StringResources.OBRACUNObracunPoreziLevelDescription;
            UltraGridRow activeRow = this.grdLevelObracunPorezi.ActiveRow;
            this.linkLabelObracunPoreziAdd.Text = Deklarit.Resources.Resources.Add + " " + oBRACUNObracunPoreziLevelDescription;
            this.linkLabelObracunPoreziUpdate.Text = Deklarit.Resources.Resources.Update + " " + oBRACUNObracunPoreziLevelDescription;
            this.linkLabelObracunPoreziDelete.Text = Deklarit.Resources.Resources.Delete + " " + oBRACUNObracunPoreziLevelDescription;
        }

        private void grdLevelObracunPorezi_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceObracunRadnici.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceObracunRadnici.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelObracunPorezi_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.ObracunPoreziUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelObracunPorezi_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsOBRACUNDataSet1 = (OBRACUNDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceObracunRadnici.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsOBRACUNDataSet1.Tables["ObracunRadnici"]);
            this.bindingSourceObracunRadnici.DataMember = "";
            this.bindingSourceObracunDoprinosi.DataMember = "ObracunRadnici_ObracunDoprinosi";
            this.bindingSourceObracunPorezi.DataMember = "ObracunRadnici_ObracunPorezi";
            this.bindingSourceObracunOlaksice.DataMember = "ObracunRadnici_ObracunOlaksice";
            this.bindingSourceOBRACUNKrediti.DataMember = "ObracunRadnici_OBRACUNKrediti";
            this.bindingSourceOBRACUNObustave.DataMember = "ObracunRadnici_OBRACUNObustave";
            this.bindingSourceObracunElementi.DataMember = "ObracunRadnici_ObracunElementi";
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunKrizni.DataMember = "ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni";
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunIzuzece.DataMember = "ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OBRACUN", this.m_Mode, this.dsOBRACUNDataSet1, this.dsOBRACUNDataSet1.ObracunRadnici.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceObracunRadnici, "KOEFICIJENT", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelKOEFICIJENT.DataBindings["Text"] != null)
            {
                this.labelKOEFICIJENT.DataBindings.Remove(this.labelKOEFICIJENT.DataBindings["Text"]);
            }
            this.labelKOEFICIJENT.DataBindings.Add(binding);
            if (!this.m_DataGrids.Contains(this.grdLevelObracunDoprinosi))
            {
                this.m_DataGrids.Add(this.grdLevelObracunDoprinosi);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelObracunPorezi))
            {
                this.m_DataGrids.Add(this.grdLevelObracunPorezi);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelObracunOlaksice))
            {
                this.m_DataGrids.Add(this.grdLevelObracunOlaksice);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelOBRACUNKrediti))
            {
                this.m_DataGrids.Add(this.grdLevelOBRACUNKrediti);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelOBRACUNObustave))
            {
                this.m_DataGrids.Add(this.grdLevelOBRACUNObustave);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelObracunElementi))
            {
                this.m_DataGrids.Add(this.grdLevelObracunElementi);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (OBRACUNDataSet.ObracunRadniciRow) ((DataRowView) this.bindingSourceObracunRadnici.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OBRACUNDataSet.ObracunRadniciRow) ((DataRowView) this.bindingSourceObracunRadnici.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OBRACUNFormObracunRadniciUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceObracunRadnici = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunRadnici).BeginInit();
            this.bindingSourceObracunDoprinosi = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunDoprinosi).BeginInit();
            this.bindingSourceObracunPorezi = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunPorezi).BeginInit();
            this.bindingSourceObracunOlaksice = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunOlaksice).BeginInit();
            this.bindingSourceOBRACUNKrediti = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBRACUNKrediti).BeginInit();
            this.bindingSourceOBRACUNObustave = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBRACUNObustave).BeginInit();
            this.bindingSourceObracunElementi = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunElementi).BeginInit();
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunKrizni = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBRACUNOBRACUNLevel1ObracunKrizni).BeginInit();
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunIzuzece = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBRACUNOBRACUNLevel1ObracunIzuzece).BeginInit();
            this.layoutManagerformObracunRadnici = new TableLayoutPanel();
            this.layoutManagerformObracunRadnici.SuspendLayout();
            this.layoutManagerformObracunRadnici.AutoSize = true;
            this.layoutManagerformObracunRadnici.Dock = DockStyle.Fill;
            this.layoutManagerformObracunRadnici.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformObracunRadnici.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformObracunRadnici.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformObracunRadnici.Size = size;
            this.layoutManagerformObracunRadnici.ColumnCount = 2;
            this.layoutManagerformObracunRadnici.RowCount = 0x16;
            this.layoutManagerformObracunRadnici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformObracunRadnici.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunRadnici.RowStyles.Add(new RowStyle());
            this.label1IDRADNIK = new UltraLabel();
            this.comboIDRADNIK = new PregledRadnikaComboBox();
            this.label1PREZIME = new UltraLabel();
            this.labelPREZIME = new UltraLabel();
            this.label1IME = new UltraLabel();
            this.labelIME = new UltraLabel();
            this.label1JMBG = new UltraLabel();
            this.labelJMBG = new UltraLabel();
            this.label1SIFRAOPCINESTANOVANJA = new UltraLabel();
            this.textSIFRAOPCINESTANOVANJA = new UltraTextEditor();
            this.label1KOEFICIJENT = new UltraLabel();
            this.labelKOEFICIJENT = new UltraLabel();
            this.label1OBRACUNSKIKOEFICIJENT = new UltraLabel();
            this.textOBRACUNSKIKOEFICIJENT = new UltraNumericEditor();
            this.label1OBRACUNATIPRIREZ = new UltraLabel();
            this.textOBRACUNATIPRIREZ = new UltraNumericEditor();
            this.label1ISKORISTENOOO = new UltraLabel();
            this.textISKORISTENOOO = new UltraNumericEditor();
            this.label1faktoo = new UltraLabel();
            this.textfaktoo = new UltraNumericEditor();
            this.grdLevelObracunDoprinosi = new UltraGrid();
            this.panelactionsObracunDoprinosi = new Panel();
            this.layoutManagerpanelactionsObracunDoprinosi = new TableLayoutPanel();
            this.layoutManagerpanelactionsObracunDoprinosi.AutoSize = true;
            this.layoutManagerpanelactionsObracunDoprinosi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsObracunDoprinosi.ColumnCount = 4;
            this.layoutManagerpanelactionsObracunDoprinosi.RowCount = 1;
            this.layoutManagerpanelactionsObracunDoprinosi.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsObracunDoprinosi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunDoprinosi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunDoprinosi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunDoprinosi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunDoprinosi.RowStyles.Add(new RowStyle());
            this.linkLabelObracunDoprinosiAdd = new UltraLabel();
            this.linkLabelObracunDoprinosiUpdate = new UltraLabel();
            this.linkLabelObracunDoprinosiDelete = new UltraLabel();
            this.linkLabelObracunDoprinosi = new UltraLabel();
            this.grdLevelObracunPorezi = new UltraGrid();
            this.panelactionsObracunPorezi = new Panel();
            this.layoutManagerpanelactionsObracunPorezi = new TableLayoutPanel();
            this.layoutManagerpanelactionsObracunPorezi.AutoSize = true;
            this.layoutManagerpanelactionsObracunPorezi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsObracunPorezi.ColumnCount = 4;
            this.layoutManagerpanelactionsObracunPorezi.RowCount = 1;
            this.layoutManagerpanelactionsObracunPorezi.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsObracunPorezi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunPorezi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunPorezi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunPorezi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunPorezi.RowStyles.Add(new RowStyle());
            this.linkLabelObracunPoreziAdd = new UltraLabel();
            this.linkLabelObracunPoreziUpdate = new UltraLabel();
            this.linkLabelObracunPoreziDelete = new UltraLabel();
            this.linkLabelObracunPorezi = new UltraLabel();
            this.grdLevelObracunOlaksice = new UltraGrid();
            this.panelactionsObracunOlaksice = new Panel();
            this.layoutManagerpanelactionsObracunOlaksice = new TableLayoutPanel();
            this.layoutManagerpanelactionsObracunOlaksice.AutoSize = true;
            this.layoutManagerpanelactionsObracunOlaksice.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsObracunOlaksice.ColumnCount = 4;
            this.layoutManagerpanelactionsObracunOlaksice.RowCount = 1;
            this.layoutManagerpanelactionsObracunOlaksice.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsObracunOlaksice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunOlaksice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunOlaksice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunOlaksice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunOlaksice.RowStyles.Add(new RowStyle());
            this.linkLabelObracunOlaksiceAdd = new UltraLabel();
            this.linkLabelObracunOlaksiceUpdate = new UltraLabel();
            this.linkLabelObracunOlaksiceDelete = new UltraLabel();
            this.linkLabelObracunOlaksice = new UltraLabel();
            this.grdLevelOBRACUNKrediti = new UltraGrid();
            this.panelactionsOBRACUNKrediti = new Panel();
            this.layoutManagerpanelactionsOBRACUNKrediti = new TableLayoutPanel();
            this.layoutManagerpanelactionsOBRACUNKrediti.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNKrediti.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsOBRACUNKrediti.ColumnCount = 4;
            this.layoutManagerpanelactionsOBRACUNKrediti.RowCount = 1;
            this.layoutManagerpanelactionsOBRACUNKrediti.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.linkLabelOBRACUNKreditiAdd = new UltraLabel();
            this.linkLabelOBRACUNKreditiUpdate = new UltraLabel();
            this.linkLabelOBRACUNKreditiDelete = new UltraLabel();
            this.linkLabelOBRACUNKrediti = new UltraLabel();
            this.grdLevelOBRACUNObustave = new UltraGrid();
            this.panelactionsOBRACUNObustave = new Panel();
            this.layoutManagerpanelactionsOBRACUNObustave = new TableLayoutPanel();
            this.layoutManagerpanelactionsOBRACUNObustave.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNObustave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsOBRACUNObustave.ColumnCount = 4;
            this.layoutManagerpanelactionsOBRACUNObustave.RowCount = 1;
            this.layoutManagerpanelactionsOBRACUNObustave.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsOBRACUNObustave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNObustave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNObustave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNObustave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.linkLabelOBRACUNObustaveAdd = new UltraLabel();
            this.linkLabelOBRACUNObustaveUpdate = new UltraLabel();
            this.linkLabelOBRACUNObustaveDelete = new UltraLabel();
            this.linkLabelOBRACUNObustave = new UltraLabel();
            this.grdLevelObracunElementi = new UltraGrid();
            this.panelactionsObracunElementi = new Panel();
            this.layoutManagerpanelactionsObracunElementi = new TableLayoutPanel();
            this.layoutManagerpanelactionsObracunElementi.AutoSize = true;
            this.layoutManagerpanelactionsObracunElementi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsObracunElementi.ColumnCount = 4;
            this.layoutManagerpanelactionsObracunElementi.RowCount = 1;
            this.layoutManagerpanelactionsObracunElementi.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsObracunElementi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunElementi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunElementi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunElementi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsObracunElementi.RowStyles.Add(new RowStyle());
            this.linkLabelObracunElementiAdd = new UltraLabel();
            this.linkLabelObracunElementiUpdate = new UltraLabel();
            this.linkLabelObracunElementiDelete = new UltraLabel();
            this.linkLabelObracunElementi = new UltraLabel();
            ((ISupportInitialize) this.textSIFRAOPCINESTANOVANJA).BeginInit();
            ((ISupportInitialize) this.textOBRACUNSKIKOEFICIJENT).BeginInit();
            ((ISupportInitialize) this.textOBRACUNATIPRIREZ).BeginInit();
            ((ISupportInitialize) this.textISKORISTENOOO).BeginInit();
            ((ISupportInitialize) this.textfaktoo).BeginInit();
            ((ISupportInitialize) this.grdLevelObracunDoprinosi).BeginInit();
            this.panelactionsObracunDoprinosi.SuspendLayout();
            this.layoutManagerpanelactionsObracunDoprinosi.SuspendLayout();
            ((ISupportInitialize) this.grdLevelObracunPorezi).BeginInit();
            this.panelactionsObracunPorezi.SuspendLayout();
            this.layoutManagerpanelactionsObracunPorezi.SuspendLayout();
            ((ISupportInitialize) this.grdLevelObracunOlaksice).BeginInit();
            this.panelactionsObracunOlaksice.SuspendLayout();
            this.layoutManagerpanelactionsObracunOlaksice.SuspendLayout();
            ((ISupportInitialize) this.grdLevelOBRACUNKrediti).BeginInit();
            this.panelactionsOBRACUNKrediti.SuspendLayout();
            this.layoutManagerpanelactionsOBRACUNKrediti.SuspendLayout();
            ((ISupportInitialize) this.grdLevelOBRACUNObustave).BeginInit();
            this.panelactionsOBRACUNObustave.SuspendLayout();
            this.layoutManagerpanelactionsOBRACUNObustave.SuspendLayout();
            ((ISupportInitialize) this.grdLevelObracunElementi).BeginInit();
            this.panelactionsObracunElementi.SuspendLayout();
            this.layoutManagerpanelactionsObracunElementi.SuspendLayout();
            UltraGridBand band = new UltraGridBand("ObracunDoprinosi", -1);
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
            UltraGridBand band8 = new UltraGridBand("ObracunPorezi", -1);
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
            UltraGridBand band7 = new UltraGridBand("ObracunOlaksice", -1);
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
            UltraGridBand band3 = new UltraGridBand("OBRACUNKrediti", -1);
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
            UltraGridBand band6 = new UltraGridBand("OBRACUNObustave", -1);
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
            UltraGridBand band2 = new UltraGridBand("ObracunElementi", -1);
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
            UltraGridBand band5 = new UltraGridBand("OBRACUNOBRACUNLevel1ObracunKrizni", -1);
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
            UltraGridBand band4 = new UltraGridBand("OBRACUNOBRACUNLevel1ObracunIzuzece", -1);
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
            this.bindingSourceObracunRadnici.DataSource = this.dsOBRACUNDataSet1;
            this.bindingSourceObracunRadnici.DataMember = "ObracunRadnici";
            ((ISupportInitialize) this.bindingSourceObracunRadnici).BeginInit();
            this.bindingSourceObracunDoprinosi.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceObracunDoprinosi.DataMember = "ObracunRadnici_ObracunDoprinosi";
            this.bindingSourceObracunPorezi.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceObracunPorezi.DataMember = "ObracunRadnici_ObracunPorezi";
            this.bindingSourceObracunOlaksice.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceObracunOlaksice.DataMember = "ObracunRadnici_ObracunOlaksice";
            this.bindingSourceOBRACUNKrediti.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceOBRACUNKrediti.DataMember = "ObracunRadnici_OBRACUNKrediti";
            this.bindingSourceOBRACUNObustave.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceOBRACUNObustave.DataMember = "ObracunRadnici_OBRACUNObustave";
            this.bindingSourceObracunElementi.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceObracunElementi.DataMember = "ObracunRadnici_ObracunElementi";
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunKrizni.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunKrizni.DataMember = "ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni";
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunIzuzece.DataSource = this.bindingSourceObracunRadnici;
            this.bindingSourceOBRACUNOBRACUNLevel1ObracunIzuzece.DataMember = "ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece";
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNIK.Location = point;
            this.label1IDRADNIK.Name = "label1IDRADNIK";
            this.label1IDRADNIK.TabIndex = 1;
            this.label1IDRADNIK.Tag = "labelIDRADNIK";
            this.label1IDRADNIK.Text = "Šifra radnika:";
            this.label1IDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNIK.AutoSize = true;
            this.label1IDRADNIK.Anchor = AnchorStyles.Left;
            this.label1IDRADNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNIK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRADNIK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRADNIK.ImageSize = size;
            this.label1IDRADNIK.Appearance.ForeColor = Color.Black;
            this.label1IDRADNIK.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1IDRADNIK, 0, 0);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1IDRADNIK, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1IDRADNIK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1IDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDRADNIK.Location = point;
            this.comboIDRADNIK.Name = "comboIDRADNIK";
            this.comboIDRADNIK.Tag = "IDRADNIK";
            this.comboIDRADNIK.TabIndex = 0;
            this.comboIDRADNIK.Anchor = AnchorStyles.Left;
            this.comboIDRADNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDRADNIK.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNIK.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNIK.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDRADNIK.Enabled = true;
            this.comboIDRADNIK.DataBindings.Add(new Binding("Value", this.bindingSourceObracunRadnici, "IDRADNIK"));
            this.comboIDRADNIK.ShowPictureBox = true;
            this.comboIDRADNIK.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDRADNIK);
            this.comboIDRADNIK.ValueMember = "IDRADNIK";
            this.comboIDRADNIK.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDRADNIK);
            this.layoutManagerformObracunRadnici.Controls.Add(this.comboIDRADNIK, 1, 0);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.comboIDRADNIK, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.comboIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PREZIME.Location = point;
            this.label1PREZIME.Name = "label1PREZIME";
            this.label1PREZIME.TabIndex = 1;
            this.label1PREZIME.Tag = "labelPREZIME";
            this.label1PREZIME.Text = "Prezime:";
            this.label1PREZIME.StyleSetName = "FieldUltraLabel";
            this.label1PREZIME.AutoSize = true;
            this.label1PREZIME.Anchor = AnchorStyles.Left;
            this.label1PREZIME.Appearance.TextVAlign = VAlign.Middle;
            this.label1PREZIME.Appearance.ForeColor = Color.Black;
            this.label1PREZIME.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1PREZIME, 0, 1);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1PREZIME, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1PREZIME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PREZIME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x45, 0x17);
            this.label1PREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPREZIME.Location = point;
            this.labelPREZIME.Name = "labelPREZIME";
            this.labelPREZIME.Tag = "PREZIME";
            this.labelPREZIME.TabIndex = 0;
            this.labelPREZIME.Anchor = AnchorStyles.Left;
            this.labelPREZIME.BackColor = Color.Transparent;
            this.labelPREZIME.DataBindings.Add(new Binding("Text", this.bindingSourceObracunRadnici, "PREZIME"));
            this.labelPREZIME.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunRadnici.Controls.Add(this.labelPREZIME, 1, 1);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.labelPREZIME, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.labelPREZIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPREZIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelPREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelPREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IME.Location = point;
            this.label1IME.Name = "label1IME";
            this.label1IME.TabIndex = 1;
            this.label1IME.Tag = "labelIME";
            this.label1IME.Text = "Ime:";
            this.label1IME.StyleSetName = "FieldUltraLabel";
            this.label1IME.AutoSize = true;
            this.label1IME.Anchor = AnchorStyles.Left;
            this.label1IME.Appearance.TextVAlign = VAlign.Middle;
            this.label1IME.Appearance.ForeColor = Color.Black;
            this.label1IME.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1IME, 0, 2);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1IME, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1IME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IME.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x17);
            this.label1IME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIME.Location = point;
            this.labelIME.Name = "labelIME";
            this.labelIME.Tag = "IME";
            this.labelIME.TabIndex = 0;
            this.labelIME.Anchor = AnchorStyles.Left;
            this.labelIME.BackColor = Color.Transparent;
            this.labelIME.DataBindings.Add(new Binding("Text", this.bindingSourceObracunRadnici, "IME"));
            this.labelIME.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunRadnici.Controls.Add(this.labelIME, 1, 2);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.labelIME, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.labelIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1JMBG.Location = point;
            this.label1JMBG.Name = "label1JMBG";
            this.label1JMBG.TabIndex = 1;
            this.label1JMBG.Tag = "labelJMBG";
            this.label1JMBG.Text = "JMBG:";
            this.label1JMBG.StyleSetName = "FieldUltraLabel";
            this.label1JMBG.AutoSize = true;
            this.label1JMBG.Anchor = AnchorStyles.Left;
            this.label1JMBG.Appearance.TextVAlign = VAlign.Middle;
            this.label1JMBG.Appearance.ForeColor = Color.Black;
            this.label1JMBG.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1JMBG, 0, 3);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1JMBG, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1JMBG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1JMBG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1JMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1JMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelJMBG.Location = point;
            this.labelJMBG.Name = "labelJMBG";
            this.labelJMBG.Tag = "JMBG";
            this.labelJMBG.TabIndex = 0;
            this.labelJMBG.Anchor = AnchorStyles.Left;
            this.labelJMBG.BackColor = Color.Transparent;
            this.labelJMBG.DataBindings.Add(new Binding("Text", this.bindingSourceObracunRadnici, "JMBG"));
            this.labelJMBG.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunRadnici.Controls.Add(this.labelJMBG, 1, 3);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.labelJMBG, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.labelJMBG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelJMBG.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.labelJMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.labelJMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPCINESTANOVANJA.Location = point;
            this.label1SIFRAOPCINESTANOVANJA.Name = "label1SIFRAOPCINESTANOVANJA";
            this.label1SIFRAOPCINESTANOVANJA.TabIndex = 1;
            this.label1SIFRAOPCINESTANOVANJA.Tag = "labelSIFRAOPCINESTANOVANJA";
            this.label1SIFRAOPCINESTANOVANJA.Text = "Šifra općine:";
            this.label1SIFRAOPCINESTANOVANJA.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPCINESTANOVANJA.AutoSize = true;
            this.label1SIFRAOPCINESTANOVANJA.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPCINESTANOVANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPCINESTANOVANJA.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPCINESTANOVANJA.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1SIFRAOPCINESTANOVANJA, 0, 4);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1SIFRAOPCINESTANOVANJA, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1SIFRAOPCINESTANOVANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPCINESTANOVANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPCINESTANOVANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x17);
            this.label1SIFRAOPCINESTANOVANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPCINESTANOVANJA.Location = point;
            this.textSIFRAOPCINESTANOVANJA.Name = "textSIFRAOPCINESTANOVANJA";
            this.textSIFRAOPCINESTANOVANJA.Tag = "SIFRAOPCINESTANOVANJA";
            this.textSIFRAOPCINESTANOVANJA.TabIndex = 0;
            this.textSIFRAOPCINESTANOVANJA.Anchor = AnchorStyles.Left;
            this.textSIFRAOPCINESTANOVANJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPCINESTANOVANJA.ReadOnly = false;
            this.textSIFRAOPCINESTANOVANJA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunRadnici, "SIFRAOPCINESTANOVANJA"));
            this.textSIFRAOPCINESTANOVANJA.MaxLength = 4;
            this.layoutManagerformObracunRadnici.Controls.Add(this.textSIFRAOPCINESTANOVANJA, 1, 4);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.textSIFRAOPCINESTANOVANJA, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.textSIFRAOPCINESTANOVANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPCINESTANOVANJA.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textSIFRAOPCINESTANOVANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textSIFRAOPCINESTANOVANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KOEFICIJENT.Location = point;
            this.label1KOEFICIJENT.Name = "label1KOEFICIJENT";
            this.label1KOEFICIJENT.TabIndex = 1;
            this.label1KOEFICIJENT.Tag = "labelKOEFICIJENT";
            this.label1KOEFICIJENT.Text = "Koeficijent:";
            this.label1KOEFICIJENT.StyleSetName = "FieldUltraLabel";
            this.label1KOEFICIJENT.AutoSize = true;
            this.label1KOEFICIJENT.Anchor = AnchorStyles.Left;
            this.label1KOEFICIJENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1KOEFICIJENT.Appearance.ForeColor = Color.Black;
            this.label1KOEFICIJENT.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1KOEFICIJENT, 0, 5);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1KOEFICIJENT, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1KOEFICIJENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x17);
            this.label1KOEFICIJENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelKOEFICIJENT.Location = point;
            this.labelKOEFICIJENT.Name = "labelKOEFICIJENT";
            this.labelKOEFICIJENT.Tag = "KOEFICIJENT";
            this.labelKOEFICIJENT.TabIndex = 0;
            this.labelKOEFICIJENT.Anchor = AnchorStyles.Left;
            this.labelKOEFICIJENT.BackColor = Color.Transparent;
            this.labelKOEFICIJENT.Appearance.TextHAlign = HAlign.Left;
            this.labelKOEFICIJENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunRadnici.Controls.Add(this.labelKOEFICIJENT, 1, 5);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.labelKOEFICIJENT, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.labelKOEFICIJENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelKOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0x88, 0x16);
            this.labelKOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x88, 0x16);
            this.labelKOEFICIJENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRACUNSKIKOEFICIJENT.Location = point;
            this.label1OBRACUNSKIKOEFICIJENT.Name = "label1OBRACUNSKIKOEFICIJENT";
            this.label1OBRACUNSKIKOEFICIJENT.TabIndex = 1;
            this.label1OBRACUNSKIKOEFICIJENT.Tag = "labelOBRACUNSKIKOEFICIJENT";
            this.label1OBRACUNSKIKOEFICIJENT.Text = "Obračunski koeficijent:";
            this.label1OBRACUNSKIKOEFICIJENT.StyleSetName = "FieldUltraLabel";
            this.label1OBRACUNSKIKOEFICIJENT.AutoSize = true;
            this.label1OBRACUNSKIKOEFICIJENT.Anchor = AnchorStyles.Left;
            this.label1OBRACUNSKIKOEFICIJENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRACUNSKIKOEFICIJENT.Appearance.ForeColor = Color.Black;
            this.label1OBRACUNSKIKOEFICIJENT.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1OBRACUNSKIKOEFICIJENT, 0, 6);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1OBRACUNSKIKOEFICIJENT, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1OBRACUNSKIKOEFICIJENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRACUNSKIKOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRACUNSKIKOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x9f, 0x17);
            this.label1OBRACUNSKIKOEFICIJENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRACUNSKIKOEFICIJENT.Location = point;
            this.textOBRACUNSKIKOEFICIJENT.Name = "textOBRACUNSKIKOEFICIJENT";
            this.textOBRACUNSKIKOEFICIJENT.Tag = "OBRACUNSKIKOEFICIJENT";
            this.textOBRACUNSKIKOEFICIJENT.TabIndex = 0;
            this.textOBRACUNSKIKOEFICIJENT.Anchor = AnchorStyles.Left;
            this.textOBRACUNSKIKOEFICIJENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRACUNSKIKOEFICIJENT.ReadOnly = false;
            this.textOBRACUNSKIKOEFICIJENT.PromptChar = ' ';
            this.textOBRACUNSKIKOEFICIJENT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRACUNSKIKOEFICIJENT.DataBindings.Add(new Binding("Value", this.bindingSourceObracunRadnici, "OBRACUNSKIKOEFICIJENT"));
            this.textOBRACUNSKIKOEFICIJENT.NumericType = NumericType.Double;
            this.textOBRACUNSKIKOEFICIJENT.MaxValue = 79228162514264337593543950335M;
            this.textOBRACUNSKIKOEFICIJENT.MinValue = -79228162514264337593543950335M;
            this.textOBRACUNSKIKOEFICIJENT.MaskInput = "{LOC}-nnnnnnn.nnnnnnnnnn";
            this.layoutManagerformObracunRadnici.Controls.Add(this.textOBRACUNSKIKOEFICIJENT, 1, 6);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.textOBRACUNSKIKOEFICIJENT, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.textOBRACUNSKIKOEFICIJENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRACUNSKIKOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0x88, 0x16);
            this.textOBRACUNSKIKOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x88, 0x16);
            this.textOBRACUNSKIKOEFICIJENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRACUNATIPRIREZ.Location = point;
            this.label1OBRACUNATIPRIREZ.Name = "label1OBRACUNATIPRIREZ";
            this.label1OBRACUNATIPRIREZ.TabIndex = 1;
            this.label1OBRACUNATIPRIREZ.Tag = "labelOBRACUNATIPRIREZ";
            this.label1OBRACUNATIPRIREZ.Text = "OBRACUNATIPRIREZ:";
            this.label1OBRACUNATIPRIREZ.StyleSetName = "FieldUltraLabel";
            this.label1OBRACUNATIPRIREZ.AutoSize = true;
            this.label1OBRACUNATIPRIREZ.Anchor = AnchorStyles.Left;
            this.label1OBRACUNATIPRIREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRACUNATIPRIREZ.Appearance.ForeColor = Color.Black;
            this.label1OBRACUNATIPRIREZ.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1OBRACUNATIPRIREZ, 0, 7);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1OBRACUNATIPRIREZ, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1OBRACUNATIPRIREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRACUNATIPRIREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRACUNATIPRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x97, 0x17);
            this.label1OBRACUNATIPRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRACUNATIPRIREZ.Location = point;
            this.textOBRACUNATIPRIREZ.Name = "textOBRACUNATIPRIREZ";
            this.textOBRACUNATIPRIREZ.Tag = "OBRACUNATIPRIREZ";
            this.textOBRACUNATIPRIREZ.TabIndex = 0;
            this.textOBRACUNATIPRIREZ.Anchor = AnchorStyles.Left;
            this.textOBRACUNATIPRIREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRACUNATIPRIREZ.ReadOnly = false;
            this.textOBRACUNATIPRIREZ.PromptChar = ' ';
            this.textOBRACUNATIPRIREZ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRACUNATIPRIREZ.DataBindings.Add(new Binding("Value", this.bindingSourceObracunRadnici, "OBRACUNATIPRIREZ"));
            this.textOBRACUNATIPRIREZ.NumericType = NumericType.Double;
            this.textOBRACUNATIPRIREZ.MaxValue = 79228162514264337593543950335M;
            this.textOBRACUNATIPRIREZ.MinValue = -79228162514264337593543950335M;
            this.textOBRACUNATIPRIREZ.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformObracunRadnici.Controls.Add(this.textOBRACUNATIPRIREZ, 1, 7);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.textOBRACUNATIPRIREZ, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.textOBRACUNATIPRIREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRACUNATIPRIREZ.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATIPRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATIPRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ISKORISTENOOO.Location = point;
            this.label1ISKORISTENOOO.Name = "label1ISKORISTENOOO";
            this.label1ISKORISTENOOO.TabIndex = 1;
            this.label1ISKORISTENOOO.Tag = "labelISKORISTENOOO";
            this.label1ISKORISTENOOO.Text = "OSOBNIODBITAK:";
            this.label1ISKORISTENOOO.StyleSetName = "FieldUltraLabel";
            this.label1ISKORISTENOOO.AutoSize = true;
            this.label1ISKORISTENOOO.Anchor = AnchorStyles.Left;
            this.label1ISKORISTENOOO.Appearance.TextVAlign = VAlign.Middle;
            this.label1ISKORISTENOOO.Appearance.ForeColor = Color.Black;
            this.label1ISKORISTENOOO.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1ISKORISTENOOO, 0, 8);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1ISKORISTENOOO, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1ISKORISTENOOO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ISKORISTENOOO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ISKORISTENOOO.MinimumSize = size;
            size = new System.Drawing.Size(0x80, 0x17);
            this.label1ISKORISTENOOO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textISKORISTENOOO.Location = point;
            this.textISKORISTENOOO.Name = "textISKORISTENOOO";
            this.textISKORISTENOOO.Tag = "ISKORISTENOOO";
            this.textISKORISTENOOO.TabIndex = 0;
            this.textISKORISTENOOO.Anchor = AnchorStyles.Left;
            this.textISKORISTENOOO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textISKORISTENOOO.ContextMenu = this.contextMenu1;
            this.textISKORISTENOOO.ReadOnly = false;
            this.textISKORISTENOOO.PromptChar = ' ';
            this.textISKORISTENOOO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textISKORISTENOOO.DataBindings.Add(new Binding("Value", this.bindingSourceObracunRadnici, "ISKORISTENOOO"));
            this.textISKORISTENOOO.NumericType = NumericType.Double;
            this.textISKORISTENOOO.MaxValue = 79228162514264337593543950335M;
            this.textISKORISTENOOO.MinValue = -79228162514264337593543950335M;
            this.textISKORISTENOOO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textISKORISTENOOO.Nullable = true;
            this.layoutManagerformObracunRadnici.Controls.Add(this.textISKORISTENOOO, 1, 8);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.textISKORISTENOOO, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.textISKORISTENOOO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textISKORISTENOOO.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textISKORISTENOOO.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textISKORISTENOOO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1faktoo.Location = point;
            this.label1faktoo.Name = "label1faktoo";
            this.label1faktoo.TabIndex = 1;
            this.label1faktoo.Tag = "labelfaktoo";
            this.label1faktoo.Text = "faktoo:";
            this.label1faktoo.StyleSetName = "FieldUltraLabel";
            this.label1faktoo.AutoSize = true;
            this.label1faktoo.Anchor = AnchorStyles.Left;
            this.label1faktoo.Appearance.TextVAlign = VAlign.Middle;
            this.label1faktoo.Appearance.ForeColor = Color.Black;
            this.label1faktoo.BackColor = Color.Transparent;
            this.layoutManagerformObracunRadnici.Controls.Add(this.label1faktoo, 0, 9);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.label1faktoo, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.label1faktoo, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1faktoo.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1faktoo.MinimumSize = size;
            size = new System.Drawing.Size(0x3b, 0x17);
            this.label1faktoo.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textfaktoo.Location = point;
            this.textfaktoo.Name = "textfaktoo";
            this.textfaktoo.Tag = "faktoo";
            this.textfaktoo.TabIndex = 0;
            this.textfaktoo.Anchor = AnchorStyles.Left;
            this.textfaktoo.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textfaktoo.ReadOnly = false;
            this.textfaktoo.PromptChar = ' ';
            this.textfaktoo.Enter += new EventHandler(this.numericEditor_Enter);
            this.textfaktoo.DataBindings.Add(new Binding("Value", this.bindingSourceObracunRadnici, "faktoo"));
            this.textfaktoo.NumericType = NumericType.Double;
            this.textfaktoo.MaxValue = 79228162514264337593543950335M;
            this.textfaktoo.MinValue = -79228162514264337593543950335M;
            this.textfaktoo.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformObracunRadnici.Controls.Add(this.textfaktoo, 1, 9);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.textfaktoo, 1);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.textfaktoo, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textfaktoo.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textfaktoo.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textfaktoo.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelObracunDoprinosi.Location = point;
            this.grdLevelObracunDoprinosi.Name = "grdLevelObracunDoprinosi";
            this.layoutManagerformObracunRadnici.Controls.Add(this.grdLevelObracunDoprinosi, 0, 10);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.grdLevelObracunDoprinosi, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.grdLevelObracunDoprinosi, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelObracunDoprinosi.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelObracunDoprinosi.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelObracunDoprinosi.Size = size;
            this.grdLevelObracunDoprinosi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsObracunDoprinosi.Location = point;
            this.panelactionsObracunDoprinosi.Name = "panelactionsObracunDoprinosi";
            this.panelactionsObracunDoprinosi.BackColor = Color.Transparent;
            this.panelactionsObracunDoprinosi.Controls.Add(this.layoutManagerpanelactionsObracunDoprinosi);
            this.layoutManagerformObracunRadnici.Controls.Add(this.panelactionsObracunDoprinosi, 0, 11);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.panelactionsObracunDoprinosi, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.panelactionsObracunDoprinosi, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsObracunDoprinosi.Margin = padding;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsObracunDoprinosi.MinimumSize = size;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsObracunDoprinosi.Size = size;
            this.panelactionsObracunDoprinosi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunDoprinosiAdd.Location = point;
            this.linkLabelObracunDoprinosiAdd.Name = "linkLabelObracunDoprinosiAdd";
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunDoprinosiAdd.Size = size;
            this.linkLabelObracunDoprinosiAdd.Text = " Add OBRACUNLevel3  ";
            this.linkLabelObracunDoprinosiAdd.Click += new EventHandler(this.ObracunDoprinosiAdd_Click);
            this.linkLabelObracunDoprinosiAdd.BackColor = Color.Transparent;
            this.linkLabelObracunDoprinosiAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunDoprinosiAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunDoprinosiAdd.Cursor = Cursors.Hand;
            this.linkLabelObracunDoprinosiAdd.AutoSize = true;
            this.layoutManagerpanelactionsObracunDoprinosi.Controls.Add(this.linkLabelObracunDoprinosiAdd, 0, 0);
            this.layoutManagerpanelactionsObracunDoprinosi.SetColumnSpan(this.linkLabelObracunDoprinosiAdd, 1);
            this.layoutManagerpanelactionsObracunDoprinosi.SetRowSpan(this.linkLabelObracunDoprinosiAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunDoprinosiAdd.Margin = padding;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunDoprinosiAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunDoprinosiAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunDoprinosiUpdate.Location = point;
            this.linkLabelObracunDoprinosiUpdate.Name = "linkLabelObracunDoprinosiUpdate";
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunDoprinosiUpdate.Size = size;
            this.linkLabelObracunDoprinosiUpdate.Text = " Update OBRACUNLevel3  ";
            this.linkLabelObracunDoprinosiUpdate.Click += new EventHandler(this.ObracunDoprinosiUpdate_Click);
            this.linkLabelObracunDoprinosiUpdate.BackColor = Color.Transparent;
            this.linkLabelObracunDoprinosiUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunDoprinosiUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunDoprinosiUpdate.Cursor = Cursors.Hand;
            this.linkLabelObracunDoprinosiUpdate.AutoSize = true;
            this.layoutManagerpanelactionsObracunDoprinosi.Controls.Add(this.linkLabelObracunDoprinosiUpdate, 1, 0);
            this.layoutManagerpanelactionsObracunDoprinosi.SetColumnSpan(this.linkLabelObracunDoprinosiUpdate, 1);
            this.layoutManagerpanelactionsObracunDoprinosi.SetRowSpan(this.linkLabelObracunDoprinosiUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunDoprinosiUpdate.Margin = padding;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunDoprinosiUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunDoprinosiUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunDoprinosiDelete.Location = point;
            this.linkLabelObracunDoprinosiDelete.Name = "linkLabelObracunDoprinosiDelete";
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunDoprinosiDelete.Size = size;
            this.linkLabelObracunDoprinosiDelete.Text = " Delete OBRACUNLevel3  ";
            this.linkLabelObracunDoprinosiDelete.Click += new EventHandler(this.ObracunDoprinosiDelete_Click);
            this.linkLabelObracunDoprinosiDelete.BackColor = Color.Transparent;
            this.linkLabelObracunDoprinosiDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunDoprinosiDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunDoprinosiDelete.Cursor = Cursors.Hand;
            this.linkLabelObracunDoprinosiDelete.AutoSize = true;
            this.layoutManagerpanelactionsObracunDoprinosi.Controls.Add(this.linkLabelObracunDoprinosiDelete, 2, 0);
            this.layoutManagerpanelactionsObracunDoprinosi.SetColumnSpan(this.linkLabelObracunDoprinosiDelete, 1);
            this.layoutManagerpanelactionsObracunDoprinosi.SetRowSpan(this.linkLabelObracunDoprinosiDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunDoprinosiDelete.Margin = padding;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunDoprinosiDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunDoprinosiDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunDoprinosi.Location = point;
            this.linkLabelObracunDoprinosi.Name = "linkLabelObracunDoprinosi";
            this.layoutManagerpanelactionsObracunDoprinosi.Controls.Add(this.linkLabelObracunDoprinosi, 3, 0);
            this.layoutManagerpanelactionsObracunDoprinosi.SetColumnSpan(this.linkLabelObracunDoprinosi, 1);
            this.layoutManagerpanelactionsObracunDoprinosi.SetRowSpan(this.linkLabelObracunDoprinosi, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunDoprinosi.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunDoprinosi.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunDoprinosi.Size = size;
            this.linkLabelObracunDoprinosi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelObracunPorezi.Location = point;
            this.grdLevelObracunPorezi.Name = "grdLevelObracunPorezi";
            this.layoutManagerformObracunRadnici.Controls.Add(this.grdLevelObracunPorezi, 0, 12);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.grdLevelObracunPorezi, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.grdLevelObracunPorezi, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelObracunPorezi.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelObracunPorezi.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelObracunPorezi.Size = size;
            this.grdLevelObracunPorezi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsObracunPorezi.Location = point;
            this.panelactionsObracunPorezi.Name = "panelactionsObracunPorezi";
            this.panelactionsObracunPorezi.BackColor = Color.Transparent;
            this.panelactionsObracunPorezi.Controls.Add(this.layoutManagerpanelactionsObracunPorezi);
            this.layoutManagerformObracunRadnici.Controls.Add(this.panelactionsObracunPorezi, 0, 13);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.panelactionsObracunPorezi, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.panelactionsObracunPorezi, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsObracunPorezi.Margin = padding;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsObracunPorezi.MinimumSize = size;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsObracunPorezi.Size = size;
            this.panelactionsObracunPorezi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunPoreziAdd.Location = point;
            this.linkLabelObracunPoreziAdd.Name = "linkLabelObracunPoreziAdd";
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunPoreziAdd.Size = size;
            this.linkLabelObracunPoreziAdd.Text = " Add OBRACUNLevel4  ";
            this.linkLabelObracunPoreziAdd.Click += new EventHandler(this.ObracunPoreziAdd_Click);
            this.linkLabelObracunPoreziAdd.BackColor = Color.Transparent;
            this.linkLabelObracunPoreziAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunPoreziAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunPoreziAdd.Cursor = Cursors.Hand;
            this.linkLabelObracunPoreziAdd.AutoSize = true;
            this.layoutManagerpanelactionsObracunPorezi.Controls.Add(this.linkLabelObracunPoreziAdd, 0, 0);
            this.layoutManagerpanelactionsObracunPorezi.SetColumnSpan(this.linkLabelObracunPoreziAdd, 1);
            this.layoutManagerpanelactionsObracunPorezi.SetRowSpan(this.linkLabelObracunPoreziAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunPoreziAdd.Margin = padding;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunPoreziAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelObracunPoreziAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunPoreziUpdate.Location = point;
            this.linkLabelObracunPoreziUpdate.Name = "linkLabelObracunPoreziUpdate";
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunPoreziUpdate.Size = size;
            this.linkLabelObracunPoreziUpdate.Text = " Update OBRACUNLevel4  ";
            this.linkLabelObracunPoreziUpdate.Click += new EventHandler(this.ObracunPoreziUpdate_Click);
            this.linkLabelObracunPoreziUpdate.BackColor = Color.Transparent;
            this.linkLabelObracunPoreziUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunPoreziUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunPoreziUpdate.Cursor = Cursors.Hand;
            this.linkLabelObracunPoreziUpdate.AutoSize = true;
            this.layoutManagerpanelactionsObracunPorezi.Controls.Add(this.linkLabelObracunPoreziUpdate, 1, 0);
            this.layoutManagerpanelactionsObracunPorezi.SetColumnSpan(this.linkLabelObracunPoreziUpdate, 1);
            this.layoutManagerpanelactionsObracunPorezi.SetRowSpan(this.linkLabelObracunPoreziUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunPoreziUpdate.Margin = padding;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunPoreziUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelObracunPoreziUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunPoreziDelete.Location = point;
            this.linkLabelObracunPoreziDelete.Name = "linkLabelObracunPoreziDelete";
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunPoreziDelete.Size = size;
            this.linkLabelObracunPoreziDelete.Text = " Delete OBRACUNLevel4  ";
            this.linkLabelObracunPoreziDelete.Click += new EventHandler(this.ObracunPoreziDelete_Click);
            this.linkLabelObracunPoreziDelete.BackColor = Color.Transparent;
            this.linkLabelObracunPoreziDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunPoreziDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunPoreziDelete.Cursor = Cursors.Hand;
            this.linkLabelObracunPoreziDelete.AutoSize = true;
            this.layoutManagerpanelactionsObracunPorezi.Controls.Add(this.linkLabelObracunPoreziDelete, 2, 0);
            this.layoutManagerpanelactionsObracunPorezi.SetColumnSpan(this.linkLabelObracunPoreziDelete, 1);
            this.layoutManagerpanelactionsObracunPorezi.SetRowSpan(this.linkLabelObracunPoreziDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunPoreziDelete.Margin = padding;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunPoreziDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelObracunPoreziDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunPorezi.Location = point;
            this.linkLabelObracunPorezi.Name = "linkLabelObracunPorezi";
            this.layoutManagerpanelactionsObracunPorezi.Controls.Add(this.linkLabelObracunPorezi, 3, 0);
            this.layoutManagerpanelactionsObracunPorezi.SetColumnSpan(this.linkLabelObracunPorezi, 1);
            this.layoutManagerpanelactionsObracunPorezi.SetRowSpan(this.linkLabelObracunPorezi, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunPorezi.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunPorezi.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunPorezi.Size = size;
            this.linkLabelObracunPorezi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelObracunOlaksice.Location = point;
            this.grdLevelObracunOlaksice.Name = "grdLevelObracunOlaksice";
            this.layoutManagerformObracunRadnici.Controls.Add(this.grdLevelObracunOlaksice, 0, 14);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.grdLevelObracunOlaksice, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.grdLevelObracunOlaksice, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelObracunOlaksice.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelObracunOlaksice.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelObracunOlaksice.Size = size;
            this.grdLevelObracunOlaksice.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsObracunOlaksice.Location = point;
            this.panelactionsObracunOlaksice.Name = "panelactionsObracunOlaksice";
            this.panelactionsObracunOlaksice.BackColor = Color.Transparent;
            this.panelactionsObracunOlaksice.Controls.Add(this.layoutManagerpanelactionsObracunOlaksice);
            this.layoutManagerformObracunRadnici.Controls.Add(this.panelactionsObracunOlaksice, 0, 15);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.panelactionsObracunOlaksice, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.panelactionsObracunOlaksice, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsObracunOlaksice.Margin = padding;
            size = new System.Drawing.Size(0x1bc, 0x19);
            this.panelactionsObracunOlaksice.MinimumSize = size;
            size = new System.Drawing.Size(0x1bc, 0x19);
            this.panelactionsObracunOlaksice.Size = size;
            this.panelactionsObracunOlaksice.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunOlaksiceAdd.Location = point;
            this.linkLabelObracunOlaksiceAdd.Name = "linkLabelObracunOlaksiceAdd";
            size = new System.Drawing.Size(0x7c, 15);
            this.linkLabelObracunOlaksiceAdd.Size = size;
            this.linkLabelObracunOlaksiceAdd.Text = " Add ObracunOlaksice  ";
            this.linkLabelObracunOlaksiceAdd.Click += new EventHandler(this.ObracunOlaksiceAdd_Click);
            this.linkLabelObracunOlaksiceAdd.BackColor = Color.Transparent;
            this.linkLabelObracunOlaksiceAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunOlaksiceAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunOlaksiceAdd.Cursor = Cursors.Hand;
            this.linkLabelObracunOlaksiceAdd.AutoSize = true;
            this.layoutManagerpanelactionsObracunOlaksice.Controls.Add(this.linkLabelObracunOlaksiceAdd, 0, 0);
            this.layoutManagerpanelactionsObracunOlaksice.SetColumnSpan(this.linkLabelObracunOlaksiceAdd, 1);
            this.layoutManagerpanelactionsObracunOlaksice.SetRowSpan(this.linkLabelObracunOlaksiceAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunOlaksiceAdd.Margin = padding;
            size = new System.Drawing.Size(0x7c, 15);
            this.linkLabelObracunOlaksiceAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x7c, 15);
            this.linkLabelObracunOlaksiceAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunOlaksiceUpdate.Location = point;
            this.linkLabelObracunOlaksiceUpdate.Name = "linkLabelObracunOlaksiceUpdate";
            size = new System.Drawing.Size(0x8e, 15);
            this.linkLabelObracunOlaksiceUpdate.Size = size;
            this.linkLabelObracunOlaksiceUpdate.Text = " Update ObracunOlaksice  ";
            this.linkLabelObracunOlaksiceUpdate.Click += new EventHandler(this.ObracunOlaksiceUpdate_Click);
            this.linkLabelObracunOlaksiceUpdate.BackColor = Color.Transparent;
            this.linkLabelObracunOlaksiceUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunOlaksiceUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunOlaksiceUpdate.Cursor = Cursors.Hand;
            this.linkLabelObracunOlaksiceUpdate.AutoSize = true;
            this.layoutManagerpanelactionsObracunOlaksice.Controls.Add(this.linkLabelObracunOlaksiceUpdate, 1, 0);
            this.layoutManagerpanelactionsObracunOlaksice.SetColumnSpan(this.linkLabelObracunOlaksiceUpdate, 1);
            this.layoutManagerpanelactionsObracunOlaksice.SetRowSpan(this.linkLabelObracunOlaksiceUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunOlaksiceUpdate.Margin = padding;
            size = new System.Drawing.Size(0x8e, 15);
            this.linkLabelObracunOlaksiceUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 15);
            this.linkLabelObracunOlaksiceUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunOlaksiceDelete.Location = point;
            this.linkLabelObracunOlaksiceDelete.Name = "linkLabelObracunOlaksiceDelete";
            size = new System.Drawing.Size(0x8a, 15);
            this.linkLabelObracunOlaksiceDelete.Size = size;
            this.linkLabelObracunOlaksiceDelete.Text = " Delete ObracunOlaksice  ";
            this.linkLabelObracunOlaksiceDelete.Click += new EventHandler(this.ObracunOlaksiceDelete_Click);
            this.linkLabelObracunOlaksiceDelete.BackColor = Color.Transparent;
            this.linkLabelObracunOlaksiceDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunOlaksiceDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunOlaksiceDelete.Cursor = Cursors.Hand;
            this.linkLabelObracunOlaksiceDelete.AutoSize = true;
            this.layoutManagerpanelactionsObracunOlaksice.Controls.Add(this.linkLabelObracunOlaksiceDelete, 2, 0);
            this.layoutManagerpanelactionsObracunOlaksice.SetColumnSpan(this.linkLabelObracunOlaksiceDelete, 1);
            this.layoutManagerpanelactionsObracunOlaksice.SetRowSpan(this.linkLabelObracunOlaksiceDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunOlaksiceDelete.Margin = padding;
            size = new System.Drawing.Size(0x8a, 15);
            this.linkLabelObracunOlaksiceDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x8a, 15);
            this.linkLabelObracunOlaksiceDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunOlaksice.Location = point;
            this.linkLabelObracunOlaksice.Name = "linkLabelObracunOlaksice";
            this.layoutManagerpanelactionsObracunOlaksice.Controls.Add(this.linkLabelObracunOlaksice, 3, 0);
            this.layoutManagerpanelactionsObracunOlaksice.SetColumnSpan(this.linkLabelObracunOlaksice, 1);
            this.layoutManagerpanelactionsObracunOlaksice.SetRowSpan(this.linkLabelObracunOlaksice, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunOlaksice.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunOlaksice.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunOlaksice.Size = size;
            this.linkLabelObracunOlaksice.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelOBRACUNKrediti.Location = point;
            this.grdLevelOBRACUNKrediti.Name = "grdLevelOBRACUNKrediti";
            this.layoutManagerformObracunRadnici.Controls.Add(this.grdLevelOBRACUNKrediti, 0, 0x10);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.grdLevelOBRACUNKrediti, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.grdLevelOBRACUNKrediti, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelOBRACUNKrediti.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelOBRACUNKrediti.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelOBRACUNKrediti.Size = size;
            this.grdLevelOBRACUNKrediti.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsOBRACUNKrediti.Location = point;
            this.panelactionsOBRACUNKrediti.Name = "panelactionsOBRACUNKrediti";
            this.panelactionsOBRACUNKrediti.BackColor = Color.Transparent;
            this.panelactionsOBRACUNKrediti.Controls.Add(this.layoutManagerpanelactionsOBRACUNKrediti);
            this.layoutManagerformObracunRadnici.Controls.Add(this.panelactionsOBRACUNKrediti, 0, 0x11);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.panelactionsOBRACUNKrediti, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.panelactionsOBRACUNKrediti, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsOBRACUNKrediti.Margin = padding;
            size = new System.Drawing.Size(0x19e, 0x19);
            this.panelactionsOBRACUNKrediti.MinimumSize = size;
            size = new System.Drawing.Size(0x19e, 0x19);
            this.panelactionsOBRACUNKrediti.Size = size;
            this.panelactionsOBRACUNKrediti.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNKreditiAdd.Location = point;
            this.linkLabelOBRACUNKreditiAdd.Name = "linkLabelOBRACUNKreditiAdd";
            size = new System.Drawing.Size(0x72, 15);
            this.linkLabelOBRACUNKreditiAdd.Size = size;
            this.linkLabelOBRACUNKreditiAdd.Text = " Add ObracunKrediti  ";
            this.linkLabelOBRACUNKreditiAdd.Click += new EventHandler(this.OBRACUNKreditiAdd_Click);
            this.linkLabelOBRACUNKreditiAdd.BackColor = Color.Transparent;
            this.linkLabelOBRACUNKreditiAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelOBRACUNKreditiAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOBRACUNKreditiAdd.Cursor = Cursors.Hand;
            this.linkLabelOBRACUNKreditiAdd.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNKrediti.Controls.Add(this.linkLabelOBRACUNKreditiAdd, 0, 0);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetColumnSpan(this.linkLabelOBRACUNKreditiAdd, 1);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetRowSpan(this.linkLabelOBRACUNKreditiAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNKreditiAdd.Margin = padding;
            size = new System.Drawing.Size(0x72, 15);
            this.linkLabelOBRACUNKreditiAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 15);
            this.linkLabelOBRACUNKreditiAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNKreditiUpdate.Location = point;
            this.linkLabelOBRACUNKreditiUpdate.Name = "linkLabelOBRACUNKreditiUpdate";
            size = new System.Drawing.Size(0x84, 15);
            this.linkLabelOBRACUNKreditiUpdate.Size = size;
            this.linkLabelOBRACUNKreditiUpdate.Text = " Update ObracunKrediti  ";
            this.linkLabelOBRACUNKreditiUpdate.Click += new EventHandler(this.OBRACUNKreditiUpdate_Click);
            this.linkLabelOBRACUNKreditiUpdate.BackColor = Color.Transparent;
            this.linkLabelOBRACUNKreditiUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelOBRACUNKreditiUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOBRACUNKreditiUpdate.Cursor = Cursors.Hand;
            this.linkLabelOBRACUNKreditiUpdate.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNKrediti.Controls.Add(this.linkLabelOBRACUNKreditiUpdate, 1, 0);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetColumnSpan(this.linkLabelOBRACUNKreditiUpdate, 1);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetRowSpan(this.linkLabelOBRACUNKreditiUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNKreditiUpdate.Margin = padding;
            size = new System.Drawing.Size(0x84, 15);
            this.linkLabelOBRACUNKreditiUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x84, 15);
            this.linkLabelOBRACUNKreditiUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNKreditiDelete.Location = point;
            this.linkLabelOBRACUNKreditiDelete.Name = "linkLabelOBRACUNKreditiDelete";
            size = new System.Drawing.Size(0x80, 15);
            this.linkLabelOBRACUNKreditiDelete.Size = size;
            this.linkLabelOBRACUNKreditiDelete.Text = " Delete ObracunKrediti  ";
            this.linkLabelOBRACUNKreditiDelete.Click += new EventHandler(this.OBRACUNKreditiDelete_Click);
            this.linkLabelOBRACUNKreditiDelete.BackColor = Color.Transparent;
            this.linkLabelOBRACUNKreditiDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelOBRACUNKreditiDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOBRACUNKreditiDelete.Cursor = Cursors.Hand;
            this.linkLabelOBRACUNKreditiDelete.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNKrediti.Controls.Add(this.linkLabelOBRACUNKreditiDelete, 2, 0);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetColumnSpan(this.linkLabelOBRACUNKreditiDelete, 1);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetRowSpan(this.linkLabelOBRACUNKreditiDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNKreditiDelete.Margin = padding;
            size = new System.Drawing.Size(0x80, 15);
            this.linkLabelOBRACUNKreditiDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x80, 15);
            this.linkLabelOBRACUNKreditiDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNKrediti.Location = point;
            this.linkLabelOBRACUNKrediti.Name = "linkLabelOBRACUNKrediti";
            this.layoutManagerpanelactionsOBRACUNKrediti.Controls.Add(this.linkLabelOBRACUNKrediti, 3, 0);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetColumnSpan(this.linkLabelOBRACUNKrediti, 1);
            this.layoutManagerpanelactionsOBRACUNKrediti.SetRowSpan(this.linkLabelOBRACUNKrediti, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNKrediti.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelOBRACUNKrediti.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelOBRACUNKrediti.Size = size;
            this.linkLabelOBRACUNKrediti.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelOBRACUNObustave.Location = point;
            this.grdLevelOBRACUNObustave.Name = "grdLevelOBRACUNObustave";
            this.layoutManagerformObracunRadnici.Controls.Add(this.grdLevelOBRACUNObustave, 0, 0x12);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.grdLevelOBRACUNObustave, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.grdLevelOBRACUNObustave, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelOBRACUNObustave.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelOBRACUNObustave.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelOBRACUNObustave.Size = size;
            this.grdLevelOBRACUNObustave.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsOBRACUNObustave.Location = point;
            this.panelactionsOBRACUNObustave.Name = "panelactionsOBRACUNObustave";
            this.panelactionsOBRACUNObustave.BackColor = Color.Transparent;
            this.panelactionsOBRACUNObustave.Controls.Add(this.layoutManagerpanelactionsOBRACUNObustave);
            this.layoutManagerformObracunRadnici.Controls.Add(this.panelactionsOBRACUNObustave, 0, 0x13);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.panelactionsOBRACUNObustave, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.panelactionsOBRACUNObustave, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsOBRACUNObustave.Margin = padding;
            size = new System.Drawing.Size(0x1cf, 0x19);
            this.panelactionsOBRACUNObustave.MinimumSize = size;
            size = new System.Drawing.Size(0x1cf, 0x19);
            this.panelactionsOBRACUNObustave.Size = size;
            this.panelactionsOBRACUNObustave.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNObustaveAdd.Location = point;
            this.linkLabelOBRACUNObustaveAdd.Name = "linkLabelOBRACUNObustaveAdd";
            size = new System.Drawing.Size(0x83, 15);
            this.linkLabelOBRACUNObustaveAdd.Size = size;
            this.linkLabelOBRACUNObustaveAdd.Text = " Add ObracunObustave  ";
            this.linkLabelOBRACUNObustaveAdd.Click += new EventHandler(this.OBRACUNObustaveAdd_Click);
            this.linkLabelOBRACUNObustaveAdd.BackColor = Color.Transparent;
            this.linkLabelOBRACUNObustaveAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelOBRACUNObustaveAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOBRACUNObustaveAdd.Cursor = Cursors.Hand;
            this.linkLabelOBRACUNObustaveAdd.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNObustave.Controls.Add(this.linkLabelOBRACUNObustaveAdd, 0, 0);
            this.layoutManagerpanelactionsOBRACUNObustave.SetColumnSpan(this.linkLabelOBRACUNObustaveAdd, 1);
            this.layoutManagerpanelactionsOBRACUNObustave.SetRowSpan(this.linkLabelOBRACUNObustaveAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNObustaveAdd.Margin = padding;
            size = new System.Drawing.Size(0x83, 15);
            this.linkLabelOBRACUNObustaveAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x83, 15);
            this.linkLabelOBRACUNObustaveAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNObustaveUpdate.Location = point;
            this.linkLabelOBRACUNObustaveUpdate.Name = "linkLabelOBRACUNObustaveUpdate";
            size = new System.Drawing.Size(0x94, 15);
            this.linkLabelOBRACUNObustaveUpdate.Size = size;
            this.linkLabelOBRACUNObustaveUpdate.Text = " Update ObracunObustave  ";
            this.linkLabelOBRACUNObustaveUpdate.Click += new EventHandler(this.OBRACUNObustaveUpdate_Click);
            this.linkLabelOBRACUNObustaveUpdate.BackColor = Color.Transparent;
            this.linkLabelOBRACUNObustaveUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelOBRACUNObustaveUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOBRACUNObustaveUpdate.Cursor = Cursors.Hand;
            this.linkLabelOBRACUNObustaveUpdate.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNObustave.Controls.Add(this.linkLabelOBRACUNObustaveUpdate, 1, 0);
            this.layoutManagerpanelactionsOBRACUNObustave.SetColumnSpan(this.linkLabelOBRACUNObustaveUpdate, 1);
            this.layoutManagerpanelactionsOBRACUNObustave.SetRowSpan(this.linkLabelOBRACUNObustaveUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNObustaveUpdate.Margin = padding;
            size = new System.Drawing.Size(0x94, 15);
            this.linkLabelOBRACUNObustaveUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x94, 15);
            this.linkLabelOBRACUNObustaveUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNObustaveDelete.Location = point;
            this.linkLabelOBRACUNObustaveDelete.Name = "linkLabelOBRACUNObustaveDelete";
            size = new System.Drawing.Size(0x90, 15);
            this.linkLabelOBRACUNObustaveDelete.Size = size;
            this.linkLabelOBRACUNObustaveDelete.Text = " Delete ObracunObustave  ";
            this.linkLabelOBRACUNObustaveDelete.Click += new EventHandler(this.OBRACUNObustaveDelete_Click);
            this.linkLabelOBRACUNObustaveDelete.BackColor = Color.Transparent;
            this.linkLabelOBRACUNObustaveDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelOBRACUNObustaveDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOBRACUNObustaveDelete.Cursor = Cursors.Hand;
            this.linkLabelOBRACUNObustaveDelete.AutoSize = true;
            this.layoutManagerpanelactionsOBRACUNObustave.Controls.Add(this.linkLabelOBRACUNObustaveDelete, 2, 0);
            this.layoutManagerpanelactionsOBRACUNObustave.SetColumnSpan(this.linkLabelOBRACUNObustaveDelete, 1);
            this.layoutManagerpanelactionsOBRACUNObustave.SetRowSpan(this.linkLabelOBRACUNObustaveDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNObustaveDelete.Margin = padding;
            size = new System.Drawing.Size(0x90, 15);
            this.linkLabelOBRACUNObustaveDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 15);
            this.linkLabelOBRACUNObustaveDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelOBRACUNObustave.Location = point;
            this.linkLabelOBRACUNObustave.Name = "linkLabelOBRACUNObustave";
            this.layoutManagerpanelactionsOBRACUNObustave.Controls.Add(this.linkLabelOBRACUNObustave, 3, 0);
            this.layoutManagerpanelactionsOBRACUNObustave.SetColumnSpan(this.linkLabelOBRACUNObustave, 1);
            this.layoutManagerpanelactionsOBRACUNObustave.SetRowSpan(this.linkLabelOBRACUNObustave, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelOBRACUNObustave.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelOBRACUNObustave.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelOBRACUNObustave.Size = size;
            this.linkLabelOBRACUNObustave.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelObracunElementi.Location = point;
            this.grdLevelObracunElementi.Name = "grdLevelObracunElementi";
            this.layoutManagerformObracunRadnici.Controls.Add(this.grdLevelObracunElementi, 0, 20);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.grdLevelObracunElementi, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.grdLevelObracunElementi, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelObracunElementi.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelObracunElementi.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelObracunElementi.Size = size;
            this.grdLevelObracunElementi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsObracunElementi.Location = point;
            this.panelactionsObracunElementi.Name = "panelactionsObracunElementi";
            this.panelactionsObracunElementi.BackColor = Color.Transparent;
            this.panelactionsObracunElementi.Controls.Add(this.layoutManagerpanelactionsObracunElementi);
            this.layoutManagerformObracunRadnici.Controls.Add(this.panelactionsObracunElementi, 0, 0x15);
            this.layoutManagerformObracunRadnici.SetColumnSpan(this.panelactionsObracunElementi, 2);
            this.layoutManagerformObracunRadnici.SetRowSpan(this.panelactionsObracunElementi, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsObracunElementi.Margin = padding;
            size = new System.Drawing.Size(450, 0x19);
            this.panelactionsObracunElementi.MinimumSize = size;
            size = new System.Drawing.Size(450, 0x19);
            this.panelactionsObracunElementi.Size = size;
            this.panelactionsObracunElementi.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunElementiAdd.Location = point;
            this.linkLabelObracunElementiAdd.Name = "linkLabelObracunElementiAdd";
            size = new System.Drawing.Size(0x7e, 15);
            this.linkLabelObracunElementiAdd.Size = size;
            this.linkLabelObracunElementiAdd.Text = " Add ObracunElementi  ";
            this.linkLabelObracunElementiAdd.Click += new EventHandler(this.ObracunElementiAdd_Click);
            this.linkLabelObracunElementiAdd.BackColor = Color.Transparent;
            this.linkLabelObracunElementiAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunElementiAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunElementiAdd.Cursor = Cursors.Hand;
            this.linkLabelObracunElementiAdd.AutoSize = true;
            this.layoutManagerpanelactionsObracunElementi.Controls.Add(this.linkLabelObracunElementiAdd, 0, 0);
            this.layoutManagerpanelactionsObracunElementi.SetColumnSpan(this.linkLabelObracunElementiAdd, 1);
            this.layoutManagerpanelactionsObracunElementi.SetRowSpan(this.linkLabelObracunElementiAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunElementiAdd.Margin = padding;
            size = new System.Drawing.Size(0x7e, 15);
            this.linkLabelObracunElementiAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 15);
            this.linkLabelObracunElementiAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunElementiUpdate.Location = point;
            this.linkLabelObracunElementiUpdate.Name = "linkLabelObracunElementiUpdate";
            size = new System.Drawing.Size(0x90, 15);
            this.linkLabelObracunElementiUpdate.Size = size;
            this.linkLabelObracunElementiUpdate.Text = " Update ObracunElementi  ";
            this.linkLabelObracunElementiUpdate.Click += new EventHandler(this.ObracunElementiUpdate_Click);
            this.linkLabelObracunElementiUpdate.BackColor = Color.Transparent;
            this.linkLabelObracunElementiUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunElementiUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunElementiUpdate.Cursor = Cursors.Hand;
            this.linkLabelObracunElementiUpdate.AutoSize = true;
            this.layoutManagerpanelactionsObracunElementi.Controls.Add(this.linkLabelObracunElementiUpdate, 1, 0);
            this.layoutManagerpanelactionsObracunElementi.SetColumnSpan(this.linkLabelObracunElementiUpdate, 1);
            this.layoutManagerpanelactionsObracunElementi.SetRowSpan(this.linkLabelObracunElementiUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunElementiUpdate.Margin = padding;
            size = new System.Drawing.Size(0x90, 15);
            this.linkLabelObracunElementiUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 15);
            this.linkLabelObracunElementiUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunElementiDelete.Location = point;
            this.linkLabelObracunElementiDelete.Name = "linkLabelObracunElementiDelete";
            size = new System.Drawing.Size(140, 15);
            this.linkLabelObracunElementiDelete.Size = size;
            this.linkLabelObracunElementiDelete.Text = " Delete ObracunElementi  ";
            this.linkLabelObracunElementiDelete.Click += new EventHandler(this.ObracunElementiDelete_Click);
            this.linkLabelObracunElementiDelete.BackColor = Color.Transparent;
            this.linkLabelObracunElementiDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelObracunElementiDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelObracunElementiDelete.Cursor = Cursors.Hand;
            this.linkLabelObracunElementiDelete.AutoSize = true;
            this.layoutManagerpanelactionsObracunElementi.Controls.Add(this.linkLabelObracunElementiDelete, 2, 0);
            this.layoutManagerpanelactionsObracunElementi.SetColumnSpan(this.linkLabelObracunElementiDelete, 1);
            this.layoutManagerpanelactionsObracunElementi.SetRowSpan(this.linkLabelObracunElementiDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunElementiDelete.Margin = padding;
            size = new System.Drawing.Size(140, 15);
            this.linkLabelObracunElementiDelete.MinimumSize = size;
            size = new System.Drawing.Size(140, 15);
            this.linkLabelObracunElementiDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelObracunElementi.Location = point;
            this.linkLabelObracunElementi.Name = "linkLabelObracunElementi";
            this.layoutManagerpanelactionsObracunElementi.Controls.Add(this.linkLabelObracunElementi, 3, 0);
            this.layoutManagerpanelactionsObracunElementi.SetColumnSpan(this.linkLabelObracunElementi, 1);
            this.layoutManagerpanelactionsObracunElementi.SetRowSpan(this.linkLabelObracunElementi, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelObracunElementi.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunElementi.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelObracunElementi.Size = size;
            this.linkLabelObracunElementi.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformObracunRadnici);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceObracunRadnici;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
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
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 1;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 2;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 5;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 6;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 7;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 8;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 9;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 10;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 11;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 12;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 13;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 14;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 15;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x10;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0x11;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x12;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0x13;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 20;
            this.grdLevelObracunDoprinosi.Visible = true;
            this.grdLevelObracunDoprinosi.Name = "grdLevelObracunDoprinosi";
            this.grdLevelObracunDoprinosi.Tag = "ObracunDoprinosi";
            this.grdLevelObracunDoprinosi.TabIndex = 0x38;
            this.grdLevelObracunDoprinosi.Dock = DockStyle.Fill;
            this.grdLevelObracunDoprinosi.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelObracunDoprinosi.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelObracunDoprinosi.DataSource = this.bindingSourceObracunDoprinosi;
            this.grdLevelObracunDoprinosi.Enter += new EventHandler(this.grdLevelObracunDoprinosi_Enter);
            this.grdLevelObracunDoprinosi.AfterRowInsert += new RowEventHandler(this.grdLevelObracunDoprinosi_AfterRowInsert);
            this.grdLevelObracunDoprinosi.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelObracunDoprinosi.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelObracunDoprinosi.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelObracunDoprinosi.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelObracunDoprinosi_DoubleClick);
            this.grdLevelObracunDoprinosi.AfterRowActivate += new EventHandler(this.grdLevelObracunDoprinosi_AfterRowActivate);
            this.grdLevelObracunDoprinosi.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelObracunDoprinosi.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelObracunDoprinosi.DisplayLayout.BandsSerializer.Add(band);
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            column153.CellActivation = Activation.Disabled;
            column153.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column153.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column153.Width = 0x5d;
            column153.Format = "";
            column153.CellAppearance = appearance108;
            column153.Hidden = true;
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            column155.CellActivation = Activation.Disabled;
            column155.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column155.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column155.Width = 0x69;
            column155.Format = "";
            column155.CellAppearance = appearance110;
            column155.Hidden = true;
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            column154.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column154.Header.Caption = StringResources.OBRACUNIDPOREZDescription;
            column154.Width = 0x63;
            appearance109.TextHAlign = HAlign.Right;
            column154.MaskInput = "{LOC}-nnnnn";
            column154.PromptChar = ' ';
            column154.Format = "";
            column154.CellAppearance = appearance109;
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            column159.CellActivation = Activation.Disabled;
            column159.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column159.Header.Caption = StringResources.OBRACUNNAZIVPOREZDescription;
            column159.Width = 0x128;
            column159.Format = "";
            column159.CellAppearance = appearance113;
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            column169.CellActivation = Activation.Disabled;
            column169.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column169.Header.Caption = StringResources.OBRACUNSTOPAPOREZADescription;
            column169.Width = 0x66;
            appearance123.TextHAlign = HAlign.Right;
            column169.MaskInput = "{LOC}-nn.nn";
            column169.PromptChar = ' ';
            column169.Format = "F2";
            column169.CellAppearance = appearance123;
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            column164.CellActivation = Activation.Disabled;
            column164.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column164.Header.Caption = StringResources.OBRACUNPOREZMJESECNODescription;
            column164.Width = 0xd9;
            appearance118.TextHAlign = HAlign.Right;
            column164.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column164.PromptChar = ' ';
            column164.Format = "F2";
            column164.CellAppearance = appearance118;
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            column157.CellActivation = Activation.Disabled;
            column157.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column157.Header.Caption = StringResources.OBRACUNMOPOREZDescription;
            column157.Width = 170;
            column157.Format = "";
            column157.CellAppearance = appearance111;
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            column163.CellActivation = Activation.Disabled;
            column163.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column163.Header.Caption = StringResources.OBRACUNPOPOREZDescription;
            column163.Width = 0xe2;
            column163.Format = "";
            column163.CellAppearance = appearance117;
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            column158.CellActivation = Activation.Disabled;
            column158.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column158.Header.Caption = StringResources.OBRACUNMZPOREZDescription;
            column158.Width = 170;
            column158.Format = "";
            column158.CellAppearance = appearance112;
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            column167.CellActivation = Activation.Disabled;
            column167.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column167.Header.Caption = StringResources.OBRACUNPZPOREZDescription;
            column167.Width = 0xe2;
            column167.Format = "";
            column167.CellAppearance = appearance121;
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            column165.CellActivation = Activation.Disabled;
            column165.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column165.Header.Caption = StringResources.OBRACUNPRIMATELJPOREZ1Description;
            column165.Width = 0x9c;
            column165.Format = "";
            column165.CellAppearance = appearance119;
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            column166.CellActivation = Activation.Disabled;
            column166.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column166.Header.Caption = StringResources.OBRACUNPRIMATELJPOREZ2Description;
            column166.Width = 0x9c;
            column166.Format = "";
            column166.CellAppearance = appearance120;
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            column168.CellActivation = Activation.Disabled;
            column168.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column168.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAPOREZDescription;
            column168.Width = 0xcd;
            column168.Format = "";
            column168.CellAppearance = appearance122;
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            column161.CellActivation = Activation.Disabled;
            column161.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column161.Header.Caption = StringResources.OBRACUNOPISPLACANJAPOREZDescription;
            column161.Width = 0x10c;
            column161.Format = "";
            column161.CellAppearance = appearance115;
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            column160.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column160.Header.Caption = StringResources.OBRACUNOBRACUNATIPOREZDescription;
            column160.Width = 0x7b;
            appearance114.TextHAlign = HAlign.Right;
            column160.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column160.PromptChar = ' ';
            column160.Format = "F2";
            column160.CellAppearance = appearance114;
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            column162.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column162.Header.Caption = StringResources.OBRACUNOSNOVICAPOREZDescription;
            column162.Width = 0x6d;
            appearance116.TextHAlign = HAlign.Right;
            column162.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column162.PromptChar = ' ';
            column162.Format = "F2";
            column162.CellAppearance = appearance116;
            band8.Columns.Add(column154);
            column154.Header.VisiblePosition = 0;
            band8.Columns.Add(column159);
            column159.Header.VisiblePosition = 1;
            band8.Columns.Add(column169);
            column169.Header.VisiblePosition = 2;
            band8.Columns.Add(column164);
            column164.Header.VisiblePosition = 3;
            band8.Columns.Add(column157);
            column157.Header.VisiblePosition = 4;
            band8.Columns.Add(column163);
            column163.Header.VisiblePosition = 5;
            band8.Columns.Add(column158);
            column158.Header.VisiblePosition = 6;
            band8.Columns.Add(column167);
            column167.Header.VisiblePosition = 7;
            band8.Columns.Add(column165);
            column165.Header.VisiblePosition = 8;
            band8.Columns.Add(column166);
            column166.Header.VisiblePosition = 9;
            band8.Columns.Add(column168);
            column168.Header.VisiblePosition = 10;
            band8.Columns.Add(column161);
            column161.Header.VisiblePosition = 11;
            band8.Columns.Add(column160);
            column160.Header.VisiblePosition = 12;
            band8.Columns.Add(column162);
            column162.Header.VisiblePosition = 13;
            band8.Columns.Add(column153);
            column153.Header.VisiblePosition = 14;
            band8.Columns.Add(column155);
            column155.Header.VisiblePosition = 15;
            this.grdLevelObracunPorezi.Visible = true;
            this.grdLevelObracunPorezi.Name = "grdLevelObracunPorezi";
            this.grdLevelObracunPorezi.Tag = "ObracunPorezi";
            this.grdLevelObracunPorezi.TabIndex = 0x38;
            this.grdLevelObracunPorezi.Dock = DockStyle.Fill;
            this.grdLevelObracunPorezi.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelObracunPorezi.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelObracunPorezi.DataSource = this.bindingSourceObracunPorezi;
            this.grdLevelObracunPorezi.Enter += new EventHandler(this.grdLevelObracunPorezi_Enter);
            this.grdLevelObracunPorezi.AfterRowInsert += new RowEventHandler(this.grdLevelObracunPorezi_AfterRowInsert);
            this.grdLevelObracunPorezi.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelObracunPorezi.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelObracunPorezi.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelObracunPorezi.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelObracunPorezi_DoubleClick);
            this.grdLevelObracunPorezi.AfterRowActivate += new EventHandler(this.grdLevelObracunPorezi_AfterRowActivate);
            this.grdLevelObracunPorezi.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelObracunPorezi.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelObracunPorezi.DisplayLayout.BandsSerializer.Add(band8);
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            column131.CellActivation = Activation.Disabled;
            column131.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column131.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column131.Width = 0x5d;
            column131.Format = "";
            column131.CellAppearance = appearance87;
            column131.Hidden = true;
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            column133.CellActivation = Activation.Disabled;
            column133.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column133.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column133.Width = 0x69;
            column133.Format = "";
            column133.CellAppearance = appearance89;
            column133.Hidden = true;
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            column132.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column132.Header.Caption = StringResources.OBRACUNIDOLAKSICEDescription;
            column132.Width = 0x70;
            appearance88.TextHAlign = HAlign.Right;
            column132.MaskInput = "{LOC}-nnnnnnnn";
            column132.PromptChar = ' ';
            column132.Format = "";
            column132.CellAppearance = appearance88;
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            column141.CellActivation = Activation.Disabled;
            column141.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column141.Header.Caption = StringResources.OBRACUNNAZIVOLAKSICEDescription;
            column141.Width = 0x128;
            column141.Format = "";
            column141.CellAppearance = appearance96;
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            column130.CellActivation = Activation.Disabled;
            column130.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column130.Header.Caption = StringResources.OBRACUNIDGRUPEOLAKSICADescription;
            column130.Width = 0x99;
            appearance86.TextHAlign = HAlign.Right;
            column130.MaskInput = "{LOC}-nnnnn";
            column130.PromptChar = ' ';
            column130.Format = "";
            column130.CellAppearance = appearance86;
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            column140.CellActivation = Activation.Disabled;
            column140.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column140.Header.Caption = StringResources.OBRACUNNAZIVGRUPEOLAKSICADescription;
            column140.Width = 0x128;
            column140.Format = "";
            column140.CellAppearance = appearance95;
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            column137.CellActivation = Activation.Disabled;
            column137.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column137.Header.Caption = StringResources.OBRACUNMAXIMALNIIZNOSGRUPEDescription;
            column137.Width = 210;
            appearance92.TextHAlign = HAlign.Right;
            column137.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column137.PromptChar = ' ';
            column137.Format = "F2";
            column137.CellAppearance = appearance92;
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            column135.CellActivation = Activation.Disabled;
            column135.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column135.Header.Caption = StringResources.OBRACUNIDTIPOLAKSICEDescription;
            column135.Width = 0x63;
            appearance90.TextHAlign = HAlign.Right;
            column135.MaskInput = "{LOC}-nnnnn";
            column135.PromptChar = ' ';
            column135.Format = "";
            column135.CellAppearance = appearance90;
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            column142.CellActivation = Activation.Disabled;
            column142.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column142.Header.Caption = StringResources.OBRACUNNAZIVTIPOLAKSICEDescription;
            column142.Width = 0x128;
            column142.Format = "";
            column142.CellAppearance = appearance97;
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            column151.CellActivation = Activation.Disabled;
            column151.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column151.Header.Caption = StringResources.OBRACUNVBDIOLAKSICADescription;
            column151.Width = 0xbf;
            column151.Format = "";
            column151.CellAppearance = appearance106;
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            column152.CellActivation = Activation.Disabled;
            column152.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column152.Header.Caption = StringResources.OBRACUNZRNOLAKSICADescription;
            column152.Width = 0xbf;
            column152.Format = "";
            column152.CellAppearance = appearance107;
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            column146.CellActivation = Activation.Disabled;
            column146.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column146.Header.Caption = StringResources.OBRACUNPRIMATELJOLAKSICA1Description;
            column146.Width = 170;
            column146.Format = "";
            column146.CellAppearance = appearance101;
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            column147.CellActivation = Activation.Disabled;
            column147.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column147.Header.Caption = StringResources.OBRACUNPRIMATELJOLAKSICA2Description;
            column147.Width = 170;
            column147.Format = "";
            column147.CellAppearance = appearance102;
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            column148.CellActivation = Activation.Disabled;
            column148.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column148.Header.Caption = StringResources.OBRACUNPRIMATELJOLAKSICA3Description;
            column148.Width = 170;
            column148.Format = "";
            column148.CellAppearance = appearance103;
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            column139.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column139.Header.Caption = StringResources.OBRACUNMZOLAKSICADescription;
            column139.Width = 0x79;
            column139.Format = "";
            column139.CellAppearance = appearance94;
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            column149.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column149.Header.Caption = StringResources.OBRACUNPZOLAKSICADescription;
            column149.Width = 0xb1;
            column149.Format = "";
            column149.CellAppearance = appearance104;
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            column138.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column138.Header.Caption = StringResources.OBRACUNMOOLAKSICADescription;
            column138.Width = 0xb8;
            column138.Format = "";
            column138.CellAppearance = appearance93;
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            column145.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column145.Header.Caption = StringResources.OBRACUNPOOLAKSICADescription;
            column145.Width = 240;
            column145.Format = "";
            column145.CellAppearance = appearance100;
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            column150.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column150.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAOLAKSICADescription;
            column150.Width = 0xdb;
            column150.Format = "";
            column150.CellAppearance = appearance105;
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            column144.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column144.Header.Caption = StringResources.OBRACUNOPISPLACANJAOLAKSICADescription;
            column144.Width = 0x10c;
            column144.Format = "";
            column144.CellAppearance = appearance99;
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            column136.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column136.Header.Caption = StringResources.OBRACUNIZNOSOLAKSICEDescription;
            column136.Width = 0x74;
            appearance91.TextHAlign = HAlign.Right;
            column136.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column136.PromptChar = ' ';
            column136.Format = "F2";
            column136.CellAppearance = appearance91;
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            column143.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column143.Header.Caption = StringResources.OBRACUNOBRACUNATAOLAKSICADescription;
            column143.Width = 0x8f;
            appearance98.TextHAlign = HAlign.Right;
            column143.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column143.PromptChar = ' ';
            column143.Format = "F2";
            column143.CellAppearance = appearance98;
            band7.Columns.Add(column132);
            column132.Header.VisiblePosition = 0;
            band7.Columns.Add(column141);
            column141.Header.VisiblePosition = 1;
            band7.Columns.Add(column130);
            column130.Header.VisiblePosition = 2;
            band7.Columns.Add(column140);
            column140.Header.VisiblePosition = 3;
            band7.Columns.Add(column137);
            column137.Header.VisiblePosition = 4;
            band7.Columns.Add(column135);
            column135.Header.VisiblePosition = 5;
            band7.Columns.Add(column142);
            column142.Header.VisiblePosition = 6;
            band7.Columns.Add(column151);
            column151.Header.VisiblePosition = 7;
            band7.Columns.Add(column152);
            column152.Header.VisiblePosition = 8;
            band7.Columns.Add(column146);
            column146.Header.VisiblePosition = 9;
            band7.Columns.Add(column147);
            column147.Header.VisiblePosition = 10;
            band7.Columns.Add(column148);
            column148.Header.VisiblePosition = 11;
            band7.Columns.Add(column139);
            column139.Header.VisiblePosition = 12;
            band7.Columns.Add(column149);
            column149.Header.VisiblePosition = 13;
            band7.Columns.Add(column138);
            column138.Header.VisiblePosition = 14;
            band7.Columns.Add(column145);
            column145.Header.VisiblePosition = 15;
            band7.Columns.Add(column150);
            column150.Header.VisiblePosition = 0x10;
            band7.Columns.Add(column144);
            column144.Header.VisiblePosition = 0x11;
            band7.Columns.Add(column136);
            column136.Header.VisiblePosition = 0x12;
            band7.Columns.Add(column143);
            column143.Header.VisiblePosition = 0x13;
            band7.Columns.Add(column131);
            column131.Header.VisiblePosition = 20;
            band7.Columns.Add(column133);
            column133.Header.VisiblePosition = 0x15;
            this.grdLevelObracunOlaksice.Visible = true;
            this.grdLevelObracunOlaksice.Name = "grdLevelObracunOlaksice";
            this.grdLevelObracunOlaksice.Tag = "ObracunOlaksice";
            this.grdLevelObracunOlaksice.TabIndex = 0x38;
            this.grdLevelObracunOlaksice.Dock = DockStyle.Fill;
            this.grdLevelObracunOlaksice.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelObracunOlaksice.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelObracunOlaksice.DataSource = this.bindingSourceObracunOlaksice;
            this.grdLevelObracunOlaksice.Enter += new EventHandler(this.grdLevelObracunOlaksice_Enter);
            this.grdLevelObracunOlaksice.AfterRowInsert += new RowEventHandler(this.grdLevelObracunOlaksice_AfterRowInsert);
            this.grdLevelObracunOlaksice.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelObracunOlaksice.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelObracunOlaksice.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelObracunOlaksice.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelObracunOlaksice_DoubleClick);
            this.grdLevelObracunOlaksice.AfterRowActivate += new EventHandler(this.grdLevelObracunOlaksice_AfterRowActivate);
            this.grdLevelObracunOlaksice.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelObracunOlaksice.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelObracunOlaksice.DisplayLayout.BandsSerializer.Add(band7);
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
            band3.Columns.Add(column44);
            column44.Header.VisiblePosition = 0;
            band3.Columns.Add(column42);
            column42.Header.VisiblePosition = 1;
            band3.Columns.Add(column48);
            column48.Header.VisiblePosition = 2;
            band3.Columns.Add(column61);
            column61.Header.VisiblePosition = 3;
            band3.Columns.Add(column64);
            column64.Header.VisiblePosition = 4;
            band3.Columns.Add(column57);
            column57.Header.VisiblePosition = 5;
            band3.Columns.Add(column58);
            column58.Header.VisiblePosition = 6;
            band3.Columns.Add(column59);
            column59.Header.VisiblePosition = 7;
            band3.Columns.Add(column56);
            column56.Header.VisiblePosition = 8;
            band3.Columns.Add(column53);
            column53.Header.VisiblePosition = 9;
            band3.Columns.Add(column51);
            column51.Header.VisiblePosition = 10;
            band3.Columns.Add(column54);
            column54.Header.VisiblePosition = 11;
            band3.Columns.Add(column52);
            column52.Header.VisiblePosition = 12;
            band3.Columns.Add(column55);
            column55.Header.VisiblePosition = 13;
            band3.Columns.Add(column50);
            column50.Header.VisiblePosition = 14;
            band3.Columns.Add(column49);
            column49.Header.VisiblePosition = 15;
            band3.Columns.Add(column62);
            column62.Header.VisiblePosition = 0x10;
            band3.Columns.Add(column63);
            column63.Header.VisiblePosition = 0x11;
            band3.Columns.Add(column60);
            column60.Header.VisiblePosition = 0x12;
            band3.Columns.Add(column43);
            column43.Header.VisiblePosition = 0x13;
            band3.Columns.Add(column41);
            column41.Header.VisiblePosition = 20;
            band3.Columns.Add(column45);
            column45.Header.VisiblePosition = 0x15;
            band3.Columns.Add(column46);
            column46.Header.VisiblePosition = 0x16;
            this.grdLevelOBRACUNKrediti.Visible = true;
            this.grdLevelOBRACUNKrediti.Name = "grdLevelOBRACUNKrediti";
            this.grdLevelOBRACUNKrediti.Tag = "OBRACUNKrediti";
            this.grdLevelOBRACUNKrediti.TabIndex = 0x38;
            this.grdLevelOBRACUNKrediti.Dock = DockStyle.Fill;
            this.grdLevelOBRACUNKrediti.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelOBRACUNKrediti.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelOBRACUNKrediti.DataSource = this.bindingSourceOBRACUNKrediti;
            this.grdLevelOBRACUNKrediti.Enter += new EventHandler(this.grdLevelOBRACUNKrediti_Enter);
            this.grdLevelOBRACUNKrediti.AfterRowInsert += new RowEventHandler(this.grdLevelOBRACUNKrediti_AfterRowInsert);
            this.grdLevelOBRACUNKrediti.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelOBRACUNKrediti.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelOBRACUNKrediti.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelOBRACUNKrediti.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelOBRACUNKrediti_DoubleClick);
            this.grdLevelOBRACUNKrediti.AfterRowActivate += new EventHandler(this.grdLevelOBRACUNKrediti_AfterRowActivate);
            this.grdLevelOBRACUNKrediti.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelOBRACUNKrediti.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelOBRACUNKrediti.DisplayLayout.BandsSerializer.Add(band3);
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            column104.CellActivation = Activation.Disabled;
            column104.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column104.Header.Caption = StringResources.OBRACUNIDOBRACUNDescription;
            column104.Width = 0x5d;
            column104.Format = "";
            column104.CellAppearance = appearance61;
            column104.Hidden = true;
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            column106.CellActivation = Activation.Disabled;
            column106.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column106.Header.Caption = StringResources.OBRACUNIDRADNIKDescription;
            column106.Width = 0x69;
            column106.Format = "";
            column106.CellAppearance = appearance63;
            column106.Hidden = true;
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            column105.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column105.Header.Caption = StringResources.OBRACUNIDOBUSTAVADescription;
            column105.Width = 0x70;
            appearance62.TextHAlign = HAlign.Right;
            column105.MaskInput = "{LOC}-nnnnnnnn";
            column105.PromptChar = ' ';
            column105.Format = "";
            column105.CellAppearance = appearance62;
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            column112.CellActivation = Activation.Disabled;
            column112.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column112.Header.Caption = StringResources.OBRACUNNAZIVOBUSTAVADescription;
            column112.Width = 0x128;
            column112.Format = "";
            column112.CellAppearance = appearance68;
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            column110.CellActivation = Activation.Disabled;
            column110.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column110.Header.Caption = StringResources.OBRACUNMOOBUSTAVADescription;
            column110.Width = 0x79;
            column110.Format = "";
            column110.CellAppearance = appearance66;
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            column119.CellActivation = Activation.Disabled;
            column119.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column119.Header.Caption = StringResources.OBRACUNPOOBUSTAVADescription;
            column119.Width = 240;
            column119.Format = "";
            column119.CellAppearance = appearance75;
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            column111.CellActivation = Activation.Disabled;
            column111.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column111.Header.Caption = StringResources.OBRACUNMZOBUSTAVADescription;
            column111.Width = 0xb8;
            column111.Format = "";
            column111.CellAppearance = appearance67;
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            column124.CellActivation = Activation.Disabled;
            column124.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column124.Header.Caption = StringResources.OBRACUNPZOBUSTAVADescription;
            column124.Width = 240;
            column124.Format = "";
            column124.CellAppearance = appearance80;
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            column127.CellActivation = Activation.Disabled;
            column127.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column127.Header.Caption = StringResources.OBRACUNVBDIOBUSTAVADescription;
            column127.Width = 0xbf;
            column127.Format = "";
            column127.CellAppearance = appearance83;
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            column129.CellActivation = Activation.Disabled;
            column129.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column129.Header.Caption = StringResources.OBRACUNZRNOBUSTAVADescription;
            column129.Width = 0xbf;
            column129.Format = "";
            column129.CellAppearance = appearance85;
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            column121.CellActivation = Activation.Disabled;
            column121.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column121.Header.Caption = StringResources.OBRACUNPRIMATELJOBUSTAVA1Description;
            column121.Width = 0x9c;
            column121.Format = "";
            column121.CellAppearance = appearance77;
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            column122.CellActivation = Activation.Disabled;
            column122.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column122.Header.Caption = StringResources.OBRACUNPRIMATELJOBUSTAVA2Description;
            column122.Width = 0x9c;
            column122.Format = "";
            column122.CellAppearance = appearance78;
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            column123.CellActivation = Activation.Disabled;
            column123.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column123.Header.Caption = StringResources.OBRACUNPRIMATELJOBUSTAVA3Description;
            column123.Width = 0x9c;
            column123.Format = "";
            column123.CellAppearance = appearance79;
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            column126.CellActivation = Activation.Disabled;
            column126.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column126.Header.Caption = StringResources.OBRACUNSIFRAOPISAPLACANJAOBUSTAVADescription;
            column126.Width = 0x9c;
            column126.Format = "";
            column126.CellAppearance = appearance82;
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            column118.CellActivation = Activation.Disabled;
            column118.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column118.Header.Caption = StringResources.OBRACUNOPISPLACANJAOBUSTAVADescription;
            column118.Width = 0x10c;
            column118.Format = "";
            column118.CellAppearance = appearance74;
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            column128.CellActivation = Activation.Disabled;
            column128.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column128.Header.Caption = StringResources.OBRACUNVRSTAOBUSTAVEDescription;
            column128.Width = 0x70;
            appearance84.TextHAlign = HAlign.Right;
            column128.MaskInput = "{LOC}-nn";
            column128.PromptChar = ' ';
            column128.Format = "";
            column128.CellAppearance = appearance84;
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            column113.CellActivation = Activation.Disabled;
            column113.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column113.Header.Caption = StringResources.OBRACUNNAZIVVRSTAOBUSTAVEDescription;
            column113.Width = 0x128;
            column113.Format = "";
            column113.CellAppearance = appearance69;
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            column109.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column109.Header.Caption = StringResources.OBRACUNIZNOSOBUSTAVEDescription;
            column109.Width = 0x6d;
            appearance65.TextHAlign = HAlign.Right;
            column109.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column109.PromptChar = ' ';
            column109.Format = "F2";
            column109.CellAppearance = appearance65;
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            column120.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column120.Header.Caption = StringResources.OBRACUNPOSTOTAKOBUSTAVEDescription;
            column120.Width = 0x81;
            appearance76.TextHAlign = HAlign.Right;
            column120.MaskInput = "{LOC}-nnn.nn";
            column120.PromptChar = ' ';
            column120.Format = "F2";
            column120.CellAppearance = appearance76;
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            column114.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column114.Header.Caption = StringResources.OBRACUNOBRACUNATAOBUSTAVAUKUNAMADescription;
            column114.Width = 190;
            appearance70.TextHAlign = HAlign.Right;
            column114.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column114.PromptChar = ' ';
            column114.Format = "F2";
            column114.CellAppearance = appearance70;
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            column108.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column108.Header.Caption = StringResources.OBRACUNISPLACENOKASADescription;
            column108.Width = 0x6d;
            appearance64.TextHAlign = HAlign.Right;
            column108.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column108.PromptChar = ' ';
            column108.Format = "F2";
            column108.CellAppearance = appearance64;
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            column125.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column125.Header.Caption = StringResources.OBRACUNSALDOKASADescription;
            column125.Width = 0x66;
            appearance81.TextHAlign = HAlign.Right;
            column125.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column125.PromptChar = ' ';
            column125.Format = "F2";
            column125.CellAppearance = appearance81;
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            column115.CellActivation = Activation.Disabled;
            column115.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column115.Header.Caption = StringResources.OBRACUNOBUSTAVLJENODOSADADescription;
            column115.Width = 0x8f;
            appearance72.TextHAlign = HAlign.Right;
            column115.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column115.PromptChar = ' ';
            column115.Format = "F2";
            column115.CellAppearance = appearance72;
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            column116.CellActivation = Activation.Disabled;
            column116.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column116.Header.Caption = StringResources.OBRACUNOBUSTAVLJENODOSADABROJRATADescription;
            column116.Width = 0xc5;
            appearance71.TextHAlign = HAlign.Right;
            column116.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column116.PromptChar = ' ';
            column116.Format = "F2";
            column116.CellAppearance = appearance71;
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            column117.CellActivation = Activation.Disabled;
            column117.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column117.Header.Caption = StringResources.OBRACUNOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEDescription;
            column117.Width = 0x123;
            appearance73.TextHAlign = HAlign.Right;
            column117.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column117.PromptChar = ' ';
            column117.Format = "F2";
            column117.CellAppearance = appearance73;
            band6.Columns.Add(column105);
            column105.Header.VisiblePosition = 0;
            band6.Columns.Add(column112);
            column112.Header.VisiblePosition = 1;
            band6.Columns.Add(column110);
            column110.Header.VisiblePosition = 2;
            band6.Columns.Add(column119);
            column119.Header.VisiblePosition = 3;
            band6.Columns.Add(column111);
            column111.Header.VisiblePosition = 4;
            band6.Columns.Add(column124);
            column124.Header.VisiblePosition = 5;
            band6.Columns.Add(column127);
            column127.Header.VisiblePosition = 6;
            band6.Columns.Add(column129);
            column129.Header.VisiblePosition = 7;
            band6.Columns.Add(column121);
            column121.Header.VisiblePosition = 8;
            band6.Columns.Add(column122);
            column122.Header.VisiblePosition = 9;
            band6.Columns.Add(column123);
            column123.Header.VisiblePosition = 10;
            band6.Columns.Add(column126);
            column126.Header.VisiblePosition = 11;
            band6.Columns.Add(column118);
            column118.Header.VisiblePosition = 12;
            band6.Columns.Add(column128);
            column128.Header.VisiblePosition = 13;
            band6.Columns.Add(column113);
            column113.Header.VisiblePosition = 14;
            band6.Columns.Add(column109);
            column109.Header.VisiblePosition = 15;
            band6.Columns.Add(column120);
            column120.Header.VisiblePosition = 0x10;
            band6.Columns.Add(column114);
            column114.Header.VisiblePosition = 0x11;
            band6.Columns.Add(column108);
            column108.Header.VisiblePosition = 0x12;
            band6.Columns.Add(column125);
            column125.Header.VisiblePosition = 0x13;
            band6.Columns.Add(column115);
            column115.Header.VisiblePosition = 20;
            band6.Columns.Add(column116);
            column116.Header.VisiblePosition = 0x15;
            band6.Columns.Add(column117);
            column117.Header.VisiblePosition = 0x16;
            band6.Columns.Add(column104);
            column104.Header.VisiblePosition = 0x17;
            band6.Columns.Add(column106);
            column106.Header.VisiblePosition = 0x18;
            this.grdLevelOBRACUNObustave.Visible = true;
            this.grdLevelOBRACUNObustave.Name = "grdLevelOBRACUNObustave";
            this.grdLevelOBRACUNObustave.Tag = "OBRACUNObustave";
            this.grdLevelOBRACUNObustave.TabIndex = 0x38;
            this.grdLevelOBRACUNObustave.Dock = DockStyle.Fill;
            this.grdLevelOBRACUNObustave.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelOBRACUNObustave.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelOBRACUNObustave.DataSource = this.bindingSourceOBRACUNObustave;
            this.grdLevelOBRACUNObustave.Enter += new EventHandler(this.grdLevelOBRACUNObustave_Enter);
            this.grdLevelOBRACUNObustave.AfterRowInsert += new RowEventHandler(this.grdLevelOBRACUNObustave_AfterRowInsert);
            this.grdLevelOBRACUNObustave.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelOBRACUNObustave.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelOBRACUNObustave.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelOBRACUNObustave.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelOBRACUNObustave_DoubleClick);
            this.grdLevelOBRACUNObustave.AfterRowActivate += new EventHandler(this.grdLevelOBRACUNObustave_AfterRowActivate);
            this.grdLevelOBRACUNObustave.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelOBRACUNObustave.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelOBRACUNObustave.DisplayLayout.BandsSerializer.Add(band6);
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
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 0;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 1;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 2;
            band2.Columns.Add(column28);
            column28.Header.VisiblePosition = 3;
            band2.Columns.Add(column33);
            column33.Header.VisiblePosition = 4;
            band2.Columns.Add(column39);
            column39.Header.VisiblePosition = 5;
            band2.Columns.Add(column37);
            column37.Header.VisiblePosition = 6;
            band2.Columns.Add(column38);
            column38.Header.VisiblePosition = 7;
            band2.Columns.Add(column35);
            column35.Header.VisiblePosition = 8;
            band2.Columns.Add(column32);
            column32.Header.VisiblePosition = 9;
            band2.Columns.Add(column31);
            column31.Header.VisiblePosition = 10;
            band2.Columns.Add(column34);
            column34.Header.VisiblePosition = 11;
            band2.Columns.Add(column36);
            column36.Header.VisiblePosition = 12;
            band2.Columns.Add(column40);
            column40.Header.VisiblePosition = 13;
            band2.Columns.Add(column27);
            column27.Header.VisiblePosition = 14;
            band2.Columns.Add(column29);
            column29.Header.VisiblePosition = 15;
            this.grdLevelObracunElementi.Visible = true;
            this.grdLevelObracunElementi.Name = "grdLevelObracunElementi";
            this.grdLevelObracunElementi.Tag = "ObracunElementi";
            this.grdLevelObracunElementi.TabIndex = 0x38;
            this.grdLevelObracunElementi.Dock = DockStyle.Fill;
            this.grdLevelObracunElementi.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelObracunElementi.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelObracunElementi.DataSource = this.bindingSourceObracunElementi;
            this.grdLevelObracunElementi.Enter += new EventHandler(this.grdLevelObracunElementi_Enter);
            this.grdLevelObracunElementi.AfterRowInsert += new RowEventHandler(this.grdLevelObracunElementi_AfterRowInsert);
            this.grdLevelObracunElementi.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelObracunElementi.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelObracunElementi.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelObracunElementi.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelObracunElementi_DoubleClick);
            this.grdLevelObracunElementi.AfterRowActivate += new EventHandler(this.grdLevelObracunElementi_AfterRowActivate);
            this.grdLevelObracunElementi.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelObracunElementi.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelObracunElementi.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "OBRACUNFormObracunRadniciUserControl";
            this.Text = " OBRACUNLevel1";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OBRACUNFormUserControl_Load);
            this.layoutManagerformObracunRadnici.ResumeLayout(false);
            this.layoutManagerformObracunRadnici.PerformLayout();
            ((ISupportInitialize) this.bindingSourceObracunRadnici).EndInit();
            ((ISupportInitialize) this.bindingSourceObracunDoprinosi).EndInit();
            ((ISupportInitialize) this.bindingSourceObracunPorezi).EndInit();
            ((ISupportInitialize) this.bindingSourceObracunOlaksice).EndInit();
            ((ISupportInitialize) this.bindingSourceOBRACUNKrediti).EndInit();
            ((ISupportInitialize) this.bindingSourceOBRACUNObustave).EndInit();
            ((ISupportInitialize) this.bindingSourceObracunElementi).EndInit();
            ((ISupportInitialize) this.bindingSourceOBRACUNOBRACUNLevel1ObracunKrizni).EndInit();
            ((ISupportInitialize) this.bindingSourceOBRACUNOBRACUNLevel1ObracunIzuzece).EndInit();
            ((ISupportInitialize) this.textSIFRAOPCINESTANOVANJA).EndInit();
            ((ISupportInitialize) this.textOBRACUNSKIKOEFICIJENT).EndInit();
            ((ISupportInitialize) this.textOBRACUNATIPRIREZ).EndInit();
            ((ISupportInitialize) this.textISKORISTENOOO).EndInit();
            ((ISupportInitialize) this.textfaktoo).EndInit();
            ((ISupportInitialize) this.grdLevelObracunDoprinosi).EndInit();
            this.panelactionsObracunDoprinosi.ResumeLayout(true);
            this.panelactionsObracunDoprinosi.PerformLayout();
            this.layoutManagerpanelactionsObracunDoprinosi.ResumeLayout(false);
            this.layoutManagerpanelactionsObracunDoprinosi.PerformLayout();
            ((ISupportInitialize) this.grdLevelObracunPorezi).EndInit();
            this.panelactionsObracunPorezi.ResumeLayout(true);
            this.panelactionsObracunPorezi.PerformLayout();
            this.layoutManagerpanelactionsObracunPorezi.ResumeLayout(false);
            this.layoutManagerpanelactionsObracunPorezi.PerformLayout();
            ((ISupportInitialize) this.grdLevelObracunOlaksice).EndInit();
            this.panelactionsObracunOlaksice.ResumeLayout(true);
            this.panelactionsObracunOlaksice.PerformLayout();
            this.layoutManagerpanelactionsObracunOlaksice.ResumeLayout(false);
            this.layoutManagerpanelactionsObracunOlaksice.PerformLayout();
            ((ISupportInitialize) this.grdLevelOBRACUNKrediti).EndInit();
            this.panelactionsOBRACUNKrediti.ResumeLayout(true);
            this.panelactionsOBRACUNKrediti.PerformLayout();
            this.layoutManagerpanelactionsOBRACUNKrediti.ResumeLayout(false);
            this.layoutManagerpanelactionsOBRACUNKrediti.PerformLayout();
            ((ISupportInitialize) this.grdLevelOBRACUNObustave).EndInit();
            this.panelactionsOBRACUNObustave.ResumeLayout(true);
            this.panelactionsOBRACUNObustave.PerformLayout();
            this.layoutManagerpanelactionsOBRACUNObustave.ResumeLayout(false);
            this.layoutManagerpanelactionsOBRACUNObustave.PerformLayout();
            ((ISupportInitialize) this.grdLevelObracunElementi).EndInit();
            this.panelactionsObracunElementi.ResumeLayout(true);
            this.panelactionsObracunElementi.PerformLayout();
            this.layoutManagerpanelactionsObracunElementi.ResumeLayout(false);
            this.layoutManagerpanelactionsObracunElementi.PerformLayout();
            this.dsOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this))
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
            this.label1IDRADNIK.Text = StringResources.OBRACUNIDRADNIKDescription;
            this.label1PREZIME.Text = StringResources.OBRACUNPREZIMEDescription;
            this.label1IME.Text = StringResources.OBRACUNIMEDescription;
            this.label1JMBG.Text = StringResources.OBRACUNJMBGDescription;
            this.label1SIFRAOPCINESTANOVANJA.Text = StringResources.OBRACUNSIFRAOPCINESTANOVANJADescription;
            this.label1KOEFICIJENT.Text = StringResources.OBRACUNKOEFICIJENTDescription;
            this.label1OBRACUNSKIKOEFICIJENT.Text = StringResources.OBRACUNOBRACUNSKIKOEFICIJENTDescription;
            this.label1OBRACUNATIPRIREZ.Text = StringResources.OBRACUNOBRACUNATIPRIREZDescription;
            this.label1ISKORISTENOOO.Text = StringResources.OBRACUNISKORISTENOOODescription;
            this.label1faktoo.Text = StringResources.OBRACUNfaktooDescription;
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

        private void ObracunDoprinosiAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelObracunDoprinosi.ActiveRow;
            this.ObracunDoprinosiInsert();
        }

        private void ObracunDoprinosiDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunDoprinosi);
            if ((currentRowListIndex != -1) && (this.grdLevelObracunDoprinosi.Selected.Rows.Count > 0))
            {
                this.grdLevelObracunDoprinosi.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelObracunDoprinosi).Selected = true;
                this.grdLevelObracunDoprinosi.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunDoprinosiInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this))
            {
                this.OBRACUNController.AddObracunDoprinosi(this.m_CurrentRow);
            }
        }

        private void ObracunDoprinosiUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunDoprinosi) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelObracunDoprinosi);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OBRACUNController.UpdateObracunDoprinosi(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunDoprinosiUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelObracunDoprinosi.ActiveRow != null)
            {
                this.ObracunDoprinosiUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunElementiAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelObracunElementi.ActiveRow;
            this.ObracunElementiInsert();
        }

        private void ObracunElementiDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunElementi);
            if ((currentRowListIndex != -1) && (this.grdLevelObracunElementi.Selected.Rows.Count > 0))
            {
                this.grdLevelObracunElementi.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelObracunElementi).Selected = true;
                this.grdLevelObracunElementi.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
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
            CreateValueList(this.grdLevelObracunElementi, "ELEMENTIDELEMENT", enumList, "IDELEMENT", "EL", true);
        }

        private void ObracunElementiInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this))
            {
                this.OBRACUNController.AddObracunElementi(this.m_CurrentRow);
            }
        }

        private void ObracunElementiUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunElementi) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelObracunElementi);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OBRACUNController.UpdateObracunElementi(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunElementiUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelObracunElementi.ActiveRow != null)
            {
                this.ObracunElementiUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void OBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OBRACUNObracunRadniciLevelDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelObracunDoprinosiAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OBRACUNObracunDoprinosiLevelDescription;
            this.linkLabelObracunDoprinosiUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OBRACUNObracunDoprinosiLevelDescription;
            this.linkLabelObracunDoprinosiDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OBRACUNObracunDoprinosiLevelDescription;
            this.linkLabelObracunPoreziAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OBRACUNObracunPoreziLevelDescription;
            this.linkLabelObracunPoreziUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OBRACUNObracunPoreziLevelDescription;
            this.linkLabelObracunPoreziDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OBRACUNObracunPoreziLevelDescription;
            this.linkLabelObracunOlaksiceAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OBRACUNObracunOlaksiceLevelDescription;
            this.linkLabelObracunOlaksiceUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OBRACUNObracunOlaksiceLevelDescription;
            this.linkLabelObracunOlaksiceDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OBRACUNObracunOlaksiceLevelDescription;
            this.linkLabelOBRACUNKreditiAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OBRACUNOBRACUNKreditiLevelDescription;
            this.linkLabelOBRACUNKreditiUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OBRACUNOBRACUNKreditiLevelDescription;
            this.linkLabelOBRACUNKreditiDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OBRACUNOBRACUNKreditiLevelDescription;
            this.linkLabelOBRACUNObustaveAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OBRACUNOBRACUNObustaveLevelDescription;
            this.linkLabelOBRACUNObustaveUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OBRACUNOBRACUNObustaveLevelDescription;
            this.linkLabelOBRACUNObustaveDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OBRACUNOBRACUNObustaveLevelDescription;
            this.linkLabelObracunElementiAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OBRACUNObracunElementiLevelDescription;
            this.linkLabelObracunElementiUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OBRACUNObracunElementiLevelDescription;
            this.linkLabelObracunElementiDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OBRACUNObracunElementiLevelDescription;
        }

        private void OBRACUNKreditiAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelOBRACUNKrediti.ActiveRow;
            this.OBRACUNKreditiInsert();
        }

        private void OBRACUNKreditiDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelOBRACUNKrediti);
            if ((currentRowListIndex != -1) && (this.grdLevelOBRACUNKrediti.Selected.Rows.Count > 0))
            {
                this.grdLevelOBRACUNKrediti.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelOBRACUNKrediti).Selected = true;
                this.grdLevelOBRACUNKrediti.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void OBRACUNKreditiInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this))
            {
                this.OBRACUNController.AddOBRACUNKrediti(this.m_CurrentRow);
            }
        }

        private void OBRACUNKreditiUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelOBRACUNKrediti) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelOBRACUNKrediti);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OBRACUNController.UpdateOBRACUNKrediti(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void OBRACUNKreditiUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelOBRACUNKrediti.ActiveRow != null)
            {
                this.OBRACUNKreditiUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void OBRACUNObustaveAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelOBRACUNObustave.ActiveRow;
            this.OBRACUNObustaveInsert();
        }

        private void OBRACUNObustaveDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelOBRACUNObustave);
            if ((currentRowListIndex != -1) && (this.grdLevelOBRACUNObustave.Selected.Rows.Count > 0))
            {
                this.grdLevelOBRACUNObustave.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelOBRACUNObustave).Selected = true;
                this.grdLevelOBRACUNObustave.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void OBRACUNObustaveInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this))
            {
                this.OBRACUNController.AddOBRACUNObustave(this.m_CurrentRow);
            }
        }

        private void OBRACUNObustaveUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelOBRACUNObustave) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelOBRACUNObustave);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OBRACUNController.UpdateOBRACUNObustave(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void OBRACUNObustaveUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelOBRACUNObustave.ActiveRow != null)
            {
                this.OBRACUNObustaveUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunOlaksiceAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelObracunOlaksice.ActiveRow;
            this.ObracunOlaksiceInsert();
        }

        private void ObracunOlaksiceDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunOlaksice);
            if ((currentRowListIndex != -1) && (this.grdLevelObracunOlaksice.Selected.Rows.Count > 0))
            {
                this.grdLevelObracunOlaksice.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelObracunOlaksice).Selected = true;
                this.grdLevelObracunOlaksice.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunOlaksiceInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this))
            {
                this.OBRACUNController.AddObracunOlaksice(this.m_CurrentRow);
            }
        }

        private void ObracunOlaksiceUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunOlaksice) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelObracunOlaksice);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OBRACUNController.UpdateObracunOlaksice(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunOlaksiceUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelObracunOlaksice.ActiveRow != null)
            {
                this.ObracunOlaksiceUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunPoreziAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelObracunPorezi.ActiveRow;
            this.ObracunPoreziInsert();
        }

        private void ObracunPoreziDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunPorezi);
            if ((currentRowListIndex != -1) && (this.grdLevelObracunPorezi.Selected.Rows.Count > 0))
            {
                this.grdLevelObracunPorezi.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelObracunPorezi).Selected = true;
                this.grdLevelObracunPorezi.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunPoreziInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceObracunRadnici, this.OBRACUNController.WorkItem, this))
            {
                this.OBRACUNController.AddObracunPorezi(this.m_CurrentRow);
            }
        }

        private void ObracunPoreziUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelObracunPorezi) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelObracunPorezi);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OBRACUNController.UpdateObracunPorezi(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ObracunPoreziUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelObracunPorezi.ActiveRow != null)
            {
                this.ObracunPoreziUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PictureBoxClickedIDRADNIK(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNIK", null, DeklaritMode.Insert));
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

        private void RegisterBindingSources()
        {
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunRadnici|ObracunRadnici"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunRadnici, "ObracunRadnici|ObracunRadnici");
            }
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunRadnici|ObracunDoprinosi"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunDoprinosi, "ObracunRadnici|ObracunDoprinosi");
            }
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunRadnici|ObracunPorezi"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunPorezi, "ObracunRadnici|ObracunPorezi");
            }
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunRadnici|ObracunOlaksice"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunOlaksice, "ObracunRadnici|ObracunOlaksice");
            }
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunRadnici|OBRACUNKrediti"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceOBRACUNKrediti, "ObracunRadnici|OBRACUNKrediti");
            }
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunRadnici|OBRACUNObustave"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceOBRACUNObustave, "ObracunRadnici|OBRACUNObustave");
            }
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunRadnici|ObracunElementi"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunElementi, "ObracunRadnici|ObracunElementi");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("ObracunRadniciSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDRADNIK(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDRADNIK.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDRADNIK.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDRADNIK"] = RuntimeHelpers.GetObjectValue(row["IDRADNIK"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["PREZIME"] = RuntimeHelpers.GetObjectValue(row["PREZIME"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IME"] = RuntimeHelpers.GetObjectValue(row["IME"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["ulica"] = RuntimeHelpers.GetObjectValue(row["ulica"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["mjesto"] = RuntimeHelpers.GetObjectValue(row["mjesto"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["kucnibroj"] = RuntimeHelpers.GetObjectValue(row["kucnibroj"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["JMBG"] = RuntimeHelpers.GetObjectValue(row["JMBG"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(row["DATUMRODJENJA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["TEKUCI"] = RuntimeHelpers.GetObjectValue(row["TEKUCI"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(row["SIFRAOPISAPLACANJANETO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(row["OPISPLACANJANETO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(row["BROJMIROVINSKOG"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(row["BROJZDRAVSTVENOG"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["MBO"] = RuntimeHelpers.GetObjectValue(row["MBO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(row["POSTOTAKOSLOBODJENJAODPOREZA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(row["KOEFICIJENT"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["AKTIVAN"] = RuntimeHelpers.GetObjectValue(row["AKTIVAN"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(row["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(row["TJEDNIFONDSATI"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(row["TJEDNIFONDSATISTAZ"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(row["GODINESTAZA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(row["MJESECISTAZA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["DANISTAZA"] = RuntimeHelpers.GetObjectValue(row["DANISTAZA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(row["DATUMPRESTANKARADNOGODNOSA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(row["ZBIRNINETO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(row["UZIMAUOBZIROSNOVICEDOPRINOSA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(row["IDIPIDENT"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["OIB"] = RuntimeHelpers.GetObjectValue(row["OIB"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDBANKE"] = RuntimeHelpers.GetObjectValue(row["IDBANKE"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(row["IDBENEFICIRANI"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDTITULA"] = RuntimeHelpers.GetObjectValue(row["IDTITULA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(row["IDRADNOMJESTO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(row["IDSTRUKA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["IDORGDIO"] = RuntimeHelpers.GetObjectValue(row["IDORGDIO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(row["OPCINARADAIDOPCINE"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(row["OPCINASTANOVANJAIDOPCINE"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(row["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(row["NAZIVBANKE1"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(row["NAZIVBANKE2"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(row["NAZIVBANKE3"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(row["VBDIBANKE"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(row["ZRNBANKE"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(row["NAZIVBENEFICIRANI"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(row["BROJPRIZNATIHMJESECI"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(row["NAZIVTITULA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(row["NAZIVRADNOMJESTO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(row["NAZIVSTRUKA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(row["ORGANIZACIJSKIDIO"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(row["OPCINARADANAZIVOPCINE"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(row["OPCINASTANOVANJANAZIVOPCINE"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(row["OPCINASTANOVANJAPRIREZ"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(row["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"]);
                    ((DataRowView) this.bindingSourceObracunRadnici.Current).Row["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"]);
                    this.bindingSourceObracunRadnici.ResetCurrentItem();
                }
            }
        }

        private void SetComboBoxColumnProperties()
        {
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelObracunDoprinosi, "IDDOPRINOS");
            gridColumn.Tag = "DOPRINOSIDDOPRINOS";
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            gridColumn.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelObracunDoprinosi.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelObracunDoprinosi.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column6 = FormHelperClass.GetGridColumn(this.grdLevelObracunPorezi, "IDPOREZ");
            column6.Tag = "POREZIDPOREZ";
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelObracunPorezi.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelObracunPorezi.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelObracunOlaksice, "IDOLAKSICE");
            column5.Tag = "OLAKSICEIDOLAKSICE";
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelObracunOlaksice.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelObracunOlaksice.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelOBRACUNKrediti, "IDKREDITOR");
            column3.Tag = "KREDITORIDKREDITOR";
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelOBRACUNKrediti.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelOBRACUNKrediti.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column4 = FormHelperClass.GetGridColumn(this.grdLevelOBRACUNObustave, "IDOBUSTAVA");
            column4.Tag = "OBUSTAVAIDOBUSTAVA";
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelOBRACUNObustave.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelOBRACUNObustave.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            DataSet dataSet = new ELEMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetELEMENTDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["ELEMENT"]) {
                Sort = "EL"
            };
            CreateValueList(this.grdLevelObracunElementi, "ELEMENTIDELEMENT", enumList, "IDELEMENT", "EL", false);
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelObracunElementi, "IDELEMENT");
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.grdLevelObracunElementi.DisplayLayout.ValueLists["ELEMENTIDELEMENT"];
            column2.Width = 370;
            this.grdLevelObracunElementi.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelObracunElementi.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.comboIDRADNIK.Focus();
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

        [LocalCommandHandler("ViewRSMA")]
        public void ViewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.ViewRSMA(this.m_CurrentRow);
            }
        }

        protected virtual PregledRadnikaComboBox comboIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDRADNIK = value;
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

        protected virtual UltraGrid grdLevelObracunDoprinosi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelObracunDoprinosi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelObracunDoprinosi = value;
            }
        }

        protected virtual UltraGrid grdLevelObracunElementi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelObracunElementi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelObracunElementi = value;
            }
        }

        protected virtual UltraGrid grdLevelOBRACUNKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelOBRACUNKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelOBRACUNKrediti = value;
            }
        }

        protected virtual UltraGrid grdLevelOBRACUNObustave
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelOBRACUNObustave;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelOBRACUNObustave = value;
            }
        }

        protected virtual UltraGrid grdLevelObracunOlaksice
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelObracunOlaksice;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelObracunOlaksice = value;
            }
        }

        protected virtual UltraGrid grdLevelObracunPorezi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelObracunPorezi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelObracunPorezi = value;
            }
        }

        protected virtual UltraLabel label1faktoo
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1faktoo;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1faktoo = value;
            }
        }

        protected virtual UltraLabel label1IDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNIK = value;
            }
        }

        protected virtual UltraLabel label1IME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IME = value;
            }
        }

        protected virtual UltraLabel label1ISKORISTENOOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ISKORISTENOOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ISKORISTENOOO = value;
            }
        }

        protected virtual UltraLabel label1JMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1JMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1JMBG = value;
            }
        }

        protected virtual UltraLabel label1KOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KOEFICIJENT = value;
            }
        }

        protected virtual UltraLabel label1OBRACUNATIPRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRACUNATIPRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRACUNATIPRIREZ = value;
            }
        }

        protected virtual UltraLabel label1OBRACUNSKIKOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRACUNSKIKOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRACUNSKIKOEFICIJENT = value;
            }
        }

        protected virtual UltraLabel label1PREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PREZIME = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPCINESTANOVANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPCINESTANOVANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPCINESTANOVANJA = value;
            }
        }

        protected virtual UltraLabel labelIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIME = value;
            }
        }

        protected virtual UltraLabel labelJMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelJMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelJMBG = value;
            }
        }

        protected virtual UltraLabel labelKOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelKOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelKOEFICIJENT = value;
            }
        }

        protected virtual UltraLabel labelPREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPREZIME = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunDoprinosi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunDoprinosi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunDoprinosi = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunDoprinosiAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunDoprinosiAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunDoprinosiAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunDoprinosiDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunDoprinosiDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunDoprinosiDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunDoprinosiUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunDoprinosiUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunDoprinosiUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunElementi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunElementi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunElementi = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunElementiAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunElementiAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunElementiAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunElementiDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunElementiDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunElementiDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunElementiUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunElementiUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunElementiUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNKrediti = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNKreditiAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNKreditiAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNKreditiAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNKreditiDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNKreditiDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNKreditiDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNKreditiUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNKreditiUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNKreditiUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNObustave
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNObustave;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNObustave = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNObustaveAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNObustaveAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNObustaveAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNObustaveDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNObustaveDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNObustaveDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelOBRACUNObustaveUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelOBRACUNObustaveUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelOBRACUNObustaveUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunOlaksice
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunOlaksice;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunOlaksice = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunOlaksiceAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunOlaksiceAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunOlaksiceAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunOlaksiceDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunOlaksiceDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunOlaksiceDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunOlaksiceUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunOlaksiceUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunOlaksiceUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunPorezi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunPorezi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunPorezi = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunPoreziAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunPoreziAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunPoreziAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunPoreziDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunPoreziDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunPoreziDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelObracunPoreziUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelObracunPoreziUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelObracunPoreziUpdate = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.OBRACUNController OBRACUNController { get; set; }

        protected virtual Panel panelactionsObracunDoprinosi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsObracunDoprinosi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsObracunDoprinosi = value;
            }
        }

        protected virtual Panel panelactionsObracunElementi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsObracunElementi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsObracunElementi = value;
            }
        }

        protected virtual Panel panelactionsOBRACUNKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsOBRACUNKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsOBRACUNKrediti = value;
            }
        }

        protected virtual Panel panelactionsOBRACUNObustave
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsOBRACUNObustave;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsOBRACUNObustave = value;
            }
        }

        protected virtual Panel panelactionsObracunOlaksice
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsObracunOlaksice;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsObracunOlaksice = value;
            }
        }

        protected virtual Panel panelactionsObracunPorezi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsObracunPorezi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsObracunPorezi = value;
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

        protected virtual UltraNumericEditor textfaktoo
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textfaktoo;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textfaktoo = value;
            }
        }

        protected virtual UltraNumericEditor textISKORISTENOOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textISKORISTENOOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textISKORISTENOOO = value;
            }
        }

        protected virtual UltraNumericEditor textOBRACUNATIPRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRACUNATIPRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRACUNATIPRIREZ = value;
            }
        }

        protected virtual UltraNumericEditor textOBRACUNSKIKOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRACUNSKIKOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRACUNSKIKOEFICIJENT = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPCINESTANOVANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPCINESTANOVANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPCINESTANOVANJA = value;
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

