namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_TABLICA01DataAdapter
    {
        int Fill(S_OD_TABLICA01DataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_TABLICA01DataSet dataSet, string gODINA);
        int FillPage(S_OD_TABLICA01DataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_TABLICA01DataSet dataSet, string gODINA, int startRow, int maxRows);
        int GetRecordCount(string gODINA);
    }
}

