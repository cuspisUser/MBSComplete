using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using EVModule.Ev;
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


namespace EVModule.EvModule
{

    [SmartPart]
    public class EvidencijaCustom : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private int BROJEVIDENCIJE;
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private EVIDENCIJADataAdapter daevidencija;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private int godina;
        private SmartPartInfoProvider infoProvider;
        private bool m_bDisablePosCHange;
        
        private int mjesec;
        private SmartPartInfo smartPartInfo1;

        public EvidencijaCustom()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.daevidencija = new EVIDENCIJADataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Evidencija radnog vremena", "PripremaPlace");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public int Broj_Oznacenih()
        {
            int num2 = 0;
            int num4 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                if (Operators.ConditionalCompareObjectEqual(this.UltraGrid1.Rows[i].Cells["OZNACEN"].Value, true, false))
                {
                    num2++;
                }
            }
            return num2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.m_bDisablePosCHange = true;
            frmPregledRadnika radnika = new frmPregledRadnika();
            radnika.ShowDialog();
            if (radnika.DialogResult != DialogResult.Cancel)
            {
                int num = 0;
                UltraGrid odabraniRadnici = new UltraGrid();
                odabraniRadnici = (UltraGrid) radnika.OdabraniRadnici;
                int num4 = odabraniRadnici.Rows.Count - 1;
                int num2 = 0;
                while (num2 <= num4)
                {
                    if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                    {
                        num++;
                    }
                    num2++;
                }
                if (num == 0)
                {
                    Interaction.MsgBox("Nema označenih radnika", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    int num5 = odabraniRadnici.Rows.Count - 1;
                    num2 = 0;
                    while (num2 <= num5)
                    {
                        if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                        {
                            DataRow row = this.EvidencijaDataSet1.EVIDENCIJARADNICI.NewRow();
                            row["idradnik"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["idradnik"].Value);
                            row["mjesec"] = this.mjesec;
                            row["idgodine"] = this.godina;
                            row["BROJEVIDENCIJE"] = this.BROJEVIDENCIJE;
                            try
                            {
                                this.EvidencijaDataSet1.EVIDENCIJARADNICI.Rows.Add(row);
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                                
                                
                            }
                        }
                        num2++;
                    }
                    int num6 = odabraniRadnici.Rows.Count - 1;
                    for (num2 = 0; num2 <= num6; num2++)
                    {
                        if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                        {
                            int num3 = 1;
                            do
                            {
                                if (Information.IsDate(Conversions.ToString(num3) + "/" + Conversions.ToString(this.mjesec) + "/" + Conversions.ToString(this.godina)))
                                {
                                    DataRow row2 = this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.NewRow();
                                    row2["idradnik"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["idradnik"].Value);
                                    row2["mjesec"] = this.mjesec;
                                    row2["idgodine"] = this.godina;
                                    row2["BROJEVIDENCIJE"] = this.BROJEVIDENCIJE;
                                    row2["dan"] = num3;
                                    row2["rr"] = 0;
                                    row2["pr"] = 0;
                                    row2["sp"] = 0;
                                    row2["go"] = 0;
                                    row2["bop"] = 0;
                                    row2["bof"] = 0;
                                    row2["rd"] = 0;
                                    row2["pd"] = 0;
                                    row2["npd"] = 0;
                                    row2["blg"] = 0;
                                    row2["zas"] = 0;
                                    row2["prv"] = 0;
                                    row2["tr"] = 0;
                                    row2["pri"] = 0;
                                    row2["nen"] = 0;
                                    row2["str"] = 0;
                                    row2["loc"] = 0;
                                    row2["odtogasmjenski"] = 0;
                                    row2["odtogadvokratni"] = 0;
                                    row2["odtogaposebni1"] = 0;
                                    row2["odtogaposebni2"] = 0;
                                    row2["odtogaposebni3"] = 0;
                                    row2["odtogakombinacija"] = 0;
                                    row2["odtogaspecijalna"] = 0;
                                    row2["NED"] = 0;
                                    row2["NOC"] = 0;
                                    row2["NENNEODOBRENA"] = 0;
                                    row2["IZNADNORME"] = 0;
                                    try
                                    {
                                        this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Rows.Add(row2);
                                    }
                                    catch (System.Exception exception3)
                                    {
                                        throw exception3;
                                        //Exception exception2 = exception3;
                                    }
                                }
                                num3++;
                            }
                            while (num3 <= 0x1f);
                        }
                    }
                    this.daevidencija.Update(this.EvidencijaDataSet1);
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

        private void Button4_Click(object sender, EventArgs e)
        {
            if (this.Broj_Oznacenih() == 0)
            {
                Interaction.MsgBox("Nema označenih zaposlenika!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                this.m_bDisablePosCHange = true;
                int[] ar = new int[0x20];
                ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    ControlBox = false,
                    Title = "Odaberite uvjete",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                OdabirUvjetaEvidencija smartPart = this.Controller.WorkItem.Items.AddNew<OdabirUvjetaEvidencija>();
                smartPart.godina = this.godina;
                smartPart.mjesec = this.mjesec;
                workspace.Show(smartPart, smartPartInfo);
                ar = smartPart.ar;
                decimal brojsati = smartPart.brojsati;
                int num15 = this.UltraGrid1.Rows.Count - 1;
                for (int i = 0; i <= num15; i++)
                {
                    if (Operators.ConditionalCompareObjectEqual(this.UltraGrid1.Rows[i].Cells["oznacen"].Value, true, false))
                    {
                        int index = 0;
                        do
                        {
                            if (ar[index] <= 0)
                            {
                                break;
                            }
                            int right = ar[index];
                            if (smartPart.RadioButton1.Checked)
                            {
                                int num5 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num5] = 0;
                                    num5++;
                                }
                                while (num5 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["rr"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["prvasmjenaidsmjene"] = 1;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                            }
                            if (smartPart.RadioButton2.Checked)
                            {
                                int num6 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num6] = 0;
                                    num6++;
                                }
                                while (num6 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["rr"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["ODTOGASMJENSKI"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["drugasmjenaidsmjene"] = 2;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                            }
                            if (smartPart.RadioButton3.Checked)
                            {
                                int num7 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num7] = 0;
                                    num7++;
                                }
                                while (num7 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["rr"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["ODTOGADVOKRATNI"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["prvasmjenaidsmjene"] = 1;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["drugasmjenaidsmjene"] = 2;
                            }
                            if (smartPart.bop.Checked)
                            {
                                int num8 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num8] = 0;
                                    num8++;
                                }
                                while (num8 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["bop"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                            }
                            if (smartPart.bof.Checked)
                            {
                                int num9 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num9] = 0;
                                    num9++;
                                }
                                while (num9 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["bof"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                            }
                            if (smartPart.Blagdan.Checked)
                            {
                                int num10 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num10] = 0;
                                    num10++;
                                }
                                while (num10 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["blg"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                            }
                            if (smartPart.go.Checked)
                            {
                                int num11 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num11] = 0;
                                    num11++;
                                }
                                while (num11 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["go"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                            }
                            if (smartPart.pd.Checked)
                            {
                                int num12 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num12] = 0;
                                    num12++;
                                }
                                while (num12 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["pd"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                            }
                            if (smartPart.nepd.Checked)
                            {
                                int num13 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num13] = 0;
                                    num13++;
                                }
                                while (num13 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["npd"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                            }
                            if (smartPart.rd.Checked)
                            {
                                int num14 = 12;
                                do
                                {
                                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0][num14] = 0;
                                    num14++;
                                }
                                while (num14 <= 0x27);
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", this.UltraGrid1.Rows[i].Cells["idradnik"].Value), " and dan ="), right)))[0]["rd"] = Operators.DivideObject(this.UltraGrid1.Rows[i].Cells["TJEDNIFONDSATI"].Value, 5);
                            }
                            index++;
                        }
                        while (index <= 0x1f);
                    }
                }
                this.BindingContext[this.EvidencijaDataSet1, "evidencijaradnicisati"].EndCurrentEdit();
                this.daevidencija.Update(this.EvidencijaDataSet1);
                this.m_bDisablePosCHange = false;
                this.m_cm_PositionChanged(null, null);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (this.Broj_Oznacenih() != 0)
            {
                for (int i = this.UltraGrid1.Rows.Count - 1; i >= 0; i += -1)
                {
                    if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
                    {
                        this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[i];
                        ((DataRowView) this.BindingContext[this.EvidencijaDataSet1, "evidencijaradnici"].Current).Delete();
                    }
                }
                try
                {
                    this.daevidencija.Update(this.EvidencijaDataSet1);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
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
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band3 = new UltraGridBand("EVIDENCIJARADNICI", -1);
            UltraGridColumn column42 = new UltraGridColumn("MJESEC");
            UltraGridColumn column43 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column44 = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column46 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column47 = new UltraGridColumn("PREZIME", -1, null, 0, SortIndicator.Ascending, false);
            UltraGridColumn column48 = new UltraGridColumn("IME");
            UltraGridColumn column49 = new UltraGridColumn("TJEDNIFONDSATI");
            UltraGridColumn column50 = new UltraGridColumn("AKTIVAN");
            UltraGridColumn column51 = new UltraGridColumn("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI");
            UltraGridColumn column52 = new UltraGridColumn("OZNACEN", 0);
            UltraGridBand band4 = new UltraGridBand("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI", 0);
            UltraGridColumn column53 = new UltraGridColumn("MJESEC");
            UltraGridColumn column54 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column55 = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column57 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column58 = new UltraGridColumn("DAN");
            UltraGridColumn column59 = new UltraGridColumn("PRVASMJENAIDSMJENE");
            UltraGridColumn column60 = new UltraGridColumn("PRVASMJENAOPISSMJENE");
            UltraGridColumn column61 = new UltraGridColumn("PRVASMJENAPOCETAK");
            UltraGridColumn column62 = new UltraGridColumn("PRVASMJENAZAVRSETAK");
            UltraGridColumn column63 = new UltraGridColumn("DRUGASMJENAIDSMJENE");
            UltraGridColumn column64 = new UltraGridColumn("DRUGASMJENAOPISSMJENE");
            UltraGridColumn column65 = new UltraGridColumn("DRUGASMJENAPOCETAK");
            UltraGridColumn column66 = new UltraGridColumn("DRUGASMJENAZAVRSETAK");
            UltraGridColumn column68 = new UltraGridColumn("RR");
            UltraGridColumn column69 = new UltraGridColumn("ODTOGASMJENSKI");
            UltraGridColumn column70 = new UltraGridColumn("ODTOGADVOKRATNI");
            UltraGridColumn column71 = new UltraGridColumn("ODTOGAPOSEBNI1");
            UltraGridColumn column72 = new UltraGridColumn("ODTOGAPOSEBNI2");
            UltraGridColumn column73 = new UltraGridColumn("ODTOGAPOSEBNI3");
            UltraGridColumn column74 = new UltraGridColumn("ODTOGAKOMBINACIJA");
            UltraGridColumn column75 = new UltraGridColumn("ODTOGASPECIJALNA");
            UltraGridColumn column76 = new UltraGridColumn("IZNADNORME");
            UltraGridColumn column77 = new UltraGridColumn("PR");
            UltraGridColumn column79 = new UltraGridColumn("SP");
            UltraGridColumn column80 = new UltraGridColumn("GO");
            UltraGridColumn column81 = new UltraGridColumn("BOP");
            UltraGridColumn column82 = new UltraGridColumn("BOF");
            UltraGridColumn column83 = new UltraGridColumn("RD");
            UltraGridColumn column84 = new UltraGridColumn("PD");
            UltraGridColumn column85 = new UltraGridColumn("NPD");
            UltraGridColumn column86 = new UltraGridColumn("BLG");
            UltraGridColumn column87 = new UltraGridColumn("ZAS");
            UltraGridColumn column88 = new UltraGridColumn("PRV");
            UltraGridColumn column90 = new UltraGridColumn("TR");
            UltraGridColumn column91 = new UltraGridColumn("PRI");
            UltraGridColumn column92 = new UltraGridColumn("NEN");
            UltraGridColumn column93 = new UltraGridColumn("NENNEODOBRENA");
            UltraGridColumn column94 = new UltraGridColumn("STR");
            UltraGridColumn column95 = new UltraGridColumn("LOC");
            UltraGridColumn column96 = new UltraGridColumn("NED");
            UltraGridColumn column97 = new UltraGridColumn("NOC");
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("EVIDENCIJARADNICISATI", -1);
            UltraGridColumn column = new UltraGridColumn("MJESEC");
            UltraGridColumn column12 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column23 = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column34 = new UltraGridColumn("IDRADNIK", -1, "UltraDropDown1");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            UltraGridColumn column45 = new UltraGridColumn("DAN");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            UltraGridColumn column56 = new UltraGridColumn("PRVASMJENAIDSMJENE");
            UltraGridColumn column67 = new UltraGridColumn("PRVASMJENAOPISSMJENE");
            UltraGridColumn column78 = new UltraGridColumn("PRVASMJENAPOCETAK");
            UltraGridColumn column89 = new UltraGridColumn("PRVASMJENAZAVRSETAK");
            UltraGridColumn column2 = new UltraGridColumn("DRUGASMJENAIDSMJENE");
            UltraGridColumn column3 = new UltraGridColumn("DRUGASMJENAOPISSMJENE");
            UltraGridColumn column4 = new UltraGridColumn("DRUGASMJENAPOCETAK");
            UltraGridColumn column5 = new UltraGridColumn("DRUGASMJENAZAVRSETAK");
            UltraGridColumn column6 = new UltraGridColumn("RR");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            UltraGridColumn column7 = new UltraGridColumn("ODTOGASMJENSKI");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            UltraGridColumn column8 = new UltraGridColumn("ODTOGADVOKRATNI");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            UltraGridColumn column9 = new UltraGridColumn("ODTOGAPOSEBNI1");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            UltraGridColumn column10 = new UltraGridColumn("ODTOGAPOSEBNI2");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            UltraGridColumn column11 = new UltraGridColumn("ODTOGAPOSEBNI3");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            UltraGridColumn column13 = new UltraGridColumn("ODTOGAKOMBINACIJA");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            UltraGridColumn column14 = new UltraGridColumn("ODTOGASPECIJALNA");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            UltraGridColumn column15 = new UltraGridColumn("IZNADNORME");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            UltraGridColumn column16 = new UltraGridColumn("PR");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            UltraGridColumn column17 = new UltraGridColumn("SP");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            UltraGridColumn column18 = new UltraGridColumn("GO");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            UltraGridColumn column19 = new UltraGridColumn("BOP");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            UltraGridColumn column20 = new UltraGridColumn("BOF");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            UltraGridColumn column21 = new UltraGridColumn("RD");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            UltraGridColumn column22 = new UltraGridColumn("PD");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            UltraGridColumn column24 = new UltraGridColumn("NPD");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            UltraGridColumn column25 = new UltraGridColumn("BLG");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            UltraGridColumn column26 = new UltraGridColumn("ZAS");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            UltraGridColumn column27 = new UltraGridColumn("PRV");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            UltraGridColumn column28 = new UltraGridColumn("TR");
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            UltraGridColumn column29 = new UltraGridColumn("PRI");
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            UltraGridColumn column30 = new UltraGridColumn("NEN");
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            UltraGridColumn column31 = new UltraGridColumn("NENNEODOBRENA");
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            UltraGridColumn column32 = new UltraGridColumn("STR");
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            UltraGridColumn column33 = new UltraGridColumn("LOC");
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            UltraGridColumn column35 = new UltraGridColumn("NED");
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            UltraGridColumn column36 = new UltraGridColumn("NOC");
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            UltraGridColumn column37 = new UltraGridColumn("", 0);
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            UltraGridBand band2 = new UltraGridBand("RADNIK", -1);
            UltraGridColumn column38 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column39 = new UltraGridColumn("SPOJENOPREZIME");
            UltraGridColumn column40 = new UltraGridColumn("PREZIME");
            UltraGridColumn column41 = new UltraGridColumn("IME");
            DockAreaPane pane3 = new DockAreaPane(DockedLocation.DockedTop, new Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003"));
            DockableControlPane pane = new DockableControlPane(new Guid("9373afb2-5358-4618-b4be-9d6c44b6bcce"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("b6b2fcb1-24ef-4b7a-8004-f67edafb3003"), -1);
            DockAreaPane pane4 = new DockAreaPane(DockedLocation.DockedLeft, new Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb"));
            DockableControlPane pane2 = new DockableControlPane(new Guid("c9a6ddcd-81e9-4c0d-8781-8476eda2fe81"), new Guid("00000000-0000-0000-0000-000000000000"), -1, new Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb"), -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.Button5 = new Button();
            this.Label1 = new Label();
            this.Button4 = new Button();
            this.Button3 = new Button();
            this.Button2 = new Button();
            this.Button1 = new Button();
            this.UltraTextEditor1 = new UltraTextEditor();
            this.UltraGroupBox2 = new UltraGroupBox();
            this.UltraGrid1 = new UltraGrid();
            this.UltraCalcManager1 = new UltraCalcManager(this.components);
            this.EvidencijaDataSet1 = new EVIDENCIJADataSet();
            this.ElementDataSet1 = new ELEMENTDataSet();
            this.UltraGroupBox3 = new UltraGroupBox();
            this.UltraGrid2 = new UltraGrid();
            this.UltraDropDown1 = new UltraDropDown();
            this.RadnikPripremaDataSet1 = new RadnikPripremaDataSet();
            this.UltraGridExcelExporter1 = new UltraGridExcelExporter(this.components);
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._PripremaPlaceCustomUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._PripremaPlaceCustomAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow3 = new DockableWindow();
            this.DockableWindow1 = new DockableWindow();
            this.WindowDockingArea3 = new WindowDockingArea();
            this.RadnikDataSet1 = new RADNIKDataSet();
            this.PrplaceDataSet1 = new PRPLACEDataSet();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            ((ISupportInitialize) this.UltraGroupBox2).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            ((ISupportInitialize) this.UltraCalcManager1).BeginInit();
            this.EvidencijaDataSet1.BeginInit();
            this.ElementDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraGroupBox3).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid2).BeginInit();
            ((ISupportInitialize) this.UltraDropDown1).BeginInit();
            this.RadnikPripremaDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea3.SuspendLayout();
            this.RadnikDataSet1.BeginInit();
            this.PrplaceDataSet1.BeginInit();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.Button5);
            this.UltraGroupBox1.Controls.Add(this.Label1);
            this.UltraGroupBox1.Controls.Add(this.Button4);
            this.UltraGroupBox1.Controls.Add(this.Button3);
            this.UltraGroupBox1.Controls.Add(this.Button2);
            this.UltraGroupBox1.Controls.Add(this.Button1);
            this.UltraGroupBox1.Controls.Add(this.UltraTextEditor1);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(0x486, 0x57);
            this.UltraGroupBox1.TabIndex = 1;
            this.Button5.Location = new System.Drawing.Point(0x1b5, 0x30);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(0xb1, 0x17);
            this.Button5.TabIndex = 0x11;
            this.Button5.Text = "Briši  zaposlenike iz evidencije";
            this.Button5.UseVisualStyleBackColor = true;
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(0x1dd, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0x16, 13);
            this.Label1.TabIndex = 0x10;
            this.Label1.Text = ".....";
            this.Button4.Cursor = Cursors.Hand;
            this.Button4.Location = new System.Drawing.Point(620, 0x30);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(0x99, 0x17);
            this.Button4.TabIndex = 15;
            this.Button4.Text = "Grupno pridruži sate";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button3.Location = new System.Drawing.Point(0x59, 0x30);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(0x60, 0x17);
            this.Button3.TabIndex = 14;
            this.Button3.Text = "Makni oznake";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button2.Location = new System.Drawing.Point(7, 0x30);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(0x4b, 0x17);
            this.Button2.TabIndex = 13;
            this.Button2.Text = "Označi sve";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button1.Location = new System.Drawing.Point(0xfe, 0x30);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(0xb1, 0x17);
            this.Button1.TabIndex = 12;
            this.Button1.Text = "Dodaj zaposlenike u evidenciju";
            this.Button1.UseVisualStyleBackColor = true;
            button.Key = "zaposlenik";
            button.Text = "Kliknite za odabir";
            this.UltraTextEditor1.ButtonsRight.Add(button);
            this.UltraTextEditor1.Location = new System.Drawing.Point(15, 15);
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            this.UltraTextEditor1.Size = new System.Drawing.Size(0x1bd, 0x15);
            this.UltraTextEditor1.TabIndex = 11;
            this.UltraTextEditor1.Text = "Odaberite evidenciju";
            this.UltraGroupBox2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.UltraGroupBox2.Controls.Add(this.UltraGrid1);
            this.UltraGroupBox2.Location = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(0x194, 0x156);
            this.UltraGroupBox2.TabIndex = 8;
            this.UltraGroupBox2.UseAppStyling = false;
            this.UltraGroupBox2.ViewStyle = GroupBoxViewStyle.Office2007;
            this.UltraGrid1.CalcManager = this.UltraCalcManager1;
            this.UltraGrid1.DataMember = "EVIDENCIJARADNICI";
            this.UltraGrid1.DataSource = this.EvidencijaDataSet1;
            appearance.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            column42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column42.CellActivation = Activation.NoEdit;
            column42.Header.VisiblePosition = 0;
            column42.Hidden = true;
            column43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column43.CellActivation = Activation.NoEdit;
            column43.Header.VisiblePosition = 1;
            column43.Hidden = true;
            column43.Width = 0x37;
            column44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column44.Header.VisiblePosition = 2;
            column44.Hidden = true;
            column46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column46.CellActivation = Activation.NoEdit;
            column46.Header.Caption = "Šifra";
            column46.Header.VisiblePosition = 3;
            column46.Width = 60;
            column47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column47.CellActivation = Activation.NoEdit;
            column47.Header.VisiblePosition = 5;
            column47.Width = 0x75;
            column48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column48.CellActivation = Activation.NoEdit;
            column48.Header.VisiblePosition = 6;
            column49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column49.CellActivation = Activation.NoEdit;
            column49.Header.VisiblePosition = 7;
            column50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column50.CellActivation = Activation.NoEdit;
            column50.Header.VisiblePosition = 8;
            column51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column51.Header.VisiblePosition = 9;
            column52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column52.CellActivation = Activation.NoEdit;
            column52.DataType = typeof(bool);
            column52.DefaultCellValue = true;
            column52.Header.Caption = "Označen";
            column52.Header.VisiblePosition = 4;
            column52.Width = 0x3f;
            band3.Columns.AddRange(new object[] { column42, column43, column44, column46, column47, column48, column49, column50, column51, column52 });
            column53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column53.Header.VisiblePosition = 0;
            column53.Width = 0x22;
            column54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column54.Header.VisiblePosition = 1;
            column54.Width = 0x3f;
            column55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column55.Header.VisiblePosition = 2;
            column57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column57.Header.VisiblePosition = 3;
            column58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column58.Header.VisiblePosition = 4;
            column59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column59.Header.VisiblePosition = 5;
            column60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column60.Header.VisiblePosition = 6;
            column61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column61.Header.VisiblePosition = 7;
            column62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column62.Header.VisiblePosition = 8;
            column63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column63.Header.VisiblePosition = 9;
            column64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column64.Header.VisiblePosition = 10;
            column65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column65.Header.VisiblePosition = 11;
            column66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column66.Header.VisiblePosition = 12;
            column68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column68.Header.VisiblePosition = 13;
            column69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column69.Header.VisiblePosition = 14;
            column70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column70.Header.VisiblePosition = 0x10;
            column71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column71.Header.VisiblePosition = 0x11;
            column72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column72.Header.VisiblePosition = 0x13;
            column73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column73.Header.VisiblePosition = 0x15;
            column74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column74.Header.VisiblePosition = 0x18;
            column75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column75.Header.VisiblePosition = 0x1a;
            column76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column76.Header.VisiblePosition = 0x16;
            column77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column77.Header.VisiblePosition = 15;
            column79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column79.Header.VisiblePosition = 0x12;
            column80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column80.Header.VisiblePosition = 20;
            column81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column81.Header.VisiblePosition = 0x17;
            column82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column82.Header.VisiblePosition = 0x19;
            column83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column83.Header.VisiblePosition = 0x1b;
            column84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column84.Header.VisiblePosition = 0x1c;
            column85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column85.Header.VisiblePosition = 0x1d;
            column86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column86.Header.VisiblePosition = 30;
            column87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column87.Header.VisiblePosition = 0x1f;
            column88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column88.Header.VisiblePosition = 0x20;
            column90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column90.Header.VisiblePosition = 0x21;
            column91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column91.Header.VisiblePosition = 0x22;
            column92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column92.Header.VisiblePosition = 0x23;
            column93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column93.Header.VisiblePosition = 0x26;
            column94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column94.Header.VisiblePosition = 0x24;
            column95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column95.Header.VisiblePosition = 0x25;
            column96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column96.Header.VisiblePosition = 0x27;
            column97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column97.Header.VisiblePosition = 40;
            band4.Columns.AddRange(new object[] { 
                column53, column54, column55, column57, column58, column59, column60, column61, column62, column63, column64, column65, column66, column68, column69, column70, 
                column71, column72, column73, column74, column75, column76, column77, column79, column80, column81, column82, column83, column84, column85, column86, column87, 
                column88, column90, column91, column92, column93, column94, column95, column96, column97
             });
            band4.Hidden = true;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band3);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band4);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance36.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance36;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance40.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance40;
            appearance41.BorderColor = Color.LightGray;
            appearance41.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance41;
            appearance2.BackColor = Color.LightSteelBlue;
            appearance2.BorderColor = Color.Black;
            appearance2.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.UltraGrid1.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(0x18e, 0x153);
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.UseAppStyling = false;
            this.UltraCalcManager1.ContainingControl = this;
            this.EvidencijaDataSet1.DataSetName = "EVIDENCIJADataSet";
            this.ElementDataSet1.DataSetName = "ELEMENTDataSet";
            this.UltraGroupBox3.Controls.Add(this.UltraGrid2);
            this.UltraGroupBox3.Controls.Add(this.UltraDropDown1);
            this.UltraGroupBox3.Dock = DockStyle.Fill;
            this.UltraGroupBox3.Location = new System.Drawing.Point(0x199, 110);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(0x2ed, 360);
            this.UltraGroupBox3.TabIndex = 9;
            this.UltraGroupBox3.ViewStyle = GroupBoxViewStyle.Office2007;
            this.UltraGrid2.CalcManager = this.UltraCalcManager1;
            this.UltraGrid2.DataMember = "EVIDENCIJARADNICI.EVIDENCIJARADNICI_EVIDENCIJARADNICISATI";
            this.UltraGrid2.DataSource = this.EvidencijaDataSet1;
            appearance6.BackColor = Color.White;
            this.UltraGrid2.DisplayLayout.Appearance = appearance6;
            band.CardView = true;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 0;
            column.Hidden = true;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.VisiblePosition = 1;
            column12.Hidden = true;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.Header.VisiblePosition = 2;
            column23.Hidden = true;
            column34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column34.CellActivation = Activation.NoEdit;
            appearance3.FontData.BoldAsString = "True";
            column34.Header.Appearance = appearance3;
            column34.Header.VisiblePosition = 14;
            column34.Hidden = true;
            column34.Width = 0x4c;
            column45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.Name = "Verdana";
            appearance4.TextHAlignAsString = "Center";
            column45.CellAppearance = appearance4;
            column45.Header.Caption = "Dan";
            column45.Header.VisiblePosition = 3;
            column56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column56.Header.VisiblePosition = 15;
            column56.Hidden = true;
            column67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column67.Header.VisiblePosition = 0x10;
            column67.Hidden = true;
            column78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column78.Header.VisiblePosition = 0x11;
            column78.Hidden = true;
            column89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column89.Header.VisiblePosition = 0x12;
            column89.Hidden = true;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 0x13;
            column2.Hidden = true;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 20;
            column3.Hidden = true;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 0x15;
            column4.Hidden = true;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 0x16;
            column5.Hidden = true;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance5.TextHAlignAsString = "Right";
            column6.CellAppearance = appearance5;
            column6.Header.Caption = "Redovan rad prema tjednom zaduženju";
            column6.Header.VisiblePosition = 6;
            column6.MaskInput = "{LOC} nnn.nn";
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance11.TextHAlignAsString = "Right";
            column7.CellAppearance = appearance11;
            column7.Header.Caption = "--od toga smjenski";
            column7.Header.VisiblePosition = 7;
            column7.MaskInput = "{LOC} nnn.nn";
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance12.TextHAlignAsString = "Right";
            column8.CellAppearance = appearance12;
            column8.Header.Caption = "-- od toga dvokratni";
            column8.Header.VisiblePosition = 8;
            column8.MaskInput = "{LOC} nnn.nn";
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance13.TextHAlignAsString = "Right";
            column9.CellAppearance = appearance13;
            column9.Header.Caption = "-- od toga posebni 7%";
            column9.Header.VisiblePosition = 9;
            column9.MaskInput = "{LOC} nnn.nn";
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance14.TextHAlignAsString = "Right";
            column10.CellAppearance = appearance14;
            column10.Header.Caption = "-- od toga posebni 14%";
            column10.Header.VisiblePosition = 10;
            column10.MaskInput = "{LOC} nnn.nn";
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance15.TextHAlignAsString = "Right";
            column11.CellAppearance = appearance15;
            column11.Header.Caption = "-- od toga posebni 21 %";
            column11.Header.VisiblePosition = 11;
            column11.MaskInput = "{LOC} nnn.nn";
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance16.TextHAlignAsString = "Right";
            column13.CellAppearance = appearance16;
            column13.Header.Caption = "-- od toga kombinacija";
            column13.Header.VisiblePosition = 12;
            column13.MaskInput = "{LOC} nnn.nn";
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance17.TextHAlignAsString = "Right";
            column14.CellAppearance = appearance17;
            column14.Header.Caption = "-- od toga specijalna odjeljenja";
            column14.Header.VisiblePosition = 13;
            column14.MaskInput = "{LOC} nnn.nn";
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance18.TextHAlignAsString = "Right";
            column15.CellAppearance = appearance18;
            column15.Header.Caption = "Iznad norme";
            column15.Header.VisiblePosition = 0x17;
            column15.MaskInput = "{LOC} nnn.nn";
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance19.TextHAlignAsString = "Right";
            column16.CellAppearance = appearance19;
            column16.Format = "";
            column16.Header.Caption = "Prekovremeni";
            column16.Header.VisiblePosition = 0x18;
            column16.MaskInput = "{LOC} nnn.nn";
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance20.TextHAlignAsString = "Right";
            column17.CellAppearance = appearance20;
            column17.Format = "";
            column17.Header.Caption = "Službeni put";
            column17.Header.VisiblePosition = 0x1d;
            column17.MaskInput = "{LOC} nnn.nn";
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance21.TextHAlignAsString = "Right";
            column18.CellAppearance = appearance21;
            column18.Format = "";
            column18.Header.Caption = "Godišnji odmor";
            column18.Header.VisiblePosition = 0x20;
            column18.MaskInput = "{LOC} nnn.nn";
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance22.TextHAlignAsString = "Right";
            column19.CellAppearance = appearance22;
            column19.Format = "";
            column19.Header.Caption = "Bolovanje poslodavac";
            column19.Header.VisiblePosition = 0x21;
            column19.MaskInput = "{LOC} nnn.nn";
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance23.TextHAlignAsString = "Right";
            column20.CellAppearance = appearance23;
            column20.Format = "";
            column20.Header.Caption = "Bolovanje fond";
            column20.Header.VisiblePosition = 0x22;
            column20.MaskInput = "{LOC} nnn.nn";
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance24.TextHAlignAsString = "Right";
            column21.CellAppearance = appearance24;
            column21.Format = "";
            column21.Header.Caption = "Rodiljni dopust";
            column21.Header.VisiblePosition = 0x23;
            column21.MaskInput = "{LOC} nnn.nn";
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance25.TextHAlignAsString = "Right";
            column22.CellAppearance = appearance25;
            column22.Format = "";
            column22.Header.Caption = "Plaćeni dopust";
            column22.Header.VisiblePosition = 0x24;
            column22.MaskInput = "{LOC} nnn.nn";
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance26.TextHAlignAsString = "Right";
            column24.CellAppearance = appearance26;
            column24.Format = "";
            column24.Header.Caption = "Neplaćeni dopust";
            column24.Header.VisiblePosition = 0x25;
            column24.MaskInput = "{LOC} nnn.nn";
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance27.TextHAlignAsString = "Right";
            column25.CellAppearance = appearance27;
            column25.Format = "";
            column25.Header.Caption = "Blagdan";
            column25.Header.VisiblePosition = 0x1a;
            column25.MaskInput = "{LOC} nnn.nn";
            column26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance28.TextHAlignAsString = "Right";
            column26.CellAppearance = appearance28;
            column26.Format = "";
            column26.Header.Caption = "Sati zastoja";
            column26.Header.VisiblePosition = 4;
            column26.MaskInput = "{LOC} nnn.nn";
            column27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance29.TextHAlignAsString = "Right";
            column27.CellAppearance = appearance29;
            column27.Format = "";
            column27.Header.Caption = "Preraspodijeljeno radno vrijeme";
            column27.Header.VisiblePosition = 0x1b;
            column27.MaskInput = "{LOC} nnn.nn";
            column28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance30.TextHAlignAsString = "Right";
            column28.CellAppearance = appearance30;
            column28.Format = "";
            column28.Header.Caption = "Terenski rad";
            column28.Header.VisiblePosition = 30;
            column28.MaskInput = "{LOC} nnn.nn";
            column29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance31.TextHAlignAsString = "Right";
            column29.CellAppearance = appearance31;
            column29.Format = "";
            column29.Header.Caption = "Sati pripravnosti";
            column29.Header.VisiblePosition = 0x1f;
            column29.MaskInput = "{LOC} nnn.nn";
            column30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance32.TextHAlignAsString = "Right";
            column30.CellAppearance = appearance32;
            column30.Format = "";
            column30.Header.Caption = "Nenazočnost odobrena";
            column30.Header.VisiblePosition = 0x26;
            column30.MaskInput = "{LOC} nnn.nn";
            column31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance33.TextHAlignAsString = "Right";
            column31.CellAppearance = appearance33;
            column31.Header.Caption = "Nenazočnost neodobrena";
            column31.Header.VisiblePosition = 0x27;
            column31.MaskInput = "{LOC} nnn.nn";
            column32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance34.TextHAlignAsString = "Right";
            column32.CellAppearance = appearance34;
            column32.Format = "";
            column32.Header.Caption = "Štrajk";
            column32.Header.VisiblePosition = 40;
            column32.MaskInput = "{LOC} nnn.nn";
            column33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance35.TextHAlignAsString = "Right";
            column33.CellAppearance = appearance35;
            column33.Format = "";
            column33.Header.Caption = "Sati isključenja s rada";
            column33.Header.VisiblePosition = 0x29;
            column33.MaskInput = "{LOC} nnn.nn";
            column35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance37.TextHAlignAsString = "Right";
            column35.CellAppearance = appearance37;
            column35.Header.Caption = "Rad nedjeljom i na blagdane";
            column35.Header.VisiblePosition = 0x1c;
            column35.MaskInput = "{LOC} nnn.nn";
            column36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance38.TextHAlignAsString = "Right";
            column36.CellAppearance = appearance38;
            column36.Header.Caption = "Noćni rad";
            column36.Header.VisiblePosition = 0x19;
            column36.MaskInput = "{LOC} nnn.nn";
            column37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column37.CellActivation = Activation.NoEdit;
            appearance39.TextHAlignAsString = "Right";
            column37.CellAppearance = appearance39;
            column37.DataType = typeof(decimal);
            column37.Format = "#,#0.00";
            column37.Formula = "[PR] + [RR] +  [NOC] +  [IZNADNORME]";
            column37.Header.Caption = "Ukupno dnevno radno vrijeme";
            column37.Header.VisiblePosition = 5;
            column37.MaskInput = "{LOC} nnn.nn";
            band.Columns.AddRange(new object[] { 
                column, column12, column23, column34, column45, column56, column67, column78, column89, column2, column3, column4, column5, column6, column7, column8, 
                column9, column10, column11, column13, column14, column15, column16, column17, column18, column19, column20, column21, column22, column24, column25, column26, 
                column27, column28, column29, column30, column31, column32, column33, column35, column36, column37
             });
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance7.BackColor = Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance7;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            appearance8.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance8;
            appearance9.BorderColor = Color.LightGray;
            appearance9.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance9;
            this.UltraGrid2.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance10.BackColor = Color.LightSteelBlue;
            appearance10.BorderColor = Color.Black;
            appearance10.ForeColor = Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance10;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid2.Dock = DockStyle.Fill;
            this.UltraGrid2.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(0x2e7, 0x165);
            this.UltraGrid2.TabIndex = 7;
            this.UltraGrid2.UpdateMode = UpdateMode.OnCellChangeOrLostFocus;
            this.UltraGrid2.UseAppStyling = false;
            this.UltraDropDown1.CalcManager = this.UltraCalcManager1;
            this.UltraDropDown1.DataMember = "RADNIK";
            this.UltraDropDown1.DataSource = this.RadnikPripremaDataSet1;
            column38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column38.Header.VisiblePosition = 0;
            column38.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x86, 0);
            column39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column39.Header.Caption = "Prezime i ime";
            column39.Header.VisiblePosition = 1;
            column39.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(0x1bc, 0);
            column40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column40.Header.VisiblePosition = 2;
            column40.Hidden = true;
            column41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column41.Header.VisiblePosition = 3;
            column41.Hidden = true;
            band2.Columns.AddRange(new object[] { column38, column39, column40, column41 });
            band2.UseRowLayout = true;
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band2);
            this.UltraDropDown1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraDropDown1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraDropDown1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraDropDown1.DisplayMember = "IDRADNIK";
            this.UltraDropDown1.Location = new System.Drawing.Point(0x2c, 0xe3);
            this.UltraDropDown1.Name = "UltraDropDown1";
            this.UltraDropDown1.Size = new System.Drawing.Size(0x22c, 0x20);
            this.UltraDropDown1.TabIndex = 1;
            this.UltraDropDown1.Text = "UltraDropDown1";
            this.UltraDropDown1.ValueMember = "IDRADNIK";
            this.UltraDropDown1.Visible = false;
            this.RadnikPripremaDataSet1.DataSetName = "RadnikPripremaDataSet";
            pane3.DockedBefore = new Guid("faf93dbf-5038-40a4-8fe5-01d81d01dddb");
            pane.Control = this.UltraGroupBox1;
            pane.OriginalControlBounds = new Rectangle(4, 3, 0x265, 0x4d);
            pane.Size = new System.Drawing.Size(100, 100);
            pane.Text = "Odabir postojeće evidencije";
            pane3.Panes.AddRange(new DockablePaneBase[] { pane });
            pane3.Size = new System.Drawing.Size(0x486, 0x69);
            pane2.Control = this.UltraGroupBox2;
            pane2.OriginalControlBounds = new Rectangle(0x2f, 0x7b, 260, 0xe1);
            pane2.Size = new System.Drawing.Size(100, 100);
            pane2.Text = "Zaposlenici u evidenciji / broj označenih: 0";
            pane4.Panes.AddRange(new DockablePaneBase[] { pane2 });
            pane4.Size = new System.Drawing.Size(0x194, 360);
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane3, pane4 });
            this.UltraDockManager1.HostControl = this;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Name = "_PripremaPlaceCustomUnpinnedTabAreaLeft";
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaLeft.TabIndex = 10;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x486, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Name = "_PripremaPlaceCustomUnpinnedTabAreaRight";
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaRight.TabIndex = 11;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Name = "_PripremaPlaceCustomUnpinnedTabAreaTop";
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x486, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaTop.TabIndex = 12;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 470);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Name = "_PripremaPlaceCustomUnpinnedTabAreaBottom";
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x486, 0);
            this._PripremaPlaceCustomUnpinnedTabAreaBottom.TabIndex = 13;
            this._PripremaPlaceCustomAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._PripremaPlaceCustomAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._PripremaPlaceCustomAutoHideControl.Name = "_PripremaPlaceCustomAutoHideControl";
            this._PripremaPlaceCustomAutoHideControl.Owner = this.UltraDockManager1;
            this._PripremaPlaceCustomAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._PripremaPlaceCustomAutoHideControl.TabIndex = 14;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(0x486, 110);
            this.WindowDockingArea1.TabIndex = 15;
            this.DockableWindow3.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(0x486, 0x69);
            this.DockableWindow3.TabIndex = 0x12;
            this.DockableWindow1.Controls.Add(this.UltraGroupBox2);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(0x194, 360);
            this.DockableWindow1.TabIndex = 0x13;
            this.WindowDockingArea3.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea3.Dock = DockStyle.Left;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.WindowDockingArea3.Location = new System.Drawing.Point(0, 110);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(0x199, 360);
            this.WindowDockingArea3.TabIndex = 0x11;
            this.RadnikDataSet1.DataSetName = "RADNIKDataSet";
            this.PrplaceDataSet1.DataSetName = "PRPLACEDataSet";
            this.Controls.Add(this._PripremaPlaceCustomAutoHideControl);
            this.Controls.Add(this.UltraGroupBox3);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaTop);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaBottom);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaLeft);
            this.Controls.Add(this._PripremaPlaceCustomUnpinnedTabAreaRight);
            this.Name = "EvidencijaCustom";
            this.Size = new System.Drawing.Size(0x486, 470);

            this.Button1.Click += new EventHandler(Button1_Click);
            this.Button2.Click += new EventHandler(Button2_Click);
            this.Button3.Click += new EventHandler(Button3_Click);
            this.Button4.Click += new EventHandler(Button4_Click);
            this.Button5.Click += new EventHandler(Button5_Click);

            this.UltraGrid1.InitializeLayout += new InitializeLayoutEventHandler(UltraGrid1_InitializeLayout);
            this.UltraGrid1.AfterRowUpdate += new RowEventHandler(UltraGrid1_AfterRowUpdate);
            this.UltraGrid1.AfterRowActivate += new EventHandler(UltraGrid1_AfterRowActivate);
            this.UltraGrid1.AfterCellUpdate += new CellEventHandler(UltraGrid1_AfterCellUpdate);
            this.UltraGrid1.ClickCell += new ClickCellEventHandler(UltraGrid1_ClickCell);

            this.UltraGrid2.BeforeCellActivate += new CancelableCellEventHandler(UltraGrid2_BeforeCellActivate);
            this.UltraGrid2.AfterCellActivate += new EventHandler(UltraGrid2_AfterCellActivate);
            this.UltraGrid2.InitializeLayout += new InitializeLayoutEventHandler(UltraGrid2_InitializeLayout);
            this.UltraGrid2.AfterRowUpdate += new RowEventHandler(UltraGrid2_AfterRowUpdate);
            this.UltraGrid2.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(UltraGrid2_InitializeRow);
            this.UltraGrid2.AfterEnterEditMode += new EventHandler(UltraGrid2_AfterEnterEditMode);

            this.UltraTextEditor1.ValueChanged += new EventHandler(this.UltraTextEditor1_ValueChanged);
            this.UltraTextEditor1.EditorButtonClick += new EditorButtonEventHandler(this.UltraTextEditor1_EditorButtonClick);
            this.UltraGroupBox1.Click += new EventHandler(this.UltraGroupBox1_Click);


            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            ((ISupportInitialize) this.UltraGroupBox2).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            ((ISupportInitialize) this.UltraCalcManager1).EndInit();
            this.EvidencijaDataSet1.EndInit();
            this.ElementDataSet1.EndInit();
            ((ISupportInitialize) this.UltraGroupBox3).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid2).EndInit();
            ((ISupportInitialize) this.UltraDropDown1).EndInit();
            this.RadnikPripremaDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea3.ResumeLayout(false);
            this.RadnikDataSet1.EndInit();
            this.PrplaceDataSet1.EndInit();
            this.ResumeLayout(false);
        }

        [LocalCommandHandler("Smjenski")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.IspisRekapitulacije();
        }

        public void IspisRekapitulacije()
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str = Conversions.ToString(Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["korisnik1adresa"], ", "), dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]));
            string str10 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnikOIB"]);
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\EvidencijaIzvjestaji\rptEvidencija.rpt");
            document.SetDataSource(this.EvidencijaDataSet1);
            SMJENEDataAdapter adapter2 = new SMJENEDataAdapter();
            SMJENEDataSet set2 = new SMJENEDataSet();
            adapter2.Fill(set2);
            string str5 = Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(Conversions.ToString(set2.SMJENE.Rows[0]["OPISSMJENE"]) + "-", set2.SMJENE.Rows[0]["POCETAK"])) + "-", set2.SMJENE.Rows[0]["ZAVRSETAK"]));
            string str6 = Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(Conversions.ToString(set2.SMJENE.Rows[1]["OPISSMJENE"]) + "-", set2.SMJENE.Rows[1]["POCETAK"])) + "-", set2.SMJENE.Rows[1]["ZAVRSETAK"]));
            document.SetParameterValue("naziv", str8);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("oib", str10);
            document.SetParameterValue("LEGENDA", str5);
            document.SetParameterValue("LEGENDA2", str6);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("IspisRekapitulacijeCommand")]
        public void IspisRekapitulacijeHandler(object sender, EventArgs e)
        {
        }

        private void m_cm_PositionChanged(object sender, EventArgs e)
        {
            this.Label1.Text = "";
            if (!this.m_bDisablePosCHange && (this.m_cm.Count != 0))
            {
                DataRowView current = (DataRowView) this.m_cm.Current;
                string str = "";
                if (current["prvasmjenaidsmjene"] != DBNull.Value)
                {
                    str = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(current["prvasmjenaopissmjene"], "-"), current["prvasmjenapocetak"]), "-"), current["prvasmjenazavrsetak"]));
                }
                if (current["drugasmjenaidsmjene"] != DBNull.Value)
                {
                    str = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(str + "---", current["drugasmjenaopissmjene"]), "-"), current["drugasmjenapocetak"]), "-"), current["drugasmjenazavrsetak"]));
                }
                this.Label1.Text = str;
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
            this.UltraDockManager1.DockAreas[1].Panes[0].Text = "Zaposlenici u evidenciji / broj označenih: " + Conversions.ToString(this.Broj_Oznacenih());
        }

        private void Parametri_OznaciSve()
        {
            int num2 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid1.Rows[i].Cells["OZNACEN"].Value = true;
                this.UltraGrid1.Rows[i].Update();
            }
            this.UltraDockManager1.DockAreas[1].Panes[0].Text = "Zaposlenici u evidenciji / broj označenih: " + Conversions.ToString(this.Broj_Oznacenih());
        }

        [LocalCommandHandler("PreracunajSatnice")]
        public void PreracunajSatniceHandler(object sender, EventArgs e)
        {
            if (this.PrplaceDataSet1.PRPLACE.Rows.Count == 0)
            {
            }
        }

        private void Priprema_Load(object sender, EventArgs e)
        {
            this.m_cm = (CurrencyManager) this.BindingContext[this.EvidencijaDataSet1, "EVIDENCIJARADNICI.EVIDENCIJARADNICI_EVIDENCIJARADNICISATI"];
            this.m_cm.PositionChanged += new EventHandler(m_cm_PositionChanged);
            this.m_cm_PositionChanged(null, null);
        }

        [CommandHandler("Rekapitulirano")]
        public void SnimiHandler(object sender, EventArgs e)
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str = Conversions.ToString(Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["korisnik1adresa"], ", "), dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]));
            string str10 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnikOIB"]);
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\EvidencijaIzvjestaji\rptEvidencijaRekap.rpt");
            document.SetDataSource(this.EvidencijaDataSet1);
            SMJENEDataAdapter adapter2 = new SMJENEDataAdapter();
            SMJENEDataSet set2 = new SMJENEDataSet();
            adapter2.Fill(set2);
            string str5 = Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(Conversions.ToString(set2.SMJENE.Rows[0]["OPISSMJENE"]) + "-", set2.SMJENE.Rows[0]["POCETAK"])) + "-", set2.SMJENE.Rows[0]["ZAVRSETAK"]));
            string str6 = Conversions.ToString(Operators.AddObject(Conversions.ToString(Operators.AddObject(Conversions.ToString(set2.SMJENE.Rows[1]["OPISSMJENE"]) + "-", set2.SMJENE.Rows[1]["POCETAK"])) + "-", set2.SMJENE.Rows[1]["ZAVRSETAK"]));
            document.SetParameterValue("naziv", str8);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("oib", str10);
            document.SetParameterValue("LEGENDA", str5);
            document.SetParameterValue("LEGENDA2", str6);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Ucitaj")]
        public void UcitajHandler(object sender, EventArgs e)
        {
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
        }

        private void UltraGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            this.UltraGrid2.PerformAction(UltraGridAction.FirstRowInBand);
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
        }

        private void UltraGrid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Column.Key == "OZNACEN")
            {
                e.Cell.Value = Operators.NotObject(e.Cell.Value);
                e.Cell.Row.Update();
            }
            this.UltraDockManager1.DockAreas[1].Panes[0].Text = "Zaposlenici u evidenciji / broj označenih: " + Conversions.ToString(this.Broj_Oznacenih());
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_AfterCellActivate(object sender, EventArgs e)
        {
        }

        private void UltraGrid2_AfterEnterEditMode(object sender, EventArgs e)
        {
            this.UltraGrid2.ActiveCell.SelectAll();
        }

        private void UltraGrid2_AfterRowUpdate(object sender, RowEventArgs e)
        {
        }

        private void UltraGrid2_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            DataRowView current = null;
            DataRowView view2 = null;
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.EvidencijaDataSet1, "evidencijaradnici"];
            if (manager.Count > 0)
            {
                current = (DataRowView) manager.Current;
            }
            CurrencyManager manager2 = (CurrencyManager) this.BindingContext[this.EvidencijaDataSet1, "EVIDENCIJARADNICI.EVIDENCIJARADNICI_EVIDENCIJARADNICISATI"];
            if (manager2.Count > 0)
            {
                view2 = (DataRowView) manager2.Current;
            }
            if (Conversions.ToBoolean(Operators.AndObject(e.Cell.Column.Key == "ODTOGADVOKRATNI", Operators.CompareObjectEqual(e.Cell.Value, 0, false))))
            {
                int num = 12;
                do
                {
                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0][num] = 0;
                    num++;
                }
                while (num <= 0x27);
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["PRVASMJENAIDSMJENE"] = 1;
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["DRUGASMJENAIDSMJENE"] = 2;
                e.Cell.Value = DB.RoundUpDecimale(Operators.DivideObject(current["tjednifondsati"], 5), 2);
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["rr"] = DB.RoundUpDecimale(Operators.DivideObject(current["tjednifondsati"], 5), 2);
            }
            else if (Conversions.ToBoolean(Operators.AndObject(e.Cell.Column.Key == "ODTOGASMJENSKI", Operators.CompareObjectEqual(e.Cell.Value, 0, false))))
            {
                int num2 = 12;
                do
                {
                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0][num2] = 0;
                    num2++;
                }
                while (num2 <= 0x27);
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["DRUGASMJENAIDSMJENE"] = 2;
                e.Cell.Value = DB.RoundUpDecimale(Operators.DivideObject(current["tjednifondsati"], 5), 2);
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["rr"] = DB.RoundUpDecimale(Operators.DivideObject(current["tjednifondsati"], 5), 2);
            }
            else if (Conversions.ToBoolean(Operators.AndObject(e.Cell.Column.Key == "RR", Operators.CompareObjectEqual(e.Cell.Value, 0, false))))
            {
                int num3 = 12;
                do
                {
                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0][num3] = 0;
                    num3++;
                }
                while (num3 <= 0x27);
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["PRVASMJENAIDSMJENE"] = 1;
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                e.Cell.Value = DB.RoundUpDecimale(Operators.DivideObject(current["tjednifondsati"], 5), 2);
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["rr"] = DB.RoundUpDecimale(Operators.DivideObject(current["tjednifondsati"], 5), 2);
            }
            else if ((((e.Cell.Column.Key != "ODTOGAPOSEBNI1") && (e.Cell.Column.Key != "ODTOGAPOSEBNI2")) && ((e.Cell.Column.Key != "ODTOGAPOSEBNI3") && (e.Cell.Column.Key != "ODTOGAKOMBINACIJA"))) && ((((e.Cell.Column.Key != "ODTOGASPECIJALNA") && (e.Cell.Column.Key != "PR")) && ((e.Cell.Column.Key != "IZNADNORME") && (e.Cell.Column.Key != "NOC"))) && ((e.Cell.Column.Key != "NED") && Operators.ConditionalCompareObjectEqual(e.Cell.Value, 0, false))))
            {
                int num4 = 12;
                do
                {
                    this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0][num4] = 0;
                    num4++;
                }
                while (num4 <= 0x27);
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["PRVASMJENAIDSMJENE"] = DBNull.Value;
                this.EvidencijaDataSet1.EVIDENCIJARADNICISATI.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik = ", current["idradnik"]), " and dan ="), view2["dan"])))[0]["DRUGASMJENAIDSMJENE"] = DBNull.Value;
                e.Cell.Value = DB.RoundUpDecimale(Operators.DivideObject(current["tjednifondsati"], 5), 2);
            }
            this.BindingContext[this.EvidencijaDataSet1, "EVIDENCIJARADNICI.EVIDENCIJARADNICI_EVIDENCIJARADNICISATI"].EndCurrentEdit();
            try
            {
                this.daevidencija.Update(this.EvidencijaDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if ((DateAndTime.DateSerial(this.godina, this.mjesec, Conversions.ToInteger(e.Row.Cells["dan"].Value)).DayOfWeek == DayOfWeek.Saturday) | (DateAndTime.DateSerial(this.godina, this.mjesec, Conversions.ToInteger(e.Row.Cells["dan"].Value)).DayOfWeek == DayOfWeek.Sunday))
            {
                e.Row.Appearance.ForeColor = Color.Red;
            }
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                this.m_bDisablePosCHange = true;
                EVIDENCIJASelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<EVIDENCIJASelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    this.EvidencijaDataSet1.Clear();
                    this.daevidencija.FillByMJESECIDGODINEBROJEVIDENCIJE(this.EvidencijaDataSet1, Conversions.ToInteger(row["mjesec"]), Conversions.ToShort(row["idgodine"]), Conversions.ToInteger(row["brojevidencije"]));
                    this.mjesec = Conversions.ToInteger(row["mjesec"]);
                    this.godina = Conversions.ToInteger(row["idgodine"]);
                    this.BROJEVIDENCIJE = Conversions.ToInteger(row["BROJEVIDENCIJE"]);
                    this.UltraTextEditor1.Value = RuntimeHelpers.GetObjectValue(row["opisevidencije"]);
                    this.Parametri_MakniOznake();
                    this.m_bDisablePosCHange = false;
                    this.m_cm_PositionChanged(null, null);
                }
            }
        }

        private void UltraTextEditor1_ValueChanged(object sender, EventArgs e)
        {
        }

        [LocalCommandHandler("Uvecanje")]
        public void UvecanjeHandler(object sender, EventArgs e)
        {
        }

        private AutoHideControl _PripremaPlaceCustomAutoHideControl;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaBottom;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaLeft;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaRight;

        private UnpinnedTabArea _PripremaPlaceCustomUnpinnedTabAreaTop;

        private Button Button1;

        private Button Button2;

        private Button Button3;

        private Button Button4;

        private Button Button5;

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

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow3;

        private ELEMENTDataSet ElementDataSet1;

        private EVIDENCIJADataSet EvidencijaDataSet1;

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

        private Label Label1;

        private CurrencyManager m_cm;

        private PRPLACEDataSet PrplaceDataSet1;

        private RADNIKDataSet RadnikDataSet1;

        private RadnikPripremaDataSet RadnikPripremaDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraCalcManager UltraCalcManager1;

        private UltraDockManager UltraDockManager1;

        private UltraDropDown UltraDropDown1;

        private UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;

        private UltraGridExcelExporter UltraGridExcelExporter1;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox2;

        private UltraGroupBox UltraGroupBox3;

        private UltraTextEditor UltraTextEditor1;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea3;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

