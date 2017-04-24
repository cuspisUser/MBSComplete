namespace Placa
{
    using System;
    using System.Data;

    public interface IS_DD_POTVRDADataAdapter
    {
        int Fill(S_DD_POTVRDADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_DD_POTVRDADataSet dataSet, string gODINAISPLATE);
        int FillPage(S_DD_POTVRDADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_DD_POTVRDADataSet dataSet, string gODINAISPLATE, int startRow, int maxRows);
        int GetRecordCount(string gODINAISPLATE);
    }
}

