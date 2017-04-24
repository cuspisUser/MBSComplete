namespace Placa
{
    using System;
    using System.Data;

    public interface IuraDocsDataAdapter
    {
        int Fill(DOKUMENTDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(DOKUMENTDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

