namespace Placa
{
    using System;
    using System.Data;

    public interface IPregledObracunaDataAdapter
    {
        int Fill(PregledObracunaDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(PregledObracunaDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

