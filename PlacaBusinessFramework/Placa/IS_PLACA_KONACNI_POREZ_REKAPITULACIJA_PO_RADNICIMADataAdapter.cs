namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter
    {
        int Fill(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet, string iDOBRACUN);
        int FillPage(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

