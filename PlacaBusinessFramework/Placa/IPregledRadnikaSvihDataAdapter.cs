namespace Placa
{
    using System;
    using System.Data;

    public interface IPregledRadnikaSvihDataAdapter
    {
        int Fill(PregledRadnikaSvihDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(PregledRadnikaSvihDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

