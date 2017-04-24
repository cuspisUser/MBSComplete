namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_RSOBRAZACDataAdapter
    {
        int Fill(sp_RSOBRAZACDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_RSOBRAZACDataSet dataSet, string iDOBRACUN, short dd);
        int FillPage(sp_RSOBRAZACDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_RSOBRAZACDataSet dataSet, string iDOBRACUN, short dd, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN, short dd);
    }
}

