namespace Placa
{
    using System;
    using System.Data;

    public interface IVERZIJADataAdapter
    {
        int Fill(VERZIJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(VERZIJADataSet dataSet, short iDVERZIJA);
        bool FillByIDVERZIJA(VERZIJADataSet dataSet, short iDVERZIJA);
        int FillPage(VERZIJADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

