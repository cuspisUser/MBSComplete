using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class IBAN
{
    /// <summary>
    /// Dio dvoslovne oznake za Republiku Hrvatsku - PRVI dio
    /// </summary>
    private readonly string H = "17";

    /// <summary>
    /// Dio dvoslovne oznake za Republiku Hrvatsku - DRUGI dio
    /// </summary>
    private readonly string R = "27";

    /// <summary>
    /// Funkcija za generiranje IBAN-a iz forme VBDI-BrojRacuna
    /// </summary>
    /// <param name="brojRacuna">Kompletan broj računa - VBDI i broj računa.</param>
    /// <param name="ibanNijeIspravanIzbaciExceptionPoruku">Ukoliko je IBAN neispravan, prikaži MessageBox.</param>
    /// <param name="razdjeliIBAN">Razdjeli IBAN na skupine od po 4 znaka. Rezultat - HRCC AAAAA AAAB BBBB BBBB B.</param>
    /// <returns></returns>
    public string GenerirajIBANIzBrojaRacuna(string brojRacuna, bool ibanNijeIspravanIzbaciExceptionPoruku = false, bool razdjeliIBAN = false)
    {
        string iban;
        string kontrolniBroj;
        string ostatak;

        //temp variables
        Int64 tmp;

        // mičemo "-" između VBDI-a i broj računa
        brojRacuna = brojRacuna.Replace("-", string.Empty);

        // ako broj računa nije sačinjen samo od brojeva, vratiti prazan string
        if (!Int64.TryParse(brojRacuna, out tmp))
        {
            return string.Empty;
        }

        // START

        // 1.) AAAAAAABBBBBBBBBBHR00
        iban  = brojRacuna + H + R + "00";

        // 2.) dobiveni broj se dijeli sa 97, te se uzima OSTATAK (MODULO operacija)
        // OBAVEZNO koristiti decimal, pošto double sa MODULO operacijom ne radi - tj. vraća krive podatke!!!
        ostatak = (decimal.Parse(iban) % (decimal)97).ToString();

        // 3.) ostatak treba oduzeti od (97 + 1)
        kontrolniBroj = ((97 + 1) - int.Parse(ostatak)).ToString();

        // 4.) ako je rezultat manji od 10, dobivenom broju će prethoditi "0" (nula)
        if (int.Parse(kontrolniBroj) < 10)
        {
            kontrolniBroj = "0" + kontrolniBroj;
        }

        // PRAVILNA konstrukcija IBAN-a
        iban = "HR" + kontrolniBroj + brojRacuna;

        // ------------------------------------------------------------------------------------
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // OBAVEZNO prije slanja IBAN-a napraviti VALIDACIJU, da li je IBAN pravilno generiran
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // ------------------------------------------------------------------------------------
        
        // VALIDACIJA
        if (!IBANValidacija(brojRacuna + H + R + kontrolniBroj))
        {
            if (ibanNijeIspravanIzbaciExceptionPoruku)
            {
                throw new Exception(string.Format("IBAN '{0}' nije ispravan!", iban));
            }

            return string.Empty;
        }

        // Razdjeli IBAN - pri unosu u platne naloge na papirnatom mediju svaka četiri znaka trebaju biti odijeljena jednim preznim poljem (blank).
        if (razdjeliIBAN && iban.Length == 21)
        {
            iban = iban.Insert(4, " ");
            iban = iban.Insert(9, " ");
            iban = iban.Insert(14, " ");
            iban = iban.Insert(19, " ");
            iban = iban.Insert(24, " ");
        }

        return iban;
    }

    /// <summary>
    /// Funkcija koja validira ispravnost IBAN-a
    /// </summary>
    /// <param name="iban">IBAN u formatu AAAAAAABBBBBBBBBBHRCC. Originalan format IBAN-a neće proći validaciju!</param>
    /// <returns></returns>
    public bool IBANValidacija(string iban)
    {
        string ostatak = (decimal.Parse(iban) % (decimal)97).ToString();

        return (ostatak == "1");
    }
}
