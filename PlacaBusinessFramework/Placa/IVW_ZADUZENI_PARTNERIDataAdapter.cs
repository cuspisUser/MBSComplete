namespace Placa
{
    using System;
    using System.Data;

    public interface IVW_ZADUZENI_PARTNERIDataAdapter
    {
        int Fill(VW_ZADUZENI_PARTNERIDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(VW_ZADUZENI_PARTNERIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

