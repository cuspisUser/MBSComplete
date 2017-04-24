namespace Placa
{
    using System;
    using System.Data;

    public interface Itrazi_partneraDataAdapter
    {
        int Fill(trazi_partneraDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(trazi_partneraDataSet dataSet, string nAZIVPARTNER);
        int FillPage(trazi_partneraDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(trazi_partneraDataSet dataSet, string nAZIVPARTNER, int startRow, int maxRows);
        int GetRecordCount(string nAZIVPARTNER);

        string Filter { get; set; }
    }
}

