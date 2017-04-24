namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_TABLICA018DataAdapter
    {
        int Fill(S_PLACA_TABLICA018DataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_TABLICA018DataSet dataSet, string gODINAOBRACUNA);
        int FillPage(S_PLACA_TABLICA018DataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_TABLICA018DataSet dataSet, string gODINAOBRACUNA, int startRow, int maxRows);
        int GetRecordCount(string gODINAOBRACUNA);
    }
}

