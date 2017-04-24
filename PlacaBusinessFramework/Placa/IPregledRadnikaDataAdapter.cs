namespace Placa
{
    using System;
    using System.Data;

    public interface IPregledRadnikaDataAdapter
    {
        int Fill(PregledRadnikaDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(PregledRadnikaDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

