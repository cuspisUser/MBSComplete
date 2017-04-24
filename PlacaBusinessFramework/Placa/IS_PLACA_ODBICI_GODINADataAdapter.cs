namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_ODBICI_GODINADataAdapter
    {
        int Fill(S_PLACA_ODBICI_GODINADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_ODBICI_GODINADataSet dataSet, string gODINAISPLATE);
        int FillPage(S_PLACA_ODBICI_GODINADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_ODBICI_GODINADataSet dataSet, string gODINAISPLATE, int startRow, int maxRows);
        int GetRecordCount(string gODINAISPLATE);
    }
}

