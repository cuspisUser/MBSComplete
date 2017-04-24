namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_PARTNERI_SA_OTVORENIMADataAdapter
    {
        int Fill(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet, int godina);
        int FillPage(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet, int godina, int startRow, int maxRows);
        int GetRecordCount(int godina);
    }
}

