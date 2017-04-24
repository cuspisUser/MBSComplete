using CrystalDecisions.CrystalReports.Engine;
using DDModule;
using DDModule.ID1OBRAZAC;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DDModule.ID1
{

    [SmartPart]
    public class IP1SmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private S_DD_IP1DataAdapter d;
        private S_DD_IP1DataSet ds;
        private string GODINA;
        private SmartPartInfoProvider infoProvider;
        
        private DateTime POCETNI;
        private SmartPartInfo smartPartInfo1;

        public IP1SmartPart()
        {
            base.Load += new EventHandler(this.IP1SmartPart_Load);
            this.d = new S_DD_IP1DataAdapter();
            this.ds = new S_DD_IP1DataSet();
            this.smartPartInfo1 = new SmartPartInfo("IP-1Obrazac", "IP-1Obrazac");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            ISmartPartInfo info = null;
            return info;
        }

        public void ID1Disketa()
        {
            S_DD_IP1DataSet set = new S_DD_IP1DataSet();
            foreach (DataRow row2 in this.ds.S_DD_IP1.Select("DDOZNACEN = 1"))
            {
                set.S_DD_IP1.ImportRow(row2);
            }
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            int num3 = 0;
            decimal left = new decimal();
            decimal num6 = new decimal();
            decimal num7 = new decimal();
            isplate[] isplateArray = new isplate[(set.S_DD_IP1.Rows.Count + 1) + 1];
            isplate[] isplateArray2 = new isplate[(set.S_DD_IP1.Rows.Count + 1) + 1];
            structPOREZI[] tporeziArray = new structPOREZI[0xf4240];
            num3 = 0;
            int num4 = 0;
            int index = 0;
            int num = 0;
            int num2 = 0;
            string str3 = Conversions.ToString(set.S_DD_IP1.Rows[num]["DDOIB"]);
            while (num4 < set.S_DD_IP1.Rows.Count)
            {
                int num27 = set.S_DD_IP1.Rows.Count - 1;
                for (num2 = 0; num2 <= num27; num2++)
                {
                    if (Operators.ConditionalCompareObjectEqual(str3, set.S_DD_IP1.Rows[num2]["ddOIB"], false))
                    {
                        num4++;
                        left = Conversions.ToDecimal(Operators.AddObject(left, set.S_DD_IP1.Rows[num2]["BRUTO"]));
                        num6 = Conversions.ToDecimal(Operators.AddObject(num6, set.S_DD_IP1.Rows[num2]["IZDACI"]));
                        num7 = Conversions.ToDecimal(Operators.AddObject(num7, set.S_DD_IP1.Rows[num2]["DOPRINOSIIZ"]));
                    }
                }
                isplateArray[index].primitak = left;
                isplateArray[index].izdatak = num6;
                isplateArray[index].izdatakdoprinosa = num7;
                isplateArray[index].mbg = Conversions.ToString(set.S_DD_IP1.Rows[num4 - 1]["DDOIB"]);
                isplateArray[index].oib = DB.FixNull(RuntimeHelpers.GetObjectValue(set.S_DD_IP1.Rows[num4 - 1]["ddoib"]));
                isplateArray[index].opcina = Conversions.ToString(set.S_DD_IP1.Rows[num4 - 1]["OPCINASTANOVANJAIDOPCINE"]);
                try
                {
                    isplateArray[index].prezime = Conversions.ToString(set.S_DD_IP1.Rows[num4 - 1]["ddprezime"]);
                    isplateArray[index].ime = Conversions.ToString(set.S_DD_IP1.Rows[num4 - 1]["ddime"]);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                left = new decimal();
                num6 = new decimal();
                num7 = new decimal();
                index++;
                if (num4 < set.S_DD_IP1.Rows.Count)
                {
                    str3 = Conversions.ToString(set.S_DD_IP1.Rows[num4]["DDOIB"]);
                }
            }
            Id1 o = new Id1 {
                IsplataUGodini = Conversions.ToInteger(mipsed.application.framework.Application.ActiveYear.ToString()),
                storno = false
            };
            IsplatiteljTip tip3 = new IsplatiteljTip();
            KontaktOsobaTip tip = new KontaktOsobaTip();
            tip3.oib = dataSet.KORISNIK.Rows[0]["KORISNIKOIB"].ToString();
            o.Isplatitelj = tip3;
            o.Identifikator = 1;
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTOSOBA"]).TrimEnd(new char[] { ' ' });
            tip.Prezime = Strings.Trim(str2.Substring(0, str2.LastIndexOf(" ")));
            tip.Ime = Strings.Trim(str2.Substring(str2.LastIndexOf(" ")));
            tip.Email = Conversions.ToString(dataSet.KORISNIK.Rows[0]["EMAIL"]);
            tip.Telefoni = new string[] { Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]), Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]) };
            o.Isplatitelj.KontaktOsoba = tip;
            num3 = 0;
            ObveznikTip[] tipArray = (ObveznikTip[]) Array.CreateInstance(typeof(ObveznikTip), index);
            int num29 = index - 1;
            for (int i = 0; i <= num29; i++)
            {
                RacunTip[] tipArray3 = new RacunTip[13];
                ObveznikTip tip5 = new ObveznikTip {
                    Ime = isplateArray[i].ime,
                    Prezime = isplateArray[i].prezime,
                    Primitak = DB.RoundUP(isplateArray[i].primitak),
                    Izdatak = DB.RoundUP(isplateArray[i].izdatak),
                    IzdatakDoprinosa = DB.RoundUP(isplateArray[i].izdatakdoprinosa),
                    oznGrOp = isplateArray[i].opcina.ToString().Substring(0, 3),
                    oib = isplateArray[i].oib
                };
                decimal num10 = new decimal();
                int num12 = 0;
                foreach (DataRow row in set.S_DD_IP1.Select("DDOIB = '" + isplateArray[i].oib + "'"))
                {
                    if (Operators.ConditionalCompareObjectGreater(row["P1422"], 0, false))
                    {
                        RacunTip tip7 = new RacunTip();
                        string str4 = "1422";
                        decimal num13 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1422"]));
                        tip7.brojRacuna = str4;
                        tip7.Iznos = num13;
                        num10 = decimal.Add(num10, num13);
                        tipArray3[num12] = tip7;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1457"], 0, false))
                    {
                        RacunTip tip8 = new RacunTip();
                        string str5 = "1457";
                        decimal num14 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1457"]));
                        tip8.brojRacuna = str5;
                        tip8.Iznos = num14;
                        num10 = decimal.Add(num10, num14);
                        tipArray3[num12] = tip8;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1465"], 0, false))
                    {
                        RacunTip tip9 = new RacunTip();
                        string str6 = "1465";
                        decimal num15 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1465"]));
                        tip9.brojRacuna = str6;
                        tip9.Iznos = num15;
                        num10 = decimal.Add(num10, num15);
                        tipArray3[num12] = tip9;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1473"], 0, false))
                    {
                        RacunTip tip10 = new RacunTip();
                        string str7 = "1473";
                        decimal num16 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1473"]));
                        tip10.brojRacuna = str7;
                        tip10.Iznos = num16;
                        num10 = decimal.Add(num10, num16);
                        tipArray3[num12] = tip10;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1546"], 0, false))
                    {
                        RacunTip tip11 = new RacunTip();
                        string str8 = "1546";
                        decimal num17 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1546"]));
                        tip11.brojRacuna = str8;
                        tip11.Iznos = num17;
                        num10 = decimal.Add(num10, num17);
                        tipArray3[num12] = tip11;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1570"], 0, false))
                    {
                        RacunTip tip12 = new RacunTip();
                        string str9 = "1570";
                        decimal num18 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1570"]));
                        tip12.brojRacuna = str9;
                        tip12.Iznos = num18;
                        num10 = decimal.Add(num10, num18);
                        tipArray3[num12] = tip12;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1589"], 0, false))
                    {
                        RacunTip tip13 = new RacunTip();
                        string str10 = "1589";
                        decimal num19 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1589"]));
                        tip13.brojRacuna = str10;
                        tip13.Iznos = num19;
                        num10 = decimal.Add(num10, num19);
                        tipArray3[num12] = tip13;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1597"], 0, false))
                    {
                        RacunTip tip14 = new RacunTip();
                        string str11 = "1597";
                        decimal num20 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1597"]));
                        tip14.brojRacuna = str11;
                        tip14.Iznos = num20;
                        num10 = decimal.Add(num10, num20);
                        tipArray3[num12] = tip14;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1600"], 0, false))
                    {
                        RacunTip tip15 = new RacunTip();
                        string str12 = "1600";
                        decimal num21 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1600"]));
                        tip15.brojRacuna = str12;
                        tip15.Iznos = num21;
                        num10 = decimal.Add(num10, num21);
                        tipArray3[num12] = tip15;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1813"], 0, false))
                    {
                        RacunTip tip16 = new RacunTip();
                        string str13 = "1813";
                        decimal num22 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1813"]));
                        tip16.brojRacuna = str13;
                        tip16.Iznos = num22;
                        num10 = decimal.Add(num10, num22);
                        tipArray3[num12] = tip16;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1821"], 0, false))
                    {
                        RacunTip tip17 = new RacunTip();
                        string str14 = "1821";
                        decimal num23 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1821"]));
                        tip17.brojRacuna = str14;
                        tip17.Iznos = num23;
                        num10 = decimal.Add(num10, num23);
                        tipArray3[num12] = tip17;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1830"], 0, false))
                    {
                        RacunTip tip18 = new RacunTip();
                        string str15 = "1830";
                        decimal num24 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1830"]));
                        tip18.brojRacuna = str15;
                        tip18.Iznos = num24;
                        num10 = decimal.Add(num10, num24);
                        tipArray3[num12] = tip18;
                        num12++;
                    }
                    if (Operators.ConditionalCompareObjectGreater(row["P1848"], 0, false))
                    {
                        RacunTip tip19 = new RacunTip();
                        string str16 = "1848";
                        decimal num25 = DB.RoundUP(RuntimeHelpers.GetObjectValue(row["P1848"]));
                        tip19.brojRacuna = str16;
                        tip19.Iznos = num25;
                        num10 = decimal.Add(num10, num25);
                        tipArray3[num12] = tip19;
                        num12++;
                    }
                }
                PorezPrirezTip tip6 = new PorezPrirezTip {
                    Racuni = tipArray3,
                    Ukupno = DB.RoundUP(num10)
                };
                tip5.PorezPrirez = tip6;
                tip5.IsplaceniPrimitak = decimal.Subtract(decimal.Subtract(DB.RoundUP(isplateArray[i].primitak), DB.RoundUP(isplateArray[i].izdatakdoprinosa)), DB.RoundUP(num10));
                tipArray[i] = tip5;
            }
            o.Obveznici = tipArray;
            DataView view = new DataView {
                Table = set.S_DD_IP1
            };
            UkupnoTip tip4 = new UkupnoTip {
                Primitak = DB.RoundUP(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(BRUTO)", "")))),
                IzdatakDoprinosa = DB.RoundUP(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(doprinosiIZ)", "")))),
                Izdatak = DB.RoundUP(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(izdACI)", ""))))
            };
            RacunTip[] tipArray2 = new RacunTip[0x17];
            num3 = 0;
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1465)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip20 = new RacunTip {
                    brojRacuna = "1465",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1465)", "")))
                };
                num3++;
                tipArray2[0] = tip20;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1805)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip21 = new RacunTip {
                    brojRacuna = "1805",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1805)", "")))
                };
                num3++;
                tipArray2[1] = tip21;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1457)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip22 = new RacunTip {
                    brojRacuna = "1457",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1457)", "")))
                };
                num3++;
                tipArray2[2] = tip22;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1813)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip23 = new RacunTip {
                    brojRacuna = "1813",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1813)", "")))
                };
                num3++;
                tipArray2[3] = tip23;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1473)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip24 = new RacunTip {
                    brojRacuna = "1473",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1473)", "")))
                };
                num3++;
                tipArray2[5] = tip24;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1546)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip25 = new RacunTip {
                    brojRacuna = "1546",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1546)", "")))
                };
                num3++;
                tipArray2[6] = tip25;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1570)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip26 = new RacunTip {
                    brojRacuna = "1570",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1570)", "")))
                };
                num3++;
                tipArray2[7] = tip26;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1589)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip27 = new RacunTip {
                    brojRacuna = "1589",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1589)", "")))
                };
                num3++;
                tipArray2[8] = tip27;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1597)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip28 = new RacunTip {
                    brojRacuna = "1597",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1597)", "")))
                };
                num3++;
                tipArray2[9] = tip28;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1600)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip29 = new RacunTip {
                    brojRacuna = "1600",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1600)", "")))
                };
                num3++;
                tipArray2[10] = tip29;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1821)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip30 = new RacunTip {
                    brojRacuna = "1821",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1821)", "")))
                };
                num3++;
                tipArray2[11] = tip30;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1830)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip31 = new RacunTip {
                    brojRacuna = "1830",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1830)", "")))
                };
                num3++;
                tipArray2[12] = tip31;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1848)", ""))), decimal.Zero) > 0)
            {
                RacunTip tip32 = new RacunTip {
                    brojRacuna = "1848",
                    Iznos = DB.RoundUP(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(P1848)", "")))
                };
                num3++;
                tipArray2[13] = tip32;
            }
            PorezPrirezTip tip2 = new PorezPrirezTip {
                Ukupno = DB.RoundUP(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(POREZIPRIREZ)", ""))))
            };
            tip4.IsplaceniPrimitak = decimal.Subtract(decimal.Subtract(DB.RoundUP(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(BRUTO)", "")))), DB.RoundUP(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(doprinosiIZ)", ""))))), DB.RoundUP(DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("SUM(porezIprirez)", "")))));
            tip4.PorezPrirez = tip2;
            tip4.PorezPrirez.Racuni = tipArray2;
            o.Ukupno = tip4;
            num3 = 0;
            try
            {
                string str = string.Empty;
                FolderBrowserDialog dialog = new FolderBrowserDialog {
                    SelectedPath = Conversions.ToString(0)
                };
                string str18 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]);
                string pattern = @"\+((0?0?)[1-9]|(0?[1-9]\d)|[1-9]\d{2})\([1-9]\d?\)[1-9]\d{5,6}";
                string str17 = @"[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)[a-zA-Z0-9]@[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)(\.[a-zA-Z]{2,4})";
                if (!Regex.IsMatch(Conversions.ToString(dataSet.KORISNIK.Rows[0]["EMAIL"]), str17))
                {
                    Interaction.MsgBox("Email nije upisan prema zadanoj XML shemi!", MsgBoxStyle.OkOnly, null);
                    return;
                }
                if (!Regex.IsMatch(Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]), pattern))
                {
                    Interaction.MsgBox("Telefon nije upisan prema zadanoj XML shemi!", MsgBoxStyle.OkOnly, null);
                    return;
                }
                if (!Regex.IsMatch(Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTfax"]), pattern))
                {
                    Interaction.MsgBox("Telefax nije upisan prema zadanoj XML shemi!", MsgBoxStyle.OkOnly, null);
                    return;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TextWriter textWriter = new StreamWriter(dialog.SelectedPath + @"\ID-1_" + str18 + ".XML");
                    new XmlSerializer(typeof(Id1), "dd").Serialize(textWriter, o);
                    textWriter.Close();
                }
                else
                {
                    return;
                }
                Interaction.MsgBox("Datoteka uspješno snimljena u: " + dialog.SelectedPath + @"\ID-1_" + str18 + ".XML", MsgBoxStyle.OkOnly, null);
                if (mipsed.application.framework.Application.ValidateXml(dialog.SelectedPath + @"\ID-1_" + str18 + ".XML", System.Windows.Forms.Application.StartupPath + @"\id1-obrazac_4_0.xsd", ref str18))
                {
                    Interaction.MsgBox("Datoteka je ispravna!", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    Interaction.MsgBox("Datoteka je neispravna!" + str18, MsgBoxStyle.OkOnly, null);
                }
            }
            catch (System.Exception exception3)
            {
                throw exception3;
            }

            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - ID-1 Popratni list",
                Description = "Pregled izvještaja - ID-1 Popratni list",
                Icon = ImageResourcesNew.mbs
            };
            document.Load(System.Windows.Forms.Application.StartupPath + @"\DDIzvjestaji\rptID1Popratni.rpt");
            document.SetDataSource(dataSet);
            document.SetParameterValue("brojdatoteka", 1);
            document.SetParameterValue("brojipobrazaca", num4);
            document.SetParameterValue("godina", mipsed.application.framework.Application.ActiveYear);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("f0995204-3ffe-4b7e-89ed-328c123db1e2"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("3f6dc627-cc2b-47b1-836d-ae58a25c1a6c"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("f0995204-3ffe-4b7e-89ed-328c123db1e2"), -1);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_DD_IP1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IZDACI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOPRINOSIIZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZIPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1422");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1805");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1457");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1465");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1473");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1546");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1570");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1589");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1597");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1600");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1813");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1821");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1830");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("P1848");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDJMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOZNACEN");
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._IP1SmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IP1SmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IP1SmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IP1SmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IP1SmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Location = new System.Drawing.Point(0, 18);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1070, 3);
            this.Panel2.TabIndex = 8;
            // 
            // Panel1
            // 
            this.Panel1.Location = new System.Drawing.Point(228, 166);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(107, 202);
            this.Panel1.TabIndex = 5;
            // 
            // BindingSource1
            // 
            this.BindingSource1.DataMember = "S_DD_IP1";
            this.BindingSource1.DataSource = typeof(Placa.S_DD_IP1DataSet);
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockableControlPane1.Control = this.Panel2;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(133, 209, 820, 270);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "...";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1070, 21);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _IP1SmartPartUnpinnedTabAreaLeft
            // 
            this._IP1SmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._IP1SmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IP1SmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._IP1SmartPartUnpinnedTabAreaLeft.Name = "_IP1SmartPartUnpinnedTabAreaLeft";
            this._IP1SmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 544);
            this._IP1SmartPartUnpinnedTabAreaLeft.TabIndex = 0;
            // 
            // _IP1SmartPartUnpinnedTabAreaRight
            // 
            this._IP1SmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._IP1SmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IP1SmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1070, 0);
            this._IP1SmartPartUnpinnedTabAreaRight.Name = "_IP1SmartPartUnpinnedTabAreaRight";
            this._IP1SmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 544);
            this._IP1SmartPartUnpinnedTabAreaRight.TabIndex = 1;
            // 
            // _IP1SmartPartUnpinnedTabAreaTop
            // 
            this._IP1SmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._IP1SmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IP1SmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._IP1SmartPartUnpinnedTabAreaTop.Name = "_IP1SmartPartUnpinnedTabAreaTop";
            this._IP1SmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1070, 0);
            this._IP1SmartPartUnpinnedTabAreaTop.TabIndex = 2;
            // 
            // _IP1SmartPartUnpinnedTabAreaBottom
            // 
            this._IP1SmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._IP1SmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IP1SmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 544);
            this._IP1SmartPartUnpinnedTabAreaBottom.Name = "_IP1SmartPartUnpinnedTabAreaBottom";
            this._IP1SmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._IP1SmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1070, 0);
            this._IP1SmartPartUnpinnedTabAreaBottom.TabIndex = 3;
            // 
            // _IP1SmartPartAutoHideControl
            // 
            this._IP1SmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IP1SmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._IP1SmartPartAutoHideControl.Name = "_IP1SmartPartAutoHideControl";
            this._IP1SmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._IP1SmartPartAutoHideControl.Size = new System.Drawing.Size(0, 544);
            this._IP1SmartPartAutoHideControl.TabIndex = 4;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataSource = this.BindingSource1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 15;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 16;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 17;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 18;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 19;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 20;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 21;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 22;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 23;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 24;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 25;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 1;
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
            ultraGridColumn26});
            ultraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.UltraGrid1.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.CellsOnly;
            this.UltraGrid1.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(0, 26);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1070, 518);
            this.UltraGrid1.TabIndex = 9;
            this.UltraGrid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.UltraGrid1_ClickCell);
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(1070, 26);
            this.WindowDockingArea2.TabIndex = 9;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel2);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(1070, 21);
            this.DockableWindow2.TabIndex = 10;
            // 
            // IP1SmartPart
            // 
            this.Controls.Add(this._IP1SmartPartAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._IP1SmartPartUnpinnedTabAreaRight);
            this.Name = "IP1SmartPart";
            this.Size = new System.Drawing.Size(1070, 544);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void IP1SmartPart_Load(object sender, EventArgs e)
        {
            this.POCETNI = mipsed.application.framework.Application.Pocetni;
        }

        public void iSPISI()
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            document.Load(System.Windows.Forms.Application.StartupPath + @"\ddIzvjestaji\RPTID.rpt");
            document.SetDataSource(this.ds);
            document.SetParameterValue("GODINA", this.GODINA);
            document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("adresa", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
            document.SetParameterValue("mb", dataSet.KORISNIK.Rows[0]["KORISNIKOIB"].ToString());
            document.SetParameterValue("mjesto", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
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

        [LocalCommandHandler("Ispisi")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.iSPISI();
        }

        [LocalCommandHandler("IzradiID1")]
        public void IzradiID1Handler(object sender, EventArgs e)
        {
            this.ID1Disketa();
        }

        public void Otvori()
        {
            ReportDocument document = new ReportDocument();
            frmDDPregleDGodina godina = new frmDDPregleDGodina();
            godina.ShowDialog();
            if (godina.DialogResult != DialogResult.Cancel)
            {
                this.ds.Clear();
                this.GODINA = Conversions.ToString(godina.OdabraniGodinaIsplate);
                this.d.Fill(this.ds, Conversions.ToString(godina.OdabraniGodinaIsplate));
                this.BindingSource1.DataSource = this.ds;
                this.BindingSource1.DataMember = "S_DD_IP1";
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

        [LocalCommandHandler("OtvoriGodinu")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            this.Otvori();
        }

        public AutoHideControl _IP1SmartPartAutoHideControl;

        public UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaBottom;

        public UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaLeft;

        public UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaRight;

        public UnpinnedTabArea _IP1SmartPartUnpinnedTabAreaTop;

        public BindingSource BindingSource1;

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

        public DockableWindow DockableWindow2;

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

        private Panel Panel1;

        private Panel Panel2;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

