namespace Placa
{
    using System;
    using System.Data;

    public interface IPROVIDER_NETODataAdapter
    {
        int Fill(PROVIDER_NETODataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(PROVIDER_NETODataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

