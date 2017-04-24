namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_BROJ_I_DATUMDataAdapter
    {
        int Fill(S_OS_BROJ_I_DATUMDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(S_OS_BROJ_I_DATUMDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
    }
}

