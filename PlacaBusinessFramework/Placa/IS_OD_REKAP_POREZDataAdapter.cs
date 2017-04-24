namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_REKAP_POREZDataAdapter
    {
        int Fill(S_OD_REKAP_POREZDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_REKAP_POREZDataSet dataSet, string iDOBRACUN);
        int FillPage(S_OD_REKAP_POREZDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_REKAP_POREZDataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

