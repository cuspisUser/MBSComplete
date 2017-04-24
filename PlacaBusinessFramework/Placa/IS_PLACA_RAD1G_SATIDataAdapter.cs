namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_RAD1G_SATIDataAdapter
    {
        int Fill(S_PLACA_RAD1G_SATIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_RAD1G_SATIDataSet dataSet, string gODINAOBRACUNA);
        int FillPage(S_PLACA_RAD1G_SATIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_RAD1G_SATIDataSet dataSet, string gODINAOBRACUNA, int startRow, int maxRows);
        int GetRecordCount(string gODINAOBRACUNA);
    }
}

