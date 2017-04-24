namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter
    {
        int Fill(S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
    }
}

