namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_zap1DataAdapter
    {
        int Fill(sp_zap1DataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_zap1DataSet dataSet, string iDOBRACUN);
        int FillPage(sp_zap1DataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_zap1DataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

