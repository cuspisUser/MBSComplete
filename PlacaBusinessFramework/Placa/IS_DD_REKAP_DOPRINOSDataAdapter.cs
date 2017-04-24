namespace Placa
{
    using System;
    using System.Data;

    public interface IS_DD_REKAP_DOPRINOSDataAdapter
    {
        int Fill(S_DD_REKAP_DOPRINOSDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_DD_REKAP_DOPRINOSDataSet dataSet, string iDOBRACUN);
        int FillPage(S_DD_REKAP_DOPRINOSDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_DD_REKAP_DOPRINOSDataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

