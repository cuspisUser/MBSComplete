namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_REKAP_NETODataAdapter
    {
        int Fill(S_OD_REKAP_NETODataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_REKAP_NETODataSet dataSet, string iDOBRACUN);
        int FillPage(S_OD_REKAP_NETODataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_REKAP_NETODataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

