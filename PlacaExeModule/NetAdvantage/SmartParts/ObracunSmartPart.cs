
using CrystalDecisions.CrystalReports.Engine;
using Deklarit;
using Deklarit.Data;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Deklarit.Utils;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win.UltraWinTree;
using KratkaRekapNamespace;
using Microsoft.Office.Interop.Excel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My.Resources;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Obracun;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer;

using System.Windows.Media.Imaging;

namespace NetAdvantage.SmartParts
{

    [SmartPart]
    public class ObracunSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private bool blokirajPromjenuPozicije;
        private bool bPromjeneMoguce;
        private BackgroundWorker bw;
        private IContainer components;
        private ReadWriteConnection connDefault;
        private GRUPEOLAKSICADataAdapter dagrupeolaksica;
        private KORISNIKDataAdapter dakorisnik;
        private OBRACUNDataAdapter daObracunGlobal;
        private RadnikZaObracunDataAdapter daRadnici;
        private SKUPPOREZAIDOPRINOSADataAdapter daSkupinePorezaIdoprinosa;
        public DateTime datumobracunastaza;
        private KORISNIKDataSet dsKorisnik;
        private S_OD_KREDIT_OBRACUNATDataSet dskreditObracunat;
        private S_OD_KRIZNI_POREZDataSet DSKRIZNI;
        private S_OD_OBUSTAVA_OBRACUNATADataSet dsObustavaobracunata;
        private S_OD_OO_MJESECNODataSet DSOO;
        private S_OD_POREZ_MJESECNODataSet DSPOREZMJESECNO;
        private S_OD_STAT_KREDITDataSet DSSTATKREDIT;
        public DataView dvBrutoElementi;
        private DataView dvDoprinosiIZ;
        private DataView dvDoprinosiNA;
        public DataView dvNetoElementi;
        private DataView dvporez;
        private fmProgress frmProg;
        public string godinaisplate;
        public string godinaobracuna;
        private SmartPartInfoProvider infoProvider;
        public string mjesecisplate;
        public decimal mjesecnifond;
        public string mjesecobracuna;
        private bool obracunavakrizni;
        private bool obracunavaobustave;
        private bool obracunavaolaksice;
        public decimal obrosnovica;
        private bool onemogucen_obracun_obustava;
        private bool onemogucen_obracun_olaksica;
        public decimal osnovnioo;
        private SqlCommand S_OD_REKAP_BRUTO;
        private SqlCommand S_OD_REKAP_FIKSNE;
        private SqlCommand S_OD_REKAP_ISPLATA;
        private SqlCommand S_OD_REKAP_KREDITNE;
        private SqlCommand S_OD_REKAP_NETO;
        private SqlCommand S_OD_REKAP_OLAKSICE;
        private SqlCommand S_OD_REKAP_POREZ;
        private SqlCommand S_OD_REKAP_POSTOTNE;
        public string sifraobracuna;
        public static string id_radnika;
        public static string id_element;
        public static DateTime razdoblje_od;
        public static DateTime razdoblje_do;
        public static string oznaka_mjeseca;
        private SmartPartInfo smartPartInfo1;
        private S_OD_STANJE_KREDITADataSet STANJEKREDITA;
        private S_OD_STANJE_OBUSTAVADataSet STANJEOBUSTAVA;
        public decimal tjednifond;
        public string txtOpisObracuna;

        public bool admin_kontrola = false;

        public ObracunSmartPart()
        {
            base.Load += new EventHandler(this.ObracunSmartPart_Load);
            this.S_OD_REKAP_POREZ = new SqlCommand();
            this.S_OD_REKAP_POSTOTNE = new SqlCommand();
            this.S_OD_REKAP_FIKSNE = new SqlCommand();
            this.S_OD_REKAP_KREDITNE = new SqlCommand();
            this.S_OD_REKAP_OLAKSICE = new SqlCommand();
            this.S_OD_REKAP_BRUTO = new SqlCommand();
            this.S_OD_REKAP_NETO = new SqlCommand();
            this.S_OD_REKAP_ISPLATA = new SqlCommand();
            this.obracunavaolaksice = false;
            this.obracunavaobustave = false;
            this.obracunavakrizni = false;
            this.DSKRIZNI = new S_OD_KRIZNI_POREZDataSet();
            this.DSPOREZMJESECNO = new S_OD_POREZ_MJESECNODataSet();
            this.DSOO = new S_OD_OO_MJESECNODataSet();
            this.dsObustavaobracunata = new S_OD_OBUSTAVA_OBRACUNATADataSet();
            this.dskreditObracunat = new S_OD_KREDIT_OBRACUNATDataSet();
            this.DSSTATKREDIT = new S_OD_STAT_KREDITDataSet();
            this.STANJEKREDITA = new S_OD_STANJE_KREDITADataSet();
            this.STANJEOBUSTAVA = new S_OD_STANJE_OBUSTAVADataSet();
            this.dsKorisnik = new KORISNIKDataSet();
            this.dakorisnik = new KORISNIKDataAdapter();
            this.bPromjeneMoguce = true;
            this.onemogucen_obracun_olaksica = false;
            this.onemogucen_obracun_obustava = false;
            this.dvDoprinosiIZ = new DataView();
            this.dvDoprinosiNA = new DataView();
            this.dvporez = new DataView();
            this.dvBrutoElementi = new DataView();
            this.dvNetoElementi = new DataView();
            this.dagrupeolaksica = new GRUPEOLAKSICADataAdapter();
            this.daSkupinePorezaIdoprinosa = new SKUPPOREZAIDOPRINOSADataAdapter();
            this.daObracunGlobal = new OBRACUNDataAdapter();
            this.daRadnici = new RadnikZaObracunDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Obračun plaće", "Obračun plaće");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private int AktivanZaposlenik()
        {
            if (this.currencyManagerZaposleniciObracun == null)
                return 0;

            try
            {
                if (this.currencyManagerZaposleniciObracun.Count > 0)
                {
                    return Conversions.ToInteger(NewLateBinding.LateIndexGet(this.currencyManagerZaposleniciObracun.Current, new object[] { "IDRADNIK" }, null));
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return 0;
        }

        private string AktivanZaposlenikPunoIme()
        {
            if (this.currencyManagerZaposleniciObracun == null)
                return "";

            try
            {
                if (this.currencyManagerZaposleniciObracun.Count > 0)
                {
                    return (DB.N2T(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.currencyManagerZaposleniciObracun.Current, new object[] { "PREZIME" }, null)), "") + " " + DB.N2T(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.currencyManagerZaposleniciObracun.Current, new object[] { "IME" }, null)), ""));
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
            return "";
        }

        private void Brisanje_bruto_Elemenata_za_Vise_radnika()
        {
            if (this.Obracun_Read_Only())
            {
                if (this.BrojOznacenihZaposlenika() == 0)
                {
                    MessageBox.Show("Nema označenih zaposlenika !", "MIPSED.7 - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmEleBrisiSvi svi2 = new frmEleBrisiSvi {
                        Text = "Briši bruto element označenim zaposlenicima"
                    };
                    using (frmEleBrisiSvi svi = svi2)
                    {
                        svi.lblSifEle.Text = "Bruto element:";
                        svi._vrsta_elementa = Conversions.ToString(2);
                        svi.__Parent_Obracun = this;
                        if (svi.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                this.Obracun_Svih_Zaposlenika();
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                                
                                
                                
                            }
                        }
                        else
                        {
                            Interaction.MsgBox("Odustali ste od brisanja elemenata označenim zaposlenicima", MsgBoxStyle.Information, "Obračun plaća");
                        }
                    }
                }
            }
        }

        private void Brisanje_neto_Elemenata_za_Vise_radnika()
        {
            if (this.Obracun_Read_Only())
            {
                if (this.BrojOznacenihZaposlenika() == 0)
                {
                    MessageBox.Show("Nema označenih zaposlenika za izvršavanje ove radnje!", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmEleBrisiSvi svi2 = new frmEleBrisiSvi {
                        Text = "Briši neto element označenim zaposlenicima"
                    };
                    using (frmEleBrisiSvi svi = svi2)
                    {
                        svi.lblSifEle.Text = "Neto element:";
                        svi._vrsta_elementa = Conversions.ToString(1);
                        svi.__Parent_Obracun = this;
                        if (svi.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                this.Obracun_Svih_Zaposlenika();
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                                
                            }
                        }
                        else
                        {
                            Interaction.MsgBox("Odustali ste od brisanja elemenata označenim zaposlenicima", MsgBoxStyle.Information, "Obračun plaća");
                        }
                    }
                }
            }
        }

        private void BrisiOznaceneRadnike()
        {
            if (this.Obracun_Read_Only())
            {
                if (this.BrojOznacenihZaposlenika() == 0)
                {
                    MessageBox.Show("Nema označenih zaposlenika !", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (this.BrojOznacenihZaposlenika() == this.UltraGrid1.Rows.Count)
                    {
                        if (MessageBox.Show("Sigurno želite brisanje svih zaposlenika iz obračuna i zatvaranje trenutnog obračuna?", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else if (MessageBox.Show("Želite li obrisati označene zaposlenike iz obračuna?", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    this.blokirajPromjenuPozicije = true;
                    for (int i = this.UltraGrid1.Rows.Count - 1; i >= 0; i += -1)
                    {
                        if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
                        {
                            this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[i];
                            ((DataRowView) this.BindingContext[this.ObracunDataSet1, "OBRACUNRADNICI"].Current).Delete();
                        }
                    }
                    try
                    {
                        this.daObracunGlobal.Update(this.ObracunDataSet1);
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }

                    if (this.ObracunDataSet1.ObracunRadnici.Rows.Count == 0)
                    {
                        ((DataRowView) this.BindingContext[this.ObracunDataSet1, "OBRACUN"].Current).Delete();
                        this.BindingContext[this.ObracunDataSet1, "OBRACUN"].EndCurrentEdit();
                        try
                        {
                            this.daObracunGlobal.Update(this.ObracunDataSet1);
                        }
                        catch (System.Exception exception3)
                        {
                            Interaction.MsgBox(exception3.Message, MsgBoxStyle.OkOnly, null);
                            throw exception3;
                            
                        }
                        this.ZapocniPonovo();
                        this.ListBox1.Items.Clear();
                        this.ListBox1.Items.Add(" ");
                        this.ListBox1.Items.Add("TRENUTNO NEMA OTVORENOG OBRAČUNA");
                    }
                    this.blokirajPromjenuPozicije = false;
                    this.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private int BrojOznacenihZaposlenika()
        {
            int num2 = 0;
            int num4 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
                {
                    num2++;
                }
            }
            return num2;
        }

        public int BrRataDoZadObr(string IDOBRACUN, int IDRADNIK, int IDKREDITOR, DateTime DATUMUGOVORA, DataSet STANJEKREDITA)
        {
            decimal num2 = 0;
            decimal num3 = 0;
            string str = "#" + DATUMUGOVORA.ToString(DateTimeFormatInfo.InvariantInfo) + "#";
            DataRow[] rowArray = STANJEKREDITA.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND IDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            DataRow[] rowArray2 = this.RadnikDataSet1.RADNIKKrediti.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND ZADKREDITIIDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            if (rowArray.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray[0]["BROJRATA"]);
            }
            else
            {
                num2 = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num3 = Conversions.ToDecimal(rowArray2[0]["ZADVECOTPLACENOBROJRATA"]);
            }
            else
            {
                num3 = new decimal();
            }
            return Convert.ToInt32(decimal.Add(num2, num3));
        }

        private void BrutoElementBrisi()
        {
            if (this.Obracun_Read_Only())
            {
                CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DatasetRekapitulacija1, "dtRekap"];
                if (manager.Count != 0)
                {
                    DataRowView current = (DataRowView) manager.Current;
                    if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["sifraelementa"])) && !Operators.ConditionalCompareObjectNotEqual(current["vrstaelementa"], 2, false))
                    {
                        this.dvBrutoElementi.Sort = "IDELEMENT";
                        this.dvBrutoElementi.RowFilter = "idelement=" + current["sifraelementa"] + " and IDVRSTAELEMENTA = 2 AND IDRADNIK = " + this.AktivanZaposlenik() +
                            " and elementrazdobljeod='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Od"]), "dd/MM/yyyy") + "' " +
                            " and elementrazdobljedo='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["do"]), "dd/MM/yyyy") + "'";

                        ((DataRowView) this.BindingContext[this.dvBrutoElementi].Current).Delete();
                        this.Obracunaj_Placu(true);
                    }
                }
            }
        }

        private void BrutoElementiUnesiOznacenima()
        {
            if (this.Obracun_Read_Only())
            {
                if (this.BrojOznacenihZaposlenika() == 0)
                {
                    MessageBox.Show("Nema označenih zaposlenika!", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmEleUnosSvi svi2 = new frmEleUnosSvi {
                        Text = "Unos bruto elementa označenim zaposlenicima"
                    };
                    frmEleUnosSvi svi = svi2;
                    svi.labelSifEle.Text = "Bruto element:";
                    svi._vrsta = Conversions.ToString(2);
                    svi._ParentFormObracun = this;
                    if (svi.ShowDialog() == DialogResult.OK)
                    {
                        this.Obracun_Svih_Zaposlenika();
                        foreach (UltraGridRow red in UltraGrid1.Rows)
                        {
                            if (red.Cells["oznacen"].Value.ToString() == "True")
                            {
                                id_radnika = red.Cells["IDRADNIK"].Value.ToString();
                                UpisiOznakuMjeseca(sifraobracuna);
                            }
                        }
                    }
                }
            }
        }

        private void BrutoElementPromjena()
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DatasetRekapitulacija1, "dtRekap"];

