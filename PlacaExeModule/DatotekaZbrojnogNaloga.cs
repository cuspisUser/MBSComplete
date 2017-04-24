using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NetAdvantage
{
    /// <summary>
    /// Klasa za generiranje datoteke zbrojnog naloga.
    /// Primjenjuje se od 01.01.2013.
    /// 
    /// Matija Božičević - 20.12.2012
    /// </summary>
    /// <remarks>
    /// ********************************************************
    /// LEGENDA
    /// ********************************************************
    /// M - podatak je obavezan
    /// O - podatak nije obavezan
    /// V - ovisno o ostalim podacima
    /// N - numeric - brojčano polje, znamenke pd 0 do 9
    /// C - alfanumeric - slova i znamenke od 0 do 9
    /// </remarks>
	public class DatotekaZbrojnogNaloga
    {
        /// <summary>
        /// Osnovni podaci (labela) datoteke. 
        /// Slog tipa "300" pojavljuje se samo jedanput na početku datoteke kao prvi slog u datoteci.
        /// </summary>
        /// <remarks></remarks>
        private const string SLOG_300 = "300";

        /// <summary>
        /// Vodeći slog grupe/bloka
        /// </summary>
        /// <remarks></remarks>
        private const string SLOG_301 = "301";

        /// <summary>
        /// Slog pojedinačnog naloga grupe/bloka
        /// </summary>
        /// <remarks></remarks>
        private const string SLOG_309 = "309";

        /// <summary>
        /// Zaključni slog datoteke. 
        /// Slog tipa "399" pojavljuje se samo jedanput na kraju datoteke.
        /// </summary>
        /// <remarks></remarks>
        private const string SLOG_399 = "399";

        private StringBuilder _datoteka;
        private StringBuilder DATOTEKA
        {
            get { return _datoteka; }
            set { _datoteka = value; }
        }

        private string S300VRSTNAL { get; set; }

        private enum TipPolja
        {
            /// <summary>
            /// Sva BROJČANA POLJA (NUMERIC) popunjavaju se desno poravnato i s vodećim nulama ako je podatak kraći od duljine polja.
            /// Ako podatak nije poznat, popunjavaju se sve nule u duljini polja.
            /// Za unos IZNOSA rezervirano je 15 mjesta  cijeli broj 13 znakova + 2 decimalna mjesta (bez delimitera).
            /// </summary>
            /// <remarks></remarks>
            N_Numeric,

            /// <summary>
            /// TEKSTUALNA POLJA popunjavaju se lijevo poravnato i u nastavku ostavljaju praznine ("blank") do zadane duljine ako je podatak kraći od duljine polja.
            /// </summary> 
            /// <remarks></remarks>
            C_Alfanumeric,

            MaticniBroj
        }

        private enum ObvezatnostPolja
        {
            M_Obvezno,
            O_NijeObvezno,
            V_OvisnoOOstalimPodacima
        }

        public DatotekaZbrojnogNaloga()
        {
            InicijalizirajDatoteku();
        }

        public void InicijalizirajDatoteku()
        {
            this.DATOTEKA = new StringBuilder();
        }

        /// <summary>
        /// Metoda za spremanje datoteke
        /// </summary>
        /// <param name="datumPredaje"></param>
        /// <remarks></remarks>
        public void SpremiDatoteku(DateTime datumPredaje)
        {
            // Preporučeni naziv datoteke je "UNggggmmdd.txt"
            string nazivDatoteke = string.Format("UN{0:yyyy}{0:MM}{0:dd}.txt", datumPredaje);

            // BrowserDialog za folder...
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (!Directory.Exists(@"A:\"))
            {
                if (MessageBox.Show("Jeste li ubacili disketu u disketni pogon?", "Zbrojni nalog", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    folderBrowser.SelectedPath = "A:";
                }
            }
            else
            {
                folderBrowser.SelectedPath = "A:";
            }

            // Ako je korisnik kliknuo OK, postavi putanju za spremanje sa odabranim folder-om
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = null;

                try
                {
                    nazivDatoteke = folderBrowser.SelectedPath + "\\" + nazivDatoteke;

                    streamWriter = new StreamWriter(nazivDatoteke, false, Encoding.GetEncoding("Windows-1250"));

                    // SPREMI datoteku...
                    streamWriter.Write(this.DATOTEKA.ToString());

                    MessageBox.Show(string.Format("Datoteka '{0}' je uspješno spremljena!", nazivDatoteke));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška u spremanju datoteke {0}!" + Environment.NewLine + Environment.NewLine + ex.Message, nazivDatoteke);
                }
                finally
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                    streamWriter = null;
                }
            }
        }

        /// <summary>
        /// Metoda za generiranje sloga 300
        /// </summary>
        /// <param name="S300DATSL">Datum podnošenja / slanja datoteke</param>
        /// <param name="S300VRSTNAL">Vrsta naloga u datoteci</param>
        /// <param name="S300IZDOK">Izvor dokumenta</param>
        /// <param name="S300NACIZVR">Način izvršenja</param>
        /// <param name="S300OIBPOS">OIB poslodavca</param>
        /// <param name="S300MBRPOS">Matični broj i podbroj poslodavca</param>
        /// <param name="S300INSIFPOS">Interna šifra poslodavca</param>
        /// <param name="S300OIBUPL">OIU uplatitelja osobnog primanja</param>
        /// <param name="S300REZERVA">Rezerva</param>
        /// <remarks></remarks>
        public void GenerirajSLOG_300(DateTime S300DATSL, string S300VRSTNAL, string S300IZDOK, string S300NACIZVR, string S300OIBPOS, string S300MBRPOS, string S300INSIFPOS, 
            string S300OIBUPL, string S300REZERVA)
        {
            this.S300VRSTNAL = S300VRSTNAL;

            string slog = null;

            slog = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}", 
                GenerirajVrijednost(S300DATSL.ToString("yyyyMMdd"), TipPolja.N_Numeric, 8, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S300VRSTNAL, TipPolja.N_Numeric, 1, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S300IZDOK, TipPolja.N_Numeric, 3, ObvezatnostPolja.O_NijeObvezno),
                GenerirajVrijednost(S300NACIZVR, TipPolja.N_Numeric, 1, (this.S300VRSTNAL == "4" ? ObvezatnostPolja.M_Obvezno : ObvezatnostPolja.O_NijeObvezno)),
                GenerirajVrijednost(S300OIBPOS, TipPolja.N_Numeric, 11, (this.S300VRSTNAL == "4" ? ObvezatnostPolja.M_Obvezno : ObvezatnostPolja.O_NijeObvezno)),
                GenerirajVrijednost(S300MBRPOS, TipPolja.MaticniBroj, 11, (this.S300VRSTNAL == "4" ? ObvezatnostPolja.M_Obvezno : ObvezatnostPolja.O_NijeObvezno)),
                GenerirajVrijednost(S300INSIFPOS, TipPolja.N_Numeric, 11, ObvezatnostPolja.O_NijeObvezno), // predhodna 2 polja su obavezna
                GenerirajVrijednost(S300OIBUPL, TipPolja.N_Numeric, 11, (this.S300VRSTNAL == "4" ? ObvezatnostPolja.M_Obvezno : ObvezatnostPolja.O_NijeObvezno)),
                GenerirajVrijednost(S300REZERVA, TipPolja.C_Alfanumeric, 940, ObvezatnostPolja.O_NijeObvezno), 
                SLOG_300);

            this.DATOTEKA.Append(slog + Microsoft.VisualBasic.ControlChars.CrLf);

        }

        /// <summary>
        /// Metoda za generiranje sloga 301
        /// </summary>
        /// <param name="S301IBANPLAT">IBAN platitelja</param>
        /// <param name="S301VALPL">Oznaka valute plaćanja</param>
        /// <param name="S301RNNAK">Račun naknade</param>
        /// <param name="S301VALNAK">Oznaka valute naknade</param>
        /// <param name="S301BRNALUK">Ukupan broj naloga u sljedećoj grupi (slogovi309)</param>
        /// <param name="S301IZNNALUK">Ukupan iznos naloga u sljedećoj grupi (slogovi309)</param>
        /// <param name="S301DATIIZVR">Datum izvršenja naloga</param>
        /// <param name="S301REZERVA">Rezerva</param>
        /// <remarks></remarks>
        public void GenerirajSLOG_301(string S301IBANPLAT, string S301VALPL, string S301RNNAK, string S301VALNAK, string S301BRNALUK, string S301IZNNALUK, DateTime S301DATIIZVR, string S301REZERVA)
        {
            string slog = null;

            slog = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", 
                GenerirajVrijednost(S301IBANPLAT, TipPolja.C_Alfanumeric, 21, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S301VALPL, TipPolja.C_Alfanumeric, 3, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S301RNNAK, TipPolja.C_Alfanumeric, 21, ObvezatnostPolja.O_NijeObvezno), 
                GenerirajVrijednost(S301VALNAK, TipPolja.C_Alfanumeric, 3, ObvezatnostPolja.O_NijeObvezno), 
                GenerirajVrijednost(S301BRNALUK, TipPolja.N_Numeric, 5, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S301IZNNALUK, TipPolja.N_Numeric, 20, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S301DATIIZVR.ToString("yyyyMMdd"), TipPolja.N_Numeric, 8, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S301REZERVA, TipPolja.C_Alfanumeric, 916, ObvezatnostPolja.O_NijeObvezno), 
                SLOG_301);

            this.DATOTEKA.Append(slog + Microsoft.VisualBasic.ControlChars.CrLf);

        }

        /// <summary>
        /// Metoda za generiranje sloga 309
        /// </summary>
        /// <param name="S309IBANRNPRIM">IBAN ili račun primatelja</param>
        /// <param name="S309NAZIVPRIM">Naziv primatelja</param>
        /// <param name="S309ADRPRIM">Adresa primatelja</param>
        /// <param name="S309SJEDPRIM">Sjedište primatelja</param>
        /// <param name="S309SFZEMPRIM">Šifra zemlje primatelja</param>
        /// <param name="S309BRMODPLAT">Broj modela platitelja</param>
        /// <param name="S309PNBPLAT">Poziv na broj platitelja</param>
        /// <param name="S309SIFNAM">Šifra namjene</param>
        /// <param name="S309OPISPL">Opis plaćanja</param>
        /// <param name="S309IZN">Iznos</param>
        /// <param name="S309BRMODPRIM">Broj modela primatelja</param>
        /// <param name="S309PNBPRIM">Poziv na broj primatelja</param>
        /// <param name="S309BICBANPRIM">BIC (SWIFT) adresa</param>
        /// <param name="S309NAZBANPRIM">Naziv banke primatelja</param>
        /// <param name="S309ADRBNPRIM">Adresa banke primatelja</param>
        /// <param name="S309SJEDBNPRIM">Sjedište banke primatelja</param>
        /// <param name="S309SFZEMBNPRIM">Šifra zemlje banke primatelja</param>
        /// <param name="S309VRSTAPRIM">Vrsta strane osobe</param>
        /// <param name="S309VALPOKR">Valuta pokrića</param>
        /// <param name="S309TROSOP">Troškovna opcija</param>
        /// <param name="S309OZNHITN">Oznaka hitnosti</param>
        /// <param name="S309SIFPRIM">Šifra vrste osobnog primanja</param>
        /// <param name="S309REZERVA">Rezerva</param>
        /// <remarks></remarks>
        public void GenerirajSLOG_309(string S309IBANRNPRIM, string S309NAZIVPRIM, string S309ADRPRIM, string S309SJEDPRIM, string S309SFZEMPRIM, string S309BRMODPLAT, string S309PNBPLAT, 
            string S309SIFNAM, string S309OPISPL, string S309IZN, string S309BRMODPRIM, string S309PNBPRIM, string S309BICBANPRIM, string S309NAZBANPRIM, string S309ADRBNPRIM, string S309SJEDBNPRIM, 
            string S309SFZEMBNPRIM, string S309VRSTAPRIM, string S309VALPOKR, string S309TROSOP, string S309OZNHITN, string S309SIFPRIM, string S309REZERVA)
        {
            string slog = null;

            slog = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}{20}{21}{22}{23}", 
                GenerirajVrijednost(S309IBANRNPRIM, TipPolja.C_Alfanumeric, 34, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S309NAZIVPRIM, TipPolja.C_Alfanumeric, 70, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S309ADRPRIM, TipPolja.C_Alfanumeric, 35, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309SJEDPRIM, TipPolja.C_Alfanumeric, 35, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309SFZEMPRIM, TipPolja.N_Numeric, 3, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309BRMODPLAT, TipPolja.C_Alfanumeric, 4, ObvezatnostPolja.O_NijeObvezno), 
                GenerirajVrijednost(S309PNBPLAT, TipPolja.C_Alfanumeric, 22, ObvezatnostPolja.O_NijeObvezno), 
                GenerirajVrijednost(S309SIFNAM, TipPolja.C_Alfanumeric, 4, ObvezatnostPolja.O_NijeObvezno), 
                GenerirajVrijednost(S309OPISPL, TipPolja.C_Alfanumeric, 140, ObvezatnostPolja.M_Obvezno),
                GenerirajVrijednost(S309IZN, TipPolja.N_Numeric, 15, ObvezatnostPolja.M_Obvezno), 
                GenerirajVrijednost(S309BRMODPRIM, TipPolja.C_Alfanumeric, 4, ObvezatnostPolja.O_NijeObvezno), 
                GenerirajVrijednost(S309PNBPRIM, TipPolja.C_Alfanumeric, 22, ObvezatnostPolja.O_NijeObvezno), 
                GenerirajVrijednost(S309BICBANPRIM, TipPolja.C_Alfanumeric, 11, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309NAZBANPRIM, TipPolja.C_Alfanumeric, 70, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309ADRBNPRIM, TipPolja.C_Alfanumeric, 35, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309SJEDBNPRIM, TipPolja.C_Alfanumeric, 35, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309SFZEMBNPRIM, TipPolja.N_Numeric, 3, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309VRSTAPRIM, TipPolja.N_Numeric, 1, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309VALPOKR, TipPolja.C_Alfanumeric, 3, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309TROSOP, TipPolja.N_Numeric, 1, ObvezatnostPolja.V_OvisnoOOstalimPodacima), 
                GenerirajVrijednost(S309OZNHITN, TipPolja.N_Numeric, 1, ObvezatnostPolja.O_NijeObvezno),
                GenerirajVrijednost(S309SIFPRIM, TipPolja.N_Numeric, 3, (this.S300VRSTNAL == "4" ? ObvezatnostPolja.M_Obvezno : ObvezatnostPolja.O_NijeObvezno)),
                GenerirajVrijednost(S309REZERVA, TipPolja.C_Alfanumeric, 446, ObvezatnostPolja.O_NijeObvezno), 
                SLOG_309);

            this.DATOTEKA.Append(slog + Microsoft.VisualBasic.ControlChars.CrLf);

        }

        /// <summary>
        /// Metoda za generiranje sloga 399
        /// </summary>
        /// <param name="S399REZERVA">Rezerva</param>
        /// <remarks></remarks>
        public void GenerirajSLOG_399(string S399REZERVA)
        {
            string slog = null;

            slog = string.Format("{0}{1}", 
                GenerirajVrijednost(S399REZERVA, TipPolja.C_Alfanumeric, 997, ObvezatnostPolja.O_NijeObvezno), 
                SLOG_399);

            this.DATOTEKA.Append(slog + Microsoft.VisualBasic.ControlChars.CrLf);

        }

        private string GenerirajVrijednost(string vrijednost, TipPolja tipPolja, int duljina, ObvezatnostPolja obvezno)
        {
            // provjera NULL
            if (object.ReferenceEquals(vrijednost, DBNull.Value) | vrijednost == null)
            {
                vrijednost = string.Empty;
            }

            // mičemo razmake
            vrijednost = vrijednost.Trim();

            // provjera obveznosti polja

            if (obvezno == ObvezatnostPolja.M_Obvezno)
            {
                if (vrijednost == string.Empty)
                {
                    throw new Exception("GREŠKA (Datoteka zbrojnog naloga): polje je označeno kao OBAVEZNO, ali nema vrijednosti!");
                }
            }


            // kratimo vrijednost ukoliko je DULJA od predviđene/dozvoljene duljine
            if (vrijednost.Length > duljina)
            {
                vrijednost = vrijednost.Substring(0, duljina);
            }

            if (tipPolja == DatotekaZbrojnogNaloga.TipPolja.C_Alfanumeric)
            {
                // slova lijevo, spaces desno
                vrijednost = vrijednost.PadRight(duljina, ' ');
            }
            else if (tipPolja == DatotekaZbrojnogNaloga.TipPolja.N_Numeric)
            {
                // vrijednost desno, nule lijevo
                vrijednost = vrijednost.PadLeft(duljina, '0');
            }
            else if (tipPolja == DatotekaZbrojnogNaloga.TipPolja.MaticniBroj)
            {
                // slova lijevo, spaces desno
                vrijednost = vrijednost.PadRight(duljina, '0');
            }

            if (vrijednost.Length != duljina)
            {
                throw new Exception("GREŠKA (Datoteka zbrojnog naloga): duljina vrijednosti NE odgovara propisanoj duljini!");
            }

            return vrijednost;

        }
	}
}
