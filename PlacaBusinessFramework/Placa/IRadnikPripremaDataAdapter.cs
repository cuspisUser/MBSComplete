namespace Placa
{
    using System;
    using System.Data;

    public interface IRadnikPripremaDataAdapter
    {
        int Fill(RadnikPripremaDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(RadnikPripremaDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