            if (manager.Count > 0)
            {
                DataRowView current = (DataRowView) manager.Current;
                if ((Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["sifraelementa"])) && !Operators.ConditionalCompareObjectNotEqual(current["vrstaelementa"], 2, false)) && this.Obracun_Read_Only())
                {
                    frmEleUnos unos2 = new frmEleUnos {
                        _cfm = this
                    };
                    frmEleUnos unos = unos2;
                    unos.cbSifra.ReadOnly = true;
                    unos.OdDatuma.ReadOnly = true;
                    unos.DoDatuma.ReadOnly = true;
                    this.dvBrutoElementi.Sort = "IDELEMENT";
                    unos._vrstaelementa = "2";
                    unos.__DataView = this.dvBrutoElementi;
                    unos.__DataView__ = this.dvNetoElementi;
                    this.dvBrutoElementi.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement=", current["sifraelementa"]), " and IDVRSTAELEMENTA = 2 "), "AND IDRADNIK = "), this.AktivanZaposlenik()), " and elementrazdobljeod='"), Strings.Format(RuntimeHelpers.GetObjectValue(current["Od"]), "dd/MM/yyyy")), "' and elementrazdobljedo='"), Strings.Format(RuntimeHelpers.GetObjectValue(current["do"]), "dd/MM/yyyy")), "'"));
                    unos.Text = string.Format("Izmjeni bruto element ({0}) na trenutnom zaposleniku ({1} - {2})", RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.BindingContext[this.dvBrutoElementi].Current, new object[] { "IDELEMENT" }, null)), this.AktivanZaposlenik(), this.AktivanZaposlenikPunoIme());
                    unos.lblSifEle.Text = "Bruto element:";
                    unos._drvElement = (DataRowView) this.BindingContext[this.dvBrutoElementi].Current;
                    unos.cbSifra.Enabled = false;
                    unos.OdDatuma.Enabled = false;
                    unos.DoDatuma.Enabled = false;
                    if (unos.ShowDialog() == DialogResult.OK)
                    {
                        this.Obracunaj_Placu(true);
                        UpisiOznakuMjeseca(sifraobracuna);
                    }
                    unos.Dispose();
                }
            }
        }

        private void BrutoElementUnos()
        {
            bool kontrola = false;
            if (this.currencyManagerZaposleniciObracun.Count == 0)
            {
                MessageBox.Show("U trenutnom obračunu nemate nadodanih zaposlenika.");
                return;
            }

            if (this.Obracun_Read_Only())
            {
                frmEleUnos unos2 = new frmEleUnos {
                    _cfm = this,
                    Text = "Unos bruto elementa na zaposleniku (" + Conversions.ToString(this.AktivanZaposlenik()) + " - " + this.AktivanZaposlenikPunoIme() + ")"
                };
                using (frmEleUnos unos = unos2)
                {
                    //object obj2 = new object();
                    DataRowView current = null;
                    //object obj3 = new object();
                    //object obj4 = new object();
                    //sobject obj5 = new object();
                    unos.lblSifEle.Text = "Bruto element:";
                    unos._vrstaelementa = "2";
                    unos.__DataView = this.dvBrutoElementi;
                    unos.__DataView__ = this.dvNetoElementi;
                    this.BindingContext[unos.__DataView].AddNew();
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "IDOBRACUN", this.sifraobracuna }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "IDRADNIK", RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.currencyManagerZaposleniciObracun.Current, new object[] { "IDRADNIK" }, null)) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "IDVRSTAELEMENTA", unos._vrstaelementa }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "ELEMENTRAZDOBLJEOD", DateAndTime.DateSerial(Conversions.ToInteger(this.godinaobracuna), Conversions.ToInteger(this.mjesecobracuna), 1) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "ELEMENTRAZDOBLJEDO", DateAndTime.DateSerial(Conversions.ToInteger(this.godinaobracuna), Conversions.ToInteger(this.mjesecobracuna), DateTime.DaysInMonth(Conversions.ToInteger(this.godinaobracuna), Conversions.ToInteger(this.mjesecobracuna))) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRSATI", 0 }, null, false, true);
                    if (this.BindingContext[this.ObracunDataSet1, "OBRACUNRADNICI"].Count > 0)
                    {
                        current = (DataRowView) this.BindingContext[this.ObracunDataSet1, "OBRACUNRADNICI"].Current;
                    }
                    else
                    {
                        return;
                    }
                    double satnica = 0;
                    decimal gstaza = 0;
                    decimal mstaza = 0;
                    decimal dstaza = 0;


                    //#OBR_1
                    DataRow drView = current.Row;
                    this.IzracunSatnice(ref drView, ref satnica, ref gstaza, ref mstaza, ref dstaza);

                    /*
                    obj2 = dstaza;
                    obj4 = mstaza;
                    obj3 = gstaza;
                    obj5 = satnica;*/

                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRSATNICA", DB.N20(RuntimeHelpers.GetObjectValue(satnica)) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRPOSTOTAK", 0 }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRIZNOS", 0 }, null, false, true);
                    unos._drvElement = (DataRowView) this.BindingContext[unos.__DataView].Current;
                    if (unos.ShowDialog() == DialogResult.OK)
                    {
                        this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
                        kontrola = true;
                    }
                    unos.Dispose();
                }
                this.Obracunaj_Placu(true);
                if (kontrola)
                {
                    UpisiOznakuMjeseca(sifraobracuna);
                }
            }
        }

        public static void UpisiOznakuMjeseca(string sifra_obracuna)
        {
            SqlClient client = new SqlClient();

            client.ExecuteNonQuery("Update ObracunElementi Set OznakaMjeseca = '" + oznaka_mjeseca + "' Where IDOBRACUN = '" + sifra_obracuna + "' And IDRADNIK = '" + id_radnika +
            "' And IDELEMENT = '" + id_element + "' And ELEMENTRAZDOBLJEOD = '" + razdoblje_od.ToString("yyyy-MM-dd") + "' And ELEMENTRAZDOBLJEDO = '" + razdoblje_do.ToString("yyyy-MM-dd") + "'");

            client.CloseConnection();
        }

        private void UpisiOznakuMjesecaSvima(string sifra_obracuna)
        {
            SqlClient client = new SqlClient();

            client.ExecuteNonQuery("Update ObracunElementi Set OznakaMjeseca = '" + oznaka_mjeseca + "' Where IDOBRACUN = '" + sifra_obracuna + "'");

            client.CloseConnection();
        }

        /*
        public void DesktopAlert()
        {
            this.UltraDesktopAlert1.Opacity = 0.9f;
            this.UltraDesktopAlert1.UseFlatMode = DefaultableBoolean.True;
            this.UltraDesktopAlert1.AnimationSpeed = Infragistics.Win.Misc.AnimationSpeed.Fast;
            UltraDesktopAlertShowWindowInfo windowInfo = new UltraDesktopAlertShowWindowInfo {
                Image = My.Resources.Resources.oko,
                Caption = string.Format("<a>{0}</a>", "Priprema platnih lista"),
                Text = string.Format("<a>{0}</a>", "Sačekajte trenutak"),
                FooterText = string.Format("<a>{0}</a>", "Mipsed obračun plaća"),
                Key = "MyWindow"
            };
            UltraDesktopAlertWindowInfo info2 = this.UltraDesktopAlert1.Show(windowInfo);
        }
        */

        [LocalCommandHandler("DodajRadnike")]
        public void DodajRadnikeHandler(object sender, EventArgs e)
        {
            this.Parametri_DodajOznaceneRadnike();
        }

        private void DoneChildFormInit(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bw.Dispose();
            this.frmProg.Close();
            this.daObracunGlobal.Update(this.ObracunDataSet1);
            DataRowView current = (DataRowView) this.BindingContext[this.ObracunDataSet1.ObracunRadnici].Current;
            this.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
            current = (DataRowView) this.currencyManagerZaposleniciObracun.Current;
            this.Platna_Ekran(current, true);
        }

        public void DovuciGO()
        {
            this.blokirajPromjenuPozicije = true;
            if (Interaction.MsgBox("Želite li odabrati element za redovan rad", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            {
                ELEMENTSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<ELEMENTSelectionListWorkItem>();
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    int num3 = Conversions.ToInteger(row["idelement"]);
                    if (Interaction.MsgBox("Želite li odabrati element za godišnji odmor", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                    {
                        ELEMENTSelectionListWorkItem item2 = this.Controller.WorkItem.Items.AddNew<ELEMENTSelectionListWorkItem>();
                        DataRow row2 = item2.ShowModal(true, "", null);
                        item2.Terminate();
                        if (row2 != null)
                        {
                            string fileName = string.Empty;
                            Workbook workbook = new Workbook();
                            int num2 = Conversions.ToInteger(row2["idelement"]);
                            OpenFileDialog dialog = new OpenFileDialog();
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                fileName = dialog.FileName;
                            }
                            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                            Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) Interaction.CreateObject("Excel.Application", "");
                            application = (Microsoft.Office.Interop.Excel.Application) Interaction.CreateObject("Excel.Application", "");
                            try
                            {
                                if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(fileName == ""))))
                                {
                                    Interaction.MsgBox("Nije odabrana datoteka", MsgBoxStyle.OkOnly, null);
                                }
                                else
                                {
                                    workbook = application.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                                }
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                                //application.Quit();
                                //return;
                            }
                            Worksheet worksheet = (Worksheet) workbook.Sheets["Sheet1"];
                            application.DisplayAlerts = false;
                            int num = 2;
                            Worksheet worksheet2 = worksheet;
                            int num4 = worksheet.Rows.Count - 1;
                            for (num = 2; num <= num4; num++)
                            {
                                if (NewLateBinding.LateGet(worksheet2.Cells[num, 1], null, "Value", new object[0], null, null, null) == null)
                                {
                                    break;
                                }
                                object obj2 = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                                OBRACUNDataSet.ObracunElementiRow row5 = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                                row5["idelement"] = num3;
                                row5["obrpostotak"] = 100;
                                row5["obrsati"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet2.Cells[num, 0x11], null, "Value", new object[0], null, null, null));
                                row5["obrsatnica"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet2.Cells[num, 15], null, "Value", new object[0], null, null, null));
                                row5["obriznos"] = DB.RoundUP(Conversions.ToDecimal(Operators.MultiplyObject(NewLateBinding.LateGet(worksheet2.Cells[num, 0x11], null, "Value", new object[0], null, null, null), NewLateBinding.LateGet(worksheet2.Cells[num, 15], null, "Value", new object[0], null, null, null))));
                                row5["idobracun"] = this.sifraobracuna;
                                row5["idradnik"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet2.Cells[num, 1], null, "Value", new object[0], null, null, null));
                                row5["elementrazdobljeod"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna), 1);
                                row5["elementrazdobljedo"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna) + 1, 1).AddDays(-1.0);
                                if (Operators.ConditionalCompareObjectGreater(Operators.MultiplyObject(NewLateBinding.LateGet(worksheet2.Cells[num, 0x11], null, "Value", new object[0], null, null, null), NewLateBinding.LateGet(worksheet2.Cells[num, 15], null, "Value", new object[0], null, null, null)), 0, false))
                                {
                                    try
                                    {
                                        this.ObracunDataSet1.ObracunElementi.Rows.Add(row5);
                                    }
                                    catch (System.Exception exception4)
                                    {
                                        throw exception4;
                                    }
                                }
                                this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
                                OBRACUNDataSet.ObracunElementiRow row3 = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                                row3["idelement"] = num2;
                                row3["obrpostotak"] = 100;
                                row3["obrsati"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet2.Cells[num, 0x10], null, "Value", new object[0], null, null, null));
                                row3["obrsatnica"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet2.Cells[num, 13], null, "Value", new object[0], null, null, null));
                                row3["obriznos"] = DB.RoundUP(Conversions.ToDecimal(Operators.MultiplyObject(NewLateBinding.LateGet(worksheet2.Cells[num, 0x10], null, "Value", new object[0], null, null, null), NewLateBinding.LateGet(worksheet2.Cells[num, 13], null, "Value", new object[0], null, null, null))));
                                row3["idobracun"] = this.sifraobracuna;
                                row3["idradnik"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(worksheet2.Cells[num, 1], null, "Value", new object[0], null, null, null));
                                row3["elementrazdobljeod"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna), 1);
                                row3["elementrazdobljedo"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna) + 1, 1).AddDays(-1.0);
                                if (Operators.ConditionalCompareObjectGreater(Operators.MultiplyObject(NewLateBinding.LateGet(worksheet2.Cells[num, 0x10], null, "Value", new object[0], null, null, null), NewLateBinding.LateGet(worksheet2.Cells[num, 13], null, "Value", new object[0], null, null, null)), 0, false))
                                {
                                    try
                                    {
                                        this.ObracunDataSet1.ObracunElementi.Rows.Add(row3);
                                    }
                                    catch (System.Exception exception5)
                                    {
                                        throw exception5;
                                    }
                                }
                                this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
                            }
                            worksheet2 = null;
                            this.SaveToDatabase();
                            this.Obracun_Svih_Zaposlenika();
                            this.blokirajPromjenuPozicije = false;
                            application.Quit();
                        }
                    }
                }
            }
        }

        [CommandHandler("DovuciIzGO")]
        public void DovuciIzGOCommandHandler(object sender, EventArgs e)
        {
            this.DovuciGO();
        }

        [CommandHandler("DovuciIzPripreme")]
        public void DovuciIzPripremeCommandHandler(object sender, EventArgs e)
        {
            ELEMENTDataSet dataSet = new ELEMENTDataSet();
            new ELEMENTDataAdapter().FillByIDVRSTAELEMENTA(dataSet, 1);
            PRPLACESelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<PRPLACESelectionListWorkItem>();
            DataRow row2 = item.ShowModal(true, "", null);
            item.Terminate();
            if (row2 != null)
            {
                IEnumerator enumerator = null;
                PRPLACEDataAdapter adapter2 = new PRPLACEDataAdapter();
                PRPLACEDataSet set2 = new PRPLACEDataSet();
                adapter2.FillByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(set2, Conversions.ToShort(row2["PRPLACEZAMJESEC"]), Conversions.ToInteger(row2["PRPLACEID"]), Conversions.ToShort(row2["PRPLACEZAGODINU"]));
                try
                {
                    enumerator = set2.PRPLACEPRPLACEELEMENTIRADNIK.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        bool[] flagArray;
                        DataRow current = (DataRow) enumerator.Current;
                        OBRACUNDataSet.ObracunElementiRow row = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                        row["idelement"] = RuntimeHelpers.GetObjectValue(current["idelement"]);
                        DataRow[] rowArray = this.ObracunDataSet1.ObracunElementi.Select(Conversions.ToString(Operators.ConcatenateObject("idosnovaosiguranja = '10' and idradnik = ", current["idradnik"])));
                        if (rowArray.Length > 0)
                        {
                            row["elementrazdobljeod"] = RuntimeHelpers.GetObjectValue(rowArray[0]["elementrazdobljeod"]);
                            row["elementrazdobljedo"] = RuntimeHelpers.GetObjectValue(rowArray[0]["elementrazdobljedo"]);
                        }
                        else
                        {
                            int godina = 0;
                            int mjesec = 0;

                            if (!int.TryParse(this.godinaobracuna.Trim(), out godina))
                            {
                                MessageBox.Show("Molimo, upišite ispravan podatak za GODINU!", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (!int.TryParse(this.mjesecobracuna.Trim(), out mjesec))
                            {
                                MessageBox.Show("Molimo, upišite ispravan podatak za MJESEC!", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            row["elementrazdobljeod"] = DateAndTime.DateSerial(godina, mjesec, 1);
                            row["elementrazdobljedo"] = DateAndTime.DateSerial(godina, mjesec + 1, 1).AddDays(-1.0);
                        }

                        row["obrpostotak"] = RuntimeHelpers.GetObjectValue(current["PRPLACEPOSTOTAK"]);
                        row["obrsati"] = RuntimeHelpers.GetObjectValue(current["PRPLACESATI"]);
                        row["obrsatnica"] = RuntimeHelpers.GetObjectValue(current["PRPLACESATNICA"]);
                        row["obriznos"] = RuntimeHelpers.GetObjectValue(current["PRPLACEIZNOS"]);
                        row["idobracun"] = this.sifraobracuna;
                        row["idradnik"] = RuntimeHelpers.GetObjectValue(current["idradnik"]);
                        DataRow[] rowArray2 = dataSet.ELEMENT.Select(Conversions.ToString(Operators.ConcatenateObject("idvrstaelementa = 1 and idelement = ", current["idelement"])));
                        bool right = false;
                        if (rowArray2.Length > 0)
                        {
                            right = true;
                        }
                        try
                        {
                            if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectGreater(current["PRPLACESATI"], 0, false), right)))
                            {
                                this.ObracunDataSet1.ObracunElementi.Rows.Add(row);
                            }
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                            
                            
                        }
                        object instance = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                        ReadOnlyConnection connection = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                        ReadOnlyCommand command = connection.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
                        if (command.IDbCommand.Parameters.Count == 0)
                        {
                            command.IDbCommand.Parameters.Add(new SqlParameter("@IDELEMENT", SqlDbType.Int));
                        }
                        command.SetParameter(0, RuntimeHelpers.GetObjectValue(current["idelement"]));
                        IDataReader reader = command.FetchData();
                        if (!command.HasMoreRows)
                        {
                            reader.Close();
                            object[] objArray2 = new object[] { connection };
                            flagArray = new bool[] { true };
                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray2, null, null, flagArray, true);
                            if (flagArray[0])
                            {
                                connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[0]), typeof(ReadOnlyConnection));
                            }
                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ELEMENT" }));
                        }
                        object[] arguments = new object[] { reader, 0 };
                        flagArray = new bool[] { true, false };
                        if (flagArray[0])
                        {
                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                        }
                        row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                        arguments = new object[] { reader, 1 };
                        flagArray = new bool[] { true, false };
                        if (flagArray[0])
                        {
                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                        }
                        row["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", arguments, null, null, flagArray));
                        arguments = new object[] { reader, 2 };
                        flagArray = new bool[] { true, false };
                        if (flagArray[0])
                        {
                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                        }
                        row["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                        reader.Close();
                        arguments = new object[] { connection };
                        flagArray = new bool[] { true };
                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                        if (flagArray[0])
                        {
                            connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                        }
                        if (!row.IsIDVRSTAELEMENTANull())
                        {
                            ReadOnlyConnection connection3 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                            ReadOnlyCommand command3 = connection3.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                            if (command3.IDbCommand.Parameters.Count == 0)
                            {
                                command3.IDbCommand.Parameters.Add(new SqlParameter("@IDVRSTAELEMENTA", SqlDbType.Int));
                            }
                            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDVRSTAELEMENTA"]));
                            IDataReader reader3 = command3.FetchData();
                            if (!command3.HasMoreRows)
                            {
                                reader3.Close();
                                arguments = new object[] { connection3 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                                throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "VRSTAELEMENT" }));
                            }
                            arguments = new object[] { reader3, 0 };
                            flagArray = new bool[] { true, false };
                            if (flagArray[0])
                            {
                                reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                            }
                            row["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                            reader3.Close();
                            arguments = new object[] { connection3 };
                            flagArray = new bool[] { true };
                            NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                            if (flagArray[0])
                            {
                                connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                            }
                        }
                        else
                        {
                            row["NAZIVVRSTAELEMENT"] = "";
                        }
                        if (!row.IsIDOSNOVAOSIGURANJANull())
                        {
                            ReadOnlyConnection connection2 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                            ReadOnlyCommand command2 = connection2.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] FROM [OSNOVAOSIGURANJA] (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                            if (command2.IDbCommand.Parameters.Count == 0)
                            {
                                command2.IDbCommand.Parameters.Add(new SqlParameter("@IDOSNOVAOSIGURANJA", SqlDbType.NVarChar, 2));
                            }
                            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDOSNOVAOSIGURANJA"]));
                            IDataReader reader2 = command2.FetchData();
                            if (!command2.HasMoreRows)
                            {
                                reader2.Close();
                                arguments = new object[] { connection2 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                                throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OSNOVAOSIGURANJA" }));
                            }
                            arguments = new object[] { reader2, 0 };
                            flagArray = new bool[] { true, false };
                            if (flagArray[0])
                            {
                                reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                            }
                            row["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                            reader2.Close();
                            arguments = new object[] { connection2 };
                            flagArray = new bool[] { true };
                            NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                            if (flagArray[0])
                            {
                                connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                            }
                        }
                        else
                        {
                            row["NAZIVOSNOVAOSIGURANJA"] = "";
                        }
                        this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                this.Obracun_Svih_Zaposlenika();
                //upis oznake mjeseca 3 iz pripreme place svim elementima i zaposlenicima
                oznaka_mjeseca = "3";
                UpisiOznakuMjesecaSvima(sifraobracuna);
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [CommandHandler("GOOdbici")]
        public void GOOBRACUNCommand(object sender, EventArgs e)
        {
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            GOOBRACUNWorkWithWorkItem item = this.Controller.WorkItem.Items.Get<GOOBRACUNWorkWithWorkItem>("GOOBRACUNWorkWithWorkItem");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<GOOBRACUNWorkWithWorkItem>("GOOBRACUNWorkWithWorkItem");
            }
            item.Show(item.Workspaces["main"]);
        }

        private void InitChildFormData(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            this.blokirajPromjenuPozicije = true;
            if (this.bPromjeneMoguce)
            {
                int count = this.BindingContext[this.ObracunDataSet1.ObracunRadnici].Count;
                int num5 = this.BindingContext[this.ObracunDataSet1.ObracunRadnici].Count - 1;
                num = 0;
                while (num <= num5)
                {
                    this.BindingContext[this.ObracunDataSet1.ObracunRadnici].Position = num;
                    DataRowView current = (DataRowView) this.BindingContext[this.ObracunDataSet1.ObracunRadnici].Current;
                    this.Izracun_Place(this.ObracunDataSet1, current);
                    decimal num4 = new decimal((((double) num) / ((double) count)) * 100.0);
                    this.bw.ReportProgress(Convert.ToInt32(num4));
                    num++;
                }
            }
            this.blokirajPromjenuPozicije = false;
            e.Result = num;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ulica");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mjesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("kucnibroj");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMRODJENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADAPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPCINESTANOVANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBENEFICIRANI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBENEFICIRANI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJPRIZNATIHMJESECI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TEKUCI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJANETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJANETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJMIROVINSKOG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJZDRAVSTVENOG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MBO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTOTAKOSLOBODJENJAODPOREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOEFICIJENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNSKIKOEFICIJENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNOMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVRADNOMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSTRUKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVSTRUKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ISKORISTENOOO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNATIPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("faktoo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TJEDNIFONDSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TJEDNIFONDSATISTAZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINESTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECISTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DANISTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMPRESTANKARADNOGODNOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTITULA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVTITULA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZBIRNINETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UZIMAUOBZIROSNOVICEDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGDIO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ORGANIZACIJSKIDIO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDIPIDENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTOTAKNASTAZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIKOBRACUNOSNOVICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOREKCIJAPRIREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ODBITAKPRIJEKOREKCIJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNAVAJOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_ObracunElementi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_OBRACUNObustave");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_OBRACUNKrediti");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_ObracunOlaksice");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_ObracunPorezi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ObracunRadnici_ObracunDoprinosi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oznacen", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUNIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJIZUZECE1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJIZUZECE2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJIZUZECE3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TEKUCIIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSIZUZECA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKRIZNIPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKRIZNIPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KRIZNISTOPA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn98 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn99 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn100 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn101 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn102 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKRIZNI1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn103 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKRIZNI2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn104 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKRIZNI3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn105 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn106 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn107 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn108 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn109 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICAKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn110 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn111 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICAPRETHODNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn112 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICAUKUPNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn113 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZPRETHODNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn114 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZUKUPNO");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_ObracunElementi", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn115 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn116 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn117 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn118 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELEMENTRAZDOBLJEOD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn119 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELEMENTRAZDOBLJEDO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn120 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOSNOVAOSIGURANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn121 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSNOVAOSIGURANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn122 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZDOBLJESESMIJEPREKLAPATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn123 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn124 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRSATNICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn125 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn126 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn127 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVRSTAELEMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn128 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTAELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn129 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRPOSTOTAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn130 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZBRAJASATEUFONDSATI");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_OBRACUNObustave", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn131 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn132 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn133 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn134 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn135 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn136 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn137 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn138 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn139 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn140 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn141 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJOBUSTAVA1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn142 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJOBUSTAVA2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn143 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJOBUSTAVA3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn144 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn145 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn146 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VRSTAOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn147 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTAOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn148 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn149 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTOTAKOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn150 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNATAOBUSTAVAUKUNAMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn151 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ISPLACENOKASA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn152 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDOKASA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn153 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBUSTAVLJENODOSADA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn154 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBUSTAVLJENODOSADABROJRATA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn155 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_OBRACUNKrediti", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn156 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn157 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn158 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn159 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUGOVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn160 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn161 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn162 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn163 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKREDITOR1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn164 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKREDITOR2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn165 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKREDITOR3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn166 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRSIFRAOPISAPLACANJAKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn167 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBROPISPLACANJAKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn168 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRMOKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn169 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRPOKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn170 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRMZKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn171 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRPZKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn172 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRIZNOSRATEKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn173 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNATIKUNSKIIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn174 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VECOTPLACENOBROJRATA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn175 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VECOTPLACENOUKUPNIIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn176 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNIZNOSKREDITA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn177 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOSADAOBUSTAVLJENO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn178 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRRATADOSADA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_ObracunOlaksice", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn179 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn180 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn181 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn182 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn183 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGRUPEOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn184 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVGRUPEOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn185 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MAXIMALNIIZNOSGRUPE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn186 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTIPOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn187 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVTIPOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn188 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn189 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn190 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJOLAKSICA1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn191 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJOLAKSICA2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn192 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJOLAKSICA3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn193 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn194 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn195 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn196 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn197 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn198 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn199 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZNOSOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn200 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNATAOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_ObracunPorezi", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn201 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn202 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn203 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn204 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn205 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPAPOREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn206 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZMJESECNO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn207 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn208 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn209 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn210 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn211 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn212 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn213 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn214 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn215 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNATIPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn216 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ObracunRadnici_ObracunDoprinosi", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn217 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn218 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn219 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn220 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn221 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn222 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn223 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn224 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn225 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn226 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn227 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn228 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn229 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn230 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn231 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn232 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn233 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn234 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNATIDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn235 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn236 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MINDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn237 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MAXDOPRINOS");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand10 = new Infragistics.Win.UltraWinGrid.UltraGridBand("dtRekap", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn238 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Opis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn239 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Iznos");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn240 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAELEMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn241 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("vrstaelementa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn242 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSATI");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn243 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("od");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn244 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("do");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Platna lista odabranog zaposlenika", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool = new Infragistics.Win.UltraWinToolbars.ButtonTool("Oznaci");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UkloniOznake");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("BrutoElementi");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DodajBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("IzmjeniBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BrisiBruto");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("NetoElementi");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DodajNeto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("IzmjeniNeto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BrisiNeto");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar4 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Radnje");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool23 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool4");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool24 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool5");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool25 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool6");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.TaskPaneTool tool26 = new Infragistics.Win.UltraWinToolbars.TaskPaneTool("TaskPaneTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Oznaci");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UkloniOznake");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DodajBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("IzmjeniBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BrisiBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DodajNeto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("IzmjeniNeto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BrisiNeto");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool20 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool1");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool21 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool2");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool22 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool3");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool17 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool4");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool18 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool5");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool19 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool6");
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("e752b100-c524-4912-b48a-be6c45b9bd95"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("13ffd687-3293-41d0-a7a6-2b8a1d1fc65f"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("e752b100-c524-4912-b48a-be6c45b9bd95"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("92b36030-618b-435d-a145-c55d4587150d"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("0fe50929-40b8-489e-b03d-160eb42db5a3"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("92b36030-618b-435d-a145-c55d4587150d"), -1);
            this.UltraCheckEditor2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.UltraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            //this.UltraCheckEditor3 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.UltraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtSifraobracuna = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.BrojRadnika = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.chkKreditneObustave = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkFiksneObustave = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkPostotneObustave = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.UltraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ObracunDataSet1 = new Placa.OBRACUNDataSet();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DatasetRekapitulacija1 = new datasetRekapitulacijaEkran();
            this._Panel2_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.UltraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._Panel2_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Panel2_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Panel2_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.SkupporezaidoprinosaDataSet1 = new Placa.SKUPPOREZAIDOPRINOSADataSet();
            this.RadnikDataSet1 = new Placa.RADNIKDataSet();
            this.GrupeolaksicaDataSet1 = new Placa.GRUPEOLAKSICADataSet();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._ObracunSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.UltraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.UltraDesktopAlert1 = new Infragistics.Win.Misc.UltraDesktopAlert(this.components);
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifraobracuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObracunDataSet1)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetRekapitulacija1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkupporezaidoprinosaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadnikDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrupeolaksicaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDesktopAlert1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraCheckEditor2
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            appearance13.FontData.BoldAsString = "True";
            this.UltraCheckEditor2.ForeColor = System.Drawing.Color.DarkBlue;
            this.UltraCheckEditor2.Appearance = appearance13;
            this.UltraCheckEditor2.BackColor = System.Drawing.Color.Transparent;
            this.UltraCheckEditor2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraCheckEditor2.Location = new System.Drawing.Point(189, 357);
            this.UltraCheckEditor2.Name = "UltraCheckEditor2";
            this.UltraCheckEditor2.Size = new System.Drawing.Size(135, 30);
            this.UltraCheckEditor2.TabIndex = 112;
            this.UltraCheckEditor2.Text = "Obračunaj obustave";
            this.UltraCheckEditor2.UseAppStyling = false;
            this.UltraCheckEditor2.CheckedChanged += new System.EventHandler(this.UltraCheckEditor2_CheckedChanged);
            // 
            // UltraCheckEditor1
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.FontData.BoldAsString = "True";
            this.UltraCheckEditor1.ForeColor = System.Drawing.Color.DarkBlue;
            this.UltraCheckEditor1.Appearance = appearance9;
            this.UltraCheckEditor1.BackColor = System.Drawing.Color.Transparent;
            this.UltraCheckEditor1.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraCheckEditor1.Location = new System.Drawing.Point(5, 331);
            this.UltraCheckEditor1.Name = "UltraCheckEditor1";
            this.UltraCheckEditor1.Size = new System.Drawing.Size(123, 30);
            this.UltraCheckEditor1.TabIndex = 111;
            this.UltraCheckEditor1.Text = "Obračunaj olakšice";
            this.UltraCheckEditor1.UseAppStyling = false;
            this.UltraCheckEditor1.CheckedChanged += new System.EventHandler(this.UltraCheckEditor1_CheckedChanged);
            // 
            // UltraCheckEditor3
            // 
            /*
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.FontData.BoldAsString = "True";
            this.UltraCheckEditor3.Appearance = appearance8;
            this.UltraCheckEditor3.BackColor = System.Drawing.Color.Transparent;
            this.UltraCheckEditor3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraCheckEditor3.Location = new System.Drawing.Point(10, 357);
            this.UltraCheckEditor3.Name = "UltraCheckEditor3";
            this.UltraCheckEditor3.Size = new System.Drawing.Size(173, 30);
            this.UltraCheckEditor3.TabIndex = 113;
            this.UltraCheckEditor3.Text = "Obračunaj pos.por";
            this.UltraCheckEditor3.UseAppStyling = false;
            this.UltraCheckEditor3.CheckedChanged += new System.EventHandler(this.UltraCheckEditor3_CheckedChanged);
            */
            // 
            // UltraGroupBox3
            // 
            this.UltraGroupBox3.Controls.Add(this.UltraGroupBox1);
            this.UltraGroupBox3.Controls.Add(this.UltraGroupBox2);
            this.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox3.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(423, 791);
            this.UltraGroupBox3.TabIndex = 83;
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.txtSifraobracuna);
            this.UltraGroupBox1.Controls.Add(this.ListBox1);
            //this.UltraGroupBox1.Controls.Add(this.UltraCheckEditor3);
            this.UltraGroupBox1.Controls.Add(this.UltraCheckEditor1);
            this.UltraGroupBox1.Controls.Add(this.BrojRadnika);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel12);
            this.UltraGroupBox1.Controls.Add(this.chkKreditneObustave);
            this.UltraGroupBox1.Controls.Add(this.UltraCheckEditor2);
            this.UltraGroupBox1.Controls.Add(this.chkFiksneObustave);
            this.UltraGroupBox1.Controls.Add(this.chkPostotneObustave);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.UltraGroupBox1.Location = new System.Drawing.Point(3, 0);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(417, 216);
            this.UltraGroupBox1.TabIndex = 82;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtSifraobracuna
            // 
            this.txtSifraobracuna.Location = new System.Drawing.Point(287, 47);
            this.txtSifraobracuna.Name = "txtSifraobracuna";
            this.txtSifraobracuna.Size = new System.Drawing.Size(100, 21);
            this.txtSifraobracuna.TabIndex = 115;
            this.txtSifraobracuna.Text = "UltraTextEditor1";
            this.txtSifraobracuna.Visible = false;
            // 
            // ListBox1
            // 
            this.ListBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(8, 3);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(403, 160);
            this.ListBox1.TabIndex = 114;
            // 
            // BrojRadnika
            // 
            this.BrojRadnika.AutoSize = true;
            this.BrojRadnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrojRadnika.Location = new System.Drawing.Point(287, 275);
            this.BrojRadnika.Name = "BrojRadnika";
            this.BrojRadnika.Size = new System.Drawing.Size(0, 0);
            this.BrojRadnika.TabIndex = 108;
            this.BrojRadnika.UseAppStyling = false;
            // 
            // UltraLabel12
            // 
            appearance31.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel12.Appearance = appearance31;
            this.UltraLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel12.Location = new System.Drawing.Point(10, 169);
            this.UltraLabel12.Name = "UltraLabel12";
            this.UltraLabel12.Size = new System.Drawing.Size(201, 14);
            this.UltraLabel12.TabIndex = 106;
            this.UltraLabel12.Text = "Vrste obustava koje se obračunavaju";
            this.UltraLabel12.UseAppStyling = false;
            // 
            // chkKreditneObustave
            // 
            appearance28.BackColor = System.Drawing.Color.Transparent;
            this.chkKreditneObustave.Appearance = appearance28;
            this.chkKreditneObustave.BackColor = System.Drawing.Color.Transparent;
            this.chkKreditneObustave.BackColorInternal = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkKreditneObustave.Location = new System.Drawing.Point(264, 189);
            this.chkKreditneObustave.Name = "chkKreditneObustave";
            this.chkKreditneObustave.Size = new System.Drawing.Size(120, 20);
            this.chkKreditneObustave.TabIndex = 110;
            this.chkKreditneObustave.Text = "Krediti";
            this.chkKreditneObustave.UseAppStyling = false;
            // 
            // chkFiksneObustave
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.chkFiksneObustave.Appearance = appearance10;
            this.chkFiksneObustave.BackColor = System.Drawing.Color.Transparent;
            this.chkFiksneObustave.BackColorInternal = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkFiksneObustave.Location = new System.Drawing.Point(138, 189);
            this.chkFiksneObustave.Name = "chkFiksneObustave";
            this.chkFiksneObustave.Size = new System.Drawing.Size(120, 20);
            this.chkFiksneObustave.TabIndex = 109;
            this.chkFiksneObustave.Text = "Fiksne obustave";
            this.chkFiksneObustave.UseAppStyling = false;
            // 
            // chkPostotneObustave
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.chkPostotneObustave.Appearance = appearance12;
            this.chkPostotneObustave.BackColor = System.Drawing.Color.Transparent;
            this.chkPostotneObustave.BackColorInternal = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkPostotneObustave.Location = new System.Drawing.Point(12, 189);
            this.chkPostotneObustave.Name = "chkPostotneObustave";
            this.chkPostotneObustave.Size = new System.Drawing.Size(120, 20);
            this.chkPostotneObustave.TabIndex = 107;
            this.chkPostotneObustave.Text = "Postotne obustave";
            this.chkPostotneObustave.UseAppStyling = false;
            // 
            // UltraGroupBox2
            // 
            this.UltraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UltraGroupBox2.Controls.Add(this.UltraGrid1);
            this.UltraGroupBox2.Location = new System.Drawing.Point(4, 215);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(418, 570);
            this.UltraGroupBox2.TabIndex = 114;
            this.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "ObracunRadnici";
            this.UltraGrid1.DataSource = this.ObracunDataSet1;
            appearance15.BackColor = System.Drawing.Color.AliceBlue;
            this.UltraGrid1.DisplayLayout.Appearance = appearance15;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Caption = "Šifr.";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Width = 70;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 109;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 7;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 9;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 12;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.VisiblePosition = 13;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.VisiblePosition = 14;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.VisiblePosition = 15;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.VisiblePosition = 16;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.VisiblePosition = 17;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.Header.VisiblePosition = 18;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.Header.VisiblePosition = 19;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn19.Header.VisiblePosition = 20;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.Header.VisiblePosition = 21;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn21.Header.VisiblePosition = 22;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn22.Header.VisiblePosition = 23;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn23.Header.VisiblePosition = 24;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn24.Header.VisiblePosition = 25;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn25.Header.VisiblePosition = 26;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn26.Header.VisiblePosition = 27;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn27.Header.VisiblePosition = 28;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn28.Header.VisiblePosition = 29;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn29.Header.VisiblePosition = 30;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn30.Header.VisiblePosition = 31;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn31.Header.VisiblePosition = 32;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn32.Header.VisiblePosition = 33;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn33.Header.VisiblePosition = 34;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn34.Header.VisiblePosition = 35;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn35.Header.VisiblePosition = 36;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn36.Header.VisiblePosition = 37;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 38;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 39;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn39.Header.VisiblePosition = 40;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn40.Header.VisiblePosition = 41;
            ultraGridColumn40.Hidden = true;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn41.Header.VisiblePosition = 42;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn42.Header.VisiblePosition = 43;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn43.Header.VisiblePosition = 44;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn44.Header.VisiblePosition = 45;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn45.Header.VisiblePosition = 46;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn46.Header.VisiblePosition = 47;
            ultraGridColumn46.Hidden = true;
            ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn47.Header.VisiblePosition = 48;
            ultraGridColumn47.Hidden = true;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn48.Header.VisiblePosition = 49;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn49.Header.VisiblePosition = 50;
            ultraGridColumn49.Hidden = true;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn50.Header.VisiblePosition = 51;
            ultraGridColumn50.Hidden = true;
            ultraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn51.Header.VisiblePosition = 52;
            ultraGridColumn51.Hidden = true;
            ultraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn52.Header.VisiblePosition = 53;
            ultraGridColumn52.Hidden = true;
            ultraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn53.Header.VisiblePosition = 54;
            ultraGridColumn53.Hidden = true;
            ultraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn54.Header.VisiblePosition = 55;
            ultraGridColumn54.Hidden = true;
            ultraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn55.Header.VisiblePosition = 56;
            ultraGridColumn55.Hidden = true;
            ultraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn56.Header.VisiblePosition = 57;
            ultraGridColumn56.Hidden = true;
            ultraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn57.Header.VisiblePosition = 58;
            ultraGridColumn57.Hidden = true;
            ultraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn58.Header.VisiblePosition = 59;
            ultraGridColumn58.Hidden = true;
            ultraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn59.Header.VisiblePosition = 60;
            ultraGridColumn59.Hidden = true;
            ultraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn60.Header.VisiblePosition = 61;
            ultraGridColumn60.Hidden = true;
            ultraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn61.Header.VisiblePosition = 62;
            ultraGridColumn61.Hidden = true;
            ultraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn62.Header.VisiblePosition = 63;
            ultraGridColumn62.Hidden = true;
            ultraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn63.Header.VisiblePosition = 64;
            ultraGridColumn63.Hidden = true;
            ultraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn64.Header.VisiblePosition = 68;
            ultraGridColumn64.Hidden = true;
            ultraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn65.Format = "#,##0.00";
            ultraGridColumn65.Header.Caption = "Obr.osnovica";
            ultraGridColumn65.Header.VisiblePosition = 65;
            ultraGridColumn65.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn66.Header.VisiblePosition = 66;
            ultraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn67.Header.VisiblePosition = 67;
            ultraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn68.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn68.Header.Caption = "Obračunavaj obs. i kred.";
            ultraGridColumn68.Header.VisiblePosition = 5;
            ultraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn69.Header.VisiblePosition = 70;
            ultraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn70.Header.VisiblePosition = 69;
            ultraGridColumn71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn71.Header.VisiblePosition = 71;
            ultraGridColumn72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn72.Header.VisiblePosition = 72;
            ultraGridColumn73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn73.Header.VisiblePosition = 73;
            ultraGridColumn74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn74.Header.VisiblePosition = 74;
            ultraGridColumn75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn75.Header.VisiblePosition = 75;
            ultraGridColumn76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn76.Header.VisiblePosition = 76;
            ultraGridColumn77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn77.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn77.DataType = typeof(bool);
            ultraGridColumn77.DefaultCellValue = false;
            ultraGridColumn77.Header.Caption = "Oz.";
            ultraGridColumn77.Header.VisiblePosition = 1;
            ultraGridColumn77.Width = 51;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
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
            ultraGridColumn19,
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
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66,
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn77});
            ultraGridBand1.Header.Caption = "";
            ultraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            ultraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance1.BackColor = System.Drawing.Color.White;
            ultraGridBand1.Override.HeaderAppearance = appearance1;
            ultraGridBand1.Override.HeaderPlacement = Infragistics.Win.UltraWinGrid.HeaderPlacement.FixedOnTop;
            ultraGridBand1.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn78.Header.VisiblePosition = 0;
            ultraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn79.Header.VisiblePosition = 1;
            ultraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn80.Header.VisiblePosition = 2;
            ultraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn81.Header.VisiblePosition = 3;
            ultraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn82.Header.VisiblePosition = 4;
            ultraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn83.Header.VisiblePosition = 5;
            ultraGridColumn84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn84.Header.VisiblePosition = 6;
            ultraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn85.Header.VisiblePosition = 7;
            ultraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn86.Header.VisiblePosition = 8;
            ultraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn87.Header.VisiblePosition = 9;
            ultraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn88.Header.VisiblePosition = 10;
            ultraGridColumn89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn89.Header.VisiblePosition = 11;
            ultraGridColumn90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn90.Header.VisiblePosition = 12;
            ultraGridColumn91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn91.Header.VisiblePosition = 13;
            ultraGridColumn92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn92.Header.VisiblePosition = 14;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90,
            ultraGridColumn91,
            ultraGridColumn92});
            ultraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn93.Header.VisiblePosition = 0;
            ultraGridColumn93.Width = 32;
            ultraGridColumn94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn94.Header.VisiblePosition = 1;
            ultraGridColumn94.Width = 70;
            ultraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn95.Header.VisiblePosition = 2;
            ultraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn96.Header.VisiblePosition = 3;
            ultraGridColumn96.Width = 109;
            ultraGridColumn97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn97.Header.VisiblePosition = 4;
            ultraGridColumn98.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn98.Header.VisiblePosition = 5;
            ultraGridColumn99.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn99.Header.VisiblePosition = 6;
            ultraGridColumn100.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn100.Header.VisiblePosition = 7;
            ultraGridColumn101.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn101.Header.VisiblePosition = 8;
            ultraGridColumn102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn102.Header.VisiblePosition = 9;
            ultraGridColumn103.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn103.Header.VisiblePosition = 10;
            ultraGridColumn104.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn104.Header.VisiblePosition = 11;
            ultraGridColumn105.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn105.Header.VisiblePosition = 12;
            ultraGridColumn106.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn106.Header.VisiblePosition = 13;
            ultraGridColumn107.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn107.Header.VisiblePosition = 14;
            ultraGridColumn108.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn108.Header.VisiblePosition = 15;
            ultraGridColumn109.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn109.Header.VisiblePosition = 16;
            ultraGridColumn110.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn110.Header.VisiblePosition = 17;
            ultraGridColumn111.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn111.Header.VisiblePosition = 18;
            ultraGridColumn112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn112.Header.VisiblePosition = 19;
            ultraGridColumn113.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn113.Header.VisiblePosition = 20;
            ultraGridColumn114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn114.Header.VisiblePosition = 21;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn93,
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn96,
            ultraGridColumn97,
            ultraGridColumn98,
            ultraGridColumn99,
            ultraGridColumn100,
            ultraGridColumn101,
            ultraGridColumn102,
            ultraGridColumn103,
            ultraGridColumn104,
            ultraGridColumn105,
            ultraGridColumn106,
            ultraGridColumn107,
            ultraGridColumn108,
            ultraGridColumn109,
            ultraGridColumn110,
            ultraGridColumn111,
            ultraGridColumn112,
            ultraGridColumn113,
            ultraGridColumn114});
            ultraGridColumn115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn115.Header.VisiblePosition = 0;
            ultraGridColumn115.Width = 32;
            ultraGridColumn116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn116.Header.VisiblePosition = 1;
            ultraGridColumn116.Width = 70;
            ultraGridColumn117.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn117.Header.VisiblePosition = 2;
            ultraGridColumn118.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn118.Header.VisiblePosition = 3;
            ultraGridColumn118.Width = 109;
            ultraGridColumn119.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn119.Header.VisiblePosition = 4;
            ultraGridColumn120.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn120.Header.VisiblePosition = 5;
            ultraGridColumn121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn121.Header.VisiblePosition = 6;
            ultraGridColumn122.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn122.Header.VisiblePosition = 7;
            ultraGridColumn123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn123.Header.VisiblePosition = 8;
            ultraGridColumn124.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn124.Header.VisiblePosition = 9;
            ultraGridColumn125.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn125.Header.VisiblePosition = 10;
            ultraGridColumn126.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn126.Header.VisiblePosition = 11;
            ultraGridColumn127.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn127.Header.VisiblePosition = 12;
            ultraGridColumn128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn128.Header.VisiblePosition = 13;
            ultraGridColumn129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn129.Header.VisiblePosition = 14;
            ultraGridColumn130.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn130.Header.VisiblePosition = 15;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn115,
            ultraGridColumn116,
            ultraGridColumn117,
            ultraGridColumn118,
            ultraGridColumn119,
            ultraGridColumn120,
            ultraGridColumn121,
            ultraGridColumn122,
            ultraGridColumn123,
            ultraGridColumn124,
            ultraGridColumn125,
            ultraGridColumn126,
            ultraGridColumn127,
            ultraGridColumn128,
            ultraGridColumn129,
            ultraGridColumn130});
            ultraGridColumn131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn131.Header.VisiblePosition = 0;
            ultraGridColumn131.Width = 32;
            ultraGridColumn132.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn132.Header.VisiblePosition = 1;
            ultraGridColumn132.Width = 70;
            ultraGridColumn133.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn133.Header.VisiblePosition = 2;
            ultraGridColumn134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn134.Header.VisiblePosition = 3;
            ultraGridColumn134.Width = 109;
            ultraGridColumn135.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn135.Header.VisiblePosition = 4;
            ultraGridColumn136.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn136.Header.VisiblePosition = 5;
            ultraGridColumn137.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn137.Header.VisiblePosition = 6;
            ultraGridColumn138.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn138.Header.VisiblePosition = 7;
            ultraGridColumn139.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn139.Header.VisiblePosition = 8;
            ultraGridColumn140.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn140.Header.VisiblePosition = 9;
            ultraGridColumn141.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn141.Header.VisiblePosition = 10;
            ultraGridColumn142.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn142.Header.VisiblePosition = 11;
            ultraGridColumn143.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn143.Header.VisiblePosition = 12;
            ultraGridColumn144.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn144.Header.VisiblePosition = 13;
            ultraGridColumn145.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn145.Header.VisiblePosition = 14;
            ultraGridColumn146.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn146.Header.VisiblePosition = 15;
            ultraGridColumn147.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn147.Header.VisiblePosition = 16;
            ultraGridColumn148.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn148.Header.VisiblePosition = 17;
            ultraGridColumn149.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn149.Header.VisiblePosition = 18;
            ultraGridColumn150.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn150.Header.VisiblePosition = 19;
            ultraGridColumn151.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn151.Header.VisiblePosition = 20;
            ultraGridColumn152.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn152.Header.VisiblePosition = 21;
            ultraGridColumn153.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn153.Header.VisiblePosition = 22;
            ultraGridColumn154.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn154.Header.VisiblePosition = 23;
            ultraGridColumn155.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn155.Header.VisiblePosition = 24;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn131,
            ultraGridColumn132,
            ultraGridColumn133,
            ultraGridColumn134,
            ultraGridColumn135,
            ultraGridColumn136,
            ultraGridColumn137,
            ultraGridColumn138,
            ultraGridColumn139,
            ultraGridColumn140,
            ultraGridColumn141,
            ultraGridColumn142,
            ultraGridColumn143,
            ultraGridColumn144,
            ultraGridColumn145,
            ultraGridColumn146,
            ultraGridColumn147,
            ultraGridColumn148,
            ultraGridColumn149,
            ultraGridColumn150,
            ultraGridColumn151,
            ultraGridColumn152,
            ultraGridColumn153,
            ultraGridColumn154,
            ultraGridColumn155});
            ultraGridColumn156.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn156.Header.VisiblePosition = 0;
            ultraGridColumn156.Width = 32;
            ultraGridColumn157.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn157.Header.VisiblePosition = 1;
            ultraGridColumn157.Width = 70;
            ultraGridColumn158.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn158.Header.VisiblePosition = 2;
            ultraGridColumn159.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn159.Header.VisiblePosition = 3;
            ultraGridColumn159.Width = 109;
            ultraGridColumn160.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn160.Header.VisiblePosition = 4;
            ultraGridColumn161.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn161.Header.VisiblePosition = 5;
            ultraGridColumn162.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn162.Header.VisiblePosition = 6;
            ultraGridColumn163.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn163.Header.VisiblePosition = 7;
            ultraGridColumn164.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn164.Header.VisiblePosition = 8;
            ultraGridColumn165.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn165.Header.VisiblePosition = 9;
            ultraGridColumn166.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn166.Header.VisiblePosition = 10;
            ultraGridColumn167.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn167.Header.VisiblePosition = 11;
            ultraGridColumn168.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn168.Header.VisiblePosition = 12;
            ultraGridColumn169.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn169.Header.VisiblePosition = 13;
            ultraGridColumn170.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn170.Header.VisiblePosition = 14;
            ultraGridColumn171.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn171.Header.VisiblePosition = 15;
            ultraGridColumn172.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn172.Header.VisiblePosition = 16;
            ultraGridColumn173.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn173.Header.VisiblePosition = 17;
            ultraGridColumn174.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn174.Header.VisiblePosition = 18;
            ultraGridColumn175.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn175.Header.VisiblePosition = 19;
            ultraGridColumn176.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn176.Header.VisiblePosition = 20;
            ultraGridColumn177.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn177.Header.VisiblePosition = 21;
            ultraGridColumn178.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn178.Header.VisiblePosition = 22;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn156,
            ultraGridColumn157,
            ultraGridColumn158,
            ultraGridColumn159,
            ultraGridColumn160,
            ultraGridColumn161,
            ultraGridColumn162,
            ultraGridColumn163,
            ultraGridColumn164,
            ultraGridColumn165,
            ultraGridColumn166,
            ultraGridColumn167,
            ultraGridColumn168,
            ultraGridColumn169,
            ultraGridColumn170,
            ultraGridColumn171,
            ultraGridColumn172,
            ultraGridColumn173,
            ultraGridColumn174,
            ultraGridColumn175,
            ultraGridColumn176,
            ultraGridColumn177,
            ultraGridColumn178});
            ultraGridColumn179.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn179.Header.VisiblePosition = 0;
            ultraGridColumn179.Width = 32;
            ultraGridColumn180.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn180.Header.VisiblePosition = 1;
            ultraGridColumn180.Width = 70;
            ultraGridColumn181.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn181.Header.VisiblePosition = 2;
            ultraGridColumn182.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn182.Header.VisiblePosition = 3;
            ultraGridColumn182.Width = 109;
            ultraGridColumn183.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn183.Header.VisiblePosition = 4;
            ultraGridColumn184.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn184.Header.VisiblePosition = 5;
            ultraGridColumn185.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn185.Header.VisiblePosition = 6;
            ultraGridColumn186.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn186.Header.VisiblePosition = 7;
            ultraGridColumn187.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn187.Header.VisiblePosition = 8;
            ultraGridColumn188.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn188.Header.VisiblePosition = 9;
            ultraGridColumn189.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn189.Header.VisiblePosition = 10;
            ultraGridColumn190.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn190.Header.VisiblePosition = 11;
            ultraGridColumn191.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn191.Header.VisiblePosition = 12;
            ultraGridColumn192.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn192.Header.VisiblePosition = 13;
            ultraGridColumn193.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn193.Header.VisiblePosition = 14;
            ultraGridColumn194.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn194.Header.VisiblePosition = 15;
            ultraGridColumn195.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn195.Header.VisiblePosition = 16;
            ultraGridColumn196.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn196.Header.VisiblePosition = 17;
            ultraGridColumn197.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn197.Header.VisiblePosition = 18;
            ultraGridColumn198.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn198.Header.VisiblePosition = 19;
            ultraGridColumn199.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn199.Header.VisiblePosition = 20;
            ultraGridColumn200.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn200.Header.VisiblePosition = 21;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn179,
            ultraGridColumn180,
            ultraGridColumn181,
            ultraGridColumn182,
            ultraGridColumn183,
            ultraGridColumn184,
            ultraGridColumn185,
            ultraGridColumn186,
            ultraGridColumn187,
            ultraGridColumn188,
            ultraGridColumn189,
            ultraGridColumn190,
            ultraGridColumn191,
            ultraGridColumn192,
            ultraGridColumn193,
            ultraGridColumn194,
            ultraGridColumn195,
            ultraGridColumn196,
            ultraGridColumn197,
            ultraGridColumn198,
            ultraGridColumn199,
            ultraGridColumn200});
            ultraGridColumn201.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn201.Header.VisiblePosition = 0;
            ultraGridColumn201.Width = 32;
            ultraGridColumn202.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn202.Header.VisiblePosition = 1;
            ultraGridColumn202.Width = 70;
            ultraGridColumn203.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn203.Header.VisiblePosition = 2;
            ultraGridColumn204.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn204.Header.VisiblePosition = 3;
            ultraGridColumn204.Width = 109;
            ultraGridColumn205.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn205.Header.VisiblePosition = 4;
            ultraGridColumn206.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn206.Header.VisiblePosition = 5;
            ultraGridColumn207.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn207.Header.VisiblePosition = 6;
            ultraGridColumn208.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn208.Header.VisiblePosition = 7;
            ultraGridColumn209.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn209.Header.VisiblePosition = 8;
            ultraGridColumn210.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn210.Header.VisiblePosition = 9;
            ultraGridColumn211.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn211.Header.VisiblePosition = 10;
            ultraGridColumn212.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn212.Header.VisiblePosition = 11;
            ultraGridColumn213.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn213.Header.VisiblePosition = 12;
            ultraGridColumn214.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn214.Header.VisiblePosition = 13;
            ultraGridColumn215.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn215.Header.VisiblePosition = 14;
            ultraGridColumn216.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn216.Header.VisiblePosition = 15;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn201,
            ultraGridColumn202,
            ultraGridColumn203,
            ultraGridColumn204,
            ultraGridColumn205,
            ultraGridColumn206,
            ultraGridColumn207,
            ultraGridColumn208,
            ultraGridColumn209,
            ultraGridColumn210,
            ultraGridColumn211,
            ultraGridColumn212,
            ultraGridColumn213,
            ultraGridColumn214,
            ultraGridColumn215,
            ultraGridColumn216});
            ultraGridColumn217.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn217.Header.VisiblePosition = 0;
            ultraGridColumn217.Width = 32;
            ultraGridColumn218.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn218.Header.VisiblePosition = 1;
            ultraGridColumn218.Width = 70;
            ultraGridColumn219.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn219.Header.VisiblePosition = 2;
            ultraGridColumn220.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn220.Header.VisiblePosition = 3;
            ultraGridColumn220.Width = 109;
            ultraGridColumn221.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn221.Header.VisiblePosition = 4;
            ultraGridColumn222.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn222.Header.VisiblePosition = 5;
            ultraGridColumn223.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn223.Header.VisiblePosition = 6;
            ultraGridColumn224.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn224.Header.VisiblePosition = 7;
            ultraGridColumn225.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn225.Header.VisiblePosition = 8;
            ultraGridColumn226.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn226.Header.VisiblePosition = 9;
            ultraGridColumn227.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn227.Header.VisiblePosition = 10;
            ultraGridColumn228.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn228.Header.VisiblePosition = 11;
            ultraGridColumn229.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn229.Header.VisiblePosition = 12;
            ultraGridColumn230.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn230.Header.VisiblePosition = 13;
            ultraGridColumn231.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn231.Header.VisiblePosition = 14;
            ultraGridColumn232.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn232.Header.VisiblePosition = 15;
            ultraGridColumn233.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn233.Header.VisiblePosition = 16;
            ultraGridColumn234.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn234.Header.VisiblePosition = 17;
            ultraGridColumn235.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn235.Header.VisiblePosition = 18;
            ultraGridColumn236.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn236.Header.VisiblePosition = 19;
            ultraGridColumn237.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn237.Header.VisiblePosition = 20;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn217,
            ultraGridColumn218,
            ultraGridColumn219,
            ultraGridColumn220,
            ultraGridColumn221,
            ultraGridColumn222,
            ultraGridColumn223,
            ultraGridColumn224,
            ultraGridColumn225,
            ultraGridColumn226,
            ultraGridColumn227,
            ultraGridColumn228,
            ultraGridColumn229,
            ultraGridColumn230,
            ultraGridColumn231,
            ultraGridColumn232,
            ultraGridColumn233,
            ultraGridColumn234,
            ultraGridColumn235,
            ultraGridColumn236,
            ultraGridColumn237});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance16;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance17.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance18.BorderColor = System.Drawing.Color.LightGray;
            appearance18.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance18;
            appearance20.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance20.BorderColor = System.Drawing.Color.Black;
            appearance20.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(412, 567);
            this.UltraGrid1.TabIndex = 56;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UltraGrid1_MouseDown);
            // 
            // ObracunDataSet1
            // 
            this.ObracunDataSet1.DataSetName = "OBRACUNDataSet";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.UltraGrid2);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Left);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Right);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Top);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Bottom);
            this.Panel2.Location = new System.Drawing.Point(0, 18);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(603, 791);
            this.Panel2.TabIndex = 3;
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.DataMember = "dtRekap";
            this.UltraGrid2.DataSource = this.DatasetRekapitulacija1;
            appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.UltraGrid2.DisplayLayout.Appearance = appearance;
            this.UltraGrid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn238.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn238.Header.VisiblePosition = 0;
            ultraGridColumn238.Width = 267;
            ultraGridColumn239.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn239.CellAppearance = appearance2;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn239.Header.Appearance = appearance3;
            ultraGridColumn239.Header.VisiblePosition = 1;
            ultraGridColumn239.Width = 78;
            ultraGridColumn240.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn240.Header.VisiblePosition = 2;
            ultraGridColumn240.Hidden = true;
            ultraGridColumn241.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn241.Header.VisiblePosition = 3;
            ultraGridColumn241.Hidden = true;
            ultraGridColumn242.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn242.CellAppearance = appearance4;
            appearance5.TextHAlignAsString = "Right";
            ultraGridColumn242.Header.Appearance = appearance5;
            ultraGridColumn242.Header.Caption = "Sati";
            ultraGridColumn242.Header.VisiblePosition = 4;
            ultraGridColumn242.Width = 57;
            ultraGridColumn243.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn243.Header.Caption = "Razdoblje od";
            ultraGridColumn243.Header.VisiblePosition = 5;
            ultraGridColumn243.Width = 103;
            ultraGridColumn244.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn244.Header.Caption = "Razdoblje do";
            ultraGridColumn244.Header.VisiblePosition = 6;
            ultraGridColumn244.Width = 96;
            ultraGridBand10.Columns.AddRange(new object[] {
            ultraGridColumn238,
            ultraGridColumn239,
            ultraGridColumn240,
            ultraGridColumn241,
            ultraGridColumn242,
            ultraGridColumn243,
            ultraGridColumn244});
            ultraGridBand10.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            ultraGridBand10.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand10);
            this.UltraGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance7;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance11.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance14.BorderColor = System.Drawing.Color.LightGray;
            appearance14.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance14;
            appearance19.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance19.BorderColor = System.Drawing.Color.Black;
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid2.Location = new System.Drawing.Point(0, 112);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(603, 679);
            this.UltraGrid2.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "Platna lista odabranog zaposlenika";
            this.UltraToolTipManager1.SetUltraToolTip(this.UltraGrid2, ultraToolTipInfo1);
            this.UltraGrid2.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.UltraGrid2_InitializeRow);
            this.UltraGrid2.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid2_DoubleClickRow);
            // 
            // DatasetRekapitulacija1
            // 
            this.DatasetRekapitulacija1.DataSetName = "datasetRekapitulacijaEkran";
            this.DatasetRekapitulacija1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _Panel2_Toolbars_Dock_Area_Left
            // 
            this._Panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 112);
            this._Panel2_Toolbars_Dock_Area_Left.Name = "_Panel2_Toolbars_Dock_Area_Left";
            this._Panel2_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 679);
            this._Panel2_Toolbars_Dock_Area_Left.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // UltraToolbarsManager1
            // 
            this.UltraToolbarsManager1.DesignerFlags = 1;
            this.UltraToolbarsManager1.DockWithinContainer = this.Panel2;
            this.UltraToolbarsManager1.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Unfold;
            this.UltraToolbarsManager1.Office2007UICompatibility = false;
            this.UltraToolbarsManager1.ShowFullMenusDelay = 500;
            this.UltraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(877, 461);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(219, 66);
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool,
            tool9});
            ultraToolbar1.Text = "UltraToolbar1";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 3;
            ultraToolbar2.FloatingLocation = new System.Drawing.Point(890, 456);
            ultraToolbar2.FloatingSize = new System.Drawing.Size(437, 24);
            tool12.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool13.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool14.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool12,
            tool13,
            tool14});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.RightOfImage;
            ultraToolbar2.Text = "BrutoElementi";
            ultraToolbar3.DockedColumn = 0;
            ultraToolbar3.DockedRow = 2;
            ultraToolbar3.FloatingLocation = new System.Drawing.Point(823, 443);
            ultraToolbar3.FloatingSize = new System.Drawing.Size(302, 46);
            tool4.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool5.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool5.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar3.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool3,
            tool4,
            tool5});
            ultraToolbar3.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.RightOfImage;
            ultraToolbar3.Text = "NetoElementi";
            ultraToolbar4.DockedColumn = 0;
            ultraToolbar4.DockedRow = 1;
            ultraToolbar4.FloatingLocation = new System.Drawing.Point(869, 435);
            ultraToolbar4.FloatingSize = new System.Drawing.Size(553, 22);
            tool23.Control = this.UltraCheckEditor2;
            tool24.Control = this.UltraCheckEditor1;
            tool25.CanSetWidth = true;
            //tool25.Control = this.UltraCheckEditor3;
            tool25.InstanceProps.Width = 173;
            ultraToolbar4.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool23,
            tool24,
            tool25});
            ultraToolbar4.Text = "Radnje";
            this.UltraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2,
            ultraToolbar3,
            ultraToolbar4});
            this.UltraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.UltraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            this.UltraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            appearance24.FontData.BoldAsString = "True";
            appearance24.FontData.Name = "Tahoma";
            this.UltraToolbarsManager1.ToolbarSettings.Appearance = appearance24;
            this.UltraToolbarsManager1.ToolbarSettings.CaptionPlacement = Infragistics.Win.TextPlacement.RightOfImage;
            this.UltraToolbarsManager1.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            tool26.SharedProps.Caption = "TaskPaneTool1";
            tool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool10.SharedProps.Caption = "Označi sve";
            tool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool11.SharedProps.Caption = "Ukloni oznake";
            tool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool15.SharedProps.Caption = "Dodaj bruto";
            tool16.SharedProps.Caption = "Izmjeni bruto";
            tool2.SharedProps.Caption = "Brisi bruto";
            tool6.SharedProps.Caption = "Dodaj neto";
            tool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool7.SharedProps.Caption = "Izmjeni neto";
            tool8.SharedProps.Caption = "Brisi neto";
            tool20.SharedProps.Caption = "ControlContainerTool1";
            tool21.SharedProps.Caption = "ControlContainerTool2";
            tool22.SharedProps.Caption = "ControlContainerTool3";
            tool22.SharedProps.Width = 186;
            tool17.Control = this.UltraCheckEditor2;
            tool17.SharedProps.Caption = "ControlContainerTool4";
            tool18.Control = this.UltraCheckEditor1;
            tool18.SharedProps.Caption = "ControlContainerTool5";
            tool19.CanSetWidth = true;
            //tool19.Control = this.UltraCheckEditor3;
            tool19.SharedProps.Caption = "ControlContainerTool6";
            tool19.SharedProps.Width = 173;
            this.UltraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool26,
            tool10,
            tool11,
            tool15,
            tool16,
            tool2,
            tool6,
            tool7,
            tool8,
            tool20,
            tool21,
            tool22,
            tool17,
            tool18,
            tool19});
            this.UltraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.UltraToolbarsManager1_ToolClick);
            // 
            // _Panel2_Toolbars_Dock_Area_Right
            // 
            this._Panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(603, 112);
            this._Panel2_Toolbars_Dock_Area_Right.Name = "_Panel2_Toolbars_Dock_Area_Right";
            this._Panel2_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 679);
            this._Panel2_Toolbars_Dock_Area_Right.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // _Panel2_Toolbars_Dock_Area_Top
            // 
            this._Panel2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Panel2_Toolbars_Dock_Area_Top.Name = "_Panel2_Toolbars_Dock_Area_Top";
            this._Panel2_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(603, 112);
            this._Panel2_Toolbars_Dock_Area_Top.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // _Panel2_Toolbars_Dock_Area_Bottom
            // 
            this._Panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 791);
            this._Panel2_Toolbars_Dock_Area_Bottom.Name = "_Panel2_Toolbars_Dock_Area_Bottom";
            this._Panel2_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(603, 0);
            this._Panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // SkupporezaidoprinosaDataSet1
            // 
            this.SkupporezaidoprinosaDataSet1.DataSetName = "SKUPPOREZAIDOPRINOSADataSet";
            // 
            // RadnikDataSet1
            // 
            this.RadnikDataSet1.DataSetName = "RADNIKDataSet";
            // 
            // GrupeolaksicaDataSet1
            // 
            this.GrupeolaksicaDataSet1.DataSetName = "GRUPEOLAKSICADataSet";
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.WorkerReportsProgress = true;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("92b36030-618b-435d-a145-c55d4587150d");
            dockableControlPane1.Control = this.UltraGroupBox3;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(3, 27, 506, 817);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Podaci o obračunu";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(423, 809);
            dockableControlPane2.Control = this.Panel2;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(530, 0, 501, 809);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "...";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(603, 809);
            dockAreaPane2.UnfilledSize = new System.Drawing.Size(100, 100);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.UltraDockManager1.ShowCloseButton = false;
            this.UltraDockManager1.ShowDisabledButtons = false;
            this.UltraDockManager1.ShowMenuButton = Infragistics.Win.DefaultableBoolean.False;
            this.UltraDockManager1.ShowPinButton = false;
            this.UltraDockManager1.ShowToolTips = false;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _ObracunSmartPartUnpinnedTabAreaLeft
            // 
            this._ObracunSmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._ObracunSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._ObracunSmartPartUnpinnedTabAreaLeft.Name = "_ObracunSmartPartUnpinnedTabAreaLeft";
            this._ObracunSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._ObracunSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 809);
            this._ObracunSmartPartUnpinnedTabAreaLeft.TabIndex = 3;
            // 
            // _ObracunSmartPartUnpinnedTabAreaRight
            // 
            this._ObracunSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._ObracunSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1031, 0);
            this._ObracunSmartPartUnpinnedTabAreaRight.Name = "_ObracunSmartPartUnpinnedTabAreaRight";
            this._ObracunSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._ObracunSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 809);
            this._ObracunSmartPartUnpinnedTabAreaRight.TabIndex = 4;
            // 
            // _ObracunSmartPartUnpinnedTabAreaTop
            // 
            this._ObracunSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._ObracunSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._ObracunSmartPartUnpinnedTabAreaTop.Name = "_ObracunSmartPartUnpinnedTabAreaTop";
            this._ObracunSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._ObracunSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1031, 0);
            this._ObracunSmartPartUnpinnedTabAreaTop.TabIndex = 5;
            // 
            // _ObracunSmartPartUnpinnedTabAreaBottom
            // 
            this._ObracunSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ObracunSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 809);
            this._ObracunSmartPartUnpinnedTabAreaBottom.Name = "_ObracunSmartPartUnpinnedTabAreaBottom";
            this._ObracunSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._ObracunSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1031, 0);
            this._ObracunSmartPartUnpinnedTabAreaBottom.TabIndex = 6;
            // 
            // _ObracunSmartPartAutoHideControl
            // 
            this._ObracunSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunSmartPartAutoHideControl.Location = new System.Drawing.Point(944, 0);
            this._ObracunSmartPartAutoHideControl.Name = "_ObracunSmartPartAutoHideControl";
            this._ObracunSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._ObracunSmartPartAutoHideControl.Size = new System.Drawing.Size(18, 755);
            this._ObracunSmartPartAutoHideControl.TabIndex = 7;
            // 
            // UltraToolTipManager1
            // 
            this.UltraToolTipManager1.ContainingControl = this;
            this.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.WindowsVista;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(428, 809);
            this.WindowDockingArea1.TabIndex = 84;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraGroupBox3);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(423, 809);
            this.DockableWindow1.TabIndex = 86;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(428, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(603, 809);
            this.WindowDockingArea2.TabIndex = 85;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel2);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(603, 809);
            this.DockableWindow2.TabIndex = 87;
            // 
            // ObracunSmartPart
            // 
            this.Controls.Add(this._ObracunSmartPartAutoHideControl);
            this.Controls.Add(this._ObracunSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._ObracunSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._ObracunSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._ObracunSmartPartUnpinnedTabAreaRight);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Name = "ObracunSmartPart";
            this.Size = new System.Drawing.Size(1031, 809);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifraobracuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObracunDataSet1)).EndInit();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetRekapitulacija1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkupporezaidoprinosaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadnikDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrupeolaksicaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDesktopAlert1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //public void IspisiPlatne()
        //{
        //    string str = string.Empty;
        //    DataRow current;
        //    IEnumerator enumerator = null;
        //    IEnumerator enumerator2 = null;
        //    IEnumerator enumerator3 = null;
        //    //this.DesktopAlert();
        //    ReportDocument document = new ReportDocument();
        //    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
        //        StartPosition = FormStartPosition.CenterParent,
        //        Modal = true,
        //        Title = "Pregled izvještaja",
        //        Description = "Pregled",
        //        Icon = ImageResourcesNew.mbs
        //    };
        //    try
        //    {
        //        enumerator = this.ObracunDataSet1.OBRACUNKrediti.Rows.GetEnumerator();
        //        while (enumerator.MoveNext())
        //        {
        //            current = (DataRow) enumerator.Current;
        //            current["dosadaobustavljeno"] = this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
        //            current["BRRATADOSADA"] = this.BrRataDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator is IDisposable)
        //        {
        //            (enumerator as IDisposable).Dispose();
        //        }
        //    }
        //    try
        //    {
        //        enumerator2 = this.ObracunDataSet1.OBRACUNObustave.Rows.GetEnumerator();
        //        while (enumerator2.MoveNext())
        //        {
        //            current = (DataRow) enumerator2.Current;
        //            current["obustavljenodosada"] = this.Obustave_Iznos(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //            current["obustavljenodosadabrojrata"] = this.Obustave_BrojRata(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //            current["OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE"] = this.Obustave_StanjeKase(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator2 is IDisposable)
        //        {
        //            (enumerator2 as IDisposable).Dispose();
        //        }
        //    }
        //    DataSet set = new DataSet();
        //    try
        //    {
        //        enumerator3 = this.ObracunDataSet1.Tables.GetEnumerator();
        //        while (enumerator3.MoveNext())
        //        {
        //            System.Data.DataTable table = (System.Data.DataTable) enumerator3.Current;
        //            set.Tables.Add(table.Copy());
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator3 is IDisposable)
        //        {
        //            (enumerator3 as IDisposable).Dispose();
        //        }
        //    }
        //    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaListaOrg.rpt");

        //    // Set connection string from config in existing LogonProperties
        //    document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
        //    document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
        //    document.DataSourceConnections[0].IntegratedSecurity = false;

        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
        //    //document.Subreports["DoprinosiNa"].SetDatabaseLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);


        //    document.SetDataSource(set);
        //    document.RecordSelectionFormula = "{OBRACUN.IDOBRACUN} = '" + this.sifraobracuna + "'";
        //    string str8 = "";
        //    int num2 = this.UltraGrid1.Rows.Count - 1;
        //    for (int i = 0; i <= num2; i++)
        //    {
        //        if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
        //        {
        //            if (str8 != "")
        //            {
        //                str8 = str8 + " OR ";
        //            }
        //            str8 = str8 + "{OBRACUNradnici.IDRADNIK} = " + this.UltraGrid1.Rows[i].Cells["IDRADNIK"].Value.ToString();
        //        }
        //    }
        //    if (str8 != "")
        //    {
        //        ReportDocument document2 = document;
        //        document2.RecordSelectionFormula = document2.RecordSelectionFormula + " AND (" + str8 + ")";
        //    }
        //    KORISNIKDataSet dataSet = new KORISNIKDataSet();
        //    new KORISNIKDataAdapter().Fill(dataSet);
        //    string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
        //    string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
        //    string str3 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
        //    string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
        //    string str9 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
        //    string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
        //    DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
        //    if (rowArray.Length > 0)
        //    {
        //        str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
        //    }
        //    else
        //    {
        //        str3 = "";
        //    }
        //    document.SetParameterValue("ADRESA2", str2);
        //    document.SetParameterValue("ADRESA", str);
        //    document.SetParameterValue("USTANOVA", string.Format("{0} Žrn: {1}", str6, str3));
        //    document.SetParameterValue("MB", str5);
        //    document.SetParameterValue("TELEFON", str9);
        //    document.SetParameterValue("FAX", str4);
        //    document.SetParameterValue("mjesec_rijecima", DB.MjesecNazivPlatna(Conversions.ToInteger(this.mjesecobracuna)));
        //    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
        //    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
        //    if (item == null)
        //    {
        //        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
        //    }
        //    item.Izvjestaj = document;
        //    item.Show(item.Workspaces["main"]);
        //    this.UltraDesktopAlert1.CloseAll();
        //}

        public void IspisiPlatneDoprinosNA()
        {
            string str = string.Empty;
            DataRow current;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            IEnumerator enumerator3 = null;
            //this.DesktopAlert();
            IBAN iban = new IBAN();
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            try
            {
                enumerator = this.ObracunDataSet1.OBRACUNKrediti.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow)enumerator.Current;
                    current["dosadaobustavljeno"] = this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
                    current["BRRATADOSADA"] = this.BrRataDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
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
                enumerator2 = this.ObracunDataSet1.OBRACUNObustave.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    current = (DataRow)enumerator2.Current;
                    current["obustavljenodosada"] = this.Obustave_Iznos(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
                    current["obustavljenodosadabrojrata"] = this.Obustave_BrojRata(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
                    current["OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE"] = this.Obustave_StanjeKase(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
                }
            }
            finally
            {
                if (enumerator2 is IDisposable)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
            }
            DataSet set = new DataSet();
            try
            {
                enumerator3 = this.ObracunDataSet1.Tables.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    System.Data.DataTable table = (System.Data.DataTable)enumerator3.Current;
                    set.Tables.Add(table.Copy());
                }
            }
            finally
            {
                if (enumerator3 is IDisposable)
                {
                    (enumerator3 as IDisposable).Dispose();
                }
            }
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaListaNew2.rpt");

            // Set connection string from config in existing LogonProperties
            document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            document.DataSourceConnections[0].IntegratedSecurity = false;

            document.Subreports["DoprinosiNA"].Database.Tables[0].LogOnInfo.ConnectionInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
            document.Subreports["DoprinosiNA"].Database.Tables[0].LogOnInfo.ConnectionInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;
            document.Subreports["DoprinosiNA"].Database.Tables[0].LogOnInfo.ConnectionInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
            document.Subreports["DoprinosiNA"].Database.Tables[0].LogOnInfo.ConnectionInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            document.Subreports["DoprinosiNA"].SetDatabaseLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);

            string racun = string.Empty;

            foreach (DataRow row in set.Tables["ObracunRadnici"].Rows)
            {
                racun = row["VBDIBANKE"].ToString() + "-" + row["Tekuci"].ToString();
                row["Tekuci"] = iban.GenerirajIBANIzBrojaRacuna(racun, true, false);
            }

            foreach (DataRow row in set.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"].Rows)
            {
                racun = row["VBDIIZUZECE"].ToString() + "-" + row["TEKUCIIZUZECE"].ToString();
                row["TEKUCIIZUZECE"] = iban.GenerirajIBANIzBrojaRacuna(racun, true, false);
            }
            
            document.SetDataSource(set);
            document.RecordSelectionFormula = "{OBRACUN.IDOBRACUN} = '" + this.sifraobracuna + "'";
            string str8 = "";
            int num2 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
                {
                    if (str8 != "")
                    {
                        str8 = str8 + " OR ";
                    }
                    str8 = str8 + "{OBRACUNradnici.IDRADNIK} = " + this.UltraGrid1.Rows[i].Cells["IDRADNIK"].Value.ToString();
                }
            }
            if (str8 != "")
            {
                ReportDocument document2 = document;
                document2.RecordSelectionFormula = document2.RecordSelectionFormula + " AND (" + str8 + ")";
            }
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
            string str3 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
            string str9 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
            string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
            DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
            if (rowArray.Length > 0)
            {
                str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
            }
            else
            {
                str3 = "";
            }
            document.SetParameterValue("ADRESA2", str2);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("USTANOVA", string.Format("{0} IBAN: {1}", str6, iban.GenerirajIBANIzBrojaRacuna(str3, true, false)));
            document.SetParameterValue("MB", str5);
            document.SetParameterValue("TELEFON", str9);
            document.SetParameterValue("FAX", str4);
            document.SetParameterValue("mjesec_rijecima", DB.MjesecNazivPlatna(Conversions.ToInteger(this.mjesecobracuna)));
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"]);
            this.UltraDesktopAlert1.CloseAll();
        }

        //public void IspisiPlatne_Abeceda()
        //{
        //    DataRow current = null;
        //    IEnumerator enumerator = null;
        //    IEnumerator enumerator2 = null;
        //    IEnumerator enumerator3 = null;
        //    //this.DesktopAlert();
        //    ReportDocument document = new ReportDocument();
        //    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
        //        StartPosition = FormStartPosition.CenterParent,
        //        Modal = true,
        //        Title = "Pregled izvještaja",
        //        Description = "Pregled",
        //        Icon = ImageResourcesNew.mbs
        //    };
        //    try
        //    {
        //        enumerator = this.ObracunDataSet1.OBRACUNKrediti.Rows.GetEnumerator();
        //        while (enumerator.MoveNext())
        //        {
        //            current = (DataRow) enumerator.Current;
        //            current["dosadaobustavljeno"] = this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
        //            current["BRRATADOSADA"] = this.BrRataDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator is IDisposable)
        //        {
        //            (enumerator as IDisposable).Dispose();
        //        }
        //    }
        //    try
        //    {
        //        enumerator2 = this.ObracunDataSet1.OBRACUNObustave.Rows.GetEnumerator();
        //        while (enumerator2.MoveNext())
        //        {
        //            current = (DataRow) enumerator2.Current;
        //            current["obustavljenodosada"] = this.Obustave_Iznos(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //            current["obustavljenodosadabrojrata"] = this.Obustave_BrojRata(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //            current["OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE"] = this.Obustave_StanjeKase(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator2 is IDisposable)
        //        {
        //            (enumerator2 as IDisposable).Dispose();
        //        }
        //    }
        //    DataSet set = new DataSet();
        //    try
        //    {
        //        enumerator3 = this.ObracunDataSet1.Tables.GetEnumerator();
        //        while (enumerator3.MoveNext())
        //        {
        //            System.Data.DataTable table = (System.Data.DataTable) enumerator3.Current;
        //            if (table.TableName == "ObracunRadnici")
        //            {
        //                System.Data.DataTable table2 = new System.Data.DataTable();
        //                table2 = new DataView(table) { Sort = "prezime" }.ToTable();
        //                set.Tables.Add(table2);
        //            }
        //            else
        //            {
        //                set.Tables.Add(table.Copy());
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator3 is IDisposable)
        //        {
        //            (enumerator3 as IDisposable).Dispose();
        //        }
        //    }
        //    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaListaOrg.rpt");

        //    // Set connection string from config in existing LogonProperties
        //    document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
        //    document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
        //    document.DataSourceConnections[0].IntegratedSecurity = false;

        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
        //    //document.Subreports["DoprinosiNa"].SetDatabaseLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);


        //    document.SetDataSource(set);
        //    KORISNIKDataSet dataSet = new KORISNIKDataSet();
        //    new KORISNIKDataAdapter().Fill(dataSet);
        //    string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
        //    string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
        //    string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
        //    string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
        //    string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
        //    string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
        //    string str3 = "";
        //    DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
        //    if (rowArray.Length > 0)
        //    {
        //        str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
        //    }
        //    else
        //    {
        //        str3 = "";
        //    }
        //    document.SetParameterValue("ADRESA2", str2);
        //    document.SetParameterValue("ADRESA", str);
        //    document.SetParameterValue("USTANOVA", str6 + " Žrn:" + str3);
        //    document.SetParameterValue("MB", str5);
        //    document.SetParameterValue("TELEFON", str8);
        //    document.SetParameterValue("FAX", str4);
        //    document.SetParameterValue("mjesec_rijecima", DB.MjesecNazivPlatna(Conversions.ToInteger(this.mjesecobracuna)));
        //    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
        //    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
        //    if (item == null)
        //    {
        //        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
        //    }
        //    item.Izvjestaj = document;
        //    item.Show(item.Workspaces["main"]);
        //    this.UltraDesktopAlert1.CloseAll();
        //}
        //public void IspisiPlatneNove()
        //{
        //    IBAN iban = new IBAN();
        //    ReportDocument document = new ReportDocument();
        //    SqlClient client = new SqlClient();
        //    bool otpremnina = false;
        //    bool volonter = false;
        //    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
        //    {
        //        StartPosition = FormStartPosition.CenterParent,
        //        Modal = true,
        //        Title = "Pregled izvještaja",
        //        Description = "Pregled",
        //        Icon = ImageResourcesNew.mbs
        //    };
            
        //    //provjera dali je otpremnina ili placa
        //    try
        //    {
        //        System.Data.DataTable tblElementi = client.GetDataTable("Select ObracunElementi.IDRADNIK, ObracunElementi.IDELEMENT, Element.Oznaka From ObracunElementi " +
        //        "Inner Join Element On ObracunElementi.IDELEMENT = Element.IDELEMENT Where ObracunElementi.IDOBRACUN = '" + sifraobracuna + "'");

        //        foreach (DataRow row in tblElementi.Rows)
        //        {
        //            if (row["Oznaka"].ToString() == "5" | row["Oznaka"].ToString() == "6")
        //            {
        //                otpremnina = true;
        //            }

        //            if (otpremnina)
        //            {
        //                if (row["Oznaka"].ToString() != "5" & row["Oznaka"].ToString() != "6")
        //                {
        //                    MessageBox.Show("Nije moguće Koristiti elemente za otpremninu sa ostalim elementima unutar jednog obračuna!");
        //                    return;
        //                }
        //            }

        //            if (row["IDELEMENT"].ToString() == "65" | row["IDELEMENT"].ToString() == "1001" | row["IDELEMENT"].ToString() == "1002")
        //            {
        //                volonter = true;
        //            }
        //        }
        //    }
        //    catch { }

        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Connection = client.sqlConnection;
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    System.Data.DataTable tbl = new System.Data.DataTable();

        //    if (otpremnina)
        //    {
        //        document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaOtpremninaNova.rpt");
        //        sqlCommand.CommandText = "sp_OtpremninaNova";
                
        //    }
        //    else if(volonter)
        //    {
        //        document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptVolonterNova.rpt");
        //        sqlCommand.CommandText = "sp_PlatnaNova";
        //    }
        //    else
        //    {
        //        document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaPlacaNova.rpt");
        //        sqlCommand.CommandText = "sp_PlatnaNova";
        //    }
        //    sqlCommand.Parameters.AddWithValue("@IDOBRACUN", sifraobracuna);

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = sqlCommand;
        //    da.Fill(tbl);            

        //    // Set connection string from config in existing LogonProperties
        //    document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
        //    document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
        //    document.DataSourceConnections[0].IntegratedSecurity = false;

        //    //generiranje IBAn broja za svakog radnika
        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        row["KorisnikIBAN"] = iban.GenerirajIBANIzBrojaRacuna(row["BrojRacuna"].ToString(), true, false);
        //    }

        //    //dohvat prosjeka zadnje tri place
        //    if (otpremnina)
        //    {
        //        int mjesec = 0; int mjesec1 = 0; int mjesec2 = 0;
        //        int godina = 0; int godina1 = 0; int godina2 = 0;
        //        foreach (DataRow row in tbl.Rows)
        //        {
        //            mjesec = Convert.ToInt32(client.ExecuteScalar("Select Top 1 MJESECISPLATE From VW_PLACA_ZAPOSLENIK_UKUPNO Where IDRADNIK = '" 
        //                                                            + row["IDRADNIK"].ToString() + "' Order by IDOBRACUN DESC"));
        //            godina = Convert.ToInt32(client.ExecuteScalar("Select top 1 GODINAISPLATE From VW_PLACA_ZAPOSLENIK_UKUPNO Where IDRADNIK = '" 
        //                                                            + row["IDRADNIK"].ToString() + "' Order by IDOBRACUN DESC"));
        //            if (mjesec == 1)
        //            {
        //                mjesec1 = 12;
        //                godina1 = godina - 1;
        //                mjesec2 = 11;
        //                godina2 = godina - 1;
        //            }
        //            else if (mjesec == 2)
        //            {
        //                mjesec1 = 1;
        //                godina1 = godina;
        //                mjesec2 = 12;
        //                godina2 = godina - 1;
        //            }
        //            else
        //            {
        //                mjesec1 = mjesec -1;
        //                godina1 = godina;
        //                mjesec2 = mjesec -2;
        //                godina2 = godina;
        //            }

        //            row["ProsjekPlace"] = Math.Round( Convert.ToDecimal(client.ExecuteScalar("Select Coalesce(ROUND(SUM(UKUPNOBRUTO) / 3,2),0) From VW_PLACA_ZAPOSLENIK_UKUPNO " +
        //                                "Where MJESECISPLATE In (" + mjesec + ", " + mjesec1 + ", " + mjesec2 + ") And GODINAISPLATE In " +
        //                                "(" + godina + ", " + godina1 + ", " + godina2 + ") And VW_PLACA_ZAPOSLENIK_UKUPNO.IDRADNIK = '" + row["IDRADNIK"].ToString() + "'")), 2);
        //        }
        //    }


        //    document.SetDataSource(tbl);

        //    KORISNIKDataSet dataSet = new KORISNIKDataSet();
        //    new KORISNIKDataAdapter().Fill(dataSet);
        //    string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
        //    string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
        //    string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
        //    string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
        //    string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
        //    string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
        //    string str3 = "";
        //    string odgovorna_osoba = Conversions.ToString(dataSet.KORISNIK.Rows[0]["PREZIMEIMEOVLASTENEOSOBE"]);
        //    DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
        //    if (rowArray.Length > 0)
        //    {
        //        str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
        //    }
        //    else
        //    {
        //        str3 = "";
        //    }

        //    document.SetParameterValue("ADRESA2", str2);
        //    document.SetParameterValue("ADRESA", str);
        //    document.SetParameterValue("USTANOVA", str6);
        //    document.SetParameterValue("OIB", str5);
        //    document.SetParameterValue("IBAN", iban.GenerirajIBANIzBrojaRacuna(str3, true, false));
        //    document.SetParameterValue("Banka", rowArray[0]["NAZIVZIRO"].ToString());
        //    document.SetParameterValue("OdgovornaOsoba", odgovorna_osoba);
        //    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
        //    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
        //    if (item == null)
        //    {
        //        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
        //    }
        //    item.Izvjestaj = document;
        //    item.Show(item.Workspaces["main"]);
        //    this.UltraDesktopAlert1.CloseAll();
        //}

        public void IspisiPlatneNP1()
        {
            IBAN iban = new IBAN();
            ReportDocument document = new ReportDocument();
            SqlClient client = new SqlClient();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = client.sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            System.Data.DataTable tbl = new System.Data.DataTable();

            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaNP1.rpt");
            sqlCommand.CommandText = "sp_PlatnaNovaNP1";

            sqlCommand.Parameters.AddWithValue("@IDOBRACUN", sifraobracuna);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCommand;
            da.Fill(tbl);

            // Set connection string from config in existing LogonProperties
            document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            document.DataSourceConnections[0].IntegratedSecurity = false;

            //generiranje IBAn broja za svakog radnika
            foreach (DataRow row in tbl.Rows)
            {
                row["KorisnikIBAN"] = iban.GenerirajIBANIzBrojaRacuna(row["BrojRacuna"].ToString(), true, false);
                row["DoprinosPrviStupIBAN"] = iban.GenerirajIBANIzBrojaRacuna(row["ZiroDoprinosPrviStup"].ToString(), true, false);
                row["DoprinosDrugiStupIBAN"] = iban.GenerirajIBANIzBrojaRacuna(row["ZiroDoprinosDrugiStup"].ToString(), true, false);
                row["OpcinaRadaIBAN"] = iban.GenerirajIBANIzBrojaRacuna(row["ZiroOpcinaRada"].ToString(), true, false);

                if (row["ZiroObustava1"] != null)
                {
                    row["IBANObustava1"] = iban.GenerirajIBANIzBrojaRacuna(row["ZiroObustava1"].ToString(), true, false);
                }

                if (row["ZiroObustava2"] != null)
                {
                    row["IBANObustava2"] = iban.GenerirajIBANIzBrojaRacuna(row["ZiroObustava2"].ToString(), true, false);
                }

                row["ZasticeniIBAN"] = iban.GenerirajIBANIzBrojaRacuna(row["RacunZasticeni"].ToString(), true, false);
            }

            document.SetDataSource(tbl);

            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
            string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
            string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
            string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
            string str3 = "";
            string odgovorna_osoba = Conversions.ToString(dataSet.KORISNIK.Rows[0]["PREZIMEIMEOVLASTENEOSOBE"]);
            DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
            if (rowArray.Length > 0)
            {
                str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
            }
            else
            {
                str3 = "";
            }

            document.SetParameterValue("ADRESA2", str2);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("USTANOVA", str6);
            document.SetParameterValue("OIB", str5);
            document.SetParameterValue("IBAN", iban.GenerirajIBANIzBrojaRacuna(str3, true, false));

            string banka = client.ExecuteScalar("Select NAZIVBANKE1 From Banke Where VBDIBANKE = " + rowArray[0]["VBDIKORISNIK"].ToString()).ToString();

            document.SetParameterValue("Banka", banka);
            document.SetParameterValue("OdgovornaOsoba", odgovorna_osoba);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"]);
            this.UltraDesktopAlert1.CloseAll();
        }



        [LocalCommandHandler("IspisiPlatneAbecedaCommnd")]
        public void IspisiPlatnebecedaHandler(object sender, EventArgs e)
        {
            //this.IspisiPlatne_Abeceda();
        }

        [LocalCommandHandler("IspisiPlatneNoveCommand")]
        public void IspisiPlatnaNoveHandler(object sender, EventArgs e)
        {
            //this.IspisiPlatneNove();
        }

        [LocalCommandHandler("IspisiPlatneNP1Command")]
        public void IspisiPlatnaNP1Handler(object sender, EventArgs e)
        {
            this.IspisiPlatneNP1();
        }

        [LocalCommandHandler("IspisiPlatneCommand")]
        public void IspisiPlatneHandler(object sender, EventArgs e)
        {
            //this.IspisiPlatne();
        }

        [LocalCommandHandler("PlatnaDoprinosNA")]
        public void IspisiPlatneDoprinosNAHandler(object sender, EventArgs e)
        {
            this.IspisiPlatneDoprinosNA();
        }

        //public void IspisiPlatnePojedinacno()
        //{
        //    DataRow current;
        //    IEnumerator enumerator = null;
        //    IEnumerator enumerator2 = null;
        //    ReportDocument document = new ReportDocument();
        //    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
        //        StartPosition = FormStartPosition.CenterParent,
        //        Modal = true,
        //        Title = "Pregled izvještaja",
        //        Description = "Pregled",
        //        Icon = ImageResourcesNew.mbs
        //    };
        //    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaListaOrg.rpt");

        //    document.RecordSelectionFormula = "{ObracunRadnici.IDRADNIK} = " + Conversions.ToString(this.AktivanZaposlenik());
        //    try
        //    {
        //        enumerator = this.ObracunDataSet1.OBRACUNKrediti.Rows.GetEnumerator();
        //        while (enumerator.MoveNext())
        //        {
        //            current = (DataRow) enumerator.Current;
        //            current["dosadaobustavljeno"] = this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
        //            current["BRRATADOSADA"] = this.BrRataDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator is IDisposable)
        //        {
        //            (enumerator as IDisposable).Dispose();
        //        }
        //    }
        //    try
        //    {
        //        enumerator2 = this.ObracunDataSet1.OBRACUNObustave.Rows.GetEnumerator();
        //        while (enumerator2.MoveNext())
        //        {
        //            current = (DataRow) enumerator2.Current;
        //            current["obustavljenodosada"] = this.Obustave_Iznos(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //            current["obustavljenodosadabrojrata"] = this.Obustave_BrojRata(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //            current["OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE"] = this.Obustave_StanjeKase(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
        //        }
        //    }
        //    finally
        //    {
        //        if (enumerator2 is IDisposable)
        //        {
        //            (enumerator2 as IDisposable).Dispose();
        //        }
        //    }
        //    document.SetDataSource(this.ObracunDataSet1);
        //    KORISNIKDataSet dataSet = new KORISNIKDataSet();
        //    new KORISNIKDataAdapter().Fill(dataSet);
        //    string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
        //    string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
        //    string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
        //    string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
        //    string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
        //    string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
        //    string str3 = "";
        //    DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
        //    if (rowArray.Length > 0)
        //    {
        //        str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
        //    }
        //    else
        //    {
        //        str3 = "";
        //    }
        //    document.SetParameterValue("ADRESA2", str2);
        //    document.SetParameterValue("ADRESA", str);
        //    document.SetParameterValue("USTANOVA", str6 + " Žrn:" + str3);
        //    document.SetParameterValue("MB", str5);
        //    document.SetParameterValue("TELEFON", str8);
        //    document.SetParameterValue("FAX", str4);
        //    document.SetParameterValue("mjesec_rijecima", DB.MjesecNazivPlatna(Conversions.ToInteger(this.mjesecobracuna)));

        //    // Set connection string from config in existing LogonProperties
        //    document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
        //    document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
        //    document.DataSourceConnections[0].IntegratedSecurity = false;

        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
        //    //document.Subreports["DoprinosiNa"].Database.Tables[0].LogOnInfo.ConnectionInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
        //    //document.Subreports["DoprinosiNa"].SetDatabaseLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);

        //    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
        //    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
        //    if (item == null)
        //    {
        //        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
        //    }
        //    item.Izvjestaj = document;
        //    item.Show(item.Workspaces["main"]);
        //}


        #region PlatneListeInstituti
        public void PlatnaInstituti()
        {
            
            
            string str = string.Empty;
            DataRow current;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            IEnumerator enumerator3 = null;
            //this.DesktopAlert();
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            try
            {
                enumerator = this.ObracunDataSet1.OBRACUNKrediti.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow)enumerator.Current;
                    current["dosadaobustavljeno"] = this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
                    current["BRRATADOSADA"] = this.BrRataDoZadObr(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), this.STANJEKREDITA);
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
                enumerator2 = this.ObracunDataSet1.OBRACUNObustave.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    current = (DataRow)enumerator2.Current;
                    current["obustavljenodosada"] = this.Obustave_Iznos(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
                    current["obustavljenodosadabrojrata"] = this.Obustave_BrojRata(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
                    current["OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE"] = this.Obustave_StanjeKase(this.sifraobracuna, Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), this.STANJEOBUSTAVA);
                }
            }
            finally
            {
                if (enumerator2 is IDisposable)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
            }
            DataSet set = new DataSet();
            try
            {
                enumerator3 = this.ObracunDataSet1.Tables.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    System.Data.DataTable table = (System.Data.DataTable)enumerator3.Current;
                    set.Tables.Add(table.Copy());
                }
            }
            finally
            {
                if (enumerator3 is IDisposable)
                {
                    (enumerator3 as IDisposable).Dispose();
                }
            }
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpPlatnaListaInstituti.rpt");
            document.SetDataSource(set);
            document.RecordSelectionFormula = "{OBRACUN.IDOBRACUN} = '" + this.sifraobracuna + "'";
            string str8 = "";

            str8 = str8 + "{OBRACUNradnici.IDRADNIK} = " + UltraGrid1.ActiveRow.Cells["IDRADNIK"].Value.ToString();

            if (str8 != "")
            {
                ReportDocument document2 = document;
                document2.RecordSelectionFormula = document2.RecordSelectionFormula + " AND (" + str8 + ")";
            }
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
            string str3 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
            string str9 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
            string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
            DataRow[] rowArray = dataSet.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
            if (rowArray.Length > 0)
            {
                str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
            }
            else
            {
                str3 = "";
            }
            document.SetParameterValue("ADRESA2", str2);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("USTANOVA", string.Format("{0} Žrn: {1}", str6, str3));
            document.SetParameterValue("MB", str5);
            document.SetParameterValue("TELEFON", str9);
            document.SetParameterValue("FAX", str4);
            document.SetParameterValue("mjesec_rijecima", DB.MjesecNazivPlatna(Conversions.ToInteger(this.mjesecobracuna)));

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlCommand sqlComm = new SqlCommand("sp_RadnikKoeficjentiZaInstitute", conn.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@IDRADNIK", UltraGrid1.ActiveRow.Cells["IDRADNIK"].Value.ToString());
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                document.SetParameterValue("KoeficjentPrvogStupca", dt.Rows[0]["KoeficjentPrvogStupca"].ToString());
                document.SetParameterValue("KoeficjentDrugogStupca", dt.Rows[0]["KoeficjentDrugogStupca"].ToString());


                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"]);
                this.UltraDesktopAlert1.CloseAll();
            }
        }
        #endregion

        [LocalCommandHandler("IspisiPlatnePojedinacnoCommand")]
        public void IspisiPlatnePojedinacnoHandler(object sender, EventArgs e)
        {
            //this.IspisiPlatnePojedinacno();
        }

        [LocalCommandHandler("PlatnaInstituti")]
        public void PlatnaInstitutiHandler(object sender, EventArgs e)
        {
            this.PlatnaInstituti();
        }


        [LocalCommandHandler("IspisiPotpisnuListuCommand")]
        public void IspisiPotpisnuListu(object sender, EventArgs e)
        {
            this.PotpisnaLista();
        }

        [LocalCommandHandler("Izlaz")]
        public void IzlazHanlder(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Želite li spremiti promjene?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            {
                this.SaveToDatabase();
            }
            this.Controller.WorkItem.Workspaces["main"].Close(RuntimeHelpers.GetObjectValue(this.Controller.WorkItem.Workspaces["main"].ActiveSmartPart));
        }

        private void Izracun_Place(OBRACUNDataSet obrac, DataRowView drvObracun)
        {
            int num = 0;
            decimal num2 = 0;
            OBRACUNDataSet.ObracunDoprinosiRow row2 = null;
            decimal num17 = 0;
            decimal num21 = 0;
            IEnumerator enumerator2 = null;
            decimal num20 = new decimal();
            drvObracun["ISKORISTENOOO"] = 0;
            drvObracun["FAKTOO"] = 0;
            double satnica = 0;
            decimal gstaza = 0;
            decimal mstaza = 0;
            decimal dstaza = 0;

            
            //#OBR_2
            DataRow drView = drvObracun.Row;
            this.IzracunSatnice(ref drView, ref satnica, ref gstaza, ref mstaza, ref dstaza);
            /*
            obj2 = dstaza;
            obj4 = mstaza;
            obj3 = gstaza;
            obj5 = satnica;
             * */
            if (Operators.ConditionalCompareObjectEqual(this.dsKorisnik.KORISNIK.Rows[0]["STAZUKOEFICIJENTU"], false, false))
            {
                drvObracun["obracunskikoeficijent"] = Operators.AddObject(drvObracun["koeficijent"], DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(drvObracun["koeficijent"], Operators.DivideObject(gstaza, 2)), 100), 3));
            }
            else
            {
                drvObracun["obracunskikoeficijent"] = RuntimeHelpers.GetObjectValue(drvObracun["koeficijent"]);
            }
            this.BindingContext[this.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
            this.PocistiObracunatoNaRadniku(this.sifraobracuna, Conversions.ToInteger(drvObracun["idradnik"]));
            decimal nUkupnoBrutoPrimanja = this.UkupniBruto(RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]));
            decimal num8 = this.UkupniNeto(RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]));
            decimal nPrvaPorezna = nUkupnoBrutoPrimanja;
            this.dvDoprinosiNA.Table = this.SkupporezaidoprinosaDataSet1.SKUPPOREZAIDOPRINOSA2;
            this.dvDoprinosiNA.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("IDSKUPPOREZAIDOPRINOSA = ", drvObracun["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]), " AND idvrstadoprinos = 1"));
            this.dvDoprinosiIZ.Table = this.SkupporezaidoprinosaDataSet1.SKUPPOREZAIDOPRINOSA2;
            this.dvDoprinosiIZ.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("IDSKUPPOREZAIDOPRINOSA = ", drvObracun["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]), " AND idvrstadoprinos = 2"));
            nPrvaPorezna = nUkupnoBrutoPrimanja;
            int num42 = this.dvDoprinosiIZ.Count - 1;
            for (num = 0; num <= num42; num++)
            {
                this.Izracun_Place_Doprinosi_Iz(drvObracun, nUkupnoBrutoPrimanja, ref nPrvaPorezna, ref row2, num, ref num2);
            }
            decimal num15 = nPrvaPorezna;
            int num43 = this.dvDoprinosiNA.Count - 1;
            for (num = 0; num <= num43; num++)
            {
                this.Izracun_Place_Doprinosi_Na(drvObracun, nUkupnoBrutoPrimanja, ref row2, num, ref num2);
            }
            this.BindingContext[this.ObracunDataSet1.ObracunDoprinosi].EndCurrentEdit();
            DataView view7 = new DataView {
                Table = this.RadnikDataSet1.RADNIKOlaksica,
                RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik= ", drvObracun["idradnik"]))
            };
            DataView view5 = view7;
            view7 = new DataView {
                Table = this.RadnikDataSet1.RADNIKObustava
            };
            DataView view4 = view7;
            view7 = new DataView {
                Table = this.RadnikDataSet1.RADNIKKrediti
            };
            DataView dvRadnikkrediti = view7;
            view7 = new DataView {
                Table = this.RadnikDataSet1.RADNIKIzuzeceOdOvrhe
            };
            DataView view = view7;
            view.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik= ", drvObracun["idradnik"]));
            view4.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik= ", drvObracun["idradnik"]));
            dvRadnikkrediti.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik= ", drvObracun["idradnik"]));
            decimal num6 = new decimal();
            if (this.obracunavaolaksice)
            {
                IEnumerator enumerator = null;
                int num44 = view5.Count - 1;
                for (num = 0; num <= num44; num++)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(!this.ObracunataOlaksicaUMjesecu(this.sifraobracuna, Conversions.ToInteger(drvObracun["idradnik"]), Conversions.ToInteger(view5[num]["ZADOLAKSICEIDOLAKSICE"])), Operators.CompareObjectLessEqual(view5[num]["ZADIZNOSOLAKSICE"], nPrvaPorezna, false))))
                    {
                        OBRACUNDataSet.ObracunOlaksiceRow row = this.ObracunDataSet1.ObracunOlaksice.NewObracunOlaksiceRow();
                        row["idobracun"] = this.sifraobracuna;
                        row["idradnik"] = RuntimeHelpers.GetObjectValue(view5[num]["idradnik"]);
                        row["idolaksice"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADOLAKSICEIDOLAKSICE"]);
                        row["obracunataolaksica"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADIZNOSOLAKSICE"]);
                        row["IZNOSOLAKSICE"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADIZNOSOLAKSICE"]);
                        row["MZOLAKSICA"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADMZOLAKSICE"]);
                        row["PZOLAKSICA"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADPZOLAKSICE"]);
                        row["MOOLAKSICA"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADMOOLAKSICE"]);
                        row["POOLAKSICA"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADPOOLAKSICE"]);
                        row["SIFRAOPISAPLACANJAOLAKSICA"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADSIFRAOPISAPLACANJAOLAKSICE"]);
                        row["OPISPLACANJAOLAKSICA"] = RuntimeHelpers.GetObjectValue(view5[num]["ZADOPISPLACANJAOLAKSICE"]);
                        num21 = Conversions.ToDecimal(Operators.AddObject(num21, row["obracunataolaksica"]));
                        object instance = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                        this.connDefault = (ReadWriteConnection) NewLateBinding.LateGet(instance, null, "GetReadWriteConnection", new object[0], null, null, null);
                        ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOLAKSICE], [IDGRUPEOLAKSICA], [IDTIPOLAKSICE], [VBDIOLAKSICA], [ZRNOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3] FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDOLAKSICE] = @IDOLAKSICE ", false);
                        if (command2.IDbCommand.Parameters.Count == 0)
                        {
                            command2.IDbCommand.Parameters.Add(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance, null, "GetDbParameter", new object[] { "@IDOLAKSICE", DbType.Int32 }, null, null, null)));
                        }
                        command2.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDOLAKSICE"]));
                        IDataReader reader2 = command2.FetchData();
                        if (!command2.HasMoreRows)
                        {
                            reader2.Close();
                            throw new OBRACUNDataAdapter.OLAKSICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "TIPOLAKSICE" }));
                        }
                        object[] arguments = new object[] { reader2, 0 };
                        bool[] copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                        }
                        row["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, copyBack));
                        object[] objArray = new object[] { reader2, 1 };
                        copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                        }
                        row["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, copyBack));
                        objArray = new object[] { reader2, 2 };
                        copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                        }
                        row["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, copyBack));
                        objArray = new object[] { reader2, 3 };
                        copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                        }
                        row["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, copyBack));
                        objArray = new object[] { reader2, 4 };
                        copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                        }
                        row["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, copyBack));
                        objArray = new object[] { reader2, 5 };
                        copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                        }
                        row["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, copyBack));
                        objArray = new object[] { reader2, 6 };
                        copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                        }
                        row["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, copyBack));
                        objArray = new object[] { reader2, 7 };
                        copyBack = new bool[] { true, false };
                        if (copyBack[0])
                        {
                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                        }
                        row["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, copyBack));
                        reader2.Close();
                        if (!row.IsIDGRUPEOLAKSICANull())
                        {
                            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
                            if (command.IDbCommand.Parameters.Count == 0)
                            {
                                command.IDbCommand.Parameters.Add(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance, null, "GetDbParameter", new object[] { "@IDGRUPEOLAKSICA", DbType.Int32 }, null, null, null)));
                            }
                            command.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDGRUPEOLAKSICA"]));
                            IDataReader reader = command.FetchData();
                            if (!command.HasMoreRows)
                            {
                                reader.Close();
                                throw new OBRACUNDataAdapter.GRUPEOLAKSICAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "GRUPEOLAKSICA" }));
                            }
                            objArray = new object[] { reader, 0 };
                            copyBack = new bool[] { true, false };
                            if (copyBack[0])
                            {
                                reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                            }
                            row["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, copyBack));
                            objArray = new object[] { reader, 1 };
                            copyBack = new bool[] { true, false };
                            if (copyBack[0])
                            {
                                reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                            }
                            row["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", objArray, null, null, copyBack));
                            reader.Close();
                        }
                        else
                        {
                            row["NAZIVGRUPEOLAKSICA"] = "";
                            row["MAXIMALNIIZNOSGRUPE"] = 0;
                        }
                        if (!row.IsIDTIPOLAKSICENull())
                        {
                            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
                            if (command3.IDbCommand.Parameters.Count == 0)
                            {
                                command3.IDbCommand.Parameters.Add(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance, null, "GetDbParameter", new object[] { "@IDTIPOLAKSICE", DbType.Int32 }, null, null, null)));
                            }
                            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDTIPOLAKSICE"]));
                            IDataReader reader3 = command3.FetchData();
                            if (!command3.HasMoreRows)
                            {
                                reader3.Close();
                                throw new OBRACUNDataAdapter.TIPOLAKSICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "TIPOLAKSICE" }));
                            }
                            objArray = new object[] { reader3, 0 };
                            copyBack = new bool[] { true, false };
                            if (copyBack[0])
                            {
                                reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                            }
                            row["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, copyBack));
                            reader3.Close();
                        }
                        else
                        {
                            row["NAZIVTIPOLAKSICE"] = "";
                        }
                        this.ObracunDataSet1.ObracunOlaksice.Rows.Add(row);
                        this.BindingContext[this.ObracunDataSet1.ObracunOlaksice].EndCurrentEdit();
                    }
                }
                decimal num23 = new decimal();
                decimal num27 = new decimal();
                decimal num24 = new decimal();
                decimal num25 = new decimal();
                decimal num26 = new decimal();
                DataView view6 = new DataView {
                    Table = this.ObracunDataSet1.ObracunOlaksice
                };
                num20 = new decimal();
                try
                {
                    enumerator = this.GrupeolaksicaDataSet1.GRUPEOLAKSICA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        num23 = DB.N20(RuntimeHelpers.GetObjectValue(view6.Table.Compute("Max(MAXIMALNIIZNOSGRUPE)", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"]), " and IDGRUPEOLAKSICA= "), current["idgrupeolaksica"])))));
                        num27 = DB.N20(RuntimeHelpers.GetObjectValue(view6.Table.Compute("SUM(obracunataolaksica)", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"]), " and IDGRUPEOLAKSICA= "), current["idgrupeolaksica"])))));
                        num24 = this.UkupnoOlaksicaUMjesecu(Conversions.ToInteger(drvObracun["idradnik"]), this.sifraobracuna, Conversions.ToInteger(current["idgrupeolaksica"]));
                        num26 = decimal.Subtract(num27, num24);
                        if (decimal.Compare(num26, decimal.Zero) <= 0)
                        {
                            num25 = new decimal();
                        }
                        else
                        {
                            num25 = num26;
                            if (decimal.Compare(num25, num23) > 0)
                            {
                                num25 = num23;
                            }
                            else
                            {
                                num25 = num27;
                            }
                        }
                        num20 = decimal.Add(num20, num25);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                num15 = num6;
                num6 = decimal.Subtract(nPrvaPorezna, num20);
            }
            else
            {
                num15 = num6;
                num6 = nPrvaPorezna;
            }
            decimal num16 = new decimal();
            decimal num7 = new decimal();
            decimal num22 = new decimal();
            decimal num13 = new decimal();
            DataView view2 = new DataView {
                Table = this.RadnikDataSet1.RADNIKOdbitak
            };
            num16 = DB.N20(RuntimeHelpers.GetObjectValue(view2.Table.Compute("Sum(faktorosobnogodbitka)", Conversions.ToString(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"])))));
            num7 = decimal.Multiply(num16, this.osnovnioo);
            num22 = DB.RoundUP(this.UkupnoOOuMjesecu(Conversions.ToInteger(drvObracun["idradnik"]), this.sifraobracuna));
            num13 = decimal.Subtract(num7, num22);
            if (decimal.Compare(num13, decimal.Zero) < 0)
            {
                num13 = new decimal();
            }
            if (decimal.Compare(num13, num6) >= 0)
            {
                num13 = num6;
            }
            drvObracun["KOREKCIJAPRIREZA"] = 0;
            drvObracun["ODBITAKPRIJEKOREKCIJE"] = 0;
            drvObracun["iskoristenooo"] = DB.RoundUP(num13);
            drvObracun["faktoo"] = num16;
            this.BindingContext[this.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
            num6 = decimal.Subtract(num6, num13);
            this.dvporez.Table = this.SkupporezaidoprinosaDataSet1.SKUPPOREZAIDOPRINOSA1;
            this.dvporez.RowFilter = Conversions.ToString(Operators.ConcatenateObject("IDSKUPPOREZAIDOPRINOSA = ", drvObracun["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
            decimal num11 = new decimal();
            decimal num10 = num6;
            int num45 = this.dvporez.Count - 1;
            num = 0;
            while (num <= num45)
            {
                decimal num29 = 0;
                decimal num30 = 0;
                this.UkupnoPorezaUMjesecu(Conversions.ToInteger(drvObracun["idradnik"]), this.sifraobracuna, Conversions.ToInteger(this.dvporez[num].Row["idporez"]), ref num30, ref num29);
                OBRACUNDataSet.ObracunPoreziRow row4 = (OBRACUNDataSet.ObracunPoreziRow) this.ObracunDataSet1.ObracunPorezi.NewRow();
                row4["idobracun"] = this.sifraobracuna;
                row4["idporez"] = RuntimeHelpers.GetObjectValue(this.dvporez[num].Row["idporez"]);
                decimal num9 = Conversions.ToDecimal(Operators.SubtractObject(this.dvporez[num].Row["POREZMJESECNO"], num30));
                if (decimal.Compare(num10, decimal.Zero) == 0)
                {
                    break;
                }
                if (decimal.Compare(num9, decimal.Zero) == 0)
                {
                    decimal num31 = new decimal();
                    num31 = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num10, this.dvporez[num].Row["stopaporeza"]), 100));
                    row4["osnovicaporez"] = Math.Abs(num9);
                    row4["idradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
                    row4["obracunatiporez"] = num31;
                }
                decimal num28 = new decimal();
                if (decimal.Compare(num9, decimal.Zero) > 0)
                {
                    if (decimal.Compare(decimal.Subtract(num10, num9), decimal.Zero) < 0)
                    {
                        num28 = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(Math.Abs(num10), this.dvporez[num].Row["stopaporeza"]), 100));
                        num28 = decimal.Subtract(num28, DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num28, drvObracun["POSTOTAKOSLOBODJENJAODPOREZA"]), 100)));
                        row4["obracunatiporez"] = num28;
                        row4["osnovicaporez"] = Math.Abs(num10);
                        num10 = new decimal();
                        row4["idradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
                    }
                    else
                    {
                        num28 = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num9, this.dvporez[num].Row["stopaporeza"]), 100));
                        num28 = decimal.Subtract(num28, DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num28, drvObracun["POSTOTAKOSLOBODJENJAODPOREZA"]), 100)));
                        row4["obracunatiporez"] = num28;
                        row4["osnovicaporez"] = num9;
                        num10 = Math.Abs(decimal.Subtract(num10, num9));
                        row4["idradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
                    }
                    this.ObracunDataSet1.ObracunPorezi.Rows.Add(row4);
                }
                num11 = decimal.Add(num11, num28);
                num++;
            }
            num15 = decimal.Add(decimal.Add(decimal.Add(decimal.Subtract(num15, num11), num13), num20), num6);
            decimal num14 = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num11, drvObracun["OPCINASTANOVANJAPRIREZ"]), 100));
            drvObracun["obracunatiprirez"] = num14;
            num15 = decimal.Subtract(num15, num14);
            decimal nObustava = num15;
            decimal num3 = decimal.Subtract(num15, num20);
            num15 = decimal.Add(num15, this.UkupniNeto(RuntimeHelpers.GetObjectValue(drvObracun["idradnik"])));
            this.BindingContext[this.ObracunDataSet1.ObracunPorezi].EndCurrentEdit();
            if (this.obracunavakrizni)
            {
                decimal num32 = 0;
                decimal num33 = 0;
                decimal num34 = 0;
                this.UkupnoKriznog_i_neto(Conversions.ToInteger(drvObracun["idradnik"]), this.sifraobracuna, ref num33, ref num32);
                decimal num35 = decimal.Add(num33, num3);
                int num36 = 1;
                if ((Operators.CompareString(this.mjesecisplate, "07", false) >= 0) & (Operators.CompareString(this.godinaisplate, "2010", false) >= 0))
                {
                    if (decimal.Compare(num35, 6000M) > 0)
                    {
                        num34 = DB.RoundUP(decimal.Divide(decimal.Multiply(num35, 4M), 100M));
                        num36 = 2;
                    }
                }
                else if ((Convert.ToDouble(num35) >= 3000.01) & (decimal.Compare(num35, 6000M) <= 0))
                {
                    num34 = DB.RoundUP(decimal.Divide(decimal.Multiply(num35, 2M), 100M));
                    num15 = decimal.Subtract(num15, num34);
                    num36 = 1;
                }
                else if (decimal.Compare(num35, 6000M) > 0)
                {
                    num34 = DB.RoundUP(decimal.Divide(decimal.Multiply(num35, 4M), 100M));
                    num36 = 2;
                }
                num34 = decimal.Subtract(num34, num32);
                OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow row12 = this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunKrizni.NewOBRACUNOBRACUNLevel1ObracunKrizniRow();
                row12["idkrizniporez"] = num36;
                row12["IDradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
                row12["IDOBRACUN"] = this.sifraobracuna;
                row12["osnovicakrizni"] = num3;
                row12["porezkrizni"] = num34;
                row12["OSNOVICAPRETHODNA"] = num33;
                row12["OSNOVICAUKUPNA"] = num35;
                row12["POREZPRETHODNI"] = num32;
                row12["POREZUKUPNO"] = decimal.Add(num34, num32);
                this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunKrizni.Rows.Add(row12);
                this.BindingContext[this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunKrizni].EndCurrentEdit();
                num15 = decimal.Subtract(num15, num34);
            }
            if (this.obracunavaobustave)
            {
                this.IzracunPlaceObustave(drvObracun, num21, ref num15, num, view4, nObustava, num3);
            }
            this.BindingContext[this.ObracunDataSet1.OBRACUNObustave].EndCurrentEdit();
            if (this.obracunavaobustave)
            {
                this.Izracun_Place_Krediti(drvObracun, num21, num15, dvRadnikkrediti);
            }
            this.BindingContext[this.ObracunDataSet1.OBRACUNKrediti].EndCurrentEdit();
            try
            {
                enumerator2 = this.ObracunDataSet1.OBRACUNKrediti.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    DataRow row3 = (DataRow) enumerator2.Current;
                    if (Operators.ConditionalCompareObjectEqual(row3["idradnik"], drvObracun["idradnik"], false))
                    {
                        num17 = Conversions.ToDecimal(Operators.AddObject(num17, row3["obracunatikunskiiznos"]));
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
            num15 = decimal.Subtract(num15, num17);
            int num46 = view.Count - 1;
            for (int i = 0; i <= num46; i++)
            {
                BANKEDataAdapter adapter = new BANKEDataAdapter();
                BANKEDataSet dataSet = new BANKEDataSet();
                adapter.FillByIDBANKE(dataSet, Conversions.ToInteger(view[i]["BANKAZASTICENOIDBANKE"]));
                if (decimal.Compare(num15, decimal.Zero) > 0)
                {
                    DataRow row13;
                    if (Operators.ConditionalCompareObjectGreaterEqual(num15, view[i]["zadiznosizuzeca"], false))
                    {
                        row13 = this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece.NewRow();
                        row13["IDradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
                        row13["IDOBRACUN"] = this.sifraobracuna;
                        row13["primateljizuzece1"] = RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["nazivbanke1"]);
                        row13["primateljizuzece2"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(dataSet.BANKE.Rows[0]["nazivbanke2"] == DBNull.Value, "", RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["nazivbanke2"])));
                        row13["primateljizuzece3"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(dataSet.BANKE.Rows[0]["nazivbanke3"] == DBNull.Value, "", RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["nazivbanke3"])));
                        row13["moizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadmoizuzece"]);
                        row13["poizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadpoizuzece"]);
                        row13["mzizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadmzizuzece"]);
                        row13["pzizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadpzizuzece"]);
                        row13["sifraopisaplacanjaizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadsifraopisaplacanjaizuzece"]);
                        row13["opisplacanjaizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadopisplacanjaizuzece"]);
                        row13["tekuciizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadtekuciizuzece"]);
                        row13["VBDIIZUZECE"] = RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["VBDIBANKE"]);
                        row13["iznosizuzeca"] = RuntimeHelpers.GetObjectValue(view[i]["zadiznosizuzeca"]);
                        this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece.Rows.Add(row13);
                        num15 = Conversions.ToDecimal(Operators.SubtractObject(num15, view[i]["zadiznosizuzeca"]));
                    }
                    else
                    {
                        row13 = this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece.NewRow();
                        row13["IDradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
                        row13["IDOBRACUN"] = this.sifraobracuna;
                        row13["primateljizuzece1"] = RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["nazivbanke1"]);
                        row13["primateljizuzece2"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(dataSet.BANKE.Rows[0]["nazivbanke2"] == DBNull.Value, "", RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["nazivbanke2"])));
                        row13["primateljizuzece3"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(dataSet.BANKE.Rows[0]["nazivbanke3"] == DBNull.Value, "", RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["nazivbanke3"])));
                        row13["moizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadmoizuzece"]);
                        row13["poizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadpoizuzece"]);
                        row13["mzizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadmzizuzece"]);
                        row13["pzizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadpzizuzece"]);
                        row13["sifraopisaplacanjaizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadsifraopisaplacanjaizuzece"]);
                        row13["opisplacanjaizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadopisplacanjaizuzece"]);
                        row13["tekuciizuzece"] = RuntimeHelpers.GetObjectValue(view[i]["zadtekuciizuzece"]);
                        row13["VBDIIZUZECE"] = RuntimeHelpers.GetObjectValue(dataSet.BANKE.Rows[0]["VBDIBANKE"]);
                        row13["iznosizuzeca"] = num15;
                        this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece.Rows.Add(row13);
                        num15 = new decimal();
                    }
                }
            }
            this.BindingContext[this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece].EndCurrentEdit();
        }

        private void Izracun_Place_Doprinosi_Iz(DataRowView drvObracun, decimal nUkupnoBrutoPrimanja, ref decimal nPrvaPorezna, ref OBRACUNDataSet.ObracunDoprinosiRow drDoprinosIz, int br, ref decimal nOsnovicaZaDoprinose)
        {
            if (Conversions.ToBoolean(Operators.AndObject(drvObracun["uzimauobzirosnovicedoprinosa"], decimal.Compare(nUkupnoBrutoPrimanja, decimal.Zero) > 0)))
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(this.dvDoprinosiIZ[br]["MINDOPRINOS"], 0, false), Operators.CompareObjectGreater(this.dvDoprinosiIZ[br]["MAXDOPRINOS"], 0, false))))
                {
                    if (Operators.ConditionalCompareObjectLess(nUkupnoBrutoPrimanja, this.dvDoprinosiIZ[br]["MINDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiIZ[br]["MINDOPRINOS"]);
                    }
                    else if (Operators.ConditionalCompareObjectGreater(nUkupnoBrutoPrimanja, this.dvDoprinosiIZ[br]["MAXDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiIZ[br]["MAXDOPRINOS"]);
                    }
                    else
                    {
                        nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                    }
                }
                else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(this.dvDoprinosiIZ[br]["MINDOPRINOS"], 0, false), Operators.CompareObjectEqual(this.dvDoprinosiIZ[br]["MAXDOPRINOS"], 0, false))))
                {
                    if (Operators.ConditionalCompareObjectLess(nUkupnoBrutoPrimanja, this.dvDoprinosiIZ[br]["MINDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiIZ[br]["MINDOPRINOS"]);
                    }
                    else
                    {
                        nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                    }
                }
                else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.dvDoprinosiIZ[br]["MINDOPRINOS"], 0, false), Operators.CompareObjectGreater(this.dvDoprinosiIZ[br]["MAXDOPRINOS"], 0, false))))
                {
                    if (Operators.ConditionalCompareObjectGreater(nUkupnoBrutoPrimanja, this.dvDoprinosiIZ[br]["MAXDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiIZ[br]["MAXDOPRINOS"]);
                    }
                    else
                    {
                        nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                    }
                }
                else
                {
                    nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                }
            }
            else
            {
                nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
            }
            drDoprinosIz = (OBRACUNDataSet.ObracunDoprinosiRow) this.ObracunDataSet1.ObracunDoprinosi.NewRow();
            drDoprinosIz["idobracun"] = this.sifraobracuna;
            drDoprinosIz["iddoprinos"] = RuntimeHelpers.GetObjectValue(this.dvDoprinosiIZ[br].Row["iddoprinos"]);
            drDoprinosIz["obracunatidoprinos"] = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject((decimal) nOsnovicaZaDoprinose, this.dvDoprinosiIZ[br].Row["stopa"]), 100));
            drDoprinosIz["osnovicadoprinos"] = (decimal) nOsnovicaZaDoprinose;
            drDoprinosIz["idradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
            if (Operators.ConditionalCompareObjectGreater(drDoprinosIz["obracunatidoprinos"], 0, false))
            {
                this.ObracunDataSet1.ObracunDoprinosi.Rows.Add(drDoprinosIz);
                nPrvaPorezna = decimal.Subtract(nPrvaPorezna, DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject((decimal) nOsnovicaZaDoprinose, this.dvDoprinosiIZ[br].Row["stopa"]), 100)));
            }
        }

        private void Izracun_Place_Doprinosi_Na(DataRowView drvObracun, decimal nUkupnoBrutoPrimanja, ref OBRACUNDataSet.ObracunDoprinosiRow drDoprinosNa, int br, ref decimal nOsnovicaZaDoprinose)
        {
            if (Conversions.ToBoolean(Operators.AndObject(drvObracun["uzimauobzirosnovicedoprinosa"], decimal.Compare(nUkupnoBrutoPrimanja, decimal.Zero) > 0)))
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(this.dvDoprinosiNA[br]["MINDOPRINOS"], 0, false), Operators.CompareObjectGreater(this.dvDoprinosiNA[br]["MAXDOPRINOS"], 0, false))))
                {
                    if (Operators.ConditionalCompareObjectLess(nUkupnoBrutoPrimanja, this.dvDoprinosiNA[br]["MINDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiNA[br]["MINDOPRINOS"]);
                    }
                    else if (Operators.ConditionalCompareObjectGreater(nUkupnoBrutoPrimanja, this.dvDoprinosiNA[br]["MAXDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiNA[br]["MAXDOPRINOS"]);
                    }
                    else
                    {
                        nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                    }
                }
                else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(this.dvDoprinosiNA[br]["MINDOPRINOS"], 0, false), Operators.CompareObjectEqual(this.dvDoprinosiNA[br]["MAXDOPRINOS"], 0, false))))
                {
                    if (Operators.ConditionalCompareObjectLess(nUkupnoBrutoPrimanja, this.dvDoprinosiNA[br]["MINDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiNA[br]["MINDOPRINOS"]);
                    }
                    else
                    {
                        nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                    }
                }
                else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.dvDoprinosiNA[br]["MINDOPRINOS"], 0, false), Operators.CompareObjectGreater(this.dvDoprinosiNA[br]["MAXDOPRINOS"], 0, false))))
                {
                    if (Operators.ConditionalCompareObjectGreater(nUkupnoBrutoPrimanja, this.dvDoprinosiNA[br]["MAXDOPRINOS"], false))
                    {
                        nOsnovicaZaDoprinose = Conversions.ToDecimal(this.dvDoprinosiNA[br]["MAXDOPRINOS"]);
                    }
                    else
                    {
                        nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                    }
                }
                else
                {
                    nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
                }
            }
            else
            {
                nOsnovicaZaDoprinose = nUkupnoBrutoPrimanja;
            }
            drDoprinosNa = (OBRACUNDataSet.ObracunDoprinosiRow) this.ObracunDataSet1.ObracunDoprinosi.NewRow();
            drDoprinosNa["idobracun"] = this.sifraobracuna;
            drDoprinosNa["iddoprinos"] = RuntimeHelpers.GetObjectValue(this.dvDoprinosiNA[br].Row["iddoprinos"]);
            drDoprinosNa["obracunatidoprinos"] = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject((decimal) nOsnovicaZaDoprinose, this.dvDoprinosiNA[br].Row["stopa"]), 100));
            drDoprinosNa["osnovicadoprinos"] = (decimal) nOsnovicaZaDoprinose;
            drDoprinosNa["idradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
            if (Operators.ConditionalCompareObjectGreater(drDoprinosNa["obracunatidoprinos"], 0, false))
            {
                this.ObracunDataSet1.ObracunDoprinosi.Rows.Add(drDoprinosNa);
            }
        }

        private void Izracun_Place_Krediti(DataRowView drv, decimal nKolikoImaOlaksicaODOsiguranja, decimal nPrviNeto, DataView dvRadnikkrediti)
        {
            if (Operators.ConditionalCompareObjectEqual(drv["obracunavajobustave"], true, false))
            {
                int num3 = dvRadnikkrediti.Count - 1;
                for (int i = 0; i <= num3; i++)
                {
                    OBRACUNDataSet.OBRACUNKreditiRow row = (OBRACUNDataSet.OBRACUNKreditiRow) this.ObracunDataSet1.OBRACUNKrediti.NewRow();
                    row["idkreditor"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["ZADKREDITIIDKREDITOR"]);
                    row["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["DATUMUGOVORA"]);
                    row["IDradnik"] = RuntimeHelpers.GetObjectValue(drv["idradnik"]);
                    row["IDOBRACUN"] = this.sifraobracuna;
                    row["OBRIZNOSRATEKREDITOR"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["ZADIZNOSRATEKREDITA"]);
                    row["VECOTPLACENOBROJRATA"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["ZADVECOTPLACENOBROJRATA"]);
                    row["VECOTPLACENOUKUPNIIZNOS"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["ZADVECOTPLACENOUKUPNIIZNOS"]);
                    row["ukupniznoskredita"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["zadukupniznoskredita"]);
                    row["OBRMOKREDITOR"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["MOKREDITOR"]);
                    row["OBRPOKREDITOR"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["POKREDITOR"]);
                    row["OBRMZKREDITOR"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["MZKREDITOR"]);
                    row["OBRPZKREDITOR"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["PZKREDITOR"]);
                    row["OBRSIFRAOPISAPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["SIFRAOPISAPLACANJAKREDITOR"]);
                    row["OBROPISPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(dvRadnikkrediti[i]["OPISPLACANJAKREDITOR"]);
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dvRadnikkrediti[i]["KREDITAKTIVAN"], true, false), !this.ObracunatiKreditUMjesecu(this.sifraobracuna, Conversions.ToInteger(drv["idradnik"]), Conversions.ToInteger(dvRadnikkrediti[i]["ZADKREDITIIDKREDITOR"]), Conversions.ToDate(dvRadnikkrediti[i]["DATUMUGOVORA"])))) && this.chkKreditneObustave.Checked)
                    {
                        decimal num2 = Conversions.ToDecimal(dvRadnikkrediti[i]["ZADIZNOSRATEKREDITA"]);
                        if (decimal.Compare(num2, decimal.Subtract(nPrviNeto, nKolikoImaOlaksicaODOsiguranja)) <= 0)
                        {
                            if (Operators.ConditionalCompareObjectGreater(Operators.SubtractObject(row["ukupniznoskredita"], this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(drv["IDRADNIK"]), Conversions.ToInteger(dvRadnikkrediti[i]["ZADKREDITIIDKREDITOR"]), Conversions.ToDate(dvRadnikkrediti[i]["DATUMUGOVORA"]), this.STANJEKREDITA)), 0, false))
                            {
                                if (Operators.ConditionalCompareObjectLessEqual(Operators.SubtractObject(row["ukupniznoskredita"], this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(drv["IDRADNIK"]), Conversions.ToInteger(dvRadnikkrediti[i]["ZADKREDITIIDKREDITOR"]), Conversions.ToDate(dvRadnikkrediti[i]["DATUMUGOVORA"]), this.STANJEKREDITA)), num2, false))
                                {
                                    num2 = Conversions.ToDecimal(Operators.SubtractObject(row["ukupniznoskredita"], this.ObsDoZadObr(this.sifraobracuna, Conversions.ToInteger(drv["IDRADNIK"]), Conversions.ToInteger(dvRadnikkrediti[i]["ZADKREDITIIDKREDITOR"]), Conversions.ToDate(dvRadnikkrediti[i]["DATUMUGOVORA"]), this.STANJEKREDITA)));
                                }
                                row["OBRACUNATIKUNSKIIZNOS"] = num2;
                                nPrviNeto = decimal.Subtract(nPrviNeto, num2);
                                this.ObracunDataSet1.OBRACUNKrediti.Rows.Add(row);
                                drv.Row.SetColumnError("PREZIME", null);
                            }
                            else
                            {
                                drv.Row.SetColumnError("PREZIME", "Obustava nije obračunata!");
                            }
                        }
                    }
                }
            }
        }

        private void IzracunPlaceObustave(DataRowView drvObracun, decimal nKolikoImaOlaksicaODOsiguranja, ref decimal nPrviNeto, int br, DataView dvradnik2, decimal nObustava, decimal nIznosBezNaknada)
        {
            if (Operators.ConditionalCompareObjectEqual(drvObracun["obracunavajobustave"], true, false))
            {
                int num3 = dvradnik2.Count - 1;
                br = 0;
                while (br <= num3)
                {
                    decimal num = 0;
                    decimal num2 = 0;
                    OBRACUNDataSet.OBRACUNObustaveRow row = this.ObracunDataSet1.OBRACUNObustave.NewOBRACUNObustaveRow();
                    row["IDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(dvradnik2[br]["ZADOBUSTAVAIDOBUSTAVA"]);
                    row["IDradnik"] = RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]);
                    row["IDOBRACUN"] = this.sifraobracuna;
                    row["postotakobustave"] = RuntimeHelpers.GetObjectValue(dvradnik2[br]["zadpostotakobustave"]);
                    row["iznosobustave"] = RuntimeHelpers.GetObjectValue(dvradnik2[br]["zadiznosobustave"]);
                    row["ISPLACENOKASA"] = RuntimeHelpers.GetObjectValue(dvradnik2[br]["zadISPLACENOKASA"]);
                    row["SALDOKASA"] = RuntimeHelpers.GetObjectValue(dvradnik2[br]["zadSALDOKASA"]);
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dvradnik2[br]["OBUSTAVAAKTIVNA"], true, false), Operators.CompareObjectEqual(dvradnik2[br]["ZADOBUSTAVAVRSTAOBUSTAVE"], 1, false)), this.chkFiksneObustave.Checked), !this.ObracunataObustavaUMjesecu(this.sifraobracuna, Conversions.ToInteger(drvObracun["idradnik"]), Conversions.ToInteger(dvradnik2[br]["ZADOBUSTAVAIDOBUSTAVA"])))))
                    {
                        num2 = Conversions.ToDecimal(dvradnik2[br]["ZADIZNOSOBUSTAVE"]);
                        if (decimal.Compare(num2, decimal.Subtract(nPrviNeto, nKolikoImaOlaksicaODOsiguranja)) <= 0)
                        {
                            row["obracunataobustavaukunama"] = num2;
                            nPrviNeto = decimal.Subtract(nPrviNeto, num2);
                            this.ObracunDataSet1.OBRACUNObustave.Rows.Add(row);
                            drvObracun.Row.SetColumnError("PREZIME", null);
                            num = decimal.Add(num, num2);
                        }
                        else
                        {
                            drvObracun.Row.SetColumnError("PREZIME", "Obustava nije obračunata!");
                        }
                    }
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dvradnik2[br]["OBUSTAVAAKTIVNA"], true, false), Operators.CompareObjectEqual(dvradnik2[br]["ZADOBUSTAVAVRSTAOBUSTAVE"], 0, false))))
                    {
                        if (Operators.ConditionalCompareObjectEqual(dvradnik2[br]["ZADPOSTOTNAODBRUTA"], true, false))
                        {
                            num2 = Conversions.ToDecimal(Operators.DivideObject(Operators.MultiplyObject(dvradnik2[br]["ZADpostotakobustavE"], this.UkupniBruto(RuntimeHelpers.GetObjectValue(dvradnik2[br]["IDRADNIK"]))), 100));
                        }
                        else
                        {
                            num2 = Conversions.ToDecimal(Operators.DivideObject(Operators.MultiplyObject(dvradnik2[br]["ZADpostotakobustavE"], nObustava), 100));
                        }
                        num2 = DB.RoundUP(num2);
                        if ((this.chkPostotneObustave.Checked & (decimal.Compare(num2, decimal.Subtract(nPrviNeto, nKolikoImaOlaksicaODOsiguranja)) < 0)) & (decimal.Compare(num2, decimal.Zero) > 0))
                        {
                            row["obracunataobustavaukunama"] = num2;
                            nPrviNeto = decimal.Subtract(nPrviNeto, num2);
                            this.ObracunDataSet1.OBRACUNObustave.Rows.Add(row);
                            num = decimal.Add(num, num2);
                        }
                    }
                    if ((decimal.Compare(num, nIznosBezNaknada) >= 0) & (decimal.Compare(num, decimal.Zero) > 0))
                    {
                        drvObracun.Row.SetColumnError("IDRADNIK", "Obustave skinute od neto naknada!");
                    }
                    else
                    {
                        drvObracun.Row.SetColumnError("IDRADNIK", null);
                    }
                    br++;
                }
            }
        }

        public void IzracunSatnice(ref DataRow drow, ref double satnica, ref decimal gstaza, ref decimal mstaza, ref decimal dstaza)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            decimal num4 = 0;
            double num5 = 0;
            placa.UkupanRadniStaz(Conversions.ToInteger(drow["GODINESTAZA"]), Conversions.ToInteger(drow["MJESECISTAZA"]), Conversions.ToInteger(drow["DANISTAZA"]), Conversions.ToDate(drow["datumzadnjegzaposlenjapromjenefondasati"]), this.datumobracunastaza, Conversions.ToInteger(drow["tjednifondsatistaz"]), Convert.ToInt32(this.tjednifond), Conversions.ToDecimal(Operators.DivideObject(drow["BROJPRIZNATIHMJESECI"], 12)), ref num2, ref num3, ref num);
            gstaza = new decimal(num2);
            mstaza = new decimal(num3);
            dstaza = new decimal(num);
            if (Operators.ConditionalCompareObjectLessEqual(drow["KOEFICIJENT"], 0, false))
            {
                satnica = 0.0;
                return;
            }
            if (Operators.ConditionalCompareObjectEqual(this.dsKorisnik.KORISNIK.Rows[0]["STAZUKOEFICIJENTU"], true, false))
            {
                try
                {
                    num4 = Conversions.ToDecimal(Operators.MultiplyObject(decimal.Divide(this.mjesecnifond, this.tjednifond), drow["TJEDNIFONDSATI"]));
                    num5 = Math.Round(Conversions.ToDouble(Operators.DivideObject(Operators.MultiplyObject(drow["koeficijent"], drow["RADNIKOBRACUNOSNOVICA"]), num4)), 8);
                    goto Label_024D;
                }
                catch (System.Exception exception1)
                {
                    satnica = 0.0;

                    throw exception1;

                    //return;
                }
            }
            try
            {
                num4 = Conversions.ToDecimal(Operators.MultiplyObject(decimal.Divide(this.mjesecnifond, this.tjednifond), drow["TJEDNIFONDSATI"]));
                num5 = Convert.ToDouble(DB.RoundUpDecimale(Conversions.ToDouble(Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(drow["koeficijent"], drow["RADNIKOBRACUNOSNOVICA"]), 1.0 + ((((double)num2) / 2.0) / 100.0)), num4)), 8));
            }
            catch (System.Exception exception3)
            {
                satnica = 0.0;

                throw exception3;

                //return;
            }
        Label_024D:
            satnica = num5;
        }

        [LocalCommandHandler("Konacni")]
        public void KonacniHandler(object sender, EventArgs e)
        {
            new frmKonacni { _CallerForm = this }.ShowDialog();
        }


        [LocalCommandHandler("BrisanjeStavkeObracun")]
        public void BrisanjeKonacniHandler(object sender, EventArgs e)
        {
            SqlClient client = new SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From GOP1 Where IDOBRACUN = '"+ sifraobracuna + "'";
            
            try
            {
                sqlUpit.ExecuteNonQuery();

                UltraCheckEditor2_CheckedChanged(null, null);
                if (UltraCheckEditor2.Checked)
                    UltraCheckEditor2.Checked = false;
                else
                    UltraCheckEditor2.Checked = true;


                sqlUpit.CommandText = "Delete From ObracunPorezi Where IDPOREZ = 999";

                sqlUpit.ExecuteNonQuery();


                sqlUpit.CommandText = "Delete From ObracunElementi Where IDELEMENT = 9997";

                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Update ObracunRadnici Set KOREKCIJAPRIREZA = 0, ISKORISTENOOO = ODBITAKPRIJEKOREKCIJE, ODBITAKPRIJEKOREKCIJE = 0 Where IDOBRACUN = '" + sifraobracuna + "' And ODBITAKPRIJEKOREKCIJE > 0";

                sqlUpit.ExecuteNonQuery();


                sqlUpit.CommandText = "Update ObracunRadnici Set KOREKCIJAPRIREZA = 0 Where IDOBRACUN = '" + sifraobracuna + "' And ODBITAKPRIJEKOREKCIJE = 0";

                sqlUpit.ExecuteNonQuery();

                MessageBox.Show("Radi provjere i sigurnosti da je godišnji obračun poreza poništen obavezno nazovite T4S na 01/4645-655 ili 01/4645-656");

            }
            catch
            {
                MessageBox.Show("Dogodila se greška prilikom brisanja obračuna");
            }
        }

        [LocalCommandHandler("RekapKonacniPorezRadniciOpcine")]
        public void KonacniPorezHandler(object sender, EventArgs e)
        {
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(set2);
            string str8 = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str6 = Conversions.ToString(set2.KORISNIK.Rows[0]["KORISNIKOIB"]);
            string str = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnik1mjesto"]);
            string str7 = Conversions.ToString(set2.KORISNIK.Rows[0]["kontakttelefon"]);
            string str4 = Conversions.ToString(set2.KORISNIK.Rows[0]["kontaktfax"]);

            System.Data.DataTable tblKorekcija = new System.Data.DataTable();
            SqlClient client = new SqlClient();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("sp_korekcija_porez_prirez", client.sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idobracun", SqlDbType.NVarChar, 11).Value = sifraobracuna;
            adapter.SelectCommand = cmd;
            adapter.Fill(tblKorekcija);

            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rekapkorekcijeporeza.rpt");
            document.SetDataSource(tblKorekcija);
            document.SetParameterValue("telefon", str7);
            document.SetParameterValue("fax", str4);
            document.SetParameterValue("adresa2", str2);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("ustanova", str8);
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

        [CommandHandler("ListaIznosaCommand")]
        public void ListaIznosaCommandHandler(object sender, EventArgs e)
        {
            this.SaveToDatabase();
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            ListaIznosaWorkItem item = this.Controller.WorkItem.Items.Get<ListaIznosaWorkItem>("ListaIznosa");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<ListaIznosaWorkItem>("ListaIznosa");
            }
            item.Show(item.Workspaces["main"]);
        }

        private void NetoElementBrisi()
        {
            if (this.Obracun_Read_Only())
            {
                CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DatasetRekapitulacija1, "dtRekap"];
                if (manager.Count != 0)
                {
                    DataRowView current = (DataRowView) manager.Current;
                    if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["sifraelementa"])) && !Operators.ConditionalCompareObjectNotEqual(current["vrstaelementa"], 1, false))
                    {
                        this.dvNetoElementi.Sort = "IDELEMENT";
                        this.dvNetoElementi.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement=", current["sifraelementa"]), " and IDVRSTAELEMENTA = 1 "), "AND IDRADNIK = "), this.AktivanZaposlenik()), " and elementrazdobljeod='"), Strings.Format(RuntimeHelpers.GetObjectValue(current["Od"]), "dd/MM/yyyy")), "' and elementrazdobljedo='"), Strings.Format(RuntimeHelpers.GetObjectValue(current["do"]), "dd/MM/yyyy")), "'"));
                        ((DataRowView) this.BindingContext[this.dvNetoElementi].Current).Delete();
                        this.Obracunaj_Placu(true);
                    }
                }
            }
        }

        private void NetoElementiUnesiOznacenima()
        {
            if (this.Obracun_Read_Only())
            {
                if (this.BrojOznacenihZaposlenika() == 0)
                {
                    MessageBox.Show("Nema označenih zaposlenika!", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmEleUnosSvi svi2 = new frmEleUnosSvi {
                        Text = "Unesi neto elementa označenim zaposlenicima"
                    };
                    frmEleUnosSvi svi = svi2;
                    svi.labelSifEle.Text = "Neto element:";
                    svi._vrsta = Conversions.ToString(1);
                    svi._ParentFormObracun = this;
                    if (svi.ShowDialog() == DialogResult.OK)
                    {
                        this.Obracun_Svih_Zaposlenika();
                        foreach (UltraGridRow red in UltraGrid1.Rows)
                        {
                            if (red.Cells["oznacen"].Value.ToString() == "True")
                            {
                                id_radnika = red.Cells["IDRADNIK"].Value.ToString(); 
                                UpisiOznakuMjeseca(sifraobracuna);
                            }
                        }
                    }
                }
            }
        }

        private void NetoElementPromjena()
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DatasetRekapitulacija1, "dtRekap"];

            if (manager.Count > 0)
            {
                DataRowView current = (DataRowView) manager.Current;
                if ((Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["sifraelementa"])) && !Operators.ConditionalCompareObjectNotEqual(current["vrstaelementa"], 1, false)) && this.Obracun_Read_Only())
                {
                    frmEleUnos unos = new frmEleUnos {
                        _cfm = this
                    };
                    unos.cbSifra.ReadOnly = true;
                    unos.OdDatuma.ReadOnly = true;
                    unos.DoDatuma.ReadOnly = true;
                    this.dvBrutoElementi.Sort = "IDELEMENT";
                    unos._vrstaelementa = "1";
                    unos.__DataView = this.dvNetoElementi;
                    unos.__DataView__ = this.dvBrutoElementi;
                    this.dvNetoElementi.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement=", current["sifraelementa"]), " and IDVRSTAELEMENTA = 1 "), "AND IDRADNIK = "), this.AktivanZaposlenik()), " and elementrazdobljeod='"), Strings.Format(RuntimeHelpers.GetObjectValue(current["Od"]), "dd/MM/yyyy")), "' and elementrazdobljedo='"), Strings.Format(RuntimeHelpers.GetObjectValue(current["do"]), "dd/MM/yyyy")), "'"));
                    unos.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Izmjeni neto element (", NewLateBinding.LateIndexGet(this.BindingContext[this.dvNetoElementi].Current, new object[] { "IDELEMENT" }, null)), ") na trenutnom zaposleniku ("), this.AktivanZaposlenik()), " - "), this.AktivanZaposlenikPunoIme()), ")"));
                    unos.lblSifEle.Text = "Neto element:";
                    unos._drvElement = (DataRowView) this.BindingContext[this.dvNetoElementi].Current;
                    unos.cbSifra.Enabled = false;
                    unos.OdDatuma.Enabled = false;
                    unos.DoDatuma.Enabled = false;
                    if (unos.ShowDialog() == DialogResult.OK)
                    {
                        this.Obracunaj_Placu(true);
                        UpisiOznakuMjeseca(sifraobracuna);
                    }
                    unos.Dispose();
                }
            }
        }

        private void NetoElementUnos()
        {
            bool kontrola = false;
            if (this.currencyManagerZaposleniciObracun.Count == 0)
            {
                MessageBox.Show("U trenutnom obračunu nemate nadodanih zaposlenika.");
                return;
            }

            if (this.Obracun_Read_Only())
            {
                frmEleUnos unos2 = new frmEleUnos {
                    _cfm = this,
                    Text = "Unesi neto element na trenutnom zaposleniku (" + Conversions.ToString(this.AktivanZaposlenik()) + " - " + this.AktivanZaposlenikPunoIme() + ")"
                };
                using (frmEleUnos unos = unos2)
                {
                    unos.lblSifEle.Text = "Neto element:";
                    unos._vrstaelementa = "1";
                    unos.__DataView = this.dvBrutoElementi;
                    unos.__DataView__ = this.dvNetoElementi;
                    this.BindingContext[unos.__DataView].AddNew();
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "IDOBRACUN", this.sifraobracuna }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "IDRADNIK", RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.currencyManagerZaposleniciObracun.Current, new object[] { "IDRADNIK" }, null)) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "IDVRSTAELEMENTA", unos._vrstaelementa }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "ELEMENTRAZDOBLJEOD", DateAndTime.DateSerial(Conversions.ToInteger(this.godinaobracuna.Trim()), Conversions.ToInteger(this.mjesecobracuna.Trim()), 1) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "ELEMENTRAZDOBLJEDO", DateAndTime.DateSerial(Conversions.ToInteger(this.godinaobracuna.Trim()), Conversions.ToInteger(this.mjesecobracuna.Trim()), DateTime.DaysInMonth(Conversions.ToInteger(this.godinaobracuna.Trim()), Conversions.ToInteger(this.mjesecobracuna.Trim()))) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRSATI", 0 }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRSATNICA", DB.N20(0) }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRPOSTOTAK", 0 }, null, false, true);
                    NewLateBinding.LateIndexSetComplex(this.BindingContext[unos.__DataView].Current, new object[] { "OBRIZNOS", 0 }, null, false, true);
                    unos._drvElement = (DataRowView) this.BindingContext[unos.__DataView].Current;
                    if (unos.ShowDialog() == DialogResult.OK)
                    {
                        this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
                        kontrola = true;
                    }
                }
                this.Obracunaj_Placu(true);
                if (kontrola)
                {
                    UpisiOznakuMjeseca(sifraobracuna);
                }
            }
        }

        // Funkcionalnost "Neto u bruto" deaktivirana
        
        [CommandHandler("NetoUBruto")]
        public void NetoUBrutoCommandHandler(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite obračun!!!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    ControlBox = true,
                    Title = "Neto u bruto",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                NetoUBrutoObracun smartPart = this.Controller.WorkItem.Items.AddNew<NetoUBrutoObracun>();
                smartPart.radnik = this.AktivanZaposlenik();
                smartPart.MjesecIsplate = this.mjesecisplate;
                smartPart.GodinaIsplate = this.godinaisplate;
                workspace.Show(smartPart, smartPartInfo);
            }
        }
        

        private void Novi_Obracun()
        {
            frmUnosPodatakaOObracunu obracunu = new frmUnosPodatakaOObracunu();
            if (obracunu.ShowDialog() == DialogResult.Cancel)
            {
                Interaction.MsgBox("Odustali ste od kreiranja obračuna!", MsgBoxStyle.Information, "Obračun plaća");
            }
            else
            {
                frmPregledRadnika frm = new frmPregledRadnika();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.Cancel)
                {
                    int num = 0;
                    UltraGrid odabraniRadnici = new UltraGrid();
                    odabraniRadnici = (UltraGrid) frm.OdabraniRadnici;
                    int num3 = odabraniRadnici.Rows.Count - 1;
                    int num2 = 0;
                    while (num2 <= num3)
                    {
                        if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                        {
                            num++;
                        }
                        num2++;
                    }
                    if (num == 0)
                    {
                        Interaction.MsgBox("Nema označenih zaposlenika", MsgBoxStyle.Information, "Obračun plaća");
                    }
                    else
                    {
                        this.mjesecobracuna = obracunu.__Obracun.mjesecobracuna;
                        this.godinaobracuna = obracunu.__Obracun.godinaobracuna;
                        this.mjesecisplate = obracunu.__Obracun.mjesecisplate;
                        this.godinaisplate = obracunu.__Obracun.godinaisplate;
                        this.mjesecnifond = obracunu.__Obracun.mjesecnifond;
                        this.tjednifond = obracunu.__Obracun.tjednifond;
                        this.osnovnioo = obracunu.__Obracun.osnovnioo;
                        this.obrosnovica = obracunu.__Obracun.obrosnovica;
                        this.sifraobracuna = obracunu.__Obracun.sifraobracuna;
                        this.txtSifraobracuna.Value = obracunu.__Obracun.sifraobracuna;
                        this.datumobracunastaza = obracunu.__Obracun.datumobracunastaza;
                        this.txtOpisObracuna = obracunu.__Obracun.txtOpisObracuna;
                        this.Cursor = Cursors.Default;
                        this.bPromjeneMoguce = true;
                        this.ListBox1.Items.Clear();
                        this.ListBox1.Items.Add(" ");
                        this.ListBox1.Items.Add("Šifra obračuna:" + this.sifraobracuna);
                        this.ListBox1.Items.Add("Godina i mjesec obračuna " + this.godinaobracuna + "/" + this.mjesecobracuna);
                        this.ListBox1.Items.Add("Godina i mjesec isplate " + this.godinaisplate + "/" + this.mjesecisplate);
                        this.ListBox1.Items.Add("Mjesečni / tjedni fond sati " + Conversions.ToString(this.mjesecnifond) + "/" + Conversions.ToString(this.tjednifond));
                        this.ListBox1.Items.Add("Osnovni OO / Obračunska osnovica " + string.Format("{0:#,##0.00}", this.osnovnioo) + "/" + string.Format("{0:#,##0.00}", this.obrosnovica));
                        this.ListBox1.Items.Add("Datum obračuna staža:" + Conversions.ToString(this.datumobracunastaza));
                        this.ListBox1.Items.Add("Opis obračuna --->>>" + this.txtOpisObracuna);
                        this.currencyManagerZaposleniciObracun = (CurrencyManager) this.BindingContext[this.ObracunDataSet1, "OBRACUNRADNICI"];

                        this.currencyManagerZaposleniciObracun.PositionChanged += new EventHandler(ZaposleniciUobracunu_Promjena_Pozicije);

                        //this.ZaposleniciUobracunu_Promjena_Pozicije(null, null);

                        this.blokirajPromjenuPozicije = true;
                        
                        DataRow row = this.ObracunDataSet1.OBRACUN.NewRow();

                        row["vrstaobracuna"] = "PL";
                        row["mjesecobracuna"] = this.mjesecobracuna;
                        row["godinaobracuna"] = this.godinaobracuna;
                        row["mjesecisplate"] = this.mjesecisplate;
                        row["godinaisplate"] = this.godinaisplate;
                        row["tjednifondsatiobracun"] = this.tjednifond;
                        row["mjesecnifondsatiobracun"] = this.mjesecnifond;
                        row["idobracun"] = this.sifraobracuna;
                        row["osnovnioo"] = this.osnovnioo;
                        row["obracunskaosnovica"] = this.obrosnovica;
                        row["datumobracunastaza"] = this.datumobracunastaza;
                        row["obrpostotnih"] = this.chkPostotneObustave.Checked;
                        row["obrfiksnih"] = this.chkFiksneObustave.Checked;
                        row["obrkreditnih"] = this.chkKreditneObustave.Checked;
                        row["zaklj"] = 0;
                        row["SVRHAOBRACUNA"] = this.txtOpisObracuna;
                        this.ObracunDataSet1.OBRACUN.Rows.Add(row);
                        this.BindingContext[this.ObracunDataSet1.OBRACUN].EndCurrentEdit();
                        int num4 = odabraniRadnici.Rows.Count - 1;
                        for (num2 = 0; num2 <= num4; num2++)
                        {
                            if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                            {
                                bool[] flagArray;
                                OBRACUNDataSet.ObracunRadniciRow row2 = (OBRACUNDataSet.ObracunRadniciRow) this.ObracunDataSet1.ObracunRadnici.NewRow();
                                row2["idradnik"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["idradnik"].Value);
                                row2["idobracun"] = this.sifraobracuna;
                                row2["OBRACUNATIPRIREZ"] = 0;
                                row2["FAKTOO"] = 0;
                                row2["ISKORISTENOOO"] = 0;
                                row2["SIFRAOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["OPCINASTANOVANJAIDOPCINE"].Value);
                                row2["obracunskikoeficijent"] = 0;
                                row2["KOREKCIJAPRIREZA"] = 0;
                                row2["ODBITAKPRIJEKOREKCIJE"] = 0;
                                row2["RADNIKOBRACUNOSNOVICA"] = this.obrosnovica;
                                row2["OBRACUNAVAJOBUSTAVE"] = true;
                                this.ObracunDataSet1.ObracunRadnici.Rows.Add(row2);
                                object instance = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                                ReadOnlyConnection connection6 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                ReadOnlyCommand command6 = connection6.GetCommand("SELECT [PREZIME], [IME], [JMBG], [DATUMRODJENJA], [TEKUCI], [SIFRAOPISAPLACANJANETO], [OPISPLACANJANETO], [BROJMIROVINSKOG], [BROJZDRAVSTVENOG], [MBO], [POSTOTAKOSLOBODJENJAODPOREZA], [KOEFICIJENT], [AKTIVAN], [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], [TJEDNIFONDSATI], [TJEDNIFONDSATISTAZ], [GODINESTAZA], [MJESECISTAZA], [DANISTAZA], [DATUMPRESTANKARADNOGODNOSA], [ZBIRNINETO], [UZIMAUOBZIROSNOVICEDOPRINOSA], [IDIPIDENT], [IDBANKE], [IDBENEFICIRANI], [IDTITULA], [IDRADNOMJESTO], [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA], [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, [IDSTRUKA], [IDORGDIO], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
                                if (command6.IDbCommand.Parameters.Count == 0)
                                {
                                    command6.IDbCommand.Parameters.Add(new SqlParameter("@IDRADNIK", SqlDbType.Int));
                                }
                                command6.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["IDRADNIK"]));
                                IDataReader reader6 = command6.FetchData();
                                if (!command6.HasMoreRows)
                                {
                                    reader6.Close();
                                    object[] objArray2 = new object[] { connection6 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", objArray2, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection6 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[0]), typeof(ReadOnlyConnection));
                                    }
                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "RADNIK" }));
                                }
                                object[] arguments = new object[] { reader6, 0 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["PREZIME"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 1 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IME"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 2 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["JMBG"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 3 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDateTime", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 4 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["TEKUCI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 5 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 6 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 7 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 8 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 9 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["MBO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 10 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 11 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 12 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["AKTIVAN"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetBoolean", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 13 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDateTime", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 14 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 15 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x10 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x11 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x12 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["DANISTAZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x13 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDateTime", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 20 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetBoolean", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x15 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetBoolean", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x16 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x17 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IDBANKE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x18 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x19 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IDTITULA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x1a };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x1b };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x1c };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x1d };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 30 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["IDORGDIO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x1f };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x20 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                arguments = new object[] { reader6, 0x21 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row2["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", arguments, null, null, flagArray));
                                reader6.Close();
                                arguments = new object[] { connection6 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection6 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                                if (!row2.IsIDBANKENull())
                                {
                                    ReadOnlyConnection connection = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command = connection.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
                                    if (command.IDbCommand.Parameters.Count == 0)
                                    {
                                        command.IDbCommand.Parameters.Add(new SqlParameter("@IDBANKE", SqlDbType.Int));
                                    }
                                    command.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["IDBANKE"]));
                                    IDataReader reader = command.FetchData();
                                    if (!command.HasMoreRows)
                                    {
                                        reader.Close();
                                        arguments = new object[] { connection };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "BANKE" }));
                                    }
                                    arguments = new object[] { reader, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    arguments = new object[] { reader, 1 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    arguments = new object[] { reader, 2 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    arguments = new object[] { reader, 3 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    arguments = new object[] { reader, 4 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader.Close();
                                    arguments = new object[] { connection };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["NAZIVBANKE1"] = "";
                                    row2["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    row2["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    row2["VBDIBANKE"] = "";
                                    row2["ZRNBANKE"] = "";
                                }
                                if (!row2.IsIDBENEFICIRANINull())
                                {
                                    ReadOnlyConnection connection2 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command2 = connection2.GetCommand("SELECT [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
                                    if (command2.IDbCommand.Parameters.Count == 0)
                                    {
                                        command2.IDbCommand.Parameters.Add(new SqlParameter("@IDBENEFICIRANI", SqlDbType.NVarChar, 1));
                                    }
                                    command2.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["IDBENEFICIRANI"]));
                                    IDataReader reader2 = command2.FetchData();
                                    if (!command2.HasMoreRows)
                                    {
                                        reader2.Close();
                                        arguments = new object[] { connection2 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "BENEFICIRANI" }));
                                    }
                                    arguments = new object[] { reader2, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    arguments = new object[] { reader2, 1 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", arguments, null, null, flagArray));
                                    reader2.Close();
                                    arguments = new object[] { connection2 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["NAZIVBENEFICIRANI"] = "";
                                    row2["BROJPRIZNATIHMJESECI"] = 0;
                                }
                                if (!row2.IsIDORGDIONull())
                                {
                                    ReadOnlyConnection connection5 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command5 = connection5.GetCommand("SELECT [ORGANIZACIJSKIDIO] FROM [ORGDIO] (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                                    if (command5.IDbCommand.Parameters.Count == 0)
                                    {
                                        command5.IDbCommand.Parameters.Add(new SqlParameter("@IDORGDIO", SqlDbType.Int));
                                    }
                                    command5.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["IDORGDIO"]));
                                    IDataReader reader5 = command5.FetchData();
                                    if (!command5.HasMoreRows)
                                    {
                                        reader5.Close();
                                        arguments = new object[] { connection5 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection5 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ORGDIO" }));
                                    }
                                    arguments = new object[] { reader5, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader5 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader5.Close();
                                    arguments = new object[] { connection5 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection5 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["ORGANIZACIJSKIDIO"] = "";
                                }
                                if (!row2.IsIDTITULANull())
                                {
                                    ReadOnlyConnection connection12 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command12 = connection12.GetCommand("SELECT [NAZIVTITULA] FROM [TITULA] (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                                    if (command12.IDbCommand.Parameters.Count == 0)
                                    {
                                        command12.IDbCommand.Parameters.Add(new SqlParameter("@IDTITULA", SqlDbType.Int));
                                    }
                                    command12.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["IDTITULA"]));
                                    IDataReader reader12 = command12.FetchData();
                                    if (!command12.HasMoreRows)
                                    {
                                        reader12.Close();
                                        arguments = new object[] { connection12 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection12 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "TITULA" }));
                                    }
                                    arguments = new object[] { reader12, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader12 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader12.Close();
                                    arguments = new object[] { connection12 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection12 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["NAZIVTITULA"] = "";
                                }
                                if (!row2.IsIDRADNOMJESTONull())
                                {
                                    ReadOnlyConnection connection7 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command7 = connection7.GetCommand("SELECT [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                                    if (command7.IDbCommand.Parameters.Count == 0)
                                    {
                                        command7.IDbCommand.Parameters.Add(new SqlParameter("@IDRADNOMJESTO", SqlDbType.Int));
                                    }
                                    command7.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["IDRADNOMJESTO"]));
                                    IDataReader reader7 = command7.FetchData();
                                    if (!command7.HasMoreRows)
                                    {
                                        reader7.Close();
                                        arguments = new object[] { connection7 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection7 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "RADNOMJESTO" }));
                                    }
                                    arguments = new object[] { reader7, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader7 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader7.Close();
                                    arguments = new object[] { connection7 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection7 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["NAZIVRADNOMJESTO"] = "";
                                }
                                if (!row2.IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull())
                                {
                                    ReadOnlyConnection connection9 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command9 = connection9.GetCommand("SELECT [NAZIVSTRUCNASPREMA] FROM [STRUCNASPREMA] (NOLOCK) WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
                                    if (command9.IDbCommand.Parameters.Count == 0)
                                    {
                                        command9.IDbCommand.Parameters.Add(new SqlParameter("@IDSTRUCNASPREMA", SqlDbType.Int));
                                    }
                                    command9.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                                    IDataReader reader9 = command9.FetchData();
                                    if (!command9.HasMoreRows)
                                    {
                                        reader9.Close();
                                        arguments = new object[] { connection9 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection9 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "STRUCNASPREMA" }));
                                    }
                                    arguments = new object[] { reader9, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader9 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader9.Close();
                                    arguments = new object[] { connection9 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection9 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = "";
                                }
                                if (!row2.IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull())
                                {
                                    ReadOnlyConnection connection10 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command10 = connection10.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] (NOLOCK) WHERE [IDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                                    if (command10.IDbCommand.Parameters.Count == 0)
                                    {
                                        command10.IDbCommand.Parameters.Add(new SqlParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", SqlDbType.Int));
                                    }
                                    command10.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                                    IDataReader reader10 = command10.FetchData();
                                    if (!command10.HasMoreRows)
                                    {
                                        reader10.Close();
                                        arguments = new object[] { connection10 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection10 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "STRUCNASPREMA" }));
                                    }
                                    arguments = new object[] { reader10, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader10 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader10.Close();
                                    arguments = new object[] { connection10 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection10 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                }
                                if (!row2.IsIDSTRUKANull())
                                {
                                    ReadOnlyConnection connection11 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command11 = connection11.GetCommand("SELECT [NAZIVSTRUKA] FROM [STRUKA] (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                                    if (command11.IDbCommand.Parameters.Count == 0)
                                    {
                                        command11.IDbCommand.Parameters.Add(new SqlParameter("@IDSTRUKA", SqlDbType.Int));
                                    }
                                    command11.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["IDSTRUKA"]));
                                    IDataReader reader11 = command11.FetchData();
                                    if (!command11.HasMoreRows)
                                    {
                                        reader11.Close();
                                        arguments = new object[] { connection11 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection11 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "STRUKA" }));
                                    }
                                    arguments = new object[] { reader11, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader11 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader11.Close();
                                    arguments = new object[] { connection11 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection11 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["NAZIVSTRUKA"] = "";
                                }
                                if (!row2.IsOPCINARADAIDOPCINENull())
                                {
                                    ReadOnlyConnection connection3 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command3 = connection3.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, [PRIREZ] AS OPCINARADAPRIREZ FROM [OPCINA] (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
                                    if (command3.IDbCommand.Parameters.Count == 0)
                                    {
                                        command3.IDbCommand.Parameters.Add(new SqlParameter("@OPCINARADAIDOPCINE", SqlDbType.NVarChar, 4));
                                    }
                                    command3.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["OPCINARADAIDOPCINE"]));
                                    IDataReader reader3 = command3.FetchData();
                                    if (!command3.HasMoreRows)
                                    {
                                        reader3.Close();
                                        arguments = new object[] { connection3 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OPCINA" }));
                                    }
                                    arguments = new object[] { reader3, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    arguments = new object[] { reader3, 1 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", arguments, null, null, flagArray));
                                    reader3.Close();
                                    arguments = new object[] { connection3 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    row2["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                }
                                if (!row2.IsOPCINASTANOVANJAIDOPCINENull())
                                {
                                    ReadOnlyConnection connection4 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command4 = connection4.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ FROM [OPCINA] (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
                                    if (command4.IDbCommand.Parameters.Count == 0)
                                    {
                                        command4.IDbCommand.Parameters.Add(new SqlParameter("@OPCINASTANOVANJAIDOPCINE", SqlDbType.NVarChar, 4));
                                    }
                                    command4.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["OPCINASTANOVANJAIDOPCINE"]));
                                    IDataReader reader4 = command4.FetchData();
                                    if (!command4.HasMoreRows)
                                    {
                                        reader4.Close();
                                        arguments = new object[] { connection4 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection4 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OPCINA" }));
                                    }
                                    arguments = new object[] { reader4, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader4 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    arguments = new object[] { reader4, 1 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader4 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", arguments, null, null, flagArray));
                                    reader4.Close();
                                    arguments = new object[] { connection4 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection4 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    row2["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                }
                                if (!row2.IsRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull())
                                {
                                    ReadOnlyConnection connection8 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command8 = connection8.GetCommand("SELECT [NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA FROM [SKUPPOREZAIDOPRINOSA] (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
                                    if (command8.IDbCommand.Parameters.Count == 0)
                                    {
                                        command8.IDbCommand.Parameters.Add(new SqlParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", SqlDbType.Int));
                                    }
                                    command8.SetParameter(0, RuntimeHelpers.GetObjectValue(row2["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
                                    IDataReader reader8 = command8.FetchData();
                                    if (!command8.HasMoreRows)
                                    {
                                        reader8.Close();
                                        arguments = new object[] { connection8 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection8 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "SKUPPOREZAIDOPRINOSA" }));
                                    }
                                    arguments = new object[] { reader8, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader8 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                    }
                                    row2["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                    reader8.Close();
                                    arguments = new object[] { connection8 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection8 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                else
                                {
                                    row2["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                }
                            }
                        }
                        this.BindingContext[this.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
                        if (frm.Bruto)
                        {
                            this.ZapocniObracun_I_Dodaj_Bruto_ELemente(frm);
                        }
                        if (frm.Neto)
                        {
                            this.Zapocni_Obracun_I_Dodaj_neto_Elemente(frm);
                        }
                        try
                        {
                            this.daObracunGlobal.Update(this.ObracunDataSet1);
                            //upis oznake mjeseca 3 za svaki dodani element svim radnicima koji su odabrani
                            if (frm.Bruto | frm.Neto)
                            {
                                oznaka_mjeseca = "3";
                                UpisiOznakuMjesecaSvima(sifraobracuna);
                            }

                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                            
                            
                            
                        }
                        this.Obracun_Svih_Zaposlenika();
                        this.blokirajPromjenuPozicije = false;
                        this.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
                        this.Cursor = Cursors.Default;
                        this.Puni_poreze(this.sifraobracuna);
                        this.Puni_oo(this.sifraobracuna);
                        this.Puni_Obustave(this.sifraobracuna);
                        this.Puni_KRIZNI_NETO(this.sifraobracuna, this.mjesecisplate, this.godinaisplate);
                        new S_OD_STANJE_KREDITADataAdapter().Fill(this.STANJEKREDITA, this.sifraobracuna);
                        new S_OD_STANJE_OBUSTAVADataAdapter().Fill(this.STANJEOBUSTAVA, this.sifraobracuna);
                    }
                }
            }
        }



        private bool Obracun_Read_Only()
        {
            if (admin_kontrola == false)
            {

                if (!this.bPromjeneMoguce)
                {
                    MessageBox.Show("Izmjene nisu moguće na trenutnom obračunu!\r\n\r\nNapomena: Izmjene je moguće raditi samo na zadnjem obračunu u nekom mjesecu.", "Obračun plaće", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    if (MessageBox.Show("unesite admin lozinku za promjenu podataka.", "Admin sučelje", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    {
                        frmAdmin admin = new frmAdmin();
                        if (admin.ShowDialog() == DialogResult.OK)
                        {
                            admin_kontrola = true;
                            return true;
                        }
                    }
                }
            }
            else
            {
                return true;
            }
            return this.bPromjeneMoguce;
        }

        private void Obracun_Svih_Zaposlenika()
        {
            this.Osvjezi_radnike();
            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(this.InitChildFormData);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DoneChildFormInit);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(this.PerformingActions);
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = false;
            this.frmProg = new fmProgress();
            this.bw.RunWorkerAsync();
            this.frmProg.ShowDialog();
        }

        private void Obracunaj_Placu(bool radiObracun = false)
        {
            DataRowView current;
            if (this.bPromjeneMoguce && (this.ObracunDataSet1.HasChanges() | radiObracun))
            {
                current = (DataRowView) this.currencyManagerZaposleniciObracun.Current;
                this.Izracun_Place(this.ObracunDataSet1, current);
            }
            this.daObracunGlobal.Update(this.ObracunDataSet1);
            current = (DataRowView) this.currencyManagerZaposleniciObracun.Current;
            this.Platna_Ekran(current, false);
        }

        private bool ObracunataObustavaUMjesecu(string IDOBRACUN, int IDRADNIK, int IDOBUSTAVA)
        {
            int num = 0;
            DataRow[] rowArray = this.dsObustavaobracunata.S_OD_OBUSTAVA_OBRACUNATA.Select("idobustava= " + Conversions.ToString(IDOBUSTAVA) + " AND IDRADNIK = " + Conversions.ToString(IDRADNIK));
            if (rowArray.Length > 0)
            {
                num = Conversions.ToInteger(rowArray[0]["obracunato"]);
            }
            else
            {
                num = 0;
            }
            return (num > 0);
        }

        private bool ObracunataOlaksicaUMjesecu(string IDOBRACUN, int IDRADNIK, int IDOLAKSICE)
        {
            return false;
        }

        private bool ObracunatiKreditUMjesecu(string IDOBRACUN, int IDRADNIK, int IDOBUSTAVA, DateTime DATUMUGOVORA)
        {
            int num = 0;
            DataRow[] rowArray = this.dskreditObracunat.S_OD_KREDIT_OBRACUNAT.Select("IDkreditor= " + Conversions.ToString(IDOBUSTAVA) + " AND IDRADNIK = " + Conversions.ToString(IDRADNIK) + " and datumugovora = '" + Conversions.ToString(DATUMUGOVORA) + "'");
            if (rowArray.Length > 0)
            {
                num = Conversions.ToInteger(rowArray[0]["obracunato"]);
            }
            else
            {
                num = 0;
            }
            return (num > 0);
        }

        private void ObracunSmartPart_Load(object sender, EventArgs e)
        {
            this.dvNetoElementi.Table = this.ObracunDataSet1.ObracunElementi;
            this.dvBrutoElementi.Table = this.ObracunDataSet1.ObracunElementi;
            this.dagrupeolaksica.Fill(this.GrupeolaksicaDataSet1);
            this.daSkupinePorezaIdoprinosa.Fill(this.SkupporezaidoprinosaDataSet1);
            this.PostaviBindingZaVrsteObustava();
            this.ZapocniPonovo();
            this.dakorisnik.Fill(this.dsKorisnik);
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.DataErrorCellAppearance.BackColor = Color.Silver;
            this.ListBox1.Items.Clear();
            this.ListBox1.Items.Add("TRENUTNO NEMA OTVORENOG OBRAČUNA");
        }

        [LocalCommandHandler("ObrasciPorezna")]
        public void ObrasciPoreznaHandler(object sender, EventArgs e)
        {
            string str2 = string.Empty;
            S_PLACA_KONACNI_REKAPOPCINEDataAdapter adapter = new S_PLACA_KONACNI_REKAPOPCINEDataAdapter();
            S_PLACA_KONACNI_REKAPOPCINEDataSet dataSet = new S_PLACA_KONACNI_REKAPOPCINEDataSet();
            adapter.Fill(dataSet, this.sifraobracuna);
            S_PLACA_KONACNI_REKAPOPCINEDataSet set3 = new S_PLACA_KONACNI_REKAPOPCINEDataSet();
            set3.Merge(dataSet.S_PLACA_KONACNI_REKAPOPCINE.Select("porezporezna <> 0 or prirezporezna <> 0"));
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(set2);
            string str7 = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str6 = Conversions.ToString(set2.KORISNIK.Rows[0]["MBKORISNIK"]);
            string str = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str4 = Conversions.ToString(set2.KORISNIK.Rows[0]["korisnik1mjesto"]);
            DataRow[] rowArray = set2.KORISNIKLevel1.Select("vbdikorisnik <> 1001005");
            if (rowArray.Length > 0)
            {
                str2 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
            }
            else
            {
                str2 = "";
            }
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\Predmet.rpt");
            document.SetDataSource(set3);
            document.SetParameterValue("mjesto", str4);
            document.SetParameterValue("ziro", str2);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("ustanova", str7);
            document.SetParameterValue("oib", str6);
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

        [LocalCommandHandler("ObrisiRadnike")]
        public void ObrisiRadnikeHandler(object sender, EventArgs e)
        {
            this.BrisiOznaceneRadnike();
        }

        public decimal ObsDoZadObr(string IDOBRACUN, int IDRADNIK, int IDKREDITOR, DateTime DATUMUGOVORA, DataSet STANJEKREDITA)
        {
            decimal num = 0;
            decimal num2 = 0;
            string str = "#" +DATUMUGOVORA.ToString(DateTimeFormatInfo.InvariantInfo) + "#";
            //string str = DATUMUGOVORA.ToString(DateTimeFormatInfo.InvariantInfo);
            DataRow[] rowArray = STANJEKREDITA.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND IDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            DataRow[] rowArray2 = this.RadnikDataSet1.RADNIKKrediti.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND ZADKREDITIIDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            if (rowArray.Length > 0)
            {
                num = Conversions.ToDecimal(rowArray[0]["OTPLACENO"]);
            }
            else
            {
                num = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray2[0]["ZADVECOTPLACENOUKUPNIIZNOS"]);
            }
            else
            {
                num2 = new decimal();
            }
            return decimal.Add(num, num2);
        }

        public decimal Obustave_BrojRata(string IDOBRACUN, int IDRADNIK, int IDobustava, DataSet stanjeobustava)
        {
            DataRow[] rowArray = stanjeobustava.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND IDobustava = " + Conversions.ToString(IDobustava));
            if (rowArray.Length > 0)
            {
                return Conversions.ToDecimal(rowArray[0]["brojrata"]);
            }
            return new decimal();
        }

        public decimal Obustave_Iznos(string IDOBRACUN, int IDRADNIK, int IDobustava, DataSet stanjeobustava)
        {
            decimal num = 0;
            decimal num2 = 0;
            DataRow[] rowArray = stanjeobustava.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND IDobustava = " + Conversions.ToString(IDobustava));
            DataRow[] rowArray2 = this.RadnikDataSet1.RADNIKObustava.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND zadobustavaidobustava = " + Conversions.ToString(IDobustava));
            if (rowArray.Length > 0)
            {
                num = Conversions.ToDecimal(rowArray[0]["OTPLACENO"]);
            }
            else
            {
                num = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray2[0]["zadsaldokasa"]);
            }
            else
            {
                num2 = new decimal();
            }
            return decimal.Add(num, num2);
        }

        public decimal Obustave_StanjeKase(string IDOBRACUN, int IDRADNIK, int IDobustava, DataSet stanjeobustava)
        {
            decimal num = 0;
            decimal num2 = 0;
            decimal num3 = 0;
            DataRow[] rowArray = stanjeobustava.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND IDobustava = " + Conversions.ToString(IDobustava));
            DataRow[] rowArray2 = this.RadnikDataSet1.RADNIKObustava.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND zadobustavaidobustava = " + Conversions.ToString(IDobustava));
            DataRow[] rowArray3 = this.RadnikDataSet1.RADNIKObustava.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND zadobustavaidobustava = " + Conversions.ToString(IDobustava));
            if (rowArray.Length > 0)
            {
                num = Conversions.ToDecimal(rowArray[0]["OTPLACENO"]);
            }
            else
            {
                num = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray2[0]["zadsaldokasa"]);
            }
            else
            {
                num2 = new decimal();
            }
            if (rowArray3.Length > 0)
            {
                num3 = Conversions.ToDecimal(rowArray3[0]["zadisplacenokasa"]);
            }
            else
            {
                num3 = new decimal();
            }
            return decimal.Subtract(decimal.Add(num, num2), num3);
        }

        public void Osvjezi_radnike()
        {
            RADNIKDataSet dataSet = new RADNIKDataSet();
            this.daRadnici.Fill(dataSet);
            this.RadnikDataSet1.Merge(dataSet, false);
        }

        private void Parametri_DodajOznaceneRadnike()
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Kliknite na 'Započni novi' za dodavanje zaposlenika ua obračun!", "MBS.Complete - Računovodstvo proračuna", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.Obracun_Read_Only())
            {
                this.blokirajPromjenuPozicije = true;
                frmPregledRadnika radnika = new frmPregledRadnika {
                    VecUObracunu = this.ObracunDataSet1.ObracunRadnici
                };
                radnika.ShowDialog();
                int num = 0;

                if (radnika.OdabraniRadnici.GetType() != new UltraGrid().GetType())
                    return;
                    
                UltraGrid odabraniRadnici = new UltraGrid();
                odabraniRadnici = (UltraGrid)radnika.OdabraniRadnici;

                if (odabraniRadnici != null)
                {
                    int num5 = odabraniRadnici.Rows.Count - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[i].Cells["oznacen"].Value, true, false))
                        {
                            num++;
                        }
                    }
                    if (num == 0)
                    {
                        Interaction.MsgBox("Nema označenih zaposlenika", MsgBoxStyle.OkOnly, null);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        this.currencyManagerZaposleniciObracun = (CurrencyManager) this.BindingContext[this.ObracunDataSet1, "OBRACUNRADNICI"];
                        this.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
                        this.blokirajPromjenuPozicije = true;
                        RowEnumerator enumerator = odabraniRadnici.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            UltraGridRow current = enumerator.Current;
                            if (Operators.ConditionalCompareObjectEqual(current.Cells["oznacen"].Value, true, false))
                            {
                                object[] objArray;
                                bool[] flagArray;
                                bool flag2 = false;
                                try
                                {
                                    OBRACUNDataSet.ObracunRadniciRow row = (OBRACUNDataSet.ObracunRadniciRow) this.ObracunDataSet1.ObracunRadnici.NewRow();
                                    row["idradnik"] = RuntimeHelpers.GetObjectValue(current.Cells["idradnik"].Value);
                                    row["idobracun"] = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
                                    row["idobracun"] = this.sifraobracuna;
                                    row["OBRACUNATIPRIREZ"] = 0;
                                    row["KOREKCIJAPRIREZA"] = 0;
                                    row["ODBITAKPRIJEKOREKCIJE"] = 0;
                                    row["FAKTOO"] = 0;
                                    row["ISKORISTENOOO"] = 0;
                                    row["SIFRAOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(current.Cells["OPCINASTANOVANJAIDOPCINE"].Value);
                                    row["obracunskikoeficijent"] = 0;
                                    row["RADNIKOBRACUNOSNOVICA"] = this.obrosnovica;
                                    row["OBRACUNAVAJOBUSTAVE"] = true;
                                    this.ObracunDataSet1.ObracunRadnici.Rows.Add(row);
                                    object instance = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                                    ReadOnlyConnection connection6 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                    ReadOnlyCommand command6 = connection6.GetCommand("SELECT [PREZIME], [IME], [JMBG], [DATUMRODJENJA], [TEKUCI], [SIFRAOPISAPLACANJANETO], [OPISPLACANJANETO], [BROJMIROVINSKOG], [BROJZDRAVSTVENOG], [MBO], [POSTOTAKOSLOBODJENJAODPOREZA], [KOEFICIJENT], [AKTIVAN], [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], [TJEDNIFONDSATI], [TJEDNIFONDSATISTAZ], [GODINESTAZA], [MJESECISTAZA], [DANISTAZA], [DATUMPRESTANKARADNOGODNOSA], [ZBIRNINETO], [UZIMAUOBZIROSNOVICEDOPRINOSA], [IDIPIDENT], [IDBANKE], [IDBENEFICIRANI], [IDTITULA], [IDRADNOMJESTO], [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA], [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, [IDSTRUKA], [IDORGDIO], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
                                    if (command6.IDbCommand.Parameters.Count == 0)
                                    {
                                        command6.IDbCommand.Parameters.Add(new SqlParameter("@IDRADNIK", SqlDbType.Int));
                                    }
                                    command6.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDRADNIK"]));
                                    IDataReader reader6 = command6.FetchData();
                                    if (!command6.HasMoreRows)
                                    {
                                        reader6.Close();
                                        object[] arguments = new object[] { connection6 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection6 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                        }
                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "RADNIK" }));
                                    }
                                    objArray = new object[] { reader6, 0 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["PREZIME"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 1 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IME"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 2 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["JMBG"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 3 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDateTime", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 4 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["TEKUCI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 5 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 6 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 7 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 8 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 9 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["MBO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 10 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 11 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 12 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["AKTIVAN"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetBoolean", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 13 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDateTime", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 14 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 15 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x10 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x11 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x12 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["DANISTAZA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x13 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDateTime", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 20 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetBoolean", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x15 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetBoolean", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x16 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x17 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IDBANKE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x18 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x19 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IDTITULA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x1a };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x1b };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["trenutnastrucnaspremaIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x1c };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x1d };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 30 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["IDORGDIO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x1f };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x20 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                    objArray = new object[] { reader6, 0x21 };
                                    flagArray = new bool[] { true, false };
                                    if (flagArray[0])
                                    {
                                        reader6 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                    }
                                    row["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt32", objArray, null, null, flagArray));
                                    reader6.Close();
                                    objArray = new object[] { connection6 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection6 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                    }
                                    if (!row.IsIDBANKENull())
                                    {
                                        ReadOnlyConnection connection = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command = connection.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
                                        if (command.IDbCommand.Parameters.Count == 0)
                                        {
                                            command.IDbCommand.Parameters.Add(new SqlParameter("@IDBANKE", SqlDbType.Int));
                                        }
                                        command.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDBANKE"]));
                                        IDataReader reader = command.FetchData();
                                        if (!command.HasMoreRows)
                                        {
                                            reader.Close();
                                            objArray = new object[] { connection };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "BANKE" }));
                                        }
                                        objArray = new object[] { reader, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        objArray = new object[] { reader, 1 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        objArray = new object[] { reader, 2 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        objArray = new object[] { reader, 3 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        objArray = new object[] { reader, 4 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader.Close();
                                        objArray = new object[] { connection };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["NAZIVBANKE1"] = "";
                                        row["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                        row["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                        row["VBDIBANKE"] = "";
                                        row["ZRNBANKE"] = "";
                                    }
                                    if (!row.IsIDBENEFICIRANINull())
                                    {
                                        ReadOnlyConnection connection2 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command2 = connection2.GetCommand("SELECT [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
                                        if (command2.IDbCommand.Parameters.Count == 0)
                                        {
                                            command2.IDbCommand.Parameters.Add(new SqlParameter("@IDBENEFICIRANI", SqlDbType.NVarChar, 1));
                                        }
                                        command2.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDBENEFICIRANI"]));
                                        IDataReader reader2 = command2.FetchData();
                                        if (!command2.HasMoreRows)
                                        {
                                            reader2.Close();
                                            objArray = new object[] { connection2 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "BENEFICIRANI" }));
                                        }
                                        objArray = new object[] { reader2, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        objArray = new object[] { reader2, 1 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetInt16", objArray, null, null, flagArray));
                                        reader2.Close();
                                        objArray = new object[] { connection2 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["NAZIVBENEFICIRANI"] = "";
                                        row["BROJPRIZNATIHMJESECI"] = 0;
                                    }
                                    if (!row.IsIDORGDIONull())
                                    {
                                        ReadOnlyConnection connection5 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command5 = connection5.GetCommand("SELECT [ORGANIZACIJSKIDIO] FROM [ORGDIO] (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                                        if (command5.IDbCommand.Parameters.Count == 0)
                                        {
                                            command5.IDbCommand.Parameters.Add(new SqlParameter("@IDORGDIO", SqlDbType.Int));
                                        }
                                        command5.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDORGDIO"]));
                                        IDataReader reader5 = command5.FetchData();
                                        if (!command5.HasMoreRows)
                                        {
                                            reader5.Close();
                                            objArray = new object[] { connection5 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection5 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ORGDIO" }));
                                        }
                                        objArray = new object[] { reader5, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader5 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader5.Close();
                                        objArray = new object[] { connection5 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection5 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["ORGANIZACIJSKIDIO"] = "";
                                    }
                                    if (!row.IsIDTITULANull())
                                    {
                                        ReadOnlyConnection connection12 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command12 = connection12.GetCommand("SELECT [NAZIVTITULA] FROM [TITULA] (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                                        if (command12.IDbCommand.Parameters.Count == 0)
                                        {
                                            command12.IDbCommand.Parameters.Add(new SqlParameter("@IDTITULA", SqlDbType.Int));
                                        }
                                        command12.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDTITULA"]));
                                        IDataReader reader12 = command12.FetchData();
                                        if (!command12.HasMoreRows)
                                        {
                                            reader12.Close();
                                            objArray = new object[] { connection12 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection12 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "TITULA" }));
                                        }
                                        objArray = new object[] { reader12, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader12 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader12.Close();
                                        objArray = new object[] { connection12 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection12 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["NAZIVTITULA"] = "";
                                    }
                                    if (!row.IsIDRADNOMJESTONull())
                                    {
                                        ReadOnlyConnection connection7 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command7 = connection7.GetCommand("SELECT [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                                        if (command7.IDbCommand.Parameters.Count == 0)
                                        {
                                            command7.IDbCommand.Parameters.Add(new SqlParameter("@IDRADNOMJESTO", SqlDbType.Int));
                                        }
                                        command7.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDRADNOMJESTO"]));
                                        IDataReader reader7 = command7.FetchData();
                                        if (!command7.HasMoreRows)
                                        {
                                            reader7.Close();
                                            objArray = new object[] { connection7 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection7 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "RADNOMJESTO" }));
                                        }
                                        objArray = new object[] { reader7, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader7 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader7.Close();
                                        objArray = new object[] { connection7 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection7 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["NAZIVRADNOMJESTO"] = "";
                                    }
                                    if (!row.IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull())
                                    {
                                        ReadOnlyConnection connection9 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command9 = connection9.GetCommand("SELECT [NAZIVSTRUCNASPREMA] FROM [STRUCNASPREMA] (NOLOCK) WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
                                        if (command9.IDbCommand.Parameters.Count == 0)
                                        {
                                            command9.IDbCommand.Parameters.Add(new SqlParameter("@IDSTRUCNASPREMA", SqlDbType.Int));
                                        }
                                        command9.SetParameter(0, RuntimeHelpers.GetObjectValue(row["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                                        IDataReader reader9 = command9.FetchData();
                                        if (!command9.HasMoreRows)
                                        {
                                            reader9.Close();
                                            objArray = new object[] { connection9 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection9 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "STRUCNASPREMA" }));
                                        }
                                        objArray = new object[] { reader9, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader9 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader9.Close();
                                        objArray = new object[] { connection9 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection9 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = "";
                                    }
                                    if (!row.IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull())
                                    {
                                        ReadOnlyConnection connection10 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command10 = connection10.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] (NOLOCK) WHERE [IDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                                        if (command10.IDbCommand.Parameters.Count == 0)
                                        {
                                            command10.IDbCommand.Parameters.Add(new SqlParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", SqlDbType.Int));
                                        }
                                        command10.SetParameter(0, RuntimeHelpers.GetObjectValue(row["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                                        IDataReader reader10 = command10.FetchData();
                                        if (!command10.HasMoreRows)
                                        {
                                            reader10.Close();
                                            objArray = new object[] { connection10 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection10 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "STRUCNASPREMA" }));
                                        }
                                        objArray = new object[] { reader10, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader10 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader10.Close();
                                        objArray = new object[] { connection10 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection10 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    }
                                    if (!row.IsIDSTRUKANull())
                                    {
                                        ReadOnlyConnection connection11 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command11 = connection11.GetCommand("SELECT [NAZIVSTRUKA] FROM [STRUKA] (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                                        if (command11.IDbCommand.Parameters.Count == 0)
                                        {
                                            command11.IDbCommand.Parameters.Add(new SqlParameter("@IDSTRUKA", SqlDbType.Int));
                                        }
                                        command11.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDSTRUKA"]));
                                        IDataReader reader11 = command11.FetchData();
                                        if (!command11.HasMoreRows)
                                        {
                                            reader11.Close();
                                            objArray = new object[] { connection11 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection11 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "STRUKA" }));
                                        }
                                        objArray = new object[] { reader11, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader11 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader11.Close();
                                        objArray = new object[] { connection11 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection11 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["NAZIVSTRUKA"] = "";
                                    }
                                    if (!row.IsOPCINARADAIDOPCINENull())
                                    {
                                        ReadOnlyConnection connection3 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command3 = connection3.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, [PRIREZ] AS OPCINARADAPRIREZ FROM [OPCINA] (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
                                        if (command3.IDbCommand.Parameters.Count == 0)
                                        {
                                            command3.IDbCommand.Parameters.Add(new SqlParameter("@OPCINARADAIDOPCINE", SqlDbType.NVarChar, 4));
                                        }
                                        command3.SetParameter(0, RuntimeHelpers.GetObjectValue(row["OPCINARADAIDOPCINE"]));
                                        IDataReader reader3 = command3.FetchData();
                                        if (!command3.HasMoreRows)
                                        {
                                            reader3.Close();
                                            objArray = new object[] { connection3 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OPCINA" }));
                                        }
                                        objArray = new object[] { reader3, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        objArray = new object[] { reader3, 1 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", objArray, null, null, flagArray));
                                        reader3.Close();
                                        objArray = new object[] { connection3 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                        row["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    }
                                    if (!row.IsOPCINASTANOVANJAIDOPCINENull())
                                    {
                                        ReadOnlyConnection connection4 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command4 = connection4.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ FROM [OPCINA] (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
                                        if (command4.IDbCommand.Parameters.Count == 0)
                                        {
                                            command4.IDbCommand.Parameters.Add(new SqlParameter("@OPCINASTANOVANJAIDOPCINE", SqlDbType.NVarChar, 4));
                                        }
                                        command4.SetParameter(0, RuntimeHelpers.GetObjectValue(row["OPCINASTANOVANJAIDOPCINE"]));
                                        IDataReader reader4 = command4.FetchData();
                                        if (!command4.HasMoreRows)
                                        {
                                            reader4.Close();
                                            objArray = new object[] { connection4 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection4 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OPCINA" }));
                                        }
                                        objArray = new object[] { reader4, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader4 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        objArray = new object[] { reader4, 1 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader4 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetDecimal", objArray, null, null, flagArray));
                                        reader4.Close();
                                        objArray = new object[] { connection4 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection4 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                        row["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    }
                                    if (!row.IsRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull())
                                    {
                                        ReadOnlyConnection connection8 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                        ReadOnlyCommand command8 = connection8.GetCommand("SELECT [NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA FROM [SKUPPOREZAIDOPRINOSA] (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
                                        if (command8.IDbCommand.Parameters.Count == 0)
                                        {
                                            command8.IDbCommand.Parameters.Add(new SqlParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", SqlDbType.Int));
                                        }
                                        command8.SetParameter(0, RuntimeHelpers.GetObjectValue(row["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
                                        IDataReader reader8 = command8.FetchData();
                                        if (!command8.HasMoreRows)
                                        {
                                            reader8.Close();
                                            objArray = new object[] { connection8 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection8 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "SKUPPOREZAIDOPRINOSA" }));
                                        }
                                        objArray = new object[] { reader8, 0 };
                                        flagArray = new bool[] { true, false };
                                        if (flagArray[0])
                                        {
                                            reader8 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                        }
                                        row["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                        reader8.Close();
                                        objArray = new object[] { connection8 };
                                        flagArray = new bool[] { true };
                                        NewLateBinding.LateCall(instance, null, "CloseConnection", objArray, null, null, flagArray, true);
                                        if (flagArray[0])
                                        {
                                            connection8 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                        }
                                    }
                                    else
                                    {
                                        row["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                                    }
                                    flag2 = true;
                                    this.BindingContext[this.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
                                }
                                catch (System.Exception exception1)
                                {
                                    throw exception1;
                                    
                                    
                                    
                                }
                                if (flag2)
                                {
                                    this.BindingContext[this.ObracunDataSet1, "OBRACUNradnici"].Position = this.BindingContext[this.ObracunDataSet1, "OBRACUNradnici"].Count;
                                    DataRowView view = (DataRowView) this.BindingContext[this.ObracunDataSet1, "OBRACUNradnici"].Current;
                                    if (radnika.Bruto)
                                    {
                                        IEnumerator enumerator2 = null;
                                        DataView view5 = new DataView {
                                            Table = this.RadnikDataSet1.RADNIKBruto
                                        };
                                        DataView view2 = view5;
                                        view2.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik=", view["idradnik"]));
                                        try
                                        {
                                            enumerator2 = view2.GetEnumerator();
                                            while (enumerator2.MoveNext())
                                            {
                                                DataRowView view3 = (DataRowView) enumerator2.Current;
                                                DataRow row4 = view3.Row;
                                                OBRACUNDataSet.ObracunElementiRow row5 = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                                                row5["idelement"] = RuntimeHelpers.GetObjectValue(row4["brutoelementidelement"]);
                                                row5["elementrazdobljeod"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna), 1);
                                                row5["elementrazdobljedo"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna) + 1, 1).AddDays(-1.0);
                                                row5["obrpostotak"] = RuntimeHelpers.GetObjectValue(row4["brutoPOSTOTAK"]);
                                                row5["obrsati"] = RuntimeHelpers.GetObjectValue(row4["brutosati"]);
                                                row5["obrsatnica"] = RuntimeHelpers.GetObjectValue(row4["brutosatnica"]);
                                                row5["obriznos"] = RuntimeHelpers.GetObjectValue(row4["brutoiznos"]);
                                                row5["idobracun"] = this.sifraobracuna;
                                                row5["idradnik"] = RuntimeHelpers.GetObjectValue(view["idradnik"]);
                                                this.ObracunDataSet1.ObracunElementi.Rows.Add(row5);
                                                object obj4 = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                                                ReadOnlyConnection connection13 = (ReadOnlyConnection) NewLateBinding.LateGet(obj4, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                                ReadOnlyCommand command13 = connection13.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
                                                if (command13.IDbCommand.Parameters.Count == 0)
                                                {
                                                    command13.IDbCommand.Parameters.Add(new SqlParameter("@IDELEMENT", SqlDbType.Int));
                                                }
                                                command13.SetParameter(0, RuntimeHelpers.GetObjectValue(row4["brutoelementidelement"]));
                                                IDataReader reader13 = command13.FetchData();
                                                if (!command13.HasMoreRows)
                                                {
                                                    reader13.Close();
                                                    objArray = new object[] { connection13 };
                                                    flagArray = new bool[] { true };
                                                    NewLateBinding.LateCall(obj4, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                    if (flagArray[0])
                                                    {
                                                        connection13 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                    }
                                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ELEMENT" }));
                                                }
                                                objArray = new object[] { reader13, 0 };
                                                flagArray = new bool[] { true, false };
                                                if (flagArray[0])
                                                {
                                                    reader13 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                                }
                                                row5["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj4, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                                objArray = new object[] { reader13, 1 };
                                                flagArray = new bool[] { true, false };
                                                if (flagArray[0])
                                                {
                                                    reader13 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                                }
                                                row5["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj4, null, "Db", new object[0], null, null, null), null, "GetInt16", objArray, null, null, flagArray));
                                                objArray = new object[] { reader13, 2 };
                                                flagArray = new bool[] { true, false };
                                                if (flagArray[0])
                                                {
                                                    reader13 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                                }
                                                row5["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj4, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                                reader13.Close();
                                                objArray = new object[] { connection13 };
                                                flagArray = new bool[] { true };
                                                NewLateBinding.LateCall(obj4, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                if (flagArray[0])
                                                {
                                                    connection13 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                }
                                                if (!row5.IsIDVRSTAELEMENTANull())
                                                {
                                                    ReadOnlyConnection connection15 = (ReadOnlyConnection) NewLateBinding.LateGet(obj4, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                                    ReadOnlyCommand command15 = connection15.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                                                    if (command15.IDbCommand.Parameters.Count == 0)
                                                    {
                                                        command15.IDbCommand.Parameters.Add(new SqlParameter("@IDVRSTAELEMENTA", SqlDbType.Int));
                                                    }
                                                    command15.SetParameter(0, RuntimeHelpers.GetObjectValue(row5["IDVRSTAELEMENTA"]));
                                                    IDataReader reader15 = command15.FetchData();
                                                    if (!command15.HasMoreRows)
                                                    {
                                                        reader15.Close();
                                                        objArray = new object[] { connection15 };
                                                        flagArray = new bool[] { true };
                                                        NewLateBinding.LateCall(obj4, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                        if (flagArray[0])
                                                        {
                                                            connection15 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                        }
                                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "VRSTAELEMENT" }));
                                                    }
                                                    objArray = new object[] { reader15, 0 };
                                                    flagArray = new bool[] { true, false };
                                                    if (flagArray[0])
                                                    {
                                                        reader15 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                                    }
                                                    row5["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj4, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                                    reader15.Close();
                                                    objArray = new object[] { connection15 };
                                                    flagArray = new bool[] { true };
                                                    NewLateBinding.LateCall(obj4, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                    if (flagArray[0])
                                                    {
                                                        connection15 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                    }
                                                }
                                                else
                                                {
                                                    row5["NAZIVVRSTAELEMENT"] = "";
                                                }
                                                if (!row5.IsIDOSNOVAOSIGURANJANull())
                                                {
                                                    ReadOnlyConnection connection14 = (ReadOnlyConnection) NewLateBinding.LateGet(obj4, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                                    ReadOnlyCommand command14 = connection14.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] FROM [OSNOVAOSIGURANJA] (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                                                    if (command14.IDbCommand.Parameters.Count == 0)
                                                    {
                                                        command14.IDbCommand.Parameters.Add(new SqlParameter("@IDOSNOVAOSIGURANJA", SqlDbType.NVarChar, 2));
                                                    }
                                                    command14.SetParameter(0, RuntimeHelpers.GetObjectValue(row5["IDOSNOVAOSIGURANJA"]));
                                                    IDataReader reader14 = command14.FetchData();
                                                    if (!command14.HasMoreRows)
                                                    {
                                                        reader14.Close();
                                                        objArray = new object[] { connection14 };
                                                        flagArray = new bool[] { true };
                                                        NewLateBinding.LateCall(obj4, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                        if (flagArray[0])
                                                        {
                                                            connection14 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                        }
                                                        throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OSNOVAOSIGURANJA" }));
                                                    }
                                                    objArray = new object[] { reader14, 0 };
                                                    flagArray = new bool[] { true, false };
                                                    if (flagArray[0])
                                                    {
                                                        reader14 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                                    }
                                                    row5["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj4, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                                    reader14.Close();
                                                    objArray = new object[] { connection14 };
                                                    flagArray = new bool[] { true };
                                                    NewLateBinding.LateCall(obj4, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                    if (flagArray[0])
                                                    {
                                                        connection14 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                    }
                                                }
                                                else
                                                {
                                                    row5["NAZIVOSNOVAOSIGURANJA"] = "";
                                                }
                                                this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
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
                                    if (radnika.Neto)
                                    {
                                        DataView view4 = new DataView {
                                            Table = this.RadnikDataSet1.RADNIKNeto,
                                            RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik=", view["idradnik"]))
                                        };
                                        int num6 = view4.Count - 1;
                                        for (int j = 0; j <= num6; j++)
                                        {
                                            DataRow row7 = view4[j].Row;
                                            OBRACUNDataSet.ObracunElementiRow row8 = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                                            row8["idelement"] = RuntimeHelpers.GetObjectValue(row7["netoelementidelement"]);
                                            row8["elementrazdobljeod"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna), 1);
                                            row8["elementrazdobljedo"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna) + 1, 1).AddDays(-1.0);
                                            row8["obrpostotak"] = RuntimeHelpers.GetObjectValue(row7["netoPOSTOTAK"]);
                                            row8["obrsati"] = RuntimeHelpers.GetObjectValue(row7["netosati"]);
                                            row8["obrsatnica"] = RuntimeHelpers.GetObjectValue(row7["netosatnica"]);
                                            row8["obriznos"] = RuntimeHelpers.GetObjectValue(row7["netoiznos"]);
                                            row8["idobracun"] = this.sifraobracuna;
                                            row8["idradnik"] = RuntimeHelpers.GetObjectValue(view["idradnik"]);
                                            this.ObracunDataSet1.ObracunElementi.Rows.Add(row8);
                                            object obj9 = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                                            ReadOnlyConnection connection16 = (ReadOnlyConnection) NewLateBinding.LateGet(obj9, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                            ReadOnlyCommand command16 = connection16.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
                                            if (command16.IDbCommand.Parameters.Count == 0)
                                            {
                                                command16.IDbCommand.Parameters.Add(new SqlParameter("@IDELEMENT", SqlDbType.Int));
                                            }
                                            command16.SetParameter(0, RuntimeHelpers.GetObjectValue(row7["netoelementidelement"]));
                                            IDataReader reader16 = command16.FetchData();
                                            if (!command16.HasMoreRows)
                                            {
                                                reader16.Close();
                                                objArray = new object[] { connection16 };
                                                flagArray = new bool[] { true };
                                                NewLateBinding.LateCall(obj9, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                if (flagArray[0])
                                                {
                                                    connection16 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                }
                                                throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ELEMENT" }));
                                            }
                                            objArray = new object[] { reader16, 0 };
                                            flagArray = new bool[] { true, false };
                                            if (flagArray[0])
                                            {
                                                reader16 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                            }
                                            row8["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj9, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                            objArray = new object[] { reader16, 1 };
                                            flagArray = new bool[] { true, false };
                                            if (flagArray[0])
                                            {
                                                reader16 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                            }
                                            row8["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj9, null, "Db", new object[0], null, null, null), null, "GetInt16", objArray, null, null, flagArray));
                                            objArray = new object[] { reader16, 2 };
                                            flagArray = new bool[] { true, false };
                                            if (flagArray[0])
                                            {
                                                reader16 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                            }
                                            row8["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj9, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                            reader16.Close();
                                            objArray = new object[] { connection16 };
                                            flagArray = new bool[] { true };
                                            NewLateBinding.LateCall(obj9, null, "CloseConnection", objArray, null, null, flagArray, true);
                                            if (flagArray[0])
                                            {
                                                connection16 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                            }
                                            if (!row8.IsIDVRSTAELEMENTANull())
                                            {
                                                ReadOnlyConnection connection18 = (ReadOnlyConnection) NewLateBinding.LateGet(obj9, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                                ReadOnlyCommand command18 = connection18.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                                                if (command18.IDbCommand.Parameters.Count == 0)
                                                {
                                                    command18.IDbCommand.Parameters.Add(new SqlParameter("@IDVRSTAELEMENTA", SqlDbType.Int));
                                                }
                                                command18.SetParameter(0, RuntimeHelpers.GetObjectValue(row8["IDVRSTAELEMENTA"]));
                                                IDataReader reader18 = command18.FetchData();
                                                if (!command18.HasMoreRows)
                                                {
                                                    reader18.Close();
                                                    objArray = new object[] { connection18 };
                                                    flagArray = new bool[] { true };
                                                    NewLateBinding.LateCall(obj9, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                    if (flagArray[0])
                                                    {
                                                        connection18 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                    }
                                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "VRSTAELEMENT" }));
                                                }
                                                objArray = new object[] { reader18, 0 };
                                                flagArray = new bool[] { true, false };
                                                if (flagArray[0])
                                                {
                                                    reader18 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                                }
                                                row8["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj9, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                                reader18.Close();
                                                objArray = new object[] { connection18 };
                                                flagArray = new bool[] { true };
                                                NewLateBinding.LateCall(obj9, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                if (flagArray[0])
                                                {
                                                    connection18 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                }
                                            }
                                            else
                                            {
                                                row8["NAZIVVRSTAELEMENT"] = "";
                                            }
                                            if (!row8.IsIDOSNOVAOSIGURANJANull())
                                            {
                                                ReadOnlyConnection connection17 = (ReadOnlyConnection) NewLateBinding.LateGet(obj9, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                                ReadOnlyCommand command17 = connection17.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] FROM [OSNOVAOSIGURANJA] (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                                                if (command17.IDbCommand.Parameters.Count == 0)
                                                {
                                                    command17.IDbCommand.Parameters.Add(new SqlParameter("@IDOSNOVAOSIGURANJA", SqlDbType.NVarChar, 2));
                                                }
                                                command17.SetParameter(0, RuntimeHelpers.GetObjectValue(row8["IDOSNOVAOSIGURANJA"]));
                                                IDataReader reader17 = command17.FetchData();
                                                if (!command17.HasMoreRows)
                                                {
                                                    reader17.Close();
                                                    objArray = new object[] { connection17 };
                                                    flagArray = new bool[] { true };
                                                    NewLateBinding.LateCall(obj9, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                    if (flagArray[0])
                                                    {
                                                        connection17 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                    }
                                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OSNOVAOSIGURANJA" }));
                                                }
                                                objArray = new object[] { reader17, 0 };
                                                flagArray = new bool[] { true, false };
                                                if (flagArray[0])
                                                {
                                                    reader17 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(IDataReader));
                                                }
                                                row8["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj9, null, "Db", new object[0], null, null, null), null, "GetString", objArray, null, null, flagArray));
                                                reader17.Close();
                                                objArray = new object[] { connection17 };
                                                flagArray = new bool[] { true };
                                                NewLateBinding.LateCall(obj9, null, "CloseConnection", objArray, null, null, flagArray, true);
                                                if (flagArray[0])
                                                {
                                                    connection17 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(ReadOnlyConnection));
                                                }
                                            }
                                            else
                                            {
                                                row8["NAZIVOSNOVAOSIGURANJA"] = "";
                                            }
                                            this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
                                       
                                        }
                                    }
                                }
                            }
                        }
                        this.blokirajPromjenuPozicije = false;
                        this.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void PerformingActions(object sender, ProgressChangedEventArgs e)
        {
            this.frmProg.progressBar1.Value = e.ProgressPercentage;
            this.frmProg.lblDescription.Text = "Sačekajte trenutak!";
        }

        /// <summary>
        /// Učitavanje podataka u UltraGrid2
        /// </summary>
        /// <param name="drvObracun"></param>
        /// <param name="threadoperacija"></param>
        private void Platna_Ekran(DataRowView drvObracun, bool threadoperacija = false)
        {
            DataRow current;
            decimal num11 = 0;
            decimal num19 = 0;
            decimal num20 = 0;
            decimal num22 = 0;
            decimal num25 = 0;
            decimal num26 = 0;
            decimal num27 = 0;
            object obj3 = null;
            object obj4 = null;
            object obj5 = null;
            object obj6 = null;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            IEnumerator enumerator3 = null;
            IEnumerator enumerator4 = null;
            IEnumerator enumerator5 = null;
            IEnumerator enumerator6 = null;
            IEnumerator enumerator7 = null;
            IEnumerator enumerator8 = null;
            IEnumerator enumerator9 = null;
            DataRow row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            double satnica = Conversions.ToDouble(obj6);
            decimal gstaza = Conversions.ToDecimal(obj4);
            decimal mstaza = Conversions.ToDecimal(obj5);
            decimal dstaza = Conversions.ToDecimal(obj3);

            //#OBR_3
            DataRow drView = drvObracun.Row;
            this.IzracunSatnice(ref drView, ref satnica, ref gstaza, ref mstaza, ref dstaza);

            obj3 = dstaza;
            obj5 = mstaza;
            obj4 = gstaza;
            obj6 = satnica;
            this.DatasetRekapitulacija1.dtRekap.Clear();
            row["opis"] = this.AktivanZaposlenikPunoIme();
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Staž;
            row["iznos"] = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, "g "), obj5), "m "), obj3), "d");
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = "IzracunSatnice";
            row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(obj6));
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            decimal num23 = this.UkupniBruto(RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]));
            decimal num24 = this.UkupniNeto(RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]));
            decimal num14 = num23;
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = "Bruto primanja";
            row["iznos"] = string.Format("{0:#,##0.00}", num23);
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            try
            {
                enumerator = this.ObracunDataSet1.ObracunElementi.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false), Operators.CompareObjectEqual(current["idvrstaelementa"], 2, false))))
                    {
                        row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                        row["opis"] = Operators.ConcatenateObject(" > ", current["nazivelement"]);
                        row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["obriznos"]));
                        row["sifraelementa"] = RuntimeHelpers.GetObjectValue(current["idelement"]);
                        row["vrstaelementa"] = RuntimeHelpers.GetObjectValue(current["idvrstaelementa"]);
                        row["brojsati"] = string.Format("{0:#,##0.00}", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(current["obrsati"])));
                        row["od"] = RuntimeHelpers.GetObjectValue(current["elementrazdobljeod"]);
                        row["do"] = RuntimeHelpers.GetObjectValue(current["elementrazdobljedo"]);
                        this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                        num22 = Conversions.ToDecimal(Operators.AddObject(num22, row["iznos"]));
                        if (Operators.ConditionalCompareObjectEqual(current["zbrajasateufondsati"], true, false))
                        {
                            num27 = Conversions.ToDecimal(Operators.AddObject(num27, row["brojsati"]));
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
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_bruto_primanja;
            row["iznos"] = string.Format("{0:#,##0.00}", num22);
            row["brojsati"] = string.Format("{0:#,##0.00}", num27);
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Doprinosi_iz_plaće;
            row["iznos"] = "";
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            decimal left = num23;
            try
            {
                enumerator2 = this.ObracunDataSet1.ObracunDoprinosi.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    current = (DataRow) enumerator2.Current;
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false), Operators.CompareObjectEqual(current["idvrstadoprinos"], 2, false))))
                    {
                        decimal num17 = 0;
                        row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                        row["opis"] = Operators.ConcatenateObject(" > ", current["nazivdoprinos"]);
                        row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["obracunatidoprinos"]));
                        this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                        left = Conversions.ToDecimal(Operators.SubtractObject(left, current["obracunatidoprinos"]));
                        num17 = Conversions.ToDecimal(Operators.AddObject(num17, current["obracunatidoprinos"]));
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
            decimal num10 = new decimal();
            DataView view = new DataView {
                Table = this.ObracunDataSet1.ObracunOlaksice
            };
            try
            {
                enumerator3 = this.GrupeolaksicaDataSet1.GRUPEOLAKSICA.Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    DataRow row3 = (DataRow) enumerator3.Current;
                    decimal num8 = DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("Max(MAXIMALNIIZNOSGRUPE)", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"]), " and IDGRUPEOLAKSICA= "), row3["idgrupeolaksica"])))));
                    decimal num30 = DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(obracunataolaksica)", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"]), " and IDGRUPEOLAKSICA= "), row3["idgrupeolaksica"])))));
                    decimal num28 = this.UkupnoOlaksicaUMjesecu(Conversions.ToInteger(drvObracun["idradnik"]), this.sifraobracuna, Conversions.ToInteger(row3["idgrupeolaksica"]));
                    decimal num16 = decimal.Subtract(num30, num28);
                    if (decimal.Compare(num16, decimal.Zero) <= 0)
                    {
                        num10 = new decimal();
                    }
                    else
                    {
                        num10 = num16;
                        if (decimal.Compare(num10, num8) > 0)
                        {
                            num10 = num8;
                        }
                        else
                        {
                            num10 = num30;
                        }
                    }
                    num26 = decimal.Add(num26, num30);
                    num11 = decimal.Add(num11, num10);
                }
            }
            finally
            {
                if (enumerator3 is IDisposable)
                {
                    (enumerator3 as IDisposable).Dispose();
                }
            }
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_porezno_priznate_olakšice;
            row["iznos"] = string.Format("{0:#,##0.00}", num11);
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            left = decimal.Subtract(left, num11);
            decimal num18 = new decimal();
            num18 = Conversions.ToDecimal(this.ObracunDataSet1.ObracunRadnici.Compute("Sum(ISKORISTENOOO)", Conversions.ToString(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"]))));
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_osobni_odbitak;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", num18);
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Porezna_osnovica;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", decimal.Subtract(left, num18));
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            try
            {
                enumerator4 = this.ObracunDataSet1.ObracunPorezi.GetEnumerator();
                while (enumerator4.MoveNext())
                {
                    current = (DataRow) enumerator4.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false))
                    {
                        row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                        row["opis"] = Operators.ConcatenateObject(" > ", current["nazivporez"]);
                        row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["obracunatiporez"]));
                        this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                        num20 = Conversions.ToDecimal(Operators.AddObject(num20, current["obracunatiporez"]));
                    }
                }
            }
            finally
            {
                if (enumerator4 is IDisposable)
                {
                    (enumerator4 as IDisposable).Dispose();
                }
            }
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_porez;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", num20);
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            decimal num21 = Conversions.ToDecimal(this.ObracunDataSet1.ObracunRadnici.Compute("Sum(obracunatiprirez)", Conversions.ToString(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"]))));
            decimal num6 = Conversions.ToDecimal(this.ObracunDataSet1.ObracunRadnici.Compute("Sum(korekcijaprireza)", Conversions.ToString(Operators.ConcatenateObject("idradnik=  ", drvObracun["idradnik"]))));
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Prirez;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", num21);
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Korekcija_prireza;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", num6);
            }
            if (decimal.Compare(num6, decimal.Zero) != 0)
            {
                this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            }
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_porez_i_prirez;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", decimal.Add(decimal.Add(num21, num20), num6));
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            decimal num9 = this.UkupniNeto(RuntimeHelpers.GetObjectValue(drvObracun["idradnik"]));
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Neto_plaća;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", decimal.Add(decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num21), num20), num6), num11));
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            try
            {
                enumerator5 = this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunKrizni.Rows.GetEnumerator();
                while (enumerator5.MoveNext())
                {
                    current = (DataRow) enumerator5.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false))
                    {
                        num19 = Conversions.ToDecimal(Operators.AddObject(num19, current["porezkrizni"]));
                    }
                }
            }
            finally
            {
                if (enumerator5 is IDisposable)
                {
                    (enumerator5 as IDisposable).Dispose();
                }
            }
            if (decimal.Compare(num19, decimal.Zero) > 0)
            {
                row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Pos_por_na_net_plaće;
                row["iznos"] = string.Format("{0:#,##0.00}", num19);
                this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Neto_plaća_umanjena_za_pos_por_;
                row["iznos"] = string.Format("{0:#,##0.00}", decimal.Subtract(decimal.Add(decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num21), num20), num6), num11), num19));
                this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            }
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = "Neto naknade";
            row["iznos"] = string.Format("{0:#,##0.00}", num9);
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            try
            {
                enumerator6 = this.ObracunDataSet1.ObracunElementi.Rows.GetEnumerator();
                while (enumerator6.MoveNext())
                {
                    current = (DataRow) enumerator6.Current;
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false), Operators.CompareObjectEqual(current["idvrstaelementa"], 1, false))))
                    {
                        row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                        row["opis"] = Operators.ConcatenateObject(" > ", current["nazivelement"]);
                        row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["obriznos"]));
                        row["sifraelementa"] = RuntimeHelpers.GetObjectValue(current["idelement"]);
                        row["vrstaelementa"] = RuntimeHelpers.GetObjectValue(current["idvrstaelementa"]);
                        row["brojsati"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["obrsati"]));
                        row["od"] = RuntimeHelpers.GetObjectValue(current["elementrazdobljeod"]);
                        row["do"] = RuntimeHelpers.GetObjectValue(current["elementrazdobljedo"]);
                        this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                    }
                }
            }
            finally
            {
                if (enumerator6 is IDisposable)
                {
                    (enumerator6 as IDisposable).Dispose();
                }
            }
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Neto_primanja;
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", decimal.Add(decimal.Add(decimal.Subtract(decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num21), num20), num6), num19), num9), num11));
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Obustave_postotne_i_fiksne;
            row["iznos"] = "";
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            try
            {
                enumerator7 = this.ObracunDataSet1.OBRACUNObustave.GetEnumerator();
                while (enumerator7.MoveNext())
                {
                    current = (DataRow) enumerator7.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false))
                    {
                        row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                        row["opis"] = Operators.ConcatenateObject(" > ", current["nazivobustava"]);
                        row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["obracunataobustavaukunama"]));
                        this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                        num25 = Conversions.ToDecimal(Operators.AddObject(num25, current["obracunataobustavaukunama"]));
                    }
                }
            }
            finally
            {
                if (enumerator7 is IDisposable)
                {
                    (enumerator7 as IDisposable).Dispose();
                }
            }
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Obustave_kreditne;
            row["iznos"] = "";
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            try
            {
                enumerator8 = this.ObracunDataSet1.OBRACUNKrediti.GetEnumerator();
                while (enumerator8.MoveNext())
                {
                    current = (DataRow) enumerator8.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false))
                    {
                        row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                        row["opis"] = Operators.ConcatenateObject(" > ", current["nazivkreditor"]);
                        row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["obracunatikunskiiznos"]));
                        this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                        num25 = Conversions.ToDecimal(Operators.AddObject(num25, current["obracunatikunskiiznos"]));
                    }
                }
            }
            finally
            {
                if (enumerator8 is IDisposable)
                {
                    (enumerator8 as IDisposable).Dispose();
                }
            }
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_obustave;
            row["iznos"] = string.Format("{0:#,##0.00}", num25);
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_olakšice;
            row["iznos"] = string.Format("{0:#,##0.00}", num11);
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            row = this.DatasetRekapitulacija1.dtRekap.NewRow();
            row["opis"] = My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_ZA_ISPLATU;
            object obj2 = 0;
            obj2 = decimal.Subtract(num26, num11);
            if (Operators.ConditionalCompareObjectGreater(obj2, 0, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", Operators.SubtractObject(decimal.Subtract(decimal.Add(decimal.Add(decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num21), num20), num6), num19), num9), num25), obj2));
            }
            else
            {
                row["iznos"] = string.Format("{0:#,##0.00}", decimal.Subtract(decimal.Add(decimal.Subtract(decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num21), num20), num6), num19), num9), num25));
            }
            if (Operators.ConditionalCompareObjectEqual(drvObracun["IDIPIDENT"], 11, false))
            {
                row["iznos"] = string.Format("{0:#,##0.00}", 0);
            }
            this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
            try
            {
                enumerator9 = this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece.GetEnumerator();
                while (enumerator9.MoveNext())
                {
                    current = (DataRow) enumerator9.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["idradnik"], drvObracun["idradnik"], false))
                    {
                        row = this.DatasetRekapitulacija1.dtRekap.NewRow();
                        row["opis"] = Operators.ConcatenateObject(" > Isplata zašt.iznosa na: ", current["PRIMATELJIZUZECE1"]);
                        row["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["IZNOSIZUZECA"]));
                        this.DatasetRekapitulacija1.dtRekap.Rows.Add(row);
                    }
                }
            }
            finally
            {
                if (enumerator9 is IDisposable)
                {
                    (enumerator9 as IDisposable).Dispose();
                }
            }
        }

        private void PocistiObracunatoNaRadniku(string sifraobr, int sifraradnika)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            connection.Open();
            DataView defaultView = this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunKrizni.DefaultView;
            defaultView.RowFilter = "idradnik= " + Conversions.ToString(sifraradnika);
            for (int i = defaultView.Count - 1; i >= 0; i += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[i].Row);
            }
            defaultView = this.ObracunDataSet1.OBRACUNKrediti.DefaultView;
            defaultView.RowFilter = "idradnik= " + Conversions.ToString(sifraradnika);
            for (int j = defaultView.Count - 1; j >= 0; j += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[j].Row);
            }
            defaultView = this.ObracunDataSet1.OBRACUNObustave.DefaultView;
            defaultView.RowFilter = "idradnik= " + Conversions.ToString(sifraradnika);
            for (int k = defaultView.Count - 1; k >= 0; k += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[k].Row);
            }
            defaultView = this.ObracunDataSet1.ObracunOlaksice.DefaultView;
            defaultView.RowFilter = "idradnik= " + Conversions.ToString(sifraradnika);
            for (int m = defaultView.Count - 1; m >= 0; m += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[m].Row);
            }
            defaultView = this.ObracunDataSet1.ObracunPorezi.DefaultView;
            defaultView.RowFilter = "idradnik= " + Conversions.ToString(sifraradnika);
            for (int n = defaultView.Count - 1; n >= 0; n += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[n].Row);
            }
            defaultView = this.ObracunDataSet1.ObracunDoprinosi.DefaultView;
            defaultView.RowFilter = "idradnik= " + Conversions.ToString(sifraradnika);
            for (int num6 = defaultView.Count - 1; num6 >= 0; num6 += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[num6].Row);
            }
            defaultView = this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece.DefaultView;
            defaultView.RowFilter = "idradnik= " + Conversions.ToString(sifraradnika);
            for (int num7 = defaultView.Count - 1; num7 >= 0; num7 += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[num7].Row);
            }
            SqlParameter[] parameterArray = new SqlParameter[2];
            parameterArray[0] = new SqlParameter("@IDOBRACUN", SqlDbType.VarChar, 11);
            parameterArray[0].Value = this.sifraobracuna;
            parameterArray[1] = new SqlParameter("@IDradnik", SqlDbType.Int);
            parameterArray[1].Value = sifraradnika;
            DataSet set = new DataSet();
            SqlCommand command2 = new SqlCommand {
                CommandType = CommandType.StoredProcedure,
                CommandText = "S_PLACA_POCISTI_PODATKE_ZAPOSLENIKA"
            };
            command2.Parameters.Add(parameterArray[0]);
            command2.Parameters.Add(parameterArray[1]);
            command2.Connection = connection;
            try
            {
                command2.ExecuteNonQuery();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //this.Cursor = Cursors.Default;
                
                
            }
            connection.Close();
        }

        private object Podaci_O_Zadnjem_Obracunu(string sIDObracun)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            command.CommandText = "SELECT ISNULL(MAX(OBRACUN.IDOBRACUN), @idobracun) FROM OBRACUN INNER JOIN OBRACUN OBRACUN_1 ON OBRACUN.MJESECISPLATE = OBRACUN_1.MJESECISPLATE AND OBRACUN.GODINAISPLATE = OBRACUN_1.GODINAISPLATE WHERE (OBRACUN_1.IDOBRACUN = @idobracun)";
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Parameters.Add("@idobracun", SqlDbType.VarChar).Value = sIDObracun;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return "";
        }

        public void PostaviBindingZaVrsteObustava()
        {
            this.chkPostotneObustave.DataBindings.Add("Checked", this.ObracunDataSet1.OBRACUN, "obrpostotnih");
            this.chkFiksneObustave.DataBindings.Add("Checked", this.ObracunDataSet1.OBRACUN, "obrfiksnih");
            this.chkKreditneObustave.DataBindings.Add("Checked", this.ObracunDataSet1.OBRACUN, "obrkreditnih");
        }

        public void PotpisnaLista()
        {
            //this.DesktopAlert();
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPotpisnaLista.rpt");
            document.SetDataSource(this.ObracunDataSet1);
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
            string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
            string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
            string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
            document.SetParameterValue("ADresa", str + " " + str2);
            document.SetParameterValue("ustanova", str6);
            document.SetParameterValue("opis", "Obračun plaće za:  " + DB.MjesecNazivPlatna(Conversions.ToInteger(this.mjesecobracuna)) + " godina " + this.godinaobracuna);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"]);
            this.UltraDesktopAlert1.CloseAll();
        }

        [CommandHandler("PrebaciElemente")]
        public void PrebaciElementeCommandHandler(object sender, EventArgs e)
        {
            this.PrebaciElementeNaknadno();
        }

        public void PrebaciElementeNaknadno()
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                Interaction.MsgBox("Otvorite obračun!!!", MsgBoxStyle.OkOnly, null);
            }
            else if (!this.Obracun_Read_Only())
            {
                Interaction.MsgBox("Izmjene nisu moguće", MsgBoxStyle.OkOnly, null);
            }
            else if (Interaction.MsgBox("Želite li stvarno dodati neto elemente iz zaduženja u aktivan obračun??", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            {
                IEnumerator enumerator = null;
                DataView view2 = new DataView {
                    Table = this.RadnikDataSet1.RADNIKNeto
                };
                DataView view = view2;
                try
                {
                    enumerator = this.ObracunDataSet1.ObracunRadnici.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        view.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik=", current["idradnik"]));
                        int num2 = view.Count - 1;
                        for (int i = 0; i <= num2; i++)
                        {
                            bool[] flagArray;
                            OBRACUNDataSet.ObracunElementiRow row = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                            row["idelement"] = RuntimeHelpers.GetObjectValue(view[i]["netoelementidelement"]);
                            row["elementrazdobljeod"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna), 1);
                            row["elementrazdobljedo"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna) + 1, 1).AddDays(-1.0);
                            row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                            row["obrsati"] = RuntimeHelpers.GetObjectValue(view[i]["netosatnica"]);
                            if (Operators.ConditionalCompareObjectEqual(view[i]["netosatnica"], 0, false))
                            {
                                object obj2 = new object();
                                object obj4 = new object();
                                object obj5 = new object();
                                object obj6 = new object();
                                double satnica = 0;
                                decimal gstaza = 0;
                                decimal mstaza = 0;
                                decimal dstaza = 0;
                                this.IzracunSatnice(ref current, ref satnica, ref gstaza, ref mstaza, ref dstaza);
                                obj2 = dstaza;
                                obj5 = mstaza;
                                obj4 = gstaza;
                                obj6 = satnica;
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(obj6);
                                row["obriznos"] = DB.RoundUP(Operators.MultiplyObject(Operators.MultiplyObject(row["obrsatnica"], row["obrsati"]), Operators.DivideObject(row["obrpostotak"], 100)));
                            }
                            else
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["netoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                            }
                            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(view[i]["netoiznos"], 0, false), Operators.CompareObjectEqual(view[i]["netosati"], 0, false))))
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["netoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                                row["obrsatnica"] = 0;
                                row["obrsati"] = 0;
                            }
                            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectGreater(view[i]["netoiznos"], 0, false), Operators.CompareObjectGreater(view[i]["netosati"], 0, false)), Operators.CompareObjectGreater(view[i]["netosatnica"], 0, false))))
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["netoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(view[i]["netosatnica"]);
                                row["obrsati"] = RuntimeHelpers.GetObjectValue(view[i]["netosati"]);
                            }
                            row["idobracun"] = RuntimeHelpers.GetObjectValue(current["idobracun"]);
                            row["idradnik"] = RuntimeHelpers.GetObjectValue(current["idradnik"]);
                            try
                            {
                                this.ObracunDataSet1.ObracunElementi.Rows.Add(row);
                            }
                            catch (System.Exception exception1)
                            {
                                throw exception1;
                            }
                            object instance = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                            ReadOnlyConnection connection = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                            ReadOnlyCommand command = connection.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
                            if (command.IDbCommand.Parameters.Count == 0)
                            {
                                command.IDbCommand.Parameters.Add(new SqlParameter("@IDELEMENT", SqlDbType.Int));
                            }
                            command.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDELEMENT"]));
                            IDataReader reader = command.FetchData();
                            if (!command.HasMoreRows)
                            {
                                reader.Close();
                                object[] objArray2 = new object[] { connection };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", objArray2, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[0]), typeof(ReadOnlyConnection));
                                }
                                throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ELEMENT" }));
                            }
                            object[] arguments = new object[] { reader, 0 };
                            flagArray = new bool[] { true, false };
                            if (flagArray[0])
                            {
                                reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                            }
                            row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                            reader.Close();
                            arguments = new object[] { connection };
                            flagArray = new bool[] { true };
                            NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                            if (flagArray[0])
                            {
                                connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                            }
                            if (!row.IsIDVRSTAELEMENTANull())
                            {
                                ReadOnlyConnection connection3 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                ReadOnlyCommand command3 = connection3.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                                if (command3.IDbCommand.Parameters.Count == 0)
                                {
                                    command3.IDbCommand.Parameters.Add(new SqlParameter("@IDVRSTAELEMENTA", SqlDbType.Int));
                                }
                                command3.SetParameter(0, 1);
                                IDataReader reader3 = command3.FetchData();
                                if (!command3.HasMoreRows)
                                {
                                    reader3.Close();
                                    arguments = new object[] { connection3 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "VRSTAELEMENT" }));
                                }
                                arguments = new object[] { reader3, 0 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                reader3.Close();
                                arguments = new object[] { connection3 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                            }
                            else
                            {
                                row["NAZIVVRSTAELEMENT"] = "";
                            }
                            if (!row.IsIDOSNOVAOSIGURANJANull() & (row.IDOSNOVAOSIGURANJA != ""))
                            {
                                ReadOnlyConnection connection2 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                ReadOnlyCommand command2 = connection2.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] FROM [OSNOVAOSIGURANJA] (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                                if (command2.IDbCommand.Parameters.Count == 0)
                                {
                                    command2.IDbCommand.Parameters.Add(new SqlParameter("@IDOSNOVAOSIGURANJA", SqlDbType.NVarChar, 2));
                                }
                                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDOSNOVAOSIGURANJA"]));
                                IDataReader reader2 = command2.FetchData();
                                if (!command2.HasMoreRows)
                                {
                                    reader2.Close();
                                    arguments = new object[] { connection2 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OSNOVAOSIGURANJA" }));
                                }
                                arguments = new object[] { reader2, 0 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                reader2.Close();
                                arguments = new object[] { connection2 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                            }
                            else
                            {
                                row["NAZIVOSNOVAOSIGURANJA"] = "";
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
                this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
                this.Obracun_Svih_Zaposlenika();
            }
        }

        public void PregledObracuna()
        {
            frmPregledObracuna obracuna = new frmPregledObracuna();
            obracuna.ShowDialog();
            if ((obracuna.DialogResult != DialogResult.Cancel) && (obracuna.ObracunSelected != null))
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(obracuna.ObracunSelected, this.Podaci_O_Zadnjem_Obracunu(Conversions.ToString(obracuna.ObracunSelected)), false), Operators.CompareObjectNotEqual(obracuna.Zakljucano, true, false))))
                {
                    this.bPromjeneMoguce = true;
                    this.UltraCheckEditor1.Enabled = true;
                    this.UltraCheckEditor2.Enabled = true;
                    //this.UltraCheckEditor3.Enabled = true;
                }
                else
                {
                    if (!admin_kontrola)
                    {
                        this.bPromjeneMoguce = false;
                        this.UltraCheckEditor1.Enabled = false;
                        this.UltraCheckEditor2.Enabled = false;
                    }
                    else
                    {
                        this.bPromjeneMoguce = true;
                        this.UltraCheckEditor1.Enabled = true;
                        this.UltraCheckEditor2.Enabled = true;
                    }
                    //this.UltraCheckEditor3.Enabled = false;
                }
                this.blokirajPromjenuPozicije = true;
                this.currencyManagerZaposleniciObracun = (CurrencyManager) this.BindingContext[this.ObracunDataSet1, "OBRACUNradnici"];
                this.ObracunDataSet1.Clear();
                try
                {
                    this.daObracunGlobal.FillByIDOBRACUN(this.ObracunDataSet1, Conversions.ToString(obracuna.ObracunSelected));
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }

                if (this.ObracunDataSet1.ObracunOlaksice.Rows.Count > 0)
                {
                    this.onemogucen_obracun_olaksica = true;
                    this.obracunavaolaksice = true;
                    this.UltraCheckEditor1.Checked = this.obracunavaolaksice;
                    this.onemogucen_obracun_olaksica = false;
                }
                if (this.ObracunDataSet1.OBRACUNObustave.Rows.Count > 0)
                {
                    this.onemogucen_obracun_obustava = true;
                    this.obracunavaobustave = true;
                    this.UltraCheckEditor2.Checked = this.obracunavaobustave;
                    this.onemogucen_obracun_obustava = false;
                }
                if (this.ObracunDataSet1.OBRACUNKrediti.Rows.Count > 0)
                {
                    this.onemogucen_obracun_obustava = true;
                    this.obracunavaobustave = true;
                    this.UltraCheckEditor2.Checked = this.obracunavaobustave;
                    this.onemogucen_obracun_obustava = false;
                }
                if (this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunKrizni.Rows.Count > 0)
                {
                    this.obracunavakrizni = true;
                    //this.UltraCheckEditor3.Checked = this.obracunavakrizni;
                }
                this.mjesecobracuna = Conversions.ToString(this.ObracunDataSet1.OBRACUN.Rows[0]["mjesecobracuna"]);
                this.godinaobracuna = Conversions.ToString(this.ObracunDataSet1.OBRACUN.Rows[0]["godinaobracuna"]);
                this.mjesecisplate = Conversions.ToString(this.ObracunDataSet1.OBRACUN.Rows[0]["mjesecisplate"]);
                this.godinaisplate = Conversions.ToString(this.ObracunDataSet1.OBRACUN.Rows[0]["godinaisplate"]);
                this.mjesecnifond = Conversions.ToDecimal(this.ObracunDataSet1.OBRACUN.Rows[0]["mjesecnifondsatiobracun"]);
                this.tjednifond = Conversions.ToDecimal(this.ObracunDataSet1.OBRACUN.Rows[0]["tjednifondsatiobracun"]);
                this.osnovnioo = Conversions.ToDecimal(this.ObracunDataSet1.OBRACUN.Rows[0]["osnovnioo"]);
                this.obrosnovica = Conversions.ToDecimal(this.ObracunDataSet1.OBRACUN.Rows[0]["obracunskaosnovica"]);
                this.sifraobracuna = Conversions.ToString(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
                this.txtSifraobracuna.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
                this.datumobracunastaza = Conversions.ToDate(this.ObracunDataSet1.OBRACUN.Rows[0]["DATUMOBRACUNASTAZA"]);
                this.txtOpisObracuna = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["SVRHAOBRACUNA"])), " ", RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["SVRHAOBRACUNA"])));
                this.ListBox1.Items.Clear();
                this.ListBox1.Items.Add(" ");

                //hvatanje id obracuna za upis kasnije u bazu
                frmKonacni.id_obracun = sifraobracuna;

                this.ListBox1.Items.Add("Šifra obračuna:" + this.sifraobracuna);
                this.ListBox1.Items.Add("Godina i mjesec obračuna " + this.godinaobracuna + "/" + this.mjesecobracuna);
                this.ListBox1.Items.Add("Godina i mjesec isplate " + this.godinaisplate + "/" + this.mjesecisplate);
                this.ListBox1.Items.Add("Mjesečni / tjedni fond sati " + Conversions.ToString(this.mjesecnifond) + "/" + Conversions.ToString(this.tjednifond));
                this.ListBox1.Items.Add("Osnovni OO / Obračunska osnovica " + string.Format("{0:#,##0.00}", this.osnovnioo) + "/" + string.Format("{0:#,##0.00}", this.obrosnovica));
                this.ListBox1.Items.Add("Datum obračuna staža:" + Conversions.ToString(this.datumobracunastaza));
                this.ListBox1.Items.Add("Opis obračuna --->>>" + this.txtOpisObracuna);
                this.blokirajPromjenuPozicije = false;
                this.UltraGrid1.PerformAction(UltraGridAction.FirstRowInGrid);
                this.ZaposleniciUobracunu_Promjena_Pozicije(null, null);
                this.Puni_poreze(Conversions.ToString(obracuna.ObracunSelected));
                this.Puni_oo(Conversions.ToString(obracuna.ObracunSelected));
                this.Puni_Obustave(Conversions.ToString(obracuna.ObracunSelected));
                this.Puni_KRIZNI_NETO(Conversions.ToString(obracuna.ObracunSelected), this.mjesecisplate, this.godinaisplate);
                S_OD_STANJE_KREDITADataAdapter adapter = new S_OD_STANJE_KREDITADataAdapter();
                this.STANJEKREDITA.S_OD_STANJE_KREDITA.Clear();
                adapter.Fill(this.STANJEKREDITA, this.sifraobracuna);
                S_OD_STANJE_OBUSTAVADataAdapter adapter2 = new S_OD_STANJE_OBUSTAVADataAdapter();
                this.STANJEOBUSTAVA.S_OD_STANJE_OBUSTAVA.Clear();
                adapter2.Fill(this.STANJEOBUSTAVA, this.sifraobracuna);
            }
        }

        public void Puni_KRIZNI_NETO(string sifraobr, string MJESECISPLATE, string GODINAISPLATE)
        {
            S_OD_KRIZNI_POREZDataAdapter adapter = new S_OD_KRIZNI_POREZDataAdapter();
            this.DSKRIZNI.S_OD_KRIZNI_POREZ.Clear();
            adapter.Fill(this.DSKRIZNI, sifraobr, MJESECISPLATE, GODINAISPLATE);
        }

        public void Puni_Obustave(string sifraobr)
        {
            S_OD_OBUSTAVA_OBRACUNATADataAdapter adapter = new S_OD_OBUSTAVA_OBRACUNATADataAdapter();
            S_OD_KREDIT_OBRACUNATDataAdapter adapter2 = new S_OD_KREDIT_OBRACUNATDataAdapter();
            this.dsObustavaobracunata.S_OD_OBUSTAVA_OBRACUNATA.Clear();
            this.dskreditObracunat.S_OD_KREDIT_OBRACUNAT.Clear();
            adapter.Fill(this.dsObustavaobracunata, sifraobr);
            adapter2.Fill(this.dskreditObracunat, sifraobr);
        }

        public void Puni_oo(string sifraobr)
        {
            S_OD_OO_MJESECNODataAdapter adapter = new S_OD_OO_MJESECNODataAdapter();
            this.DSOO.S_OD_OO_MJESECNO.Clear();
            adapter.Fill(this.DSOO, sifraobr);
        }

        public void Puni_poreze(string sifraobr)
        {
            S_OD_POREZ_MJESECNODataAdapter adapter = new S_OD_POREZ_MJESECNODataAdapter();
            this.DSPOREZMJESECNO.S_OD_POREZ_MJESECNO.Clear();
            adapter.Fill(this.DSPOREZMJESECNO, sifraobr);
        }

        private void RadniciUObracunu_OznaciSve()
        {
            int num2 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid1.Rows[i].Cells["oznacen"].Value = true;
            }
            try
            {
                this.BindingContext[this.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
        }

        [LocalCommandHandler("Rekapitulacija")]
        public void Rekap(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Rekapitulacija obračuna",
                Description = "Rekapitulacija obračuna",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            KratkaRekapWorkItem item = this.Controller.WorkItem.Items.Get<KratkaRekapWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<KratkaRekapWorkItem>("Pregled");
            }
            item.Obracun = Conversions.ToString(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            item.opisobracuna = DB.N2T(this.txtOpisObracuna, "");
            item.Show(item.Workspaces["main"], info);
        }

        [LocalCommandHandler("Bruto")]
        public void RekapBrutoH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija bruto elemenata",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Bruto smartPart = this.Controller.WorkItem.Items.AddNew<Bruto>();
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("Doprinos")]
        public void RekapDoprinosH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija doprinosa",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Doprinos smartPart = this.Controller.WorkItem.Items.AddNew<Doprinos>();
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("Fiksna")]
        public void RekapFiksnaH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija fiksnih obustava",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Fiksna smartPart = this.Controller.WorkItem.Items.AddNew<Fiksna>();
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("Kredit")]
        public void RekapKreditH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija kredita",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Kredit smartPart = this.Controller.WorkItem.Items.AddNew<Kredit>();
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("Neto")]
        public void RekapNetoH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija neto elemenata",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Neto smartPart = this.Controller.WorkItem.Items.AddNew<Neto>();
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("Olaksica")]
        public void RekapOlaksicaH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija olakšica",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Olaksica smartPart = this.Controller.WorkItem.Items.AddNew<Olaksica>();
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("Porez")]
        public void RekapPorezH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija poreza",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Porez smartPart = this.Controller.WorkItem.Items.AddNew<Porez>();
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            workspace.Show(smartPart, smartPartInfo);
        }

        [LocalCommandHandler("Postotna")]
        public void RekapPostotnaH(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Potrebno je otvoriti obračun!", "MBS.Complete");
                return;
            }

            this.SaveToDatabase();
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = false,
                Title = "Rekapitulacija postotnih obustava",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            Postotna smartPart = this.Controller.WorkItem.Items.AddNew<Postotna>();
            smartPart.obracun.Value = RuntimeHelpers.GetObjectValue(this.ObracunDataSet1.OBRACUN.Rows[0]["idobracun"]);
            smartPart.mjesec = Conversions.ToInteger(this.mjesecobracuna);
            smartPart.godina = Conversions.ToInteger(this.godinaobracuna);
            workspace.Show(smartPart, smartPartInfo);
        }

        [CommandHandler("RSMCommand")]
        public void RSMCommandHandler(object sender, EventArgs e)
        {
            this.SaveToDatabase();
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            RSMObrazacWorkItem item = this.Controller.WorkItem.Items.Get<RSMObrazacWorkItem>("RSMA");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<RSMObrazacWorkItem>("RSMA");
            }
            item.Show(item.Workspaces["main"]);
        }

        public void SaveToDatabase()
        {
            try
            {
                this.daObracunGlobal.Update(this.ObracunDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        [LocalCommandHandler("OtvoriPostojeci")]
        public void StalnaZaduzenjaHandler(object sender, EventArgs e)
        {
            this.PregledObracuna();
        }

        public decimal UkupniBruto(object sifraradnika)
        {
            return DB.N20(RuntimeHelpers.GetObjectValue(this.dvBrutoElementi.Table.Compute("SUM(obriznos)", Conversions.ToString(Operators.ConcatenateObject("IDVRSTAELEMENTA = 2 and idradnik=  ", sifraradnika)))));
        }

        public decimal UkupniNeto(object sifraradnika)
        {
            return DB.N20(RuntimeHelpers.GetObjectValue(this.dvNetoElementi.Table.Compute("SUM(obriznos)", "IDVRSTAELEMENTA = 1 and idradnik= " + Conversions.ToString(sifraradnika))));
        }

        private void UkupnoKriznog_i_neto(int sifraradnika, string sifraobr, ref decimal decNetoPlaca, ref decimal decObracunatiKrizni)
        {
            DataRow[] rowArray = this.DSKRIZNI.S_OD_KRIZNI_POREZ.Select("IDRADNIK = " + Conversions.ToString(sifraradnika));
            if (rowArray.Length > 0)
            {
                decNetoPlaca = Conversions.ToDecimal(rowArray[0]["netoplaca"]);
                decObracunatiKrizni = Conversions.ToDecimal(rowArray[0]["porezkrizni"]);
            }
            else
            {
                decNetoPlaca = new decimal();
                decObracunatiKrizni = new decimal();
            }
        }

        private decimal UkupnoOlaksicaUMjesecu(int sifraradnik, string sifraobr, int sifragrupeolaksice)
        {
            decimal num = 0;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            command.CommandText = "SELECT SUM(OBRACUNolaksice.OBRACUNATAOLAKSICA) AS UKUPNOOBRACUNATOIZNOSOLAKSICE FROM OBRACUN INNER JOIN OBRACUNolaksice ON OBRACUN.IDOBRACUN = OBRACUNolaksice.IDOBRACUN INNER JOIN OLAKSICE ON OBRACUNolaksice.IDOLAKSICE = OLAKSICE.IDOLAKSICE INNER JOIN GRUPEOLAKSICA ON OLAKSICE.IDGRUPEOLAKSICA = GRUPEOLAKSICA.IDGRUPEOLAKSICA INNER JOIN OBRACUN OBRACUN_1 ON OBRACUN.MJESECOBRACUNA = OBRACUN_1.MJESECOBRACUNA AND OBRACUN.GODINAOBRACUNA = OBRACUN_1.GODINAOBRACUNA WHERE (OBRACUN.IDOBRACUN <> '" + sifraobr + "') AND (OBRACUN_1.IDOBRACUN = '" + sifraobr + "') and obracunolaksice.idradnik = '" + Conversions.ToString(sifraradnik) + "' GROUP BY GRUPEOLAKSICA.MAXIMALNIIZNOSGRUPE, OBRACUN.MJESECISPLATE, OBRACUN.GODINAISPLATE, GRUPEOLAKSICA.IDGRUPEOLAKSICA HAVING GRUPEOLAKSICA.IDGRUPEOLAKSICA = " + Conversions.ToString(sifragrupeolaksice);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                num = DB.N20(reader.GetDecimal(0));
            }
            else
            {
                num = new decimal();
            }
            reader.Close();
            connection.Close();
            return num;
        }

        private decimal UkupnoOOuMjesecu(int sifraradnika, string sifraobr)
        {
            DataRow[] rowArray = this.DSOO.S_OD_OO_MJESECNO.Select("IDRADNIK = " + Conversions.ToString(sifraradnika));
            if (rowArray.Length > 0)
            {
                return Conversions.ToDecimal(rowArray[0]["UKUPNOOBRACUNATOOO"]);
            }
            return new decimal();
        }

        private void UkupnoPorezaUMjesecu(int sifraradnika, string sifraobr, int SIFRAPOREZA, ref decimal decOsnovicaPoreza, ref decimal decObracunatiPorez)
        {
            DataRow[] rowArray = this.DSPOREZMJESECNO.S_OD_POREZ_MJESECNO.Select("IDPOREZ = " + Conversions.ToString(SIFRAPOREZA) + " AND IDRADNIK = " + Conversions.ToString(sifraradnika));
            if (rowArray.Length > 0)
            {
                decOsnovicaPoreza = Conversions.ToDecimal(rowArray[0]["OSNOVICA"]);
                decObracunatiPorez = Conversions.ToDecimal(rowArray[0]["OBRACUNATIPOREZ"]);
            }
            else
            {
                decOsnovicaPoreza = new decimal();
                decObracunatiPorez = new decimal();
            }
        }

        private void UltraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.onemogucen_obracun_olaksica)
            {
                try
                {
                    this.obracunavaolaksice = !this.obracunavaolaksice;
                    if (this.obracunavaolaksice)
                    {

                    }
                    this.Obracun_Svih_Zaposlenika();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }

        private void UltraCheckEditor2_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.onemogucen_obracun_obustava)
            {
                this.obracunavaobustave = !this.obracunavaobustave;
                if (this.obracunavaobustave)
                {
                }
                this.Obracun_Svih_Zaposlenika();
            }
        }

        /*
        private void UltraCheckEditor3_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.onemogucen_obracun_kriznog_poreza && (DateTime.Compare(DateAndTime.DateSerial(Conversions.ToInteger(this.godinaisplate), Conversions.ToInteger(this.mjesecisplate), 1), DateAndTime.DateSerial(0x7da, 11, 1)) < 0))
            {
                this.obracunavakrizni = !this.obracunavakrizni;
                if (this.obracunavakrizni)
                {
                }
                this.Obracun_Svih_Zaposlenika();
            }
        }
        */

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UltraGridRow context = null;
                UltraGridCell cell = null;
                UIElement element = null;

                element = this.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(e.Location);
                context = (UltraGridRow) element.GetContext(typeof(UltraGridRow));
                cell = (UltraGridCell) element.GetContext(typeof(UltraGridCell));

                if (((context != null && cell != null) && context.IsDataRow) && (cell.Column.Key == "oznacen"))
                {
                    context.Selected = true;
                    context.Cells["oznacen"].Value = Operators.NotObject(context.Cells["oznacen"].Value);
                }
                if (this.bPromjeneMoguce)
                {
                    if (((context != null && cell != null) && context.IsDataRow) && (cell.Column.Key == "OBRACUNAVAJOBUSTAVE"))
                    {
                        context.Selected = true;
                        context.Cells["OBRACUNAVAJOBUSTAVE"].Value = Operators.NotObject(context.Cells["OBRACUNAVAJOBUSTAVE"].Value);
                    }
                    this.UltraGrid1.UpdateData();
                    new OBRACUNDataAdapter().Update(this.ObracunDataSet1);
                }

                if (this.currencyManagerZaposleniciObracun.Count > 0)
                {
                    DataRowView current = (DataRowView)this.currencyManagerZaposleniciObracun.Current;
                    this.Platna_Ekran(current, false);
                }
            }
        }

        private void UltraGrid2_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DatasetRekapitulacija1, "dtRekap"];
            if (manager.Count != 0)
            {
                DataRowView current = (DataRowView) manager.Current;
                if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["sifraelementa"])))
                {
                    if (Operators.ConditionalCompareObjectEqual(current["vrstaelementa"], 2, false))
                    {
                        this.BrutoElementPromjena();
                    }
                    else if (Operators.ConditionalCompareObjectEqual(current["vrstaelementa"], 1, false))
                    {
                        this.NetoElementPromjena();
                    }
                }
            }
        }

        private void UltraGrid2_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.Row.Index == 0)
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Appearance.FontData.SizeInPoints = 10;
            }

            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, My.Resources.ResourcesPlacaExe.ObracunSmartPart_Platna_Ekran_Ukupno_bruto_primanja, false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, "Neto plaća", false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, "Neto primanja", false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, "ZA ISPLATU", false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
        }

        private void UltraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Oznaci":
                    this.RadniciUObracunu_OznaciSve();
                    break;

                case "UkloniOznake":
                    this.Zaposlenik_Ukloni_Oznake_Svima();
                    break;

                case "DodajBruto":
                    if (this.BrojOznacenihZaposlenika() == 0)
                    {
                        this.BrutoElementUnos();
                    }
                    else
                    {
                        this.BrutoElementiUnesiOznacenima();
                    }
                    break;

                case "IzmjeniBruto":
                    this.BrutoElementPromjena();
                    break;

                case "BrisiBruto":
                    if (this.BrojOznacenihZaposlenika() <= 1)
                    {
                        this.BrutoElementBrisi();
                    }
                    else
                    {
                        this.Brisanje_bruto_Elemenata_za_Vise_radnika();
                    }
                    break;

                case "DodajNeto":
                    if (this.BrojOznacenihZaposlenika() == 0)
                    {
                        this.NetoElementUnos();
                    }
                    else
                    {
                        this.NetoElementiUnesiOznacenima();
                    }
                    break;

                case "IzmjeniNeto":
                    this.NetoElementPromjena();
                    break;

                case "BrisiNeto":
                    if (this.BrojOznacenihZaposlenika() <= 1)
                    {
                        this.NetoElementBrisi();
                    }
                    else
                    {
                        this.Brisanje_neto_Elemenata_za_Vise_radnika();
                    }
                    break;
            }
        }

        [CommandHandler("VirmaniCommand")]
        public void VirmaniCommandHandler(object sender, EventArgs e)
        {
            this.SaveToDatabase();
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            VirmaniWorkItemUser user = this.Controller.WorkItem.Items.Get<VirmaniWorkItemUser>("Virmani");
            
            if (user == null)
            {
                user = this.Controller.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Virmani");
            }

            JOPPD.SifraJOPPDObrazac identifikator = new JOPPD.SifraJOPPDObrazac(user);
            identifikator.Show();
        }

        private void Zapocni_Obracun_I_Dodaj_neto_Elemente(frmPregledRadnika frm)
        {
            IEnumerator enumerator = null;
            DataView view = new DataView {
                Table = this.RadnikDataSet1.RADNIKNeto
            };
            try
            {
                enumerator = this.ObracunDataSet1.ObracunRadnici.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    view.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik=", current["idradnik"]));
                    int num2 = view.Count - 1;
                    for (int i = 0; i <= num2; i++)
                    {
                        if (frm.Neto)
                        {
                            bool[] flagArray;
                            OBRACUNDataSet.ObracunElementiRow row = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                            row["idelement"] = RuntimeHelpers.GetObjectValue(view[i]["netoelementidelement"]);
                            row["elementrazdobljeod"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna), 1);
                            row["elementrazdobljedo"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna) + 1, 1).AddDays(-1.0);
                            row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                            row["obrsati"] = RuntimeHelpers.GetObjectValue(view[i]["netosatnica"]);
                            if (Operators.ConditionalCompareObjectEqual(view[i]["netosatnica"], 0, false))
                            {
                                /*object obj2 = new object();
                                object obj4 = new object();
                                object obj5 = new object();
                                object obj6 = new object();*/
                                double satnica = 0;
                                decimal gstaza = 0;
                                decimal mstaza = 0;
                                decimal dstaza = 0;
                                this.IzracunSatnice(ref current, ref satnica, ref gstaza, ref mstaza, ref dstaza);
                                /*obj2 = dstaza;
                                obj5 = mstaza;
                                obj4 = gstaza;
                                obj6 = satnica;*/
                                row["obrsatnica"] = 0;
                                row["obriznos"] = DB.RoundUP(Operators.MultiplyObject(Operators.MultiplyObject(row["obrsatnica"], row["obrsati"]), Operators.DivideObject(row["obrpostotak"], 100)));
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                                row["obrsati"] = RuntimeHelpers.GetObjectValue(view[i]["netosati"]);
                            }
                            else
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["netoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(view[i]["netosatnica"]);
                            }
                            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(view[i]["netoiznos"], 0, false), Operators.CompareObjectEqual(view[i]["netosati"], 0, false))))
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["netoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                                row["obrsatnica"] = 0;
                                row["obrsati"] = 0;
                            }
                            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectGreater(view[i]["netoiznos"], 0, false), Operators.CompareObjectGreater(view[i]["netosati"], 0, false)), Operators.CompareObjectGreater(view[i]["netosatnica"], 0, false))))
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["netoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["netopostotak"]);
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(view[i]["netosatnica"]);
                                row["obrsati"] = RuntimeHelpers.GetObjectValue(view[i]["netosati"]);
                            }
                            row["idobracun"] = RuntimeHelpers.GetObjectValue(current["idobracun"]);
                            row["idradnik"] = RuntimeHelpers.GetObjectValue(current["idradnik"]);
                            this.ObracunDataSet1.ObracunElementi.Rows.Add(row);
                            object instance = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                            ReadOnlyConnection connection = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                            ReadOnlyCommand command = connection.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
                            if (command.IDbCommand.Parameters.Count == 0)
                            {
                                command.IDbCommand.Parameters.Add(new SqlParameter("@IDELEMENT", SqlDbType.Int));
                            }
                            command.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDELEMENT"]));
                            IDataReader reader = command.FetchData();
                            if (!command.HasMoreRows)
                            {
                                reader.Close();
                                object[] objArray2 = new object[] { connection };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", objArray2, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[0]), typeof(ReadOnlyConnection));
                                }
                                throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ELEMENT" }));
                            }
                            object[] arguments = new object[] { reader, 0 };
                            flagArray = new bool[] { true, false };
                            if (flagArray[0])
                            {
                                reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                            }
                            row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                            reader.Close();
                            arguments = new object[] { connection };
                            flagArray = new bool[] { true };
                            NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                            if (flagArray[0])
                            {
                                connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                            }
                            if (!row.IsIDVRSTAELEMENTANull())
                            {
                                ReadOnlyConnection connection3 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                ReadOnlyCommand command3 = connection3.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                                if (command3.IDbCommand.Parameters.Count == 0)
                                {
                                    command3.IDbCommand.Parameters.Add(new SqlParameter("@IDVRSTAELEMENTA", SqlDbType.Int));
                                }
                                command3.SetParameter(0, 1);
                                IDataReader reader3 = command3.FetchData();
                                if (!command3.HasMoreRows)
                                {
                                    reader3.Close();
                                    arguments = new object[] { connection3 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "VRSTAELEMENT" }));
                                }
                                arguments = new object[] { reader3, 0 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                reader3.Close();
                                arguments = new object[] { connection3 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                            }
                            else
                            {
                                row["NAZIVVRSTAELEMENT"] = "";
                            }
                            if (!row.IsIDOSNOVAOSIGURANJANull() & (row.IDOSNOVAOSIGURANJA != ""))
                            {
                                ReadOnlyConnection connection2 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                ReadOnlyCommand command2 = connection2.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] FROM [OSNOVAOSIGURANJA] (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                                if (command2.IDbCommand.Parameters.Count == 0)
                                {
                                    command2.IDbCommand.Parameters.Add(new SqlParameter("@IDOSNOVAOSIGURANJA", SqlDbType.NVarChar, 2));
                                }
                                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDOSNOVAOSIGURANJA"]));
                                IDataReader reader2 = command2.FetchData();
                                if (!command2.HasMoreRows)
                                {
                                    reader2.Close();
                                    arguments = new object[] { connection2 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                }
                                arguments = new object[] { reader2, 0 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                reader2.Close();
                                arguments = new object[] { connection2 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                            }
                            else
                            {
                                row["NAZIVOSNOVAOSIGURANJA"] = "";
                            }
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
            this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
        }

        [LocalCommandHandler("ZapocniNovi")]
        public void ZapocniNoviHandler(object sender, EventArgs e)
        {
            if (this.ObracunDataSet1.OBRACUN.Rows.Count == 0)
            {
                this.Novi_Obracun();
            }
            else if (Interaction.MsgBox("Trenutno je otvoren obračun " + this.sifraobracuna + " želite li otvoriti novi obračun???", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            {
                this.ListBox1.Items.Clear();
                this.blokirajPromjenuPozicije = true;
                this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunIzuzece.Clear();
                this.ObracunDataSet1.ObracunElementi.Clear();
                this.ObracunDataSet1.OBRACUNKrediti.Clear();
                this.ObracunDataSet1.OBRACUNObustave.Clear();
                this.ObracunDataSet1.OBRACUNOBRACUNLevel1ObracunKrizni.Clear();
                this.ObracunDataSet1.ObracunDoprinosi.Clear();
                this.ObracunDataSet1.ObracunPorezi.Clear();
                this.ObracunDataSet1.ObracunRadnici.Clear();
                this.ObracunDataSet1.OBRACUN.Clear();
                this.blokirajPromjenuPozicije = false;
                this.Novi_Obracun();
            }
        }

        private void ZapocniObracun_I_Dodaj_Bruto_ELemente(frmPregledRadnika frm)
        {
            IEnumerator enumerator = null;
            DataView view = new DataView {
                Table = this.RadnikDataSet1.RADNIKBruto
            };
            try
            {
                enumerator = this.ObracunDataSet1.ObracunRadnici.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    view.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idradnik=", current["idradnik"]));
                    int num2 = view.Count - 1;
                    for (int i = 0; i <= num2; i++)
                    {
                        if (frm.Bruto)
                        {
                            bool[] flagArray;
                            OBRACUNDataSet.ObracunElementiRow row = (OBRACUNDataSet.ObracunElementiRow) this.ObracunDataSet1.ObracunElementi.NewRow();
                            row["idelement"] = RuntimeHelpers.GetObjectValue(view[i]["brutoelementidelement"]);
                            row["elementrazdobljeod"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna), 1);
                            row["elementrazdobljedo"] = DateAndTime.DateSerial(int.Parse(this.godinaobracuna), int.Parse(this.mjesecobracuna) + 1, 1).AddDays(-1.0);
                            row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["brutopostotak"]);
                            row["obrsati"] = RuntimeHelpers.GetObjectValue(view[i]["brutosati"]);
                            if (Operators.ConditionalCompareObjectEqual(view[i]["brutosatnica"], 0, false))
                            {
                                object obj2 = 0;
                                object obj4 = 0;
                                object obj5 = 0;
                                object obj6 = 0;
                                double satnica = Conversions.ToDouble(obj6);
                                decimal gstaza = Conversions.ToDecimal(obj4);
                                decimal mstaza = Conversions.ToDecimal(obj5);
                                decimal dstaza = Conversions.ToDecimal(obj2);
                                this.IzracunSatnice(ref current, ref satnica, ref gstaza, ref mstaza, ref dstaza);
                                obj2 = dstaza;
                                obj5 = mstaza;
                                obj4 = gstaza;
                                obj6 = satnica;
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(obj6);
                                row["obriznos"] = DB.RoundUP(Operators.MultiplyObject(Operators.MultiplyObject(row["obrsatnica"], row["obrsati"]), Operators.DivideObject(row["obrpostotak"], 100)));
                            }
                            else
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["brutoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["brutopostotak"]);
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(view[i]["brutopostotak"]);
                            }
                            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(view[i]["brutoiznos"], 0, false), Operators.CompareObjectEqual(view[i]["brutosati"], 0, false))))
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["brutoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["brutopostotak"]);
                                row["obrsatnica"] = 0;
                                row["obrsati"] = 0;
                            }
                            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectGreater(view[i]["brutoiznos"], 0, false), Operators.CompareObjectGreater(view[i]["brutosati"], 0, false)), Operators.CompareObjectGreater(view[i]["brutosatnica"], 0, false))))
                            {
                                row["obriznos"] = RuntimeHelpers.GetObjectValue(view[i]["brutoiznos"]);
                                row["obrpostotak"] = RuntimeHelpers.GetObjectValue(view[i]["brutopostotak"]);
                                row["obrsatnica"] = RuntimeHelpers.GetObjectValue(view[i]["brutosatnica"]);
                                row["obrsati"] = RuntimeHelpers.GetObjectValue(view[i]["brutosati"]);
                            }
                            row["idobracun"] = RuntimeHelpers.GetObjectValue(current["idobracun"]);
                            row["idradnik"] = RuntimeHelpers.GetObjectValue(current["idradnik"]);
                            this.ObracunDataSet1.ObracunElementi.Rows.Add(row);
                            object instance = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
                            ReadOnlyConnection connection = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                            ReadOnlyCommand command = connection.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
                            if (command.IDbCommand.Parameters.Count == 0)
                            {
                                command.IDbCommand.Parameters.Add(new SqlParameter("@IDELEMENT", SqlDbType.Int));
                            }
                            command.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDELEMENT"]));
                            IDataReader reader = command.FetchData();
                            if (!command.HasMoreRows)
                            {
                                reader.Close();
                                object[] objArray2 = new object[] { connection };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", objArray2, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[0]), typeof(ReadOnlyConnection));
                                }
                                throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "ELEMENT" }));
                            }
                            object[] arguments = new object[] { reader, 0 };
                            flagArray = new bool[] { true, false };
                            if (flagArray[0])
                            {
                                reader = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                            }
                            row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                            reader.Close();
                            arguments = new object[] { connection };
                            flagArray = new bool[] { true };
                            NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                            if (flagArray[0])
                            {
                                connection = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                            }
                            if (!row.IsIDVRSTAELEMENTANull())
                            {
                                ReadOnlyConnection connection3 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                ReadOnlyCommand command3 = connection3.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                                if (command3.IDbCommand.Parameters.Count == 0)
                                {
                                    command3.IDbCommand.Parameters.Add(new SqlParameter("@IDVRSTAELEMENTA", SqlDbType.Int));
                                }
                                command3.SetParameter(0, 2);
                                IDataReader reader3 = command3.FetchData();
                                if (!command3.HasMoreRows)
                                {
                                    reader3.Close();
                                    arguments = new object[] { connection3 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "VRSTAELEMENT" }));
                                }
                                arguments = new object[] { reader3, 0 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader3 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                reader3.Close();
                                arguments = new object[] { connection3 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection3 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                            }
                            else
                            {
                                row["NAZIVVRSTAELEMENT"] = "";
                            }
                            if (!row.IsIDOSNOVAOSIGURANJANull() & (row.IDOSNOVAOSIGURANJA != ""))
                            {
                                ReadOnlyConnection connection2 = (ReadOnlyConnection) NewLateBinding.LateGet(instance, null, "GetReadOnlyConnection", new object[0], null, null, null);
                                ReadOnlyCommand command2 = connection2.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] FROM [OSNOVAOSIGURANJA] (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                                if (command2.IDbCommand.Parameters.Count == 0)
                                {
                                    command2.IDbCommand.Parameters.Add(new SqlParameter("@IDOSNOVAOSIGURANJA", SqlDbType.NVarChar, 2));
                                }
                                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(row["IDOSNOVAOSIGURANJA"]));
                                IDataReader reader2 = command2.FetchData();
                                if (!command2.HasMoreRows)
                                {
                                    reader2.Close();
                                    arguments = new object[] { connection2 };
                                    flagArray = new bool[] { true };
                                    NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                    if (flagArray[0])
                                    {
                                        connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                    }
                                    throw new ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, ResourceManager.Instance.GetString("inex"), new object[] { "OSNOVAOSIGURANJA" }));
                                }
                                arguments = new object[] { reader2, 0 };
                                flagArray = new bool[] { true, false };
                                if (flagArray[0])
                                {
                                    reader2 = (IDataReader) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(IDataReader));
                                }
                                row["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(instance, null, "Db", new object[0], null, null, null), null, "GetString", arguments, null, null, flagArray));
                                reader2.Close();
                                arguments = new object[] { connection2 };
                                flagArray = new bool[] { true };
                                NewLateBinding.LateCall(instance, null, "CloseConnection", arguments, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    connection2 = (ReadOnlyConnection) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(arguments[0]), typeof(ReadOnlyConnection));
                                }
                            }
                            else
                            {
                                row["NAZIVOSNOVAOSIGURANJA"] = "";
                            }
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
            this.BindingContext[this.ObracunDataSet1.ObracunElementi].EndCurrentEdit();
        }

        public void ZapocniPonovo()
        {
            this.bPromjeneMoguce = false;
            this.sifraobracuna = "";
            this.RadnikDataSet1.Clear();
            this.DatasetRekapitulacija1.Clear();
            this.daRadnici.Fill(this.RadnikDataSet1);
            this.ObracunDataSet1.Clear();
            this.onemogucen_obracun_olaksica = true;
            this.onemogucen_obracun_obustava = true;
            this.onemogucen_obracun_olaksica = false;
            this.onemogucen_obracun_obustava = false;
        }

        public void ZaposleniciUobracunu_Promjena_Pozicije(object sender, EventArgs e)
        {
            if (this.currencyManagerZaposleniciObracun == null)
                return;

            if (!this.blokirajPromjenuPozicije && (this.currencyManagerZaposleniciObracun.Count != 0))
            {
                DataRowView current = (DataRowView) this.currencyManagerZaposleniciObracun.Current;
                this.dvBrutoElementi.RowFilter = "IDVRSTAELEMENTA = 2 AND IDRADNIK = " + Conversions.ToString(this.AktivanZaposlenik());
                this.dvNetoElementi.RowFilter = "IDVRSTAELEMENTA = 1 AND IDRADNIK = " + Conversions.ToString(this.AktivanZaposlenik());
                this.Obracunaj_Placu(false);
            }
        }

        private void Zaposlenik_Ukloni_Oznake_Svima()
        {
            int num2 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid1.Rows[i].Cells["oznacen"].Value = false;
            }
            try
            {
                this.BindingContext[this.ObracunDataSet1.ObracunRadnici].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
        }

        private AutoHideControl _ObracunSmartPartAutoHideControl;
        private UnpinnedTabArea _ObracunSmartPartUnpinnedTabAreaBottom;
        private UnpinnedTabArea _ObracunSmartPartUnpinnedTabAreaLeft;
        private UnpinnedTabArea _ObracunSmartPartUnpinnedTabAreaRight;
        private UnpinnedTabArea _ObracunSmartPartUnpinnedTabAreaTop;
        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Bottom;
        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Left;
        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Top;
        private BackgroundWorker BackgroundWorker1;
        private UltraLabel BrojRadnika;
        private UltraCheckEditor chkFiksneObustave;
        private UltraCheckEditor chkKreditneObustave;
        private UltraCheckEditor chkPostotneObustave;

        [CreateNew]
        public OBRACUNController Controller { get; set; }

        private CurrencyManager currencyManagerZaposleniciObracun;


        private datasetRekapitulacijaEkran DatasetRekapitulacija1;

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

        private DockableWindow DockableWindow2;

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

        private GRUPEOLAKSICADataSet GrupeolaksicaDataSet1;

        private System.Windows.Forms.ListBox ListBox1;

        public OBRACUNDataSet ObracunDataSet1;

        private Panel Panel2;

        private RADNIKDataSet RadnikDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private SKUPPOREZAIDOPRINOSADataSet SkupporezaidoprinosaDataSet1;

        private UltraTextEditor txtSifraobracuna;

        private UltraCheckEditor UltraCheckEditor1;

        private UltraCheckEditor UltraCheckEditor2;

        // private UltraCheckEditor UltraCheckEditor3;

        private UltraDesktopAlert UltraDesktopAlert1;

        private UltraDockManager UltraDockManager1;

        public UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox2;

        private UltraGroupBox UltraGroupBox3;

        private UltraLabel UltraLabel12;

        private UltraToolbarsManager UltraToolbarsManager1;

        private UltraToolTipManager UltraToolTipManager1;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

