namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_BLAGAJNA_U_GKDataAdapter
    {
        int Fill(S_FIN_BLAGAJNA_U_GKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_BLAGAJNA_U_GKDataSet dataSet, DateTime dAT1, DateTime dAT2, int bLAG);
        int FillPage(S_FIN_BLAGAJNA_U_GKDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_BLAGAJNA_U_GKDataSet dataSet, DateTime dAT1, DateTime dAT2, int bLAG, int startRow, int maxRows);
        int GetRecordCount(DateTime dAT1, DateTime dAT2, int bLAG);
    }
}

