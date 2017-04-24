namespace Placa
{
    using System;
    using System.Data;

    public interface IpartnerabecedaDataAdapter
    {
        int Fill(PARTNERDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(PARTNERDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

