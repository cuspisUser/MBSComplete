namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_DNEVNIKBLAGAJNEDataAdapter
    {
        int Fill(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet, DateTime dat1, DateTime dat2, int blag);
        int FillPage(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet, DateTime dat1, DateTime dat2, int blag, int startRow, int maxRows);
        int GetRecordCount(DateTime dat1, DateTime dat2, int blag);
    }
}

