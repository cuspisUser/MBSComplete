namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_PROSJEK_PLACEDataAdapter
    {
        int Fill(S_OD_PROSJEK_PLACEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_PROSJEK_PLACEDataSet dataSet, string oDD, string dOOO, int iDRADNIK);
        int FillPage(S_OD_PROSJEK_PLACEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_PROSJEK_PLACEDataSet dataSet, string oDD, string dOOO, int iDRADNIK, int startRow, int maxRows);
        int GetRecordCount(string oDD, string dOOO, int iDRADNIK);
    }
}

