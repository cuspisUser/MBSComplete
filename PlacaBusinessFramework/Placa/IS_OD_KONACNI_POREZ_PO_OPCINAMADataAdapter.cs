namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter
    {
        int Fill(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet, string idobracun);
        int FillPage(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet, string idobracun, int startRow, int maxRows);
        int GetRecordCount(string idobracun);
    }
}

