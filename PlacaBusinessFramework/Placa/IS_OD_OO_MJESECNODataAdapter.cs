namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_OO_MJESECNODataAdapter
    {
        int Fill(S_OD_OO_MJESECNODataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_OO_MJESECNODataSet dataSet, string iDOBRACUN);
        int FillPage(S_OD_OO_MJESECNODataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_OO_MJESECNODataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

