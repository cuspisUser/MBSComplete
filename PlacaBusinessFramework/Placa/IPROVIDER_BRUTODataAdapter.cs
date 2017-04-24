namespace Placa
{
    using System;
    using System.Data;

    public interface IPROVIDER_BRUTODataAdapter
    {
        int Fill(PROVIDER_BRUTODataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(PROVIDER_BRUTODataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

