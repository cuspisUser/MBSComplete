namespace Placa
{
    using System;
    using System.Data;

    public interface ItestDataAdapter
    {
        int Fill(testDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(testDataSet dataSet, int idtest);
        bool FillByidtest(testDataSet dataSet, int idtest);
        int FillPage(testDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

