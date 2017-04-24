namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_KONACNIDataAdapter
    {
        int Fill(S_OD_KONACNIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_KONACNIDataSet dataSet, int gODINA, string iDOBRACUN);
        int FillPage(S_OD_KONACNIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_KONACNIDataSet dataSet, int gODINA, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(int gODINA, string iDOBRACUN);
    }
}

