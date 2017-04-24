namespace Placa
{
    using System;
    using System.Data;

    public interface IS_DD_IPPDataAdapter
    {
        int Fill(S_DD_IPPDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_DD_IPPDataSet dataSet, string mJESEC, string gODINA);
        int FillPage(S_DD_IPPDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_DD_IPPDataSet dataSet, string mJESEC, string gODINA, int startRow, int maxRows);
        int GetRecordCount(string mJESEC, string gODINA);
    }
}

