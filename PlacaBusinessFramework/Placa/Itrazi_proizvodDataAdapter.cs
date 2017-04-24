namespace Placa
{
    using System;
    using System.Data;

    public interface Itrazi_proizvodDataAdapter
    {
        int Fill(trazi_proizvodDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(trazi_proizvodDataSet dataSet, string nazivproizvod);
        int FillPage(trazi_proizvodDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(trazi_proizvodDataSet dataSet, string nazivproizvod, int startRow, int maxRows);
        int GetRecordCount(string nazivproizvod);

        string Filter { get; set; }
    }
}

