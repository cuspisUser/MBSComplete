namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_BILANCA_STANJA_NA_DANDataAdapter
    {
        int Fill(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet, DateTime dATUM, string sORT, short vrsta);
        int FillPage(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet, DateTime dATUM, string sORT, short vrsta, int startRow, int maxRows);
        int GetRecordCount(DateTime dATUM, string sORT, short vrsta);
    }
}

