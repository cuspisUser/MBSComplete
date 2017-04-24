namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_IPPDataAdapter
    {
        int Fill(S_OD_IPPDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_IPPDataSet dataSet, string mjesec, string godina);
        int FillPage(S_OD_IPPDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_IPPDataSet dataSet, string mjesec, string godina, int startRow, int maxRows);
        int GetRecordCount(string mjesec, string godina);
    }
}

