namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_BOLOVANJE_FONDDataAdapter
    {
        int Fill(S_OD_BOLOVANJE_FONDDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_BOLOVANJE_FONDDataSet dataSet, string oDD, string dOOO, int idradnik);
        int FillPage(S_OD_BOLOVANJE_FONDDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_BOLOVANJE_FONDDataSet dataSet, string oDD, string dOOO, int idradnik, int startRow, int maxRows);
        int GetRecordCount(string oDD, string dOOO, int idradnik);
    }
}

