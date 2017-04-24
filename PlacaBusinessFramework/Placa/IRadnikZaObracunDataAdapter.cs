namespace Placa
{
    using System;
    using System.Data;

    public interface IRadnikZaObracunDataAdapter
    {
        int Fill(RADNIKDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(RADNIKDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

